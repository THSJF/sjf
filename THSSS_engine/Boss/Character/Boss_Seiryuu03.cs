﻿ 
// Type: Shooting.Boss_Seiryuu03
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class Boss_Seiryuu03 : BaseBossTouhou
  {
    public Boss_Seiryuu03(StageDataPackage StageData)
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
      this.OriginalPosition = new PointF(30f, -50f);
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
      this.LoadArmon(".\\CS\\StEx\\道中Boss\\ctrl.csv");
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
      EndBoss_Touhou_Small endBossTouhouSmall = new EndBoss_Touhou_Small(this.StageData, this.OriginalPosition, Color.ForestGreen, Color.Green);
      Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
      this.Background3D.WarpEnabled = false;
      LifeItem_Touhou lifeItemTouhou = new LifeItem_Touhou(this.StageData, this.OriginalPosition);
    }

    private void Ctrl3()
    {
      if (!this.OnSpell)
      {
        if (this.Time == 1)
        {
          Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
          this.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 180);
        }
        if (this.Time != 200)
          return;
        this.OnSpell = true;
        this.SpellTime = 3000;
      }
      else if (this.Time == 201)
      {
        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
        SpellCard_SSSEx_01 spellCardSssEx01 = new SpellCard_SSSEx_01(this.StageData);
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
        this.SpellTime = 3000;
      }
      else if (this.Time == 101)
      {
        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
        SpellCard_SSSEx_02 spellCardSssEx02 = new SpellCard_SSSEx_02(this.StageData);
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
        this.SpellTime = 3000;
      }
      else if (this.Time == 101)
      {
        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
        SpellCard_SSSEx_03 spellCardSssEx03 = new SpellCard_SSSEx_03(this.StageData);
      }
    }
  }
}
