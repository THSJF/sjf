// Decompiled with JetBrains decompiler
// Type: THMHJ.RPYInfo
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System;

namespace THMHJ
{
  [Serializable]
  public class RPYInfo
  {
    private string version;
    private string name;
    private DateTime time;
    private byte chara;
    private byte level;
    private long score;
    private byte mode;
    private byte specialmode;

    public string Version
    {
      get
      {
        return this.version;
      }
    }

    public string Name
    {
      get
      {
        return this.name;
      }
    }

    public DateTime Time
    {
      get
      {
        return this.time;
      }
    }

    public byte Chara
    {
      get
      {
        return this.chara;
      }
    }

    public byte Level
    {
      get
      {
        return this.level;
      }
    }

    public long Score
    {
      get
      {
        return this.score;
      }
    }

    public byte Mode
    {
      get
      {
        return this.mode;
      }
    }

    public byte SpecialMode
    {
      get
      {
        return this.specialmode;
      }
    }

    public void SetVersion(string v)
    {
      this.version = v;
    }

    public void SetName(string n)
    {
      this.name = n;
    }

    public void SetTime(int years, int months, int day, int hour, int minute, int second)
    {
      this.time = new DateTime(years, months, day, hour, minute, second);
    }

    public void SetTime(DateTime times)
    {
      this.time = new DateTime(times.Year, times.Month, times.Day, times.Hour, times.Minute, times.Second);
    }

    public void SetChara(byte c)
    {
      this.chara = c;
    }

    public void SetLevel(byte l)
    {
      this.level = l;
    }

    public void SetScore(long s)
    {
      this.score = s;
    }

    public void SetMode(byte t)
    {
      this.mode = t;
    }

    public void SetSpecialMode(byte t)
    {
      this.specialmode = t;
    }
  }
}
