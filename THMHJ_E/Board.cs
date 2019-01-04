// Decompiled with JetBrains decompiler
// Type: THMHJ.Board
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace THMHJ
{
  internal class Board
  {
    private Texture2D board;
    private Vector2 position;
    private float alpha;
    private string text;
    private int time;
    private bool achiv;
    private bool finished;

    public bool Finished
    {
      get
      {
        return this.finished;
      }
    }

    public Board(Texture2D board, string text)
    {
      this.board = board;
      this.text = text;
      this.position = new Vector2(214f, -45f);
      this.achiv = true;
    }

    public void UseDefault()
    {
      this.achiv = false;
    }

    public void Update()
    {
      if (this.time == 10 && this.achiv)
        Program.game.PlaySound("achivget");
      if (this.time < 20)
      {
        this.position.Y += 2.3f;
        this.alpha += 0.05f;
      }
      if (this.time >= 180 && this.time < 200)
      {
        this.position.Y -= 2.3f;
        this.alpha -= 0.05f;
      }
      if (this.time == 200)
        this.finished = true;
      ++this.time;
    }

    public void Draw(SpriteBatch s)
    {
      s.Draw(this.board, this.position, new Rectangle?(new Rectangle(0, 0, 214, 45)), new Color(1f, 1f, 1f, this.alpha), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
      if (this.achiv)
      {
        s.Draw(this.board, this.position + new Vector2(10f, 5f), new Rectangle?(new Rectangle(215, 0, 39, 28)), new Color(1f, 1f, 1f, this.alpha), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        Vector2 vector2 = new Vector2(Main.dfont.MeasureString(this.text).X, 0.0f);
        Vector2 position = this.position + new Vector2((float) (int) (50.0 + (157.0 - (double) Main.dfont.MeasureString(this.text + "达成").X) / 2.0), 7f);
        Main.dfont.Draw(s, this.text, position + new Vector2(1f, 1f), new Color(0.0f, 0.0f, 0.0f, this.alpha));
        Main.dfont.Draw(s, this.text, position, new Color(1f, 1f, 0.0f, this.alpha));
        Main.dfont.Draw(s, "达成", position + vector2 + new Vector2(1f, 1f), new Color(0.0f, 0.0f, 0.0f, this.alpha));
        Main.dfont.Draw(s, "达成", position + vector2, new Color(1f, 1f, 1f, this.alpha));
      }
      else
      {
        Vector2 position = this.position + new Vector2((float) (int) ((217.0 - (double) Main.dfont.MeasureString(this.text).X) / 2.0), 7f);
        Main.dfont.Draw(s, this.text, position + new Vector2(1f, 1f), new Color(0.0f, 0.0f, 0.0f, this.alpha));
        Main.dfont.Draw(s, this.text, position, new Color(1f, 1f, 1f, this.alpha));
      }
    }
  }
}
