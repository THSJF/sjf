 
// Type: Shooting.EnemyPlane_TouhouSmall
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class EnemyPlane_TouhouSmall : BaseEnemyPlane_Touhou
  {
    protected bool BackFire { get; set; }

    protected Color BackFireColor { get; set; }

    public EnemyPlane_TouhouSmall(
      StageDataPackage StageData,
      string EnemyName,
      PointF OriginalPosition,
      float Velocity,
      double Direction,
      byte ColorType)
      : base(StageData, EnemyName, OriginalPosition, Velocity, Direction, ColorType)
    {
      this.HealthPoint = 10f;
      this.ItemCount = 1;
    }

    public EnemyPlane_TouhouSmall(
      StageDataPackage StageData,
      string EnemyName,
      PointF OriginalPosition,
      float Velocity,
      double Direction)
      : base(StageData, EnemyName, OriginalPosition, Velocity, Direction)
    {
      this.HealthPoint = 20f;
      this.ItemCount = 1;
    }

    public override void Show()
    {
      if (this.BackFire)
        this.SpriteMain.Draw2D(this.TextureObjectDictionary["GhostFire_" + (object) (this.Time % 32 / 4)], this.ScaleWidth, this.ScaleLength, 0.0f, this.Position, Color.FromArgb(192, this.BackFireColor), this.Mirrored);
      base.Show();
    }

    public void SetBackFire()
    {
      this.BackFire = true;
      switch (this.ColorType)
      {
        case 0:
          this.BackFireColor = Color.Red;
          break;
        case 1:
          this.BackFireColor = Color.Blue;
          break;
        case 2:
          this.BackFireColor = Color.Green;
          break;
        case 3:
          this.BackFireColor = Color.Yellow;
          break;
        default:
          this.BackFireColor = Color.White;
          break;
      }
    }
  }
}
