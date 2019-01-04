// Decompiled with JetBrains decompiler
// Type: Shooting.GameState_GameSetMenu
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  internal class GameState_GameSetMenu : GameState_PauseMenu
  {
    public GameState_GameSetMenu(GlobalDataPackage GlobalData)
      : base(GlobalData)
    {
    }

    public override void Init()
    {
      List<BaseMenuGroup> menuGroupList = this.StageData.MenuGroupList;
      MenuGroup_GameSet menuGroupGameSet1 = new MenuGroup_GameSet(this.StageData);
      menuGroupGameSet1.OriginalPosition = new PointF(36f, 16f);
      MenuGroup_GameSet menuGroupGameSet2 = menuGroupGameSet1;
      menuGroupList.Add((BaseMenuGroup) menuGroupGameSet2);
      this.KClass.Hex2Key(0);
    }
  }
}
