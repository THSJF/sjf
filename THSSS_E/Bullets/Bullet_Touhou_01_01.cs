 
// Type: Shooting.Bullet_Touhou_01_01
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class Bullet_Touhou_01_01 : Bullet_Touhou_01
  {
    public string SubBulletName { get; set; }

    public Bullet_Touhou_01_01(
      StageDataPackage StageData,
      string textureName,
      PointF OriginalPosition,
      float Velocity,
      double Direction,
      byte ColorType)
      : base(StageData, textureName, OriginalPosition, Velocity, Direction, ColorType)
    {
    }

    public override bool OutBoundary()
    {
      if (this.LifeTime != 0 && this.Time > this.LifeTime)
        return true;
      if (this.Reflect <= (byte) 0)
      {
        if (this.Time < 100)
          return false;
        int num1 = this.Region >= 10 ? this.Region : 10;
        int num2;
        if ((double) -num1 < (double) this.OriginalPosition.X)
        {
          PointF originalPosition = this.OriginalPosition;
          double x = (double) originalPosition.X;
          Rectangle boundRect = this.BoundRect;
          double num3 = (double) (boundRect.Width + num1);
          if (x < num3)
          {
            double num4 = (double) -num1;
            originalPosition = this.OriginalPosition;
            double y1 = (double) originalPosition.Y;
            if (num4 < y1)
            {
              originalPosition = this.OriginalPosition;
              double y2 = (double) originalPosition.Y;
              boundRect = this.BoundRect;
              double num5 = (double) (boundRect.Height + num1);
              num2 = y2 >= num5 ? 1 : 0;
              goto label_10;
            }
          }
        }
        num2 = 1;
label_10:
        return num2 != 0;
      }
      int num6 = 5;
      PointF originalPosition1;
      Rectangle boundRect1;
      int num7;
      if ((double) this.OriginalPosition.X >= (double) num6)
      {
        originalPosition1 = this.OriginalPosition;
        double x = (double) originalPosition1.X;
        boundRect1 = this.BoundRect;
        double num1 = (double) (boundRect1.Width - num6);
        num7 = x < num1 ? 1 : 0;
      }
      else
        num7 = 0;
      if (num7 == 0)
      {
        --this.Reflect;
        this.Direction -= 2.0 * (this.Direction - Math.PI / 2.0);
        BaseBullet_Touhou baseBulletTouhou = new BaseBullet_Touhou(this.StageData, this.SubBulletName, this.OriginalPosition, this.Velocity, this.Direction, this.ColorType);
        this.GiveEndEffect();
        return true;
      }
      originalPosition1 = this.OriginalPosition;
      double y = (double) originalPosition1.Y;
      boundRect1 = this.BoundRect;
      double num8 = (double) (boundRect1.Bottom + num6);
      return y > num8;
    }
  }
}
