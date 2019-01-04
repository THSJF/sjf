// Decompiled with JetBrains decompiler
// Type: Shooting.MenuGroup_ReplaySaver
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Shooting
{
  internal class MenuGroup_ReplaySaver : BaseMenuGroup
  {
    public MenuGroup_ReplaySaver(StageDataPackage StageData, PointF OriginalPosition)
      : base(StageData)
    {
      this.OriginalPosition = OriginalPosition;
      this.MenuSelectIndex = 0;
      this.MenuItemList = new List<BaseMenuItem>();
      for (int index = 0; index < 25; ++index)
        this.MenuItemList.Add((BaseMenuItem) new DescriptionMenuItem(StageData, string.Format("{0:00}", (object) (index + 1))));
      float x = OriginalPosition.X + 12f;
      float y = OriginalPosition.Y + 12f;
      foreach (BaseMenuItem menuItem in this.MenuItemList)
      {
        menuItem.Position = new PointF(x, (float) (this.BoundRect.Top + 10));
        menuItem.DestPoint = new PointF(x, y);
        y += 17f;
        ((DescriptionMenuItem) menuItem).Description = this.SetDescroption(".\\Replay\\thSSS_" + menuItem.Name + ".rpy");
      }
      this.MenuItemList[this.MenuSelectIndex].Selected = true;
    }

    public virtual string SetDescroption(string fileName)
    {
      string str1 = "------- -------- ------ -- --- ";
      if (!File.Exists(fileName))
        return str1;
      try
      {
        ReplayInfo replayInfo = Replay.ReadTitle(fileName);
        if (replayInfo.Version != "ver 1.00")
          return str1;
        string str2 = (string) null;
        if (replayInfo != null)
        {
          string str3 = str2 + (replayInfo.PlayerName == null ? "        " : replayInfo.PlayerName.PadRight(8)) + (replayInfo.Date == null ? "       " : replayInfo.Date.PadRight(9)) + (replayInfo.MyPlaneName == null ? "               " : replayInfo.MyPlaneName.PadRight(7));
          switch (replayInfo.Rank)
          {
            case DifficultLevel.Easy:
              str3 += "E  ";
              break;
            case DifficultLevel.Normal:
              str3 += "N  ";
              break;
            case DifficultLevel.Hard:
              str3 += "H  ";
              break;
            case DifficultLevel.Lunatic:
              str3 += "L  ";
              break;
            case DifficultLevel.Ultra:
              str3 += "U  ";
              break;
            case DifficultLevel.Extra:
              str3 += "EX ";
              break;
          }
          str2 = str3 + (replayInfo.LastStage == null ? "   " : replayInfo.LastStage.PadRight(4));
        }
        return str2;
      }
      catch
      {
        return str1;
      }
    }

    public override void ProcessKeys()
    {
      base.ProcessKeys();
      this.ProcessKeys2();
    }

    public virtual void ProcessKeys2()
    {
      if (this.KClass.Key_Z && this.LastZ == 0)
      {
        this.MenuItemList[this.MenuSelectIndex].Click();
        this.OnChangeMenu = this.TimeMain + 1;
      }
      if (!this.KClass.Key_X && !this.KClass.Key_ESC || this.LastX != 0)
        return;
      this.StageData.SoundPlay("se_cancel00.wav");
      if (this.StageData.Rep.CanRead)
      {
        ReplayInfo repInfo = this.StageData.GlobalData.LastState.StageData.RepInfo;
        repInfo.PlayerName = "autosave";
        this.StageData.Rep.SaveRpy(".\\Replay\\AutoSave.rpy", repInfo);
      }
      this.StageData.StateSwitchData = new StateSwitchDataPackage()
      {
        NextState = "MainMenu",
        NeedInit = true,
        SDPswitch = new StageDataPackage(this.StageData.GlobalData)
      };
      this.StageData.Rep.CloseRpy();
    }

    public override void ProcessZ()
    {
      if (!this.StageData.Rep.CanRead)
        return;
      this.StageData.SoundPlay("se_ok00.wav");
      this.StageData.GlobalData.LastState.StageData.SetReplayStageInfo();
      this.StageData.MenuGroupList.Add((BaseMenuGroup) new MenuGroup_ReplayNamer(this.StageData, this.MenuItemList[0].OriginalPosition, (DescriptionMenuItem) this.MenuItemList[this.MenuSelectIndex]));
    }
  }
}
