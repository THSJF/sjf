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
