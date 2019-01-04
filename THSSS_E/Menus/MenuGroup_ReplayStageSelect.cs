// Decompiled with JetBrains decompiler
// Type: Shooting.MenuGroup_ReplayStageSelect
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Shooting
{
  internal class MenuGroup_ReplayStageSelect : BaseMenuGroup
  {
    private const string NullDescription = "----------";
    private string RepIndex;

    public MenuGroup_ReplayStageSelect(
      StageDataPackage StageData,
      PointF OriginalPosition,
      DescriptionMenuItem RepMenuItem)
      : base(StageData)
    {
      this.RepIndex = RepMenuItem.Name;
      this.MenuSelectIndex = 0;
      this.MenuItemList = new List<BaseMenuItem>();
      for (int index = 0; index < 6; ++index)
        this.MenuItemList.Add((BaseMenuItem) new DescriptionMenuItem(StageData, string.Format("Stage{0:00}", (object) (index + 1)))
        {
          Description = "----------"
        });
      this.MenuItemList.Add((BaseMenuItem) new DescriptionMenuItem(StageData, "StageEx")
      {
        Description = "----------"
      });
      float x = OriginalPosition.X + 12f;
      float y = OriginalPosition.Y + 12f;
      foreach (BaseMenuItem menuItem in this.MenuItemList)
      {
        menuItem.Position = new PointF(x, OriginalPosition.Y + 10f);
        menuItem.DestPoint = new PointF(x, y);
        y += 17f;
      }
      string str = ".\\Replay\\thSSS_" + this.RepIndex + ".rpy";
      if (File.Exists(str))
      {
        ReplayInfo replayInfo = Replay.ReadTitle(str);
        if (replayInfo.StartStage == "StEx")
        {
          ((DescriptionMenuItem) this.MenuItemList[6]).Description = replayInfo.MyPlaneData[1].Score.ToString().PadLeft(10);
        }
        else
        {
          int num = !replayInfo.StartStage.Contains("St") ? Convert.ToInt32(replayInfo.StartStage.Replace("Bs", "")) : Convert.ToInt32(replayInfo.StartStage.Replace("St", ""));
          for (int index = 0; index < replayInfo.MyPlaneData.Count - 1; ++index)
          {
            if (num - 1 + index < 6)
              ((DescriptionMenuItem) this.MenuItemList[num - 1 + index]).Description = replayInfo.MyPlaneData[index + 1].Score.ToString().PadLeft(10);
          }
        }
      }
      this.MenuItemList[this.MenuSelectIndex].Selected = true;
      DescriptionMenuItem descriptionMenuItem = new DescriptionMenuItem(StageData, this.RepIndex);
      descriptionMenuItem.Description = RepMenuItem.Description;
      descriptionMenuItem.OriginalPosition = RepMenuItem.OriginalPosition;
      descriptionMenuItem.Selected = true;
      this.MenuTilte = (BaseMenuItem) descriptionMenuItem;
      this.MenuTitlePos1 = new PointF(RepMenuItem.OriginalPosition.X, 16f);
      this.MenuTitlePos2 = RepMenuItem.OriginalPosition;
      this.TxtureObject = this.TextureObjectDictionary["MenuBackground"];
      this.OriginalPosition = new PointF((float) (this.BoundRect.Width / 2), (float) (this.BoundRect.Height / 2));
      this.AngleDegree = 90.0;
      this.ColorValue = Color.SkyBlue;
    }

    public override void ProcessKeys()
    {
      base.ProcessKeys();
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
      if (!(((DescriptionMenuItem) this.MenuItemList[this.MenuSelectIndex]).Description != "----------"))
        return;
      this.StageData.SoundPlay("se_ok00.wav");
      string fileName = ".\\Replay\\thSSS_" + this.RepIndex + ".rpy";
      this.StageData.Rep.LoadRpy(fileName);
      ReplayInfo replayInfo = Replay.ReadTitle(fileName);
      this.StageData.RepInfo = replayInfo;
      int num;
      string str;
      if (this.MenuSelectIndex < 6)
      {
        if (replayInfo.StartStage.Contains("St"))
        {
          num = this.MenuSelectIndex + 1;
          str = "St" + num.ToString();
        }
        else
        {
          num = this.MenuSelectIndex + 1;
          str = "Bs" + num.ToString();
        }
      }
      else
        str = "StEx";
      this.StageData.StateSwitchData = new StateSwitchDataPackage()
      {
        NextState = str,
        NeedInit = true,
        SDPswitch = new StageDataPackage(this.StageData.GlobalData)
        {
          OnReplay = true,
          Difficulty = replayInfo.Rank
        }
      };
      int index = !(str == "StEx") ? (!replayInfo.StartStage.Contains("St") ? this.MenuSelectIndex - Convert.ToInt32(replayInfo.StartStage.Replace("Bs", "")) + 1 : this.MenuSelectIndex - Convert.ToInt32(replayInfo.StartStage.Replace("St", "")) + 1) : 0;
      Point point = new Point(192, 398);
      if (index >= 0)
        point = new Point((int) replayInfo.MyPlaneData[index].PosX, (int) replayInfo.MyPlaneData[index].PosY);
      BaseMyPlane baseMyPlane;
      switch (replayInfo.MyPlaneName)
      {
        case "Aya":
          switch (replayInfo.WeaponType)
          {
            case "A":
              baseMyPlane = (BaseMyPlane) new MyPlane_Aya(this.StageData.StateSwitchData.SDPswitch, point);
              break;
            case "B":
              baseMyPlane = (BaseMyPlane) new MyPlane_AyaB(this.StageData.StateSwitchData.SDPswitch, point);
              break;
            default:
              baseMyPlane = new BaseMyPlane(this.StageData.StateSwitchData.SDPswitch, point);
              break;
          }
                    break;
        case "Plane":
          switch (replayInfo.WeaponType)
          {
            case "A":
              baseMyPlane = new BaseMyPlane(this.StageData.StateSwitchData.SDPswitch, point);
              break;
            case "B":
              baseMyPlane = (BaseMyPlane) new MyPlane_PlaneB(this.StageData.StateSwitchData.SDPswitch, point);
              break;
            default:
              baseMyPlane = new BaseMyPlane(this.StageData.StateSwitchData.SDPswitch, point);
              break;
          }
                    break;
        case "Reimu":
          baseMyPlane = (BaseMyPlane) new MyPlane_Reimu(this.StageData.StateSwitchData.SDPswitch, point);
          break;
        case "Sanae":
          baseMyPlane = (BaseMyPlane) new MyPlane_Sanae(this.StageData.StateSwitchData.SDPswitch, point);
          break;
        case "Marisa":
          baseMyPlane = (BaseMyPlane) new MyPlane_Marisa(this.StageData.StateSwitchData.SDPswitch, point);
          break;
        case "Koishi":
          baseMyPlane = (BaseMyPlane) new MyPlane_Koishi(this.StageData.StateSwitchData.SDPswitch, point);
          break;
        default:
          baseMyPlane = new BaseMyPlane(this.StageData.StateSwitchData.SDPswitch, point);
          break;
      }
      if (index >= 0)
      {
        baseMyPlane.Life = replayInfo.MyPlaneData[index].Life;
        baseMyPlane.Spell = replayInfo.MyPlaneData[index].Spell;
        baseMyPlane.Power = replayInfo.MyPlaneData[index].Power;
        baseMyPlane.Score = replayInfo.MyPlaneData[index].Score;
        baseMyPlane.OriginalPosition = new PointF(replayInfo.MyPlaneData[index].PosX, replayInfo.MyPlaneData[index].PosY);
        baseMyPlane.Graze = replayInfo.MyPlaneData[index].Graze;
        baseMyPlane.LifeUpCount = replayInfo.MyPlaneData[index].LifeUpCount;
        baseMyPlane.LifeChip = replayInfo.MyPlaneData[index].LifeChip;
        baseMyPlane.SpellChip = replayInfo.MyPlaneData[index].SpellChip;
        baseMyPlane.StarPoint = replayInfo.MyPlaneData[index].StarPoint;
        baseMyPlane.HighItemScore = replayInfo.MyPlaneData[index].HighItemScore;
        baseMyPlane.Rate = replayInfo.MyPlaneData[index].Rate;
        baseMyPlane.LastColor = replayInfo.MyPlaneData[index].LastColor;
        this.StageData.Rep.DataPosition = replayInfo.MyPlaneData[index].DataPosition;
      }
      this.StageData.StateSwitchData.SDPswitch.MyPlane = baseMyPlane;
      this.StageData.StateSwitchData.SDPswitch.RepInfo = replayInfo;
    }
  }
}
