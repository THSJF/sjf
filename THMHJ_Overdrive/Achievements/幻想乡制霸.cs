// Decompiled with JetBrains decompiler
// Type: THMHJ.Achievements.幻想乡制霸
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System.Collections;

namespace THMHJ.Achievements
{
  internal sealed class 幻想乡制霸 : AchievementBase
  {
    public override bool Check(Hashtable data)
    {
      bool flag = true;
      for (int index1 = 0; index1 < 4; ++index1)
      {
        for (int index2 = 0; index2 < 4; ++index2)
        {
          if (((PracticeData) data[(object) "practice"]).clearstate[index1][index2] < 6)
          {
            flag = false;
            break;
          }
        }
        if (!flag)
          break;
      }
      if (flag)
      {
        this.finished = true;
        this.get = true;
      }
      return this.get;
    }
  }
}
