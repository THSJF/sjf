// Decompiled with JetBrains decompiler
// Type: Shooting.MenuGroup_RankSelectEx
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  internal class MenuGroup_RankSelectEx : MenuGroup_RankSelect
  {
    public MenuGroup_RankSelectEx(StageDataPackage StageData)
      : base(StageData, false)
    {
      this.MenuSelectIndex = 0;
      this.MenuItemList = new List<BaseMenuItem>()
      {
        new BaseMenuItem(StageData, "Menu_Extra")
      };
      int num1 = 200 + this.MenuSelectIndex * 150;
      int num2 = 200 - this.MenuSelectIndex * 100;
      int num3 = -200;
      int num4 = 0;
      foreach (BaseMenuItem menuItem in this.MenuItemList)
      {
        menuItem.Position = new PointF((float) (num1 + num3), 48f);
        menuItem.DestPoint = new PointF((float) num1, (float) num2);
        menuItem.Scale = 0.8f;
        menuItem.Vibrateable = false;
        menuItem.MaxVelocity = 30f;
        num2 += 100;
        num1 -= 150;
        num3 -= 100;
        ++num4;
      }
      this.MenuItemList[this.MenuSelectIndex].Selected = true;
    }

    public override void SelectItemChanged()
    {
      if (this.MenuSelectIndex < 0)
        this.MenuSelectIndex = 0;
      else if (this.MenuSelectIndex > this.MenuItemList.Count - 1)
        this.MenuSelectIndex = this.MenuItemList.Count - 1;
      this.LastSelectTime = this.TimeMain;
      this.MenuItemList.ForEach((Action<BaseMenuItem>) (x => x.Selected = false));
      this.MenuItemList[this.MenuSelectIndex].Select();
    }

    public override void ProcessZ()
    {
      this.StageData.StateSwitchData.SDPswitch.Difficulty = DifficultLevel.Extra;
      List<BaseMenuGroup> menuGroupList = this.StageData.MenuGroupList;
      MenuGroup_PlayerSelectEx groupPlayerSelectEx1 = new MenuGroup_PlayerSelectEx(this.StageData);
      groupPlayerSelectEx1.OriginalPosition = this.OriginalPosition;
      MenuGroup_PlayerSelectEx groupPlayerSelectEx2 = groupPlayerSelectEx1;
      menuGroupList.Add((BaseMenuGroup) groupPlayerSelectEx2);
    }
  }
}
