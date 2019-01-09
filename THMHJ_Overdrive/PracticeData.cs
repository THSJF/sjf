// Decompiled with JetBrains decompiler
// Type: THMHJ.PracticeData
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System;

namespace THMHJ
{
  [Serializable]
  public class PracticeData
  {
    public bool[] clear;
    public PracticeScore[][] data;
    public int[][] clearstate;

    public PracticeData()
    {
      this.clear = new bool[4];
      this.data = new PracticeScore[4][];
      this.clearstate = new int[4][];
      for (int index1 = 0; index1 < 4; ++index1)
      {
        this.data[index1] = new PracticeScore[5];
        this.clearstate[index1] = new int[5];
        for (int index2 = 0; index2 < 5; ++index2)
        {
          this.data[index1][index2] = new PracticeScore();
          this.clearstate[index1][index2] = 0;
        }
      }
    }
  }
}
