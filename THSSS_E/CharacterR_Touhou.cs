using System;
using System.Drawing;

namespace Shooting
{
  internal class CharacterR_Touhou : BaseStoryItem
  {
    public TextureObject TxtureObject2 { get; set; }

    public CharacterR_Touhou(StageDataPackage StageData, string textureName)
      : base(StageData)
    {
      this.OriginalPosition = new PointF((float) (this.BoundRect.Width - 70), 128f);
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
        if ((double) this.OriginalPosition.X <= (double) (this.BoundRect.Width - 100))
          return;
        PointF originalPosition = this.OriginalPosition;
        double num = (double) originalPosition.X - 2.0;
        originalPosition = this.OriginalPosition;
        double y = (double) originalPosition.Y;
        this.OriginalPosition = new PointF((float) num, (float) y);
      }
      else if ((double) this.OriginalPosition.X < (double) (this.BoundRect.Width - 70))
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
      this.Angle = -(this.Direction - Math.PI / 2.0);
      if (this.Active)
      {
        this.TransparentValueF += 10f;
        this.ColorValue = Color.White;
      }
      else
        this.ColorValue = Color.Gray;
    }

    public override void Show()
    {
      if (this.TxtureObject2 != null)
        this.SpriteMain.Draw2D(this.TxtureObject2, this.ScaleWidth, this.ScaleLength, (float) (this.Direction - Math.PI / 2.0 + this.Angle), this.Position, Color.FromArgb(this.TransparentValue, this.ColorValue), this.Mirrored);
      base.Show();
    }
  }
}
