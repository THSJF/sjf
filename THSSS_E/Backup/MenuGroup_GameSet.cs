// Decompiled with JetBrains decompiler
// Type: Shooting.MenuGroup_GameSet
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  internal class MenuGroup_GameSet : MenuGroup_GameOver
  {
    public MenuGroup_GameSet(StageDataPackage StageData)
      : base(StageData)
    {
      this.MenuSelectIndex = 0;
      this.MenuItemList = new List<BaseMenuItem>();
      if (!StageData.GlobalData.LastState.StageData.OnReplay)
      {
        if (StageData.GlobalData.LastState.StageData.ContinueTimes == 0)
          this.MenuItemList.Add(new BaseMenuItem(StageData, "Menu_保存录像"));
      }
      else
        StageData.OnReplay = false;
      this.MenuItemList.Add(new BaseMenuItem(StageData, "Menu_从头开始"));
      this.MenuItemList.Add(new BaseMenuItem(StageData, "Menu_返回主菜单"));
      int num1 = 62;
      int num2 = 300;
      int num3 = -200;
      foreach (BaseMenuItem menuItem in this.MenuItemList)
      {
        menuItem.DestPoint = new PointF((float) num1, (float) num2);
        menuItem.Position = new PointF((float) (num1 + num3), 150f);
        num2 += 30;
        num3 -= 50;
      }
      this.MenuItemList[this.MenuSelectIndex].Selected = true;
    }
  }
}
