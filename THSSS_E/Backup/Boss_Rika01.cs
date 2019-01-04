// Decompiled with JetBrains decompiler
// Type: Shooting.Boss_Rika01
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class Boss_Rika01 : BaseBossTouhou
  {
    public Boss_Rika01(StageDataPackage StageData)
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
      this.Life = 10;
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
        case 6:
          this.Ctrl6();
          break;
        case 7:
          this.Ctrl7();
          break;
        case 8:
          this.Ctrl8();
          break;
        case 9:
          this.Ctrl9();
          break;
        case 10:
          this.Ctrl10();
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
        EndBoss_FSCEx endBossFscEx = new EndBoss_FSCEx(this.StageData, this.OriginalPosition, Color.White, Color.Blue);
      }
      else
      {
        this.LifeTime = this.Time + 150;
        EndBoss_TouhouEx endBossTouhouEx = new EndBoss_TouhouEx(this.StageData, this.OriginalPosition, Color.White, Color.Blue);
      }
    }

    private void Ctrl10()
    {
      if (!this.OnSpell)
      {
        this.Armon = this.ArmonArray[0];
        if (this.Time == 1)
        {
          Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
          this.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 160);
        }
        else if (this.Time <= 50)
          ;
        if (this.Time != 60)
          return;
        new CSEmitterController(this.StageData, this.StageData.LoadCS(".\\CS\\StEx\\关底Boss\\1非.mbg")).BossBinding = true;
      }
      else if (this.Time == 1)
      {
        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
        switch (this.MyPlane.Name)
        {
          case "Reimu":
            SpellCard_SSSEx_01A spellCardSssEx01A1 = new SpellCard_SSSEx_01A(this.StageData);
            break;
          case "Marisa":
            SpellCard_SSSEx_01B spellCardSssEx01B = new SpellCard_SSSEx_01B(this.StageData);
            break;
          case "Sanae":
            SpellCard_SSSEx_01C spellCardSssEx01C = new SpellCard_SSSEx_01C(this.StageData);
            break;
          case "Koishi":
            SpellCard_SSSEx_01D spellCardSssEx01D = new SpellCard_SSSEx_01D(this.StageData);
            break;
          default:
            SpellCard_SSSEx_01A spellCardSssEx01A2 = new SpellCard_SSSEx_01A(this.StageData);
            break;
        }
      }
    }

    private void Ctrl9()
    {
      if (!this.OnSpell)
      {
        this.Armon = this.ArmonArray[2];
        if (this.Time == 1)
        {
          Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
          this.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 160);
        }
        else if (this.Time > 50)
          this.RandomMove(346, 30, 2f, new Rectangle(this.BoundRect.Width / 2 - 60, 100, 120, 40));
        if (this.Time != 60)
          return;
        new CSEmitterController(this.StageData, this.StageData.LoadCS(".\\CS\\StEx\\关底Boss\\2非.mbg")).BossBinding = true;
      }
      else if (this.Time == 1)
      {
        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
        switch (this.MyPlane.Name)
        {
          case "Reimu":
            SpellCard_SSSEx_02A spellCardSssEx02A1 = new SpellCard_SSSEx_02A(this.StageData);
            break;
          case "Marisa":
            SpellCard_SSSEx_02B spellCardSssEx02B = new SpellCard_SSSEx_02B(this.StageData);
            break;
          case "Sanae":
            SpellCard_SSSEx_02C spellCardSssEx02C = new SpellCard_SSSEx_02C(this.StageData);
            break;
          case "Koishi":
            SpellCard_SSSEx_02D spellCardSssEx02D = new SpellCard_SSSEx_02D(this.StageData);
            break;
          default:
            SpellCard_SSSEx_02A spellCardSssEx02A2 = new SpellCard_SSSEx_02A(this.StageData);
            break;
        }
      }
    }

    private void Ctrl8()
    {
      if (!this.OnSpell)
      {
        this.Armon = this.ArmonArray[4];
        if (this.Time == 1)
        {
          Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
          this.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 160);
        }
        else if (this.Time <= 150)
          ;
        if (this.Time != 160)
          return;
        new CSEmitterController(this.StageData, this.StageData.LoadCS(".\\CS\\StEx\\关底Boss\\3非.mbg")).BossBinding = true;
      }
      else if (this.Time == 1)
      {
        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
        switch (this.MyPlane.Name)
        {
          case "Reimu":
            SpellCard_SSSEx_03A spellCardSssEx03A1 = new SpellCard_SSSEx_03A(this.StageData);
            break;
          case "Marisa":
            SpellCard_SSSEx_03B spellCardSssEx03B = new SpellCard_SSSEx_03B(this.StageData);
            break;
          case "Sanae":
            SpellCard_SSSEx_03C spellCardSssEx03C = new SpellCard_SSSEx_03C(this.StageData);
            break;
          case "Koishi":
            SpellCard_SSSEx_03D spellCardSssEx03D = new SpellCard_SSSEx_03D(this.StageData);
            break;
          default:
            SpellCard_SSSEx_03A spellCardSssEx03A2 = new SpellCard_SSSEx_03A(this.StageData);
            break;
        }
      }
    }

    private void Ctrl7()
    {
      if (!this.OnSpell)
      {
        this.Armon = this.ArmonArray[6];
        if (this.Time == 1)
        {
          Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
          this.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 160);
        }
        else if (this.Time > 50)
          this.RandomMove(346, 30, 2f, new Rectangle(this.BoundRect.Width / 2 - 60, 100, 120, 40));
        if (this.Time != 60)
          return;
        new CSEmitterController(this.StageData, this.StageData.LoadCS(".\\CS\\StEx\\关底Boss\\4非.mbg")).BossBinding = true;
      }
      else if (this.Time == 1)
      {
        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
        switch (this.MyPlane.Name)
        {
          case "Reimu":
            SpellCard_SSSEx_04A spellCardSssEx04A1 = new SpellCard_SSSEx_04A(this.StageData);
            break;
          case "Marisa":
            SpellCard_SSSEx_04B spellCardSssEx04B = new SpellCard_SSSEx_04B(this.StageData);
            break;
          case "Sanae":
            SpellCard_SSSEx_04C spellCardSssEx04C = new SpellCard_SSSEx_04C(this.StageData);
            break;
          case "Koishi":
            SpellCard_SSSEx_04D spellCardSssEx04D = new SpellCard_SSSEx_04D(this.StageData);
            break;
          default:
            SpellCard_SSSEx_04A spellCardSssEx04A2 = new SpellCard_SSSEx_04A(this.StageData);
            break;
        }
      }
    }

    private void Ctrl6()
    {
      if (!this.OnSpell)
      {
        this.Armon = this.ArmonArray[8];
        if (this.Time == 1)
        {
          Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
          this.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 160);
        }
        else if (this.Time > 50)
          this.RandomMove(346, 30, 2f, new Rectangle(this.BoundRect.Width / 2 - 60, 100, 120, 40));
        if (this.Time != 60)
          return;
        new CSEmitterController(this.StageData, this.StageData.LoadCS(".\\CS\\StEx\\关底Boss\\5非.mbg")).BossBinding = true;
      }
      else if (this.Time == 1)
      {
        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
        switch (this.MyPlane.Name)
        {
          case "Reimu":
            SpellCard_SSSEx_05A spellCardSssEx05A1 = new SpellCard_SSSEx_05A(this.StageData);
            break;
          case "Marisa":
            SpellCard_SSSEx_05B spellCardSssEx05B = new SpellCard_SSSEx_05B(this.StageData);
            break;
          case "Sanae":
            SpellCard_SSSEx_05C spellCardSssEx05C = new SpellCard_SSSEx_05C(this.StageData);
            break;
          case "Koishi":
            SpellCard_SSSEx_05D spellCardSssEx05D = new SpellCard_SSSEx_05D(this.StageData);
            break;
          default:
            SpellCard_SSSEx_05A spellCardSssEx05A2 = new SpellCard_SSSEx_05A(this.StageData);
            break;
        }
      }
    }

    private void Ctrl5()
    {
      if (!this.OnSpell)
      {
        this.Armon = this.ArmonArray[10];
        if (this.Time == 1)
        {
          Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
          this.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 160);
        }
        else if (this.Time > 50)
          this.RandomMove(346, 30, 2f, new Rectangle(this.BoundRect.Width / 2 - 60, 100, 120, 40));
        if (this.Time != 60)
          return;
        new CSEmitterController(this.StageData, this.StageData.LoadCS(".\\CS\\StEx\\关底Boss\\6非.mbg")).BossBinding = true;
      }
      else if (this.Time == 1)
      {
        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
        switch (this.MyPlane.Name)
        {
          case "Reimu":
            SpellCard_SSSEx_06A spellCardSssEx06A1 = new SpellCard_SSSEx_06A(this.StageData);
            break;
          case "Marisa":
            SpellCard_SSSEx_06B spellCardSssEx06B = new SpellCard_SSSEx_06B(this.StageData);
            break;
          case "Sanae":
            SpellCard_SSSEx_06C spellCardSssEx06C = new SpellCard_SSSEx_06C(this.StageData);
            break;
          case "Koishi":
            SpellCard_SSSEx_06D spellCardSssEx06D = new SpellCard_SSSEx_06D(this.StageData);
            break;
          default:
            SpellCard_SSSEx_06A spellCardSssEx06A2 = new SpellCard_SSSEx_06A(this.StageData);
            break;
        }
      }
    }

    private void Ctrl4()
    {
      if (!this.OnSpell)
      {
        this.Armon = this.ArmonArray[12];
        if (this.Time == 1)
        {
          Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
          this.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 160);
        }
        else if (this.Time > 150)
          this.RandomMove(346, 30, 2f, new Rectangle(this.BoundRect.Width / 2 - 60, 100, 120, 40));
        if (this.Time != 160)
          return;
        new CSEmitterController(this.StageData, this.StageData.LoadCS(".\\CS\\StEx\\关底Boss\\7非.mbg")).BossBinding = true;
      }
      else if (this.Time == 1)
      {
        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
        switch (this.MyPlane.Name)
        {
          case "Reimu":
            SpellCard_SSSEx_07A spellCardSssEx07A1 = new SpellCard_SSSEx_07A(this.StageData);
            break;
          case "Marisa":
            SpellCard_SSSEx_07B spellCardSssEx07B = new SpellCard_SSSEx_07B(this.StageData);
            break;
          case "Sanae":
            SpellCard_SSSEx_07C spellCardSssEx07C = new SpellCard_SSSEx_07C(this.StageData);
            break;
          case "Koishi":
            SpellCard_SSSEx_07D spellCardSssEx07D = new SpellCard_SSSEx_07D(this.StageData);
            break;
          default:
            SpellCard_SSSEx_07A spellCardSssEx07A2 = new SpellCard_SSSEx_07A(this.StageData);
            break;
        }
      }
    }

    private void Ctrl3()
    {
      if (!this.OnSpell)
      {
        this.Armon = this.ArmonArray[14];
        if (this.Time == 1)
        {
          Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
          this.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 160);
        }
        else if (this.Time > 50)
          this.RandomMove(346, 30, 2f, new Rectangle(this.BoundRect.Width / 2 - 60, 100, 120, 40));
        if (this.Time != 60)
          return;
        new CSEmitterController(this.StageData, this.StageData.LoadCS(".\\CS\\StEx\\关底Boss\\8非.mbg")).BossBinding = true;
      }
      else if (this.Time == 1)
      {
        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
        SpellCard_SSSEx_08 spellCardSssEx08 = new SpellCard_SSSEx_08(this.StageData);
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
          this.SpellTime -= 1200;
        }
        if (this.Time != 100)
          return;
        this.OnSpell = true;
      }
      else if (this.Time == 101)
      {
        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
        SpellCard_SSSEx_09 spellCardSssEx09 = new SpellCard_SSSEx_09(this.StageData);
      }
    }

    private void Ctrl1()
    {
      if (!this.OnSpell)
      {
        if (this.Time == 1)
        {
          Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
          this.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 140);
        }
        if (this.Time != 100)
          return;
        this.OnSpell = true;
        this.SpellTime = 7200;
      }
      else if (this.Time == 101)
      {
        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
        SpellCard_SSSEx_10 spellCardSssEx10 = new SpellCard_SSSEx_10(this.StageData);
      }
    }

    public override void HitCheckAll()
    {
      if (this.OnSpell && this.StageData.SpellList.Count > 0 && this.MyPlane.Name != "Koishi")
        this.StageData.SpellList.ForEach((Action<BaseObject>) (x => x.Damage = 0));
      else
        base.HitCheckAll();
    }
  }
}
