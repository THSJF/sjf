// Decompiled with JetBrains decompiler
// Type: THMHJ.Achievement
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System;

namespace THMHJ
{
  [Serializable]
  public class Achievement
  {
    public bool get;
    public bool[] level;

    public Achievement()
    {
      this.level = new bool[5];
      for (int index = 0; index < this.level.Length; ++index)
        this.level[index] = false;
    }
  }
}
