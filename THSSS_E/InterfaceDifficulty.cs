using System.Drawing;

namespace Shooting
{
  public class InterfaceDifficulty : BaseInterface
  {
    public InterfaceDifficulty(StageDataPackage StageData, PointF OriginalPosition)
      : base(StageData, (string) null, OriginalPosition)
    {
    }

    public override void Ctrl()
    {
      base.Ctrl();
      switch (this.StageData.Difficulty)
      {
        case DifficultLevel.Easy:
          this.TxtureObject = this.TextureObjectDictionary["Easy"];
          break;
        case DifficultLevel.Normal:
          this.TxtureObject = this.TextureObjectDictionary["Normal"];
          break;
        case DifficultLevel.Hard:
          this.TxtureObject = this.TextureObjectDictionary["Hard"];
          break;
        case DifficultLevel.Lunatic:
          this.TxtureObject = this.TextureObjectDictionary["Lunatic"];
          break;
        case DifficultLevel.Extra:
          this.TxtureObject = this.TextureObjectDictionary["Extra"];
          break;
      }
    }

    public override void Show()
    {
      if (this.TxtureObject == null)
        return;
      this.SpriteMain.Draw2D(this.TxtureObject, 1f, 0.0f, this.OriginalPosition, Color.FromArgb(this.TransparentValue, Color.White));
    }
  }
}
