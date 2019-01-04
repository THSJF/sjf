// Decompiled with JetBrains decompiler
// Type: THMHJ.Boss
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace THMHJ
{
  public class Boss
  {
    public Vector3 rgb = new Vector3(1f, 1f, 1f);
    private float alpha = 1f;
    private Vector2 spposition;
    private Dictionary<string, Vector2> fsposition;
    private Dictionary<string, Vector2> fscenter;
    private Dictionary<string, Rectangle> fsrect;
    private Dictionary<string, float> fsscale;
    private Dictionary<string, int> fsframe;
    private float floatimage;
    private Praticle praticle;
    private Praticle praticle2;
    private Praticle praticle3;
    private Praticle sppraticle;
    private Praticle sppraticle2;
    private Dialog dialogm;
    private Texture2D tex;
    private Texture2D bosslist;
    private Effect force;
    private Vector2 origin;
    private Vector2 originsize;
    private Vector2 step;
    private int ns;
    private int ny;
    private Vector2 judge;
    private Vector2 judgesize;
    private Vector2 position;
    private float scale;
    private int time;
    private int ltime;
    private int type;
    private int dialog;
    private int entype;
    private int letype;
    private int colortype;
    private int passedCards;
    private float sx;
    private float presx;
    private bool level1;
    private bool level2;
    private bool turned;
    private bool back;
    private List<float[]> bossset;
    private float cirscale;
    private int cirrotate;
    private Hashtable bossimage;
    private Hashtable bossdimage;
    private Hashtable[] spellcard;
    public ItemManager itemm;
    public List<BossCard> CardArray;
    public bool start;
    public bool leave;
    public bool die;
    private bool wait;
    private bool image;
    private string imageid;
    private Vector2 imagep;
    private float imagea;
    private int imagetime;
    private int battletime;
    private float numalpha;
    public bool banbomb;
    public bool lastone;
    public bool timecard;
    public bool nothide;

    public Vector2 Position
    {
      get
      {
        return this.position;
      }
    }

    public Hashtable[] Spellcard
    {
      get
      {
        return this.spellcard;
      }
    }

    public Boss(
      Texture2D tex_t,
      Texture2D bosslist_t,
      Hashtable[] spellcard_h,
      Sprite dialog_s,
      Sprite dm_s,
      Sprite[] db_s,
      Sprite name_s,
      int stage,
      int bgtype,
      Cname c,
      Effect force_e,
      List<float[]> bossset_l,
      int type_i,
      int dialog_i,
      int entype_i,
      int letype_i,
      int cards_i,
      int color_i)
    {
      this.fsposition = new Dictionary<string, Vector2>();
      this.fscenter = new Dictionary<string, Vector2>();
      this.fsrect = new Dictionary<string, Rectangle>();
      this.fsscale = new Dictionary<string, float>();
      this.fsframe = new Dictionary<string, int>();
      this.imageid = stage.ToString() + bgtype.ToString();
      this.tex = tex_t;
      this.bosslist = bosslist_t;
      this.spellcard = spellcard_h;
      this.bossset = bossset_l;
      this.force = force_e;
      this.type = type_i;
      this.InitType(this.type);
      this.dialog = dialog_i;
      this.colortype = color_i;
      if (this.dialog != -1)
      {
        if (File.Exists("Content/Data/d" + stage.ToString() + this.dialog.ToString() + ((int) c).ToString() + ".xna"))
        {
          this.dialogm = new Dialog(dialog_s, dm_s, db_s, name_s, stage, c, this.dialog, this);
          this.wait = true;
          goto label_4;
        }
      }
      this.wait = false;
label_4:
      this.entype = entype_i;
      this.InitEnType(this.entype);
      this.letype = letype_i;
      this.passedCards = 0;
      this.praticle = new Praticle(false, true, new Rectangle(49, 48, 14, 13), new Vector4(this.Position.X - 15f, this.Position.Y - 15f, 30f, 30f), new Vector2(7f, 7f), 1, 5, 30, 3f, -0.1f, new Vector2(0.0f, 360f), 10f);
      this.praticle.scale = new Vector4(1.2f, 0.5f, 0.0f, 0.0f);
      this.praticle.calpha = 1f;
      this.praticle.stop = true;
      this.praticle2 = new Praticle(true, true, new Rectangle(2, 37, 38, 38), new Vector4(this.Position.X - 15f, this.Position.Y - 15f, 45f, 45f), new Vector2(19f, 19f), 60, 0, 40, 0.0f, 0.08f, new Vector2(-90f, 0.0f), 10f);
      this.praticle2.scale = new Vector4(1.2f, 0.4f, 0.5f, 0.0f);
      this.sppraticle = new Praticle(true, true, new Rectangle(2, 37, 38, 38), new Vector4(this.Position.X - 15f, this.Position.Y - 15f, 45f, 45f), new Vector2(19f, 19f), 60, 0, 40, 0.0f, 0.08f, new Vector2(-90f, 0.0f), 10f);
      this.sppraticle.scale = new Vector4(1.2f, 0.4f, 0.5f, 0.0f);
      this.sppraticle.stop = true;
      this.sppraticle2 = new Praticle(true, true, new Rectangle(2, 37, 38, 38), new Vector4(this.Position.X - 15f, this.Position.Y - 15f, 45f, 45f), new Vector2(19f, 19f), 60, 0, 40, 0.0f, 0.08f, new Vector2(-90f, 0.0f), 10f);
      this.sppraticle2.scale = new Vector4(1.2f, 0.4f, 0.5f, 0.0f);
      this.sppraticle2.stop = true;
      this.praticle3 = new Praticle(false, true, new Rectangle(71, 48, 76, 76), new Vector4(this.Position.X - 5f, this.Position.Y - 5f, 10f, 10f), new Vector2(38f, 38f), 150, 30, 100, 2f, 0.0f, new Vector2(0.0f, 360f), 30f);
      this.praticle3.speedr = 3f;
      this.praticle3.calpha = 1f;
      this.praticle3.rotation = new Vector4(0.0f, 90f, 90f, 180f);
      this.praticle3.scale = new Vector4(0.5f, 2.5f, 0.5f, 0.5f);
      this.praticle3.stop = true;
      this.CardArray = new List<BossCard>();
      this.SpecialInit();
    }

    public void Texture(Hashtable bossimage_c, Hashtable bossdimage_c)
    {
      this.bossdimage = bossdimage_c;
      this.bossimage = bossimage_c;
    }

    public int NowCardType()
    {
      return this.CardArray[0].type;
    }

    public void Update(
      EnemyManager e,
      CSManager csm,
      Character Player,
      BossBackground bg,
      Texture2D bgmt,
      int stage)
    {
      this.praticle.posrect = new Vector4(this.Position.X - 15f, this.Position.Y - 15f, 30f, 30f);
      this.praticle2.posrect = new Vector4(this.Position.X - 20f, this.Position.Y - 15f, 45f, 45f);
      this.praticle3.posrect = new Vector4(this.Position.X - 5f, this.Position.Y - 5f, 10f, 10f);
      this.praticle2.Update();
      if (this.dialogm != null)
      {
        if (this.time >= 160)
          this.dialogm.Update(bgmt, stage);
        if (this.dialogm.ok)
        {
          this.wait = false;
          Program.game.game.BanShoot(false);
        }
      }
      if (bg != null && bg.Start)
        Effects.SetforceParameters(this.force, this.time, (float) (((double) this.Position.X - 2.0) / 640.0), this.Position.Y / 480f);
      else
        Effects.SetforceParameters(this.force, this.time, (float) (((double) this.Position.X + 91.0) / 640.0), this.Position.Y / 480f);
      if (this.time <= 120)
      {
        if (csm != null)
        {
          foreach (CrazyStorm crazyStorm in csm.csc)
          {
            foreach (Layer layer in crazyStorm.layerm.LayerArray)
            {
              foreach (Barrage barrage in layer.Barrages)
              {
                if (!barrage.Dis && barrage.time > 15 | !barrage.Mist && (!barrage.NeedDelete && !barrage.Invincible) && Math.Sqrt(((double) barrage.x - (double) this.Position.X) * ((double) barrage.x - (double) this.Position.X) + ((double) barrage.y - (double) this.Position.Y) * ((double) barrage.y - (double) this.Position.Y)) < (double) Math.Abs(this.time * 6))
                {
                  barrage.time = 1 + barrage.add + barrage.life;
                  barrage.Dis = true;
                  barrage.Blend = true;
                  barrage.randf = 10f * (float) Main.rand.NextDouble();
                }
              }
            }
          }
        }
        if (e != null)
        {
          for (int index = 0; index < e.EnemyArray.Count; ++index)
          {
            if (!e.EnemyArray[index].die && e.EnemyArray[index].hp > 0 && (!Main.IsOut(e.EnemyArray[index].Position) && Math.Sqrt(((double) e.EnemyArray[index].Position.X - (double) this.Position.X) * ((double) e.EnemyArray[index].Position.X - (double) this.Position.X) + ((double) e.EnemyArray[index].Position.Y - (double) this.Position.Y) * ((double) e.EnemyArray[index].Position.Y - (double) this.Position.Y)) < (double) Math.Abs(this.time * 6)))
            {
              e.EnemyArray[index].mana = true;
              e.EnemyArray[index].hp = 0;
            }
          }
        }
        this.position.X += (float) ((224.0 - (double) this.Position.X) / 30.0);
        this.position.Y += (float) ((170.0 - (double) this.Position.Y) / 30.0);
        if (Player != null)
          Player.IAuto = true;
      }
      else if (Player != null)
        Player.IAuto = false;
      ++this.time;
      this.SpecialUpdate();
      this.sx = this.Position.X;
      if ((double) Math.Abs(this.sx - this.presx) >= 0.5 && !this.turned)
      {
        this.ns = 0;
        this.turned = true;
        this.back = false;
      }
      else if ((double) Math.Abs(this.sx - this.presx) < 0.5 && this.turned)
      {
        this.ns = (int) this.step.X - 1;
        this.turned = false;
        this.back = true;
      }
      if (this.time % 7 == 0)
      {
        if (this.turned)
        {
          this.ny = (double) this.sx <= (double) this.presx ? (int) this.step.Y - 1 : (int) this.step.Y;
          if (this.ny <= 0)
            this.ny = 0;
        }
        if (!this.back)
        {
          ++this.ns;
          if ((double) Math.Abs(this.sx - this.presx) >= 0.5 && (double) this.ns > (double) this.step.X)
            this.ns = (int) this.step.X;
          if ((double) Math.Abs(this.sx - this.presx) < 0.5 && (double) this.ns > (double) this.step.X)
            this.ns = 0;
        }
        else
        {
          --this.ns;
          if (this.ns < 0)
          {
            this.ns = 0;
            this.ny = 0;
            this.back = false;
          }
        }
      }
      this.presx = this.sx;
      this.cirrotate += 7;
      if (this.cirrotate >= 360)
        this.cirrotate -= 360;
      this.cirscale = (float) (1.5 + 0.200000002980232 * Math.Sin((double) this.time / Math.PI / 7.0));
      if (!this.wait)
      {
        ++this.battletime;
        if (this.battletime == 120)
        {
          Hashtable data = new Hashtable();
          data[(object) "reset"] = (object) null;
          Program.game.achivmanager.Check(AchievementType.Challenge, 12, data);
          Program.game.achivmanager.Check(AchievementType.Challenge, 13, data);
        }
        this.numalpha += 0.01666667f;
        if ((double) this.numalpha >= 1.0)
          this.numalpha = 1f;
        if (this.CardArray.Count >= 2)
          this.CardArray[0].Update(this.CardArray[1].type, this.Position, bg, this.colortype);
        else if (this.CardArray.Count >= 1)
          this.CardArray[0].Update(this.CardArray[0].type, this.Position, bg, this.colortype);
        if (this.CardArray.Count >= 1 && this.CardArray[0].die)
        {
          ++this.passedCards;
          if (this.CardArray[0].fdie)
          {
            this.CardArray.RemoveAt(0);
            this.CardArray[0].cf = true;
          }
          else
            this.CardArray.RemoveAt(0);
          if (this.CardArray.Count == 0)
          {
            if (this.letype != 3)
            {
              bg.Switch(false);
              Program.game.game.Quake(50, 5);
              this.praticle2.stop = true;
              this.praticle3.stop = false;
              Program.game.game.PlaySound("enep01", true, this.Position.X);
            }
            else
              Program.game.game.PlaySound("tan", true, this.Position.X);
            this.leave = true;
            this.itemm.shot = true;
            if (!this.lastone)
              Time.Init();
          }
          else
          {
            Program.game.game.PlaySound("tan", true, this.Position.X);
            bg.Switch(false);
          }
        }
        if (this.leave)
        {
          this.numalpha -= 0.05f;
          if ((double) this.numalpha <= 0.0)
            this.numalpha = 0.0f;
          if (!this.lastone)
            ++this.ltime;
          else if (this.time % 3 == 0)
            ++this.ltime;
          if (this.letype == 3)
            this.cirscale += 0.05f;
          if (this.letype == 3 && this.ltime == 1)
            this.ltime = 59;
          int num = 0;
          if (this.ltime == 1 && this.dialogm != null && this.dialogm.next)
            num = 40;
          if (this.ltime == 59 + num)
          {
            Program.game.game.ClearSth("Enemy");
            if (this.dialogm != null && this.dialogm.next)
            {
              this.dialogm.Continue();
              this.wait = true;
            }
          }
          if (this.ltime >= 60 + num && (this.letype != 3 && this.ltime < 100 + num || this.letype == 3 && this.ltime < 140 + num))
            this.Leave(bg);
          if (this.letype == 3 && this.ltime >= 140 + num || this.letype != 3 && this.ltime >= 100 + num)
          {
            Hashtable data = new Hashtable();
            data[(object) "level"] = (object) Main.Level;
            data[(object) "type"] = (object) this.dialog;
            Program.game.achivmanager.Check(AchievementType.Challenge, 12, data);
            data[(object) "continued"] = (object) Program.game.game.BanRecord;
            data[(object) nameof (stage)] = (object) Program.game.game.StmStage;
            Program.game.achivmanager.Check(AchievementType.Challenge, 13, data);
            this.die = true;
            this.praticle.Delete();
            Time.Init();
          }
          if (this.itemm != null)
            this.itemm.shot = true;
        }
        else if (!Player.Dis && !Player.free && !Player.Wudi)
          this.Judge(Player);
      }
      else if (this.time >= 60)
        Program.game.game.BanShoot(true);
      if (!this.image)
        return;
      this.ImageUpdate();
    }

    public void Draw(NSpriteBatch s, Vector2 q)
    {
      if (s.IsBegan)
        s.End();
      if (!s.IsBegan)
        s.Begin(SpriteBlendMode.Additive);
      this.praticle2.Draw((SpriteBatch) s, q);
      this.sppraticle.Draw((SpriteBatch) s, q);
      this.sppraticle2.Draw((SpriteBatch) s, q);
      s.Draw(this.bosslist, new Vector2(this.Position.X + q.X, this.Position.Y + q.Y), new Rectangle?(new Rectangle(225, 135, 138, 138)), Color.White, MathHelper.ToRadians((float) this.cirrotate), new Vector2(69.5f, 69.5f), this.cirscale, SpriteEffects.None, 0.0f);
      if (s.IsBegan)
        s.End();
      if (!s.IsBegan)
        s.Begin();
      this.SpecialDraw((SpriteBatch) s, q);
      s.Draw(this.tex, new Vector2(this.Position.X + q.X, this.Position.Y + q.Y), new Rectangle?(new Rectangle((int) ((double) this.origin.X + (double) this.ns * (double) this.originsize.X), (int) ((double) this.origin.Y + (double) this.ny * (double) this.originsize.Y), (int) this.originsize.X, (int) this.originsize.Y)), new Color(this.rgb.X, this.rgb.Y, this.rgb.Z, this.alpha), 0.0f, this.judge, this.scale, SpriteEffects.None, 0.0f);
      this.rgb.X = 1f;
      this.rgb.Y = 1f;
    }

    private void SpecialInit()
    {
      if (this.type != 8)
        return;
      this.level1 = false;
      this.level2 = false;
      this.fsposition.Add("Throne", new Vector2());
      this.fsposition.Add("BackBone", new Vector2());
      this.fsposition.Add("Skull", new Vector2());
      this.fsposition.Add("LeftWing1", new Vector2());
      this.fsposition.Add("LeftWing2", new Vector2());
      this.fsposition.Add("LeftWing3", new Vector2());
      this.fsposition.Add("RightWing1", new Vector2());
      this.fsposition.Add("RightWing2", new Vector2());
      this.fsposition.Add("RightWing3", new Vector2());
      this.fsposition.Add("LeftFlag1", new Vector2());
      this.fsposition.Add("LeftFlag2", new Vector2());
      this.fsposition.Add("RightFlag1", new Vector2());
      this.fsposition.Add("RightFlag2", new Vector2());
      this.fscenter.Add("Throne", new Vector2(69f, 90f));
      this.fscenter.Add("BackBone", new Vector2(109f, 122f));
      this.fscenter.Add("Skull", new Vector2(89f, 82f));
      this.fscenter.Add("LeftWing", new Vector2(102f, 129f));
      this.fscenter.Add("RightWing", new Vector2(2f, 129f));
      this.fscenter.Add("Flag", new Vector2(25f, 0.0f));
      this.fsrect.Add("Throne", new Rectangle(702, 1300, 137, 180));
      this.fsrect.Add("BackBone", new Rectangle(0, 1373, 217, 244));
      this.fsrect.Add("Skull", new Rectangle(346, 1300, 178, 164));
      this.fsrect.Add("Wing", new Rectangle(0, 1617, 104, 169));
      this.fsrect.Add("Flag", new Rectangle(417, 1517, 50, 110));
      this.fsrect.Add("BackFlag", new Rectangle(417, 1737, 50, 110));
      this.fsscale.Add("BackBone", 0.8f);
      this.fsscale.Add("Skull", 0.73f);
      this.fsscale.Add("Wing", 0.8f);
      this.fsscale.Add("Flag", 0.8f);
      this.fsframe.Add("Flag", 0);
      this.fscenter.Add("OriginSize", this.originsize);
    }

    private void SpecialUpdate()
    {
      if (this.type != 8)
        return;
      if (this.passedCards >= 2)
      {
        this.originsize = this.fscenter["OriginSize"];
        this.fsrect["Throne"] = new Rectangle(0, 1812, 137, 180);
        this.sppraticle.posrect = new Vector4(this.Position.X - 40f, this.Position.Y, 45f, 45f);
        this.sppraticle2.posrect = new Vector4(this.Position.X - 10f, this.Position.Y, 45f, 45f);
        if (this.passedCards == 2 && this.CardArray[0].CurrentTime < 120)
          this.spposition = this.position;
        else
          this.spposition.Y += (float) ((-200.0 - (double) this.spposition.Y) / 120.0);
      }
      else
      {
        this.originsize = new Vector2(0.0f, 0.0f);
        this.spposition = this.position;
        this.sppraticle.posrect = new Vector4(this.spposition.X - 105f, this.spposition.Y, 45f, 45f);
        this.sppraticle2.posrect = new Vector4(this.spposition.X + 65f, this.spposition.Y, 45f, 45f);
      }
      this.floatimage = (float) (5.0 + 5.0 * Math.Abs(Math.Sin((double) this.time / Math.PI / 10.0)));
      this.fsposition["Throne"] = new Vector2(this.spposition.X, this.spposition.Y - 30f);
      this.fsposition["BackBone"] = new Vector2(this.spposition.X + 6f, this.spposition.Y - 10f);
      this.fsposition["Skull"] = new Vector2(this.spposition.X, this.spposition.Y + 50f);
      this.fsposition["LeftWing1"] = new Vector2(this.spposition.X - 40f, this.spposition.Y + 60f);
      this.fsposition["RightWing1"] = new Vector2(this.spposition.X + 40f, this.spposition.Y + 60f);
      this.fsposition["LeftWing2"] = new Vector2(this.spposition.X - 50f, this.spposition.Y + 50f);
      this.fsposition["RightWing2"] = new Vector2(this.spposition.X + 50f, this.spposition.Y + 50f);
      this.fsposition["LeftWing3"] = new Vector2(this.spposition.X - 80f, this.spposition.Y + 40f);
      this.fsposition["RightWing3"] = new Vector2(this.spposition.X + 80f, this.spposition.Y + 40f);
      this.fsposition["LeftFlag1"] = new Vector2(this.spposition.X - 65f, this.spposition.Y + 60f);
      this.fsposition["RightFlag1"] = new Vector2(this.spposition.X + 65f, this.spposition.Y + 60f);
      this.fsposition["LeftFlag2"] = new Vector2(this.spposition.X - 100f, this.spposition.Y + 40f);
      this.fsposition["RightFlag2"] = new Vector2(this.spposition.X + 100f, this.spposition.Y + 40f);
      if (this.time % 7 == 0)
      {
        Dictionary<string, int> fsframe;
        (fsframe = this.fsframe)["Flag"] = fsframe["Flag"] + 1;
        if (this.fsframe["Flag"] >= 9)
          this.fsframe["Flag"] = 0;
        if (this.CardArray.Count >= 8)
        {
          this.fsrect["Flag"] = new Rectangle(417 + this.fsframe["Flag"] * 50, this.fsrect["Flag"].Y, this.fsrect["Flag"].Width, this.fsrect["Flag"].Height);
          this.fsrect["BackFlag"] = new Rectangle(417 + this.fsframe["Flag"] * 50, this.fsrect["BackFlag"].Y, this.fsrect["BackFlag"].Width, this.fsrect["BackFlag"].Height);
        }
        else
        {
          this.fsrect["Flag"] = new Rectangle(417 + this.fsframe["Flag"] * 50, 1627, this.fsrect["Flag"].Width, this.fsrect["Flag"].Height);
          this.fsrect["BackFlag"] = new Rectangle(417 + this.fsframe["Flag"] * 50, 1847, this.fsrect["BackFlag"].Width, this.fsrect["BackFlag"].Height);
        }
      }
      if (this.CardArray.Count < 6)
      {
        if (!this.level1)
        {
          CrazyStorm crazyStorm1 = Program.game.game.PlayEffect(true, "8", new Vector2(this.Position.X + 93f, (float) ((double) this.Position.Y + 50.0 - 13.0)));
          crazyStorm1.BanSound(true);
          crazyStorm1.effect = true;
          CrazyStorm crazyStorm2 = Program.game.game.PlayEffect(true, "8", new Vector2((float) ((double) this.Position.X - 50.0 + 93.0), (float) ((double) this.Position.Y + 50.0 - 13.0)));
          crazyStorm2.BanSound(true);
          crazyStorm2.effect = true;
          CrazyStorm crazyStorm3 = Program.game.game.PlayEffect(true, "8", new Vector2((float) ((double) this.Position.X + 50.0 + 93.0), (float) ((double) this.Position.Y + 50.0 - 13.0)));
          crazyStorm3.BanSound(true);
          crazyStorm3.effect = true;
          this.level1 = true;
        }
        this.fsrect["Skull"] = new Rectangle(524, 1300, 178, 164);
      }
      if (this.CardArray.Count >= 2)
      {
        this.sppraticle.Update();
        this.sppraticle2.Update();
        this.sppraticle.stop = false;
        this.sppraticle2.stop = false;
        this.praticle2.stop = true;
      }
      else
      {
        this.praticle2.stop = false;
        this.sppraticle.stop = true;
        this.sppraticle2.stop = true;
      }
      if (this.CardArray.Count < 6 && this.CardArray.Count >= 4)
      {
        this.fsrect["Wing"] = new Rectangle(104, 1617, 104, 169);
      }
      else
      {
        if (this.CardArray.Count >= 4 || this.CardArray.Count < 2)
          return;
        if (!this.level2)
        {
          CrazyStorm crazyStorm1 = Program.game.game.PlayEffect(true, "8", new Vector2((float) ((double) this.Position.X - 40.0 + 93.0), (float) ((double) this.Position.Y + 60.0 - 13.0)));
          crazyStorm1.BanSound(true);
          crazyStorm1.effect = true;
          CrazyStorm crazyStorm2 = Program.game.game.PlayEffect(true, "8", new Vector2((float) ((double) this.Position.X + 40.0 + 93.0), (float) ((double) this.Position.Y + 60.0 - 13.0)));
          crazyStorm2.BanSound(true);
          crazyStorm2.effect = true;
          this.level2 = true;
        }
        this.fsrect["Wing"] = new Rectangle(312, 1617, 104, 169);
      }
    }

    private void SpecialDraw(SpriteBatch s, Vector2 q)
    {
      if (this.type != 8)
        return;
      Color color1 = new Color(this.rgb.X, this.rgb.Y, this.rgb.Z, this.alpha);
      Color color2 = new Color(1f, 1f, 1f, this.alpha);
      if (this.CardArray.Count >= 6)
      {
        s.Draw(this.tex, this.fsposition["BackBone"] + new Vector2(0.0f, this.floatimage) + q, new Rectangle?(this.fsrect["BackBone"]), color2, 0.0f, this.fscenter["BackBone"], this.fsscale["BackBone"], SpriteEffects.None, 0.0f);
        s.Draw(this.tex, this.fsposition["Throne"] + new Vector2(0.0f, this.floatimage) + q, new Rectangle?(this.fsrect["Throne"]), color2, 0.0f, this.fscenter["Throne"], 1f, SpriteEffects.None, 0.0f);
        s.Draw(this.tex, this.fsposition["LeftFlag2"] + new Vector2(0.0f, this.floatimage) + q, new Rectangle?(this.fsrect["BackFlag"]), color1, 0.0f, this.fscenter["Flag"], this.fsscale["Flag"], SpriteEffects.FlipHorizontally, 0.0f);
        s.Draw(this.tex, this.fsposition["RightFlag2"] + new Vector2(0.0f, this.floatimage) + q, new Rectangle?(this.fsrect["BackFlag"]), color1, 0.0f, this.fscenter["Flag"], this.fsscale["Flag"], SpriteEffects.None, 0.0f);
        s.Draw(this.tex, this.fsposition["LeftFlag1"] + new Vector2(0.0f, this.floatimage) + q, new Rectangle?(this.fsrect["Flag"]), color1, 0.0f, this.fscenter["Flag"], this.fsscale["Flag"], SpriteEffects.None, 0.0f);
        s.Draw(this.tex, this.fsposition["RightFlag1"] + new Vector2(0.0f, this.floatimage) + q, new Rectangle?(this.fsrect["Flag"]), color1, 0.0f, this.fscenter["Flag"], this.fsscale["Flag"], SpriteEffects.FlipHorizontally, 0.0f);
        s.Draw(this.tex, this.fsposition["LeftWing3"] + new Vector2(0.0f, this.floatimage) + q, new Rectangle?(this.fsrect["Wing"]), color1, MathHelper.ToRadians(-60f), this.fscenter["LeftWing"], this.fsscale["Wing"], SpriteEffects.None, 0.0f);
        s.Draw(this.tex, this.fsposition["RightWing3"] + new Vector2(0.0f, this.floatimage) + q, new Rectangle?(this.fsrect["Wing"]), color1, MathHelper.ToRadians(60f), this.fscenter["RightWing"], this.fsscale["Wing"], SpriteEffects.FlipHorizontally, 0.0f);
        s.Draw(this.tex, this.fsposition["LeftWing2"] + new Vector2(0.0f, this.floatimage) + q, new Rectangle?(this.fsrect["Wing"]), color1, MathHelper.ToRadians(-30f), this.fscenter["LeftWing"], this.fsscale["Wing"], SpriteEffects.None, 0.0f);
        s.Draw(this.tex, this.fsposition["RightWing2"] + new Vector2(0.0f, this.floatimage) + q, new Rectangle?(this.fsrect["Wing"]), color1, MathHelper.ToRadians(30f), this.fscenter["RightWing"], this.fsscale["Wing"], SpriteEffects.FlipHorizontally, 0.0f);
        s.Draw(this.tex, this.fsposition["LeftWing1"] + new Vector2(0.0f, this.floatimage) + q, new Rectangle?(this.fsrect["Wing"]), color1, 0.0f, this.fscenter["LeftWing"], this.fsscale["Wing"], SpriteEffects.None, 0.0f);
        s.Draw(this.tex, this.fsposition["RightWing1"] + new Vector2(0.0f, this.floatimage) + q, new Rectangle?(this.fsrect["Wing"]), color1, 0.0f, this.fscenter["RightWing"], this.fsscale["Wing"], SpriteEffects.FlipHorizontally, 0.0f);
        s.Draw(this.tex, this.fsposition["Skull"] + new Vector2(0.0f, this.floatimage) + q, new Rectangle?(this.fsrect["Skull"]), color1, 0.0f, this.fscenter["Skull"], this.fsscale["Skull"], SpriteEffects.None, 0.0f);
      }
      else if (this.CardArray.Count >= 2)
      {
        s.Draw(this.tex, this.fsposition["BackBone"] + new Vector2(0.0f, this.floatimage) + q, new Rectangle?(this.fsrect["BackBone"]), color2, 0.0f, this.fscenter["BackBone"], this.fsscale["BackBone"], SpriteEffects.None, 0.0f);
        s.Draw(this.tex, this.fsposition["Throne"] + new Vector2(0.0f, this.floatimage) + q, new Rectangle?(this.fsrect["Throne"]), color2, 0.0f, this.fscenter["Throne"], 1f, SpriteEffects.None, 0.0f);
        s.Draw(this.tex, this.fsposition["LeftFlag2"] + new Vector2(0.0f, this.floatimage) + q, new Rectangle?(this.fsrect["BackFlag"]), color1, 0.0f, this.fscenter["Flag"], this.fsscale["Flag"], SpriteEffects.FlipHorizontally, 0.0f);
        s.Draw(this.tex, this.fsposition["RightFlag2"] + new Vector2(0.0f, this.floatimage) + q, new Rectangle?(this.fsrect["BackFlag"]), color1, 0.0f, this.fscenter["Flag"], this.fsscale["Flag"], SpriteEffects.None, 0.0f);
        s.Draw(this.tex, this.fsposition["LeftFlag1"] + new Vector2(0.0f, this.floatimage) + q, new Rectangle?(this.fsrect["Flag"]), color1, 0.0f, this.fscenter["Flag"], this.fsscale["Flag"], SpriteEffects.None, 0.0f);
        s.Draw(this.tex, this.fsposition["RightFlag1"] + new Vector2(0.0f, this.floatimage) + q, new Rectangle?(this.fsrect["Flag"]), color1, 0.0f, this.fscenter["Flag"], this.fsscale["Flag"], SpriteEffects.FlipHorizontally, 0.0f);
        s.Draw(this.tex, this.fsposition["LeftWing2"] + new Vector2(0.0f, this.floatimage) + q, new Rectangle?(this.fsrect["Wing"]), color1, MathHelper.ToRadians(-30f), this.fscenter["LeftWing"], this.fsscale["Wing"], SpriteEffects.None, 0.0f);
        s.Draw(this.tex, this.fsposition["RightWing2"] + new Vector2(0.0f, this.floatimage) + q, new Rectangle?(this.fsrect["Wing"]), color1, MathHelper.ToRadians(30f), this.fscenter["RightWing"], this.fsscale["Wing"], SpriteEffects.FlipHorizontally, 0.0f);
        s.Draw(this.tex, this.fsposition["LeftWing1"] + new Vector2(0.0f, this.floatimage) + q, new Rectangle?(this.fsrect["Wing"]), color1, 0.0f, this.fscenter["LeftWing"], this.fsscale["Wing"], SpriteEffects.None, 0.0f);
        s.Draw(this.tex, this.fsposition["RightWing1"] + new Vector2(0.0f, this.floatimage) + q, new Rectangle?(this.fsrect["Wing"]), color1, 0.0f, this.fscenter["RightWing"], this.fsscale["Wing"], SpriteEffects.FlipHorizontally, 0.0f);
        s.Draw(this.tex, this.fsposition["Skull"] + new Vector2(0.0f, this.floatimage) + q, new Rectangle?(this.fsrect["Skull"]), color1, 0.0f, this.fscenter["Skull"], this.fsscale["Skull"], SpriteEffects.None, 0.0f);
      }
      else
        s.Draw(this.tex, this.fsposition["Throne"] + new Vector2(0.0f, this.floatimage) + q, new Rectangle?(this.fsrect["Throne"]), color2, 0.0f, this.fscenter["Throne"], 1f, SpriteEffects.None, 0.0f);
    }

    public void UpDraw(SpriteBatch s, Character Player)
    {
      float num1 = this.numalpha;
      if (Player != null && (double) Player.body.position.Y <= 120.0)
        num1 = this.numalpha * (Player.body.position.Y / 120f);
      s.Draw(this.bosslist, new Vector2(31f, 12f), new Rectangle?(new Rectangle(0, 350, 385, 70)), new Color(1f, 1f, 1f, num1), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
      int num2 = 0;
      for (int index = 1; index < this.CardArray.Count; ++index)
      {
        if (this.CardArray[index].type == 1)
          ++num2;
      }
      s.End();
      s.Begin(SpriteBlendMode.Additive);
      Color color = new Color(1f, 1f, 1f, num1 + -0.23f * Math.Abs((float) Math.Sin((double) MathHelper.ToRadians((float) (this.time * 3)))));
      for (int index = 0; index < num2 && index < 7; ++index)
        s.Draw(this.bosslist, new Vector2(31f, 12f), new Rectangle?(new Rectangle(0, 420 + index * 70, 385, 70)), color, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
      s.End();
      s.Begin();
      if (this.CardArray.Count < 1)
        return;
      this.CardArray[0].Draw(s, num1);
    }

    private void ImageUpdate()
    {
      ++this.imagetime;
      if (this.imagetime <= 90)
      {
        this.imagep.X += (float) ((-160.0 - (double) this.imagep.X) / 30.0);
        this.imagep.Y += (float) ((30.0 - (double) this.imagep.Y) / 30.0);
        this.imagea += 0.05f;
        if ((double) this.imagea < 1.0)
          return;
        this.imagea = 1f;
      }
      else
      {
        this.imagep.X += (float) ((-600.0 - (double) this.imagep.X) / 30.0);
        this.imagep.Y += (float) ((80.0 - (double) this.imagep.Y) / 30.0);
        this.imagea -= 0.05f;
        if ((double) this.imagea > 0.0)
          return;
        this.imagea = 0.0f;
        this.image = false;
      }
    }

    public void ImageDraw(SpriteBatch s)
    {
      if (!this.bossimage.ContainsKey((object) this.imageid))
        return;
      s.Draw((Texture2D) this.bossimage[(object) this.imageid], this.imagep, new Rectangle?(), new Color(1f, 1f, 1f, this.imagea), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
    }

    private void InitType(int type)
    {
      this.origin = new Vector2(this.bossset[type - 1][0], this.bossset[type - 1][1]);
      this.originsize = new Vector2(this.bossset[type - 1][2], this.bossset[type - 1][3]);
      this.step = new Vector2(this.bossset[type - 1][4], this.bossset[type - 1][5]);
      this.judge = new Vector2(this.bossset[type - 1][6], this.bossset[type - 1][7]);
      this.judgesize = new Vector2(this.bossset[type - 1][8], this.bossset[type - 1][9]);
      this.scale = this.bossset[type - 1][10];
    }

    private void InitEnType(int entype)
    {
      switch (entype)
      {
        case 0:
          if (Main.Mode != Modes.SINGLE)
            break;
          this.position = new Vector2(224f, -150f);
          break;
        case 1:
          if (Main.Mode != Modes.SINGLE)
            break;
          this.position = new Vector2(-150f, 50f);
          break;
        case 2:
          if (Main.Mode != Modes.SINGLE)
            break;
          this.position = new Vector2(566f, 50f);
          break;
      }
    }

    public void Return()
    {
      if (Main.Mode != Modes.SINGLE)
        return;
      float num = 20f;
      this.position.X += (224f - this.Position.X) / num;
      this.position.Y += (170f - this.Position.Y) / num;
    }

    public void Hide()
    {
      if (Main.Mode != Modes.SINGLE)
        return;
      float num = 0.0f;
      if (this.type == 8)
        num = 20f;
      this.position.X += (float) ((224.0 - (double) this.Position.X) / (20.0 + (double) num));
      this.position.Y += (float) ((-100.0 - (double) num * 1.5 - (double) this.Position.Y) / (20.0 + (double) num));
    }

    private void Leave(BossBackground bg)
    {
      switch (this.letype)
      {
        case 0:
          if (Main.Mode != Modes.SINGLE)
            break;
          this.position.X += (float) ((224.0 - (double) this.Position.X) / 30.0);
          this.position.Y += (float) ((-150.0 - (double) this.Position.Y) / 30.0);
          break;
        case 1:
          if (Main.Mode != Modes.SINGLE)
            break;
          bg.Switch(false);
          this.position.X += (float) ((-150.0 - (double) this.Position.X) / 30.0);
          this.position.Y += (float) ((50.0 - (double) this.Position.Y) / 30.0);
          break;
        case 2:
          if (Main.Mode != Modes.SINGLE)
            break;
          this.position.X += (float) ((566.0 - (double) this.Position.X) / 30.0);
          this.position.Y += (float) ((50.0 - (double) this.Position.Y) / 30.0);
          break;
        case 3:
          if (this.lastone)
            Time.Slowdown(0.33f);
          if (!this.lastone && this.ltime % 10 == 0 || this.lastone && this.ltime % 5 == 0)
          {
            this.praticle2.stop = true;
            this.praticle3.quantity = this.lastone ? 70 : 80;
            if (this.ltime == 130)
              this.praticle3.quantity = 90;
            this.praticle3.stop = false;
            Program.game.game.PlaySound("tan00", true, this.Position.X);
            break;
          }
          if (this.ltime != 139)
            break;
          bg.Switch(false);
          Program.game.game.Quake(60, 5);
          Program.game.game.PlaySound("enep01", true, this.Position.X);
          break;
      }
    }

    public void Image()
    {
      this.image = true;
      this.imagep = new Vector2(300f, -50f);
      this.imagea = 0.0f;
      this.imagetime = 0;
    }

    public void Setpos(float x, float y)
    {
      this.position = new Vector2(x, y);
    }

    public BossCard AddNewCard(
      int type_i,
      CSManager csm,
      Hashtable barragec,
      Character Player,
      int stage,
      int barrageid_i,
      int totaltime_i,
      int maxhp_i)
    {
      BossCard bossCard = new BossCard(this, this.bosslist, csm, barragec, Player, this.itemm, type_i, stage, barrageid_i, totaltime_i, maxhp_i);
      this.CardArray.Add(bossCard);
      return bossCard;
    }

    public void Judge(Character Player)
    {
      if (this.timecard || Main.Mode != Modes.SINGLE || ((double) Player.body.position.X < (double) this.Position.X - (double) this.judgesize.X / 2.0 || (double) Player.body.position.X > (double) this.Position.X + (double) this.judgesize.X / 2.0) || ((double) Player.body.position.Y < (double) this.Position.Y - (double) this.judgesize.Y / 2.0 || (double) Player.body.position.Y > (double) this.Position.Y + (double) this.judgesize.Y / 2.0))
        return;
      Player.Dis = true;
    }

    public float Judge(Vector2 pos, int power)
    {
      if (!this.timecard && this.CardArray.Count >= 1 && (Main.Mode != Modes.SINGLE || (double) pos.Y > 16.0 && (double) pos.Y < 463.0 && ((double) pos.X > 31.0 && (double) pos.X < 416.0)) && (Main.Mode == Modes.SINGLE || (double) pos.Y > 10.0 && (double) pos.Y < 470.0 && ((double) pos.X > 10.0 && (double) pos.X < 630.0)))
      {
        int num1 = 30;
        int num2 = 0;
        if (this.type == 8)
        {
          num1 = 61;
          num2 = 30;
        }
        if ((double) pos.X >= (double) this.Position.X - (double) num1 && (double) pos.X <= (double) this.Position.X + (double) num1 && ((double) pos.Y >= (double) this.Position.Y - 50.0 + (double) num2 && (double) pos.Y <= (double) this.Position.Y + 50.0 + (double) num2))
        {
          this.CardArray[0].DeHp(power, true);
          this.praticle.stop = false;
          this.praticle.TIME = 0;
          return this.CardArray[0].GetHp();
        }
      }
      return 0.0f;
    }

    public bool IsTarget()
    {
      if (!this.leave)
        return !this.timecard;
      return false;
    }
  }
}
