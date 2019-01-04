// Decompiled with JetBrains decompiler
// Type: Shooting.SubPlane_Marisa
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class SubPlane_Marisa : BaseSubPlane
  {
    public SubPlane_Marisa(StageDataPackage StageData, PointF Position)
      : base(StageData, "MarisaSubPlane", Position)
    {
    }

    public override void Shoot()
    {
      MarisaLaser marisaLaser = new MarisaLaser(this.StageData, "MarisaSubBullet00", this.OriginalPosition, -96f, this.ShootDirection);
      marisaLaser.Angle = 1.57079637050629;
      marisaLaser.Active = true;
      marisaLaser.SetBinding((BaseObject) this);
    }

    public override void Show()
    {
      if (!this.Enabled || this.TxtureObject == null)
        return;
      double num = (double) (-this.Time * 5 % 360) * Math.PI / 180.0;
      if (this.MyPlane.Power >= 400)
        this.SpriteMain.Draw2D(this.TxtureObject, 1.3f, 1.3f, -(float) num, this.Position, Color.FromArgb(150, this.ColorValue), this.Mirrored);
      this.SpriteMain.Draw2D(this.TxtureObject, this.ScaleWidth, this.ScaleLength, (float) num, this.Position, Color.FromArgb(this.TransparentValue, this.ColorValue), this.Mirrored);
    }
  }
}
