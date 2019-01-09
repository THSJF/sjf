using System;
using System.Drawing;

namespace Shooting
{
  internal class MagicCircle : BaseEffect
  {
    public MagicCircle(StageDataPackage StageData, string textureName)
      : base(StageData, textureName, new PointF(0.0f, 0.0f), 0.0f, 0.0)
    {
    }

    public override void Move()
    {
      if (this.Boss == null)
        return;
      this.OriginalPosition = this.Boss.OriginalPosition;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.Angle += 0.0199999995529652;
      this.Scale += (float) Math.Sin((double) this.Time * 3.0 / 180.0 * Math.PI) / 80f;
      this.TransparentValueF = (float) (100 + (int) (Math.Sin((double) this.Time * 2.0 / 180.0 * Math.PI) * 75.0));
    }

    public override bool OutBoundary()
    {
      return this.Boss == null;
    }
  }
}
