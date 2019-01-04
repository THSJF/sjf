// Decompiled with JetBrains decompiler
// Type: Shooting.MenuOption
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  internal class MenuOption : BaseMenuGroup
  {
    private BaseNum BGMvolumn;
    private BaseNum SEvolumn;

    public MenuOption(StageDataPackage StageData)
      : base(StageData)
    {
      this.MenuSelectIndex = 0;
      this.MenuItemList = new List<BaseMenuItem>()
      {
        new BaseMenuItem(StageData, "Menu_BGM_Vol"),
        new BaseMenuItem(StageData, "Menu_SE_Vol"),
        new BaseMenuItem(StageData, "Menu_Quit")
      };
      int num1 = 220;
      int num2 = 220;
      int num3 = -200;
      foreach (BaseMenuItem menuItem in this.MenuItemList)
      {
        menuItem.DestPoint = new PointF((float) num1, (float) num2);
        menuItem.Position = new PointF((float) (num1 + num3), 140f);
        num2 += 24;
        num3 -= 50;
      }
      StageDataPackage StageData1 = StageData;
      PointF destPoint = this.MenuItemList[0].DestPoint;
      double num4 = (double) destPoint.X + 130.0;
      destPoint = this.MenuItemList[0].DestPoint;
      double num5 = (double) destPoint.Y + 16.0;
      PointF Position = new PointF((float) num4, (float) num5);
      this.BGMvolumn = new BaseNum(StageData1, Position)
      {
        Num = this.BGM_Player.Volume,
        Count = 3
      };
      this.SEvolumn = new BaseNum(StageData, new PointF(this.MenuItemList[1].DestPoint.X + 130f, this.MenuItemList[1].DestPoint.Y + 16f))
      {
        Num = StageData.GlobalData.SEVolume,
        Count = 3
      };
      this.MenuItemList[this.MenuSelectIndex].Selected = true;
    }

    public override void ProcessKeys()
    {
      base.ProcessKeys();
      if (this.KClass.Key_Z && this.LastZ == 0)
      {
        switch (this.MenuItemList[this.MenuSelectIndex].Name)
        {
          case "Menu_Quit":
            this.OnRemoveMenu = this.TimeMain + 20;
            this.TransparentVelocity = -15f;
            using (List<BaseMenuItem>.Enumerator enumerator = this.MenuItemList.GetEnumerator())
            {
              while (enumerator.MoveNext())
              {
                BaseMenuItem current = enumerator.Current;
                current.DestPoint = new PointF(60f, 160f);
                current.OnRemove = true;
              }
              goto case "Menu_BGM_Vol";
            }
          case "Menu_BGM_Vol":
          case "Menu_SE_Vol":
            this.StageData.SoundPlay("se_ok00.wav");
            break;
          default:
            this.StageData.StateSwitchData = new StateSwitchDataPackage()
            {
              NextState = "此功能尚未开通",
              NeedInit = true,
              SDPswitch = this.StageData
            };
            goto case "Menu_BGM_Vol";
        }
      }
      if ((this.KClass.Key_X || this.KClass.Key_ESC) && this.LastX == 0)
      {
        this.MenuSelectIndex = this.MenuItemList.Count - 1;
        this.SelectItemChanged();
        this.StageData.SoundPlay("se_cancel00.wav");
      }
      if (this.KClass.ArrowRight && (this.LastRight == 0 || this.LastRight > 30))
      {
        switch (this.MenuItemList[this.MenuSelectIndex].Name)
        {
          case "Menu_BGM_Vol":
            this.BGM_Player.Volume += 5;
            this.BGMvolumn.Num = this.BGM_Player.Volume;
            break;
          case "Menu_SE_Vol":
            foreach (XAudio2_Player xaudio2Player in this.StageData.SoundDictionary.Values)
            {
              xaudio2Player.Volume += 5;
              this.SEvolumn.Num = xaudio2Player.Volume;
            }
            this.StageData.SoundPlay("se_ok00.wav");
            break;
        }
        this.LastSelectTime = this.TimeMain;
        this.StageData.GlobalData.BGMVolume = this.BGM_Player.Volume;
        this.StageData.GlobalData.SEVolume = this.SEvolumn.Num;
      }
      if (!this.KClass.ArrowLeft || this.LastLeft != 0 && this.LastLeft <= 30)
        return;
      switch (this.MenuItemList[this.MenuSelectIndex].Name)
      {
        case "Menu_BGM_Vol":
          this.BGM_Player.Volume -= 5;
          this.BGMvolumn.Num = this.BGM_Player.Volume;
          break;
        case "Menu_SE_Vol":
          foreach (XAudio2_Player xaudio2Player in this.StageData.SoundDictionary.Values)
          {
            xaudio2Player.Volume -= 5;
            this.SEvolumn.Num = xaudio2Player.Volume;
          }
          this.StageData.SoundPlay("se_ok00.wav");
          break;
      }
      this.LastSelectTime = this.TimeMain;
      this.StageData.GlobalData.BGMVolume = this.BGM_Player.Volume;
      this.StageData.GlobalData.SEVolume = this.SEvolumn.Num;
    }

    public override void Show()
    {
      base.Show();
      this.BGMvolumn.Show();
      this.SEvolumn.Show();
    }
  }
}
