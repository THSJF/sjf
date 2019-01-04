// Decompiled with JetBrains decompiler
// Type: THMHJ.SingleBomb
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace THMHJ
{
  internal class SingleBomb
  {
    private Character target;
    private CrazyStorm cs;
    private Sprite tex;
    private Cname type;
    private int time;
    private int wait;
    private bool die;

    public bool Die
    {
      get
      {
        return this.die;
      }
    }

    public SingleBomb(Cname type_C, Vector2 pos)
    {
      this.type = type_C;
      if (this.type != Cname.SANAE)
      {
        Program.game.game.PlaySound("nep00", true, pos.X);
        this.cs = Program.game.game.PlayEffect(false, ((int) (14 + this.type)).ToString(), new Vector2(pos.X, pos.Y));
        this.cs.BanSound(true);
        this.cs.effect = true;
        this.cs.clearb = true;
        this.cs.bomb = true;
      }
      switch (this.type)
      {
        case Cname.REIMU:
          this.tex = new Sprite();
          this.target = new Character(this.tex);
          this.cs.shoot.AddRange((IEnumerable<byte>) new List<byte>()
          {
            (byte) 0,
            (byte) 1,
            (byte) 2,
            (byte) 3,
            (byte) 10,
            (byte) 11,
            (byte) 17,
            (byte) 17,
            (byte) 17,
            (byte) 17,
            (byte) 17,
            (byte) 17
          });
          break;
        case Cname.MARISA:
          Program.game.game.Quake((int) ((double) this.cs.time.total * 0.949999988079071), 2);
          this.cs.SetOPos(new Vector2(pos.X, pos.Y));
          this.cs.shoot.AddRange((IEnumerable<byte>) new List<byte>()
          {
            (byte) 2,
            (byte) 30
          });
          break;
        case Cname.SANAE:
          if (Main.IsKeyDown(Keys.LeftShift) || Main.IsKeyDown(Keys.RightShift) || !Main.Replay && PadState.IsKeyDown(JOYKEYS.Slow))
          {
            this.cs = Program.game.game.PlayEffect(false, "19", new Vector2(pos.X, pos.Y));
            this.cs.SetOPos(pos);
          }
          else
          {
            Program.game.game.PlaySound("nep00", true, pos.X);
            Program.game.game.Quake(250, 2);
            this.cs = Program.game.game.PlayEffect(false, ((int) (14 + this.type)).ToString(), new Vector2(pos.X, pos.Y));
            this.cs.shoot.AddRange((IEnumerable<byte>) new List<byte>()
            {
              (byte) 0,
              (byte) 125
            });
            this.cs.clearb = true;
          }
          this.cs.BanSound(true);
          this.cs.effect = true;
          this.cs.bomb = true;
          break;
        case Cname.PATCHOULI:
          Program.game.game.Quake((int) ((double) this.cs.time.total * 0.949999988079071), 2);
          this.cs.shoot.AddRange((IEnumerable<byte>) new List<byte>()
          {
            (byte) 2,
            (byte) 3,
            (byte) 9,
            (byte) 9
          });
          break;
      }
      this.time = 0;
    }

    public void Update(Character Player, CSManager csm, EnemyManager em, Boss boss)
    {
      Character Player1 = Player;
      ++this.time;
      if (this.time <= 40)
      {
        Program.game.game.bgcolor.a += 0.015f;
        if ((double) Program.game.game.bgcolor.a >= 1.0)
          Program.game.game.bgcolor.a = 1f;
      }
      if (this.time % 6 < 2)
      {
        Player.body.color.r = 0.0f;
        Player.body.color.g = 0.0f;
      }
      else
      {
        Player.body.color.r = 1f;
        Player.body.color.g = 1f;
      }
      if (this.cs != null)
      {
        switch (this.type)
        {
          case Cname.REIMU:
            Player.BanShoot = false;
            Vector2 vector2_1;
            Vector2 vector2_2;
            if (Main.Mode == Modes.SINGLE)
            {
              vector2_1 = new Vector2(42f, 406f);
              vector2_2 = new Vector2(43f, 453f);
            }
            else
            {
              vector2_1 = new Vector2(10f, 630f);
              vector2_2 = new Vector2(20f, 465f);
            }
            this.target.body.position.X = 224f;
            this.target.body.position.Y = 144f;
            foreach (Enemy enemy in em.EnemyArray)
            {
              if (!enemy.die && (double) enemy.Position.X >= (double) vector2_1.X && ((double) enemy.Position.X <= (double) vector2_1.Y && (double) enemy.Position.Y >= (double) vector2_2.X) && (double) enemy.Position.Y <= (double) vector2_2.Y)
              {
                this.target.body.position = enemy.Position;
                break;
              }
            }
            if (boss != null && !boss.leave)
              this.target.body.position = boss.Position;
            Player1 = this.target;
            if (this.time == 199)
            {
              Program.game.game.Quake(30, 3);
              break;
            }
            if (this.time == 229)
            {
              Program.game.game.Quake(30, 3);
              break;
            }
            if (this.time == 259)
            {
              Program.game.game.Quake(30, 3);
              break;
            }
            break;
          case Cname.MARISA:
            this.cs.SetPos(new Vector2(Player.body.position.X + 93f, Player.body.position.Y - 13f), true);
            Player.speedadd = new Vector2(0.15f, 0.02f);
            break;
          case Cname.SANAE:
            if (this.cs.Id == "e19")
            {
              Player.BanShoot = false;
              this.cs.SetPos(Player.body.position + new Vector2(93f, -13f), true);
              using (List<CrazyStorm>.Enumerator enumerator = csm.csc.GetEnumerator())
              {
                while (enumerator.MoveNext())
                {
                  foreach (Layer layer in enumerator.Current.layerm.LayerArray)
                  {
                    foreach (Barrage barrage in layer.Barrages)
                    {
                      if (!barrage.Invincible && barrage.time > 15 | !barrage.Mist && (!barrage.NeedDelete && Math.Sqrt(((double) barrage.x - (double) Player.body.position.X - 93.0) * ((double) barrage.x - (double) Player.body.position.X - 93.0) + ((double) barrage.y - (double) Player.body.position.Y + 13.0) * ((double) barrage.y - (double) Player.body.position.Y + 13.0)) <= 100.0))
                      {
                        barrage.life = 0;
                        barrage.Dis = true;
                        barrage.Blend = true;
                      }
                    }
                  }
                }
                break;
              }
            }
            else
              break;
          case Cname.PATCHOULI:
            foreach (CrazyStorm crazyStorm in csm.csc)
            {
              foreach (Layer layer in crazyStorm.layerm.LayerArray)
              {
                foreach (Barrage barrage in layer.Barrages)
                {
                  if (!barrage.Invincible && barrage.time > 15 | !barrage.Mist && (!barrage.NeedDelete && Math.Sqrt(((double) barrage.x - (double) Player.body.position.X - 93.0) * ((double) barrage.x - (double) Player.body.position.X - 93.0) + ((double) barrage.y - (double) Player.body.position.Y + 13.0) * ((double) barrage.y - (double) Player.body.position.Y + 13.0)) <= 168.0))
                  {
                    barrage.life = 0;
                    barrage.Dis = true;
                    barrage.Blend = true;
                  }
                }
              }
            }
            foreach (Enemy enemy in em.EnemyArray)
            {
              if (!enemy.IsInWudi() && Math.Sqrt(((double) enemy.Position.X - (double) Player.body.position.X) * ((double) enemy.Position.X - (double) Player.body.position.X) + ((double) enemy.Position.Y - (double) Player.body.position.Y) * ((double) enemy.Position.Y - (double) Player.body.position.Y)) <= 168.0)
              {
                enemy.hp -= 24;
                Program.game.game.Score += 10L;
              }
            }
            if (boss != null && Math.Sqrt(((double) boss.Position.X - (double) Player.body.position.X) * ((double) boss.Position.X - (double) Player.body.position.X) + ((double) boss.Position.Y - (double) Player.body.position.Y) * ((double) boss.Position.Y - (double) Player.body.position.Y)) <= 168.0)
            {
              Program.game.game.Score += 10L;
              if (boss.CardArray.Count >= 1)
                boss.CardArray[0].DeHp(24, this.cs.isforshoot);
            }
            if (this.cs.time.total - this.cs.time.now <= 20)
            {
              using (List<Layer>.Enumerator enumerator = this.cs.layerm.LayerArray.GetEnumerator())
              {
                while (enumerator.MoveNext())
                {
                  foreach (Barrage barrage in enumerator.Current.Barrages)
                    barrage.alpha = (float) ((this.cs.time.total - this.cs.time.now) * 5);
                }
                break;
              }
            }
            else
              break;
        }
      }
      if (this.cs == null)
      {
        if (this.wait == 0)
        {
          if (this.type == Cname.MARISA)
            Player.speedadd = new Vector2(1f, 1f);
          Player.BanShoot = false;
        }
        ++this.wait;
        Program.game.game.bgcolor.a -= 0.015f;
        if ((double) Program.game.game.bgcolor.a <= 0.0)
          Program.game.game.bgcolor.a = 0.0f;
        if (this.wait != 40)
          return;
        Player.body.color.r = 1f;
        Player.body.color.g = 1f;
        this.wait = 0;
        this.die = true;
      }
      else if (this.cs.IsClosing())
      {
        this.cs.EndStart();
        this.cs.Break();
        this.cs = (CrazyStorm) null;
      }
      else
      {
        if (!this.cs.Run())
          return;
        this.cs.Update(Player1, em, boss);
      }
    }
  }
}
