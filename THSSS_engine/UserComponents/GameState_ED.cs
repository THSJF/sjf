 
// Type: Shooting.GameState_ED
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using Shooting.Planes.Story;
using SlimDX.Direct3D9;
using System;
using System.Drawing;
using System.IO;

namespace Shooting
{
  internal class GameState_ED : BaseGameState, IGameState
  {
    private int testStartTime = 0;
    private int[] keyTime = new int[1]{ 500 };
    private bool StageFlag;

    public GameState_ED(GlobalDataPackage GlobalData)
      : base(GlobalData)
    {
      this.StageName = "All";
      this.DXFont = new SlimDX.Direct3D9.Font(this.DeviceMain, new System.Drawing.Font("Arial", 14f, FontStyle.Bold | FontStyle.Italic));
    }

    public override void UpdateData()
    {
      ++this.TimeMain;
      this.SoundPlayList.Clear();
      if (this.StageData.Rep != null && this.StageData.OnReplay)
      {
        int keyValue = this.StageData.Rep.ReadKey();
        if (keyValue == 57358)
          keyValue = this.StageData.Rep.ReadKey();
        if (keyValue == 4080)
        {
          this.StateSwitchData = new StateSwitchDataPackage()
          {
            NextState = "GameOverMenu",
            NeedInit = true,
            SDPswitch = new StageDataPackage(this.GlobalData)
          };
          this.GlobalData.LastState = (IGameState) this;
          this.StageData.KClass.Hex2Key(0);
          this.StageData.SoundPlay("se_pause.wav");
        }
        else
          this.StageData.KClass.Hex2Key(keyValue);
      }
      this.Background3D.Ctrl();
      this.Background.Ctrl();
      this.Background2.Ctrl();
      this.Drama();
      if (this.Story != null)
        this.Story.Ctrl();
      for (int index = this.EnemyPlaneList.Count - 1; index >= 0; --index)
        this.EnemyPlaneList[index].Ctrl();
      for (int index = this.BulletList.Count - 1; index >= 0; --index)
        this.BulletList[index].Ctrl();
      for (int index = this.EffectList.Count - 1; index >= 0; --index)
        this.EffectList[index].Ctrl();
      this.Particle3D.Ctrl();
      for (int index = this.InterfaceList.Count - 1; index >= 0; --index)
        this.InterfaceList[index].Ctrl();
      this.StageData.Vibrate();
      this.SoundPlayList.ForEach((Action<XAudio2_Player>) (x => x.Play()));
      if (this.TimeMain % 6 != 0 && this.KClass.Key_plus && this.MyPlane.Life >= 0 && this.StateSwitchData == null)
        this.UpdateData();
      this.GlobalData.LastState = (IGameState) this;
    }

    public override void Init()
    {
      this.StageData.C_History = this.StageData.PData.C_History.Find(new Predicate<ClearHistory>(this.StageData.FindClear));
    }

    public void Drama()
    {
      if (this.TimeMain == 2)
      {
        if (this.StageData.C_History.PracticeLevel < 7)
          this.StageData.C_History.PracticeLevel = 7;
        this.StageFlag = false;
        new BackgroundTransitionIn(this.StageData)
        {
          Delay = 0
        }.LifeTime = 280;
        this.BoundRect = new Rectangle(128, 0, 384, 480);
        if (this.StageData.ContinueTimes == 0)
        {
          this.StageData.ChangeBGM(".\\BGM\\ED.wav", 0, 0, 0, 0, 0);
          Story_SSStaff storySsStaff = new Story_SSStaff(this.StageData);
        }
        this.StageData.CurrentStageName = "All";
        this.StageData.RepInfo.LastStage = this.StageData.CurrentStageName;
        this.StageData.C_History = this.StageData.PData.C_History.Find(new Predicate<ClearHistory>(this.StageData.FindClear));
        ++this.StageData.C_History.ClearTimes;
        if (this.StageData.ContinueTimes == 0)
          ++this.StageData.C_History.NoContinueClearTimes;
        this.StageData.S_History = this.StageData.PData.S_History.FindAll(new Predicate<ScoreHistory>(this.StageData.FindScore));
      }
      if (this.TimeMain > 2 && (this.Story == null && !this.StageFlag))
      {
        this.StageFlag = true;
        this.TimeMain = 3;
      }
      if (this.Story != null)
        return;
      if (this.TimeMain == 5)
      {
        this.StageData.ChangeBGM(".\\BGM\\Staff.wav", 0, 0, 0, 0, 0);
        foreach (string file in Directory.GetFiles(".\\CS\\Staff\\", "*.mbg"))
          new CSEmitterController(this.StageData, this.StageData.LoadCS(file))
          {
            OnRoad = true
          }.Time = this.TimeMain - 60;
        this.BoundRect = new Rectangle(128, 0, 640, 480);
      }
      if (!this.StageFlag || this.TimeMain <= this.keyTime[0] || !this.KClass.Key_Z)
        return;
      if (this.StageData.ContinueTimes == 0)
      {
        EndStage ed = new EndStage(this.StageData, "FinalReplaySaveMenu", true);
        ed.CtrlCall = (BaseObject.CtrlActionCallBack) (x =>
        {
          if (ed.Time != ed.LifeTime)
            return;
          this.BoundRect = new Rectangle(0, 0, 640, 480);
        });
        this.GlobalData.LastState = (IGameState) this;
        if (this.StageData.C_History.PracticeLevel < 8)
          this.StageData.C_History.PracticeLevel = 8;
      }
      else
      {
        EndStage endStage = new EndStage(this.StageData, "MainMenu", true);
        this.GlobalData.LastState = (IGameState) this;
      }
    }

    public override void BGM_ON()
    {
    }

    public override void Render()
    {
      this.GlobalData.ScreenTexMan.Begin();
      this.Background3D.Show();
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      this.DeviceMain.SetRenderState(RenderState.SourceBlend, 5);
      this.DeviceMain.SetRenderState(RenderState.DestinationBlend, 2);
      this.Background2.Show(true);
      this.SpriteMain.End();
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      this.Background2.Show(false);
      this.SpriteMain.End();
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      this.DeviceMain.SetRenderState(RenderState.SourceBlend, 5);
      this.DeviceMain.SetRenderState(RenderState.DestinationBlend, 2);
      this.BulletList.ForEach((Action<BaseBullet_Touhou>) (x =>
      {
        if (!x.Active)
          return;
        x.Show();
      }));
      this.EffectList.ForEach((Action<BaseEffect>) (x =>
      {
        if (!x.Active)
          return;
        x.Show();
      }));
      this.SpriteMain.End();
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      this.BulletList.ForEach((Action<BaseBullet_Touhou>) (x =>
      {
        if (x.Active || x.Layer >= 0)
          return;
        x.Show();
      }));
      this.BulletList.ForEach((Action<BaseBullet_Touhou>) (x =>
      {
        if (x.Active || x.Layer != 0)
          return;
        x.Show();
      }));
      this.BulletList.ForEach((Action<BaseBullet_Touhou>) (x =>
      {
        if (x.Active || x.Layer <= 0)
          return;
        x.Show();
      }));
      this.EffectList.ForEach((Action<BaseEffect>) (x =>
      {
        if (x.Active || x.Layer >= 0)
          return;
        x.Show();
      }));
      this.EffectList.ForEach((Action<BaseEffect>) (x =>
      {
        if (x.Active || x.Layer != 0)
          return;
        x.Show();
      }));
      this.EffectList.ForEach((Action<BaseEffect>) (x =>
      {
        if (x.Active || x.Layer <= 0)
          return;
        x.Show();
      }));
      if (this.Story != null)
        this.Story.Show();
      this.SpriteMain.End();
      this.Particle3D.Show();
      this.GlobalData.ScreenTexMan.End();
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      this.GlobalData.EffectMain = this.GlobalData.EffectDictionary["Filter"];
      this.GlobalData.EffectMain.Technique = (EffectHandle) "technique1";
      this.GlobalData.EffectMain.Begin();
      this.GlobalData.EffectMain.BeginPass(0);
      this.GlobalData.SpriteMain.Draw2D(this.GlobalData.ScreenTexMan.RenderTexture, (PointF) new Point(0, 0), 0.0f, new PointF(0.0f, 0.0f), Color.White);
      this.SpriteMain.End();
      this.GlobalData.EffectMain.EndPass();
      this.GlobalData.EffectMain.End();
    }
  }
}
