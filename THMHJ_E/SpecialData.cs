// Decompiled with JetBrains decompiler
// Type: THMHJ.SpecialData
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System;

namespace THMHJ
{
  [Serializable]
  public class SpecialData
  {
    public AchievementList[] ach;
    public SpellCardChallenges[] spe;

    public SpecialData()
    {
      this.ach = new AchievementList[3];
      for (int index = 0; index < this.ach.Length; ++index)
        this.ach[index] = new AchievementList();
      this.ach[0].achiv = new Achievement[6];
      this.ach[1].achiv = new Achievement[16];
      this.ach[2].achiv = new Achievement[8];
      for (int index1 = 0; index1 < this.ach.Length; ++index1)
      {
        for (int index2 = 0; index2 < this.ach[index1].achiv.Length; ++index2)
          this.ach[index1].achiv[index2] = new Achievement();
      }
      this.spe = new SpellCardChallenges[4];
      for (int index = 0; index < this.spe.Length; ++index)
        this.spe[index] = new SpellCardChallenges();
    }
  }
}
