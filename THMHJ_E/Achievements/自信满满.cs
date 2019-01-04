// Decompiled with JetBrains decompiler
// Type: THMHJ.Achievements.自信满满
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System.Collections;

namespace THMHJ.Achievements
{
  internal sealed class 自信满满 : AchievementBase
  {
    private bool bombed;

    public override bool Check(Hashtable data)
    {
      if (data.ContainsKey((object) "reset"))
        this.bombed = false;
      if (data.ContainsKey((object) "bomb") && (bool) data[(object) "bomb"])
        this.bombed = true;
      if (data.ContainsKey((object) "level") && !(bool) data[(object) "continued"] && ((int) data[(object) "stage"] > 1 && (Difficulty) data[(object) "level"] == Difficulty.LUNATIC) && ((int) data[(object) "type"] == 1 && !this.bombed))
      {
        this.finished = true;
        this.get = true;
      }
      return this.get;
    }
  }
}
