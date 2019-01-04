// Decompiled with JetBrains decompiler
// Type: Shooting.CharacterR
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class CharacterR : BaseStoryItem
  {
    public CharacterR(StageDataPackage StageData, string textureName)
      : base(StageData)
    {
      Rectangle boundRect = this.BoundRect;
      double num1 = (double) (boundRect.Right - 100);
      boundRect = this.BoundRect;
      double num2 = (double) (boundRect.Top + 200);
      this.Position = new PointF((float) num1, (float) num2);
      this.Velocity = 0.0f;
      this.Direction = 0.0;
      this.TxtureObject = this.TextureObjectDictionary[textureName];
      this.Active = false;
      this.TransparentValueF = 0.0f;
    }

    public override void Move()
    {
      if (this.Active)
      {
        if ((double) this.Position.X <= (double) (this.BoundRect.Right - 130))
          return;
        PointF originalPosition = this.OriginalPosition;
        double num = (double) originalPosition.X - 2.0;
        originalPosition = this.OriginalPosition;
        double y = (double) originalPosition.Y;
        this.OriginalPosition = new PointF((float) num, (float) y);
      }
      else if ((double) this.Position.X < (double) (this.BoundRect.Right - 100))
      {
        PointF originalPosition = this.OriginalPosition;
        double num = (double) originalPosition.X + 2.0;
        originalPosition = this.OriginalPosition;
        double y = (double) originalPosition.Y;
        this.OriginalPosition = new PointF((float) num, (float) y);
      }
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time <= 1)
      {
        this.TransparentValueF = 0.0f;
      }
      else
      {
        if (this.Time >= 26)
          return;
        this.TransparentValueF += 10f;
      }
    }

    public override void Show()
    {
      SizeF destinationSize = new SizeF((float) this.TxtureObject.Width * this.Scale, (float) this.TxtureObject.Height * this.Scale);
      if (this.Active)
        this.SpriteMain.Draw2D(this.TxtureObject.TXTure, this.TxtureObject.PosRect, destinationSize, this.TxtureObject.RotatingCenter, 0.0f, this.Position, Color.FromArgb(this.TransparentValue, Color.White));
      else
        this.SpriteMain.Draw2D(this.TxtureObject.TXTure, this.TxtureObject.PosRect, destinationSize, this.TxtureObject.RotatingCenter, 0.0f, this.Position, Color.FromArgb(this.TransparentValue, Color.Gray));
    }
  }
}
