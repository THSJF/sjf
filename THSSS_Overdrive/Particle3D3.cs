// Decompiled with JetBrains decompiler
// Type: Shooting.Particle3D3
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class Particle3D3 : BaseParticle3D
  {
    private float maxScale;

    public Particle3D3(
      StageDataPackage StageData,
      string textureName,
      PointF OriginalPosition,
      float Velocity,
      double Direction,
      int LifeTime)
      : base(StageData, textureName, OriginalPosition, Velocity, Direction)
    {
      this.Active = true;
      StageData.Particle3D.ParticleList.Add((BaseParticle3D) this);
      this.MaxTransparent = 128;
      this.TransparentValueF = (float) this.MaxTransparent;
      this.LifeTime = LifeTime;
      this.Accelerate = -Velocity / (float) LifeTime;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time == 1)
      {
        this.maxScale = this.Scale;
      }
      else
      {
        if (this.LifeTime / 2 >= this.Time || this.Time > this.LifeTime)
          return;
        this.Scale -= this.maxScale * 2f / (float) this.LifeTime;
      }
    }
  }
}
