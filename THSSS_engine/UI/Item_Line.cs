 
// Type: Shooting.Item_Line
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class Item_Line : BaseInterface
  {
    private int vl = 0;
    public int Delta = 13;

    public int Value
    {
      get
      {
        return this.vl;
      }
      set
      {
        if (value < 0)
          this.vl = 0;
        else if (value > this.MaxValue)
          this.vl = this.MaxValue;
        else
          this.vl = value;
      }
    }

    public int MaxValue { get; set; }

    public string Text { get; set; }

    public Color TextColorValue { get; set; }

    public string FontType { get; set; }

    public Item_Line(StageDataPackage StageData, PointF OriginalPosition)
      : base(StageData, "ItemLine", OriginalPosition)
    {
      this.MaxValue = 1;
      this.TransparentValueF = 0.0f;
    }

    public virtual void DrawText(Point Pos, float Scale, Color color)
    {
      int num = 0;
      char[] charArray = this.Text.ToCharArray();
      for (int index = 0; index < charArray.Length; ++index)
      {
        if (charArray[index] == '.' || charArray[index] == ',')
          num += (int) (8.0 * (double) Scale);
      }
      for (int index = 0; index < charArray.Length; ++index)
      {
        if (charArray[index] == '.' || charArray[index] == ',')
          num -= (int) (5.0 * (double) Scale);
        PointF position = new PointF((float) (Pos.X + 5 + num), (float) (Pos.Y + 6));
        if (charArray[index].ToString() != " ")
          this.SpriteMain.Draw2D(this.TextureObjectDictionary[this.FontType + charArray[index].ToString()], Scale, 0.0f, position, Color.FromArgb(this.TransparentValue, color));
        num += (int) ((double) this.Delta * (double) Scale);
        if (charArray[index] == '.' || charArray[index] == ',')
          num -= (int) (3.0 * (double) Scale);
      }
    }

    public override void Show()
    {
      if (this.MaxValue != 0)
      {
        int width = this.TxtureObject.Width * this.Value / this.MaxValue;
        if (width > 0)
        {
          Size size = new Size(width, this.TxtureObject.Height);
          Rectangle rectangle = new Rectangle(new Point(0, 0), size);
          this.SpriteMain.Draw2D(this.TxtureObject.TXTure, this.TxtureObject.PosRect, (SizeF) size, this.TxtureObject.LeftTop, 0.0f, this.OriginalPosition, Color.FromArgb(this.TransparentValue * 7 / 10, this.ColorValue));
        }
      }
      this.DrawText(new Point((int) this.OriginalPosition.X, (int) this.OriginalPosition.Y + 3), 1f, this.ColorValue);
    }
  }
}
