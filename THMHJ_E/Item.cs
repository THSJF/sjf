// Decompiled with JetBrains decompiler
// Type: THMHJ.Item
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace THMHJ
{
  public class Item
  {
    private Texture2D tex;
    private ItemType type;
    private int time;
    private Vector2 speed;
    private float direction;
    private float rotate;
    private Rectangle rect;
    private Vector2 pos;
    private bool clear;
    public bool die;
    public bool ok;
    public bool max;

    public ItemType Type
    {
      get
      {
        return this.type;
      }
    }

    public Item(Texture2D tex_t, ItemType type_i, Rectangle rect_r, Vector2 pos_v)
    {
      this.tex = tex_t;
      this.type = type_i;
      this.rect = rect_r;
      this.pos = pos_v;
      this.direction = this.type != ItemType.Green ? -90f : MathHelper.Lerp(-96f, -84f, (float) Main.Rand(false));
      this.direction = MathHelper.ToRadians(this.direction);
      this.speed = new Vector2(3.5f * (float) Math.Cos((double) this.direction), 3.5f * (float) Math.Sin((double) this.direction));
    }

    public void Clear()
    {
      this.clear = true;
      this.ok = true;
    }

    public void Update(ItemManager im, ItemTipManager itm, Vector2 ppos, bool ban, bool auto)
    {
      if (Main.IsYDownOut(this.pos.Y))
        this.die = true;
      if (!this.die && !ban && ppos != Vector2.Zero)
      {
        if (this.type == ItemType.Green && this.time >= 50)
          this.ok = true;
        if ((double) ppos.Y <= (double) Main.gn.Itemline[(int) (Main.Character - 1)] || auto)
        {
          this.ok = true;
          this.max = true;
        }
        if (((double) this.pos.X - (double) ppos.X) * ((double) this.pos.X - (double) ppos.X) + ((double) this.pos.Y - (double) ppos.Y) * ((double) this.pos.Y - (double) ppos.Y) <= (double) (Main.IsKeyDown(Keys.LeftShift) || Main.IsKeyDown(Keys.RightShift) || !Main.Replay && PadState.IsKeyDown(JOYKEYS.Slow) ? 3600 : 900))
          this.ok = true;
        if (this.ok)
        {
          if (!this.ok)
          {
            this.pos.X += (float) (5.0 * Math.Cos((double) Main.Twopointangle(ppos.X, ppos.Y, this.pos.X, this.pos.Y))) * Time.Stop;
            this.pos.Y += (float) (5.0 * Math.Sin((double) Main.Twopointangle(ppos.X, ppos.Y, this.pos.X, this.pos.Y))) * Time.Stop;
          }
          else
          {
            this.pos.X += (float) (10.0 * Math.Cos((double) Main.Twopointangle(ppos.X, ppos.Y, this.pos.X, this.pos.Y))) * Time.Stop;
            this.pos.Y += (float) (10.0 * Math.Sin((double) Main.Twopointangle(ppos.X, ppos.Y, this.pos.X, this.pos.Y))) * Time.Stop;
          }
          if (Math.Abs((int) this.pos.X - (int) ppos.X) <= 4 && Math.Abs((int) this.pos.Y - (int) ppos.Y) <= 4)
          {
            Program.game.game.PlaySound("item", true, ppos.X);
            switch (this.type)
            {
              case ItemType.BigBlue:
                int num1 = (double) ppos.Y < (double) Main.gn.Itemline[(int) (Main.Character - 1)] || this.max ? 20000 + Program.game.game.MaxBlue : 50 * (545 - (int) ppos.Y) + Program.game.game.MaxBlue;
                int score_i1 = num1 - num1 % 10;
                Program.game.game.Score += (long) score_i1;
                ItemTip itemTip1 = new ItemTip(itm, this.pos, score_i1, (double) ppos.Y >= (double) Main.gn.Itemline[(int) (Main.Character - 1)] & !this.max);
                break;
              case ItemType.Blue:
                int num2 = (double) ppos.Y < (double) Main.gn.Itemline[(int) (Main.Character - 1)] || this.max ? 10000 + Program.game.game.MaxBlue : 25 * (545 - (int) ppos.Y) + Program.game.game.MaxBlue;
                int score_i2 = num2 - num2 % 10;
                Program.game.game.Score += (long) score_i2;
                ItemTip itemTip2 = new ItemTip(itm, this.pos, score_i2, (double) ppos.Y >= (double) Main.gn.Itemline[(int) (Main.Character - 1)] & !this.max);
                break;
              case ItemType.BigRed:
                Program.game.game.Score += 200000L;
                if (Program.game.game.Point < 200)
                {
                  Program.game.game.Point += 20;
                  if (Program.game.game.Point >= 200)
                  {
                    Program.game.game.Point = 200;
                    ItemTip itemTip3 = new ItemTip(itm, this.pos, TipType.FullPower, false);
                  }
                  if (Program.game.game.Point % 50 == 0)
                  {
                    Program.game.game.PlaySound("powerup", true, ppos.X);
                    break;
                  }
                  break;
                }
                break;
              case ItemType.Red:
                Program.game.game.Score += 10000L;
                if (Program.game.game.Point < 200)
                {
                  ++Program.game.game.Point;
                  if (Program.game.game.Point >= 200)
                  {
                    Program.game.game.Point = 200;
                    ItemTip itemTip3 = new ItemTip(itm, this.pos, TipType.FullPower, false);
                  }
                  if (Program.game.game.Point % 50 == 0)
                  {
                    Program.game.game.PlaySound("powerup", true, ppos.X);
                    break;
                  }
                  break;
                }
                break;
              case ItemType.Full:
                Program.game.game.Score += 2000000L;
                if (Program.game.game.Point < 200)
                  Program.game.game.PlaySound("powerup", true, ppos.X);
                Program.game.game.Point = 200;
                ItemTip itemTip4 = new ItemTip(itm, this.pos, TipType.FullPower, false);
                break;
              case ItemType.BigUp:
                Program.game.game.Score += 1000000L;
                Program.game.game.Life += 5;
                Program.game.game.PlaySound("extend", true, ppos.X);
                break;
              case ItemType.Up:
                ++Program.game.game.Life;
                if (Program.game.game.Life % 5 == 0)
                {
                  Program.game.game.Score += 1000000L;
                  Program.game.game.PlaySound("extend", true, ppos.X);
                  break;
                }
                break;
              case ItemType.BigBomb:
                Program.game.game.Bomb += 5;
                Program.game.game.PlaySound("cardget", true, ppos.X);
                break;
              case ItemType.Bomb:
                ++Program.game.game.Bomb;
                if (Program.game.game.Bomb % 5 == 0)
                {
                  Program.game.game.PlaySound("cardget", true, ppos.X);
                  break;
                }
                break;
              case ItemType.Green:
                Program.game.game.Score += 100L;
                Program.game.game.MaxBlue += 5;
                break;
            }
            this.die = true;
          }
        }
      }
      else
        this.ok = false;
      if ((double) this.speed.Y <= 0.0)
        this.rotate += 1f * Time.Stop;
      else
        this.rotate = 0.0f;
      if ((double) this.speed.Y < 1.5)
      {
        this.speed.Y += 0.07f;
      }
      else
      {
        this.speed.X -= 0.01f;
        if ((double) this.speed.X <= 0.0)
          this.speed.X = 0.0f;
      }
      this.pos.X += this.speed.X * Time.Stop;
      this.pos.Y += this.speed.Y * Time.Stop;
      if ((double) this.pos.Y >= 500.0)
        this.die = true;
      ++this.time;
    }

    public void Draw(SpriteBatch s, Vector2 q)
    {
      if (!this.clear)
      {
        int num1 = Main.Mode != Modes.SINGLE ? 0 : 16;
        float num2 = this.pos.Y - (float) num1;
        if ((double) num2 < 0.0)
        {
          Color color = new Color(1f, 1f, 1f, (float) (-(double) num2 / 10.0));
          if (this.type <= ItemType.Blue)
            s.Draw(this.tex, new Vector2(this.pos.X + q.X, (float) num1), new Rectangle?(new Rectangle(6, 38, 16, 13)), color, 0.0f, new Vector2(8f, 0.0f), 1f, SpriteEffects.None, 0.0f);
          else if (this.type <= ItemType.Red)
            s.Draw(this.tex, new Vector2(this.pos.X + q.X, (float) num1), new Rectangle?(new Rectangle(25, 38, 16, 13)), color, 0.0f, new Vector2(8f, 0.0f), 1f, SpriteEffects.None, 0.0f);
          else if (this.type == ItemType.Full)
            s.Draw(this.tex, new Vector2(this.pos.X + q.X, (float) num1), new Rectangle?(new Rectangle(44, 38, 16, 13)), color, 0.0f, new Vector2(8f, 0.0f), 1f, SpriteEffects.None, 0.0f);
          else if (this.type <= ItemType.Up)
          {
            s.Draw(this.tex, new Vector2(this.pos.X + q.X, (float) num1), new Rectangle?(new Rectangle(63, 38, 16, 13)), color, 0.0f, new Vector2(8f, 0.0f), 1f, SpriteEffects.None, 0.0f);
          }
          else
          {
            if (this.type > ItemType.Bomb)
              return;
            s.Draw(this.tex, new Vector2(this.pos.X + q.X, (float) num1), new Rectangle?(new Rectangle(82, 38, 16, 13)), color, 0.0f, new Vector2(8f, 0.0f), 1f, SpriteEffects.None, 0.0f);
          }
        }
        else
          s.Draw(this.tex, new Vector2(this.pos.X + q.X, this.pos.Y + q.Y), new Rectangle?(this.rect), Color.White, this.rotate, new Vector2((float) this.rect.Width / 2f, (float) this.rect.Height / 2f), 1f, SpriteEffects.None, 0.0f);
      }
      else
        s.Draw(this.tex, new Vector2(this.pos.X + q.X, this.pos.Y + q.Y), new Rectangle?(new Rectangle(178, 16, 11, 11)), Color.White, this.rotate, new Vector2(6f, 6f), 1f, SpriteEffects.None, 0.0f);
    }
  }
}
