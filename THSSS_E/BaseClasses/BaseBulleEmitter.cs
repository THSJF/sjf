// Decompiled with JetBrains decompiler
// Type: Shooting.BaseBulleEmitter
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class BaseBulleEmitter : BaseEnemyPlane
  {
    public BaseBulleEmitter(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.OriginalPosition = new PointF(0.0f, 0.0f);
      this.Velocity = 0.0f;
      this.Direction = 0.0;
      this.HealthPoint = 1000000f;
      this.HitEnabled = false;
      this.EnemyPlaneList.Add((BaseEnemyPlane) this);
    }

    public override bool HitCheck(BaseObject MyPlane)
    {
      return false;
    }
  }
}
