// Decompiled with JetBrains decompiler
// Type: Shooting.Boss_Rika02
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class Boss_Rika02 : BaseBossTouhou
  {
    public Boss_Rika02(StageDataPackage StageData)
      : base(StageData)
    {
      this.TxtureObjects = new TextureObject[3, 4]
      {
        {
          this.TextureObjectDictionary["BossRika-00"],
          this.TextureObjectDictionary["BossRika-01"],
          this.TextureObjectDictionary["BossRika-02"],
          this.TextureObjectDictionary["BossRika-03"]
        },
        {
          this.TextureObjectDictionary["BossRika-10"],
          this.TextureObjectDictionary["BossRika-11"],
          this.TextureObjectDictionary["BossRika-12"],
          this.TextureObjectDictionary["BossRika-13"]
        },
        {
          this.TextureObjectDictionary["BossRika-20"],
          this.TextureObjectDictionary["BossRika-21"],
          this.TextureObjectDictionary["BossRika-22"],
          this.TextureObjectDictionary["BossRika-23"]
        }
      };
      this.TxtureObject = this.TxtureObjects[0, 0];
      this.OriginalPosition = new PointF((float) (this.BoundRect.Width / 2), 120f);
      this.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 120);
      this.MaxHP = 10000;
      this.HealthPoint = (float) this.MaxHP;
      this.Life = 1;
      this.Region = 20;
      this.Velocity = 4f;
      this.DirectionDegree = 90.0;
      this.SpellTime = 3600;
      this.LifeTime = 100000;
      this.OnSpell = false;
      this.SetBossLifeLineTex();
      this.LoadArmon(".\\CS\\StEx\\关底Boss\\ctrl.csv");
    }

    public override void Ctrl()
    {
      base.Ctrl(); 
            if (!this.OnSpell)
        this.Armon = 0.0f;
      switch (this.Life)
      {
        case 0:
          this.Velocity = 0.0f;
          this.DestPoint = (PointF) new Point(this.Ran.Next(100, this.BoundRect.Width - 100), this.Ran.Next(70, 200));
          break;
        case 1:
          this.Ctrl1();
          break;
      }
      this.MoveToPoint(this.DestPoint);
      if (!this.OnSpell)
      {
        if ((double) this.HealthPoint >= (double) this.SpellcardHP && this.Time <= this.SpellTime)
          return;
        this.HealthPoint = (float) this.SpellcardHP;
        this.Time = 0;
        this.OnSpell = true;
        ShootingStarShard shootingStarShard = new ShootingStarShard(this.StageData, new PointF((float) (this.BoundRect.Width / 2), 0.0f));
      }
      else if ((double) this.HealthPoint <= 0.0 || this.Time > this.SpellTime)
      {
        --this.Life;
        Rectangle boundRect;
        if ((double) this.HealthPoint <= 0.0 && this.Life >= -1)
        {
          this.GiveItems();
          StageDataPackage stageData = this.StageData;
          boundRect = this.BoundRect;
          PointF OriginalPosition = new PointF((float) (boundRect.Width / 2), 0.0f);
          ShootingStarShard shootingStarShard = new ShootingStarShard(stageData, OriginalPosition);
        }
        if (this.Life <= 0)
        {
          if (this.Life == 0)
          {
            this.DestPoint = (PointF) new Point(this.Ran.Next((int) this.OriginalPosition.X - 30, (int) this.OriginalPosition.X + 30), this.Ran.Next((int) this.OriginalPosition.Y + 30, (int) this.OriginalPosition.Y + 50));
            this.Velocity = 0.5f;
            BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
            this.HealthPoint = 0.0f;
            this.GiveEndEffect();
            this.Life = -1;
          }
        }
        else
        {
          BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
          this.StageData.SoundPlay("se_tan00.wav");
          this.HealthPoint = (float) this.MaxHP;
          this.Time = 0;
          this.OnSpell = false;
          boundRect = this.BoundRect;
          this.DestPoint = (PointF) new Point(boundRect.Width / 2, 120);
          this.Velocity = 4f;
        }
      }
    }

    public override void GiveEndEffect()
    {
      this.TransparentValueF = (float) byte.MaxValue;
      Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
      this.Background3D.WarpEnabled = false;
      this.LifeTime = this.Time + 150;
      this.Region = 0;
      this.StageData.SoundPlay("se_tan01.wav");
      EndBoss_TouhouEx endBossTouhouEx = new EndBoss_TouhouEx(this.StageData, this.OriginalPosition, Color.White, Color.Blue);
    }

    private void Ctrl1()
    {
      if (!this.OnSpell)
      {
        if (this.Time != 1)
          return;
        this.OnSpell = true;
        this.SpellTime = 3000;
      }
      else if (this.Time == 2)
      {
        SpellCard_SSSEx_FSC spellCardSssExFsc = new SpellCard_SSSEx_FSC(this.StageData);
      }
    }
  }
}
