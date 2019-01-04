// Decompiled with JetBrains decompiler
// Type: Shooting.ParticleSmaller
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class ParticleSmaller : BaseParticle
  {
    public ParticleSmaller(
      StageDataPackage StageData,
      string textureName,
      PointF Position,
      float Velocity,
      double Direction)
      : base(StageData, textureName, Position, Velocity, Direction)
    {
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time > 0)
        this.Scale -= 1f / (float) this.LifeTime;
      if ((double) this.Scale >= 0.200000002980232)
        return;
      this.Scale = 0.2f;
    }
  }
}
