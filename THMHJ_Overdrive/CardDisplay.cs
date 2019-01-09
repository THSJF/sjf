// Decompiled with JetBrains decompiler
// Type: THMHJ.CardDisplay
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.Text;

namespace THMHJ
{
  internal class CardDisplay
  {
    private Texture2D tex;
    private Hashtable[] spellcard;
    private string cardname;
    private int stage;
    private int id;
    private int time;
    private float fontalpha;
    private Vector2 fontpos;
    private float fontpl;
    private float palpha;
    private Vector2 ppos;
    private float nalpha;
    private float bonus;
    private int clear;
    private int play;

    public string CardName
    {
      get
      {
        return this.cardname;
      }
    }

    public CardDisplay(Texture2D tex_t, Hashtable[] spellcard_h, int stage_i, int id_i)
    {
      this.tex = tex_t;
      this.spellcard = spellcard_h;
      this.stage = stage_i;
      this.id = id_i;
      this.fontpos = new Vector2(423f, 301f);
      this.ppos = new Vector2(223f, 292f);
      if (Main.SpecialMode != Modes.SPELLCARD)
      {
        this.cardname = (string) this.spellcard[(int) (Main.Level - 1)][(object) (this.stage.ToString() + this.id.ToString())];
        this.ReadRecord(this.cardname);
      }
      else
      {
        this.cardname = (string) this.spellcard[5][(object) this.id.ToString()];
        this.ReadRecord(Program.game.game.Spellcardid);
      }
      this.fontpl = (float) this.GetStringSize(this.cardname);
    }

    private int GetStringSize(string s)
    {
      int num = 0;
      for (int startIndex = 0; startIndex < s.Length; ++startIndex)
      {
        if (Encoding.Default.GetByteCount(s.Substring(startIndex, 1)) > 1)
          num += 18;
        else
          num += 10;
      }
      return num;
    }

    public void Update(float bonus_f)
    {
      this.bonus = bonus_f;
      ++this.time;
      if (this.time <= 50)
      {
        this.palpha += 0.1f;
        if ((double) this.palpha >= 1.0)
          this.palpha = 1f;
        this.fontalpha += 0.05f;
        if ((double) this.fontalpha >= 1.0)
          this.fontalpha = 1f;
        this.fontpos.X += (float) ((420.0 - (double) this.fontpl - (double) this.fontpos.X) / 10.0);
      }
      else if (this.time >= 50)
      {
        this.fontpos.Y += (float) ((34.0 - (double) this.fontpos.Y) / 20.0);
        this.ppos.Y += (float) ((25.0 - (double) this.ppos.Y) / 20.0);
      }
      if (this.time <= 100 || this.time > 140)
        return;
      this.nalpha += 0.025f;
    }

    public void Draw(SpriteBatch s, Character Player)
    {
      float a1 = this.palpha;
      if (Player != null && (double) Player.body.position.Y <= 120.0)
        a1 = this.palpha * (Player.body.position.Y / 120f);
      s.Draw(this.tex, this.ppos, new Rectangle?(new Rectangle(18, 52, 199, 34)), new Color(1f, 1f, 1f, a1), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
      float a2 = this.fontalpha;
      if (Player != null && (double) Player.body.position.Y <= 120.0)
        a2 = this.fontalpha * (Player.body.position.Y / 120f);
      Main.scfont.Draw(s, this.cardname, this.fontpos + new Vector2(1f, 1f), new Color(0.0f, 0.0f, 0.0f, a2));
      Main.scfont.Draw(s, this.cardname, this.fontpos, new Color(1f, 1f, 1f, a2));
      float a3 = this.nalpha;
      if (Player != null && (double) Player.body.position.Y <= 120.0)
        a3 = this.nalpha * (Player.body.position.Y / 120f);
      s.Draw(this.tex, new Vector2(230f, 52f), new Rectangle?(new Rectangle(11, 37, 39, 13)), new Color(1f, 1f, 1f, a3), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
      string str1 = this.bonus.ToString().PadLeft(7, '0');
      Main.scdfont.Draw(s, str1, new Vector2(270f, 53f) + new Vector2(1f, 1f), new Color(0.0f, 0.0f, 0.0f, a3));
      Main.scdfont.Draw(s, str1, new Vector2(270f, 53f), new Color(1f, 1f, 1f, a3));
      s.Draw(this.tex, new Vector2(322f, 52f), new Rectangle?(new Rectangle(123, 37, 45, 13)), new Color(1f, 1f, 1f, a3), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
      string str2 = this.play.ToString().PadLeft(3, '0');
      string str3 = this.clear.ToString().PadLeft(3, '0');
      Main.scdfont.Draw(s, str3 + "/" + str2, new Vector2(371f, 53f) + new Vector2(1f, 1f), new Color(0.0f, 0.0f, 0.0f, a3));
      Main.scdfont.Draw(s, str3 + "/" + str2, new Vector2(371f, 53f), new Color(1f, 1f, 1f, a3));
    }

    private void ReadRecord(string cardname)
    {
      foreach (SpellCardData spellCardData in Program.game.game.playdata.players[(int) (Main.Character - 1)].sc[(int) (Main.Level - 1)])
      {
        if (spellCardData.name == cardname)
        {
          this.play = spellCardData.playtime;
          this.clear = spellCardData.cleartime;
          break;
        }
      }
    }

    private void ReadRecord(int id)
    {
      SpecialData specialData = Program.game.game.LoadSpecialData();
      this.play = (int) specialData.spe[(int) (Main.Character - 1)].sc[id].playtime;
      this.clear = (int) specialData.spe[(int) (Main.Character - 1)].sc[id].cleartime;
    }
  }
}
