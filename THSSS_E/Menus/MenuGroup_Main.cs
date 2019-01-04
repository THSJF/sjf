// Decompiled with JetBrains decompiler
// Type: Shooting.MenuGroup_Main
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  internal class MenuGroup_Main : BaseMenuGroup
  {
    public MenuGroup_Main(StageDataPackage StageData)
      : base(StageData)
    {
      this.MenuSelectIndex = 0;
      this.MenuItemList = new List<BaseMenuItem>()
      {
        new BaseMenuItem(StageData, "Menu_Start"),
        new BaseMenuItem(StageData, "Menu_Practice"),
        new BaseMenuItem(StageData, "Menu_Replay"),
        new BaseMenuItem(StageData, "Menu_PlayerData"),
        new BaseMenuItem(StageData, "Menu_MusicRoom"),
        new BaseMenuItem(StageData, "Menu_Option"),
        new BaseMenuItem(StageData, "Menu_Manual"),
        new BaseMenuItem(StageData, "Menu_Exit")
      };
      if (StageData.PData.C_History.FindAll((Predicate<ClearHistory>) (a => a.NoContinueClearTimes > 0)).Count > 0)
        this.MenuItemList.Insert(1, new BaseMenuItem(StageData, "Menu_ExtraStart"));
      else
        this.MenuItemList.Insert(1, new BaseMenuItem(StageData, "DMenu_ExtraStart"));
      int num1 = 50;
      int num2 = 190;
      int num3 = -200;
      foreach (BaseMenuItem menuItem in this.MenuItemList)
      {
        menuItem.Position = new PointF((float) (num1 + num3), 140f);
        menuItem.DestPoint = new PointF((float) num1, (float) num2);
        num2 += 24;
        num1 = num1;
        num3 -= 50;
        menuItem.AngleDegree = 0.0;
      }
      this.MenuItemList[this.MenuSelectIndex].Selected = true;
    }

    public override void ProcessKeys()
    {
      base.ProcessKeys();
      if (this.KClass.Key_Z && this.LastZ == 0)
      {
        this.MenuItemList[this.MenuSelectIndex].Click();
        this.OnChangeMenu = this.TimeMain + 20;
        this.StageData.SoundPlay("se_ok00.wav");
      }
      if (!this.KClass.Key_X && !this.KClass.Key_ESC || this.LastX != 0)
        return;
      this.MenuSelectIndex = this.MenuItemList.Count - 1;
      this.SelectItemChanged();
      this.StageData.SoundPlay("se_cancel00.wav");
    }

    public override void ProcessZ()
    {
      switch (this.MenuItemList[this.MenuSelectIndex].Name)
      {
        case "Menu_Start":
          this.StageData.StateSwitchData = new StateSwitchDataPackage()
          {
            SDPswitch = new StageDataPackage(this.StageData.GlobalData),
            NeedInit = true
          };
          this.StageData.MenuGroupList.Add((BaseMenuGroup) new MenuGroup_RankSelect(this.StageData, false));
          break;
        case "Menu_ExtraStart":
          this.StageData.StateSwitchData = new StateSwitchDataPackage()
          {
            SDPswitch = new StageDataPackage(this.StageData.GlobalData),
            NeedInit = true
          };
          this.StageData.MenuGroupList.Add((BaseMenuGroup) new MenuGroup_RankSelectEx(this.StageData));
          break;
        case "Menu_Replay":
          this.StageData.MenuGroupList.Add((BaseMenuGroup) new MenuGroup_ReplayLoader(this.StageData, new PointF(36f, 16f)));
          break;
        case "Menu_Practice":
          this.StageData.StateSwitchData = new StateSwitchDataPackage()
          {
            SDPswitch = new StageDataPackage(this.StageData.GlobalData),
            NeedInit = true
          };
          this.StageData.MenuGroupList.Add((BaseMenuGroup) new MenuGroup_RankSelect(this.StageData, true));
          break;
        case "Menu_SpellPractice":
          this.StageData.StateSwitchData = new StateSwitchDataPackage()
          {
            SDPswitch = new StageDataPackage(this.StageData.GlobalData),
            NeedInit = true
          };
          this.StageData.MenuGroupList.Add((BaseMenuGroup) new MenuGroup_SCPractice(this.StageData));
          break;
        case "Menu_MusicRoom":
          this.StageData.MenuGroupList.Add((BaseMenuGroup) new MenuGroup_MusicRoom(this.StageData));
          break;
        case "Menu_PlayerData":
          this.StageData.MenuGroupList.Add((BaseMenuGroup) new MenuGroup_PlayerData(this.StageData));
          break;
        case "Menu_Manual":
          this.StageData.MenuGroupList.Add((BaseMenuGroup) new MenuGroup_Manual(this.StageData));
          break;
        case "Menu_Option":
          this.StageData.MenuGroupList.Add((BaseMenuGroup) new MenuOption(this.StageData));
          break;
        case "Menu_Exit":
          this.StageData.StateSwitchData = new StateSwitchDataPackage()
          {
            NextState = "GameExit"
          };
          break;
      }
    }
  }
}
