// Decompiled with JetBrains decompiler
// Type: Shooting.BaseTimeSC
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

namespace Shooting
{
  internal class BaseTimeSC : BaseSpellCard
  {
    public BaseTimeSC(StageDataPackage StageData)
      : base(StageData)
    {
      this.Boss.Armon = 1f;
      this.Boss.HitEnabled = false;
      this.Boss.TransparentValueF = 200f;
    }

    public override void GiveEndEffect()
    {
      if (!this.Bombed && !this.Missed)
      {
        this.StageData.SoundPlay("se_cardget.wav");
        SpellCardBonus spellCardBonus = new SpellCardBonus(this.StageData, this.GetSpellCardBonus());
        if (!this.StageData.OnReplay)
          ++this.SC_Data.Recorded;
      }
      this.Background3D.Enabled3D = true;
      this.StageData.SCBstring = (string) null;
      this.Boss.HitEnabled = true;
      this.Boss.TransparentValueF = (float) byte.MaxValue;
    }

    public override long GetSpellCardBonus()
    {
      if (this.Bombed || this.Missed)
        return 0;
      return this.BaseScore + (long) this.Difficulty * 2000000L;
    }
  }
}
