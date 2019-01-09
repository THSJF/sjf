// Decompiled with JetBrains decompiler
// Type: THMHJ.StageManager
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

namespace THMHJ
{
  internal class StageManager
  {
    private string bgtype = "2";
    private CrazyStorm special;
    private LoadReady Next;
    private StageData StgData;
    private List<float[]> enemyset;
    private List<float[]> bossset;
    private Hashtable bossgj;
    public List<ItemManager> itemm;
    private int stage;
    private int nextstage;
    private int spellcardid;
    private long prestagescore;
    private int time;
    private int ltime;
    private int rtime;
    private string text;
    private Texture2D bgmt;
    private Texture2D bosses;
    private Texture2D bosslist;
    private Texture2D items;
    private Texture2D words;
    private Sprite blackt;
    private Sprite stagetitle;
    private Sprite dialog;
    private Sprite dm;
    private Sprite[] db;
    private Sprite name;
    private StreamReader rd;
    private StageType type;
    private BackGround bg;
    private Hashtable bossbg;
    private CautionManager Cautionm;
    private ItemTipManager itemtipm;
    public Boss boss;
    private Sprite bgmist;
    private Hashtable modelc;
    private Hashtable stagec;
    private Hashtable backgc;
    private Hashtable bossgc;
    private Hashtable bossimage;
    private Hashtable bossdimage;
    private Hashtable idc;
    private Hashtable[] spellcard;
    private RenderTarget2D renderTarget;
    private Effect force;
    private GraphicsDevice gd;
    private GraphicsDeviceManager g;
    private int id;
    private int idn;
    private int idnow;
    private int idto;
    private List<Code> code;
    private RecordManager recordmanager;
    private int pausecount;
    private int pausetime;
    private bool pause;
    private bool recordpause;
    private bool randok;
    private bool firstok;
    private BossCard lastcard;
    private int endtype;
    private _3DPraticleManager _3dpraticle;

    public int Stage
    {
      get
      {
        return this.stage;
      }
    }

    public int RTime
    {
      get
      {
        return this.rtime;
      }
    }

    public List<Code> Codes
    {
      get
      {
        return this.code;
      }
    }

    public int EndType
    {
      get
      {
        return this.endtype;
      }
    }

    public bool RecordPause
    {
      get
      {
        return this.recordpause;
      }
    }

    public StageManager(
      StageType t,
      int stage_i,
      Texture2D enemy,
      Effect force_e,
      _3DPraticleManager tdpraticle)
    {
      this.idc = new Hashtable();
      this.idto = -1;
      this.type = t;
      this.stage = stage_i;
      this.recordmanager = new RecordManager();
      this.g = Program.game.GetGDM();
      this.gd = Program.game.GetGD();
      this.renderTarget = new RenderTarget2D(this.g.GraphicsDevice, 640, 480, 1, this.g.GraphicsDevice.DisplayMode.Format, this.g.GraphicsDevice.PresentationParameters.MultiSampleType, this.g.GraphicsDevice.PresentationParameters.MultiSampleQuality);
      this.force = force_e;
      this._3dpraticle = tdpraticle;
    }

    public StageManager(
      StageType t,
      Texture2D enemy,
      Effect force_e,
      _3DPraticleManager tdpraticle,
      int stage_i,
      int spellcardid_i)
    {
      this.idc = new Hashtable();
      this.idto = -1;
      this.type = t;
      this.stage = stage_i;
      this.spellcardid = spellcardid_i;
      this.recordmanager = new RecordManager();
      this.g = Program.game.GetGDM();
      this.gd = Program.game.GetGD();
      this.renderTarget = new RenderTarget2D(this.g.GraphicsDevice, 640, 480, 1, this.g.GraphicsDevice.DisplayMode.Format, this.g.GraphicsDevice.PresentationParameters.MultiSampleType, this.g.GraphicsDevice.PresentationParameters.MultiSampleQuality);
      this.force = force_e;
      this._3dpraticle = tdpraticle;
    }

    public void Texture(
      Texture2D bgm_t,
      Sprite black_t,
      Hashtable model_c,
      Hashtable bossg_c,
      Sprite stage_title,
      Texture2D bosses_t,
      Texture2D bosslist_t,
      Texture2D items_t,
      Sprite dialog_t,
      Sprite dm_s,
      Sprite[] db_s,
      Sprite name_s,
      Texture2D words_t,
      Hashtable bossimage_c,
      Hashtable bossdimage_c,
      Sprite bgmist_s)
    {
      this.bgmist = bgmist_s;
      this.dm = dm_s;
      this.db = db_s;
      this.name = name_s;
      this.bgmt = bgm_t;
      this.blackt = black_t;
      this.modelc = model_c;
      this.stagetitle = stage_title;
      this.bosses = bosses_t;
      this.bossgc = bossg_c;
      this.bosslist = bosslist_t;
      this.items = items_t;
      this.dialog = dialog_t;
      this.words = words_t;
      this.bossimage = bossimage_c;
      this.bossdimage = bossdimage_c;
      this.itemtipm = new ItemTipManager(this.bosslist);
    }

    public void Data(
      List<float[]> enemyset_l,
      List<float[]> bossset_l,
      Hashtable stage_c,
      Hashtable backg_c,
      Hashtable[] spellcard_h,
      Hashtable bossgj_l,
      StageData stgd)
    {
      this.enemyset = enemyset_l;
      this.bossset = bossset_l;
      this.stagec = stage_c;
      this.backgc = backg_c;
      this.spellcard = spellcard_h;
      this.bossgj = bossgj_l;
      this.StgData = stgd;
      this.Load(this.stage);
    }

    public void Data(
      Hashtable bossgj_l,
      Hashtable stage_c,
      Hashtable backg_c,
      Hashtable[] spellcard_h,
      Hashtable model_c,
      StageData stgd)
    {
      this.bossgj = bossgj_l;
      this.stagec = stage_c;
      this.backgc = backg_c;
      this.spellcard = spellcard_h;
      this.modelc = model_c;
      this.StgData = stgd;
      this.Load(this.nextstage);
    }

    private void Load(int stage)
    {
      switch (this.type)
      {
        case StageType.SINGLE:
          this.rd = (StreamReader) this.stagec[(object) (stage.ToString() + "0" + ((int) Main.Level).ToString())];
          break;
        case StageType.SPELLCARD:
          this.rd = (StreamReader) this.stagec[(object) this.spellcardid.ToString()];
          break;
      }
      this.code = new List<Code>();
      while ((this.text = this.rd.ReadLine()) != null)
      {
        if (this.text.Contains("For "))
        {
          string str1 = this.text.Split('[')[1].Split(']')[0];
          int num1 = int.Parse(str1.Split(':')[0]) * 3600 + int.Parse(str1.Split(':')[1]) * 60 + int.Parse(str1.Split(':')[2]);
          string str2 = this.text.Split('[')[2].Split(']')[0];
          int num2 = int.Parse(str2.Split(':')[0]) * 3600 + int.Parse(str2.Split(':')[1]) * 60 + int.Parse(str2.Split(':')[2]);
          string str3 = this.text.Split('[')[3].Split(']')[0];
          int num3 = int.Parse(str3.Split(':')[0]) * 3600 + int.Parse(str3.Split(':')[1]) * 60 + int.Parse(str3.Split(':')[2]);
          do
          {
            this.text = this.rd.ReadLine();
            string str4 = "";
            if (this.text.Length > 2)
              str4 = this.text[0].ToString() + this.text[1].ToString();
            for (int stm_i = num1; stm_i <= num2; stm_i += num3)
            {
              if (this.text.Length > 0 && str4 != "//")
                this.code.Add(new Code(stm_i, this.text));
            }
          }
          while (!this.text.Contains("}"));
        }
        string str5 = "";
        if (this.text.Length > 2)
          str5 = this.text[0].ToString() + this.text[1].ToString();
        if (this.text.Contains("[") && this.text.Length > 0 && str5 != "//")
        {
          string str1 = this.text.Split('[')[1].Split(']')[0];
          this.code.Add(new Code(int.Parse(str1.Split(':')[0]) * 3600 + int.Parse(str1.Split(':')[1]) * 60 + int.Parse(str1.Split(':')[2]), this.text.Split(']')[1]));
        }
      }
    }

    private void Process(
      string ist,
      EnemyManager enemys,
      CSManager csm,
      Hashtable barragec,
      Character Player)
    {
      if (ist.Contains("Pause"))
      {
        ist = ist.Split('(')[1].Split(')')[0];
        this.pausecount = int.Parse(ist);
        this.pause = true;
      }
      else if (ist.Contains("Goto"))
      {
        ist = ist.Split('(')[1].Split(')')[0];
        this.time = int.Parse(ist.Split(':')[0]) * 3600 + int.Parse(ist.Split(':')[1]) * 60 + int.Parse(ist.Split(':')[2]);
      }
      else if (ist.Contains("LastBoss"))
      {
        if (this.boss == null)
          return;
        this.boss.lastone = true;
      }
      else if (ist.Contains("ExtraBoss"))
      {
        if (this.boss == null)
          return;
        this.boss.banbomb = true;
      }
      else if (ist.Contains("PlayMusic(road)"))
      {
        if (Music.BGMContaining)
          return;
        if (this.stage != 7)
        {
          BGM bgm1 = new BGM(this.bgmt, 2 + (this.stage - 1) * 2);
        }
        else
        {
          BGM bgm2 = new BGM(this.bgmt, 15);
        }
        Music.BGM.Play();
      }
      else if (ist.Contains("PlayMusic(boss)"))
      {
        if (!Music.BGMContaining)
        {
          if (this.stage != 7)
          {
            BGM bgm1 = new BGM(this.bgmt, 3 + (this.stage - 1) * 2);
          }
          else
          {
            BGM bgm2 = new BGM(this.bgmt, 16);
          }
          Music.BGM.Play();
        }
        if (Main.SpecialMode != Modes.SPELLCARD)
          return;
        Music.BGMContaining = true;
      }
      else if (ist.Contains("Caution"))
      {
        ist = ist.Split('(')[1].Split(')')[0];
        if (this.Cautionm == null)
          this.Cautionm = new CautionManager();
        Caution caution = new Caution(this.Cautionm, this.words, new Vector2(float.Parse(ist.Split(',')[0]), float.Parse(ist.Split(',')[1])));
      }
      else if (ist.Contains("SetEnemyParent"))
      {
        ist = ist.Split('(')[1].Split(')')[0];
        int index1 = enemys.GetIndex(ist.Split(',')[0]);
        int index2 = enemys.GetIndex(ist.Split(',')[1]);
        if (index1 == -1 || index2 == -1)
          return;
        enemys.EnemyArray[index2].pdie += new Enemy.ParentDie(enemys.EnemyArray[index1].ParentIsDead);
      }
      else if (ist.Contains("SetEnemyItems"))
      {
        if (this.itemm == null)
          this.itemm = new List<ItemManager>();
        Program.game.game.TransItemm(this.itemm);
        ist = ist.Split('(')[1].Split(')')[0];
        int index = enemys.GetIndex(this.id);
        if (index == -1)
          return;
        ItemManager itemManager = new ItemManager(this.itemm, this.items, float.Parse(ist.Split(',')[0]), float.Parse(ist.Split(',')[1]), float.Parse(ist.Split(',')[2]), float.Parse(ist.Split(',')[3]), float.Parse(ist.Split(',')[4]), float.Parse(ist.Split(',')[5]));
        enemys.EnemyArray[index].items = itemManager;
        enemys.EnemyArray[index].itemsave = new List<float>();
        enemys.EnemyArray[index].itemsave.Add(float.Parse(ist.Split(',')[0]));
        enemys.EnemyArray[index].itemsave.Add(float.Parse(ist.Split(',')[1]));
        enemys.EnemyArray[index].itemsave.Add(float.Parse(ist.Split(',')[2]));
        enemys.EnemyArray[index].itemsave.Add(float.Parse(ist.Split(',')[3]));
        enemys.EnemyArray[index].itemsave.Add(float.Parse(ist.Split(',')[4]));
        enemys.EnemyArray[index].itemsave.Add(float.Parse(ist.Split(',')[5]));
        this.itemm.Add(itemManager);
      }
      else if (ist.Contains("SetEnemy"))
      {
        ist = ist.Split('(')[1].Split(')')[0];
        float num1 = 0.0f;
        float num2 = 0.0f;
        float num3 = 0.0f;
        float num4 = 0.0f;
        float num5 = 0.0f;
        if (ist.Split(',')[0].Contains("+"))
          num1 = MathHelper.Lerp(0.0f, float.Parse(ist.Split(',')[0].Split('+')[1]), (float) Main.Rand(false));
        if (ist.Split(',')[1].Contains("+"))
          num2 = MathHelper.Lerp(0.0f, float.Parse(ist.Split(',')[1].Split('+')[1]), (float) Main.Rand(false));
        if (ist.Split(',')[2].Contains("+"))
          num3 = MathHelper.Lerp(0.0f, float.Parse(ist.Split(',')[2].Split('+')[1]), (float) Main.Rand(false));
        if (ist.Split(',')[3].Contains("+"))
          num4 = MathHelper.Lerp(0.0f, float.Parse(ist.Split(',')[3].Split('+')[1]), (float) Main.Rand(false));
        if (ist.Split(',')[4].Contains("+"))
          num5 = MathHelper.Lerp(0.0f, float.Parse(ist.Split(',')[4].Split('+')[1]), (float) Main.Rand(false));
        if (this.id < this.idn)
          this.id = this.idn;
        ++this.id;
        Enemy enemy = new Enemy(this.enemyset, enemys, csm, barragec, int.Parse(ist.Split(',')[0].Split('+')[0]) + (int) Math.Round((double) num1), new Vector2((float) ((double) float.Parse(ist.Split(',')[1].Split('+')[0]) + (double) num2), (float) ((double) float.Parse(ist.Split(',')[2].Split('+')[0]) + (double) num3)), (float) ((double) float.Parse(ist.Split(',')[3].Split('+')[0]) + (double) num4), (float) ((double) float.Parse(ist.Split(',')[4].Split('+')[0]) + (double) num5), int.Parse(ist.Split(',')[5]), int.Parse(ist.Split(',')[6]), this.stage, int.Parse(ist.Split(',')[7]), this.id);
        this.idnow = this.id;
        if (ist.Split(',').Length < 9)
          return;
        enemys.EnemyArray[enemys.GetIndex(this.id)].label = ist.Split(',')[8];
      }
      else if (ist.Contains("CopyEnemy"))
      {
        if (this.itemm == null)
          this.itemm = new List<ItemManager>();
        ist = ist.Split('(')[1].Split(')')[0];
        float num1 = 0.0f;
        float num2 = 0.0f;
        float num3 = 0.0f;
        float num4 = 0.0f;
        if (ist.Split(',')[0].Contains("++"))
          num3 = float.Parse(ist.Split(',')[0].Split("++".ToCharArray())[2]);
        else if (ist.Split(',')[0].Contains("+"))
          num1 = MathHelper.Lerp(0.0f, float.Parse(ist.Split(',')[0].Split('+')[1]), (float) Main.Rand(false));
        if (ist.Split(',')[1].Contains("++"))
          num4 = float.Parse(ist.Split(',')[1].Split("++".ToCharArray())[2]);
        else if (ist.Split(',')[1].Contains("+"))
          num2 = MathHelper.Lerp(0.0f, float.Parse(ist.Split(',')[1].Split('+')[1]), (float) Main.Rand(false));
        if (ist.Split(',')[0].Contains("--"))
          num3 = -float.Parse(ist.Split(',')[0].Split("--".ToCharArray())[2]);
        if (ist.Split(',')[1].Contains("--"))
          num4 = -float.Parse(ist.Split(',')[1].Split("--".ToCharArray())[2]);
        if (this.idn < this.id)
          this.idn = this.id;
        int index1;
        if (ist.Split(',').Length >= 6)
        {
          index1 = enemys.GetIndex(ist.Split(',')[5]);
        }
        else
        {
          int id = this.id;
          if (this.idto != -1)
            id = this.idto;
          index1 = enemys.GetIndex(id);
        }
        this.idto = -1;
        ++this.idn;
        if (index1 == -1)
          return;
        float x;
        if ((double) num3 != 0.0)
        {
          if (!ist.Split(',')[0].Contains("nul"))
          {
            if ((double) num3 < 0.0)
              x = float.Parse(ist.Split(',')[0].Split("--".ToCharArray())[0]);
            else
              x = float.Parse(ist.Split(',')[0].Split("++".ToCharArray())[0]);
          }
          else
            x = enemys.EnemyArray[index1].copy.Position.X;
        }
        else if (!ist.Split(',')[0].Contains("nul"))
          x = float.Parse(ist.Split(',')[0].Split('+')[0]);
        else
          x = enemys.EnemyArray[index1].copy.Position.X;
        float y;
        if ((double) num4 != 0.0)
        {
          if (!ist.Split(',')[1].Contains("nul"))
          {
            if ((double) num4 < 0.0)
              y = float.Parse(ist.Split(',')[1].Split("--".ToCharArray())[0]);
            else
              y = float.Parse(ist.Split(',')[1].Split("++".ToCharArray())[0]);
          }
          else
            y = enemys.EnemyArray[index1].copy.Position.Y;
        }
        else if (!ist.Split(',')[1].Contains("nul"))
          y = float.Parse(ist.Split(',')[1].Split('+')[0]);
        else
          y = enemys.EnemyArray[index1].copy.Position.Y;
        Enemy enemy = new Enemy(this.enemyset, enemys, csm, barragec, enemys.EnemyArray[index1].copy.type, new Vector2(x + num1 + num3, y + num2 + num4), enemys.EnemyArray[index1].copy.speed, enemys.EnemyArray[index1].copy.speedf, enemys.EnemyArray[index1].copy.life, enemys.EnemyArray[index1].copy.hp, this.stage, enemys.EnemyArray[index1].copy.barrageid, this.idn);
        this.idnow = this.idn;
        if (ist.Split(',')[2].Contains("+"))
        {
          int num5 = int.Parse(ist.Split(',')[2].Split('+')[0]);
          enemy.ftime = (int) MathHelper.Lerp((float) num5, (float) (num5 + int.Parse(ist.Split(',')[2].Split('+')[1])), (float) Main.Rand(false));
        }
        else
          enemy.ftime = int.Parse(ist.Split(',')[2]);
        if (enemys.EnemyArray[index1].itemsave != null)
        {
          ItemManager itemManager = new ItemManager(this.itemm, this.items, enemys.EnemyArray[index1].itemsave[0], enemys.EnemyArray[index1].itemsave[1], enemys.EnemyArray[index1].itemsave[2], enemys.EnemyArray[index1].itemsave[3], enemys.EnemyArray[index1].itemsave[4], enemys.EnemyArray[index1].itemsave[5]);
          enemy.items = itemManager;
          List<float> floatList = new List<float>();
          foreach (float num5 in enemys.EnemyArray[index1].itemsave)
            floatList.Add(num5);
          enemy.itemsave = floatList;
          this.itemm.Add(itemManager);
        }
        int count;
        if (ist.Split(',')[4] == "all")
        {
          count = enemys.EnemyArray[index1].EventArray.Count;
        }
        else
        {
          count = int.Parse(ist.Split(',')[4]);
          if (count > enemys.EnemyArray[index1].EventArray.Count)
            count = enemys.EnemyArray[index1].EventArray.Count;
        }
        for (int index2 = 0; index2 < count; ++index2)
        {
          if (!enemys.EnemyArray[index1].EventArray[index2].Independent)
          {
            EnemyEvent enemyEvent = new EnemyEvent();
            enemyEvent.occasion = enemys.EnemyArray[index1].EventArray[index2].occasion;
            enemyEvent.value = enemys.EnemyArray[index1].EventArray[index2].value;
            enemyEvent.target = enemys.EnemyArray[index1].EventArray[index2].target;
            enemyEvent.targets = enemys.EnemyArray[index1].EventArray[index2].targets;
            if (ist.Split(',')[3] == "true")
              enemyEvent.targetxr = enemys.EnemyArray[index1].EventArray[index2].targetx;
            enemyEvent.time = enemys.EnemyArray[index1].EventArray[index2].time;
            enemyEvent.type = enemys.EnemyArray[index1].EventArray[index2].type;
            enemy.EventArray.Add(enemyEvent);
          }
        }
      }
      else if (ist.Contains("Saveid"))
      {
        ist = ist.Split('(')[1].Split(')')[0];
        if (!this.idc.Contains((object) ist))
          this.idc.Add((object) ist, (object) this.idnow);
        else
          this.idc[(object) ist] = (object) this.idnow;
      }
      else if (ist.Contains("Loadid"))
      {
        ist = ist.Split('(')[1].Split(')')[0];
        if (!this.idc.Contains((object) ist))
          return;
        this.idto = (int) this.idc[(object) ist];
      }
      else if (ist.Contains("AddEvent"))
      {
        ist = ist.Split('(')[1].Split(')')[0];
        float num = 0.0f;
        if (ist.Split(',')[2].Contains("+"))
          num = MathHelper.Lerp(0.0f, float.Parse(ist.Split(',')[2].Split('+')[1]), (float) Main.Rand(false));
        int id = this.id;
        if (this.id < this.idn)
          id = this.idn;
        int index = enemys.GetIndex(id);
        if (index == -1)
          return;
        enemys.EnemyArray[index].EventArray.Add(new EnemyEvent(int.Parse(ist.Split(',')[0]), ist.Split(',')[1], (float) ((double) float.Parse(ist.Split(',')[2].Split('+')[0]) + (double) num), int.Parse(ist.Split(',')[3]), int.Parse(ist.Split(',')[4])));
      }
      else if (ist.Contains("SetNoHarmTime"))
      {
        ist = ist.Split('(')[1].Split(')')[0];
        int id = this.id;
        if (this.id < this.idn)
          id = this.idn;
        int index = enemys.GetIndex(id);
        if (index == -1)
          return;
        enemys.EnemyArray[index].noharm = int.Parse(ist);
      }
      else if (ist.Contains("ChangeEnemy"))
      {
        ist = ist.Split('(')[1].Split(')')[0];
        int index1 = enemys.GetIndex(ist.Split(',')[0]);
        if (index1 != -1)
        {
          enemys.EnemyArray[index1].EventArray.Add(new EnemyEvent(0, ist.Split(',')[1], float.Parse(ist.Split(',')[2]), int.Parse(ist.Split(',')[3]), int.Parse(ist.Split(',')[4]))
          {
            Independent = true
          });
        }
        else
        {
          for (int index2 = 0; index2 < enemys.EnemyArray.Count; ++index2)
            enemys.EnemyArray[index2].EventArray.Add(new EnemyEvent(0, ist.Split(',')[1], float.Parse(ist.Split(',')[2]), int.Parse(ist.Split(',')[3]), int.Parse(ist.Split(',')[4])));
        }
      }
      else if (ist.Contains("SetBossCard"))
      {
        ist = ist.Split('(')[1].Split(')')[0];
        if (this.boss == null)
          return;
        string[] strArray = ist.Split(',');
        if (strArray.Length == 4)
        {
          BossCard bossCard = Main.SpecialMode == Modes.SPELLCARD ? this.boss.AddNewCard(int.Parse(strArray[0]), csm, barragec, Player, this.stage, this.spellcardid, int.Parse(strArray[2]), int.Parse(strArray[3])) : this.boss.AddNewCard(int.Parse(strArray[0]), csm, barragec, Player, this.stage, int.Parse(strArray[1]), int.Parse(strArray[2]), int.Parse(strArray[3]));
          this.lastcard = bossCard;
          if (bossCard.type == 1 && this.boss.banbomb)
            bossCard.banbomb = true;
        }
        else if (strArray.Length == 5)
        {
          if (strArray[4] == "TRANS")
          {
            BossCard bossCard = this.boss.AddNewCard(int.Parse(strArray[0]), csm, barragec, Player, this.stage, int.Parse(strArray[1]), int.Parse(strArray[2]), int.Parse(strArray[3]));
            this.lastcard = bossCard;
            if (bossCard.type == 1 && this.boss.banbomb)
              bossCard.banbomb = true;
            bossCard.transform = true;
          }
          else if (strArray[4] == "TIMENOTHIDE")
          {
            BossCard bossCard = Main.SpecialMode == Modes.SPELLCARD ? this.boss.AddNewCard(int.Parse(strArray[0]), csm, barragec, Player, this.stage, this.spellcardid, int.Parse(strArray[2]), int.Parse(strArray[3])) : this.boss.AddNewCard(int.Parse(strArray[0]), csm, barragec, Player, this.stage, int.Parse(strArray[1]), int.Parse(strArray[2]), int.Parse(strArray[3]));
            this.lastcard = bossCard;
            if (bossCard.type == 1 && this.boss.banbomb)
              bossCard.banbomb = true;
            bossCard.timecard = true;
            bossCard.nothide = true;
          }
          else if (strArray[4] == "TIME")
          {
            BossCard bossCard = Main.SpecialMode == Modes.SPELLCARD ? this.boss.AddNewCard(int.Parse(strArray[0]), csm, barragec, Player, this.stage, this.spellcardid, int.Parse(strArray[2]), int.Parse(strArray[3])) : this.boss.AddNewCard(int.Parse(strArray[0]), csm, barragec, Player, this.stage, int.Parse(strArray[1]), int.Parse(strArray[2]), int.Parse(strArray[3]));
            this.lastcard = bossCard;
            if (bossCard.type == 1 && this.boss.banbomb)
              bossCard.banbomb = true;
            bossCard.timecard = true;
            bossCard.nothide = false;
          }
          else if (strArray[4] == "CONTINUE")
            this.lastcard.AddNewBarrage(new BarrageSet(csm.Createnew(this.stage, int.Parse(strArray[1]), barragec))
            {
              time = int.Parse(strArray[2]),
              hp = int.Parse(strArray[3])
            });
          else if (strArray[4] == "LAST")
          {
            BossCard bossCard = this.boss.AddNewCard(int.Parse(strArray[0]), csm, barragec, Player, this.stage, int.Parse(strArray[1]), int.Parse(strArray[2]), int.Parse(strArray[3]));
            this.lastcard = bossCard;
            if (bossCard.type == 1 && this.boss.banbomb)
              bossCard.banbomb = true;
            bossCard.banbomb = true;
          }
          else
          {
            BossCard bossCard = this.boss.AddNewCard(int.Parse(strArray[0]), csm, barragec, Player, this.stage, int.Parse(strArray[1]), int.Parse(strArray[2]), int.Parse(strArray[3]));
            this.lastcard = bossCard;
            if (bossCard.type == 1 && this.boss.banbomb)
              bossCard.banbomb = true;
            bossCard.wudi = int.Parse(strArray[4]);
          }
        }
        if (this.boss.CardArray.Count != 1)
          return;
        this.boss.CardArray[0].first = true;
      }
      else if (ist.Contains("SetBossItems"))
      {
        if (this.itemm == null)
          this.itemm = new List<ItemManager>();
        ist = ist.Split('(')[1].Split(')')[0];
        if (this.boss == null)
          return;
        ItemManager itemManager = new ItemManager(this.itemm, this.items, float.Parse(ist.Split(',')[0]), float.Parse(ist.Split(',')[1]), float.Parse(ist.Split(',')[2]), float.Parse(ist.Split(',')[3]), float.Parse(ist.Split(',')[4]), float.Parse(ist.Split(',')[5]), float.Parse(ist.Split(',')[6]), float.Parse(ist.Split(',')[7]), float.Parse(ist.Split(',')[8]));
        Program.game.game.TransItemm(this.itemm);
        this.boss.itemm = itemManager;
        this.itemm.Add(itemManager);
      }
      else if (ist.Contains("SetBoss"))
      {
        ist = ist.Split('(')[1].Split(')')[0];
        this.bgtype = ist.Split(',')[1];
        this.boss = new Boss(this.bosses, this.bosslist, this.spellcard, this.dialog, this.dm, this.db, this.name, this.stage, int.Parse(this.bgtype), Player.type, this.force, this.bossset, int.Parse(ist.Split(',')[0]), int.Parse(ist.Split(',')[2]), int.Parse(ist.Split(',')[3]), int.Parse(ist.Split(',')[4]), int.Parse(ist.Split(',')[5]), int.Parse(ist.Split(',')[6]));
        this.boss.Texture(this.bossimage, this.bossdimage);
      }
      else if (ist.Contains("LoadBackGround"))
      {
        this.bg = new BackGround(Program.game.GetCM(), this.g, this.gd, this.stage, this._3dpraticle);
        this.bg.Texture(this.modelc, this.backgc);
        this.bossbg = new Hashtable();
        foreach (object key in (IEnumerable) this.bossgj.Keys)
        {
          BossBackground bossBackground = new BossBackground((List<string>) this.bossgj[key], this.bossgc);
          this.bossbg.Add(key, (object) bossBackground);
        }
      }
      else if (ist.Contains("ShowTitle"))
      {
        Title title = new Title(this.stage, this.stagetitle);
      }
      else
      {
        if (!ist.Contains("StageEnd"))
          return;
        string s = ist.Split('(')[1].Split(')')[0];
        if (s == "ed")
          this.endtype = 1;
        else if (s == "exed")
          this.endtype = 2;
        else if (s == "sc")
        {
          --this.ltime;
          this.recordpause = true;
          Program.game.game.RecordSpecialScore();
        }
        else
          this.nextstage = int.Parse(s);
        if (Main.SpecialMode == Modes.PRACTICE)
          this.endtype = 0;
        ++this.ltime;
      }
    }

    public void syncInit(Character Player)
    {
      if (Main.Replay)
        return;
      Player?.Init();
      ActionRecord actionRecord = new ActionRecord();
      actionRecord.type = (byte) 12;
      actionRecord.time = this.rtime;
      actionRecord.stage = (byte) this.stage;
      if (this.recordmanager == null)
        return;
      this.recordmanager.actions.Add(actionRecord);
    }

    public void Update(EnemyManager enemys, CSManager csm, Hashtable barragec, Character Player)
    {
      if (this.pause)
      {
        ++this.pausetime;
        if (this.pausetime >= this.pausecount)
        {
          this.pause = false;
          this.pausetime = 0;
          ++this.time;
        }
      }
      if (!this.firstok)
      {
        Player.Ban = false;
        Player.Init();
        this.firstok = true;
        Main.OpenFpsInspect();
      }
      if (!Main.Replay)
        this.RecordAction();
      else
        this.RecordPlay(Player);
      if (!this.pause)
      {
        for (int index = 0; index < this.code.Count; ++index)
        {
          if (this.time == this.code[index].Stm)
          {
            this.Process(this.code[index].Text, enemys, csm, barragec, Player);
            this.code.RemoveAt(index);
            --index;
          }
        }
      }
      if (this.bg != null)
        this.bg.Update(this.boss);
      BGM.Update();
      Title.Update();
      if (Main.SpecialMode != Modes.SPELLCARD)
        ((BossBackground) this.bossbg[(object) this.bgtype]).Update();
      else
        ((BossBackground) this.bossbg[(object) this.spellcardid.ToString()]).Update();
      if (this.boss != null)
      {
        if (this.boss.die)
          this.boss = (Boss) null;
        else if (Main.SpecialMode != Modes.SPELLCARD)
          this.boss.Update(enemys, csm, Player, (BossBackground) this.bossbg[(object) this.bgtype], this.bgmt, this.stage);
        else
          this.boss.Update(enemys, csm, Player, (BossBackground) this.bossbg[(object) this.spellcardid.ToString()], this.bgmt, this.stage);
      }
      enemys.Update(Player, this.boss);
      if (this.itemm != null)
      {
        for (int index = 0; index < this.itemm.Count; ++index)
        {
          if (!this.itemm[index].die && this.itemm[index].GetCount() != 0)
          {
            if (!Player.Dis)
              this.itemm[index].Ban(false);
            else
              this.itemm[index].Ban(true);
            this.itemm[index].Update(this.itemtipm, Player.Auto || Player.IAuto);
          }
          else
          {
            this.itemm.RemoveAt(index);
            --index;
          }
        }
      }
      if (this.stage == 6 && this.time == 1700)
      {
        this.special = Program.game.game.PlayEffect(true, "29", new Vector2(0.0f, 0.0f));
        this.special.BanSound(true);
        this.special.effect = true;
      }
      else if (this.stage == 6 && this.boss != null && this.special != null)
      {
        this.special.Close();
        this.special = (CrazyStorm) null;
      }
      if (this.itemtipm != null)
        this.itemtipm.Update();
      if (this.Cautionm != null)
        this.Cautionm.Update();
      if (this.boss == null && !this.pause)
        ++this.time;
      ++this.rtime;
      if (!this.randok && !Main.Replay)
      {
        Main.SetRandSeed(Main.Chaos_GetRandomSeed());
        this.recordmanager.seeds.Add(new RandSeedRecord()
        {
          seed = Main.RandSeed,
          stage = (byte) this.stage
        });
        this.recordmanager.Positions.Add(new PositionRecord()
        {
          stage = (byte) this.stage,
          Position = Player.Position()
        });
        this.recordmanager.scores.Add(new ScoreRecord()
        {
          type = (byte) 5,
          score = Program.game.game.Score,
          stage = (byte) this.stage
        });
        this.recordmanager.scores.Add(new ScoreRecord()
        {
          type = (byte) 6,
          score = (long) Program.game.game.Life,
          stage = (byte) this.stage
        });
        this.recordmanager.scores.Add(new ScoreRecord()
        {
          type = (byte) 7,
          score = (long) Program.game.game.Bomb,
          stage = (byte) this.stage
        });
        this.recordmanager.scores.Add(new ScoreRecord()
        {
          type = (byte) 8,
          score = (long) Program.game.game.Point,
          stage = (byte) this.stage
        });
        this.recordmanager.scores.Add(new ScoreRecord()
        {
          type = (byte) 9,
          score = (long) Program.game.game.Graze,
          stage = (byte) this.stage
        });
        this.randok = true;
      }
      if (!this.randok && Main.Replay)
      {
        foreach (RandSeedRecord seed in Main.ReplayContent.seeds)
        {
          if ((int) seed.stage == (int) (byte) this.stage)
          {
            Main.SetRandSeed(seed.seed);
            break;
          }
        }
        foreach (PositionRecord position in Main.ReplayContent.Positions)
        {
          if ((int) position.stage == (int) (byte) this.stage)
          {
            Player.SetPosition(position.Position);
            break;
          }
        }
        foreach (ScoreRecord score in Main.ReplayContent.scores)
        {
          if ((int) score.stage == (int) (byte) this.stage)
          {
            if (score.type == (byte) 5)
              Program.game.game.Score = score.score;
            else if (score.type == (byte) 6)
              Program.game.game.Life = (int) score.score;
            else if (score.type == (byte) 7)
              Program.game.game.Bomb = (int) score.score;
            else if (score.type == (byte) 8)
              Program.game.game.Point = (int) score.score;
            else if (score.type == (byte) 9)
              Program.game.game.Graze = (int) score.score;
          }
        }
        this.randok = true;
      }
      if (this.ltime < 1)
        return;
      int num = 0;
      if (this.endtype != 0)
        num = 150;
      if (this.ltime == 1)
      {
        Player.Ban = true;
        Program.game.game.ReadyForNext = true;
        Stageclear stageclear = new Stageclear(this.bosslist, this.StgData);
      }
      else if (this.ltime == 250)
      {
        Music.Savevolume = Music.BGMvolume;
        if (!Main.Replay)
        {
          this.recordmanager.scores.Add(new ScoreRecord()
          {
            type = (byte) 10,
            stage = (byte) this.stage,
            score = Program.game.game.Score - this.prestagescore
          });
          this.prestagescore = Program.game.game.Score;
          if (this.endtype > 0)
          {
            Program.game.game.BanPause = true;
            Program.game.game.BanPlayer(true);
            Main.ifcontinued = Program.game.game.OverTime > 0;
            Main.EDrecordsave = new RecordSave(Program.game.game.playdata.Clone(), Program.game.game.StmStage, Program.game.game.Score);
            Main.EDreplaysave = new ReplaySave(Program.game.game.Record, Program.game.game.Rtime, Program.game.game.Score, (int) (Main.Character - 1), (int) (Main.Level - 1), Program.game.game.StmStage);
          }
        }
      }
      else if (this.ltime > 250 && this.ltime <= 300 + num)
      {
        if (this.endtype == 0)
        {
          Program.game.game.bgcolor.a += 0.02f;
          Music.BGMvolume -= 2;
        }
        else
        {
          Program.game.game.bgcolor.a += 0.005f;
          if (this.ltime % 2 == 0)
            --Music.BGMvolume;
          if (Music.BGMvolume <= 0)
            Music.BGMvolume = 0;
        }
      }
      ++this.ltime;
      if (this.ltime < 310 + num)
        return;
      if (Main.SpecialMode != Modes.PRACTICE)
      {
        if (this.endtype != 0)
        {
          Program.game.achivmanager.Check(AchievementType.Hidden, 1, new Hashtable()
          {
            [(object) "time"] = (object) Program.game.game.OverTime,
            [(object) "limit"] = (object) Program.game.game.OverLimit
          });
          Music.BGMvolume = Music.Savevolume;
          Program.game.game.Finish("ED " + this.endtype.ToString());
        }
        else if (this.Next == null)
        {
          this.Next = new LoadReady();
          Program.game.game.LoadNewStage(this.gd, this.nextstage, this.Next);
        }
        else
        {
          if (this.Next == null || !this.Next.Ready)
            return;
          this.Next = (LoadReady) null;
          this.time = 0;
          this.ltime = 0;
          this.rtime = 0;
          this.stage = this.nextstage;
          Program.game.game.ReadyForNext = false;
          this.firstok = false;
          this.randok = false;
          this.bg.Load(this.stage);
        }
      }
      else
      {
        Music.BGMvolume = Music.Savevolume;
        if (Main.Replay)
          return;
        Program.game.game.RecordPracticeScore();
        Program.game.game.PracticeFinished();
      }
    }

    public void RecordPlay(Character Player)
    {
      foreach (ActionRecord action in Main.ReplayContent.actions)
      {
        if ((int) action.stage == (int) (byte) this.stage && action.time == this.rtime)
        {
          switch (action.type)
          {
            case 3:
              this.recordpause = true;
              continue;
            case 12:
              Player.Init();
              continue;
            default:
              continue;
          }
        }
      }
      for (int index = 0; index < RecordManager.used.Length; ++index)
      {
        int num = 1 << RecordManager.used.Length - index - 1;
        Main.MKeys[index] = this.rtime <= Main.ReplayContent.records[this.stage - 1].Count - 1 && ((int) Main.ReplayContent.records[this.stage - 1][this.rtime] & (int) (byte) num) > 0;
      }
    }

    public void RecordAction()
    {
      bool[] flagArray = new bool[RecordManager.used.Length];
      foreach (int pressedKey in Main.keyboardstat.GetPressedKeys())
      {
        for (int index = 0; index < RecordManager.used.Length; ++index)
        {
          if (object.Equals((object) (Keys) pressedKey, (object) RecordManager.used[index]))
          {
            flagArray[index] = true;
            break;
          }
        }
      }
      JOYBUTTONS padstat = Main.padstat;
      for (int index = 0; index < RecordManager.padused.Length; ++index)
      {
        if ((padstat & PadState.set[RecordManager.padused[index]]) == PadState.set[RecordManager.padused[index]])
          flagArray[index] = true;
      }
      byte num1 = 0;
      for (int index = 0; index < flagArray.Length; ++index)
      {
        if (flagArray[index])
        {
          int num2 = 1 << flagArray.Length - index - 1;
          num1 += (byte) num2;
        }
      }
      this.recordmanager.records[this.stage - 1].Add(num1);
    }

    public void Draw(NSpriteBatch s, EnemyManager enemys, bool Pause, Colors bgcolor)
    {
      Vector2 quakeact = Program.game.game.Quakeact;
      Vector4 vector4 = Vector4.Zero;
      switch (Main.Mode)
      {
        case Modes.SINGLE:
          vector4 = new Vector4(24f, 0.0f, 400f, 480f);
          break;
        case Modes.NETWORK:
          vector4 = new Vector4(0.0f, 0.0f, 640f, 480f);
          break;
      }
      if (Pause)
      {
        if (this.bg != null)
        {
          BossBackground bossBackground;
          if (Main.SpecialMode != Modes.SPELLCARD)
          {
            bossBackground = (BossBackground) this.bossbg[(object) this.bgtype];
            if ((!this.bossbg.ContainsKey((object) this.bgtype) || !bossBackground.Start) && Main.BackGround)
              this.bg.Draw(s, Pause);
            if (this.bossbg.ContainsKey((object) this.bgtype))
              bossBackground.Draw((SpriteBatch) s, this.gd, this.renderTarget);
          }
          else
          {
            bossBackground = (BossBackground) this.bossbg[(object) this.spellcardid.ToString()];
            if ((!this.bossbg.ContainsKey((object) this.bgtype) || !bossBackground.Start) && Main.BackGround)
              this.bg.Draw(s, Pause);
            if (this.bossbg.ContainsKey((object) this.bgtype) || Main.SpecialMode == Modes.SPELLCARD)
              bossBackground.Draw((SpriteBatch) s, this.gd, this.renderTarget);
          }
          if (s.IsBegan)
            s.End();
          this.gd.SetRenderTarget(0, this.renderTarget);
          if (!s.IsBegan)
            s.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Immediate, SaveStateMode.None);
          if (this.boss != null)
          {
            if (s.IsBegan)
              s.End();
            if (!s.IsBegan)
              s.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Immediate, SaveStateMode.None);
            if (this.force != null && !this.boss.lastone)
              Effects.SetForceParameters(this.force, Time.Stop);
            this.force.Begin();
            this.force.CurrentTechnique.Passes[0].Begin();
            if ((!this.bossbg.ContainsKey((object) this.bgtype) || !bossBackground.Start) && Main.BackGround)
            {
              Texture2D render = this.bg.GetRender();
              float num1 = 0.1921875f;
              float num2 = 0.625f;
              float x = 640f / (float) render.Width;
              float y = 480f / (float) render.Height;
              s.Draw(render, new Vector2(28f, 0.0f), new Rectangle?(new Rectangle((int) ((double) render.Width * (double) num1) + (int) quakeact.X, (int) quakeact.Y, (int) ((double) render.Width * (double) num2), render.Height)), Color.White, 0.0f, Vector2.Zero, new Vector2(x, y), SpriteEffects.None, 0.0f);
            }
            if (Main.SpecialMode == Modes.SPELLCARD && Program.game.game.BossStage == 43)
            {
              this.blackt.color.a = 1f;
              this.blackt.Draw((SpriteBatch) s, SpriteEffects.None, 0.0f);
            }
            if ((this.bossbg.ContainsKey((object) this.bgtype) || Main.SpecialMode == Modes.SPELLCARD) && bossBackground.Render != null)
              s.Draw(bossBackground.Render, new Vector2(vector4.X, vector4.Y), new Rectangle?(new Rectangle((int) vector4.X + (int) quakeact.X, (int) vector4.Y + (int) quakeact.Y, (int) vector4.Z, (int) vector4.W)), Color.White);
            this.force.CurrentTechnique.Passes[0].End();
            this.force.End();
            if (s.IsBegan)
              s.End();
            if (!s.IsBegan)
              s.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Immediate, SaveStateMode.None);
          }
          else
          {
            if ((!this.bossbg.ContainsKey((object) this.bgtype) || !bossBackground.Start) && Main.BackGround)
            {
              Texture2D render = this.bg.GetRender();
              float num1 = 0.1921875f;
              float num2 = 0.625f;
              float x = 640f / (float) render.Width;
              float y = 480f / (float) render.Height;
              s.Draw(render, new Vector2(28f, 0.0f), new Rectangle?(new Rectangle((int) ((double) render.Width * (double) num1) + (int) quakeact.X, (int) quakeact.Y, (int) ((double) render.Width * (double) num2), render.Height)), Color.White, 0.0f, Vector2.Zero, new Vector2(x, y), SpriteEffects.None, 0.0f);
            }
            if (Main.SpecialMode == Modes.SPELLCARD && Program.game.game.BossStage == 43)
            {
              this.blackt.color.a = 1f;
              this.blackt.Draw((SpriteBatch) s, SpriteEffects.None, 0.0f);
            }
          }
          if (this.Stage == 6 && (!this.bossbg.ContainsKey((object) this.bgtype) || !bossBackground.Start))
            this.bgmist.Draw((SpriteBatch) s, SpriteEffects.None, 0.0f);
        }
        enemys.Draw((SpriteBatch) s, quakeact);
        if (this.boss != null)
          this.boss.Draw(s, quakeact);
        if (this.itemm != null)
        {
          for (int index = 0; index < this.itemm.Count; ++index)
          {
            if (!this.itemm[index].die)
              this.itemm[index].Draw((SpriteBatch) s, quakeact);
          }
        }
        this.blackt.color = bgcolor;
        if ((double) this.blackt.color.a > 0.0)
          this.blackt.Draw((SpriteBatch) s, SpriteEffects.None, 0.0f);
        if (s.IsBegan)
          s.End();
        this.gd.SetRenderTarget(0, (RenderTarget2D) null);
      }
      else
      {
        if (this.bg != null)
        {
          BossBackground bossBackground;
          if (Main.SpecialMode != Modes.SPELLCARD)
          {
            bossBackground = (BossBackground) this.bossbg[(object) this.bgtype];
            if ((!this.bossbg.ContainsKey((object) this.bgtype) || !bossBackground.Start) && Main.BackGround)
              this.bg.Draw(s, Pause);
            if (this.bossbg.ContainsKey((object) this.bgtype))
              bossBackground.Draw((SpriteBatch) s, this.gd, this.renderTarget);
          }
          else
          {
            bossBackground = (BossBackground) this.bossbg[(object) this.spellcardid.ToString()];
            if ((!this.bossbg.ContainsKey((object) this.bgtype) || !bossBackground.Start) && Main.BackGround)
              this.bg.Draw(s, Pause);
            if (this.bossbg.ContainsKey((object) this.bgtype) || Main.SpecialMode == Modes.SPELLCARD)
              bossBackground.Draw((SpriteBatch) s, this.gd, this.renderTarget);
          }
          if (this.boss != null)
          {
            if (s.IsBegan)
              s.End();
            if (!s.IsBegan)
              s.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Immediate, SaveStateMode.None);
            if (this.force != null && !this.boss.lastone)
              Effects.SetForceParameters(this.force, Time.Stop);
            this.force.Begin();
            this.force.CurrentTechnique.Passes[0].Begin();
            if ((!this.bossbg.ContainsKey((object) this.bgtype) || !bossBackground.Start) && Main.BackGround)
            {
              Texture2D render = this.bg.GetRender();
              float num1 = 0.1921875f;
              float num2 = 0.625f;
              float x = 640f / (float) render.Width;
              float y = 480f / (float) render.Height;
              s.Draw(render, new Vector2(28f, 0.0f), new Rectangle?(new Rectangle((int) ((double) render.Width * (double) num1) + (int) quakeact.X, (int) quakeact.Y, (int) ((double) render.Width * (double) num2), render.Height)), Color.White, 0.0f, Vector2.Zero, new Vector2(x, y), SpriteEffects.None, 0.0f);
            }
            if (Main.SpecialMode == Modes.SPELLCARD && Program.game.game.BossStage == 43)
            {
              this.blackt.color.a = 1f;
              this.blackt.Draw((SpriteBatch) s, SpriteEffects.None, 0.0f);
            }
            if ((this.bossbg.ContainsKey((object) this.bgtype) || Main.SpecialMode == Modes.SPELLCARD) && bossBackground.Render != null)
              s.Draw(bossBackground.Render, new Vector2(vector4.X, vector4.Y), new Rectangle?(new Rectangle((int) vector4.X + (int) quakeact.X, (int) vector4.Y + (int) quakeact.Y, (int) vector4.Z, (int) vector4.W)), Color.White);
            this.force.CurrentTechnique.Passes[0].End();
            this.force.End();
            if (s.IsBegan)
              s.End();
            if (!s.IsBegan)
              s.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Immediate, SaveStateMode.None);
          }
          else
          {
            if ((!this.bossbg.ContainsKey((object) this.bgtype) || !bossBackground.Start) && Main.BackGround)
            {
              Texture2D render = this.bg.GetRender();
              float num1 = 0.1921875f;
              float num2 = 0.625f;
              float x = 640f / (float) render.Width;
              float y = 480f / (float) render.Height;
              s.Draw(render, new Vector2(28f, 0.0f), new Rectangle?(new Rectangle((int) ((double) render.Width * (double) num1) + (int) quakeact.X, (int) quakeact.Y, (int) ((double) render.Width * (double) num2), render.Height)), Color.White, 0.0f, Vector2.Zero, new Vector2(x, y), SpriteEffects.None, 0.0f);
            }
            if (Main.SpecialMode == Modes.SPELLCARD && Program.game.game.BossStage == 43)
            {
              this.blackt.color.a = 1f;
              this.blackt.Draw((SpriteBatch) s, SpriteEffects.None, 0.0f);
            }
          }
          if (this.Stage == 6 && (!this.bossbg.ContainsKey((object) this.bgtype) || !bossBackground.Start))
            this.bgmist.Draw((SpriteBatch) s, SpriteEffects.None, 0.0f);
        }
        this.blackt.color = bgcolor;
        if ((double) this.blackt.color.a > 0.0)
          this.blackt.Draw((SpriteBatch) s, SpriteEffects.None, 0.0f);
        enemys.Draw((SpriteBatch) s, quakeact);
        if (this.boss != null)
          this.boss.Draw(s, quakeact);
        if (this.itemm != null)
        {
          for (int index = 0; index < this.itemm.Count; ++index)
          {
            if (!this.itemm[index].die)
              this.itemm[index].Draw((SpriteBatch) s, quakeact);
          }
        }
        if (this.itemtipm != null)
          this.itemtipm.Draw((SpriteBatch) s);
        if (this.Cautionm == null)
          return;
        this.Cautionm.Draw((SpriteBatch) s);
      }
    }

    public RecordManager GetRecord()
    {
      return this.recordmanager;
    }

    public Texture2D GetRender()
    {
      return this.renderTarget.GetTexture();
    }

    public bool IsBossed()
    {
      return this.boss != null;
    }

    public Vector2 GetBosspos()
    {
      return this.boss.Position;
    }

    public void BossCardDraw(SpriteBatch s, Character Player)
    {
      this.boss.UpDraw(s, Player);
    }

    public void BossImageDraw(SpriteBatch s)
    {
      this.boss.ImageDraw(s);
    }

    public Boss GetBoss()
    {
      return this.boss;
    }
  }
}
