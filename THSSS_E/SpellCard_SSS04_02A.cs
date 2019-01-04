// Decompiled with JetBrains decompiler
// Type: Shooting.SpellCard_SSS04_02A
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class SpellCard_SSS04_02A : BaseSpellCard
  {
    public SpellCard_SSS04_02A(StageDataPackage StageData)
      : base(StageData)
    {
      if (this.Difficulty < DifficultLevel.Hard)
        this.SC_Name = "镜符「月季色红梦裂隙」";
      else
        this.SC_Name = "镜符「月季色红梦裂隙」";
      this.BaseScore = 25000000L;
      this.Boss.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 120);
      this.Boss.Velocity = 4f;
      StageData.SoundPlay("se_cat00.wav");
      BackgroundBoss04 backgroundBoss04 = new BackgroundBoss04(StageData);
      BulletTitle bulletTitle = new BulletTitle(StageData, this.SC_Name);
      SpellCardAttack spellCardAttack = new SpellCardAttack(StageData);
      new FullPic2(StageData, "FaceKage_ct").Scale = 0.8f;
    }

    public override void Shoot()
    {
      this.Boss.Armon = this.Boss.ArmonArray[3];
      if (this.Time > 100)
        this.Boss.RandomMove(205, 20, 2f, new Rectangle(this.BoundRect.Width / 2 - 45, 100, 90, 40));
      if (this.Time != 150)
        return;
      this.Boss.OnAction = 10000;
      string FileName;
      switch (this.Difficulty)
      {
        case DifficultLevel.Easy:
          FileName = ".\\CS\\St04\\关底Boss\\2符E0.mbg";
          break;
        case DifficultLevel.Normal:
          FileName = ".\\CS\\St04\\关底Boss\\2符N0.mbg";
          break;
        case DifficultLevel.Hard:
          FileName = ".\\CS\\St04\\关底Boss\\2符H0.mbg";
          break;
        case DifficultLevel.Lunatic:
          FileName = ".\\CS\\St04\\关底Boss\\2符L0.mbg";
          break;
        default:
          FileName = ".\\CS\\St04\\关底Boss\\2符U0.mbg";
          break;
      }
      CSEmitterController emitterController = new CSEmitterController(this.StageData, this.StageData.LoadCS(FileName));
    }
  }
}
