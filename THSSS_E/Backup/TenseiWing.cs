// Decompiled with JetBrains decompiler
// Type: Shooting.TenseiWing
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class TenseiWing : BaseEffect
  {
    public TenseiWing(StageDataPackage StageData)
      : base(StageData, (string) null, PointF.Empty, 0.0f, 0.0)
    {
      if (this.Boss == null)
        return;
      this.OriginalPosition = this.Boss.OriginalPosition;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Boss == null)
        return;
      this.OriginalPosition = this.Boss.OriginalPosition;
      float num1 = (float) ((177.0 + 4.0 * Math.Sin((double) this.Time / 150.0 * Math.PI * 2.0)) / 180.0 * 3.14159274101257);
      PointF pointF;
      ref PointF local1 = ref pointF;
      PointF originalPosition = this.OriginalPosition;
      double num2 = (double) originalPosition.X - 4.0;
      originalPosition = this.OriginalPosition;
      double y1 = (double) originalPosition.Y;
      local1 = new PointF((float) num2, (float) y1);
      float num3 = (float) (1.0 - 0.200000002980232 * Math.Sin((double) this.Time / 150.0 * Math.PI * 2.0));
      BaseObject baseObject1 = new BaseObject(this.StageData, "beike1", PointF.Empty, 1f, (double) num1)
      {
        OriginalPosition = pointF,
        LifeTime = 20,
        TransparentValueF = 30f,
        AngleWithDirection = true,
        ColorValue = Color.FromArgb(220, 220, (int) byte.MaxValue),
        Active = true,
        AngleDegree = -90.0
      };
      baseObject1.TransparentVelocity = -baseObject1.TransparentValueF / (float) baseObject1.LifeTime;
      baseObject1.ScaleVelocity = 0.3f / (float) baseObject1.LifeTime;
      baseObject1.ScaleWidth = num3;
      this.Background2.BackgroundList.Add(baseObject1);
      float num4 = (float) ((3.0 - 4.0 * Math.Sin((double) this.Time / 150.0 * Math.PI * 2.0)) / 180.0 * 3.14159274101257);
      ref PointF local2 = ref pointF;
      originalPosition = this.OriginalPosition;
      double num5 = (double) originalPosition.X + 4.0;
      originalPosition = this.OriginalPosition;
      double y2 = (double) originalPosition.Y;
      local2 = new PointF((float) num5, (float) y2);
      float num6 = (float) (1.0 - 0.200000002980232 * Math.Sin((double) this.Time / 150.0 * Math.PI * 2.0));
      BaseObject baseObject2 = new BaseObject(this.StageData, "beike1", PointF.Empty, 1f, (double) num4)
      {
        OriginalPosition = pointF,
        LifeTime = 20,
        TransparentValueF = 30f,
        AngleWithDirection = true,
        ColorValue = Color.FromArgb(220, 220, (int) byte.MaxValue),
        Active = true,
        AngleDegree = 90.0
      };
      baseObject2.TransparentVelocity = -baseObject2.TransparentValueF / (float) baseObject2.LifeTime;
      baseObject2.ScaleVelocity = 0.3f / (float) baseObject2.LifeTime;
      baseObject2.ScaleWidth = num6;
      baseObject2.Mirrored = true;
      this.Background2.BackgroundList.Add(baseObject2);
      if (this.Boss.Life <= 0)
        this.LifeTime = this.Time + 10;
    }
  }
}
