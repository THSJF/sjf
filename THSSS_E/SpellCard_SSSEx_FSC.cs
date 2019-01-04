// Decompiled with JetBrains decompiler
// Type: Shooting.SpellCard_SSSEx_FSC
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class SpellCard_SSSEx_FSC : BaseSpellCard
  {
    public SpellCard_SSSEx_FSC(StageDataPackage StageData)
      : base(StageData)
    {
      this.SC_Name = "「雾隐之蝶」";
      this.BaseScore = 40000000L;
      this.Boss.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 120);
      this.Boss.Velocity = 4f;
      StageData.SoundPlay("se_cat00.wav");
      BulletTitle bulletTitle = new BulletTitle(StageData, this.SC_Name);
      SpellCardAttack spellCardAttack = new SpellCardAttack(StageData);
      BackgroundBossEx backgroundBossEx = new BackgroundBossEx(StageData);
      switch (this.MyPlane.Name)
      {
        case "Reimu":
          FullPic2 fullPic2_1 = new FullPic2(StageData, "FaceRika_ct0");
          break;
        case "Marisa":
          FullPic2 fullPic2_2 = new FullPic2(StageData, "FaceRika_ct1");
          break;
        case "Sanae":
          FullPic2 fullPic2_3 = new FullPic2(StageData, "FaceRika_ct2");
          break;
        case "Koishi":
          FullPic2 fullPic2_4 = new FullPic2(StageData, "FaceRika_ct3");
          break;
        default:
          FullPic2 fullPic2_5 = new FullPic2(StageData, "FaceRika_ct0");
          break;
      }
    }

    public override void Shoot()
    {
      this.Boss.Armon = this.Boss.ArmonArray[18];
      if (this.Time != 100)
        return;
      CSEmitterController emitterController = new CSEmitterController(this.StageData, this.StageData.LoadCS(".\\CS\\StEx\\关底Boss\\FSC符.mbg"));
    }
  }
}
