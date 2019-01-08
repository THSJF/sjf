// Decompiled with JetBrains decompiler
// Type: Shooting.SubPlane_Sanae
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class SubPlane_Sanae : BaseSubPlane
  {
    public SubPlane_Sanae(StageDataPackage StageData, PointF Position)
      : base(StageData, "SanaeSubPlane", Position)
    {
      this.AngleDegree = 90.0;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.Scale = (float) (1.0 + 0.100000001490116 * Math.Sin((double) this.TimeMain / 40.0 * 2.0 * Math.PI));
    }

    public override void Shoot()
    {
      if (this.KClass.Key_Shift)
      {
        BaseMyBullet_Touhou baseMyBulletTouhou1 = new BaseMyBullet_Touhou(this.StageData, "SanaeSubBullet02", this.OriginalPosition, 40f, this.ShootDirection - 0.0299999993294477);
        baseMyBulletTouhou1.Angle = 1.57079637050629;
        baseMyBulletTouhou1.Damage = 3;
        BaseMyBullet_Touhou baseMyBulletTouhou2 = new BaseMyBullet_Touhou(this.StageData, "SanaeSubBullet02", this.OriginalPosition, 40f, this.ShootDirection + 0.0299999993294477);
        baseMyBulletTouhou2.Angle = 1.57079637050629;
        baseMyBulletTouhou2.Damage = 3;
      }
      else
      {
        BaseMyBullet_Touhou baseMyBulletTouhou1 = new BaseMyBullet_Touhou(this.StageData, "SanaeSubBullet00", this.OriginalPosition, 30f, this.ShootDirection - 0.150000005960464);
        baseMyBulletTouhou1.Angle = 3.14159274101257;
        baseMyBulletTouhou1.Damage = 7;
        baseMyBulletTouhou1.Mirrored = this.Mirrored;
        BaseMyBullet_Touhou baseMyBulletTouhou2 = new BaseMyBullet_Touhou(this.StageData, "SanaeSubBullet00", this.OriginalPosition, 30f, this.ShootDirection + 0.150000005960464);
        baseMyBulletTouhou2.Angle = 3.14159274101257;
        baseMyBulletTouhou2.Damage = 7;
        baseMyBulletTouhou2.Mirrored = this.Mirrored;
        BaseMyBullet_Touhou baseMyBulletTouhou3 = new BaseMyBullet_Touhou(this.StageData, "SanaeSubBullet00", this.OriginalPosition, 30f, this.ShootDirection);
        baseMyBulletTouhou3.Angle = 3.14159274101257;
        baseMyBulletTouhou3.Damage = 7;
        baseMyBulletTouhou3.Mirrored = this.Mirrored;
      }
    }

    public override void Show()
    {
      if (!this.Enabled)
        return;
      if (this.MyPlane.Power >= 400)
      {
        float scale = this.Scale;
        float transparentValueF = this.TransparentValueF;
        this.Scale = 1.3f;
        this.TransparentValueF = 150f;
        base.Show();
        this.TransparentValueF = transparentValueF;
        this.Scale = scale;
      }
      base.Show();
    }
  }
}
