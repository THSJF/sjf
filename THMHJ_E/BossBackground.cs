// Decompiled with JetBrains decompiler
// Type: THMHJ.BossBackground
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.Collections.Generic;

namespace THMHJ
{
  public class BossBackground
  {
    private List<BSprite> bsc;
    private bool start;
    private int time;
    private Texture2D render;

    public bool Start
    {
      get
      {
        return this.start;
      }
    }

    public Texture2D Render
    {
      get
      {
        return this.render;
      }
    }

    public BossBackground(List<string> text, Hashtable tex)
    {
      this.bsc = new List<BSprite>();
      foreach (string eve in text)
      {
        string[] strArray = eve.Split('(')[1].Split(')')[0].Split(',');
        if (eve.Contains("Create"))
          this.bsc.Add(new BSprite((Texture2D) tex[(object) strArray[0]], bool.Parse(strArray[1]), new Vector2(float.Parse(strArray[2]), float.Parse(strArray[3])), new Vector2(float.Parse(strArray[4]), float.Parse(strArray[5])), float.Parse(strArray[6]), int.Parse(strArray[7])));
        else if (eve.Contains("SetMove"))
          this.Search(int.Parse(strArray[0]))?.SetMove(new Vector2(float.Parse(strArray[1]), float.Parse(strArray[2])));
        else if (eve.Contains("SetRotate"))
          this.Search(int.Parse(strArray[0]))?.SetRotate(float.Parse(strArray[1]));
        else if (eve.Contains("SetScale"))
          this.Search(int.Parse(strArray[0]))?.SetScale(new Vector2(float.Parse(strArray[1]), float.Parse(strArray[2])));
        else if (eve.Contains("TurnWhen"))
          this.Search(int.Parse(strArray[0]))?.TurnWhen(eve);
      }
    }

    private BSprite Search(int id)
    {
      foreach (BSprite bsprite in this.bsc)
      {
        if (bsprite.Id == id)
          return bsprite;
      }
      return (BSprite) null;
    }

    public void Switch(bool start_b)
    {
      this.start = start_b;
      if (this.start)
      {
        this.time = 0;
      }
      else
      {
        this.time = 0;
        foreach (BSprite bsprite in this.bsc)
          bsprite.Init();
      }
    }

    public void Update()
    {
      if (!this.start)
        return;
      if (this.time < 60)
        ++this.time;
      foreach (BSprite bsprite in this.bsc)
        bsprite.Update();
    }

    public void Draw(SpriteBatch s, GraphicsDevice gd, RenderTarget2D r)
    {
      if (this.start)
      {
        gd.SetRenderTarget(0, r);
        gd.Clear(Color.Black);
        foreach (BSprite bsprite in this.bsc)
        {
          if (!bsprite.Add)
            bsprite.Draw(s);
        }
        s.End();
        s.Begin(SpriteBlendMode.Additive);
        foreach (BSprite bsprite in this.bsc)
        {
          if (bsprite.Add)
            bsprite.Draw(s);
        }
        s.End();
        s.Begin();
        gd.SetRenderTarget(0, (RenderTarget2D) null);
        this.render = r.GetTexture();
      }
      else
        this.render = (Texture2D) null;
    }
  }
}
