 
// Type: Shooting.GameState_ReplaySaveMenu
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX.Direct3D9;
using System;
using System.Drawing;

namespace Shooting
{
  internal class GameState_ReplaySaveMenu : BaseMenu, IGameState
  {
    public GameState_ReplaySaveMenu(GlobalDataPackage GlobalData)
      : base(GlobalData)
    {
      this.BackgroundLight = (int) byte.MaxValue;
    }

    public GameState_ReplaySaveMenu()
    {
    }

    public override void Init()
    {
      this.StageData.MenuGroupList.Add((BaseMenuGroup) new MenuGroup_ReplaySaver(this.StageData, new PointF(128f, 16f)));
      this.StageData.MenuGroupList.Add((BaseMenuGroup) new MenuGroup_ScoreSaver(this.StageData, new PointF(36f, 16f)));
      this.KClass.Hex2Key(0);
    }

    public override void Render()
    {
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
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
