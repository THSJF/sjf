// Decompiled with JetBrains decompiler
// Type: Shooting.GlobalDataPackage
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

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

namespace Shooting
{
  public class GlobalDataPackage
  {
    public KeyClass KClass = new KeyClass();
    public bool Clear = false;
    public int BGMVolume = 100;
    public int SEVolume = 80;
    public string FontType = "宋体";
    public const int WindowWidth = 640;
    public const int WindowHeight = 480;
    public SlimDX.XAudio2.XAudio2 DeviceXaudio2;
    public MasteringVoice MasteringVoice;
    public Device DeviceMain;
    public PresentParameters presentParams;
    public MySprite SpriteMain;
    public Effect EffectMain;
    public Dictionary<string, Effect> EffectDictionary;
    public Dictionary<string, TextureObject> TextureObjectDictionary;
    public Dictionary<string, XAudio2_Player> SoundDictionary;
    public Dictionary<string, IModel> ModelDictionary;
    public Dictionary<string, bool[,]> BulletPicDictionary;
    public Wave_Player BGM_Player;
    public List<string> LoadingList;
    public Replay Rep;
    public PlayerData PData;
    public ScreenTexManager ScreenTexMan;
    public IGameState LastState;
    private bool SoundInitSuccess;

    public GlobalDataPackage()
    {
      this.TextureObjectDictionary = new Dictionary<string, TextureObject>();
      try
      {
        this.DeviceXaudio2 = new SlimDX.XAudio2.XAudio2();
        this.MasteringVoice = new MasteringVoice(this.DeviceXaudio2);
        this.SoundInitSuccess = true;
        this.BGM_Player = new Wave_Player(this.DeviceXaudio2);
      }
      catch
      {
        int num = (int) MessageBox.Show("音频设备故障", "Sound Initial Error");
      }
    }

    public void LoadResources1()
    {
      this.ScreenTexMan = new ScreenTexManager(this.DeviceMain);
            do { }
            while(!this.LoadEffect());
      this.LoadingList = new List<string>();
      this.LoadFolderTextureList(".\\Image");
    }

    public void LoadResources()
    {
      this.PData = new PlayerData();
      this.LoadSound();
      this.LoadBulletPic();
      while (this.LoadingList.Count > 0)
        Thread.Sleep(1);
      Hash.Init();
    }

    public void LoadFolderTextureList(string Path)
    {
      if (Path == ".\\Image\\NowLoading")
        return;
      foreach (string file in Directory.GetFiles(Path, "*.png"))
        this.LoadingList.Add(new FileInfo(file).FullName);
      foreach (string directory in Directory.GetDirectories(Path))
        this.LoadFolderTextureList(directory);
    }

    private bool LoadEffect()
    {
      this.EffectDictionary = new Dictionary<string, Effect>();
      try
      {
        this.EffectDictionary.Add("Blur", Effect.FromFile(this.DeviceMain, ".\\FX\\Blur.fx", ShaderFlags.None));
        this.EffectDictionary.Add("Warp", Effect.FromFile(this.DeviceMain, ".\\FX\\Warp.fx", ShaderFlags.None));
        this.EffectDictionary.Add("Filter", Effect.FromFile(this.DeviceMain, ".\\FX\\Filter.fx", ShaderFlags.None));
        return true;
      }
      catch
      {
        return false;
      }
    }

    public void LoadModelDictionary()
    {
      this.ModelDictionary = new Dictionary<string, IModel>();
      this.LoadModel("Petal00", 0);
      this.LoadModel("Petal01", 0);
      this.LoadModel("Petal02", 0);
      this.LoadModel("Petal03", 0);
      this.LoadModel("Petal10", 0);
      this.LoadModel("Petal11", 0);
      this.LoadModel("Petal12", 0);
      this.LoadModel("Petal13", 0);
      this.LoadModel("Petal20", 0);
      this.LoadModel("Petal21", 0);
      this.LoadModel("Petal22", 0);
      this.LoadModel("Petal23", 0);
      this.LoadModel("Petal30", 0);
      this.LoadModel("Petal31", 0);
      this.LoadModel("Petal32", 0);
      this.LoadModel("Petal33", 0);
      this.LoadModel("Effect-0", 0);
      this.LoadModel("Effect-1", 0);
      this.LoadModel("BG02d", 0);
      this.LoadModel("liba", 0);
      this.LoadModel("zhu", 0);
      this.LoadModel("柳树", 0);
      this.LoadModel("草地", 0);
      this.LoadModel("地砖", 0);
      this.LoadModel("黑暗滤镜", 0);
      this.LoadModel("极光素材", 0);
      this.LoadModel("万花镜素材", 0);
      this.LoadModel("草地ex", 0);
      this.LoadModel("Tree1", 0);
      this.LoadModel("Tree2", 0);
      this.LoadModel("591-1", 0);
      this.LoadModel("591-1R", 0);
      this.LoadModel("Leaf", 0);
      this.LoadModel("Tree", 0);
      this.LoadModel("Cloud01", 0);
      this.LoadModel("Cloud02", 0);
      this.LoadModel("夜空（暗）", 0);
      this.LoadModel("夜空（亮）", 0);
      this.LoadModel("云（暗层）", 0);
      this.LoadModel("云（亮层）", 0);
      this.LoadModel("BG01a", 0);
      this.LoadModel("Stair", 2);
      this.LoadModel("祭坛", 2);
    }

    private void LoadModel(string Name, int ModelType)
    {
      bool flag = false;
      int num1 = 0;
      while (!flag && num1 < 20)
      {
        try
        {
          switch (ModelType)
          {
            case 0:
              IModel model1 = (IModel) new Model(this.DeviceMain, this.TextureObjectDictionary[Name], Name);
              this.ModelDictionary.Add(Name, model1);
              break;
            case 1:
              IModel model2 = (IModel) new Model_Circle(this.DeviceMain, this.TextureObjectDictionary[Name], Name);
              this.ModelDictionary.Add(Name, model2);
              break;
            case 2:
              IModel model3 = (IModel) new Model_Mesh(this.DeviceMain, Name)
              {
                GlobalData = this
              };
              this.ModelDictionary.Add(model3.Name, model3);
              break;
          }
          flag = true;
        }
        catch
        {
          flag = false;
          ++num1;
        }
      }
      if (num1 != 20)
        return;
      int num2 = (int) MessageBox.Show(Name + "模型生成时出错", "LoadModel Error");
    }

    private void LoadBulletPic()
    {
      try
      {
        this.BulletPicDictionary = new Dictionary<string, bool[,]>();
        for (int index = 0; index < Directory.GetFiles(".\\BPic", "*.png").Length; ++index)
        {
          FileInfo fileInfo = new FileInfo(Directory.GetFiles(".\\BPic", "*.png")[index]);
          Bitmap bitmap = (Bitmap) Image.FromFile(fileInfo.FullName);
          bool[,] flagArray = new bool[bitmap.Width, bitmap.Height];
          for (int x = 0; x < bitmap.Width; ++x)
          {
            for (int y = 0; y < bitmap.Height; ++y)
              flagArray[x, y] = bitmap.GetPixel(x, y).G < (byte) 128;
          }
          this.BulletPicDictionary.Add(fileInfo.Name, flagArray);
        }
      }
      catch
      {
        int num = (int) MessageBox.Show("图像读取错误", "LoadBPic Error");
      }
    }

    public void LoadSound()
    {
      if (!this.SoundInitSuccess)
        return;
      this.SoundDictionary = new Dictionary<string, XAudio2_Player>();
      for (int index = 0; index < Directory.GetFiles(".\\Sound", "*.wav").Length; ++index)
      {
        FileInfo fileInfo = new FileInfo(Directory.GetFiles(".\\Sound", "*.wav")[index]);
        this.SoundDictionary.Add(fileInfo.Name, new XAudio2_Player(fileInfo.FullName, this.DeviceXaudio2)
        {
          Volume = this.SEVolume
        });
        if (!this.SoundDictionary[fileInfo.Name].loadSuccess)
        {
          int num = (int) MessageBox.Show(fileInfo.Name + "读取错误", "LoadSound Error");
        }
      }
    }

    public void TextureObjectLoader(string imageFileName)
    {
      this.TextureObjectLoader(imageFileName, 0);
    }

    public void TextureObjectLoader(string imageFileName, int colorKey)
    {
      if (!File.Exists(imageFileName))
        return;
      Bitmap bitmap = (Bitmap) Image.FromFile(imageFileName);
      Rectangle Rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
      bitmap.Dispose();
      int num1 = 0;
      Texture texture;
            do { }
            while(!this.SetTexture(imageFileName,colorKey,Rect,out texture)&&num1++<20);
      if (num1 >= 20)
      {
        int num2 = (int) MessageBox.Show(imageFileName + "纹理读取错误", "LoadTexture Error");
      }
      FileInfo fileInfo = new FileInfo(imageFileName);
      string path = fileInfo.FullName.Replace(fileInfo.Extension, ".txt");
      if (File.Exists(path))
      {
        char[] chArray = new char[1]{ '\t' };
        foreach (string readAllLine in File.ReadAllLines(path, Encoding.Default))
        {
          string[] strArray = readAllLine.Split(chArray);
          this.TextureObjectDictionary.Add(strArray[0], new TextureObject()
          {
            TXTure = texture,
            PosRect = new Rectangle(Convert.ToInt32(strArray[1]), Convert.ToInt32(strArray[2]), Convert.ToInt32(strArray[3]), Convert.ToInt32(strArray[4])),
            OffsetX = Convert.ToInt32(strArray[5]),
            OffsetY = Convert.ToInt32(strArray[6]),
            SrcWidth = Rect.Width,
            SrcHeight = Rect.Height
          });
        }
      }
      else
        this.TextureObjectDictionary.Add(fileInfo.Name.Replace(".png", ""), new TextureObject()
        {
          TXTure = texture,
          PosRect = new Rectangle(0, 0, Rect.Width, Rect.Height),
          SrcWidth = Rect.Width,
          SrcHeight = Rect.Height
        });
    }

    private bool SetTexture(
      string imageFileName,
      int colorKey,
      Rectangle Rect,
      out Texture texture)
    {
      try
      {
        texture = Texture.FromFile(this.DeviceMain, imageFileName, Rect.Width, Rect.Height, 0, Usage.None, SlimDX.Direct3D9.Format.Unknown, Pool.Managed, SlimDX.Direct3D9.Filter.Linear, SlimDX.Direct3D9.Filter.None, colorKey);
        return true;
      }
      catch
      {
        texture = (Texture) null;
        return false;
      }
    }

    public void BGM_Play(string FileName)
    {
      try
      {
        int bgmVolume = this.BGMVolume;
        this.BGM_Player.FileName = FileName;
        this.BGM_Player.Volume = bgmVolume;
        this.BGM_Player.Play();
      }
      catch
      {
      }
    }

    public void BGM_OFF()
    {
      this.BGM_Player.Stop();
    }

    public void BGM_Pause()
    {
      this.BGM_Player.Puase();
    }

    public void BGM_Resume()
    {
      if (this.BGM_Player == null)
        return;
      this.BGM_Player.Resume();
    }

    public void OnLostDevice()
    {
      if (this.SpriteMain != null)
        this.SpriteMain.sprite.OnLostDevice();
      if (this.ScreenTexMan != null)
        this.ScreenTexMan.Dispose();
      if (this.EffectDictionary == null)
        return;
      foreach (Effect effect in this.EffectDictionary.Values)
        effect.OnLostDevice();
    }

    public void OnResetDevice()
    {
      this.SpriteMain.sprite.OnResetDevice();
      this.DeviceMain.Reset(this.presentParams);
      if (this.ScreenTexMan != null)
        this.ScreenTexMan.Reset();
      if (this.EffectDictionary == null)
        return;
      foreach (Effect effect in this.EffectDictionary.Values)
        effect.OnResetDevice();
    }

    public void Dispose()
    {
      this.DeviceMain.Direct3D.Dispose();
      this.SpriteMain.Dispose();
      if (this.TextureObjectDictionary != null)
      {
        foreach (TextureObject textureObject in this.TextureObjectDictionary.Values)
          textureObject.Dispose();
      }
      if (this.SoundDictionary != null)
      {
        foreach (XAudio2_Player xaudio2Player in this.SoundDictionary.Values)
          xaudio2Player.Dispose();
      }
      if (this.BGM_Player != null)
        this.BGM_Player.Dispose();
      if (this.ScreenTexMan != null)
        this.ScreenTexMan.Dispose();
      if (this.EffectDictionary != null)
      {
        foreach (ComObject comObject in this.EffectDictionary.Values)
          comObject.Dispose();
      }
      if (this.ModelDictionary != null)
      {
        foreach (Model model in this.ModelDictionary.Values)
          model.Dispose();
      }
      if (this.DeviceXaudio2 == null)
        return;
      this.DeviceXaudio2.Dispose();
    }
  }
}
