// Decompiled with JetBrains decompiler
// Type: THMHJ.Rebound
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace THMHJ
{
  [Serializable]
  public class Rebound
  {
    public bool NeedDelete;
    public int id;
    public int parentid;
    public float x;
    public float y;
    public int begin;
    public int life;
    public int longs;
    public int time;
    public float angle;
    public float speed;
    public float speedd;
    public float speedx;
    public float speedy;
    public Vector2 speedds;
    public float aspeed;
    public float aspeedx;
    public float aspeedy;
    public float aspeedd;
    public Vector2 aspeedds;
    public Rebound rand;
    public List<Event> Parentevents;
    public Rebound copys;

    public Rebound()
    {
    }

    public Rebound(float xs, float ys, LayerManager layerm)
    {
      this.rand = new Rebound();
      this.Parentevents = new List<Event>();
      this.x = xs;
      this.y = ys;
      this.begin = layerm.LayerArray[this.parentid].begin;
      this.life = layerm.LayerArray[this.parentid].end - layerm.LayerArray[this.parentid].begin + 1;
      this.longs = 100;
      this.time = 1;
      this.angle = 0.0f;
    }

    public void Update(
      LayerManager layerm,
      CrazyStorm cs,
      Time Times,
      Center Centers,
      Vector2 Player)
    {
      if (!(Times.now >= this.begin & Times.now <= this.begin + this.life - 1))
        return;
      int now = Times.now;
      this.speedx += this.aspeedx;
      this.speedy += this.aspeedy;
      this.x += this.speedx;
      this.y += this.speedy;
      float x1 = this.x - 4f;
      float y1 = this.y + 16f;
      float x2 = (float) ((double) this.x - 4.0 + (double) this.longs * Math.Cos((double) MathHelper.ToRadians(this.angle)));
      float y2 = (float) ((double) this.y + 16.0 + (double) this.longs * Math.Sin((double) MathHelper.ToRadians(this.angle)));
      Line line1 = new Line(new PointF(x1, y1), new PointF(x2, y2));
      foreach (Barrage barrage in layerm.LayerArray[this.parentid].Barrages)
      {
        if (barrage.Rebound && (barrage.time > 15 || !barrage.Mist) && !barrage.Dis)
        {
          float speedx = barrage.speedx;
          float speedy = barrage.speedy;
          float num1 = speedx + barrage.aspeedx;
          float num2 = speedy + barrage.aspeedy;
          float x3 = barrage.x;
          float y3 = barrage.y;
          float num3 = x3 + (num1 - this.speedx);
          float num4 = y3 + (num2 - this.speedy);
          float x4 = num3;
          float y4 = num4;
          float x5 = barrage.x;
          float y5 = barrage.y;
          Line line2 = new Line(new PointF(x4, y4), new PointF(x5, y5));
          if (((Main.CheckTwoLineCrose(line1, line2) ? 1 : 0) & (barrage.reboundtime < this.time ? 1 : (this.time == 0 ? 1 : 0))) != 0)
          {
            float num5 = (float) (((double) y2 - (double) y1) * ((double) x5 - (double) x4) - ((double) y5 - (double) y4) * ((double) x2 - (double) x1));
            float num6 = (float) (((double) x2 - (double) x1) * ((double) x5 - (double) x4) * ((double) y4 - (double) y1) + ((double) y2 - (double) y1) * ((double) x5 - (double) x4) * (double) x1 - ((double) y5 - (double) y4) * ((double) x2 - (double) x1) * (double) x4) / num5;
            float num7 = (float) ((((double) y2 - (double) y1) * ((double) y5 - (double) y4) * ((double) x4 - (double) x1) + ((double) x2 - (double) x1) * ((double) y5 - (double) y4) * (double) y1 - ((double) x5 - (double) x4) * ((double) y2 - (double) y1) * (double) y4) / -(double) num5);
            barrage.speedd = 2f * this.angle - barrage.speedd;
            float num8 = (float) (((double) num6 - (double) x4) * ((double) num6 - (double) x4) + ((double) num7 - (double) y4) * ((double) num7 - (double) y4));
            barrage.x = num6 + barrage.xscale * (float) (Math.Sqrt((double) num8) * Math.Cos((double) MathHelper.ToRadians(barrage.speedd)));
            barrage.y = num7 + barrage.yscale * (float) (Math.Sqrt((double) num8) * Math.Sin((double) MathHelper.ToRadians(barrage.speedd)));
            barrage.speedx = barrage.xscale * barrage.speed * (float) Math.Cos((double) MathHelper.ToRadians(barrage.speedd));
            barrage.speedy = barrage.yscale * barrage.speed * (float) Math.Sin((double) MathHelper.ToRadians(barrage.speedd));
            ++barrage.reboundtime;
            foreach (Event parentevent in this.Parentevents)
            {
              string str = "";
              string s = "";
              int num9 = 0;
              string tag = parentevent.tag;
              if (parentevent.tag.Contains("变化到"))
              {
                str = tag.Split("变化到".ToCharArray())[0];
                s = tag.Split("变化到".ToCharArray())[3].Split('+')[0];
                num9 = 1;
              }
              if (parentevent.tag.Contains("增加"))
              {
                str = tag.Split("增".ToCharArray())[0];
                s = tag.Split("增".ToCharArray())[1].Replace("加", "").Split('+')[0];
                num9 = 2;
              }
              if (parentevent.tag.Contains("减少"))
              {
                str = tag.Split("减少".ToCharArray())[0];
                s = tag.Split("减少".ToCharArray())[2].Split('+')[0];
                num9 = 3;
              }
              if (parentevent.tag.Contains("+"))
              {
                float num10 = float.Parse(parentevent.tag.Split('+')[1]);
                s = (float.Parse(s) + MathHelper.Lerp(-num10, num10, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb))).ToString();
              }
              if (str == "生命")
              {
                switch (num9)
                {
                  case 1:
                    barrage.life = (int) float.Parse(s);
                    break;
                  case 2:
                    barrage.life += (int) float.Parse(s);
                    break;
                  case 3:
                    barrage.life -= (int) float.Parse(s);
                    break;
                }
              }
              if (str == "类型")
              {
                switch (num9)
                {
                  case 1:
                    barrage.type = (int) float.Parse(s);
                    break;
                  case 2:
                    barrage.type += (int) float.Parse(s);
                    break;
                  case 3:
                    barrage.type -= (int) float.Parse(s);
                    break;
                }
              }
              if (str == "宽比")
              {
                switch (num9)
                {
                  case 1:
                    barrage.wscale = float.Parse(s);
                    break;
                  case 2:
                    barrage.wscale += float.Parse(s);
                    break;
                  case 3:
                    barrage.wscale -= float.Parse(s);
                    break;
                }
              }
              if (str == "高比")
              {
                switch (num9)
                {
                  case 1:
                    barrage.hscale = float.Parse(s);
                    break;
                  case 2:
                    barrage.hscale += float.Parse(s);
                    break;
                  case 3:
                    barrage.hscale -= float.Parse(s);
                    break;
                }
              }
              if (str == "R")
              {
                switch (num9)
                {
                  case 1:
                    barrage.R = float.Parse(s);
                    break;
                  case 2:
                    barrage.R += float.Parse(s);
                    break;
                  case 3:
                    barrage.R -= float.Parse(s);
                    break;
                }
              }
              if (str == "G")
              {
                switch (num9)
                {
                  case 1:
                    barrage.G = float.Parse(s);
                    break;
                  case 2:
                    barrage.G += float.Parse(s);
                    break;
                  case 3:
                    barrage.G -= float.Parse(s);
                    break;
                }
              }
              if (str == "B")
              {
                switch (num9)
                {
                  case 1:
                    barrage.B = float.Parse(s);
                    break;
                  case 2:
                    barrage.B += float.Parse(s);
                    break;
                  case 3:
                    barrage.B -= float.Parse(s);
                    break;
                }
              }
              if (str == "不透明度")
              {
                switch (num9)
                {
                  case 1:
                    barrage.alpha = float.Parse(s);
                    break;
                  case 2:
                    barrage.alpha += float.Parse(s);
                    break;
                  case 3:
                    barrage.alpha -= float.Parse(s);
                    break;
                }
              }
              if (str == "朝向")
              {
                switch (num9)
                {
                  case 1:
                    barrage.head = float.Parse(s);
                    break;
                  case 2:
                    barrage.head += float.Parse(s);
                    break;
                  case 3:
                    barrage.head -= float.Parse(s);
                    break;
                }
              }
              if (str == "子弹速度")
              {
                switch (num9)
                {
                  case 1:
                    barrage.speed = float.Parse(s);
                    break;
                  case 2:
                    barrage.speed += float.Parse(s);
                    break;
                  case 3:
                    barrage.speed -= float.Parse(s);
                    break;
                }
                barrage.speedx = barrage.xscale * barrage.speed * (float) Math.Cos((double) MathHelper.ToRadians(barrage.speedd));
                barrage.speedy = barrage.yscale * barrage.speed * (float) Math.Sin((double) MathHelper.ToRadians(barrage.speedd));
              }
              if (str == "子弹速度方向")
              {
                if (s.Contains("自机"))
                {
                  barrage.speedd = MathHelper.ToDegrees(Main.Twopointangle(Player.X, Player.Y, barrage.x, barrage.y));
                }
                else
                {
                  switch (num9)
                  {
                    case 1:
                      barrage.speedd = float.Parse(s);
                      break;
                    case 2:
                      barrage.speedd += float.Parse(s);
                      break;
                    case 3:
                      barrage.speedd -= float.Parse(s);
                      break;
                  }
                }
                barrage.speedx = barrage.xscale * barrage.speed * (float) Math.Cos((double) MathHelper.ToRadians(barrage.speedd));
                barrage.speedy = barrage.yscale * barrage.speed * (float) Math.Sin((double) MathHelper.ToRadians(barrage.speedd));
              }
              if (str == "子弹加速度")
              {
                switch (num9)
                {
                  case 1:
                    barrage.aspeed = float.Parse(s);
                    break;
                  case 2:
                    barrage.aspeed += float.Parse(s);
                    break;
                  case 3:
                    barrage.aspeed -= float.Parse(s);
                    break;
                }
                barrage.aspeedx = barrage.xscale * barrage.aspeed * (float) Math.Cos((double) MathHelper.ToRadians(barrage.aspeedd));
                barrage.aspeedy = barrage.yscale * barrage.aspeed * (float) Math.Sin((double) MathHelper.ToRadians(barrage.aspeedd));
              }
              if (str == "子弹加速度方向")
              {
                if (s.Contains("自机"))
                {
                  barrage.aspeedd = MathHelper.ToDegrees(Main.Twopointangle(Player.X, Player.Y, barrage.x, barrage.y));
                }
                else
                {
                  switch (num9)
                  {
                    case 1:
                      barrage.aspeedd = float.Parse(s);
                      break;
                    case 2:
                      barrage.aspeedd += float.Parse(s);
                      break;
                    case 3:
                      barrage.aspeedd -= float.Parse(s);
                      break;
                  }
                }
                barrage.aspeedx = barrage.xscale * barrage.aspeed * (float) Math.Cos((double) MathHelper.ToRadians(barrage.aspeedd));
                barrage.aspeedy = barrage.yscale * barrage.aspeed * (float) Math.Sin((double) MathHelper.ToRadians(barrage.aspeedd));
              }
              if (str == "横比")
              {
                switch (num9)
                {
                  case 1:
                    barrage.xscale = float.Parse(s);
                    break;
                  case 2:
                    barrage.xscale += float.Parse(s);
                    break;
                  case 3:
                    barrage.xscale -= float.Parse(s);
                    break;
                }
              }
              if (str == "纵比")
              {
                switch (num9)
                {
                  case 1:
                    barrage.yscale = float.Parse(s);
                    break;
                  case 2:
                    barrage.yscale += float.Parse(s);
                    break;
                  case 3:
                    barrage.yscale -= float.Parse(s);
                    break;
                }
              }
              if (str == "雾化效果")
                barrage.Mist = (int) float.Parse(s) > 0;
              if (str == "消除效果")
                barrage.Dispel = (int) float.Parse(s) > 0;
              if (str == "高光效果")
                barrage.Blend = (int) float.Parse(s) > 0;
              if (str == "拖影效果")
                barrage.Afterimage = (int) float.Parse(s) > 0;
              if (str == "出屏即消")
                barrage.Outdispel = (int) float.Parse(s) > 0;
              if (str == "无敌状态")
                barrage.Invincible = (int) float.Parse(s) > 0;
            }
          }
        }
      }
    }

    private double Rand(bool Ban, bool bomb)
    {
      if (!Ban)
        return Main.Rand(bomb);
      return Main.rand.NextDouble();
    }

    public Rebound Clone()
    {
      return this.Copy() as Rebound;
    }

    public object Copy()
    {
      return this.MemberwiseClone();
    }
  }
}
