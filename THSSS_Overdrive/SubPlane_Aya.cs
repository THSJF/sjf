// Decompiled with JetBrains decompiler
// Type: Shooting.SubPlane_Aya
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class SubPlane_Aya : BaseSubPlane
  {
    private int shootFlag = 0;

    public SubPlane_Aya(StageDataPackage StageData, PointF Position)
      : base(StageData, "Center", Position)
    {
    }

    public override void Refresh()
    {
      base.Refresh();
      this.shootFlag = 0;
    }

    public override void Shoot()
    {
      BaseMyBullet_Touhou baseMyBulletTouhou1 = new BaseMyBullet_Touhou(this.StageData, "ReimuAyaBullet01", this.OriginalPosition, 8f, this.ShootDirection);
      baseMyBulletTouhou1.TransparentValueF = 150f;
      baseMyBulletTouhou1.Angle = 1.57079637050629;
      baseMyBulletTouhou1.Damage = 6;
      if (this.shootFlag++ % 2 != 0)
        return;
      BaseMyBullet_Touhou baseMyBulletTouhou2 = new BaseMyBullet_Touhou(this.StageData, "ReimuAyaBullet01", this.OriginalPosition, 8f, this.ShootDirection + (double) this.Ran.Next(-3, 4) / 20.0);
      baseMyBulletTouhou2.TransparentValueF = 150f;
      baseMyBulletTouhou2.Angle = 1.57079637050629;
      baseMyBulletTouhou2.Damage = 6;
    }
  }
}
