using SlimDX;
using SlimDX.Direct3D9;
using SlimDX.XAudio2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Shooting {
    public class GlobalDataPackage {
        public KeyClass KClass = new KeyClass();
        public bool Clear = false;
        public int BGMVolume = 100;
        public int SEVolume = 80;
        public string FontType = "宋体";
        public const int WindowWidth = 640;
        public const int WindowHeight = 480;
        public XAudio2 DeviceXaudio2;
        public MasteringVoice MasteringVoice;
        public Device DeviceMain;
        public PresentParameters presentParams;
        public MySprite SpriteMain;
        public Effect EffectMain;
        public Dictionary<string,Effect> EffectDictionary;
        public Dictionary<string,TextureObject> TextureObjectDictionary;
        public Dictionary<string,XAudio2_Player> SoundDictionary;
        public Dictionary<string,IModel> ModelDictionary;
        public Dictionary<string,bool[,]> BulletPicDictionary;
        public Wave_Player BGM_Player;
        public List<string> LoadingList;
        public Replay Rep;
        public PlayerData PData;
        public ScreenTexManager ScreenTexMan;
        public IGameState LastState;
        private bool SoundInitSuccess;

        public GlobalDataPackage() {
            TextureObjectDictionary=new Dictionary<string,TextureObject>();
            try {
                DeviceXaudio2=new XAudio2();
                MasteringVoice=new MasteringVoice(DeviceXaudio2);
                SoundInitSuccess=true;
                BGM_Player=new Wave_Player(DeviceXaudio2);
            } catch {
                MessageBox.Show("音频设备故障","Sound Initial Error");
            }
        }

        public void LoadResources1() {
            ScreenTexMan=new ScreenTexManager(DeviceMain);
            do { } while(!LoadEffect());
            LoadingList=new List<string>();
            LoadFolderTextureList(".\\Image");
        }

        public void LoadResources() {
            PData=new PlayerData();
            LoadSound();
            LoadBulletPic();
            while(LoadingList.Count>0) {
                Thread.Sleep(1);
            }
            Hash.Init();
        }

        public void LoadFolderTextureList(string Path) {
            if(Path==".\\Image\\NowLoading")
                return;
            foreach(string file in Directory.GetFiles(Path,"*.png")) {
                LoadingList.Add(new FileInfo(file).FullName);
            }
            foreach(string directory in Directory.GetDirectories(Path)) {
                LoadFolderTextureList(directory);
            }
        }

        private bool LoadEffect() {
            EffectDictionary=new Dictionary<string,Effect>();
            try {
                EffectDictionary.Add("Blur",Effect.FromFile(DeviceMain,".\\FX\\Blur.fx",ShaderFlags.None));
                EffectDictionary.Add("Warp",Effect.FromFile(DeviceMain,".\\FX\\Warp.fx",ShaderFlags.None));
                EffectDictionary.Add("Filter",Effect.FromFile(DeviceMain,".\\FX\\Filter.fx",ShaderFlags.None));
                return true;
            } catch {
                return false;
            }
        }

        public void LoadModelDictionary() {
            ModelDictionary=new Dictionary<string,IModel>();
            LoadModel("Petal00",0);
            LoadModel("Petal01",0);
            LoadModel("Petal02",0);
            LoadModel("Petal03",0);
            LoadModel("Petal10",0);
            LoadModel("Petal11",0);
            LoadModel("Petal12",0);
            LoadModel("Petal13",0);
            LoadModel("Petal20",0);
            LoadModel("Petal21",0);
            LoadModel("Petal22",0);
            LoadModel("Petal23",0);
            LoadModel("Petal30",0);
            LoadModel("Petal31",0);
            LoadModel("Petal32",0);
            LoadModel("Petal33",0);
            LoadModel("Effect-0",0);
            LoadModel("Effect-1",0);
            LoadModel("BG02d",0);
            LoadModel("liba",0);
            LoadModel("zhu",0);
            LoadModel("柳树",0);
            LoadModel("草地",0);
            LoadModel("地砖",0);
            LoadModel("黑暗滤镜",0);
            LoadModel("极光素材",0);
            LoadModel("万花镜素材",0);
            LoadModel("草地ex",0);
            LoadModel("Tree1",0);
            LoadModel("Tree2",0);
            LoadModel("591-1",0);
            LoadModel("591-1R",0);
            LoadModel("Leaf",0);
            LoadModel("Tree",0);
            LoadModel("Cloud01",0);
            LoadModel("Cloud02",0);
            LoadModel("夜空（暗）",0);
            LoadModel("夜空（亮）",0);
            LoadModel("云（暗层）",0);
            LoadModel("云（亮层）",0);
            LoadModel("BG01a",0);
            LoadModel("Stair",2);
            LoadModel("祭坛",2);
        }

        private void LoadModel(string Name,int ModelType) {
            bool flag = false;
            int num1 = 0;
            while(!flag&&num1<20) {
                try {
                    switch(ModelType) {
                        case 0:
                            IModel model1 = new Model(DeviceMain,TextureObjectDictionary[Name],Name);
                            ModelDictionary.Add(Name,model1);
                            break;
                        case 1:
                            IModel model2 = new Model_Circle(DeviceMain,TextureObjectDictionary[Name],Name);
                            ModelDictionary.Add(Name,model2);
                            break;
                        case 2:
                            IModel model3 = new Model_Mesh(DeviceMain,Name) {
                                GlobalData=this
                            };
                            ModelDictionary.Add(model3.Name,model3);
                            break;
                    }
                    flag=true;
                } catch {
                    flag=false;
                    ++num1;
                }
            }
            if(num1!=20) {
                return;
            }
            MessageBox.Show(Name+"模型生成时出错","LoadModel Error");
        }

        private void LoadBulletPic() {
            try {
                BulletPicDictionary=new Dictionary<string,bool[,]>();
                for(int index = 0;index<Directory.GetFiles(".\\BPic","*.png").Length;++index) {
                    FileInfo fileInfo = new FileInfo(Directory.GetFiles(".\\BPic","*.png")[index]);
                    Bitmap bitmap = (Bitmap)Image.FromFile(fileInfo.FullName);
                    bool[,] flagArray = new bool[bitmap.Width,bitmap.Height];
                    for(int x = 0;x<bitmap.Width;++x) {
                        for(int y = 0;y<bitmap.Height;++y)
                            flagArray[x,y]=bitmap.GetPixel(x,y).G<128;
                    }
                    BulletPicDictionary.Add(fileInfo.Name,flagArray);
                }
            } catch {
                MessageBox.Show("图像读取错误","LoadBPic Error");
            }
        }

        public void LoadSound() {
            if(!SoundInitSuccess) {
                return;
            }
            SoundDictionary=new Dictionary<string,XAudio2_Player>();
            for(int index = 0;index<Directory.GetFiles(".\\Sound","*.wav").Length;++index) {
                FileInfo fileInfo = new FileInfo(Directory.GetFiles(".\\Sound","*.wav")[index]);
                SoundDictionary.Add(fileInfo.Name,new XAudio2_Player(fileInfo.FullName,DeviceXaudio2) {
                    Volume=SEVolume
                });
                if(!SoundDictionary[fileInfo.Name].loadSuccess) {
                    MessageBox.Show(fileInfo.Name+"读取错误","LoadSound Error");
                }
            }
        }

        public void TextureObjectLoader(string imageFileName) => TextureObjectLoader(imageFileName,0);

        public void TextureObjectLoader(string imageFileName,int colorKey) {
            if(!File.Exists(imageFileName)) {
                return;
            }
            Bitmap bitmap = (Bitmap)Image.FromFile(imageFileName);
            Rectangle Rect = new Rectangle(0,0,bitmap.Width,bitmap.Height);
            bitmap.Dispose();
            int num1 = 0;
            Texture texture;
            do { } while(!SetTexture(imageFileName,colorKey,Rect,out texture)&&num1++<20);
            if(num1>=20) {
                MessageBox.Show(imageFileName+"纹理读取错误","LoadTexture Error");
            }
            FileInfo fileInfo = new FileInfo(imageFileName);
            string path = fileInfo.FullName.Replace(fileInfo.Extension,".txt");
            if(File.Exists(path)) {
                char[] chArray = new char[1] { '\t' };
                foreach(string readAllLine in File.ReadAllLines(path,Encoding.Default)) {
                    string[] strArray = readAllLine.Split(chArray);
                    TextureObjectDictionary.Add(strArray[0],new TextureObject() {
                        TXTure=texture,
                        PosRect=new Rectangle(Convert.ToInt32(strArray[1]),Convert.ToInt32(strArray[2]),Convert.ToInt32(strArray[3]),Convert.ToInt32(strArray[4])),
                        OffsetX=Convert.ToInt32(strArray[5]),
                        OffsetY=Convert.ToInt32(strArray[6]),
                        SrcWidth=Rect.Width,
                        SrcHeight=Rect.Height
                    });
                }
            } else
                TextureObjectDictionary.Add(fileInfo.Name.Replace(".png",""),new TextureObject() {
                    TXTure=texture,
                    PosRect=new Rectangle(0,0,Rect.Width,Rect.Height),
                    SrcWidth=Rect.Width,
                    SrcHeight=Rect.Height
                });
        }

        private bool SetTexture(string imageFileName,int colorKey,Rectangle Rect,out Texture texture) {
            try {
                texture=Texture.FromFile(DeviceMain,imageFileName,Rect.Width,Rect.Height,0,Usage.None,Format.Unknown,Pool.Managed,Filter.Linear,Filter.None,colorKey);
                return true;
            } catch {
                texture=null;
                return false;
            }
        }

        public void BGM_Play(string FileName) {
            try {
                int bgmVolume = BGMVolume;
                BGM_Player.FileName=FileName;
                BGM_Player.Volume=bgmVolume;
                BGM_Player.Play();
            } catch {
            }
        }

        public void BGM_OFF() => BGM_Player.Stop();

        public void BGM_Pause() => BGM_Player.Puase();

        public void BGM_Resume() {
            if(BGM_Player==null) {
                return;
            }
            BGM_Player.Resume();
        }

        public void OnLostDevice() {
            if(SpriteMain!=null) {
                SpriteMain.sprite.OnLostDevice();
            }
            if(ScreenTexMan!=null) {
                ScreenTexMan.Dispose();
            }
            if(EffectDictionary==null) {
                return;
            }
            foreach(Effect effect in EffectDictionary.Values) {
                effect.OnLostDevice();
            }
        }

        public void OnResetDevice() {
            SpriteMain.sprite.OnResetDevice();
            DeviceMain.Reset(presentParams);
            if(ScreenTexMan!=null) {
                ScreenTexMan.Reset();
            }
            if(EffectDictionary==null) {
                return;
            }
            foreach(Effect effect in EffectDictionary.Values) {
                effect.OnResetDevice();
            }
        }

        public void Dispose() {
            DeviceMain.Direct3D.Dispose();
            SpriteMain.Dispose();
            if(TextureObjectDictionary!=null) {
                foreach(TextureObject textureObject in TextureObjectDictionary.Values) {
                    textureObject.Dispose();
                }
            }
            if(SoundDictionary!=null) {
                foreach(XAudio2_Player xaudio2Player in SoundDictionary.Values) {
                    xaudio2Player.Dispose();
                }
            }
            if(BGM_Player!=null) {
                BGM_Player.Dispose();
            }
            if(ScreenTexMan!=null) {
                ScreenTexMan.Dispose();
            }
            if(EffectDictionary!=null) {
                foreach(ComObject comObject in EffectDictionary.Values) {
                    comObject.Dispose();
                }
            }
            if(ModelDictionary!=null) {
                foreach(Model model in ModelDictionary.Values)
                    model.Dispose();
            }
            if(DeviceXaudio2==null) {
                return;
            }
            DeviceXaudio2.Dispose();
        }
    }
}
