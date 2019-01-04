// Decompiled with JetBrains decompiler
// Type: Shooting.BackgroundSakura
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class BackgroundSakura : BaseParticle3D
  {
    public BackgroundSakura(StageDataPackage StageData)
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
      int num1 = 25;
      float Velocity = 2.7f;
      if (this.Boss != null && this.Boss.Life >= 2)
      {
        num1 = 50;
        Velocity = 1.35f;
      }
      if (this.Time % num1 != 0)
        return;
      int num2 = this.Time / 2;
      if (num2 > 110)
        num2 = 110;
      BackgroundParticle3D1 backgroundParticle3D1 = new BackgroundParticle3D1(this.StageData, "Sakura", new PointF((float) (num2 + this.Ran.Next(30)), -80f), Velocity, 1.72079633275536, 350);
      backgroundParticle3D1.Angle = (double) this.StageData.Ran.Next(-10, 10) * 3.14159274101257 / 180.0;
      backgroundParticle3D1.Active = true;
      backgroundParticle3D1.MaxTransparent = 60;
      backgroundParticle3D1.Direction3D = 0.75;
      backgroundParticle3D1.Depth = -100f;
      backgroundParticle3D1.MaxDepth = 1000f;
      backgroundParticle3D1.OutsideRegion = 128;
    }

    public override void Show()
    {
    }
  }
}
