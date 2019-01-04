// Decompiled with JetBrains decompiler
// Type: Shooting.BaseSpell
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

namespace Shooting
{
  public class BaseSpell : BaseObject
  {
    public BaseSpell()
    {
    }

    public BaseSpell(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.Position = this.MyPlane.Position;
      this.Damage = 12;
      this.LifeTime = 300;
      this.SpellList.Add((BaseObject) this);
      StageData.VibrateStart(this.LifeTime);
      BackgroundBlack backgroundBlack = new BackgroundBlack(StageData, this.Position);
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time < 30)
      {
        for (int index = this.ItemList.Count - 1; index >= 0; --index)
        {
          if (this.HitCheck((BaseObject) this.ItemList[index]) && !(this.ItemList[index] is ShootingStarShard))
          {
            this.ItemList[index].Obtain = true;
            this.ItemList[index].Doubled = true;
          }
        }
      }
      this.MyPlane.DeadTime = -1;
      if (!this.OutBoundary())
        return;
      this.SpellList.Remove((BaseObject) this);
      this.MyPlane.Time = this.MyPlane.UnmatchedTime - 60;
    }

    public override bool OutBoundary()
    {
      return this.Time > this.LifeTime;
    }

    public override void HitCheckAll()
    {
      for (int index = this.BulletList.Count - 1; index >= 0; --index)
      {
        if (this.HitCheck((BaseObject) this.BulletList[index]) && !this.BulletList[index].UnRemoveable)
        {
          this.BulletList[index].GiveEndEffect();
          this.BulletList[index].GiveItems();
          this.BulletList.RemoveAt(index);
        }
      }
      for (int index = this.EnemyPlaneList.Count - 1; index >= 0; --index)
      {
        if (this.HitCheck((BaseObject) this.EnemyPlaneList[index]))
        {
          this.EnemyPlaneList[index].HealthPoint -= (float) this.Damage;
          if ((double) this.EnemyPlaneList[index].HealthPoint <= 0.0)
          {
            this.EnemyPlaneList[index].GiveEndEffect();
            this.EnemyPlaneList[index].GiveItems();
            this.EnemyPlaneList.RemoveAt(index);
            this.StageData.SoundPlay("se_enep00.wav");
            break;
          }
        }
      }
      if (this.Boss == null || (this.Boss.Time <= this.Boss.UnmatchedTime || !this.HitCheck((BaseObject) this.Boss)))
        return;
      this.Boss.HealthPoint -= (float) (int) ((double) this.Damage * (1.0 - (double) this.Boss.Armon));
      if ((double) this.Boss.HealthPoint <= 200.0)
        this.StageData.SoundPlay("se_damage01.wav");
    }
  }
}
