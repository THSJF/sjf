// Decompiled with JetBrains decompiler
// Type: THMHJ.Batch
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace THMHJ
{
  [Serializable]
  public class Batch
  {
    public int bindid = -1;
    private float[] conditions = new float[13];
    private float[] results = new float[33];
    public bool NeedDelete;
    public int id;
    public int parentid;
    public bool Binding;
    public bool bansound;
    public bool Bindwithspeedd;
    public bool Deepbind;
    public bool Deepbinded;
    public float x;
    public float y;
    public int time;
    public int begin;
    public int life;
    public float fx;
    public float fy;
    public float r;
    public float rdirection;
    public Vector2 rdirections;
    public int tiao;
    public int t;
    public float fdirection;
    public float bfdirection;
    public Vector2 fdirections;
    public int range;
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
    public int sonlife;
    public float type;
    public float wscale;
    public float hscale;
    public float colorR;
    public float colorG;
    public float colorB;
    public float alpha;
    public float head;
    public Vector2 heads;
    public bool Withspeedd;
    public float sonspeed;
    public float sonspeedd;
    public Vector2 sonspeedds;
    public float sonaspeed;
    public float sonaspeedd;
    public float bsonaspeedd;
    public Vector2 sonaspeedds;
    public float xscale;
    public float yscale;
    public bool Mist;
    public bool Dispel;
    public bool Blend;
    public bool Afterimage;
    public bool Outdispel;
    public bool Invincible;
    public bool Cover;
    public bool Rebound;
    public bool Force;
    public Batch rand;
    public List<Event> Parentevents;
    public List<Execution> Eventsexe;
    public List<Event> Sonevents;
    public Batch copys;

    public Batch()
    {
    }

    public Batch(float xs, float ys, LayerManager layerm)
    {
      this.rand = new Batch();
      this.Parentevents = new List<Event>();
      this.Sonevents = new List<Event>();
      this.Eventsexe = new List<Execution>();
      this.x = xs;
      this.y = ys;
      this.begin = layerm.LayerArray[this.parentid].begin;
      this.life = layerm.LayerArray[this.parentid].end - layerm.LayerArray[this.parentid].begin + 1;
      this.fx = -99998f;
      this.fy = -99998f;
      this.r = 0.0f;
      this.rdirection = 0.0f;
      this.tiao = 1;
      this.t = 5;
      this.fdirection = 0.0f;
      this.range = 360;
      this.speed = 0.0f;
      this.speedd = 0.0f;
      this.aspeed = 0.0f;
      this.aspeedd = 0.0f;
      this.sonlife = 200;
      this.type = 1f;
      this.wscale = 1f;
      this.hscale = 1f;
      this.colorR = (float) byte.MaxValue;
      this.colorG = (float) byte.MaxValue;
      this.colorB = (float) byte.MaxValue;
      this.alpha = 100f;
      this.head = 0.0f;
      this.Withspeedd = true;
      this.sonspeed = 5f;
      this.sonspeedd = 0.0f;
      this.sonaspeed = 0.0f;
      this.sonaspeedd = 0.0f;
      this.xscale = 1f;
      this.yscale = 1f;
      this.Mist = true;
      this.Dispel = true;
      this.Blend = false;
      this.Afterimage = false;
      this.Outdispel = true;
      this.Invincible = false;
      this.Cover = true;
      this.Rebound = true;
      this.Force = true;
    }

    public void Update(
      LayerManager layerm,
      CrazyStorm cs,
      Time Times,
      Center Centers,
      Vector2 Player)
    {
      if (this.bindid == this.id)
      {
        this.bindid = -1;
        this.Deepbind = false;
        this.Bindwithspeedd = false;
      }
      if (this.bindid != -1 && this.bindid >= layerm.LayerArray[this.parentid].BatchArray.Count)
      {
        this.bindid = -1;
        this.Deepbind = false;
        this.Bindwithspeedd = false;
      }
      if (this.Deepbinded)
        ++this.time;
      if (!(!this.Deepbinded & Times.now >= this.begin & Times.now <= this.begin + this.life - 1) && !(this.Deepbinded & this.time >= this.begin & this.time <= this.begin + this.life - 1) && !this.Deepbind)
        return;
      if (!this.Deepbind & !this.Deepbinded)
        this.time = Times.now - this.begin + 1;
      if (!this.Deepbind)
      {
        this.speedx += this.aspeedx;
        this.speedy += this.aspeedy;
        this.x += this.speedx;
        this.y += this.speedy;
        this.fx += this.speedx;
        this.fy += this.speedy;
        this.conditions[0] = !this.Deepbinded ? (float) this.time : (float) (this.time - this.begin + 1);
        this.conditions[1] = this.fx;
        this.conditions[2] = this.fy;
        this.conditions[3] = this.r;
        this.conditions[4] = this.rdirection;
        this.conditions[5] = (float) this.tiao;
        this.conditions[6] = (float) this.t;
        this.conditions[7] = this.fdirection;
        this.conditions[8] = (float) this.range;
        this.conditions[9] = this.wscale;
        this.conditions[10] = this.hscale;
        this.conditions[11] = this.alpha;
        this.conditions[12] = this.head;
        this.results[0] = this.fx;
        this.results[1] = this.fy;
        this.results[2] = this.r;
        this.results[3] = this.rdirection;
        this.results[4] = (float) this.tiao;
        this.results[5] = (float) this.t;
        this.results[6] = this.fdirection;
        this.results[7] = (float) this.range;
        this.results[8] = this.speed;
        this.results[9] = this.speedd;
        this.results[10] = this.aspeed;
        this.results[11] = this.aspeedd;
        this.results[12] = (float) this.life;
        this.results[13] = this.type;
        this.results[14] = this.wscale;
        this.results[15] = this.hscale;
        this.results[16] = this.colorR;
        this.results[17] = this.colorG;
        this.results[18] = this.colorB;
        this.results[19] = this.alpha;
        this.results[20] = this.head;
        this.results[21] = this.sonspeed;
        this.results[22] = this.sonspeedd;
        this.results[23] = this.sonaspeed;
        this.results[24] = this.sonaspeedd;
        this.results[25] = this.xscale;
        this.results[26] = this.yscale;
        this.results[27] = 0.0f;
        this.results[28] = 0.0f;
        this.results[29] = 0.0f;
        this.results[30] = 0.0f;
        this.results[31] = 0.0f;
        this.results[32] = 0.0f;
        foreach (Event parentevent in this.Parentevents)
        {
          if (parentevent.t <= 0)
            parentevent.t = 1;
          if (this.time % parentevent.t == 0)
            ++parentevent.loop;
          foreach (EventRead result in parentevent.results)
          {
            if (result.special == 3)
            {
              if (result.changevalue == 0)
                result.res = this.x - 4f + Centers.ox - Centers.x;
              if (result.changevalue == 1)
                result.res = this.y + 16f + Centers.oy - Centers.y;
              if (result.changevalue == 6)
                result.res = MathHelper.ToDegrees(Main.Twopointangle(this.x - 4f + Centers.ox - Centers.x, this.y + 16f + Centers.oy - Centers.y, this.fx + Centers.ox - Centers.x, this.fy + Centers.oy - Centers.y));
              if (result.changevalue == 24)
                result.res = MathHelper.ToDegrees(Main.Twopointangle(this.x - 4f + Centers.ox - Centers.x, this.y + 16f + Centers.oy - Centers.y, this.fx + Centers.ox - Centers.x, this.fy + Centers.oy - Centers.y));
            }
            if (result.special == 4)
            {
              float degrees = MathHelper.ToDegrees(Main.Twopointangle(Player.X, Player.Y, this.fx + Centers.ox - Centers.x, this.fy + Centers.oy - Centers.y));
              if (result.changevalue == 0)
                result.res = Player.X;
              if (result.changevalue == 1)
                result.res = Player.Y;
              if (result.changevalue == 3)
                result.res = degrees;
              if (result.changevalue == 6)
                result.res = degrees;
              if (result.changevalue == 9)
                result.res = degrees;
              if (result.changevalue == 11)
                result.res = degrees;
              if (result.changevalue == 24)
                result.res = degrees;
            }
            if (result.opreator == ">")
            {
              if (result.opreator2 == ">")
              {
                if (result.collector == "且")
                {
                  if ((double) this.conditions[result.contype] > (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) & (double) this.conditions[result.contype2] > (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime))
                  {
                    if (result.special == 1)
                      this.Recover(layerm);
                    else if (result.special == 2)
                    {
                      this.Shoot(layerm, cs, Times, Centers, Player);
                    }
                    else
                    {
                      Execution execution = new Execution();
                      if (!result.noloop)
                      {
                        if (result.time > 0)
                        {
                          --result.time;
                          if (result.time == 0)
                            result.noloop = true;
                        }
                        execution.parentid = this.parentid;
                        execution.id = this.id;
                        execution.change = result.change;
                        execution.changetype = result.changetype;
                        execution.changevalue = result.changevalue;
                        execution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                        execution.region = this.results[result.changename].ToString();
                        execution.time = result.times;
                        execution.ctime = execution.time;
                        this.Eventsexe.Add(execution);
                      }
                      else
                        continue;
                    }
                  }
                }
                else if (result.collector == "或" && ((double) this.conditions[result.contype] > (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) || (double) this.conditions[result.contype2] > (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime)))
                {
                  if (result.special == 1)
                    this.Recover(layerm);
                  else if (result.special == 2)
                  {
                    this.Shoot(layerm, cs, Times, Centers, Player);
                  }
                  else
                  {
                    Execution execution = new Execution();
                    if (!result.noloop)
                    {
                      if (result.time > 0)
                      {
                        --result.time;
                        if (result.time == 0)
                          result.noloop = true;
                      }
                      execution.parentid = this.parentid;
                      execution.id = this.id;
                      execution.change = result.change;
                      execution.changetype = result.changetype;
                      execution.changevalue = result.changevalue;
                      execution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                      execution.region = this.results[result.changename].ToString();
                      execution.time = result.times;
                      execution.ctime = execution.time;
                      this.Eventsexe.Add(execution);
                    }
                    else
                      continue;
                  }
                }
              }
              else if (result.opreator2 == "=")
              {
                if (result.collector == "且")
                {
                  if ((double) this.conditions[result.contype] > (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) & (double) this.conditions[result.contype2] == (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime))
                  {
                    if (result.special == 1)
                      this.Recover(layerm);
                    else if (result.special == 2)
                    {
                      this.Shoot(layerm, cs, Times, Centers, Player);
                    }
                    else
                    {
                      Execution execution = new Execution();
                      if (!result.noloop)
                      {
                        if (result.time > 0)
                        {
                          --result.time;
                          if (result.time == 0)
                            result.noloop = true;
                        }
                        execution.parentid = this.parentid;
                        execution.id = this.id;
                        execution.change = result.change;
                        execution.changetype = result.changetype;
                        execution.changevalue = result.changevalue;
                        execution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                        execution.region = this.results[result.changename].ToString();
                        execution.time = result.times;
                        execution.ctime = execution.time;
                        this.Eventsexe.Add(execution);
                      }
                      else
                        continue;
                    }
                  }
                }
                else if (result.collector == "或" && ((double) this.conditions[result.contype] > (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) || (double) this.conditions[result.contype2] == (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime)))
                {
                  if (result.special == 1)
                    this.Recover(layerm);
                  else if (result.special == 2)
                  {
                    this.Shoot(layerm, cs, Times, Centers, Player);
                  }
                  else
                  {
                    Execution execution = new Execution();
                    if (!result.noloop)
                    {
                      if (result.time > 0)
                      {
                        --result.time;
                        if (result.time == 0)
                          result.noloop = true;
                      }
                      execution.parentid = this.parentid;
                      execution.id = this.id;
                      execution.change = result.change;
                      execution.changetype = result.changetype;
                      execution.changevalue = result.changevalue;
                      execution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                      execution.region = this.results[result.changename].ToString();
                      execution.time = result.times;
                      execution.ctime = execution.time;
                      this.Eventsexe.Add(execution);
                    }
                    else
                      continue;
                  }
                }
              }
              else if (result.opreator2 == "<")
              {
                if (result.collector == "且")
                {
                  if ((double) this.conditions[result.contype] > (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) & (double) this.conditions[result.contype2] < (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime))
                  {
                    if (result.special == 1)
                      this.Recover(layerm);
                    else if (result.special == 2)
                    {
                      this.Shoot(layerm, cs, Times, Centers, Player);
                    }
                    else
                    {
                      Execution execution = new Execution();
                      if (!result.noloop)
                      {
                        if (result.time > 0)
                        {
                          --result.time;
                          if (result.time == 0)
                            result.noloop = true;
                        }
                        execution.parentid = this.parentid;
                        execution.id = this.id;
                        execution.change = result.change;
                        execution.changetype = result.changetype;
                        execution.changevalue = result.changevalue;
                        execution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                        execution.region = this.results[result.changename].ToString();
                        execution.time = result.times;
                        execution.ctime = execution.time;
                        this.Eventsexe.Add(execution);
                      }
                      else
                        continue;
                    }
                  }
                }
                else if (result.collector == "或" && ((double) this.conditions[result.contype] > (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) || (double) this.conditions[result.contype2] < (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime)))
                {
                  if (result.special == 1)
                    this.Recover(layerm);
                  else if (result.special == 2)
                  {
                    this.Shoot(layerm, cs, Times, Centers, Player);
                  }
                  else
                  {
                    Execution execution = new Execution();
                    if (!result.noloop)
                    {
                      if (result.time > 0)
                      {
                        --result.time;
                        if (result.time == 0)
                          result.noloop = true;
                      }
                      execution.parentid = this.parentid;
                      execution.id = this.id;
                      execution.change = result.change;
                      execution.changetype = result.changetype;
                      execution.changevalue = result.changevalue;
                      execution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                      execution.region = this.results[result.changename].ToString();
                      execution.time = result.times;
                      execution.ctime = execution.time;
                      this.Eventsexe.Add(execution);
                    }
                    else
                      continue;
                  }
                }
              }
              else if ((double) this.conditions[result.contype] > (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime))
              {
                if (result.special == 1)
                  this.Recover(layerm);
                else if (result.special == 2)
                {
                  this.Shoot(layerm, cs, Times, Centers, Player);
                }
                else
                {
                  Execution execution = new Execution();
                  if (!result.noloop)
                  {
                    if (result.time > 0)
                    {
                      --result.time;
                      if (result.time == 0)
                        result.noloop = true;
                    }
                    execution.parentid = this.parentid;
                    execution.id = this.id;
                    execution.change = result.change;
                    execution.changetype = result.changetype;
                    execution.changevalue = result.changevalue;
                    execution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                    execution.region = this.results[result.changename].ToString();
                    execution.time = result.times;
                    execution.ctime = execution.time;
                    this.Eventsexe.Add(execution);
                  }
                  else
                    continue;
                }
              }
            }
            if (result.opreator == "=")
            {
              if (result.opreator2 == ">")
              {
                if (result.collector == "且")
                {
                  if ((double) this.conditions[result.contype] == (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) & (double) this.conditions[result.contype2] > (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime))
                  {
                    if (result.special == 1)
                      this.Recover(layerm);
                    else if (result.special == 2)
                    {
                      this.Shoot(layerm, cs, Times, Centers, Player);
                    }
                    else
                    {
                      Execution execution = new Execution();
                      if (!result.noloop)
                      {
                        if (result.time > 0)
                        {
                          --result.time;
                          if (result.time == 0)
                            result.noloop = true;
                        }
                        execution.parentid = this.parentid;
                        execution.id = this.id;
                        execution.change = result.change;
                        execution.changetype = result.changetype;
                        execution.changevalue = result.changevalue;
                        execution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                        execution.region = this.results[result.changename].ToString();
                        execution.time = result.times;
                        execution.ctime = execution.time;
                        this.Eventsexe.Add(execution);
                      }
                      else
                        continue;
                    }
                  }
                }
                else if (result.collector == "或" && ((double) this.conditions[result.contype] == (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) || (double) this.conditions[result.contype2] > (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime)))
                {
                  if (result.special == 1)
                    this.Recover(layerm);
                  else if (result.special == 2)
                  {
                    this.Shoot(layerm, cs, Times, Centers, Player);
                  }
                  else
                  {
                    Execution execution = new Execution();
                    if (!result.noloop)
                    {
                      if (result.time > 0)
                      {
                        --result.time;
                        if (result.time == 0)
                          result.noloop = true;
                      }
                      execution.parentid = this.parentid;
                      execution.id = this.id;
                      execution.change = result.change;
                      execution.changetype = result.changetype;
                      execution.changevalue = result.changevalue;
                      execution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                      execution.region = this.results[result.changename].ToString();
                      execution.time = result.times;
                      execution.ctime = execution.time;
                      this.Eventsexe.Add(execution);
                    }
                    else
                      continue;
                  }
                }
              }
              else if (result.opreator2 == "=")
              {
                if (result.collector == "且")
                {
                  if ((double) this.conditions[result.contype] == (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) & (double) this.conditions[result.contype2] == (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime))
                  {
                    if (result.special == 1)
                      this.Recover(layerm);
                    else if (result.special == 2)
                    {
                      this.Shoot(layerm, cs, Times, Centers, Player);
                    }
                    else
                    {
                      Execution execution = new Execution();
                      if (!result.noloop)
                      {
                        if (result.time > 0)
                        {
                          --result.time;
                          if (result.time == 0)
                            result.noloop = true;
                        }
                        execution.parentid = this.parentid;
                        execution.id = this.id;
                        execution.change = result.change;
                        execution.changetype = result.changetype;
                        execution.changevalue = result.changevalue;
                        execution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                        execution.region = this.results[result.changename].ToString();
                        execution.time = result.times;
                        execution.ctime = execution.time;
                        this.Eventsexe.Add(execution);
                      }
                      else
                        continue;
                    }
                  }
                }
                else if (result.collector == "或" && ((double) this.conditions[result.contype] == (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) || (double) this.conditions[result.contype2] == (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime)))
                {
                  if (result.special == 1)
                    this.Recover(layerm);
                  else if (result.special == 2)
                  {
                    this.Shoot(layerm, cs, Times, Centers, Player);
                  }
                  else
                  {
                    Execution execution = new Execution();
                    if (!result.noloop)
                    {
                      if (result.time > 0)
                      {
                        --result.time;
                        if (result.time == 0)
                          result.noloop = true;
                      }
                      execution.parentid = this.parentid;
                      execution.id = this.id;
                      execution.change = result.change;
                      execution.changetype = result.changetype;
                      execution.changevalue = result.changevalue;
                      execution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                      execution.region = this.results[result.changename].ToString();
                      execution.time = result.times;
                      execution.ctime = execution.time;
                      this.Eventsexe.Add(execution);
                    }
                    else
                      continue;
                  }
                }
              }
              else if (result.opreator2 == "<")
              {
                if (result.collector == "且")
                {
                  if ((double) this.conditions[result.contype] == (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) & (double) this.conditions[result.contype2] < (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime))
                  {
                    if (result.special == 1)
                      this.Recover(layerm);
                    else if (result.special == 2)
                    {
                      this.Shoot(layerm, cs, Times, Centers, Player);
                    }
                    else
                    {
                      Execution execution = new Execution();
                      if (!result.noloop)
                      {
                        if (result.time > 0)
                        {
                          --result.time;
                          if (result.time == 0)
                            result.noloop = true;
                        }
                        execution.parentid = this.parentid;
                        execution.id = this.id;
                        execution.change = result.change;
                        execution.changetype = result.changetype;
                        execution.changevalue = result.changevalue;
                        execution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                        execution.region = this.results[result.changename].ToString();
                        execution.time = result.times;
                        execution.ctime = execution.time;
                        this.Eventsexe.Add(execution);
                      }
                      else
                        continue;
                    }
                  }
                }
                else if (result.collector == "或" && ((double) this.conditions[result.contype] == (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) || (double) this.conditions[result.contype2] < (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime)))
                {
                  if (result.special == 1)
                    this.Recover(layerm);
                  else if (result.special == 2)
                  {
                    this.Shoot(layerm, cs, Times, Centers, Player);
                  }
                  else
                  {
                    Execution execution = new Execution();
                    if (!result.noloop)
                    {
                      if (result.time > 0)
                      {
                        --result.time;
                        if (result.time == 0)
                          result.noloop = true;
                      }
                      execution.parentid = this.parentid;
                      execution.id = this.id;
                      execution.change = result.change;
                      execution.changetype = result.changetype;
                      execution.changevalue = result.changevalue;
                      execution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                      execution.region = this.results[result.changename].ToString();
                      execution.time = result.times;
                      execution.ctime = execution.time;
                      this.Eventsexe.Add(execution);
                    }
                    else
                      continue;
                  }
                }
              }
              else if ((double) this.conditions[result.contype] == (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime))
              {
                if (result.special == 1)
                  this.Recover(layerm);
                else if (result.special == 2)
                {
                  this.Shoot(layerm, cs, Times, Centers, Player);
                }
                else
                {
                  Execution execution = new Execution();
                  if (!result.noloop)
                  {
                    if (result.time > 0)
                    {
                      --result.time;
                      if (result.time == 0)
                        result.noloop = true;
                    }
                    execution.parentid = this.parentid;
                    execution.id = this.id;
                    execution.change = result.change;
                    execution.changetype = result.changetype;
                    execution.changevalue = result.changevalue;
                    execution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                    execution.region = this.results[result.changename].ToString();
                    execution.time = result.times;
                    execution.ctime = execution.time;
                    this.Eventsexe.Add(execution);
                  }
                  else
                    continue;
                }
              }
            }
            if (result.opreator == "<")
            {
              if (result.opreator2 == ">")
              {
                if (result.collector == "且")
                {
                  if ((double) this.conditions[result.contype] < (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) & (double) this.conditions[result.contype2] > (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime))
                  {
                    if (result.special == 1)
                      this.Recover(layerm);
                    else if (result.special == 2)
                    {
                      this.Shoot(layerm, cs, Times, Centers, Player);
                    }
                    else
                    {
                      Execution execution = new Execution();
                      if (!result.noloop)
                      {
                        if (result.time > 0)
                        {
                          --result.time;
                          if (result.time == 0)
                            result.noloop = true;
                        }
                        execution.parentid = this.parentid;
                        execution.id = this.id;
                        execution.change = result.change;
                        execution.changetype = result.changetype;
                        execution.changevalue = result.changevalue;
                        execution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                        execution.region = this.results[result.changename].ToString();
                        execution.time = result.times;
                        execution.ctime = execution.time;
                        this.Eventsexe.Add(execution);
                      }
                    }
                  }
                }
                else if (result.collector == "或" && ((double) this.conditions[result.contype] < (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) || (double) this.conditions[result.contype2] > (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime)))
                {
                  if (result.special == 1)
                    this.Recover(layerm);
                  else if (result.special == 2)
                  {
                    this.Shoot(layerm, cs, Times, Centers, Player);
                  }
                  else
                  {
                    Execution execution = new Execution();
                    if (!result.noloop)
                    {
                      if (result.time > 0)
                      {
                        --result.time;
                        if (result.time == 0)
                          result.noloop = true;
                      }
                      execution.parentid = this.parentid;
                      execution.id = this.id;
                      execution.change = result.change;
                      execution.changetype = result.changetype;
                      execution.changevalue = result.changevalue;
                      execution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                      execution.region = this.results[result.changename].ToString();
                      execution.time = result.times;
                      execution.ctime = execution.time;
                      this.Eventsexe.Add(execution);
                    }
                  }
                }
              }
              else if (result.opreator2 == "=")
              {
                if (result.collector == "且")
                {
                  if ((double) this.conditions[result.contype] < (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) & (double) this.conditions[result.contype2] == (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime))
                  {
                    if (result.special == 1)
                      this.Recover(layerm);
                    else if (result.special == 2)
                    {
                      this.Shoot(layerm, cs, Times, Centers, Player);
                    }
                    else
                    {
                      Execution execution = new Execution();
                      if (!result.noloop)
                      {
                        if (result.time > 0)
                        {
                          --result.time;
                          if (result.time == 0)
                            result.noloop = true;
                        }
                        execution.parentid = this.parentid;
                        execution.id = this.id;
                        execution.change = result.change;
                        execution.changetype = result.changetype;
                        execution.changevalue = result.changevalue;
                        execution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                        execution.region = this.results[result.changename].ToString();
                        execution.time = result.times;
                        execution.ctime = execution.time;
                        this.Eventsexe.Add(execution);
                      }
                    }
                  }
                }
                else if (result.collector == "或" && ((double) this.conditions[result.contype] < (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) || (double) this.conditions[result.contype2] == (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime)))
                {
                  if (result.special == 1)
                    this.Recover(layerm);
                  else if (result.special == 2)
                  {
                    this.Shoot(layerm, cs, Times, Centers, Player);
                  }
                  else
                  {
                    Execution execution = new Execution();
                    if (!result.noloop)
                    {
                      if (result.time > 0)
                      {
                        --result.time;
                        if (result.time == 0)
                          result.noloop = true;
                      }
                      execution.parentid = this.parentid;
                      execution.id = this.id;
                      execution.change = result.change;
                      execution.changetype = result.changetype;
                      execution.changevalue = result.changevalue;
                      execution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                      execution.region = this.results[result.changename].ToString();
                      execution.time = result.times;
                      execution.ctime = execution.time;
                      this.Eventsexe.Add(execution);
                    }
                  }
                }
              }
              else if (result.opreator2 == "<")
              {
                if (result.collector == "且")
                {
                  if ((double) this.conditions[result.contype] < (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) & (double) this.conditions[result.contype2] < (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime))
                  {
                    if (result.special == 1)
                      this.Recover(layerm);
                    else if (result.special == 2)
                    {
                      this.Shoot(layerm, cs, Times, Centers, Player);
                    }
                    else
                    {
                      Execution execution = new Execution();
                      if (!result.noloop)
                      {
                        if (result.time > 0)
                        {
                          --result.time;
                          if (result.time == 0)
                            result.noloop = true;
                        }
                        execution.parentid = this.parentid;
                        execution.id = this.id;
                        execution.change = result.change;
                        execution.changetype = result.changetype;
                        execution.changevalue = result.changevalue;
                        execution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                        execution.region = this.results[result.changename].ToString();
                        execution.time = result.times;
                        execution.ctime = execution.time;
                        this.Eventsexe.Add(execution);
                      }
                    }
                  }
                }
                else if (result.collector == "或" && ((double) this.conditions[result.contype] < (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime) || (double) this.conditions[result.contype2] < (double) float.Parse(result.condition2) + (double) (parentevent.loop * parentevent.addtime)))
                {
                  if (result.special == 1)
                    this.Recover(layerm);
                  else if (result.special == 2)
                  {
                    this.Shoot(layerm, cs, Times, Centers, Player);
                  }
                  else
                  {
                    Execution execution = new Execution();
                    if (!result.noloop)
                    {
                      if (result.time > 0)
                      {
                        --result.time;
                        if (result.time == 0)
                          result.noloop = true;
                      }
                      execution.parentid = this.parentid;
                      execution.id = this.id;
                      execution.change = result.change;
                      execution.changetype = result.changetype;
                      execution.changevalue = result.changevalue;
                      execution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                      execution.region = this.results[result.changename].ToString();
                      execution.time = result.times;
                      execution.ctime = execution.time;
                      this.Eventsexe.Add(execution);
                    }
                  }
                }
              }
              else if ((double) this.conditions[result.contype] < (double) float.Parse(result.condition) + (double) (parentevent.loop * parentevent.addtime))
              {
                if (result.special == 1)
                  this.Recover(layerm);
                else if (result.special == 2)
                {
                  this.Shoot(layerm, cs, Times, Centers, Player);
                }
                else
                {
                  Execution execution = new Execution();
                  if (!result.noloop)
                  {
                    if (result.time > 0)
                    {
                      --result.time;
                      if (result.time == 0)
                        result.noloop = true;
                    }
                    execution.parentid = this.parentid;
                    execution.id = this.id;
                    execution.change = result.change;
                    execution.changetype = result.changetype;
                    execution.changevalue = result.changevalue;
                    execution.value = (double) result.rand == 0.0 ? result.res : result.res + MathHelper.Lerp(-result.rand, result.rand, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
                    execution.region = this.results[result.changename].ToString();
                    execution.time = result.times;
                    execution.ctime = execution.time;
                    this.Eventsexe.Add(execution);
                  }
                }
              }
            }
          }
        }
        for (int index = 0; index < this.Eventsexe.Count; ++index)
        {
          if (!this.Eventsexe[index].NeedDelete)
          {
            this.Eventsexe[index].Update(this);
          }
          else
          {
            this.Eventsexe.RemoveAt(index);
            --index;
          }
        }
      }
      int num = 0;
      if (this.rand.t != 0)
        num = (int) MathHelper.Lerp((float) -this.rand.t, (float) this.rand.t, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
      if (this.t <= 0)
        return;
      if (this.Deepbind)
      {
        this.Shoot(layerm, cs, Times, Centers, Player);
      }
      else
      {
        if (this.time % this.t + num != 0)
          return;
        this.Shoot(layerm, cs, Times, Centers, Player);
      }
    }

    private void Shoot(
      LayerManager layerm,
      CrazyStorm cs,
      Time Times,
      Center Centers,
      Vector2 Player)
    {
      int tiao = this.tiao;
      int num1 = 0;
      int num2 = 0;
      float num3 = 0.0f;
      float num4 = 0.0f;
      float num5 = 0.0f;
      float num6 = 0.0f;
      float num7 = 0.0f;
      float num8 = 0.0f;
      float num9 = 0.0f;
      float num10 = 0.0f;
      float val1 = 0.0f;
      float val2 = 0.0f;
      if (this.rand.tiao != 0)
        tiao += (int) MathHelper.Lerp((float) -this.rand.tiao, (float) this.rand.tiao, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
      if ((double) this.rand.fx != 0.0)
        num3 = (float) (int) MathHelper.Lerp(-this.rand.fx, this.rand.fx, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
      if ((double) this.rand.fy != 0.0)
        num4 = (float) (int) MathHelper.Lerp(-this.rand.fy, this.rand.fy, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
      if ((double) this.rand.r != 0.0)
        num1 = (int) MathHelper.Lerp(-this.rand.r, this.rand.r, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
      if ((double) this.rand.rdirection != 0.0)
        num5 = MathHelper.Lerp(-this.rand.rdirection, this.rand.rdirection, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
      if ((double) this.rand.head != 0.0)
        num6 = (float) (int) MathHelper.Lerp(-this.rand.head, this.rand.head, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
      if (this.rand.range != 0)
        num2 = (int) MathHelper.Lerp((float) -this.rand.range, (float) this.rand.range, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
      if ((double) this.rand.sonspeed != 0.0)
        num7 = MathHelper.Lerp(-this.rand.sonspeed, this.rand.sonspeed, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
      if ((double) this.rand.fdirection != 0.0)
        num8 = MathHelper.Lerp(-this.rand.fdirection, this.rand.fdirection, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
      if ((double) this.rand.sonaspeed != 0.0)
        num9 = MathHelper.Lerp(-this.rand.sonaspeed, this.rand.sonaspeed, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
      if ((double) this.rand.sonaspeedd != 0.0)
        num10 = MathHelper.Lerp(-this.rand.sonaspeedd, this.rand.sonaspeedd, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
      if ((double) this.rand.wscale != 0.0)
        val1 = MathHelper.Lerp(-this.rand.wscale, this.rand.wscale, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
      if ((double) this.rand.hscale != 0.0)
        val2 = MathHelper.Lerp(-this.rand.hscale, this.rand.hscale, (float) this.Rand(cs.effect && !cs.bomb, cs.bomb));
      if (this.bindid == -1)
      {
        for (int index1 = 0; index1 < tiao; ++index1)
        {
          Barrage barrage = new Barrage();
          barrage.shoot = cs.shoot;
          if ((double) layerm.LayerArray[this.parentid].BatchArray[this.id].rdirection == -99999.0)
            this.rdirection = MathHelper.ToDegrees(Main.Twopointangle(Player.X, Player.Y, this.fx + Centers.ox - Centers.x, this.fy + Centers.oy - Centers.y));
          float degrees = this.rdirection + ((float) index1 - (float) (((double) tiao - 1.0) / 2.0)) * (float) (this.range + num2) / (float) tiao + num5;
          barrage.x = this.fx + (float) (((double) this.r + (double) num1) * Math.Cos((double) MathHelper.ToRadians(degrees))) + num3 + Centers.ox - Centers.x;
          barrage.y = this.fy + (float) (((double) this.r + (double) num1) * Math.Sin((double) MathHelper.ToRadians(degrees))) + num4 + Centers.oy - Centers.y;
          barrage.life = this.sonlife;
          barrage.type = (int) this.type - 1;
          barrage.wscale = this.wscale + Math.Max(val1, val2);
          barrage.hscale = this.hscale + Math.Max(val1, val2);
          barrage.head = this.head + num6;
          barrage.alpha = this.alpha;
          barrage.R = this.colorR;
          barrage.G = this.colorG;
          barrage.B = this.colorB;
          barrage.speed = this.sonspeed + num7;
          barrage.aspeed = this.sonaspeed + num9;
          barrage.fx = this.x - 4f;
          barrage.fy = this.y + 16f;
          barrage.fdirection = (double) this.bfdirection < -99997.0 ? this.bfdirection : this.fdirection;
          barrage.fdirections = this.fdirections;
          barrage.randfdirection = num8;
          barrage.g = index1;
          barrage.tiaos = tiao;
          barrage.range = this.range;
          barrage.randrange = num2;
          barrage.sonaspeedd = (double) this.bsonaspeedd < -99997.0 ? this.bsonaspeedd : this.sonaspeedd;
          barrage.sonaspeedds = this.sonaspeedds;
          barrage.randsonaspeedd = num10;
          barrage.Withspeedd = this.Withspeedd;
          barrage.xscale = this.xscale;
          barrage.yscale = this.yscale;
          barrage.Mist = this.Mist;
          barrage.Dispel = this.Dispel;
          barrage.Blend = this.Blend;
          barrage.Outdispel = this.Outdispel;
          barrage.Afterimage = this.Afterimage;
          barrage.Invincible = this.Invincible;
          barrage.Cover = this.Cover;
          barrage.Rebound = this.Rebound;
          barrage.Force = this.Force;
          for (int idx = 0; idx < this.Sonevents.Count; ++idx)
          {
            Event @event = new Event(idx);
            @event.t = this.Sonevents[idx].t;
            @event.addtime = this.Sonevents[idx].addtime;
            @event.events = this.Sonevents[idx].events;
            for (int index2 = 0; index2 < this.Sonevents[idx].results.Count; ++index2)
              @event.results.Add((EventRead) this.Sonevents[idx].results[index2].Copy());
            @event.index = this.Sonevents[idx].index;
            barrage.Events.Add(@event);
          }
          barrage.parentid = this.id;
          layerm.LayerArray[this.parentid].Barrages.Add(barrage);
        }
      }
      else
      {
        for (int index1 = 0; index1 < layerm.LayerArray[this.parentid].Barrages.Count; ++index1)
        {
          if (((!layerm.LayerArray[this.parentid].Barrages[index1].IsLase & layerm.LayerArray[this.parentid].Barrages[index1].parentid == this.bindid ? 1 : 0) & (layerm.LayerArray[this.parentid].Barrages[index1].time > 15 ? 1 : (!layerm.LayerArray[this.parentid].Barrages[index1].Mist ? 1 : 0)) & (!layerm.LayerArray[this.parentid].Barrages[index1].NeedDelete ? 1 : 0)) != 0)
          {
            if (this.Deepbind)
            {
              if (layerm.LayerArray[this.parentid].Barrages[index1].batch != null)
              {
                layerm.LayerArray[this.parentid].Barrages[index1].batch.x = layerm.LayerArray[this.parentid].Barrages[index1].x - (Centers.ox - Centers.x);
                layerm.LayerArray[this.parentid].Barrages[index1].batch.y = layerm.LayerArray[this.parentid].Barrages[index1].y - (Centers.oy - Centers.y);
                layerm.LayerArray[this.parentid].Barrages[index1].batch.fx = layerm.LayerArray[this.parentid].Barrages[index1].x - (Centers.ox - Centers.x);
                layerm.LayerArray[this.parentid].Barrages[index1].batch.fy = layerm.LayerArray[this.parentid].Barrages[index1].y - (Centers.oy - Centers.y);
                layerm.LayerArray[this.parentid].Barrages[index1].batch.Update(layerm, cs, Times, Centers, Player);
              }
              else
              {
                layerm.LayerArray[this.parentid].Barrages[index1].batch = this.Clone();
                layerm.LayerArray[this.parentid].Barrages[index1].batch.Deepbind = false;
                layerm.LayerArray[this.parentid].Barrages[index1].batch.Deepbinded = true;
                layerm.LayerArray[this.parentid].Barrages[index1].batch.bindid = -1;
                layerm.LayerArray[this.parentid].Barrages[index1].batch.time = 0;
                if (this.Bindwithspeedd)
                  layerm.LayerArray[this.parentid].Barrages[index1].batch.fdirection += layerm.LayerArray[this.parentid].Barrages[index1].fdirection;
                layerm.LayerArray[this.parentid].Barrages[index1].batch.Bindwithspeedd = false;
              }
            }
            else
            {
              for (int index2 = 0; index2 < tiao; ++index2)
              {
                Barrage barrage = new Barrage();
                barrage.shoot = cs.shoot;
                if ((double) layerm.LayerArray[this.parentid].BatchArray[this.id].rdirection == -99999.0)
                  this.rdirection = MathHelper.ToDegrees(Main.Twopointangle(Player.X, Player.Y, layerm.LayerArray[this.parentid].Barrages[index1].x, layerm.LayerArray[this.parentid].Barrages[index1].y));
                float degrees = this.rdirection + ((float) index2 - (float) (((double) tiao - 1.0) / 2.0)) * (float) (this.range + num2) / (float) tiao + num5;
                barrage.x = layerm.LayerArray[this.parentid].Barrages[index1].x + (float) (((double) this.r + (double) num1) * Math.Cos((double) MathHelper.ToRadians(degrees))) + num3;
                barrage.y = layerm.LayerArray[this.parentid].Barrages[index1].y + (float) (((double) this.r + (double) num1) * Math.Sin((double) MathHelper.ToRadians(degrees))) + num4;
                barrage.life = this.sonlife;
                barrage.type = (int) this.type - 1;
                barrage.wscale = this.wscale + Math.Max(val1, val2);
                barrage.hscale = this.hscale + Math.Max(val1, val2);
                if ((double) layerm.LayerArray[this.parentid].BatchArray[this.id].head == -100000.0)
                  this.head = MathHelper.ToDegrees(Main.Twopointangle(this.heads.X, this.heads.Y, barrage.x, barrage.y));
                barrage.head = this.head + num6;
                barrage.alpha = this.alpha;
                barrage.R = this.colorR;
                barrage.G = this.colorG;
                barrage.B = this.colorB;
                barrage.speed = this.sonspeed + num7;
                barrage.aspeed = this.sonaspeed + num9;
                barrage.fx = this.x - 4f;
                barrage.fy = this.y + 16f;
                barrage.fdirection = (double) this.bfdirection < -99997.0 ? this.bfdirection : this.fdirection;
                barrage.bindspeedd = layerm.LayerArray[this.parentid].Barrages[index1].speedd;
                barrage.Bindwithspeedd = this.Bindwithspeedd;
                barrage.fdirections = this.fdirections;
                barrage.randfdirection = num8;
                barrage.g = index2;
                barrage.tiaos = tiao;
                barrage.range = this.range;
                barrage.randrange = num2;
                barrage.sonaspeedd = (double) this.bsonaspeedd < -99997.0 ? this.bsonaspeedd : this.sonaspeedd;
                barrage.sonaspeedds = this.sonaspeedds;
                barrage.randsonaspeedd = num10;
                barrage.Withspeedd = this.Withspeedd;
                barrage.xscale = this.xscale;
                barrage.yscale = this.yscale;
                barrage.Mist = this.Mist;
                barrage.Dispel = this.Dispel;
                barrage.Blend = this.Blend;
                barrage.Outdispel = this.Outdispel;
                barrage.Afterimage = this.Afterimage;
                barrage.Invincible = this.Invincible;
                barrage.Cover = this.Cover;
                barrage.Rebound = this.Rebound;
                barrage.Force = this.Force;
                for (int idx = 0; idx < this.Sonevents.Count; ++idx)
                {
                  Event @event = new Event(idx);
                  @event.t = this.Sonevents[idx].t;
                  @event.addtime = this.Sonevents[idx].addtime;
                  @event.events = this.Sonevents[idx].events;
                  for (int index3 = 0; index3 < this.Sonevents[idx].results.Count; ++index3)
                    @event.results.Add((EventRead) this.Sonevents[idx].results[index3].Copy());
                  @event.index = this.Sonevents[idx].index;
                  barrage.Events.Add(@event);
                }
                barrage.parentid = this.id;
                layerm.LayerArray[this.parentid].Barrages.Add(barrage);
              }
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

    public Batch Clone()
    {
      Batch batch = this.Copy() as Batch;
      batch.Parentevents = new List<Event>();
      foreach (Event parentevent in this.Parentevents)
        batch.Parentevents.Add((Event) parentevent.Clone());
      batch.Eventsexe = new List<Execution>();
      foreach (Execution execution in this.Eventsexe)
        batch.Eventsexe.Add((Execution) execution.Clone());
      batch.Sonevents = new List<Event>();
      foreach (Event sonevent in this.Sonevents)
        batch.Sonevents.Add((Event) sonevent.Clone());
      return batch;
    }

    public object Copy()
    {
      return this.MemberwiseClone();
    }

    public void Recover(LayerManager layerm)
    {
      this.x = layerm.LayerArray[this.parentid].BatchArray[this.id].x;
      this.y = layerm.LayerArray[this.parentid].BatchArray[this.id].y;
      this.begin = layerm.LayerArray[this.parentid].BatchArray[this.id].begin;
      this.life = layerm.LayerArray[this.parentid].BatchArray[this.id].life;
      this.fx = layerm.LayerArray[this.parentid].BatchArray[this.id].fx;
      this.fy = layerm.LayerArray[this.parentid].BatchArray[this.id].fy;
      this.r = layerm.LayerArray[this.parentid].BatchArray[this.id].r;
      this.rdirection = layerm.LayerArray[this.parentid].BatchArray[this.id].rdirection;
      this.tiao = layerm.LayerArray[this.parentid].BatchArray[this.id].tiao;
      this.t = layerm.LayerArray[this.parentid].BatchArray[this.id].t;
      this.fdirection = layerm.LayerArray[this.parentid].BatchArray[this.id].fdirection;
      this.range = layerm.LayerArray[this.parentid].BatchArray[this.id].range;
      this.speed = layerm.LayerArray[this.parentid].BatchArray[this.id].speed;
      this.speedd = layerm.LayerArray[this.parentid].BatchArray[this.id].speedd;
      this.aspeed = layerm.LayerArray[this.parentid].BatchArray[this.id].aspeed;
      this.aspeedd = layerm.LayerArray[this.parentid].BatchArray[this.id].aspeedd;
      this.sonlife = layerm.LayerArray[this.parentid].BatchArray[this.id].sonlife;
      this.type = layerm.LayerArray[this.parentid].BatchArray[this.id].type;
      this.wscale = layerm.LayerArray[this.parentid].BatchArray[this.id].wscale;
      this.hscale = layerm.LayerArray[this.parentid].BatchArray[this.id].hscale;
      this.colorR = layerm.LayerArray[this.parentid].BatchArray[this.id].colorR;
      this.colorG = layerm.LayerArray[this.parentid].BatchArray[this.id].colorG;
      this.colorB = layerm.LayerArray[this.parentid].BatchArray[this.id].colorB;
      this.alpha = layerm.LayerArray[this.parentid].BatchArray[this.id].alpha;
      this.head = layerm.LayerArray[this.parentid].BatchArray[this.id].head;
      this.Withspeedd = layerm.LayerArray[this.parentid].BatchArray[this.id].Withspeedd;
      this.sonspeed = layerm.LayerArray[this.parentid].BatchArray[this.id].sonspeed;
      this.sonspeedd = layerm.LayerArray[this.parentid].BatchArray[this.id].sonspeedd;
      this.sonaspeed = layerm.LayerArray[this.parentid].BatchArray[this.id].sonaspeed;
      this.sonaspeedd = layerm.LayerArray[this.parentid].BatchArray[this.id].sonaspeedd;
      this.xscale = layerm.LayerArray[this.parentid].BatchArray[this.id].xscale;
      this.yscale = layerm.LayerArray[this.parentid].BatchArray[this.id].yscale;
      this.Mist = layerm.LayerArray[this.parentid].BatchArray[this.id].Mist;
      this.Dispel = layerm.LayerArray[this.parentid].BatchArray[this.id].Dispel;
      this.Blend = layerm.LayerArray[this.parentid].BatchArray[this.id].Blend;
      this.Afterimage = layerm.LayerArray[this.parentid].BatchArray[this.id].Afterimage;
      this.Outdispel = layerm.LayerArray[this.parentid].BatchArray[this.id].Outdispel;
      this.Invincible = layerm.LayerArray[this.parentid].BatchArray[this.id].Invincible;
    }
  }
}
