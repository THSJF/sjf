// Decompiled with JetBrains decompiler
// Type: THMHJ.Game
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
using System.Threading;

namespace THMHJ {
    public class Game {
        private int time4 = 7;
        private int selection = 1;
        private int selection2 = 1;
        private Sound sound;
        private StageData Stgdata;
        private GameResource gr;
        private _3DPraticleManager _3dpraticle;
        private SpecialSystem Special;
        private Character Actor;
        private GraphicsDevice gd;
        private RenderTarget2D renderTarget;
        private Texture2D Pausescreen;
        private int time;
        private int time2;
        private int time3;
        private int time5;
        private int rptime;
        private bool step;
        private bool savestep;
        private bool stopblur;
        public Colors bgcolor;
        public long Score;
        public long HiScore;
        public int Life;
        public int Bomb;
        public int Point;
        public int MaxBlue;
        public int Graze;
        private int overtime;
        private int overlimit;
        public bool Finished;
        public bool Pause;
        private bool banrecord;
        public PlayData playdata;
        public PracticeData practicedata;
        private ReplaySave resave;
        private RecordSave cosave;
        public bool BanPause;
        public bool GameOver;
        public bool ReadyForNext;
        private bool waitforsave;
        private bool finishpractice;
        private int gamestage;
        private int bossstage;
        private int spellcardid;
        private string stage;
        public Praticle praticle;
        public Thread thread;
        private StageManager stm;
        private EnemyManager enemym;
        private CSManager csm;
        private int quaketime;
        private int quakeadd;
        private int quaketotal;
        private int quakestrength;
        private int retrytime;
        private int watch;
        public Vector2 quake;

        public event DrawDelegate Drawevents;

        public event DrawDelegate2 DrawJudge;

        public event DrawDelegate3 Drawevents2;

        public int OverTime {
            get {
                return overtime;
            }
        }

        public int OverLimit {
            get {
                return overlimit;
            }
        }

        public bool BanRecord {
            get {
                return banrecord;
            }
        }

        public int BossStage {
            get {
                return bossstage;
            }
        }

        public int Spellcardid {
            get {

                return spellcardid;
            }
        }

        public string Stage {
            get {
                return stage;
            }
        }

        public int StmStage {
            get {
                if(this.stm!=null)
                    return this.stm.Stage;
                return 0;
            }
        }

        public RecordManager Record {
            get {
                if(this.stm!=null)
                    return this.stm.GetRecord();
                return (RecordManager)null;
            }
        }

        public int Rtime {
            get {
                if(this.stm!=null)
                    return this.stm.RTime;
                return 0;
            }
        }

        public Vector2 Quakeact {
            get {
                return this.quake;
            }
        }

        public Game(GraphicsDevice gd_g,GameResource gr_g) {
            sound=new Sound();
            Init(gd_g,gr_g);
            gamestage=1;
            if(Main.Level==Difficulty.EASY)
                overlimit=3;
            else if(Main.Level==Difficulty.NORMAL)
                overlimit=5;
            else if(Main.Level==Difficulty.HARD)
                overlimit=7;
            else if(Main.Level==Difficulty.LUNATIC)
                overlimit=9;
            if(Main.Level==Difficulty.EXTRA)
                gamestage=7;
            if(gamestage==7) {
                overlimit=Int32.MaxValue;
                Life=50;
                Bomb=50;
            }
            Life=10;
            Bomb=10;
            _3dpraticle=new _3DPraticleManager();
            thread=new Thread(new ParameterizedThreadStart(Load));
            thread.Priority=ThreadPriority.Highest;
            thread.Start(gd);
        }

        public Game(GraphicsDevice gd_g,GameResource gr_g,int gamestage_i) {
            sound=new Sound();
            Init(gd_g,gr_g);
            gamestage=gamestage_i;
            Life=SourseForm.life;
            Bomb=SourseForm.spell;
            Point=SourseForm.power;
            MaxBlue=SourseForm.highItemScore;
            switch(Main.Level) {
                case Difficulty.EASY:
                    overlimit=3;
                    break;
                case Difficulty.NORMAL:
                    overlimit=5;
                    break;
                case Difficulty.HARD:
                    overlimit=7;
                    break;
                case Difficulty.LUNATIC:
                    overlimit=9;
                    break;
            }
            //  if(gamestage>=2&&Main.SpecialMode==Modes.PRACTICE)
            //     Point=200;
            if(gamestage==7) overlimit=0;
            _3dpraticle=new _3DPraticleManager();
            thread=new Thread(new ParameterizedThreadStart(Load));
            thread.Priority=ThreadPriority.Highest;
            thread.Start(gd);
        }

        public Game(GraphicsDevice gd_g,GameResource gr_g,int bossstage_i,int spellcardid_i) {
            sound=new Sound();
            Init(gd_g,gr_g);
            bossstage=bossstage_i;
            spellcardid=spellcardid_i;
            overlimit=0;
            Point=200;
            _3dpraticle=new _3DPraticleManager();
            thread=new Thread(new ParameterizedThreadStart(this.Load));
            thread.Priority=ThreadPriority.Highest;
            thread.Start((object)this.gd);
        }

        private void Init(GraphicsDevice gd_g,GameResource gr_g) {
            this.gd=gd_g;
            this.gr=gr_g;
            this.bgcolor=new Colors(1f,1f,1f,1f);
            if(!Music.BGMContaining)
                Music.BGM.Dispose();
            Music.BGMvolume=int.Parse(Main.ini.ReadValue("Sound","BGM"));
            Sound.SEvolume=int.Parse(Main.ini.ReadValue("Sound","SE"));
            if(!this.gr.ok)
                this.gr.bless=new Sprite(Texture2D.FromFile(this.gd,Cry.Decry("Content/Graphics/Info/bless.xna",0)));
            this.gr.bless.position=new Vector2(450f,420f);
            PraticleManager.Clear();
            this.praticle=new Praticle(false,true,new Rectangle(0,0,28,28),new Vector4(520f,407f,100f,40f),new Vector2(14f,14f),15,0,80,1f,0.02f,new Vector2(180f,0.0f),20f);
            this.praticle.scale=new Vector4(1f,0.5f,0.0f,0.0f);
            if(!this.gr.ok)
                return;
            this.praticle.stop=true;
        }

        private void Dispose() {
            PraticleManager.Clear();
            Program.game.game.StopSound("Result bank");
            SelfBarrageManager.Dispose();
            if(Main.SpecialMode==Modes.SPELLCARD&&!Main.Replay)
                Main.SkiptoSCChanllenges=true;
            if(Main.stagecheck!="ENTRANCE")
                Music.BGMContaining=false;
            if(!Music.BGMContaining)
                Music.BGM.Dispose();
            this._3dpraticle.Dispose();
            Bonus.Dispose();
            this.Drawevents=(Game.DrawDelegate)null;
            this.DrawJudge=(Game.DrawDelegate2)null;
            this.Drawevents2=(Game.DrawDelegate3)null;
            if(Main.Replay||Main.SpecialMode==Modes.SPELLCARD)
                return;
            this.SavePlayData(this.playdata);
            this.SavePracticeData(this.practicedata);
        }

        private void Load(object obj) {
            try {
                GraphicsDevice graphicsDevice = (GraphicsDevice)obj;
                this.renderTarget=new RenderTarget2D(graphicsDevice,640,480,1,graphicsDevice.DisplayMode.Format,graphicsDevice.PresentationParameters.MultiSampleType,graphicsDevice.PresentationParameters.MultiSampleQuality);
                if(Main.SpecialMode!=Modes.SPELLCARD) {
                    this.playdata=this.LoadPlayData();
                    this.practicedata=this.LoadPracticeData();
                    if(Main.Mode==Modes.SINGLE&&Main.SpecialMode!=Modes.PRACTICE) {
                        if(this.playdata.players[(int)(Main.Character-1)].ranks[(int)(Main.Level-1)].data[0]!=null)
                            this.HiScore=this.playdata.players[(int)(Main.Character-1)].ranks[(int)(Main.Level-1)].data[0].score;
                    } else if(Main.SpecialMode==Modes.PRACTICE)
                        this.HiScore=this.practicedata.data[(int)(Main.Character-1)][(int)(Main.Level-1)].score[this.gamestage-1];
                    if(Main.Mode==Modes.SINGLE&&this.gamestage>this.practicedata.clearstate[(int)(Main.Character-1)][(int)(Main.Level-1)])
                        this.practicedata.clearstate[(int)(Main.Character-1)][(int)(Main.Level-1)]=this.gamestage;
                } else
                    this.HiScore=this.LoadSpecialData().spe[(int)(Main.Character-1)].sc[this.spellcardid].score;
                if(!this.gr.ok)
                    this.gr.black=new Sprite(Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\Black\\0.xna",0)));
                this.gr.black.color.a=1f;
                if(!this.gr.ok)
                    this.gr.grazebox=new Sprite(Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\UI\\grazebox.xna",0)));
                this.Special=new SpecialSystem(this.gr.grazebox);
                Special.Power=SourseForm.specialPower;
                if(!this.gr.ok)
                    this.gr.fan=new Sprite(Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\Pattern\\fan.xna",0)));
                this.gr.fan.color.a=0.0f;
                this.gr.fan.origin=new Vector2(144f,163f);
                this.gr.fan.position=new Vector2(68f,413f);
                this.gr.fan.rotation=120f;
                if(!this.gr.ok)
                    this.gr.pausetitle=new Sprite(Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\Info\\pause.xna",0)));
                this.gr.pausetitle.color.a=0.0f;
                if(!this.gr.ok)
                    this.gr.gameovertitle=new Sprite(Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\Info\\gameover.xna",0)));
                this.gr.gameovertitle.color.a=0.0f;
                if(!this.gr.ok)
                    this.gr.replaytitle=new Sprite(Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\Info\\replayend.xna",0)));
                this.gr.replaytitle.color.a=0.0f;
                this.gr.replaytitle.position=new Vector2(16f,278f);
                if(!this.gr.ok) {
                    this.gr.button=new Sprite[5];
                    this.gr.buttonon=new Sprite[5];
                    this.gr.choose=new Sprite[2];
                }
                for(int index = 1;index<=5;++index) {
                    if(!this.gr.ok) {
                        this.gr.button[index-1]=new Sprite(Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\Button\\pause"+index.ToString()+".xna",0)));
                        this.gr.buttonon[index-1]=new Sprite(Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\Button\\pause"+index.ToString()+"on.xna",0)));
                    }
                    if(index!=5) {
                        this.gr.button[index-1].position=new Vector2(44f,(float)(319+(index-1)*30));
                        this.gr.buttonon[index-1].position=this.gr.button[index-1].position;
                    } else {
                        this.gr.button[index-1].position=new Vector2(44f,319f);
                        this.gr.buttonon[index-1].position=this.gr.button[index-1].position;
                    }
                    this.gr.button[index-1].color.a=0.0f;
                    this.gr.buttonon[index-1].color.a=0.0f;
                }
                if(!this.gr.ok)
                    this.gr.choose[0]=new Sprite(Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\Button\\choose1.xna",0)));
                this.gr.choose[0].color.a=0.0f;
                this.gr.choose[0].position.X=64f;
                if(!this.gr.ok)
                    this.gr.choose[1]=new Sprite(Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\Button\\choose2.xna",0)));
                this.gr.choose[1].color.a=0.0f;
                this.gr.choose[1].position.X=64f;
                if(Main.Mode==Modes.SINGLE) {
                    if(!this.gr.ok) {
                        this.gr.ui=new Sprite(Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\UI\\single.xna",0)));
                        this.gr.dicolty=new Sprite(Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\List\\dicolty.xna",0)));
                    }
                    this.gr.dicolty.rect=new Rectangle(0,(int)(Main.Level-1)*17,118,17);
                    this.gr.dicolty.position=new Vector2(474f,-30f);
                    this.gr.number=Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\List\\number.xna",0));
                    this.gr.numlogo=Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\List\\numlogo.xna",0));
                } else {
                    int mode = (int)Main.Mode;
                }
                if(!this.gr.ok) {
                    this.gr.actor=new Sprite(Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\List\\actor.xna",0)));
                    this.gr.judge=new Sprite(Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\Pattern\\judge.xna",0)));
                }
                EquipShoot.Init();
                if(!this.gr.ok) {
                    this.gr.selfbarrage=Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\List\\selfbarrage.xna",0));
                    this.gr.enemys=Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\List\\enemys.xna",0));
                }
                this.enemym=new EnemyManager(this.gr.enemys);
                StreamReader streamReader1 = new StreamReader(Cry.Decry("Content\\Data\\0.xna",2));
                this.gr.enemyset=new List<float[]>();
                for(string str = streamReader1.ReadLine();str!=null;str=streamReader1.ReadLine()) {
                    float[] numArray = new float[13];
                    for(int index = 0;index<12;++index) {
                        numArray[index]=0.0f;
                        numArray[index]=float.Parse(str.Split(',')[index]);
                    }
                    if(str.Split(',').Length>=13)
                        numArray[12]=float.Parse(str.Split(',')[12]);
                    this.gr.enemyset.Add(numArray);
                }
                streamReader1.Close();
                if(!this.gr.ok) {
                    this.gr.bosslist=Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\List\\bosslist.xna",0));
                    this.gr.bosses=Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\List\\bosses.xna",0));
                    this.gr.bossimage=new Hashtable();
                    this.gr.bossdimage=new Hashtable();
                    for(int index1 = 1;index1<=7;++index1) {
                        for(int index2 = 2;File.Exists("Content\\Graphics\\Character\\a"+index1.ToString()+index2.ToString()+".xna");++index2)
                            this.gr.bossimage.Add((object)(index1.ToString()+index2.ToString()),(object)Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\Character\\a"+index1.ToString()+index2.ToString()+".xna",0)));
                    }
                }
                StreamReader streamReader2 = new StreamReader(Cry.Decry("Content\\Data\\1.xna",2));
                this.gr.bossset=new List<float[]>();
                for(string str = streamReader2.ReadLine();str!=null;str=streamReader2.ReadLine()) {
                    float[] numArray = new float[11];
                    for(int index = 0;index<11;++index)
                        numArray[index]=float.Parse(str.Split(',')[index]);
                    this.gr.bossset.Add(numArray);
                }
                streamReader2.Close();
                Dialog.Init();
                if(!this.gr.ok) {
                    this.gr.dialog=new Sprite(Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\UI\\dialog.xna",0)));
                    this.gr.dialogn=new Sprite(Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\Info\\dialogn.xna",0)));
                    this.gr.dm=new Sprite(Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\Character\\dm"+((int)(Main.Character-1)).ToString()+".xna",0)));
                    this.gr.db=new Sprite[7];
                    for(int index = 1;index<=7;++index)
                        this.gr.db[index-1]=new Sprite(Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\Character\\db"+index.ToString()+".xna",0)));
                    this.gr.words=Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\Info\\words.xna",0));
                    this.gr.items=Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\Pattern\\items.xna",0));
                    this.gr.bgm=Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\Info\\bgm.xna",0));
                }
                this.gr.backgc=new Hashtable();
                StreamReader streamReader3;
                if(Main.SpecialMode!=Modes.SPELLCARD) {
                    streamReader3=new StreamReader(Cry.Decry("Content\\Data\\"+this.gamestage.ToString()+"1.xna",2));
                    this.gr.backgc.Add((object)(this.gamestage.ToString()+"1"),(object)streamReader3);
                } else {
                    streamReader3=new StreamReader(Cry.Decry("Content\\Data\\"+(this.bossstage/10).ToString()+"1.xna",2));
                    this.gr.backgc.Add((object)((this.bossstage/10).ToString()+"1"),(object)streamReader3);
                }
                string str1 = streamReader3.ReadLine()??"";
                if(!this.gr.ok) {
                    this.gr.modelc=new Hashtable();
                    if(str1.Contains("UsingModel")) {
                        string[] strArray = str1.Split('(')[1].Split(')')[0].Split(',');
                        for(int index = 0;index<strArray.Length;++index)
                            this.gr.modelc.Add((object)strArray[index],(object)Program.game.GetCM().Load<Model>(strArray[index]));
                    }
                }
                if(!this.gr.ok) {
                    this.gr.bgmist=new Sprite(Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\Pattern\\bgmist.xna",0)));
                    this.gr.bgmist.color.a=1f;
                    this.gr.bossgc=new Hashtable();
                    StreamReader streamReader4 = new StreamReader(Cry.Decry("Content\\Data\\2.xna",2));
                    if(Main.SpecialMode!=Modes.SPELLCARD) {
                        for(int index = 0;index<this.gamestage-1;++index)
                            streamReader4.ReadLine();
                    } else {
                        for(int index = 0;index<this.bossstage/10-1;++index)
                            streamReader4.ReadLine();
                    }
                    string[] strArray = new string[0];
                    string str2 = streamReader4.ReadLine();
                    if(str2!=null)
                        strArray=str2.Split(',');
                    for(int index = 0;index<strArray.Length;++index)
                        this.gr.bossgc.Add((object)strArray[index].ToString(),(object)Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\Black\\"+strArray[index].ToString()+".xna",0)));
                    streamReader4.Dispose();
                }
                if(Main.SpecialMode!=Modes.SPELLCARD) {
                    this.gr.bossgjs=new Hashtable();
                    int num = 2;
                    StreamReader streamReader4 = (StreamReader)null;
                    for(;File.Exists("Content\\Data\\"+this.gamestage.ToString()+num.ToString()+".xna");++num) {
                        List<string> stringList = new List<string>();
                        streamReader4=new StreamReader(Cry.Decry("Content\\Data\\"+this.gamestage.ToString()+num.ToString()+".xna",2));
                        for(string str2 = streamReader4.ReadLine();str2!=null;str2=streamReader4.ReadLine())
                            stringList.Add(str2);
                        this.gr.bossgjs.Add((object)num.ToString(),(object)stringList);
                    }
                    streamReader4?.Dispose();
                } else {
                    this.gr.bossgjs=new Hashtable();
                    List<string> stringList = new List<string>();
                    StreamReader streamReader4 = new StreamReader(Cry.Decry("Content\\Data\\"+this.bossstage.ToString()+".xna",2));
                    for(string str2 = streamReader4.ReadLine();str2!=null;str2=streamReader4.ReadLine())
                        stringList.Add(str2);
                    this.gr.bossgjs.Add((object)this.spellcardid.ToString(),(object)stringList);
                }
                if(Main.SpecialMode!=Modes.SPELLCARD) {
                    this.gr.stagec=new Hashtable();
                    StreamReader streamReader4 = new StreamReader(Cry.Decry("Content\\Data\\"+this.gamestage.ToString()+"0"+((int)Main.Level).ToString()+".xna",2));
                    this.gr.stagec.Add((object)(this.gamestage.ToString()+"0"+((int)Main.Level).ToString()),(object)streamReader4);
                } else {
                    this.gr.stagec=new Hashtable();
                    this.gr.stagec.Add((object)this.spellcardid.ToString(),(object)new StreamReader(Cry.Decry("Content\\Data\\sc"+this.bossstage.ToString()+this.spellcardid.ToString()+".xna",2)));
                }
                if(!this.gr.ok) {
                    this.gr.barrages=Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\Pattern\\barrages.xna",0));
                    this.gr.mist=Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\Pattern\\mist.xna",0));
                    this.gr.dis=Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\Pattern\\dis.xna",0));
                    this.gr.spellcard=new Hashtable[6];
                    for(int index1 = 1;index1<=6;++index1) {
                        this.gr.spellcard[index1-1]=new Hashtable();
                        StreamReader streamReader4 = new StreamReader(Cry.Decry("Content\\Data\\s"+index1.ToString()+".xna",2));
                        for(string str2 = streamReader4.ReadLine();str2!=null;str2=streamReader4.ReadLine()) {
                            string[] strArray = str2.Split(' ');
                            string str3 = "";
                            for(int index2 = 1;index2<strArray.Length;++index2) {
                                str3+=strArray[index2];
                                if(index2!=strArray.Length-1)
                                    str3+=" ";
                            }
                            this.gr.spellcard[index1-1].Add((object)strArray[0],(object)str3);
                        }
                    }
                }
                Effects.Init();
                if(!this.gr.ok) {
                    this.gr.blur=Program.game.GetCM().Load<Effect>("000");
                    this.gr.force=Program.game.GetCM().Load<Effect>("001");
                }
                if(!this.gr.ok)
                    this.gr.stagetitle=new Sprite(Texture2D.FromFile(graphicsDevice,Cry.Decry("Content\\Graphics\\Info\\stagetitle.xna",0)));
                this.stm=Main.SpecialMode==Modes.SPELLCARD ? new StageManager(StageType.SPELLCARD,this.gr.enemys,this.gr.force,this._3dpraticle,this.bossstage/10,this.spellcardid) : new StageManager(StageType.SINGLE,this.gamestage,this.gr.enemys,this.gr.force,this._3dpraticle);
                this.stm.Texture(this.gr.bgm,this.gr.black,this.gr.modelc,this.gr.bossgc,this.gr.stagetitle,this.gr.bosses,this.gr.bosslist,this.gr.items,this.gr.dialog,this.gr.dm,this.gr.db,this.gr.dialogn,this.gr.words,this.gr.bossimage,this.gr.bossdimage,this.gr.bgmist);
                this.Stgdata=new StageData();
                this.stm.Data(this.gr.enemyset,this.gr.bossset,this.gr.stagec,this.gr.backgc,this.gr.spellcard,this.gr.bossgjs,this.Stgdata);
                this.csm=new CSManager(this.gr.barrages,this.gr.mist,this.gr.dis);
                this.gr.Playersave=new Sprite();
                Character character = new Character(this.gr.Playersave);
                character.body.position.X=317f;
                character.body.position.Y=407f;
                if(!Main.gameseed.HasValue)
                    Main.gameseed=new int?(Main.Chaos_GetRandomSeed());
                Main.SetRandSeed(Main.gameseed.Value);
                this.gr.barragec=new Hashtable();
                if(Main.SpecialMode!=Modes.SPELLCARD) {
                    if(this.stm.Codes!=null) {
                        foreach(Code code in this.stm.Codes) {
                            if(code.Text.Contains("SetEnemy(")) {
                                string str2 = this.gamestage.ToString()+code.Text.Split('(')[1].Split(')')[0].Split(',')[7];
                                if(str2!=this.gamestage.ToString()+"-1"&&!this.gr.barragec.ContainsKey((object)str2))
                                    this.gr.barragec.Add((object)str2,(object)new CrazyStorm(graphicsDevice,this.csm,false,"b"+str2,character.body.position));
                            } else if(code.Text.Contains("SetBossCard(")) {
                                string str2 = this.gamestage.ToString()+code.Text.Split('(')[1].Split(')')[0].Split(',')[1];
                                if(str2!=this.gamestage.ToString()+"-1"&&!this.gr.barragec.ContainsKey((object)str2))
                                    this.gr.barragec.Add((object)str2,(object)new CrazyStorm(graphicsDevice,this.csm,false,"b"+str2,character.body.position));
                            }
                        }
                    }
                } else
                    this.gr.barragec.Add((object)this.spellcardid.ToString(),(object)new CrazyStorm(graphicsDevice,this.csm,false,"bsc"+this.spellcardid.ToString(),character.body.position));
                if(!this.gr.ok) {
                    this.gr.effectc=new Hashtable();
                    for(int index = 0;File.Exists("Content\\Data\\e"+index.ToString()+".xna");++index)
                        this.gr.effectc.Add((object)index.ToString(),(object)new CrazyStorm(graphicsDevice,this.csm,false,"e"+index.ToString(),character.body.position));
                    this.gr.effectc.Add((object)"bg",(object)new CrazyStorm(graphicsDevice,this.csm,true,"bg",new Vector2(315f,240f)));
                } else {
                    foreach(CrazyStorm crazyStorm in (IEnumerable)this.gr.effectc.Values)
                        crazyStorm.SetCsm(this.csm);
                }
                CrazyStorm crazyStorm1 = this.PlayEffect(true,"0",new Vector2(640f,490f));
                crazyStorm1.BanSound(true);
                crazyStorm1.effect=true;
                this.gr.ok=true;
                GC.Collect();
            } catch(Exception ex) {
                StreamWriter streamWriter = new StreamWriter("Error.txt");
                DateTime now = DateTime.Now;
                streamWriter.Write("["+now.Hour.ToString("00")+":"+now.Minute.ToString("00")+":"+now.Second.ToString("00")+"]\n"+ex.ToString());
                streamWriter.Close();
                Main.Error(ex.ToString());
            }
        }

        private void Load2(object obj) {
            try {
                Load2Trans load2Trans = (Load2Trans)obj;
                if(Main.Mode==Modes.SINGLE&&load2Trans.stage>this.practicedata.clearstate[(int)(Main.Character-1)][(int)(Main.Level-1)])
                    this.practicedata.clearstate[(int)(Main.Character-1)][(int)(Main.Level-1)]=load2Trans.stage;
                this.gr.backgc=new Hashtable();
                StreamReader streamReader1 = new StreamReader(Cry.Decry("Content\\Data\\"+load2Trans.stage.ToString()+"1.xna",2));
                this.gr.backgc.Add((object)(load2Trans.stage.ToString()+"1"),(object)streamReader1);
                string[] strArray1 = streamReader1.ReadLine().Split('(')[1].Split(')')[0].Split(',');
                for(int index = 0;index<strArray1.Length;++index) {
                    if(!this.gr.modelc.ContainsKey((object)strArray1[index]))
                        this.gr.modelc.Add((object)strArray1[index],(object)Program.game.GetCM().Load<Model>(strArray1[index]));
                    else
                        this.gr.modelc[(object)strArray1[index]]=(object)Program.game.GetCM().Load<Model>(strArray1[index]);
                }
                StreamReader streamReader2 = new StreamReader(Cry.Decry("Content\\Data\\2.xna",2));
                for(int index = 0;index<load2Trans.stage-1;++index)
                    streamReader2.ReadLine();
                string[] strArray2 = new string[0];
                string str1 = streamReader2.ReadLine();
                if(str1!=null)
                    strArray2=str1.Split(',');
                for(int index = 0;index<strArray2.Length;++index) {
                    if(!this.gr.bossgc.ContainsKey((object)strArray2[index].ToString()))
                        this.gr.bossgc.Add((object)strArray2[index].ToString(),(object)Texture2D.FromFile(this.gd,Cry.Decry("Content\\Graphics\\Black\\"+strArray2[index].ToString()+".xna",0)));
                }
                streamReader2.Close();
                this.gr.bossgjs=new Hashtable();
                int num = 2;
                StreamReader streamReader3 = (StreamReader)null;
                for(;File.Exists("Content\\Data\\"+load2Trans.stage.ToString()+num.ToString()+".xna");++num) {
                    List<string> stringList = new List<string>();
                    streamReader3=new StreamReader(Cry.Decry("Content\\Data\\"+load2Trans.stage.ToString()+num.ToString()+".xna",2));
                    for(string str2 = streamReader3.ReadLine();str2!=null;str2=streamReader3.ReadLine())
                        stringList.Add(str2);
                    this.gr.bossgjs.Add((object)num.ToString(),(object)stringList);
                }
                streamReader3?.Close();
                this.gr.stagec=new Hashtable();
                StreamReader streamReader4 = new StreamReader(Cry.Decry("Content\\Data\\"+load2Trans.stage.ToString()+"0"+((int)Main.Level).ToString()+".xna",2));
                this.gr.stagec.Add((object)(load2Trans.stage.ToString()+"0"+((int)Main.Level).ToString()),(object)streamReader4);
                this.gr.Playersave=new Sprite();
                Character character = new Character(this.gr.Playersave);
                character.body.position.X=317f;
                character.body.position.Y=407f;
                this.Stgdata=new StageData();
                this.stm.Data(this.gr.bossgjs,this.gr.stagec,this.gr.backgc,this.gr.spellcard,this.gr.modelc,this.Stgdata);
                Main.SetRandSeed(Main.gameseed.Value);
                this.gr.barragec=new Hashtable();
                if(this.stm.Codes!=null) {
                    foreach(Code code in this.stm.Codes) {
                        if(code.Text.Contains("SetEnemy(")) {
                            string str2 = load2Trans.stage.ToString()+code.Text.Split('(')[1].Split(')')[0].Split(',')[7];
                            if(str2!=load2Trans.stage.ToString()+"-1"&&!this.gr.barragec.ContainsKey((object)str2))
                                this.gr.barragec.Add((object)str2,(object)new CrazyStorm(this.gd,this.csm,false,"b"+str2,character.body.position));
                        } else if(code.Text.Contains("SetBossCard(")) {
                            string str2 = load2Trans.stage.ToString()+code.Text.Split('(')[1].Split(')')[0].Split(',')[1];
                            if(str2!=load2Trans.stage.ToString()+"-1"&&!this.gr.barragec.ContainsKey((object)str2))
                                this.gr.barragec.Add((object)str2,(object)new CrazyStorm(this.gd,this.csm,false,"b"+str2,character.body.position));
                        }
                    }
                }
                BGM.Disposes();
                Music.BGMvolume=Music.Savevolume;
                load2Trans.ld.Ready=true;
                GC.Collect();
            } catch(Exception ex) {
                StreamWriter streamWriter = new StreamWriter("Error.txt");
                DateTime now = DateTime.Now;
                streamWriter.Write("["+now.Hour.ToString("00")+":"+now.Minute.ToString("00")+":"+now.Second.ToString("00")+"]\n"+ex.ToString());
                streamWriter.Close();
                Main.Error(ex.ToString());
            }
        }

        public void LoadNewStage(GraphicsDevice gd,int stage,LoadReady ld) {
            Program.game.game.SpecialSystemReset();
            Load2Trans load2Trans = new Load2Trans();
            load2Trans.ld=ld;
            load2Trans.stage=stage;
            load2Trans.g=gd;
            this.thread=new Thread(new ParameterizedThreadStart(this.Load2));
            this.thread.Priority=ThreadPriority.Highest;
            this.thread.Start((object)load2Trans);
        }

        private PlayData LoadPlayData() {
            Stream serializationStream = Cry.Decry("Content\\Data\\4.xna",2);
            PlayData playData = (PlayData)new BinaryFormatter().Deserialize(serializationStream);
            serializationStream.Close();
            return playData;
        }

        private void SavePlayData(PlayData data) {
            FileStream fileStream = new FileStream("Content\\Data\\4.xna",FileMode.Create);
            new BinaryFormatter().Serialize((Stream)fileStream,(object)data);
            fileStream.Close();
            Cry.Encry("Content\\Data\\4.xna",2);
        }

        private PracticeData LoadPracticeData() {
            Stream serializationStream = Cry.Decry("Content\\Data\\5.xna",2);
            PracticeData practiceData = (PracticeData)new BinaryFormatter().Deserialize(serializationStream);
            serializationStream.Close();
            return practiceData;
        }

        private void SavePracticeData(PracticeData data) {
            FileStream fileStream = new FileStream("Content\\Data\\5.xna",FileMode.Create);
            new BinaryFormatter().Serialize((Stream)fileStream,(object)data);
            fileStream.Close();
            Cry.Encry("Content\\Data\\5.xna",2);
        }

        public SpecialData LoadSpecialData() {
            Stream serializationStream = Cry.Decry("Content\\Data\\8.xna",2);
            SpecialData specialData = (SpecialData)new BinaryFormatter().Deserialize(serializationStream);
            serializationStream.Close();
            return specialData;
        }

        public void SaveSpecialData(SpecialData data) {
            FileStream fileStream = new FileStream("Content\\Data\\8.xna",FileMode.Create);
            new BinaryFormatter().Serialize((Stream)fileStream,(object)data);
            fileStream.Close();
            Cry.Encry("Content\\Data\\8.xna",2);
        }

        public void Quake(int time,int strength) {
            if(this.quaketime!=0)
                return;
            this.quaketime=1;
            this.quaketotal=time;
            this.quakestrength=strength;
        }

        public void PlaySound(string k,bool apply3d,float position) {
            this.sound.Play(k,apply3d,position);
        }

        public void StopSound(string k) {
            this.sound.Stop(k);
        }

        public void PauseSound() {
            this.sound.Pause();
        }

        public void ResumeSound() {
            this.sound.Resume();
        }

        public CrazyStorm PlayEffect(bool add,string id,Vector2 p) {
            CrazyStorm crazyStorm = this.csm.Createnew(add,id,this.gr.effectc);
            crazyStorm.SetPos(p,false);
            crazyStorm.Start();
            return crazyStorm;
        }

        public CrazyStorm FindEffect(string id) {
            return this.csm.Find(id);
        }

        public Texture2D Getex(string id) {
            switch(id) {
                case "bosslist":
                    return this.gr.bosslist;
                case "items":
                    return this.gr.items;
                default:
                    return (Texture2D)null;
            }
        }

        public void ClearSth(string id) {
            switch(id) {
                case "Enemy":
                    this.enemym.Clear();
                    break;
            }
        }

        public void DeathProcess() {
            this.Special.Return();
            this.GameOver=true;
            ++this.overtime;
            this.Pause=true;
            this.PauseSound();
            this.time3=0;
            this.time5=16;
            this.gr.fan.rotation=120f;
            if(!Main.Replay&&Main.SpecialMode!=Modes.PRACTICE&&this.overtime<this.overlimit)
                return;
            this.selection=2;
        }

        public void DeathItem() {
            ItemManager itemManager = new ItemManager(this.stm.itemm,this.gr.items,0.0f,0.0f,0.0f,9f,0.0f,0.0f);
            if(this.stm.itemm==null)
                this.stm.itemm=new List<ItemManager>();
            this.TransItemm(this.stm.itemm);
            this.stm.itemm.Add(itemManager);
            itemManager.DeathShoot(this.Actor.body.position);
            this.Point-=50;
            if(this.Point>0)
                return;
            this.Point=0;
        }

        public void BonusItem(int life,int bomb) {
            ItemManager itemManager = new ItemManager(this.stm.itemm,this.gr.items,0.0f,0.0f,0.0f,0.0f,(float)life,(float)bomb);
            if(this.stm.itemm==null)
                this.stm.itemm=new List<ItemManager>();
            this.TransItemm(this.stm.itemm);
            this.stm.itemm.Add(itemManager);
            Program.game.game.PlaySound("bonus",true,this.Actor.body.position.X);
            itemManager.Shoot(new Vector2(this.Actor.body.position.X,this.Actor.body.position.Y-60f),0.0f,this.Actor,(Boss)null);
        }

        public void SpecialSystemReset() {
            this.Special.Clear();
        }

        public void SmallItem(Vector2 pos) {
            ItemManager itemManager = new ItemManager(this.stm.itemm,this.gr.items);
            this.stm.itemm.Add(itemManager);
            itemManager.SmallShoot(pos);
        }

        public void BanShoot(bool b) {
            this.Actor.Ban=b;
        }

        public void AddStgData(int miss,int bomb,int kill) {
            this.Stgdata.miss+=miss;
            this.Stgdata.bomb+=bomb;
            if(kill==0)
                return;
            this.Special.Add();
        }

        public void TransItemm(List<ItemManager> itemm) {
            this.Actor.SetItemm(itemm);
        }

        public void ControlPause() {
            if(this.time2<=120||this.Pause)
                return;
            this.Pause=true;
            this.PauseSound();
            this.time3=0;
            this.time5=16;
            this.gr.fan.rotation=120f;
            this.selection=1;
        }

        public void SUpdate() {
            if(this.thread.ThreadState!=ThreadState.Stopped) {
                if(!this.gr.ok) {
                    ++this.time;
                    if(this.time<=20)
                        this.gr.bless.color.a+=0.05f;
                    if(this.time>30&this.time<=50)
                        this.gr.bless.color.a-=0.05f;
                    if(this.time==50)
                        this.time=0;
                }
            } else {
                if((double)this.gr.bless.color.a>0.0) {
                    this.gr.bless.color.a-=0.025f;
                    if((double)this.gr.bless.color.a<=0.0)
                        this.gr.bless.color.a=0.0f;
                }
                if(this.time2==0) {
                    this.praticle.stop=true;
                    if(this.gr.ok)
                        this.time2=39;
                }
                if(this.time2==40) {
                    this.stage="READY";
                    this.Actor=new Character(this.gr.actor,this.gr.judge,this.gr.selfbarrage,this.gr.items,Main.Character,Characters.attribute[(int)(Main.Character-1)],Characters.attribute[(int)(Main.Character-1+4)]);
                }
                if(this.time2>40&this.time2<=80) {
                    this.gr.actor.color.a+=0.05f;
                    this.gr.ui.color.a+=0.05f;
                    this.gr.grazebox.color.a+=0.025f;
                }
                if(this.time2==80) {
                    if(!Main.Replay&&Main.SpecialMode!=Modes.SPELLCARD)
                        Program.game.achivmanager.Check(AchievementType.Normal,1,(Hashtable)null);
                    Program.game.achivmanager.Check(AchievementType.Hidden,3,new Hashtable() {
                        [(object)"reset"]=(object)null
                    });
                    this.stage="START";
                    this.praticle.Delete();
                    if(!Main.Replay&&Main.SpecialMode!=Modes.SPELLCARD) {
                        ++this.playdata.players[(int)(Main.Character-1)].playtime;
                        Program.game.achivmanager.Check(AchievementType.Hidden,0,new Hashtable() {
                            [(object)"playdata"]=(object)this.playdata
                        });
                    }
                }
                if(this.time2>80) {
                    if(this.Score>=this.HiScore)
                        this.HiScore=this.Score;
                    if(Main.SpecialMode!=Modes.SPELLCARD) {
                        if(this.time2>100)
                            this.gr.dicolty.position.Y=(float)(((double)this.gr.dicolty.position.Y*9.0+13.0)/10.0);
                        if(this.time2>100&&this.time2<=120)
                            this.gr.dicolty.color.a+=0.05f;
                    }
                    if(this.time2>120)
                        this.time2=121;
                    if(!this.Pause&&!this.Finished) {
                        int num = 1;
                        Program.game.achivmanager.Check(AchievementType.Challenge,4,new Hashtable() {
                            [(object)"level"]=(object)Main.Level,
                            [(object)"score"]=(object)this.Score
                        });
                        Program.game.achivmanager.Check(AchievementType.Challenge,10,new Hashtable() {
                            [(object)"position"]=(object)this.Actor.Position(),
                            [(object)"count"]=(object)this.csm.BarrageCount
                        });
                        Program.game.achivmanager.Check(AchievementType.Hidden,4,new Hashtable() {
                            [(object)"graze"]=(object)this.Graze
                        });
                        for(int index = 0;index<num;++index) {
                            if(this.quaketime>=1) {
                                if(this.quaketime==1+this.quakeadd)
                                    this.quake=new Vector2((float)-this.quakestrength,0.0f);
                                else if(this.quaketime==2+this.quakeadd)
                                    this.quake=new Vector2(0.0f,(float)this.quakestrength);
                                else if(this.quaketime==3+this.quakeadd)
                                    this.quake=new Vector2(0.0f,(float)-this.quakestrength);
                                else if(this.quaketime==4+this.quakeadd)
                                    this.quake=new Vector2((float)this.quakestrength,0.0f);
                                else if(this.quaketime==5+this.quakeadd)
                                    this.quake=new Vector2((float)-this.quakestrength,(float)this.quakestrength);
                                else if(this.quaketime==6+this.quakeadd)
                                    this.quake=new Vector2((float)this.quakestrength,(float)-this.quakestrength);
                                else if(this.quaketime==7+this.quakeadd)
                                    this.quake=new Vector2((float)-this.quakestrength,(float)-this.quakestrength);
                                else if(this.quaketime==8+this.quakeadd)
                                    this.quake=new Vector2((float)this.quakestrength,(float)this.quakestrength);
                                ++this.quaketime;
                                if(this.quaketime%9==0)
                                    this.quakeadd+=9;
                                if(this.quaketime>=this.quaketotal) {
                                    this.quaketime=0;
                                    this.quakeadd=0;
                                    this.quake=Vector2.Zero;
                                }
                            }
                            this.stm.Update(this.enemym,this.csm,this.gr.barragec,this.Actor);
                            this.Actor.Update(this.csm,this.enemym,this.stm.GetBoss());
                            this.csm.Update(this.Actor,this.enemym,this.stm.boss);
                            Bonus.Updates();
                            Stageclear.Updates();
                            this.Special.Update(this.stm.GetBoss(),this.Actor);
                            PraticleManager.Update();
                        }
                    }
                    if(!this.Pause&&!this.stm.RecordPause) {
                        this.stopblur=false;
                        if(this.time3>0&this.time3<=60) {
                            for(int index = 0;index<2;++index) {
                                this.gr.choose[index].color.a-=0.07f;
                                if((double)this.gr.choose[index].color.a<=0.0)
                                    this.gr.choose[index].color.a=0.0f;
                            }
                            this.gr.fan.color.a-=0.05f;
                            if((double)this.gr.fan.color.a<=0.0)
                                this.gr.fan.color.a=0.0f;
                            this.gr.fan.rotation=(float)(((double)this.gr.fan.rotation*9.0-120.0)/10.0);
                            if(this.time3<=15) {
                                this.gr.pausetitle.position.X-=2f;
                                this.gr.pausetitle.color.a-=0.07f;
                                if((double)this.gr.pausetitle.color.a<=0.0)
                                    this.gr.pausetitle.color.a=0.0f;
                                this.gr.gameovertitle.position.X-=2f;
                                this.gr.gameovertitle.color.a-=0.07f;
                                if((double)this.gr.gameovertitle.color.a<=0.0)
                                    this.gr.gameovertitle.color.a=0.0f;
                            }
                            if(this.time3>5&&this.time3<=20) {
                                this.gr.button[4].position.X-=2f;
                                this.gr.buttonon[4].position.X-=2f;
                                this.gr.button[4].color.a-=0.07f;
                                if((double)this.gr.button[4].color.a<=0.0)
                                    this.gr.button[4].color.a=0.0f;
                                this.gr.buttonon[4].color.a-=0.07f;
                                if((double)this.gr.buttonon[4].color.a<=0.0)
                                    this.gr.buttonon[4].color.a=0.0f;
                                this.gr.button[0].position.X-=2f;
                                this.gr.buttonon[0].position.X-=2f;
                                this.gr.button[0].color.a-=0.07f;
                                if((double)this.gr.button[0].color.a<=0.0)
                                    this.gr.button[0].color.a=0.0f;
                                this.gr.buttonon[0].color.a-=0.07f;
                                if((double)this.gr.buttonon[0].color.a<=0.0)
                                    this.gr.buttonon[0].color.a=0.0f;
                            }
                            for(int index = 1;index<4;++index) {
                                if(this.time3>5+index*5&this.time3<=20+index*5) {
                                    this.gr.button[index].position.X-=2f;
                                    this.gr.buttonon[index].position.X-=2f;
                                    this.gr.button[index].color.a-=0.07f;
                                    if((double)this.gr.button[index].color.a<=0.0)
                                        this.gr.button[index].color.a=0.0f;
                                    this.gr.buttonon[index].color.a-=0.07f;
                                    if((double)this.gr.buttonon[index].color.a<=0.0)
                                        this.gr.buttonon[index].color.a=0.0f;
                                }
                            }
                        }
                        if(((this.time2>120 ? 1 : 0)&(Main.keyboardstat.IsKeyDown(Keys.Escape)&Main.keyboardstat!=Main.prekeyboard ? 1 : (PadState.IsKeyPressed(JOYKEYS.Pause,Main.prepadstat) ? 1 : 0))&(!this.BanPause ? 1 : 0))!=0) {
                            if(Main.keyboardstat.IsKeyDown(Keys.Z)||PadState.IsKeyDown(JOYKEYS.Confirm)) {
                                this.PlaySound("invalid",false,0.0f);
                            } else {
                                this.Pause=true;
                                this.PauseSound();
                                this.time3=0;
                                this.time5=16;
                                this.gr.fan.rotation=120f;
                                this.selection=1;
                                this.PlaySound("pause",false,0.0f);
                            }
                        }
                        ++this.time3;
                        if(this.time3>60)
                            this.time3=61;
                    } else if(!this.stm.RecordPause) {
                        if(this.time3==1&&!this.waitforsave) {
                            if(Main.Replay)
                                this.banrecord=true;
                            this.gr.pausetitle.position=new Vector2(16f,278f);
                            this.gr.gameovertitle.position=new Vector2(16f,278f);
                            this.Actor.Ban=true;
                            if(!Music.BGM.IsDisposed&&!Music.BGMContaining)
                                Music.BGM.Pause();
                            Effects.Changetheta(2f,10);
                            if((Main.Replay||Main.SpecialMode==Modes.PRACTICE||this.overtime>=this.overlimit)&&this.GameOver) {
                                this.gr.button[4].color.r=0.5f;
                                this.gr.button[4].color.g=0.5f;
                                this.gr.button[4].color.b=0.5f;
                            } else {
                                this.gr.button[4].color.r=1f;
                                this.gr.button[4].color.g=1f;
                                this.gr.button[4].color.b=1f;
                            }
                            if(this.banrecord) {
                                this.gr.button[2].color.r=0.5f;
                                this.gr.button[2].color.g=0.5f;
                                this.gr.button[2].color.b=0.5f;
                            } else {
                                this.gr.button[2].color.r=1f;
                                this.gr.button[2].color.g=1f;
                                this.gr.button[2].color.b=1f;
                            }
                            if(this.GameOver) {
                                if(Main.Mode==Modes.SINGLE&&Main.SpecialMode==Modes.SINGLE&&!Main.Replay) {
                                    this.waitforsave=true;
                                    this.cosave=new RecordSave(this.playdata,this.stm.Stage,this.Score);
                                }
                                if(Main.SpecialMode==Modes.PRACTICE&&!Main.Replay)
                                    this.RecordPracticeScore();
                                if(Main.SpecialMode!=Modes.SPELLCARD)
                                    Program.game.game.PlaySound("Result bank",false,0.0f);
                            }
                        }
                        if(this.waitforsave) {
                            if(this.cosave.Ok) {
                                this.waitforsave=false;
                                this.gr.gameovertitle.position.X+=2f;
                                this.gr.gameovertitle.color.a+=0.07f;
                            } else
                                this.cosave.Update();
                        }
                        if(this.time3>1&this.time3<=60) {
                            this.gr.fan.color.a+=0.05f;
                            if((double)this.gr.fan.color.a>=1.0)
                                this.gr.fan.color.a=1f;
                            this.gr.fan.rotation=(float)(((double)this.gr.fan.rotation*9.0+0.0)/10.0);
                            if(this.time3>0&this.time3<=15) {
                                if(!this.GameOver||this.finishpractice) {
                                    this.gr.pausetitle.position.X+=2f;
                                    this.gr.pausetitle.color.a+=0.07f;
                                    if((double)this.gr.pausetitle.color.a>=1.0)
                                        this.gr.pausetitle.color.a=1f;
                                } else {
                                    this.gr.gameovertitle.position.X+=2f;
                                    this.gr.gameovertitle.color.a+=0.07f;
                                    if((double)this.gr.gameovertitle.color.a>=1.0)
                                        this.gr.gameovertitle.color.a=1f;
                                }
                            }
                            if(this.GameOver&&this.time3>5&&this.time3<=20) {
                                this.gr.button[4].position.X+=2f;
                                this.gr.buttonon[4].position.X+=2f;
                                if(4!=this.selection-1) {
                                    this.gr.button[4].color.a+=0.07f;
                                    if((double)this.gr.button[4].color.a>=1.0)
                                        this.gr.button[4].color.a=1f;
                                } else {
                                    this.gr.buttonon[4].color.a+=0.07f;
                                    if((double)this.gr.buttonon[4].color.a>=1.0)
                                        this.gr.buttonon[4].color.a=1f;
                                }
                            } else if(!this.GameOver&&this.time3>5&&this.time3<=20) {
                                this.gr.button[0].position.X+=2f;
                                this.gr.buttonon[0].position.X+=2f;
                                if(this.selection-1!=0) {
                                    this.gr.button[0].color.a+=0.07f;
                                    if((double)this.gr.button[0].color.a>=1.0)
                                        this.gr.button[0].color.a=1f;
                                } else {
                                    this.gr.buttonon[0].color.a+=0.07f;
                                    if((double)this.gr.buttonon[0].color.a>=1.0)
                                        this.gr.buttonon[0].color.a=1f;
                                }
                            }
                            for(int index = 1;index<4;++index) {
                                if(this.time3>5+index*5&this.time3<=20+index*5) {
                                    this.gr.button[index].position.X+=2f;
                                    this.gr.buttonon[index].position.X+=2f;
                                    if(index!=this.selection-1) {
                                        this.gr.button[index].color.a+=0.07f;
                                        if((double)this.gr.button[index].color.a>=1.0)
                                            this.gr.button[index].color.a=1f;
                                    } else {
                                        this.gr.buttonon[index].color.a+=0.07f;
                                        if((double)this.gr.buttonon[index].color.a>=1.0)
                                            this.gr.buttonon[index].color.a=1f;
                                    }
                                }
                            }
                        }
                        if(this.time3>60) {
                            this.stopblur=true;
                            if(!this.step) {
                                for(int index = 0;index<4;++index) {
                                    if(index!=this.selection-1) {
                                        if(index==0&&this.GameOver) {
                                            this.gr.button[4].color.a=1f;
                                            this.gr.buttonon[4].color.a=0.0f;
                                        } else if(index==0&&!this.GameOver) {
                                            this.gr.button[0].color.a=1f;
                                            this.gr.buttonon[0].color.a=0.0f;
                                        } else if(index!=0) {
                                            this.gr.button[index].color.a=1f;
                                            this.gr.buttonon[index].color.a=0.0f;
                                        }
                                    } else if(index==0&&this.GameOver) {
                                        this.gr.button[4].color.a=0.0f;
                                        this.gr.buttonon[4].color.a=1f;
                                    } else if(index==0&&!this.GameOver) {
                                        this.gr.button[0].color.a=0.0f;
                                        this.gr.buttonon[0].color.a=1f;
                                    } else if(index!=0) {
                                        this.gr.button[index].color.a=0.0f;
                                        this.gr.buttonon[index].color.a=1f;
                                    }
                                    if(this.selection-1==index) {
                                        if(index==0&&this.GameOver) {
                                            if(this.time4>0&this.time4<=3)
                                                ++this.gr.buttonon[4].position.X;
                                            if(this.time4>3&this.time4<=6)
                                                --this.gr.buttonon[4].position.X;
                                        } else if(index==0&&!this.GameOver) {
                                            if(this.time4>0&this.time4<=3)
                                                ++this.gr.buttonon[0].position.X;
                                            if(this.time4>3&this.time4<=6)
                                                --this.gr.buttonon[0].position.X;
                                        } else if(index!=0) {
                                            if(this.time4>0&this.time4<=3)
                                                ++this.gr.buttonon[index].position.X;
                                            if(this.time4>3&this.time4<=6)
                                                --this.gr.buttonon[index].position.X;
                                        }
                                    }
                                }
                                if(!this.GameOver&&(((Main.keyboardstat.IsKeyDown(Keys.Escape) ? 1 : (Main.keyboardstat.IsKeyDown(Keys.X) ? 1 : 0))&(Main.keyboardstat!=Main.prekeyboard ? 1 : 0))!=0||PadState.IsKeyPressed(JOYKEYS.Special,Main.prepadstat)||PadState.IsKeyPressed(JOYKEYS.Pause,Main.prepadstat))) {
                                    this.PlaySound("cancel",false,0.0f);
                                    this.Pause=false;
                                    this.ResumeSound();
                                    this.Actor.Ban=false;
                                    this.stm.syncInit(this.Actor);
                                    this.gr.button[4].position.X=44f;
                                    this.gr.buttonon[4].position.X=44f;
                                    this.gr.gameovertitle.position.X=46f;
                                    this.time3=0;
                                    this.time2=81;
                                    if(!Music.BGM.IsDisposed)
                                        Music.BGM.Resume();
                                    Program.game.game.StopSound("Result bank");
                                    Effects.Changetheta(0.1f,10);
                                    Effects.BlackWhite=0.0f;
                                } else if(this.Pause&&(Main.keyboardstat.IsKeyDown(Keys.Up)&Main.keyboardstat!=Main.prekeyboard||PadState.IsKeyPressed(JOYKEYS.Up,Main.prepadstat))) {
                                    this.PlaySound("select",false,0.0f);
                                    --this.selection;
                                    if(this.banrecord&&this.selection==3||(Main.Replay||Main.SpecialMode==Modes.PRACTICE||this.overtime>=this.overlimit)&&(this.GameOver&&this.selection==1))
                                        --this.selection;
                                    if(this.selection==0)
                                        this.selection=4;
                                    this.time4=0;
                                } else if(this.Pause&&(Main.keyboardstat.IsKeyDown(Keys.Down)&Main.keyboardstat!=Main.prekeyboard||PadState.IsKeyPressed(JOYKEYS.Down,Main.prepadstat))) {
                                    this.PlaySound("select",false,0.0f);
                                    ++this.selection;
                                    if(this.banrecord&&this.selection==3)
                                        ++this.selection;
                                    if(this.selection==5)
                                        this.selection=!Main.Replay&&Main.SpecialMode!=Modes.PRACTICE&&this.overtime<this.overlimit||!this.GameOver ? 1 : 2;
                                    this.time4=0;
                                } else if(this.Pause&&Main.keyboardstat.IsKeyDown(Keys.R)&Main.keyboardstat!=Main.prekeyboard) {
                                    this.PlaySound("ok",false,0.0f);
                                    Main.stagecheck="ENTRANCE";
                                    this.Finished=true;
                                    this.Dispose();
                                } else if(this.Pause&&(Main.keyboardstat.IsKeyDown(Keys.Enter)&Main.keyboardstat!=Main.prekeyboard||Main.keyboardstat.IsKeyDown(Keys.Z)&Main.keyboardstat!=Main.prekeyboard||PadState.IsKeyPressed(JOYKEYS.Confirm,Main.prepadstat))) {
                                    this.PlaySound("ok",false,0.0f);
                                    switch(this.selection) {
                                        case 1:
                                            this.Pause=false;
                                            if(!this.GameOver) {
                                                this.gr.button[4].position.X=44f;
                                                this.gr.buttonon[4].position.X=44f;
                                                this.gr.gameovertitle.position.X=46f;
                                            } else {
                                                this.Life=10;
                                                this.Bomb=10;
                                                ++this.retrytime;
                                                this.Score=(long)this.retrytime;
                                                if(this.Bomb<10)
                                                    this.Bomb=10;
                                                this.gr.button[0].position.X=44f;
                                                this.gr.buttonon[0].position.X=44f;
                                                this.gr.pausetitle.position.X=46f;
                                                this.GameOver=false;
                                                this.banrecord=true;
                                                this.BanPause=false;
                                            }
                                            this.Actor.Ban=false;
                                            this.stm.syncInit(this.Actor);
                                            this.time3=0;
                                            this.time2=81;
                                            this.ResumeSound();
                                            if(!Music.BGM.IsDisposed)
                                                Music.BGM.Resume();
                                            Program.game.game.StopSound("Result bank");
                                            Effects.Changetheta(0.1f,10);
                                            Effects.BlackWhite=0.0f;
                                            break;
                                        case 2:
                                            this.step=true;
                                            this.time5=0;
                                            this.selection2=2;
                                            this.gr.choose[0].position.Y=353f;
                                            this.gr.choose[1].position.Y=353f;
                                            break;
                                        case 3:
                                            this.step=true;
                                            this.time5=0;
                                            this.selection2=2;
                                            this.gr.choose[0].position.Y=383f;
                                            this.gr.choose[1].position.Y=383f;
                                            break;
                                        case 4:
                                            this.step=true;
                                            this.time5=0;
                                            this.selection2=2;
                                            this.gr.choose[0].position.Y=413f;
                                            this.gr.choose[1].position.Y=413f;
                                            break;
                                    }
                                }
                                if(this.time5>0&this.time5<=15) {
                                    if(this.selection-1==0&&!this.GameOver) {
                                        this.gr.buttonon[0].color.a+=0.07f;
                                        if((double)this.gr.buttonon[0].color.a>=1.0)
                                            this.gr.buttonon[0].color.a=1f;
                                    } else if(this.selection-1==0&&this.GameOver) {
                                        this.gr.buttonon[4].color.a+=0.07f;
                                        if((double)this.gr.buttonon[4].color.a>=1.0)
                                            this.gr.buttonon[4].color.a=1f;
                                    } else if(this.selection-1!=0) {
                                        this.gr.buttonon[this.selection-1].color.a+=0.07f;
                                        if((double)this.gr.buttonon[this.selection-1].color.a>=1.0)
                                            this.gr.buttonon[this.selection-1].color.a=1f;
                                    }
                                    this.gr.choose[this.selection2-1].color.a-=0.07f;
                                    if((double)this.gr.choose[this.selection2-1].color.a<=0.0)
                                        this.gr.choose[this.selection2-1].color.a=0.0f;
                                }
                                ++this.time5;
                                if(this.time5>15)
                                    this.time5=16;
                            } else {
                                if(this.time5>0&this.time5<=15) {
                                    if(this.selection-1==0&&!this.GameOver) {
                                        this.gr.buttonon[0].color.a-=0.07f;
                                        if((double)this.gr.buttonon[0].color.a<=0.0)
                                            this.gr.buttonon[0].color.a=0.0f;
                                    } else if(this.selection-1==0&&this.GameOver) {
                                        this.gr.buttonon[3].color.a-=0.07f;
                                        if((double)this.gr.buttonon[3].color.a<=0.0)
                                            this.gr.buttonon[3].color.a=0.0f;
                                    } else if(this.selection-1!=0) {
                                        this.gr.buttonon[this.selection-1].color.a-=0.07f;
                                        if((double)this.gr.buttonon[this.selection-1].color.a<=0.0)
                                            this.gr.buttonon[this.selection-1].color.a=0.0f;
                                    }
                                    this.gr.choose[this.selection2-1].color.a+=0.07f;
                                    if((double)this.gr.choose[this.selection2-1].color.a>=1.0)
                                        this.gr.choose[this.selection2-1].color.a=1f;
                                }
                                if(this.time5>5&&!this.savestep) {
                                    if(((Main.keyboardstat.IsKeyDown(Keys.Escape) ? 1 : (Main.keyboardstat.IsKeyDown(Keys.X) ? 1 : 0))&(Main.keyboardstat!=Main.prekeyboard ? 1 : 0))!=0||PadState.IsKeyPressed(JOYKEYS.Pause,Main.prepadstat)||PadState.IsKeyPressed(JOYKEYS.Special,Main.prepadstat)) {
                                        this.PlaySound("cancel",false,0.0f);
                                        this.step=false;
                                        this.time5=0;
                                    } else if(Main.keyboardstat.IsKeyDown(Keys.Left)&Main.keyboardstat!=Main.prekeyboard||PadState.IsKeyPressed(JOYKEYS.Left,Main.prepadstat)) {
                                        this.PlaySound("select",false,0.0f);
                                        --this.selection2;
                                        if(this.selection2==0)
                                            this.selection2=2;
                                        if(this.selection2==1) {
                                            this.gr.choose[0].color.a=1f;
                                            this.gr.choose[1].color.a=0.0f;
                                        } else {
                                            this.gr.choose[0].color.a=0.0f;
                                            this.gr.choose[1].color.a=1f;
                                        }
                                    } else if(Main.keyboardstat.IsKeyDown(Keys.Right)&Main.keyboardstat!=Main.prekeyboard||PadState.IsKeyPressed(JOYKEYS.Right,Main.prepadstat)) {
                                        this.PlaySound("select",false,0.0f);
                                        ++this.selection2;
                                        if(this.selection2==3)
                                            this.selection2=1;
                                        if(this.selection2==1) {
                                            this.gr.choose[0].color.a=1f;
                                            this.gr.choose[1].color.a=0.0f;
                                        } else {
                                            this.gr.choose[0].color.a=0.0f;
                                            this.gr.choose[1].color.a=1f;
                                        }
                                    } else if(Main.keyboardstat.IsKeyDown(Keys.Enter)&Main.keyboardstat!=Main.prekeyboard||Main.keyboardstat.IsKeyDown(Keys.Z)&Main.keyboardstat!=Main.prekeyboard||PadState.IsKeyPressed(JOYKEYS.Confirm,Main.prepadstat)) {
                                        this.PlaySound("ok",false,0.0f);
                                        switch(this.selection2) {
                                            case 1:
                                                switch(this.selection) {
                                                    case 2:
                                                        Main.stage="ENTRANCE";
                                                        this.Finished=true;
                                                        this.Dispose();
                                                        break;
                                                    case 3:
                                                        this.savestep=true;
                                                        this.resave=Main.SpecialMode==Modes.SPELLCARD ? new ReplaySave(this.stm.GetRecord(),this.stm.RTime,this.Score,(int)(Main.Character-1),(int)(Main.Level-1),this.bossstage,this.spellcardid) : new ReplaySave(this.stm.GetRecord(),this.stm.RTime,this.Score,(int)(Main.Character-1),(int)(Main.Level-1),this.stm.Stage);
                                                        break;
                                                    case 4:
                                                        Main.stagecheck="ENTRANCE";
                                                        this.Finished=true;
                                                        this.Dispose();
                                                        break;
                                                }
                                                break;
                                            case 2:
                                                this.step=false;
                                                this.time5=0;
                                                break;
                                        }
                                    }
                                } else if(this.time5>5&&this.resave!=null) {
                                    this.resave.Update();
                                    if(this.resave.Ok) {
                                        Main.stage="ENTRANCE";
                                        this.Finished=true;
                                        this.Dispose();
                                    }
                                }
                                ++this.time5;
                                if(this.time5>15)
                                    this.time5=16;
                            }
                            ++this.time4;
                            if(this.time4>=7)
                                this.time4=7;
                        }
                        if(!this.waitforsave)
                            ++this.time3;
                        if(this.time3>60)
                            this.time3=61;
                    }
                    if(this.stm.RecordPause) {
                        this.Pause=true;
                        if(this.rptime==0) {
                            this.Actor.Ban=true;
                            this.PauseSound();
                            if(!Music.BGM.IsDisposed&&!Music.BGMContaining)
                                Music.BGM.Pause();
                            Effects.Changetheta(2f,10);
                            this.gr.button[1].position=new Vector2(14f,320f);
                            this.gr.buttonon[1].position=this.gr.button[1].position;
                            if(Main.SpecialMode==Modes.SPELLCARD&&!Main.Replay) {
                                this.gr.button[2].position=new Vector2(14f,350f);
                                this.gr.buttonon[2].position=this.gr.button[2].position;
                                this.gr.button[3].position=new Vector2(14f,380f);
                                this.gr.buttonon[3].position=this.gr.button[3].position;
                            } else {
                                this.gr.button[3].position=new Vector2(14f,350f);
                                this.gr.buttonon[3].position=this.gr.button[3].position;
                            }
                            this.gr.fan.rotation=120f;
                            this.gr.fan.color.a=0.0f;
                            this.gr.pausetitle.color.a=0.0f;
                            this.gr.gameovertitle.color.a=0.0f;
                            for(int index = 0;index<=4;++index) {
                                this.gr.button[index].color.a=0.0f;
                                this.gr.buttonon[index].color.a=0.0f;
                            }
                        } else if(this.rptime>0&&this.rptime<=60) {
                            this.gr.fan.color.a+=0.05f;
                            if((double)this.gr.fan.color.a>=1.0)
                                this.gr.fan.color.a=1f;
                            this.gr.fan.rotation=(float)(((double)this.gr.fan.rotation*9.0+0.0)/10.0);
                            if(this.rptime>0&this.rptime<=15&&(Main.SpecialMode!=Modes.SPELLCARD||Main.Replay)) {
                                this.gr.replaytitle.position.X+=2f;
                                this.gr.replaytitle.color.a+=0.07f;
                                if((double)this.gr.replaytitle.color.a>=1.0)
                                    this.gr.replaytitle.color.a=1f;
                            }
                            if(this.rptime>5&&this.rptime<=20) {
                                int num;
                                if(Main.SpecialMode==Modes.SPELLCARD&&!Main.Replay) {
                                    num=1;
                                } else {
                                    num=2;
                                    this.gr.button[2].color.a=this.gr.buttonon[2].color.a=0.0f;
                                }
                                for(int index = 1;index<4;index+=num) {
                                    this.gr.button[index].position.X+=2f;
                                    this.gr.buttonon[index].position.X+=2f;
                                    if(index!=this.selection-1) {
                                        this.gr.button[index].color.a+=0.07f;
                                        if((double)this.gr.button[index].color.a>=1.0)
                                            this.gr.button[index].color.a=1f;
                                    } else {
                                        this.gr.buttonon[index].color.a+=0.07f;
                                        if((double)this.gr.buttonon[index].color.a>=1.0)
                                            this.gr.buttonon[index].color.a=1f;
                                    }
                                }
                            }
                        } else {
                            if(this.selection==1) {
                                this.gr.button[1].color.a=0.0f;
                                this.gr.buttonon[1].color.a=1f;
                                if(Main.SpecialMode==Modes.SPELLCARD&&!Main.Replay) {
                                    this.gr.button[2].color.a=1f;
                                    this.gr.buttonon[2].color.a=0.0f;
                                }
                                this.gr.button[3].color.a=1f;
                                this.gr.buttonon[3].color.a=0.0f;
                                if(this.time4>0&this.time4<=3)
                                    ++this.gr.buttonon[1].position.X;
                                if(this.time4>3&this.time4<=6)
                                    --this.gr.buttonon[1].position.X;
                            } else if(this.selection==2) {
                                if(Main.SpecialMode==Modes.SPELLCARD&&!Main.Replay) {
                                    this.gr.button[2].color.a=0.0f;
                                    this.gr.buttonon[2].color.a=1f;
                                    this.gr.button[1].color.a=1f;
                                    this.gr.buttonon[1].color.a=0.0f;
                                    this.gr.button[3].color.a=1f;
                                    this.gr.buttonon[3].color.a=0.0f;
                                    if(this.time4>0&this.time4<=3)
                                        ++this.gr.buttonon[2].position.X;
                                    if(this.time4>3&this.time4<=6)
                                        --this.gr.buttonon[2].position.X;
                                } else {
                                    this.gr.button[3].color.a=0.0f;
                                    this.gr.buttonon[3].color.a=1f;
                                    this.gr.button[1].color.a=1f;
                                    this.gr.buttonon[1].color.a=0.0f;
                                    this.gr.button[2].color.a=this.gr.buttonon[2].color.a=0.0f;
                                    if(this.time4>0&this.time4<=3)
                                        ++this.gr.buttonon[3].position.X;
                                    if(this.time4>3&this.time4<=6)
                                        --this.gr.buttonon[3].position.X;
                                }
                            } else if(this.selection==3) {
                                this.gr.button[3].color.a=0.0f;
                                this.gr.buttonon[3].color.a=1f;
                                this.gr.button[1].color.a=1f;
                                this.gr.buttonon[1].color.a=0.0f;
                                this.gr.button[2].color.a=1f;
                                this.gr.buttonon[2].color.a=0.0f;
                                if(this.time4>0&this.time4<=3)
                                    ++this.gr.buttonon[3].position.X;
                                if(this.time4>3&this.time4<=6)
                                    --this.gr.buttonon[3].position.X;
                            }
                            if(!this.savestep) {
                                int num = 2;
                                if(Main.SpecialMode==Modes.SPELLCARD&&!Main.Replay)
                                    num=3;
                                if(this.Pause&&Main.keyboardstat.IsKeyDown(Keys.Up)&Main.keyboardstat!=Main.prekeyboard||PadState.IsKeyPressed(JOYKEYS.Up,Main.prepadstat)) {
                                    this.PlaySound("select",false,0.0f);
                                    --this.selection;
                                    if(this.selection==0)
                                        this.selection=num;
                                    this.time4=0;
                                } else if(this.Pause&&Main.keyboardstat.IsKeyDown(Keys.Down)&Main.keyboardstat!=Main.prekeyboard||PadState.IsKeyPressed(JOYKEYS.Down,Main.prepadstat)) {
                                    this.PlaySound("select",false,0.0f);
                                    ++this.selection;
                                    if(this.selection==num+1)
                                        this.selection=1;
                                    this.time4=0;
                                } else if(this.Pause&&Main.keyboardstat.IsKeyDown(Keys.R)&Main.keyboardstat!=Main.prekeyboard) {
                                    this.PlaySound("ok",false,0.0f);
                                    Main.stagecheck="ENTRANCE";
                                    this.Finished=true;
                                    this.Dispose();
                                } else if(this.Pause&&(Main.keyboardstat.IsKeyDown(Keys.Enter)&Main.keyboardstat!=Main.prekeyboard||Main.keyboardstat.IsKeyDown(Keys.Z)&Main.keyboardstat!=Main.prekeyboard||PadState.IsKeyPressed(JOYKEYS.Confirm,Main.prepadstat))) {
                                    this.PlaySound("ok",false,0.0f);
                                    if(Main.SpecialMode==Modes.SPELLCARD&&!Main.Replay) {
                                        switch(this.selection) {
                                            case 1:
                                                Main.stage="ENTRANCE";
                                                this.Finished=true;
                                                this.Dispose();
                                                break;
                                            case 2:
                                                this.savestep=true;
                                                this.resave=new ReplaySave(this.stm.GetRecord(),this.stm.RTime,this.Score,(int)(Main.Character-1),(int)(Main.Level-1),this.bossstage,this.spellcardid);
                                                break;
                                            case 3:
                                                this.PlaySound("ok",false,0.0f);
                                                Main.stagecheck="ENTRANCE";
                                                this.Finished=true;
                                                this.Dispose();
                                                break;
                                        }
                                    } else {
                                        switch(this.selection) {
                                            case 1:
                                                Main.stage="ENTRANCE";
                                                this.Finished=true;
                                                this.Dispose();
                                                break;
                                            case 2:
                                                this.PlaySound("ok",false,0.0f);
                                                Main.stagecheck="ENTRANCE";
                                                this.Finished=true;
                                                this.Dispose();
                                                break;
                                        }
                                    }
                                }
                            } else if(this.resave!=null) {
                                this.resave.Update();
                                if(this.resave.Ok) {
                                    Main.stage="ENTRANCE";
                                    this.Finished=true;
                                    this.Dispose();
                                }
                            }
                            if(this.time5>0&this.time5<=15) {
                                if(this.selection==1) {
                                    this.gr.buttonon[1].color.a+=0.07f;
                                    if((double)this.gr.buttonon[1].color.a>=1.0)
                                        this.gr.buttonon[1].color.a=1f;
                                } else if(this.selection==2) {
                                    this.gr.buttonon[3].color.a+=0.07f;
                                    if((double)this.gr.buttonon[3].color.a>=1.0)
                                        this.gr.buttonon[3].color.a=1f;
                                }
                            }
                            ++this.time5;
                            if(this.time5>15)
                                this.time5=16;
                            ++this.time4;
                            if(this.time4>=7)
                                this.time4=7;
                        }
                        ++this.rptime;
                    }
                }
                ++this.time2;
                ++this.watch;
                if(!Main.Replay&&Main.SpecialMode!=Modes.SPELLCARD&&this.watch>=60) {
                    ++this.playdata.players[(int)(Main.Character-1)].totaltime;
                    this.watch=0;
                    Program.game.achivmanager.Check(AchievementType.Hidden,5,new Hashtable() {
                        [(object)"playerdata"]=(object)this.playdata.players
                    });
                }
            }
            if(this.time2<=80)
                PraticleManager.Update();
            Effects.ChangeUpdate();
        }

        public void RecordSpecialScore() {
            SpecialData data = this.LoadSpecialData();
            if(this.HiScore>data.spe[(int)(Main.Character-1)].sc[this.spellcardid].score)
                data.spe[(int)(Main.Character-1)].sc[this.spellcardid].score=this.HiScore;
            this.SaveSpecialData(data);
        }

        public void RecordPracticeScore() {
            if(this.HiScore<=this.practicedata.data[(int)(Main.Character-1)][(int)(Main.Level-1)].score[this.stm.Stage-1])
                return;
            this.practicedata.data[(int)(Main.Character-1)][(int)(Main.Level-1)].score[this.stm.Stage-1]=this.HiScore;
        }

        public void PracticeFinished() {
            this.finishpractice=true;
            this.Pause=true;
            this.PauseSound();
            this.GameOver=true;
            this.time3=0;
            this.time5=16;
            this.gr.fan.rotation=120f;
            this.selection=2;
        }

        public void SDraw(NSpriteBatch s) {
            if(this.stage!=null) {
                if(this.time2>80) {
                    this.stm.Draw(s,this.enemym,this.Pause,this.bgcolor);
                    if(this.Pause) {
                        if(!this.stopblur) {
                            if(!s.IsBegan)
                                s.Begin();
                            this.gd.SetRenderTarget(0,this.renderTarget);
                            if(this.stm.GetRender()!=null)
                                s.Draw(this.stm.GetRender(),Vector2.Zero,Color.White);
                            if(this.stm.IsBossed())
                                this.stm.BossImageDraw((SpriteBatch)s);
                            this.Actor.Draw((SpriteBatch)s,this.Pause,this.quake);
                            PraticleManager.Draw((SpriteBatch)s,this.quake);
                            this.csm.Draw((SpriteBatch)s,this.quake);
                            if(this.DrawJudge!=null)
                                this.DrawJudge(s,this.Pause,this.quake);
                            if(this.Drawevents!=null)
                                this.Drawevents(s);
                            if(this.Drawevents2!=null)
                                this.Drawevents2(s,this.Actor);
                            this.Special.Draw((SpriteBatch)s);
                            if(this.stm.IsBossed())
                                this.stm.BossCardDraw((SpriteBatch)s,this.Actor);
                            if(s.IsBegan)
                                s.End();
                            this.gd.SetRenderTarget(0,(RenderTarget2D)null);
                            Texture2D texture1 = this.renderTarget.GetTexture();
                            Effects.BlackWhite=1f;
                            Effects.SetblurParameters(this.gr.blur,1f/(float)this.renderTarget.Width,0.0f);
                            this.gd.SetRenderTarget(0,this.renderTarget);
                            if(!s.IsBegan)
                                s.Begin(SpriteBlendMode.AlphaBlend,SpriteSortMode.Immediate,SaveStateMode.None);
                            this.gr.blur.Begin();
                            this.gr.blur.CurrentTechnique.Passes[0].Begin();
                            s.Draw(texture1,this.quake,Color.White);
                            this.gr.blur.CurrentTechnique.Passes[0].End();
                            this.gr.blur.End();
                            if(s.IsBegan)
                                s.End();
                            this.gd.SetRenderTarget(0,(RenderTarget2D)null);
                            Texture2D texture2 = this.renderTarget.GetTexture();
                            this.gd.SetRenderTarget(0,this.renderTarget);
                            Effects.SetblurParameters(this.gr.blur,0.0f,1f/(float)this.renderTarget.Height);
                            if(!s.IsBegan)
                                s.Begin(SpriteBlendMode.AlphaBlend,SpriteSortMode.Immediate,SaveStateMode.None);
                            this.gr.blur.Begin();
                            this.gr.blur.CurrentTechnique.Passes[0].Begin();
                            s.Draw(texture2,Vector2.Zero,Color.White);
                            this.gr.blur.CurrentTechnique.Passes[0].End();
                            this.gr.blur.End();
                            if(s.IsBegan)
                                s.End();
                            this.gd.SetRenderTarget(0,(RenderTarget2D)null);
                            this.Pausescreen=this.renderTarget.GetTexture();
                        }
                        if(!s.IsBegan)
                            s.Begin(SpriteBlendMode.AlphaBlend,SpriteSortMode.Immediate,SaveStateMode.None);
                        s.Draw(this.Pausescreen,Vector2.Zero,Color.White);
                    }
                }
                if(!this.Pause) {
                    if(this.stm.IsBossed())
                        this.stm.BossImageDraw((SpriteBatch)s);
                    this.Actor.Draw((SpriteBatch)s,this.Pause,this.quake);
                    if(s.IsBegan)
                        s.End();
                    if(!s.IsBegan)
                        s.Begin(SpriteBlendMode.Additive);
                    PraticleManager.Draw((SpriteBatch)s,this.quake);
                    if(s.IsBegan)
                        s.End();
                    if(!s.IsBegan)
                        s.Begin();
                    this.csm.Draw((SpriteBatch)s,this.quake);
                    if(this.DrawJudge!=null)
                        this.DrawJudge(s,this.Pause,this.quake);
                    if(this.Drawevents!=null)
                        this.Drawevents(s);
                    if(this.Drawevents2!=null)
                        this.Drawevents2(s,this.Actor);
                    this.Special.ChangeAlpha(this.Actor.Position());
                    this.Special.Draw((SpriteBatch)s);
                    if(this.stm.IsBossed())
                        this.stm.BossCardDraw((SpriteBatch)s,this.Actor);
                }
                if(!this.savestep) {
                    this.gr.fan.Draw((SpriteBatch)s,SpriteEffects.None,0.0f);
                    this.gr.pausetitle.Draw((SpriteBatch)s,SpriteEffects.None,0.0f);
                    this.gr.gameovertitle.Draw((SpriteBatch)s,SpriteEffects.None,0.0f);
                    this.gr.replaytitle.Draw((SpriteBatch)s,SpriteEffects.None,0.0f);
                    for(int index = 0;index<5;++index) {
                        this.gr.button[index].Draw((SpriteBatch)s,SpriteEffects.None,0.0f);
                        this.gr.buttonon[index].Draw((SpriteBatch)s,SpriteEffects.None,0.0f);
                    }
                    this.gr.choose[0].Draw((SpriteBatch)s,SpriteEffects.None,0.0f);
                    this.gr.choose[1].Draw((SpriteBatch)s,SpriteEffects.None,0.0f);
                } else if(this.resave!=null)
                    this.resave.Draw((SpriteBatch)s,Vector2.Zero);
                if(this.waitforsave&&this.cosave!=null)
                    this.cosave.Draw((SpriteBatch)s,Vector2.Zero);
                this.gr.ui.Draw((SpriteBatch)s,SpriteEffects.None,0.0f);
                this.gr.dicolty.Draw((SpriteBatch)s,SpriteEffects.None,0.0f);
                if(this.stm.IsBossed()) {
                    float x = this.stm.GetBosspos().X;
                    float a = 0.0f;
                    if((double)x>=50.0&&(double)x<=390.0)
                        a=1f;
                    if((double)x<50.0)
                        a=(double)x>=0.0 ? x/50f : 0.0f;
                    else if((double)x>390.0)
                        a=(double)x<=440.0 ? (float)(((double)x-390.0)/50.0) : 0.0f;
                    s.Draw(this.gr.bosslist,new Vector2(x,482f),new Rectangle?(new Rectangle(280,15,89,25)),new Color(1f,1f,1f,a),0.0f,new Vector2(45f,25f),1f,SpriteEffects.None,0.0f);
                }
                for(int index = 0;index<10-this.HiScore.ToString().Length;++index)
                    s.Draw(this.gr.number,new Vector2((float)(516+index*12),41f),new Rectangle?(new Rectangle(0,0,12,16)),new Color(1f,1f,1f,this.gr.ui.color.a));
                char[] charArray1 = this.HiScore.ToString().ToCharArray();
                for(int index = 10-this.HiScore.ToString().Length;index<10;++index)
                    s.Draw(this.gr.number,new Vector2((float)(516+index*12),41f),new Rectangle?(new Rectangle(int.Parse(charArray1[index-10+this.HiScore.ToString().Length].ToString())*12,0,12,16)),new Color(1f,1f,1f,this.gr.ui.color.a));
                for(int index = 0;index<10-this.Score.ToString().Length;++index)
                    s.Draw(this.gr.number,new Vector2((float)(516+index*12),63f),new Rectangle?(new Rectangle(0,0,12,16)),new Color(1f,1f,1f,this.gr.ui.color.a));
                char[] charArray2 = this.Score.ToString().ToCharArray();
                for(int index = 10-this.Score.ToString().Length;index<10;++index)
                    s.Draw(this.gr.number,new Vector2((float)(516+index*12),63f),new Rectangle?(new Rectangle(int.Parse(charArray2[index-10+this.Score.ToString().Length].ToString())*12,0,12,16)),new Color(1f,1f,1f,this.gr.ui.color.a));
                if(this.Life>=50) {
                    this.Bomb+=this.Life-50;
                    this.Life=50;
                }
                if(this.Bomb>=50)
                    this.Bomb=50;
                for(int index = 0;index<this.Life/5;++index)
                    s.Draw(this.gr.numlogo,new Vector2((float)(516+index*12),94f),new Rectangle?(new Rectangle(40,0,10,17)),new Color(1f,0.6f,1f,this.gr.ui.color.a));
                if(this.Life%5!=0)
                    s.Draw(this.gr.numlogo,new Vector2((float)(516+this.Life/5*12),94f),new Rectangle?(new Rectangle((this.Life%5-1)*10,0,10,17)),new Color(1f,1f,1f,this.gr.ui.color.a));
                for(int index = 0;index<this.Bomb/5;++index)
                    s.Draw(this.gr.numlogo,new Vector2((float)(516+index*12),116f),new Rectangle?(new Rectangle(40,0,10,17)),new Color(0.0f,0.9f,0.4f,this.gr.ui.color.a));
                if(this.Bomb%5!=0)
                    s.Draw(this.gr.numlogo,new Vector2((float)(516+this.Bomb/5*12),116f),new Rectangle?(new Rectangle((this.Bomb%5-1)*10,0,10,17)),new Color(1f,1f,1f,this.gr.ui.color.a));
                s.Draw(this.gr.number,new Vector2(516f,150f),new Rectangle?(new Rectangle(this.Point/50*12,0,12,16)),new Color(1f,1f,1f,this.gr.ui.color.a));
                s.Draw(this.gr.number,new Vector2(528f,150f),new Rectangle?(new Rectangle(120,0,12,16)),new Color(1f,1f,1f,this.gr.ui.color.a));
                string str = (this.Point*2).ToString().PadLeft(3,'0');
                for(int index = 1;index<=2;++index)
                    s.Draw(this.gr.number,new Vector2((float)(528+index*12),150f),new Rectangle?(new Rectangle(int.Parse(str[index].ToString())*12,0,12,16)),new Color(1f,1f,1f,this.gr.ui.color.a));
                s.Draw(this.gr.number,new Vector2(564f,150f),new Rectangle?(new Rectangle(132,0,12,16)),new Color(1f,1f,1f,this.gr.ui.color.a));
                s.Draw(this.gr.number,new Vector2(576f,150f),new Rectangle?(new Rectangle(48,0,12,16)),new Color(1f,1f,1f,this.gr.ui.color.a));
                s.Draw(this.gr.number,new Vector2(588f,150f),new Rectangle?(new Rectangle(120,0,12,16)),new Color(1f,1f,1f,this.gr.ui.color.a));
                for(int index = 1;index<=2;++index)
                    s.Draw(this.gr.number,new Vector2((float)(588+index*12),150f),new Rectangle?(new Rectangle(0,0,12,16)),new Color(1f,1f,1f,this.gr.ui.color.a));
                char[] charArray3 = (this.MaxBlue+10000).ToString().PadLeft(6,' ').ToCharArray();
                for(int index = 0;index<charArray3.Length;++index) {
                    if(charArray3[index]!=' ')
                        s.Draw(this.gr.number,new Vector2((float)(552+index*12),173f),new Rectangle?(new Rectangle(int.Parse(charArray3[index].ToString())*12,0,12,16)),new Color(1f,1f,1f,this.gr.ui.color.a));
                }
                char[] charArray4 = this.Graze.ToString().PadLeft(5,' ').ToCharArray();
                for(int index = 0;index<charArray4.Length;++index) {
                    if(charArray4[index]!=' ')
                        s.Draw(this.gr.number,new Vector2((float)(564+index*12),196f),new Rectangle?(new Rectangle(int.Parse(charArray4[index].ToString())*12,0,12,16)),new Color(1f,1f,1f,this.gr.ui.color.a));
                }
                if(this.stm!=null&&this.stm.EndType!=0&&(double)this.gr.black.color.a>0.0)
                    this.gr.black.Draw((SpriteBatch)s,SpriteEffects.None,0.0f);
            }
            if(this.time2>80)
                return;
            if(s.IsBegan)
                s.End();
            if(!s.IsBegan)
                s.Begin(SpriteBlendMode.Additive,SpriteSortMode.Immediate,SaveStateMode.None);
            PraticleManager.Draw((SpriteBatch)s,Vector2.Zero);
            if(s.IsBegan)
                s.End();
            if(!s.IsBegan)
                s.Begin();
            this.gr.bless.Draw((SpriteBatch)s,SpriteEffects.None,0.0f);
        }

        public void PreReadSave() {
            for(int index = 0;index<Main.MKeys.Length;++index)
                Main.preMKeys[index]=Main.MKeys[index];
        }

        public void Finish(string nextstage) {
            Main.stage=nextstage;
            this.Finished=true;
            if(Main.stage.Contains("ED"))
                Program.game.achivmanager.Check(AchievementType.Challenge,6,new Hashtable() {
                    [(object)"dead"]=(object)this.Actor.havedead,
                    [(object)"level"]=(object)(int)(Main.Level-1)
                });
            this.Dispose();
        }

        public void BanPlayer(bool ban) {
            this.Actor.Ban=ban;
        }

        public delegate void DrawDelegate(NSpriteBatch s);

        public delegate void DrawDelegate2(NSpriteBatch s,bool Pause,Vector2 Quakeset);

        public delegate void DrawDelegate3(NSpriteBatch s,Character Player);
    }
}
