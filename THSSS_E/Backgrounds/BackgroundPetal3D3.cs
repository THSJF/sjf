// Decompiled with JetBrains decompiler
// Type: Shooting.BackgroundPetal3D3
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using System;
using System.Drawing;

namespace Shooting
{
  internal class BackgroundPetal3D3 : BaseParticle3D
  {
    public BackgroundPetal3D3(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.Background3D.BackgroundParticleList.Add((BaseParticle3D) this);
    }

    public override void Ctrl()
    {
      ++this.Time;
      this.Shoot();
    }

    public override void Shoot()
    {
      if (this.Time % 4 != 0)
        return;
      for (int index = 0; index < 3; ++index)
      {
        BackgroundParticle3D2 backgroundParticle3D2 = new BackgroundParticle3D2(this.StageData, "Petal0" + this.Ran.Next(4).ToString(), new PointF((float) this.StageData.Ran.Next(0, this.BoundRect.Width), (float) this.StageData.Ran.Next(-150, this.Time > 600 ? 100 : 300)), (float) this.StageData.Ran.Next(3, 6), Math.PI / 2.0 + (double) this.StageData.Ran.Next(-4, 3) / 10.0, 250);
        backgroundParticle3D2.Angle = (double) this.StageData.Ran.Next(0, 360) * 3.14159274101257 / 180.0;
        backgroundParticle3D2.AngularVelocity3D = (float) this.StageData.Ran.Next(10) / 100f;
        backgroundParticle3D2.Scale = (float) this.StageData.Ran.Next(4, 6) / 10f;
        backgroundParticle3D2.RotatingAxis = new Vector3((float) this.StageData.Ran.Next(-100, 100), (float) this.StageData.Ran.Next(-100, 100), (float) this.StageData.Ran.Next(-100, 100));
        backgroundParticle3D2.MaxTransparent = 160;
        backgroundParticle3D2.Depth = (float) this.Ran.Next(-300, 0);
        backgroundParticle3D2.MaxDepth = 1000f;
        backgroundParticle3D2.Direction3D = this.Time > 600 ? Math.PI / 6.0 : Math.PI / 4.0;
      }
    }

    public override void Show()
    {
    }
  }
}
