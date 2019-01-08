// Decompiled with JetBrains decompiler
// Type: Shooting.PowerItem_Touhou
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class PowerItem_Touhou : BaseItem_Touhou
  {
    public PowerItem_Touhou(StageDataPackage StageData, PointF OriginalPosition)
      : base(StageData, "Item-0", OriginalPosition)
    {
      this.Region = 5;
    }

    public override void HitCheckAll()
    {
      base.HitCheckAll();
      if (!this.HitCheck((BaseObject) this.MyPlane))
        return;
      this.ItemList.Remove((BaseItem) this);
      float power = (float) this.MyPlane.Power;
      this.MyPlane.Power += 2;
      if ((double) power != (double) this.MyPlane.Power && this.MyPlane.Power % 100 == 0)
        this.StageData.SoundPlay("se_powerup.wav");
      int num = this.MyPlane.Power == 400 ? 51200 : 10;
      this.MyPlane.Score += (long) num;
      this.MyPlane.StarPoint += 20;
      if (this.MyPlane.Power == 400)
      {
        ParticleScoreValue particleScoreValue = new ParticleScoreValue(this.StageData, this.OriginalPosition, (long) num);
      }
      this.StageData.SoundPlay("se_item00.wav", this.OriginalPosition.X / (float) this.BoundRect.Width);
    }

    public override void Show()
    {
      base.Show();
      if ((double) this.OriginalPosition.Y >= -8.0)
        return;
      this.SpriteMain.Draw2D(this.TextureObjectDictionary["Item-8"], 1f, 0.0f, new PointF(this.Position.X, (float) this.BoundRect.Top), Color.FromArgb(this.TransparentValue, this.ColorValue));
    }
  }
}
