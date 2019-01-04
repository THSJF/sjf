// Decompiled with JetBrains decompiler
// Type: Shooting.MP3_Player
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Runtime.InteropServices;

namespace Shooting
{
  public class MP3_Player
  {
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    private string Name = "";
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    private string durLength = "";
    [MarshalAs(UnmanagedType.LPTStr)]
    private string TemStr = "";
    public MP3_Player.structMCI mc = new MP3_Player.structMCI();
    private int ilong;
    private int volumn;

    public MP3_Player()
    {
      this.Volumn = 100;
    }

    public string FileName
    {
      get
      {
        return this.mc.iName;
      }
      set
      {
        try
        {
          this.TemStr = "";
          this.TemStr = this.TemStr.PadLeft((int) sbyte.MaxValue, Convert.ToChar(" "));
          this.Name = this.Name.PadLeft(260, Convert.ToChar(" "));
          this.mc.iName = value;
          this.ilong = APIClass.GetShortPathName(this.mc.iName, this.Name, this.Name.Length);
          this.Name = this.GetCurrPath(this.Name);
          this.Name = "open " + (object) Convert.ToChar(34) + this.Name + (object) Convert.ToChar(34) + " alias media";
          this.ilong = APIClass.mciSendString("close all", this.TemStr, this.TemStr.Length, 0);
          this.ilong = APIClass.mciSendString(this.Name, this.TemStr, this.TemStr.Length, 0);
          this.ilong = APIClass.mciSendString("set media time format milliseconds", this.TemStr, this.TemStr.Length, 0);
          this.mc.state = MP3_Player.State.mStop;
        }
        catch
        {
        }
      }
    }

    public void Play()
    {
      this.TemStr = "";
      this.TemStr = this.TemStr.PadLeft((int) sbyte.MaxValue, Convert.ToChar(" "));
      APIClass.mciSendString("play media", this.TemStr, this.TemStr.Length, 0);
      this.mc.state = MP3_Player.State.mPlaying;
    }

    public void PlayRepeat()
    {
      this.TemStr = "";
      this.TemStr = this.TemStr.PadLeft((int) sbyte.MaxValue, Convert.ToChar(" "));
      APIClass.mciSendString("play media repeat", this.TemStr, this.TemStr.Length, 0);
      this.mc.state = MP3_Player.State.mPlaying;
    }

    public void Stop()
    {
      this.TemStr = "";
      this.TemStr = this.TemStr.PadLeft(128, Convert.ToChar(" "));
      this.ilong = APIClass.mciSendString("close media", this.TemStr, 128, 0);
      this.ilong = APIClass.mciSendString("close all", this.TemStr, 128, 0);
      this.mc.state = MP3_Player.State.mStop;
    }

    public void Puase()
    {
      this.TemStr = "";
      this.TemStr = this.TemStr.PadLeft(128, Convert.ToChar(" "));
      this.ilong = APIClass.mciSendString("pause media", this.TemStr, this.TemStr.Length, 0);
      this.mc.state = MP3_Player.State.mPuase;
    }

    public void Resume()
    {
      if (this.mc.state != MP3_Player.State.mPuase)
        return;
      this.TemStr = "";
      this.TemStr = this.TemStr.PadLeft((int) sbyte.MaxValue, Convert.ToChar(" "));
      this.ilong = APIClass.mciSendString("resume media", this.TemStr, this.TemStr.Length, 0);
      this.mc.state = MP3_Player.State.mPlaying;
    }

    public void SetStartEnd(int t1, int t2)
    {
      this.TemStr = "";
      this.TemStr = this.TemStr.PadLeft(128, Convert.ToChar(" "));
      APIClass.mciSendString("play media from " + t1.ToString() + " to " + t2.ToString() + " repeat", this.TemStr, this.TemStr.Length, 0);
    }

    public void SetStartEnd(float t1, float t2)
    {
      this.SetStartEnd((int) t1 * 1000, (int) t2 * 1000);
    }

    private string GetCurrPath(string name)
    {
      if (name.Length < 1)
        return "";
      name = name.Trim();
      name = name.Substring(0, name.Length - 1);
      return name;
    }

    public int Duration
    {
      get
      {
        this.durLength = "";
        this.durLength = this.durLength.PadLeft(128, Convert.ToChar(" "));
        APIClass.mciSendString("status media length", this.durLength, this.durLength.Length, 0);
        this.durLength = this.durLength.Trim();
        if (this.durLength == "")
          return 0;
        return (int) (Convert.ToDouble(this.durLength) / 1000.0);
      }
    }

    public int CurrentPosition
    {
      get
      {
        this.durLength = "";
        this.durLength = this.durLength.PadLeft(128, Convert.ToChar(" "));
        APIClass.mciSendString("status media position", this.durLength, this.durLength.Length, 0);
        this.mc.iPos = (int) Convert.ToDouble(this.durLength.Replace("\0", ""));
        return this.mc.iPos;
      }
    }

    public int Volumn
    {
      get
      {
        return this.volumn;
      }
      set
      {
        this.volumn = value >= 0 ? (value <= 100 ? value : 100) : 0;
        this.TemStr = "";
        this.TemStr = this.TemStr.PadLeft((int) sbyte.MaxValue, Convert.ToChar(" "));
        APIClass.mciSendString("setaudio media volume to " + (value * 10).ToString(), this.TemStr, this.TemStr.Length, 0);
      }
    }

    public enum State
    {
      mPlaying = 1,
      mPuase = 2,
      mStop = 3,
    }

    public struct structMCI
    {
      public bool bMut;
      public int iDur;
      public int iPos;
      public int iVol;
      public int iBal;
      public string iName;
      public MP3_Player.State state;
    }
  }
}
