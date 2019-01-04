// Decompiled with JetBrains decompiler
// Type: Shooting.EmitterSaveEnegy2
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class EmitterSaveEnegy2 : BaseEffect
  {
    public EmitterSaveEnegy2(StageDataPackage StageData, PointF Position)
      : base(StageData)
    {
      this.Position = Position;
      this.Velocity = 0.0f;
      this.Direction = 0.0;
      this.LifeTime = 20;
    }

    public override void Shoot()
    {
      if (this.Time % 3 != 0)
        return;
      for (int index = 0; index < 5; ++index)
      {
        double num1 = (double) this.Ran.Next(360) / 180.0 * Math.PI;
        int num2 = this.Ran.Next(150, 200);
        ParticleBack particleBack1 = new ParticleBack(this.StageData, "snow", new PointF(this.Position.X + (float) num2 * (float) Math.Cos(num1), this.Position.Y + (float) num2 * (float) Math.Sin(num1)), 0.0f, num1 + Math.PI);
        particleBack1.AngularVelocity = (float) this.Ran.Next(10) / 100f;
        particleBack1.TransparentValueF = 200f;
        particleBack1.LifeTime = this.Ran.Next(30, 50);
        particleBack1.Scale = (float) this.Ran.Next(80, 100) / 100f;
        ParticleBack particleBack2 = particleBack1;
        particleBack2.Velocity = (float) num2 / (float) particleBack2.LifeTime;
      }
    }

    public override void Show()
    {
    }
  }
}
