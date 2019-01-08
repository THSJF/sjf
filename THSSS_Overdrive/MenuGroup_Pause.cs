// Decompiled with JetBrains decompiler
// Type: Shooting.MenuGroup_Pause
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  internal class MenuGroup_Pause : MenuGroup_GameOver
  {
    public MenuGroup_Pause(StageDataPackage StageData)
      : base(StageData)
    {
      this.MenuSelectIndex = 0;
      this.MenuItemList = new List<BaseMenuItem>();
      this.MenuItemList.Add(new BaseMenuItem(StageData, "Menu_继续游戏"));
      if (!StageData.GlobalData.LastState.StageData.OnReplay && StageData.GlobalData.LastState.StageData.ContinueTimes == 0)
        this.MenuItemList.Add(new BaseMenuItem(StageData, "Menu_保存录像"));
      this.MenuItemList.Add(new BaseMenuItem(StageData, "Menu_返回主菜单"));
      this.MenuItemList.Add(new BaseMenuItem(StageData, "Menu_从头开始"));
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
      this.MenuTitlePos2 = new PointF(-50f, 240f);
      this.MenuTitlePos1 = new PointF(44f, 240f);
      BaseMenuItem baseMenuItem = new BaseMenuItem(StageData, "Menu_游戏暂停");
      baseMenuItem.Position = this.MenuTitlePos2;
      this.MenuTilte = baseMenuItem;
      this.MenuItemList[this.MenuSelectIndex].Selected = true;
    }

    public override void ProcessKeys()
    {
      base.ProcessKeys();
      if (!this.KClass.Key_C)
        return;
      for (int index = 0; index < this.MenuItemList.Count; ++index)
      {
        this.MenuItemList[index].Selected = false;
        if (this.MenuItemList[index].Name == "Menu_从头开始")
        {
          this.MenuItemList[index].Selected = true;
          this.MenuSelectIndex = index;
          this.MenuItemList[this.MenuSelectIndex].Click();
          this.OnChangeMenu = this.TimeMain + 20;
          this.StageData.SoundPlay("se_ok00.wav");
        }
      }
    }
  }
}
