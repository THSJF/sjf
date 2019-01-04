// Decompiled with JetBrains decompiler
// Type: THMHJ.Time
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace THMHJ
{
  public class Time
  {
    private static float stop = 1f;
    public List<GlobalEvent> GE = new List<GlobalEvent>();
    public List<int> GEcount = new List<int>();
    public int total;
    public int now;
    public int times;
    public Vector2 quake;
    private LayerManager layerm;
    private CSManager csm;
    private CrazyStorm cs;

    public static float Stop
    {
      get
      {
        return Time.stop;
      }
    }

    public Time(CSManager csm_c, CrazyStorm cs_c, LayerManager layerm_c)
    {
      this.cs = cs_c;
      this.csm = csm_c;
      this.layerm = layerm_c;
      this.total = 200;
      this.now = 1;
      this.quake = new Vector2(0.0f, 0.0f);
      Time.stop = 1f;
      this.GE.Clear();
      this.GEcount.Clear();
    }

    public static void Init()
    {
      Time.stop = 1f;
    }

    public static void Slowdown(float scale)
    {
      Time.stop = scale;
    }

    private double Rand(bool Ban, bool bomb)
    {
      if (!Ban)
        return Main.Rand(bomb);
      return Main.rand.NextDouble();
    }

    public void Init(Vector2 Player)
    {
      foreach (Layer layer in this.layerm.LayerArray)
      {
        foreach (Batch batch in layer.BatchArray)
        {
          batch.copys = batch.Copy() as Batch;
          foreach (Event parentevent in batch.copys.Parentevents)
            parentevent.loop = 0;
          float num1 = MathHelper.Lerp(-batch.copys.rand.speed, batch.copys.rand.speed, (float) this.Rand(this.cs.effect && !this.cs.bomb, this.cs.bomb));
          int num2 = (int) MathHelper.Lerp(-batch.copys.rand.speedd, batch.copys.rand.speedd, (float) this.Rand(this.cs.effect && !this.cs.bomb, this.cs.bomb));
          float num3 = MathHelper.Lerp(-batch.copys.rand.aspeed, batch.copys.rand.aspeed, (float) this.Rand(this.cs.effect && !this.cs.bomb, this.cs.bomb));
          int num4 = (int) MathHelper.Lerp(-batch.copys.rand.aspeedd, batch.copys.rand.aspeedd, (float) this.Rand(this.cs.effect && !this.cs.bomb, this.cs.bomb));
          if ((double) batch.fx == -99998.0)
            batch.copys.fx = batch.x - 4f;
          if ((double) batch.fx == -99999.0)
            batch.copys.fx = Player.X;
          if ((double) batch.fy == -99998.0)
            batch.copys.fy = batch.y + 16f;
          if ((double) batch.fy == -99999.0)
            batch.copys.fy = Player.Y;
          if ((double) batch.speedd == -99999.0)
            batch.copys.speedd = MathHelper.ToDegrees(Main.Twopointangle(Player.X, Player.Y, batch.copys.fx, batch.copys.fy));
          if ((double) batch.aspeedd == -99999.0)
            batch.copys.aspeedd = MathHelper.ToDegrees(Main.Twopointangle(Player.X, Player.Y, batch.copys.fx, batch.copys.fy));
          batch.copys.aspeed += num3;
          batch.copys.aspeedd += (float) num4;
          batch.copys.speed += num1;
          batch.copys.speedd += (float) num2;
          batch.copys.aspeedx = batch.copys.aspeed * (float) Math.Cos((double) MathHelper.ToRadians(batch.copys.aspeedd));
          batch.copys.aspeedy = batch.copys.aspeed * (float) Math.Sin((double) MathHelper.ToRadians(batch.copys.aspeedd));
          batch.copys.speedx = batch.copys.speed * (float) Math.Cos((double) MathHelper.ToRadians(batch.copys.speedd));
          batch.copys.speedy = batch.copys.speed * (float) Math.Sin((double) MathHelper.ToRadians(batch.copys.speedd));
          batch.copys.bfdirection = batch.fdirection;
          batch.copys.bsonaspeedd = batch.sonaspeedd;
          if ((double) batch.fdirection == -99998.0)
            batch.copys.fdirection = MathHelper.ToDegrees(Main.Twopointangle(batch.x - 4f, batch.y + 16f, batch.copys.fx, batch.copys.fy));
          else if ((double) batch.fdirection == -99999.0)
            batch.copys.fdirection = MathHelper.ToDegrees(Main.Twopointangle(Player.X, Player.Y, batch.copys.fx, batch.copys.fy));
          else if ((double) batch.fdirection == -100000.0)
            batch.copys.fdirection = MathHelper.ToDegrees(Main.Twopointangle(batch.fdirections.X, batch.fdirections.Y, batch.copys.fx, batch.copys.fy));
          if ((double) batch.sonaspeedd == -99998.0)
            batch.copys.sonaspeedd = MathHelper.ToDegrees(Main.Twopointangle(batch.x - 4f, batch.y + 16f, batch.copys.fx, batch.copys.fy));
          else if ((double) batch.sonaspeedd == -99999.0)
            batch.copys.sonaspeedd = MathHelper.ToDegrees(Main.Twopointangle(Player.X, Player.Y, batch.copys.fx, batch.copys.fy));
          else if ((double) batch.sonaspeedd == -100000.0)
            batch.copys.sonaspeedd = MathHelper.ToDegrees(Main.Twopointangle(batch.sonaspeedds.X, batch.sonaspeedds.Y, batch.copys.fx, batch.copys.fy));
          if ((double) batch.head == -100000.0)
            batch.copys.head = MathHelper.ToDegrees(Main.Twopointangle(batch.heads.X, batch.heads.Y, batch.copys.fx, batch.copys.fx));
          foreach (Event parentevent in batch.Parentevents)
          {
            foreach (string str1 in parentevent.events)
            {
              string str2 = str1.Split('：')[0];
              string str3 = "";
              string str4 = "";
              string str5 = "";
              string str6 = "";
              string str7 = "";
              string str8 = str1.Split('：')[1];
              float num5 = 0.0f;
              int num6 = 0;
              if (str1.Contains("且"))
              {
                str7 = "且";
                str3 = str2.Split("且".ToCharArray())[1];
                str2 = str2.Split("且".ToCharArray())[0];
              }
              else if (str1.Contains("或"))
              {
                str7 = "或";
                str3 = str2.Split("或".ToCharArray())[1];
                str2 = str2.Split("或".ToCharArray())[0];
              }
              if (str2.Contains(">"))
              {
                str4 = str2.Split('>')[0];
                str5 = ">";
                str2 = str2.Split('>')[1];
              }
              if (str2.Contains("="))
              {
                str4 = str2.Split('=')[0];
                str5 = "=";
                str2 = str2.Split('=')[1];
              }
              if (str2.Contains("<"))
              {
                str4 = str2.Split('<')[0];
                str5 = "<";
                str2 = str2.Split('<')[1];
              }
              if (str3.Contains(">"))
              {
                string str9 = str3.Split('>')[0];
                str6 = ">";
                str3 = str3.Split('>')[1];
              }
              if (str3.Contains("="))
              {
                string str9 = str3.Split('=')[0];
                str6 = "=";
                str3 = str3.Split('=')[1];
              }
              if (str3.Contains("<"))
              {
                string str9 = str3.Split('<')[0];
                str6 = "<";
                str3 = str3.Split('<')[1];
              }
              if (str1.Contains("变化到"))
              {
                int num7 = 0;
                string[] strArray = str8.Split("变".ToCharArray())[1].Split("，".ToCharArray());
                int result = (int) this.csm.results[(object) str8.Split("变".ToCharArray())[0]];
                string str9 = str8.Split("变".ToCharArray())[0];
                if (strArray[0].Replace("化到", "").Contains<char>('+'))
                {
                  if (strArray[0].Replace("化到", "").Split('+')[0] == "自身")
                    num6 = 3;
                  else if (strArray[0].Replace("化到", "").Split('+')[0] == "自机")
                    num6 = 4;
                  else
                    num5 = float.Parse(strArray[0].Replace("化到", "").Split('+')[0]);
                }
                else if (strArray[0].Replace("化到", "") == "自身")
                  num6 = 3;
                else if (strArray[0].Replace("化到", "") == "自机")
                  num6 = 4;
                else
                  num5 = float.Parse(strArray[0].Replace("化到", ""));
                string str10 = strArray[1];
                int num8 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                EventRead eventRead = new EventRead();
                eventRead.condition = str2;
                eventRead.result = str8;
                eventRead.condition2 = str3;
                eventRead.contype = (int) this.csm.conditions[(object) str4];
                eventRead.contype2 = (int) this.csm.conditions[(object) str4];
                eventRead.opreator = str5;
                eventRead.opreator2 = str6;
                eventRead.collector = str7;
                eventRead.change = num7;
                eventRead.changetype = (int) this.csm.type[(object) str10];
                eventRead.changevalue = result;
                eventRead.changename = (int) this.csm.results[(object) str9];
                eventRead.res = num5;
                eventRead.special = num6;
                if (strArray[0].Replace("化到", "").Contains<char>('+'))
                  eventRead.rand = float.Parse(strArray[0].Replace("化到", "").Split('+')[1]);
                eventRead.times = num8;
                if (strArray[2].Contains("("))
                  eventRead.time = int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
                parentevent.results.Add(eventRead);
              }
              else if (str1.Contains("增加"))
              {
                int num7 = 1;
                string[] strArray = str8.Split("增".ToCharArray())[1].Split("，".ToCharArray());
                strArray[0] = strArray[0].Replace("加", "");
                int result = (int) this.csm.results[(object) str8.Split("增".ToCharArray())[0]];
                string str9 = str8.Split("增".ToCharArray())[0];
                if (strArray[0].Contains<char>('+'))
                {
                  if (strArray[0].Split('+')[0] == "自身")
                    num6 = 3;
                  else if (strArray[0].Split('+')[0] == "自机")
                    num6 = 4;
                  else
                    num5 = float.Parse(strArray[0].Split('+')[0]);
                }
                else if (strArray[0] == "自身")
                  num6 = 3;
                else if (strArray[0] == "自机")
                  num6 = 4;
                else
                  num5 = float.Parse(strArray[0]);
                string str10 = strArray[1];
                int num8 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                EventRead eventRead = new EventRead();
                eventRead.condition = str2;
                eventRead.result = str8;
                eventRead.condition2 = str3;
                eventRead.contype = (int) this.csm.conditions[(object) str4];
                eventRead.contype2 = (int) this.csm.conditions[(object) str4];
                eventRead.opreator = str5;
                eventRead.opreator2 = str6;
                eventRead.collector = str7;
                eventRead.change = num7;
                eventRead.changetype = (int) this.csm.type[(object) str10];
                eventRead.changevalue = result;
                eventRead.changename = (int) this.csm.results[(object) str9];
                eventRead.res = num5;
                eventRead.special = num6;
                if (strArray[0].Contains<char>('+'))
                  eventRead.rand = float.Parse(strArray[0].Split('+')[1]);
                eventRead.times = num8;
                if (strArray[2].Contains("("))
                  eventRead.time = int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
                parentevent.results.Add(eventRead);
              }
              else if (str1.Contains("减少"))
              {
                int num7 = 2;
                string[] strArray = str8.Split("减少".ToCharArray())[2].Split("，".ToCharArray());
                int result = (int) this.csm.results[(object) str8.Split("减少".ToCharArray())[0]];
                string str9 = str8.Split("减少".ToCharArray())[0];
                if (strArray[0].Contains<char>('+'))
                {
                  if (strArray[0].Split('+')[0] == "自身")
                    num6 = 3;
                  else if (strArray[0].Split('+')[0] == "自机")
                    num6 = 4;
                  else
                    num5 = float.Parse(strArray[0].Split('+')[0]);
                }
                else if (strArray[0] == "自身")
                  num6 = 3;
                else if (strArray[0] == "自机")
                  num6 = 4;
                else
                  num5 = float.Parse(strArray[0]);
                string str10 = strArray[1];
                int num8 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                EventRead eventRead = new EventRead();
                eventRead.condition = str2;
                eventRead.result = str8;
                eventRead.condition2 = str3;
                eventRead.contype = (int) this.csm.conditions[(object) str4];
                eventRead.contype2 = (int) this.csm.conditions[(object) str4];
                eventRead.opreator = str5;
                eventRead.opreator2 = str6;
                eventRead.collector = str7;
                eventRead.change = num7;
                eventRead.changetype = (int) this.csm.type[(object) str10];
                eventRead.changevalue = result;
                eventRead.changename = (int) this.csm.results[(object) str9];
                eventRead.res = num5;
                eventRead.special = num6;
                if (strArray[0].Contains<char>('+'))
                  eventRead.rand = float.Parse(strArray[0].Split('+')[1]);
                eventRead.times = num8;
                if (strArray[2].Contains("("))
                  eventRead.time = int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
                parentevent.results.Add(eventRead);
              }
              else if (str1.Contains("恢复"))
                parentevent.results.Add(new EventRead()
                {
                  special = 1,
                  opreator = str5,
                  opreator2 = str6,
                  condition = str2,
                  condition2 = str3,
                  contype = (int) this.csm.conditions[(object) str4],
                  contype2 = (int) this.csm.conditions[(object) str4],
                  collector = str7
                });
              else if (str1.Contains("发射"))
                parentevent.results.Add(new EventRead()
                {
                  special = 2,
                  opreator = str5,
                  opreator2 = str6,
                  condition = str2,
                  condition2 = str3,
                  contype = (int) this.csm.conditions[(object) str4],
                  contype2 = (int) this.csm.conditions[(object) str4],
                  collector = str7
                });
            }
          }
          foreach (Event sonevent in batch.Sonevents)
          {
            foreach (string str1 in sonevent.events)
            {
              string str2 = str1.Split('：')[0];
              string str3 = "";
              string str4 = "";
              string str5 = "";
              string str6 = "";
              string str7 = "";
              string str8 = "";
              string str9 = str1.Split('：')[1];
              float num5 = 0.0f;
              int num6 = 0;
              if (str1.Contains("且"))
              {
                str8 = "且";
                str3 = str2.Split("且".ToCharArray())[1];
                str2 = str2.Split("且".ToCharArray())[0];
              }
              else if (str1.Contains("或"))
              {
                str8 = "或";
                str3 = str2.Split("或".ToCharArray())[1];
                str2 = str2.Split("或".ToCharArray())[0];
              }
              if (str2.Contains(">"))
              {
                str4 = str2.Split('>')[0];
                str6 = ">";
                str2 = str2.Split('>')[1];
              }
              if (str2.Contains("="))
              {
                str4 = str2.Split('=')[0];
                str6 = "=";
                str2 = str2.Split('=')[1];
              }
              if (str2.Contains("<"))
              {
                str4 = str2.Split('<')[0];
                str6 = "<";
                str2 = str2.Split('<')[1];
              }
              if (str3.Contains(">"))
              {
                str5 = str3.Split('>')[0];
                str7 = ">";
                str3 = str3.Split('>')[1];
              }
              if (str3.Contains("="))
              {
                str5 = str3.Split('=')[0];
                str7 = "=";
                str3 = str3.Split('=')[1];
              }
              if (str3.Contains("<"))
              {
                str5 = str3.Split('<')[0];
                str7 = "<";
                str3 = str3.Split('<')[1];
              }
              if (str1.Contains("变化到"))
              {
                int num7 = 0;
                string[] strArray = str9.Split("变".ToCharArray())[1].Split("，".ToCharArray());
                int num8 = (int) this.csm.results2[(object) str9.Split("变".ToCharArray())[0]];
                string str10 = str9.Split("变".ToCharArray())[0];
                if (strArray[0].Replace("化到", "").Contains<char>('+'))
                {
                  if (strArray[0].Replace("化到", "").Split('+')[0] == "自身")
                    num6 = 3;
                  else if (strArray[0].Replace("化到", "").Split('+')[0] == "自机")
                    num6 = 4;
                  else if (strArray[0].Replace("化到", "").Split('+')[0] == "中心")
                  {
                    num6 = 5;
                    str6 = "";
                  }
                  else
                    num5 = float.Parse(strArray[0].Replace("化到", "").Split('+')[0]);
                }
                else if (strArray[0].Replace("化到", "") == "自身")
                  num6 = 3;
                else if (strArray[0].Replace("化到", "") == "自机")
                  num6 = 4;
                else if (strArray[0].Replace("化到", "") == "中心")
                {
                  num6 = 5;
                  str6 = "";
                }
                else
                  num5 = float.Parse(strArray[0].Replace("化到", ""));
                string str11 = strArray[1];
                int num9 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                EventRead eventRead = new EventRead();
                eventRead.condition = str2;
                eventRead.result = str9;
                eventRead.condition2 = str3;
                eventRead.contype = (int) this.csm.conditions2[(object) str4];
                eventRead.contype2 = (int) this.csm.conditions2[(object) str5];
                eventRead.opreator = str6;
                eventRead.opreator2 = str7;
                eventRead.collector = str8;
                eventRead.change = num7;
                eventRead.changetype = (int) this.csm.type[(object) str11];
                eventRead.changevalue = num8;
                eventRead.changename = (int) this.csm.results2[(object) str10];
                eventRead.res = num5;
                eventRead.special = num6;
                if (strArray[0].Replace("化到", "").Contains<char>('+'))
                  eventRead.rand = float.Parse(strArray[0].Replace("化到", "").Split('+')[1]);
                eventRead.times = num9;
                if (strArray[2].Contains("("))
                  eventRead.time = int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
                sonevent.results.Add(eventRead);
              }
              else if (str1.Contains("增加"))
              {
                int num7 = 1;
                string[] strArray = str9.Split("增".ToCharArray())[1].Split("，".ToCharArray());
                strArray[0] = strArray[0].Replace("加", "");
                int num8 = (int) this.csm.results2[(object) str9.Split("增".ToCharArray())[0]];
                string str10 = str9.Split("增".ToCharArray())[0];
                if (strArray[0].Contains<char>('+'))
                {
                  if (strArray[0].Split('+')[0] == "自身")
                    num6 = 3;
                  else if (strArray[0].Split('+')[0] == "自机")
                    num6 = 4;
                  else if (strArray[0].Split('+')[0] == "中心")
                  {
                    num6 = 5;
                    str6 = "";
                  }
                  else
                    num5 = float.Parse(strArray[0].Split('+')[0]);
                }
                else if (strArray[0] == "自身")
                  num6 = 3;
                else if (strArray[0] == "自机")
                  num6 = 4;
                else if (strArray[0] == "中心")
                {
                  num6 = 5;
                  str6 = "";
                }
                else
                  num5 = float.Parse(strArray[0]);
                string str11 = strArray[1];
                int num9 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                EventRead eventRead = new EventRead();
                eventRead.condition = str2;
                eventRead.result = str9;
                eventRead.condition2 = str3;
                eventRead.contype = (int) this.csm.conditions2[(object) str4];
                eventRead.contype2 = (int) this.csm.conditions2[(object) str5];
                eventRead.opreator = str6;
                eventRead.opreator2 = str7;
                eventRead.collector = str8;
                eventRead.change = num7;
                eventRead.changetype = (int) this.csm.type[(object) str11];
                eventRead.changevalue = num8;
                eventRead.changename = (int) this.csm.results2[(object) str10];
                eventRead.res = num5;
                eventRead.special = num6;
                if (strArray[0].Contains<char>('+'))
                  eventRead.rand = float.Parse(strArray[0].Split('+')[1]);
                eventRead.times = num9;
                if (strArray[2].Contains("("))
                  eventRead.time = int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
                sonevent.results.Add(eventRead);
              }
              else if (str1.Contains("减少"))
              {
                int num7 = 2;
                string[] strArray = str9.Split("减少".ToCharArray())[2].Split("，".ToCharArray());
                int num8 = (int) this.csm.results2[(object) str9.Split("减少".ToCharArray())[0]];
                string str10 = str9.Split("减少".ToCharArray())[0];
                if (strArray[0].Contains<char>('+'))
                {
                  if (strArray[0].Split('+')[0] == "自身")
                    num6 = 3;
                  else if (strArray[0].Split('+')[0] == "自机")
                    num6 = 4;
                  else if (strArray[0].Split('+')[0] == "中心")
                  {
                    num6 = 5;
                    str6 = "";
                  }
                  else
                    num5 = float.Parse(strArray[0].Split('+')[0]);
                }
                else if (strArray[0] == "自身")
                  num6 = 3;
                else if (strArray[0] == "自机")
                  num6 = 4;
                else if (strArray[0] == "中心")
                {
                  num6 = 5;
                  str6 = "";
                }
                else
                  num5 = float.Parse(strArray[0]);
                string str11 = strArray[1];
                int num9 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                EventRead eventRead = new EventRead();
                eventRead.condition = str2;
                eventRead.result = str9;
                eventRead.condition2 = str3;
                eventRead.contype = (int) this.csm.conditions2[(object) str4];
                eventRead.contype2 = (int) this.csm.conditions2[(object) str5];
                eventRead.opreator = str6;
                eventRead.opreator2 = str7;
                eventRead.collector = str8;
                eventRead.change = num7;
                eventRead.changetype = (int) this.csm.type[(object) str11];
                eventRead.changevalue = num8;
                eventRead.changename = (int) this.csm.results2[(object) str10];
                eventRead.res = num5;
                eventRead.special = num6;
                if (strArray[0].Contains<char>('+'))
                  eventRead.rand = float.Parse(strArray[0].Split('+')[1]);
                eventRead.times = num9;
                if (strArray[2].Contains("("))
                  eventRead.time = int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
                sonevent.results.Add(eventRead);
              }
            }
          }
        }
        foreach (Lase lase in layer.LaseArray)
        {
          lase.copys = lase.Copy() as Lase;
          foreach (Event parentevent in lase.copys.Parentevents)
            parentevent.loop = 0;
          float num1 = MathHelper.Lerp(-lase.copys.rand.speed, lase.copys.rand.speed, (float) this.Rand(this.cs.effect && !this.cs.bomb, this.cs.bomb));
          int num2 = (int) MathHelper.Lerp(-lase.copys.rand.speedd, lase.copys.rand.speedd, (float) this.Rand(this.cs.effect && !this.cs.bomb, this.cs.bomb));
          float num3 = MathHelper.Lerp(-lase.copys.rand.aspeed, lase.copys.rand.aspeed, (float) this.Rand(this.cs.effect && !this.cs.bomb, this.cs.bomb));
          int num4 = (int) MathHelper.Lerp(-lase.copys.rand.aspeedd, lase.copys.rand.aspeedd, (float) this.Rand(this.cs.effect && !this.cs.bomb, this.cs.bomb));
          lase.copys.aspeed += num3;
          lase.copys.aspeedd += (float) num4;
          lase.copys.speed += num1;
          lase.copys.speedd += (float) num2;
          lase.copys.aspeedx = lase.copys.aspeed * (float) Math.Cos((double) MathHelper.ToRadians(lase.copys.aspeedd));
          lase.copys.aspeedy = lase.copys.aspeed * (float) Math.Sin((double) MathHelper.ToRadians(lase.copys.aspeedd));
          lase.copys.speedx = lase.copys.speed * (float) Math.Cos((double) MathHelper.ToRadians(lase.copys.speedd));
          lase.copys.speedy = lase.copys.speed * (float) Math.Sin((double) MathHelper.ToRadians(lase.copys.speedd));
          if ((double) lase.fdirection == -99999.0)
            lase.copys.fdirection = MathHelper.ToDegrees(Main.Twopointangle(Player.X, Player.Y, lase.copys.x - 4f, lase.copys.y + 16f));
          else if ((double) lase.fdirection == -100000.0)
            lase.copys.fdirection = MathHelper.ToDegrees(Main.Twopointangle(lase.fdirections.X, lase.fdirections.Y, lase.copys.x - 4f, lase.copys.y + 16f));
          if ((double) lase.sonaspeedd == -99998.0)
            lase.copys.sonaspeedd = MathHelper.ToDegrees(Main.Twopointangle(lase.x - 4f, lase.y + 16f, lase.copys.x - 4f, lase.copys.y + 16f));
          else if ((double) lase.sonaspeedd == -99999.0)
            lase.copys.sonaspeedd = MathHelper.ToDegrees(Main.Twopointangle(Player.X, Player.Y, lase.copys.x - 4f, lase.copys.y + 16f));
          else if ((double) lase.sonaspeedd == -100000.0)
            lase.copys.sonaspeedd = MathHelper.ToDegrees(Main.Twopointangle(lase.sonaspeedds.X, lase.sonaspeedds.Y, lase.copys.x - 4f, lase.copys.y + 16f));
          foreach (Event parentevent in lase.Parentevents)
          {
            foreach (string str1 in parentevent.events)
            {
              string str2 = str1.Split('：')[0];
              string str3 = "";
              string str4 = "";
              string str5 = "";
              string str6 = "";
              string str7 = "";
              string str8 = "";
              string str9 = str1.Split('：')[1];
              float num5 = 0.0f;
              int num6 = 0;
              if (str1.Contains("且"))
              {
                str8 = "且";
                str3 = str2.Split("且".ToCharArray())[1];
                str2 = str2.Split("且".ToCharArray())[0];
              }
              else if (str1.Contains("或"))
              {
                str8 = "或";
                str3 = str2.Split("或".ToCharArray())[1];
                str2 = str2.Split("或".ToCharArray())[0];
              }
              if (str2.Contains(">"))
              {
                str4 = str2.Split('>')[0];
                str6 = ">";
                str2 = str2.Split('>')[1];
              }
              if (str2.Contains("="))
              {
                str4 = str2.Split('=')[0];
                str6 = "=";
                str2 = str2.Split('=')[1];
              }
              if (str2.Contains("<"))
              {
                str4 = str2.Split('<')[0];
                str6 = "<";
                str2 = str2.Split('<')[1];
              }
              if (str3.Contains(">"))
              {
                str5 = str3.Split('>')[0];
                str7 = ">";
                str3 = str3.Split('>')[1];
              }
              if (str3.Contains("="))
              {
                str5 = str3.Split('=')[0];
                str7 = "=";
                str3 = str3.Split('=')[1];
              }
              if (str3.Contains("<"))
              {
                str5 = str3.Split('<')[0];
                str7 = "<";
                str3 = str3.Split('<')[1];
              }
              if (str1.Contains("变化到"))
              {
                int num7 = 0;
                string[] strArray = str9.Split("变化到".ToCharArray())[3].Split("，".ToCharArray());
                int lresult = (int) this.csm.lresults[(object) str9.Split("变化到".ToCharArray())[0]];
                string str10 = str9.Split("变化到".ToCharArray())[0];
                if (strArray[0].Contains<char>('+'))
                {
                  if (strArray[0].Split('+')[0] == "自机")
                    num6 = 4;
                  else
                    num5 = float.Parse(strArray[0].Split('+')[0]);
                }
                else if (strArray[0] == "自机")
                  num6 = 4;
                else
                  num5 = float.Parse(strArray[0]);
                string str11 = strArray[1];
                int num8 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                EventRead eventRead = new EventRead();
                eventRead.condition = str2;
                eventRead.result = str9;
                eventRead.condition2 = str3;
                eventRead.contype = (int) this.csm.lconditions[(object) str4];
                eventRead.contype2 = (int) this.csm.lconditions[(object) str5];
                eventRead.opreator = str6;
                eventRead.opreator2 = str7;
                eventRead.collector = str8;
                eventRead.change = num7;
                eventRead.changetype = (int) this.csm.type[(object) str11];
                eventRead.changevalue = lresult;
                eventRead.changename = (int) this.csm.lresults[(object) str10];
                eventRead.res = num5;
                eventRead.special = num6;
                if (strArray[0].Contains<char>('+'))
                  eventRead.rand = float.Parse(strArray[0].Split('+')[1]);
                eventRead.times = num8;
                if (strArray[2].Contains("("))
                  eventRead.time = int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
                parentevent.results.Add(eventRead);
              }
              else if (str1.Contains("增加"))
              {
                int num7 = 1;
                string[] strArray = str9.Split("增".ToCharArray())[1].Split("，".ToCharArray());
                strArray[0] = strArray[0].Replace("加", "");
                int lresult = (int) this.csm.lresults[(object) str9.Split("增".ToCharArray())[0]];
                string str10 = str9.Split("增".ToCharArray())[0];
                if (strArray[0].Contains<char>('+'))
                {
                  if (strArray[0].Split('+')[0] == "自机")
                    num6 = 4;
                  else
                    num5 = float.Parse(strArray[0].Split('+')[0]);
                }
                else if (strArray[0] == "自机")
                  num6 = 4;
                else
                  num5 = float.Parse(strArray[0]);
                string str11 = strArray[1];
                int num8 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                EventRead eventRead = new EventRead();
                eventRead.condition = str2;
                eventRead.result = str9;
                eventRead.condition2 = str3;
                eventRead.contype = (int) this.csm.lconditions[(object) str4];
                eventRead.contype2 = (int) this.csm.lconditions[(object) str5];
                eventRead.opreator = str6;
                eventRead.opreator2 = str7;
                eventRead.collector = str8;
                eventRead.change = num7;
                eventRead.changetype = (int) this.csm.type[(object) str11];
                eventRead.changevalue = lresult;
                eventRead.changename = (int) this.csm.lresults[(object) str10];
                eventRead.res = num5;
                eventRead.special = num6;
                if (strArray[0].Contains<char>('+'))
                  eventRead.rand = float.Parse(strArray[0].Split('+')[1]);
                eventRead.times = num8;
                if (strArray[2].Contains("("))
                  eventRead.time = int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
                parentevent.results.Add(eventRead);
              }
              else if (str1.Contains("减少"))
              {
                int num7 = 2;
                string[] strArray = str9.Split("减少".ToCharArray())[2].Split("，".ToCharArray());
                int lresult = (int) this.csm.lresults[(object) str9.Split("减少".ToCharArray())[0]];
                string str10 = str9.Split("减少".ToCharArray())[0];
                if (strArray[0].Contains<char>('+'))
                {
                  if (strArray[0].Split('+')[0] == "自机")
                    num6 = 4;
                  else
                    num5 = float.Parse(strArray[0].Split('+')[0]);
                }
                else if (strArray[0] == "自机")
                  num6 = 4;
                else
                  num5 = float.Parse(strArray[0]);
                string str11 = strArray[1];
                int num8 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                EventRead eventRead = new EventRead();
                eventRead.condition = str2;
                eventRead.result = str9;
                eventRead.condition2 = str3;
                eventRead.contype = (int) this.csm.lconditions[(object) str4];
                eventRead.contype2 = (int) this.csm.lconditions[(object) str5];
                eventRead.opreator = str6;
                eventRead.opreator2 = str7;
                eventRead.collector = str8;
                eventRead.change = num7;
                eventRead.changetype = (int) this.csm.type[(object) str11];
                eventRead.changevalue = lresult;
                eventRead.changename = (int) this.csm.lresults[(object) str10];
                eventRead.res = num5;
                eventRead.special = num6;
                if (strArray[0].Contains<char>('+'))
                  eventRead.rand = float.Parse(strArray[0].Split('+')[1]);
                eventRead.times = num8;
                if (strArray[2].Contains("("))
                  eventRead.time = int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
                parentevent.results.Add(eventRead);
              }
              else if (str1.Contains("恢复"))
                parentevent.results.Add(new EventRead()
                {
                  special = 1,
                  opreator = str6,
                  opreator2 = str7,
                  condition = str2,
                  condition2 = str3,
                  contype = (int) this.csm.lconditions[(object) str4],
                  contype2 = (int) this.csm.lconditions[(object) str5],
                  collector = str8
                });
              else if (str1.Contains("发射"))
                parentevent.results.Add(new EventRead()
                {
                  special = 2,
                  opreator = str6,
                  opreator2 = str7,
                  condition = str2,
                  condition2 = str3,
                  contype = (int) this.csm.lconditions[(object) str4],
                  contype2 = (int) this.csm.lconditions[(object) str5],
                  collector = str8
                });
            }
          }
          foreach (Event sonevent in lase.Sonevents)
          {
            foreach (string str1 in sonevent.events)
            {
              string str2 = str1.Split('：')[0];
              string str3 = "";
              string str4 = "";
              string str5 = "";
              string str6 = "";
              string str7 = "";
              string str8 = "";
              string str9 = str1.Split('：')[1];
              float num5 = 0.0f;
              int num6 = 0;
              if (str1.Contains("且"))
              {
                str8 = "且";
                str3 = str2.Split("且".ToCharArray())[1];
                str2 = str2.Split("且".ToCharArray())[0];
              }
              else if (str1.Contains("或"))
              {
                str8 = "或";
                str3 = str2.Split("或".ToCharArray())[1];
                str2 = str2.Split("或".ToCharArray())[0];
              }
              if (str2.Contains(">"))
              {
                str4 = str2.Split('>')[0];
                str6 = ">";
                str2 = str2.Split('>')[1];
              }
              if (str2.Contains("="))
              {
                str4 = str2.Split('=')[0];
                str6 = "=";
                str2 = str2.Split('=')[1];
              }
              if (str2.Contains("<"))
              {
                str4 = str2.Split('<')[0];
                str6 = "<";
                str2 = str2.Split('<')[1];
              }
              if (str3.Contains(">"))
              {
                str5 = str3.Split('>')[0];
                str7 = ">";
                str3 = str3.Split('>')[1];
              }
              if (str3.Contains("="))
              {
                str5 = str3.Split('=')[0];
                str7 = "=";
                str3 = str3.Split('=')[1];
              }
              if (str3.Contains("<"))
              {
                str5 = str3.Split('<')[0];
                str7 = "<";
                str3 = str3.Split('<')[1];
              }
              if (str1.Contains("变化到"))
              {
                int num7 = 0;
                string[] strArray = str9.Split("变化到".ToCharArray())[3].Split("，".ToCharArray());
                int num8 = (int) this.csm.lresults2[(object) str9.Split("变化到".ToCharArray())[0]];
                string str10 = str9.Split("变化到".ToCharArray())[0];
                if (strArray[0].Contains<char>('+'))
                {
                  if (strArray[0].Split('+')[0] == "自机")
                    num6 = 4;
                  else if (strArray[0].Split('+')[0] == "中心")
                  {
                    num6 = 5;
                    str6 = "";
                  }
                  else
                    num5 = float.Parse(strArray[0].Split('+')[0]);
                }
                else if (strArray[0] == "自机")
                  num6 = 4;
                else if (strArray[0] == "中心")
                {
                  num6 = 5;
                  str6 = "";
                }
                else
                  num5 = float.Parse(strArray[0]);
                string str11 = strArray[1];
                int num9 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                EventRead eventRead = new EventRead();
                eventRead.condition = str2;
                eventRead.result = str9;
                eventRead.condition2 = str3;
                eventRead.contype = (int) this.csm.lconditions[(object) str4];
                eventRead.contype2 = (int) this.csm.lconditions[(object) str5];
                eventRead.opreator = str6;
                eventRead.opreator2 = str7;
                eventRead.collector = str8;
                eventRead.change = num7;
                eventRead.changetype = (int) this.csm.type[(object) str11];
                eventRead.changevalue = num8;
                eventRead.changename = (int) this.csm.lresults2[(object) str10];
                eventRead.res = num5;
                eventRead.special = num6;
                if (strArray[0].Contains<char>('+'))
                  eventRead.rand = float.Parse(strArray[0].Split('+')[1]);
                eventRead.times = num9;
                if (strArray[2].Contains("("))
                  eventRead.time = int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
                sonevent.results.Add(eventRead);
              }
              else if (str1.Contains("增加"))
              {
                int num7 = 1;
                string[] strArray = str9.Split("增".ToCharArray())[1].Split("，".ToCharArray());
                strArray[0] = strArray[0].Replace("加", "");
                int num8 = (int) this.csm.lresults2[(object) str9.Split("增".ToCharArray())[0]];
                string str10 = str9.Split("增".ToCharArray())[0];
                if (strArray[0].Contains<char>('+'))
                {
                  if (strArray[0].Split('+')[0] == "自机")
                    num6 = 4;
                  else if (strArray[0].Split('+')[0] == "中心")
                  {
                    num6 = 5;
                    str6 = "";
                  }
                  else
                    num5 = float.Parse(strArray[0].Split('+')[0]);
                }
                else if (strArray[0] == "自机")
                  num6 = 4;
                else if (strArray[0] == "中心")
                {
                  num6 = 5;
                  str6 = "";
                }
                else
                  num5 = float.Parse(strArray[0]);
                string str11 = strArray[1];
                int num9 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                EventRead eventRead = new EventRead();
                eventRead.condition = str2;
                eventRead.result = str9;
                eventRead.condition2 = str3;
                eventRead.contype = (int) this.csm.lconditions[(object) str4];
                eventRead.contype2 = (int) this.csm.lconditions[(object) str5];
                eventRead.opreator = str6;
                eventRead.opreator2 = str7;
                eventRead.collector = str8;
                eventRead.change = num7;
                eventRead.changetype = (int) this.csm.type[(object) str11];
                eventRead.changevalue = num8;
                eventRead.changename = (int) this.csm.lresults2[(object) str10];
                eventRead.res = num5;
                eventRead.special = num6;
                if (strArray[0].Contains<char>('+'))
                  eventRead.rand = float.Parse(strArray[0].Split('+')[1]);
                eventRead.times = num9;
                if (strArray[2].Contains("("))
                  eventRead.time = int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
                sonevent.results.Add(eventRead);
              }
              else if (str1.Contains("减少"))
              {
                int num7 = 2;
                string[] strArray = str9.Split("减少".ToCharArray())[2].Split("，".ToCharArray());
                int num8 = (int) this.csm.lresults2[(object) str9.Split("减少".ToCharArray())[0]];
                string str10 = str9.Split("减少".ToCharArray())[0];
                if (strArray[0].Contains<char>('+'))
                {
                  if (strArray[0].Split('+')[0] == "自机")
                    num6 = 4;
                  else if (strArray[0].Split('+')[0] == "中心")
                  {
                    num6 = 5;
                    str6 = "";
                  }
                  else
                    num5 = float.Parse(strArray[0].Split('+')[0]);
                }
                else if (strArray[0] == "自机")
                  num6 = 4;
                else if (strArray[0] == "中心")
                {
                  num6 = 5;
                  str6 = "";
                }
                else
                  num5 = float.Parse(strArray[0]);
                string str11 = strArray[1];
                int num9 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                EventRead eventRead = new EventRead();
                eventRead.condition = str2;
                eventRead.result = str9;
                eventRead.condition2 = str3;
                eventRead.contype = (int) this.csm.lconditions[(object) str4];
                eventRead.contype2 = (int) this.csm.lconditions[(object) str5];
                eventRead.opreator = str6;
                eventRead.opreator2 = str7;
                eventRead.collector = str8;
                eventRead.change = num7;
                eventRead.changetype = (int) this.csm.type[(object) str11];
                eventRead.changevalue = num8;
                eventRead.changename = (int) this.csm.lresults2[(object) str10];
                eventRead.res = num5;
                eventRead.special = num6;
                if (strArray[0].Contains<char>('+'))
                  eventRead.rand = float.Parse(strArray[0].Split('+')[1]);
                eventRead.times = num9;
                if (strArray[2].Contains("("))
                  eventRead.time = int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
                sonevent.results.Add(eventRead);
              }
            }
          }
        }
        foreach (Cover cover in layer.CoverArray)
        {
          cover.copys = cover.Copy() as Cover;
          foreach (Event parentevent in cover.copys.Parentevents)
            parentevent.loop = 0;
          float num1 = MathHelper.Lerp(-cover.copys.rand.speed, cover.copys.rand.speed, (float) this.Rand(this.cs.effect && !this.cs.bomb, this.cs.bomb));
          int num2 = (int) MathHelper.Lerp(-cover.copys.rand.speedd, cover.copys.rand.speedd, (float) this.Rand(this.cs.effect && !this.cs.bomb, this.cs.bomb));
          float num3 = MathHelper.Lerp(-cover.copys.rand.aspeed, cover.copys.rand.aspeed, (float) this.Rand(this.cs.effect && !this.cs.bomb, this.cs.bomb));
          int num4 = (int) MathHelper.Lerp(-cover.copys.rand.aspeedd, cover.copys.rand.aspeedd, (float) this.Rand(this.cs.effect && !this.cs.bomb, this.cs.bomb));
          cover.copys.aspeed += num3;
          cover.copys.aspeedd += (float) num4;
          cover.copys.speed += num1;
          cover.copys.speedd += (float) num2;
          cover.copys.aspeedx = cover.copys.aspeed * (float) Math.Cos((double) MathHelper.ToRadians(cover.copys.aspeedd));
          cover.copys.aspeedy = cover.copys.aspeed * (float) Math.Sin((double) MathHelper.ToRadians(cover.copys.aspeedd));
          cover.copys.speedx = cover.copys.speed * (float) Math.Cos((double) MathHelper.ToRadians(cover.copys.speedd));
          cover.copys.speedy = cover.copys.speed * (float) Math.Sin((double) MathHelper.ToRadians(cover.copys.speedd));
          foreach (Event parentevent in cover.Parentevents)
          {
            foreach (string str1 in parentevent.events)
            {
              string str2 = str1.Split('：')[0];
              string str3 = "";
              string str4 = "";
              string str5 = "";
              string str6 = "";
              string str7 = "";
              string str8 = "";
              string str9 = str1.Split('：')[1];
              float num5 = 0.0f;
              int num6 = 0;
              if (str1.Contains("且"))
              {
                str8 = "且";
                str3 = str2.Split("且".ToCharArray())[1];
                str2 = str2.Split("且".ToCharArray())[0];
              }
              else if (str1.Contains("或"))
              {
                str8 = "或";
                str3 = str2.Split("或".ToCharArray())[1];
                str2 = str2.Split("或".ToCharArray())[0];
              }
              if (str2.Contains(">"))
              {
                str4 = str2.Split('>')[0];
                str6 = ">";
                str2 = str2.Split('>')[1];
              }
              if (str2.Contains("="))
              {
                str4 = str2.Split('=')[0];
                str6 = "=";
                str2 = str2.Split('=')[1];
              }
              if (str2.Contains("<"))
              {
                str4 = str2.Split('<')[0];
                str6 = "<";
                str2 = str2.Split('<')[1];
              }
              if (str3.Contains(">"))
              {
                str5 = str3.Split('>')[0];
                str7 = ">";
                str3 = str3.Split('>')[1];
              }
              if (str3.Contains("="))
              {
                str5 = str3.Split('=')[0];
                str7 = "=";
                str3 = str3.Split('=')[1];
              }
              if (str3.Contains("<"))
              {
                str5 = str3.Split('<')[0];
                str7 = "<";
                str3 = str3.Split('<')[1];
              }
              if (str1.Contains("变化到"))
              {
                int num7 = 0;
                string[] strArray = str9.Split("变化到".ToCharArray())[3].Split("，".ToCharArray());
                int cresult = (int) this.csm.cresults[(object) str9.Split("变化到".ToCharArray())[0]];
                string str10 = str9.Split("变化到".ToCharArray())[0];
                if (strArray[0].Contains<char>('+'))
                {
                  if (strArray[0].Split('+')[0] == "自机")
                    num6 = 4;
                  else
                    num5 = float.Parse(strArray[0].Split('+')[0]);
                }
                else if (strArray[0] == "自机")
                  num6 = 4;
                else
                  num5 = float.Parse(strArray[0]);
                string str11 = strArray[1];
                int num8 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                EventRead eventRead = new EventRead();
                eventRead.condition = str2;
                eventRead.result = str9;
                eventRead.condition2 = str3;
                eventRead.contype = (int) this.csm.cconditions[(object) str4];
                eventRead.contype2 = (int) this.csm.cconditions[(object) str5];
                eventRead.opreator = str6;
                eventRead.opreator2 = str7;
                eventRead.collector = str8;
                eventRead.change = num7;
                eventRead.changetype = (int) this.csm.type[(object) str11];
                eventRead.changevalue = cresult;
                eventRead.changename = (int) this.csm.cresults[(object) str10];
                eventRead.res = num5;
                eventRead.special = num6;
                if (strArray[0].Contains<char>('+'))
                  eventRead.rand = float.Parse(strArray[0].Split('+')[1]);
                eventRead.times = num8;
                if (strArray[2].Contains("("))
                  eventRead.time = int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
                parentevent.results.Add(eventRead);
              }
              else if (str1.Contains("增加"))
              {
                int num7 = 1;
                string[] strArray = str9.Split("增".ToCharArray())[1].Split("，".ToCharArray());
                strArray[0] = strArray[0].Replace("加", "");
                int cresult = (int) this.csm.cresults[(object) str9.Split("增".ToCharArray())[0]];
                string str10 = str9.Split("增".ToCharArray())[0];
                if (strArray[0].Contains<char>('+'))
                {
                  if (strArray[0].Split('+')[0] == "自机")
                    num6 = 4;
                  else
                    num5 = float.Parse(strArray[0].Split('+')[0]);
                }
                else if (strArray[0] == "自机")
                  num6 = 4;
                else
                  num5 = float.Parse(strArray[0]);
                string str11 = strArray[1];
                int num8 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                EventRead eventRead = new EventRead();
                eventRead.condition = str2;
                eventRead.result = str9;
                eventRead.condition2 = str3;
                eventRead.contype = (int) this.csm.cconditions[(object) str4];
                eventRead.contype2 = (int) this.csm.cconditions[(object) str5];
                eventRead.opreator = str6;
                eventRead.opreator2 = str7;
                eventRead.collector = str8;
                eventRead.change = num7;
                eventRead.changetype = (int) this.csm.type[(object) str11];
                eventRead.changevalue = cresult;
                eventRead.changename = (int) this.csm.cresults[(object) str10];
                eventRead.res = num5;
                eventRead.special = num6;
                if (strArray[0].Contains<char>('+'))
                  eventRead.rand = float.Parse(strArray[0].Split('+')[1]);
                eventRead.times = num8;
                if (strArray[2].Contains("("))
                  eventRead.time = int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
                parentevent.results.Add(eventRead);
              }
              else if (str1.Contains("减少"))
              {
                int num7 = 2;
                string[] strArray = str9.Split("减少".ToCharArray())[2].Split("，".ToCharArray());
                int cresult = (int) this.csm.cresults[(object) str9.Split("减少".ToCharArray())[0]];
                string str10 = str9.Split("减少".ToCharArray())[0];
                if (strArray[0].Contains<char>('+'))
                {
                  if (strArray[0].Split('+')[0] == "自机")
                    num6 = 4;
                  else
                    num5 = float.Parse(strArray[0].Split('+')[0]);
                }
                else if (strArray[0] == "自机")
                  num6 = 4;
                else
                  num5 = float.Parse(strArray[0]);
                string str11 = strArray[1];
                int num8 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                EventRead eventRead = new EventRead();
                eventRead.condition = str2;
                eventRead.result = str9;
                eventRead.condition2 = str3;
                eventRead.contype = (int) this.csm.cconditions[(object) str4];
                eventRead.contype2 = (int) this.csm.cconditions[(object) str5];
                eventRead.opreator = str6;
                eventRead.opreator2 = str7;
                eventRead.collector = str8;
                eventRead.change = num7;
                eventRead.changetype = (int) this.csm.type[(object) str11];
                eventRead.changevalue = cresult;
                eventRead.changename = (int) this.csm.cresults[(object) str10];
                eventRead.res = num5;
                eventRead.special = num6;
                if (strArray[0].Contains<char>('+'))
                  eventRead.rand = float.Parse(strArray[0].Split('+')[1]);
                eventRead.times = num8;
                if (strArray[2].Contains("("))
                  eventRead.time = int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
                parentevent.results.Add(eventRead);
              }
            }
          }
          foreach (Event sonevent in cover.Sonevents)
          {
            foreach (string str1 in sonevent.events)
            {
              string str2 = str1.Split('：')[0];
              string str3 = "";
              string str4 = "";
              string str5 = "";
              string str6 = "";
              string str7 = "";
              string str8 = "";
              string str9 = str1.Split('：')[1];
              float num5 = 0.0f;
              int num6 = 0;
              if (str1.Contains("且"))
              {
                str8 = "且";
                str3 = str2.Split("且".ToCharArray())[1];
                str2 = str2.Split("且".ToCharArray())[0];
              }
              else if (str1.Contains("或"))
              {
                str8 = "或";
                str3 = str2.Split("或".ToCharArray())[1];
                str2 = str2.Split("或".ToCharArray())[0];
              }
              if (str2.Contains(">"))
              {
                str4 = str2.Split('>')[0];
                str6 = ">";
                str2 = str2.Split('>')[1];
              }
              if (str2.Contains("="))
              {
                str4 = str2.Split('=')[0];
                str6 = "=";
                str2 = str2.Split('=')[1];
              }
              if (str2.Contains("<"))
              {
                str4 = str2.Split('<')[0];
                str6 = "<";
                str2 = str2.Split('<')[1];
              }
              if (str3.Contains(">"))
              {
                str5 = str3.Split('>')[0];
                str7 = ">";
                str3 = str3.Split('>')[1];
              }
              if (str3.Contains("="))
              {
                str5 = str3.Split('=')[0];
                str7 = "=";
                str3 = str3.Split('=')[1];
              }
              if (str3.Contains("<"))
              {
                str5 = str3.Split('<')[0];
                str7 = "<";
                str3 = str3.Split('<')[1];
              }
              if (str1.Contains("变化到"))
              {
                int num7 = 0;
                string[] strArray = str9.Split("变化到".ToCharArray())[3].Split("，".ToCharArray());
                int num8 = (int) this.csm.results2[(object) str9.Split("变化到".ToCharArray())[0]];
                string str10 = str9.Split("变化到".ToCharArray())[0];
                if (strArray[0].Contains<char>('+'))
                {
                  if (strArray[0].Split('+')[0] == "自身")
                    num6 = 3;
                  else if (strArray[0].Split('+')[0] == "自机")
                    num6 = 4;
                  else if (strArray[0].Split('+')[0] == "中心")
                  {
                    num6 = 5;
                    str6 = "";
                  }
                  else
                    num5 = float.Parse(strArray[0].Split('+')[0]);
                }
                else if (strArray[0] == "自身")
                  num6 = 3;
                else if (strArray[0] == "自机")
                  num6 = 4;
                else if (strArray[0] == "中心")
                {
                  num6 = 5;
                  str6 = "";
                }
                else
                  num5 = float.Parse(strArray[0]);
                string str11 = strArray[1];
                int num9 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                EventRead eventRead = new EventRead();
                eventRead.condition = str2;
                eventRead.result = str9;
                eventRead.condition2 = str3;
                eventRead.contype = (int) this.csm.conditions2[(object) str4];
                eventRead.contype2 = (int) this.csm.conditions2[(object) str5];
                eventRead.opreator = str6;
                eventRead.opreator2 = str7;
                eventRead.collector = str8;
                eventRead.change = num7;
                eventRead.changetype = (int) this.csm.type[(object) str11];
                eventRead.changevalue = num8;
                eventRead.changename = (int) this.csm.results2[(object) str10];
                eventRead.res = num5;
                eventRead.special = num6;
                eventRead.special2 = 1;
                if (strArray[0].Contains<char>('+'))
                  eventRead.rand = float.Parse(strArray[0].Split('+')[1]);
                eventRead.times = num9;
                if (strArray[2].Contains("("))
                  eventRead.time = int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
                sonevent.results.Add(eventRead);
              }
              else if (str1.Contains("增加"))
              {
                int num7 = 1;
                string[] strArray = str9.Split("增".ToCharArray())[1].Split("，".ToCharArray());
                strArray[0] = strArray[0].Replace("加", "");
                int num8 = (int) this.csm.results2[(object) str9.Split("增".ToCharArray())[0]];
                string str10 = str9.Split("增".ToCharArray())[0];
                if (strArray[0].Contains<char>('+'))
                {
                  if (strArray[0].Split('+')[0] == "自身")
                    num6 = 3;
                  else if (strArray[0].Split('+')[0] == "自机")
                    num6 = 4;
                  else if (strArray[0].Split('+')[0] == "中心")
                  {
                    num6 = 5;
                    str6 = "";
                  }
                  else
                    num5 = float.Parse(strArray[0].Split('+')[0]);
                }
                else if (strArray[0] == "自身")
                  num6 = 3;
                else if (strArray[0] == "自机")
                  num6 = 4;
                else if (strArray[0] == "中心")
                {
                  num6 = 5;
                  str6 = "";
                }
                else
                  num5 = float.Parse(strArray[0]);
                string str11 = strArray[1];
                int num9 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                EventRead eventRead = new EventRead();
                eventRead.condition = str2;
                eventRead.result = str9;
                eventRead.condition2 = str3;
                eventRead.contype = (int) this.csm.conditions2[(object) str4];
                eventRead.contype2 = (int) this.csm.conditions2[(object) str5];
                eventRead.opreator = str6;
                eventRead.opreator2 = str7;
                eventRead.collector = str8;
                eventRead.change = num7;
                eventRead.changetype = (int) this.csm.type[(object) str11];
                eventRead.changevalue = num8;
                eventRead.changename = (int) this.csm.results2[(object) str10];
                eventRead.res = num5;
                eventRead.special = num6;
                eventRead.special2 = 1;
                if (strArray[0].Contains<char>('+'))
                  eventRead.rand = float.Parse(strArray[0].Split('+')[1]);
                eventRead.times = num9;
                if (strArray[2].Contains("("))
                  eventRead.time = int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
                sonevent.results.Add(eventRead);
              }
              else if (str1.Contains("减少"))
              {
                int num7 = 2;
                string[] strArray = str9.Split("减少".ToCharArray())[2].Split("，".ToCharArray());
                int num8 = (int) this.csm.results2[(object) str9.Split("减少".ToCharArray())[0]];
                string str10 = str9.Split("减少".ToCharArray())[0];
                if (strArray[0].Contains<char>('+'))
                {
                  if (strArray[0].Split('+')[0] == "自身")
                    num6 = 3;
                  else if (strArray[0].Split('+')[0] == "自机")
                    num6 = 4;
                  else if (strArray[0].Split('+')[0] == "中心")
                  {
                    num6 = 5;
                    str6 = "";
                  }
                  else
                    num5 = float.Parse(strArray[0].Split('+')[0]);
                }
                else if (strArray[0] == "自身")
                  num6 = 3;
                else if (strArray[0] == "自机")
                  num6 = 4;
                else if (strArray[0] == "中心")
                {
                  num6 = 5;
                  str6 = "";
                }
                else
                  num5 = float.Parse(strArray[0]);
                string str11 = strArray[1];
                int num9 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                EventRead eventRead = new EventRead();
                eventRead.condition = str2;
                eventRead.result = str9;
                eventRead.condition2 = str3;
                eventRead.contype = (int) this.csm.conditions2[(object) str4];
                eventRead.contype2 = (int) this.csm.conditions2[(object) str5];
                eventRead.opreator = str6;
                eventRead.opreator2 = str7;
                eventRead.collector = str8;
                eventRead.change = num7;
                eventRead.changetype = (int) this.csm.type[(object) str11];
                eventRead.changevalue = num8;
                eventRead.changename = (int) this.csm.results2[(object) str10];
                eventRead.res = num5;
                eventRead.special = num6;
                eventRead.special2 = 1;
                if (strArray[0].Contains<char>('+'))
                  eventRead.rand = float.Parse(strArray[0].Split('+')[1]);
                eventRead.times = num9;
                if (strArray[2].Contains("("))
                  eventRead.time = int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
                sonevent.results.Add(eventRead);
              }
            }
          }
        }
        foreach (Rebound rebound in layer.ReboundArray)
        {
          rebound.copys = rebound.Copy() as Rebound;
          float num1 = MathHelper.Lerp(-rebound.copys.rand.speed, rebound.copys.rand.speed, (float) this.Rand(this.cs.effect && !this.cs.bomb, this.cs.bomb));
          int num2 = (int) MathHelper.Lerp(-rebound.copys.rand.speedd, rebound.copys.rand.speedd, (float) this.Rand(this.cs.effect && !this.cs.bomb, this.cs.bomb));
          float num3 = MathHelper.Lerp(-rebound.copys.rand.aspeed, rebound.copys.rand.aspeed, (float) this.Rand(this.cs.effect && !this.cs.bomb, this.cs.bomb));
          int num4 = (int) MathHelper.Lerp(-rebound.copys.rand.aspeedd, rebound.copys.rand.aspeedd, (float) this.Rand(this.cs.effect && !this.cs.bomb, this.cs.bomb));
          rebound.copys.aspeed += num3;
          rebound.copys.aspeedd += (float) num4;
          rebound.copys.speed += num1;
          rebound.copys.speedd += (float) num2;
          rebound.copys.aspeedx = rebound.copys.aspeed * (float) Math.Cos((double) MathHelper.ToRadians(rebound.copys.aspeedd));
          rebound.copys.aspeedy = rebound.copys.aspeed * (float) Math.Sin((double) MathHelper.ToRadians(rebound.copys.aspeedd));
          rebound.copys.speedx = rebound.copys.speed * (float) Math.Cos((double) MathHelper.ToRadians(rebound.copys.speedd));
          rebound.copys.speedy = rebound.copys.speed * (float) Math.Sin((double) MathHelper.ToRadians(rebound.copys.speedd));
        }
        foreach (Force force in layer.ForceArray)
        {
          force.copys = force.Copy() as Force;
          float num1 = MathHelper.Lerp(-force.copys.rand.speed, force.copys.rand.speed, (float) this.Rand(this.cs.effect && !this.cs.bomb, this.cs.bomb));
          int num2 = (int) MathHelper.Lerp(-force.copys.rand.speedd, force.copys.rand.speedd, (float) this.Rand(this.cs.effect && !this.cs.bomb, this.cs.bomb));
          float num3 = MathHelper.Lerp(-force.copys.rand.aspeed, force.copys.rand.aspeed, (float) this.Rand(this.cs.effect && !this.cs.bomb, this.cs.bomb));
          int num4 = (int) MathHelper.Lerp(-force.copys.rand.aspeedd, force.copys.rand.aspeedd, (float) this.Rand(this.cs.effect && !this.cs.bomb, this.cs.bomb));
          force.copys.aspeed += num3;
          force.copys.aspeedd += (float) num4;
          force.copys.speed += num1;
          force.copys.speedd += (float) num2;
          force.copys.aspeedx = force.copys.aspeed * (float) Math.Cos((double) MathHelper.ToRadians(force.copys.aspeedd));
          force.copys.aspeedy = force.copys.aspeed * (float) Math.Sin((double) MathHelper.ToRadians(force.copys.aspeedd));
          force.copys.speedx = force.copys.speed * (float) Math.Cos((double) MathHelper.ToRadians(force.copys.speedd));
          force.copys.speedy = force.copys.speed * (float) Math.Sin((double) MathHelper.ToRadians(force.copys.speedd));
        }
      }
    }

    public void Update(CrazyStorm cs, Center Centers, Vector2 Player)
    {
      ++this.now;
      if (this.now > this.total && (!cs.effect || cs.specialnotkill))
      {
        this.now = 1;
        ++this.times;
        Centers.Eventsexe.Clear();
        foreach (Layer layer in this.layerm.LayerArray)
        {
          foreach (Batch batch in layer.BatchArray)
          {
            batch.Eventsexe.Clear();
            batch.copys = batch.Copy() as Batch;
            foreach (Event parentevent in batch.copys.Parentevents)
              parentevent.loop = 0;
            float num1 = MathHelper.Lerp(-batch.copys.rand.speed, batch.copys.rand.speed, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
            int num2 = (int) MathHelper.Lerp(-batch.copys.rand.speedd, batch.copys.rand.speedd, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
            float num3 = MathHelper.Lerp(-batch.copys.rand.aspeed, batch.copys.rand.aspeed, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
            int num4 = (int) MathHelper.Lerp(-batch.copys.rand.aspeedd, batch.copys.rand.aspeedd, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
            if ((double) batch.fx == -99998.0)
              batch.copys.fx = batch.x - 4f;
            if ((double) batch.fx == -99999.0)
              batch.copys.fx = Player.X;
            if ((double) batch.fy == -99998.0)
              batch.copys.fy = batch.y + 16f;
            if ((double) batch.fy == -99999.0)
              batch.copys.fy = Player.Y;
            if ((double) batch.speedd == -99999.0)
              batch.copys.speedd = MathHelper.ToDegrees(Main.Twopointangle(Player.X, Player.Y, batch.copys.fx, batch.copys.fy));
            if ((double) batch.aspeedd == -99999.0)
              batch.copys.aspeedd = MathHelper.ToDegrees(Main.Twopointangle(Player.X, Player.Y, batch.copys.fx, batch.copys.fy));
            batch.copys.aspeed += num3;
            batch.copys.aspeedd += (float) num4;
            batch.copys.speed += num1;
            batch.copys.speedd += (float) num2;
            batch.copys.aspeedx = batch.copys.aspeed * (float) Math.Cos((double) MathHelper.ToRadians(batch.copys.aspeedd));
            batch.copys.aspeedy = batch.copys.aspeed * (float) Math.Sin((double) MathHelper.ToRadians(batch.copys.aspeedd));
            batch.copys.speedx = batch.copys.speed * (float) Math.Cos((double) MathHelper.ToRadians(batch.copys.speedd));
            batch.copys.speedy = batch.copys.speed * (float) Math.Sin((double) MathHelper.ToRadians(batch.copys.speedd));
            batch.copys.bfdirection = batch.fdirection;
            batch.copys.bsonaspeedd = batch.sonaspeedd;
            if ((double) batch.fdirection == -99998.0)
              batch.copys.fdirection = MathHelper.ToDegrees(Main.Twopointangle(batch.x - 4f, batch.y + 16f, batch.copys.fx, batch.copys.fy));
            else if ((double) batch.fdirection == -99999.0)
              batch.copys.fdirection = MathHelper.ToDegrees(Main.Twopointangle(Player.X, Player.Y, batch.copys.fx, batch.copys.fy));
            else if ((double) batch.fdirection == -100000.0)
              batch.copys.fdirection = MathHelper.ToDegrees(Main.Twopointangle(batch.fdirections.X, batch.fdirections.Y, batch.copys.fx, batch.copys.fy));
            if ((double) batch.sonaspeedd == -99998.0)
              batch.copys.sonaspeedd = MathHelper.ToDegrees(Main.Twopointangle(batch.x - 4f, batch.y + 16f, batch.copys.fx, batch.copys.fy));
            else if ((double) batch.sonaspeedd == -99999.0)
              batch.copys.sonaspeedd = MathHelper.ToDegrees(Main.Twopointangle(Player.X, Player.Y, batch.copys.fx, batch.copys.fy));
            else if ((double) batch.sonaspeedd == -100000.0)
              batch.copys.sonaspeedd = MathHelper.ToDegrees(Main.Twopointangle(batch.sonaspeedds.X, batch.sonaspeedds.Y, batch.copys.fx, batch.copys.fy));
            if ((double) batch.head == -100000.0)
              batch.copys.head = MathHelper.ToDegrees(Main.Twopointangle(batch.heads.X, batch.heads.Y, batch.copys.fx, batch.copys.fx));
          }
          foreach (Lase lase in layer.LaseArray)
          {
            lase.Eventsexe.Clear();
            lase.copys = lase.Copy() as Lase;
            foreach (Event parentevent in lase.copys.Parentevents)
              parentevent.loop = 0;
            float num1 = MathHelper.Lerp(-lase.copys.rand.speed, lase.copys.rand.speed, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
            int num2 = (int) MathHelper.Lerp(-lase.copys.rand.speedd, lase.copys.rand.speedd, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
            float num3 = MathHelper.Lerp(-lase.copys.rand.aspeed, lase.copys.rand.aspeed, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
            int num4 = (int) MathHelper.Lerp(-lase.copys.rand.aspeedd, lase.copys.rand.aspeedd, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
            lase.copys.aspeed += num3;
            lase.copys.aspeedd += (float) num4;
            lase.copys.speed += num1;
            lase.copys.speedd += (float) num2;
            lase.copys.aspeedx = lase.copys.aspeed * (float) Math.Cos((double) MathHelper.ToRadians(lase.copys.aspeedd));
            lase.copys.aspeedy = lase.copys.aspeed * (float) Math.Sin((double) MathHelper.ToRadians(lase.copys.aspeedd));
            lase.copys.speedx = lase.copys.speed * (float) Math.Cos((double) MathHelper.ToRadians(lase.copys.speedd));
            lase.copys.speedy = lase.copys.speed * (float) Math.Sin((double) MathHelper.ToRadians(lase.copys.speedd));
            if ((double) lase.fdirection == -99999.0)
              lase.copys.fdirection = MathHelper.ToDegrees(Main.Twopointangle(Player.X, Player.Y, lase.copys.x - 4f, lase.copys.y + 16f));
            else if ((double) lase.fdirection == -100000.0)
              lase.copys.fdirection = MathHelper.ToDegrees(Main.Twopointangle(lase.fdirections.X, lase.fdirections.Y, lase.copys.x - 4f, lase.copys.y + 16f));
            if ((double) lase.sonaspeedd == -99998.0)
              lase.copys.sonaspeedd = MathHelper.ToDegrees(Main.Twopointangle(lase.x - 4f, lase.y + 16f, lase.copys.x - 4f, lase.copys.y + 16f));
            else if ((double) lase.sonaspeedd == -99999.0)
              lase.copys.sonaspeedd = MathHelper.ToDegrees(Main.Twopointangle(Player.X, Player.Y, lase.copys.x - 4f, lase.copys.y + 16f));
            else if ((double) lase.sonaspeedd == -100000.0)
              lase.copys.sonaspeedd = MathHelper.ToDegrees(Main.Twopointangle(lase.sonaspeedds.X, lase.sonaspeedds.Y, lase.copys.x - 4f, lase.copys.y + 16f));
          }
          foreach (Cover cover in layer.CoverArray)
          {
            cover.Eventsexe.Clear();
            cover.copys = cover.Copy() as Cover;
            foreach (Event parentevent in cover.copys.Parentevents)
              parentevent.loop = 0;
            float num1 = MathHelper.Lerp(-cover.copys.rand.speed, cover.copys.rand.speed, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
            int num2 = (int) MathHelper.Lerp(-cover.copys.rand.speedd, cover.copys.rand.speedd, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
            float num3 = MathHelper.Lerp(-cover.copys.rand.aspeed, cover.copys.rand.aspeed, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
            int num4 = (int) MathHelper.Lerp(-cover.copys.rand.aspeedd, cover.copys.rand.aspeedd, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
            cover.copys.aspeed += num3;
            cover.copys.aspeedd += (float) num4;
            cover.copys.speed += num1;
            cover.copys.speedd += (float) num2;
            cover.copys.aspeedx = cover.copys.aspeed * (float) Math.Cos((double) MathHelper.ToRadians(cover.copys.aspeedd));
            cover.copys.aspeedy = cover.copys.aspeed * (float) Math.Sin((double) MathHelper.ToRadians(cover.copys.aspeedd));
            cover.copys.speedx = cover.copys.speed * (float) Math.Cos((double) MathHelper.ToRadians(cover.copys.speedd));
            cover.copys.speedy = cover.copys.speed * (float) Math.Sin((double) MathHelper.ToRadians(cover.copys.speedd));
          }
          foreach (Rebound rebound in layer.ReboundArray)
          {
            rebound.copys = rebound.Copy() as Rebound;
            float num1 = MathHelper.Lerp(-rebound.copys.rand.speed, rebound.copys.rand.speed, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
            int num2 = (int) MathHelper.Lerp(-rebound.copys.rand.speedd, rebound.copys.rand.speedd, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
            float num3 = MathHelper.Lerp(-rebound.copys.rand.aspeed, rebound.copys.rand.aspeed, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
            int num4 = (int) MathHelper.Lerp(-rebound.copys.rand.aspeedd, rebound.copys.rand.aspeedd, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
            rebound.copys.aspeed += num3;
            rebound.copys.aspeedd += (float) num4;
            rebound.copys.speed += num1;
            rebound.copys.speedd += (float) num2;
            rebound.copys.aspeedx = rebound.copys.aspeed * (float) Math.Cos((double) MathHelper.ToRadians(rebound.copys.aspeedd));
            rebound.copys.aspeedy = rebound.copys.aspeed * (float) Math.Sin((double) MathHelper.ToRadians(rebound.copys.aspeedd));
            rebound.copys.speedx = rebound.copys.speed * (float) Math.Cos((double) MathHelper.ToRadians(rebound.copys.speedd));
            rebound.copys.speedy = rebound.copys.speed * (float) Math.Sin((double) MathHelper.ToRadians(rebound.copys.speedd));
          }
          foreach (Force force in layer.ForceArray)
          {
            force.copys = force.Copy() as Force;
            float num1 = MathHelper.Lerp(-force.copys.rand.speed, force.copys.rand.speed, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
            int num2 = (int) MathHelper.Lerp(-force.copys.rand.speedd, force.copys.rand.speedd, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
            float num3 = MathHelper.Lerp(-force.copys.rand.aspeed, force.copys.rand.aspeed, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
            int num4 = (int) MathHelper.Lerp(-force.copys.rand.aspeedd, force.copys.rand.aspeedd, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
            force.copys.aspeed += num3;
            force.copys.aspeedd += (float) num4;
            force.copys.speed += num1;
            force.copys.speedd += (float) num2;
            force.copys.aspeedx = force.copys.aspeed * (float) Math.Cos((double) MathHelper.ToRadians(force.copys.aspeedd));
            force.copys.aspeedy = force.copys.aspeed * (float) Math.Sin((double) MathHelper.ToRadians(force.copys.aspeedd));
            force.copys.speedx = force.copys.speed * (float) Math.Cos((double) MathHelper.ToRadians(force.copys.speedd));
            force.copys.speedy = force.copys.speed * (float) Math.Sin((double) MathHelper.ToRadians(force.copys.speedd));
          }
        }
        foreach (GlobalEvent globalEvent in this.GE)
        {
          globalEvent.qtcount = 0;
          globalEvent.stcount = 0;
        }
        Time.stop = 1f;
        this.quake = new Vector2(0.0f, 0.0f);
      }
      else if (this.now > this.total && cs.effect)
        cs.Close();
      for (int index = 0; index < this.GE.Count; ++index)
      {
        if (index + 1 == this.now && this.GE[index].isgoto)
        {
          ++this.GE[index].gtcount;
          if (this.GE[index].gotowhere != 0 && (this.GE[index].gototime == 0 || this.GE[index].gtcount <= this.GE[index].gototime))
            this.now = this.GE[index].gotowhere;
        }
        if (this.GE[index].isquake && this.now >= index + 1)
        {
          ++this.GE[index].qtcount;
          if (this.GE[index].qtcount % 2 == 0 && (this.GE[index].quaketime == 0 || this.GE[index].qtcount <= this.GE[index].quaketime))
            this.quake = new Vector2(0.0f, (float) (1.0 - (double) this.GE[index].qtcount / (double) this.GE[index].quaketime) * (float) this.GE[index].quakelevel * (float) Math.Sin((double) this.GE[index].qtcount));
          Program.game.game.quake.X = this.quake.X;
          Program.game.game.quake.Y = this.quake.Y;
        }
        if (this.GE[index].isstop && this.now >= index + 1)
        {
          if (this.now == index + 1)
          {
            Program.game.game.PlaySound("kira", false, 0.0f);
            Program.game.game.PlaySound("slash", false, 0.0f);
          }
          ++this.GE[index].stcount;
          if (this.GE[index].stoptime == 0 || this.GE[index].stcount <= this.GE[index].stoptime)
          {
            if (this.GE[index].stoplevel == 0)
              Time.stop = (float) this.GE[index].stcount / (float) this.GE[index].stoptime * (float) this.GE[index].stcount / (float) this.GE[index].stoptime;
            else if (this.GE[index].stoplevel == 1)
              Time.stop = 0.0f;
          }
          else
            Time.stop = 1f;
        }
      }
    }
  }
}
