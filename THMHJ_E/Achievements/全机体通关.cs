// Decompiled with JetBrains decompiler
// Type: THMHJ.Achievements.全机体通关
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System.Collections;

namespace THMHJ.Achievements
{
  internal sealed class 全机体通关 : AchievementBase
  {
    public override bool Check(Hashtable data)
    {
      bool flag = true;
      for (int index = 0; index < 4; ++index)
      {
        if (!((PracticeData) data[(object) "practice"]).clear[index])
        {
          flag = false;
          break;
        }
      }
      if (flag)
      {
        this.finished = true;
        this.get = true;
      }
      return flag;
    }
  }
}
