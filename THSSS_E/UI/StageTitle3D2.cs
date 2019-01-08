 
// Type: Shooting.StageTitle3D2
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using SlimDX.Direct3D9;
using System.Drawing;

namespace Shooting
{
  public class StageTitle3D2 : StageTitle3D
  {
    public StageTitle3D2(StageDataPackage StageData, string TextureName)
      : base(StageData, TextureName)
    {
      Rectangle boundRect = this.BoundRect;
      double num1 = (double) (boundRect.Width / 2);
      boundRect = this.BoundRect;
      double num2 = (double) (boundRect.Height / 2 - 80);
      this.OriginalPosition = new PointF((float) num1, (float) num2);
    }

    public override void SetupVertex()
    {
      DataStream dataStream = this.vertexBuffer.Lock(0, 0, LockFlags.Discard);
      float num1 = -this.TxtureObject.RotatingCenter.X;
      float num2 = (float) this.TxtureObject.Width - this.TxtureObject.RotatingCenter.X;
      float y1 = -this.TxtureObject.RotatingCenter.Y;
      float y2 = (float) this.TxtureObject.Height - this.TxtureObject.RotatingCenter.Y;
      float num3 = (float) this.TxtureObject.PosRect.X / (float) this.TxtureObject.SrcWidth;
      float num4 = (float) (this.TxtureObject.PosRect.X + this.TxtureObject.Width) / (float) this.TxtureObject.SrcWidth;
      float y3 = (float) this.TxtureObject.PosRect.Y / (float) this.TxtureObject.SrcHeight;
      float y4 = (float) (this.TxtureObject.PosRect.Y + this.TxtureObject.Height) / (float) this.TxtureObject.SrcHeight;
      TexturedColoredVertex[] data = new TexturedColoredVertex[2 * this.Length];
      for (int index = 0; index < this.Length; ++index)
      {
        int alpha = -10 * index + this.Time * 3;
        if (alpha < 0)
          alpha = 0;
        else if (alpha > this.TransparentValue)
          alpha = this.TransparentValue;
        data[2 * index] = new TexturedColoredVertex(new Vector3(num1 + (num2 - num1) * (float) index / (float) this.Length, y1, 0.0f), new Vector2(num3 + (num4 - num3) * (float) index / (float) this.Length, y3), Color.FromArgb(alpha, this.ColorValue).ToArgb());
        data[2 * index + 1] = new TexturedColoredVertex(new Vector3(num1 + (num2 - num1) * (float) index / (float) this.Length, y2, 0.0f), new Vector2(num3 + (num4 - num3) * (float) index / (float) this.Length, y4), Color.FromArgb(alpha, this.ColorValue).ToArgb());
      }
      dataStream.WriteRange<TexturedColoredVertex>(data);
      this.vertexBuffer.Unlock();
    }
  }
}
