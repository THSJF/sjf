// Decompiled with JetBrains decompiler
// Type: THMHJ.PlayerData
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System;
using System.Collections.Generic;

namespace THMHJ
{
  [Serializable]
  public class PlayerData
  {
    public PlayRanks[] ranks;
    public List<SpellCardData>[] sc;
    public int playtime;
    public int cleartime;
    public int totaltime;

    public PlayerData()
    {
      this.ranks = new PlayRanks[5];
      this.sc = new List<SpellCardData>[5];
      for (int index = 0; index < 5; ++index)
      {
        this.sc[index] = new List<SpellCardData>();
        this.ranks[index] = new PlayRanks();
      }
    }
  }
}
