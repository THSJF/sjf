// Decompiled with JetBrains decompiler
// Type: Shooting.BulletYukaLaser
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class BulletYukaLaser : BulletLaser
  {
    public BulletYukaLaser(
      StageDataPackage StageData,
      string textureName,
      PointF OriginalPosition,
      float Velocity,
      double Direction)
      : base(StageData, textureName, OriginalPosition, Velocity, Direction)
    {
      this.OriginalPosition = OriginalPosition;
      this.ScaleWidth = 0.05f;
      this.Active = true;
      this.LifeTime = 500;
      this.ColorValue = Color.FromArgb((int) byte.MaxValue, 120, 80);
      this.UnRemoveable = true;
      this.Angle = 0.0;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.Region = (int) ((double) this.TxtureObject.Width / 2.0 * 0.699999988079071);
      if ((double) this.ScaleLength < (double) this.DesScaleLength)
        this.ScaleLength += 0.05f;
      else if ((double) this.ScaleWidth < (double) this.DesScaleWidth)
        this.ScaleWidth += 0.05f;
      if (this.Time < this.LifeTime - 50)
        this.TransparentValueF = (float) (150 + this.Ran.Next(40));
      else
        this.TransparentValueF = (float) ((this.LifeTime - this.Time) * 2 - 20 + this.Ran.Next(40));
    }

    public override void HitCheckAll()
    {
      if (!this.MyPlane.HitEnabled || !this.HitCheck((BaseObject) this.MyPlane) || this.Time >= this.LifeTime - 50)
        return;
      this.MyPlane.PreMiss();
    }
  }
}
