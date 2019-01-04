// Decompiled with JetBrains decompiler
// Type: Shooting.SpellCard_SSS04_03C
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class SpellCard_SSS04_03C : BaseSpellCard
  {
    public SpellCard_SSS04_03C(StageDataPackage StageData)
      : base(StageData)
    {
      if (this.Difficulty < DifficultLevel.Hard)
        this.SC_Name = "岚符「大孔雀暴风」";
      else
        this.SC_Name = "岚符「大孔雀暴风」";
      this.BaseScore = 25000000L;
      this.Boss.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 128);
      this.Boss.Velocity = 4f;
      StageData.SoundPlay("se_cat00.wav");
      BackgroundBoss04 backgroundBoss04 = new BackgroundBoss04(StageData);
      BulletTitle bulletTitle = new BulletTitle(StageData, this.SC_Name);
      SpellCardAttack spellCardAttack = new SpellCardAttack(StageData);
      FullPic2 fullPic2 = new FullPic2(StageData, "FaceKage_ct");
    }

    public override void Shoot()
    {
      this.Boss.Armon = this.Boss.ArmonArray[4];
      if (this.Time > 100)
        this.Boss.MoveUpDown();
      if (this.Time == 150)
      {
        string FileName;
        switch (this.Difficulty)
        {
          case DifficultLevel.Easy:
            FileName = ".\\CS\\St04\\关底Boss\\3符E2.mbg";
            break;
          case DifficultLevel.Normal:
            FileName = ".\\CS\\St04\\关底Boss\\3符N2.mbg";
            break;
          case DifficultLevel.Hard:
            FileName = ".\\CS\\St04\\关底Boss\\3符H2.mbg";
            break;
          case DifficultLevel.Lunatic:
            FileName = ".\\CS\\St04\\关底Boss\\3符L2.mbg";
            break;
          default:
            FileName = ".\\CS\\St04\\关底Boss\\3符U2.mbg";
            break;
        }
        CSEmitterController emitterController = new CSEmitterController(this.StageData, this.StageData.LoadCS(FileName));
      }
      if ((this.Time - 160) % 363 != 0)
        return;
      this.Boss.OnAction = 250;
    }
  }
}
