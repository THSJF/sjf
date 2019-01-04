// Decompiled with JetBrains decompiler
// Type: Shooting.MenuGroup_RankSelect
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  internal class MenuGroup_RankSelect : BaseMenuGroup
  {
    private bool StageSelect;

    public MenuGroup_RankSelect(StageDataPackage StageData, bool StageSelect)
      : base(StageData)
    {
      this.StageSelect = StageSelect;
      this.MenuSelectIndex = 1;
      this.MenuItemList = new List<BaseMenuItem>()
      {
        new BaseMenuItem(StageData, "Menu_Easy"),
        new BaseMenuItem(StageData, "Menu_Normal"),
        new BaseMenuItem(StageData, "Menu_Hard"),
        new BaseMenuItem(StageData, "Menu_Lunatic")
      };
      int num1 = 220 + this.MenuSelectIndex * 150;
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
      this.MenuTitlePos1 = new PointF(0.0f, 0.0f);
      this.MenuTitlePos2 = new PointF(0.0f, -150f);
      BaseMenuItem baseMenuItem = new BaseMenuItem(StageData, "MenuTitle_RankSelect");
      baseMenuItem.Position = this.MenuTitlePos2;
      this.MenuTilte = baseMenuItem;
      this.TransparentValueF = 0.0f;
      this.TransparentVelocity = 20f;
      this.TxtureObject = this.TextureObjectDictionary["MenuBackground"];
      double num5 = (double) (this.BoundRect.Width / 2);
      Rectangle boundRect = this.BoundRect;
      double num6 = (double) (boundRect.Height / 2);
      this.OriginalPosition = new PointF((float) num5, (float) num6);
      this.AngleDegree = 90.0;
      this.Scale = 0.625f;
      this.MaxScale = 0.75f;
      this.ScaleVelocity = 0.005f;
      boundRect = this.BoundRect;
      double num7 = (double) (boundRect.Width / 2 + 30 * (this.MenuSelectIndex - 1));
      boundRect = this.BoundRect;
      double num8 = (double) (boundRect.Height / 2 - 20 * (this.MenuSelectIndex - 1));
      this.DestPoint = new PointF((float) num7, (float) num8);
      this.Velocity = 4f;
      this.AngleWithDirection = false;
    }

    public override void SelectItemChanged()
    {
      base.SelectItemChanged();
      int num1 = 220 + this.MenuSelectIndex * 150;
      int num2 = 200 - this.MenuSelectIndex * 100;
      foreach (BaseObject menuItem in this.MenuItemList)
      {
        menuItem.DestPoint = new PointF((float) num1, (float) num2);
        num2 += 100;
        num1 -= 150;
      }
      this.DestPoint = new PointF((float) (this.BoundRect.Width / 2 + 30 * (this.MenuSelectIndex - 1)), (float) (this.BoundRect.Height / 2 - 20 * (this.MenuSelectIndex - 1)));
      this.Velocity = 4f;
    }

    public override void ProcessKeys()
    {
      if (this.KClass.ArrowDown && (this.LastDown == 0 || this.LastDown > 30) || this.KClass.ArrowLeft && (this.LastLeft == 0 || this.LastLeft > 30))
      {
        ++this.MenuSelectIndex;
        this.StageData.SoundPlay("se_select00.wav");
        this.SelectItemChanged();
      }
      if (this.KClass.ArrowUp && (this.LastUp == 0 || this.LastUp > 30) || this.KClass.ArrowRight && (this.LastRight == 0 || this.LastRight > 30))
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
        menuItem.DestPoint = new PointF(0.0f, 0.0f);
        menuItem.OnRemove = true;
      }
      this.StageData.SoundPlay("se_cancel00.wav");
    }

    public override void ProcessZ()
    {
      switch (this.MenuItemList[this.MenuSelectIndex].Name)
      {
        case "Menu_Easy":
          this.StageData.StateSwitchData.SDPswitch.Difficulty = DifficultLevel.Easy;
          break;
        case "Menu_Normal":
          this.StageData.StateSwitchData.SDPswitch.Difficulty = DifficultLevel.Normal;
          break;
        case "Menu_Hard":
          this.StageData.StateSwitchData.SDPswitch.Difficulty = DifficultLevel.Hard;
          break;
        case "Menu_Lunatic":
          this.StageData.StateSwitchData.SDPswitch.Difficulty = DifficultLevel.Lunatic;
          break;
        case "Ultra":
          this.StageData.StateSwitchData.SDPswitch.Difficulty = DifficultLevel.Ultra;
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
      this.StageData.MenuGroupList.Add((BaseMenuGroup) new MenuGroup_PlayerSelect(this.StageData, this.StageSelect));
    }

    public override void Show()
    {
      base.Show();
      this.MenuItemList[this.MenuSelectIndex].Show();
    }
  }
}
