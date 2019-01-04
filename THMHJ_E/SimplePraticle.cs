// Decompiled with JetBrains decompiler
// Type: THMHJ.SimplePraticle
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace THMHJ
{
  public class SimplePraticle
  {
    public Dictionary<string, float> values;
    private Texture2D image;
    private Rectangle rect;
    private Vector2 anchor;
    public Vector2 position;
    public Vector2 oposition;
    public float alpha;
    public float oalpha;
    public float rotate;
    public float orotate;
    public Vector2 scale;
    public Vector2 oscale;
    public int time;
    public bool NeedDis;

    public SimplePraticle(Texture2D image, Rectangle rect, Vector2 anchor)
    {
      this.image = image;
      this.rect = rect;
      this.anchor = anchor;
      this.values = new Dictionary<string, float>();
    }

    public void Backup(Vector2 position, float alpha, float rotate, Vector2 scale)
    {
      this.oposition = new Vector2(position.X, position.Y);
      this.oalpha = alpha;
      this.orotate = rotate;
      this.oscale = new Vector2(scale.X, scale.Y);
    }

    public void Update(PraticleUpdate itemupdate)
    {
      ++this.time;
      itemupdate(this);
    }

    public void Draw(SpriteBatch s)
    {
      s.Draw(this.image, this.position, new Rectangle?(this.rect), new Color(1f, 1f, 1f, this.alpha), MathHelper.ToRadians(this.rotate), this.anchor, this.scale, SpriteEffects.None, 0.0f);
    }
  }
}
