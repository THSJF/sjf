// Decompiled with JetBrains decompiler
// Type: Shooting.SubPlane_AyaB
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class SubPlane_AyaB : BaseSubPlane
  {
    public SubPlane_AyaB(StageDataPackage StageData, PointF Position)
      : base(StageData, "MarisaSubPlane10", Position)
    {
    }

    public override void Refresh()
    {
      base.Refresh();
    }

    public override void Shoot()
    {
      if (this.KClass.Key_Shift)
      {
        BaseMyBullet_Touhou baseMyBulletTouhou = new BaseMyBullet_Touhou(this.StageData, "AyaBullet10", this.OriginalPosition, 12f, this.ShootDirection);
        baseMyBulletTouhou.Angle = 1.57079637050629;
        baseMyBulletTouhou.Damage = 4;
      }
      else
      {
        BulletGuidance bulletGuidance = new BulletGuidance(this.StageData, "AyaBullet10", this.Position, 8f, this.ShootDirection);
        bulletGuidance.TransparentValueF = 180f;
        bulletGuidance.Angle = 1.57079637050629;
      }
    }
  }
}
