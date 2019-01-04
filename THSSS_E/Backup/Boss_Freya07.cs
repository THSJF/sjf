// Decompiled with JetBrains decompiler
// Type: Shooting.Boss_Freya07
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class Boss_Freya07 : BaseBossTouhou
  {
    private bool ShowWings { get; set; }

    private TextureObject TxtureObject2 { get; set; }

    private TextureObject[] TxtureObjects2 { get; set; }

    private int IndexX2 { get; set; }

    public Boss_Freya07(StageDataPackage StageData)
      : base(StageData)
    {
      this.TxtureObjects = new TextureObject[3, 4]
      {
        {
          this.TextureObjectDictionary["BossFreya-00"],
          this.TextureObjectDictionary["BossFreya-01"],
          this.TextureObjectDictionary["BossFreya-02"],
          this.TextureObjectDictionary["BossFreya-03"]
        },
        {
          this.TextureObjectDictionary["BossFreya-10"],
          this.TextureObjectDictionary["BossFreya-11"],
          this.TextureObjectDictionary["BossFreya-12"],
          this.TextureObjectDictionary["BossFreya-13"]
        },
        {
          this.TextureObjectDictionary["BossFreya-00"],
          this.TextureObjectDictionary["BossFreya-01"],
          this.TextureObjectDictionary["BossFreya-02"],
          this.TextureObjectDictionary["BossFreya-03"]
        }
      };
      this.TxtureObjects2 = new TextureObject[8]
      {
        this.TextureObjectDictionary["BossFreyaWing-00"],
        this.TextureObjectDictionary["BossFreyaWing-01"],
        this.TextureObjectDictionary["BossFreyaWing-02"],
        this.TextureObjectDictionary["BossFreyaWing-03"],
        this.TextureObjectDictionary["BossFreyaWing-04"],
        this.TextureObjectDictionary["BossFreyaWing-05"],
        this.TextureObjectDictionary["BossFreyaWing-06"],
        this.TextureObjectDictionary["BossFreyaWing-07"]
      };
      this.TxtureObject = this.TxtureObjects[0, 0];
      this.TxtureObject2 = this.TxtureObjects2[0];
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
      this.ShowWings = true;
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
        this.IndexX2 = this.TimeMain % 32 / 8;
      }
      if (num != (this.Mirrored ? this.IndexY : -this.IndexY))
      {
        this.IndexX = 0.0f;
        this.IndexX2 = 0;
      }
      if ((double) this.IndexX > 3.0)
        this.IndexX = 3f;
      if (this.IndexX2 > 7)
        this.IndexX2 = 7;
      this.TxtureObject = this.TxtureObjects[this.IndexY, (int) this.IndexX];
      this.TxtureObject2 = this.TxtureObjects2[this.IndexX2];
    }

    public override void GiveEndEffect()
    {
      this.TransparentValueF = (float) byte.MaxValue;
      Background2DRemover background2Dremover = new Background2DRemover(this.StageData);
      this.Background3D.WarpEnabled = false;
      this.LifeTime = this.Time + 150;
      this.Region = 0;
      this.StageData.SoundPlay("se_tan01.wav");
      EndBoss_Touhou01 endBossTouhou01 = new EndBoss_Touhou01(this.StageData, this.OriginalPosition, Color.LightPink, Color.Pink);
    }

    private void Ctrl3()
    {
      if (!this.OnSpell)
      {
        this.Armon = 0.0f;
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
            FileName = ".\\CS\\St02\\关底Boss\\1非E.mbg";
            break;
          case DifficultLevel.Normal:
            FileName = ".\\CS\\St02\\关底Boss\\1非N.mbg";
            break;
          case DifficultLevel.Hard:
            FileName = ".\\CS\\St02\\关底Boss\\1非H.mbg";
            break;
          case DifficultLevel.Lunatic:
            FileName = ".\\CS\\St02\\关底Boss\\1非L.mbg";
            break;
          default:
            FileName = ".\\CS\\St02\\关底Boss\\1非L.mbg";
            break;
        }
        new CSEmitterController(this.StageData, this.StageData.LoadCS(FileName)).BossBinding = true;
      }
      else if (this.Time == 1)
      {
        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
        SpellCard_SSS02_02 spellCardSsS0202 = new SpellCard_SSS02_02(this.StageData);
      }
    }

    private void Ctrl2()
    {
      if (!this.OnSpell)
      {
        this.ShowWings = false;
        if (this.Time == 100)
        {
          this.StageData.SoundPlay("se_boon01.wav");
          EmitterGiveOutEnegy3D emitterGiveOutEnegy3D = new EmitterGiveOutEnegy3D(this.StageData, this.Boss.OriginalPosition, Color.SkyBlue);
          BackgroundWing backgroundWing = new BackgroundWing(this.StageData, "Wing", this.Boss.OriginalPosition, 0.0f, 0.0, 0);
          new BackgroundWing(this.StageData, "Wing", this.Boss.OriginalPosition, 0.0f, Math.PI, 0).Mirrored = true;
          this.StageData.VibrateStart(50);
        }
        this.Armon = 0.3f;
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
            FileName = ".\\CS\\St02\\关底Boss\\2非E.mbg";
            break;
          case DifficultLevel.Normal:
            FileName = ".\\CS\\St02\\关底Boss\\2非N.mbg";
            break;
          case DifficultLevel.Hard:
            FileName = ".\\CS\\St02\\关底Boss\\2非H.mbg";
            break;
          case DifficultLevel.Lunatic:
            FileName = ".\\CS\\St02\\关底Boss\\2非L.mbg";
            break;
          default:
            FileName = ".\\CS\\St02\\关底Boss\\2非L.mbg";
            break;
        }
        new CSEmitterController(this.StageData, this.StageData.LoadCS(FileName)).BossBinding = true;
      }
      else if (this.Time == 1)
      {
        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
        SpellCard_SSS02_03 spellCardSsS0203 = new SpellCard_SSS02_03(this.StageData);
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
        else
          this.RandomMove1(150, 4f);
        if (this.Time != 150)
          return;
        this.OnSpell = true;
        this.SpellTime = 3000;
      }
      else if (this.Time == 151)
      {
        BulletRemover2 bulletRemover2 = new BulletRemover2(this.StageData, this.OriginalPosition);
        SpellCard_SSS02_04 spellCardSsS0204 = new SpellCard_SSS02_04(this.StageData);
      }
    }

    public override void GiveItems()
    {
      PointF OriginalPosition;
      for (int index = 0; index < 15; ++index)
      {
        ref PointF local = ref OriginalPosition;
        PointF originalPosition = this.OriginalPosition;
        double num1 = (double) originalPosition.X + (double) this.Ran.Next(-49, 50);
        originalPosition = this.OriginalPosition;
        double num2 = (double) originalPosition.Y + (double) this.Ran.Next(-49, 50);
        local = new PointF((float) num1, (float) num2);
        PowerItem_Touhou powerItemTouhou = new PowerItem_Touhou(this.StageData, OriginalPosition);
      }
      for (int index = 0; index < 20; ++index)
      {
        ref PointF local = ref OriginalPosition;
        PointF originalPosition = this.OriginalPosition;
        double num1 = (double) originalPosition.X + (double) this.Ran.Next(-49, 50);
        originalPosition = this.OriginalPosition;
        double num2 = (double) originalPosition.Y + (double) this.Ran.Next(-49, 50);
        local = new PointF((float) num1, (float) num2);
        ScoreItem_Touhou scoreItemTouhou = new ScoreItem_Touhou(this.StageData, OriginalPosition);
      }
    }

    public override void Show()
    {
      if (this.ShowWings && this.TxtureObject2 != null)
        this.SpriteMain.Draw2D(this.TxtureObject2, this.ScaleWidth, this.ScaleLength, (float) (this.Angle - Math.PI / 2.0), this.Position, Color.FromArgb(this.TransparentValue, this.ColorValue), this.Mirrored);
      base.Show();
    }
  }
}
