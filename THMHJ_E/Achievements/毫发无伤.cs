// Decompiled with JetBrains decompiler
// Type: THMHJ.Achievements.毫发无伤
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System.Collections;

namespace THMHJ.Achievements
{
  internal sealed class 毫发无伤 : AchievementBase
  {
    public override bool Check(Hashtable data)
    {
      if ((bool) data[(object) "dead"])
        return false;
      this.finishedlevel[(int) data[(object) "level"]] = true;
      int num = 0;
      for (int index = 0; index < this.finishedlevel.Length; ++index)
      {
        if (this.finishedlevel[index])
          ++num;
      }
      if (num == this.finishedlevel.Length)
        this.finished = true;
      this.get = true;
      return true;
    }
  }
}
