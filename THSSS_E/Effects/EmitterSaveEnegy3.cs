 
// Type: Shooting.EmitterSaveEnegy3
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class EmitterSaveEnegy3 : BaseEffect
  {
    public EmitterSaveEnegy3(StageDataPackage StageData, PointF Position)
      : base(StageData)
    {
      this.Position = Position;
      this.Velocity = 0.0f;
      this.Direction = 0.0;
      this.LifeTime = 90;
    }

    public override void Shoot()
    {
      if (this.Time % 5 != 0)
        return;
      for (int index = 0; index < 5; ++index)
      {
        double num1 = (double) this.Ran.Next(360) / 180.0 * Math.PI;
        int num2 = this.Ran.Next(10, 100);
        ParticleLongerByV particleLongerByV1 = new ParticleLongerByV(this.StageData, "590-1", new PointF(this.Position.X + (float) num2 * (float) Math.Cos(num1), this.Position.Y + (float) num2 * (float) Math.Sin(num1)), 0.0f, num1 + Math.PI);
        particleLongerByV1.TransparentValueF = 200f;
        particleLongerByV1.LifeTime = 20;
        particleLongerByV1.Scale = (float) this.Ran.Next(20, 50) / 100f;
        ParticleLongerByV particleLongerByV2 = particleLongerByV1;
        particleLongerByV2.Velocity = (float) num2 / (float) particleLongerByV2.LifeTime;
      }
    }

    public override void Show()
    {
    }
  }
}
