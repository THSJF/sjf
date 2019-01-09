using SlimDX.Direct3D9;
using System.Drawing;

namespace Shooting
{
  internal class StoryBox : BaseStoryItem
  {
    private string text;
    private Texture StringTexture;
    private System.Drawing.Font sysfont;
    private char[] TextArray;
    private string text2;
    private Texture StringTexture2;
    public Color FontColor2 = new Color();
        public string DrawText2;
    private char[] TextArray2;

    private SlimDX.Direct3D9.Font DXfont { get; set; }

    public Color FontColor { get; set; }

    public int OffsetX { get; set; }

    public int OffsetY { get; set; }

    public bool Shadowed { get; set; }

    public string DrawText { get; set; }

    public string Text
    {
      get
      {
        return this.text;
      }
      set
      {
        if (!(value != this.text))
          return;
        this.text = value;
        this.TextArray = this.text.ToCharArray();
        this.DrawText = "";
        this.Time = 0;
      }
    }

    public string Text2
    {
      get
      {
        return this.text2;
      }
      set
      {
        if (!(value != this.text2))
          return;
        this.text2 = value;
        this.TextArray2 = this.text2.ToCharArray();
        this.DrawText2 = "";
        this.Time = 0;
      }
    }

    public StoryBox(StageDataPackage StageData)
      : base(StageData)
    {
      this.TxtureObject = this.TextureObjectDictionary["对话框"];
      Rectangle boundRect = this.BoundRect;
      double left = (double) boundRect.Left;
      boundRect = this.BoundRect;
      int bottom = boundRect.Bottom;
      int height = this.TxtureObject.Height;
      boundRect = this.BoundRect;
      int width = boundRect.Width;
      int num1 = height * width / this.TxtureObject.Width;
      double num2 = (double) (bottom - num1 - 8);
      this.Position = new PointF((float) left, (float) num2);
      this.Velocity = 0.0f;
      this.Direction = 0.0;
      this.TransparentValueF = 0.0f;
      this.TransparentVelocity = 10f;
      this.OffsetX = 20;
      this.OffsetY = 21;
      this.Shadowed = true;
      this.sysfont = new System.Drawing.Font(StageData.GlobalData.FontType, 1536f / (float) Dpi.PixelsPerXLogicalInch, FontStyle.Bold);
      this.DXfont = new SlimDX.Direct3D9.Font(StageData.DeviceMain, this.sysfont);
      this.FontColor = Color.White;
    }

    public override void Ctrl()
    {
      if (this.DrawText != null && this.DrawText.Replace("\r\n", "") == this.text)
      {
        this.TransparentValueF = (float) this.MaxTransparent;
      }
      else
      {
        if (this.TextArray != null && this.Time < this.TextArray.Length)
        {
          if ((double) this.DXfont.MeasureString(this.SpriteMain.sprite, this.DrawText + this.TextArray[this.Time].ToString(), DrawTextFormat.Left).Width / 1.14999997615814 > (double) (this.TxtureObject.Width - this.OffsetX))
            this.DrawText += "\r\n";
          this.DrawText += this.TextArray[this.Time].ToString();
        }
        if (this.StringTexture != null)
          this.StringTexture.Dispose();
        this.StringTexture = this.StageData.DrawString(this.DrawText, this.sysfont, Brushes.White, 512, 256);
        if (this.TextArray2 != null && this.Time < this.TextArray2.Length)
        {
          if ((double) this.DXfont.MeasureString(this.SpriteMain.sprite, this.DrawText2 + this.TextArray2[this.Time].ToString(), DrawTextFormat.Left).Width / 1.14999997615814 > (double) (this.TxtureObject.Width - this.OffsetX))
            this.DrawText2 += "\r\n";
          this.DrawText2 += this.TextArray2[this.Time].ToString();
        }
        if (this.StringTexture2 != null)
          this.StringTexture2.Dispose();
        this.StringTexture2 = this.StageData.DrawString(this.DrawText2, this.sysfont, Brushes.White, 512, 256);
        base.Ctrl();
      }
    }

    public void DrawFullText()
    {
      StoryBox storyBox1;
      if (this.TextArray != null)
      {
        for (; this.Time < this.TextArray.Length; ++storyBox1.Time)
        {
          if ((double) this.DXfont.MeasureString(this.SpriteMain.sprite, this.DrawText + this.TextArray[this.Time].ToString(), DrawTextFormat.Left).Width / 1.14999997615814 > (double) (this.TxtureObject.Width - this.OffsetX))
            this.DrawText += "\r\n";
          this.DrawText += this.TextArray[this.Time].ToString();
          storyBox1 = this;
        }
      }
      if (this.StringTexture != null)
        this.StringTexture.Dispose();
      this.StringTexture = this.StageData.DrawString(this.DrawText, this.sysfont, Brushes.White, 512, 256);
      StoryBox storyBox2;
      if (this.TextArray2 != null)
      {
        for (; this.Time < this.TextArray2.Length; ++storyBox2.Time)
        {
          if ((double) this.DXfont.MeasureString(this.SpriteMain.sprite, this.DrawText2 + this.TextArray2[this.Time].ToString(), DrawTextFormat.Left).Width / 1.14999997615814 > (double) (this.TxtureObject.Width - this.OffsetX))
            this.DrawText2 += "\r\n";
          this.DrawText2 += this.TextArray2[this.Time].ToString();
          storyBox2 = this;
        }
      }
      if (this.StringTexture2 != null)
        this.StringTexture2.Dispose();
      this.StringTexture2 = this.StageData.DrawString(this.DrawText2, this.sysfont, Brushes.White, 512, 256);
    }

    public void SetFont(float FontSize)
    {
      if (this.sysfont == null)
        return;
      FontSize = FontSize * 96f / (float) Dpi.PixelsPerXLogicalInch;
      if ((double) this.sysfont.Size == (double) FontSize)
        return;
      this.sysfont = new System.Drawing.Font(this.StageData.GlobalData.FontType, FontSize, FontStyle.Bold);
      this.DXfont = new SlimDX.Direct3D9.Font(this.StageData.DeviceMain, this.sysfont);
    }

    public override void Show()
    {
      SizeF destinationSize1 = new SizeF((float) this.TxtureObject.Width, 116f);
      this.SpriteMain.Draw2D(this.TxtureObject.TXTure, this.TxtureObject.PosRect, destinationSize1, this.TxtureObject.LeftTop, 0.0f, this.Position, Color.FromArgb(this.TransparentValue, Color.White));
      if (this.Text == null || this.StringTexture == null)
        return;
      PointF position1;
      if (this.Shadowed)
      {
        MySprite spriteMain = this.SpriteMain;
        Texture stringTexture = this.StringTexture;
        Rectangle srcRectangle = new Rectangle(0, 0, 512, 256);
        SizeF destinationSize2 = new SizeF(512f, 256f);
        position1 = this.Position;
        double num1 = (double) ((int) position1.X + 2 + this.OffsetX);
        position1 = this.Position;
        double num2 = (double) ((int) position1.Y + 2 + (int) ((double) this.OffsetY * (double) destinationSize1.Height / 90.0));
        PointF position2 = new PointF((float) num1, (float) num2);
        Color color = Color.FromArgb(150, 0, 0, 0);
        spriteMain.Draw2D(stringTexture, srcRectangle, destinationSize2, position2, color);
      }
      MySprite spriteMain1 = this.SpriteMain;
      Texture stringTexture1 = this.StringTexture;
      Rectangle srcRectangle1 = new Rectangle(0, 0, 512, 256);
      SizeF destinationSize3 = new SizeF(512f, 256f);
      position1 = this.Position;
      double num3 = (double) ((int) position1.X + this.OffsetX);
      position1 = this.Position;
      double num4 = (double) ((int) position1.Y + (int) ((double) this.OffsetY * (double) destinationSize1.Height / 90.0));
      PointF position3 = new PointF((float) num3, (float) num4);
      Color fontColor = this.FontColor;
      spriteMain1.Draw2D(stringTexture1, srcRectangle1, destinationSize3, position3, fontColor);
      if (this.StringTexture2 == null)
        return;
      MySprite spriteMain2 = this.SpriteMain;
      Texture stringTexture2 = this.StringTexture2;
      Rectangle srcRectangle2 = new Rectangle(0, 0, 512, 256);
      SizeF destinationSize4 = new SizeF(512f, 256f);
      position1 = this.Position;
      double num5 = (double) ((int) position1.X + this.OffsetX);
      position1 = this.Position;
      double num6 = (double) ((int) position1.Y + (int) ((double) this.OffsetY * (double) destinationSize1.Height / 90.0));
      PointF position4 = new PointF((float) num5, (float) num6);
      Color fontColor2 = this.FontColor2;
      spriteMain2.Draw2D(stringTexture2, srcRectangle2, destinationSize4, position4, fontColor2);
    }

    public override void Dispose()
    {
      this.DXfont.Dispose();
      if (this.StringTexture == null)
        return;
      this.StringTexture.Dispose();
    }
  }
}
