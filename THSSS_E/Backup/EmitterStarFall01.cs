// Decompiled with JetBrains decompiler
// Type: Shooting.EmitterStarFall01
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class EmitterStarFall01 : BaseEffect
  {
    public EmitterStarFall01(StageDataPackage StageData, PointF OriginalPosition)
      : base(StageData, (string) null, OriginalPosition, 0.0f, 0.0)
    {
      this.Velocity = 4f;
      this.MaxVelocity = 8f;
      this.LifeTime = this.Ran.Next(120, 160);
      this.DirectionDegree = (double) this.Ran.Next(140, 150);
      this.ScaleLengthVelocityDictionary.Add(this.LifeTime - 50, -0.02f);
    }

    public override void Shoot()
    {
      for (int index = 0; index < 3; ++index)
      {
        float num1 = 0.0f;
        double num2 = (double) this.Ran.Next(360) * Math.PI / 180.0;
        PointF Position;
        ref PointF local = ref Position;
        PointF originalPosition = this.OriginalPosition;
        double num3 = (double) originalPosition.X + (double) num1 * Math.Sin(num2);
        originalPosition = this.OriginalPosition;
        double num4 = (double) originalPosition.Y + (double) num1 * Math.Cos(num2);
        local = new PointF((float) num3, (float) num4);
        ParticleTitleStar particleTitleStar = new ParticleTitleStar(this.StageData, "Star", Position, (float) this.StageData.Ran.Next(1, 200) / 1000f, (double) this.Ran.Next(360) * Math.PI / 180.0);
        particleTitleStar.Active = true;
        particleTitleStar.Scale = (float) this.StageData.Ran.Next(40, 200) / 1000f * this.Scale;
        particleTitleStar.LifeTime = 80;
      }
    }
  }
}
