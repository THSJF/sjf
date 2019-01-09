// Decompiled with JetBrains decompiler
// Type: THMHJ.SimplePraticleActor
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace THMHJ
{
  internal class SimplePraticleActor
  {
    public Vector2 emitrange;
    public Vector2 emitcenter;
    public int emitcycle;
    public int emitdensity;
    private bool ifemit;
    private Texture2D image;
    private bool addon;
    private Rectangle imagerect;
    private Vector2 imageanchor;
    public Vector2 praticlescale;
    public Vector2 scalerange;
    public float praticlealpha;
    public Vector2 alpharange;
    public float praticlerotate;
    public Vector2 rotaterange;
    private PraticleUpdate itemupdate;
    private List<SimplePraticle> box;
    private int time;

    public bool IsEmitting
    {
      get
      {
        return this.ifemit;
      }
    }

    public SimplePraticleActor(
      Vector2 emitcenter,
      Vector2 emitrange,
      int emitcycle,
      int emitdensity)
    {
      this.emitcenter = emitcenter;
      this.emitrange = emitrange;
      this.emitcycle = emitcycle;
      this.emitdensity = emitdensity;
      this.box = new List<SimplePraticle>();
    }

    public void SetTexture(Texture2D image, bool addon)
    {
      this.image = image;
      this.imageanchor = new Vector2((float) image.Width / 2f, (float) image.Height / 2f);
      this.addon = addon;
    }

    public void SetTexture(Texture2D image, Rectangle rect, Vector2 anchor, bool addon)
    {
      this.image = image;
      this.imagerect = rect;
      this.imageanchor = anchor;
      this.addon = addon;
    }

    public void SetPraticle(
      Vector2 scale,
      Vector2 scalerange,
      float alpha,
      Vector2 alpharange,
      float rotate,
      Vector2 rotaterange)
    {
      this.praticlescale = scale;
      this.scalerange = scalerange;
      this.praticlealpha = alpha;
      this.alpharange = alpharange;
      this.praticlerotate = rotate;
      this.rotaterange = rotaterange;
    }

    public void SetPraticleEvent(PraticleUpdate itemupdate)
    {
      this.itemupdate = itemupdate;
    }

    public void Start()
    {
      this.ifemit = true;
    }

    public void Stop()
    {
      this.ifemit = false;
    }

    public void Update()
    {
      if (this.ifemit)
      {
        ++this.time;
        if (this.time % this.emitcycle == 0)
        {
          for (int index = 0; index < this.emitdensity; ++index)
          {
            SimplePraticle simplePraticle = new SimplePraticle(this.image, this.imagerect, this.imageanchor);
            simplePraticle.position = new Vector2(this.emitcenter.X + MathHelper.Lerp(-this.emitrange.X, this.emitrange.X, (float) Main.rand.NextDouble()), this.emitcenter.Y + MathHelper.Lerp(-this.emitrange.Y, this.emitrange.Y, (float) Main.rand.NextDouble()));
            simplePraticle.alpha = this.praticlealpha + MathHelper.Lerp(this.alpharange.X, this.alpharange.Y, (float) Main.rand.NextDouble());
            double num1 = (double) MathHelper.Lerp(this.rotaterange.X, this.rotaterange.Y, (float) Main.rand.NextDouble());
            simplePraticle.rotate = this.praticlerotate;
            float num2 = MathHelper.Lerp(this.scalerange.X, this.scalerange.Y, (float) Main.rand.NextDouble());
            simplePraticle.scale = new Vector2(this.praticlescale.X + num2, this.praticlescale.Y + num2);
            simplePraticle.Backup(simplePraticle.position, simplePraticle.alpha, simplePraticle.rotate, simplePraticle.scale);
            this.box.Add(simplePraticle);
          }
        }
      }
      for (int index = 0; index < this.box.Count; ++index)
      {
        if (!this.box[index].NeedDis)
        {
          this.box[index].Update(this.itemupdate);
        }
        else
        {
          this.box.RemoveAt(index);
          --index;
        }
      }
    }

    public void Draw(SpriteBatch s)
    {
      if (this.addon)
      {
        s.End();
        s.Begin(SpriteBlendMode.Additive);
      }
      for (int index = 0; index < this.box.Count; ++index)
        this.box[index].Draw(s);
      if (!this.addon)
        return;
      s.End();
      s.Begin();
    }
  }
}
