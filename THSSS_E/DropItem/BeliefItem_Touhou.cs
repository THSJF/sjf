 
// Type: Shooting.BeliefItem_Touhou
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class BeliefItem_Touhou : BaseItem_Touhou
  {
    public BeliefItem_Touhou(StageDataPackage StageData, PointF OriginalPosition)
      : base(StageData, "Item-2", OriginalPosition)
    {
      this.Region = 5;
    }

    public override void HitCheckAll()
    {
      base.HitCheckAll();
      if (!this.HitCheck((BaseObject) this.MyPlane))
        return;
      this.ItemList.Remove((BaseItem) this);
      this.MyPlane.HighItemScore += 300;
      this.MyPlane.StarPoint += 20;
      this.StageData.SoundPlay("se_item00.wav", this.OriginalPosition.X / (float) this.BoundRect.Width);
    }

    public override void Show()
    {
      base.Show();
      if ((double) this.OriginalPosition.Y >= -8.0)
        return;
      this.SpriteMain.Draw2D(this.TextureObjectDictionary["Item-10"], 1f, 0.0f, new PointF(this.Position.X, (float) this.BoundRect.Top), Color.FromArgb(this.TransparentValue, this.ColorValue));
    }
  }
}
