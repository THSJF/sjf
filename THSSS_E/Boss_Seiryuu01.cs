// Decompiled with JetBrains decompiler
// Type: Shooting.Boss_Seiryuu01
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class Boss_Seiryuu01 : BaseBossTouhou
  {
    public Boss_Seiryuu01(StageDataPackage StageData)
      : base(StageData)
    {
      this.TxtureObjects = new TextureObject[3, 4]
      {
        {
          this.TextureObjectDictionary["BossSeiryuu-00"],
          this.TextureObjectDictionary["BossSeiryuu-01"],
          this.TextureObjectDictionary["BossSeiryuu-02"],
          this.TextureObjectDictionary["BossSeiryuu-03"]
        },
        {
          this.TextureObjectDictionary["BossSeiryuu-10"],
          this.TextureObjectDictionary["BossSeiryuu-11"],
          this.TextureObjectDictionary["BossSeiryuu-12"],
          this.TextureObjectDictionary["BossSeiryuu-13"]
        },
        {
          this.TextureObjectDictionary["BossSeiryuu-20"],
          this.TextureObjectDictionary["BossSeiryuu-21"],
          this.TextureObjectDictionary["BossSeiryuu-22"],
          this.TextureObjectDictionary["BossSeiryuu-23"]
        }
      };
      this.TxtureObject = this.TxtureObjects[0, 0];
      this.OriginalPosition = new PointF((float) (this.BoundRect.Width / 2), 150f);
      this.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 150);
      this.MaxHP = 10000;
      this.HealthPoint = (float) this.MaxHP;
      this.Life = 3;
      this.Region = 20;
      this.Velocity = 4f;
      this.DirectionDegree = 90.0;
      this.SpellTime = 2400;
      this.LifeTime = 100000;
      this.OnSpell = false;
      this.SetBossLifeLineTex();
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

    public override void TextureCtrl()
    {
      int num = this.Mirrored ? this.IndexY : -this.IndexY;
      if (this.OnAction > 0)
      {
        this.IndexY = 2;
        this.IndexX += 0.125f;
        --this.OnAction;
      }
      else if ((double) this.Vx < -0.0500000007450581)
      {
        this.Mirrored = false;
        this.IndexY = 1;
        if ((double) this.Vx < -1.0)
        {
          if ((double) this.IndexX < 2.0)
            this.IndexX += 0.125f;
          else
            this.IndexX = (float) (2 + this.Time % 16 / 8);
        }
        else if ((double) this.Vx < -0.5)
          this.IndexX = 1f;
        else
          this.IndexX = 0.0f;
      }
      else if ((double) this.Vx > 0.0500000007450581)
      {
        this.Mirrored = true;
        this.IndexY = 1;
        if ((double) this.Vx > 1.0)
        {
          if ((double) this.IndexX < 2.0)
            this.IndexX += 0.125f;
          else
            this.IndexX = (float) (2 + this.Time % 16 / 8);
        }
        else if ((double) this.Vx > 0.5)
          this.IndexX = 1f;
        else
          this.IndexX = 0.0f;
      }
      else
      {
        this.Mirrored = false;
        this.IndexY = 0;
        this.IndexX = (float) (this.TimeMain % 32 / 8);
      }
      if (num != (this.Mirrored ? this.IndexY : -this.IndexY))
        this.IndexX = 0.0f;
      if ((double) this.IndexX > 3.0)
        this.IndexX = 3f;
      this.TxtureObject = this.TxtureObjects[this.IndexY, (int) this.IndexX];
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
        EndBoss_FSC03 endBossFsC03 = new EndBoss_FSC03(this.StageData, this.OriginalPosition, Color.ForestGreen, Color.Green);
      }
      else
      {
        this.LifeTime = this.Time + 150;
        EndBoss_Touhou03 endBossTouhou03 = new EndBoss_Touhou03(this.StageData, this.OriginalPosition, Color.ForestGreen, Color.Green);
      }
    }

    private void Ctrl3()
    {
      if (!this.OnSpell)
      {
        this.Armon = 0.25f;
        if (this.Time == 1)
        {
          Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
          this.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 160);
        }
        else if (this.Time > 50)
          this.RandomMove(206, 20, 2f, new Rectangle(this.BoundRect.Width / 2 - 45, 100, 90, 40));
        if (this.Time != 60)
          return;
        string FileName;
        switch (this.Difficulty)
        {
          case DifficultLevel.Easy:
            FileName = ".\\CS\\St03\\关底Boss\\1非E.mbg";
            break;
          case DifficultLevel.Normal:
            FileName = ".\\CS\\St03\\关底Boss\\1非N.mbg";
            break;
          case DifficultLevel.Hard:
            FileName = ".\\CS\\St03\\关底Boss\\1非H.mbg";
            break;
          case DifficultLevel.Lunatic:
            FileName = ".\\CS\\St03\\关底Boss\\1非L.mbg";
            break;
          default:
            FileName = ".\\CS\\St03\\关底Boss\\1非L.mbg";
            break;
        }
        new CSEmitterController(this.StageData, this.StageData.LoadCS(FileName)).BossBinding = true;
      }
      else if (this.Time == 1)
      {
        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
        SpellCard_SSS03_03 spellCardSsS0303 = new SpellCard_SSS03_03(this.StageData);
      }
    }

    private void Ctrl2()
    {
      if (!this.OnSpell)
      {
        this.Armon = 0.25f;
        if (this.Time == 1)
        {
          Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
          this.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 120);
        }
        else if (this.Time > 150)
          this.RandomMove(206, 30, 2f, new Rectangle(this.BoundRect.Width / 2 - 60, 100, 120, 40));
        if (this.Time != 160)
          return;
        string FileName;
        switch (this.Difficulty)
        {
          case DifficultLevel.Easy:
            FileName = ".\\CS\\St03\\关底Boss\\2非E.mbg";
            break;
          case DifficultLevel.Normal:
            FileName = ".\\CS\\St03\\关底Boss\\2非N.mbg";
            break;
          case DifficultLevel.Hard:
            FileName = ".\\CS\\St03\\关底Boss\\2非H.mbg";
            break;
          case DifficultLevel.Lunatic:
            FileName = ".\\CS\\St03\\关底Boss\\2非L.mbg";
            break;
          default:
            FileName = ".\\CS\\St03\\关底Boss\\2非L.mbg";
            break;
        }
        new CSEmitterController(this.StageData, this.StageData.LoadCS(FileName)).BossBinding = true;
      }
      else if (this.Time == 1)
      {
        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
        SpellCard_SSS03_04 spellCardSsS0304 = new SpellCard_SSS03_04(this.StageData);
      }
    }

    private void Ctrl1()
    {
      if (!this.OnSpell)
      {
        this.Armon = 0.25f;
        if (this.Time == 1)
        {
          Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
          this.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 160);
        }
        else if (this.Time > 150)
          this.RandomMove(206, 30, 2f, new Rectangle(this.BoundRect.Width / 2 - 60, 100, 120, 40));
        if (this.Time != 160)
          return;
        string FileName;
        switch (this.Difficulty)
        {
          case DifficultLevel.Easy:
            FileName = ".\\CS\\St03\\关底Boss\\3非E.mbg";
            break;
          case DifficultLevel.Normal:
            FileName = ".\\CS\\St03\\关底Boss\\3非N.mbg";
            break;
          case DifficultLevel.Hard:
            FileName = ".\\CS\\St03\\关底Boss\\3非H.mbg";
            break;
          case DifficultLevel.Lunatic:
            FileName = ".\\CS\\St03\\关底Boss\\3非L.mbg";
            break;
          default:
            FileName = ".\\CS\\St03\\关底Boss\\3非U.mbg";
            break;
        }
        new CSEmitterController(this.StageData, this.StageData.LoadCS(FileName)).BossBinding = true;
      }
      else if (this.Time == 1)
      {
        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
        SpellCard_SSS03_05 spellCardSsS0305 = new SpellCard_SSS03_05(this.StageData);
      }
    }
  }
}
