// Decompiled with JetBrains decompiler
// Type: THMHJ.ItemManager
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace THMHJ
{
  public class ItemManager
  {
    private List<ItemManager> itemm;
    private Texture2D tex;
    private float bblue;
    private float blue;
    private float bred;
    private float red;
    private float full;
    private float bup;
    private float up;
    private float bbomb;
    private float bomb;
    public List<Item> items;
    private Vector2 ppos;
    public bool die;
    public bool shot;
    public bool ban;
    private bool grazed;

    public bool Grazed
    {
      get
      {
        return this.grazed;
      }
    }

    public ItemManager(List<ItemManager> im, Texture2D tex_t)
    {
      this.itemm = im;
      this.tex = tex_t;
      this.items = new List<Item>();
    }

    public ItemManager(
      List<ItemManager> im,
      Texture2D tex_t,
      float bblue_f,
      float blue_f,
      float bred_f,
      float red_f,
      float up_f,
      float bomb_f)
    {
      this.itemm = im;
      this.tex = tex_t;
      this.bblue = bblue_f;
      this.blue = blue_f;
      this.bred = bred_f;
      this.red = red_f;
      this.up = up_f;
      this.bomb = bomb_f;
      this.items = new List<Item>();
    }

    public ItemManager(
      List<ItemManager> im,
      Texture2D tex_t,
      float bblue_f,
      float blue_f,
      float bred_f,
      float red_f,
      float full_f,
      float bup_f,
      float up_f,
      float bbomb_f,
      float bomb_f)
    {
      this.itemm = im;
      this.tex = tex_t;
      this.bblue = bblue_f;
      this.blue = blue_f;
      this.bred = bred_f;
      this.red = red_f;
      this.full = full_f;
      this.bup = bup_f;
      this.up = up_f;
      this.bbomb = bbomb_f;
      this.bomb = bomb_f;
      this.items = new List<Item>();
    }

    public void DeathShoot(Vector2 pos)
    {
      this.shot = true;
      for (int index = 1; (double) index < (double) this.red; ++index)
        this.items.Add(new Item(this.tex, ItemType.Red, new Rectangle(63, 15, 13, 13), new Vector2(pos.X + 80f * (float) Math.Cos((double) MathHelper.ToRadians((float) (180 + index * 20))), pos.Y + 60f * (float) Math.Sin((double) MathHelper.ToRadians((float) (180 + index * 20))))));
      for (int index = 0; index < 2; ++index)
        this.items.Add(new Item(this.tex, ItemType.BigRed, new Rectangle(40, 10, 17, 17), new Vector2(MathHelper.Lerp(pos.X - 30f, pos.X + 30f, (float) Main.Rand(false)), MathHelper.Lerp(pos.Y - 40f, pos.Y + 20f, (float) Main.Rand(false)))));
    }

    public void SmallShoot(Vector2 pos)
    {
      this.shot = true;
      this.items.Add(new Item(this.tex, ItemType.Green, new Rectangle(178, 16, 11, 11), pos));
    }

    public void Shoot(Vector2 pos, float size, Character Player, Boss boss)
    {
      this.shot = true;
      if ((double) this.bblue > 0.0 && (double) MathHelper.Lerp(0.0f, 100f, (float) Main.Rand(false)) <= (double) this.bblue)
        this.items.Add(new Item(this.tex, ItemType.BigBlue, new Rectangle(0, 10, 18, 18), new Vector2(MathHelper.Lerp(pos.X - size, pos.X + size, (float) Main.Rand(false)), MathHelper.Lerp(pos.Y - size, pos.Y + size, (float) Main.Rand(false)))));
      for (int index = 0; (double) index < (double) this.blue; ++index)
        this.items.Add(new Item(this.tex, ItemType.Blue, new Rectangle(23, 15, 13, 13), new Vector2(MathHelper.Lerp(pos.X - size / 2f, pos.X + size / 2f, (float) Main.Rand(false)), MathHelper.Lerp(pos.Y - size / 2f, pos.Y + size / 2f, (float) Main.Rand(false)))));
      if ((double) this.bred > 0.0 && (double) MathHelper.Lerp(0.0f, 100f, (float) Main.Rand(false)) <= (double) this.bred)
      {
        float x = MathHelper.Lerp(pos.X - size, pos.X + size, (float) Main.Rand(false));
        float y = MathHelper.Lerp(pos.Y - size, pos.Y + size, (float) Main.Rand(false));
        if (Program.game.game.Point < 200)
          this.items.Add(new Item(this.tex, ItemType.BigRed, new Rectangle(40, 10, 17, 17), new Vector2(x, y)));
        else
          this.items.Add(new Item(this.tex, ItemType.BigBlue, new Rectangle(0, 10, 18, 18), new Vector2(x, y)));
      }
      for (int index = 0; (double) index < (double) this.red; ++index)
      {
        float x = MathHelper.Lerp(pos.X - size / 2f, pos.X + size / 2f, (float) Main.Rand(false));
        float y = MathHelper.Lerp(pos.Y - size / 2f, pos.Y + size / 2f, (float) Main.Rand(false));
        if (Program.game.game.Point < 200)
          this.items.Add(new Item(this.tex, ItemType.Red, new Rectangle(63, 15, 13, 13), new Vector2(x, y)));
        else
          this.items.Add(new Item(this.tex, ItemType.Blue, new Rectangle(23, 15, 13, 13), new Vector2(x, y)));
      }
      for (int index = 0; (double) index < (double) this.full; ++index)
        this.items.Add(new Item(this.tex, ItemType.Full, new Rectangle(82, 9, 19, 19), new Vector2(MathHelper.Lerp(pos.X - size / 2f, pos.X + size / 2f, (float) Main.Rand(false)), MathHelper.Lerp(pos.Y - size / 2f, pos.Y + size / 2f, (float) Main.Rand(false)))));
      if (boss != null && !Player.dead || boss == null)
      {
        if (boss != null)
          Program.game.game.PlaySound("bonus", true, this.ppos.X);
        if ((double) this.bup > 0.0 && (double) MathHelper.Lerp(0.0f, 100f, (float) Main.Rand(false)) <= (double) this.bup)
          this.items.Add(new Item(this.tex, ItemType.BigUp, new Rectangle(107, 0, 29, 29), new Vector2(MathHelper.Lerp(pos.X - size, pos.X + size, (float) Main.Rand(false)), MathHelper.Lerp(pos.Y - size, pos.Y + size, (float) Main.Rand(false)))));
        for (int index = 0; (double) index < (double) this.up; ++index)
          this.items.Add(new Item(this.tex, ItemType.Up, new Rectangle(111, 35, 21, 21), new Vector2(MathHelper.Lerp(pos.X - size / 2f, pos.X + size / 2f, (float) Main.Rand(false)), MathHelper.Lerp(pos.Y - size / 2f, pos.Y + size / 2f, (float) Main.Rand(false)))));
      }
      if ((double) this.bbomb > 0.0 && (double) MathHelper.Lerp(0.0f, 100f, (float) Main.Rand(false)) <= (double) this.bbomb)
        this.items.Add(new Item(this.tex, ItemType.BigBomb, new Rectangle(141, 3, 27, 26), new Vector2(MathHelper.Lerp(pos.X - size, pos.X + size, (float) Main.Rand(false)), MathHelper.Lerp(pos.Y - size, pos.Y + size, (float) Main.Rand(false)))));
      for (int index = 0; (double) index < (double) this.bomb; ++index)
        this.items.Add(new Item(this.tex, ItemType.Bomb, new Rectangle(143, 35, 21, 21), new Vector2(MathHelper.Lerp(pos.X - size / 2f, pos.X + size / 2f, (float) Main.Rand(false)), MathHelper.Lerp(pos.Y - size / 2f, pos.Y + size / 2f, (float) Main.Rand(false)))));
    }

    public int GetCount()
    {
      if (!this.shot)
        return 1;
      return this.items.Count;
    }

    public void Transpos(float x, float y)
    {
      this.ppos = new Vector2(x, y);
    }

    public void Ban(bool b)
    {
      this.ban = b;
    }

    public void Clear(ItemType type)
    {
      foreach (ItemManager itemManager in this.itemm)
      {
        foreach (Item obj in itemManager.items)
        {
          if (!obj.die && type == ItemType.BigBlue)
            obj.Clear();
          else if (!obj.die && obj.Type == type)
            obj.Clear();
        }
      }
    }

    public void Update(ItemTipManager itm, bool auto)
    {
      this.grazed = false;
      for (int index = 0; index < this.items.Count; ++index)
      {
        if (!this.items[index].die)
        {
          this.items[index].Update(this, itm, this.ppos, this.ban, auto);
          if (this.items[index].ok)
            this.grazed = true;
        }
        else
        {
          this.items.RemoveAt(index);
          --index;
        }
      }
    }

    public void Draw(SpriteBatch s, Vector2 Quakeset)
    {
      for (int index = 0; index < this.items.Count; ++index)
      {
        if (!this.items[index].die)
          this.items[index].Draw(s, Quakeset);
      }
    }
  }
}
