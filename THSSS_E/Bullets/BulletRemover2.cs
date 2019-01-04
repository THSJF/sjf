// Decompiled with JetBrains decompiler
// Type: Shooting.BulletRemover2
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class BulletRemover2 : BaseBackground
  {
    public BulletRemover2(StageDataPackage StageData, PointF OriginalPosition)
      : base(StageData, (string) null, (PointF) new Point(0, 0), 0.0f, Math.PI / 2.0)
    {
      this.OriginalPosition = OriginalPosition;
      this.LifeTime = 30;
      this.Region = 2;
      foreach (BaseObject enemyPlane in this.EnemyPlaneList)
        enemyPlane.GiveEndEffect();
      this.EnemyPlaneList.Clear();
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.Region += 25;
      for (int index = this.BulletList.Count - 1; index >= 0; --index)
      {
        if (this.HitCheck((BaseObject) this.BulletList[index], (float) this.Region))
        {
          this.BulletList[index].GiveEndEffect();
          this.BulletList[index].GiveItems();
          this.BulletList.RemoveAt(index);
        }
      }
    }
  }
}
