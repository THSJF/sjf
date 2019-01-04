// Decompiled with JetBrains decompiler
// Type: Shooting.Bullet_Touhou_01_02
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class Bullet_Touhou_01_02 : Bullet_Touhou_01
  {
    public string SubBulletName { get; set; }

    public Bullet_Touhou_01_02(
      StageDataPackage StageData,
      string textureName,
      PointF OriginalPosition,
      float Velocity,
      double Direction,
      byte ColorType)
      : base(StageData, textureName, OriginalPosition, Velocity, Direction, ColorType)
    {
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time != this.LifeTime)
        return;
      BaseBullet_Touhou baseBulletTouhou = new BaseBullet_Touhou(this.StageData, this.SubBulletName, this.OriginalPosition, this.Velocity / 2f, this.Direction, this.ColorType);
      this.GiveEndEffect();
    }
  }
}
