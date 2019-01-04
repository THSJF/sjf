// Decompiled with JetBrains decompiler
// Type: Shooting.MenuGroup_ReplayNamer
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  internal class MenuGroup_ReplayNamer : BaseMenuGroup
  {
    private int NameIndex = 0;
    private string[] PlayerName = new string[8];
    private string RepDescription = (string) null;
    private DescriptionMenuItem RepMenuItem;

    public MenuGroup_ReplayNamer(
      StageDataPackage StageData,
      PointF OriginalPosition,
      DescriptionMenuItem RepMenuItem)
      : base(StageData)
    {
      this.RepMenuItem = RepMenuItem;
      this.MenuItemList = new List<BaseMenuItem>();
      StageDataPackage stageData = StageData.GlobalData.LastState.StageData;
      string[,] strArray = new string[7, 13]
      {
        {
          "A",
          "B",
          "C",
          "D",
          "E",
          "F",
          "G",
          "H",
          "I",
          "J",
          "K",
          "L",
          "M"
        },
        {
          "N",
          "O",
          "P",
          "Q",
          "R",
          "S",
          "T",
          "U",
          "V",
          "W",
          "X",
          "Y",
          "Z"
        },
        {
          "a",
          "b",
          "c",
          "d",
          "e",
          "f",
          "g",
          "h",
          "i",
          "j",
          "k",
          "l",
          "m"
        },
        {
          "n",
          "o",
          "p",
          "q",
          "r",
          "s",
          "t",
          "u",
          "v",
          "w",
          "x",
          "y",
          "z"
        },
        {
          "0",
          "1",
          "2",
          "3",
          "4",
          "5",
          "6",
          "7",
          "8",
          "9",
          "+",
          "-",
          "="
        },
        {
          ".",
          ",",
          "!",
          "?",
          "@",
          ":",
          ";",
          "[",
          "]",
          "(",
          ")",
          "_",
          "/"
        },
        {
          "{",
          "}",
          "|",
          "~",
          "^",
          "#",
          "$",
          "%",
          "&",
          "*",
          " ",
          "BS",
          "OK"
        }
      };
      for (int index1 = 0; index1 < 7; ++index1)
      {
        for (int index2 = 0; index2 < 13; ++index2)
        {
          BaseMenuItem baseMenuItem = (BaseMenuItem) new DescriptionMenuItem(StageData, strArray[index1, index2]);
          baseMenuItem.OriginalPosition = new PointF((float) (stageData.BoundRect.Left + stageData.BoundRect.Width / 2 - 138), 300f);
          baseMenuItem.DestPoint = new PointF((float) (stageData.BoundRect.Left + stageData.BoundRect.Width / 2 - 138 + index2 * 22), (float) (270 + index1 * 22));
          this.MenuItemList.Add(baseMenuItem);
        }
      }
      this.MenuSelectIndex = this.MenuItemList.Count - 1;
      ReplayInfo repInfo = StageData.GlobalData.LastState.StageData.RepInfo;
      this.RepDescription += DateTime.Now.Date.ToString("yy'/'MM'/'dd").PadRight(9);
      this.RepDescription += repInfo.MyPlaneName.PadRight(7);
      switch (repInfo.Rank)
      {
        case DifficultLevel.Easy:
          this.RepDescription += "E  ";
          break;
        case DifficultLevel.Normal:
          this.RepDescription += "N  ";
          break;
        case DifficultLevel.Hard:
          this.RepDescription += "H  ";
          break;
        case DifficultLevel.Lunatic:
          this.RepDescription += "L  ";
          break;
        case DifficultLevel.Ultra:
          this.RepDescription += "U  ";
          break;
        case DifficultLevel.Extra:
          this.RepDescription += "EX ";
          break;
      }
      this.RepDescription += repInfo.LastStage == null ? "   " : repInfo.LastStage.PadRight(4);
      this.MenuItemList[this.MenuSelectIndex].Selected = true;
      DescriptionMenuItem descriptionMenuItem = new DescriptionMenuItem(StageData, RepMenuItem.Name);
      descriptionMenuItem.Description = "        " + this.RepDescription;
      descriptionMenuItem.OriginalPosition = RepMenuItem.OriginalPosition;
      descriptionMenuItem.Selected = true;
      this.MenuTilte = (BaseMenuItem) descriptionMenuItem;
      this.MenuTitlePos1 = new PointF(OriginalPosition.X, OriginalPosition.Y);
      this.MenuTitlePos2 = RepMenuItem.OriginalPosition;
      for (char[] charArray = stageData.PData.PlayerName.ToCharArray(); this.NameIndex < charArray.Length; ++this.NameIndex)
        this.PlayerName[this.NameIndex] = charArray[this.NameIndex].ToString();
      this.ShowPlayerName();
    }

    public override void ProcessKeys()
    {
      if (this.KClass.ArrowDown && (this.LastDown == 0 || this.LastDown > 30))
      {
        this.MenuSelectIndex += 13;
        this.StageData.SoundPlay("se_select00.wav");
        this.SelectItemChanged();
      }
      if (this.KClass.ArrowUp && (this.LastUp == 0 || this.LastUp > 30))
      {
        this.MenuSelectIndex -= 13;
        this.StageData.SoundPlay("se_select00.wav");
        this.SelectItemChanged();
      }
      if (this.KClass.ArrowLeft && (this.LastLeft == 0 || this.LastLeft > 30))
      {
        --this.MenuSelectIndex;
        if ((this.MenuSelectIndex + 1) % 13 == 0)
          this.MenuSelectIndex += 13;
        this.StageData.SoundPlay("se_select00.wav");
        this.SelectItemChanged();
      }
      if (this.KClass.ArrowRight && (this.LastRight == 0 || this.LastRight > 30))
      {
        ++this.MenuSelectIndex;
        if (this.MenuSelectIndex % 13 == 0)
          this.MenuSelectIndex -= 13;
        this.StageData.SoundPlay("se_select00.wav");
        this.SelectItemChanged();
      }
      if (this.KClass.Key_Z && this.LastZ == 0)
      {
        this.MenuItemList[this.MenuSelectIndex].Click();
        this.OnChangeMenu = this.TimeMain + 1;
      }
      if (this.KClass.Key_X && this.LastX == 0)
      {
        if (this.NameIndex > 0)
        {
          --this.NameIndex;
          this.PlayerName[this.NameIndex] = (string) null;
        }
        this.StageData.SoundPlay("se_cancel00.wav");
        this.ShowPlayerName();
      }
      if (!this.KClass.Key_ESC)
        return;
      this.OnRemoveMenu = this.TimeMain + 20;
      this.TransparentVelocity = -15f;
      foreach (BaseMenuItem menuItem in this.MenuItemList)
      {
        BaseMenuItem baseMenuItem = menuItem;
        PointF originalPosition = this.MenuItemList[0].OriginalPosition;
        double x = (double) originalPosition.X;
        originalPosition = this.MenuItemList[0].OriginalPosition;
        double y = (double) originalPosition.Y;
        PointF pointF = new PointF((float) x, (float) y);
        baseMenuItem.DestPoint = pointF;
        menuItem.OnRemove = true;
      }
      this.StageData.SoundPlay("se_cancel00.wav");
    }

    public override void ProcessZ()
    {
      if (this.MenuSelectIndex == this.MenuItemList.Count - 1)
      {
        ReplayInfo repInfo = this.StageData.GlobalData.LastState.StageData.RepInfo;
        repInfo.PlayerName = (string) null;
        for (int index = 0; index < 7; ++index)
          repInfo.PlayerName += this.PlayerName[index];
        this.StageData.Rep.SaveRpy(".\\Replay\\thSSS_" + this.RepMenuItem.Name + ".rpy", repInfo);
        this.RepMenuItem.Description = ((DescriptionMenuItem) this.MenuTilte).Description;
        this.OnRemoveMenu = this.TimeMain + 20;
        this.TransparentVelocity = -15f;
        foreach (BaseMenuItem menuItem in this.MenuItemList)
        {
          BaseMenuItem baseMenuItem = menuItem;
          PointF originalPosition = this.MenuItemList[0].OriginalPosition;
          double x = (double) originalPosition.X;
          originalPosition = this.MenuItemList[0].OriginalPosition;
          double y = (double) originalPosition.Y;
          PointF pointF = new PointF((float) x, (float) y);
          baseMenuItem.DestPoint = pointF;
          menuItem.OnRemove = true;
        }
        this.StageData.SoundPlay("se_extend.wav");
      }
      else if (this.MenuSelectIndex == this.MenuItemList.Count - 2)
      {
        if (this.NameIndex > 0)
        {
          --this.NameIndex;
          this.PlayerName[this.NameIndex] = (string) null;
        }
        this.StageData.SoundPlay("se_cancel00.wav");
      }
      else
      {
        this.PlayerName[this.NameIndex] = this.MenuItemList[this.MenuSelectIndex].Name;
        this.StageData.SoundPlay("se_ok00.wav");
        if (this.NameIndex < 7)
          ++this.NameIndex;
      }
      this.ShowPlayerName();
    }

    private void ShowPlayerName()
    {
      string str = (string) null;
      for (int index = 0; index < 7; ++index)
        str += this.PlayerName[index];
      ((DescriptionMenuItem) this.MenuTilte).Description = str.PadRight(8) + this.RepDescription;
      this.StageData.GlobalData.LastState.StageData.PData.PlayerName = str;
    }
  }
}
