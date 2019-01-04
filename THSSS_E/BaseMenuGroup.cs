// Decompiled with JetBrains decompiler
// Type: Shooting.BaseMenuGroup
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  public class BaseMenuGroup : BaseObject
  {
    public int LastDown = 1;
    public int LastUp = 1;
    public int LastLeft = 1;
    public int LastRight = 1;
    public int LastZ = 1;
    public int LastX = 1;
    public int OnChangeMenu = 0;
    public int OnRemoveMenu = 0;
    public PointF MenuTitlePos1 = new PointF(280f, -30f);
    public PointF MenuTitlePos2 = new PointF(280f, -150f);

    public int MenuSelectIndex { get; set; }

    public int LastSelectTime { get; set; }

    public List<BaseMenuItem> MenuItemList { get; set; }

    public BaseMenuItem MenuTilte { get; set; }

    public BaseMenuGroup()
    {
    }

    public BaseMenuGroup(StageDataPackage StageData)
    {
      this.StageData = StageData;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.MenuItemList.Count <= 0)
        return;
      this.MenuItemList.ForEach((Action<BaseMenuItem>) (x => x.Ctrl()));
      if (this.MenuTilte == null)
        return;
      if (this.StageData.MenuGroupList[this.StageData.MenuGroupList.Count - 1] == this && this.TimeMain > this.OnRemoveMenu)
        this.MenuTilte.DestPoint = this.MenuTitlePos1;
      else
        this.MenuTilte.DestPoint = this.MenuTitlePos2;
      this.MenuTilte.Ctrl();
      this.MenuTilte.ColorValue = Color.White;
      this.MenuTilte.TransparentValueF = (float) byte.MaxValue;
    }

    public virtual void MenuSelect()
    {
      if (this.TimeMain - this.LastSelectTime < 7 || this.TimeMain < this.OnChangeMenu)
        return;
      if (this.TimeMain == this.OnChangeMenu)
      {
        this.ProcessZ();
      }
      else
      {
        if (this.TimeMain < this.OnRemoveMenu)
          return;
        if (this.TimeMain == this.OnRemoveMenu)
        {
          this.ProcessX();
        }
        else
        {
          this.ProcessKeys();
          this.LastDown = this.KClass.ArrowDown ? this.LastDown + 1 : 0;
          this.LastUp = this.KClass.ArrowUp ? this.LastUp + 1 : 0;
          this.LastLeft = this.KClass.ArrowLeft ? this.LastLeft + 1 : 0;
          this.LastRight = this.KClass.ArrowRight ? this.LastRight + 1 : 0;
          this.LastZ = this.KClass.Key_Z ? this.LastZ + 1 : 0;
          this.LastX = this.KClass.Key_X || this.KClass.Key_ESC ? this.LastX + 1 : 0;
        }
      }
    }

    public virtual void ProcessKeys()
    {
      if (this.KClass.ArrowDown && (this.LastDown == 0 || this.LastDown > 30))
      {
        ++this.MenuSelectIndex;
        this.StageData.SoundPlay("se_select00.wav");
        this.SelectItemChanged();
      }
      if (!this.KClass.ArrowUp || this.LastUp != 0 && this.LastUp <= 30)
        return;
      --this.MenuSelectIndex;
      this.StageData.SoundPlay("se_select00.wav");
      this.SelectItemChanged();
    }

    public virtual void ProcessZ()
    {
    }

    public virtual void ProcessX()
    {
      this.StageData.MenuGroupList.Remove(this);
      this.StageData.MenuGroupList[this.StageData.MenuGroupList.Count - 1].LastSelectTime = this.TimeMain;
    }

    public virtual void SelectItemChanged()
    {
      if (this.MenuSelectIndex < 0)
        this.MenuSelectIndex += this.MenuItemList.Count;
      else if (this.MenuSelectIndex > this.MenuItemList.Count - 1)
        this.MenuSelectIndex -= this.MenuItemList.Count;
      this.LastSelectTime = this.TimeMain;
      this.MenuItemList.ForEach((Action<BaseMenuItem>) (x => x.Selected = false));
      this.MenuItemList[this.MenuSelectIndex].Select();
    }

    public override void Show()
    {
      base.Show();
      if (this.MenuItemList.Count <= 0)
        return;
      this.MenuItemList.ForEach((Action<BaseMenuItem>) (x => x.Show()));
      if (this.MenuTilte == null)
        return;
      this.MenuTilte.Show();
    }
  }
}
