 
// Type: Shooting.BulletGroupCircle
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class BulletGroupCircle : BaseObject
  {
    public BulletGroupCircle(
      StageDataPackage StageData,
      BaseObject bullet,
      PointF OriginalPosition,
      double Direction,
      int Count,
      int Radius,
      byte ColorType)
    {
      double num = Direction;
      for (int index = 0; index < Count; ++index)
      {
        PointF OriginalPosition1 = new PointF(OriginalPosition.X + (float) Radius * (float) Math.Cos(num), OriginalPosition.Y + (float) Radius * (float) Math.Sin(num));
        BaseBullet_Touhou baseBulletTouhou = new BaseBullet_Touhou(StageData, (string) null, OriginalPosition1, 0.0f, 0.0, ColorType);
        baseBulletTouhou.Copy(bullet);
        baseBulletTouhou.OriginalPosition = OriginalPosition1;
        baseBulletTouhou.Direction = num;
        num += 2.0 * Math.PI / (double) Count;
      }
      StageData.SoundPlay("se_tan00a.wav");
    }
  }
}
