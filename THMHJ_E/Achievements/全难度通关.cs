// Decompiled with JetBrains decompiler
// Type: THMHJ.Achievements.全难度通关
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System.Collections;

namespace THMHJ.Achievements
{
  internal sealed class 全难度通关 : AchievementBase
  {
    public override bool Check(Hashtable data)
    {
      for (int index1 = 0; index1 < 4; ++index1)
      {
        bool flag = true;
        for (int index2 = 0; index2 < 5; ++index2)
        {
          if (((PlayData) data[(object) "playdata"]).players[index1].sc[index2].Count < (int) Main.SpellcardNum[index2])
          {
            flag = false;
            break;
          }
        }
        if (flag)
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
