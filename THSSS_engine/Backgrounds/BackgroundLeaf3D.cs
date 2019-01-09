 
// Type: Shooting.BackgroundLeaf3D
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using System;
using System.Drawing;

namespace Shooting
{
  internal class BackgroundLeaf3D : BaseParticle3D
  {
    public BackgroundLeaf3D(StageDataPackage StageData)
    {
      this.StageData = StageData;
      StageData.Particle3D.ParticleList.Add((BaseParticle3D) this);
    }

    public override void Ctrl()
    {
      ++this.Time;
      this.Shoot();
    }

    public override void Shoot()
    {
      if (this.Time % 20 != 0)
        return;
      for (int index = 0; index < 2; ++index)
      {
        BackgroundParticle3D1 backgroundParticle3D1 = new BackgroundParticle3D1(this.StageData, "Leaf", new PointF((float) this.StageData.Ran.Next(130, 700), (float) this.StageData.Ran.Next(-50, -20)), (float) this.StageData.Ran.Next(2, 4), Math.PI / 2.0 + (double) this.StageData.Ran.Next(1, 8) / 10.0, 200);
        backgroundParticle3D1.Angle = (double) this.StageData.Ran.Next(0, 360) * 3.14159274101257 / 180.0;
        backgroundParticle3D1.AngularVelocity3D = (float) this.StageData.Ran.Next(5) / 100f;
        backgroundParticle3D1.Scale = (float) this.StageData.Ran.Next(5, 20) / 10f;
        backgroundParticle3D1.RotatingAxis = new Vector3((float) this.StageData.Ran.Next(-100, 100), (float) this.StageData.Ran.Next(-100, 100), (float) this.StageData.Ran.Next(-100, 100));
        backgroundParticle3D1.ColorValue = Color.FromArgb(this.StageData.Ran.Next(150, 250), (int) byte.MaxValue, this.StageData.Ran.Next(150, (int) byte.MaxValue));
      }
    }

    public override void Show()
    {
    }
  }
}
