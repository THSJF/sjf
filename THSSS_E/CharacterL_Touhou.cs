using System.Drawing;

namespace Shooting
{
  internal class CharacterL_Touhou : CharacterR_Touhou
  {
    public CharacterL_Touhou(StageDataPackage StageData, string textureName)
      : base(StageData, textureName)
    {
      this.OriginalPosition = new PointF(70f, 128f);
    }

    public override void Move()
    {
      if (this.Active)
      {
        if ((double) this.OriginalPosition.X >= 100.0)
          return;
        PointF originalPosition = this.OriginalPosition;
        double num = (double) originalPosition.X + 2.0;
        originalPosition = this.OriginalPosition;
        double y = (double) originalPosition.Y;
        this.OriginalPosition = new PointF((float) num, (float) y);
      }
      else if ((double) this.OriginalPosition.X > 70.0)
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
