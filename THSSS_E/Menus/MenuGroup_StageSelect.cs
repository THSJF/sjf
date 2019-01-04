// Decompiled with JetBrains decompiler
// Type: Shooting.MenuGroup_StageSelect
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  internal class MenuGroup_StageSelect : BaseMenuGroup
  {
    public MenuGroup_StageSelect(StageDataPackage StageData)
      : base(StageData)
    {
      this.MenuSelectIndex = 0;
      this.MenuItemList = new List<BaseMenuItem>();
      this.MenuItemList.Add(new BaseMenuItem(StageData, "Stage01"));
      this.MenuItemList.Add(new BaseMenuItem(StageData, "Boss01"));
      int practiceLevel = 1;
      StageData.PData.C_History.ForEach((Action<ClearHistory>) (a =>
      {
        if (a.Rank != StageData.StateSwitchData.SDPswitch.Difficulty || !(a.MyPlaneFullName == StageData.StateSwitchData.SDPswitch.MyPlane.FullName))
          return;
        practiceLevel = a.PracticeLevel;
      }));
      if (practiceLevel > 1)
      {
        this.MenuItemList.Add(new BaseMenuItem(StageData, "Stage02"));
        this.MenuItemList.Add(new BaseMenuItem(StageData, "Boss02"));
      }
      if (practiceLevel > 2)
      {
        this.MenuItemList.Add(new BaseMenuItem(StageData, "Stage03"));
        this.MenuItemList.Add(new BaseMenuItem(StageData, "Boss03"));
      }
      if (practiceLevel > 3)
      {
        this.MenuItemList.Add(new BaseMenuItem(StageData, "Stage04"));
        this.MenuItemList.Add(new BaseMenuItem(StageData, "Boss04"));
      }
      if (practiceLevel > 4)
      {
        this.MenuItemList.Add(new BaseMenuItem(StageData, "Stage05"));
        this.MenuItemList.Add(new BaseMenuItem(StageData, "Boss05"));
      }
      if (practiceLevel > 5)
      {
        this.MenuItemList.Add(new BaseMenuItem(StageData, "Stage06"));
        this.MenuItemList.Add(new BaseMenuItem(StageData, "Boss06"));
      }
      int num1 = 440;
      int num2 = 120;
      int num3 = 0;
      int num4 = 0;
      foreach (BaseMenuItem menuItem in this.MenuItemList)
      {
        menuItem.Position = new PointF((float) (num1 + num3), 120f);
        if (num4 % 2 == 0)
        {
          menuItem.DestPoint = new PointF((float) num1, (float) num2);
        }
        else
        {
          menuItem.DestPoint = new PointF((float) (num1 + 80), (float) num2);
          num2 += 32;
        }
        ++num4;
      }
      this.MenuItemList[this.MenuSelectIndex].Selected = true;
      BaseMenuItem baseMenuItem = new BaseMenuItem(StageData, "MenuTitle_StageSelect");
      baseMenuItem.Position = this.MenuTitlePos2;
      this.MenuTilte = baseMenuItem;
      this.TransparentValueF = 0.0f;
      this.MaxTransparent = 210;
      this.TransparentVelocity = 10f;
      this.AngleDegree = 90.0;
      this.Scale = 0.75f;
      this.OriginalPosition = new PointF((float) (this.BoundRect.Width / 2 + 30 * (int) (StageData.StateSwitchData.SDPswitch.Difficulty - 1)), (float) (this.BoundRect.Height / 2 - 20 * (int) (StageData.StateSwitchData.SDPswitch.Difficulty - 1)));
    }

    public override void ProcessKeys()
    {
      if (this.KClass.ArrowDown && (this.LastDown == 0 || this.LastDown > 30))
      {
        this.MenuSelectIndex += 2;
        this.StageData.SoundPlay("se_select00.wav");
        this.SelectItemChanged();
      }
      if (this.KClass.ArrowUp && (this.LastUp == 0 || this.LastUp > 30))
      {
        this.MenuSelectIndex -= 2;
        this.StageData.SoundPlay("se_select00.wav");
        this.SelectItemChanged();
      }
      if (this.KClass.ArrowLeft && (this.LastLeft == 0 || this.LastLeft > 30))
      {
        --this.MenuSelectIndex;
        this.StageData.SoundPlay("se_select00.wav");
        this.SelectItemChanged();
      }
      if (this.KClass.ArrowRight && (this.LastRight == 0 || this.LastRight > 30))
      {
        ++this.MenuSelectIndex;
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
        menuItem.DestPoint = new PointF(480f, 120f);
        menuItem.OnRemove = true;
      }
      this.StageData.SoundPlay("se_cancel00.wav");
    }

    public override void ProcessZ()
    {
            StageData.StateSwitchData.SDPswitch.MyPlane.LifeUpCount=SourseForm.lifeUpCount;
            StageData.StateSwitchData.SDPswitch.MyPlane.Life=SourseForm.life;
            StageData.StateSwitchData.SDPswitch.MyPlane.LifeChip=SourseForm.lifeChip;
            StageData.StateSwitchData.SDPswitch.MyPlane.Spell=SourseForm.spell;
            StageData.StateSwitchData.SDPswitch.MyPlane.SpellChip=SourseForm.spellChip;
            StageData.StateSwitchData.SDPswitch.MyPlane.Power=SourseForm.power;
            StageData.StateSwitchData.SDPswitch.MyPlane.HighItemScore=SourseForm.highItemScore;
            StageData.StateSwitchData.SDPswitch.MyPlane.StarPoint=SourseForm.starPoint;
            StageData.StateSwitchData.SDPswitch.MyPlane.LastColor=SourseForm.starColor;
            StageData.StateSwitchData.SDPswitch.MyPlane.Score=SourseForm.score;
            //this.StageData.StateSwitchData.SDPswitch.MyPlane.Life = 9;
            this.StageData.StateSwitchData.SDPswitch.OnPractice = true;
      switch (this.MenuItemList[this.MenuSelectIndex].Name)
      {
        case "Stage01":
          this.StageData.Rep.CreatRpy();
          this.StageData.StateSwitchData.NextState = "St1";
          this.StageData.StateSwitchData.SDPswitch.SetReplayInfo(this.StageData.StateSwitchData.NextState);
          break;
        case "Stage02":
          this.StageData.Rep.CreatRpy();
          this.StageData.StateSwitchData.NextState = "St2";
          this.StageData.StateSwitchData.SDPswitch.SetReplayInfo(this.StageData.StateSwitchData.NextState);
          break;
        case "Stage03":
          this.StageData.Rep.CreatRpy();
          this.StageData.StateSwitchData.NextState = "St3";
          this.StageData.StateSwitchData.SDPswitch.SetReplayInfo(this.StageData.StateSwitchData.NextState);
          break;
        case "Stage04":
          this.StageData.Rep.CreatRpy();
          this.StageData.StateSwitchData.NextState = "St4";
          this.StageData.StateSwitchData.SDPswitch.SetReplayInfo(this.StageData.StateSwitchData.NextState);
          break;
        case "Stage05":
          this.StageData.Rep.CreatRpy();
          this.StageData.StateSwitchData.NextState = "St5";
          this.StageData.StateSwitchData.SDPswitch.SetReplayInfo(this.StageData.StateSwitchData.NextState);
          break;
        case "Stage06":
          this.StageData.Rep.CreatRpy();
          this.StageData.StateSwitchData.NextState = "St6";
          this.StageData.StateSwitchData.SDPswitch.SetReplayInfo(this.StageData.StateSwitchData.NextState);
          break;
        case "Boss01":
          this.StageData.Rep.CreatRpy();
          this.StageData.StateSwitchData.NextState = "Bs1";
          this.StageData.StateSwitchData.SDPswitch.SetReplayInfo(this.StageData.StateSwitchData.NextState);
          break;
        case "Boss02":
          this.StageData.Rep.CreatRpy();
          this.StageData.StateSwitchData.NextState = "Bs2";
          this.StageData.StateSwitchData.SDPswitch.SetReplayInfo(this.StageData.StateSwitchData.NextState);
          break;
        case "Boss03":
          this.StageData.Rep.CreatRpy();
          this.StageData.StateSwitchData.NextState = "Bs3";
          this.StageData.StateSwitchData.SDPswitch.SetReplayInfo(this.StageData.StateSwitchData.NextState);
          break;
        case "Boss04":
          this.StageData.Rep.CreatRpy();
          this.StageData.StateSwitchData.NextState = "Bs4";
          this.StageData.StateSwitchData.SDPswitch.SetReplayInfo(this.StageData.StateSwitchData.NextState);
          break;
        case "Boss05":
          this.StageData.Rep.CreatRpy();
          this.StageData.StateSwitchData.NextState = "Bs5";
          this.StageData.StateSwitchData.SDPswitch.SetReplayInfo(this.StageData.StateSwitchData.NextState);
          break;
        case "Boss06":
          this.StageData.Rep.CreatRpy();
          this.StageData.StateSwitchData.NextState = "Bs6";
          this.StageData.StateSwitchData.SDPswitch.SetReplayInfo(this.StageData.StateSwitchData.NextState);
          break;
        case "StageEx":
          this.StageData.Rep.CreatRpy();
          this.StageData.StateSwitchData.NextState = "Stage_test";
          this.StageData.StateSwitchData.SDPswitch.SetReplayInfo(this.StageData.StateSwitchData.NextState);
          break;
      }
    }
  }
}
