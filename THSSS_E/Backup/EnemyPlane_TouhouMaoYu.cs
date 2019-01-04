// Decompiled with JetBrains decompiler
// Type: Shooting.EnemyPlane_TouhouMaoYu
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class EnemyPlane_TouhouMaoYu : BaseEnemyPlane_Touhou
  {
    public bool BackFire { get; set; }

    public Color BackFireColor { get; set; }

    public EnemyPlane_TouhouMaoYu(
      StageDataPackage StageData,
      PointF OriginalPosition,
      float Velocity,
      double Direction,
      byte ColorType)
      : base(StageData, (string) null, OriginalPosition, Velocity, Direction, ColorType)
    {
      this.HealthPoint = 15f;
      this.Region = 6;
      this.TxtureObject = this.TextureObjectDictionary["EnemyMaoYu0" + (object) ColorType];
      this.ItemCount = 1;
    }

    public override void Shoot()
    {
    }

    public override void TextureCtrl()
    {
      this.AngleDegree += 15.0;
    }
  }
}
