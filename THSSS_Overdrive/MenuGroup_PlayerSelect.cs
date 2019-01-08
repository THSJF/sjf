// Decompiled with JetBrains decompiler
// Type: Shooting.MenuGroup_PlayerSelect
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  internal class MenuGroup_PlayerSelect : BaseMenuGroup
  {
    private bool StageSelect;
    protected List<BaseMenuItem> PlayerDescription;

    public MenuGroup_PlayerSelect(StageDataPackage StageData, bool StageSelect)
      : base(StageData)
    {
      this.StageSelect = StageSelect;
      this.MenuSelectIndex = 0;
      this.MenuItemList = new List<BaseMenuItem>();
      this.PlayerDescription = new List<BaseMenuItem>();
      List<BaseMenuItem> menuItemList1 = this.MenuItemList;
      CharacterMenuItem characterMenuItem1 = new CharacterMenuItem(StageData, "FaceReimu_me");
      characterMenuItem1.DestPoint1 = new PointF((float) sbyte.MinValue, 10f);
      characterMenuItem1.DestPoint2 = new PointF(-228f, 10f);
      characterMenuItem1.TransparentValueF = 0.0f;
      CharacterMenuItem characterMenuItem2 = characterMenuItem1;
      menuItemList1.Add((BaseMenuItem) characterMenuItem2);
      List<BaseMenuItem> playerDescription1 = this.PlayerDescription;
      CharacterMenuItem characterMenuItem3 = new CharacterMenuItem(StageData, "DescriptionReimu");
      characterMenuItem3.DestPoint1 = new PointF(190f, 10f);
      characterMenuItem3.DestPoint2 = new PointF(260f, 10f);
      characterMenuItem3.TransparentValueF = 0.0f;
      CharacterMenuItem characterMenuItem4 = characterMenuItem3;
      playerDescription1.Add((BaseMenuItem) characterMenuItem4);
      List<BaseMenuItem> menuItemList2 = this.MenuItemList;
      CharacterMenuItem characterMenuItem5 = new CharacterMenuItem(StageData, "FaceMarisa_me");
      characterMenuItem5.DestPoint1 = new PointF((float) sbyte.MinValue, 10f);
      characterMenuItem5.DestPoint2 = new PointF(-228f, 10f);
      characterMenuItem5.TransparentValueF = 0.0f;
      CharacterMenuItem characterMenuItem6 = characterMenuItem5;
      menuItemList2.Add((BaseMenuItem) characterMenuItem6);
      List<BaseMenuItem> playerDescription2 = this.PlayerDescription;
      CharacterMenuItem characterMenuItem7 = new CharacterMenuItem(StageData, "DescriptionMarisa");
      characterMenuItem7.DestPoint1 = new PointF(190f, 10f);
      characterMenuItem7.DestPoint2 = new PointF(260f, 10f);
      characterMenuItem7.TransparentValueF = 0.0f;
      CharacterMenuItem characterMenuItem8 = characterMenuItem7;
      playerDescription2.Add((BaseMenuItem) characterMenuItem8);
      List<BaseMenuItem> menuItemList3 = this.MenuItemList;
      CharacterMenuItem characterMenuItem9 = new CharacterMenuItem(StageData, "FaceSanae_me");
      characterMenuItem9.DestPoint1 = new PointF(0.0f, 30f);
      characterMenuItem9.DestPoint2 = new PointF(-100f, 30f);
      characterMenuItem9.TransparentValueF = 0.0f;
      CharacterMenuItem characterMenuItem10 = characterMenuItem9;
      menuItemList3.Add((BaseMenuItem) characterMenuItem10);
      List<BaseMenuItem> playerDescription3 = this.PlayerDescription;
      CharacterMenuItem characterMenuItem11 = new CharacterMenuItem(StageData, "DescriptionSanae");
      characterMenuItem11.DestPoint1 = new PointF(190f, 10f);
      characterMenuItem11.DestPoint2 = new PointF(260f, 10f);
      characterMenuItem11.TransparentValueF = 0.0f;
      CharacterMenuItem characterMenuItem12 = characterMenuItem11;
      playerDescription3.Add((BaseMenuItem) characterMenuItem12);
      List<BaseMenuItem> menuItemList4 = this.MenuItemList;
      CharacterMenuItem characterMenuItem13 = new CharacterMenuItem(StageData, "FaceKoishi_me");
      characterMenuItem13.DestPoint1 = new PointF((float) sbyte.MinValue, 10f);
      characterMenuItem13.DestPoint2 = new PointF(-228f, 10f);
      characterMenuItem13.TransparentValueF = 0.0f;
      CharacterMenuItem characterMenuItem14 = characterMenuItem13;
      menuItemList4.Add((BaseMenuItem) characterMenuItem14);
      List<BaseMenuItem> playerDescription4 = this.PlayerDescription;
      CharacterMenuItem characterMenuItem15 = new CharacterMenuItem(StageData, "DescriptionKoishi");
      characterMenuItem15.DestPoint1 = new PointF(190f, 10f);
      characterMenuItem15.DestPoint2 = new PointF(260f, 10f);
      characterMenuItem15.TransparentValueF = 0.0f;
      CharacterMenuItem characterMenuItem16 = characterMenuItem15;
      playerDescription4.Add((BaseMenuItem) characterMenuItem16);
      this.MenuItemList[this.MenuSelectIndex].Selected = true;
      this.PlayerDescription[this.MenuSelectIndex].Selected = true;
      BaseMenuItem baseMenuItem = new BaseMenuItem(StageData, "MenuTitle_PlayerSelect");
      baseMenuItem.Position = this.MenuTitlePos2;
      this.MenuTilte = baseMenuItem;
      this.TransparentValueF = 0.0f;
      this.MaxTransparent = (int) byte.MaxValue;
      this.TransparentVelocity = 10f;
      this.TxtureObject = this.TextureObjectDictionary["MenuBackground"];
      this.AngleDegree = 90.0;
      this.Scale = 0.75f;
      Rectangle boundRect = this.BoundRect;
      double num1 = (double) (boundRect.Width / 2 + 30 * (int) (StageData.StateSwitchData.SDPswitch.Difficulty - 1));
      boundRect = this.BoundRect;
      double num2 = (double) (boundRect.Height / 2 - 20 * (int) (StageData.StateSwitchData.SDPswitch.Difficulty - 1));
      this.OriginalPosition = new PointF((float) num1, (float) num2);
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.PlayerDescription.ForEach((Action<BaseMenuItem>) (x => x.Ctrl()));
    }

    public override void ProcessKeys()
    {
      if (this.KClass.ArrowLeft && this.LastLeft == 0)
      {
        --this.MenuSelectIndex;
        this.StageData.SoundPlay("se_select00.wav");
        this.SelectItemChanged();
      }
      if (this.KClass.ArrowRight && this.LastRight == 0)
      {
        ++this.MenuSelectIndex;
        this.StageData.SoundPlay("se_select00.wav");
        this.SelectItemChanged();
      }
      if (this.KClass.Key_Z && this.LastZ == 0)
      {
        this.MenuItemList[this.MenuSelectIndex].Click();
        this.OnChangeMenu = this.TimeMain + 20;
        this.StageData.SoundPlay("se_ok00.wav");
      }
      if (!this.KClass.Key_X && !this.KClass.Key_ESC || this.LastX != 0)
        return;
      this.OnRemoveMenu = this.TimeMain + 20;
      this.TransparentVelocity = -15f;
      foreach (BaseMenuItem menuItem in this.MenuItemList)
      {
        menuItem.Selected = false;
        menuItem.OnRemove = true;
      }
      foreach (BaseMenuItem baseMenuItem in this.PlayerDescription)
      {
        baseMenuItem.Selected = false;
        baseMenuItem.OnRemove = true;
      }
      this.StageData.SoundPlay("se_cancel00.wav");
    }

    public override void SelectItemChanged()
    {
      base.SelectItemChanged();
      for (int index = 0; index < this.PlayerDescription.Count; ++index)
      {
        if (index == this.MenuSelectIndex)
          this.PlayerDescription[index].Select();
        else
          this.PlayerDescription[index].Selected = false;
      }
    }

    public override void ProcessZ()
    {
      Point OriginalPosition = new Point(192, 398);
      switch (this.MenuItemList[this.MenuSelectIndex].Name)
      {
        case "FaceAya_ct":
          this.StageData.MenuGroupList.Add((BaseMenuGroup) new MenuGroup_WeaponSelect(this.StageData, this.StageSelect, 0));
          break;
        case "Plane":
          this.StageData.MenuGroupList.Add((BaseMenuGroup) new MenuGroup_WeaponSelect(this.StageData, this.StageSelect, 1));
          break;
        case "FaceReimu_me":
          this.StageData.StateSwitchData.SDPswitch.MyPlane = (BaseMyPlane) new MyPlane_Reimu(this.StageData.StateSwitchData.SDPswitch, OriginalPosition);
          if (!this.StageSelect)
          {
            this.StageData.Rep.CreatRpy();
            this.StageData.StateSwitchData.NextState = "St1";
            this.StageData.StateSwitchData.SDPswitch.SetReplayInfo(this.StageData.StateSwitchData.NextState);
            break;
          }
          this.StageData.MenuGroupList.Add((BaseMenuGroup) new MenuGroup_StageSelect(this.StageData));
          break;
        case "FaceSanae_me":
          this.StageData.StateSwitchData.SDPswitch.MyPlane = (BaseMyPlane) new MyPlane_Sanae(this.StageData.StateSwitchData.SDPswitch, OriginalPosition);
          if (!this.StageSelect)
          {
            this.StageData.Rep.CreatRpy();
            this.StageData.StateSwitchData.NextState = "St1";
            this.StageData.StateSwitchData.SDPswitch.SetReplayInfo(this.StageData.StateSwitchData.NextState);
            break;
          }
          this.StageData.MenuGroupList.Add((BaseMenuGroup) new MenuGroup_StageSelect(this.StageData));
          break;
        case "FaceMarisa_me":
          this.StageData.StateSwitchData.SDPswitch.MyPlane = (BaseMyPlane) new MyPlane_Marisa(this.StageData.StateSwitchData.SDPswitch, OriginalPosition);
          if (!this.StageSelect)
          {
            this.StageData.Rep.CreatRpy();
            this.StageData.StateSwitchData.NextState = "St1";
            this.StageData.StateSwitchData.SDPswitch.SetReplayInfo(this.StageData.StateSwitchData.NextState);
            break;
          }
          this.StageData.MenuGroupList.Add((BaseMenuGroup) new MenuGroup_StageSelect(this.StageData));
          break;
        case "FaceKoishi_me":
          this.StageData.StateSwitchData.SDPswitch.MyPlane = (BaseMyPlane) new MyPlane_Koishi(this.StageData.StateSwitchData.SDPswitch, OriginalPosition);
          if (!this.StageSelect)
          {
            this.StageData.Rep.CreatRpy();
            this.StageData.StateSwitchData.NextState = "St1";
            this.StageData.StateSwitchData.SDPswitch.SetReplayInfo(this.StageData.StateSwitchData.NextState);
            break;
          }
          this.StageData.MenuGroupList.Add((BaseMenuGroup) new MenuGroup_StageSelect(this.StageData));
          break;
      }
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
