// Decompiled with JetBrains decompiler
// Type: Shooting.BackgroundParticleEmitter
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class BackgroundParticleEmitter : Background3DObject
  {
    public BackgroundParticleEmitter(StageDataPackage StageData, PointF OriginalPosition)
      : base(StageData, (string) null, OriginalPosition, true)
    {
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time % 30 != 0)
        return;
      PointF pointF = new PointF(this.OriginalPosition.X + (float) this.Ran.Next(-20, 20), this.OriginalPosition.Y + (float) this.Ran.Next(-20, 20));
      Background3DObject background3Dobject = new Background3DObject(this.StageData, "591-1", this.OriginalPosition, false);
      background3Dobject.Scale = (float) this.Ran.Next(40, 60) / 100f;
      background3Dobject.ScaleVelocity = -0.004f;
      background3Dobject.Velocity = (float) this.Ran.Next(-10, 10) / 20f;
      background3Dobject.DirectionDegree = (double) this.Ran.Next(360);
      background3Dobject.VelocityZ = (float) this.Ran.Next(6, 15) / 20f;
      background3Dobject.LifeTime = 200;
      background3Dobject.Active = true;
      background3Dobject.Angle3DX = this.StageData.Background3D.Envi.CameraAngle - 1.570796f;
      background3Dobject.TransparentValueF = 0.0f;
      background3Dobject.TransparentVelocity = 10f;
    }

    public override void Show()
    {
    }
  }
}
