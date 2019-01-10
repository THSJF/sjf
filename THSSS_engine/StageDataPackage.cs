using SlimDX;
using SlimDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;

namespace Shooting {
    public class StageDataPackage {
        public MyRandom Ran = new MyRandom();
        public bool C_Check = false;
        public bool OnReplay = false;
        public bool OnPractice = false;
        public int ContinueTimes = 0;
        private int VibrateTime = -1;
        public int SlowMode = 0;
        public string CurrentStageName = null;
        public string SCBstring = null;
        public Dictionary<string,CS_Data> CS_Cathe = new Dictionary<string,CS_Data>();
        public StateSwitchDataPackage StateSwitchData;
        public ReplayInfo RepInfo;
        public long TimeTotal;
        public long RealTimeTotal;
        public int TimeMain;
        public Rectangle BoundRect;
        public BaseMyPlane MyPlane;
        public BaseBossTouhou Boss;
        public List<BaseBullet_Touhou> BulletList;
        public List<BaseObject> MyBulletList;
        public List<BaseEnemyPlane> EnemyPlaneList;
        public List<BaseEffect> EffectList;
        public List<BaseObject> SpellList;
        public List<BaseObject> InterfaceList;
        public List<BaseItem> ItemList;
        public BaseStory Story;
        public BackgroundManager Background;
        public BackgroundManager Background2;
        public BackgroundManager3D Background3D;
        public ParticleManager3D Particle3D;
        public List<XAudio2_Player> SoundPlayList;
        public List<BaseMenuGroup> MenuGroupList;
        public DifficultLevel Difficulty;
        private Rectangle VibrateRectSave;
        public ClearHistory C_History { get; set; }
        public List<ScoreHistory> S_History { get; set; }
        public GlobalDataPackage GlobalData { get; set; }
        public Device DeviceMain => GlobalData.DeviceMain;
        public Dictionary<string,IModel> ModelDictionary => GlobalData.ModelDictionary;
        public Dictionary<string,TextureObject> TextureObjectDictionary => GlobalData.TextureObjectDictionary;
        public Dictionary<string,XAudio2_Player> SoundDictionary => GlobalData.SoundDictionary;
        public Wave_Player BGM_Player {
            get => GlobalData.BGM_Player;
            set => GlobalData.BGM_Player=value;
        }
        public KeyClass KClass => GlobalData.KClass;
        public MySprite SpriteMain => GlobalData.SpriteMain;
        public Replay Rep => GlobalData.Rep;
        public ScreenTexManager ScreenTexMan => GlobalData.ScreenTexMan;
        public Effect EffectMain {
            get => GlobalData.EffectMain;
            set => GlobalData.EffectMain=value;
        }
        public Dictionary<string,Effect> EffectDictionary => GlobalData.EffectDictionary;

        public PlayerData PData {
            get => GlobalData.PData;
            set => GlobalData.PData=value;
        }
        public string SlowRate {
            get {
                float num1 = 60f*RealTimeTotal/Stopwatch.Frequency;
                float num2 = (float)((num1-(double)TimeTotal)*100.0)/num1;
                return (num2<0.0 ? 0.0f : num2).ToString("F1")+"%";
            }
        }
        public StageDataPackage(GlobalDataPackage GlobalData) {
            this.GlobalData=GlobalData;
            Init();
        }
        public void Init() {
            BoundRect=new Rectangle(0,0,640,480);
            BulletList=new List<BaseBullet_Touhou>();
            EnemyPlaneList=new List<BaseEnemyPlane>();
            MyBulletList=new List<BaseObject>();
            SpellList=new List<BaseObject>();
            EffectList=new List<BaseEffect>();
            ItemList=new List<BaseItem>();
            InterfaceList=new List<BaseObject>();
            SoundPlayList=new List<XAudio2_Player>();
            Background=new BackgroundManager();
            Background2=new BackgroundManager();
            Background3D=new BackgroundManager3D(this);
            Particle3D=new ParticleManager3D(this);
            MenuGroupList=new List<BaseMenuGroup>();
            TimeMain=0;
            RepInfo=new ReplayInfo();
        }
        public void Vibrate() {
            if(VibrateTime>TimeMain) {
                int maxValue = VibrateTime-TimeMain>=20 ? 10 : (VibrateTime-TimeMain)/2;
                BoundRect=new Rectangle(VibrateRectSave.X+(Ran.Next(maxValue)-maxValue/2),VibrateRectSave.Y+(Ran.Next(maxValue)-maxValue/2),VibrateRectSave.Width,VibrateRectSave.Height);
            } else {
                if(VibrateTime!=TimeMain) return;
                BoundRect=VibrateRectSave;
            }
        }
        public void VibrateStart(int CuntinueTime) {
            if(VibrateTime<TimeMain) VibrateRectSave=BoundRect;
            VibrateTime=TimeMain+CuntinueTime;
        }
        public void VibrateStop() {
            if(VibrateTime<TimeMain) return;
            VibrateTime=-1;
            BoundRect=VibrateRectSave;
        }
        public void RemoveBullets() {
            foreach(BaseObject bullet in BulletList)
                bullet.GiveEndEffect();
            BulletList.Clear();
            foreach(BaseEnemyPlane enemyPlane in EnemyPlaneList) {
                enemyPlane.GiveEndEffect();
                if(enemyPlane.TxtureObject!=null) SoundPlay("se_enep00.wav");
            }
            EnemyPlaneList.Clear();
            foreach(BaseObject bullet in MyBulletList) {
                ParticleSmaller particleSmaller = new ParticleSmaller(this,"光点",bullet.Position,bullet.Velocity,bullet.Direction);
                particleSmaller.LifeTime=30;
                particleSmaller.Scale=0.5f;
            }
            MyBulletList.Clear();
        }
        public void SoundPlay(string MusicName) => SoundPlay(MusicName,0.5f);
        public void SoundPlay(string MusicName,float VoicePos) {
            if(MusicName==null||!SoundDictionary.ContainsKey(MusicName)) return;
            if(!SoundPlayList.Contains(SoundDictionary[MusicName])) {
                SoundDictionary[MusicName].VoicePos=VoicePos;
                SoundPlayList.Add(SoundDictionary[MusicName]);
            } else {

                SoundDictionary[MusicName].VoicePos=(float)((VoicePos+(double)SoundDictionary[MusicName].VoicePos)/2.0);
            }
        }

        public void ChangeBGM(string MusicName,int PlayBegin,int PlayLength,int LoopCount,int LoopBegin,int LoopEnd) {
            int bgmVolume = GlobalData.BGMVolume;
            BGM_Player.FileName=MusicName;
            BGM_Player.Volume=bgmVolume;
            BGM_Player.PlayRepeat(PlayBegin,PlayLength,LoopCount,LoopBegin,LoopEnd);
        }

        public void ChangeBGM(string MusicName,bool Repeat) {
            if(Repeat) {
                ChangeBGM(MusicName,0,0,byte.MaxValue,0,0);
            } else {
                ChangeBGM(MusicName,0,0,0,0,0);
            }
        }

        public void SetReplayInfo(string StartStage) {
            RepInfo.MyPlaneName=MyPlane.Name;
            RepInfo.Rank=Difficulty;
            RepInfo.WeaponType=MyPlane.WeaponType;
            RepInfo.StartStage=StartStage;
            SetReplayStageInfo();
        }

        public void SetReplayStageInfo() {
            if(OnReplay||RepInfo.MyPlaneData.Count>0&&RepInfo.MyPlaneData[RepInfo.MyPlaneData.Count-1].DataPosition+2L==Rep.DataPosition) return;
            RepInfo.LastStage=CurrentStageName;
            RepInfo.SlowRate=SlowRate;
            List<MyPlaneInfo> planeData = RepInfo.MyPlaneData;
            MyPlaneInfo myPlaneInfo1 = new MyPlaneInfo();
            myPlaneInfo1.Score=MyPlane.Score;
            myPlaneInfo1.Life=MyPlane.Life;
            myPlaneInfo1.Spell=MyPlane.Spell;
            myPlaneInfo1.Power=MyPlane.Power;
            myPlaneInfo1.Graze=MyPlane.Graze;
            MyPlaneInfo myPlaneInfo2 = myPlaneInfo1;
            PointF originalPosition = MyPlane.OriginalPosition;
            double x = originalPosition.X;
            myPlaneInfo2.PosX=(float)x;
            MyPlaneInfo myPlaneInfo3 = myPlaneInfo1;
            originalPosition=MyPlane.OriginalPosition;
            double y = originalPosition.Y;
            myPlaneInfo3.PosY=(float)y;
            myPlaneInfo1.LifeChip=MyPlane.LifeChip;
            myPlaneInfo1.SpellChip=MyPlane.SpellChip;
            myPlaneInfo1.LifeUpCount=MyPlane.LifeUpCount;
            myPlaneInfo1.StarPoint=MyPlane.StarPoint;
            myPlaneInfo1.HighItemScore=MyPlane.HighItemScore;
            myPlaneInfo1.Rate=MyPlane.Rate;
            myPlaneInfo1.LastColor=MyPlane.LastColor;
            myPlaneInfo1.DataPosition=Rep.DataPosition;
            MyPlaneInfo myPlaneInfo4 = myPlaneInfo1;
            planeData.Add(myPlaneInfo4);
            Rep.WriteKey(57358);
        }
        public bool FindScore(ScoreHistory SH) => SH.Rank==Difficulty&&SH.MyPlaneFullName==MyPlane.FullName;
        public bool FindClear(ClearHistory CH) => CH.Rank==Difficulty&&CH.MyPlaneFullName==MyPlane.FullName;
        public void PreLoadCS(string Path) {
            foreach(string file in Directory.GetFiles(Path,"*.mbg")) {
                FileInfo fileInfo = new FileInfo(file);
                CS_Data csData = new CS_Data(file);
                csData.String2Data(this);
                CS_Cathe.Add(file,csData);
            }
            foreach(string directory in Directory.GetDirectories(Path)) {
                PreLoadCS(directory);
            }
        }
        public void ClearCSCathe() => CS_Cathe.Clear();
        public CS_Data LoadCS(string FileName) {
            if(CS_Cathe.ContainsKey(FileName)) return CS_Cathe[FileName];
            CS_Data csData = new CS_Data(FileName);
            csData.String2Data(this);
            return csData;
        }
        public Texture DrawString(string text,System.Drawing.Font font,Brush brush,int width,int height) {
            Bitmap bitmap = new Bitmap(width,height,PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.TextRenderingHint=TextRenderingHint.AntiAlias;
            graphics.DrawString(text,font,brush,0.0f,0.0f);
            graphics.Dispose();
            Texture texture = new Texture(DeviceMain,width,height,1,Usage.None,Format.A8R8G8B8,Pool.Managed);
            texture.GetLevelDescription(0);
            DataRectangle dataRectangle = texture.LockRectangle(0,new Rectangle(0,0,width,height),LockFlags.Discard);
            BitmapData bitmapdata = bitmap.LockBits(new Rectangle(0,0,width,height),ImageLockMode.ReadOnly,bitmap.PixelFormat);
            IntPtr scan0 = bitmapdata.Scan0;
            dataRectangle.Data.WriteRange(scan0,bitmapdata.Width*bitmapdata.Height*4);
            bitmap.UnlockBits(bitmapdata);
            texture.UnlockRectangle(0);
            bitmap.Dispose();
            return texture;
        }
        public void Dispose() {
            if(Background3D!=null) Background3D.Dispose();
            if(Particle3D!=null) Particle3D.Dispose();
            if(Rep==null) return;
            Rep.Dispose();
        }
    }
}
