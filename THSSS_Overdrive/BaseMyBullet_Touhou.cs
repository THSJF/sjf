// Decompiled with JetBrains decompiler
// Type: Shooting.BaseMyBullet_Touhou
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class BaseMyBullet_Touhou : BaseMyBullet
  {
    public BaseMyBullet_Touhou(
      StageDataPackage StageData,
      string textureName,
      PointF OriginalPosition,
      float Velocity,
      double Direction)
      : base(StageData, textureName, (PointF) new Point(), Velocity, Direction)
    {
      this.Angle = 1.57079637050629;
      this.TransparentValueF = 180f;
      this.OriginalPosition = OriginalPosition;
    }
  }
}
