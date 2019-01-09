// Decompiled with JetBrains decompiler
// Type: THMHJ.Enemy
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;

namespace THMHJ
{
  public class Enemy
  {
    private Vector3 rgb = new Vector3(1f, 1f, 1f);
    private float alpha = 1f;
    private Praticle praticle;
    private Praticle epraticle;
    private Sprite esprite;
    private CrazyStorm barrage;
    public ItemManager items;
    public List<float> itemsave;
    private List<float[]> enemyset;
    public List<EnemyEvent> EventArray;
    public Enemy copy;
    private Texture2D tex;
    public Vector2 origin;
    public Vector2 originsize;
    public Vector2 step;
    private int ns;
    public Vector2 judge;
    public Vector2 judgesize;
    public Vector2 Position;
    public float speed;
    public float speedf;
    public int noharm;
    public int type;
    public int typeid;
    public int life;
    public int ohp;
    public int hp;
    public int barrageid;
    public int id;
    private int color;
    public string label;
    public bool mana;
    public bool deadkill;
    public bool die;
    public int ftime;
    private int time;
    private float scale;
    private float rotate;
    private float sx;
    private float presx;
    private SpriteEffects se;
    private SpriteEffects prese;
    private bool turned;
    private bool specialed;
    private int flash;

    public event Enemy.ParentDie pdie;

    public Enemy()
    {
    }

    public Enemy(
      List<float[]> enemyset_l,
      EnemyManager e,
      CSManager csm,
      Hashtable barragec,
      int type_i,
      Vector2 pos,
      float speed_f,
      float speedf_f,
      int life_i,
      int hp_i,
      int stage,
      int barrageid_i,
      int id_i)
    {
      this.enemyset = enemyset_l;
      this.type = type_i;
      this.InitType(this.type);
      this.Position = pos;
      this.speed = speed_f;
      this.speedf = speedf_f;
      this.life = life_i;
      this.hp = hp_i;
      this.ohp = this.hp;
      this.barrageid = barrageid_i;
      this.id = id_i;
      this.tex = e.tex;
      this.copy = new Enemy();
      this.copy.type = this.type;
      this.copy.Position = new Vector2(this.Position.X, this.Position.Y);
      this.copy.speed = this.speed;
      this.copy.speedf = this.speedf;
      this.copy.life = this.life;
      this.copy.hp = this.hp;
      this.copy.barrageid = this.barrageid;
      this.copy.id = this.id;
      this.EventArray = new List<EnemyEvent>();
      this.se = SpriteEffects.None;
      if (this.barrageid != -1)
        this.barrage = csm.Createnew(stage, this.barrageid, barragec);
      this.praticle = new Praticle(false, true, new Rectangle(49, 48, 14, 13), new Vector4(pos.X - 10f, pos.Y - 10f, 20f, 20f), new Vector2(7f, 7f), 1, 5, 30, 3f, -0.1f, new Vector2(0.0f, 360f), 10f);
      this.praticle.scale = new Vector4(1.2f, 0.5f, 0.0f, 0.0f);
      this.praticle.calpha = 1f;
      this.praticle.stop = true;
      e.EnemyArray.Add(this);
    }

    private void InitSpecial()
    {
      switch (this.typeid)
      {
        case 2:
          this.esprite = new Sprite(PraticleManager.practile);
          this.esprite.rect = new Rectangle((this.type - 11) * 60, 171, 60, 60);
          this.esprite.origin = new Vector2(30f, 30f);
          this.esprite.scale = new Vector2(2f, 2f);
          break;
        case 3:
          this.epraticle = new Praticle(false, true, new Rectangle((this.type - 15) * 21, 129, 21, 21), new Vector4(this.Position.X - 10f, this.Position.Y - 10f, 20f, 20f), new Vector2(10f, 10f), 30, 0, 30, 0.5f, 0.05f, new Vector2(90f, 0.0f), 60f);
          this.epraticle.scale = new Vector4(1.7f, 1.7f, 0.3f, 0.3f);
          this.epraticle.calpha = 1f;
          this.esprite = new Sprite(PraticleManager.practile);
          this.esprite.rect = new Rectangle((this.type - 15) * 21, 150, 21, 21);
          this.esprite.origin = new Vector2(10f, 10f);
          this.esprite.scale = new Vector2(5.5f, 5.5f);
          break;
      }
    }

    private void UpdateSpecial()
    {
      if (!this.specialed)
      {
        this.InitSpecial();
        this.specialed = true;
      }
      switch (this.typeid)
      {
        case 1:
          this.rotate += 10f;
          if ((double) this.rotate <= 360.0)
            break;
          this.rotate -= 360f;
          break;
        case 2:
          this.esprite.position = new Vector2(this.Position.X, this.Position.Y);
          this.esprite.color.a = 0.4f * (float) Math.Abs(Math.Sin((double) MathHelper.ToRadians((float) (this.time * 3))));
          if (this.time == 1)
          {
            this.alpha = 0.0f;
            this.scale = 0.0f;
          }
          else if (this.time <= 21)
          {
            this.alpha += 0.05f;
            this.scale += 0.05f;
            this.esprite.rotation += 8.571428f;
            this.esprite.scale -= new Vector2(0.04761905f, 0.04761905f);
          }
          else if (this.time < this.life - 20)
            ++this.esprite.rotation;
          else if (this.time >= this.life - 20)
          {
            this.alpha -= 0.05f;
            this.scale -= 0.05f;
            this.esprite.color.a -= 0.05f;
            if ((double) this.esprite.color.a <= 0.0)
              this.esprite.color.a = 0.0f;
          }
          if (this.time % 7 != 0)
            break;
          ++this.ns;
          if (this.ns < 10)
            break;
          this.ns = 0;
          break;
        case 3:
          this.epraticle.posrect = new Vector4(this.Position.X - 10f, this.Position.Y - 10f, 20f, 20f);
          this.esprite.position = new Vector2(this.Position.X, this.Position.Y);
          if (this.time == this.life - 20)
            this.epraticle.stop = true;
          if (this.time <= this.life - 20)
            this.esprite.color.a = 0.8f * (float) Math.Abs(Math.Sin((double) MathHelper.ToRadians((float) (this.time * 2))));
          if (this.time == 1)
          {
            this.alpha = 0.0f;
            this.scale = 0.0f;
          }
          else if (this.time <= 21)
          {
            this.alpha += 0.05f;
            this.scale += 0.05f;
          }
          else if (this.time >= this.life - 20)
          {
            this.alpha -= 0.05f;
            this.scale -= 0.05f;
            this.esprite.color.a -= 0.05f;
            if ((double) this.esprite.color.a <= 0.0)
              this.esprite.color.a = 0.0f;
          }
          if (this.time % 7 != 0)
            break;
          ++this.ns;
          if (this.ns < 6)
            break;
          this.ns = 0;
          break;
      }
    }

    private void DrawSpecial(SpriteBatch s)
    {
      switch (this.typeid)
      {
        case 2:
          if (this.esprite == null)
            break;
          s.End();
          s.Begin(SpriteBlendMode.Additive);
          this.esprite.Draw(s, SpriteEffects.None, 0.0f);
          s.End();
          s.Begin();
          break;
        case 3:
          if (this.esprite == null)
            break;
          this.esprite.Draw(s, SpriteEffects.None, 0.0f);
          break;
      }
    }

    public void Update(Character Player)
    {
      this.praticle.posrect = new Vector4(this.Position.X - 10f, this.Position.Y - 10f, 20f, 20f);
      if (this.barrage != null)
        this.barrage.SetPos(new Vector2(this.Position.X + 93f, this.Position.Y - 13f), false);
      for (int index = 0; index < this.EventArray.Count; ++index)
      {
        if (!this.EventArray[index].stop)
          this.EventArray[index].Update(this);
        else if (this.EventArray[index].stop && this.EventArray[index].Independent)
        {
          this.EventArray.RemoveAt(index);
          --index;
        }
      }
      this.presx = this.Position.X;
      this.Position.X += this.speed * (float) Math.Cos((double) MathHelper.ToRadians(this.speedf));
      this.Position.Y += this.speed * (float) Math.Sin((double) MathHelper.ToRadians(this.speedf));
      this.sx = this.Position.X;
      ++this.time;
      this.UpdateSpecial();
      if (!Player.Dis && !Player.free && !Player.Wudi)
        this.Judge(Player);
      if (this.barrage != null && !this.barrage.IsStarted() && this.time >= this.ftime)
        this.barrage.Start();
      if (this.step != Vector2.Zero)
      {
        this.se = (double) this.sx >= (double) this.presx ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        if ((double) this.presx != (double) this.sx && !this.turned)
          this.ns = (int) this.step.X;
        if ((double) this.presx == (double) this.sx && this.turned)
        {
          if (this.prese == SpriteEffects.FlipHorizontally)
            this.se = this.prese;
          this.ns = (int) this.step.X;
        }
        if (this.time % 7 == 0)
        {
          if ((double) this.presx == (double) this.sx)
          {
            this.turned = false;
            ++this.ns;
            if ((double) this.ns >= (double) this.step.X)
              this.ns = 0;
          }
          else
          {
            this.turned = true;
            ++this.ns;
            if (this.typeid != 4)
            {
              if ((double) this.ns >= (double) this.step.X + (double) this.step.Y)
                this.ns = (int) this.step.X + 1;
            }
            else if ((double) this.ns >= (double) this.step.X + (double) this.step.Y)
              this.ns = (int) ((double) this.step.X + (double) this.step.Y) - 1;
          }
        }
      }
      if (this.time >= this.life)
      {
        this.die = true;
        this.praticle.Delete();
        if (this.epraticle != null)
          this.epraticle.Delete();
        if (this.barrage != null)
          this.barrage.Close();
      }
      this.prese = this.se;
      if (this.hp > 0)
        return;
      this.hp = 0;
      if (!this.die)
      {
        CrazyStorm crazyStorm = Program.game.game.PlayEffect(true, (this.color + 7).ToString(), new Vector2(this.Position.X + 93f, this.Position.Y - 13f));
        crazyStorm.BanSound(true);
        crazyStorm.effect = true;
      }
      this.die = true;
      this.praticle.Delete();
      if (this.epraticle != null)
        this.epraticle.Delete();
      if (this.barrage != null)
        this.barrage.Close();
      if (this.items == null || this.mana)
        return;
      if (this.pdie != null)
        this.pdie();
      Program.game.game.PlaySound("enep00", true, this.Position.X);
      if (!this.deadkill)
        Program.game.game.AddStgData(0, 0, 1);
      Program.game.game.Score += 20000L;
      this.items.Shoot(this.Position, Math.Max(this.originsize.X, this.originsize.Y), Player, (Boss) null);
    }

    public void Draw(SpriteBatch s, Vector2 q)
    {
      this.DrawSpecial(s);
      s.Draw(this.tex, new Vector2(this.Position.X + q.X, this.Position.Y + q.Y), new Rectangle?(new Rectangle((int) ((double) this.origin.X + (double) this.ns * (double) this.originsize.X), (int) this.origin.Y, (int) this.originsize.X, (int) this.originsize.Y)), new Color(this.rgb.X, this.rgb.Y, this.rgb.Z, this.alpha), MathHelper.ToRadians(this.rotate), this.judge, this.scale, this.se, 0.0f);
      this.rgb.X = 1f;
      this.rgb.Y = 1f;
    }

    private void InitType(int type)
    {
      this.origin = new Vector2(this.enemyset[type - 1][0], this.enemyset[type - 1][1]);
      this.originsize = new Vector2(this.enemyset[type - 1][2], this.enemyset[type - 1][3]);
      this.step = new Vector2(this.enemyset[type - 1][4], this.enemyset[type - 1][5]);
      this.judge = new Vector2(this.enemyset[type - 1][6], this.enemyset[type - 1][7]);
      this.judgesize = new Vector2(this.enemyset[type - 1][8], this.enemyset[type - 1][9]);
      this.scale = this.enemyset[type - 1][10];
      this.color = (int) this.enemyset[type - 1][11];
      this.typeid = (int) this.enemyset[type - 1][12];
    }

    public void Judge(Character Player)
    {
      if (this.noharm >= this.time || Main.Mode != Modes.SINGLE || ((double) Player.body.position.X < (double) this.Position.X - (double) this.judgesize.X / 7.0 || (double) Player.body.position.X > (double) this.Position.X + (double) this.judgesize.X / 7.0) || ((double) Player.body.position.Y < (double) this.Position.Y - (double) this.judgesize.Y / 7.0 || (double) Player.body.position.Y > (double) this.Position.Y + (double) this.judgesize.Y / 7.0))
        return;
      this.hp = 0;
      Player.Dis = true;
    }

    public bool Judge(Vector2 pos, int power)
    {
      if (Main.Mode == Modes.SINGLE && ((double) pos.Y <= 26.0 || (double) pos.Y >= 453.0 || ((double) pos.X <= 41.0 || (double) pos.X >= 406.0)) || Main.Mode != Modes.SINGLE && ((double) pos.Y <= 20.0 || (double) pos.Y >= 460.0 || ((double) pos.X <= 20.0 || (double) pos.X >= 620.0)) || ((double) pos.X < (double) this.Position.X - (double) this.judgesize.X / 2.0 || (double) pos.X > (double) this.Position.X + (double) this.judgesize.X / 2.0 || ((double) pos.Y < (double) this.Position.Y - (double) this.judgesize.Y / 2.0 || (double) pos.Y > (double) this.Position.Y + (double) this.judgesize.Y / 2.0)))
        return false;
      if (this.noharm < this.time)
        this.hp -= power;
      ++this.flash;
      if (this.hp > 0 && (double) this.hp / (double) this.ohp <= 0.200000002980232 && this.flash % 3 == 0)
      {
        if (this.flash % 2 == 0)
        {
          this.rgb.X = 0.0f;
          this.rgb.Y = 0.0f;
        }
        else
        {
          this.rgb.X = 1f;
          this.rgb.Y = 1f;
        }
      }
      if (this.flash % 2 == 0)
        Program.game.game.PlaySound("damage00", true, this.Position.X);
      this.praticle.stop = false;
      this.praticle.TIME = 0;
      return true;
    }

    public void ParentIsDead()
    {
      this.hp = 0;
    }

    public bool IsInWudi()
    {
      return this.noharm >= this.time;
    }

    public delegate void ParentDie();
  }
}
