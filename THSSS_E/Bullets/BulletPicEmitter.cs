// Decompiled with JetBrains decompiler
// Type: Shooting.BulletPicEmitter
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class BulletPicEmitter
  {
    public static void ShootBulletPic00(
      StageDataPackage StageData,
      bool[,] BulletPic,
      string BulletName,
      PointF OriginalPosition,
      byte ColorType)
    {
      int num = (int) Math.Sqrt((double) BulletPic.Length);
      for (int index1 = 0; index1 < num; ++index1)
      {
        for (int index2 = 0; index2 < num; ++index2)
        {
          if (BulletPic[index1, index2])
          {
            PointF OriginalPosition1 = new PointF(OriginalPosition.X + (float) index1 - (float) (num / 2), OriginalPosition.Y + (float) index2 - (float) (num / 2));
            BaseBullet_Touhou baseBulletTouhou = new BaseBullet_Touhou(StageData, BulletName, OriginalPosition1, 0.0f, 0.0, ColorType);
            baseBulletTouhou.Velocity = (float) baseBulletTouhou.GetDistance(OriginalPosition) * 3f / (float) num;
            baseBulletTouhou.Direction = baseBulletTouhou.GetDirection(OriginalPosition) + Math.PI;
          }
        }
      }
    }

    public static void ShootBulletPic01(
      StageDataPackage StageData,
      bool[,] BulletPic,
      string BulletName,
      PointF OriginalPosition,
      double Direction,
      byte ColorType,
      float Scale,
      float bigger)
    {
      BulletPicEmitter.ShootBulletPic01(StageData, BulletPic, BulletName, OriginalPosition, 1f, Direction, ColorType, Scale, bigger);
    }

    public static void ShootBulletPic01(
      StageDataPackage StageData,
      bool[,] BulletPic,
      string BulletName,
      PointF OriginalPosition,
      float BaseVelocity,
      double Direction,
      byte ColorType,
      float Scale,
      float bigger)
    {
      int num1 = (int) Math.Sqrt((double) BulletPic.Length);
      for (int index1 = 0; index1 < num1; ++index1)
      {
        for (int index2 = 0; index2 < num1; ++index2)
        {
          if (BulletPic[index1, index2])
          {
            float num2 = ((float) index1 - (float) (((double) num1 - 1.0) / 2.0)) * (float) Math.Cos(Direction - Math.PI / 2.0);
            float num3 = -((float) index1 - (float) (((double) num1 - 1.0) / 2.0)) * (float) Math.Sin(Direction - Math.PI / 2.0);
            PointF OriginalPosition1 = new PointF(OriginalPosition.X + num2 * Scale, OriginalPosition.Y - num3 * Scale);
            new BaseBullet_Touhou(StageData, BulletName, OriginalPosition1, 0.0f, Direction - ((double) index1 - ((double) num1 - 1.0) / 2.0) * (double) bigger, ColorType).Velocity = BaseVelocity + (float) index2 * 2f / (float) num1;
          }
        }
      }
    }

    public static void ShootBulletPic02(
      StageDataPackage StageData,
      string BPicName,
      BaseObject Bullet,
      PointF OriginalPosition,
      double Direction,
      byte ColorType,
      float Scale,
      bool Mirrored)
    {
      bool[,] bulletPic = StageData.GlobalData.BulletPicDictionary[BPicName];
      int num1 = (int) Math.Sqrt((double) bulletPic.Length);
      int num2 = Mirrored ? -1 : 1;
      for (int index1 = 0; index1 < num1; ++index1)
      {
        for (int index2 = 0; index2 < num1; ++index2)
        {
          if (bulletPic[index1, index2])
          {
            float num3 = (float) ((double) num2 * (double) ((float) index1 - (float) (((double) num1 - 1.0) / 2.0)) * Math.Cos(Direction - Math.PI / 2.0) + (double) ((float) index2 - (float) (((double) num1 - 1.0) / 2.0)) * Math.Sin(Direction - Math.PI / 2.0));
            float num4 = (float) ((double) -num2 * (double) ((float) index1 - (float) (((double) num1 - 1.0) / 2.0)) * Math.Sin(Direction - Math.PI / 2.0) + (double) ((float) index2 - (float) (((double) num1 - 1.0) / 2.0)) * Math.Cos(Direction - Math.PI / 2.0));
            PointF pointF = new PointF(OriginalPosition.X + num3 * Scale, OriginalPosition.Y - num4 * Scale);
            BaseBullet_Touhou baseBulletTouhou = new BaseBullet_Touhou(StageData, (string) null, OriginalPosition, 0.0f, 0.0);
            baseBulletTouhou.Copy(Bullet);
            baseBulletTouhou.ColorType = ColorType;
            baseBulletTouhou.OriginalPosition = OriginalPosition;
            baseBulletTouhou.DestPoint = pointF;
          }
        }
      }
    }

    public static void ShootItem(
      StageDataPackage StageData,
      string BPicName,
      PointF OriginalPosition,
      float Scale)
    {
      bool[,] bulletPic = StageData.GlobalData.BulletPicDictionary[BPicName];
      float num1 = Scale;
      int num2 = (int) Math.Sqrt((double) bulletPic.Length);
      for (int index1 = 0; index1 < num2; ++index1)
      {
        for (int index2 = 0; index2 < num2; ++index2)
        {
          if (bulletPic[index1, index2])
          {
            PointF OriginalPosition1 = new PointF(OriginalPosition.X + (float) (index1 - num2 / 2) * num1 + (float) StageData.Ran.Next(-2, 3), OriginalPosition.Y + (float) (index2 - num2 / 2) * num1 + (float) StageData.Ran.Next(-2, 3));
            if (StageData.Ran.Next(100) < 60)
            {
              ScoreItem_Touhou scoreItemTouhou = new ScoreItem_Touhou(StageData, OriginalPosition1);
            }
            else
            {
              PowerItem_Touhou powerItemTouhou = new PowerItem_Touhou(StageData, OriginalPosition1);
            }
          }
        }
      }
    }
  }
}
