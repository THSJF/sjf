// Decompiled with JetBrains decompiler
// Type: Shooting.Planes.Story.DescriptionBox
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX.Direct3D9;
using System.Drawing;

namespace Shooting.Planes.Story
{
  internal class DescriptionBox : BaseStoryItem
  {
    private Texture StringTexture;
    private System.Drawing.Font sysfont;

    private SlimDX.Direct3D9.Font DXfont { get; set; }

    public Color FontColor { get; set; }

    public string Text { get; set; }

    public int OffsetX { get; set; }

    public int OffsetY { get; set; }

    public bool Shadowed { get; set; }

    public DescriptionBox(StageDataPackage StageData)
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
      double num2 = (double) (bottom - num1);
      this.Position = new PointF((float) left, (float) num2);
      this.Velocity = 0.0f;
      this.Direction = 0.0;
      this.TransparentValueF = 0.0f;
      this.MaxTransparent = 200;
      this.TransparentVelocity = 10f;
      this.OffsetX = 20;
      this.OffsetY = 20;
      this.sysfont = new System.Drawing.Font(StageData.GlobalData.FontType, 1536f / (float) Dpi.PixelsPerXLogicalInch, FontStyle.Bold);
      this.DXfont = new SlimDX.Direct3D9.Font(StageData.DeviceMain, this.sysfont);
      this.FontColor = Color.White;
    }

    public override void Ctrl()
    {
      if (this.StringTexture != null)
        this.StringTexture.Dispose();
      this.StringTexture = this.StageData.DrawString(this.Text, this.sysfont, Brushes.White, 1024, 256);
      base.Ctrl();
    }

    public override void Show()
    {
      SizeF destinationSize = new SizeF();
            ref SizeF local = ref destinationSize;
      Rectangle boundRect = this.BoundRect;
      double width1 = (double) boundRect.Width;
      int height = this.TxtureObject.Height;
      boundRect = this.BoundRect;
      int width2 = boundRect.Width;
      double num = (double) (height * width2 / this.TxtureObject.Width);
      local = new SizeF((float) width1, (float) num);
      this.SpriteMain.Draw2D(this.TxtureObject.TXTure, this.TxtureObject.PosRect, destinationSize, new PointF(0.0f, 0.0f), 0.0f, this.Position, Color.FromArgb(this.TransparentValue, Color.White));
      if (this.Text == null || this.StringTexture == null)
        return;
      if (this.Shadowed)
        this.SpriteMain.Draw2D(this.StringTexture, new Rectangle(0, 0, 1024, 256), new SizeF(1024f, 256f), new PointF((float) ((int) this.Position.X + 1 + this.OffsetX), (float) ((int) this.Position.Y + 1 + (int) ((double) this.OffsetY * (double) destinationSize.Height / 90.0))), Color.FromArgb(150, 0, 0, 0));
      this.SpriteMain.Draw2D(this.StringTexture, new Rectangle(0, 0, 1024, 256), new SizeF(1024f, 256f), new PointF((float) ((int) this.Position.X + this.OffsetX), (float) ((int) this.Position.Y + (int) ((double) this.OffsetY * (double) destinationSize.Height / 90.0))), Color.White);
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
