 
// Type: Shooting.GameState_SplashScreen2
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX.Direct3D9;
using System;
using System.Drawing;

namespace Shooting
{
  internal class GameState_SplashScreen2 : GameState_SplashScreen, IGameState
  {
    public string PreNextState { get; set; }

    public GameState_SplashScreen2(GlobalDataPackage GlobalData)
      : this(GlobalData, "MainMenu")
    {
    }

    public GameState_SplashScreen2(GlobalDataPackage GlobalData, string nextState)
    {
      this.GlobalData = GlobalData;
      this.TxtureObject = GlobalData.TextureObjectDictionary["这只是测试版"];
      this.PreNextState = nextState;
    }

    public override void UpdateData()
    {
      ++this.TimeMain;
      if (this.TimeMain < 70)
        this.Background.Light += 4;
      else if (this.TimeMain > 120)
        this.Background.Light -= 4;
      if (this.Background.Light != 0)
        return;
      this.StateSwitchData = new StateSwitchDataPackage()
      {
        NextState = this.PreNextState,
        NeedInit = true,
        SDPswitch = new StageDataPackage(this.GlobalData)
      };
      this.GlobalData.LastState = (IGameState) this;
    }

    public override void Render()
    {
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      this.Background.Show(false);
      this.SpriteMain.Draw2D(this.TxtureObject, 1f, 0.0f, (PointF) new Point(320, 240), this.Background.Light);
      this.StageData.EffectList.ForEach((Action<BaseEffect>) (x => x.Show()));
      this.SpriteMain.End();
    }
  }
}
