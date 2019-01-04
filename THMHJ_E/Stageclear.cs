// Decompiled with JetBrains decompiler
// Type: THMHJ.Stageclear
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace THMHJ
{
  internal class Stageclear
  {
    private static Stageclear stgc;
    private static int dt;
    private Texture2D tex;
    private StageData sd;
    private bool die;
    private float x1;
    private float x2;
    private float a1;
    private float a2;
    private float a3;
    private float a4;
    private float a5;
    private float a6;
    private float m1;
    private float m2;
    private long mo;
    private int time;

    public static void Updates()
    {
      if (Stageclear.stgc != null && !Stageclear.stgc.die)
      {
        Stageclear.stgc.Update();
        Stageclear.dt = 0;
      }
      else
      {
        if (Stageclear.stgc == null || !Stageclear.stgc.die)
          return;
        Stageclear.stgc.Close();
        ++Stageclear.dt;
        if (Stageclear.dt < 20)
          return;
        Stageclear.dt = 0;
        Stageclear.stgc = (Stageclear) null;
      }
    }

    public Stageclear(Texture2D tex_t, StageData sd_s)
    {
      this.tex = tex_t;
      this.sd = sd_s;
      Program.game.game.Drawevents += new Game.DrawDelegate(this.Draw);
      this.x1 = this.x2 = 280f;
      Stageclear.stgc = this;
    }

    public void Close()
    {
      Program.game.game.Drawevents -= new Game.DrawDelegate(this.Draw);
    }

    public void Update()
    {
      ++this.time;
      if (this.time == 1)
      {
        this.mo = Program.game.game.Score % 10L;
        this.m1 = this.sd.miss > 2 ? 0.0f : (float) ((3.0 - (double) this.sd.miss) * 0.00999999977648258 * ((double) Main.Level / 2.0));
        this.m2 = this.sd.bomb > 3 ? 0.0f : (float) ((4.0 - (double) this.sd.bomb) * 0.00999999977648258);
      }
      if (this.time <= 20)
        this.a1 += 0.05f;
      else if (this.time <= 40)
        this.a2 += 0.05f;
      else if (this.time <= 60)
        this.a3 += 0.05f;
      else if (this.time <= 80)
        this.a4 += 0.05f;
      else if (this.time <= 100)
        this.a5 += 0.05f;
      else if (this.time <= 120)
        this.a6 += 0.05f;
      if (this.time == 100 && this.sd.miss <= 3)
      {
        Program.game.game.PlaySound("bonus", false, 0.0f);
        long num1 = (long) ((double) Program.game.game.Score * (1.0 + (double) this.m1));
        long num2 = num1 - num1 % 10L;
        Program.game.game.Score = num2 + this.mo;
      }
      if (this.time == 120 && (Difficulty) this.sd.bomb <= 4 + Main.Level)
      {
        Program.game.game.PlaySound("bonus", false, 0.0f);
        long num1 = (long) ((double) Program.game.game.Score * (1.0 + (double) this.m2));
        long num2 = num1 - num1 % 10L;
        Program.game.game.Score = num2 + this.mo;
      }
      if (this.time >= 100 && this.time <= 140)
        this.x1 += (float) ((300.0 - (double) this.x1) / 20.0);
      if (this.time >= 120 && this.time <= 160)
        this.x2 += (float) ((300.0 - (double) this.x2) / 20.0);
      if (this.time >= 200 && this.time <= 220)
      {
        this.a5 -= 0.05f;
        this.x1 += (float) ((320.0 - (double) this.x1) / 20.0);
      }
      if (this.time >= 220 && this.time <= 240)
      {
        this.a6 -= 0.05f;
        this.x2 += (float) ((320.0 - (double) this.x2) / 20.0);
      }
      if (this.time >= 260 && this.time <= 280)
      {
        this.a1 -= 0.05f;
        this.a2 -= 0.05f;
        this.a3 -= 0.05f;
        this.a4 -= 0.05f;
      }
      if (this.time < 300)
        return;
      this.die = true;
    }

    public void Draw(SpriteBatch s)
    {
      s.Draw(this.tex, new Vector2(225f, 140f), new Rectangle?(new Rectangle(0, 282, 373, 68)), new Color(1f, 1f, 1f, this.a1), 0.0f, new Vector2(187f, 34f), 1f, SpriteEffects.None, 0.0f);
      s.Draw(this.tex, new Vector2(150f, 185f), new Rectangle?(new Rectangle(8, 154, 78, 19)), new Color(1f, 1f, 1f, this.a2));
      for (int index = 0; index < this.sd.miss.ToString().Length; ++index)
        s.Draw(this.tex, new Vector2((float) (253 + index * 8), 188f), new Rectangle?(new Rectangle(int.Parse(this.sd.miss.ToString()[index].ToString()) * 15, 9, 15, 20)), new Color(1f, 1f, 1f, this.a2), 0.0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.0f);
      s.Draw(this.tex, new Vector2(this.x1, 188f), new Rectangle?(new Rectangle(180, 9, 15, 20)), new Color(1f, 1f, 1f, this.a5), 0.0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.0f);
      s.Draw(this.tex, new Vector2(this.x1 + 8f, 188f), new Rectangle?(new Rectangle(15, 9, 15, 20)), new Color(1f, 1f, 1f, this.a5), 0.0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.0f);
      s.Draw(this.tex, new Vector2(this.x1 + 16f, 188f), new Rectangle?(new Rectangle(165, 9, 15, 20)), new Color(1f, 1f, 1f, this.a5), 0.0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.0f);
      if (this.time > 100)
      {
        string str = this.m1.ToString();
        if (str.Split('.').Length <= 1)
          str = "0.00";
        for (int index = 0; index < 2; ++index)
          s.Draw(this.tex, new Vector2(this.x1 + 24f + (float) (index * 8), 188f), new Rectangle?(new Rectangle(int.Parse(str.Split('.')[1].PadRight(2, '0')[index].ToString()) * 15, 9, 15, 20)), new Color(1f, 1f, 1f, this.a5), 0.0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.0f);
      }
      s.Draw(this.tex, new Vector2(150f, 210f), new Rectangle?(new Rectangle(8, 176, 78, 19)), new Color(1f, 1f, 1f, this.a3));
      for (int index = 0; index < this.sd.bomb.ToString().Length; ++index)
        s.Draw(this.tex, new Vector2((float) (253 + index * 8), 213f), new Rectangle?(new Rectangle(int.Parse(this.sd.bomb.ToString()[index].ToString()) * 15, 9, 15, 20)), new Color(1f, 1f, 1f, this.a3), 0.0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.0f);
      s.Draw(this.tex, new Vector2(this.x2, 213f), new Rectangle?(new Rectangle(180, 9, 15, 20)), new Color(1f, 1f, 1f, this.a6), 0.0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.0f);
      s.Draw(this.tex, new Vector2(this.x2 + 8f, 213f), new Rectangle?(new Rectangle(15, 9, 15, 20)), new Color(1f, 1f, 1f, this.a6), 0.0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.0f);
      s.Draw(this.tex, new Vector2(this.x2 + 16f, 213f), new Rectangle?(new Rectangle(165, 9, 15, 20)), new Color(1f, 1f, 1f, this.a6), 0.0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.0f);
      if (this.time <= 100)
        return;
      string str1 = this.m2.ToString();
      if (str1.Split('.').Length <= 1)
        str1 = "0.00";
      for (int index = 0; index < 2; ++index)
        s.Draw(this.tex, new Vector2(this.x2 + 24f + (float) (index * 8), 213f), new Rectangle?(new Rectangle(int.Parse(str1.Split('.')[1].PadRight(2, '0')[index].ToString()) * 15, 9, 15, 20)), new Color(1f, 1f, 1f, this.a6), 0.0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0.0f);
    }
  }
}
