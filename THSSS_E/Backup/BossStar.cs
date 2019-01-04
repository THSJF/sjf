// Decompiled with JetBrains decompiler
// Type: Shooting.BossStar
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class BossStar : BaseEffect
  {
    public int ColorType;

    public BossStar(StageDataPackage StageData, PointF OriginalPosition)
      : base(StageData, (string) null, (PointF) new Point(0, 0), 0.0f, Math.PI / 2.0)
    {
      this.OriginalPosition = OriginalPosition;
      this.LifeTime = 130;
    }

    public override void Shoot()
    {
      if (this.Time == 1)
      {
        int num1 = 110;
        double num2 = Math.PI / 2.0;
        for (int index = 0; index < 3; ++index)
        {
          PointF OriginalPosition;
          ref PointF local = ref OriginalPosition;
          PointF originalPosition = this.OriginalPosition;
          double num3 = (double) (originalPosition.X + (float) num1 * (float) Math.Cos(num2));
          originalPosition = this.OriginalPosition;
          double num4 = (double) (originalPosition.Y + (float) num1 * (float) Math.Sin(num2));
          local = new PointF((float) num3, (float) num4);
          BossStarEmitter01 bossStarEmitter01 = new BossStarEmitter01(this.StageData, OriginalPosition);
          bossStarEmitter01.Velocity = 2.8f;
          bossStarEmitter01.DirectionDegree = num2 * 180.0 / Math.PI + 45.0;
          bossStarEmitter01.DirectionVelocityDegree = 2f;
          bossStarEmitter01.ColorType = this.ColorType;
          num2 += 2.0 * Math.PI / 3.0;
        }
      }
      else
      {
        if (this.Time != this.LifeTime)
          return;
        BaseEffect baseEffect = new BaseEffect(this.StageData, "Light0" + this.ColorType.ToString(), this.Position, 0.0f, 0.0);
        baseEffect.LifeTime = 50;
        baseEffect.ScaleVelocity = 0.4f;
        baseEffect.TransparentVelocityDictionary.Add(20, -5f);
      }
    }
  }
}
