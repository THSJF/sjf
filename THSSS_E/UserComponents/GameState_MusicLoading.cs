 
// Type: Shooting.GameState_MusicLoading
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX.Direct3D9;
using System;
using System.Drawing;
using System.Threading;

namespace Shooting
{
  internal class GameState_MusicLoading : BaseMenu, IGameState
  {
    private bool LoadFlag;
    private Thread LoadingThread;

    public GameState_MusicLoading(GlobalDataPackage GlobalData)
      : base(GlobalData)
    {
    }

    public GameState_MusicLoading()
    {
    }

    public override void Init()
    {
      this.LoadFlag = false;
      this.Background.Light = 0;
    }

    public override void UpdateData()
    {
      base.UpdateData();
      if (this.TimeMain == 1)
      {
        this.LoadingThread = new Thread(new ThreadStart(this.PreloadMusic));
        this.LoadingThread.Start();
      }
      if (this.LoadFlag && this.TimeMain > 0)
      {
        this.StageData.StateSwitchData = new StateSwitchDataPackage()
        {
          NextState = this.StageData.GlobalData.LastState.StageName,
          NeedInit = false
        };
        ((BaseGameState) this.StageData.GlobalData.LastState).TimeSycn();
        this.LoadingThread.Abort();
      }
      if (this.TimeMain < 50)
        this.Background.Light += 5;
      else if (this.TimeMain > 60)
      {
        if (this.TimeMain % 60 >= 30)
          this.Background.Light += 4;
        else if (this.TimeMain % 60 < 30)
          this.Background.Light -= 4;
      }
      Particle particle = new Particle(this.StageData, "Star", new PointF((float) this.StageData.Ran.Next(400, 640), (float) this.StageData.Ran.Next(440, 580)), (float) (this.StageData.Ran.Next(10, 20) / 10), -1.0 * Math.PI / 2.0 - (double) this.StageData.Ran.Next(1, 5) / 10.0);
      particle.Active = true;
      particle.Scale = (float) this.StageData.Ran.Next(25, 70) / 100f;
      particle.LifeTime = 70;
    }

    private void PreloadMusic()
    {
      if (this.GlobalData.LastState is BaseStage)
      {
        switch (((BaseGameState) this.GlobalData.LastState).StageName)
        {
          case "St1":
            this.BGM_Player.PreLoad(".\\BGM\\Stage01.wav");
            this.BGM_Player.PreLoad(".\\BGM\\Boss01.wav");
            this.GlobalData.LastState.StageData.ClearCSCathe();
            this.GlobalData.LastState.StageData.PreLoadCS(".\\CS\\St01");
            break;
          case "St2":
            this.BGM_Player.PreLoad(".\\BGM\\Stage02.wav");
            this.BGM_Player.PreLoad(".\\BGM\\Boss02.wav");
            this.GlobalData.LastState.StageData.ClearCSCathe();
            this.GlobalData.LastState.StageData.PreLoadCS(".\\CS\\St02");
            break;
          case "St3":
            this.BGM_Player.PreLoad(".\\BGM\\Stage03.wav");
            this.BGM_Player.PreLoad(".\\BGM\\Boss03.wav");
            this.GlobalData.LastState.StageData.ClearCSCathe();
            this.GlobalData.LastState.StageData.PreLoadCS(".\\CS\\St03");
            break;
          case "St4":
            this.BGM_Player.PreLoad(".\\BGM\\Stage04.wav");
            this.BGM_Player.PreLoad(".\\BGM\\Boss04.wav");
            this.GlobalData.LastState.StageData.ClearCSCathe();
            this.GlobalData.LastState.StageData.PreLoadCS(".\\CS\\St04");
            break;
          case "St5":
            this.BGM_Player.PreLoad(".\\BGM\\Stage05.wav");
            this.BGM_Player.PreLoad(".\\BGM\\Boss05.wav");
            this.GlobalData.LastState.StageData.ClearCSCathe();
            this.GlobalData.LastState.StageData.PreLoadCS(".\\CS\\St05");
            break;
          case "St6":
            this.BGM_Player.PreLoad(".\\BGM\\Stage06.wav");
            this.BGM_Player.PreLoad(".\\BGM\\Boss06.wav");
            this.GlobalData.LastState.StageData.ClearCSCathe();
            this.GlobalData.LastState.StageData.PreLoadCS(".\\CS\\St06");
            break;
          case "StEx":
            this.BGM_Player.PreLoad(".\\BGM\\StageEx.wav");
            this.BGM_Player.PreLoad(".\\BGM\\BossEx.wav");
            this.GlobalData.LastState.StageData.ClearCSCathe();
            this.GlobalData.LastState.StageData.PreLoadCS(".\\CS\\StEx");
            break;
        }
      }
      this.LoadFlag = true;
    }

    public override void Render()
    {
      this.GlobalData.LastState.Render();
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      this.DeviceMain.SetRenderState(RenderState.SourceBlend, 5);
      this.DeviceMain.SetRenderState(RenderState.DestinationBlend, 2);
      this.EffectList.ForEach((Action<BaseEffect>) (x => x.Show()));
      this.SpriteMain.End();
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      this.SpriteMain.Draw2D(this.GlobalData.TextureObjectDictionary["NowLoading-0"], 1f, 0.0f, (PointF) new Point(520, 440), this.Background.Light);
      this.StageData.EffectList.ForEach((Action<BaseEffect>) (x =>
      {
        if (x.Active)
          return;
        x.Show();
      }));
      this.SpriteMain.End();
    }

    public override void BGM_Pause()
    {
    }

    public override void BGM_Resume()
    {
    }
  }
}
