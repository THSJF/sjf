// Decompiled with JetBrains decompiler
// Type: THMHJ.ItemTip
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace THMHJ
{
  public class ItemTip
  {
    private TipType type;
    private Texture2D tex;
    private Vector2 pos;
    private bool max;
    private int score;
    private float alpha;
    private int time;
    public bool die;

    public ItemTip(ItemTipManager m, Vector2 pos_v, int score_i, bool max)
    {
      this.pos = pos_v;
      this.tex = m.Tex;
      this.score = score_i;
      this.alpha = 0.8f;
      this.type = TipType.Item;
      this.max = max;
      m.Add(this);
    }

    public ItemTip(ItemTipManager m, Vector2 pos_v, TipType type_t, bool max)
    {
      this.pos = pos_v;
      this.tex = m.Tex;
      this.type = type_t;
      this.alpha = 0.8f;
      this.max = max;
      m.Add(this);
    }

    public void Update()
    {
      ++this.time;
      if (this.time >= 1 && this.time <= 30)
        this.pos.Y -= 0.5f;
      if (this.time >= 20 && this.time <= 60)
        this.alpha -= 0.02f;
      if (this.time <= 60)
        return;
      this.die = true;
    }

    public void Draw(SpriteBatch s)
    {
      if (this.type == TipType.Item)
      {
        char[] charArray = this.score.ToString().ToCharArray();
        for (int index = 0; index < charArray.Length; ++index)
        {
          int num = int.Parse(charArray[index].ToString());
          if (this.max)
            s.Draw(this.tex, this.pos - new Vector2((float) (11.0 * (double) charArray.Length / 2.0) - (float) (index * 11), 15f), new Rectangle?(new Rectangle(243 + num * 11, 69, 11, 11)), new Color(1f, 1f, 1f, this.alpha), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
          else
            s.Draw(this.tex, this.pos - new Vector2((float) (11.0 * (double) charArray.Length / 2.0) - (float) (index * 11), 15f), new Rectangle?(new Rectangle(243 + num * 11, 80, 11, 11)), new Color(1f, 1f, 1f, this.alpha), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        }
      }
      else
      {
        if (this.type != TipType.FullPower)
          return;
        s.Draw(this.tex, this.pos - new Vector2(0.0f, 25f), new Rectangle?(new Rectangle(191, 35, 83, 17)), new Color(1f, 1f, 1f, this.alpha), 0.0f, new Vector2(42f, 9f), 1f, SpriteEffects.None, 0.0f);
      }
    }
  }
}
