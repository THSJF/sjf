// Decompiled with JetBrains decompiler
// Type: Shooting.BossPetal
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class BossPetal : BaseEffect
  {
    public BossPetal(StageDataPackage StageData, PointF OriginalPosition)
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
          PointF OriginalPosition = new PointF();
                    ref PointF local = ref OriginalPosition;
          PointF originalPosition = this.OriginalPosition;
          double num3 = (double) (originalPosition.X + (float) num1 * (float) Math.Cos(num2));
          originalPosition = this.OriginalPosition;
          double num4 = (double) (originalPosition.Y + (float) num1 * (float) Math.Sin(num2));
          local = new PointF((float) num3, (float) num4);
          BossPetalEmitter01 bossPetalEmitter01 = new BossPetalEmitter01(this.StageData, OriginalPosition);
          bossPetalEmitter01.Velocity = 2f;
          bossPetalEmitter01.DirectionDegree = num2 * 180.0 / Math.PI + 35.0;
          bossPetalEmitter01.DirectionVelocityDegree = 2f;
          num2 += 2.0 * Math.PI / 3.0;
        }
      }
      else
      {
        if (this.Time != this.LifeTime)
          return;
        BaseEffect baseEffect = new BaseEffect(this.StageData, "591-1", this.Position, 0.0f, 0.0);
        baseEffect.LifeTime = 50;
        baseEffect.ScaleVelocity = 0.4f;
        baseEffect.TransparentVelocityDictionary.Add(20, -5f);
      }
    }
  }
}
