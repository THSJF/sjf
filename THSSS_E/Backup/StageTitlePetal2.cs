// Decompiled with JetBrains decompiler
// Type: Shooting.StageTitlePetal2
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using System;
using System.Drawing;

namespace Shooting
{
  public class StageTitlePetal2 : BaseParticle3D
  {
    public StageTitlePetal2(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.Background3D.BackgroundParticleList.Add((BaseParticle3D) this);
      this.OriginalPosition = new PointF((float) (this.BoundRect.Width / 2 - 45), 40f);
      this.Direction = Math.PI / 2.0;
      this.Velocity = 3f;
      this.LifeTime = 80;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.Shoot();
      float num = 5f;
      this.Vx = 10f * (float) Math.Sin((double) this.Time / (double) num);
      this.Depth += 10f * (float) Math.Cos((double) this.Time / (double) num);
    }

    public override void Shoot()
    {
      if (this.Time % 1 != 0)
        return;
      for (int index = 0; index < 8; ++index)
      {
        StageDataPackage stageData = this.StageData;
        MyRandom ran = this.StageData.Ran;
        int minValue = (int) this.OriginalPosition.X - 60;
        PointF originalPosition = this.OriginalPosition;
        int maxValue = (int) originalPosition.X - 35;
        double num1 = (double) ran.Next(minValue, maxValue);
        originalPosition = this.OriginalPosition;
        double y = (double) (int) originalPosition.Y;
        PointF OriginalPosition = new PointF((float) num1, (float) y);
        double num2 = (double) this.StageData.Ran.Next(10, 30) / 10.0;
        int LifeTime = 100 + this.Ran.Next(40);
        Particle3D4 particle3D4 = new Particle3D4(stageData, "Petal00", OriginalPosition, (float) num2, Math.PI / 2.0, LifeTime);
        particle3D4.Angle = (double) this.StageData.Ran.Next(0, 360) * 3.14159274101257 / 180.0;
        particle3D4.AngularVelocity3D = (float) this.StageData.Ran.Next(10) / 100f;
        particle3D4.Scale = (float) this.StageData.Ran.Next(5, 8) / 10f;
        particle3D4.RotatingAxis = new Vector3((float) this.StageData.Ran.Next(-100, 100), (float) this.StageData.Ran.Next(-100, 100), (float) this.StageData.Ran.Next(-100, 100));
        particle3D4.MaxTransparent = (int) byte.MaxValue;
        particle3D4.Depth = (float) this.Ran.Next((int) this.Depth - 50, (int) this.Depth - 50);
      }
    }

    public override void Show()
    {
    }
  }
}
