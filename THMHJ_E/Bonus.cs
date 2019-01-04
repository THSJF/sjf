// Decompiled with JetBrains decompiler
// Type: THMHJ.Bonus
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace THMHJ
{
  internal class Bonus
  {
    private static Bonus bonus;
    private Texture2D tex;
    private float a1;
    private float a2;
    private float a3;
    private float y1;
    private float y2;
    private float y3;
    private int score;
    private int type;
    private int time;
    private int t;
    private bool overtime;
    private bool die;

    public static void Dispose()
    {
      Bonus.bonus = (Bonus) null;
    }

    public static bool IsBonused()
    {
      return Bonus.bonus != null;
    }

    public static void Updates()
    {
      if (Bonus.bonus != null && !Bonus.bonus.die)
      {
        Bonus.bonus.Update();
      }
      else
      {
        if (Bonus.bonus == null || !Bonus.bonus.die)
          return;
        Bonus.bonus.Close();
        Bonus.bonus = (Bonus) null;
      }
    }

    public Bonus(int score_i, int type_i, int time_i)
    {
      this.score = score_i;
      this.type = type_i;
      this.time = time_i;
      this.tex = Program.game.game.Getex("bosslist");
      this.y1 = 100f;
      this.y2 = 120f;
      this.y3 = 150f;
      Program.game.game.Drawevents += new Game.DrawDelegate(this.Draw);
      Program.game.game.Score += (long) this.score;
      Bonus.bonus = this;
    }

    public Bonus(int score_i, int type_i, int time_i, bool overtime_b)
    {
      this.overtime = overtime_b;
      this.score = score_i;
      this.type = type_i;
      this.time = time_i;
      this.tex = Program.game.game.Getex("bosslist");
      this.y1 = 100f;
      this.y2 = 120f;
      this.y3 = 150f;
      Program.game.game.Drawevents += new Game.DrawDelegate(this.Draw);
      Program.game.game.Score += (long) this.score;
      Bonus.bonus = this;
    }

    public void Close()
    {
      Program.game.game.Drawevents -= new Game.DrawDelegate(this.Draw);
    }

    public void Update()
    {
      ++this.t;
      if (this.t <= 120)
        this.y1 += (float) ((120.0 - (double) this.y1) / 10.0);
      else
        this.y1 += (float) ((100.0 - (double) this.y1) / 10.0);
      if (this.t <= 20)
        this.a1 += 0.05f;
      else if (this.t >= 120 && this.t <= 240)
        this.a1 -= 0.05f;
      if (this.t >= 30 && this.t <= 150)
        this.y2 += (float) ((150.0 - (double) this.y2) / 10.0);
      else if (this.t >= 150)
        this.y2 += (float) ((120.0 - (double) this.y2) / 10.0);
      if (this.t >= 30 && this.t <= 50)
        this.a2 += 0.05f;
      else if (this.t >= 150 && this.t <= 170)
        this.a2 -= 0.05f;
      if (this.t >= 60 && this.t <= 180)
        this.y3 += (float) ((180.0 - (double) this.y3) / 10.0);
      else if (this.t >= 180)
        this.y3 += (float) ((150.0 - (double) this.y3) / 10.0);
      if (this.t >= 60 && this.t <= 80)
        this.a3 += 0.05f;
      else if (this.t >= 180 && this.t <= 200)
        this.a3 -= 0.05f;
      if ((double) this.a1 <= 0.0)
        this.a1 = 0.0f;
      if ((double) this.a2 <= 0.0)
        this.a2 = 0.0f;
      if ((double) this.a3 <= 0.0)
        this.a3 = 0.0f;
      if ((double) this.a1 >= 1.0)
        this.a1 = 1f;
      if ((double) this.a2 >= 1.0)
        this.a2 = 1f;
      if ((double) this.a3 >= 1.0)
        this.a3 = 1f;
      if (this.t < 200)
        return;
      this.die = true;
    }

    public void Draw(SpriteBatch s)
    {
      if (Bonus.bonus == null)
        return;
      if (this.type == 1)
      {
        if (this.score != 0 && !this.overtime)
          s.Draw(this.tex, new Vector2(224f, this.y1), new Rectangle?(new Rectangle(7, 103, 212, 24)), new Color(1f, 1f, 1f, this.a1), 0.0f, new Vector2(106f, 12f), 1f, SpriteEffects.None, 0.0f);
        else
          s.Draw(this.tex, new Vector2(224f, this.y1), new Rectangle?(new Rectangle(7, (int) sbyte.MaxValue, 131, 20)), new Color(1f, 1f, 1f, this.a1), 0.0f, new Vector2(66f, 10f), 1f, SpriteEffects.None, 0.0f);
      }
      for (int index = 0; index < 8 - this.score.ToString().Length; ++index)
        s.Draw(this.tex, new Vector2((float) (162 + index * 15), this.y2), new Rectangle?(new Rectangle(0, 9, 15, 20)), new Color(1f, 1f, 1f, this.a2));
      char[] charArray = this.score.ToString().ToCharArray();
      for (int index = 8 - this.score.ToString().Length; index < 8; ++index)
        s.Draw(this.tex, new Vector2((float) (162 + index * 15), this.y2), new Rectangle?(new Rectangle(int.Parse(charArray[index - 8 + this.score.ToString().Length].ToString()) * 15, 9, 15, 20)), new Color(1f, 1f, 1f, this.a2));
      s.Draw(this.tex, new Vector2(159f, this.y3), new Rectangle?(new Rectangle((int) byte.MaxValue, 109, 76, 16)), new Color(1f, 1f, 1f, this.a3), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
      float num = (float) this.time / 60f;
      string str1 = num.ToString().Split('.')[0].PadLeft(2, '0');
      for (int index = 0; index < 2; ++index)
        s.Draw(this.tex, new Vector2((float) (235 + index * 8), this.y3 + 1f), new Rectangle?(new Rectangle(int.Parse(str1[index].ToString()) * 15, 9, 15, 20)), new Color(1f, 1f, 1f, this.a3), 0.0f, Vector2.Zero, 0.7f, SpriteEffects.None, 0.0f);
      string str2;
      if (num.ToString().Split('.').Length <= 1)
        str2 = "00";
      else
        str2 = num.ToString().Split('.')[1].PadLeft(2, '0');
      s.Draw(this.tex, new Vector2(249f, this.y3 + 1f), new Rectangle?(new Rectangle(165, 9, 15, 20)), new Color(1f, 1f, 1f, this.a3), 0.0f, Vector2.Zero, 0.7f, SpriteEffects.None, 0.0f);
      for (int index = 0; index < 2; ++index)
        s.Draw(this.tex, new Vector2((float) ((int) byte.MaxValue + index * 8), this.y3 + 1f), new Rectangle?(new Rectangle(int.Parse(str2[index].ToString()) * 15, 9, 15, 20)), new Color(1f, 1f, 1f, this.a3), 0.0f, Vector2.Zero, 0.7f, SpriteEffects.None, 0.0f);
      s.Draw(this.tex, new Vector2(271f, this.y3 + 1f), new Rectangle?(new Rectangle(150, 9, 15, 20)), new Color(1f, 1f, 1f, this.a3), 0.0f, Vector2.Zero, 0.7f, SpriteEffects.None, 0.0f);
    }

    public static int GetScore(int type, float time, bool dob)
    {
      int num = 2000000 + 2000000 * Program.game.game.StmStage - (int) ((double) time / 60.0 * 50000.0);
      if (dob)
        num /= 2;
      if (type == 0)
        num /= 2;
      return num;
    }
  }
}
