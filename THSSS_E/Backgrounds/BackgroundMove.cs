// Decompiled with JetBrains decompiler
// Type: Shooting.BackgroundMove
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class BackgroundMove : BaseObject_CS
  {
    public BackgroundMove(StageDataPackage StageData, string textureName)
      : base(StageData, textureName, new PointF(0.0f, 0.0f), 0.0f, 0.0)
    {
      this.Background.BackgroundList.Add((BaseObject) this);
      Rectangle boundRect = this.BoundRect;
      double num1 = (double) (boundRect.Height / 2);
      boundRect = this.BoundRect;
      double num2 = (double) (boundRect.Height / 2);
      this.OriginalPosition = new PointF((float) num1, (float) num2);
      this.Scale = (float) this.BoundRect.Height / (float) this.TxtureObject.Height;
      this.Velocity = 2f;
      this.DirectionDegree = 225.0;
      this.OutsideRegion = 1000;
    }

    public override void Ctrl()
    {
      this.AngleDegree = -this.DirectionDegree + 90.0;
      base.Ctrl();
      float x1 = this.OriginalPosition.X;
      float y1 = this.OriginalPosition.Y;
      Rectangle boundRect;
      if ((double) this.OriginalPosition.X <= (double) (-this.BoundRect.Height / 2))
      {
        x1 = this.OriginalPosition.X + (float) this.BoundRect.Height;
      }
      else
      {
        double x2 = (double) this.OriginalPosition.X;
        boundRect = this.BoundRect;
        double num = (double) (boundRect.Height / 2);
        if (x2 >= num)
        {
          double x3 = (double) this.OriginalPosition.X;
          boundRect = this.BoundRect;
          double height = (double) boundRect.Height;
          x1 = (float) (x3 - height);
        }
      }
      double y2 = (double) this.OriginalPosition.Y;
      boundRect = this.BoundRect;
      double num1 = (double) (-boundRect.Height / 2);
      if (y2 <= num1)
      {
        double y3 = (double) this.OriginalPosition.Y;
        boundRect = this.BoundRect;
        double height = (double) boundRect.Height;
        y1 = (float) (y3 + height);
      }
      else
      {
        double y3 = (double) this.OriginalPosition.Y;
        boundRect = this.BoundRect;
        double num2 = (double) (boundRect.Height / 2);
        if (y3 >= num2)
        {
          double y4 = (double) this.OriginalPosition.Y;
          boundRect = this.BoundRect;
          double height = (double) boundRect.Height;
          y1 = (float) (y4 - height);
        }
      }
      this.OriginalPosition = new PointF(x1, y1);
    }

    public override void Show()
    {
      float x1 = this.OriginalPosition.X;
      float y1 = this.OriginalPosition.Y;
      base.Show();
      float x2 = x1 + (float) this.BoundRect.Height;
      this.OriginalPosition = new PointF(x2, y1);
      base.Show();
      float y2 = y1 + (float) this.BoundRect.Height;
      this.OriginalPosition = new PointF(x2, y2);
      base.Show();
      float x3 = x2 - (float) this.BoundRect.Height;
      this.OriginalPosition = new PointF(x3, y2);
      base.Show();
      float y3 = y2 - (float) this.BoundRect.Height;
      this.OriginalPosition = new PointF(x3, y3);
    }
  }
}
