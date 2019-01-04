// Decompiled with JetBrains decompiler
// Type: Shooting.Emitter
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class Emitter : BaseEffect
  {
    public Emitter(StageDataPackage StageData, PointF Position)
      : base(StageData)
    {
      this.Position = Position;
      this.Velocity = 0.0f;
      this.Direction = 0.0;
    }

    public override void Shoot()
    {
      for (int index = 0; index < 10; ++index)
      {
        ParticleSmaller particleSmaller = new ParticleSmaller(this.StageData, this.MyPlane.Name == "Aya" ? "MyParticle" : "MyParticle01", this.Position, (float) (this.Ran.Next(20, 200) / 10), (double) this.Ran.Next(360) / 180.0 * Math.PI);
        particleSmaller.LifeTime = 20;
        particleSmaller.Scale = (float) this.Ran.Next(100) / 100f;
        particleSmaller.TransparentValueF = 200f;
      }
    }

    public override bool OutBoundary()
    {
      return this.Time >= 4;
    }

    public override void Show()
    {
    }
  }
}
