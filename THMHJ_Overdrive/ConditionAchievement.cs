// Decompiled with JetBrains decompiler
// Type: THMHJ.ConditionAchievement
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System.Collections;

namespace THMHJ
{
  internal class ConditionAchievement : AchievementBase
  {
    public override bool Check(Hashtable data)
    {
      if ((bool) data[(object) "ok"])
      {
        this.finished = true;
        this.get = true;
      }
      return (bool) data[(object) "ok"];
    }
  }
}
