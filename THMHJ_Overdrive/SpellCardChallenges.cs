// Decompiled with JetBrains decompiler
// Type: THMHJ.SpellCardChallenges
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System;

namespace THMHJ
{
  [Serializable]
  public class SpellCardChallenges
  {
    public SpellCard[] sc;

    public SpellCardChallenges()
    {
      this.sc = new SpellCard[32];
      for (int index = 0; index < this.sc.Length; ++index)
        this.sc[index] = new SpellCard();
    }
  }
}
