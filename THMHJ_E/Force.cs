// Decompiled with JetBrains decompiler
// Type: THMHJ.Force
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace THMHJ
{
  [Serializable]
  public class Force
  {
    public bool NeedDelete;
    public int id;
    public int parentid;
    public float x;
    public float y;
    public int begin;
    public int life;
    public int halfw;
    public int halfh;
    public bool Circle;
    public int type;
    public int controlid;
    public float speed;
    public float speedd;
    public float speedx;
    public float speedy;
    public float aspeed;
    public float aspeedx;
    public float aspeedy;
    public float aspeedd;
    public float addaspeed;
    public float addaspeedd;
    public bool Suction;
    public bool Repulsion;
    public float addspeed;
    public Force rand;
    public List<Event> Parentevents;
    public Force copys;

    public Force()
    {
    }

    public Force(float xs, float ys, LayerManager layerm)
    {
      this.rand = new Force();
      this.Parentevents = new List<Event>();
      this.x = xs;
      this.y = ys;
      this.begin = layerm.LayerArray[this.parentid].begin;
      this.life = layerm.LayerArray[this.parentid].end - layerm.LayerArray[this.parentid].begin + 1;
      this.halfw = 100;
      this.halfh = 100;
      this.type = 0;
      this.controlid = 1;
      this.speed = 0.0f;
      this.speedd = 0.0f;
      this.aspeed = 0.0f;
      this.aspeedd = 0.0f;
      this.Circle = false;
    }

    public void Update(LayerManager layerm, Time Times, Center Centers, Character Player)
    {
      if (!(Times.now >= this.begin & Times.now <= this.begin + this.life - 1))
        return;
      float x = Player.body.position.X;
      float y1 = Player.body.position.Y;
      int now = Times.now;
      this.speedx += this.aspeedx;
      this.speedy += this.aspeedy;
      this.x += this.speedx;
      this.y += this.speedy;
      float y2;
      float y3;
      if (this.Circle)
      {
        if (Math.Sqrt(((double) this.x - 4.0 - (double) x) * ((double) this.x - 4.0 - (double) x) + ((double) this.y + 16.0 - (double) y1) * ((double) this.y + 16.0 - (double) y1)) <= (double) Math.Max(this.halfw, this.halfh))
        {
          float num1;
          float num2;
          if (this.Suction)
          {
            float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x - 4f, this.y + 16f, x, y1));
            num1 = x + this.addspeed * (float) Math.Cos((double) MathHelper.ToRadians(degrees));
            num2 = y1 + this.addspeed * (float) Math.Sin((double) MathHelper.ToRadians(degrees));
          }
          else if (this.Repulsion)
          {
            float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x - 4f, this.y + 16f, x, y1));
            num1 = x + this.addspeed * (float) Math.Cos((double) MathHelper.ToRadians(180f + degrees));
            num2 = y1 + this.addspeed * (float) Math.Sin((double) MathHelper.ToRadians(180f + degrees));
          }
          else
          {
            num1 = x + this.addspeed * (float) Math.Cos((double) MathHelper.ToRadians(this.addaspeedd));
            num2 = y1 + this.addspeed * (float) Math.Sin((double) MathHelper.ToRadians(this.addaspeedd));
          }
          if ((double) num1 <= (double) Player.rangex.X)
            num1 = Player.rangex.X;
          if ((double) num1 >= (double) Player.rangex.Y)
            y2 = Player.rangex.Y;
          if ((double) num2 <= (double) Player.rangey.X)
            num2 = Player.rangey.X;
          if ((double) num2 >= (double) Player.rangey.Y)
            y3 = Player.rangey.Y;
        }
      }
      else if ((double) Math.Abs(this.x - 4f - x) <= (double) this.halfw & (double) Math.Abs(this.y + 16f - y1) <= (double) this.halfh)
      {
        float num1;
        float num2;
        if (this.Suction)
        {
          float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x - 4f, this.y + 16f, x, y1));
          num1 = x + this.addspeed * (float) Math.Cos((double) MathHelper.ToRadians(degrees));
          num2 = y1 + this.addspeed * (float) Math.Sin((double) MathHelper.ToRadians(degrees));
        }
        else if (this.Repulsion)
        {
          float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x - 4f, this.y + 16f, x, y1));
          num1 = x + this.addspeed * (float) Math.Cos((double) MathHelper.ToRadians(180f + degrees));
          num2 = y1 + this.addspeed * (float) Math.Sin((double) MathHelper.ToRadians(180f + degrees));
        }
        else
        {
          num1 = x + this.addspeed * (float) Math.Cos((double) MathHelper.ToRadians(this.addaspeedd));
          num2 = y1 + this.addspeed * (float) Math.Sin((double) MathHelper.ToRadians(this.addaspeedd));
        }
        if ((double) num1 <= (double) Player.rangex.X)
          num1 = Player.rangex.X;
        if ((double) num1 >= (double) Player.rangex.Y)
          y2 = Player.rangex.Y;
        if ((double) num2 <= (double) Player.rangey.X)
          num2 = Player.rangey.X;
        if ((double) num2 >= (double) Player.rangey.Y)
          y3 = Player.rangey.Y;
      }
      foreach (Barrage barrage in layerm.LayerArray[this.parentid].Barrages)
      {
        if (barrage.Force)
        {
          if (this.Circle)
          {
            if (this.type == 0)
            {
              if (Math.Sqrt(((double) this.x - 4.0 - (double) barrage.x) * ((double) this.x - 4.0 - (double) barrage.x) + ((double) this.y + 16.0 - (double) barrage.y) * ((double) this.y + 16.0 - (double) barrage.y)) <= (double) Math.Max(this.halfw, this.halfh))
              {
                if (this.Suction)
                {
                  float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x - 4f, this.y + 16f, barrage.x, barrage.y));
                  barrage.speedx += barrage.xscale * this.addaspeed * (float) Math.Cos((double) MathHelper.ToRadians(degrees));
                  barrage.speedy += barrage.yscale * this.addaspeed * (float) Math.Sin((double) MathHelper.ToRadians(degrees));
                }
                else if (this.Repulsion)
                {
                  float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x - 4f, this.y + 16f, barrage.x, barrage.y));
                  barrage.speedx += barrage.xscale * this.addaspeed * (float) Math.Cos((double) MathHelper.ToRadians(180f + degrees));
                  barrage.speedy += barrage.yscale * this.addaspeed * (float) Math.Sin((double) MathHelper.ToRadians(180f + degrees));
                }
                else
                {
                  barrage.speedx += barrage.xscale * this.addaspeed * (float) Math.Cos((double) MathHelper.ToRadians(this.addaspeedd));
                  barrage.speedy += barrage.yscale * this.addaspeed * (float) Math.Sin((double) MathHelper.ToRadians(this.addaspeedd));
                }
              }
            }
            else if (this.type == 1 && barrage.parentid == this.controlid - 1 & Math.Sqrt(((double) this.x - 4.0 - (double) barrage.x) * ((double) this.x - 4.0 - (double) barrage.x) + ((double) this.y + 16.0 - (double) barrage.y) * ((double) this.y + 16.0 - (double) barrage.y)) <= (double) Math.Max(this.halfw, this.halfh))
            {
              if (this.Suction)
              {
                float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x - 4f, this.y + 16f, barrage.x, barrage.y));
                barrage.speedx += barrage.xscale * this.addaspeed * (float) Math.Cos((double) MathHelper.ToRadians(degrees));
                barrage.speedy += barrage.yscale * this.addaspeed * (float) Math.Sin((double) MathHelper.ToRadians(degrees));
              }
              else if (this.Repulsion)
              {
                float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x - 4f, this.y + 16f, barrage.x, barrage.y));
                barrage.speedx += barrage.xscale * this.addaspeed * (float) Math.Cos((double) MathHelper.ToRadians(180f + degrees));
                barrage.speedy += barrage.yscale * this.addaspeed * (float) Math.Sin((double) MathHelper.ToRadians(180f + degrees));
              }
              else
              {
                barrage.speedx += barrage.xscale * this.addaspeed * (float) Math.Cos((double) MathHelper.ToRadians(this.addaspeedd));
                barrage.speedy += barrage.yscale * this.addaspeed * (float) Math.Sin((double) MathHelper.ToRadians(this.addaspeedd));
              }
            }
          }
          else if (this.type == 0)
          {
            if ((double) Math.Abs(this.x - 4f - barrage.x) <= (double) this.halfw & (double) Math.Abs(this.y + 16f - barrage.y) <= (double) this.halfh)
            {
              if (this.Suction)
              {
                float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x - 4f, this.y + 16f, barrage.x, barrage.y));
                barrage.speedx += barrage.xscale * this.addaspeed * (float) Math.Cos((double) MathHelper.ToRadians(degrees));
                barrage.speedy += barrage.yscale * this.addaspeed * (float) Math.Sin((double) MathHelper.ToRadians(degrees));
              }
              else if (this.Repulsion)
              {
                float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x - 4f, this.y + 16f, barrage.x, barrage.y));
                barrage.speedx += barrage.xscale * this.addaspeed * (float) Math.Cos((double) MathHelper.ToRadians(180f + degrees));
                barrage.speedy += barrage.yscale * this.addaspeed * (float) Math.Sin((double) MathHelper.ToRadians(180f + degrees));
              }
              else
              {
                barrage.speedx += barrage.xscale * this.addaspeed * (float) Math.Cos((double) MathHelper.ToRadians(this.addaspeedd));
                barrage.speedy += barrage.yscale * this.addaspeed * (float) Math.Sin((double) MathHelper.ToRadians(this.addaspeedd));
              }
            }
          }
          else if (this.type == 1 && barrage.parentid == this.controlid - 1 & (double) Math.Abs(this.x - 4f - barrage.x) <= (double) this.halfw & (double) Math.Abs(this.y + 16f - barrage.y) <= (double) this.halfh)
          {
            if (this.Suction)
            {
              float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x - 4f, this.y + 16f, barrage.x, barrage.y));
              barrage.speedx += barrage.xscale * this.addaspeed * (float) Math.Cos((double) MathHelper.ToRadians(degrees));
              barrage.speedy += barrage.yscale * this.addaspeed * (float) Math.Sin((double) MathHelper.ToRadians(degrees));
            }
            else if (this.Repulsion)
            {
              float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x - 4f, this.y + 16f, barrage.x, barrage.y));
              barrage.speedx += barrage.xscale * this.addaspeed * (float) Math.Cos((double) MathHelper.ToRadians(180f + degrees));
              barrage.speedy += barrage.yscale * this.addaspeed * (float) Math.Sin((double) MathHelper.ToRadians(180f + degrees));
            }
            else
            {
              barrage.speedx += barrage.xscale * this.addaspeed * (float) Math.Cos((double) MathHelper.ToRadians(this.addaspeedd));
              barrage.speedy += barrage.yscale * this.addaspeed * (float) Math.Sin((double) MathHelper.ToRadians(this.addaspeedd));
            }
          }
        }
      }
    }

    public Force Clone()
    {
      return this.Copy() as Force;
    }

    public object Copy()
    {
      return this.MemberwiseClone();
    }
  }
}
