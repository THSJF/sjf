// Decompiled with JetBrains decompiler
// Type: THMHJ.Caution
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace THMHJ
{
  internal class Caution
  {
    private Texture2D tex;
    private Vector2 pos;
    private Vector2 scale;
    private float alpha;
    private int time;
    public bool die;

    public Caution(CautionManager m, Texture2D tex_t, Vector2 pos_v)
    {
      this.pos = pos_v;
      this.tex = tex_t;
      this.scale = new Vector2(2f, 0.0f);
      m.Add(this);
    }

    public void Update()
    {
      ++this.time;
      if (this.time <= 10)
      {
        this.scale.X -= 0.1f;
        this.scale.Y += 0.1f;
        this.alpha += 0.1f;
      }
      if (this.time >= 70 && this.time <= 80)
      {
        this.scale.X += 0.1f;
        this.scale.Y -= 0.1f;
        this.alpha -= 0.1f;
      }
      if (this.time < 80)
        return;
      this.die = true;
    }

    public void Draw(SpriteBatch s)
    {
      s.Draw(this.tex, this.pos, new Rectangle?(new Rectangle(0, 0, 76, 30)), new Color(1f, 1f, 1f, this.alpha), 0.0f, new Vector2(38f, 15f), this.scale, SpriteEffects.None, 0.0f);
    }
  }
}
