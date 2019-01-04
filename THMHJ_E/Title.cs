// Decompiled with JetBrains decompiler
// Type: THMHJ.Title
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace THMHJ
{
  internal class Title
  {
    private static Title title;
    private Sprite tex;
    private float titlescale;
    private float titlealpha;
    private float tipalpha;
    private int time;
    private int stage;
    private bool die;

    public static void Update()
    {
      if (Title.title != null && !Title.title.die)
      {
        Title.title.Updates();
      }
      else
      {
        if (Title.title == null || !Title.title.die)
          return;
        Title.title.Close();
        Title.title = (Title) null;
      }
    }

    public Title(int stage_i, Sprite stagetitle)
    {
      this.tex = stagetitle;
      this.stage = stage_i;
      this.titlescale = 2f;
      Program.game.game.Drawevents += new Game.DrawDelegate(this.Draw);
      Title.title = this;
    }

    public void Close()
    {
      Program.game.game.Drawevents -= new Game.DrawDelegate(this.Draw);
    }

    public void Updates()
    {
      ++this.time;
      if (this.time >= 1 && this.time <= 25)
        this.titlealpha += 0.04f;
      if (this.time >= 25 && this.time <= 75)
        this.tipalpha += 0.02f;
      if (this.time >= 200 && this.time <= 250)
        this.titlealpha -= 0.02f;
      if (this.time >= 250 && this.time <= 300)
        this.tipalpha -= 0.02f;
      this.titlescale += (float) ((1.0 - (double) this.titlescale) / 20.0);
      if (this.time <= 300)
        return;
      this.die = true;
    }

    public void Draw(SpriteBatch s)
    {
      this.tex.rect = this.stage % 2 != 1 ? new Rectangle(380, (this.stage - 1) / 2 * 120, 380, 93) : new Rectangle(0, this.stage / 2 * 120, 380, 93);
      this.tex.origin = new Vector2(190f, 45f);
      this.tex.position = new Vector2(226f, 173f);
      this.tex.color.a = this.titlealpha;
      this.tex.scale = new Vector2(this.titlescale, this.titlescale);
      if ((double) this.titlealpha > 0.0)
        this.tex.Draw(s, SpriteEffects.None, 0.0f);
      this.tex.rect = this.stage % 2 != 1 ? new Rectangle(380, 93 + (this.stage - 1) / 2 * 120, 380, 30) : new Rectangle(0, 93 + this.stage / 2 * 120, 380, 30);
      this.tex.origin = new Vector2(190f, 15f);
      this.tex.position = new Vector2(226f, 230f);
      this.tex.color.a = this.tipalpha;
      this.tex.scale = new Vector2(1f, 1f);
      if ((double) this.tipalpha <= 0.0)
        return;
      this.tex.Draw(s, SpriteEffects.None, 0.0f);
    }
  }
}
