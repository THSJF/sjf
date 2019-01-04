// Decompiled with JetBrains decompiler
// Type: THMHJ.Sprite
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace THMHJ
{
  public class Sprite
  {
    public Vector2 position = Vector2.Zero;
    public Colors color = new Colors(1f, 1f, 1f, 0.0f);
    public Vector2 origin = Vector2.Zero;
    public Vector2 scale = new Vector2(1f, 1f);
    private Texture2D texture;
    public Rectangle rect;
    public float rotation;
    public float speed;
    public float aspeed;
    public bool IsDisposed;

    public Texture2D Texture
    {
      get
      {
        return this.texture;
      }
    }

    public Sprite()
    {
    }

    public Sprite(Texture2D t)
    {
      this.texture = t;
      this.rect = Rectangle.Empty;
    }

    public Sprite(Texture2D t, Rectangle r)
    {
      this.texture = t;
      this.rect = r;
    }

    public void Draw(SpriteBatch s)
    {
      this.Draw(s, SpriteEffects.None, 0.0f);
    }

    public void Draw(SpriteBatch s, SpriteEffects e, float depth)
    {
      if ((double) this.color.a <= 0.0)
        return;
      if (this.rect == Rectangle.Empty)
        s.Draw(this.texture, this.position, new Rectangle?(), new Color(this.color.r, this.color.g, this.color.b, this.color.a), MathHelper.ToRadians(this.rotation), this.origin, this.scale, e, depth);
      else
        s.Draw(this.texture, this.position, new Rectangle?(this.rect), new Color(this.color.r, this.color.g, this.color.b, this.color.a), MathHelper.ToRadians(this.rotation), this.origin, this.scale, e, depth);
    }

    public void Dispose()
    {
      this.texture.Dispose();
      this.IsDisposed = true;
    }
  }
}
