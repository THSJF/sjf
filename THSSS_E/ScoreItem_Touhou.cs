// Decompiled with JetBrains decompiler
// Type: Shooting.ScoreItem_Touhou
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class ScoreItem_Touhou : BaseItem_Touhou
  {
    public ScoreItem_Touhou(StageDataPackage StageData, PointF OriginalPosition)
      : base(StageData, "Item-1", OriginalPosition)
    {
      this.Region = 5;
    }

    public override void HitCheckAll()
    {
      base.HitCheckAll();
      if (!this.HitCheck((BaseObject) this.MyPlane))
        return;
      this.ItemList.Remove((BaseItem) this);
      long ScoreValue;
      if (this.Doubled)
      {
        ScoreValue = (long) ((double) this.MyPlane.HighItemScore * (double) this.MyPlane.Rate) / 10L * 10L;
        new ParticleScoreValue(this.StageData, this.OriginalPosition, ScoreValue).ColorValue = Color.FromArgb(254, 222, 63);
      }
      else
      {
        ScoreValue = (long) (10 + (this.MyPlane.HighItemScore - 10) * (448 - (int) this.OriginalPosition.Y) / 320) / 10L * 10L;
        ParticleScoreValue particleScoreValue = new ParticleScoreValue(this.StageData, this.OriginalPosition, ScoreValue);
      }
      this.MyPlane.Score += ScoreValue;
      this.MyPlane.StarPoint += 20;
      this.StageData.SoundPlay("se_item00.wav", this.OriginalPosition.X / (float) this.BoundRect.Width);
    }

    public override void Show()
    {
      base.Show();
      if ((double) this.OriginalPosition.Y >= -8.0)
        return;
      this.SpriteMain.Draw2D(this.TextureObjectDictionary["Item-9"], 1f, 0.0f, new PointF(this.Position.X, (float) this.BoundRect.Top), Color.FromArgb(this.TransparentValue, this.ColorValue));
    }
  }
}
