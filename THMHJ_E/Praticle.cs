// Decompiled with JetBrains decompiler
// Type: THMHJ.Praticle
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace THMHJ
{
  public class Praticle : PraticleManager
  {
    public Rectangle sourcerect;
    public Vector4 posrect;
    public Vector2 origin;
    public int quantity;
    public Vector4 scale;
    public int life;
    public int LIFE;
    public float speed;
    public float speedr;
    public float acced;
    public Vector2 angle;
    public Vector4 rotation;
    public float calpha;
    public float alpha;
    public float fade;
    public int time;
    public int TIME;
    public bool stop;
    private bool Addable;
    public List<Praticle> Mine;

    public Praticle(
      bool diy,
      bool Ad,
      Rectangle sr,
      Vector4 pr,
      Vector2 og,
      int qt,
      int LF,
      int lf,
      float sp,
      float ac,
      Vector2 ag,
      float fd)
    {
      this.sourcerect = sr;
      this.posrect = pr;
      this.origin = og;
      this.quantity = qt;
      this.scale = new Vector4(1f, 0.0f, 1f, 0.0f);
      this.life = lf;
      this.LIFE = LF;
      this.TIME = 0;
      this.time = 0;
      this.speed = sp;
      this.acced = ac;
      this.angle = ag;
      this.rotation = Vector4.Zero;
      this.alpha = 0.0f;
      this.fade = fd;
      this.Addable = Ad;
      this.stop = false;
      this.Mine = new List<Praticle>();
      if (diy)
        return;
      if (Ad)
        PraticleManager.APraticleArray.Add(this);
      else
        PraticleManager.PraticleArray.Add(this);
    }

    public void Update()
    {
      if (this.quantity - 60 <= 0 && this.TIME % (60 / this.quantity) == 0 & !this.stop)
      {
        Praticle praticle = (Praticle) this.MemberwiseClone();
        praticle.alpha = this.calpha;
        praticle.speed += MathHelper.Lerp(0.0f, this.speedr, (float) Main.rand.NextDouble());
        praticle.posrect.X += MathHelper.Lerp(0.0f, this.posrect.Z, (float) Main.rand.NextDouble());
        praticle.posrect.Y += MathHelper.Lerp(0.0f, this.posrect.W, (float) Main.rand.NextDouble());
        praticle.scale.X += MathHelper.Lerp(-praticle.scale.Y, praticle.scale.Y, (float) Main.rand.NextDouble());
        praticle.scale.Z += MathHelper.Lerp(-praticle.scale.W, praticle.scale.W, (float) Main.rand.NextDouble());
        praticle.rotation.X += MathHelper.Lerp(-praticle.rotation.Y, praticle.rotation.Y, (float) Main.rand.NextDouble());
        praticle.rotation.Z += MathHelper.Lerp(-praticle.rotation.W, praticle.rotation.W, (float) Main.rand.NextDouble());
        praticle.angle.X += MathHelper.Lerp(-praticle.angle.Y, praticle.angle.Y, (float) Main.rand.NextDouble());
        this.Mine.Add(praticle);
      }
      if (this.quantity - 60 > 0 & !this.stop)
      {
        for (int index = 0; index < this.quantity - 60; ++index)
        {
          Praticle praticle = (Praticle) this.MemberwiseClone();
          praticle.alpha = this.calpha;
          praticle.speed += MathHelper.Lerp(0.0f, this.speedr, (float) Main.rand.NextDouble());
          praticle.posrect.X += MathHelper.Lerp(0.0f, this.posrect.Z, (float) Main.rand.NextDouble());
          praticle.posrect.Y += MathHelper.Lerp(0.0f, this.posrect.W, (float) Main.rand.NextDouble());
          praticle.scale.X += MathHelper.Lerp(-praticle.scale.Y, praticle.scale.Y, (float) Main.rand.NextDouble());
          praticle.scale.Z += MathHelper.Lerp(-praticle.scale.W, praticle.scale.W, (float) Main.rand.NextDouble());
          praticle.rotation.X += MathHelper.Lerp(-praticle.rotation.Y, praticle.rotation.Y, (float) Main.rand.NextDouble());
          praticle.rotation.Z += MathHelper.Lerp(-praticle.rotation.W, praticle.rotation.W, (float) Main.rand.NextDouble());
          praticle.angle.X += MathHelper.Lerp(-praticle.angle.Y, praticle.angle.Y, (float) Main.rand.NextDouble());
          this.Mine.Add(praticle);
        }
        this.stop = true;
      }
      foreach (Praticle praticle in this.Mine)
      {
        if (praticle.time <= praticle.life)
        {
          if ((double) praticle.time <= (double) praticle.fade)
          {
            praticle.alpha += 1f / praticle.fade;
            if ((double) praticle.alpha >= 1.0)
              praticle.alpha = 1f;
          }
          if ((double) praticle.time >= (double) praticle.life - (double) praticle.fade)
          {
            praticle.alpha -= 1f / praticle.fade;
            if ((double) praticle.alpha <= 0.0)
              praticle.alpha = 0.0f;
          }
          praticle.scale.X += (praticle.scale.Z - praticle.scale.X) / (float) praticle.life;
          praticle.speed += praticle.acced;
          praticle.posrect.X += praticle.speed * (float) Math.Cos((double) MathHelper.ToRadians(praticle.angle.X));
          praticle.posrect.Y += praticle.speed * (float) Math.Sin((double) MathHelper.ToRadians(praticle.angle.X));
          praticle.rotation.X += (praticle.rotation.Z - praticle.rotation.X) / (float) praticle.life;
          ++praticle.time;
        }
      }
      ++this.TIME;
      if (this.TIME < this.LIFE || this.LIFE == 0)
        return;
      this.stop = true;
    }

    public void Draw(SpriteBatch s, Vector2 q)
    {
      foreach (Praticle praticle in this.Mine)
      {
        if (praticle.time <= praticle.life && (double) praticle.alpha > 0.0)
          s.Draw(PraticleManager.practile, new Vector2(praticle.posrect.X + q.X, praticle.posrect.Y + q.Y), new Rectangle?(praticle.sourcerect), new Color(1f, 1f, 1f, praticle.alpha), MathHelper.ToRadians(praticle.rotation.X), praticle.origin, praticle.scale.X, SpriteEffects.None, 0.0f);
      }
    }

    public void Delete()
    {
      this.Mine.Clear();
      if (this.Addable)
        PraticleManager.APraticleArray.Remove(this);
      else
        PraticleManager.PraticleArray.Remove(this);
    }
  }
}
