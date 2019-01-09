 
// Type: Shooting.SpellCard_SSS06_FSC02
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class SpellCard_SSS06_FSC02 : BaseFSC
  {
    public SpellCard_SSS06_FSC02(StageDataPackage StageData)
      : base(StageData)
    {
      this.SC_Name = "第二个愿望「无穷之力」";
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
      if (this.Time > 100)
      {
        this.Boss.MoveUpDown();
        this.Boss.Armon = this.Boss.ArmonArray[11];
      }
      if (this.Time != 100)
        return;
      string FileName;
      switch (this.Difficulty)
      {
        case DifficultLevel.Hard:
          FileName = ".\\CS\\St06\\关底Boss\\FSC2H.mbg";
          break;
        case DifficultLevel.Lunatic:
          FileName = ".\\CS\\St06\\关底Boss\\FSC2L.mbg";
          break;
        default:
          FileName = ".\\CS\\St06\\关底Boss\\FSC2L.mbg";
          break;
      }
      CSEmitterController emitterController = new CSEmitterController(this.StageData, this.StageData.LoadCS(FileName));
    }
  }
}
