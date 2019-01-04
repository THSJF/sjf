// Decompiled with JetBrains decompiler
// Type: THMHJ.Achievements.一个也不落
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System.Collections;

namespace THMHJ.Achievements
{
  internal sealed class 一个也不落 : AchievementBase
  {
    private bool last;
    private int time;

    public override bool Check(Hashtable data)
    {
      if (data.ContainsKey((object) "reset"))
        this.time = 0;
      if (data.ContainsKey((object) "y"))
      {
        bool flag = (double) (float) data[(object) "y"] < (double) (int) data[(object) "itemline"];
        if (flag != this.last)
        {
          if (flag)
            ++this.time;
          this.last = flag;
        }
      }
      if (this.time >= 50)
      {
        this.finished = true;
        this.get = true;
      }
      return this.get;
    }
  }
}
