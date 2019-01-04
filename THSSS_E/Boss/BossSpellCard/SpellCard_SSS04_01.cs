// Decompiled with JetBrains decompiler
// Type: Shooting.SpellCard_SSS04_01
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class SpellCard_SSS04_01 : BaseSpellCard
  {
    public SpellCard_SSS04_01(StageDataPackage StageData)
      : base(StageData)
    {
      if (this.Difficulty < DifficultLevel.Hard)
        this.SC_Name = "魔镜「幻影之境」";
      else
        this.SC_Name = "魔镜「虚无幽幻之境」";
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
      this.Boss.Armon = this.Boss.ArmonArray[1];
      if (this.Time > 50)
        this.Boss.MoveUpDown();
      if (this.Time != 100)
        return;
      string FileName;
      switch (this.Difficulty)
      {
        case DifficultLevel.Easy:
          FileName = ".\\CS\\St04\\关底Boss\\1符E.mbg";
          break;
        case DifficultLevel.Normal:
          FileName = ".\\CS\\St04\\关底Boss\\1符N.mbg";
          break;
        case DifficultLevel.Hard:
          FileName = ".\\CS\\St04\\关底Boss\\1符H.mbg";
          break;
        case DifficultLevel.Lunatic:
          FileName = ".\\CS\\St04\\关底Boss\\1符L.mbg";
          break;
        default:
          FileName = ".\\CS\\St04\\关底Boss\\1符U.mbg";
          break;
      }
      new CSEmitterController(this.StageData, this.StageData.LoadCS(FileName)).BossBinding = true;
    }
  }
}
