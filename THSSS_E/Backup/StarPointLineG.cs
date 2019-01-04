// Decompiled with JetBrains decompiler
// Type: Shooting.StarPointLineG
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX.Direct3D9;
using System.Drawing;

namespace Shooting
{
  public class StarPointLineG : BaseObject
  {
    protected string type;

    public StarPointLineG(StageDataPackage StageData, PointF OriginalPosition)
    {
      this.StageData = StageData;
      this.OriginalPosition = OriginalPosition;
      this.TransparentValueF = 0.0f;
      this.TransparentVelocity = 10f;
      this.type = "C";
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if ((double) this.MyPlane.OriginalPosition.X < 100.0 && (double) this.MyPlane.OriginalPosition.Y > (double) (this.BoundRect.Height - 140))
        this.TransparentVelocity = -10f;
      else
        this.TransparentVelocity = 10f;
      if (this.TransparentValue < 50)
        this.TransparentValueF = 50f;
      this.TxtureObject = this.TextureObjectDictionary["border" + this.type + "2"];
      if (this.MyPlane.LastColor == EnchantmentType.Green && this.Story == null)
        this.DestPoint = new PointF(66f, 404f);
      else
        this.DestPoint = new PointF(-6f, 404f);
      this.Velocity = 3f;
    }

    public override void Show()
    {
      if (this.TxtureObject == null)
        return;
      this.SpriteMain.Draw2D(this.TextureObjectDictionary["border" + this.type + "1"], 1f, 0.0f, this.OriginalPosition, Color.FromArgb(this.TransparentValue, Color.White));
      int num1 = this.TxtureObject.Height * this.MyPlane.StarPoint / this.MyPlane.maxStarPoint;
      int height = num1 > 1 ? num1 : 1;
      Size size1 = new Size(this.TxtureObject.Width, height);
      Rectangle rectangle;
      ref Rectangle local = ref rectangle;
      Rectangle posRect = this.TxtureObject.PosRect;
      int x1 = posRect.X;
      posRect = this.TxtureObject.PosRect;
      int y = posRect.Y + this.TxtureObject.Height - height;
      Point location = new Point(x1, y);
      Size size2 = size1;
      local = new Rectangle(location, size2);
      MySprite spriteMain = this.SpriteMain;
      Texture txTure = this.TxtureObject.TXTure;
      Rectangle srcRectangle = rectangle;
      SizeF destinationSize = (SizeF) size1;
      PointF rotatingCenter = this.TxtureObject.RotatingCenter;
      PointF originalPosition = this.OriginalPosition;
      double x2 = (double) originalPosition.X;
      originalPosition = this.OriginalPosition;
      double num2 = (double) originalPosition.Y + (double) this.TxtureObject.Height - (double) height;
      PointF position = new PointF((float) x2, (float) num2);
      Color color = Color.FromArgb(this.TransparentValue * 8 / 10, Color.White);
      spriteMain.Draw2D(txTure, srcRectangle, destinationSize, rotatingCenter, 0.0f, position, color);
      this.SpriteMain.Draw2D(this.TextureObjectDictionary["border" + this.type + "0"], 1f, 0.0f, this.OriginalPosition, Color.FromArgb(this.TransparentValue, Color.White));
    }
  }
}
