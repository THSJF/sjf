// Decompiled with JetBrains decompiler
// Type: Shooting.BaseMenuItem
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX.Direct3D9;
using System;
using System.Drawing;

namespace Shooting
{
  public class BaseMenuItem : BaseObject
  {
    public bool Selected { get; set; }

    public string Name { get; set; }

    public bool OnRemove { get; set; }

    public int TwinkleTime { get; set; }

    public int VibrateTime { get; set; }

    public float OffsetX { get; set; }

    public float OffsetY { get; set; }

    public bool Vibrateable { get; set; }

    public bool Twinkleable { get; set; }

    public bool UnSelectVisible { get; set; }

    public BaseMenuItem()
    {
    }

    public BaseMenuItem(StageDataPackage StageData, string textureName)
    {
      this.StageData = StageData;
      this.TxtureObject = this.TextureObjectDictionary[textureName];
      this.Name = textureName;
      this.MaxVelocity = 10f;
      this.UnSelectVisible = true;
      this.Vibrateable = true;
      this.Twinkleable = true;
      this.Selected = false;
    }

    public override void Move()
    {
      float distance = (float) this.GetDistance(this.DestPoint);
      if ((double) distance > 0.0)
        this.Velocity = (float) Math.Sqrt((double) distance) / 1f;
      else
        this.Velocity = 0.0f;
      this.Direction = this.GetDirection(this.DestPoint);
      base.Move();
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Selected)
      {
        double num = 1.0 + Math.Sin((double) this.Time / 5.0);
        if (!this.Twinkleable)
          num = 2.0;
        this.ColorValue = Color.FromArgb(220 + (int) (12.0 * num), 220 + (int) (12.0 * num), 220 + (int) (12.0 * num));
        this.TransparentValueF = (float) byte.MaxValue;
      }
      else if (!this.UnSelectVisible)
      {
        this.TransparentVelocity = -25f;
      }
      else
      {
        this.ColorValue = Color.FromArgb(150, 150, 150);
        this.TransparentValueF = (float) byte.MaxValue;
      }
      if (this.Time < this.VibrateTime)
      {
        this.OffsetX = (float) this.Ran.Next(-2, 3);
        this.OffsetY = (float) this.Ran.Next(-2, 3);
      }
      else
      {
        this.OffsetX = 0.0f;
        this.OffsetY = 0.0f;
      }
      if (this.Time < this.TwinkleTime)
      {
        if (this.Time % 4 == 0)
          this.TransparentValueF = (float) byte.MaxValue;
        else if (this.Time % 4 == 2)
          this.TransparentValueF = 0.0f;
      }
      if (!this.OnRemove)
        return;
      this.MaxTransparent -= 15;
    }

    public virtual void Select()
    {
      this.Time = 0;
      this.Selected = true;
      if (this.Vibrateable)
        this.VibrateTime = this.Time + 10;
      this.TwinkleTime = 0;
    }

    public virtual void Click()
    {
      this.Time = 0;
      this.VibrateTime = 0;
      this.TwinkleTime = this.Time + 30;
    }

    public override void Show()
    {
      SizeF sizeF = new SizeF((float) this.TxtureObject.Width * this.Scale, (float) this.TxtureObject.Height * this.Scale);
      MySprite spriteMain = this.SpriteMain;
      Texture txTure = this.TxtureObject.TXTure;
      Rectangle posRect = this.TxtureObject.PosRect;
      SizeF destinationSize = sizeF;
      PointF rotationCenter = new PointF(0.0f, 0.0f);
      double angle = this.Angle;
      PointF position1 = this.Position;
      double num1 = (double) position1.X - (double) this.OffsetX;
      position1 = this.Position;
      double num2 = (double) position1.Y - (double) this.OffsetY;
      PointF position2 = new PointF((float) num1, (float) num2);
      Color color = Color.FromArgb(this.TransparentValue, this.ColorValue);
      spriteMain.Draw2D(txTure, posRect, destinationSize, rotationCenter, (float) angle, position2, color);
    }
  }
}
