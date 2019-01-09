// Decompiled with JetBrains decompiler
// Type: THMHJ.Achievements.满载而归
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System.Collections;

namespace THMHJ.Achievements
{
  internal sealed class 满载而归 : AchievementBase
  {
    public override bool Check(Hashtable data)
    {
      PlayData playData = (PlayData) data[(object) "playdata"];
      for (int index1 = 0; index1 < playData.players.Length; ++index1)
      {
        for (int index2 = 1; index2 < playData.players[index1].sc.Length; ++index2)
        {
          if (playData.players[index1].sc[index2].Count >= (int) Main.SpellcardNum[index2])
          {
            int num = 0;
            for (int index3 = 0; index3 < playData.players[index1].sc[index2].Count; ++index3)
            {
              if (playData.players[index1].sc[index2][index3].cleartime > 0)
                ++num;
            }
            if (num >= (int) Main.SpellcardNum[index2])
            {
              this.finishedlevel[index2] = true;
              this.get = true;
            }
          }
        }
      }
      int num1 = 0;
      for (int index = 0; index < this.finishedlevel.Length; ++index)
      {
        if (this.finishedlevel[index])
          ++num1;
      }
      if (num1 == this.finishedlevel.Length)
        this.finished = true;
      return this.get;
    }
  }
}
