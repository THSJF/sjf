// Decompiled with JetBrains decompiler
// Type: Shooting.ParticleLongerByV
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class ParticleLongerByV : BaseEffect
  {
    public ParticleLongerByV(
      StageDataPackage StageData,
      string textureName,
      PointF Position,
      float Velocity,
      double Direction)
      : base(StageData, textureName, Position, Velocity, Direction)
    {
      this.LifeTime = 30;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time <= 0)
        return;
      this.TransparentValueF -= (float) ((int) byte.MaxValue / this.LifeTime);
      this.ScaleLength = this.ScaleWidth + (float) ((double) this.ScaleWidth * (double) Math.Abs(this.Velocity) / 10.0);
    }
  }
}
