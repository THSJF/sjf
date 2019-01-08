using System;
using System.Drawing;

namespace Shooting
{
  internal class GameTitle : BaseEffect
  {
    public GameTitle(
      StageDataPackage StageData,
      string textureName,
      Point Position,
      Point DestPoint)
      : base(StageData)
    {
      this.TxtureObject = this.TextureObjectDictionary[textureName];
      this.Position = (PointF) Position;
      this.DestPoint = (PointF) DestPoint;
      this.Velocity = 5f;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.Angle = -(this.Direction - Math.PI / 2.0);
      this.TransparentValueF += 2f;
    }
  }
}
