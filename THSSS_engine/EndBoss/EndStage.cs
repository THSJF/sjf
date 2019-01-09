 
// Type: Shooting.EndStage
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

namespace Shooting
{
  internal class EndStage : BaseEffect
  {
    private string nextState = (string) null;
    private bool nextInit = false;
    private int tempVolumn;

    public int FadeOutTime { get; set; }

    public EndStage(StageDataPackage StageData, string NextState, bool NextInit)
      : this(StageData, NextState, NextInit, 50)
    {
    }

    public EndStage(StageDataPackage StageData, string NextState, bool NextInit, int FadeOutTime)
      : base(StageData)
    {
      this.tempVolumn = this.BGM_Player.Volume;
      this.LifeTime = 160;
      this.nextState = NextState;
      this.nextInit = NextInit;
      this.FadeOutTime = FadeOutTime;
      this.MyPlane.SpellEnabled = false;
      if (this.MyPlane.EnchantmentTime > 50)
        this.MyPlane.EnchantmentTime = 50;
      BackgroundTransitionOut backgroundTransitionOut = new BackgroundTransitionOut(StageData, FadeOutTime);
    }

    public override void Ctrl()
    {
      base.Ctrl();
      int num = this.LifeTime - 100;
      this.BGM_Player.Volume = (int) ((double) this.tempVolumn * (1.0 - (double) this.Time / (double) num));
      if (this.Time == num)
      {
        this.StageData.ChangeBGM(this.BGM_Player.FileName, false);
        this.BGM_Player.Stop();
      }
      if (this.Time != this.LifeTime)
        return;
      this.BGM_Player.Volume = this.tempVolumn;
      if (this.nextInit)
      {
        if (this.StageData.OnReplay && this.nextState == "MainMenu")
        {
          this.StageData.Rep.CloseRpy();
          this.StageData.OnReplay = false;
        }
        this.StageData.StateSwitchData = new StateSwitchDataPackage()
        {
          NextState = this.nextState,
          NeedInit = true,
          SDPswitch = new StageDataPackage(this.StageData.GlobalData)
        };
      }
      else if (this.StageData.OnPractice)
      {
        this.StageData.StateSwitchData = new StateSwitchDataPackage()
        {
          NextState = "GameSetMenu",
          NeedInit = true,
          SDPswitch = new StageDataPackage(this.StageData.GlobalData)
        };
      }
      else
      {
        this.StageData.StateSwitchData = new StateSwitchDataPackage()
        {
          NextState = this.nextState,
          NeedInit = false,
          SDPswitch = this.StageData
        };
        this.MyPlane.Refresh();
        this.StageData.SetReplayStageInfo();
      }
      this.Background3D.Clear();
      this.Background.Clear();
      this.Background2.Clear();
      BackgroundTransitionOut backgroundTransitionOut = new BackgroundTransitionOut(this.StageData, 2);
      backgroundTransitionOut.TransparentValueF = (float) byte.MaxValue;
      backgroundTransitionOut.TransparentVelocity = 0.0f;
      backgroundTransitionOut.LifeTime = 1;
      this.BulletList.Clear();
      this.EnemyPlaneList.Clear();
      this.ItemList.Clear();
      this.TimeMain = 0;
      this.MyPlane.Refresh();
      this.Ran = new MyRandom(0);
      this.StageData.VibrateStop();
    }

    public override void Show()
    {
    }
  }
}
