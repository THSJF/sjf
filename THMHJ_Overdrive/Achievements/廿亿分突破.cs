// Decompiled with JetBrains decompiler
// Type: THMHJ.Achievements.廿亿分突破
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System.Collections;

namespace THMHJ.Achievements
{
  internal sealed class 廿亿分突破 : AchievementBase
  {
    public override bool Check(Hashtable data)
    {
      if ((Difficulty) data[(object) "level"] != Difficulty.HARD && (Difficulty) data[(object) "level"] != Difficulty.LUNATIC || (long) data[(object) "score"] < 2000000000L)
        return false;
      this.finished = true;
      this.get = true;
      return true;
    }
  }
}
