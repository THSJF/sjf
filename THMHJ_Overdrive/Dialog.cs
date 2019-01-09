// Decompiled with JetBrains decompiler
// Type: THMHJ.Dialog
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;

namespace THMHJ
{
  internal class Dialog
  {
    public static List<int> already;
    private Boss b;
    private StreamReader sr;
    private Sprite tex;
    private Sprite dm;
    private Sprite[] db;
    private Sprite name;
    private Vector2 left;
    private Vector2 right;
    private string n;
    private float dalpha;
    private int now;
    private int now2;
    private int last;
    private int last2;
    private float colorm;
    private float colorb;
    private float namecolor;
    private int nametime;
    private int nameid;
    private int time;
    private bool namestart;
    private bool start;
    public bool close;
    public bool next;
    public bool ok;

    public static void Init()
    {
      Dialog.already = new List<int>();
    }

    public Dialog(
      Sprite tex_s,
      Sprite dm_s,
      Sprite[] db_s,
      Sprite name_s,
      int stage,
      Cname c,
      int type,
      Boss b_b)
    {
      this.name = name_s;
      this.name.position = new Vector2(207f, 244f);
      this.colorm = this.colorb = 0.5f;
      this.now = this.now2 = -1;
      this.last = this.last2 = -1;
      this.b = b_b;
      this.sr = new StreamReader(Cry.Decry("Content/Data/d" + stage.ToString() + type.ToString() + ((int) c).ToString() + ".xna", 2));
      this.n = this.sr.ReadLine();
      if (this.n == "PAUSE")
      {
        this.next = true;
        this.time = 10;
      }
      else
      {
        string str = this.n.Split(']')[0].Remove(0, 1);
        if (str.Length != 2)
        {
          this.now = int.Parse(str[0].ToString());
          this.now2 = -1;
        }
        else
        {
          this.now = int.Parse(str[0].ToString());
          this.now2 = int.Parse(str[1].ToString());
        }
      }
      this.dm = dm_s;
      this.dm.color.a = 0.0f;
      this.db = db_s;
      for (int index = 0; index < this.db.Length; ++index)
        this.db[index].color.a = 0.0f;
      this.left = new Vector2(-30f, 92f);
      this.right = new Vector2(210f, 92f);
      this.tex = tex_s;
      this.tex.color.a = 0.0f;
      this.tex.origin = new Vector2(195f, 60f);
      this.tex.position = new Vector2(224f, 400f);
      Program.game.game.Drawevents += new Game.DrawDelegate(this.Draw);
    }

    public void Continue()
    {
      this.left = new Vector2(-30f, 92f);
      this.right = new Vector2(210f, 92f);
      this.ok = false;
      this.n = this.sr.ReadLine();
      this.next = false;
      if (this.n == null)
        this.close = true;
      else
        this.Read();
      this.time = 0;
    }

    private void Read()
    {
      string str = this.n.Split(']')[0].Remove(0, 1);
      if (str.Length != 2)
      {
        if (this.last2 == -1 || this.last == -1)
        {
          this.last = this.now;
          this.last2 = this.now2;
        }
        this.now = int.Parse(str[0].ToString());
        this.now2 = -1;
      }
      else
      {
        if (this.last2 != -1 || this.last == -1)
        {
          this.last = this.now;
          this.last2 = this.now2;
        }
        this.now = int.Parse(str[0].ToString());
        this.now2 = int.Parse(str[1].ToString());
      }
    }

    public void Update(Texture2D bgmt, int stage)
    {
      ++this.time;
      if (this.now2 != -1 && !this.namestart)
      {
        bool flag = false;
        foreach (int num in Dialog.already)
        {
          if (this.now == num)
          {
            flag = true;
            break;
          }
        }
        if (!flag)
        {
          this.namestart = true;
          this.nameid = this.now;
        }
      }
      if (this.namestart && !this.close && !this.next)
      {
        ++this.nametime;
        if (this.nametime > 60 && this.nametime <= 80)
          this.namecolor += 0.05f;
        if (this.nametime > 220 && this.nametime <= 240)
          this.namecolor -= 0.05f;
      }
      else
      {
        this.namecolor -= 0.1f;
        if ((double) this.namecolor <= 0.0)
          this.namecolor = 0.0f;
      }
      if (!this.close && !this.next)
      {
        if (this.time <= 10)
        {
          this.start = false;
          this.tex.color.a += 0.1f;
          if ((double) this.tex.color.a >= 1.0)
            this.tex.color.a = 1f;
          this.dalpha += 0.1f;
          if ((double) this.dalpha >= 1.0)
            this.dalpha = 1f;
          if (this.now2 != -1)
          {
            this.db[this.now].color.a += 0.1f;
            if ((double) this.db[this.now].color.a >= 1.0)
              this.db[this.now].color.a = 1f;
            this.colorb += 0.1f;
            if ((double) this.colorb >= 1.0)
              this.colorb = 1f;
            this.colorm -= 0.1f;
            if ((double) this.colorm <= 0.5)
              this.colorm = 0.5f;
          }
          else
          {
            this.dm.color.a += 0.1f;
            if ((double) this.dm.color.a >= 1.0)
              this.dm.color.a = 1f;
            this.colorb -= 0.1f;
            if ((double) this.colorb <= 0.5)
              this.colorb = 0.5f;
            this.colorm += 0.1f;
            if ((double) this.colorm >= 1.0)
              this.colorm = 1f;
          }
        }
        if (this.time >= 11 && Main.IsKeyUp(Keys.Z) && (Main.Replay || PadState.IsKeyUp(JOYKEYS.Confirm)) && !this.start)
          this.start = true;
        else if (this.time >= 11 && (Main.IsKeyDown(Keys.Z) || !Main.Replay && PadState.IsKeyDown(JOYKEYS.Confirm)) && this.start)
        {
          Program.game.game.PlaySound("plst", false, 0.0f);
          this.time = 0;
          this.dalpha = 0.0f;
          this.n = this.sr.ReadLine();
          if (this.n == "PAUSE")
          {
            this.next = true;
            this.start = false;
          }
          else if (this.n == "MUSIC")
          {
            BGM.Disposes();
            if (stage != 7)
            {
              BGM bgm1 = new BGM(bgmt, 3 + (stage - 1) * 2);
            }
            else
            {
              BGM bgm2 = new BGM(bgmt, 16);
            }
            Music.BGM.Play();
            this.n = this.sr.ReadLine();
            if (this.n == null)
              this.close = true;
            else
              this.Read();
          }
          else if (this.n == null)
            this.close = true;
          else
            this.Read();
        }
        this.tex.position.Y += (float) ((370.0 - (double) this.tex.position.Y) / 5.0);
        if (this.now2 == -1)
        {
          this.left.X += (float) ((0.0 - (double) this.left.X) / 5.0);
          this.left.Y += (float) ((62.0 - (double) this.left.Y) / 5.0);
          this.right.X += (float) ((210.0 - (double) this.right.X) / 5.0);
          this.right.Y += (float) ((92.0 - (double) this.right.Y) / 5.0);
        }
        else
        {
          this.left.X += (float) ((-30.0 - (double) this.left.X) / 5.0);
          this.left.Y += (float) ((92.0 - (double) this.left.Y) / 5.0);
          this.right.X += (float) ((180.0 - (double) this.right.X) / 5.0);
          this.right.Y += (float) ((62.0 - (double) this.right.Y) / 5.0);
        }
      }
      else if (this.time <= 10)
      {
        this.tex.color.a -= 0.1f;
        if ((double) this.tex.color.a <= 0.0)
          this.tex.color.a = 0.0f;
        this.tex.position.Y += (float) ((380.0 - (double) this.tex.position.Y) / 5.0);
        this.left.X -= 4f;
        this.right.X += 4f;
        this.dm.color.a -= 0.1f;
        if ((double) this.dm.color.a <= 0.0)
          this.dm.color.a = 0.0f;
        for (int index = 0; index < this.db.Length; ++index)
        {
          if (this.db[index] != null)
          {
            this.db[index].color.a -= 0.1f;
            if ((double) this.db[index].color.a <= 0.0)
              this.db[index].color.a = 0.0f;
          }
        }
      }
      else
      {
        if (this.time < 11)
          return;
        for (int index = 0; index < this.db.Length; ++index)
        {
          if (this.db[index] != null)
          {
            --this.db[index].color.r;
            this.db[index].color.b = 1f;
            this.db[index].color.g = 1f;
          }
        }
        this.ok = true;
        if (this.namestart)
          Dialog.already.Add(this.nameid);
        this.tex.color.a = 0.0f;
        this.time = 11;
        if (!this.close)
          return;
        Program.game.game.Drawevents -= new Game.DrawDelegate(this.Draw);
      }
    }

    public void Draw(SpriteBatch s)
    {
      if (this.n != null && this.n != "PAUSE" && this.n != "MUSIC")
      {
        if (this.now2 != -1)
        {
          this.db[this.now].position = this.right;
          this.db[this.now].color.r = this.db[this.now].color.g = this.db[this.now].color.b = this.colorb;
          this.db[this.now].rect = new Rectangle(this.now2 * 298, 0, 298, 421);
          this.db[this.now].Draw(s, SpriteEffects.None, 0.0f);
          if (this.last != -1)
          {
            this.dm.position = this.left;
            this.dm.color.r = this.dm.color.g = this.dm.color.b = this.colorm;
            this.dm.rect = new Rectangle(this.last * 298, 0, 298, 421);
            this.dm.Draw(s, SpriteEffects.None, 0.0f);
          }
        }
        else if (this.now != -1)
        {
          this.dm.position = this.left;
          this.dm.color.r = this.dm.color.g = this.dm.color.b = this.colorm;
          this.dm.rect = new Rectangle(this.now * 298, 0, 298, 421);
          this.dm.Draw(s, SpriteEffects.None, 0.0f);
          if (this.last2 != -1)
          {
            this.db[this.last].position = this.right;
            this.db[this.last].color.r = this.db[this.last].color.g = this.db[this.last].color.b = this.colorb;
            this.db[this.last].rect = new Rectangle(this.last2 * 298, 0, 298, 421);
            this.db[this.last].Draw(s, SpriteEffects.None, 0.0f);
          }
        }
        this.tex.Draw(s, SpriteEffects.None, 0.0f);
        char[] charArray = this.n.Split(']')[1].ToCharArray();
        int length = charArray.Length;
        int num1 = 0;
        int num2 = 0;
        while (length > 0)
        {
          string str = "";
          for (int index = num2; index < 21 + num2 && length > 0; ++index)
          {
            str += charArray[index].ToString();
            --length;
          }
          Main.dfont.Draw(s, str, new Vector2(55f, (float) (334 + num1)), new Color(0.0f, 0.0f, 0.0f, this.dalpha));
          if (this.now2 == -1)
            Main.dfont.Draw(s, str, new Vector2(54f, (float) (333 + num1)), new Color(0.0f, 1f, 0.0f, this.dalpha));
          else
            Main.dfont.Draw(s, str, new Vector2(54f, (float) (333 + num1)), new Color(1f, 0.0f, 0.0f, this.dalpha));
          num1 += 21;
          num2 += 21;
        }
      }
      else if (this.now2 != -1)
      {
        this.db[this.now].position = this.right;
        this.db[this.now].color.r = this.db[this.now].color.g = this.db[this.now].color.b = this.colorb;
        this.db[this.now].rect = new Rectangle(this.now2 * 298, 0, 298, 421);
        this.db[this.now].Draw(s, SpriteEffects.None, 0.0f);
        this.dm.position = this.left;
        this.dm.color.r = this.dm.color.g = this.dm.color.b = this.colorm;
        this.dm.rect = new Rectangle(this.last * 298, 0, 298, 421);
        this.dm.Draw(s, SpriteEffects.None, 0.0f);
      }
      else if (this.now != -1)
      {
        this.dm.position = this.left;
        this.dm.color.r = this.dm.color.g = this.dm.color.b = this.colorm;
        this.dm.rect = new Rectangle(this.now * 298, 0, 298, 421);
        this.dm.Draw(s, SpriteEffects.None, 0.0f);
        if (this.last2 != -1)
        {
          this.db[this.last].position = this.right;
          this.db[this.last].color.r = this.db[this.last].color.g = this.db[this.last].color.b = this.colorb;
          this.db[this.last].rect = new Rectangle(this.last2 * 298, 0, 298, 421);
          this.db[this.last].Draw(s, SpriteEffects.None, 0.0f);
        }
      }
      if (!this.namestart)
        return;
      this.name.rect = new Rectangle(0, this.nameid * 72, 207, 72);
      this.name.color.a = this.namecolor;
      this.name.Draw(s, SpriteEffects.None, 0.0f);
    }
  }
}
