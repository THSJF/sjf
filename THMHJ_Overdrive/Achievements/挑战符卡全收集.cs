// Decompiled with JetBrains decompiler
// Type: THMHJ.Achievements.挑战符卡全收集
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System.Collections;

namespace THMHJ.Achievements
{
  internal sealed class 挑战符卡全收集 : AchievementBase
  {
    public override bool Check(Hashtable data)
    {
      SpecialData specialData = (SpecialData) data[(object) "specialdata"];
      for (int index1 = 0; index1 < specialData.spe.Length; ++index1)
      {
        int num = 0;
        for (int index2 = 0; index2 < specialData.spe[index1].sc.Length; ++index2)
        {
          if (specialData.spe[index1].sc[index2].cleartime > (short) 0)
            ++num;
        }
        if (num == 32)
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
