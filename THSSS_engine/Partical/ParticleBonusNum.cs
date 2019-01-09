 
// Type: Shooting.ParticleBonusNum
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class ParticleBonusNum : BaseEffect
  {
    public ParticleBonusNum(
      StageDataPackage StageData,
      string textureName,
      PointF OriginalPosition)
      : base(StageData, textureName, OriginalPosition, 0.0f, -1.57079637050629)
    {
      this.OriginalPosition = OriginalPosition;
      this.LifeTime = 100;
      this.Active = false;
      this.Angle = -this.Direction + Math.PI / 2.0;
    }

    public override void Ctrl()
    {
      this.Angle = -this.Direction + Math.PI / 2.0;
      if (this.Time < 24)
        this.Velocity = (float) Math.Cos((double) this.Time * Math.PI * 2.0 / 32.0);
      else
        this.Velocity = 0.0f;
      base.Ctrl();
      if (this.Time <= this.LifeTime - 20)
        return;
      this.TransparentValueF -= 12f;
    }
  }
}
