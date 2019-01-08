 
// Type: Shooting.Bullet_Touhou_01_03
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class Bullet_Touhou_01_03 : Bullet_Touhou_01
  {
    public string SubBulletName { get; set; }

    public Bullet_Touhou_01_03(
      StageDataPackage StageData,
      string textureName,
      PointF OriginalPosition,
      float Velocity,
      double Direction,
      byte ColorType)
      : base(StageData, textureName, OriginalPosition, Velocity, Direction, ColorType)
    {
      this.LifeTime = 50;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time != this.LifeTime)
        return;
      byte colorType = this.ColorType;
      BulletGroupCircle bulletGroupCircle = new BulletGroupCircle(this.StageData, new BaseObject(this.StageData, this.SubBulletName + colorType.ToString(), new PointF(0.0f, 0.0f), 2.5f, 0.0), this.OriginalPosition, this.Direction, (int) this.Difficulty * 2 + 3, 0, colorType);
      this.GiveEndEffect();
    }
  }
}
