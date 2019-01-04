// Decompiled with JetBrains decompiler
// Type: Shooting.MenuGroup_Manual
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  internal class MenuGroup_Manual : BaseMenuGroup
  {
    private List<BaseMenuItem> MenuItemListManual;

    public MenuGroup_Manual(StageDataPackage StageData)
      : base(StageData)
    {
      this.MenuSelectIndex = 0;
      this.MenuItemList = new List<BaseMenuItem>()
      {
        new BaseMenuItem(StageData, "Menu_Manual01"),
        new BaseMenuItem(StageData, "Menu_Manual02"),
        new BaseMenuItem(StageData, "Menu_Manual03"),
        new BaseMenuItem(StageData, "Menu_Manual04"),
        new BaseMenuItem(StageData, "Menu_Manual05"),
        new BaseMenuItem(StageData, "Menu_Manual06")
      };
      int num1 = 20;
      int num2 = 85;
      foreach (BaseMenuItem menuItem in this.MenuItemList)
      {
        menuItem.Position = new PointF((float) num1, 90f);
        menuItem.DestPoint = new PointF((float) num1, (float) num2);
        num2 += 30;
      }
      this.MenuItemList[this.MenuSelectIndex].Selected = true;
      this.MenuItemListManual = new List<BaseMenuItem>()
      {
        new BaseMenuItem(StageData, "Manual01"),
        new BaseMenuItem(StageData, "Manual02"),
        new BaseMenuItem(StageData, "Manual03"),
        new BaseMenuItem(StageData, "Manual04"),
        new BaseMenuItem(StageData, "Manual05"),
        new BaseMenuItem(StageData, "Manual06")
      };
      foreach (BaseMenuItem baseMenuItem in this.MenuItemListManual)
      {
        baseMenuItem.Position = new PointF(0.0f, 0.0f);
        baseMenuItem.DestPoint = new PointF(0.0f, 0.0f);
        baseMenuItem.UnSelectVisible = false;
        baseMenuItem.Vibrateable = false;
        baseMenuItem.Twinkleable = false;
        baseMenuItem.TransparentValueF = 0.0f;
      }
      this.MenuItemListManual[this.MenuSelectIndex].Selected = true;
      this.TransparentValueF = 0.0f;
      this.MaxTransparent = (int) byte.MaxValue;
      this.TransparentVelocity = 5f;
      this.TxtureObject = this.TextureObjectDictionary["MenuBackground"];
      this.OriginalPosition = new PointF((float) (this.BoundRect.Width / 2), (float) (this.BoundRect.Height / 2));
      this.AngleDegree = 90.0;
      this.ColorValue = Color.FromArgb(30, 110, 150);
    }

    public override void SelectItemChanged()
    {
      base.SelectItemChanged();
      this.MenuItemListManual.ForEach((Action<BaseMenuItem>) (x => x.Selected = false));
      this.MenuItemListManual[this.MenuSelectIndex].Select();
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.MenuItemListManual.ForEach((Action<BaseMenuItem>) (x => x.Ctrl()));
    }

    public override void ProcessKeys()
    {
      base.ProcessKeys();
            if(!this.KClass.Key_Z||this.LastZ!=0) { }
      if (!this.KClass.Key_X && !this.KClass.Key_ESC || this.LastX != 0)
        return;
      this.OnRemoveMenu = this.TimeMain + 20;
      this.TransparentVelocity = -15f;
      foreach (BaseMenuItem menuItem in this.MenuItemList)
        menuItem.OnRemove = true;
      foreach (BaseMenuItem baseMenuItem in this.MenuItemListManual)
        baseMenuItem.OnRemove = true;
      this.StageData.SoundPlay("se_cancel00.wav");
    }

    public override void Show()
    {
      base.Show();
      this.MenuItemListManual.ForEach((Action<BaseMenuItem>) (x => x.Show()));
    }
  }
}
