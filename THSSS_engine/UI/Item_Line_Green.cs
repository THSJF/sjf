 
// Type: Shooting.Item_Line_Green
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class Item_Line_Green : Item_Line
  {
    public Item_Line_Green(StageDataPackage StageData, PointF OriginalPosition)
      : base(StageData, OriginalPosition)
    {
      this.ColorValue = Color.FromArgb(177, (int) byte.MaxValue, 191);
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.MaxValue = 3000;
      this.Value = 0;
      this.Text = this.MyPlane.StarPoint.ToString("N0");
      this.Text = this.Text.PadLeft(11, ' ');
    }
  }
}
