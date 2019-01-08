// Decompiled with JetBrains decompiler
// Type: Shooting.Execution
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  [Serializable]
  public class Execution
  {
    public int parentid;
    public int id;
    public int change;
    public int changetype;
    public int changevalue;
    public string region;
    public float value;
    public int time;
    public int ctime;

    public void Update(BaseEmitter_CS objects)
    {
      switch (this.changevalue)
      {
        case 0:
          PointF csPosition1 = objects.CS_Position;
          float x = csPosition1.X;
          BaseEmitter_CS baseEmitterCs1 = objects;
          double num1 = (double) this.ChangeValue(x);
          csPosition1 = objects.CS_Position;
          double y1 = (double) csPosition1.Y;
          PointF pointF1 = new PointF((float) num1, (float) y1);
          baseEmitterCs1.CS_Position = pointF1;
          break;
        case 1:
          PointF csPosition2 = objects.CS_Position;
          float y2 = csPosition2.Y;
          BaseEmitter_CS baseEmitterCs2 = objects;
          csPosition2 = objects.CS_Position;
          PointF pointF2 = new PointF(csPosition2.X, this.ChangeValue(y2));
          baseEmitterCs2.CS_Position = pointF2;
          break;
        case 2:
          objects.EmitRadius = this.ChangeValue(objects.EmitRadius);
          break;
        case 3:
          objects.RadiusDirection = this.ChangeValue(objects.RadiusDirection);
          break;
        case 4:
          objects.Way = this.ChangeValue(objects.Way);
          break;
        case 5:
          objects.Circle = this.ChangeValue(objects.Circle);
          break;
        case 6:
          objects.EmitDirection = this.ChangeValue(objects.EmitDirection);
          break;
        case 7:
          objects.Range = this.ChangeValue(objects.Range);
          break;
        case 8:
          objects.Velocity = this.ChangeValue(objects.Velocity);
          break;
        case 9:
          objects.DirectionDegree = this.ChangeValue(objects.DirectionDegree);
          break;
        case 10:
          objects.AccelerateCS = this.ChangeValue(objects.AccelerateCS);
          break;
        case 11:
          objects.AccDirection = this.ChangeValue(objects.AccDirection);
          break;
        case 12:
          objects.SubBullet.LifeTime = this.ChangeValue(objects.SubBullet.LifeTime);
          break;
        case 13:
          objects.SubBullet.Type = this.ChangeValue(objects.SubBullet.Type);
          break;
        case 14:
          objects.SubBullet.ScaleWidth = this.ChangeValue(objects.SubBullet.ScaleWidth);
          break;
        case 15:
          objects.SubBullet.ScaleLength = this.ChangeValue(objects.SubBullet.ScaleLength);
          break;
        case 16:
          int num2 = this.ChangeValue((int) objects.SubBullet.ColorValue.R);
          int num3 = num2 < 0 ? 0 : num2;
          int red = num3 > (int) byte.MaxValue ? (int) byte.MaxValue : num3;
          objects.SubBullet.ColorValue = Color.FromArgb(red, (int) objects.SubBullet.ColorValue.G, (int) objects.SubBullet.ColorValue.B);
          break;
        case 17:
          int num4 = this.ChangeValue((int) objects.SubBullet.ColorValue.G);
          int num5 = num4 < 0 ? 0 : num4;
          int green = num5 > (int) byte.MaxValue ? (int) byte.MaxValue : num5;
          objects.SubBullet.ColorValue = Color.FromArgb((int) objects.SubBullet.ColorValue.R, green, (int) objects.SubBullet.ColorValue.B);
          break;
        case 18:
          int num6 = this.ChangeValue((int) objects.SubBullet.ColorValue.B);
          int num7 = num6 < 0 ? 0 : num6;
          int blue = num7 > (int) byte.MaxValue ? (int) byte.MaxValue : num7;
          objects.SubBullet.ColorValue = Color.FromArgb((int) objects.SubBullet.ColorValue.R, (int) objects.SubBullet.ColorValue.G, blue);
          break;
        case 19:
          objects.SubBullet.TransparentValueF = this.ChangeValue(objects.SubBullet.TransparentValueF);
          break;
        case 20:
          objects.SubBullet.AngleDegree = this.ChangeValue(objects.SubBullet.AngleDegree);
          break;
        case 21:
          objects.SubBullet.Velocity = this.ChangeValue(objects.SubBullet.Velocity);
          break;
        case 22:
          objects.SubBullet.DirectionDegree = this.ChangeValue(objects.SubBullet.DirectionDegree);
          break;
        case 23:
          objects.SubBullet.AccelerateCS = this.ChangeValue(objects.SubBullet.AccelerateCS);
          break;
        case 24:
          objects.SubBullet.AccDirection = this.ChangeValue(objects.SubBullet.AccDirection);
          break;
        case 25:
          objects.SubBullet.ScaleX = this.ChangeValue(objects.SubBullet.ScaleX);
          break;
        case 26:
          objects.SubBullet.ScaleY = this.ChangeValue(objects.SubBullet.ScaleY);
          break;
        case 27:
          objects.SubBullet.BeginningEffect = (double) this.value > 0.0;
          break;
        case 28:
          objects.SubBullet.EndingEffect = (double) this.value > 0.0;
          break;
        case 29:
          objects.SubBullet.Active = (double) this.value > 0.0;
          break;
        case 30:
          objects.SubBullet.Ghosting = (double) this.value > 0.0;
          break;
        case 31:
          objects.SubBullet.OutBound = (double) this.value > 0.0;
          break;
        case 32:
          objects.SubBullet.UnRemoveable = (double) this.value > 0.0;
          break;
      }
      --this.ctime;
      if (!(this.changetype == 2 & this.ctime == -1) && !(this.changetype != 2 & this.ctime == 0))
        return;
      objects.EventsExecutionList.Remove(this);
    }

    public void Update(BaseObject_CS objects)
    {
      switch (this.changevalue)
      {
        case 0:
          objects.LifeTime = this.ChangeValue(objects.LifeTime);
          break;
        case 1:
          objects.Type = this.ChangeValue(objects.Type);
          break;
        case 2:
          objects.ScaleWidth = this.ChangeValue(objects.ScaleWidth);
          break;
        case 3:
          objects.ScaleLength = this.ChangeValue(objects.ScaleLength);
          break;
        case 4:
          Color colorValue1 = objects.ColorValue;
          int num1 = this.ChangeValue((int) colorValue1.R);
          int num2 = num1 < 0 ? 0 : num1;
          int num3 = num2 > (int) byte.MaxValue ? (int) byte.MaxValue : num2;
          BaseObject_CS baseObjectCs1 = objects;
          int red = num3;
          colorValue1 = objects.ColorValue;
          int g1 = (int) colorValue1.G;
          colorValue1 = objects.ColorValue;
          int b1 = (int) colorValue1.B;
          Color color1 = Color.FromArgb(red, g1, b1);
          baseObjectCs1.ColorValue = color1;
          break;
        case 5:
          Color colorValue2 = objects.ColorValue;
          int num4 = this.ChangeValue((int) colorValue2.G);
          int num5 = num4 < 0 ? 0 : num4;
          int num6 = num5 > (int) byte.MaxValue ? (int) byte.MaxValue : num5;
          BaseObject_CS baseObjectCs2 = objects;
          colorValue2 = objects.ColorValue;
          int r1 = (int) colorValue2.R;
          int green = num6;
          colorValue2 = objects.ColorValue;
          int b2 = (int) colorValue2.B;
          Color color2 = Color.FromArgb(r1, green, b2);
          baseObjectCs2.ColorValue = color2;
          break;
        case 6:
          Color colorValue3 = objects.ColorValue;
          int num7 = this.ChangeValue((int) colorValue3.B);
          int num8 = num7 < 0 ? 0 : num7;
          int num9 = num8 > (int) byte.MaxValue ? (int) byte.MaxValue : num8;
          BaseObject_CS baseObjectCs3 = objects;
          colorValue3 = objects.ColorValue;
          int r2 = (int) colorValue3.R;
          colorValue3 = objects.ColorValue;
          int g2 = (int) colorValue3.G;
          int blue = num9;
          Color color3 = Color.FromArgb(r2, g2, blue);
          baseObjectCs3.ColorValue = color3;
          break;
        case 7:
          objects.TransparentValueF = this.ChangeValue(objects.TransparentValueF);
          break;
        case 8:
          objects.AngleDegree = this.ChangeValue(objects.AngleDegree);
          break;
        case 9:
          objects.Velocity = this.ChangeValue(objects.Velocity);
          break;
        case 10:
          objects.DirectionDegree = this.ChangeValue(objects.DirectionDegree);
          break;
        case 11:
          objects.AccelerateCS = this.ChangeValue(objects.AccelerateCS);
          break;
        case 12:
          objects.AccDirection = this.ChangeValue(objects.AccDirection);
          break;
        case 13:
          objects.ScaleX = this.ChangeValue(objects.ScaleX);
          break;
        case 14:
          objects.ScaleY = this.ChangeValue(objects.ScaleY);
          break;
        case 15:
          objects.BeginningEffect = (double) this.value > 0.0;
          break;
        case 16:
          objects.EndingEffect = (double) this.value > 0.0;
          break;
        case 17:
          objects.Active = (double) this.value > 0.0;
          break;
        case 18:
          objects.Ghosting = (double) this.value > 0.0;
          break;
        case 19:
          objects.OutBound = (double) this.value > 0.0;
          break;
        case 20:
          objects.UnRemoveable = (double) this.value > 0.0;
          break;
      }
      --this.ctime;
      if (!(this.changetype == 2 & this.ctime == -1) && !(this.changetype != 2 & this.ctime == 0))
        return;
      objects.EventsExecutionList.Remove(this);
    }

    private int ChangeValue(int Value)
    {
      return (int) this.ChangeValue((double) Value);
    }

    private float ChangeValue(float Value)
    {
      return (float) this.ChangeValue((double) Value);
    }

    private double ChangeValue(double Value)
    {
      if (this.changetype == 0)
      {
        if (this.change == 0)
          return (Value * ((double) this.ctime - 1.0) + (double) this.value) / (double) this.ctime;
        if (this.change == 1)
          return Value + (double) this.value / (double) this.time;
        return Value - (double) this.value / (double) this.time;
      }
      if (this.changetype == 1)
      {
        if (this.change == 0)
          return (double) this.value;
        if (this.change == 1)
          return Value + (double) this.value;
        return Value - (double) this.value;
      }
      if (this.change == 0)
        return (double) float.Parse(this.region) + ((double) this.value - (double) float.Parse(this.region)) * Math.Sin(2.0 * Math.PI / (double) this.time * ((double) this.time - (double) this.ctime));
      if (this.change == 1)
        return (double) float.Parse(this.region) + (double) this.value * Math.Sin(2.0 * Math.PI / (double) this.time * ((double) this.time - (double) this.ctime));
      return (double) float.Parse(this.region) - (double) this.value * Math.Sin(2.0 * Math.PI / (double) this.time * ((double) this.time - (double) this.ctime));
    }
  }
}
