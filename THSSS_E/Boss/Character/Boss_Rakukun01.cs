 
// Type: Shooting.Boss_Rakukun01
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class Boss_Rakukun01 : BaseBossTouhou
  {
    public Boss_Rakukun01(StageDataPackage StageData)
      : base(StageData)
    {
      this.TxtureObjects = new TextureObject[3, 4]
      {
        {
          this.TextureObjectDictionary["BossRakukun-00"],
          this.TextureObjectDictionary["BossRakukun-01"],
          this.TextureObjectDictionary["BossRakukun-02"],
          this.TextureObjectDictionary["BossRakukun-03"]
        },
        {
          this.TextureObjectDictionary["BossRakukun-10"],
          this.TextureObjectDictionary["BossRakukun-11"],
          this.TextureObjectDictionary["BossRakukun-12"],
          this.TextureObjectDictionary["BossRakuki-13"]
        },
        {
          this.TextureObjectDictionary["BossRakukun-20"],
          this.TextureObjectDictionary["BossRakukun-21"],
          this.TextureObjectDictionary["BossRakukun-22"],
          this.TextureObjectDictionary["BossRakukun-23"]
        }
      };
      this.TxtureObject = this.TxtureObjects[0, 0];
      this.OriginalPosition = new PointF((float) (this.BoundRect.Width / 2), 150f);
      this.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 150);
      this.MaxHP = 10000;
      this.HealthPoint = (float) this.MaxHP;
      this.Life = 5;
      this.Region = 20;
      this.Velocity = 4f;
      this.DirectionDegree = 90.0;
      this.SpellTime = 3600;
      this.LifeTime = 100000;
      this.OnSpell = false;
      this.SetBossLifeLineTex();
      this.LoadArmon(".\\CS\\St05\\关底Boss\\ctrl.csv");
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
        case 2:
          this.Ctrl2();
          break;
        case 3:
          this.Ctrl3();
          break;
        case 4:
          this.Ctrl4();
          break;
        case 5:
          this.Ctrl5();
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
            int x = this.Ran.Next((int) this.OriginalPosition.X - 30, (int) this.OriginalPosition.X + 30);
            MyRandom ran = this.Ran;
            PointF originalPosition = this.OriginalPosition;
            int minValue = (int) originalPosition.Y + 30;
            originalPosition = this.OriginalPosition;
            int maxValue = (int) originalPosition.Y + 50;
            int y = ran.Next(minValue, maxValue);
            this.DestPoint = (PointF) new Point(x, y);
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
      if (this.MyPlane.FscEnabled)
      {
        this.LifeTime = this.Time + 50;
        EndBoss_FSC05 endBossFsC05 = new EndBoss_FSC05(this.StageData, this.OriginalPosition, Color.YellowGreen, Color.Green);
      }
      else
      {
        this.LifeTime = this.Time + 150;
        EndBoss_Touhou05 endBossTouhou05 = new EndBoss_Touhou05(this.StageData, this.OriginalPosition, Color.YellowGreen, Color.Green);
      }
    }

    private void Ctrl5()
    {
      if (!this.OnSpell)
      {
        this.Armon = this.ArmonArray[0];
        if (this.Time == 1)
        {
          Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
          this.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 160);
        }
        else if (this.Time > 50)
          this.RandomMove(346, 30, 2f, new Rectangle(this.BoundRect.Width / 2 - 60, 100, 120, 40));
        if (this.Time != 60)
          return;
        string FileName;
        switch (this.Difficulty)
        {
          case DifficultLevel.Easy:
            FileName = ".\\CS\\St05\\关底Boss\\1非E.mbg";
            break;
          case DifficultLevel.Normal:
            FileName = ".\\CS\\St05\\关底Boss\\1非N.mbg";
            break;
          case DifficultLevel.Hard:
            FileName = ".\\CS\\St05\\关底Boss\\1非H.mbg";
            break;
          case DifficultLevel.Lunatic:
            FileName = ".\\CS\\St05\\关底Boss\\1非L.mbg";
            break;
          default:
            FileName = ".\\CS\\St05\\关底Boss\\1非L.mbg";
            break;
        }
        new CSEmitterController(this.StageData, this.StageData.LoadCS(FileName)).BossBinding = true;
      }
      else if (this.Time == 1)
      {
        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
        SpellCard_SSS05_01 spellCardSsS0501 = new SpellCard_SSS05_01(this.StageData);
      }
    }

    private void Ctrl4()
    {
      if (!this.OnSpell)
      {
        this.Armon = this.ArmonArray[2];
        if (this.Time == 1)
        {
          Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
          this.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 160);
        }
        else if (this.Time > 150)
          this.RandomMove(346, 30, 2f, new Rectangle(this.BoundRect.Width / 2 - 60, 100, 120, 40));
        if (this.Time != 160)
          return;
        string FileName;
        switch (this.Difficulty)
        {
          case DifficultLevel.Easy:
            FileName = ".\\CS\\St05\\关底Boss\\2非E.mbg";
            break;
          case DifficultLevel.Normal:
            FileName = ".\\CS\\St05\\关底Boss\\2非N.mbg";
            break;
          case DifficultLevel.Hard:
            FileName = ".\\CS\\St05\\关底Boss\\2非H.mbg";
            break;
          case DifficultLevel.Lunatic:
            FileName = ".\\CS\\St05\\关底Boss\\2非L.mbg";
            break;
          default:
            FileName = ".\\CS\\St05\\关底Boss\\2非L.mbg";
            break;
        }
        new CSEmitterController(this.StageData, this.StageData.LoadCS(FileName)).BossBinding = true;
      }
      else if (this.Time == 1)
      {
        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
        SpellCard_SSS05_02 spellCardSsS0502 = new SpellCard_SSS05_02(this.StageData);
      }
    }

    private void Ctrl3()
    {
      if (!this.OnSpell)
      {
        this.Armon = this.ArmonArray[4];
        if (this.Time == 1)
        {
          Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
          this.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 160);
        }
        else if (this.Time > 50)
          this.RandomMove(346, 30, 2f, new Rectangle(this.BoundRect.Width / 2 - 60, 100, 120, 40));
        if (this.Time != 60)
          return;
        string FileName;
        switch (this.Difficulty)
        {
          case DifficultLevel.Easy:
            FileName = ".\\CS\\St05\\关底Boss\\3非E.mbg";
            break;
          case DifficultLevel.Normal:
            FileName = ".\\CS\\St05\\关底Boss\\3非N.mbg";
            break;
          case DifficultLevel.Hard:
            FileName = ".\\CS\\St05\\关底Boss\\3非H.mbg";
            break;
          case DifficultLevel.Lunatic:
            FileName = ".\\CS\\St05\\关底Boss\\3非L.mbg";
            break;
          default:
            FileName = ".\\CS\\St05\\关底Boss\\3非L.mbg";
            break;
        }
        new CSEmitterController(this.StageData, this.StageData.LoadCS(FileName)).BossBinding = true;
      }
      else if (this.Time == 1)
      {
        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
        SpellCard_SSS05_03 spellCardSsS0503 = new SpellCard_SSS05_03(this.StageData);
      }
    }

    private void Ctrl2()
    {
      if (!this.OnSpell)
      {
        if (this.Time == 1)
        {
          Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
          this.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 180);
        }
        if (this.Time != 100)
          return;
        this.OnSpell = true;
      }
      else if (this.Time == 101)
      {
        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
        SpellCard_SSS05_04 spellCardSsS0504 = new SpellCard_SSS05_04(this.StageData);
      }
    }

    private void Ctrl1()
    {
      if (!this.OnSpell)
      {
        if (this.Time == 1)
        {
          Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
          this.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 180);
        }
        if (this.Time != 100)
          return;
        this.OnSpell = true;
      }
      else if (this.Time == 101)
      {
        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
        SpellCard_SSS05_05 spellCardSsS0505 = new SpellCard_SSS05_05(this.StageData);
      }
    }
  }
}
