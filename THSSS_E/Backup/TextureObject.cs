// Decompiled with JetBrains decompiler
// Type: Shooting.TextureObject
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX.Direct3D9;
using System.Drawing;

namespace Shooting
{
  public class TextureObject
  {
    public Texture TXTure { get; set; }

    public int Width
    {
      get
      {
        return this.PosRect.Width;
      }
    }

    public int Height
    {
      get
      {
        return this.PosRect.Height;
      }
    }

    public int SrcWidth { get; set; }

    public int SrcHeight { get; set; }

    public Rectangle PosRect { get; set; }

    public int OffsetX { get; set; }

    public int OffsetY { get; set; }

    public PointF RotatingCenter
    {
      get
      {
        Rectangle posRect = this.PosRect;
        double num1 = (double) (posRect.Width / 2 + this.OffsetX);
        posRect = this.PosRect;
        double num2 = (double) (posRect.Height / 2 + this.OffsetY);
        return new PointF((float) num1, (float) num2);
      }
    }

    public PointF LeftTop
    {
      get
      {
        return new PointF(0.0f, 0.0f);
      }
    }

    public PointF RightTop
    {
      get
      {
        return new PointF((float) this.Width, 0.0f);
      }
    }

    public void Dispose()
    {
      if (this.TXTure.Disposed)
        return;
      this.TXTure.Dispose();
    }
  }
}
