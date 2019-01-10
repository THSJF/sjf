using SlimDX.Direct3D9;
using System.Drawing;

namespace Shooting {
    public class TextureObject {
        public Texture TXTure { get; set; }
        public int Width => PosRect.Width;
        public int Height => PosRect.Height;
        public int SrcWidth { get; set; }
        public int SrcHeight { get; set; }
        public Rectangle PosRect { get; set; }
        public int OffsetX { get; set; }
        public int OffsetY { get; set; }
        public PointF RotatingCenter {
            get {
                Rectangle posRect = PosRect;
                double num1 = posRect.Width/2+OffsetX;
                posRect=PosRect;
                double num2 = posRect.Height/2+OffsetY;
                return new PointF((float)num1,(float)num2);
            }
        }
        public PointF LeftTop => new PointF(0.0f,0.0f);
        public PointF GetRightTop() {
            return new PointF(Width,0.0f);
        }
        public void Dispose() {
            if(TXTure.Disposed) return;
            TXTure.Dispose();
        }
    }
}
