// Decompiled with JetBrains decompiler
// Type: Shooting.MenuGroup_WeaponSelect
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  internal class MenuGroup_WeaponSelect : BaseMenuGroup
  {
    private bool StageSelect;

    public MenuGroup_WeaponSelect(StageDataPackage StageData, bool StageSelect, int PlaneType)
      : base(StageData)
    {
      this.StageSelect = StageSelect;
      this.MenuSelectIndex = 0;
      if (PlaneType == 1)
      {
        this.MenuItemList = new List<BaseMenuItem>();
        List<BaseMenuItem> menuItemList1 = this.MenuItemList;
        CharacterMenuItem characterMenuItem1 = new CharacterMenuItem(StageData, "Weapon_PlaneA");
        characterMenuItem1.Scale = 0.7f;
        characterMenuItem1.DestPoint1 = new PointF(270f, 150f);
        characterMenuItem1.DestPoint2 = new PointF(200f, 150f);
        characterMenuItem1.TransparentValueF = 0.0f;
        CharacterMenuItem characterMenuItem2 = characterMenuItem1;
        menuItemList1.Add((BaseMenuItem) characterMenuItem2);
        List<BaseMenuItem> menuItemList2 = this.MenuItemList;
        CharacterMenuItem characterMenuItem3 = new CharacterMenuItem(StageData, "Weapon_PlaneB");
        characterMenuItem3.Scale = 0.7f;
        characterMenuItem3.DestPoint1 = new PointF(270f, 150f);
        characterMenuItem3.DestPoint2 = new PointF(340f, 150f);
        characterMenuItem3.TransparentValueF = 0.0f;
        CharacterMenuItem characterMenuItem4 = characterMenuItem3;
        menuItemList2.Add((BaseMenuItem) characterMenuItem4);
      }
      else
      {
        List<BaseMenuItem> baseMenuItemList1 = new List<BaseMenuItem>();
        List<BaseMenuItem> baseMenuItemList2 = baseMenuItemList1;
        CharacterMenuItem characterMenuItem1 = new CharacterMenuItem(StageData, "Weapon_AyaA");
        characterMenuItem1.Scale = 0.7f;
        characterMenuItem1.DestPoint1 = new PointF(270f, 150f);
        characterMenuItem1.DestPoint2 = new PointF(200f, 150f);
        characterMenuItem1.TransparentValueF = 0.0f;
        CharacterMenuItem characterMenuItem2 = characterMenuItem1;
        baseMenuItemList2.Add((BaseMenuItem) characterMenuItem2);
        this.MenuItemList = baseMenuItemList1;
      }
      this.MenuItemList[this.MenuSelectIndex].Selected = true;
      this.MenuTitlePos1 = new PointF(280f, 30f);
      this.MenuTitlePos2 = new PointF(280f, -100f);
      BaseMenuItem baseMenuItem = new BaseMenuItem(StageData, "MenuTitle_WeaponSelect");
      baseMenuItem.Position = this.MenuTitlePos2;
      this.MenuTilte = baseMenuItem;
      this.TransparentValueF = 0.0f;
      this.MaxTransparent = (int) byte.MaxValue;
      this.TransparentVelocity = 5f;
      this.OriginalPosition = new PointF((float) (this.BoundRect.Width / 2), (float) (this.BoundRect.Height / 2));
      this.AngleDegree = 90.0;
    }

    public override void ProcessKeys()
    {
      if (this.KClass.ArrowLeft && this.LastLeft == 0)
      {
        ++this.MenuSelectIndex;
        this.StageData.SoundPlay("se_select00.wav");
        this.SelectItemChanged();
      }
      if (this.KClass.ArrowRight && this.LastRight == 0)
      {
        --this.MenuSelectIndex;
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
      this.StageData.SoundPlay("se_cancel00.wav");
    }

    public override void ProcessZ()
    {
      Point point = new Point(192, 398);
      switch (this.MenuItemList[this.MenuSelectIndex].Name)
      {
        case "Weapon_AyaA":
          this.StageData.StateSwitchData.SDPswitch.MyPlane = (BaseMyPlane) new MyPlane_Aya(this.StageData.StateSwitchData.SDPswitch, point);
          break;
        case "Weapon_AyaB":
          this.StageData.StateSwitchData.SDPswitch.MyPlane = (BaseMyPlane) new MyPlane_AyaB(this.StageData.StateSwitchData.SDPswitch, point);
          break;
        case "Weapon_PlaneA":
          this.StageData.StateSwitchData.SDPswitch.MyPlane = (BaseMyPlane) new AutoPlane(this.StageData.StateSwitchData.SDPswitch, point);
          break;
        case "Weapon_PlaneB":
          this.StageData.StateSwitchData.SDPswitch.MyPlane = (BaseMyPlane) new MyPlane_PlaneB(this.StageData.StateSwitchData.SDPswitch, point);
          break;
        default:
          this.StageData.StateSwitchData = new StateSwitchDataPackage()
          {
            NextState = "此功能尚未开通",
            NeedInit = true,
            SDPswitch = this.StageData
          };
          break;
      }
      if (!this.StageSelect)
      {
        this.StageData.Rep.CreatRpy();
        this.StageData.StateSwitchData.NextState = "St1";
        this.StageData.StateSwitchData.SDPswitch.SetReplayInfo(this.StageData.StateSwitchData.NextState);
      }
      else
        this.StageData.MenuGroupList.Add((BaseMenuGroup) new MenuGroup_StageSelect(this.StageData));
    }

    public override void Show()
    {
      if (this.StageData.MenuGroupList[this.StageData.MenuGroupList.Count - 1] != this)
        return;
      base.Show();
    }
  }
}
