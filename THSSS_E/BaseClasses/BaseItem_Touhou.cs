// Decompiled with JetBrains decompiler
// Type: Shooting.BaseItem_Touhou
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class BaseItem_Touhou : BaseItem
  {
    public BaseItem_Touhou(StageDataPackage StageData, string textureName, PointF OriginalPosition)
      : base(StageData, textureName, OriginalPosition)
    {
      this.OriginalPosition = OriginalPosition;
      this.Velocity = 4f;
      this.Direction = 3.0 * Math.PI / 2.0;
      this.Angle = 0.0;
      this.Accelerate = (float) (-(double) this.Velocity / 40.0);
      this.AngularVelocity = 0.2f;
    }

    public override void Ctrl()
    {
      if (!this.Enabled)
        return;
      ++this.Time;
      this.Move();
      this.Velocity += this.Accelerate;
      if ((double) this.Velocity < 0.0)
        this.Velocity = 0.0f;
      this.Angle += (double) this.AngularVelocity;
      this.TransparentValueF += this.TransparentVelocity;
      PointF pointF;
      if (this.Obtain)
      {
        pointF = this.Position;
        double y1 = (double) pointF.Y;
        pointF = this.MyPlane.Position;
        double y2 = (double) pointF.Y;
        double y3 = y1 - y2;
        pointF = this.Position;
        double x1 = (double) pointF.X;
        pointF = this.MyPlane.Position;
        double x2 = (double) pointF.X;
        double x3 = x1 - x2;
        this.Direction = Math.PI + Math.Atan2(y3, x3);
        this.Accelerate = 1f;
        if ((double) this.Velocity > 10.0)
          this.Velocity = 10f;
      }
      else if (this.Time == 40)
      {
        this.AngularVelocity = 0.0f;
        this.Angle = 0.0;
      }
      else if (this.Time > 40)
      {
        this.Direction = Math.PI / 2.0;
        this.Accelerate = 0.15f;
        if ((double) this.Velocity > 1.5)
          this.Velocity = 1.5f;
      }
      pointF = this.OriginalPosition;
      if ((double) pointF.Y < 0.0)
      {
        pointF = this.OriginalPosition;
        this.TransparentValueF = (float) ((int) byte.MaxValue + 2 * (int) pointF.Y);
      }
      else
        this.TransparentValueF = (float) byte.MaxValue;
      if (!this.OutBoundary())
        return;
      this.ItemList.Remove((BaseItem) this);
    }

    public override void HitCheckAll()
    {
      if (this.Time < 10)
        return;
      if (this.HitCheck((BaseObject) this.MyPlane, 48f))
        this.Obtain = true;
      if ((double) this.MyPlane.OriginalPosition.Y >= 128.0)
        return;
      this.Obtain = true;
      this.Doubled = true;
    }
  }
}
