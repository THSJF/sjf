 
// Type: Shooting.GameState_SplashScreen
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  internal class GameState_SplashScreen : IGameState
  {
    public TextureObject TxtureObject { get; set; }

    public TextureObject TxtureObject1 { get; set; }

    public GlobalDataPackage GlobalData { get; set; }

    public StageDataPackage StageData { get; set; }

    public string StageName { get; set; }

    public Device DeviceMain
    {
      get
      {
        return this.GlobalData.DeviceMain;
      }
    }

    public StateSwitchDataPackage StateSwitchData
    {
      get
      {
        return this.StageData.StateSwitchData;
      }
      set
      {
        this.StageData.StateSwitchData = value;
      }
    }

    public MySprite SpriteMain
    {
      get
      {
        return this.StageData.SpriteMain;
      }
    }

    public int TimeMain { get; set; }

    public BackgroundManager Background
    {
      get
      {
        return this.StageData.Background;
      }
      set
      {
        this.StageData.Background = value;
      }
    }

    public BackgroundManager3D Background3D
    {
      get
      {
        return this.StageData.Background3D;
      }
      set
      {
        this.StageData.Background3D = value;
      }
    }

    public ParticleManager3D Particle3D
    {
      get
      {
        return this.StageData.Particle3D;
      }
      set
      {
        this.StageData.Particle3D = value;
      }
    }

    public GameState_SplashScreen()
    {
    }

    public GameState_SplashScreen(GlobalDataPackage GlobalData)
    {
      this.GlobalData = GlobalData;
      this.LoadTexture();
    }

    public void LoadTexture()
    {
      this.GlobalData.TextureObjectLoader(".\\Image\\NowLoading\\NowLoading.png");
      this.GlobalData.TextureObjectLoader(".\\Image\\NowLoading\\NowLoading-0.png");
      this.GlobalData.TextureObjectLoader(".\\Image\\NowLoading\\NowLoading-1.png");
      this.GlobalData.TextureObjectLoader(".\\Image\\NowLoading\\Splash_Screen.png");
      this.GlobalData.TextureObjectLoader(".\\Image\\NowLoading\\Star.png");
      this.GlobalData.TextureObjectLoader(".\\Image\\NowLoading\\sssssstar.png");
      this.GlobalData.TextureObjectLoader(".\\Image\\NowLoading\\back.png");
      this.TxtureObject = this.GlobalData.TextureObjectDictionary["NowLoading-0"];
    }

    public virtual void Init()
    {
      if (this.StageData == null)
        this.StageData = new StageDataPackage(this.GlobalData);
      this.Background = new BackgroundManager();
      this.TimeMain = 0;
      this.Background.Light = 0;
      this.StageData.EffectList = new List<BaseEffect>();
      this.StageData.BoundRect = new Rectangle(450, 390, 640, 480);
    }

    public virtual void UpdateData()
    {
      ++this.TimeMain;
      if (this.TimeMain < 50)
        this.Background.Light += 5;
      else if (this.TimeMain > 60)
      {
        if (this.TimeMain % 60 >= 30)
          this.Background.Light += 4;
        else if (this.TimeMain % 60 < 30)
          this.Background.Light -= 4;
      }
      if (this.Background.Light < 0)
        this.Background.Light = 0;
      else if (this.Background.Light > (int) byte.MaxValue)
        this.Background.Light = (int) byte.MaxValue;
      if (this.TimeMain == 1)
      {
        this.Background.BackgroundList.Add(new BaseObject(this.StageData, "Splash_Screen", new PointF(320f, 240f), 0.0f, Math.PI / 2.0)
        {
          OutsideRegion = 10000
        });
        this.Background.BackgroundList.Add(new BaseObject(this.StageData, "sssssstar", new PointF(440f, 160f), 0.0f, Math.PI / 2.0)
        {
          DirectionVelocityDegree = 0.5f,
          OutsideRegion = 10000
        });
        this.Background.BackgroundList.Add(new BaseObject(this.StageData, "back", new PointF(320f, 240f), 0.0f, Math.PI / 2.0)
        {
          OutsideRegion = 10000
        });
      }
      this.Background.Ctrl();
      Particle particle = new Particle(this.StageData, "Star", new PointF((float) this.StageData.Ran.Next(this.StageData.BoundRect.Left - 50, this.StageData.BoundRect.Right), (float) this.StageData.Ran.Next(this.StageData.BoundRect.Top + 50, this.StageData.BoundRect.Top + 100)), (float) (this.StageData.Ran.Next(10, 20) / 10), -1.0 * Math.PI / 2.0 - (double) this.StageData.Ran.Next(1, 5) / 10.0);
      particle.Active = true;
      particle.Scale = (float) this.StageData.Ran.Next(25, 70) / 100f;
      particle.LifeTime = 70;
      if (this.GlobalData.LoadingList.Count <= 0)
        return;
      this.GlobalData.TextureObjectLoader(this.GlobalData.LoadingList[0]);
      this.GlobalData.LoadingList.RemoveAt(0);
    }

    public virtual void Render()
    {
      for (int index = this.StageData.EffectList.Count - 1; index >= 0; --index)
        this.StageData.EffectList[index].Ctrl();
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      this.Background.Show(false);
      this.StageData.EffectList.ForEach((Action<BaseEffect>) (x =>
      {
        if (x.Active)
          return;
        x.Show();
      }));
      this.SpriteMain.End();
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      this.DeviceMain.SetRenderState(RenderState.SourceBlend, 5);
      this.DeviceMain.SetRenderState(RenderState.DestinationBlend, 2);
      this.SpriteMain.Draw2D(this.TxtureObject, 1f, 0.0f, (PointF) new Point(520, 432), this.Background.Light);
      this.StageData.EffectList.ForEach((Action<BaseEffect>) (x =>
      {
        if (!x.Active)
          return;
        x.Show();
      }));
      this.SpriteMain.End();
    }

    public void BGM_ON()
    {
    }

    public virtual void BGM_Resume()
    {
    }

    public virtual void BGM_Pause()
    {
    }

    public void Dispose()
    {
      if (this.StageData == null)
        return;
      this.StageData.Dispose();
    }
  }
}
