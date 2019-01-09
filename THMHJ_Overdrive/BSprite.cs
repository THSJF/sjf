// Decompiled with JetBrains decompiler
// Type: THMHJ.BSprite
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace THMHJ
{
  internal class BSprite
  {
    private Texture2D tex;
    private Vector2 origin;
    private Vector2 Position;
    private Vector2 scale;
    private Vector2 speed;
    private float rotate;
    private float rspeed;
    private float alpha;
    private float nowa;
    private bool add;
    private int id;
    private List<string> events;

    public bool Add
    {
      get
      {
        return this.add;
      }
    }

    public int Id
    {
      get
      {
        return this.id;
      }
    }

    public BSprite(
      Texture2D tex_t,
      bool add_b,
      Vector2 ori,
      Vector2 pos,
      float alpha_f,
      int id_i)
    {
      this.tex = tex_t;
      this.add = add_b;
      this.Position = pos;
      this.origin = ori;
      this.alpha = alpha_f;
      this.id = id_i;
      this.scale = new Vector2(1f, 1f);
      this.events = new List<string>();
    }

    public void Init()
    {
      this.nowa = 0.0f;
    }

    public void SetMove(Vector2 speed_v)
    {
      this.speed = speed_v;
    }

    public void SetRotate(float speed)
    {
      this.rspeed = speed;
    }

    public void SetScale(Vector2 scale_v)
    {
      this.scale = scale_v;
    }

    public void TurnWhen(string eve)
    {
      this.events.Add(eve);
    }

    public void Update()
    {
      this.nowa += this.alpha / 60f;
      if ((double) this.nowa >= (double) this.alpha)
        this.nowa = this.alpha;
      this.Position += this.speed * Time.Stop;
      this.rotate += this.rspeed * Time.Stop;
      if ((double) this.rotate >= 360.0)
        this.rotate -= 360f;
      foreach (string str in this.events)
      {
        string[] strArray = str.Split('(')[1].Split(')')[0].Split(',');
        if (strArray[1] == "nul" && this.Check(float.Parse(strArray[2]), this.Position.Y, this.speed.Y) || strArray[2] == "nul" && this.Check(float.Parse(strArray[1]), this.Position.X, this.speed.X) || this.Check(new Vector2(float.Parse(strArray[1]), float.Parse(strArray[2])), this.Position, this.speed))
        {
          if (strArray[3] != "nul")
            this.Position.X = float.Parse(strArray[3]);
          if (strArray[4] != "nul")
            this.Position.Y = float.Parse(strArray[4]);
        }
      }
    }

    private bool Check(float num, float ori, float speed)
    {
      return ((double) num - (double) ori) * (double) speed <= 0.0;
    }

    private bool Check(Vector2 num, Vector2 ori, Vector2 speed)
    {
      bool flag1 = false;
      bool flag2 = false;
      if (((double) num.X - (double) ori.X) * (double) speed.X <= 0.0)
        flag1 = true;
      if (((double) num.Y - (double) ori.Y) * (double) speed.Y <= 0.0)
        flag2 = true;
      return flag1 & flag2;
    }

    public void Draw(SpriteBatch s)
    {
      Vector2 vector2 = Vector2.Zero;
      if (Main.Mode == Modes.SINGLE)
        vector2 = new Vector2(32f, 16f);
      s.Draw(this.tex, this.Position + vector2, new Rectangle?(), new Color(1f, 1f, 1f, this.nowa / 100f), MathHelper.ToRadians(this.rotate), this.origin, this.scale, SpriteEffects.None, 0.0f);
    }
  }
}
