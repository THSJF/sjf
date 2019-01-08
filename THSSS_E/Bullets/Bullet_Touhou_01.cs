 
// Type: Shooting.Bullet_Touhou_01
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class Bullet_Touhou_01 : BaseBullet_Touhou
  {
    public float Velocity0 { get; set; }

    public float Velocity1 { get; set; }

    public int Time1 { get; set; }

    public float Velocity2 { get; set; }

    public int Time2 { get; set; }

    public Bullet_Touhou_01(
      StageDataPackage StageData,
      string textureName,
      PointF OriginalPosition,
      float Velocity,
      double Direction,
      byte ColorType)
      : base(StageData, textureName, OriginalPosition, Velocity, Direction, ColorType)
    {
      this.Velocity0 = Velocity;
    }

    public override void Ctrl()
    {
      if (this.Time < this.Time1)
        this.Accelerate = (this.Velocity1 - this.Velocity0) / (float) this.Time1;
      else if (this.Time1 == this.Time)
        this.Accelerate = 0.0f;
      else if (this.Time1 < this.Time && this.Time < this.Time2)
        this.Accelerate = (this.Velocity2 - this.Velocity1) / (float) (this.Time2 - this.Time1);
      else if (this.Time2 == this.Time)
        this.Accelerate = 0.0f;
      base.Ctrl();
    }
  }
}
