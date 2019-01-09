 
// Type: Shooting.Item_Line_SpellChip
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class Item_Line_SpellChip : Item_Line
  {
    public Item_Line_SpellChip(StageDataPackage StageData, PointF OriginalPosition)
      : base(StageData, OriginalPosition)
    {
      this.FontType = "ShardNum_";
      this.Delta = 9;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.Value = 0;
      int num = this.MyPlane.SpellChip;
      string str1 = num.ToString();
      num = this.MyPlane.nextSpellChip;
      string str2 = num.ToString();
      this.Text = str1 + "/" + str2;
      this.Text = this.Text.PadLeft(5, ' ');
    }
  }
}
