// Decompiled with JetBrains decompiler
// Type: Shooting.BaseSpellCard
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;

namespace Shooting
{
  internal class BaseSpellCard : BaseBulleEmitter
  {
    public SpellCardHistory SC_Data;

    public bool Bombed { get; set; }

    public bool Missed { get; set; }

    public long BaseScore { get; set; }

    public int SpellTime { get; set; }

    public string SC_Name { get; set; }

    public BaseSpellCard(StageDataPackage StageData)
      : base(StageData)
    {
      if (this.Boss == null)
        return;
      this.BaseScore = 10000000L;
      this.OriginalPosition = this.Boss.OriginalPosition;
      this.SpellTime = this.Boss.SpellTime - this.Boss.Time;
      this.Background3D.Enabled3D = false;
      this.SC_Name = (string) null;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time == 1)
      {
        this.SC_Data = this.StageData.PData.SC_History.Find(new Predicate<SpellCardHistory>(this.FindSC));
        if (!this.StageData.OnReplay)
          ++this.SC_Data.History;
      }
      if (this.KClass.Key_X && this.MyPlane.Spell > 0)
        this.Bombed = true;
      if (this.MyPlane.Time <= 1)
        this.Missed = true;
      if (this.Time > 210 && this.SpellList.Count > 0)
        this.Bombed = true;
      if (this.GetSpellCardBonus() > 0L)
      {
        StageDataPackage stageData = this.StageData;
        string str1 = this.GetSpellCardBonus().ToString().PadRight(14, ' ');
        int num = this.SC_Data.Recorded;
        string str2 = num.ToString();
        num = this.SC_Data.History;
        string str3 = num.ToString();
        string str4 = (str2 + "/" + str3).PadLeft(6);
        string str5 = str1 + str4;
        stageData.SCBstring = str5;
      }
      else
        this.StageData.SCBstring = "Failed".PadRight(14, ' ') + (this.SC_Data.Recorded.ToString() + "/" + this.SC_Data.History.ToString()).PadLeft(6);
    }

    public override void GiveEndEffect()
    {
      if (!this.Bombed && !this.Missed && this.Time < this.SpellTime)
      {
        this.StageData.SoundPlay("se_cardget.wav");
        SpellCardBonus spellCardBonus = new SpellCardBonus(this.StageData, this.GetSpellCardBonus());
        if (!this.StageData.OnReplay)
          ++this.SC_Data.Recorded;
      }
      this.Background3D.Enabled3D = true;
      this.StageData.SCBstring = (string) null;
    }

    public virtual long GetSpellCardBonus()
    {
      if (this.Bombed || this.Missed)
        return 0;
      return (this.BaseScore - this.BaseScore * (long) this.Time / 2L / (long) this.SpellTime) / 10L * 10L;
    }

    public bool FindSC(SpellCardHistory SCH)
    {
      return SCH.Rank == this.Difficulty && SCH.MyPlaneFullName == this.MyPlane.FullName && SCH.Name == this.SC_Name;
    }
  }
}
