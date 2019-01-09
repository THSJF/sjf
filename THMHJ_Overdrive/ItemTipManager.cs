// Decompiled with JetBrains decompiler
// Type: THMHJ.ItemTipManager
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace THMHJ
{
  public class ItemTipManager
  {
    private Texture2D tex;
    private List<ItemTip> ItemTipm;

    public Texture2D Tex
    {
      get
      {
        return this.tex;
      }
    }

    public ItemTipManager(Texture2D tex_t)
    {
      this.tex = tex_t;
      this.ItemTipm = new List<ItemTip>();
    }

    public void Add(ItemTip a)
    {
      this.ItemTipm.Add(a);
    }

    public void Update()
    {
      for (int index = 0; index < this.ItemTipm.Count; ++index)
      {
        if (!this.ItemTipm[index].die)
        {
          this.ItemTipm[index].Update();
        }
        else
        {
          this.ItemTipm.RemoveAt(index);
          --index;
        }
      }
    }

    public void Draw(SpriteBatch s)
    {
      for (int index = 0; index < this.ItemTipm.Count; ++index)
      {
        if (!this.ItemTipm[index].die)
          this.ItemTipm[index].Draw(s);
      }
    }
  }
}
