 
// Type: Shooting.Boss_Kage02
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class Boss_Kage02 : BaseBossTouhou
  {
    public Boss_Kage02(StageDataPackage StageData)
      : base(StageData)
    {
      this.TxtureObjects = new TextureObject[3, 4]
      {
        {
          this.TextureObjectDictionary["BossKage-00"],
          this.TextureObjectDictionary["BossKage-01"],
          this.TextureObjectDictionary["BossKage-02"],
          this.TextureObjectDictionary["BossKage-03"]
        },
        {
          this.TextureObjectDictionary["BossKage-10"],
          this.TextureObjectDictionary["BossKage-11"],
          this.TextureObjectDictionary["BossKage-12"],
          this.TextureObjectDictionary["BossKage-13"]
        },
        {
          this.TextureObjectDictionary["BossKage-20"],
          this.TextureObjectDictionary["BossKage-21"],
          this.TextureObjectDictionary["BossKage-22"],
          this.TextureObjectDictionary["BossKage-23"]
        }
      };
      this.TxtureObject = this.TxtureObjects[0, 0];
      this.OriginalPosition = new PointF((float) (this.BoundRect.Width / 2), 150f);
      this.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 150);
      this.MaxHP = 10000;
      this.HealthPoint = (float) this.MaxHP;
      this.Life = 1;
      this.Region = 20;
      this.Velocity = 4f;
      this.DirectionDegree = 90.0;
      this.SpellTime = 2400;
      this.LifeTime = 100000;
      this.OnSpell = false;
      this.SetBossLifeLineTex();
      this.LoadArmon(".\\CS\\St04\\关底Boss\\ctrl.csv");
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
      this.Region = 0;
      this.StageData.SoundPlay("se_tan01.wav");
      this.LifeTime = this.Time + 150;
      EndBoss_Touhou04 endBossTouhou04 = new EndBoss_Touhou04(this.StageData, this.OriginalPosition, Color.Pink, Color.Violet);
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

    private void Ctrl1()
    {
      if (!this.OnSpell)
      {
        if (this.Time != 1)
          return;
        this.OnSpell = true;
        this.SpellTime = 3000;
      }
      else
      {
        this.Boss.Armon = 0.4f;
        if (this.Time == 2)
        {
          SpellCard_SSS04_FSC spellCardSsS04Fsc = new SpellCard_SSS04_FSC(this.StageData);
        }
      }
    }

    public override void GiveItems()
    {
      base.GiveItems();
      SpellItem_Touhou spellItemTouhou = new SpellItem_Touhou(this.StageData, this.OriginalPosition);
    }
  }
}
