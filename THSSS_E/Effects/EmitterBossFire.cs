 
// Type: Shooting.EmitterBossFire
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class EmitterBossFire : BaseEffect
  {
    public EmitterBossFire(StageDataPackage StageData, PointF OriginalPosition, Color ColorValue)
      : base(StageData, (string) null, OriginalPosition, 0.0f, 0.0)
    {
      this.OriginalPosition = OriginalPosition;
      this.ColorValue = ColorValue;
    }

    public override void Move()
    {
      if (this.Boss == null)
        return;
      this.OriginalPosition = this.Boss.OriginalPosition;
    }

    public override void Shoot()
    {
      if (this.Time % 10 != 0)
        return;
      new ParticleBossFire(this.StageData, "Effect01_1", this.OriginalPosition, 0.0f, 0.0, 60).ColorValue = this.ColorValue;
      new ParticleBossFire2(this.StageData, "Effect01_2", this.OriginalPosition, 0.0f, (double) this.Ran.Next(360) * Math.PI / 180.0, 80).ColorValue = this.ColorValue;
      new ParticleBossFire2(this.StageData, "Effect01_2", this.OriginalPosition, 0.0f, (double) this.Ran.Next(360) * Math.PI / 180.0, 100).ColorValue = this.ColorValue;
    }

    public override bool OutBoundary()
    {
      return this.Boss == null;
    }
  }
}
