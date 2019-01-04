// Decompiled with JetBrains decompiler
// Type: Shooting.BaseSubPlane
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class BaseSubPlane : BaseObject
  {
    public double ShootDirection { get; set; }

    public BaseSubPlane(StageDataPackage StageData, string textureName, PointF Position)
      : base(StageData, textureName, Position, 0.0f, Math.PI / 2.0)
    {
      this.TransparentValueF = 0.0f;
      this.TransparentVelocity = 20f;
      this.AngleWithDirection = false;
      this.AngleDegree = 90.0;
    }

    public virtual void Refresh()
    {
      this.Time = 0;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      PointF destPoint = this.DestPoint;
      this.MoveToPoint(this.DestPoint);
    }

    public void MoveToPoint(PointF DP)
    {
      float distance = (float) this.GetDistance(DP);
      if ((double) distance > 2.0)
        this.Velocity = distance / 2.5f;
      else if ((double) distance > 0.0)
        this.Velocity = 0.5f;
      else
        this.Velocity = 0.0f;
      this.Direction = this.GetDirection(DP);
    }

    public override void Shoot()
    {
      BulletGuidance bulletGuidance = new BulletGuidance(this.StageData, "子机子弹", this.Position, 8f, -1.0 * Math.PI / 2.0);
      bulletGuidance.TransparentValueF = 150f;
      bulletGuidance.Angle = 3.14159274101257;
    }

    public override void Show()
    {
      if (!this.Enabled)
        return;
      base.Show();
    }
  }
}
