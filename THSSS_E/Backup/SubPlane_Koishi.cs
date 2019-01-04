// Decompiled with JetBrains decompiler
// Type: Shooting.SubPlane_Koishi
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class SubPlane_Koishi : BaseSubPlane
  {
    public SubPlane_Koishi(StageDataPackage StageData, PointF Position)
      : base(StageData, "KoishiSubPlane01", Position)
    {
      this.AngleDegree = 90.0;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.Scale = (float) (1.0 + 0.100000001490116 * Math.Sin((double) this.TimeMain / 40.0 * 2.0 * Math.PI));
      if (this.KClass.Key_Shift)
        this.TxtureObject = this.TextureObjectDictionary["KoishiSubPlane00"];
      else
        this.TxtureObject = this.TextureObjectDictionary["KoishiSubPlane01"];
    }

    public override void Shoot()
    {
      if (this.KClass.Key_Shift)
      {
        int num1 = 5;
        double num2 = 24.0 * Math.PI / 180.0 / (double) (num1 - 1);
        double Direction = this.ShootDirection - (double) (num1 - 1) * num2 / 2.0;
        for (int index = 0; index < num1; ++index)
        {
          BaseMyBullet_Touhou baseMyBulletTouhou = new BaseMyBullet_Touhou(this.StageData, "KoishiSubBullet00", this.OriginalPosition, 15f, Direction);
          baseMyBulletTouhou.Angle = 1.57079637050629;
          baseMyBulletTouhou.Damage = 6;
          Direction += num2;
        }
      }
      else
      {
        int num1 = 15;
        double num2 = 120.0 * Math.PI / 180.0 / (double) (num1 - 1);
        double Direction = this.ShootDirection - (double) (num1 - 1) * num2 / 2.0;
        for (int index = 0; index < num1; ++index)
        {
          BaseMyBullet_Touhou baseMyBulletTouhou = new BaseMyBullet_Touhou(this.StageData, "KoishiSubBullet01", this.OriginalPosition, 8f, Direction);
          baseMyBulletTouhou.Angle = 1.57079637050629;
          baseMyBulletTouhou.Damage = 15;
          Direction += num2;
        }
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
