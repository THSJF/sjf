// Decompiled with JetBrains decompiler
// Type: THMHJ.Achievements.弹幕痴狂
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System.Collections;

namespace THMHJ.Achievements
{
  internal sealed class 弹幕痴狂 : AchievementBase
  {
    public override bool Check(Hashtable data)
    {
      foreach (PlayerData playerData in (PlayerData[]) data[(object) "playerdata"])
      {
        if (playerData.totaltime / 3600 >= 30)
        {
          this.finished = true;
          this.get = true;
          return true;
        }
      }
      return false;
    }
  }
}
