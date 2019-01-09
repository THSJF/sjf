// Decompiled with JetBrains decompiler
// Type: THMHJ.Effects
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace THMHJ
{
  internal class Effects
  {
    public static float theta;
    public static float BlackWhite;
    private static bool effectchange;
    private static float origin;
    private static float target;
    private static int time;

    public static void Init()
    {
      Effects.theta = 0.1f;
      Effects.BlackWhite = 0.0f;
    }

    public static void SetforceParameters(Effect effect, int time, float x, float y)
    {
      effect.Parameters["fTimer"].SetValue(time);
      effect.Parameters[nameof (x)].SetValue(x);
      effect.Parameters[nameof (y)].SetValue(y);
      effect.Parameters["stop"].SetValue(1);
    }

    public static void SetForceParameters(Effect effect, float stop)
    {
      effect.Parameters[nameof (stop)].SetValue(stop);
    }

    public static void SetblurParameters(Effect effect, float dx, float dy)
    {
      EffectParameter parameter1 = effect.Parameters["SampleWeights"];
      EffectParameter parameter2 = effect.Parameters["SampleOffsets"];
      EffectParameter parameter3 = effect.Parameters["BlackWhite"];
      int count = parameter1.Elements.Count;
      float[] numArray = new float[count];
      Vector2[] vector2Array = new Vector2[count];
      numArray[0] = Effects.ComputeGaussian(0.0f);
      vector2Array[0] = new Vector2(0.0f);
      float num1 = numArray[0];
      for (int index = 0; index < count / 2; ++index)
      {
        float gaussian = Effects.ComputeGaussian((float) (index + 1));
        numArray[index * 2 + 1] = gaussian;
        numArray[index * 2 + 2] = gaussian;
        num1 += gaussian * 2f;
        float num2 = (float) (index * 2) + 1.5f;
        Vector2 vector2 = new Vector2(dx, dy) * num2;
        vector2Array[index * 2 + 1] = vector2;
        vector2Array[index * 2 + 2] = -vector2;
      }
      for (int index = 0; index < numArray.Length; ++index)
        numArray[index] /= num1;
      parameter1.SetValue(numArray);
      parameter2.SetValue(vector2Array);
      parameter3.SetValue(Effects.BlackWhite);
    }

    private static float ComputeGaussian(float n)
    {
      return (float) (1.0 / Math.Sqrt(2.0 * Math.PI) * (double) Effects.theta * Math.Exp(-((double) n * (double) n) / (2.0 * (double) Effects.theta * (double) Effects.theta)));
    }

    public static float Getthetaa()
    {
      return Effects.theta;
    }

    public static void Changetheta(float tg, int t)
    {
      Effects.effectchange = true;
      Effects.origin = Effects.theta;
      Effects.target = tg;
      Effects.time = t;
    }

    public static void ChangeUpdate()
    {
      if (!Effects.effectchange)
        return;
      Effects.theta += (Effects.target - Effects.origin) / (float) Effects.time;
      if ((double) Math.Abs(Effects.theta - Effects.target) >= 1.0 / 1000.0)
        return;
      Effects.effectchange = false;
      Effects.theta = Effects.target;
    }
  }
}
