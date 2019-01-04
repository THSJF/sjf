// Decompiled with JetBrains decompiler
// Type: Shooting.ItemBonus
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class ItemBonus : BaseEffect
  {
    public ItemBonus(StageDataPackage StageData)
      : base(StageData, (string) null, (PointF) new Point(0, 0), 0.0f, Math.PI / 2.0)
    {
      Rectangle boundRect = this.BoundRect;
      double num1 = (double) (boundRect.Width / 2);
      boundRect = this.BoundRect;
      double num2 = (double) (boundRect.Height / 2);
      this.OriginalPosition = new PointF((float) num1, (float) num2);
      this.LifeTime = 72;
      this.TransparentValueF = 0.0f;
      this.Accelerate = 0.1f;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.Direction = this.GetDirection((BaseObject) this.MyPlane);
    }

    public override void Shoot()
    {
      int num1 = 160 - this.Time;
      int num2 = 10;
      for (int index = 0; index < num2; ++index)
      {
        PointF OriginalPosition;
        ref PointF local1 = ref OriginalPosition;
        PointF originalPosition = this.OriginalPosition;
        double num3 = (double) originalPosition.X + (double) num1 * Math.Sin(this.Angle) + (double) this.Ran.Next(-15, 15);
        originalPosition = this.OriginalPosition;
        double num4 = (double) originalPosition.Y + (double) num1 * Math.Cos(this.Angle) + (double) this.Ran.Next(-15, 15);
        local1 = new PointF((float) num3, (float) num4);
        StarItem_Touhou starItemTouhou1 = new StarItem_Touhou(this.StageData, OriginalPosition);
        ref PointF local2 = ref OriginalPosition;
        originalPosition = this.OriginalPosition;
        double num5 = (double) originalPosition.X - (double) num1 * Math.Sin(this.Angle) + (double) this.Ran.Next(-15, 15);
        originalPosition = this.OriginalPosition;
        double num6 = (double) originalPosition.Y - (double) num1 * Math.Cos(this.Angle) + (double) this.Ran.Next(-15, 15);
        local2 = new PointF((float) num5, (float) num6);
        StarItem_Touhou starItemTouhou2 = new StarItem_Touhou(this.StageData, OriginalPosition);
      }
      this.Angle += 0.300000011920929;
    }
  }
}
