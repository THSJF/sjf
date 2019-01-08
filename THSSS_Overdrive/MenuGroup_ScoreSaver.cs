// Decompiled with JetBrains decompiler
// Type: Shooting.MenuGroup_ScoreSaver
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  internal class MenuGroup_ScoreSaver : BaseMenuGroup
  {
    private int NameIndex = 0;
    private string[] PlayerName = new string[8];
    private int HistorySelectIndex = -1;
    private List<BaseMenuItem> ScoreHistorys;

    public MenuGroup_ScoreSaver(StageDataPackage StageData, PointF OriginalPosition)
      : base(StageData)
    {
      this.OriginalPosition = OriginalPosition;
      this.ScoreHistorys = new List<BaseMenuItem>();
      for (int index = 0; index < 10; ++index)
        this.ScoreHistorys.Add((BaseMenuItem) new DescriptionMenuItem(StageData, string.Format("{0:00}", (object) (index + 1))));
      StageDataPackage stageData = StageData.GlobalData.LastState.StageData;
      for (int index1 = 0; index1 < stageData.S_History.Count; ++index1)
      {
        if (stageData.MyPlane.Score > stageData.S_History[index1].Score)
        {
          ScoreHistory scoreHistory1 = new ScoreHistory();
          scoreHistory1.MyPlaneFullName = stageData.MyPlane.FullName;
          scoreHistory1.Rank = stageData.Difficulty;
          scoreHistory1.PlayerName = "";
          scoreHistory1.Score = stageData.MyPlane.Score;
          ScoreHistory scoreHistory2 = scoreHistory1;
          DateTime dateTime = DateTime.Now;
          dateTime = dateTime.Date;
          string str = dateTime.ToString("yyyy'/'MM'/'dd");
          scoreHistory2.Date = str;
          scoreHistory1.Time = DateTime.Now.ToShortTimeString();
          scoreHistory1.Stage = stageData.CurrentStageName;
          scoreHistory1.SlowRate = stageData.SlowRate;
          ScoreHistory SH = scoreHistory1;
          for (int index2 = stageData.S_History.Count - 1; index2 > index1; --index2)
            stageData.S_History[index2].Copy(stageData.S_History[index2 - 1]);
          stageData.S_History[index1].Copy(SH);
          this.HistorySelectIndex = index1;
          break;
        }
      }
      float x = OriginalPosition.X + 12f;
      float y = OriginalPosition.Y + 30f;
      int num = 0;
      foreach (BaseMenuItem scoreHistory in this.ScoreHistorys)
      {
        scoreHistory.Position = new PointF(x, (float) (this.BoundRect.Top + 40));
        scoreHistory.DestPoint = new PointF(x, y);
        y += 17f;
        if (stageData.CurrentStageName.Contains("St"))
          ((DescriptionMenuItem) scoreHistory).Description = stageData.S_History[num++].Data2DrawStringSimple();
        else
          ((DescriptionMenuItem) scoreHistory).Description = stageData.S_History[num++].Data2DrawString();
      }
      if (this.HistorySelectIndex >= 0)
        this.ScoreHistorys[this.HistorySelectIndex].Selected = true;
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
      this.MenuItemList = new List<BaseMenuItem>();
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
      if (this.MenuSelectIndex >= 0)
        this.MenuItemList[this.MenuSelectIndex].Selected = true;
      for (char[] charArray = stageData.PData.PlayerName.ToCharArray(); this.NameIndex < charArray.Length; ++this.NameIndex)
        this.PlayerName[this.NameIndex] = charArray[this.NameIndex].ToString();
      this.ShowPlayerName();
    }

    public override void ProcessKeys()
    {
      this.ScoreHistorys.ForEach((Action<BaseMenuItem>) (x => x.Ctrl()));
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
      if (!this.KClass.Key_X || this.LastX != 0)
        return;
      if (this.NameIndex > 0)
      {
        --this.NameIndex;
        this.PlayerName[this.NameIndex] = (string) null;
      }
      this.StageData.SoundPlay("se_cancel00.wav");
      this.ShowPlayerName();
    }

    public override void ProcessZ()
    {
      if (this.MenuSelectIndex == this.MenuItemList.Count - 1)
      {
        this.OnRemoveMenu = this.TimeMain + 20;
        this.TransparentVelocity = -15f;
        foreach (BaseMenuItem scoreHistory in this.ScoreHistorys)
        {
          scoreHistory.DestPoint = new PointF(this.OriginalPosition.X + 12f, this.OriginalPosition.Y + 30f);
          scoreHistory.OnRemove = true;
        }
        this.StageData.SoundPlay("se_ok00.wav");
      }
      else if (this.MenuSelectIndex == this.MenuItemList.Count - 2)
      {
        if (this.NameIndex > 0)
        {
          --this.NameIndex;
          this.PlayerName[this.NameIndex] = " ";
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
      StageDataPackage stageData = this.StageData.GlobalData.LastState.StageData;
      if (this.HistorySelectIndex < 0)
        return;
      stageData.S_History[this.HistorySelectIndex].PlayerName = str;
      stageData.PData.PlayerName = str;
      if (stageData.CurrentStageName.Contains("St"))
        ((DescriptionMenuItem) this.ScoreHistorys[this.HistorySelectIndex]).Description = stageData.S_History[this.HistorySelectIndex].Data2DrawStringSimple();
      else
        ((DescriptionMenuItem) this.ScoreHistorys[this.HistorySelectIndex]).Description = stageData.S_History[this.HistorySelectIndex].Data2DrawString();
    }

    public override void Show()
    {
      base.Show();
      if (this.ScoreHistorys.Count <= 0)
        return;
      this.ScoreHistorys.ForEach((Action<BaseMenuItem>) (x => x.Show()));
    }
  }
}
