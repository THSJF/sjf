// Decompiled with JetBrains decompiler
// Type: THMHJ.EnemyManager
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace THMHJ
{
  public class EnemyManager
  {
    public Texture2D tex;
    public List<Enemy> EnemyArray;
    private Enemy temp;
    private bool prefurther;

    public EnemyManager(Texture2D tex_t)
    {
      this.tex = tex_t;
      this.EnemyArray = new List<Enemy>();
    }

    public void Update(Character Player, Boss boss)
    {
      for (int index = 0; index < this.EnemyArray.Count; ++index)
      {
        if (!this.EnemyArray[index].die)
          this.EnemyArray[index].Update(Player);
      }
    }

    public void Clear()
    {
      this.EnemyArray.Clear();
    }

    public Enemy MinDistance(Vector2 p, float px, bool further)
    {
      if (this.prefurther != further)
      {
        this.temp = (Enemy) null;
        this.prefurther = further;
      }
      Enemy enemy1 = new Enemy();
      enemy1.die = true;
      float num1 = 9999999f;
      foreach (Enemy enemy2 in this.EnemyArray)
      {
        if (!enemy2.die)
        {
          float num2 = (float) (((double) p.X - (double) enemy2.Position.X) * ((double) p.X - (double) enemy2.Position.X) + ((double) p.Y - (double) enemy2.Position.Y) * ((double) p.Y - (double) enemy2.Position.Y));
          double degrees = (double) MathHelper.ToDegrees(Main.Twopointangle(enemy2.Position.X, enemy2.Position.Y, p.X, p.Y));
          if ((Main.Mode != Modes.SINGLE || (double) enemy2.Position.Y > 16.0 && (double) enemy2.Position.Y < 463.0 && ((double) enemy2.Position.X > 31.0 && (double) enemy2.Position.X < 416.0)) && (Main.Mode == Modes.SINGLE || (double) enemy2.Position.Y > -10.0 && (double) enemy2.Position.Y < 470.0 && ((double) enemy2.Position.X > 10.0 && (double) enemy2.Position.X < 630.0)) && ((!further || (double) Math.Abs(px - p.X) > 20.0) && (double) num2 <= (double) num1))
          {
            num1 = (float) (((double) p.X - (double) enemy2.Position.X) * ((double) p.X - (double) enemy2.Position.X) + ((double) p.Y - (double) enemy2.Position.Y) * ((double) p.Y - (double) enemy2.Position.Y));
            enemy1 = enemy2;
          }
        }
      }
      if (!enemy1.die && (this.temp == null || this.temp.die || Main.Mode == Modes.SINGLE && ((double) this.temp.Position.Y <= 16.0 || (double) this.temp.Position.Y >= 463.0 || ((double) this.temp.Position.X <= 31.0 || (double) this.temp.Position.X >= 416.0)) || Main.Mode != Modes.SINGLE && ((double) this.temp.Position.Y <= -10.0 || (double) this.temp.Position.Y >= 470.0 || ((double) this.temp.Position.X <= 10.0 || (double) this.temp.Position.X >= 630.0))))
        this.temp = enemy1;
      if (this.temp != null)
        return this.temp;
      return enemy1;
    }

    public void Draw(SpriteBatch s, Vector2 Quakeset)
    {
      for (int index = 0; index < this.EnemyArray.Count; ++index)
      {
        if (!this.EnemyArray[index].die)
          this.EnemyArray[index].Draw(s, Quakeset);
      }
    }

    public int GetIndex(int id)
    {
      for (int index = 0; index < this.EnemyArray.Count; ++index)
      {
        if (this.EnemyArray[index].id == id)
          return index;
      }
      return -1;
    }

    public int GetIndex(string id)
    {
      for (int index = 0; index < this.EnemyArray.Count; ++index)
      {
        if (this.EnemyArray[index].label == id)
          return index;
      }
      return -1;
    }

    public float Judge(Vector2 pos, int power)
    {
      for (int index = 0; index < this.EnemyArray.Count; ++index)
      {
        if (!this.EnemyArray[index].die && this.EnemyArray[index].Judge(pos, power) && this.EnemyArray[index].hp != 0)
          return (float) (this.EnemyArray[index].ohp / this.EnemyArray[index].hp);
      }
      return 0.0f;
    }
  }
}
