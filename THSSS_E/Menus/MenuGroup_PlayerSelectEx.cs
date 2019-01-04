// Decompiled with JetBrains decompiler
// Type: Shooting.MenuGroup_PlayerSelectEx
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  internal class MenuGroup_PlayerSelectEx : MenuGroup_PlayerSelect
  {
    public MenuGroup_PlayerSelectEx(StageDataPackage StageData)
      : base(StageData, false)
    {
      this.MenuItemList = new List<BaseMenuItem>();
      this.PlayerDescription = new List<BaseMenuItem>();
      if (StageData.PData.C_History.FindAll((Predicate<ClearHistory>) (x => x.NoContinueClearTimes > 0 && x.MyPlaneFullName == "ReimuA")).Count > 0)
      {
        List<BaseMenuItem> menuItemList = this.MenuItemList;
        CharacterMenuItem characterMenuItem1 = new CharacterMenuItem(StageData, "FaceReimu_me");
        characterMenuItem1.DestPoint1 = new PointF((float) sbyte.MinValue, 10f);
        characterMenuItem1.DestPoint2 = new PointF(-228f, 10f);
        characterMenuItem1.TransparentValueF = 0.0f;
        CharacterMenuItem characterMenuItem2 = characterMenuItem1;
        menuItemList.Add((BaseMenuItem) characterMenuItem2);
        List<BaseMenuItem> playerDescription = this.PlayerDescription;
        CharacterMenuItem characterMenuItem3 = new CharacterMenuItem(StageData, "DescriptionReimu");
        characterMenuItem3.DestPoint1 = new PointF(190f, 10f);
        characterMenuItem3.DestPoint2 = new PointF(260f, 10f);
        characterMenuItem3.TransparentValueF = 0.0f;
        CharacterMenuItem characterMenuItem4 = characterMenuItem3;
        playerDescription.Add((BaseMenuItem) characterMenuItem4);
      }
      List<ClearHistory> all = StageData.PData.C_History.FindAll((Predicate<ClearHistory>) (x => x.ClearTimes > 0));
      if (StageData.PData.C_History.FindAll((Predicate<ClearHistory>) (x => x.NoContinueClearTimes > 0 && x.MyPlaneFullName == "MarisaA")).Count > 0)
      {
        List<BaseMenuItem> menuItemList = this.MenuItemList;
        CharacterMenuItem characterMenuItem1 = new CharacterMenuItem(StageData, "FaceMarisa_me");
        characterMenuItem1.DestPoint1 = new PointF((float) sbyte.MinValue, 10f);
        characterMenuItem1.DestPoint2 = new PointF(-228f, 10f);
        characterMenuItem1.TransparentValueF = 0.0f;
        CharacterMenuItem characterMenuItem2 = characterMenuItem1;
        menuItemList.Add((BaseMenuItem) characterMenuItem2);
        List<BaseMenuItem> playerDescription = this.PlayerDescription;
        CharacterMenuItem characterMenuItem3 = new CharacterMenuItem(StageData, "DescriptionMarisa");
        characterMenuItem3.DestPoint1 = new PointF(190f, 10f);
        characterMenuItem3.DestPoint2 = new PointF(260f, 10f);
        characterMenuItem3.TransparentValueF = 0.0f;
        CharacterMenuItem characterMenuItem4 = characterMenuItem3;
        playerDescription.Add((BaseMenuItem) characterMenuItem4);
      }
      all = StageData.PData.C_History.FindAll((Predicate<ClearHistory>) (x => x.ClearTimes > 0));
      if (StageData.PData.C_History.FindAll((Predicate<ClearHistory>) (x => x.NoContinueClearTimes > 0 && x.MyPlaneFullName == "SanaeA")).Count > 0)
      {
        List<BaseMenuItem> menuItemList = this.MenuItemList;
        CharacterMenuItem characterMenuItem1 = new CharacterMenuItem(StageData, "FaceSanae_me");
        characterMenuItem1.DestPoint1 = new PointF(0.0f, 30f);
        characterMenuItem1.DestPoint2 = new PointF(-100f, 30f);
        characterMenuItem1.TransparentValueF = 0.0f;
        CharacterMenuItem characterMenuItem2 = characterMenuItem1;
        menuItemList.Add((BaseMenuItem) characterMenuItem2);
        List<BaseMenuItem> playerDescription = this.PlayerDescription;
        CharacterMenuItem characterMenuItem3 = new CharacterMenuItem(StageData, "DescriptionSanae");
        characterMenuItem3.DestPoint1 = new PointF(190f, 10f);
        characterMenuItem3.DestPoint2 = new PointF(260f, 10f);
        characterMenuItem3.TransparentValueF = 0.0f;
        CharacterMenuItem characterMenuItem4 = characterMenuItem3;
        playerDescription.Add((BaseMenuItem) characterMenuItem4);
      }
      all = StageData.PData.C_History.FindAll((Predicate<ClearHistory>) (x => x.ClearTimes > 0));
      if (StageData.PData.C_History.FindAll((Predicate<ClearHistory>) (x => x.NoContinueClearTimes > 0 && x.MyPlaneFullName == "KoishiA")).Count > 0)
      {
        List<BaseMenuItem> menuItemList = this.MenuItemList;
        CharacterMenuItem characterMenuItem1 = new CharacterMenuItem(StageData, "FaceKoishi_me");
        characterMenuItem1.DestPoint1 = new PointF((float) sbyte.MinValue, 10f);
        characterMenuItem1.DestPoint2 = new PointF(-228f, 10f);
        characterMenuItem1.TransparentValueF = 0.0f;
        CharacterMenuItem characterMenuItem2 = characterMenuItem1;
        menuItemList.Add((BaseMenuItem) characterMenuItem2);
        List<BaseMenuItem> playerDescription = this.PlayerDescription;
        CharacterMenuItem characterMenuItem3 = new CharacterMenuItem(StageData, "DescriptionKoishi");
        characterMenuItem3.DestPoint1 = new PointF(190f, 10f);
        characterMenuItem3.DestPoint2 = new PointF(260f, 10f);
        characterMenuItem3.TransparentValueF = 0.0f;
        CharacterMenuItem characterMenuItem4 = characterMenuItem3;
        playerDescription.Add((BaseMenuItem) characterMenuItem4);
      }
      this.MenuItemList[this.MenuSelectIndex].Selected = true;
      this.PlayerDescription[this.MenuSelectIndex].Selected = true;
    }

    public override void ProcessZ()
    {
      Point point = new Point(192, 398);
      switch (this.MenuItemList[this.MenuSelectIndex].Name)
      {
        case "Plane":
          this.StageData.StateSwitchData.SDPswitch.MyPlane = new BaseMyPlane(this.StageData.StateSwitchData.SDPswitch, point);
          break;
        case "FaceReimu_me":
          this.StageData.StateSwitchData.SDPswitch.MyPlane = (BaseMyPlane) new MyPlane_Reimu(this.StageData.StateSwitchData.SDPswitch, point);
          break;
        case "FaceSanae_me":
          this.StageData.StateSwitchData.SDPswitch.MyPlane = (BaseMyPlane) new MyPlane_Sanae(this.StageData.StateSwitchData.SDPswitch, point);
          break;
        case "FaceMarisa_me":
          this.StageData.StateSwitchData.SDPswitch.MyPlane = (BaseMyPlane) new MyPlane_Marisa(this.StageData.StateSwitchData.SDPswitch, point);
          break;
        case "FaceKoishi_me":
          this.StageData.StateSwitchData.SDPswitch.MyPlane = (BaseMyPlane) new MyPlane_Koishi(this.StageData.StateSwitchData.SDPswitch, point);
          break;
        default:
          this.StageData.StateSwitchData.SDPswitch.MyPlane = new BaseMyPlane(this.StageData.StateSwitchData.SDPswitch, point);
          break;
      }
      this.StageData.Rep.CreatRpy();
      this.StageData.StateSwitchData.NextState = "StEx";
      this.StageData.StateSwitchData.SDPswitch.SetReplayInfo(this.StageData.StateSwitchData.NextState);
    }

    public override void Show()
    {
      base.Show();
      if (this.StageData.MenuGroupList[this.StageData.MenuGroupList.Count - 1] != this)
        return;
      this.PlayerDescription.ForEach((Action<BaseMenuItem>) (x => x.Show()));
    }
  }
}
