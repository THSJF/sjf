// Decompiled with JetBrains decompiler
// Type: Shooting.MusicTitle
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class MusicTitle : BaseEffect
  {
    public new PointF Position
    {
      get
      {
        PointF originalPosition = this.OriginalPosition;
        double num1 = (double) originalPosition.X + 36.0;
        originalPosition = this.OriginalPosition;
        double num2 = (double) originalPosition.Y + 16.0;
        return new PointF((float) num1, (float) num2);
      }
    }

    public MusicTitle(StageDataPackage StageData, string textureName)
      : this(StageData, textureName, new Point(0, 0))
    {
      Rectangle boundRect1 = this.BoundRect;
      int width1 = boundRect1.Width;
      boundRect1 = this.BoundRect;
      int y = boundRect1.Height - 16;
      this.DestPoint = (PointF) new Point(width1, y);
      this.Scale = 0.5f;
      Rectangle boundRect2 = this.BoundRect;
      double width2 = (double) boundRect2.Width;
      boundRect2 = this.BoundRect;
      double num = (double) (boundRect2.Height + 100);
      this.OriginalPosition = new PointF((float) width2, (float) num);
    }

    public MusicTitle(StageDataPackage StageData, string textureName, Point DestPoint)
      : base(StageData)
    {
      this.TxtureObject = this.TextureObjectDictionary[textureName];
      this.OriginalPosition = new PointF((float) (this.BoundRect.Width - 10), 350f);
      this.Velocity = 4f;
      this.Direction = Math.PI / 2.0;
      this.Scale = 2f;
      this.DestPoint = (PointF) DestPoint;
      this.LifeTime = 240;
    }

    public override void Move()
    {
      float distance = (float) this.GetDistance(this.DestPoint);
      if ((double) distance > 50.0)
        this.Velocity = 7f;
      else if ((double) distance > 35.0)
        this.Velocity = 5f;
      else if ((double) distance > 15.0)
        this.Velocity = 3f;
      else if ((double) distance > 1.0)
        this.Velocity = 1f;
      else
        this.Velocity = 0.0f;
      this.Direction = this.GetDirection(this.DestPoint);
      this.Angle = -(this.Direction - Math.PI / 2.0);
      base.Move();
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if ((double) this.Scale > 1.0)
        this.Scale -= 0.03f;
      if (this.Time < this.LifeTime - 35)
        return;
      this.MaxTransparent -= 8;
    }

    public override bool OutBoundary()
    {
      return this.Time > this.LifeTime;
    }

    public override void Show()
    {
      this.SpriteMain.Draw2D(this.TxtureObject.TXTure, this.TxtureObject.PosRect, new SizeF((float) this.TxtureObject.Width * this.Scale, (float) this.TxtureObject.Height * this.Scale), this.TxtureObject.RightTop, 0.0f, this.Position, Color.FromArgb(this.TransparentValue, Color.White));
    }
  }
}
