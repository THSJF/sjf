// Decompiled with JetBrains decompiler
// Type: THMHJ.Entrance
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
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace THMHJ
{
  public class Entrance
  {
    private int time4 = 7;
    private int time7 = 7;
    private float scale = 2.5f;
    private float scale2 = 0.8f;
    private float x1 = 320f;
    private float y1 = 240f;
    private float x2 = 320f;
    private float y2 = 240f;
    private int selection = 1;
    private int selection2 = 1;
    private Sound sound;
    private GraphicsDevice gd;
    private GameResource gr;
    private Sprite crapwise;
    private Sprite displaybox;
    private Sprite playdata;
    private Sprite playerdata;
    private Sprite leveldata;
    private Sprite[] level;
    private Sprite[] character;
    private Sprite cinfo;
    private Sprite mrcover;
    private Sprite bgmlist;
    private Sprite[] keybutton;
    private Sprite[] keybuttonon;
    private Texture2D optionnum;
    private Texture2D optionnumon;
    private Texture2D e1;
    private Texture2D e2;
    private Texture2D bless;
    private Texture2D logo;
    private Texture2D blackground;
    private Texture2D press;
    private Texture2D[] button;
    private Texture2D[] buttonon;
    private Texture2D buttonsp;
    private Texture2D buttonspon;
    private Texture2D volume;
    private Texture2D volumeon;
    private Texture2D blackbox;
    private Texture2D achivbox;
    private Texture2D achivlogo;
    private Texture2D achivrate;
    private Texture2D achivstatus;
    private Texture2D achivtype;
    private Texture2D achivboxon;
    private Praticle praticle;
    private List<string[]> pstring;
    private int time;
    private int time2;
    private int time3;
    private int time5;
    private int time6;
    private int time8;
    private int time9;
    private int time11;
    private int time12;
    private int time13;
    private int time14;
    private int time15;
    private int time16;
    private int time17;
    private int time18;
    private int time19;
    private int time20;
    private int time21;
    private int time22;
    private int time23;
    private int time24;
    private int time25;
    private int time26;
    private int time27;
    private bool steps;
    private float fade;
    private float fade2;
    private float fade3;
    private float fade4;
    private float fade5;
    private float pfade;
    private float[] buttonfade;
    private int[] buttonx;
    private int[] buttony;
    private int buttonspx;
    private int buttonspy;
    private int pselection;
    private Thread thread;
    private string stage;
    public bool Finished;
    private bool Fadeout;
    private bool stepFadeout;
    private int season;
    private int mlock;
    private bool[] mlist;
    private float[] mlistx;
    private float[] mlisty;
    private float[] mlistfade;
    private Vector2[] crapwisexy;
    private PRACTICE PRACTICE;
    private REPLAY REPLAY;
    private PLAYDATA PLAYDATA;
    private SPECIAL SPECIAL;
    private PracticeData practicedata;

    public Entrance(GraphicsDevice g, GameResource gr_g)
    {
      this.gd = g;
      this.gr = gr_g;
      Main.Replay = false;
      Music.BGMvolume = int.Parse(Main.ini.ReadValue("Sound", "BGM"));
      Sound.SEvolume = int.Parse(Main.ini.ReadValue("Sound", "SE"));
      this.sound = new Sound();
      this.stage = "OP";
      this.season = (int) MathHelper.Lerp(1f, 5f, (float) Main.rand.NextDouble());
      this.bless = Texture2D.FromFile(g, Cry.Decry("Content/Graphics/Info/bless.xna", 0));
      PraticleManager.initialize(g);
      this.praticle = new Praticle(false, true, new Rectangle(0, 0, 28, 28), new Vector4(520f, 407f, 100f, 40f), new Vector2(14f, 14f), 15, 0, 80, 1f, 0.02f, new Vector2(180f, 0.0f), 20f);
      this.praticle.scale = new Vector4(1f, 0.5f, 0.0f, 0.0f);
      this.thread = new Thread(new ParameterizedThreadStart(this.Load));
      this.thread.Priority = ThreadPriority.Highest;
      this.thread.Start((object) g);
    }

    private void Load(object obj)
    {
      try
      {
        GraphicsDevice graphicsDevice = (GraphicsDevice) obj;
        this.practicedata = this.LoadPracticeData();
        Characters.Initialize();
        this.e1 = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Info\\e1.xna", 0));
        this.e2 = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Info\\e2.xna", 0));
        this.logo = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Pattern\\logo.xna", 0));
        switch (this.season)
        {
          case 1:
            this.blackground = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Black\\1.xna", 0));
            break;
          case 2:
            this.blackground = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Black\\2.xna", 0));
            break;
          case 3:
            this.blackground = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Black\\3.xna", 0));
            break;
          case 4:
            this.blackground = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Black\\4.xna", 0));
            break;
        }
        this.press = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Info\\press.xna", 0));
        this.button = new Texture2D[17];
        this.buttonon = new Texture2D[17];
        this.buttonfade = new float[14];
        this.buttonx = new int[14];
        this.buttony = new int[14];
        this.level = new Sprite[5];
        this.character = new Sprite[4];
        for (int index = 1; index < 14; ++index)
          this.buttonfade[index] = 0.0f;
        this.keybutton = new Sprite[5];
        this.keybuttonon = new Sprite[5];
        for (int index = 0; index < 4; ++index)
        {
          this.keybutton[index] = new Sprite(Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Button\\option" + (index + 6).ToString() + ".xna", 0)));
          this.keybuttonon[index] = new Sprite(Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Button\\option" + (index + 6).ToString() + "on.xna", 0)));
        }
        this.keybutton[4] = new Sprite(Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Button\\begin8.xna", 0)));
        this.keybuttonon[4] = new Sprite(Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Button\\begin8on.xna", 0)));
        this.optionnum = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\List\\optionnum.xna", 0));
        this.optionnumon = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\List\\optionnumon.xna", 0));
        for (int index = 1; index < 8; ++index)
        {
          int num = index;
          if (index >= 2)
            num = index + 1;
          this.button[index] = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Button\\begin" + num.ToString() + ".xna", 0));
          this.buttonon[index] = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Button\\begin" + num.ToString() + "on.xna", 0));
          this.buttonx[index] = 20 + (index - 1) * 12;
          if (index < 5)
          {
            this.buttony[index] = 180 + (index - 1) * 33;
          }
          else
          {
            this.buttonx[index] = 20 + (index - 1) * 12 + 12;
            this.buttony[index] = 210 + (index - 1) * 33;
          }
        }
        this.buttonsp = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Button\\begin9.xna", 0));
        this.buttonspon = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Button\\begin9on.xna", 0));
        this.buttonspx = 68;
        this.buttonspy = 309;
        for (int index = 1; index < 6; ++index)
        {
          this.button[8 + index] = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Button\\option" + index.ToString() + ".xna", 0));
          if (index > 2)
            this.buttonon[8 + index] = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Button\\option" + index.ToString() + "on.xna", 0));
        }
        this.buttonx[9] = 20;
        this.buttonx[10] = 30;
        this.buttony[9] = 266;
        this.buttony[10] = 296;
        this.buttonx[13] = 40;
        this.buttony[13] = 326;
        this.buttonx[11] = 50;
        this.buttonx[12] = 60;
        this.buttony[11] = 356;
        this.buttony[12] = 386;
        for (int index = 14; index <= 16; ++index)
        {
          this.button[index] = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Button\\special" + (index - 13).ToString() + ".xna", 0));
          this.buttonon[index] = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Button\\special" + (index - 13).ToString() + "on.xna", 0));
        }
        this.volume = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Button\\volume.xna", 0));
        this.volumeon = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Button\\volumeon.xna", 0));
        this.crapwise = new Sprite(Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Button\\crapwise.xna", 0)));
        this.crapwisexy = new Vector2[2];
        this.crapwisexy[0] = new Vector2(366f, 242f);
        this.crapwisexy[1] = new Vector2(52f, 242f);
        this.displaybox = new Sprite(Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\UI\\displaybox.xna", 0)));
        this.blackbox = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\UI\\blackbox.xna", 0));
        for (int index = 0; index < 5; ++index)
          this.level[index] = new Sprite(Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Info\\level" + (index + 1).ToString() + ".xna", 0)));
        for (int index = 0; index < 4; ++index)
        {
          this.character[index] = new Sprite(Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Character\\" + index.ToString() + "1.xna", 0)));
          this.character[index].position = new Vector2(200f, 0.0f);
        }
        this.cinfo = new Sprite(Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Info\\cinfo.xna", 0)));
        this.cinfo.position = new Vector2(100f, 20f);
        this.playdata = new Sprite(Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Info\\playdata.xna", 0)));
        this.playerdata = new Sprite(Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Info\\playerdata.xna", 0)));
        this.leveldata = new Sprite(Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Info\\leveldata.xna", 0)));
        this.achivbox = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Info\\achivbox.xna", 0));
        this.achivboxon = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Info\\achivboxon.xna", 0));
        this.achivlogo = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Info\\achivlogo.xna", 0));
        this.achivrate = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Info\\achivrate.xna", 0));
        this.achivstatus = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Info\\achivstatus.xna", 0));
        this.achivtype = Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\Info\\achivtype.xna", 0));
        this.pstring = new List<string[]>();
        StreamReader streamReader1 = new StreamReader(Cry.Decry("Content\\Data\\6.xna", 2));
        int index1 = 0;
        string[] strArray1 = new string[4];
        while (!streamReader1.EndOfStream)
        {
          string source = streamReader1.ReadLine();
          if (source.Contains<char>(']'))
          {
            strArray1[index1] = source.Split(']')[0];
            index1 = 0;
            string[] strArray2 = new string[4];
            for (int index2 = 0; index2 < 4; ++index2)
              strArray2[index2] = strArray1[index2];
            this.pstring.Add(strArray2);
            strArray1 = new string[4];
          }
          else
          {
            strArray1[index1] = source;
            ++index1;
          }
        }
        streamReader1.Close();
        if (!File.Exists("Content\\Music\\00.xna"))
        {
          StreamWriter streamWriter = new StreamWriter("Content\\Music\\00.xna", false);
          streamWriter.WriteLine("Fantasy Danmaku Festival");
          streamWriter.WriteLine("0");
          streamWriter.Close();
          Cry.Encry("Content\\Music\\00.xna", 2);
          this.mlock = 0;
        }
        else
        {
          StreamReader streamReader2 = new StreamReader(Cry.Decry("Content\\Music\\00.xna", 2));
          streamReader2.ReadLine();
          int num = int.Parse(streamReader2.ReadLine());
          streamReader2.Close();
          this.mlock = num;
        }
        this.mlist = new bool[16];
        this.mlistx = new float[16];
        this.mlisty = new float[16];
        this.mlistfade = new float[16];
        for (int index2 = 0; index2 < 16; ++index2)
        {
          if (this.mlock >= index2)
            this.mlist[index2] = true;
          this.mlistx[index2] = 17f;
          this.mlisty[index2] = (float) (153 + index2 * 24);
        }
        this.mrcover = new Sprite(Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\UI\\mrcover.xna", 0)));
        this.bgmlist = new Sprite(Texture2D.FromFile(graphicsDevice, Cry.Decry("Content\\Graphics\\List\\bgmlist.xna", 0)));
        Music.BGM = Music.SB.GetCue("1");
        Music.BGM.Play();
        GC.Collect();
        if (!Main.SkiptoSCChanllenges)
          return;
        this.e1.Dispose();
        this.e2.Dispose();
        this.bless.Dispose();
        this.praticle.Delete();
        this.fade = 0.0f;
        switch (this.season)
        {
          case 1:
            this.praticle = new Praticle(false, true, new Rectangle(155, 5, 31, 25), new Vector4(0.0f, -50f, 640f, 40f), new Vector2(16f, 13f), 15, 0, 260, 1f, 0.01f, new Vector2(90f, 10f), 30f);
            this.praticle.scale = new Vector4(0.5f, 1f, 1f, 1f);
            this.praticle.rotation = new Vector4(0.0f, 360f, 120f, 270f);
            break;
          case 2:
            this.praticle = new Praticle(false, true, new Rectangle(71, 0, 34, 33), new Vector4(0.0f, -50f, 640f, 40f), new Vector2(16f, 16f), 10, 0, 260, 1f, 0.01f, new Vector2(90f, 10f), 30f);
            this.praticle.scale = new Vector4(0.5f, 1f, 1f, 1f);
            this.praticle.rotation = new Vector4(0.0f, 360f, 120f, 270f);
            break;
          case 3:
            this.praticle = new Praticle(false, true, new Rectangle(28, 0, 43, 31), new Vector4(0.0f, -50f, 640f, 40f), new Vector2(22f, 15f), 15, 0, 260, 1f, 0.01f, new Vector2(90f, 10f), 30f);
            this.praticle.scale = new Vector4(0.5f, 1f, 1f, 1f);
            this.praticle.rotation = new Vector4(0.0f, 360f, 120f, 270f);
            break;
          case 4:
            this.praticle = new Praticle(false, true, new Rectangle(110, 0, 41, 40), new Vector4(0.0f, -50f, 640f, 40f), new Vector2(20f, 20f), 10, 0, 260, 1f, 0.01f, new Vector2(90f, 10f), 30f);
            this.praticle.scale = new Vector4(0.5f, 1f, 1f, 1f);
            this.praticle.rotation = new Vector4(0.0f, 360f, 120f, 270f);
            break;
        }
        this.fade3 = 1f;
        this.fade4 = 0.5f;
        this.scale = 1f;
        this.scale2 = 0.6f;
        this.x1 = 240f;
        this.y1 = 420f;
        this.x2 = 320f;
        this.y2 = 70f;
        this.time2 = 1160;
        this.stage = "SPECIAL";
      }
      catch (Exception ex)
      {
        StreamWriter streamWriter = new StreamWriter("Error.txt");
        DateTime now = DateTime.Now;
        streamWriter.Write("[" + now.Hour.ToString("00") + ":" + now.Minute.ToString("00") + ":" + now.Second.ToString("00") + "]\n" + ex.ToString());
        streamWriter.Close();
        Main.Message(ex.ToString());
      }
    }

    public GraphicsDevice GetGD()
    {
      return this.gd;
    }

    public void PlaySound(string k)
    {
      this.sound.Play(k, false, 0.0f);
    }

    private PracticeData LoadPracticeData()
    {
      Stream serializationStream = Cry.Decry("Content\\Data\\5.xna", 2);
      PracticeData practiceData = (PracticeData) new BinaryFormatter().Deserialize(serializationStream);
      serializationStream.Close();
      return practiceData;
    }

    public unsafe void Update()
    {
      if (this.thread.ThreadState != ThreadState.Stopped)
      {
        ++this.time;
        if (this.time <= 20)
          this.fade += 0.05f;
        if (this.time > 30 & this.time <= 50)
          this.fade -= 0.05f;
        if (this.time == 50)
          this.time = 0;
      }
      else if (this.stage == "OP")
      {
        if ((double) this.fade > 0.0)
          this.fade -= 0.025f;
        if (this.time2 == 0)
          this.praticle.stop = true;
        if (this.time2 == 40)
          this.bless.Dispose();
        if (this.time2 > 40 & this.time2 < 990 && (Main.keyboardstat.GetPressedKeys().Length != 0 & Main.keyboardstat != Main.prekeyboard || PadState.GetPressedKeys() != JOYBUTTONS.None || Main.Only))
        {
          if (!Main.Only)
            this.PlaySound("ok");
          this.e1.Dispose();
          this.e2.Dispose();
          this.praticle.Delete();
          this.time2 = 1020;
        }
        if (this.time2 > 240 & this.time2 <= 280)
          this.fade2 += 0.025f;
        if (this.time2 > 500 & this.time2 <= 600)
          this.fade2 -= 0.01f;
        if (this.time2 == 620)
          this.e1.Dispose();
        if (this.time2 > 640 & this.time2 <= 680)
          this.fade2 += 0.025f;
        if (this.time2 > 900 & this.time2 <= 1000)
          this.fade2 -= 0.01f;
        if (this.time2 == 1020)
          this.e2.Dispose();
        if (this.time2 >= 1030 & this.time2 <= 1070)
          this.fade3 += 0.025f;
        if (this.time2 == 1020)
        {
          Program.game.achivmanager.Check(AchievementType.Normal, 0, (Hashtable) null);
          switch (this.season)
          {
            case 1:
              this.praticle = new Praticle(false, true, new Rectangle(155, 5, 31, 25), new Vector4(0.0f, -50f, 640f, 40f), new Vector2(16f, 13f), 15, 0, 260, 1f, 0.01f, new Vector2(90f, 10f), 30f);
              this.praticle.scale = new Vector4(0.5f, 1f, 1f, 1f);
              this.praticle.rotation = new Vector4(0.0f, 360f, 120f, 270f);
              break;
            case 2:
              this.praticle = new Praticle(false, true, new Rectangle(71, 0, 34, 33), new Vector4(0.0f, -50f, 640f, 40f), new Vector2(16f, 16f), 10, 0, 260, 1f, 0.01f, new Vector2(90f, 10f), 30f);
              this.praticle.scale = new Vector4(0.5f, 1f, 1f, 1f);
              this.praticle.rotation = new Vector4(0.0f, 360f, 120f, 270f);
              break;
            case 3:
              this.praticle = new Praticle(false, true, new Rectangle(28, 0, 43, 31), new Vector4(0.0f, -50f, 640f, 40f), new Vector2(22f, 15f), 15, 0, 260, 1f, 0.01f, new Vector2(90f, 10f), 30f);
              this.praticle.scale = new Vector4(0.5f, 1f, 1f, 1f);
              this.praticle.rotation = new Vector4(0.0f, 360f, 120f, 270f);
              break;
            case 4:
              this.praticle = new Praticle(false, true, new Rectangle(110, 0, 41, 40), new Vector4(0.0f, -50f, 640f, 40f), new Vector2(20f, 20f), 10, 0, 260, 1f, 0.01f, new Vector2(90f, 10f), 30f);
              this.praticle.scale = new Vector4(0.5f, 1f, 1f, 1f);
              this.praticle.rotation = new Vector4(0.0f, 360f, 120f, 270f);
              break;
          }
        }
        if (this.time2 > 1030 & this.time2 <= 1070)
          this.fade4 += 0.025f;
        if (this.time2 > 1030 & this.time2 < 1160)
          this.scale += (float) ((1.0 - (double) this.scale) / 15.0);
        if (this.time2 >= 1160)
        {
          Main.Only = true;
          if (this.time2 >= 1160 & this.time2 <= 1200)
            this.fade5 += 0.025f;
          if (this.time2 > 1220 & this.time2 <= 1260)
            this.fade5 -= 0.025f;
          if (this.time2 == 1260)
            this.time2 = 1160;
          if (Main.keyboardstat.GetPressedKeys().Length != 0 & Main.keyboardstat != Main.prekeyboard || PadState.GetPressedKeys() != JOYBUTTONS.None)
          {
            this.PlaySound("opause");
            this.press.Dispose();
            this.stage = "BEGIN";
          }
        }
        ++this.time2;
      }
      else if (this.stage == "BEGIN")
      {
        if (this.time3 == 1)
        {
          this.buttonx[7] = 114;
          this.buttony[7] = 408;
        }
        for (int index = 1; index < 8; ++index)
        {
          if (this.time3 > (index - 1) * 3 & this.time3 <= 10 + (index - 1) * 3)
          {
            this.buttonfade[index] += 0.1f;
            this.buttonx[index] += 3;
          }
          if (this.selection == index && this.selection < 5 || this.selection == index + 1 && this.selection >= 6)
          {
            if (this.time4 > 0 & this.time4 <= 3)
              ++this.buttonx[index];
            if (this.time4 > 3 & this.time4 <= 6)
              --this.buttonx[index];
          }
        }
        if (this.time3 > 12 && this.time3 <= 22)
          this.buttonspx += 3;
        if (this.selection == 5)
        {
          if (this.time4 > 0 & this.time4 <= 3)
            ++this.buttonspx;
          if (this.time4 > 3 & this.time4 <= 6)
            --this.buttonspx;
        }
        if (this.time3 >= 21)
        {
          if (((!this.Fadeout ? 1 : 0) & (Main.keyboardstat.IsKeyDown(Keys.Up) & Main.keyboardstat != Main.prekeyboard ? 1 : (PadState.IsKeyPressed(JOYKEYS.Up, Main.prepadstat) ? 1 : 0))) != 0)
          {
            this.PlaySound("select");
            --this.selection;
            if (this.selection == 0)
              this.selection = 8;
            this.time4 = 0;
          }
          else if (((!this.Fadeout ? 1 : 0) & (Main.keyboardstat.IsKeyDown(Keys.Down) & Main.keyboardstat != Main.prekeyboard ? 1 : (PadState.IsKeyPressed(JOYKEYS.Down, Main.prepadstat) ? 1 : 0))) != 0)
          {
            this.PlaySound("select");
            ++this.selection;
            if (this.selection == 9)
              this.selection = 1;
            this.time4 = 0;
          }
          else if (!this.Fadeout && (Main.keyboardstat.IsKeyDown(Keys.X) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Escape) & Main.keyboardstat != Main.prekeyboard || (PadState.IsKeyPressed(JOYKEYS.Special, Main.prepadstat) || PadState.IsKeyPressed(JOYKEYS.Pause, Main.prepadstat))))
          {
            this.PlaySound("select");
            this.selection = 8;
            this.time4 = 0;
          }
        }
        if (this.time3 >= 31 && !this.Fadeout && (Main.keyboardstat.IsKeyDown(Keys.Enter) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Z) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Confirm, Main.prepadstat)))
        {
          this.PlaySound("ok");
          this.Fadeout = true;
          this.time5 = 0;
        }
        if (this.Fadeout)
        {
          for (int index = 1; index < 8; ++index)
          {
            if (this.time5 > (index - 1) * 3 & this.time5 <= 10 + (index - 1) * 3)
            {
              this.buttonfade[index] -= 0.1f;
              this.buttonx[index] -= 3;
            }
          }
          if (this.time5 > 12 && this.time5 <= 22)
            this.buttonspx -= 3;
          if (this.time5 >= 31)
          {
            bool flag = false;
            switch (this.selection)
            {
              case 1:
                Main.Mode = Modes.SINGLE;
                Main.SpecialMode = Modes.SINGLE;
                Main.Replay = false;
                this.selection = (int) Main.Level;
                for (int index = 0; index < 4; ++index)
                {
                  if (this.practicedata.clear[index])
                  {
                    flag = true;
                    break;
                  }
                }
                if (!flag && this.selection == 5)
                  this.selection = 1;
                this.stage = "SINGLE";
                this.displaybox.position = new Vector2(38f, 198f);
                for (int index = 0; index < 5; ++index)
                  this.level[index].position = new Vector2((float) (29 + index * 100), 203f);
                break;
              case 2:
                Main.Mode = Modes.SINGLE;
                Main.SpecialMode = Modes.PRACTICE;
                Main.Replay = false;
                this.selection = (int) Main.Level;
                for (int index = 0; index < 4; ++index)
                {
                  if (this.practicedata.clear[index])
                  {
                    flag = true;
                    break;
                  }
                }
                if (!flag && this.selection == 5)
                  this.selection = 1;
                this.stage = "PRACTICE";
                this.displaybox.position = new Vector2(38f, 198f);
                for (int index = 0; index < 5; ++index)
                  this.level[index].position = new Vector2((float) (29 + index * 100), 203f);
                break;
              case 3:
                this.selection = 1;
                this.stage = "PLAY DATA";
                break;
              case 4:
                this.selection = 1;
                this.stage = "REPLAY";
                break;
              case 5:
                this.selection = 1;
                this.stage = "SPECIAL";
                break;
              case 6:
                this.selection = 1;
                this.pselection = 0;
                this.stage = "MUSIC ROOM";
                break;
              case 7:
                this.selection = 1;
                this.stage = "OPTION";
                break;
              case 8:
                this.selection = 1;
                Program.game.Exit();
                break;
            }
            this.Fadeout = false;
            this.time3 = 0;
          }
          ++this.time5;
        }
        this.scale2 += (float) ((0.600000023841858 - (double) this.scale2) / 8.0);
        this.x1 += (float) ((100.0 - (double) this.x1) / 11.0);
        this.y1 += (float) ((60.0 - (double) this.y1) / 11.0);
        this.x2 += (float) ((450.0 - (double) this.x2) / 11.0);
        this.y2 += (float) ((80.0 - (double) this.y2) / 11.0);
        ++this.time3;
        ++this.time4;
        if (this.time4 >= 7)
          this.time4 = 7;
      }
      else if (this.stage == "SINGLE")
      {
        if (this.time12 >= 0 & this.time12 <= 22)
        {
          this.fade4 -= 0.03f;
          if ((double) this.fade4 <= 0.5)
            this.fade4 = 0.5f;
          this.displaybox.position.X = (float) (((double) this.displaybox.position.X * 9.0 + 88.0) / 10.0);
          this.displaybox.color.a += 0.05f;
          if ((double) this.displaybox.color.a >= 1.0)
            this.displaybox.color.a = 1f;
          this.level[this.selection - 1].color.a += 0.05f;
          if ((double) this.level[this.selection - 1].color.a >= 1.0)
            this.level[this.selection - 1].color.a = 1f;
          for (int index = 0; index < 5; ++index)
          {
            if (this.time12 == 1)
            {
              fixed (float* v = &this.level[index].position.X)
              {
                ValueEvent valueEvent = new ValueEvent(v, (float) (80 - (this.selection - 1 - index) * 100), 10, ChangeType.NONLINEAR);
              }
            }
            if (index != this.selection - 1)
            {
              this.level[index].color.a -= 0.05f;
              if ((double) this.level[index].color.a <= 0.0)
                this.level[index].color.a = 0.0f;
            }
          }
          if (this.time12 == 1)
          {
            fixed (float* v = &this.crapwise.color.a)
            {
              ValueEvent valueEvent = new ValueEvent(v, 0.0f, 10, ChangeType.NONLINEAR);
            }
          }
          if (this.time12 == 11)
          {
            this.crapwisexy[0] = new Vector2(366f, 242f);
            this.crapwisexy[1] = new Vector2(52f, 242f);
            fixed (float* v = &this.crapwise.color.a)
            {
              ValueEvent valueEvent = new ValueEvent(v, 1f, 10, ChangeType.NONLINEAR);
            }
          }
          if (!this.steps)
          {
            for (int index = 0; index < 4; ++index)
            {
              this.character[index].color.a -= 0.05f;
              if ((double) this.character[index].color.a <= 0.0)
                this.character[index].color.a = 0.0f;
            }
          }
        }
        if (!this.Fadeout & !this.steps)
        {
          if (((!this.Fadeout ? 1 : 0) & (Main.keyboardstat.IsKeyDown(Keys.Left) & Main.keyboardstat != Main.prekeyboard ? 1 : (PadState.IsKeyPressed(JOYKEYS.Left, Main.prepadstat) ? 1 : 0))) != 0)
          {
            this.PlaySound("select");
            --this.selection;
            if (this.selection == 0)
            {
              this.selection = 4;
              for (int index = 0; index < 4; ++index)
              {
                if (this.practicedata.clear[index])
                {
                  this.selection = 5;
                  break;
                }
              }
            }
            for (int index = 0; index < 5; ++index)
            {
              fixed (float* v = &this.level[index].position.X)
              {
                ValueEvent valueEvent = new ValueEvent(v, (float) (80 - (this.selection - 1 - index) * 100), 10, ChangeType.NONLINEAR);
              }
            }
            this.time12 = 0;
          }
          else if (((!this.Fadeout ? 1 : 0) & (Main.keyboardstat.IsKeyDown(Keys.Right) & Main.keyboardstat != Main.prekeyboard ? 1 : (PadState.IsKeyPressed(JOYKEYS.Right, Main.prepadstat) ? 1 : 0))) != 0)
          {
            this.PlaySound("select");
            ++this.selection;
            bool flag = false;
            for (int index = 0; index < 4; ++index)
            {
              if (this.practicedata.clear[index])
              {
                flag = true;
                break;
              }
            }
            if (flag)
            {
              if (this.selection == 6)
                this.selection = 1;
            }
            else if (this.selection == 5)
              this.selection = 1;
            for (int index = 0; index < 5; ++index)
            {
              if (index != this.selection - 1)
              {
                this.level[index].color.a -= 0.05f;
                if ((double) this.level[index].color.a <= 0.0)
                  this.level[this.selection - 1].color.a = 0.0f;
              }
            }
            for (int index = 0; index < 5; ++index)
            {
              fixed (float* v = &this.level[index].position.X)
              {
                ValueEvent valueEvent = new ValueEvent(v, (float) (80 - (this.selection - 1 - index) * 100), 10, ChangeType.NONLINEAR);
              }
            }
            this.time12 = 0;
          }
          if (this.time12 >= 22)
          {
            if (Main.keyboardstat.IsKeyDown(Keys.Enter) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Z) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Confirm, Main.prepadstat))
            {
              this.PlaySound("ok");
              Main.Level = (Difficulty) this.selection;
              this.time14 = 0;
              this.steps = true;
            }
            else if (Main.keyboardstat.IsKeyDown(Keys.X) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Escape) & Main.keyboardstat != Main.prekeyboard || (PadState.IsKeyPressed(JOYKEYS.Special, Main.prepadstat) || PadState.IsKeyPressed(JOYKEYS.Pause, Main.prepadstat)))
            {
              for (int index = 0; index < 5; ++index)
              {
                fixed (float* v = &this.level[index].position.X)
                {
                  ValueEvent valueEvent = new ValueEvent(v, (float) (30 - (this.selection - 1 - index) * 100), 10, ChangeType.NONLINEAR);
                }
              }
              this.PlaySound("cancel");
              this.Fadeout = true;
              this.time13 = 0;
            }
          }
        }
        if (!this.steps)
        {
          if (this.time12 >= 22 & this.time12 <= 72)
          {
            this.displaybox.color.a -= 0.01f;
            if ((double) this.displaybox.color.a <= 0.0)
              this.displaybox.color.a = 0.0f;
          }
          if (this.time12 >= 72 & this.time12 <= 122)
          {
            this.displaybox.color.a += 0.01f;
            if ((double) this.displaybox.color.a >= 1.0)
              this.displaybox.color.a = 1f;
          }
          if (this.time12 >= 122)
            this.time12 = 42;
        }
        else
        {
          if (this.time14 > 0 & this.time14 <= 22)
          {
            this.displaybox.position.X = (float) (((double) this.displaybox.position.X * 4.0 + 88.0 - 50.0) / 5.0);
            this.displaybox.color.a -= 0.05f;
            if ((double) this.displaybox.color.a <= 0.0)
              this.displaybox.color.a = 0.0f;
            this.level[this.selection - 1].color.a -= 0.05f;
            if ((double) this.level[this.selection - 1].color.a <= 0.0)
              this.level[this.selection - 1].color.a = 0.0f;
            for (int index = 0; index < 5; ++index)
            {
              if (this.time14 == 1)
              {
                fixed (float* v = &this.level[index].position.X)
                {
                  ValueEvent valueEvent = new ValueEvent(v, (float) (30 - (this.selection - 1 - index) * 100), 10, ChangeType.NONLINEAR);
                }
              }
            }
            if (this.time14 == 1)
            {
              fixed (float* v = &this.crapwise.color.a)
              {
                ValueEvent valueEvent = new ValueEvent(v, 0.0f, 10, ChangeType.NONLINEAR);
              }
              fixed (float* v = &this.cinfo.color.a)
              {
                ValueEvent valueEvent = new ValueEvent(v, 1f, 10, ChangeType.NONLINEAR);
              }
              fixed (float* v = &this.cinfo.position.X)
              {
                ValueEvent valueEvent = new ValueEvent(v, 20f, 10, ChangeType.NONLINEAR);
              }
            }
            if (this.time14 == 11)
            {
              this.crapwisexy[0] = new Vector2(600f, 242f);
              this.crapwisexy[1] = new Vector2(22f, 242f);
              fixed (float* v = &this.crapwise.color.a)
              {
                ValueEvent valueEvent = new ValueEvent(v, 1f, 10, ChangeType.NONLINEAR);
              }
            }
          }
          if (this.time14 >= 23)
            this.time14 = 23;
          if (this.time14 >= 0 && !this.stepFadeout)
          {
            for (int index = 0; index < 4; ++index)
            {
              if (this.time14 == 0)
                this.character[index].position.X = 200f;
              if (index == this.selection2 - 1)
              {
                this.character[index].color.a += 0.05f;
                if ((double) this.character[index].color.a >= 1.0)
                  this.character[index].color.a = 1f;
                this.character[index].position.X += (float) ((0.0 - (double) this.character[index].position.X) / 10.0);
              }
              else
              {
                this.character[index].color.a -= 0.05f;
                if ((double) this.character[index].color.a <= 0.0)
                  this.character[index].color.a = 0.0f;
                this.character[index].position.X += (float) ((200.0 - (double) this.character[index].position.X) / 10.0);
              }
            }
          }
          if (this.time14 >= 22 && !this.stepFadeout)
          {
            if (((!this.Fadeout ? 1 : 0) & (Main.keyboardstat.IsKeyDown(Keys.Left) & Main.keyboardstat != Main.prekeyboard ? 1 : (PadState.IsKeyPressed(JOYKEYS.Left, Main.prepadstat) ? 1 : 0))) != 0)
            {
              this.PlaySound("select");
              --this.selection2;
              if (this.selection2 == 0)
                this.selection2 = 4;
            }
            else if (((!this.Fadeout ? 1 : 0) & (Main.keyboardstat.IsKeyDown(Keys.Right) & Main.keyboardstat != Main.prekeyboard ? 1 : (PadState.IsKeyPressed(JOYKEYS.Right, Main.prepadstat) ? 1 : 0))) != 0)
            {
              this.PlaySound("select");
              ++this.selection2;
              if (this.selection2 == 5)
                this.selection2 = 1;
            }
            if (Main.keyboardstat.IsKeyDown(Keys.X) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Escape) & Main.keyboardstat != Main.prekeyboard || (PadState.IsKeyPressed(JOYKEYS.Special, Main.prepadstat) || PadState.IsKeyPressed(JOYKEYS.Pause, Main.prepadstat)))
            {
              for (int index = 0; index < 5; ++index)
              {
                fixed (float* v = &this.level[index].position.X)
                {
                  ValueEvent valueEvent = new ValueEvent(v, (float) (80 - (this.selection - 1 - index) * 100), 10, ChangeType.NONLINEAR);
                }
              }
              fixed (float* v = &this.cinfo.color.a)
              {
                ValueEvent valueEvent = new ValueEvent(v, 0.0f, 10, ChangeType.NONLINEAR);
              }
              fixed (float* v = &this.cinfo.position.X)
              {
                ValueEvent valueEvent = new ValueEvent(v, 100f, 10, ChangeType.NONLINEAR);
              }
              this.PlaySound("cancel");
              this.steps = false;
              this.time12 = 0;
              this.time14 = 0;
              Main.keyboardstat = Main.prekeyboard;
            }
            else if (Main.keyboardstat.IsKeyDown(Keys.Enter) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Z) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Confirm, Main.prepadstat))
            {
              if (this.selection == 5 && this.practicedata.clear[this.selection2 - 1] || this.selection != 5)
              {
                this.PlaySound("ok");
                Main.Character = (Cname) this.selection2;
                this.stepFadeout = true;
                this.time15 = 0;
              }
              else
                this.PlaySound("invalid");
            }
          }
          if (this.stepFadeout)
          {
            if (this.time15 <= 22)
            {
              for (int index = 0; index < 4; ++index)
              {
                this.character[index].color.a -= 0.05f;
                if ((double) this.character[index].color.a <= 0.0)
                  this.character[index].color.a = 0.0f;
              }
              this.crapwise.color.a -= 0.05f;
              if ((double) this.crapwise.color.a <= 0.0)
                this.crapwise.color.a = 0.0f;
              this.cinfo.color.a -= 0.05f;
              if ((double) this.cinfo.color.a <= 0.0)
                this.cinfo.color.a = 0.0f;
              this.fade4 -= 0.06f;
              this.fade3 -= 0.05f;
              for (int index = 0; index < this.praticle.Mine.Count; ++index)
                this.praticle.Mine[index].alpha -= 0.05f;
              Music.BGMvolume -= 5;
            }
            if (this.time15 >= 22)
            {
              Main.stage = "GAME";
              this.selection = 1;
              this.selection2 = 1;
              this.stepFadeout = false;
              this.time15 = 0;
              this.Finished = true;
            }
            ++this.time15;
          }
        }
        if (this.Fadeout)
        {
          if (this.time13 >= 0 & this.time13 <= 22)
          {
            this.fade4 += 0.03f;
            if ((double) this.fade4 >= 1.0)
              this.fade4 = 1f;
            this.displaybox.position.X -= 2.272727f;
            this.displaybox.color.a -= 0.05f;
            if ((double) this.displaybox.color.a <= 0.0)
              this.displaybox.color.a = 0.0f;
            this.level[this.selection - 1].color.a -= 0.05f;
            if ((double) this.level[this.selection - 1].color.a <= 0.0)
              this.level[this.selection - 1].color.a = 0.0f;
            this.crapwise.color.a -= 0.05f;
            if ((double) this.crapwise.color.a <= 0.0)
              this.crapwise.color.a = 0.0f;
          }
          if (this.time13 >= 22)
          {
            this.stage = "BEGIN";
            this.selection = 1;
            this.Fadeout = false;
            this.time12 = 0;
          }
          ++this.time13;
        }
        this.x1 += (float) ((550.0 - (double) this.x1) / 11.0);
        this.y1 += (float) ((360.0 - (double) this.y1) / 11.0);
        this.x2 += (float) ((200.0 - (double) this.x2) / 11.0);
        this.y2 += (float) ((80.0 - (double) this.y2) / 11.0);
        ++this.time12;
        if (this.steps)
          ++this.time14;
      }
      else if (this.stage == "PRACTICE")
      {
        if (this.time16 >= 0 & this.time16 <= 22)
        {
          this.fade4 -= 0.03f;
          if ((double) this.fade4 <= 0.5)
            this.fade4 = 0.5f;
        }
        if (this.time16 == 0)
          this.PRACTICE = new PRACTICE(this.practicedata, this.blackbox, this.displaybox, this.level, this.crapwise, this.character, this.cinfo, this.crapwisexy, this.selection, this.selection2);
        else if (this.time16 > 1)
          this.PRACTICE.Update();
        ++this.time16;
        if (this.PRACTICE.Ok)
        {
          if (this.time17 == 0)
          {
            this.selection = this.PRACTICE.Selection;
            this.selection2 = this.PRACTICE.Selection2;
          }
          if (this.time17 <= 22)
          {
            this.character[this.selection2 - 1].color.a -= 0.07f;
            if ((double) this.character[this.selection2 - 1].color.a <= 0.0)
              this.character[this.selection2 - 1].color.a = 0.0f;
            this.crapwise.color.a -= 0.05f;
            if ((double) this.crapwise.color.a <= 0.0)
              this.crapwise.color.a = 0.0f;
            this.cinfo.color.a -= 0.05f;
            if ((double) this.cinfo.color.a <= 0.0)
              this.cinfo.color.a = 0.0f;
            this.fade4 -= 0.06f;
            this.fade3 -= 0.05f;
            for (int index = 0; index < this.praticle.Mine.Count; ++index)
              this.praticle.Mine[index].alpha -= 0.05f;
            Music.BGMvolume -= 5;
          }
          if (this.time17 >= 22)
          {
            Main.stage = "PRACTICE " + this.PRACTICE.Selection3.ToString();
            this.Finished = true;
          }
          ++this.time17;
        }
        if (this.PRACTICE.Fadeout)
        {
          if (this.time17 == 0)
          {
            this.selection = this.PRACTICE.Selection;
            this.selection2 = this.PRACTICE.Selection2;
          }
          if (this.time17 <= 22)
          {
            this.fade4 += 0.03f;
            if ((double) this.fade4 >= 1.0)
              this.fade4 = 1f;
            this.displaybox.position.X -= 2.272727f;
            this.displaybox.color.a -= 0.05f;
            if ((double) this.displaybox.color.a <= 0.0)
              this.displaybox.color.a = 0.0f;
            this.level[this.selection - 1].color.a -= 0.05f;
            if ((double) this.level[this.selection - 1].color.a <= 0.0)
              this.level[this.selection - 1].color.a = 0.0f;
            this.crapwise.color.a -= 0.05f;
            if ((double) this.crapwise.color.a <= 0.0)
              this.crapwise.color.a = 0.0f;
          }
          ++this.time17;
          if (this.time17 > 22)
          {
            this.stage = "BEGIN";
            this.selection = 2;
            this.Fadeout = false;
            this.PRACTICE = (PRACTICE) null;
            this.time17 = 0;
            this.time16 = 0;
          }
        }
        this.x1 += (float) ((550.0 - (double) this.x1) / 11.0);
        this.y1 += (float) ((360.0 - (double) this.y1) / 11.0);
        this.x2 += (float) ((200.0 - (double) this.x2) / 11.0);
        this.y2 += (float) ((80.0 - (double) this.y2) / 11.0);
      }
      else if (this.stage == "PLAY DATA")
      {
        if (this.time20 >= 0 & this.time20 <= 22)
        {
          this.fade4 -= 0.03f;
          if ((double) this.fade4 <= 0.5)
            this.fade4 = 0.5f;
        }
        if (this.time20 == 0)
          this.PLAYDATA = new PLAYDATA(this.blackbox, this.crapwise, this.playdata, this.playerdata, this.leveldata);
        else if (this.time20 > 1)
          this.PLAYDATA.Update();
        ++this.time20;
        if (this.PLAYDATA.Fadeout)
        {
          ++this.time21;
          if (this.time21 <= 22)
          {
            this.fade4 += 0.03f;
            if ((double) this.fade4 >= 1.0)
              this.fade4 = 1f;
          }
          if (this.time21 > 22)
          {
            this.crapwise.rotation = 0.0f;
            this.crapwise.origin = Vector2.Zero;
            this.crapwise.scale = new Vector2(1f, 1f);
            this.stage = "BEGIN";
            this.selection = 3;
            this.Fadeout = false;
            this.PLAYDATA = (PLAYDATA) null;
            this.time21 = 0;
            this.time20 = 0;
          }
        }
        this.x1 += (float) ((240.0 - (double) this.x1) / 11.0);
        this.y1 += (float) ((420.0 - (double) this.y1) / 11.0);
        this.x2 += (float) ((320.0 - (double) this.x2) / 11.0);
        this.y2 += (float) ((70.0 - (double) this.y2) / 11.0);
      }
      else if (this.stage == "REPLAY")
      {
        if (this.time18 >= 0 & this.time18 <= 22)
        {
          this.fade4 -= 0.03f;
          if ((double) this.fade4 <= 0.5)
            this.fade4 = 0.5f;
        }
        if (this.time18 == 0)
          this.REPLAY = new REPLAY(this.blackbox);
        else if (this.time18 > 1)
          this.REPLAY.Update();
        ++this.time18;
        if (this.REPLAY.Ok)
        {
          ++this.time19;
          if (this.time19 <= 20)
          {
            this.fade4 -= 0.05f;
            this.fade3 -= 0.05f;
            for (int index = 0; index < this.praticle.Mine.Count; ++index)
              this.praticle.Mine[index].alpha -= 0.05f;
            Music.BGMvolume -= 5;
          }
          else
          {
            if (!this.REPLAY.Spellcard)
              Main.stage = "PRACTICE " + this.REPLAY.Selection2.ToString();
            else
              Main.stage = "GAME " + (object) this.REPLAY.BossStage + " " + (object) this.REPLAY.BarrageId;
            Main.Replay = true;
            this.Finished = true;
          }
        }
        if (this.REPLAY.Fadeout)
        {
          ++this.time19;
          if (this.time19 <= 22)
          {
            this.fade4 += 0.03f;
            if ((double) this.fade4 >= 1.0)
              this.fade4 = 1f;
          }
          if (this.time19 > 22)
          {
            this.stage = "BEGIN";
            this.selection = 4;
            this.Fadeout = false;
            this.REPLAY = (REPLAY) null;
            this.time19 = 0;
            this.time18 = 0;
          }
        }
        this.x1 += (float) ((240.0 - (double) this.x1) / 11.0);
        this.y1 += (float) ((420.0 - (double) this.y1) / 11.0);
        this.x2 += (float) ((320.0 - (double) this.x2) / 11.0);
        this.y2 += (float) ((70.0 - (double) this.y2) / 11.0);
      }
      else if (this.stage == "SPECIAL")
      {
        if (this.time25 == 0)
        {
          this.SPECIAL = new SPECIAL(this.practicedata, this.character, this.blackbox, new Texture2D[8]
          {
            this.button[14],
            this.button[15],
            this.button[16],
            this.button[7],
            this.buttonon[14],
            this.buttonon[15],
            this.buttonon[16],
            this.buttonon[7]
          });
          this.SPECIAL.Texture(this.gd, this.achivbox, this.achivboxon, this.achivlogo, this.achivrate, this.achivstatus, this.achivtype, this.crapwise.Texture);
        }
        else if (this.time25 > 1)
          this.SPECIAL.Update();
        ++this.time25;
        if (this.SPECIAL.Step)
        {
          if (this.time27 >= 0 & this.time27 <= 22)
          {
            this.fade4 -= 0.03f;
            if ((double) this.fade4 <= 0.5)
              this.fade4 = 0.5f;
          }
          this.x1 += (float) ((240.0 - (double) this.x1) / 11.0);
          this.y1 += (float) ((420.0 - (double) this.y1) / 11.0);
          this.x2 += (float) ((320.0 - (double) this.x2) / 11.0);
          this.y2 += (float) ((70.0 - (double) this.y2) / 11.0);
          ++this.time27;
        }
        else
        {
          if (this.time27 > 0)
          {
            this.fade4 += 0.03f;
            if ((double) this.fade4 >= 1.0)
            {
              this.fade4 = 1f;
              this.time27 = 0;
            }
          }
          this.x1 += (float) ((100.0 - (double) this.x1) / 11.0);
          this.y1 += (float) ((60.0 - (double) this.y1) / 11.0);
          this.x2 += (float) ((450.0 - (double) this.x2) / 11.0);
          this.y2 += (float) ((80.0 - (double) this.y2) / 11.0);
        }
        if (this.SPECIAL.Finished)
        {
          switch (this.SPECIAL.Selection)
          {
            case 0:
              ++this.time26;
              if (this.time26 > 20)
              {
                this.praticle.Delete();
                Main.stage = "ED 4";
                Music.BGMvolume = int.Parse(Main.ini.ReadValue("Sound", "BGM"));
                this.Finished = true;
              }
              for (int index = 0; index < this.praticle.Mine.Count; ++index)
                this.praticle.Mine[index].alpha -= 0.05f;
              Music.BGMvolume -= 5;
              break;
            case 2:
              ++this.time26;
              if (this.time26 > 20)
              {
                this.praticle.Delete();
                Main.Mode = Modes.SINGLE;
                Main.SpecialMode = Modes.SPELLCARD;
                Main.Replay = false;
                Main.stage = "GAME " + this.SPECIAL.Scselection;
                Music.BGMvolume = int.Parse(Main.ini.ReadValue("Sound", "BGM"));
                this.Finished = true;
              }
              for (int index = 0; index < this.praticle.Mine.Count; ++index)
                this.praticle.Mine[index].alpha -= 0.05f;
              Music.BGMvolume -= 5;
              break;
            case 3:
              this.stage = "BEGIN";
              this.selection = 5;
              this.Fadeout = false;
              this.SPECIAL = (SPECIAL) null;
              this.time25 = 0;
              this.time27 = 0;
              break;
          }
        }
      }
      else if (this.stage == "MUSIC ROOM")
      {
        for (int index = 1; index <= 16; ++index)
        {
          if (this.time9 >= (index - 1) * 3 & this.time9 <= 10 + (index - 1) * 3)
          {
            if (index < 8)
              this.mlistfade[index - 1] += 0.1f;
            this.mlistx[index - 1] += 3f;
          }
        }
        if (this.time9 > 0 && this.time9 <= 20)
          this.mrcover.color.a += 0.05f;
        if (this.time9 >= 0 && this.time9 <= 22)
        {
          this.fade4 -= 0.03f;
          if ((double) this.fade4 <= 0.5)
            this.fade4 = 0.5f;
        }
        if (!this.Fadeout)
        {
          if (this.time9 == 0)
          {
            this.pfade = 0.0f;
          }
          else
          {
            this.pfade += 0.05f;
            if ((double) this.pfade >= 1.0)
              this.pfade = 1f;
          }
        }
        if (!this.Fadeout)
        {
          if (this.time9 % 60 == 0)
            Program.game.achivmanager.Check(AchievementType.Hidden, 6, (Hashtable) null);
          if (this.time9 >= 28)
          {
            for (int index = 0; index < 16; ++index)
            {
              if (index == this.selection - 1)
                this.mlistx[index] += (float) ((35.0 - (double) this.mlistx[index]) / 4.0);
              else
                this.mlistx[index] += (float) ((47.0 - (double) this.mlistx[index]) / 4.0);
              if (this.selection > 8)
                this.mlisty[index] += (float) (((double) (153 + (index - this.selection + 8) * 24) - (double) this.mlisty[index]) / 4.0);
              else
                this.mlisty[index] += (float) (((double) (153 + index * 24) - (double) this.mlisty[index]) / 4.0);
              if ((double) this.mlisty[index] >= 133.0 && (double) this.mlisty[index] <= 336.0)
              {
                this.mlistfade[index] += 0.1f;
                if ((double) this.mlistfade[index] >= 1.0)
                  this.mlistfade[index] = 1f;
              }
              else
              {
                this.mlistfade[index] -= 0.1f;
                if ((double) this.mlistfade[index] <= 0.0)
                  this.mlistfade[index] = 0.0f;
              }
            }
            if ((Main.keyboardstat.IsKeyDown(Keys.Enter) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Z) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Confirm, Main.prepadstat)) && this.mlist[this.selection - 1])
            {
              Music.BGM.Dispose();
              Music.BGM = Music.SB.GetCue(this.selection.ToString());
              Music.BGM.Play();
              this.pselection = this.selection;
              this.pfade = 0.0f;
            }
            if (Main.keyboardstat.IsKeyDown(Keys.X) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Escape) & Main.keyboardstat != Main.prekeyboard || (PadState.IsKeyPressed(JOYKEYS.Special, Main.prepadstat) || PadState.IsKeyPressed(JOYKEYS.Pause, Main.prepadstat)))
            {
              this.PlaySound("cancel");
              this.Fadeout = true;
              this.time11 = 0;
            }
            if (Main.keyboardstat.IsKeyDown(Keys.Up) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Up, Main.prepadstat))
            {
              this.PlaySound("select");
              --this.selection;
              if (this.selection == 0)
                this.selection = 16;
            }
            if (Main.keyboardstat.IsKeyDown(Keys.Down) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Down, Main.prepadstat))
            {
              this.PlaySound("select");
              ++this.selection;
              if (this.selection == 17)
                this.selection = 1;
            }
          }
        }
        if (this.Fadeout)
        {
          this.pfade -= 0.05f;
          if ((double) this.pfade <= 0.0)
            this.pfade = 0.0f;
          if (this.time11 == 1)
          {
            Music.BGM.Dispose();
            Music.BGM = Music.SB.GetCue("1");
            Music.BGM.Play();
          }
          for (int index = 1; index <= 16; ++index)
          {
            if (this.time11 >= (index - 1) * 3 & this.time11 <= 10 + (index - 1) * 3)
            {
              this.mlistfade[index - 1] -= 0.1f;
              if ((double) this.mlistfade[index - 1] <= 0.0)
                this.mlistfade[index - 1] = 0.0f;
              this.mlistx[index - 1] -= 3f;
            }
          }
          if (this.time11 > 30 && this.time11 <= 50)
            this.mrcover.color.a -= 0.05f;
          if (this.time11 >= 30 && this.time11 <= 52)
          {
            this.fade4 += 0.03f;
            if ((double) this.fade4 >= 1.0)
              this.fade4 = 1f;
          }
          if (this.time11 >= 55)
          {
            this.stage = "BEGIN";
            this.selection = 6;
            this.Fadeout = false;
            for (int index = 0; index < 16; ++index)
            {
              this.mlistx[index] = 17f;
              this.mlisty[index] = (float) (153 + index * 24);
            }
            this.time9 = 0;
          }
          ++this.time11;
        }
        this.y1 += (float) ((360.0 - (double) this.y1) / 11.0);
        this.x2 += (float) ((200.0 - (double) this.x2) / 11.0);
        this.y2 += (float) ((80.0 - (double) this.y2) / 11.0);
        ++this.time9;
      }
      else if (this.stage == "OPTION")
      {
        if (this.time6 == 1)
        {
          this.buttonx[7] = 70;
          this.buttony[7] = 416;
        }
        if (this.time6 > 39 & this.time6 <= 49)
        {
          this.buttonfade[7] += 0.1f;
          this.buttonx[7] += 3;
        }
        if (this.time6 > 30 & this.time6 <= 40)
        {
          this.buttonfade[13] += 0.1f;
          this.buttonx[13] += 3;
        }
        if (this.selection == 3)
        {
          if (this.time7 > 0 & this.time7 <= 3)
            ++this.buttonx[13];
          if (this.time7 > 3 & this.time7 <= 6)
            --this.buttonx[13];
        }
        else if (this.selection == 6)
        {
          if (this.time7 > 0 & this.time7 <= 3)
            ++this.buttonx[7];
          if (this.time7 > 3 & this.time7 <= 6)
            --this.buttonx[7];
        }
        for (int index = 9; index < 13; ++index)
        {
          if (this.time6 > index * 3 & this.time6 <= 10 + index * 3)
          {
            this.buttonfade[index] += 0.1f;
            this.buttonx[index] += 3;
          }
          if (this.selection == index - 8 && index < 11)
          {
            if (this.time7 > 0 & this.time7 <= 3)
              ++this.buttonx[index];
            if (this.time7 > 3 & this.time7 <= 6)
              --this.buttonx[index];
          }
          else if (this.selection == index - 8 && index > 11 && index < 13)
          {
            if (this.time7 > 0 & this.time7 <= 3)
              ++this.buttonx[index - 1];
            if (this.time7 > 3 & this.time7 <= 6)
              --this.buttonx[index - 1];
          }
        }
        if (this.time6 >= 31 && !this.Fadeout && !this.steps)
        {
          if (Main.keyboardstat.IsKeyDown(Keys.Up) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Up, Main.prepadstat))
          {
            this.PlaySound("select");
            --this.selection;
            if (this.selection == 0)
              this.selection = 6;
            this.time7 = 0;
          }
          else if (Main.keyboardstat.IsKeyDown(Keys.Down) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Down, Main.prepadstat))
          {
            this.PlaySound("select");
            ++this.selection;
            if (this.selection == 7)
              this.selection = 1;
            this.time7 = 0;
          }
          else if (Main.keyboardstat.IsKeyDown(Keys.Left) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Left, Main.prepadstat))
          {
            this.PlaySound("ok");
                        if(this.selection==1)
                            Music.BGMvolume=(int)MathHelper.Clamp((float)(Music.BGMvolume-10),0.0f,100f);
                        else if(this.selection==2)
                            Sound.SEvolume=(int)MathHelper.Clamp((float)(Sound.SEvolume-10),0.0f,100f);
                        else if(this.selection!=3) { }
          }
          else if (Main.keyboardstat.IsKeyDown(Keys.Right) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Right, Main.prepadstat))
          {
            this.PlaySound("ok");
                        if(this.selection==1)
                            Music.BGMvolume=(int)MathHelper.Clamp((float)(Music.BGMvolume+10),0.0f,100f);
                        else if(this.selection==2)
                            Sound.SEvolume=(int)MathHelper.Clamp((float)(Sound.SEvolume+10),0.0f,100f);
                        else if(this.selection!=3) { }
          }
          else if (Main.keyboardstat.IsKeyDown(Keys.Enter) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Z) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Confirm, Main.prepadstat))
          {
            this.PlaySound("ok");
            switch (this.selection)
            {
              case 3:
                this.steps = true;
                break;
              case 4:
                Main.Fullorwindow = Main.Fullorwindow != 0 ? 0 : 1;
                Main.Changescreen();
                break;
              case 5:
                Music.BGMvolume = 70;
                Sound.SEvolume = 70;
                break;
              case 6:
                this.Fadeout = true;
                this.time8 = 0;
                break;
            }
          }
          else if (Main.keyboardstat.IsKeyDown(Keys.X) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Escape) & Main.keyboardstat != Main.prekeyboard || (PadState.IsKeyPressed(JOYKEYS.Special, Main.prepadstat) || PadState.IsKeyPressed(JOYKEYS.Pause, Main.prepadstat)))
          {
            this.PlaySound("select");
            this.selection = 6;
            this.time8 = 0;
          }
        }
        if (this.Fadeout)
        {
          if (this.time8 > 6 & this.time8 <= 16)
          {
            this.buttonfade[13] -= 0.1f;
            this.buttonx[13] -= 3;
          }
          if (this.time8 > 12 & this.time8 <= 22)
          {
            this.buttonfade[7] -= 0.1f;
            this.buttonx[7] -= 3;
          }
          for (int index = 9; index < 13; ++index)
          {
            if (this.time8 > (index - 9) * 3 & this.time8 <= 10 + (index - 9) * 3)
            {
              this.buttonfade[index] -= 0.1f;
              this.buttonx[index] -= 3;
            }
          }
          if (this.time8 >= 22)
          {
            this.stage = "BEGIN";
            this.selection = 7;
            this.Fadeout = false;
            this.time6 = 0;
            Main.ini.WriteValue("Sound", "BGM", Music.BGMvolume);
            Main.ini.WriteValue("Sound", "SE", Sound.SEvolume);
            Main.ini.WriteValue("Mode", "Full/Window", Main.Fullorwindow);
          }
          ++this.time8;
        }
        if (this.steps)
        {
          if (this.time22 > 6 & this.time22 <= 16)
          {
            this.buttonfade[13] -= 0.1f;
            this.buttonx[13] -= 3;
          }
          if (this.time22 > 12 & this.time22 <= 22)
          {
            this.buttonfade[7] -= 0.1f;
            this.buttonx[7] -= 3;
          }
          for (int index = 9; index < 13; ++index)
          {
            if (this.time22 > (index - 9) * 3 & this.time22 <= 10 + (index - 9) * 3)
            {
              this.buttonfade[index] -= 0.1f;
              this.buttonx[index] -= 3;
            }
          }
          if (this.time22 == 2)
          {
            this.selection2 = 1;
            this.time24 = 7;
            for (int index = 0; index < 5; ++index)
            {
              this.keybutton[index].color.a = 0.0f;
              this.keybuttonon[index].color.a = 0.0f;
              this.keybutton[index].position.X = (float) (84 + 15 * index);
              this.keybuttonon[index].position.X = (float) (84 + 15 * index);
              this.keybutton[index].position.Y = (float) (280 + 30 * index);
              this.keybuttonon[index].position.Y = (float) (280 + 30 * index);
            }
          }
          for (int index = 0; index < 5; ++index)
          {
            if (this.time22 > 2 + index * 3 && this.time22 <= 12 + index * 3)
            {
              this.keybutton[index].color.a += 0.1f;
              if (index == 0)
                this.keybuttonon[index].color.a += 0.1f;
              this.keybutton[index].position.X -= 3f;
              this.keybuttonon[index].position.X -= 3f;
            }
          }
          if (this.time24 > 0 & this.time24 <= 3)
          {
            ++this.keybutton[this.selection2 - 1].position.X;
            if (this.selection2 == 5)
              ++this.keybuttonon[this.selection2 - 1].position.X;
          }
          if (this.time24 > 3 & this.time24 <= 6)
          {
            --this.keybutton[this.selection2 - 1].position.X;
            if (this.selection2 == 5)
              --this.keybuttonon[this.selection2 - 1].position.X;
          }
          if (this.time22 > 24 && !this.stepFadeout)
          {
            if (Main.keyboardstat.IsKeyDown(Keys.Up) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Up, Main.prepadstat))
            {
              this.PlaySound("select");
              --this.selection2;
              if (this.selection2 == 0)
                this.selection2 = 5;
              for (int index = 0; index < 5; ++index)
                this.keybuttonon[index].color.a = index + 1 != this.selection2 ? 0.0f : 1f;
              this.time24 = 0;
            }
            else if (Main.keyboardstat.IsKeyDown(Keys.Down) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Down, Main.prepadstat))
            {
              this.PlaySound("select");
              ++this.selection2;
              if (this.selection2 == 6)
                this.selection2 = 1;
              for (int index = 0; index < 5; ++index)
                this.keybuttonon[index].color.a = index + 1 != this.selection2 ? 0.0f : 1f;
              this.time24 = 0;
            }
            else if ((Main.keyboardstat.IsKeyDown(Keys.Enter) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Z) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Confirm, Main.prepadstat)) && this.selection2 == 5)
            {
              this.PlaySound("ok");
              this.stepFadeout = true;
              this.time23 = 0;
            }
            JOYBUTTONS pressedKeys = PadState.GetPressedKeys();
            if (this.selection2 != 5 && pressedKeys != JOYBUTTONS.None && pressedKeys != Main.prepadstat)
            {
              int num = 1;
              bool flag = false;
              for (int index = 0; index < PadState.JOY_BUTTON.Length; ++index)
              {
                if ((pressedKeys & PadState.JOY_BUTTON[index]) == PadState.JOY_BUTTON[index])
                {
                  num = index + 1;
                  flag = true;
                  break;
                }
              }
              if (flag)
              {
                this.PlaySound("ok");
                switch (this.selection2)
                {
                  case 1:
                    foreach (JOYKEYS key in PadState.setf.Keys)
                    {
                      if (key != JOYKEYS.Confirm && PadState.setf[key] == num)
                      {
                        PadState.setf[key] = PadState.setf[JOYKEYS.Confirm];
                        break;
                      }
                    }
                    PadState.setf[JOYKEYS.Confirm] = num;
                    break;
                  case 2:
                    foreach (JOYKEYS key in PadState.setf.Keys)
                    {
                      if (key != JOYKEYS.Special && PadState.setf[key] == num)
                      {
                        PadState.setf[key] = PadState.setf[JOYKEYS.Special];
                        break;
                      }
                    }
                    PadState.setf[JOYKEYS.Special] = num;
                    break;
                  case 3:
                    foreach (JOYKEYS key in PadState.setf.Keys)
                    {
                      if (key != JOYKEYS.Slow && PadState.setf[key] == num)
                      {
                        PadState.setf[key] = PadState.setf[JOYKEYS.Slow];
                        break;
                      }
                    }
                    PadState.setf[JOYKEYS.Slow] = num;
                    break;
                  case 4:
                    foreach (JOYKEYS key in PadState.setf.Keys)
                    {
                      if (key != JOYKEYS.Pause && PadState.setf[key] == num)
                      {
                        PadState.setf[key] = PadState.setf[JOYKEYS.Pause];
                        break;
                      }
                    }
                    PadState.setf[JOYKEYS.Pause] = num;
                    break;
                }
              }
            }
          }
          if (this.stepFadeout)
          {
            for (int index = 0; index < 5; ++index)
            {
              if (this.time23 > index * 3 && this.time23 <= 10 + index * 3)
              {
                this.keybutton[index].color.a -= 0.1f;
                if ((double) this.keybutton[index].color.a <= 0.0)
                  this.keybutton[index].color.a = 0.0f;
                this.keybuttonon[index].color.a -= 0.1f;
                if ((double) this.keybuttonon[index].color.a <= 0.0)
                  this.keybuttonon[index].color.a = 0.0f;
                this.keybutton[index].position.X += 3f;
                this.keybuttonon[index].position.X += 3f;
              }
            }
            if (this.time23 > 8 & this.time23 <= 18)
            {
              this.buttonfade[13] += 0.1f;
              this.buttonx[13] += 3;
            }
            if (this.time23 > 14 & this.time23 <= 24)
            {
              this.buttonfade[7] += 0.1f;
              this.buttonx[7] += 3;
            }
            for (int index = 9; index < 13; ++index)
            {
              if (this.time23 > 2 + (index - 9) * 3 & this.time23 <= 12 + (index - 9) * 3)
              {
                this.buttonfade[index] += 0.1f;
                this.buttonx[index] += 3;
              }
            }
            if (this.time23 >= 30)
            {
              this.steps = false;
              this.stepFadeout = false;
              this.selection2 = 1;
              this.time22 = 0;
              PadState.set[JOYKEYS.Confirm] = PadState.JOY_BUTTON[PadState.setf[JOYKEYS.Confirm] - 1];
              Main.ini.WriteValue("Input", "Confirm", PadState.setf[JOYKEYS.Confirm]);
              PadState.set[JOYKEYS.Special] = PadState.JOY_BUTTON[PadState.setf[JOYKEYS.Special] - 1];
              Main.ini.WriteValue("Input", "Special", PadState.setf[JOYKEYS.Special]);
              PadState.set[JOYKEYS.Slow] = PadState.JOY_BUTTON[PadState.setf[JOYKEYS.Slow] - 1];
              Main.ini.WriteValue("Input", "Slow", PadState.setf[JOYKEYS.Slow]);
              PadState.set[JOYKEYS.Pause] = PadState.JOY_BUTTON[PadState.setf[JOYKEYS.Pause] - 1];
              Main.ini.WriteValue("Input", "Pause", PadState.setf[JOYKEYS.Pause]);
            }
            ++this.time23;
          }
          ++this.time22;
          ++this.time24;
          if (this.time24 >= 7)
            this.time24 = 7;
        }
        this.x1 += (float) ((250.0 - (double) this.x1) / 11.0);
        this.y1 += (float) ((360.0 - (double) this.y1) / 11.0);
        this.x2 += (float) ((200.0 - (double) this.x2) / 11.0);
        this.y2 += (float) ((80.0 - (double) this.y2) / 11.0);
        ++this.time6;
        ++this.time7;
        if (this.time7 >= 7)
          this.time7 = 7;
      }
      PraticleManager.Update();
    }

    public void Draw(SpriteBatch s)
    {
      if (this.time2 < 240)
      {
        s.End();
        s.Begin(SpriteBlendMode.Additive, SpriteSortMode.Immediate, SaveStateMode.None);
        PraticleManager.Draw(s, Vector2.Zero);
        s.End();
        s.Begin();
        if (this.bless.IsDisposed)
          return;
        s.Draw(this.bless, new Vector2(450f, 420f), new Color(1f, 1f, 1f, this.fade));
      }
      else
      {
        if (this.bless.IsDisposed & !this.e1.IsDisposed)
          s.Draw(this.e1, Vector2.Zero, new Color(1f, 1f, 1f, this.fade2));
        if (this.e1.IsDisposed & !this.e2.IsDisposed)
          s.Draw(this.e2, Vector2.Zero, new Color(1f, 1f, 1f, this.fade2));
        if (this.e2.IsDisposed & !this.logo.IsDisposed)
        {
          s.Draw(this.blackground, new Vector2(this.x1, this.y1), new Rectangle?(), new Color(1f, 1f, 1f, this.fade4), 0.0f, new Vector2((float) (this.blackground.Width / 2), (float) (this.blackground.Height / 2)), this.scale, SpriteEffects.None, 0.0f);
          s.Draw(this.logo, new Vector2(this.x2, this.y2), new Rectangle?(), new Color(1f, 1f, 1f, this.fade3), 0.0f, new Vector2((float) (this.logo.Width / 2), (float) (this.logo.Height / 2)), this.scale2, SpriteEffects.None, 0.0f);
          if (!this.press.IsDisposed)
            s.Draw(this.press, new Vector2((float) (320 - this.press.Width / 2), (float) (405 - this.press.Height / 2)), new Color(1f, 1f, 1f, this.fade5));
        }
        if (this.stage == "BEGIN")
        {
          for (int index = 1; index < 8; ++index)
          {
            s.Draw(this.button[index], new Vector2((float) this.buttonx[index], (float) this.buttony[index]), new Rectangle?(), new Color(1f, 1f, 1f, this.buttonfade[index]), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
            if (this.selection == index && this.selection < 5 || this.selection == index + 1 && this.selection >= 6)
              s.Draw(this.buttonon[index], new Vector2((float) this.buttonx[index], (float) this.buttony[index]), new Rectangle?(), new Color(1f, 1f, 1f, this.buttonfade[index]), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
          }
          s.Draw(this.buttonsp, new Vector2((float) this.buttonspx, (float) this.buttonspy), new Rectangle?(), new Color(1f, 1f, 1f, this.buttonfade[5]), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
          if (this.selection == 5)
            s.Draw(this.buttonspon, new Vector2((float) this.buttonspx, (float) this.buttonspy), new Rectangle?(), new Color(1f, 1f, 1f, this.buttonfade[5]), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        }
        else if (this.stage == "SINGLE")
        {
          this.displaybox.Draw(s, SpriteEffects.None, 0.0f);
          for (int index = 0; index < 5; ++index)
            this.level[index].Draw(s, SpriteEffects.None, 0.0f);
          for (int index = 0; index < 4; ++index)
            this.character[index].Draw(s, SpriteEffects.None, 0.0f);
          this.cinfo.rect = new Rectangle((this.selection2 - 1) * 314, 0, 314, 483);
          this.cinfo.Draw(s, SpriteEffects.None, 0.0f);
          this.crapwise.position = this.crapwisexy[0];
          this.crapwise.Draw(s, SpriteEffects.None, 0.0f);
          this.crapwise.position = this.crapwisexy[1];
          this.crapwise.Draw(s, SpriteEffects.FlipHorizontally, 0.0f);
        }
        else if (this.stage == "PRACTICE" && this.PRACTICE != null)
          this.PRACTICE.Draw(s);
        else if (this.stage == "PLAY DATA" && this.PLAYDATA != null)
          this.PLAYDATA.Draw(s);
        else if (this.stage == "REPLAY" && this.REPLAY != null)
          this.REPLAY.Draw(s);
        else if (this.stage == "SPECIAL" && this.SPECIAL != null)
          this.SPECIAL.Draw(s);
        else if (this.stage == "OPTION")
        {
          s.Draw(this.button[7], new Vector2((float) this.buttonx[7], (float) this.buttony[7]), new Rectangle?(), new Color(1f, 1f, 1f, this.buttonfade[7]), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
          if (this.selection == 6)
            s.Draw(this.buttonon[7], new Vector2((float) this.buttonx[7], (float) this.buttony[7]), new Rectangle?(), new Color(1f, 1f, 1f, this.buttonfade[7]), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
          for (int index = 9; index < 14; ++index)
          {
            s.Draw(this.button[index], new Vector2((float) this.buttonx[index], (float) this.buttony[index]), new Rectangle?(), new Color(1f, 1f, 1f, this.buttonfade[index]), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
            if (this.selection == index - 8 && index > 11)
              s.Draw(this.buttonon[index - 1], new Vector2((float) this.buttonx[index - 1], (float) this.buttony[index - 1]), new Rectangle?(), new Color(1f, 1f, 1f, this.buttonfade[index - 1]), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
          }
          if (this.selection == 3)
            s.Draw(this.buttonon[13], new Vector2((float) this.buttonx[13], (float) this.buttony[13]), new Rectangle?(), new Color(1f, 1f, 1f, this.buttonfade[13]), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
          for (int index = 1; index <= Music.BGMvolume; ++index)
          {
            if (index % 10 == 0)
              s.Draw(this.volume, new Vector2((float) (115 + 9 * (index / 10)), 268f), new Rectangle?(), new Color(1f, 1f, 1f, this.buttonfade[9]), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
          }
          if (this.selection == 1)
          {
            for (int index = 1; index <= Music.BGMvolume; ++index)
            {
              if (index % 10 == 0)
                s.Draw(this.volumeon, new Vector2((float) (115 + 9 * (index / 10)), 268f), new Rectangle?(), new Color(1f, 1f, 1f, this.buttonfade[9]), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
            }
          }
          for (int index = 1; index <= Sound.SEvolume; ++index)
          {
            if (index % 10 == 0)
              s.Draw(this.volume, new Vector2((float) (115 + 9 * (index / 10)), 298f), new Rectangle?(), new Color(1f, 1f, 1f, this.buttonfade[10]), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
          }
          if (this.selection == 2)
          {
            for (int index = 1; index <= Sound.SEvolume; ++index)
            {
              if (index % 10 == 0)
                s.Draw(this.volumeon, new Vector2((float) (115 + 9 * (index / 10)), 298f), new Rectangle?(), new Color(1f, 1f, 1f, this.buttonfade[10]), 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
            }
          }
          if (this.steps)
          {
            JOYKEYS[] joykeysArray = new JOYKEYS[4]
            {
              JOYKEYS.Confirm,
              JOYKEYS.Special,
              JOYKEYS.Slow,
              JOYKEYS.Pause
            };
            for (int index = 0; index < 5; ++index)
            {
              if (this.selection2 != index + 1)
                this.keybutton[index].Draw(s, SpriteEffects.None, 0.0f);
              this.keybuttonon[index].Draw(s, SpriteEffects.None, 0.0f);
              if (index != 4)
              {
                s.Draw(this.optionnum, new Vector2(this.keybutton[index].position.X + 110f, this.keybutton[index].position.Y), new Rectangle?(new Rectangle(PadState.setf[joykeysArray[index]] / 10 * 22, 0, 22, 29)), new Color(1f, 1f, 1f, this.keybutton[index].color.a));
                s.Draw(this.optionnumon, new Vector2(this.keybutton[index].position.X + 110f, this.keybutton[index].position.Y), new Rectangle?(new Rectangle(PadState.setf[joykeysArray[index]] / 10 * 22, 0, 22, 29)), new Color(1f, 1f, 1f, this.keybuttonon[index].color.a));
                s.Draw(this.optionnum, new Vector2(this.keybutton[index].position.X + 123f, this.keybutton[index].position.Y), new Rectangle?(new Rectangle(PadState.setf[joykeysArray[index]] % 10 * 22, 0, 22, 29)), new Color(1f, 1f, 1f, this.keybutton[index].color.a));
                s.Draw(this.optionnumon, new Vector2(this.keybutton[index].position.X + 123f, this.keybutton[index].position.Y), new Rectangle?(new Rectangle(PadState.setf[joykeysArray[index]] % 10 * 22, 0, 22, 29)), new Color(1f, 1f, 1f, this.keybuttonon[index].color.a));
              }
            }
          }
        }
        else if (this.stage == "MUSIC ROOM")
        {
          this.mrcover.Draw(s, SpriteEffects.None, 0.0f);
          for (int index = 0; index < 16; ++index)
          {
            this.bgmlist.rect = !this.mlist[index] ? new Rectangle(0, 383, 450, 24) : new Rectangle(0, index * 24, 450, 24);
            this.bgmlist.position.X = this.mlistx[index];
            this.bgmlist.position.Y = this.mlisty[index];
            this.bgmlist.color.a = this.mlistfade[index];
            this.bgmlist.Draw(s, SpriteEffects.None, 0.0f);
          }
          if (this.pselection > 0)
          {
            for (int index = 0; index < 4; ++index)
            {
              if (this.pstring[this.pselection - 1][index] != null)
                Main.dfont.Draw(s, this.pstring[this.pselection - 1][index], new Vector2(42f, (float) (380 + index * 20)), new Color(1f, 1f, 1f, this.pfade));
            }
          }
        }
        s.End();
        s.Begin(SpriteBlendMode.Additive);
        PraticleManager.Draw(s, Vector2.Zero);
        s.End();
        s.Begin();
      }
    }
  }
}
