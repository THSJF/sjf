// Decompiled with JetBrains decompiler
// Type: THMHJ.SelfBarrage
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace THMHJ
{
  public class SelfBarrage : SelfBarrageManager
  {
    public Colors color = new Colors(1f, 1f, 1f, 0.0f);
    public Vector2 origin = Vector2.Zero;
    public Vector2 scale = new Vector2(1f, 1f);
    private Enemy target;
    private Texture2D shape;
    public Vector2 Position;
    public Rectangle rect;
    public float alpha;
    public float rotation;
    public float speed;
    public float speedx;
    public float speedy;
    public float speedd;
    public int power;
    public float time;
    public float dx;
    public float dy;
    public int label;
    public bool straight;
    public bool ignore;
    public bool chase;
    public bool further;
    public bool rotate;
    public bool ＮeedDelete;
    public bool Judged;

    public SelfBarrage(
      Texture2D t,
      Rectangle r,
      Vector2 o,
      Vector2 p,
      float alpha_f,
      Vector2 scale_v)
    {
      this.shape = t;
      this.rect = r;
      this.origin = o;
      this.Position = p;
      this.alpha = alpha_f;
      this.scale = scale_v;
      SelfBarrageManager.SBArray.Add(this);
    }

    public void Update(EnemyManager e, Boss b, Character Player)
    {
      float num1 = Player.body.position.X + 93f;
      float num2 = Player.body.position.Y - 13f;
      if (!this.straight)
        this.time += Time.Stop;
      else
        ++this.time;
      this.speedx = this.speed * (float) Math.Cos((double) MathHelper.ToRadians(this.speedd));
      this.speedy = this.speed * (float) Math.Sin((double) MathHelper.ToRadians(this.speedd));
      this.Position.X += this.speedx * Time.Stop;
      this.Position.Y += this.speedy * Time.Stop;
      if (this.straight && !Player.Dis && !Player.Ban)
      {
        this.Position.X = (float) ((double) num1 + (double) this.dx + (double) this.time * (double) this.speed * Math.Cos((double) MathHelper.ToRadians(this.speedd)));
        this.Position.Y = (float) ((double) num2 + (double) this.dy + (double) this.time * (double) this.speed * Math.Sin((double) MathHelper.ToRadians(this.speedd)));
      }
      float radians = 0.0f;
      if ((double) this.speed != 0.0)
      {
        if ((double) this.speedy != 0.0)
        {
          radians = 1.570796f - (float) Math.Atan((double) this.speedx / (double) this.speedy);
          if ((double) this.speedy < 0.0)
            radians += 3.141593f;
        }
        else
        {
          if ((double) this.speedx >= 0.0)
            radians = 0.0f;
          if ((double) this.speedx < 0.0)
            radians = 3.141593f;
        }
        if ((double) this.speed > 0.0)
        {
          this.speedd = MathHelper.ToDegrees(radians);
          if (this.rotate)
            this.rotation += 5f * Time.Stop;
          else
            this.rotation = this.speedd;
        }
        else if (this.rotate)
          this.rotation += 5f * Time.Stop;
        else
          this.rotation = MathHelper.ToDegrees(radians);
      }
      if (!this.Judged || this.straight)
      {
        this.color.a += 0.5f;
        if ((double) this.color.a >= (double) this.alpha)
          this.color.a = this.alpha;
        Vector2 vector2_1;
        Vector2 vector2_2;
        if (Main.Mode == Modes.SINGLE)
        {
          vector2_1 = new Vector2(-50f, 450f);
          vector2_2 = new Vector2(-50f, 490f);
        }
        else
        {
          vector2_1 = new Vector2(-50f, 690f);
          vector2_2 = new Vector2(-50f, 330f);
        }
        if (this.chase)
        {
          float num3 = -1f;
          float num4 = -1f;
          float num5 = -1f;
          float num6 = 0.0f;
          float num7 = 0.0f;
          float num8 = 0.0f;
          if (b != null && b.IsTarget())
          {
            num4 = (float) Math.Sqrt(((double) this.Position.X - (double) b.Position.X) * ((double) this.Position.X - (double) b.Position.X) + ((double) this.Position.Y - (double) b.Position.Y) * ((double) this.Position.Y - (double) b.Position.Y));
            num7 = MathHelper.ToDegrees(Main.Twopointangle(b.Position.X, b.Position.Y, this.Position.X, this.Position.Y));
            if ((double) num7 <= 0.0)
              num7 = 360f + num7;
          }
          this.target = e.MinDistance(this.Position, Player.body.position.X, this.further);
          if (!this.target.die)
          {
            num5 = (float) Math.Sqrt(((double) this.Position.X - (double) this.target.Position.X) * ((double) this.Position.X - (double) this.target.Position.X) + ((double) this.Position.Y - (double) this.target.Position.Y) * ((double) this.Position.Y - (double) this.target.Position.Y));
            num8 = MathHelper.ToDegrees(Main.Twopointangle(this.target.Position.X, this.target.Position.Y, this.Position.X, this.Position.Y));
            if ((double) num8 <= 0.0)
              num8 = 360f + num8;
          }
          if ((double) num4 != -1.0)
          {
            num3 = num4;
            num6 = num7;
          }
          if ((double) num5 != -1.0)
          {
            num3 = num5;
            num6 = num8;
          }
          if ((double) num4 != -1.0 && (double) num5 != -1.0 && (double) num4 < (double) num5)
          {
            num3 = num4;
            num6 = num7;
          }
          else if ((double) num4 != -1.0 && (double) num5 != -1.0)
          {
            num3 = num5;
            num6 = num8;
          }
          if ((double) this.speedd > 180.0 && (double) num6 < 180.0 && (double) Math.Abs(this.speedd - num6) > 180.0)
            num6 += 360f;
          if ((double) num3 != -1.0)
            this.speedd += (float) (((double) num6 - (double) this.speedd) / ((double) num3 / (double) this.speed));
        }
        if ((double) this.Position.X < (double) vector2_1.X || (double) this.Position.X > (double) vector2_1.Y || ((double) this.Position.Y < (double) vector2_2.X || (double) this.Position.Y > (double) vector2_2.Y))
          this.ＮeedDelete = true;
        if (!this.ignore)
        {
          float num3 = e.Judge(this.Position, (int) ((double) this.power * (double) Time.Stop));
          if ((double) num3 != 0.0 && (double) num3 != 0.0)
          {
            this.Judged = true;
            Program.game.game.Score += 10L;
          }
          if (b != null && (double) b.Judge(this.Position, (int) ((double) this.power * (double) Time.Stop)) != 0.0)
          {
            this.Judged = true;
            Program.game.game.Score += 10L;
          }
        }
        if (!this.Judged || !this.straight)
          return;
        this.color.g -= 0.1f;
        this.color.b -= 0.1f;
        if ((double) this.color.g > 0.0)
          return;
        this.color = new Colors(1f, 0.0f, 0.0f, 1f);
      }
      else
      {
        this.speed = 2f;
        this.scale.X += 0.2f;
        this.scale.Y += 0.2f;
        this.color.a -= 0.07f;
        if ((double) this.color.a > 0.0)
          return;
        this.ＮeedDelete = true;
      }
    }

    public void Draw(SpriteBatch s, Vector2 q)
    {
      s.End();
      s.Begin(SpriteBlendMode.Additive);
      s.Draw(this.shape, new Vector2(this.Position.X + q.X, this.Position.Y + q.Y), new Rectangle?(this.rect), new Color(this.color.r, this.color.g, this.color.b, this.color.a), MathHelper.ToRadians(this.rotation + 90f), this.origin, this.scale, SpriteEffects.None, 0.0f);
      s.End();
      s.Begin();
    }
  }
}
