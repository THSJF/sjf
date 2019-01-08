 
// Type: Shooting.EndBoss_Touhou06
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class EndBoss_Touhou06 : EndBoss_Touhou
  {
    public EndBoss_Touhou06(
      StageDataPackage StageData,
      PointF OriginalPosition,
      Color Color1,
      Color Color2)
      : base(StageData, OriginalPosition, Color1, Color2)
    {
      StageData.SlowMode = 300;
      if (!(this.Boss is Boss_Tensei02) || (double) this.Boss.HealthPoint > 0.0)
        return;
      this.LifeTime = 95;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time == 98)
      {
        this.Boss.GiveItems();
        BaseParticle3D baseParticle3D = new BaseParticle3D(this.StageData, "夜空（亮）", new PointF((float) (this.BoundRect.Width / 2), (float) (this.BoundRect.Height / 2)), 0.0f, Math.PI / 2.0);
        baseParticle3D.Depth = -10f;
        baseParticle3D.TransparentVelocity = 10f;
        baseParticle3D.TransparentValueF = 0.0f;
        this.Background3D.BackgroundParticleList.Add(baseParticle3D);
      }
      if (this.Time != this.LifeTime)
        return;
      if (this.Boss is Boss_Tensei02 && (double) this.Boss.HealthPoint <= 0.0)
      {
        this.Boss.HealthPoint = (float) this.Boss.MaxHP;
        this.Boss.Life = 1;
        this.Boss.Time = 1;
        this.Boss.Region = 20;
        this.Boss.LifeTime = 9999999;
        this.StageData.SlowMode = 0;
      }
      else
      {
        new EndStage(this.StageData, "All", false, 100).LifeTime = 210;
        ClearBonus clearBonus = new ClearBonus(this.StageData, 6000000 * (int) (this.Difficulty + 1) + (this.MyPlane.Life * 20000000 + this.MyPlane.Spell * 5000000 + this.MyPlane.GreenPoint * 1000));
      }
    }
  }
}
