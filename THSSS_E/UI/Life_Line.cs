// Decompiled with JetBrains decompiler
// Type: Shooting.Life_Line
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class Life_Line : BaseInterface
  {
    protected int maxLife = 9;
    public float size = 20f;
    private int life;

    public int Life
    {
      set
      {
        if (value > this.maxLife)
          this.life = this.maxLife;
        else if (value < 0)
          this.life = 0;
        else
          this.life = value;
      }
      get
      {
        return this.life;
      }
    }

    public Life_Line(StageDataPackage StageData, string textureName, PointF OriginalPosition)
      : base(StageData, textureName, OriginalPosition)
    {
    }

    public Life_Line(
      StageDataPackage StageData,
      TextureObject TxtureObject,
      PointF OriginalPosition)
      : base(StageData, (string) null, OriginalPosition)
    {
      this.TxtureObject = TxtureObject;
    }

    public override void Show()
    {
      SizeF destinationSize = new SizeF(this.size, this.size);
      for (int index = 0; index < this.life; ++index)
      {
        PointF position = new PointF(this.OriginalPosition.X + (float) index * this.size, this.OriginalPosition.Y);
        this.SpriteMain.Draw2D(this.TxtureObject.TXTure, this.TxtureObject.PosRect, destinationSize, new PointF(0.0f, 0.0f), 0.0f, position, Color.FromArgb(this.TransparentValue, Color.White));
      }
    }
  }
}
