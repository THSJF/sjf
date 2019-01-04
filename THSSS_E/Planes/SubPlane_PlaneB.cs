// Decompiled with JetBrains decompiler
// Type: Shooting.SubPlane_PlaneB
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class SubPlane_PlaneB : BaseSubPlane
  {
    public SubPlane_PlaneB(StageDataPackage StageData, PointF Position)
      : base(StageData, "MySubPlane", Position)
    {
      this.ShootDirection = -1.0 * Math.PI / 2.0;
    }

    public override void Shoot()
    {
      BaseMyBullet_Touhou baseMyBulletTouhou = new BaseMyBullet_Touhou(this.StageData, "子机子弹", this.OriginalPosition, 4f, this.ShootDirection);
      baseMyBulletTouhou.Angle = 3.14159274101257;
      baseMyBulletTouhou.Damage = 5;
      baseMyBulletTouhou.Accelerate = 0.5f;
    }
  }
}
