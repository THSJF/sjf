// Decompiled with JetBrains decompiler
// Type: Shooting.MenuGroup_SCPractice
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using Shooting.Planes.Story;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  internal class MenuGroup_SCPractice : BaseMenuGroup
  {
    private int deltaY = 20;
    private DescriptionBox DescriptionBox;

    public MenuGroup_SCPractice(StageDataPackage StageData)
      : base(StageData)
    {
      this.MenuSelectIndex = 0;
      this.MenuItemList = new List<BaseMenuItem>();
      List<SpellCardHistory> all = StageData.PData.SC_History.FindAll((Predicate<SpellCardHistory>) (a => a.MyPlaneFullName == "ReimuA"));
      for (int index = 0; index < all.Count; ++index)
      {
        List<BaseMenuItem> menuItemList = this.MenuItemList;
        SCMenuItem scMenuItem1 = new SCMenuItem(StageData, all[index].Index.ToString().PadRight(3));
        scMenuItem1.Description = (all[index].Rank.ToString().PadLeft(10) + all[index].Recorded.ToString().PadLeft(2) + "/" + all[index].History.ToString().PadLeft(2)).PadLeft(40);
        scMenuItem1.TxtureObject = StageData.TextureObjectDictionary["欧" + all[index].Name];
        scMenuItem1.DefaultColor = all[index].Recorded > 0 ? Color.SkyBlue : Color.White;
        SCMenuItem scMenuItem2 = scMenuItem1;
        menuItemList.Add((BaseMenuItem) scMenuItem2);
      }
      int num1 = 100;
      int num2 = 100;
      foreach (BaseMenuItem menuItem in this.MenuItemList)
      {
        menuItem.TransparentValueF = 0.0f;
        menuItem.Position = new PointF((float) num1, 90f);
        menuItem.DestPoint = new PointF((float) num1, (float) num2);
        menuItem.MaxVelocity = 10000f;
        num2 += this.deltaY;
      }
      this.MenuItemList[this.MenuSelectIndex].Selected = true;
      this.MenuTitlePos1 = new PointF(140f, -30f);
      this.MenuTitlePos2 = new PointF(140f, -150f);
      BaseMenuItem baseMenuItem = new BaseMenuItem(StageData, "MenuTitle_MusicRoom");
      baseMenuItem.Position = this.MenuTitlePos2;
      this.MenuTilte = baseMenuItem;
      this.TransparentValueF = 0.0f;
      this.TransparentVelocity = 5f;
      this.TxtureObject = this.TextureObjectDictionary["MenuBackground"];
      this.Scale = 0.625f;
      Rectangle boundRect = this.BoundRect;
      double num3 = (double) (boundRect.Width / 2);
      boundRect = this.BoundRect;
      double num4 = (double) (boundRect.Height / 2);
      this.OriginalPosition = new PointF((float) num3, (float) num4);
      this.AngleDegree = 90.0;
      this.ColorValue = Color.SlateBlue;
      DescriptionBox descriptionBox = new DescriptionBox(StageData);
      descriptionBox.MaxTransparent = 0;
      descriptionBox.OffsetX = 50;
      this.DescriptionBox = descriptionBox;
    }

    public override void SelectItemChanged()
    {
      base.SelectItemChanged();
      int num1 = 100;
      int num2 = 100;
      int num3 = (this.MenuSelectIndex - 8) * this.deltaY;
      if (num3 < 0)
        num3 = 0;
      foreach (BaseObject menuItem in this.MenuItemList)
      {
        menuItem.DestPoint = new PointF((float) num1, (float) (num2 - num3));
        num2 += this.deltaY;
      }
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.DescriptionBox.Ctrl();
      foreach (BaseMenuItem menuItem in this.MenuItemList)
        menuItem.TransparentValueF = (float) (400.0 - (double) Math.Abs(260f - menuItem.Position.Y) * 2.0);
    }

    public override void ProcessKeys()
    {
      base.ProcessKeys();
            if(!this.KClass.Key_Z||this.LastZ!=0) { }
      if (!this.KClass.Key_X && !this.KClass.Key_ESC || this.LastX != 0)
        return;
      this.OnRemoveMenu = this.TimeMain + 20;
      this.TransparentVelocity = -15f;
      this.DescriptionBox.TransparentVelocity = -15f;
      foreach (BaseMenuItem menuItem in this.MenuItemList)
      {
        menuItem.DestPoint = new PointF(100f, 60f);
        menuItem.OnRemove = true;
      }
      this.StageData.SoundPlay("se_cancel00.wav");
    }

    public override void Show()
    {
      base.Show();
      this.DescriptionBox.Show();
    }
  }
}
