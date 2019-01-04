// Decompiled with JetBrains decompiler
// Type: Shooting.EDPetal
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using System;
using System.Drawing;

namespace Shooting
{
  public class EDPetal : BaseParticle3D
  {
    public double DestAngleDegree { get; set; }

    public EDPetal(
      StageDataPackage StageData,
      string modelName,
      PointF OriginalPosition,
      float Velocity,
      double Direction)
      : base(StageData, modelName, OriginalPosition, 0.0f, Math.PI / 2.0)
    {
      this.OriginalPosition = OriginalPosition;
      this.LifeTime = 300;
      this.TransparentValueF = 0.0f;
      this.TransparentVelocity = 10f;
      this.Angle3D = 1.570796f;
      this.Depth = 1f;
      this.Background3D.BackgroundParticleList.Add((BaseParticle3D) this);
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if ((double) this.Angle3D > 0.0)
        this.Angle3D -= (float) Math.PI / 90f;
      if (this.DestAngleDegree - this.AngleDegree > 1.0)
        this.AngleDegree += (this.DestAngleDegree - this.AngleDegree) / 8.0;
      else
        this.AngleDegree = this.DestAngleDegree;
      this.RotatingAxis = new Vector3((float) Math.Cos(this.Angle), (float) Math.Sin(this.Angle), 0.0f);
      if (this.Time != this.LifeTime - 22)
        return;
      this.TransparentVelocity = -12f;
    }
  }
}
