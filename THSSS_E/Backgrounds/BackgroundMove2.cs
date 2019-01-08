 
// Type: Shooting.BackgroundMove2
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class BackgroundMove2 : BaseObject_CS
  {
    public int Length;
    private float Width;

    public BackgroundMove2(StageDataPackage StageData, string textureName)
      : base(StageData, textureName, new PointF(0.0f, 0.0f), 0.0f, 0.0)
    {
      this.Background.BackgroundList.Add((BaseObject) this);
      Rectangle boundRect = this.BoundRect;
      double num1 = (double) (boundRect.Height / 2);
      boundRect = this.BoundRect;
      double num2 = (double) (boundRect.Height / 2);
      this.OriginalPosition = new PointF((float) num1, (float) num2);
      this.Length = this.BoundRect.Height * 2;
      this.Velocity = 2f;
      this.DirectionDegree = 225.0;
      this.OutsideRegion = 10000;
    }

    public override void Ctrl()
    {
      this.Scale = (float) this.Length / (float) this.TxtureObject.Height;
      this.Width = (float) this.TxtureObject.Width * this.Scale;
      this.AngleDegree = -this.DirectionDegree + 90.0;
      base.Ctrl();
      float x = this.OriginalPosition.X;
      float y = this.OriginalPosition.Y;
      if ((double) this.OriginalPosition.X <= -(double) this.Width / 2.0)
        x = this.OriginalPosition.X + this.Width;
      else if ((double) this.OriginalPosition.X >= (double) this.Width / 2.0)
        x = this.OriginalPosition.X - this.Width;
      if ((double) this.OriginalPosition.Y <= (double) (-this.Length / 2))
        y = this.OriginalPosition.Y + (float) this.Length;
      else if ((double) this.OriginalPosition.Y >= (double) (this.Length / 2))
        y = this.OriginalPosition.Y - (float) this.Length;
      this.OriginalPosition = new PointF(x, y);
    }

    public override void Show()
    {
      float x1 = this.OriginalPosition.X;
      float y1 = this.OriginalPosition.Y;
      base.Show();
      float x2 = x1 + this.Width;
      this.OriginalPosition = new PointF(x2, y1);
      base.Show();
      float y2 = y1 + (float) this.Length;
      this.OriginalPosition = new PointF(x2, y2);
      base.Show();
      float x3 = x2 - this.Width;
      this.OriginalPosition = new PointF(x3, y2);
      base.Show();
      float y3 = y2 - (float) this.Length;
      this.OriginalPosition = new PointF(x3, y3);
    }
  }
}
