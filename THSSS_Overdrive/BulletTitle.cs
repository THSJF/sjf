// Decompiled with JetBrains decompiler
// Type: Shooting.BulletTitle
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX.Direct3D9;
using System.Drawing;

namespace Shooting
{
  internal class BulletTitle : MusicTitle
  {
    public BulletTitle(StageDataPackage StageData, string textureName)
      : this(StageData, textureName, new Point(0, 0))
    {
      this.DestPoint = (PointF) new Point(this.BoundRect.Width - 10, 20);
    }

    public BulletTitle(StageDataPackage StageData, string textureName, Point DestPoint)
      : base(StageData, textureName, DestPoint)
    {
      this.Layer = 1;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time > 200 && this.Boss != null && (this.Boss.OnSpell && (double) this.Boss.HealthPoint > 0.0))
        ++this.LifeTime;
      PointF originalPosition1 = this.MyPlane.OriginalPosition;
      double y1 = (double) originalPosition1.Y;
      originalPosition1 = this.OriginalPosition;
      double num1 = (double) originalPosition1.Y + (double) this.TxtureObject.Height + 16.0;
      int num2;
      if (y1 < num1)
      {
        PointF originalPosition2 = this.MyPlane.OriginalPosition;
        double x1 = (double) originalPosition2.X;
        originalPosition2 = this.OriginalPosition;
        double num3 = (double) originalPosition2.X - (double) this.TxtureObject.Width;
        if (x1 > num3)
        {
          PointF originalPosition3 = this.MyPlane.OriginalPosition;
          double x2 = (double) originalPosition3.X;
          originalPosition3 = this.OriginalPosition;
          double x3 = (double) originalPosition3.X;
          num2 = x2 >= x3 ? 1 : 0;
          goto label_6;
        }
      }
      num2 = 1;
label_6:
      if (num2 == 0)
      {
        this.TransparentValueF -= 10f;
        if ((double) this.TransparentValueF >= 50.0)
          return;
        this.TransparentValueF = 50f;
      }
      else if (this.Boss != null && this.Time > 100)
      {
        PointF originalPosition2 = this.Boss.OriginalPosition;
        double y2 = (double) originalPosition2.Y;
        originalPosition2 = this.OriginalPosition;
        double num3 = (double) originalPosition2.Y + (double) this.TxtureObject.Height + 16.0;
        int num4;
        if (y2 < num3)
        {
          originalPosition2 = this.Boss.OriginalPosition;
          if ((double) originalPosition2.Y > 0.0)
          {
            originalPosition2 = this.Boss.OriginalPosition;
            double x1 = (double) originalPosition2.X;
            originalPosition2 = this.OriginalPosition;
            double num5 = (double) originalPosition2.X - (double) this.TxtureObject.Width;
            if (x1 > num5)
            {
              originalPosition2 = this.Boss.OriginalPosition;
              double x2 = (double) originalPosition2.X;
              originalPosition2 = this.OriginalPosition;
              double x3 = (double) originalPosition2.X;
              num4 = x2 >= x3 ? 1 : 0;
              goto label_15;
            }
          }
        }
        num4 = 1;
label_15:
        if (num4 == 0)
        {
          this.TransparentValueF -= 10f;
          if ((double) this.TransparentValueF >= 50.0)
            return;
          this.TransparentValueF = 50f;
        }
        else
          this.TransparentValueF += 10f;
      }
      else
        this.TransparentValueF += 10f;
    }

    public void DrawText(string Text, Point Pos, float Scale)
    {
      int num = 0;
      char[] charArray = Text.ToCharArray();
      for (int index = 0; index < charArray.Length; ++index)
      {
        if (charArray[index] == '.' || charArray[index] == ',')
          num += (int) (8.0 * (double) Scale);
      }
      for (int index = 0; index < charArray.Length; ++index)
      {
        if (charArray[index] == '.' || charArray[index] == ',')
          num -= (int) (5.0 * (double) Scale);
        PointF position = new PointF((float) (Pos.X + 5 + num), (float) (Pos.Y + 9));
        this.SpriteMain.Draw2D(this.TextureObjectDictionary[charArray[index].ToString() ?? ""], Scale, 0.0f, position, Color.FromArgb(this.TransparentValue, Color.White));
        num += (int) (14.0 * (double) Scale);
        if (charArray[index] == '.' || charArray[index] == ',')
          num -= (int) (3.0 * (double) Scale);
      }
    }

    public override void Show()
    {
      TextureObject textureObject = this.StageData.TextureObjectDictionary["tiaotiao2"];
      MySprite spriteMain = this.SpriteMain;
      Texture txTure = textureObject.TXTure;
      Rectangle posRect = textureObject.PosRect;
      SizeF destinationSize = new SizeF((float) textureObject.Width * this.Scale, (float) textureObject.Height * this.Scale);
      PointF rightTop = textureObject.RightTop;
      PointF position1 = this.Position;
      double x = (double) position1.X;
      position1 = this.Position;
      double num = (double) position1.Y - 16.0;
      PointF position2 = new PointF((float) x, (float) num);
      Color color = Color.FromArgb(this.TransparentValue, Color.White);
      spriteMain.Draw2D(txTure, posRect, destinationSize, rightTop, 0.0f, position2, color);
      base.Show();
      if (this.StageData.SCBstring == null)
        return;
      this.DrawText(this.StageData.SCBstring, new Point(240, 68), 0.6f);
    }
  }
}
