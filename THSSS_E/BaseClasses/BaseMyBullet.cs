 
// Type: Shooting.BaseMyBullet
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class BaseMyBullet : BaseObject
  {
    public BaseMyBullet(
      StageDataPackage StageData,
      string textureName,
      PointF Position,
      float v,
      double drctn)
      : base(StageData, textureName, Position, v, drctn)
    {
      this.Damage = 21;
      this.Region = 15;
      this.MyBulletList.Add((BaseObject) this);
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (!this.OutBoundary())
        return;
      this.MyBulletList.Remove((BaseObject) this);
    }

    public override void GiveEndEffect()
    {
      Emitter2 emitter2 = new Emitter2(this.StageData, this.Position);
      ParticleBiger particleBiger = new ParticleBiger(this.StageData, (string) null, this.Position, 3f, this.Direction);
      particleBiger.Scale = 1.2f;
      particleBiger.LifeTime = 15;
      particleBiger.TxtureObject = this.TxtureObject;
      particleBiger.Angle = this.Angle;
      particleBiger.MaxTransparent = 100;
    }
  }
}
