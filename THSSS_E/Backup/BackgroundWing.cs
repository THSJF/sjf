// Decompiled with JetBrains decompiler
// Type: Shooting.BackgroundWing
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using System;
using System.Drawing;

namespace Shooting
{
  public class BackgroundWing : BaseParticle3D
  {
    private int lastlife;

    public BackgroundWing(
      StageDataPackage StageData,
      string textureName,
      PointF OriginalPosition,
      float Velocity,
      double Direction,
      int LifeTime)
      : base(StageData, textureName, OriginalPosition, Velocity, Direction)
    {
      StageData.Particle3D.ParticleList.Add((BaseParticle3D) this);
      this.LifeTime = LifeTime;
      if (this.Boss != null)
        this.SetBinding((BaseObject) this.Boss);
      this.Scale = 0.1f;
      this.MaxScale = 0.6f;
      this.ScaleVelocity = 0.02f;
      this.RotatingAxis = new Vector3(0.0f, 1f, 0.0f);
      this.lastlife = this.Boss.Life;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.Angle3D = -(float) (Math.PI / 18.0 * (1.0 - Math.Sin((double) this.Time / 30.0)));
      if (this.Boss != null)
      {
        if (this.Boss.Time > this.Boss.UnmatchedTime && this.Time > 50 && this.Boss.HitEnabled)
        {
          for (int index = this.MyBulletList.Count - 1; index >= 0; --index)
          {
            PointF originalPosition1 = this.MyBulletList[index].OriginalPosition;
            double y1 = (double) originalPosition1.Y;
            originalPosition1 = this.OriginalPosition;
            double y2 = (double) originalPosition1.Y;
            if (y1 < y2)
            {
              PointF originalPosition2 = this.MyBulletList[index].OriginalPosition;
              double x1 = (double) originalPosition2.X;
              originalPosition2 = this.OriginalPosition;
              double num1 = (double) originalPosition2.X - 100.0;
              int num2;
              if (x1 > num1)
              {
                PointF originalPosition3 = this.MyBulletList[index].OriginalPosition;
                double x2 = (double) originalPosition3.X;
                originalPosition3 = this.OriginalPosition;
                double num3 = (double) originalPosition3.X + 100.0;
                num2 = x2 >= num3 ? 1 : 0;
              }
              else
                num2 = 1;
              if (num2 == 0)
              {
                if (this.Boss.Time > this.Boss.UnmatchedTime)
                  this.Boss.HealthPoint -= (float) ((double) this.MyBulletList[index].Damage * (1.0 - (double) this.Boss.Armon) / 3.0);
                this.MyBulletList[index].GiveEndEffect();
                this.MyBulletList.RemoveAt(index);
                this.MyPlane.Score += 100L;
              }
            }
          }
        }
        if (this.Boss.Life < this.lastlife)
        {
          this.LifeTime = this.Time + 10;
          this.TransparentVelocity = -25f;
          this.lastlife = this.Boss.Life;
        }
      }
      if (this.Time != this.LifeTime)
        return;
      BulletPicEmitter.ShootItem(this.StageData, "WingItem.png", this.OriginalPosition, 10f);
    }
  }
}
