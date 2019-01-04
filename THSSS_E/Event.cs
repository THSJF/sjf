// Decompiled with JetBrains decompiler
// Type: Shooting.Event
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;

namespace Shooting
{
  [Serializable]
  public class Event
  {
    public string EventString;
    public float rand;
    public int special;
    public int special2;
    public string condition;
    public string condition2;
    public string result;
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

    public void String2EmitterEvent()
    {
      string eventString = this.EventString;
      string str1 = eventString.Split('：')[0];
      string str2 = "";
      string str3 = "";
      string str4 = "";
      string str5 = "";
      string str6 = "";
      string str7 = eventString.Split('：')[1];
      float num1 = 0.0f;
      int num2 = 0;
      if (eventString.Contains("且"))
      {
        str6 = "且";
        str2 = str1.Split("且".ToCharArray())[1];
        str1 = str1.Split("且".ToCharArray())[0];
      }
      else if (eventString.Contains("或"))
      {
        str6 = "或";
        str2 = str1.Split("或".ToCharArray())[1];
        str1 = str1.Split("或".ToCharArray())[0];
      }
      if (str1.Contains(">"))
      {
        str3 = str1.Split('>')[0];
        str4 = ">";
        str1 = str1.Split('>')[1];
      }
      else if (str1.Contains("="))
      {
        str3 = str1.Split('=')[0];
        str4 = "=";
        str1 = str1.Split('=')[1];
      }
      else if (str1.Contains("<"))
      {
        str3 = str1.Split('<')[0];
        str4 = "<";
        str1 = str1.Split('<')[1];
      }
      if (str2.Contains(">"))
      {
        string str8 = str2.Split('>')[0];
        str5 = ">";
        str2 = str2.Split('>')[1];
      }
      else if (str2.Contains("="))
      {
        string str8 = str2.Split('=')[0];
        str5 = "=";
        str2 = str2.Split('=')[1];
      }
      else if (str2.Contains("<"))
      {
        string str8 = str2.Split('<')[0];
        str5 = "<";
        str2 = str2.Split('<')[1];
      }
      if (eventString.Contains("变化到"))
      {
        int num3 = 0;
        string[] strArray = str7.Split("变".ToCharArray())[1].Split("，".ToCharArray());
        int result = (int) Hash.results[(object) str7.Split("变".ToCharArray())[0]];
        string str8 = str7.Split("变".ToCharArray())[0];
        if (strArray[0].Replace("化到", "").Contains("+"))
        {
          if (strArray[0].Replace("化到", "").Split('+')[0] == "自身")
            num2 = 3;
          else if (strArray[0].Replace("化到", "").Split('+')[0] == "自机")
            num2 = 4;
          else
            num1 = float.Parse(strArray[0].Replace("化到", "").Split('+')[0]);
        }
        else if (strArray[0].Replace("化到", "") == "自身")
          num2 = 3;
        else if (strArray[0].Replace("化到", "") == "自机")
          num2 = 4;
        else
          num1 = float.Parse(strArray[0].Replace("化到", ""));
        string str9 = strArray[1];
        int num4 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
        this.condition = str1;
        this.result = str7;
        this.condition2 = str2;
        this.contype = (int) Hash.conditions[(object) str3];
        this.contype2 = (int) Hash.conditions[(object) str3];
        this.opreator = str4;
        this.opreator2 = str5;
        this.collector = str6;
        this.change = num3;
        this.changetype = (int) Hash.type[(object) str9];
        this.changevalue = result;
        this.changename = (int) Hash.results[(object) str8];
        this.res = num1;
        this.special = num2;
        if (strArray[0].Replace("化到", "").Contains("+"))
          this.rand = float.Parse(strArray[0].Replace("化到", "").Split('+')[1]);
        this.times = num4;
        if (!strArray[2].Contains("("))
          return;
        this.time = int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
      }
      else if (eventString.Contains("增加"))
      {
        int num3 = 1;
        string[] strArray = str7.Split("增".ToCharArray())[1].Split("，".ToCharArray());
        strArray[0] = strArray[0].Replace("加", "");
        int result = (int) Hash.results[(object) str7.Split("增".ToCharArray())[0]];
        string str8 = str7.Split("增".ToCharArray())[0];
        if (strArray[0].Contains("+"))
        {
          if (strArray[0].Split('+')[0] == "自身")
            num2 = 3;
          else if (strArray[0].Split('+')[0] == "自机")
            num2 = 4;
          else
            num1 = float.Parse(strArray[0].Split('+')[0]);
        }
        else if (strArray[0] == "自身")
          num2 = 3;
        else if (strArray[0] == "自机")
          num2 = 4;
        else
          num1 = float.Parse(strArray[0]);
        string str9 = strArray[1];
        int num4 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
        this.condition = str1;
        this.result = str7;
        this.condition2 = str2;
        this.contype = (int) Hash.conditions[(object) str3];
        this.contype2 = (int) Hash.conditions[(object) str3];
        this.opreator = str4;
        this.opreator2 = str5;
        this.collector = str6;
        this.change = num3;
        this.changetype = (int) Hash.type[(object) str9];
        this.changevalue = result;
        this.changename = (int) Hash.results[(object) str8];
        this.res = num1;
        this.special = num2;
        if (strArray[0].Contains("+"))
          this.rand = float.Parse(strArray[0].Split('+')[1]);
        this.times = num4;
        if (!strArray[2].Contains("("))
          return;
        this.time = int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
      }
      else if (eventString.Contains("减少"))
      {
        int num3 = 2;
        string[] strArray = str7.Split("减少".ToCharArray())[2].Split("，".ToCharArray());
        int result = (int) Hash.results[(object) str7.Split("减少".ToCharArray())[0]];
        string str8 = str7.Split("减少".ToCharArray())[0];
        if (strArray[0].Contains("+"))
        {
          if (strArray[0].Split('+')[0] == "自身")
            num2 = 3;
          else if (strArray[0].Split('+')[0] == "自机")
            num2 = 4;
          else
            num1 = float.Parse(strArray[0].Split('+')[0]);
        }
        else if (strArray[0] == "自身")
          num2 = 3;
        else if (strArray[0] == "自机")
          num2 = 4;
        else
          num1 = float.Parse(strArray[0]);
        string str9 = strArray[1];
        int num4 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
        this.condition = str1;
        this.result = str7;
        this.condition2 = str2;
        this.contype = (int) Hash.conditions[(object) str3];
        this.contype2 = (int) Hash.conditions[(object) str3];
        this.opreator = str4;
        this.opreator2 = str5;
        this.collector = str6;
        this.change = num3;
        this.changetype = (int) Hash.type[(object) str9];
        this.changevalue = result;
        this.changename = (int) Hash.results[(object) str8];
        this.res = num1;
        this.special = num2;
        if (strArray[0].Contains("+"))
          this.rand = float.Parse(strArray[0].Split('+')[1]);
        this.times = num4;
        if (!strArray[2].Contains("("))
          return;
        this.time = int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
      }
      else if (eventString.Contains("恢复"))
      {
        this.special = 1;
        this.opreator = str4;
        this.opreator2 = str5;
        this.condition = str1;
        this.condition2 = str2;
        this.contype = (int) Hash.conditions[(object) str3];
        this.contype2 = (int) Hash.conditions[(object) str3];
        this.collector = str6;
      }
      else if (eventString.Contains("发射"))
      {
        this.special = 2;
        this.opreator = str4;
        this.opreator2 = str5;
        this.condition = str1;
        this.condition2 = str2;
        this.contype = (int) Hash.conditions[(object) str3];
        this.contype2 = (int) Hash.conditions[(object) str3];
        this.collector = str6;
      }
    }

    public void String2BulletEvent()
    {
      string eventString = this.EventString;
      string str1 = eventString.Split('：')[0];
      string str2 = "";
      string str3 = "";
      string str4 = "";
      string str5 = "";
      string str6 = "";
      string str7 = eventString.Split('：')[1];
      float num1 = 0.0f;
      int num2 = 0;
      if (eventString.Contains("且"))
      {
        str6 = "且";
        str2 = str1.Split("且".ToCharArray())[1];
        str1 = str1.Split("且".ToCharArray())[0];
      }
      else if (eventString.Contains("或"))
      {
        str6 = "或";
        str2 = str1.Split("或".ToCharArray())[1];
        str1 = str1.Split("或".ToCharArray())[0];
      }
      if (str1.Contains(">"))
      {
        str3 = str1.Split('>')[0];
        str4 = ">";
        str1 = str1.Split('>')[1];
      }
      else if (str1.Contains("="))
      {
        str3 = str1.Split('=')[0];
        str4 = "=";
        str1 = str1.Split('=')[1];
      }
      else if (str1.Contains("<"))
      {
        str3 = str1.Split('<')[0];
        str4 = "<";
        str1 = str1.Split('<')[1];
      }
      if (str2.Contains(">"))
      {
        string str8 = str2.Split('>')[0];
        str5 = ">";
        str2 = str2.Split('>')[1];
      }
      else if (str2.Contains("="))
      {
        string str8 = str2.Split('=')[0];
        str5 = "=";
        str2 = str2.Split('=')[1];
      }
      else if (str2.Contains("<"))
      {
        string str8 = str2.Split('<')[0];
        str5 = "<";
        str2 = str2.Split('<')[1];
      }
      if (eventString.Contains("变化到"))
      {
        int num3 = 0;
        string[] strArray = str7.Split("变".ToCharArray())[1].Split("，".ToCharArray());
        int num4 = (int) Hash.results2[(object) str7.Split("变".ToCharArray())[0]];
        string str8 = str7.Split("变".ToCharArray())[0];
        if (strArray[0].Replace("化到", "").Contains("+"))
        {
          if (strArray[0].Replace("化到", "").Split('+')[0] == "自身")
            num2 = 3;
          else if (strArray[0].Replace("化到", "").Split('+')[0] == "自机")
            num2 = 4;
          else
            num1 = float.Parse(strArray[0].Replace("化到", "").Split('+')[0]);
        }
        else if (strArray[0].Replace("化到", "") == "自身")
          num2 = 3;
        else if (strArray[0].Replace("化到", "") == "自机")
          num2 = 4;
        else
          num1 = float.Parse(strArray[0].Replace("化到", ""));
        string str9 = strArray[1];
        int num5 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
        this.condition = str1;
        this.result = str7;
        this.condition2 = str2;
        this.contype = (int) Hash.conditions2[(object) str3];
        this.contype2 = (int) Hash.conditions2[(object) str3];
        this.opreator = str4;
        this.opreator2 = str5;
        this.collector = str6;
        this.change = num3;
        this.changetype = (int) Hash.type[(object) str9];
        this.changevalue = num4;
        this.changename = (int) Hash.results2[(object) str8];
        this.res = num1;
        this.special = num2;
        if (strArray[0].Replace("化到", "").Contains("+"))
          this.rand = float.Parse(strArray[0].Replace("化到", "").Split('+')[1]);
        this.times = num5;
        if (!strArray[2].Contains("("))
          return;
        this.time = int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
      }
      else if (eventString.Contains("增加"))
      {
        int num3 = 1;
        string[] strArray = str7.Split("增".ToCharArray())[1].Split("，".ToCharArray());
        strArray[0] = strArray[0].Replace("加", "");
        int num4 = (int) Hash.results2[(object) str7.Split("增".ToCharArray())[0]];
        string str8 = str7.Split("增".ToCharArray())[0];
        if (strArray[0].Contains("+"))
        {
          if (strArray[0].Split('+')[0] == "自身")
            num2 = 3;
          else if (strArray[0].Split('+')[0] == "自机")
            num2 = 4;
          else
            num1 = float.Parse(strArray[0].Split('+')[0]);
        }
        else if (strArray[0] == "自身")
          num2 = 3;
        else if (strArray[0] == "自机")
          num2 = 4;
        else
          num1 = float.Parse(strArray[0]);
        string str9 = strArray[1];
        int num5 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
        this.condition = str1;
        this.result = str7;
        this.condition2 = str2;
        this.contype = (int) Hash.conditions2[(object) str3];
        this.contype2 = (int) Hash.conditions2[(object) str3];
        this.opreator = str4;
        this.opreator2 = str5;
        this.collector = str6;
        this.change = num3;
        this.changetype = (int) Hash.type[(object) str9];
        this.changevalue = num4;
        this.changename = (int) Hash.results2[(object) str8];
        this.res = num1;
        this.special = num2;
        if (strArray[0].Contains("+"))
          this.rand = float.Parse(strArray[0].Split('+')[1]);
        this.times = num5;
        if (!strArray[2].Contains("("))
          return;
        this.time = int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
      }
      else if (eventString.Contains("减少"))
      {
        int num3 = 2;
        string[] strArray = str7.Split("减少".ToCharArray())[2].Split("，".ToCharArray());
        int num4 = (int) Hash.results2[(object) str7.Split("减少".ToCharArray())[0]];
        string str8 = str7.Split("减少".ToCharArray())[0];
        if (strArray[0].Contains("+"))
        {
          if (strArray[0].Split('+')[0] == "自身")
            num2 = 3;
          else if (strArray[0].Split('+')[0] == "自机")
            num2 = 4;
          else
            num1 = float.Parse(strArray[0].Split('+')[0]);
        }
        else if (strArray[0] == "自身")
          num2 = 3;
        else if (strArray[0] == "自机")
          num2 = 4;
        else
          num1 = float.Parse(strArray[0]);
        string str9 = strArray[1];
        int num5 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
        this.condition = str1;
        this.result = str7;
        this.condition2 = str2;
        this.contype = (int) Hash.conditions2[(object) str3];
        this.contype2 = (int) Hash.conditions2[(object) str3];
        this.opreator = str4;
        this.opreator2 = str5;
        this.collector = str6;
        this.change = num3;
        this.changetype = (int) Hash.type[(object) str9];
        this.changevalue = num4;
        this.changename = (int) Hash.results2[(object) str8];
        this.res = num1;
        this.special = num2;
        if (strArray[0].Contains("+"))
          this.rand = float.Parse(strArray[0].Split('+')[1]);
        this.times = num5;
        if (!strArray[2].Contains("("))
          return;
        this.time = int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
      }
      else if (eventString.Contains("恢复"))
      {
        this.special = 1;
        this.opreator = str4;
        this.opreator2 = str5;
        this.condition = str1;
        this.condition2 = str2;
        this.contype = (int) Hash.conditions2[(object) str3];
        this.contype2 = (int) Hash.conditions2[(object) str3];
        this.collector = str6;
      }
      else if (eventString.Contains("发射"))
      {
        this.special = 2;
        this.opreator = str4;
        this.opreator2 = str5;
        this.condition = str1;
        this.condition2 = str2;
        this.contype = (int) Hash.conditions2[(object) str3];
        this.contype2 = (int) Hash.conditions2[(object) str3];
        this.collector = str6;
      }
    }

    public object Clone()
    {
      return this.MemberwiseClone();
    }
  }
}
