 
// Type: Shooting.SpellDisable
namespace Shooting
{
  internal class SpellDisable : BaseEffect
  {
    private bool spellenable;

    public SpellDisable(StageDataPackage StageData)
      : base(StageData)
    {
      this.spellenable = this.MyPlane.SpellEnabled;
      this.LifeTime = 30;
      this.MyPlane.SpellEnabled = false;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time != this.LifeTime)
        return;
      this.MyPlane.SpellEnabled = this.spellenable;
    }
  }
}
