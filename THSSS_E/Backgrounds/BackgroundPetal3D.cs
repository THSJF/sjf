// Decompiled with JetBrains decompiler
// Type: Shooting.BackgroundPetal3D
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using System;
using System.Drawing;

namespace Shooting
{
  internal class BackgroundPetal3D : BaseParticle3D
  {
    public BackgroundPetal3D(StageDataPackage StageData)
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
      if (this.Time % 5 != 0)
        return;
      for (int index = 0; index < 3; ++index)
      {
        BackgroundParticle3D1 backgroundParticle3D1 = new BackgroundParticle3D1(this.StageData, "Petal3" + this.Ran.Next(4).ToString(), new PointF((float) this.StageData.Ran.Next(280, this.BoundRect.Width + 160), (float) this.StageData.Ran.Next(-20, 0)), (float) this.StageData.Ran.Next(15, 25) / 10f, Math.PI / 2.0 + (double) this.StageData.Ran.Next(1, 8) / 10.0, 200);
        backgroundParticle3D1.Angle = (double) this.StageData.Ran.Next(0, 360) * 3.14159274101257 / 180.0;
        backgroundParticle3D1.AngularVelocity3D = (float) this.StageData.Ran.Next(10) / 100f;
        backgroundParticle3D1.Scale = (float) this.StageData.Ran.Next(35, 50) / 100f;
        backgroundParticle3D1.RotatingAxis = new Vector3((float) this.StageData.Ran.Next(-100, 100), (float) this.StageData.Ran.Next(-100, 100), (float) this.StageData.Ran.Next(-100, 100));
        backgroundParticle3D1.MaxTransparent = 200;
        backgroundParticle3D1.Depth = (float) this.Ran.Next(0, 30);
      }
    }

    public override void Show()
    {
    }
  }
}
