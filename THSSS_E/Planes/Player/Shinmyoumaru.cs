// Decompiled with JetBrains decompiler
// Type: Shooting.Shinmyoumaru
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class Shinmyoumaru : BaseSubPlane
  {
    public float IndexX { get; set; }

    public int IndexY { get; set; }

    public Shinmyoumaru(StageDataPackage StageData, PointF Position)
      : base(StageData, "ReimuSubPlane", Position)
    {
      this.AngularVelocityDegree = 5f;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.TextureCtrl();
    }

    public void TextureCtrl()
    {
      if (!this.KClass.Key_Shift)
      {
        this.TxtureObject = this.TextureObjectDictionary["ReimuSubPlane"];
      }
      else
      {
        this.Angle = Math.PI / 2.0;
        int indexY = this.IndexY;
        if ((double) this.Vx > 0.5)
        {
          this.IndexY = 2;
          if ((double) this.IndexX < 4.0)
            this.IndexX += 0.5f;
          else
            this.IndexX = (float) (4 + this.Time % 24 / 6);
        }
        else if ((double) this.Vx < -0.5)
        {
          this.IndexY = 1;
          if ((double) this.IndexX < 4.0)
            this.IndexX += 0.5f;
          else
            this.IndexX = (float) (4 + this.Time % 24 / 6);
        }
        else
        {
          this.IndexY = 0;
          this.IndexX = (float) (this.Time % 48 / 6);
        }
        if (indexY != this.IndexY)
          this.IndexX = 1f;
        if ((double) this.IndexX > 7.0)
          this.IndexX = 7f;
        int num = this.IndexY;
        string str1 = num.ToString();
        num = (int) this.IndexX;
        string str2 = num.ToString();
        this.TxtureObject = this.TextureObjectDictionary["Maru" + str1 + str2];
      }
    }

    public override void Shoot()
    {
      if (this.KClass.Key_Shift)
      {
        BaseMyBullet_Touhou baseMyBulletTouhou1 = new BaseMyBullet_Touhou(this.StageData, "MaruBullet", this.OriginalPosition, 18f, this.ShootDirection + Math.PI / 60.0);
        baseMyBulletTouhou1.Angle = 1.57079637050629;
        baseMyBulletTouhou1.Damage = 5;
        BaseMyBullet_Touhou baseMyBulletTouhou2 = new BaseMyBullet_Touhou(this.StageData, "MaruBullet", this.OriginalPosition, 18f, this.ShootDirection - Math.PI / 60.0);
        baseMyBulletTouhou2.Angle = 1.57079637050629;
        baseMyBulletTouhou2.Damage = 5;
      }
      else
      {
        BulletGuidance bulletGuidance = new BulletGuidance(this.StageData, "ReimuSubBullet", this.Position, 8f, this.ShootDirection);
        bulletGuidance.TransparentValueF = 180f;
        bulletGuidance.Angle = 1.57079637050629;
        bulletGuidance.Damage = 9;
      }
    }

    public override void Show()
    {
      if (!this.Enabled || this.TxtureObject == null)
        return;
      if (!this.KClass.Key_Shift)
      {
        double num = (double) (-this.Time * 5 % 360) * Math.PI / 180.0;
        if (this.MyPlane.Power >= 400)
          this.SpriteMain.Draw2D(this.TxtureObject, 1.3f, 1.3f, -(float) num, this.Position, Color.FromArgb(this.TransparentValue * 6 / 10, this.ColorValue), this.Mirrored);
        this.SpriteMain.Draw2D(this.TxtureObject, this.ScaleWidth, this.ScaleLength, (float) num, this.Position, Color.FromArgb(this.TransparentValue, this.ColorValue), this.Mirrored);
      }
      else
        base.Show();
    }
  }
}
