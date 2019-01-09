// Decompiled with JetBrains decompiler
// Type: THMHJ.EventRead
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System;

namespace THMHJ
{
  [Serializable]
  public class EventRead
  {
    public float rand;
    public int special;
    public int special2;
    public string condition;
    public string result;
    public string condition2;
    public int contype;
    public int contype2;
    public string opreator;
    public string opreator2;
    public string collector;
    public int change;
    public int changetype;
    public int changevalue;
    public int changename;
    public float res;
    public int times;
    public int time;
    public bool noloop;

    public object Copy()
    {
      return this.MemberwiseClone();
    }
  }
}
