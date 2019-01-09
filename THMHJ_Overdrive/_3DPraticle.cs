// Decompiled with JetBrains decompiler
// Type: THMHJ._3DPraticle
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace THMHJ
{
  internal class _3DPraticle : _3DPraticleManager
  {
    private int time;
    public int id;
    public ModelM model;
    public Vector3 scale;
    public int life;
    public Vector3 Position;
    public Vector3 speed;
    public Vector3 acced;
    public Vector3 rotate;
    public Vector3 rotates;
    public float alpha;
    public bool fade;
    public int fadetime;
    public bool die;

    public void Update()
    {
      ++this.time;
      this.speed += this.acced;
      this.Position += this.speed;
      this.rotate += this.rotates;
      if (this.fade)
      {
        if ((double) this.Position.Y <= 0.0 && this.time < this.life)
          this.time = this.life;
        if (this.time >= 1 && this.time <= this.fadetime)
          this.alpha += 1f / (float) this.fadetime;
        else if (this.time >= this.life && this.time <= this.life + this.fadetime)
          this.alpha -= 1f / (float) this.fadetime;
      }
      else
        this.alpha = 1f;
      if (this.time < this.life || (double) this.alpha > 0.0 && this.fade)
        return;
      this.die = true;
    }

    public void Draw(bool Anti, Matrix view, Matrix projection, GraphicsDevice g)
    {
      this.model.alpha = this.alpha;
      this.model.ats = this.Position;
      this.model.scales = this.scale;
      this.model.rotations = this.rotate;
      this.model.Draw(Anti, view, projection, g);
    }
  }
}
