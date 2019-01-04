// Decompiled with JetBrains decompiler
// Type: THMHJ.PracticeScore
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System;

namespace THMHJ
{
  [Serializable]
  public class PracticeScore
  {
    public long[] score;

    public PracticeScore()
    {
      this.score = new long[7];
      for (int index = 0; index < 7; ++index)
        this.score[index] = 0L;
    }
  }
}
