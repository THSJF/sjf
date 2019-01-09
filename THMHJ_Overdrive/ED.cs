// Decompiled with JetBrains decompiler
// Type: THMHJ.ED
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace THMHJ
{
  public class ED
  {
    private int edtype;
    private RecordSave record;
    private ReplaySave replay;
    private GraphicsDevice gd;
    private Texture2D praticle;
    private SimplePraticleActor praticle1;
    private Texture2D text;
    private float[] textcolor;
    private Texture2D white;
    private float whitecolor;
    private Sprite[] background;
    private Sprite logo;
    private Sprite end;
    private Sprite black;
    private Sprite[] staff;
    private Sprite[] background2;
    private Sprite[] staff2;
    private Texture2D white2;
    private Sprite thanks;
    private Sprite next;
    private Sprite dialogbg;
    private Sprite[] dialog;
    private Sprite tip;
    private float whitecolor2;
    private bool ifcontinued;
    private int dialogt;
    private int dialogtime;
    private bool dialogfinish;
    private bool ifsaw;
    public bool Finished;
    private int time;

    public ED(bool continued, int edtype, GraphicsDevice g, RecordSave record, ReplaySave replay)
    {
      this.ifcontinued = continued;
      this.edtype = edtype;
      this.record = record;
      this.replay = replay;
      this.gd = g;
      GC.Collect();
      BGM.Disposes();
      PracticeData practiceData = this.LoadPracticeData();
      if (edtype == 1)
      {
        for (int index = 0; index < 4; ++index)
        {
          if (practiceData.clear[index])
          {
            this.ifsaw = true;
            break;
          }
        }
      }
      Program.game.achivmanager.Check(AchievementType.Normal, 2, new Hashtable()
      {
        [(object) "ok"] = (object) (!this.ifcontinued & edtype == 1)
      });
      Program.game.achivmanager.Check(AchievementType.Challenge, 9, new Hashtable()
      {
        [(object) "level"] = (object) Main.Level
      });
      if (edtype == 1 && !this.ifsaw || edtype == 4)
      {
        if (!this.ifcontinued || edtype == 4)
        {
          this.praticle = Texture2D.FromFile(g, Cry.Decry("Content\\Graphics\\List\\praticle.xna", 0));
          this.praticle1 = new SimplePraticleActor(new Vector2(470f, 0.0f), new Vector2(400f, 100f), 10, 3);
          this.praticle1.SetTexture(this.praticle, new Rectangle(155, 6, 32, 22), new Vector2(16f, 11f), true);
          this.praticle1.SetPraticle(new Vector2(1f, 1f), new Vector2(-0.7f, 0.8f), 0.0f, Vector2.Zero, 0.0f, new Vector2(0.0f, 360f));
          this.praticle1.SetPraticleEvent(new PraticleUpdate(this.Praticle1Update));
          this.text = Texture2D.FromFile(g, Cry.Decry("Content\\Graphics\\Black\\31.xna", 0));
          this.textcolor = new float[4];
          this.white = Texture2D.FromFile(g, Cry.Decry("Content\\Graphics\\Black\\32.xna", 0));
          this.background = new Sprite[4];
          for (int index = 0; index < 4; ++index)
          {
            Texture2D t = Texture2D.FromFile(g, Cry.Decry("Content\\Graphics\\Black\\" + (1 + index).ToString() + ".xna", 0));
            this.background[index] = new Sprite(t);
            this.background[index].origin = new Vector2((float) (t.Width / 2), (float) (t.Height / 2));
            this.background[index].position = new Vector2(320f, 240f);
            this.background[index].scale = new Vector2(2f, 2f);
          }
          Texture2D t1 = Texture2D.FromFile(g, Cry.Decry("Content\\Graphics\\Pattern\\logo.xna", 0));
          this.logo = new Sprite(t1);
          this.logo.origin = new Vector2((float) (t1.Width / 2), (float) (t1.Height / 2));
          this.logo.position = new Vector2(320f, 240f);
          this.logo.scale = new Vector2(1.2f, 1.2f);
          this.end = new Sprite(Texture2D.FromFile(g, Cry.Decry("Content\\Graphics\\Black\\33.xna", 0)));
          this.black = new Sprite(this.white);
          this.black.position = new Vector2(640f, 0.0f);
          this.black.color.r = this.black.color.g = this.black.color.b = 0.0f;
          this.staff = new Sprite[6];
          for (int index = 0; index < 6; ++index)
            this.staff[index] = new Sprite(Texture2D.FromFile(g, Cry.Decry("Content\\Graphics\\Black\\" + (34 + index).ToString() + ".xna", 0)));
          this.background2 = new Sprite[2];
          for (int index = 0; index < 2; ++index)
          {
            Texture2D t2 = Texture2D.FromFile(g, Cry.Decry("Content\\Graphics\\Black\\" + (40 + index).ToString() + ".xna", 0));
            this.background2[index] = new Sprite(t2);
            this.background2[index].origin = new Vector2((float) (t2.Width / 2), (float) (t2.Height / 2));
            this.background2[index].position = new Vector2(320f, 240f);
            this.background2[index].scale = new Vector2(1f, 1f);
          }
          this.staff2 = new Sprite[4];
          for (int index = 0; index < 4; ++index)
            this.staff2[index] = new Sprite(Texture2D.FromFile(g, Cry.Decry("Content\\Graphics\\Black\\" + (42 + index).ToString() + ".xna", 0)));
          this.white2 = Texture2D.FromFile(g, Cry.Decry("Content\\Graphics\\Black\\32.xna", 0));
          this.thanks = new Sprite(Texture2D.FromFile(g, Cry.Decry("Content\\Graphics\\Black\\46.xna", 0)));
          this.next = new Sprite(Texture2D.FromFile(g, Cry.Decry("Content\\Graphics\\Black\\47.xna", 0)));
        }
        else
        {
          Program.game.PlaySound("Result bank");
          this.dialogbg = new Sprite(Texture2D.FromFile(g, Cry.Decry("Content\\Graphics\\Black\\53.xna", 0)));
          this.dialog = new Sprite[4];
          for (int index = 0; index < 4; ++index)
          {
            this.dialog[index] = new Sprite(Texture2D.FromFile(g, Cry.Decry("Content\\Graphics\\Black\\" + (48 + index).ToString() + ".xna", 0)));
            this.dialog[index].position.Y = 30f;
          }
          this.tip = new Sprite(Texture2D.FromFile(g, Cry.Decry("Content\\Graphics\\Black\\52.xna", 0)));
        }
      }
      else if (!this.ifcontinued)
      {
        this.time = 7141;
        Program.game.PlaySound("Result bank");
      }
      else
      {
        Program.game.PlaySound("Result bank");
        this.dialogbg = new Sprite(Texture2D.FromFile(g, Cry.Decry("Content\\Graphics\\Black\\53.xna", 0)));
        this.dialog = new Sprite[4];
        for (int index = 0; index < 4; ++index)
        {
          this.dialog[index] = new Sprite(Texture2D.FromFile(g, Cry.Decry("Content\\Graphics\\Black\\" + (48 + index).ToString() + ".xna", 0)));
          this.dialog[index].position.Y = 30f;
        }
        this.tip = new Sprite(Texture2D.FromFile(g, Cry.Decry("Content\\Graphics\\Black\\52.xna", 0)));
      }
    }

    public void Update()
    {
      if (!this.ifcontinued || this.edtype == 4)
      {
        if (this.time == 120)
        {
          Music.BGM = Music.SB.GetCue("14");
          Music.BGM.Play();
          StreamReader streamReader = new StreamReader(Cry.Decry("Content/Music/00.xna", 2));
          streamReader.ReadLine();
          int num = int.Parse(streamReader.ReadLine());
          streamReader.Close();
          if (num < 13)
          {
            StreamWriter streamWriter = new StreamWriter("Content/Music/00.xna", false);
            streamWriter.WriteLine("Fantasy Danmaku Festival");
            streamWriter.WriteLine(13.ToString());
            streamWriter.Close();
            Cry.Encry("Content/Music/00.xna", 2);
          }
          this.praticle1.Start();
        }
        else if (this.time > 180 && this.time <= 380)
          this.textcolor[0] += 0.005f;
        else if (this.time > 600 && this.time <= 800)
          this.textcolor[1] += 0.005f;
        else if (this.time > 1020 && this.time <= 1220)
          this.textcolor[2] += 0.005f;
        else if (this.time > 1440 && this.time <= 1640)
          this.textcolor[3] += 0.005f;
        else if (this.time > 1740 && this.time <= 1800)
          this.whitecolor += 0.01666667f;
        else if (this.time > 1820 && this.time <= 1840)
        {
          this.background[0].color.a += 0.05f;
          this.background[0].scale += new Vector2((float) ((0.800000011920929 - (double) this.background[0].scale.X) / 15.0), (float) ((0.800000011920929 - (double) this.background[0].scale.Y) / 15.0));
          this.logo.color.a += 0.05f;
          this.logo.scale += new Vector2((float) ((0.699999988079071 - (double) this.logo.scale.X) / 20.0), (float) ((0.699999988079071 - (double) this.logo.scale.Y) / 20.0));
        }
        else if (this.time > 1840 && this.time <= 2200)
        {
          this.background[0].scale -= new Vector2(0.00065f, 0.00065f);
          this.logo.scale -= new Vector2(0.0003f, 0.0003f);
          if (this.time > 2020 && this.time <= 2040)
            this.end.color.a += 0.05f;
          if (this.time == 2200)
            this.praticle1.Stop();
        }
        else if (this.time > 2200 && this.time <= 2250)
        {
          this.background[0].position.X += (float) ((0.0 - (double) this.background[0].position.X) / 40.0);
          this.logo.color.a -= 0.05f;
          if ((double) this.logo.color.a <= 0.0)
            this.logo.color.a = 0.0f;
          this.end.color.a -= 0.02f;
          this.black.position.X += (float) ((182.0 - (double) this.black.position.X) / 15.0);
          this.black.color.a = 1f;
        }
        else if (this.time > 2260 && this.time <= 2670)
        {
          if (this.time == 2300)
            this.praticle1 = (SimplePraticleActor) null;
          this.background[0].position.X += 0.1f;
          this.staff[0].color.a += 0.01f;
          if ((double) this.staff[0].color.a >= 1.0)
            this.staff[0].color.a = 1f;
        }
        else if (this.time > 2670 && this.time <= 3080)
        {
          this.background[0].position.X += 0.1f;
          this.background[1].position = this.background[0].position;
          this.background[1].scale = this.background[0].scale;
          this.background[1].color.a += 0.005f;
          if ((double) this.background[1].color.a >= 1.0)
            this.background[1].color.a = 1f;
          this.staff[0].color.a -= 0.02f;
          if ((double) this.staff[0].color.a <= 0.0)
            this.staff[0].color.a = 0.0f;
          this.staff[1].color.a += 0.01f;
          if ((double) this.staff[1].color.a >= 1.0)
            this.staff[1].color.a = 1f;
        }
        else if (this.time > 3080 && this.time <= 3490)
        {
          this.background[0].position.X += 0.1f;
          this.background[1].position = this.background[0].position;
          this.staff[1].color.a -= 0.02f;
          if ((double) this.staff[1].color.a <= 0.0)
            this.staff[1].color.a = 0.0f;
          this.staff[2].color.a += 0.01f;
          if ((double) this.staff[2].color.a >= 1.0)
            this.staff[2].color.a = 1f;
        }
        else if (this.time > 3490 && this.time <= 3900)
        {
          this.background[0].position.X += 0.1f;
          this.background[1].position = this.background[0].position;
          this.background[2].position = this.background[0].position;
          this.background[2].scale = this.background[0].scale;
          this.background[2].color.a += 0.005f;
          if ((double) this.background[2].color.a >= 1.0)
            this.background[2].color.a = 1f;
          this.staff[2].color.a -= 0.02f;
          if ((double) this.staff[2].color.a <= 0.0)
            this.staff[2].color.a = 0.0f;
          this.staff[3].color.a += 0.01f;
          if ((double) this.staff[3].color.a >= 1.0)
            this.staff[3].color.a = 1f;
        }
        else if (this.time > 3900 && this.time <= 4310)
        {
          this.background[0].position.X += 0.1f;
          this.background[2].position = this.background[0].position;
          this.staff[3].color.a -= 0.02f;
          if ((double) this.staff[3].color.a <= 0.0)
            this.staff[3].color.a = 0.0f;
          this.staff[4].color.a += 0.01f;
          if ((double) this.staff[4].color.a >= 1.0)
            this.staff[4].color.a = 1f;
        }
        else if (this.time > 4310 && this.time <= 4750)
        {
          this.background[0].position.X += 0.1f;
          this.background[2].position = this.background[0].position;
          this.background[3].position = this.background[0].position;
          this.background[3].scale = this.background[0].scale;
          this.background[3].color.a += 0.005f;
          if ((double) this.background[3].color.a >= 1.0)
            this.background[3].color.a = 1f;
          this.staff[4].color.a -= 0.02f;
          if ((double) this.staff[4].color.a <= 0.0)
            this.staff[4].color.a = 0.0f;
          this.staff[5].color.a += 0.01f;
          if ((double) this.staff[5].color.a >= 1.0)
            this.staff[5].color.a = 1f;
        }
        else if (this.time > 4750 && this.time <= 4800)
        {
          this.staff[5].color.a -= 0.05f;
          if ((double) this.staff[5].color.a <= 0.0)
            this.staff[5].color.a = 0.0f;
          for (int index = 0; index < 4; ++index)
            this.background[index].color.a -= 0.02f;
          this.black.position.X += (float) ((-200.0 - (double) this.black.position.X) / 15.0);
        }
        else if (this.time > 4800 && this.time <= 5220)
        {
          this.background2[0].color.a += 0.02f;
          if ((double) this.background2[0].color.a >= 1.0)
            this.background2[0].color.a = 1f;
          this.background2[0].position.X += 0.1f;
          this.background2[0].position.Y = 230f;
          this.background2[0].scale = new Vector2(0.8f, 0.8f);
          this.staff2[0].color.a += 0.01f;
          if ((double) this.staff2[0].color.a >= 1.0)
            this.staff2[0].color.a = 1f;
        }
        else if (this.time > 5220 && this.time <= 5640)
        {
          this.background2[0].position.X += 0.1f;
          this.staff2[0].color.a -= 0.02f;
          if ((double) this.staff2[0].color.a <= 0.0)
            this.staff2[0].color.a = 0.0f;
          this.staff2[1].color.a += 0.01f;
          if ((double) this.staff2[1].color.a >= 1.0)
            this.staff2[1].color.a = 1f;
        }
        else if (this.time > 5640 && this.time <= 6060)
        {
          this.background2[0].position.X += 0.1f;
          this.staff2[1].color.a -= 0.02f;
          if ((double) this.staff2[1].color.a <= 0.0)
            this.staff2[1].color.a = 0.0f;
          this.staff2[2].color.a += 0.01f;
          if ((double) this.staff2[2].color.a >= 1.0)
            this.staff2[2].color.a = 1f;
        }
        else if (this.time > 6060 && this.time <= 6480)
        {
          this.background2[0].position.X += 0.1f;
          this.staff2[2].color.a -= 0.02f;
          if ((double) this.staff2[2].color.a <= 0.0)
            this.staff2[2].color.a = 0.0f;
          this.staff2[3].color.a += 0.01f;
          if ((double) this.staff2[3].color.a >= 1.0)
            this.staff2[3].color.a = 1f;
        }
        if (this.time > 6450 && this.time <= 6500)
          this.whitecolor2 += 0.02f;
        else if (this.time == 6501)
        {
          for (int index = 0; index < 4; ++index)
            this.textcolor[index] = 0.0f;
          this.background2[0].color.a = 0.0f;
          this.staff2[3].color.a = 0.0f;
          this.black.color.a = 0.0f;
          this.whitecolor2 = 0.0f;
          this.background2[1].scale = new Vector2(1.3f, 1.3f);
        }
        else if (this.time > 6500 && this.time <= 6520)
        {
          this.background2[1].scale += new Vector2((float) ((0.699999988079071 - (double) this.background2[1].scale.X) / 15.0), (float) ((0.699999988079071 - (double) this.background2[1].scale.Y) / 15.0));
          this.background2[1].color.a += 0.05f;
        }
        else if (this.time > 6520 && this.time <= 6920)
        {
          this.background2[1].scale -= new Vector2(0.0006f, 0.0006f);
          if (this.time > 6720)
          {
            this.thanks.color.a += 0.05f;
            if ((double) this.thanks.color.a >= 1.0)
              this.thanks.color.a = 1f;
          }
        }
        else if (this.time > 6920 && this.time <= 6970)
        {
          this.background2[1].scale -= new Vector2(0.0006f, 0.0006f);
          this.whitecolor -= 0.05f;
          if ((double) this.whitecolor <= 0.0)
            this.whitecolor = 0.0f;
          this.background2[1].color.a -= 0.05f;
          if ((double) this.background2[1].color.a <= 0.0)
            this.background2[1].color.a = 0.0f;
          this.thanks.color.a -= 0.1f;
          if ((double) this.thanks.color.a <= 0.0)
            this.thanks.color.a = 0.0f;
          this.next.color.a += 0.02f;
        }
        else if (this.time >= 7120 && this.time <= 7140)
          this.next.color.a -= 0.05f;
        else if (this.time == 7141 && this.edtype != 4)
        {
          if (this.edtype == 1)
          {
            ++this.record.Playdata.players[(int) (Main.Character - 1)].cleartime;
            PracticeData data = this.LoadPracticeData();
            data.clear[(int) (Main.Character - 1)] = true;
            this.SavePracticeData(data);
            Program.game.achivmanager.Check(AchievementType.Normal, 3, new Hashtable()
            {
              [(object) "practice"] = (object) data
            });
            Program.game.achivmanager.Check(AchievementType.Normal, 4, new Hashtable()
            {
              [(object) "playdata"] = (object) this.record.Playdata
            });
            Program.game.achivmanager.Check(AchievementType.Normal, 5, new Hashtable()
            {
              [(object) "practice"] = (object) data
            });
          }
        }
        else if (this.time > 7141 && this.edtype != 4 && !this.record.Ok)
        {
          this.record.Update();
          if (this.record.Ok)
            this.SavePlayData(this.record.Playdata);
        }
        else if (this.time > 7141 && this.edtype != 4 && !this.replay.Ok)
          this.replay.Update();
        else if (this.time > 7141)
        {
          BGM.Disposes();
          Program.game.StopSound("Result bank");
          Main.stage = "ENTRANCE";
          this.Finished = true;
        }
        if (this.edtype == 4 && (Main.keyboardstat.IsKeyDown(Keys.Escape) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Special, Main.prepadstat) || PadState.IsKeyPressed(JOYKEYS.Pause, Main.prepadstat)))
        {
          BGM.Disposes();
          Program.game.StopSound("Result bank");
          Main.stage = "ENTRANCE";
          this.Finished = true;
        }
        if (this.praticle1 != null)
          this.praticle1.Update();
      }
      else
        this.ContinueUpdate();
      ++this.time;
    }

    public void ContinueUpdate()
    {
      if (this.time > 20 && this.time < 40)
      {
        this.dialogbg.color.a += 0.05f;
      }
      else
      {
        if (this.time < 140)
          return;
        if (!this.dialogfinish)
        {
          this.time = 140;
          for (int index = 0; index < this.dialog.Length; ++index)
          {
            if (index == this.dialogt)
            {
              this.dialog[index].color.a += 0.05f;
              if ((double) this.dialog[index].color.a >= 1.0)
                this.dialog[index].color.a = 1f;
            }
            else
            {
              this.dialog[index].color.a -= 0.05f;
              if ((double) this.dialog[index].color.a <= 0.0)
                this.dialog[index].color.a = 0.0f;
            }
          }
          ++this.dialogtime;
          if (this.dialogtime < 60 || !(Main.keyboardstat.IsKeyDown(Keys.Enter) & Main.keyboardstat != Main.prekeyboard) && !(Main.keyboardstat.IsKeyDown(Keys.Z) & Main.keyboardstat != Main.prekeyboard) && !PadState.IsKeyPressed(JOYKEYS.Confirm, Main.prepadstat))
            return;
          ++this.dialogt;
          if (this.dialogt > this.dialog.Length - 1)
            this.dialogfinish = true;
          this.dialogtime = 0;
        }
        else if (this.time > 140 && this.time <= 160)
        {
          for (int index = 0; index < this.dialog.Length; ++index)
          {
            this.dialog[index].color.a -= 0.05f;
            if ((double) this.dialog[index].color.a <= 0.0)
              this.dialog[index].color.a = 0.0f;
          }
          this.dialogbg.color.a -= 0.05f;
        }
        else if (this.time > 160 && !this.record.Ok)
        {
          this.record.Update();
          if (this.record.Ok)
            this.SavePlayData(this.record.Playdata);
          this.time = 161;
        }
        else if (this.time > 160 && this.time <= 180)
          this.tip.color.a += 0.05f;
        else if (this.time > 270 && this.time <= 290)
        {
          this.tip.color.a -= 0.05f;
        }
        else
        {
          if (this.time <= 290)
            return;
          BGM.Disposes();
          Program.game.StopSound("Result bank");
          Main.stage = "ENTRANCE";
          this.Finished = true;
        }
      }
    }

    public void Draw(SpriteBatch s)
    {
      if (this.time > 7141 && this.edtype != 4 && !this.record.Ok)
        this.record.Draw(s, new Vector2(95f, 0.0f));
      else if (this.time > 7141 && this.edtype != 4 && !this.replay.Ok)
        this.replay.Draw(s, new Vector2(95f, 0.0f));
      if (this.edtype == 1 && !this.ifsaw || this.edtype == 4)
      {
        if (!this.ifcontinued || this.edtype == 4)
        {
          for (int index = 0; index < 4; ++index)
            s.Draw(this.text, new Vector2(60f, (float) (175 + 38 * index)), new Rectangle?(new Rectangle(0, 38 * index, 307, 38)), new Color(1f, 1f, 1f, this.textcolor[index]), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
          s.Draw(this.white, Vector2.Zero, new Color(1f, 1f, 1f, this.whitecolor));
          for (int index = 0; index < 4; ++index)
            this.background[index].Draw(s, SpriteEffects.None, 0.0f);
          if (this.praticle1 != null)
            this.praticle1.Draw(s);
          for (int index = 0; index < 2; ++index)
            this.background2[index].Draw(s, SpriteEffects.None, 0.0f);
          this.logo.Draw(s, SpriteEffects.None, 0.0f);
          this.end.Draw(s, SpriteEffects.None, 0.0f);
          this.black.Draw(s, SpriteEffects.None, 0.0f);
          for (int index = 0; index < 6; ++index)
            this.staff[index].Draw(s, SpriteEffects.None, 0.0f);
          for (int index = 0; index < 4; ++index)
            this.staff2[index].Draw(s, SpriteEffects.None, 0.0f);
          s.Draw(this.white2, Vector2.Zero, new Color(1f, 1f, 1f, this.whitecolor2));
          this.thanks.Draw(s, SpriteEffects.None, 0.0f);
          this.next.Draw(s, SpriteEffects.None, 0.0f);
        }
        else
        {
          this.dialogbg.Draw(s, SpriteEffects.None, 0.0f);
          for (int index = 0; index < 4; ++index)
            this.dialog[index].Draw(s, SpriteEffects.None, 0.0f);
          this.tip.Draw(s, SpriteEffects.None, 0.0f);
          if (this.time <= 160 || this.record.Ok)
            return;
          this.record.Draw(s, new Vector2(95f, 0.0f));
        }
      }
      else
      {
        if (!this.ifcontinued)
          return;
        this.dialogbg.Draw(s, SpriteEffects.None, 0.0f);
        for (int index = 0; index < 4; ++index)
          this.dialog[index].Draw(s, SpriteEffects.None, 0.0f);
        this.tip.Draw(s, SpriteEffects.None, 0.0f);
        if (this.time <= 160 || this.record.Ok)
          return;
        this.record.Draw(s, new Vector2(95f, 0.0f));
      }
    }

    private void SavePlayData(PlayData data)
    {
      FileStream fileStream = new FileStream("Content\\Data\\4.xna", FileMode.Create);
      new BinaryFormatter().Serialize((Stream) fileStream, (object) data);
      fileStream.Close();
      Cry.Encry("Content\\Data\\4.xna", 2);
    }

    private PracticeData LoadPracticeData()
    {
      Stream serializationStream = Cry.Decry("Content\\Data\\5.xna", 2);
      PracticeData practiceData = (PracticeData) new BinaryFormatter().Deserialize(serializationStream);
      serializationStream.Close();
      return practiceData;
    }

    private void SavePracticeData(PracticeData data)
    {
      FileStream fileStream = new FileStream("Content\\Data\\5.xna", FileMode.Create);
      new BinaryFormatter().Serialize((Stream) fileStream, (object) data);
      fileStream.Close();
      Cry.Encry("Content\\Data\\5.xna", 2);
    }

    private void Praticle1Update(SimplePraticle item)
    {
      if (item.time == 1)
        item.values.Add("alpha", 1f);
      item.position.Y += 2f;
      item.position.X -= 1.4f;
      item.rotate += 3f;
      item.scale.X = item.oscale.X * Math.Abs((float) Math.Sin((double) MathHelper.ToRadians((float) (item.time * 2))));
      if ((double) item.position.Y >= 480.0)
      {
        Dictionary<string, float> values;
        (values = item.values)["alpha"] = values["alpha"] - 0.01f;
        if ((double) item.values["alpha"] <= 0.0)
          item.NeedDis = true;
      }
      if (this.time > 2200 && this.time <= 2300)
      {
        Dictionary<string, float> values;
        (values = item.values)["alpha"] = values["alpha"] - 0.015f;
        if ((double) item.values["alpha"] <= 0.0)
          item.NeedDis = true;
      }
      if (this.time < 1820 || this.time > 2300)
        return;
      item.alpha = item.values["alpha"];
    }
  }
}
