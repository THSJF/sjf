// Decompiled with JetBrains decompiler
// Type: THMHJ.Achievements.条件反射
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System.Collections;

namespace THMHJ.Achievements
{
  internal sealed class 条件反射 : AchievementBase
  {
    private int miss;
    private int just;

    public override bool Check(Hashtable data)
    {
      if (data.ContainsKey((object) "missorjust"))
      {
        if ((bool) data[(object) "missorjust"])
          ++this.miss;
        else
          ++this.just;
      }
      if (data.ContainsKey((object) "level") && this.miss > 0 && this.miss == this.just)
      {
        this.miss = this.just = 0;
        this.finishedlevel[(int) data[(object) "level"] - 1] = true;
        int num = 0;
        for (int index = 0; index < this.finishedlevel.Length; ++index)
        {
          if (this.finishedlevel[index])
            ++num;
        }
        if (num == this.finishedlevel.Length)
          this.finished = true;
        this.get = true;
      }
      return this.get;
    }
  }
}
