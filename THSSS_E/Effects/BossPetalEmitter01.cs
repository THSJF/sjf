// Decompiled with JetBrains decompiler
// Type: Shooting.BossPetalEmitter01
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using System;
using System.Drawing;

namespace Shooting
{
  public class BossPetalEmitter01 : BaseEffect
  {
    public BossPetalEmitter01(StageDataPackage StageData, PointF OriginalPosition)
      : base(StageData, (string) null, (PointF) new Point(0, 0), 0.0f, Math.PI / 2.0)
    {
      this.OriginalPosition = OriginalPosition;
      this.LifeTime = 130;
    }

    public override void Shoot()
    {
      if (this.Time % 1 != 0)
        return;
      for (int index = 0; index < 2; ++index)
      {
        StageDataPackage stageData = this.StageData;
        MyRandom ran1 = this.StageData.Ran;
        int minValue1 = (int) this.OriginalPosition.X - 20;
        PointF originalPosition = this.OriginalPosition;
        int maxValue1 = (int) originalPosition.X + 20;
        double num1 = (double) ran1.Next(minValue1, maxValue1);
        MyRandom ran2 = this.StageData.Ran;
        originalPosition = this.OriginalPosition;
        int minValue2 = (int) originalPosition.Y - 20;
        originalPosition = this.OriginalPosition;
        int maxValue2 = (int) originalPosition.Y + 20;
        double num2 = (double) ran2.Next(minValue2, maxValue2);
        PointF OriginalPosition = new PointF((float) num1, (float) num2);
        double num3 = (double) this.StageData.Ran.Next(10, 30) / 10.0;
        double direction = this.Direction;
        int LifeTime = 100 + this.Ran.Next(60);
        Particle3D3 particle3D3 = new Particle3D3(stageData, "Petal30", OriginalPosition, (float) num3, direction, LifeTime);
        particle3D3.Angle = (double) this.StageData.Ran.Next(0, 360) * 3.14159274101257 / 180.0;
        particle3D3.AngularVelocity3D = (float) this.StageData.Ran.Next(10) / 100f;
        particle3D3.Scale = (float) this.StageData.Ran.Next(5, 8) / 10f;
        particle3D3.RotatingAxis = new Vector3((float) this.StageData.Ran.Next(-100, 100), (float) this.StageData.Ran.Next(-100, 100), (float) this.StageData.Ran.Next(-100, 100));
        particle3D3.MaxTransparent = (int) byte.MaxValue;
      }
    }
  }
}
