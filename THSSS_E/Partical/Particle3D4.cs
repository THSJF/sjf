 
// Type: Shooting.Particle3D4
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class Particle3D4 : BaseParticle3D
  {
    private float maxScale;

    public Particle3D4(
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
      this.Accelerate = (float) this.Ran.Next(10) / 100f;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time == 1)
        this.maxScale = this.Scale;
      else if (this.LifeTime * 3 / 4 < this.Time && this.Time <= this.LifeTime)
        this.Scale -= this.maxScale * 4f / (float) this.LifeTime;
      float num = 8f / this.Vy;
      this.Vx = 10f * (float) Math.Sin((double) this.Time / (double) num);
      this.Depth += 10f * (float) Math.Cos((double) this.Time / (double) num);
    }
  }
}
