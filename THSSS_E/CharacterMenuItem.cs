// Decompiled with JetBrains decompiler
// Type: Shooting.CharacterMenuItem
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class CharacterMenuItem : BaseMenuItem
  {
    public PointF DestPoint1 { get; set; }

    public PointF DestPoint2 { get; set; }

    public CharacterMenuItem(StageDataPackage StageData, string textureName)
      : base(StageData, textureName)
    {
      this.DestPoint = this.DestPoint1;
    }

    public override void Ctrl()
    {
      if (!this.Enabled)
        return;
      ++this.Time;
      this.Move();
      this.Velocity += this.Accelerate;
      this.TransparentValueF += this.TransparentVelocity;
      if (this.Time == 1)
        this.OriginalPosition = this.DestPoint2;
      if (this.Selected)
      {
        double num = 1.0 + Math.Sin((double) this.Time / 6.0);
        this.ColorValue = Color.White;
        this.TransparentVelocity = 25f;
        this.DestPoint = this.DestPoint1;
      }
      else
      {
        this.ColorValue = Color.Gray;
        this.TransparentVelocity = -25f;
        this.DestPoint = this.DestPoint2;
      }
      if (this.Time < this.TwinkleTime)
      {
        if (this.Time % 4 == 0)
          this.ColorValue = Color.White;
        else if (this.Time % 4 == 2)
          this.ColorValue = Color.Gray;
      }
      if (!this.OnRemove)
        return;
      this.MaxTransparent -= 15;
    }

    public override void Select()
    {
      this.Time = 1;
      this.Selected = true;
      this.VibrateTime = 0;
      this.TwinkleTime = 0;
    }

    public override void Click()
    {
      this.Time = 1;
      this.VibrateTime = 0;
      this.TwinkleTime = this.Time + 30;
    }
  }
}
