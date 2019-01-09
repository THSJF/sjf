 
// Type: Shooting.BaseEffect
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class BaseEffect : BaseObject_CS
  {
    public int Layer { get; set; }

    public BaseEffect()
    {
    }

    public BaseEffect(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.EffectList.Add(this);
    }

    public BaseEffect(
      StageDataPackage StageData,
      string textureName,
      PointF Position,
      float Velocity,
      double Direction)
      : base(StageData, textureName, Position, Velocity, Direction)
    {
      this.EffectList.Add(this);
      this.Active = true;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.Shoot();
      if (!this.OutBoundary())
        return;
      this.EffectList.Remove(this);
    }

    public override bool HitCheck(BaseObject MyPlane)
    {
      return false;
    }
  }
}
