// Decompiled with JetBrains decompiler
// Type: Shooting.SpellCard_SSS01_FSC
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class SpellCard_SSS01_FSC : BaseFSC
  {
    public SpellCard_SSS01_FSC(StageDataPackage StageData)
      : base(StageData)
    {
      if (this.Difficulty < DifficultLevel.Hard)
        this.SC_Name = "夜风「轮回的幸运之星」";
      else
        this.SC_Name = "夜风「轮回的幸运之星」";
      this.Boss.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 120);
      this.Boss.Velocity = 4f;
      StageData.SoundPlay("se_cat00.wav");
      new BackgroundMove2(StageData, "Card01b").DirectionDegree = 270.0;
      BackgroundMove2 backgroundMove2 = new BackgroundMove2(StageData, "Card01a");
      backgroundMove2.DirectionDegree = -80.0;
      backgroundMove2.Length = 1024;
      backgroundMove2.TransparentValueF = 80f;
      BulletTitle bulletTitle = new BulletTitle(StageData, this.SC_Name);
      SpellCardAttack spellCardAttack = new SpellCardAttack(StageData);
      FullPic2 fullPic2 = new FullPic2(StageData, "FaceAmi_ct");
    }

    public override void Shoot()
    {
      if (this.Time > 100)
      {
        this.Boss.MoveUpDown();
        this.Boss.Armon = 0.0f;
      }
      if (this.Time != 100)
        return;
      this.Boss.OnAction = 10000;
      string FileName;
      switch (this.Difficulty)
      {
        case DifficultLevel.Hard:
          FileName = ".\\CS\\St01\\关底Boss\\FSC符H.mbg";
          break;
        case DifficultLevel.Lunatic:
          FileName = ".\\CS\\St01\\关底Boss\\FSC符L.mbg";
          break;
        default:
          FileName = ".\\CS\\St01\\关底Boss\\FSC符L.mbg";
          break;
      }
      CSEmitterController emitterController = new CSEmitterController(this.StageData, this.StageData.LoadCS(FileName));
    }
  }
}
