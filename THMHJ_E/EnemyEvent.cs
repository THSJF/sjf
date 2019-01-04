// Decompiled with JetBrains decompiler
// Type: THMHJ.EnemyEvent
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System;

namespace THMHJ
{
  public class EnemyEvent
  {
    public int occasion;
    public string value;
    public float target;
    public float targetxr;
    public float targetx;
    public string targets;
    public int time;
    public int type;
    private int t;
    private float origin;
    public bool stop;
    public bool Independent;

    public EnemyEvent()
    {
    }

    public EnemyEvent(int occasion_i, string value_s, float target_f, int time_i, int type_i)
    {
      this.occasion = occasion_i;
      this.value = value_s;
      this.target = target_f;
      this.time = time_i;
      this.type = type_i;
    }

    public EnemyEvent(int occasion_i, string value_s, string targets_f, int time_i, int type_i)
    {
      this.occasion = occasion_i;
      this.value = value_s;
      this.targets = targets_f;
      this.time = time_i;
      this.type = type_i;
    }

    public void Update(Enemy e)
    {
      if (this.t >= this.occasion && this.t < this.occasion + this.time)
      {
        switch (this.value)
        {
          case "x":
            if (this.t == this.occasion)
            {
              this.origin = e.Position.X;
              if ((double) this.targetxr != 0.0)
                this.target = this.origin + this.targetxr;
            }
            switch (this.type)
            {
              case 1:
                e.Position.X += (this.target - this.origin) / (float) this.time;
                break;
              case 2:
                e.Position.X = this.target;
                break;
              case 3:
                e.Position.X = this.origin + (this.target - this.origin) * (float) Math.Sin((double) this.t / (double) this.time * 3.14159274101257 * 2.0);
                break;
            }
                        break;
                    case "y":
            if (this.t == this.occasion)
            {
              this.origin = e.Position.Y;
              if ((double) this.targetxr != 0.0)
                this.target = this.origin + this.targetxr;
            }
            switch (this.type)
            {
              case 1:
                e.Position.Y += (this.target - this.origin) / (float) this.time;
                break;
              case 2:
                e.Position.Y = this.target;
                break;
              case 3:
                e.Position.Y = this.origin + (this.target - this.origin) * (float) Math.Sin((double) this.t / (double) this.time * 3.14159274101257 * 2.0);
                break;
            }
                        break;
                    case "speed":
            if (this.t == this.occasion)
            {
              this.origin = e.speed;
              if ((double) this.targetxr != 0.0)
                this.target = this.origin + this.targetxr;
            }
            switch (this.type)
            {
              case 1:
                e.speed += (this.target - this.origin) / (float) this.time;
                break;
              case 2:
                e.speed = this.target;
                break;
              case 3:
                e.speed = this.origin + (this.target - this.origin) * (float) Math.Sin((double) this.t / (double) this.time * 3.14159274101257 * 2.0);
                break;
            }
                        break;
                    case "speedf":
            if (this.t == this.occasion)
            {
              this.origin = e.speedf;
              if ((double) this.targetxr != 0.0)
                this.target = this.origin + this.targetxr;
            }
            switch (this.type)
            {
              case 1:
                e.speedf += (this.target - this.origin) / (float) this.time;
                break;
              case 2:
                e.speedf = this.target;
                break;
              case 3:
                e.speedf = this.origin + (this.target - this.origin) * (float) Math.Sin((double) this.t / (double) this.time * 3.14159274101257 * 2.0);
                break;
            }
                        break;
                    case "life":
            if (this.t == this.occasion)
            {
              this.origin = (float) e.life;
              if ((double) this.targetxr != 0.0)
                this.target = this.origin + this.targetxr;
            }
            switch (this.type)
            {
              case 1:
                e.life += (int) (((double) this.target - (double) this.origin) / (double) this.time);
                break;
              case 2:
                e.life = (int) this.target;
                break;
              case 3:
                e.life = (int) ((double) this.origin + ((double) this.target - (double) this.origin) * Math.Sin((double) this.t / (double) this.time * 3.14159274101257 * 2.0));
                break;
            }
                        break;
                    case "hp":
            if (this.t == this.occasion)
            {
              this.origin = (float) e.hp;
              if ((double) this.targetxr != 0.0)
                this.target = this.origin + this.targetxr;
            }
            switch (this.type)
            {
              case 1:
                e.hp += (int) (((double) this.target - (double) this.origin) / (double) this.time);
                break;
              case 2:
                e.hp = (int) this.target;
                break;
              case 3:
                e.hp = (int) ((double) this.origin + ((double) this.target - (double) this.origin) * Math.Sin((double) this.t / (double) this.time * 3.14159274101257 * 2.0));
                break;
            }
                        break;
                    case "barrage":
            if (this.type == 2)
            {
              e.barrageid = int.Parse(this.targets);
              break;
            }
            break;
        }
        if (this.t == this.occasion)
          this.targetx = this.target - this.origin;
      }
      if (this.t >= this.occasion + this.time)
        this.stop = true;
      ++this.t;
    }
  }
}
