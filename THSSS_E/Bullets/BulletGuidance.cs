// Decompiled with JetBrains decompiler
// Type: Shooting.BulletGuidance
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class BulletGuidance : BaseObject
  {
    private bool targetFlag = false;

    public BaseObject Target { get; set; }

    public BulletGuidance(
      StageDataPackage StageData,
      string textureName,
      PointF Position,
      float Velocity,
      double Direction)
      : base(StageData, textureName, Position, Velocity, Direction)
    {
      this.Damage = 3;
      this.Region = 15;
      this.LifeTime = 100;
      this.MyBulletList.Add((BaseObject) this);
      if (this.Boss != null)
      {
        PointF originalPosition = this.Boss.OriginalPosition;
        int num;
        if ((double) originalPosition.X > 0.0)
        {
          originalPosition = this.Boss.OriginalPosition;
          double x = (double) originalPosition.X;
          Rectangle boundRect = this.BoundRect;
          double width = (double) boundRect.Width;
          if (x < width)
          {
            originalPosition = this.Boss.OriginalPosition;
            if ((double) originalPosition.Y > 0.0)
            {
              originalPosition = this.Boss.OriginalPosition;
              double y = (double) originalPosition.Y;
              boundRect = this.BoundRect;
              double height = (double) boundRect.Height;
              num = y >= height ? 1 : 0;
              goto label_6;
            }
          }
        }
        num = 1;
label_6:
        if (num == 0 && this.Boss.HitEnabled)
          this.Target = (BaseObject) this.Boss;
      }
      this.GhostingCount = 5;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Target == null && !this.targetFlag)
      {
        double dist = 300.0;
        this.EnemyPlaneList.ForEach((Action<BaseEnemyPlane>) (x =>
        {
          if (!x.HitEnabled)
            return;
          double distance = this.GetDistance((BaseObject) x);
          if (distance < dist)
          {
            this.Target = (BaseObject) x;
            dist = distance;
          }
        }));
      }
      else
        this.targetFlag = true;
      if (this.Target != null)
      {
        if ((double) this.Target.HealthPoint > 0.0)
        {
          double direction1 = this.GetDirection(this.Target);
          double direction2 = this.Direction;
          if (direction1 > Math.PI)
            direction1 -= 2.0 * Math.PI;
          if (direction2 > Math.PI)
            direction2 -= 2.0 * Math.PI;
          double num = direction1 - direction2;
          if (num > Math.PI)
            num -= 2.0 * Math.PI;
          if (Math.Abs(num) > 0.0199999995529652 && this.GetDistance(this.Target) > 50.0)
            this.Direction += num / 5.0;
          else
            this.Direction += num;
        }
        else
          this.Target = (BaseObject) null;
      }
      if (!this.OutBoundary())
        return;
      this.MyBulletList.Remove((BaseObject) this);
    }

    public override bool OutBoundary()
    {
      if (this.LifeTime != 0 && this.Time > this.LifeTime)
        return true;
      if (this.Time < 10)
        return false;
      int num1 = 2;
      double num2 = (double) -num1;
      PointF originalPosition = this.OriginalPosition;
      double x1 = (double) originalPosition.X;
      int num3;
      if (num2 < x1)
      {
        originalPosition = this.OriginalPosition;
        double x2 = (double) originalPosition.X;
        Rectangle boundRect = this.BoundRect;
        double num4 = (double) (boundRect.Width + num1);
        if (x2 < num4)
        {
          double num5 = (double) -num1;
          originalPosition = this.OriginalPosition;
          double y1 = (double) originalPosition.Y;
          if (num5 < y1)
          {
            originalPosition = this.OriginalPosition;
            double y2 = (double) originalPosition.Y;
            boundRect = this.BoundRect;
            double num6 = (double) (boundRect.Height + num1);
            num3 = y2 >= num6 ? 1 : 0;
            goto label_9;
          }
        }
      }
      num3 = 1;
label_9:
      return num3 != 0;
    }

    public override void GiveEndEffect()
    {
      ParticleBiger particleBiger = new ParticleBiger(this.StageData, (string) null, this.Position, 2f, this.Direction);
      particleBiger.Scale = 1.2f;
      particleBiger.LifeTime = 15;
      particleBiger.TxtureObject = this.TxtureObject;
      particleBiger.Angle = this.Angle;
    }
  }
}
