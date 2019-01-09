 
// Type: Shooting.BaseNum
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX.Direct3D9;
using System.Drawing;

namespace Shooting
{
  internal class BaseNum : BaseObject
  {
    private const int NumWidth = 16;

    public int Num { get; set; }

    public int Count { get; set; }

    public BaseNum(StageDataPackage StageData, PointF Position)
      : base(StageData, (string) null, Position, 0.0f, 0.0)
    {
    }

    public override void Show()
    {
      int num1 = this.Num;
      for (int index = 0; index < this.Count; ++index)
      {
        int num2 = num1 % 10;
        num1 /= 10;
        TextureObject textureObject = this.TextureObjectDictionary[num2.ToString()];
        MySprite spriteMain = this.SpriteMain;
        Texture txTure = textureObject.TXTure;
        Rectangle posRect = textureObject.PosRect;
        SizeF destinationSize = new SizeF((float) textureObject.Width, (float) textureObject.Height);
        PointF rotatingCenter = textureObject.RotatingCenter;
        PointF position1 = this.Position;
        double num3 = (double) position1.X + (double) (16 * (this.Count - index - 1));
        position1 = this.Position;
        double y = (double) position1.Y;
        PointF position2 = new PointF((float) num3, (float) y);
        Color white = Color.White;
        spriteMain.Draw2D(txTure, posRect, destinationSize, rotatingCenter, 0.0f, position2, white);
      }
    }
  }
}
