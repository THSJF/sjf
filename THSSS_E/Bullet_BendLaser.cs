// Decompiled with JetBrains decompiler
// Type: Shooting.Bullet_BendLaser
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class Bullet_BendLaser : BaseBullet_Touhou
  {
    private Particle3D_BendLaser PL;

    public Bullet_BendLaser(StageDataPackage StageData)
      : base(StageData)
    {
    }

    public Bullet_BendLaser(
      StageDataPackage StageData,
      PointF OriginalPosition,
      float Velocity,
      double Direction,
      byte ColorType,
      int Length)
      : this(StageData, OriginalPosition, Velocity, Direction, ColorType, Length, 16)
    {
    }

    public Bullet_BendLaser(
      StageDataPackage StageData,
      PointF OriginalPosition,
      float Velocity,
      double Direction,
      byte ColorType,
      int Length,
      int Width)
      : this(StageData, (string) null, OriginalPosition, Velocity, Direction, Length)
    {
      this.ColorType = ColorType;
      ParticleBeginBullet particleBeginBullet = new ParticleBeginBullet(StageData, this.Position, ColorType);
      particleBeginBullet.Scale = 0.5f;
      particleBeginBullet.Active = true;
      Particle3D_BendLaser particle3DBendLaser = new Particle3D_BendLaser(StageData, this.GhostingCount, Width, (int) ColorType);
      particle3DBendLaser.OriginalPosition = this.OriginalPosition;
      particle3DBendLaser.LastPoints = this.LastPoints;
      this.PL = particle3DBendLaser;
    }

    public Bullet_BendLaser(
      StageDataPackage StageData,
      string textureName,
      PointF OriginalPosition,
      float Velocity,
      double Direction,
      int Length)
      : base(StageData, textureName, OriginalPosition, Velocity, Direction)
    {
      this.GhostingCount = Length;
      this.Region = 2;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time == 1 && this.PL == null)
      {
        Particle3D_BendLaser particle3DBendLaser = new Particle3D_BendLaser(this.StageData, this.GhostingCount, (int) ((double) this.ScaleLength * 16.0), (int) this.ColorType);
        particle3DBendLaser.OriginalPosition = this.OriginalPosition;
        particle3DBendLaser.LastPoints = this.LastPoints;
        this.PL = particle3DBendLaser;
      }
      this.PL.LastPoints = this.LastPoints;
      this.PL.TransparentValueF = this.TransparentValueF;
      if (this.Time % 8 != 0)
        return;
      this.Grazed = false;
    }

    public override bool OutBoundary()
    {
      if (this.LifeTime != 0 && this.Time > this.LifeTime)
      {
        this.PL.Dispose();
        this.StageData.Particle3D.ParticleList.Remove((BaseParticle3D) this.PL);
        return true;
      }
      if (this.Reflect <= (byte) 0)
      {
        if (this.Time < 100)
          return false;
        int num1 = this.OutsideRegion >= 10 ? this.OutsideRegion * 2 : 20;
        Rectangle boundRect;
        int num2;
        if ((double) -num1 < (double) this.LastPoints[this.LastPoints.Length - 1].X)
        {
          double x = (double) this.LastPoints[this.LastPoints.Length - 1].X;
          boundRect = this.BoundRect;
          double num3 = (double) (boundRect.Width + num1);
          if (x < num3 && (double) -num1 < (double) this.LastPoints[this.LastPoints.Length - 1].Y)
          {
            double y = (double) this.LastPoints[this.LastPoints.Length - 1].Y;
            boundRect = this.BoundRect;
            double num4 = (double) (boundRect.Height + num1);
            num2 = y >= num4 ? 1 : 0;
            goto label_9;
          }
        }
        num2 = 1;
label_9:
        if (num2 == 0)
          return false;
        int num5;
        if ((double) -num1 < (double) this.OriginalPosition.X)
        {
          PointF originalPosition = this.OriginalPosition;
          double x = (double) originalPosition.X;
          boundRect = this.BoundRect;
          double num3 = (double) (boundRect.Width + num1);
          if (x < num3)
          {
            double num4 = (double) -num1;
            originalPosition = this.OriginalPosition;
            double y1 = (double) originalPosition.Y;
            if (num4 < y1)
            {
              originalPosition = this.OriginalPosition;
              double y2 = (double) originalPosition.Y;
              boundRect = this.BoundRect;
              double num6 = (double) (boundRect.Height + num1);
              num5 = y2 >= num6 ? 1 : 0;
              goto label_16;
            }
          }
        }
        num5 = 1;
label_16:
        if (num5 == 0)
          return false;
        this.PL.Dispose();
        this.StageData.Particle3D.ParticleList.Remove((BaseParticle3D) this.PL);
        return true;
      }
      PointF originalPosition1 = this.OriginalPosition;
      int num;
      if ((double) originalPosition1.X >= 0.0)
      {
        originalPosition1 = this.OriginalPosition;
        num = (double) originalPosition1.X < (double) this.BoundRect.Width ? 1 : 0;
      }
      else
        num = 0;
      if (num == 0)
      {
        --this.Reflect;
        this.Direction -= 2.0 * (this.Direction - Math.PI / 2.0);
      }
      originalPosition1 = this.OriginalPosition;
      if ((double) originalPosition1.Y < 20.0)
      {
        --this.Reflect;
        this.Direction = -this.Direction;
      }
      return false;
    }

    public override bool HitCheck(BaseObject Target, float Radius)
    {
      for (int index = 3; index < this.LastPoints.Length - 3; ++index)
      {
        PointF lastPoint = this.LastPoints[index];
        double x1 = (double) lastPoint.X;
        PointF originalPosition = Target.OriginalPosition;
        double x2 = (double) originalPosition.X;
        double num1 = x1 - x2;
        double x3 = (double) lastPoint.X;
        originalPosition = Target.OriginalPosition;
        double x4 = (double) originalPosition.X;
        double num2 = x3 - x4;
        double num3 = num1 * num2;
        double y1 = (double) lastPoint.Y;
        originalPosition = Target.OriginalPosition;
        double y2 = (double) originalPosition.Y;
        double num4 = y1 - y2;
        double y3 = (double) lastPoint.Y;
        originalPosition = Target.OriginalPosition;
        double y4 = (double) originalPosition.Y;
        double num5 = y3 - y4;
        double num6 = num4 * num5;
        if (Math.Sqrt(num3 + num6) - (double) Target.Region < (double) Radius)
          return true;
      }
      return false;
    }

    public override void GiveEndEffect()
    {
      for (int index = 0; index < this.LastPoints.Length; index += 8)
      {
        ParticleEndBullet particleEndBullet = new ParticleEndBullet(this.StageData, this.LastPoints[index], this.ColorType, this.SizeValue);
      }
      this.StageData.Particle3D.ParticleList.Remove((BaseParticle3D) this.PL);
    }

    public override void GiveItems()
    {
      int num = this.Region / 5;
      for (int index1 = 0; index1 < this.LastPoints.Length; index1 += 8)
      {
        for (int index2 = 0; index2 <= num; ++index2)
        {
          double direction = this.Direction;
          for (int index3 = 0; index3 < index2 * 5 + 1; ++index3)
          {
            StarItem_Touhou starItemTouhou = new StarItem_Touhou(this.StageData, new PointF(this.LastPoints[index1].X + (float) index2 * (float) Math.Cos(direction), this.LastPoints[index1].Y + (float) index2 * (float) Math.Sin(direction)));
            direction += 2.0 * Math.PI / (double) (index2 * 6);
          }
        }
      }
    }

    public override void Show()
    {
    }

    public override void ShowRegion()
    {
      PointF originalPosition = this.OriginalPosition;
      for (int index = 3; index < this.LastPoints.Length - 3; ++index)
      {
        this.OriginalPosition = this.LastPoints[index];
        base.ShowRegion();
      }
      this.OriginalPosition = originalPosition;
    }
  }
}
