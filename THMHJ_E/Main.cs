// Decompiled with JetBrains decompiler
// Type: THMHJ.Main
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;

namespace THMHJ {
    public class Main:Microsoft.Xna.Framework.Game {
        public SourseForm sourseForm;
        public static Watch timewatch = new Watch();
        public static float replayds = 1f;
        public static string version = "1.04";
        public static string rpyversion = "1.02";
        public static string nametemp = "";
        private static GameResource gr = new GameResource();
        public static GameNumber gn = new GameNumber();
        public static Difficulty Level = Difficulty.EASY;
        public static Cname Character = Cname.REIMU;
        public static string[] CharacterString = new string[4]
        {
      "Reimu",
      "Marisa",
      "Sanae",
      "Patchouli"
        };
        public static string[] LevelString = new string[6]
        {
      "E",
      "N",
      "H",
      "L",
      "Ex",
      "Sp"
        };
        public static string[] TypeString = new string[2]
        {
      "S",
      "N"
        };
        public static short[] SpellcardNum = new short[5]
        {
      (short) 27,
      (short) 27,
      (short) 29,
      (short) 32,
      (short) 12
        };
        public static int? gameseed = new int?();
        private static int randtime = 0;
        private static int bombtime = 0;
        public static bool FpsInspect;
        private static long FpsLost;
        private static long FpsFull;
        public AchievementManager achivmanager;
        public static float ds;
        private Sound sound;
        private ResolveTexture2D resolveTexture;
        private static int WindowSizeType;
        public static bool Record;
        public static bool Replay;
        private static RecordManager Replaycontent;
        public static bool[] MKeys;
        public static bool[] preMKeys;
        public static int ReplayFirstStage;
        private GraphicsDeviceManager graphics;
        public static GraphicsAdapter adapter;
        public static SurfaceFormat format;
        private NSpriteBatch spriteBatch;
        private Texture2D screen;
        public static SpriteFontX font;
        public static SpriteFontX dfont;
        public static SpriteFontX scfont;
        public static SpriteFontX scdfont;
        public static IniFiles ini;
        public Entrance entrance;
        public Game game;
        public ED ed;
        public static bool ifcontinued;
        public static RecordSave EDrecordsave;
        public static ReplaySave EDreplaysave;
        public static Hashtable gsound;
        public static string stage;
        public static string stagecheck;
        public static bool BackGround;
        public static bool VSync;
        public static int Fullorwindow;
        public static Modes Mode;
        public static Modes SpecialMode;
        public static bool Only;
        public static bool SkiptoSCChanllenges;
        public static JOYINFOEX padinfo;
        public static JOYBUTTONS padstat;
        public static JOYBUTTONS prepadstat;
        public static KeyboardState prekeyboard;
        public static KeyboardState keyboardstat;
        public static string WindowTitle;
        public static Random rand;
        private static Random gamerand;
        private static Random bombrand;
        private static int randseed;
        private static System.Threading.Timer fpstimer;
        public static int fps;
        public static int fpsup;
        public static int MultiSampleQuality;
        public static MultiSampleType MultiSampleType;

        [DllImport("User32.dll")]
        public static extern bool IsIconic(IntPtr hwnd);

        [DllImport("winmm.dll")]
        public static extern int joyGetPosEx(int uJoyID,ref JOYINFOEX pji);

        private void graphics_PreparingDeviceSettings(object sender,PreparingDeviceSettingsEventArgs e) {
        }

        private void FpsRecord(object obj) {
            fps=fpsup-1;
            if(fps<0)
                fps=0;
            fpsup=0;
            if(!FpsInspect||fps<=0) {
                return;
            }
            int num = 60;
            if(num-fps>0) {
                FpsLost+=num-fps;
            }
            FpsFull+=num;
        }

        public static void OpenFpsInspect() {
            Main.FpsInspect=true;
            Main.FpsLost=0L;
            Main.FpsFull=0L;
        }

        public static float GetFpsLostRate() {
            Main.FpsInspect=false;
            return (float)Main.FpsLost/(float)Main.FpsFull;
        }

        public static int Chaos_GetRandomSeed() {
            byte[] data = new byte[4];
            new RNGCryptoServiceProvider().GetBytes(data);
            return BitConverter.ToInt32(data,0);
        }

        public static void KeyRecordRecover() {
            if(!Main.Replay) {
                Main.prekeyboard=Main.keyboardstat;
            } else {
                for(int index = 0;index<Main.MKeys.Length;++index)
                    Main.preMKeys[index]=Main.MKeys[index];
            }
        }

        public static bool IsKeyDown(Microsoft.Xna.Framework.Input.Keys Key) {
            if(!Program.game.IsActive&&!Main.Replay)
                return false;
            if(!Main.Replay)
                return Main.keyboardstat.IsKeyDown(Key);
            for(int index = 0;index<RecordManager.used.Length;++index) {
                if(Key==RecordManager.used[index])
                    return Main.MKeys[index];
            }
            return false;
        }

        public static bool IsKeyPressed(Microsoft.Xna.Framework.Input.Keys Key) {
            if(!Program.game.IsActive&&!Main.Replay)
                return false;
            if(!Main.Replay)
                return Main.keyboardstat.IsKeyDown(Key)&Main.prekeyboard!=Main.keyboardstat;
            for(int index = 0;index<RecordManager.used.Length;++index) {
                if(Key==RecordManager.used[index])
                    return Main.MKeys[index]&Main.MKeys[index]!=Main.preMKeys[index];
            }
            return false;
        }

        public static bool IsKeyUp(Microsoft.Xna.Framework.Input.Keys Key) {
            if(!Program.game.IsActive&&!Main.Replay)
                return false;
            if(!Main.Replay)
                return Main.keyboardstat.IsKeyUp(Key);
            for(int index = 0;index<RecordManager.used.Length;++index) {
                if(Key==RecordManager.used[index])
                    return !Main.MKeys[index];
            }
            return false;
        }

        public static void SetReplay(RecordManager rm) {
            Main.Replaycontent=rm;
        }

        public static void ResizeWindow(Main game,int size) {
            int num1 = 0;
            int num2 = 0;
            if(size==1) {
                num1=800;
                num2=600;
            } else if(size==2) {
                num1=1280;
                num2=720;
            }
            if(size==0)
                return;
            game.graphics.PreferredBackBufferWidth=num1;
            game.graphics.PreferredBackBufferHeight=num2;
            game.graphics.ApplyChanges();
        }

        public static void Changescreen() {
            Program.game.graphics.ToggleFullScreen();
        }

        public static void Message(string content) {
            int num = (int)MessageBox.Show(content);
        }

        public static void Error(string content) {
            int num = (int)MessageBox.Show(content,"错误",MessageBoxButtons.OK,MessageBoxIcon.Hand);
        }

        public GraphicsDeviceManager GetGDM() {
            return this.graphics;
        }

        public GraphicsDevice GetGD() {
            return this.GraphicsDevice;
        }

        public ContentManager GetCM() {
            return this.Content;
        }

        public static float Twopointangle(float x2,float y2,float x1,float y1) {
            float num = (double)x2-(double)x1==0.0 ? (float)Math.Atan(((double)y2-(double)y1)/((double)x2-(double)x1+0.100000001490116)) : (float)Math.Atan(((double)y2-(double)y1)/((double)x2-(double)x1));
            if((double)x2-(double)x1<0.0)
                num+=3.141593f;
            return num;
        }

        private static float CrossMul(PointF pt1,PointF pt2) {
            return (float)((double)pt1.X*(double)pt2.Y-(double)pt1.Y*(double)pt2.X);
        }

        private static bool CheckCrose(Line line1,Line line2) {
            PointF pt1_1 = new PointF();
            PointF pt1_2 = new PointF();
            PointF pt2 = new PointF();
            pt1_1.X=line2.Start.X-line1.End.X;
            pt1_1.Y=line2.Start.Y-line1.End.Y;
            pt1_2.X=line2.End.X-line1.End.X;
            pt1_2.Y=line2.End.Y-line1.End.Y;
            pt2.X=line1.Start.X-line1.End.X;
            pt2.Y=line1.Start.Y-line1.End.Y;
            return (double)Main.CrossMul(pt1_1,pt2)*(double)Main.CrossMul(pt1_2,pt2)<=0.0;
        }

        public static bool CheckTwoLineCrose(Line line1,Line line2) {
            if(Main.CheckCrose(line1,line2))
                return Main.CheckCrose(line2,line1);
            return false;
        }

        public static bool IsOut(Vector2 pos) {
            Vector2 vector2_1;
            Vector2 vector2_2;
            if(Main.Mode==Modes.SINGLE) {
                vector2_1=new Vector2(32f,416f);
                vector2_2=new Vector2(16f,463f);
            } else {
                vector2_1=new Vector2(0.0f,640f);
                vector2_2=new Vector2(0.0f,480f);
            }
            return (double)pos.X<(double)vector2_1.X||(double)pos.X>(double)vector2_1.Y||((double)pos.Y<(double)vector2_2.X||(double)pos.Y>(double)vector2_2.Y);
        }

        public static bool IsXOut(float x) {
            Vector2 vector2 = Main.Mode!=Modes.SINGLE ? new Vector2(0.0f,640f) : new Vector2(32f,416f);
            return (double)x<(double)vector2.X||(double)x>(double)vector2.Y;
        }

        public static bool IsYDownOut(float y) {
            float num = Main.Mode!=Modes.SINGLE ? 480f : 470f;
            return (double)y>=(double)num;
        }

        public static void SetRandSeed(int seed) {
            Main.randseed=seed;
            Main.gamerand=new Random(Main.randseed);
            Main.bombrand=new Random(Main.randseed);
            Main.randtime=0;
            Main.bombtime=0;
        }

        public static double Rand(bool isbomb) {
            if(isbomb) {
                ++Main.bombtime;
                return Main.bombrand.NextDouble();
            }
            ++Main.randtime;
            return Main.gamerand.NextDouble();
        }

        public void PlaySound(string name) {
            this.sound.Play(name,false,0.0f);
        }

        public void StopSound(string name) {
            this.sound.Stop(name);
        }

        public static RecordManager ReplayContent {
            get {
                return Main.Replaycontent;
            }
        }

        public static int RandSeed {
            get {
                return Main.randseed;
            }
        }

        public Main() {
            try {
                this.sound=new Sound();
                this.graphics=new GraphicsDeviceManager((Microsoft.Xna.Framework.Game)this);
                this.graphics.PreferMultiSampling=false;
                Main.ini=new IniFiles(Directory.GetCurrentDirectory()+"/custom.ini");
                this.Content.RootDirectory="Content/Model";
                this.graphics.PreferredBackBufferWidth=640;
                this.graphics.PreferredBackBufferHeight=480;
                Main.WindowTitle="東方幕華祭 ～ Fantastic Danmaku Festival. ver "+Main.version;
                Main.padinfo=new JOYINFOEX();
                Main.padinfo.dwSize=Marshal.SizeOf(typeof(JOYINFOEX));
                Main.padinfo.dwFlags=128;
                Main.MKeys=new bool[RecordManager.used.Length];
                Main.preMKeys=new bool[RecordManager.used.Length];
                sourseForm=new SourseForm();
                sourseForm.Show();
            } catch(Exception ex) {
                StreamWriter streamWriter = new StreamWriter("Error.txt");
                DateTime now = DateTime.Now;
                streamWriter.Write("["+now.Hour.ToString("00")+":"+now.Minute.ToString("00")+":"+now.Second.ToString("00")+"]\n"+ex.ToString());
                streamWriter.Close();
                Main.Message(ex.ToString());
            }
        }

        protected override void Initialize() {
            try {
                Main.fpstimer=new System.Threading.Timer(new TimerCallback(this.FpsRecord),(object)null,0,1000);
                if(!File.Exists("Content/Music/00.xna")) {
                    StreamWriter streamWriter = new StreamWriter("Content/Music/00.xna",false);
                    streamWriter.WriteLine("Fantasy Danmaku Festival");
                    streamWriter.WriteLine("0");
                    streamWriter.Close();
                    Cry.Encry("Content/Music/00.xna",2);
                }
                if(!File.Exists("Content/Data/4.xna")) {
                    PlayData playData = new PlayData();
                    FileStream fileStream = new FileStream("Content/Data/4.xna",FileMode.Create);
                    new BinaryFormatter().Serialize((Stream)fileStream,(object)playData);
                    fileStream.Close();
                    Cry.Encry("Content/Data/4.xna",2);
                }
                if(!File.Exists("Content/Data/5.xna")) {
                    PracticeData practiceData = new PracticeData();
                    FileStream fileStream = new FileStream("Content/Data/5.xna",FileMode.Create);
                    new BinaryFormatter().Serialize((Stream)fileStream,(object)practiceData);
                    fileStream.Close();
                    Cry.Encry("Content/Data/5.xna",2);
                }
                if(!File.Exists("Content/Data/8.xna")) {
                    SpecialData specialData = new SpecialData();
                    FileStream fileStream = new FileStream("Content/Data/8.xna",FileMode.Create);
                    new BinaryFormatter().Serialize((Stream)fileStream,(object)specialData);
                    fileStream.Close();
                    Cry.Encry("Content/Data/8.xna",2);
                }
                if(!File.Exists("Content/Music/10.xna")) {
                    new StreamWriter("Content/Data/10.xna",false).Close();
                    Cry.Encry("Content/Data/10.xna",2);
                }
                Main.rand=new Random();
                Main.font=new SpriteFontX(new Font("宋体",12f,FontStyle.Regular,GraphicsUnit.Pixel),(IGraphicsDeviceService)this.graphics,TextRenderingHint.ClearTypeGridFit);
                Main.dfont=new SpriteFontX(new Font("微软雅黑",16f,FontStyle.Bold,GraphicsUnit.Pixel),(IGraphicsDeviceService)this.graphics,TextRenderingHint.AntiAlias);
                Main.scfont=new SpriteFontX(new Font("宋体",16f,FontStyle.Bold,GraphicsUnit.Pixel),(IGraphicsDeviceService)this.graphics,TextRenderingHint.AntiAlias);
                Main.scdfont=new SpriteFontX(new Font("宋体",10f,FontStyle.Bold,GraphicsUnit.Pixel),(IGraphicsDeviceService)this.graphics,TextRenderingHint.SingleBitPerPixelGridFit);
                PadState.InitPad(Main.ini);
                Main.WindowSizeType=int.Parse(Main.ini.ReadValue("Graphics","WindowSize"));
                Main.Fullorwindow=int.Parse(Main.ini.ReadValue("Mode","Full/Window"));
                Main.BackGround=int.Parse(Main.ini.ReadValue("Graphics","BackGround"))==1;
                Main.VSync=int.Parse(Main.ini.ReadValue("Graphics","VSync"))==1;
                this.graphics.SynchronizeWithVerticalRetrace=Main.VSync;
                this.IsFixedTimeStep=false;
                Main.ResizeWindow(this,Main.WindowSizeType);
                if(Main.Fullorwindow==1)
                    this.graphics.ToggleFullScreen();
                Sound.Init();
                Music.Init();
                Main.stage="ENTRANCE";
                base.Initialize();
            } catch(Exception ex) {
                StreamWriter streamWriter = new StreamWriter("Error.txt");
                DateTime now = DateTime.Now;
                streamWriter.Write("["+now.Hour.ToString("00")+":"+now.Minute.ToString("00")+":"+now.Second.ToString("00")+"]\n"+ex.ToString());
                streamWriter.Close();
                Main.Message(ex.ToString());
            }
        }

        protected override void LoadContent() {
            try {
                Cry.Key="NYLilMS35bt1RuSa47uRvO1FCYgPVq";
                Cry.Vector="KU4Tn93FEoYca";
                this.spriteBatch=new NSpriteBatch(this.GraphicsDevice);
                this.screen=Texture2D.FromFile(this.GraphicsDevice,Cry.Decry("Content\\Graphics\\Pattern\\screen.xna",0));
                this.achivmanager=new AchievementManager(Texture2D.FromFile(this.GraphicsDevice,Cry.Decry("Content\\Graphics\\Info\\achivboard.xna",0)));
            } catch(Exception ex) {
                StreamWriter streamWriter = new StreamWriter("Error.txt");
                DateTime now = DateTime.Now;
                streamWriter.Write("["+now.Hour.ToString("00")+":"+now.Minute.ToString("00")+":"+now.Second.ToString("00")+"]\n"+ex.ToString());
                streamWriter.Close();
                Main.Message(ex.ToString());
            }
        }

        protected override void Update(GameTime gameTime) {
            if(!Main.VSync)
                Main.timewatch.Start();
            int posEx = Main.joyGetPosEx(0,ref Main.padinfo);
            this.Window.Title=Main.WindowTitle;
            if(this.IsActive) {
                Main.keyboardstat=Keyboard.GetState();
                Main.padstat=PadState.GetState(posEx,Main.padinfo.dwXpos,Main.padinfo.dwYpos,Main.padinfo.dwButtons);
            }
            if(this.entrance!=null) {
                this.entrance.Update();
                if(this.entrance.Finished) {
                    this.entrance=(Entrance)null;
                    Main.gr=new GameResource();
                }
            }
            if(this.game!=null) {
                this.game.SUpdate();
                if(this.game.Finished) {
                    this.game=(Game)null;
                    if(!Main.stage.Contains("PRACTICE")&&!Main.stage.Contains("GAME"))
                        Main.gr=new GameResource();
                }
            }
            if(this.ed!=null) {
                this.ed.Update();
                if(this.ed.Finished)
                    this.ed=(ED)null;
            }
            if(Main.stagecheck!=Main.stage) {
                if(Main.stage=="ENTRANCE")
                    this.entrance=new Entrance(this.GraphicsDevice,Main.gr);
                else if(Main.stage=="GAME") {
                    this.game=new Game(this.GraphicsDevice,Main.gr);
                    Main.MKeys=new bool[RecordManager.used.Length];
                    Main.preMKeys=new bool[RecordManager.used.Length];
                } else if(Main.stage.Contains("GAME")) {
                    this.game=new Game(this.GraphicsDevice,Main.gr,int.Parse(Main.stage.Split(' ')[1]),int.Parse(Main.stage.Split(' ')[2]));
                    Main.MKeys=new bool[RecordManager.used.Length];
                    Main.preMKeys=new bool[RecordManager.used.Length];
                } else if(Main.stage.Contains("PRACTICE")) {
                    this.game=new Game(this.GraphicsDevice,Main.gr,int.Parse(Main.stage.Split(' ')[1]));
                    Main.MKeys=new bool[RecordManager.used.Length];
                    Main.preMKeys=new bool[RecordManager.used.Length];
                } else if(Main.stage.Contains("ED"))
                    this.ed=new ED((Main.ifcontinued ? 1 : 0)!=0,int.Parse(Main.stage.Split(' ')[1]),this.GraphicsDevice,Main.EDrecordsave,Main.EDreplaysave);
            }
            Main.stagecheck=Main.stage;
            this.achivmanager.Update();
            ValueEventManager.Update();
            Music.Update();
            Sound.Update();
            Main.prekeyboard=Main.keyboardstat;
            Main.prepadstat=Main.padstat;
            if(this.game==null)
                return;
            this.game.PreReadSave();
        }

        protected override void Draw(GameTime gameTime) {
            this.GraphicsDevice.Clear(Microsoft.Xna.Framework.Graphics.Color.Black);
            if(!this.spriteBatch.IsBegan)
                this.spriteBatch.Begin();
            if(this.entrance!=null)
                this.entrance.Draw((SpriteBatch)this.spriteBatch);
            if(this.game!=null)
                this.game.SDraw(this.spriteBatch);
            if(this.ed!=null)
                this.ed.Draw((SpriteBatch)this.spriteBatch);
            Main.font.Draw((SpriteBatch)this.spriteBatch,Main.fps.ToString().PadLeft(2,'0'),new Vector2(629f,470f),Microsoft.Xna.Framework.Graphics.Color.Black);
            Main.font.Draw((SpriteBatch)this.spriteBatch,Main.fps.ToString().PadLeft(2,'0'),new Vector2(628f,469f),Microsoft.Xna.Framework.Graphics.Color.White);
            this.achivmanager.Draw((SpriteBatch)this.spriteBatch);
            if(this.spriteBatch.IsBegan)
                this.spriteBatch.End();
            if(Main.WindowSizeType!=0) {
                PresentationParameters presentationParameters = this.graphics.GraphicsDevice.PresentationParameters;
                if(this.resolveTexture!=null)
                    this.resolveTexture.Dispose();
                this.resolveTexture=new ResolveTexture2D(this.GraphicsDevice,presentationParameters.BackBufferWidth,presentationParameters.BackBufferHeight,0,this.GraphicsDevice.DisplayMode.Format);
                this.graphics.GraphicsDevice.ResolveBackBuffer(this.resolveTexture);
                this.GraphicsDevice.Clear(Microsoft.Xna.Framework.Graphics.Color.Black);
                if(!this.spriteBatch.IsBegan)
                    this.spriteBatch.Begin(SpriteBlendMode.AlphaBlend,SpriteSortMode.Immediate,SaveStateMode.None);
                switch(Main.WindowSizeType) {
                    case 1:
                        this.spriteBatch.Draw((Texture2D)this.resolveTexture,Vector2.Zero,new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0,0,640,480)),Microsoft.Xna.Framework.Graphics.Color.White,0.0f,Vector2.Zero,1.25f,SpriteEffects.None,0.0f);
                        break;
                    case 2:
                        this.spriteBatch.Draw(this.screen,Vector2.Zero,Microsoft.Xna.Framework.Graphics.Color.White);
                        this.spriteBatch.Draw((Texture2D)this.resolveTexture,new Vector2(160f,0.0f),new Microsoft.Xna.Framework.Rectangle?(new Microsoft.Xna.Framework.Rectangle(0,0,640,480)),Microsoft.Xna.Framework.Graphics.Color.White,0.0f,Vector2.Zero,1.5f,SpriteEffects.None,0.0f);
                        break;
                }
                if(this.spriteBatch.IsBegan)
                    this.spriteBatch.End();
            }
            ++Main.fpsup;
            if(Main.VSync)
                return;
            float num = Main.Fullorwindow==1 ? 16f : 15f;
            if((double)Main.timewatch.GetDuration()>=(double)num)
                return;
            do {
                Thread.Sleep(1);
            }
            while((double)Main.timewatch.GetDuration()<(double)num);
        }
    }
}
