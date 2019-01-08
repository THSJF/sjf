using System.Drawing;

namespace Shooting
{
  internal class CharacterL : CharacterR
  {
    public CharacterL(StageDataPackage StageData, string textureName)
      : base(StageData, textureName)
    {
      Rectangle boundRect = this.BoundRect;
      double num1 = (double) (boundRect.Left + 100);
      boundRect = this.BoundRect;
      double num2 = (double) (boundRect.Top + 200);
      this.Position = new PointF((float) num1, (float) num2);
    }

    public override void Move()
    {
      if (this.Active)
      {
        if ((double) this.OriginalPosition.X >= 150.0)
          return;
        PointF originalPosition = this.OriginalPosition;
        double num = (double) originalPosition.X + 2.0;
        originalPosition = this.OriginalPosition;
        double y = (double) originalPosition.Y;
        this.OriginalPosition = new PointF((float) num, (float) y);
      }
      else if ((double) this.OriginalPosition.X > 100.0)
      {
        PointF originalPosition = this.OriginalPosition;
        double num = (double) originalPosition.X - 2.0;
        originalPosition = this.OriginalPosition;
        double y = (double) originalPosition.Y;
        this.OriginalPosition = new PointF((float) num, (float) y);
      }
    }
  }
}
