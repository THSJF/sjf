 
// Type: Shooting.Item_Line_Score
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class Item_Line_Score : Item_Line
  {
    private long scoreValue { get; set; }

    public Item_Line_Score(StageDataPackage StageData, PointF OriginalPosition)
      : base(StageData, OriginalPosition)
    {
      this.FontType = "ScoreNum_";
    }

    public override void Show()
    {
      this.MaxValue = 0;
      this.Value = 0;
      if (this.MyPlane.Score - this.scoreValue < 1000L)
        this.scoreValue += 1000L;
      else
        this.scoreValue += (this.MyPlane.Score - this.scoreValue) / 5L;
      if (this.scoreValue > this.MyPlane.Score)
        this.scoreValue = this.MyPlane.Score;
      this.Text = (10000000000L + this.scoreValue).ToString("N0");
      this.Text = this.Text.Remove(0, 1).PadLeft(10, ' ');
      base.Show();
    }
  }
}
