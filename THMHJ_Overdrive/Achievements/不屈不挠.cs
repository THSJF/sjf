// Decompiled with JetBrains decompiler
// Type: THMHJ.Achievements.不屈不挠
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System.Collections;

namespace THMHJ.Achievements
{
  internal sealed class 不屈不挠 : AchievementBase
  {
    public override bool Check(Hashtable data)
    {
      if ((int) data[(object) "time"] == (int) data[(object) "limit"] - 1)
      {
        this.finished = true;
        this.get = true;
      }
      return this.get;
    }
  }
}
