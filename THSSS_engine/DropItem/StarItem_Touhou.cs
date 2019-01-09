 
// Type: Shooting.StarItem_Touhou
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class StarItem_Touhou : BaseItem_Touhou
  {
    public StarItem_Touhou(StageDataPackage StageData, PointF OriginalPosition)
      : base(StageData, "SmallStar", OriginalPosition)
    {
      this.Region = 5;
      this.AngularVelocity = 0.0f;
      this.DirectionDegree += (double) this.Ran.Next(-49, 50) / 10.0;
      this.MaxTransparent = 80;
      this.TransparentValueF = 0.0f;
      this.TransparentVelocity = 16f;
      this.Active = true;
      this.AngleWithDirection = false;
    }

    public override void HitCheckAll()
    {
      if (!this.HitCheck((BaseObject) this.MyPlane))
        return;
      this.ItemList.Remove((BaseItem) this);
      ++this.MyPlane.StarPoint;
      this.MyPlane.Score += 100L;
      if (++this.MyPlane.GreenPoint % 2 == 0)
        this.MyPlane.HighItemScore += 10;
      this.StageData.SoundPlay("se_item00.wav", this.OriginalPosition.X / (float) this.BoundRect.Width);
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time == 40)
        this.Obtain = true;
      this.Angle = 0.0;
    }
  }
}
