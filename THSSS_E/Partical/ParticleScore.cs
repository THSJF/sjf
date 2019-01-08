 
// Type: Shooting.ParticleScore
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class ParticleScore : BaseEffect
  {
    public ParticleScore(StageDataPackage StageData, string textureName, PointF Position)
      : base(StageData, textureName, Position, 1f, -1.57079637050629)
    {
      this.LifeTime = 50;
      this.Active = false;
    }

    public override void Ctrl()
    {
      this.Angle = -this.Direction + Math.PI / 2.0;
      base.Ctrl();
      if (this.Time <= 0)
        return;
      this.TransparentValueF -= (float) ((int) byte.MaxValue / this.LifeTime);
    }
  }
}
