// Decompiled with JetBrains decompiler
// Type: THMHJ.AchievementBase
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System.Collections;

namespace THMHJ
{
  public abstract class AchievementBase
  {
    public bool[] finishedlevel;
    public bool finished;
    public bool get;

    public AchievementBase()
    {
      this.finishedlevel = new bool[5];
    }

    public abstract bool Check(Hashtable data);
  }
}
