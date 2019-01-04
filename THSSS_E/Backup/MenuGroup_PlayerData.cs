// Decompiled with JetBrains decompiler
// Type: Shooting.MenuGroup_PlayerData
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  internal class MenuGroup_PlayerData : BaseMenuGroup
  {
    private int ScorePageIndex = 0;
    private List<BaseMenuItem> MenuItemListPlane;
    private int MenuPlaneSelectIndex;
    private List<DescriptionMenuItem> ScorePageList;
    private List<BaseMenuItem> ClearHistoryList;

    public MenuGroup_PlayerData(StageDataPackage StageData)
      : base(StageData)
    {
      this.TransparentValueF = 0.0f;
      this.MaxTransparent = (int) byte.MaxValue;
      this.TransparentVelocity = 5f;
      this.TxtureObject = this.TextureObjectDictionary["MenuBackground"];
      Rectangle boundRect = this.BoundRect;
      double num1 = (double) (boundRect.Width / 2);
      boundRect = this.BoundRect;
      double num2 = (double) (boundRect.Height / 2);
      this.OriginalPosition = new PointF((float) num1, (float) num2);
      this.AngleDegree = 90.0;
      this.ColorValue = Color.FromArgb(30, 110, 150);
      this.MenuTitlePos1 = new PointF(140f, -30f);
      this.MenuTitlePos2 = new PointF(140f, -150f);
      BaseMenuItem baseMenuItem1 = new BaseMenuItem(StageData, "MenuTitle_PlayerData");
      baseMenuItem1.Position = this.MenuTitlePos2;
      this.MenuTilte = baseMenuItem1;
      this.ClearHistoryList = new List<BaseMenuItem>();
      this.MenuPlaneSelectIndex = 0;
      this.MenuItemListPlane = new List<BaseMenuItem>()
      {
        new BaseMenuItem(StageData, "History_ReimuA"),
        new BaseMenuItem(StageData, "History_MarisaA"),
        new BaseMenuItem(StageData, "History_SanaeA"),
        new BaseMenuItem(StageData, "History_KoishiA")
      };
      int num3 = 90;
      int num4 = 90;
      int num5 = 0;
      foreach (BaseMenuItem baseMenuItem2 in this.MenuItemListPlane)
      {
        baseMenuItem2.DestPoint = new PointF((float) num3, (float) num4);
        baseMenuItem2.Position = new PointF((float) (num3 + num5), (float) num4);
        baseMenuItem2.UnSelectVisible = false;
        baseMenuItem2.Vibrateable = false;
      }
      this.MenuItemListPlane[this.MenuSelectIndex].Selected = true;
      this.MenuSelectIndex = 0;
      this.MenuItemList = new List<BaseMenuItem>()
      {
        new BaseMenuItem(StageData, "History_Easy"),
        new BaseMenuItem(StageData, "History_Normal"),
        new BaseMenuItem(StageData, "History_Hard"),
        new BaseMenuItem(StageData, "History_Lunatic"),
        new BaseMenuItem(StageData, "History_Extra")
      };
      int num6 = 480;
      int num7 = 90;
      int num8 = 0;
      foreach (BaseMenuItem menuItem in this.MenuItemList)
      {
        menuItem.DestPoint = new PointF((float) num6, (float) num7);
        menuItem.Position = new PointF((float) (num6 + num8), (float) num7);
        menuItem.UnSelectVisible = false;
        menuItem.Vibrateable = false;
      }
      this.MenuItemList[this.MenuSelectIndex].Selected = true;
      this.ScorePageList = new List<DescriptionMenuItem>();
      this.AddNewScorePage();
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.MenuItemListPlane.ForEach((Action<BaseMenuItem>) (x => x.Ctrl()));
      this.ScorePageList.ForEach((Action<DescriptionMenuItem>) (x => x.Ctrl()));
      this.ClearHistoryList.ForEach((Action<BaseMenuItem>) (x => x.Ctrl()));
    }

    public override void ProcessKeys()
    {
      base.ProcessKeys();
      if (this.KClass.Key_Z && this.LastZ == 0)
      {
        ++this.ScorePageIndex;
        if (this.ScorePageIndex > (this.MenuSelectIndex == 2 || this.MenuSelectIndex == 3 ? 5 : 4))
          this.ScorePageIndex = 0;
        this.AddNewScorePage();
        this.StageData.SoundPlay("se_ok00.wav");
      }
      if ((this.KClass.Key_X || this.KClass.Key_ESC) && this.LastX == 0)
      {
        this.OnRemoveMenu = this.TimeMain + 20;
        this.TransparentVelocity = -15f;
        foreach (BaseMenuItem menuItem in this.MenuItemList)
          menuItem.OnRemove = true;
        foreach (BaseMenuItem baseMenuItem in this.MenuItemListPlane)
          baseMenuItem.OnRemove = true;
        foreach (BaseMenuItem scorePage in this.ScorePageList)
          scorePage.OnRemove = true;
        foreach (BaseMenuItem clearHistory in this.ClearHistoryList)
          clearHistory.OnRemove = true;
        this.StageData.SoundPlay("se_cancel00.wav");
      }
      if (this.KClass.ArrowRight && (this.LastRight == 0 || this.LastRight > 30))
      {
        ++this.MenuPlaneSelectIndex;
        this.StageData.SoundPlay("se_select00.wav");
        this.SelectItemChanged();
      }
      if (!this.KClass.ArrowLeft || this.LastLeft != 0 && this.LastLeft <= 30)
        return;
      --this.MenuPlaneSelectIndex;
      this.StageData.SoundPlay("se_select00.wav");
      this.SelectItemChanged();
    }

    public override void SelectItemChanged()
    {
      base.SelectItemChanged();
      if (this.MenuPlaneSelectIndex < 0)
        this.MenuPlaneSelectIndex += this.MenuItemListPlane.Count;
      else if (this.MenuPlaneSelectIndex > this.MenuItemListPlane.Count - 1)
        this.MenuPlaneSelectIndex -= this.MenuItemListPlane.Count;
      this.MenuItemListPlane.ForEach((Action<BaseMenuItem>) (x => x.Selected = false));
      this.MenuItemListPlane[this.MenuPlaneSelectIndex].Select();
      this.ScorePageIndex = 0;
      this.AddNewScorePage();
    }

    private void AddNewScorePage()
    {
      this.ScorePageList.Clear();
      List<ScoreHistory> all1 = this.StageData.PData.S_History.FindAll(new Predicate<ScoreHistory>(this.FindScore));
      List<SpellCardHistory> all2 = this.StageData.PData.SC_History.FindAll(new Predicate<SpellCardHistory>(this.FindSC));
      List<ClearHistory> all3 = this.StageData.PData.C_History.FindAll(new Predicate<ClearHistory>(this.FindClear));
      switch (this.ScorePageIndex)
      {
        case 0:
          for (int index = 0; index < all1.Count; ++index)
            this.ScorePageList.Add(new DescriptionMenuItem(this.StageData, (index + 1).ToString().PadRight(2))
            {
              Description = all1[index].Data2DrawString(),
              DefaultColor = Color.FromArgb(230 - 15 * index, 230 - 12 * index, (int) byte.MaxValue)
            });
          int num1 = 50;
          int num2 = 130;
          int num3 = 0;
          using (List<DescriptionMenuItem>.Enumerator enumerator = this.ScorePageList.GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              BaseMenuItem current = (BaseMenuItem) enumerator.Current;
              current.DestPoint = new PointF((float) num1, (float) num2);
              current.Position = new PointF((float) (num1 + num3), 100f);
              num2 += 20;
            }
            break;
          }
        case 1:
          int num4;
          for (int index = 0; index < 10; ++index)
          {
            if (all2[index].History > 0)
            {
              List<DescriptionMenuItem> scorePageList = this.ScorePageList;
              StageDataPackage stageData = this.StageData;
              num4 = all2[index].Index;
              string Name = num4.ToString().PadRight(3);
              SCMenuItem scMenuItem1 = new SCMenuItem(stageData, Name);
              SCMenuItem scMenuItem2 = scMenuItem1;
              num4 = all2[index].Recorded;
              string str1 = num4.ToString().PadLeft(2);
              num4 = all2[index].History;
              string str2 = num4.ToString().PadLeft(2);
              string str3 = (str1 + "/" + str2).PadLeft(40);
              scMenuItem2.Description = str3;
              scMenuItem1.TxtureObject = this.StageData.TextureObjectDictionary["欧" + all2[index].Name];
              scMenuItem1.DefaultColor = all2[index].Recorded > 0 ? Color.SkyBlue : Color.White;
              SCMenuItem scMenuItem3 = scMenuItem1;
              scorePageList.Add((DescriptionMenuItem) scMenuItem3);
            }
            else
            {
              List<DescriptionMenuItem> scorePageList = this.ScorePageList;
              StageDataPackage stageData = this.StageData;
              num4 = all2[index].Index;
              string Name = num4.ToString().PadRight(3);
              SCMenuItem scMenuItem1 = new SCMenuItem(stageData, Name);
              SCMenuItem scMenuItem2 = scMenuItem1;
              num4 = all2[index].Recorded;
              string str1 = num4.ToString().PadLeft(2);
              num4 = all2[index].History;
              string str2 = num4.ToString().PadLeft(2);
              string str3 = (str1 + "/" + str2).PadLeft(40);
              scMenuItem2.Description = str3;
              scMenuItem1.TxtureObject = this.StageData.TextureObjectDictionary["???"];
              scMenuItem1.DefaultColor = all2[index].Recorded > 0 ? Color.SkyBlue : Color.White;
              SCMenuItem scMenuItem3 = scMenuItem1;
              scorePageList.Add((DescriptionMenuItem) scMenuItem3);
            }
          }
          int num5 = 80;
          int num6 = 130;
          int num7 = 0;
          using (List<DescriptionMenuItem>.Enumerator enumerator = this.ScorePageList.GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              BaseMenuItem current = (BaseMenuItem) enumerator.Current;
              current.DestPoint = new PointF((float) num5, (float) num6);
              current.Position = new PointF((float) (num5 + num7), 100f);
              num6 += 20;
            }
            break;
          }
        case 2:
          int num8;
          for (int index = 10; index < 20; ++index)
          {
            if (all2[index].History > 0)
            {
              List<DescriptionMenuItem> scorePageList = this.ScorePageList;
              StageDataPackage stageData = this.StageData;
              num8 = all2[index].Index;
              string Name = num8.ToString().PadRight(3);
              SCMenuItem scMenuItem1 = new SCMenuItem(stageData, Name);
              SCMenuItem scMenuItem2 = scMenuItem1;
              num8 = all2[index].Recorded;
              string str1 = num8.ToString().PadLeft(2);
              num8 = all2[index].History;
              string str2 = num8.ToString().PadLeft(2);
              string str3 = (str1 + "/" + str2).PadLeft(40);
              scMenuItem2.Description = str3;
              scMenuItem1.TxtureObject = this.StageData.TextureObjectDictionary["欧" + all2[index].Name];
              scMenuItem1.DefaultColor = all2[index].Recorded > 0 ? Color.SkyBlue : Color.White;
              SCMenuItem scMenuItem3 = scMenuItem1;
              scorePageList.Add((DescriptionMenuItem) scMenuItem3);
            }
            else
            {
              List<DescriptionMenuItem> scorePageList = this.ScorePageList;
              StageDataPackage stageData = this.StageData;
              num8 = all2[index].Index;
              string Name = num8.ToString().PadRight(3);
              SCMenuItem scMenuItem1 = new SCMenuItem(stageData, Name);
              SCMenuItem scMenuItem2 = scMenuItem1;
              num8 = all2[index].Recorded;
              string str1 = num8.ToString().PadLeft(2);
              num8 = all2[index].History;
              string str2 = num8.ToString().PadLeft(2);
              string str3 = (str1 + "/" + str2).PadLeft(40);
              scMenuItem2.Description = str3;
              scMenuItem1.TxtureObject = this.StageData.TextureObjectDictionary["???"];
              scMenuItem1.DefaultColor = all2[index].Recorded > 0 ? Color.SkyBlue : Color.White;
              SCMenuItem scMenuItem3 = scMenuItem1;
              scorePageList.Add((DescriptionMenuItem) scMenuItem3);
            }
          }
          int num9 = 80;
          int num10 = 130;
          int num11 = 0;
          using (List<DescriptionMenuItem>.Enumerator enumerator = this.ScorePageList.GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              BaseMenuItem current = (BaseMenuItem) enumerator.Current;
              current.DestPoint = new PointF((float) num9, (float) num10);
              current.Position = new PointF((float) (num9 + num11), 100f);
              num10 += 20;
            }
            break;
          }
        case 3:
          int num12;
          for (int index = 20; index < Math.Min(all2.Count, 30); ++index)
          {
            if (all2[index].History > 0)
            {
              List<DescriptionMenuItem> scorePageList = this.ScorePageList;
              StageDataPackage stageData = this.StageData;
              num12 = all2[index].Index;
              string Name = num12.ToString().PadRight(3);
              SCMenuItem scMenuItem1 = new SCMenuItem(stageData, Name);
              SCMenuItem scMenuItem2 = scMenuItem1;
              num12 = all2[index].Recorded;
              string str1 = num12.ToString().PadLeft(2);
              num12 = all2[index].History;
              string str2 = num12.ToString().PadLeft(2);
              string str3 = (str1 + "/" + str2).PadLeft(40);
              scMenuItem2.Description = str3;
              scMenuItem1.TxtureObject = this.StageData.TextureObjectDictionary["欧" + all2[index].Name];
              scMenuItem1.DefaultColor = all2[index].Recorded > 0 ? Color.SkyBlue : Color.White;
              SCMenuItem scMenuItem3 = scMenuItem1;
              scorePageList.Add((DescriptionMenuItem) scMenuItem3);
            }
            else
            {
              List<DescriptionMenuItem> scorePageList = this.ScorePageList;
              StageDataPackage stageData = this.StageData;
              num12 = all2[index].Index;
              string Name = num12.ToString().PadRight(3);
              SCMenuItem scMenuItem1 = new SCMenuItem(stageData, Name);
              SCMenuItem scMenuItem2 = scMenuItem1;
              num12 = all2[index].Recorded;
              string str1 = num12.ToString().PadLeft(2);
              num12 = all2[index].History;
              string str2 = num12.ToString().PadLeft(2);
              string str3 = (str1 + "/" + str2).PadLeft(40);
              scMenuItem2.Description = str3;
              scMenuItem1.TxtureObject = this.StageData.TextureObjectDictionary["???"];
              scMenuItem1.DefaultColor = all2[index].Recorded > 0 ? Color.SkyBlue : Color.White;
              SCMenuItem scMenuItem3 = scMenuItem1;
              scorePageList.Add((DescriptionMenuItem) scMenuItem3);
            }
          }
          int num13 = 80;
          int num14 = 130;
          int num15 = 0;
          using (List<DescriptionMenuItem>.Enumerator enumerator = this.ScorePageList.GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              BaseMenuItem current = (BaseMenuItem) enumerator.Current;
              current.DestPoint = new PointF((float) num13, (float) num14);
              current.Position = new PointF((float) (num13 + num15), 100f);
              num14 += 20;
            }
            break;
          }
        case 4:
          int num16;
          for (int index = 30; index < Math.Min(all2.Count, 40); ++index)
          {
            if (all2[index].History > 0)
            {
              List<DescriptionMenuItem> scorePageList = this.ScorePageList;
              StageDataPackage stageData = this.StageData;
              num16 = all2[index].Index;
              string Name = num16.ToString().PadRight(3);
              SCMenuItem scMenuItem1 = new SCMenuItem(stageData, Name);
              SCMenuItem scMenuItem2 = scMenuItem1;
              num16 = all2[index].Recorded;
              string str1 = num16.ToString().PadLeft(2);
              num16 = all2[index].History;
              string str2 = num16.ToString().PadLeft(2);
              string str3 = (str1 + "/" + str2).PadLeft(40);
              scMenuItem2.Description = str3;
              scMenuItem1.TxtureObject = this.StageData.TextureObjectDictionary["欧" + all2[index].Name];
              scMenuItem1.DefaultColor = all2[index].Recorded > 0 ? Color.SkyBlue : Color.White;
              SCMenuItem scMenuItem3 = scMenuItem1;
              scorePageList.Add((DescriptionMenuItem) scMenuItem3);
            }
            else
            {
              List<DescriptionMenuItem> scorePageList = this.ScorePageList;
              StageDataPackage stageData = this.StageData;
              num16 = all2[index].Index;
              string Name = num16.ToString().PadRight(3);
              SCMenuItem scMenuItem1 = new SCMenuItem(stageData, Name);
              SCMenuItem scMenuItem2 = scMenuItem1;
              num16 = all2[index].Recorded;
              string str1 = num16.ToString().PadLeft(2);
              num16 = all2[index].History;
              string str2 = num16.ToString().PadLeft(2);
              string str3 = (str1 + "/" + str2).PadLeft(40);
              scMenuItem2.Description = str3;
              scMenuItem1.TxtureObject = this.StageData.TextureObjectDictionary["???"];
              scMenuItem1.DefaultColor = all2[index].Recorded > 0 ? Color.SkyBlue : Color.White;
              SCMenuItem scMenuItem3 = scMenuItem1;
              scorePageList.Add((DescriptionMenuItem) scMenuItem3);
            }
          }
          int num17 = 80;
          int num18 = 130;
          int num19 = 0;
          using (List<DescriptionMenuItem>.Enumerator enumerator = this.ScorePageList.GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              BaseMenuItem current = (BaseMenuItem) enumerator.Current;
              current.DestPoint = new PointF((float) num17, (float) num18);
              current.Position = new PointF((float) (num17 + num19), 100f);
              num18 += 20;
            }
            break;
          }
        case 5:
          int num20;
          for (int index = 40; index < Math.Min(all2.Count, 50); ++index)
          {
            if (all2[index].History > 0)
            {
              List<DescriptionMenuItem> scorePageList = this.ScorePageList;
              StageDataPackage stageData = this.StageData;
              num20 = all2[index].Index;
              string Name = num20.ToString().PadRight(3);
              SCMenuItem scMenuItem1 = new SCMenuItem(stageData, Name);
              SCMenuItem scMenuItem2 = scMenuItem1;
              num20 = all2[index].Recorded;
              string str1 = num20.ToString().PadLeft(2);
              num20 = all2[index].History;
              string str2 = num20.ToString().PadLeft(2);
              string str3 = (str1 + "/" + str2).PadLeft(40);
              scMenuItem2.Description = str3;
              scMenuItem1.TxtureObject = this.StageData.TextureObjectDictionary["欧" + all2[index].Name];
              scMenuItem1.DefaultColor = all2[index].Recorded > 0 ? Color.SkyBlue : Color.White;
              SCMenuItem scMenuItem3 = scMenuItem1;
              scorePageList.Add((DescriptionMenuItem) scMenuItem3);
            }
            else
            {
              List<DescriptionMenuItem> scorePageList = this.ScorePageList;
              StageDataPackage stageData = this.StageData;
              num20 = all2[index].Index;
              string Name = num20.ToString().PadRight(3);
              SCMenuItem scMenuItem1 = new SCMenuItem(stageData, Name);
              SCMenuItem scMenuItem2 = scMenuItem1;
              num20 = all2[index].Recorded;
              string str1 = num20.ToString().PadLeft(2);
              num20 = all2[index].History;
              string str2 = num20.ToString().PadLeft(2);
              string str3 = (str1 + "/" + str2).PadLeft(40);
              scMenuItem2.Description = str3;
              scMenuItem1.TxtureObject = this.StageData.TextureObjectDictionary["???"];
              scMenuItem1.DefaultColor = all2[index].Recorded > 0 ? Color.SkyBlue : Color.White;
              SCMenuItem scMenuItem3 = scMenuItem1;
              scorePageList.Add((DescriptionMenuItem) scMenuItem3);
            }
          }
          int num21 = 80;
          int num22 = 130;
          int num23 = 0;
          using (List<DescriptionMenuItem>.Enumerator enumerator = this.ScorePageList.GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              BaseMenuItem current = (BaseMenuItem) enumerator.Current;
              current.DestPoint = new PointF((float) num21, (float) num22);
              current.Position = new PointF((float) (num21 + num23), 100f);
              num22 += 20;
            }
            break;
          }
      }
      int num24 = 215;
      int num25 = 350;
      this.ClearHistoryList = new List<BaseMenuItem>();
      List<BaseMenuItem> clearHistoryList1 = this.ClearHistoryList;
      SCMenuItem scMenuItem4 = new SCMenuItem(this.StageData, "");
      scMenuItem4.OriginalPosition = new PointF((float) num24, (float) num25);
      scMenuItem4.DestPoint = new PointF((float) num24, (float) num25);
      scMenuItem4.Scale = 1f;
      scMenuItem4.OffX = 0;
      scMenuItem4.OffY = -5;
      scMenuItem4.TxtureObject = this.StageData.TextureObjectDictionary["History_游戏次数"];
      scMenuItem4.Description = all3[0].StartTimes.ToString().PadLeft(18, ' ');
      scMenuItem4.DefaultColor = Color.FromArgb(230, 230, (int) byte.MaxValue);
      SCMenuItem scMenuItem5 = scMenuItem4;
      clearHistoryList1.Add((BaseMenuItem) scMenuItem5);
      int num26 = num25 + 24;
      long playingTime = all3[0].PlayingTime;
      string str4 = ((int) (playingTime / 216000L)).ToString("d2") + ":" + ((int) (playingTime % 216000L / 3600L)).ToString("d2") + ":" + ((int) (playingTime % 3600L / 60L)).ToString("d2");
      List<BaseMenuItem> clearHistoryList2 = this.ClearHistoryList;
      SCMenuItem scMenuItem6 = new SCMenuItem(this.StageData, "");
      scMenuItem6.OriginalPosition = new PointF((float) num24, (float) num26);
      scMenuItem6.DestPoint = new PointF((float) num24, (float) num26);
      scMenuItem6.Scale = 1f;
      scMenuItem6.OffX = 0;
      scMenuItem6.OffY = -5;
      scMenuItem6.TxtureObject = this.StageData.TextureObjectDictionary["History_游戏时间"];
      scMenuItem6.Description = str4.PadLeft(18, ' ');
      scMenuItem6.DefaultColor = Color.FromArgb(230, 230, (int) byte.MaxValue);
      SCMenuItem scMenuItem7 = scMenuItem6;
      clearHistoryList2.Add((BaseMenuItem) scMenuItem7);
      int num27 = num26 + 24;
      List<BaseMenuItem> clearHistoryList3 = this.ClearHistoryList;
      SCMenuItem scMenuItem8 = new SCMenuItem(this.StageData, "");
      scMenuItem8.OriginalPosition = new PointF((float) num24, (float) num27);
      scMenuItem8.DestPoint = new PointF((float) num24, (float) num27);
      scMenuItem8.Scale = 1f;
      scMenuItem8.OffX = 0;
      scMenuItem8.OffY = -5;
      scMenuItem8.TxtureObject = this.StageData.TextureObjectDictionary["History_通关次数"];
      SCMenuItem scMenuItem9 = scMenuItem8;
      int num28 = all3[0].ClearTimes;
      string str5 = num28.ToString().PadLeft(18, ' ');
      scMenuItem9.Description = str5;
      scMenuItem8.DefaultColor = Color.FromArgb(230, 230, (int) byte.MaxValue);
      SCMenuItem scMenuItem10 = scMenuItem8;
      clearHistoryList3.Add((BaseMenuItem) scMenuItem10);
      int num29 = num27 + 24;
      List<BaseMenuItem> clearHistoryList4 = this.ClearHistoryList;
      SCMenuItem scMenuItem11 = new SCMenuItem(this.StageData, "");
      scMenuItem11.OriginalPosition = new PointF((float) num24, (float) num29);
      scMenuItem11.DestPoint = new PointF((float) num24, (float) num29);
      scMenuItem11.Scale = 1f;
      scMenuItem11.OffX = 0;
      scMenuItem11.OffY = -5;
      scMenuItem11.TxtureObject = this.StageData.TextureObjectDictionary["History_无续关通关次数"];
      SCMenuItem scMenuItem12 = scMenuItem11;
      num28 = all3[0].NoContinueClearTimes;
      string str6 = num28.ToString().PadLeft(18, ' ');
      scMenuItem12.Description = str6;
      scMenuItem11.DefaultColor = Color.FromArgb(230, 230, (int) byte.MaxValue);
      SCMenuItem scMenuItem13 = scMenuItem11;
      clearHistoryList4.Add((BaseMenuItem) scMenuItem13);
      int num30 = num29 + 24;
      int num31 = num24 - 70;
      List<BaseMenuItem> clearHistoryList5 = this.ClearHistoryList;
      BaseMenuItem baseMenuItem1 = new BaseMenuItem(this.StageData, "History_切换");
      baseMenuItem1.OriginalPosition = new PointF((float) num31, (float) num30);
      baseMenuItem1.DestPoint = new PointF((float) num31, (float) num30);
      baseMenuItem1.Scale = 1f;
      baseMenuItem1.Selected = true;
      BaseMenuItem baseMenuItem2 = baseMenuItem1;
      clearHistoryList5.Add(baseMenuItem2);
      List<BaseMenuItem> clearHistoryList6 = this.ClearHistoryList;
      BaseMenuItem baseMenuItem3 = new BaseMenuItem(this.StageData, "History_Arrow");
      baseMenuItem3.OriginalPosition = new PointF(70f, 95f);
      baseMenuItem3.DestPoint = new PointF(70f, 95f);
      baseMenuItem3.Selected = true;
      BaseMenuItem baseMenuItem4 = baseMenuItem3;
      clearHistoryList6.Add(baseMenuItem4);
      List<BaseMenuItem> clearHistoryList7 = this.ClearHistoryList;
      BaseMenuItem baseMenuItem5 = new BaseMenuItem(this.StageData, "History_Arrow");
      baseMenuItem5.OriginalPosition = new PointF(322f, 112f);
      baseMenuItem5.DestPoint = new PointF(322f, 112f);
      baseMenuItem5.Selected = true;
      baseMenuItem5.AngleDegree = 180.0;
      BaseMenuItem baseMenuItem6 = baseMenuItem5;
      clearHistoryList7.Add(baseMenuItem6);
      List<BaseMenuItem> clearHistoryList8 = this.ClearHistoryList;
      BaseMenuItem baseMenuItem7 = new BaseMenuItem(this.StageData, "History_Arrow");
      baseMenuItem7.OriginalPosition = new PointF(480f, 89f);
      baseMenuItem7.DestPoint = new PointF(480f, 89f);
      baseMenuItem7.Selected = true;
      baseMenuItem7.AngleDegree = 90.0;
      BaseMenuItem baseMenuItem8 = baseMenuItem7;
      clearHistoryList8.Add(baseMenuItem8);
      List<BaseMenuItem> clearHistoryList9 = this.ClearHistoryList;
      BaseMenuItem baseMenuItem9 = new BaseMenuItem(this.StageData, "History_Arrow");
      baseMenuItem9.OriginalPosition = new PointF(464f, 119f);
      baseMenuItem9.DestPoint = new PointF(464f, 119f);
      baseMenuItem9.Selected = true;
      baseMenuItem9.AngleDegree = -90.0;
      BaseMenuItem baseMenuItem10 = baseMenuItem9;
      clearHistoryList9.Add(baseMenuItem10);
    }

    public override void Show()
    {
      base.Show();
      this.MenuItemListPlane.ForEach((Action<BaseMenuItem>) (x => x.Show()));
      this.ScorePageList.ForEach((Action<DescriptionMenuItem>) (x => x.Show()));
      this.ClearHistoryList.ForEach((Action<BaseMenuItem>) (x => x.Show()));
    }

    public bool FindScore(ScoreHistory SH)
    {
      return SH.Rank.ToString() == this.MenuItemList[this.MenuSelectIndex].Name.Replace("History_", string.Empty) && SH.MyPlaneFullName == this.MenuItemListPlane[this.MenuPlaneSelectIndex].Name.Replace("History_", string.Empty);
    }

    public bool FindClear(ClearHistory CH)
    {
      return CH.Rank.ToString() == this.MenuItemList[this.MenuSelectIndex].Name.Replace("History_", string.Empty) && CH.MyPlaneFullName == this.MenuItemListPlane[this.MenuPlaneSelectIndex].Name.Replace("History_", string.Empty);
    }

    public bool FindSC(SpellCardHistory SCH)
    {
      return SCH.Rank.ToString() == this.MenuItemList[this.MenuSelectIndex].Name.Replace("History_", string.Empty) && SCH.MyPlaneFullName == this.MenuItemListPlane[this.MenuPlaneSelectIndex].Name.Replace("History_", string.Empty);
    }
  }
}
