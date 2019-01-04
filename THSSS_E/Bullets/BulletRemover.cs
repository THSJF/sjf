// Decompiled with JetBrains decompiler
// Type: Shooting.BulletRemover
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class BulletRemover : BaseBackground
  {
    public BulletRemover(StageDataPackage StageData, PointF OriginalPosition)
      : base(StageData, (string) null, (PointF) new Point(0, 0), 0.0f, Math.PI / 2.0)
    {
      this.OriginalPosition = OriginalPosition;
      this.LifeTime = 30;
      this.Region = 2;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.Region += 20;
      for (int index = this.BulletList.Count - 1; index >= 0; --index)
      {
        if (this.HitCheck((BaseObject) this.BulletList[index], (float) this.Region) && !this.BulletList[index].UnRemoveable)
        {
          this.BulletList[index].GiveEndEffect();
          this.BulletList.RemoveAt(index);
        }
      }
      for (int index = this.EnemyPlaneList.Count - 1; index >= 0; --index)
      {
        if (this.HitCheck((BaseObject) this.EnemyPlaneList[index], (float) this.Region))
        {
          this.EnemyPlaneList[index].HealthPoint -= 20f;
          if ((double) this.EnemyPlaneList[index].HealthPoint <= 0.0)
          {
            this.EnemyPlaneList[index].GiveEndEffect();
            this.EnemyPlaneList[index].GiveItems();
            this.EnemyPlaneList.RemoveAt(index);
            this.StageData.SoundPlay("se_enep00.wav");
          }
        }
      }
    }
  }
}
