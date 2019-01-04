// Decompiled with JetBrains decompiler
// Type: Shooting.EDPetal_Emitter
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class EDPetal_Emitter : BaseEffect
  {
    private string EDText;

    public int Hold { get; set; }

    public EDPetal_Emitter(StageDataPackage StageData, PointF OriginalPosition, string EDText)
      : base(StageData, (string) null, (PointF) new Point(0, 0), 0.0f, Math.PI / 2.0)
    {
      this.OriginalPosition = OriginalPosition;
      this.LifeTime = 130;
      this.EDText = EDText;
    }

    public override void Shoot()
    {
      if (this.Time == 10)
      {
        BaseEffect baseEffect = new BaseEffect(this.StageData, this.EDText, this.OriginalPosition, 0.0f, 0.0);
        baseEffect.Scale = this.Scale;
        baseEffect.Direction = Math.PI / 2.0;
        baseEffect.OriginalPosition = this.OriginalPosition;
        baseEffect.Active = false;
        baseEffect.TransparentValueF = 0.0f;
        baseEffect.TransparentVelocity = 10f;
        baseEffect.LifeTime = 322 + this.Hold;
        baseEffect.TransparentVelocityDictionary.Add(300 + this.Hold, -12f);
      }
      for (int index = 0; index < 5; ++index)
      {
        if (this.Time == 1 + index * 3)
          new EDPetal(this.StageData, "ED_Petal", this.OriginalPosition, 0.0f, 0.0)
          {
            DestAngleDegree = ((double) (72 * index))
          }.LifeTime = 300 + this.Hold;
      }
    }
  }
}
