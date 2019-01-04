// Decompiled with JetBrains decompiler
// Type: Shooting.MenuGroup_ReplayLoader
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;
using System.IO;

namespace Shooting
{
  internal class MenuGroup_ReplayLoader : MenuGroup_ReplaySaver
  {
    private const string NullDescription = "------- -------- ----- ------- ------- --- ----";

    public MenuGroup_ReplayLoader(StageDataPackage StageData, PointF OriginalPosition)
      : base(StageData, OriginalPosition)
    {
      this.TransparentValueF = 0.0f;
      this.TransparentVelocity = 5f;
      this.TxtureObject = this.TextureObjectDictionary["MenuBackground"];
      this.Scale = 0.625f;
      Rectangle boundRect = this.BoundRect;
      double num1 = (double) (boundRect.Width / 2);
      boundRect = this.BoundRect;
      double num2 = (double) (boundRect.Height / 2);
      this.OriginalPosition = new PointF((float) num1, (float) num2);
      this.AngleDegree = 90.0;
      this.ColorValue = Color.SkyBlue;
    }

    public override string SetDescroption(string fileName)
    {
      if (!File.Exists(fileName))
        return "------- -------- ----- ------- ------- --- ----";
      try
      {
        ReplayInfo replayInfo = Replay.ReadTitle(fileName);
        if (replayInfo.Version != "ver 1.00")
          return "------- -------- ----- ------- ------- --- ----";
        string str = (string) null;
        if (replayInfo != null)
          str = str + (replayInfo.PlayerName == null ? "        " : replayInfo.PlayerName.PadRight(8)) + (replayInfo.Date == null ? "        " : replayInfo.Date.PadRight(9)) + (replayInfo.Time == null ? "        " : replayInfo.Time.PadRight(6)) + (replayInfo.MyPlaneName == null ? "               " : replayInfo.MyPlaneName.PadRight(8)) + replayInfo.Rank.ToString().PadRight(8) + (replayInfo.LastStage == null ? "   " : replayInfo.LastStage.PadRight(4)) + (replayInfo.SlowRate == null ? "   " : replayInfo.SlowRate.PadRight(4));
        return str;
      }
      catch
      {
        return "------- -------- ----- ------- ------- --- ----";
      }
    }

    public override void ProcessKeys2()
    {
      if (this.KClass.Key_Z && this.LastZ == 0)
      {
        this.MenuItemList[this.MenuSelectIndex].Click();
        this.OnChangeMenu = this.TimeMain + 1;
      }
      if (!this.KClass.Key_X && !this.KClass.Key_ESC || this.LastX != 0)
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
      if (!(((DescriptionMenuItem) this.MenuItemList[this.MenuSelectIndex]).Description != "------- -------- ----- ------- ------- --- ----"))
        return;
      this.StageData.SoundPlay("se_ok00.wav");
      this.StageData.MenuGroupList.Add((BaseMenuGroup) new MenuGroup_ReplayStageSelect(this.StageData, new PointF(200f, 150f), (DescriptionMenuItem) this.MenuItemList[this.MenuSelectIndex]));
    }
  }
}
