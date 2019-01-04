// Decompiled with JetBrains decompiler
// Type: Shooting.GameState_PauseMenu
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX.Direct3D9;
using System;
using System.Drawing;

namespace Shooting
{
  internal class GameState_PauseMenu : BaseMenu, IGameState
  {
    private float blurLevel;

    public GameState_PauseMenu(GlobalDataPackage GlobalData)
      : base(GlobalData)
    {
      this.BackgroundLight = (int) byte.MaxValue;
    }

    public GameState_PauseMenu()
    {
    }

    public override void Init()
    {
      this.StageData.MenuGroupList.Add((BaseMenuGroup) new MenuGroup_Pause(this.StageData));
      this.KClass.Hex2Key(0);
    }

    public override void UpdateData()
    {
      base.UpdateData();
      if (this.TimeMain < 50)
        this.blurLevel = (float) ((double) this.TimeMain * 25.0 / 500000.0);
      else
        this.blurLevel = 1f / 400f;
    }

    public override void Render()
    {
      this.GlobalData.ScreenTexMan.Begin();
      this.GlobalData.LastState.Render();
      this.GlobalData.ScreenTexMan.End();
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      this.GlobalData.EffectMain = this.GlobalData.EffectDictionary["Blur"];
      this.GlobalData.EffectMain.Technique = (EffectHandle) "technique1";
      this.GlobalData.EffectMain.Begin();
      this.GlobalData.EffectMain.SetValue<float>((EffectHandle) "BlurLevel", this.blurLevel);
      this.GlobalData.EffectMain.BeginPass(0);
      this.GlobalData.SpriteMain.Draw2D(this.GlobalData.ScreenTexMan.RenderTexture, (PointF) new Point(0, 0), 0.0f, new PointF(0.0f, 0.0f), Color.White);
      this.SpriteMain.End();
      this.GlobalData.EffectMain.EndPass();
      this.GlobalData.EffectMain.End();
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      this.Background.Show(false);
      if (this.GlobalData.LastState is BaseStage)
      {
        ((BaseStage) this.GlobalData.LastState).ShowInterface();
        ((BaseGameState) this.GlobalData.LastState).InterfaceList.ForEach((Action<BaseObject>) (x => x.Show()));
      }
      this.StageData.MenuGroupList[this.StageData.MenuGroupList.Count - 1].Show();
      this.SpriteMain.End();
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      this.DeviceMain.SetRenderState(RenderState.SourceBlend, 5);
      this.DeviceMain.SetRenderState(RenderState.DestinationBlend, 2);
      this.EffectList.ForEach((Action<BaseEffect>) (x => x.Show()));
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
