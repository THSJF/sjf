 
// Type: Shooting.BackgroundBlack
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class BackgroundBlack : BaseObject
  {
    public BackgroundBlack(StageDataPackage StageData, PointF Position)
      : base(StageData, "MyBullet0008", new PointF(0.0f, 0.0f), 0.0f, 0.0)
    {
      this.Background.BackgroundList.Add((BaseObject) this);
      this.Position = Position;
      this.Scale = 1f;
      this.LifeTime = 350;
      this.TransparentValueF = 0.0f;
      this.MaxTransparent = 180;
      this.ColorValue = Color.Black;
    }

    public override void Ctrl()
    {
      ++this.Time;
      ++this.Scale;
      if (this.Time < 40)
        this.TransparentValueF += 6f;
      if (this.Time <= this.LifeTime - 40)
        return;
      this.TransparentValueF -= 6f;
    }
  }
}
