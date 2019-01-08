using System.Drawing;

namespace Shooting
{
  public class TransitionIn : BaseObject
  {
    public int Delay { get; set; }

    public TransitionIn(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.TxtureObject = this.TextureObjectDictionary["MenuBackground"];
      this.OriginalPosition = new PointF(0.0f, 0.0f);
      this.TransparentValueF = (float) byte.MaxValue;
      StageData.InterfaceList.Add((BaseObject) this);
      this.Delay = 1;
      this.LifeTime = 50;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time <= this.Delay)
        return;
      this.TransparentValueF -= (float) ((int) byte.MaxValue / (this.LifeTime - this.Delay));
    }

    public override void Show()
    {
      this.SpriteMain.Draw2D(this.TxtureObject, 1f, 0.0f, this.OriginalPosition, this.TxtureObject.LeftTop, Color.FromArgb(this.TransparentValue, Color.Black));
    }
  }
}
