// Decompiled with JetBrains decompiler
// Type: Shooting.EmitterSaveEnegy
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class EmitterSaveEnegy : BaseEffect
  {
    public int ColorType { get; set; }

    public EmitterSaveEnegy(StageDataPackage StageData, PointF Position, int colorType)
      : base(StageData)
    {
      this.Position = Position;
      this.Velocity = 0.0f;
      this.Direction = 0.0;
      this.LifeTime = 200;
      this.ColorType = colorType;
    }

    public override void Shoot()
    {
      if (this.Time % 5 != 0)
        return;
      for (int index = 0; index < 5; ++index)
      {
        double num1 = (double) this.Ran.Next(360) / 180.0 * Math.PI;
        int num2 = this.Ran.Next(10, 100);
        ParticleSmaller particleSmaller = new ParticleSmaller(this.StageData, "MyBullet000" + this.ColorType.ToString(), new PointF(this.Position.X + (float) num2 * (float) Math.Cos(num1), this.Position.Y + (float) num2 * (float) Math.Sin(num1)), 0.0f, num1 + Math.PI);
        particleSmaller.TransparentValueF = 200f;
        particleSmaller.LifeTime = 50;
        particleSmaller.Velocity = (float) num2 / (float) particleSmaller.LifeTime;
        particleSmaller.Scale = (float) this.Ran.Next(20, 50) / 100f;
      }
    }

    public override void Show()
    {
    }
  }
}
