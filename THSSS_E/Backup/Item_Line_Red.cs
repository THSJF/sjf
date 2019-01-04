// Decompiled with JetBrains decompiler
// Type: Shooting.Item_Line_Red
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class Item_Line_Red : Item_Line
  {
    public Item_Line_Red(StageDataPackage StageData, PointF OriginalPosition)
      : base(StageData, OriginalPosition)
    {
      this.FontType = "RedNum_";
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.MaxValue = 400;
      this.Value = 0;
      this.Text = ((float) this.MyPlane.Power / 100f).ToString("f2") + "/4.00";
      this.Text = this.Text.PadLeft(11, ' ');
    }
  }
}
