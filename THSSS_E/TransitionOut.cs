using System.Drawing;

namespace Shooting
{
  public class TransitionOut : BaseObject
  {
    public TransitionOut(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.TxtureObject = this.TextureObjectDictionary["MenuBackground"];
      this.OriginalPosition = new PointF(0.0f, 0.0f);
      this.TransparentValueF = 0.0f;
      StageData.InterfaceList.Add((BaseObject) this);
      this.LifeTime = (int) byte.MaxValue;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.TransparentValueF += (float) ((int) byte.MaxValue / this.LifeTime);
    }

    public override void Show()
    {
      this.SpriteMain.Draw2D(this.TxtureObject, 1f, 0.0f, this.OriginalPosition, this.TxtureObject.LeftTop, Color.FromArgb(this.TransparentValue, Color.Black));
    }
  }
}
