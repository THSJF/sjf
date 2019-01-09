// Decompiled with JetBrains decompiler
// Type: THMHJ.BossCard
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.Collections.Generic;

namespace THMHJ
{
  public class BossCard
  {
    private Boss boss;
    private ItemManager itemm;
    private Character Player;
    private List<BarrageSet> barrages;
    private CardDisplay cd;
    private Texture2D tex;
    private int realtime;
    private int frame;
    private int totaltime;
    private int time;
    private int maxhp;
    private int hp;
    public int type;
    private int stage;
    private int flash;
    private int barrageid;
    private float mfscale;
    private float mcscale;
    private float fscale;
    private float cscale;
    private float fx;
    private float cx;
    private float numalpha;
    public bool first;
    public bool die;
    public bool fdie;
    public bool cf;
    public int wudi;
    public bool banbomb;
    public bool timecard;
    public bool nothide;
    public bool transform;
    private bool cleared;
    private float numflash;

    public int CurrentTime
    {
      get
      {
        return this.time;
      }
    }

    public BossCard(
      Boss boss_i,
      Texture2D tex_t,
      CSManager csm,
      Hashtable barragec,
      Character Player_c,
      ItemManager itemm_i,
      int type_i,
      int stage_i,
      int barrageid_i,
      int totaltime_i,
      int maxhp_i)
    {
      this.boss = boss_i;
      this.Player = Player_c;
      this.tex = tex_t;
      this.totaltime = totaltime_i;
      this.realtime = this.totaltime;
      this.maxhp = maxhp_i;
      this.hp = this.maxhp;
      this.type = type_i;
      this.stage = stage_i;
      this.barrageid = barrageid_i;
      this.barrages = new List<BarrageSet>();
      this.barrages.Add(new BarrageSet(csm.Createnew(this.stage, this.barrageid, barragec)));
      this.itemm = itemm_i;
      this.Player.dead = false;
      this.Player.shot = false;
      this.Player.bombed = false;
      this.Player.shifted = false;
    }

    public void AddNewBarrage(BarrageSet bg)
    {
      this.barrages.Add(bg);
    }

    public void Update(int t, Vector2 pos, BossBackground bg, int colortype)
    {
      this.numflash -= 0.02f;
      if ((double) this.numflash <= 0.0)
        this.numflash = 0.0f;
      if (this.timecard)
      {
        this.boss.timecard = true;
        this.timecard = false;
        this.boss.nothide = this.nothide;
      }
      if (this.time == 40 && !this.boss.start)
      {
        this.boss.start = true;
        CrazyStorm crazyStorm = Program.game.game.PlayEffect(true, "24", new Vector2(this.boss.Position.X + 93f, this.boss.Position.Y - 13f));
        crazyStorm.BanSound(true);
        crazyStorm.effect = true;
        Program.game.game.PlaySound("ch02", true, this.boss.Position.X);
      }
      if (this.time == 80 && this.transform)
      {
        CrazyStorm crazyStorm = Program.game.game.PlayEffect(true, "24", new Vector2(this.boss.Position.X + 93f, this.boss.Position.Y - 13f));
        crazyStorm.BanSound(true);
        crazyStorm.effect = true;
        Program.game.game.PlaySound("ch02", true, this.boss.Position.X);
      }
      if (this.barrages[0] != null)
        this.barrages[0].cs.SetPos(new Vector2(pos.X + 93f, pos.Y - 13f), false);
      if ((double) Time.Stop != 0.0)
        ++this.time;
      if (this.cf && this.time == 1)
      {
        this.mcscale = 1f;
        this.cscale = this.mcscale;
        this.cx = 45f;
      }
      if (this.time <= 60)
        Time.Init();
      if (this.time == 120)
      {
        this.Player.dead = false;
        this.Player.shot = false;
        this.Player.bombed = false;
        this.Player.shifted = false;
      }
      if (this.time > 60 && this.time <= 120)
        this.numalpha += 0.01666667f;
      if (this.time <= 120)
        this.boss.Return();
      int num1 = 0;
      if (this.transform)
        num1 = 100;
      if (!this.cf && this.time <= 120)
      {
        if (t == this.type)
        {
          if (t == 0)
          {
            this.mfscale += 0.01085816f;
            this.fscale = this.mfscale;
            this.fx = 45f;
          }
          else
          {
            this.mcscale += 0.03584337f;
            this.cscale = this.mcscale;
            this.cx = 45f;
          }
        }
        else if (t == 0)
        {
          this.mcscale += 0.03584337f;
          this.cscale = this.mcscale;
          this.cx = 45f;
        }
        else
        {
          this.fdie = true;
          if (this.time <= 30)
          {
            this.mcscale += 0.03333334f;
            this.cscale = this.mcscale;
          }
          this.cx = 45f;
          if (this.time > 30)
          {
            this.mfscale += 0.01111111f;
            this.fscale = this.mfscale;
          }
          this.fx = 128f;
        }
      }
      else if (this.time > 120 + num1)
      {
        Program.game.achivmanager.Check(AchievementType.Challenge, 12, new Hashtable()
        {
          [(object) "bomb"] = (object) this.Player.bombed,
          [(object) "shot"] = (object) this.Player.shot
        });
        Program.game.achivmanager.Check(AchievementType.Challenge, 13, new Hashtable()
        {
          [(object) "bomb"] = (object) this.Player.bombed
        });
        Program.game.achivmanager.Check(AchievementType.Hidden, 2, new Hashtable()
        {
          [(object) "position"] = (object) this.Player.body.position,
          [(object) "type"] = (object) this.type
        });
        if (this.boss.timecard && !this.boss.nothide)
          this.boss.Hide();
        if (this.time == 121 + num1)
          this.barrages[0].cs.Start();
        if (this.type == 0)
          this.fscale = (float) this.hp / (float) this.maxhp * this.mfscale;
        if (t == this.type || t != 1)
          this.cscale = (float) this.hp / (float) this.maxhp * this.mcscale;
        ++this.frame;
        if ((this.time - (120 + num1)) % 60 == 0 && this.realtime > 0)
        {
          --this.realtime;
          if (this.realtime <= 9)
          {
            Hashtable data = new Hashtable();
            if (this.cd != null)
              data[(object) "name"] = (object) this.cd.CardName;
            else
              data[(object) "name"] = (object) "";
            data[(object) "level"] = (object) (int) (Main.Level - 1);
            Program.game.achivmanager.Check(AchievementType.Challenge, 0, data);
            Program.game.achivmanager.Check(AchievementType.Challenge, 3, new Hashtable()
            {
              [(object) "barrageid"] = (object) this.barrageid,
              [(object) "time"] = (object) this.realtime
            });
            Program.game.game.PlaySound("timeout", true, this.boss.Position.X);
            this.numflash = 1f;
          }
        }
        if (this.barrages.Count >= 2 && (this.realtime <= this.barrages[1].time || this.hp <= this.barrages[1].hp))
        {
          Program.game.game.PlaySound("tan", true, this.boss.Position.X);
          this.barrages[0].cs.Breakanditem();
          Time.Init();
          this.barrages.RemoveAt(0);
          this.barrages[0].cs.Start();
          this.barrages[0].cs.SetPos(new Vector2(pos.X + 93f, pos.Y - 13f), false);
        }
        if (this.realtime == 0 && this.hp != 0)
        {
          Hashtable data = new Hashtable();
          if (this.cd != null)
            data[(object) "name"] = (object) this.cd.CardName;
          else
            data[(object) "name"] = (object) "";
          data[(object) "level"] = (object) (int) (Main.Level - 1);
          data[(object) "shoot"] = (object) this.Player.shot;
          data[(object) "bomb"] = (object) this.Player.bombed;
          data[(object) "dead"] = (object) this.Player.dead;
          Program.game.achivmanager.Check(AchievementType.Challenge, 1, data);
          Program.game.achivmanager.Check(AchievementType.Challenge, 5, data);
          Program.game.achivmanager.Check(AchievementType.Challenge, 11, data);
          this.hp = 0;
          if (!Bonus.IsBonused())
          {
            if (this.Player.dead || this.Player.bombed)
            {
              Bonus bonus1 = new Bonus(Bonus.GetScore(this.type, (float) this.frame, true), this.type, this.frame, true);
            }
            else
            {
              this.AddClearRecord(this.stage, this.barrageid);
              if (!this.boss.timecard)
              {
                Bonus bonus2 = new Bonus(Bonus.GetScore(this.type, (float) this.frame, false), this.type, this.frame);
              }
              else
              {
                Bonus bonus3 = new Bonus(Bonus.GetScore(this.type, 0.0f, false), this.type, this.frame);
              }
            }
          }
          if (this.itemm != null)
          {
            this.itemm.Shoot(pos, 70f, this.Player, this.boss);
            this.itemm.shot = false;
          }
          if (this.cd != null)
            Program.game.game.Drawevents2 -= new Game.DrawDelegate3(this.cd.Draw);
          this.cd = (CardDisplay) null;
          this.barrages[0].cs.Breakanditem();
          this.boss.timecard = false;
          Time.Init();
          Program.game.game.FindEffect("e" + (25 + colortype).ToString())?.Break();
          this.die = true;
        }
      }
      if (this.type != 1)
        return;
      if (!this.first && this.time <= 120)
      {
        if (this.time == 30)
        {
          bg.Switch(true);
          this.boss.Image();
          Program.game.game.PlaySound("cat", true, this.boss.Position.X);
          CrazyStorm crazyStorm = Program.game.game.PlayEffect(true, (25 + colortype).ToString(), new Vector2(this.boss.Position.X + 93f, this.boss.Position.Y - 13f));
          crazyStorm.BanSound(true);
          crazyStorm.effect = true;
          crazyStorm.SetOPos(new Vector2(this.boss.Position.X + 93f, this.boss.Position.Y - 13f));
          Program.game.game.Quake(49, 4);
          this.AddSCRecord(this.stage, this.barrageid);
          this.cd = new CardDisplay(this.tex, this.boss.Spellcard, this.stage, this.barrageid);
          Program.game.game.Drawevents2 += new Game.DrawDelegate3(this.cd.Draw);
        }
        if (this.time == 90)
          Program.game.game.PlaySound("ch02", true, this.boss.Position.X);
      }
      else if (this.first && this.time > 120 && this.time == 121)
      {
        bg.Switch(true);
        Program.game.game.PlaySound("cat", true, this.boss.Position.X);
        CrazyStorm crazyStorm = Program.game.game.PlayEffect(true, (25 + colortype).ToString(), new Vector2(this.boss.Position.X + 93f, this.boss.Position.Y - 13f));
        crazyStorm.BanSound(true);
        crazyStorm.effect = true;
        crazyStorm.SetOPos(new Vector2(this.boss.Position.X + 93f, this.boss.Position.Y - 13f));
        Program.game.game.Quake(49, 4);
        this.AddSCRecord(this.stage, this.barrageid);
        this.cd = new CardDisplay(this.tex, this.boss.Spellcard, this.stage, this.barrageid);
        Program.game.game.Drawevents2 += new Game.DrawDelegate3(this.cd.Draw);
      }
      Program.game.game.FindEffect("e" + (25 + colortype).ToString())?.SetPos(new Vector2(this.boss.Position.X + 93f, this.boss.Position.Y - 13f), true);
      int num2 = this.Player.dead || this.Player.bombed ? Bonus.GetScore(this.type, 0.0f, true) : (this.boss.timecard ? Bonus.GetScore(this.type, 0.0f, false) : Bonus.GetScore(this.type, (float) this.frame, false));
      if (this.cd == null)
        return;
      this.cd.Update((float) num2);
    }

    public void Draw(SpriteBatch s, float numalpha)
    {
      s.Draw(this.tex, new Vector2(this.fx, 20f), new Rectangle?(new Rectangle(83, 0, 274, 8)), new Color(1f, 1f, 1f, numalpha), 0.0f, Vector2.Zero, new Vector2(this.fscale, 1f), SpriteEffects.None, 0.0f);
      s.Draw(this.tex, new Vector2(this.cx, 20f), new Rectangle?(new Rectangle(0, 0, 83, 8)), new Color(1f, 1f, 1f, numalpha), 0.0f, Vector2.Zero, new Vector2(this.cscale, 1f), SpriteEffects.None, 0.0f);
      char[] charArray = this.realtime.ToString().PadLeft(2, '0').ToCharArray();
      for (int index = 0; index < charArray.Length + 1 && this.realtime > 0; ++index)
      {
        if (index != charArray.Length)
        {
          s.Draw(this.tex, new Vector2(67f + (float) (index * 11) + (float) (index * 2), 29f), new Rectangle?(new Rectangle(int.Parse(charArray[index].ToString()) * 15, 9, 15, 20)), new Color(1f, 1f, 1f, numalpha), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
          s.Draw(this.tex, new Vector2(67f + (float) (index * 11) + (float) (index * 2), 29f), new Rectangle?(new Rectangle(int.Parse(charArray[index].ToString()) * 15, 9, 15, 20)), new Color(1f, 0.0f, 0.0f, this.numflash), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        }
      }
    }

    public void DeHp(int power, bool isselfbarrage)
    {
      if (this.die)
        return;
      int num = 0;
      if (this.transform)
        num = 100;
      if (this.time > 150 + num && this.time - (150 + num) > this.wudi)
      {
        if (!this.banbomb || isselfbarrage)
          this.hp -= power;
        ++this.flash;
        if (this.hp > 0 && (double) this.hp / (double) this.maxhp <= 0.200000002980232 && this.flash % 3 == 0)
        {
          if (this.flash % 2 == 0)
          {
            this.boss.rgb.X = 0.5f;
            this.boss.rgb.Y = 0.5f;
          }
          else
          {
            this.boss.rgb.X = 1f;
            this.boss.rgb.Y = 1f;
          }
        }
        if (this.flash % 2 == 0)
          Program.game.game.PlaySound("damage00", true, this.boss.Position.X);
      }
      if (this.hp > 0 || this.realtime == 0)
        return;
      Hashtable data = new Hashtable();
      if (this.cd != null)
        data[(object) "name"] = (object) this.cd.CardName;
      else
        data[(object) "name"] = (object) "";
      data[(object) "level"] = (object) (int) (Main.Level - 1);
      data[(object) "shoot"] = (object) this.Player.shot;
      data[(object) "bomb"] = (object) this.Player.bombed;
      Program.game.achivmanager.Check(AchievementType.Challenge, 2, data);
      Program.game.achivmanager.Check(AchievementType.Challenge, 7, new Hashtable()
      {
        [(object) "time"] = (object) this.realtime,
        [(object) "level"] = (object) (int) (Main.Level - 1)
      });
      this.hp = 0;
      if (this.Player.dead || this.Player.bombed)
      {
        Bonus bonus1 = new Bonus(Bonus.GetScore(this.type, (float) this.frame, true), this.type, this.frame, true);
      }
      else
      {
        this.AddClearRecord(this.stage, this.barrageid);
        Bonus bonus2 = new Bonus(Bonus.GetScore(this.type, (float) this.frame, false), this.type, this.frame);
      }
      this.realtime = 0;
    }

    public float GetHp()
    {
      return (float) this.hp / (float) this.maxhp;
    }

    private void AddSCRecord(int stage, int barrageid)
    {
      if (Main.SpecialMode != Modes.SPELLCARD)
      {
        List<SpellCardData> spellCardDataList = Program.game.game.playdata.players[(int) (Main.Character - 1)].sc[(int) (Main.Level - 1)];
        string str = (string) this.boss.Spellcard[(int) (Main.Level - 1)][(object) (stage.ToString() + barrageid.ToString())];
        if (str == null)
          return;
        foreach (SpellCardData spellCardData in spellCardDataList)
        {
          if (spellCardData.name == str)
          {
            if (Main.Replay)
              return;
            ++spellCardData.playtime;
            return;
          }
        }
        spellCardDataList.Add(new SpellCardData()
        {
          name = str,
          playtime = 1,
          cleartime = 0
        });
      }
      else
      {
        if (Main.Replay)
          return;
        SpecialData data = Program.game.game.LoadSpecialData();
        ++data.spe[(int) (Main.Character - 1)].sc[Program.game.game.Spellcardid].playtime;
        Program.game.game.SaveSpecialData(data);
      }
    }

    private void AddClearRecord(int stage, int barrageid)
    {
      if (!this.cleared)
      {
        if (Main.SpecialMode != Modes.SPELLCARD)
        {
          List<SpellCardData> spellCardDataList = Program.game.game.playdata.players[(int) (Main.Character - 1)].sc[(int) (Main.Level - 1)];
          string str = (string) this.boss.Spellcard[(int) (Main.Level - 1)][(object) (stage.ToString() + barrageid.ToString())];
          foreach (SpellCardData spellCardData in spellCardDataList)
          {
            if (spellCardData.name == str)
            {
              if (!Main.Replay)
              {
                Program.game.achivmanager.Check(AchievementType.Challenge, 8, new Hashtable()
                {
                  [(object) "level"] = (object) Main.Level,
                  [(object) "shifted"] = (object) this.Player.shifted,
                  [(object) "mode"] = (object) Main.SpecialMode
                });
                ++spellCardData.cleartime;
                Program.game.achivmanager.Check(AchievementType.Challenge, 14, new Hashtable()
                {
                  [(object) "playdata"] = (object) Program.game.game.playdata
                });
                break;
              }
              break;
            }
          }
        }
        else if (!Main.Replay)
        {
          SpecialData data = Program.game.game.LoadSpecialData();
          ++data.spe[(int) (Main.Character - 1)].sc[Program.game.game.Spellcardid].cleartime;
          Program.game.game.SaveSpecialData(data);
          Program.game.achivmanager.Check(AchievementType.Challenge, 15, new Hashtable()
          {
            [(object) "specialdata"] = (object) data
          });
          Program.game.achivmanager.Check(AchievementType.Hidden, 7, new Hashtable()
          {
            [(object) "cleartime"] = (object) data.spe[(int) (Main.Character - 1)].sc[Program.game.game.Spellcardid].cleartime,
            [(object) "totaltime"] = (object) data.spe[(int) (Main.Character - 1)].sc[Program.game.game.Spellcardid].playtime
          });
        }
      }
      this.cleared = true;
    }
  }
}
