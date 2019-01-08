// Decompiled with JetBrains decompiler
// Type: Shooting.SpellCard_SSS06_FSC03
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class SpellCard_SSS06_FSC03 : BaseTimeSC
  {
    public SpellCard_SSS06_FSC03(StageDataPackage StageData)
      : base(StageData)
    {
      this.SC_Name = "第三个愿望「永生不灭」";
      this.Boss.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 120);
      this.Boss.Velocity = 4f;
      StageData.SoundPlay("se_cat00.wav");
      BackgroundBoss06 backgroundBoss06 = new BackgroundBoss06(StageData);
      BulletTitle bulletTitle = new BulletTitle(StageData, this.SC_Name);
      SpellCardAttack spellCardAttack = new SpellCardAttack(StageData);
      FullPic3 fullPic3 = new FullPic3(StageData, "FaceTensei_ct3");
    }

    public override void Shoot() { 
            if (this.Time > 100)
      {
        this.Boss.MoveUpDown();
        this.Boss.Armon = this.Boss.ArmonArray[12];
      }
      if (this.Time != 100)
        return;
      string FileName;
      switch (this.Difficulty)
      {
        case DifficultLevel.Hard:
          FileName = ".\\CS\\St06\\关底Boss\\FSC3H.mbg";
          break;
        case DifficultLevel.Lunatic:
          FileName = ".\\CS\\St06\\关底Boss\\FSC3L.mbg";
          break;
        default:
          FileName = ".\\CS\\St06\\关底Boss\\FSC3L.mbg";
          break;
      }
      CSEmitterController emitterController = new CSEmitterController(this.StageData, this.StageData.LoadCS(FileName));
    }

    public override void GiveEndEffect()
    {
      if (!this.Bombed && !this.Missed && this.Time >= this.SpellTime)
      {
        this.StageData.SoundPlay("se_cardget.wav");
        SpellCardBonus spellCardBonus = new SpellCardBonus(this.StageData, this.GetSpellCardBonus());
        if (!this.StageData.OnReplay)
          ++this.SC_Data.Recorded;
      }
      this.Background3D.Enabled3D = true;
      this.StageData.SCBstring = (string) null;
    }

    public override long GetSpellCardBonus()
    {
      return this.Bombed || this.Missed ? 0L : 99999990L;
    }
  }
}
