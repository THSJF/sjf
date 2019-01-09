 
// Type: Shooting.EnemyPlane_TouhouNormal
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class EnemyPlane_TouhouNormal : BaseEnemyPlane_Touhou
  {
    public EnemyPlane_TouhouNormal(
      StageDataPackage StageData,
      string EnemyName,
      PointF OriginalPosition,
      float Velocity,
      double Direction,
      byte ColorType)
      : this(StageData, EnemyName, OriginalPosition, Velocity, Direction)
    {
      this.ColorType = ColorType;
    }

    public EnemyPlane_TouhouNormal(
      StageDataPackage StageData,
      string EnemyName,
      PointF OriginalPosition,
      float Velocity,
      double Direction)
      : base(StageData, (string) null, OriginalPosition, Velocity, Direction)
    {
      this.TxtureObject = this.TextureObjectDictionary[EnemyName];
    }

    public override void TextureCtrl()
    {
    }
  }
}
