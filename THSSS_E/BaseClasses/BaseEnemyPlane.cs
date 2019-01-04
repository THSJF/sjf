// Decompiled with JetBrains decompiler
// Type: Shooting.BaseEnemyPlane
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class BaseEnemyPlane : BaseObject_CS
  {
    public BaseEnemyPlane()
    {
    }

    public BaseEnemyPlane(
      StageDataPackage StageData,
      string textureName,
      PointF p,
      float v,
      double drctn)
      : base(StageData, textureName, p, v, drctn)
    {
      this.Region = 4;
      this.EnemyPlaneList.Add(this);
    }

    public override void Shoot()
    {
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.ShootEnabled)
        this.Shoot();
      if (!this.OutBoundary())
        return;
      this.EnemyPlaneList.Remove(this);
    }

    public override void HitCheckAll()
    {
      for (int index = this.MyBulletList.Count - 1; index >= 0; --index)
      {
        if (this.HitCheck(this.MyBulletList[index]))
        {
          if (this.MyPlane.EnchantmentState == EnchantmentType.Red)
            this.HealthPoint -= (float) this.MyBulletList[index].Damage * 1.25f;
          else
            this.HealthPoint -= (float) this.MyBulletList[index].Damage;
          this.MyBulletList[index].GiveEndEffect();
          this.MyBulletList.RemoveAt(index);
          this.MyPlane.Score += 10L;
          PointF originalPosition;
          if ((double) this.HealthPoint <= 0.0)
          {
            this.GiveEndEffect();
            this.GiveItems();
            this.EnemyPlaneList.Remove(this);
            StageDataPackage stageData = this.StageData;
            originalPosition = this.OriginalPosition;
            double num = (double) originalPosition.X / (double) this.BoundRect.Width;
            stageData.SoundPlay("se_enep00.wav", (float) num);
            break;
          }
          StageDataPackage stageData1 = this.StageData;
          originalPosition = this.OriginalPosition;
          double num1 = (double) originalPosition.X / (double) this.BoundRect.Width;
          stageData1.SoundPlay("se_damage01.wav", (float) num1);
        }
      }
      if (!this.MyPlane.HitEnabled || !this.HitCheck((BaseObject) this.MyPlane))
        return;
      this.MyPlane.PreMiss();
    }

    public override void GiveEndEffect()
    {
    }

    public override void GiveItems()
    {
    }
  }
}
