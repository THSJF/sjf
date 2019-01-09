// Decompiled with JetBrains decompiler
// Type: THMHJ.Achievements.轻飘飘
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System.Collections;

namespace THMHJ.Achievements
{
  internal sealed class 轻飘飘 : AchievementBase
  {
    private short[] cardnum = new short[5];

    public override bool Check(Hashtable data)
    {
      if ((Difficulty) data[(object) "level"] >= Difficulty.NORMAL && !(bool) data[(object) "shifted"] && (Modes) data[(object) "mode"] != Modes.PRACTICE)
        ++this.cardnum[(int) data[(object) "level"] - 1];
      for (int index1 = 0; index1 < this.cardnum.Length; ++index1)
      {
        if (this.cardnum[index1] >= (short) 3)
        {
          this.cardnum[index1] = (short) 0;
          this.finishedlevel[index1] = true;
          int num = 0;
          for (int index2 = 0; index2 < this.finishedlevel.Length; ++index2)
          {
            if (this.finishedlevel[index2])
              ++num;
          }
          if (num == this.finishedlevel.Length)
            this.finished = true;
          this.get = true;
        }
      }
      return this.get;
    }
  }
}
