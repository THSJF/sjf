 
// Type: Shooting.MySpell_Line
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class MySpell_Line : Life_Line
  {
    public MySpell_Line(StageDataPackage StageData, string textureName, PointF OriginalPosition)
      : base(StageData, textureName, OriginalPosition)
    {
      this.size = 16f;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.Life = this.MyPlane.Spell;
    }

    public override void Show()
    {
      SizeF destinationSize = new SizeF(this.size, this.size);
      PointF position = new PointF();
            PointF originalPosition;
      for (int index = 0; index < 8; ++index)
      {
        TextureObject textureObject = this.TextureObjectDictionary["Bomb0d"];
        ref PointF local = ref position;
        originalPosition = this.OriginalPosition;
        double num = (double) originalPosition.X + (double) index * (double) this.size;
        originalPosition = this.OriginalPosition;
        double y = (double) originalPosition.Y;
        local = new PointF((float) num, (float) y);
        this.SpriteMain.Draw2D(textureObject.TXTure, textureObject.PosRect, destinationSize, new PointF(0.0f, 0.0f), 0.0f, position, Color.FromArgb(this.TransparentValue, Color.White));
      }
      for (int index = 0; index < this.Life; ++index)
      {
        TextureObject textureObject = this.TextureObjectDictionary["Bomb"];
        ref PointF local = ref position;
        originalPosition = this.OriginalPosition;
        double num = (double) originalPosition.X + (double) index * (double) this.size;
        originalPosition = this.OriginalPosition;
        double y = (double) originalPosition.Y;
        local = new PointF((float) num, (float) y);
        this.SpriteMain.Draw2D(textureObject.TXTure, textureObject.PosRect, destinationSize, new PointF(0.0f, 0.0f), 0.0f, position, Color.FromArgb(this.TransparentValue, Color.White));
      }
      if (this.Life >= 8)
        return;
      int num1 = this.MyPlane.SpellChip * 4 / this.MyPlane.nextSpellChip;
      if (num1 <= 0)
        return;
      TextureObject textureObject1 = this.TextureObjectDictionary["Bomb" + (num1 - 1).ToString("D2")];
      ref PointF local1 = ref position;
      originalPosition = this.OriginalPosition;
      double num2 = (double) originalPosition.X + (double) this.Life * (double) this.size;
      originalPosition = this.OriginalPosition;
      double y1 = (double) originalPosition.Y;
      local1 = new PointF((float) num2, (float) y1);
      this.SpriteMain.Draw2D(textureObject1.TXTure, textureObject1.PosRect, destinationSize, new PointF(0.0f, 0.0f), 0.0f, position, Color.FromArgb(this.TransparentValue, Color.White));
    }
  }
}
