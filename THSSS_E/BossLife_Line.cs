// Decompiled with JetBrains decompiler
// Type: Shooting.BossLife_Line
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class BossLife_Line : Life_Line
  {
    public BossLife_Line(StageDataPackage StageData, string textureName, PointF OriginalPosition)
      : base(StageData, textureName, OriginalPosition)
    {
      this.TransparentVelocity = 0.0f;
      this.TransparentValueF = 0.0f;
    }

    public override void Ctrl()
    {
      if (this.Boss == null)
        return;
      base.Ctrl();
      PointF originalPosition = this.MyPlane.OriginalPosition;
      int num1;
      if ((double) originalPosition.X < (double) this.Life * (double) this.size)
      {
        originalPosition = this.MyPlane.OriginalPosition;
        double y1 = (double) originalPosition.Y;
        double size = (double) this.size;
        originalPosition = this.OriginalPosition;
        double y2 = (double) originalPosition.Y;
        double num2 = size + y2;
        num1 = y1 >= num2 ? 1 : 0;
      }
      else
        num1 = 1;
      if (num1 == 0)
      {
        this.TransparentValueF -= 10f;
        if ((double) this.TransparentValueF < 50.0)
          this.TransparentValueF = 50f;
      }
      else
        this.TransparentValueF += 10f;
      this.Life = this.Boss.Life;
    }

    public override void Show()
    {
      if (this.Boss == null)
        return;
      this.size = 16f;
      SizeF destinationSize = new SizeF(this.size, this.size);
      PointF position;
      for (int index = 0; index < this.Life - 1; ++index)
      {
        if (index < 5)
        {
          position = new PointF(this.OriginalPosition.X + (float) index * this.size, this.OriginalPosition.Y);
          this.SpriteMain.Draw2D(this.TxtureObject.TXTure, this.TxtureObject.PosRect, destinationSize, new PointF(0.0f, 0.0f), 0.0f, position, Color.FromArgb(this.TransparentValue, Color.White));
        }
        else
        {
          position = new PointF(this.OriginalPosition.X + (float) (index - 5) * this.size, this.OriginalPosition.Y + 16f);
          this.SpriteMain.Draw2D(this.TxtureObject.TXTure, this.TxtureObject.PosRect, destinationSize, new PointF(0.0f, 0.0f), 0.0f, position, Color.FromArgb(this.TransparentValue, Color.White));
        }
      }
    }
  }
}
