// Decompiled with JetBrains decompiler
// Type: THMHJ.Achievements.擦弹有快感
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System.Collections;

namespace THMHJ.Achievements
{
  internal sealed class 擦弹有快感 : AchievementBase
  {
    public override bool Check(Hashtable data)
    {
      if ((int) data[(object) "graze"] >= 20000)
      {
        this.finished = true;
        this.get = true;
      }
      return this.get;
    }
  }
}
