 
// Type: Shooting.GameState_GameOverMenu
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  internal class GameState_GameOverMenu : GameState_PauseMenu
  {
    public GameState_GameOverMenu(GlobalDataPackage GlobalData)
      : base(GlobalData)
    {
    }

    public override void Init()
    {
      List<BaseMenuGroup> menuGroupList = this.StageData.MenuGroupList;
      MenuGroup_GameOver menuGroupGameOver1 = new MenuGroup_GameOver(this.StageData);
      menuGroupGameOver1.OriginalPosition = new PointF(36f, 16f);
      MenuGroup_GameOver menuGroupGameOver2 = menuGroupGameOver1;
      menuGroupList.Add((BaseMenuGroup) menuGroupGameOver2);
      StageDataPackage stageData = this.StageData.GlobalData.LastState.StageData;
      if (!stageData.OnReplay && !stageData.OnPractice && stageData.MyPlane.Score > stageData.S_History[9].Score)
        this.StageData.MenuGroupList.Add((BaseMenuGroup) new MenuGroup_ScoreSaver(this.StageData, new PointF(36f, 16f)));
      this.KClass.Hex2Key(0);
    }
  }
}
