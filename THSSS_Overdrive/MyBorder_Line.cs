// Decompiled with JetBrains decompiler
// Type: Shooting.MyBorder_Line
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class MyBorder_Line : Life_Line
  {
    public MyBorder_Line(StageDataPackage StageData, string textureName, PointF OriginalPosition)
      : base(StageData, textureName, OriginalPosition)
    {
      this.size = 16f;
      this.maxLife = 11;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.Life = this.MyPlane.EnchantmentCount;
    }

    public override void Show()
    {
      SizeF destinationSize = new SizeF(this.size, this.size);
      PointF position = new PointF();
            PointF originalPosition;
      for (int index = 0; index < this.MyPlane.EnchantmentCountNeeded; ++index)
      {
        TextureObject textureObject = this.TextureObjectDictionary["Border0d"];
        ref PointF local = ref position;
        originalPosition = this.OriginalPosition;
        double num = (double) originalPosition.X + (double) (index * 12);
        originalPosition = this.OriginalPosition;
        double y = (double) originalPosition.Y;
        local = new PointF((float) num, (float) y);
        this.SpriteMain.Draw2D(textureObject.TXTure, textureObject.PosRect, destinationSize, new PointF(0.0f, 0.0f), 0.0f, position, Color.FromArgb(this.TransparentValue, Color.White));
      }
      for (int index = 0; index < this.Life; ++index)
      {
        TextureObject textureObject = this.TextureObjectDictionary["Border"];
        ref PointF local = ref position;
        originalPosition = this.OriginalPosition;
        double num = (double) originalPosition.X + (double) (index * 12);
        originalPosition = this.OriginalPosition;
        double y = (double) originalPosition.Y;
        local = new PointF((float) num, (float) y);
        this.SpriteMain.Draw2D(textureObject.TXTure, textureObject.PosRect, destinationSize, new PointF(0.0f, 0.0f), 0.0f, position, Color.FromArgb(this.TransparentValue, Color.White));
      }
    }
  }
}
