// Decompiled with JetBrains decompiler
// Type: Shooting.BaseItem
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class BaseItem : BaseObject
  {
    public float AngularVelocity { get; set; }

    public bool Obtain { get; set; }

    public bool Doubled { get; set; }

    public BaseItem(StageDataPackage StageData, string textureName, PointF Position)
      : base(StageData, textureName, Position, 0.0f, 0.0)
    {
      this.ItemList.Add(this);
      this.Velocity = (float) this.Ran.Next(1, 6);
      this.Direction = (double) this.Ran.Next(180, 360) / 360.0 * Math.PI * 2.0;
      this.Angle = 0.0;
      if (this.Direction - 1.57079637050629 > 0.0)
        this.AngularVelocity = -0.2f;
      else
        this.AngularVelocity = 0.2f;
    }

    public override void HitCheckAll()
    {
      if (!this.HitCheck((BaseObject) this.MyPlane, 200f))
        return;
      this.Obtain = true;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.Angle += (double) this.AngularVelocity;
      if (this.Time == 12)
      {
        this.Direction = Math.PI / 2.0;
        this.AngularVelocity = 0.0f;
        this.Angle = 0.0;
      }
      else if (this.Time > 12)
      {
        if (this.Obtain)
        {
          PointF position = this.Position;
          double y1 = (double) position.Y;
          position = this.MyPlane.Position;
          double y2 = (double) position.Y;
          double y3 = y1 - y2;
          position = this.Position;
          double x1 = (double) position.X;
          position = this.MyPlane.Position;
          double x2 = (double) position.X;
          double x3 = x1 - x2;
          this.Direction = Math.PI + Math.Atan2(y3, x3);
          this.Velocity = 8f;
        }
        else
          this.Velocity = 4f;
      }
      if (!this.OutBoundary())
        return;
      this.ItemList.Remove(this);
    }

    public override bool OutBoundary()
    {
      PointF pointF;
      if ((double) this.OriginalPosition.X < 0.0)
      {
        this.OriginalPosition = new PointF(0.0f, this.OriginalPosition.Y);
      }
      else
      {
        pointF = this.OriginalPosition;
        if ((double) pointF.X > (double) this.BoundRect.Width)
        {
          double width = (double) this.BoundRect.Width;
          pointF = this.OriginalPosition;
          double y = (double) pointF.Y;
          this.OriginalPosition = new PointF((float) width, (float) y);
        }
      }
      if (this.Time < 30)
        return false;
      pointF = this.Position;
      return (double) pointF.Y > (double) (this.BoundRect.Bottom + 30);
    }
  }
}
