using System.Drawing;

namespace Shooting
{
  public class TextTwinkle : BaseEffect
  {
    public int Circle { get; set; }

    public Color TwinkleColor { get; set; }

    public Color OriginalColor { get; set; }

    public TextTwinkle(
      StageDataPackage StageData,
      string textureName,
      PointF Position,
      float Velocity,
      double Direction)
      : base(StageData, textureName, Position, Velocity, Direction)
    {
      this.Active = false;
      this.LifeTime = 150;
      this.Circle = 30;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time <= 1)
        this.OriginalColor = this.ColorValue;
      else if (this.Time < this.LifeTime * 3 / 5)
      {
        if (this.Time % this.Circle == 0)
        {
          this.ColorValue = this.TwinkleColor;
        }
        else
        {
          if (this.Time % this.Circle != this.Circle / 2)
            return;
          this.ColorValue = this.OriginalColor;
        }
      }
      else
      {
        if (this.LifeTime * 4 / 5 >= this.Time || this.Time >= this.LifeTime)
          return;
        this.TransparentValueF -= (float) (this.MaxTransparent * 5 / this.LifeTime);
      }
    }
  }
}
