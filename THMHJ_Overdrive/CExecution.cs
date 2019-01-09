// Decompiled with JetBrains decompiler
// Type: THMHJ.CExecution
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using System;

namespace THMHJ
{
  public class CExecution
  {
    public int change;
    public int changetype;
    public int changevalue;
    public string region;
    public float value;
    public float value2;
    public int time;
    public int ctime;
    public bool NeedDelete;

    public void Update(Center Centers, Character Player, Boss boss)
    {
      if (this.changetype == 0)
      {
        switch (this.changevalue)
        {
          case 0:
            if (this.change == 0)
              Centers.ospeed = (Centers.ospeed * ((float) this.ctime - 1f) + this.value) / (float) this.ctime;
            else if (this.change == 1)
              Centers.ospeed += this.value / (float) this.time;
            else if (this.change == 2)
              Centers.ospeed -= this.value / (float) this.time;
            Centers.speedx = Centers.ospeed * (float) Math.Cos((double) MathHelper.ToRadians(Centers.ospeedd));
            Centers.speedy = Centers.ospeed * (float) Math.Sin((double) MathHelper.ToRadians(Centers.ospeedd));
            break;
          case 1:
            if (this.change == 0)
              Centers.ospeedd = (Centers.ospeedd * ((float) this.ctime - 1f) + this.value) / (float) this.ctime;
            else if (this.change == 1)
              Centers.ospeedd += this.value / (float) this.time;
            else if (this.change == 2)
              Centers.ospeedd -= this.value / (float) this.time;
            Centers.speedx = Centers.ospeed * (float) Math.Cos((double) MathHelper.ToRadians(Centers.ospeedd));
            Centers.speedy = Centers.ospeed * (float) Math.Sin((double) MathHelper.ToRadians(Centers.ospeedd));
            break;
          case 2:
            if (this.change == 0)
              Centers.oaspeed = (Centers.oaspeed * ((float) this.ctime - 1f) + this.value) / (float) this.ctime;
            else if (this.change == 1)
              Centers.oaspeed += this.value / (float) this.time;
            else if (this.change == 2)
              Centers.oaspeed -= this.value / (float) this.time;
            Centers.aspeedx = Centers.oaspeed * (float) Math.Cos((double) MathHelper.ToRadians(Centers.oaspeedd));
            Centers.aspeedy = Centers.oaspeed * (float) Math.Sin((double) MathHelper.ToRadians(Centers.oaspeedd));
            break;
          case 3:
            if (this.change == 0)
              Centers.oaspeedd = (Centers.oaspeedd * ((float) this.ctime - 1f) + this.value) / (float) this.ctime;
            else if (this.change == 1)
              Centers.oaspeedd += this.value / (float) this.time;
            else if (this.change == 2)
              Centers.oaspeedd -= this.value / (float) this.time;
            Centers.aspeedx = Centers.oaspeed * (float) Math.Cos((double) MathHelper.ToRadians(Centers.oaspeedd));
            Centers.aspeedy = Centers.oaspeed * (float) Math.Sin((double) MathHelper.ToRadians(Centers.oaspeedd));
            break;
        }
      }
      else if (this.changetype == 1)
      {
        switch (this.changevalue)
        {
          case 0:
            if (this.change == 0)
              Centers.ospeed = this.value;
            else if (this.change == 1)
              Centers.ospeed += this.value;
            else if (this.change == 2)
              Centers.ospeed -= this.value;
            Centers.speedx = Centers.ospeed * (float) Math.Cos((double) MathHelper.ToRadians(Centers.ospeedd));
            Centers.speedy = Centers.ospeed * (float) Math.Sin((double) MathHelper.ToRadians(Centers.ospeedd));
            break;
          case 1:
            if (this.change == 0)
              Centers.ospeedd = this.value;
            else if (this.change == 1)
              Centers.ospeedd += this.value;
            else if (this.change == 2)
              Centers.ospeedd -= this.value;
            Centers.speedx = Centers.ospeed * (float) Math.Cos((double) MathHelper.ToRadians(Centers.ospeedd));
            Centers.speedy = Centers.ospeed * (float) Math.Sin((double) MathHelper.ToRadians(Centers.ospeedd));
            break;
          case 2:
            if (this.change == 0)
              Centers.oaspeed = this.value;
            else if (this.change == 1)
              Centers.oaspeed += this.value;
            else if (this.change == 2)
              Centers.oaspeed -= this.value;
            Centers.aspeedx = Centers.oaspeed * (float) Math.Cos((double) MathHelper.ToRadians(Centers.oaspeedd));
            Centers.aspeedy = Centers.oaspeed * (float) Math.Sin((double) MathHelper.ToRadians(Centers.oaspeedd));
            break;
          case 3:
            if (this.change == 0)
              Centers.oaspeedd = this.value;
            else if (this.change == 1)
              Centers.ospeedd += this.value;
            else if (this.change == 2)
              Centers.ospeedd -= this.value;
            Centers.aspeedx = Centers.oaspeed * (float) Math.Cos((double) MathHelper.ToRadians(Centers.oaspeedd));
            Centers.aspeedy = Centers.oaspeed * (float) Math.Sin((double) MathHelper.ToRadians(Centers.oaspeedd));
            break;
        }
      }
      else if (this.changetype == 2)
      {
        switch (this.changevalue)
        {
          case 0:
            if (this.change == 0)
              Centers.ospeed = float.Parse(this.region) + (this.value - float.Parse(this.region)) * (float) Math.Sin((double) MathHelper.ToRadians((float) (360.0 / (double) this.time * ((double) this.time - (double) this.ctime))));
            else if (this.change == 1)
              Centers.ospeed = float.Parse(this.region) + this.value * (float) Math.Sin((double) MathHelper.ToRadians((float) (360.0 / (double) this.time * ((double) this.time - (double) this.ctime))));
            else if (this.change == 2)
              Centers.ospeed = float.Parse(this.region) - this.value * (float) Math.Sin((double) MathHelper.ToRadians((float) (360.0 / (double) this.time * ((double) this.time - (double) this.ctime))));
            Centers.speedx = Centers.ospeed * (float) Math.Cos((double) MathHelper.ToRadians(Centers.ospeedd));
            Centers.speedy = Centers.ospeed * (float) Math.Sin((double) MathHelper.ToRadians(Centers.ospeedd));
            break;
          case 1:
            if (this.change == 0)
              Centers.ospeedd = float.Parse(this.region) + (this.value - float.Parse(this.region)) * (float) Math.Sin((double) MathHelper.ToRadians((float) (360.0 / (double) this.time * ((double) this.time - (double) this.ctime))));
            else if (this.change == 1)
              Centers.ospeedd = float.Parse(this.region) + this.value * (float) Math.Sin((double) MathHelper.ToRadians((float) (360.0 / (double) this.time * ((double) this.time - (double) this.ctime))));
            else if (this.change == 2)
              Centers.ospeedd = float.Parse(this.region) - this.value * (float) Math.Sin((double) MathHelper.ToRadians((float) (360.0 / (double) this.time * ((double) this.time - (double) this.ctime))));
            Centers.speedx = Centers.ospeed * (float) Math.Cos((double) MathHelper.ToRadians(Centers.ospeedd));
            Centers.speedy = Centers.ospeed * (float) Math.Sin((double) MathHelper.ToRadians(Centers.ospeedd));
            break;
          case 2:
            if (this.change == 0)
              Centers.oaspeed = float.Parse(this.region) + (this.value - float.Parse(this.region)) * (float) Math.Sin((double) MathHelper.ToRadians((float) (360.0 / (double) this.time * ((double) this.time - (double) this.ctime))));
            else if (this.change == 1)
              Centers.oaspeed = float.Parse(this.region) + this.value * (float) Math.Sin((double) MathHelper.ToRadians((float) (360.0 / (double) this.time * ((double) this.time - (double) this.ctime))));
            else if (this.change == 2)
              Centers.oaspeed = float.Parse(this.region) - this.value * (float) Math.Sin((double) MathHelper.ToRadians((float) (360.0 / (double) this.time * ((double) this.time - (double) this.ctime))));
            Centers.aspeedx = Centers.oaspeed * (float) Math.Cos((double) MathHelper.ToRadians(Centers.oaspeedd));
            Centers.aspeedy = Centers.oaspeed * (float) Math.Sin((double) MathHelper.ToRadians(Centers.oaspeedd));
            break;
          case 3:
            if (this.change == 0)
              Centers.oaspeedd = float.Parse(this.region) + (this.value - float.Parse(this.region)) * (float) Math.Sin((double) MathHelper.ToRadians((float) (360.0 / (double) this.time * ((double) this.time - (double) this.ctime))));
            else if (this.change == 1)
              Centers.oaspeedd = float.Parse(this.region) + this.value * (float) Math.Sin((double) MathHelper.ToRadians((float) (360.0 / (double) this.time * ((double) this.time - (double) this.ctime))));
            else if (this.change == 2)
              Centers.oaspeedd = float.Parse(this.region) - this.value * (float) Math.Sin((double) MathHelper.ToRadians((float) (360.0 / (double) this.time * ((double) this.time - (double) this.ctime))));
            Centers.aspeedx = Centers.oaspeed * (float) Math.Cos((double) MathHelper.ToRadians(Centers.oaspeedd));
            Centers.aspeedy = Centers.oaspeed * (float) Math.Sin((double) MathHelper.ToRadians(Centers.oaspeedd));
            break;
        }
      }
      else if (this.changetype == 3 && boss != null)
      {
        boss.Setpos((float) (((double) boss.Position.X * 19.0 + (double) Player.body.position.X) / 20.0), boss.Position.Y);
        Centers.ox = (float) (((double) Centers.ox * 19.0 + (double) Player.body.position.X) / 20.0);
      }
      else if (this.changetype == 4 && boss != null)
      {
        float num = Main.Mode != Modes.SINGLE ? 0.0f : -93f;
        boss.Setpos(boss.Position.X + (float) (((double) this.value + (double) num - (double) boss.Position.X) / 20.0), boss.Position.Y + (float) (((double) this.value2 - (double) boss.Position.Y) / 20.0));
        Centers.ox = (float) (((double) Centers.ox * 19.0 + ((double) this.value + (double) num)) / 20.0);
        Centers.oy = (float) (((double) Centers.oy * 19.0 + (double) this.value2) / 20.0);
      }
      --this.ctime;
      if (this.changetype == 2 & this.ctime == -1)
      {
        this.NeedDelete = true;
      }
      else
      {
        if (!(this.changetype != 2 & this.ctime == 0))
          return;
        this.NeedDelete = true;
      }
    }
  }
}
