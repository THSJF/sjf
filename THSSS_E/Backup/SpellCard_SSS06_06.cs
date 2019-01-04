// Decompiled with JetBrains decompiler
// Type: Shooting.SpellCard_SSS06_06
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class SpellCard_SSS06_06 : BaseSpellCard
  {
    private int flag = 1;

    public SpellCard_SSS06_06(StageDataPackage StageData)
      : base(StageData)
    {
      if (this.Difficulty < DifficultLevel.Hard)
        this.SC_Name = "「流星神话」";
      else
        this.SC_Name = "「流星神话」";
      this.BaseScore = 35000000L;
      this.Boss.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 120);
      this.Boss.Velocity = 4f;
      StageData.SoundPlay("se_cat00.wav");
      BackgroundBoss06 backgroundBoss06 = new BackgroundBoss06(StageData);
      BulletTitle bulletTitle = new BulletTitle(StageData, this.SC_Name);
      SpellCardAttack spellCardAttack = new SpellCardAttack(StageData);
      FullPic3 fullPic3 = new FullPic3(StageData, "FaceTensei_ct3");
    }

    public override void Shoot()
    {
      if (this.SpellList.Count > 0 || this.MyPlane.Time < this.MyPlane.UnmatchedTime - 30)
        this.Boss.Armon = 1f;
      else
        this.Boss.Armon = this.Boss.ArmonArray[9];
      if (this.Time > 100)
        this.Boss.MoveUpDown();
      if (this.Time == 150)
      {
        string FileName;
        switch (this.Difficulty)
        {
          case DifficultLevel.Easy:
            FileName = ".\\CS\\St06\\关底Boss\\6符P1E.mbg";
            break;
          case DifficultLevel.Normal:
            FileName = ".\\CS\\St06\\关底Boss\\6符P1N.mbg";
            break;
          case DifficultLevel.Hard:
            FileName = ".\\CS\\St06\\关底Boss\\6符P1H.mbg";
            break;
          case DifficultLevel.Lunatic:
            FileName = ".\\CS\\St06\\关底Boss\\6符P1L.mbg";
            break;
          default:
            FileName = ".\\CS\\St06\\关底Boss\\6符P1L.mbg";
            break;
        }
        CSEmitterController emitterController = new CSEmitterController(this.StageData, this.StageData.LoadCS(FileName));
      }
      if (((double) this.Boss.HealthPoint < (double) (this.Boss.MaxHP * 3) / 4.0 || this.Time > 1800) && this.flag == 1)
      {
        ++this.flag;
        this.ClearEmitter();
        string FileName;
        switch (this.Difficulty)
        {
          case DifficultLevel.Easy:
            FileName = ".\\CS\\St06\\关底Boss\\6符P2E.mbg";
            break;
          case DifficultLevel.Normal:
            FileName = ".\\CS\\St06\\关底Boss\\6符P2N.mbg";
            break;
          case DifficultLevel.Hard:
            FileName = ".\\CS\\St06\\关底Boss\\6符P2H.mbg";
            break;
          case DifficultLevel.Lunatic:
            FileName = ".\\CS\\St06\\关底Boss\\6符P2L.mbg";
            break;
          default:
            FileName = ".\\CS\\St06\\关底Boss\\6符P2L.mbg";
            break;
        }
        CSEmitterController emitterController = new CSEmitterController(this.StageData, this.StageData.LoadCS(FileName));
      }
      if (((double) this.Boss.HealthPoint < (double) (this.Boss.MaxHP * 2) / 4.0 || this.Time > 3600) && this.flag == 2)
      {
        ++this.flag;
        this.ClearEmitter();
        string FileName;
        switch (this.Difficulty)
        {
          case DifficultLevel.Easy:
            FileName = ".\\CS\\St06\\关底Boss\\6符P3E.mbg";
            break;
          case DifficultLevel.Normal:
            FileName = ".\\CS\\St06\\关底Boss\\6符P3N.mbg";
            break;
          case DifficultLevel.Hard:
            FileName = ".\\CS\\St06\\关底Boss\\6符P3H.mbg";
            break;
          case DifficultLevel.Lunatic:
            FileName = ".\\CS\\St06\\关底Boss\\6符P3L.mbg";
            break;
          default:
            FileName = ".\\CS\\St06\\关底Boss\\6符P2L.mbg";
            break;
        }
        CSEmitterController emitterController = new CSEmitterController(this.StageData, this.StageData.LoadCS(FileName));
      }
      if ((double) this.Boss.HealthPoint >= (double) this.Boss.MaxHP / 4.0 && this.Time <= 5400 || this.flag != 3)
        return;
      ++this.flag;
      this.ClearEmitter();
      string FileName1;
      switch (this.Difficulty)
      {
        case DifficultLevel.Easy:
          FileName1 = ".\\CS\\St06\\关底Boss\\6符P4E.mbg";
          break;
        case DifficultLevel.Normal:
          FileName1 = ".\\CS\\St06\\关底Boss\\6符P4N.mbg";
          break;
        case DifficultLevel.Hard:
          FileName1 = ".\\CS\\St06\\关底Boss\\6符P4H.mbg";
          break;
        case DifficultLevel.Lunatic:
          FileName1 = ".\\CS\\St06\\关底Boss\\6符P4L.mbg";
          break;
        default:
          FileName1 = ".\\CS\\St06\\关底Boss\\6符P4L.mbg";
          break;
      }
      CSEmitterController emitterController1 = new CSEmitterController(this.StageData, this.StageData.LoadCS(FileName1));
    }

    private void ClearEmitter()
    {
      for (int index = this.EnemyPlaneList.Count - 1; index >= 0; --index)
      {
        if (!(this.EnemyPlaneList[index] is BaseSpellCard))
        {
          this.EnemyPlaneList[index].GiveEndEffect();
          this.EnemyPlaneList.RemoveAt(index);
        }
      }
      foreach (BaseObject bullet in this.BulletList)
        bullet.GiveEndEffect();
      this.BulletList.Clear();
    }
  }
}
