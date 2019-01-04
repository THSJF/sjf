// Decompiled with JetBrains decompiler
// Type: THMHJ.Center
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace THMHJ
{
  public class Center
  {
    public List<string> events = new List<string>();
    public List<Event> Events = new List<Event>();
    public List<CExecution> Eventsexe = new List<CExecution>();
    public float ox;
    public float oy;
    public float ospeed;
    public float ospeedd;
    public float oaspeed;
    public float oaspeedd;
    public float speedx;
    public float speedy;
    public float aspeedx;
    public float aspeedy;
    public float x;
    public float y;
    public float speed;
    public float speedd;
    public float aspeed;
    public float aspeedd;
    public bool Available;
    public bool Aim;

    public Center()
    {
      this.x = 315f;
      this.y = 240f;
      this.speed = 0.0f;
      this.speedd = 0.0f;
      this.aspeed = 0.0f;
      this.aspeedd = 0.0f;
      this.ox = this.x;
      this.oy = this.y;
      this.ospeed = this.speed;
      this.ospeedd = this.speedd;
      this.oaspeed = this.aspeed;
      this.oaspeedd = this.aspeedd;
      this.speedx = 0.0f;
      this.speedy = 0.0f;
      this.aspeedx = 0.0f;
      this.aspeedy = 0.0f;
      this.events = new List<string>();
    }

    public void Update(CSManager csm, CrazyStorm cs, Time t, Character Player, Boss boss)
    {
      if (!this.Available)
        return;
      this.speedx += this.aspeedx;
      this.speedy += this.aspeedy;
      this.ox += this.speedx;
      this.ox += this.speedy;
      boss?.Setpos(boss.Position.X + this.speedx, boss.Position.Y + this.speedy);
      Hashtable hashtable1 = new Hashtable();
      Hashtable hashtable2 = new Hashtable();
      hashtable1.Add((object) "当前帧", (object) t.now);
      hashtable2.Add((object) "速度", (object) this.ospeed);
      hashtable2.Add((object) "速度方向", (object) this.ospeedd);
      hashtable2.Add((object) "加速度", (object) this.oaspeed);
      hashtable2.Add((object) "加速度方向", (object) this.oaspeedd);
      foreach (string str1 in this.events)
      {
        if (str1.Contains("PlayMusic"))
        {
          int num = int.Parse(str1.Split('=')[1].Split('：')[0]);
          if (t.now == num || num > t.total && t.times > 0 && t.now == num - t.total)
            Program.game.game.PlaySound(str1.Split('(')[1].Split(')')[0], true, this.x);
        }
        else if (str1.Contains("UseKira"))
          cs.usekira = true;
        else if (str1.Contains("BanSound"))
        {
          cs.bansoundbg = true;
        }
        else
        {
          string s = str1.Split('：')[0];
          string str2 = "";
          string str3 = "";
          string str4 = str1.Split('：')[1];
          int num1 = 0;
          string str5 = "";
          int num2 = 0;
          string str6 = "";
          float num3 = 0.0f;
          int num4 = 0;
          if (s.Contains("="))
          {
            str2 = s.Split('=')[0];
            str3 = "=";
            s = s.Split('=')[1];
          }
          if (str3 == "=" && (double) float.Parse(hashtable1[(object) str2].ToString()) == (double) float.Parse(s))
          {
            if (str1.Contains("变化到"))
            {
              num1 = 0;
              string[] strArray = str4.Split("变化到".ToCharArray())[3].Split("，".ToCharArray());
              num2 = (int) csm.results3[(object) str4.Split("变化到".ToCharArray())[0]];
              str6 = str4.Split("变化到".ToCharArray())[0];
              if (strArray[0].Contains<char>('+'))
                num3 = (float) ((double) float.Parse(strArray[0].Split('+')[0]) + (double) MathHelper.Lerp((float) -(double) float.Parse(strArray[0].Split('+')[1]), float.Parse(strArray[0].Split('+')[1]), (float) this.Rand(cs.effect && !cs.bomb, cs.bomb)));
              else
                num3 = num2 == 1 || num2 == 3 ? (!strArray[0].Contains("自机") ? float.Parse(strArray[0]) : MathHelper.ToDegrees(Main.Twopointangle(Player.body.position.X + 93f, Player.body.position.Y - 13f, this.ox, this.oy))) : float.Parse(strArray[0]);
              str5 = strArray[1];
              num4 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
            }
            else if (str1.Contains("增加"))
            {
              num1 = 1;
              string[] strArray = str4.Split("增".ToCharArray())[1].Split("，".ToCharArray());
              strArray[0] = strArray[0].Replace("加", "");
              num2 = (int) csm.results3[(object) str4.Split("增".ToCharArray())[0]];
              str6 = str4.Split("增".ToCharArray())[0];
              if (strArray[0].Contains<char>('+'))
                num3 = (float) ((double) float.Parse(strArray[0].Split('+')[0]) + (double) MathHelper.Lerp((float) -(double) float.Parse(strArray[0].Split('+')[1]), float.Parse(strArray[0].Split('+')[1]), (float) this.Rand(cs.effect && !cs.bomb, cs.bomb)));
              else
                num3 = num2 == 1 || num2 == 3 ? (!strArray[0].Contains("自机") ? float.Parse(strArray[0]) : MathHelper.ToDegrees(Main.Twopointangle(Player.body.position.X + 93f, Player.body.position.Y - 13f, this.ox, this.oy))) : float.Parse(strArray[0]);
              str5 = strArray[1];
              num4 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
            }
            else if (str1.Contains("减少"))
            {
              num1 = 2;
              string[] strArray = str4.Split("减少".ToCharArray())[2].Split("，".ToCharArray());
              num2 = (int) csm.results3[(object) str4.Split("减少".ToCharArray())[0]];
              str6 = str4.Split("减少".ToCharArray())[0];
              if (strArray[0].Contains<char>('+'))
                num3 = (float) ((double) float.Parse(strArray[0].Split('+')[0]) + (double) MathHelper.Lerp((float) -(double) float.Parse(strArray[0].Split('+')[1]), float.Parse(strArray[0].Split('+')[1]), (float) this.Rand(cs.effect && !cs.bomb, cs.bomb)));
              else
                num3 = num2 == 1 || num2 == 3 ? (!strArray[0].Contains("自机") ? float.Parse(strArray[0]) : MathHelper.ToDegrees(Main.Twopointangle(Player.body.position.X + 93f, Player.body.position.Y - 13f, this.ox, this.oy))) : float.Parse(strArray[0]);
              str5 = strArray[1];
              num4 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
            }
            if (str1.Contains("跟随自机"))
              this.Eventsexe.Add(new CExecution()
              {
                changetype = 3,
                ctime = 60
              });
            else if (str1.Contains("范围移动"))
            {
              this.Eventsexe.Add(new CExecution()
              {
                changetype = 4,
                ctime = 60,
                value = MathHelper.Lerp(float.Parse(str1.Split('，')[1]), float.Parse(str1.Split('，')[2]), (float) this.Rand(cs.effect && !cs.bomb, cs.bomb)),
                value2 = MathHelper.Lerp(float.Parse(str1.Split('，')[3]), float.Parse(str1.Split('，')[4]), (float) this.Rand(cs.effect && !cs.bomb, cs.bomb))
              });
            }
            else
            {
              CExecution cexecution = new CExecution()
              {
                change = num1,
                changetype = (int) csm.type[(object) str5],
                changevalue = num2,
                value = num3,
                region = hashtable2[(object) str6].ToString(),
                time = num4
              };
              cexecution.ctime = cexecution.time;
              this.Eventsexe.Add(cexecution);
            }
          }
        }
      }
      for (int index = 0; index < this.Eventsexe.Count; ++index)
      {
        if (!this.Eventsexe[index].NeedDelete)
        {
          this.Eventsexe[index].Update(this, Player, boss);
        }
        else
        {
          this.Eventsexe.RemoveAt(index);
          --index;
        }
      }
    }

    private double Rand(bool Ban, bool bomb)
    {
      if (!Ban)
        return Main.Rand(bomb);
      return Main.rand.NextDouble();
    }
  }
}
