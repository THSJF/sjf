// Decompiled with JetBrains decompiler
// Type: Shooting.BaseStage
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using Shooting.Properties;
using SlimDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Shooting
{
  internal class BaseStage : BaseGameState, IGameState
  {
    private IContainer components = (IContainer) null;
    protected int testStartTime = 0;
    private GameRegion GameRegion_Main;
    private GameRegion gameRegion_Score;
    private GameRegion gameRegion_Player;
    private GameRegion gameRegion_Spell;
    private GameRegion gameRegion_Power;
    private GameRegion gameRegion_LifeSelf;
    private GameRegion gameRegion_SpellLine;
    private GameRegion gameRegion_ScoreValue;
    private GameRegion gameRegion_BluePoint;
    private GameRegion gameRegion_GreenPoint;
    private GameRegion gameRegion_Graze;
    private GameRegion gameRegion_HiScoreValue;
    private GameRegion gameRegion1;
    private GameRegion gameRegion_HiScore;
    private string testString;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.gameRegion_ScoreValue = new GameRegion();
      this.gameRegion_SpellLine = new GameRegion();
      this.gameRegion_Power = new GameRegion();
      this.gameRegion_Spell = new GameRegion();
      this.gameRegion_Player = new GameRegion();
      this.gameRegion_Score = new GameRegion();
      this.gameRegion_LifeSelf = new GameRegion();
      this.GameRegion_Main = new GameRegion();
      this.gameRegion_BluePoint = new GameRegion();
      this.gameRegion_GreenPoint = new GameRegion();
      this.gameRegion_Graze = new GameRegion();
      this.gameRegion_HiScoreValue = new GameRegion();
      this.gameRegion1 = new GameRegion();
      this.gameRegion_HiScore = new GameRegion();
      this.SuspendLayout();
      this.gameRegion_ScoreValue.BackColor = Color.Transparent;
      this.gameRegion_ScoreValue.BackgroundImageLayout = ImageLayout.Zoom;
      this.gameRegion_ScoreValue.BorderStyle = BorderStyle.Fixed3D;
      this.gameRegion_ScoreValue.Location = new Point(488, 70);
      this.gameRegion_ScoreValue.Margin = new Padding(10, 1, 3, 1);
      this.gameRegion_ScoreValue.Name = "gameRegion_ScoreValue";
      this.gameRegion_ScoreValue.Size = new Size(110, 16);
      this.gameRegion_ScoreValue.TabIndex = 7;
      this.gameRegion_SpellLine.BackColor = Color.Transparent;
      this.gameRegion_SpellLine.BackgroundImage = (Image) Resources.FiveStar;
      this.gameRegion_SpellLine.BackgroundImageLayout = ImageLayout.Zoom;
      this.gameRegion_SpellLine.BorderStyle = BorderStyle.Fixed3D;
      this.gameRegion_SpellLine.Location = new Point(504, (int) sbyte.MaxValue);
      this.gameRegion_SpellLine.Margin = new Padding(10, 1, 3, 1);
      this.gameRegion_SpellLine.Name = "gameRegion_SpellLine";
      this.gameRegion_SpellLine.Size = new Size(110, 16);
      this.gameRegion_SpellLine.TabIndex = 6;
      this.gameRegion_Power.BackColor = Color.Transparent;
      this.gameRegion_Power.BackgroundImage = (Image) Resources.FiveStar;
      this.gameRegion_Power.BackgroundImageLayout = ImageLayout.None;
      this.gameRegion_Power.BorderStyle = BorderStyle.Fixed3D;
      this.gameRegion_Power.Location = new Point(442, 188);
      this.gameRegion_Power.Name = "gameRegion_Power";
      this.gameRegion_Power.Size = new Size(163, 25);
      this.gameRegion_Power.TabIndex = 5;
      this.gameRegion_Spell.BackColor = Color.Transparent;
      this.gameRegion_Spell.BackgroundImage = (Image) Resources.Spell;
      this.gameRegion_Spell.BackgroundImageLayout = ImageLayout.None;
      this.gameRegion_Spell.BorderStyle = BorderStyle.Fixed3D;
      this.gameRegion_Spell.Location = new Point(428, 125);
      this.gameRegion_Spell.Name = "gameRegion_Spell";
      this.gameRegion_Spell.Size = new Size(70, 16);
      this.gameRegion_Spell.TabIndex = 4;
      this.gameRegion_Player.BackColor = Color.Transparent;
      this.gameRegion_Player.BackgroundImage = (Image) Resources.Player;
      this.gameRegion_Player.BackgroundImageLayout = ImageLayout.None;
      this.gameRegion_Player.BorderStyle = BorderStyle.Fixed3D;
      this.gameRegion_Player.Location = new Point(428, 99);
      this.gameRegion_Player.Name = "gameRegion_Player";
      this.gameRegion_Player.Size = new Size(70, 16);
      this.gameRegion_Player.TabIndex = 3;
      this.gameRegion_Score.BackColor = Color.Transparent;
      this.gameRegion_Score.BackgroundImage = (Image) Resources.Score;
      this.gameRegion_Score.BackgroundImageLayout = ImageLayout.None;
      this.gameRegion_Score.BorderStyle = BorderStyle.Fixed3D;
      this.gameRegion_Score.Location = new Point(428, 67);
      this.gameRegion_Score.Name = "gameRegion_Score";
      this.gameRegion_Score.Size = new Size(70, 16);
      this.gameRegion_Score.TabIndex = 2;
      this.gameRegion_LifeSelf.BackColor = Color.Transparent;
      this.gameRegion_LifeSelf.BackgroundImage = (Image) Resources.MyPlane;
      this.gameRegion_LifeSelf.BackgroundImageLayout = ImageLayout.Zoom;
      this.gameRegion_LifeSelf.BorderStyle = BorderStyle.Fixed3D;
      this.gameRegion_LifeSelf.Location = new Point(504, 101);
      this.gameRegion_LifeSelf.Margin = new Padding(10, 1, 3, 1);
      this.gameRegion_LifeSelf.Name = "gameRegion_LifeSelf";
      this.gameRegion_LifeSelf.Size = new Size(110, 16);
      this.gameRegion_LifeSelf.TabIndex = 0;
      this.GameRegion_Main.Location = new Point(36, 16);
      this.GameRegion_Main.MaximumSize = new Size(384, 448);
      this.GameRegion_Main.MinimumSize = new Size(384, 448);
      this.GameRegion_Main.Name = "GameRegion_Main";
      this.GameRegion_Main.Size = new Size(384, 448);
      this.GameRegion_Main.TabIndex = 1;
      this.gameRegion_BluePoint.BackColor = Color.Transparent;
      this.gameRegion_BluePoint.BackgroundImage = (Image) Resources.FiveStar;
      this.gameRegion_BluePoint.BackgroundImageLayout = ImageLayout.None;
      this.gameRegion_BluePoint.BorderStyle = BorderStyle.Fixed3D;
      this.gameRegion_BluePoint.Location = new Point(442, 214);
      this.gameRegion_BluePoint.Name = "gameRegion_BluePoint";
      this.gameRegion_BluePoint.Size = new Size(163, 25);
      this.gameRegion_BluePoint.TabIndex = 9;
      this.gameRegion_GreenPoint.BackColor = Color.Transparent;
      this.gameRegion_GreenPoint.BackgroundImage = (Image) Resources.FiveStar;
      this.gameRegion_GreenPoint.BackgroundImageLayout = ImageLayout.None;
      this.gameRegion_GreenPoint.BorderStyle = BorderStyle.Fixed3D;
      this.gameRegion_GreenPoint.Location = new Point(442, 240);
      this.gameRegion_GreenPoint.Name = "gameRegion_GreenPoint";
      this.gameRegion_GreenPoint.Size = new Size(163, 25);
      this.gameRegion_GreenPoint.TabIndex = 10;
      this.gameRegion_Graze.BackColor = Color.Transparent;
      this.gameRegion_Graze.BackgroundImage = (Image) Resources.FiveStar;
      this.gameRegion_Graze.BackgroundImageLayout = ImageLayout.None;
      this.gameRegion_Graze.BorderStyle = BorderStyle.Fixed3D;
      this.gameRegion_Graze.Location = new Point(442, 266);
      this.gameRegion_Graze.Name = "gameRegion_Graze";
      this.gameRegion_Graze.Size = new Size(163, 25);
      this.gameRegion_Graze.TabIndex = 11;
      this.gameRegion_HiScoreValue.BackColor = Color.Transparent;
      this.gameRegion_HiScoreValue.BackgroundImageLayout = ImageLayout.Zoom;
      this.gameRegion_HiScoreValue.BorderStyle = BorderStyle.Fixed3D;
      this.gameRegion_HiScoreValue.Location = new Point(488, 47);
      this.gameRegion_HiScoreValue.Margin = new Padding(10, 1, 3, 1);
      this.gameRegion_HiScoreValue.Name = "gameRegion_HiScoreValue";
      this.gameRegion_HiScoreValue.Size = new Size(110, 16);
      this.gameRegion_HiScoreValue.TabIndex = 12;
      this.gameRegion1.BackColor = Color.Transparent;
      this.gameRegion1.BackgroundImageLayout = ImageLayout.Zoom;
      this.gameRegion1.Location = new Point(451, 48);
      this.gameRegion1.Margin = new Padding(10, 3, 3, 3);
      this.gameRegion1.Name = "gameRegion1";
      this.gameRegion1.Size = new Size(165, 20);
      this.gameRegion1.TabIndex = 12;
      this.gameRegion_HiScore.BackColor = Color.Transparent;
      this.gameRegion_HiScore.BackgroundImage = (Image) Resources.Score;
      this.gameRegion_HiScore.BackgroundImageLayout = ImageLayout.None;
      this.gameRegion_HiScore.BorderStyle = BorderStyle.Fixed3D;
      this.gameRegion_HiScore.Location = new Point(428, 44);
      this.gameRegion_HiScore.Name = "gameRegion_HiScore";
      this.gameRegion_HiScore.Size = new Size(70, 16);
      this.gameRegion_HiScore.TabIndex = 13;
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackgroundImage = (Image) Resources.background;
      this.Controls.Add((Control) this.gameRegion_Score);
      this.Controls.Add((Control) this.gameRegion_HiScore);
      this.Controls.Add((Control) this.gameRegion_HiScoreValue);
      this.Controls.Add((Control) this.gameRegion_Graze);
      this.Controls.Add((Control) this.gameRegion_GreenPoint);
      this.Controls.Add((Control) this.gameRegion_BluePoint);
      this.Controls.Add((Control) this.gameRegion_ScoreValue);
      this.Controls.Add((Control) this.gameRegion_SpellLine);
      this.Controls.Add((Control) this.gameRegion_Spell);
      this.Controls.Add((Control) this.gameRegion_Player);
      this.Controls.Add((Control) this.gameRegion_LifeSelf);
      this.Controls.Add((Control) this.GameRegion_Main);
      this.Controls.Add((Control) this.gameRegion_Power);
      this.Name = nameof (BaseStage);
      this.Size = new Size(640, 480);
      this.ResumeLayout(false);
    }

    private byte Slowflag { get; set; }

    protected bool RoadFlag { get; set; }

    public BaseStage(GlobalDataPackage GlobalData)
      : base(GlobalData)
    {
      this.InitializeComponent();
      this.DXFont = new SlimDX.Direct3D9.Font(this.DeviceMain, new System.Drawing.Font("Arial", 14f, FontStyle.Bold));
    }

    public override void Init()
    {
      this.BoundRect = new Rectangle(this.GameRegion_Main.Location, this.GameRegion_Main.Size);
      Point OriginalPosition1;
      ref Point local = ref OriginalPosition1;
      Rectangle boundRect1 = this.BoundRect;
      int x1 = boundRect1.Width / 2;
      boundRect1 = this.BoundRect;
      int y1 = boundRect1.Bottom - 50;
      local = new Point(x1, y1);
      if (this.MyPlane == null)
        this.MyPlane = (BaseMyPlane) new MyPlane_Aya(this.StageData, OriginalPosition1);
      this.Boss = (BaseBossTouhou) null;
      this.BulletList = new List<BaseBullet_Touhou>();
      this.EnemyPlaneList = new List<BaseEnemyPlane>();
      this.MyBulletList = new List<BaseObject>();
      this.SpellList = new List<BaseObject>();
      this.EffectList = new List<BaseEffect>();
      this.ItemList = new List<BaseItem>();
      List<BaseObject> baseObjectList1 = new List<BaseObject>();
      baseObjectList1.Add((BaseObject) new StarPointLineG(this.StageData, new PointF(66f, 404f)));
      baseObjectList1.Add((BaseObject) new StarPointLineB(this.StageData, new PointF(-6f, 404f)));
      baseObjectList1.Add((BaseObject) new StarPointLineR(this.StageData, new PointF(-6f, 404f)));
      baseObjectList1.Add((BaseObject) new BaseInterface(this.StageData, "TotalBackgroundHalf", (PointF) new Point(0, 0))
      {
        Delay = 0
      });
      baseObjectList1.Add((BaseObject) new BossLife_Line(this.StageData, "表示符卡数量的星星（单个）", new PointF((float) (this.BoundRect.Left + 65), (float) (this.BoundRect.Top + 22))));
      List<BaseObject> baseObjectList2 = baseObjectList1;
      StageDataPackage stageData1 = this.StageData;
      Rectangle boundRect2 = this.BoundRect;
      int left = boundRect2.Left;
      boundRect2 = this.BoundRect;
      int num = boundRect2.Width / 2;
      PointF OriginalPosition2 = new PointF((float) (left + num + 18), (float) (this.BoundRect.Top + 13));
      HP_Line hpLine = new HP_Line(stageData1, "HP_Line1", OriginalPosition2);
      baseObjectList2.Add((BaseObject) hpLine);
      baseObjectList1.Add((BaseObject) new SpellClock(this.StageData));
      List<BaseObject> baseObjectList3 = baseObjectList1;
      MyLife_Line myLifeLine1 = new MyLife_Line(this.StageData, this.MyPlane.TxtureObject, (PointF) this.gameRegion_LifeSelf.Location);
      myLifeLine1.Delay = 30;
      MyLife_Line myLifeLine2 = myLifeLine1;
      baseObjectList3.Add((BaseObject) myLifeLine2);
      List<BaseObject> baseObjectList4 = baseObjectList1;
      StageDataPackage stageData2 = this.StageData;
      Point location1 = this.gameRegion_LifeSelf.Location;
      int x2 = location1.X + 82;
      location1 = this.gameRegion_LifeSelf.Location;
      int y2 = location1.Y + 11;
      PointF OriginalPosition3 = (PointF) new Point(x2, y2);
      Item_Line_LifeChip itemLineLifeChip1 = new Item_Line_LifeChip(stageData2, OriginalPosition3);
      itemLineLifeChip1.Delay = 35;
      Item_Line_LifeChip itemLineLifeChip2 = itemLineLifeChip1;
      baseObjectList4.Add((BaseObject) itemLineLifeChip2);
      List<BaseObject> baseObjectList5 = baseObjectList1;
      MySpell_Line mySpellLine1 = new MySpell_Line(this.StageData, "Bomb", (PointF) this.gameRegion_SpellLine.Location);
      mySpellLine1.Delay = 40;
      MySpell_Line mySpellLine2 = mySpellLine1;
      baseObjectList5.Add((BaseObject) mySpellLine2);
      List<BaseObject> baseObjectList6 = baseObjectList1;
      StageDataPackage stageData3 = this.StageData;
      Point location2 = this.gameRegion_SpellLine.Location;
      int x3 = location2.X + 82;
      location2 = this.gameRegion_SpellLine.Location;
      int y3 = location2.Y + 11;
      PointF OriginalPosition4 = (PointF) new Point(x3, y3);
      Item_Line_SpellChip itemLineSpellChip1 = new Item_Line_SpellChip(stageData3, OriginalPosition4);
      itemLineSpellChip1.Delay = 45;
      Item_Line_SpellChip itemLineSpellChip2 = itemLineSpellChip1;
      baseObjectList6.Add((BaseObject) itemLineSpellChip2);
      baseObjectList1.Add((BaseObject) new BaseInterface(this.StageData, "最高得分", (PointF) this.gameRegion_HiScore.Location)
      {
        Delay = 10
      });
      baseObjectList1.Add((BaseObject) new BaseInterface(this.StageData, "InterfaceLine00", (PointF) new Point(this.gameRegion_HiScore.Location.X + 60, this.gameRegion_HiScore.Location.Y + 16))
      {
        Delay = 15
      });
      baseObjectList1.Add((BaseObject) new BaseInterface(this.StageData, "得分", (PointF) this.gameRegion_Score.Location)
      {
        Delay = 20
      });
      baseObjectList1.Add((BaseObject) new BaseInterface(this.StageData, "InterfaceLine01", (PointF) new Point(this.gameRegion_Score.Location.X + 60, this.gameRegion_Score.Location.Y + 16))
      {
        Delay = 25
      });
      baseObjectList1.Add((BaseObject) new BaseInterface(this.StageData, "剩余人数", (PointF) this.gameRegion_Player.Location)
      {
        Delay = 30
      });
      baseObjectList1.Add((BaseObject) new BaseInterface(this.StageData, "InterfaceLine02", (PointF) new Point(this.gameRegion_Player.Location.X + 60, this.gameRegion_Player.Location.Y + 22))
      {
        Delay = 35
      });
      baseObjectList1.Add((BaseObject) new BaseInterface(this.StageData, "SC", (PointF) this.gameRegion_Spell.Location)
      {
        Delay = 40
      });
      baseObjectList1.Add((BaseObject) new BaseInterface(this.StageData, "InterfaceLine03", (PointF) new Point(this.gameRegion_Spell.Location.X + 60, this.gameRegion_Spell.Location.Y + 22))
      {
        Delay = 45
      });
      baseObjectList1.Add((BaseObject) new BaseInterface(this.StageData, "灵力", (PointF) this.gameRegion_Power.Location)
      {
        Delay = 70
      });
      baseObjectList1.Add((BaseObject) new BaseInterface(this.StageData, "InterfaceLine04", (PointF) new Point(this.gameRegion_Spell.Location.X + 60, this.gameRegion_Power.Location.Y + 16))
      {
        Delay = 75
      });
      baseObjectList1.Add((BaseObject) new BaseInterface(this.StageData, "最大得点", (PointF) this.gameRegion_BluePoint.Location)
      {
        Delay = 80
      });
      baseObjectList1.Add((BaseObject) new BaseInterface(this.StageData, "InterfaceLine05", (PointF) new Point(this.gameRegion_Spell.Location.X + 60, this.gameRegion_BluePoint.Location.Y + 16))
      {
        Delay = 85
      });
      List<BaseObject> baseObjectList7 = baseObjectList1;
      StageDataPackage stageData4 = this.StageData;
      int x4 = this.gameRegion_Graze.Location.X;
      Point location3 = this.gameRegion_GreenPoint.Location;
      int y4 = location3.Y;
      PointF OriginalPosition5 = (PointF) new Point(x4, y4);
      BaseInterface baseInterface1 = new BaseInterface(stageData4, "擦弹", OriginalPosition5)
      {
        Delay = 90
      };
      baseObjectList7.Add((BaseObject) baseInterface1);
      List<BaseObject> baseObjectList8 = baseObjectList1;
      StageDataPackage stageData5 = this.StageData;
      location3 = this.gameRegion_HiScoreValue.Location;
      int x5 = location3.X - 20;
      location3 = this.gameRegion_HiScoreValue.Location;
      int y5 = location3.Y;
      PointF OriginalPosition6 = (PointF) new Point(x5, y5);
      Item_Line_HiScore itemLineHiScore1 = new Item_Line_HiScore(stageData5, OriginalPosition6);
      itemLineHiScore1.Delay = 10;
      Item_Line_HiScore itemLineHiScore2 = itemLineHiScore1;
      baseObjectList8.Add((BaseObject) itemLineHiScore2);
      List<BaseObject> baseObjectList9 = baseObjectList1;
      StageDataPackage stageData6 = this.StageData;
      location3 = this.gameRegion_ScoreValue.Location;
      int x6 = location3.X - 20;
      location3 = this.gameRegion_ScoreValue.Location;
      int y6 = location3.Y;
      PointF OriginalPosition7 = (PointF) new Point(x6, y6);
      Item_Line_Score itemLineScore1 = new Item_Line_Score(stageData6, OriginalPosition7);
      itemLineScore1.Delay = 20;
      Item_Line_Score itemLineScore2 = itemLineScore1;
      baseObjectList9.Add((BaseObject) itemLineScore2);
      List<BaseObject> baseObjectList10 = baseObjectList1;
      StageDataPackage stageData7 = this.StageData;
      location3 = this.gameRegion_Power.Location;
      int x7 = location3.X + 50;
      location3 = this.gameRegion_Power.Location;
      int y7 = location3.Y;
      PointF OriginalPosition8 = (PointF) new Point(x7, y7);
      Item_Line_Red itemLineRed1 = new Item_Line_Red(stageData7, OriginalPosition8);
      itemLineRed1.Delay = 70;
      Item_Line_Red itemLineRed2 = itemLineRed1;
      baseObjectList10.Add((BaseObject) itemLineRed2);
      List<BaseObject> baseObjectList11 = baseObjectList1;
      StageDataPackage stageData8 = this.StageData;
      location3 = this.gameRegion_BluePoint.Location;
      int x8 = location3.X + 50;
      location3 = this.gameRegion_BluePoint.Location;
      int y8 = location3.Y;
      PointF OriginalPosition9 = (PointF) new Point(x8, y8);
      Item_Line_Blue itemLineBlue1 = new Item_Line_Blue(stageData8, OriginalPosition9);
      itemLineBlue1.Delay = 80;
      Item_Line_Blue itemLineBlue2 = itemLineBlue1;
      baseObjectList11.Add((BaseObject) itemLineBlue2);
      List<BaseObject> baseObjectList12 = baseObjectList1;
      StageDataPackage stageData9 = this.StageData;
      location3 = this.gameRegion_Graze.Location;
      int x9 = location3.X + 50;
      location3 = this.gameRegion_GreenPoint.Location;
      int y9 = location3.Y;
      PointF OriginalPosition10 = (PointF) new Point(x9, y9);
      Item_Line_Gray itemLineGray1 = new Item_Line_Gray(stageData9, OriginalPosition10);
      itemLineGray1.Delay = 90;
      Item_Line_Gray itemLineGray2 = itemLineGray1;
      baseObjectList12.Add((BaseObject) itemLineGray2);
      baseObjectList1.Add((BaseObject) new BossMark(this.StageData));
      List<BaseObject> baseObjectList13 = baseObjectList1;
      InterfaceDifficulty interfaceDifficulty1 = new InterfaceDifficulty(this.StageData, new PointF((float) ((this.BoundRect.Right + 640) / 2), 24f));
      interfaceDifficulty1.Delay = 110;
      InterfaceDifficulty interfaceDifficulty2 = interfaceDifficulty1;
      baseObjectList13.Add((BaseObject) interfaceDifficulty2);
      this.InterfaceList = baseObjectList1;
      if (this.StageData.Difficulty > DifficultLevel.Normal)
      {
        List<BaseObject> interfaceList1 = this.InterfaceList;
        StageDataPackage stageData10 = this.StageData;
        location3 = this.gameRegion_Spell.Location;
        int x10 = location3.X;
        location3 = this.gameRegion_Spell.Location;
        int y10 = location3.Y + 26;
        PointF OriginalPosition11 = (PointF) new Point(x10, y10);
        BaseInterface baseInterface2 = new BaseInterface(stageData10, "BD", OriginalPosition11)
        {
          Delay = 50
        };
        interfaceList1.Add((BaseObject) baseInterface2);
        List<BaseObject> interfaceList2 = this.InterfaceList;
        StageDataPackage stageData11 = this.StageData;
        location3 = this.gameRegion_SpellLine.Location;
        int x11 = location3.X;
        location3 = this.gameRegion_SpellLine.Location;
        int y11 = location3.Y + 26;
        PointF OriginalPosition12 = (PointF) new Point(x11, y11);
        MyBorder_Line myBorderLine1 = new MyBorder_Line(stageData11, "Border", OriginalPosition12);
        myBorderLine1.Delay = 50;
        MyBorder_Line myBorderLine2 = myBorderLine1;
        interfaceList2.Add((BaseObject) myBorderLine2);
      }
      this.SoundPlayList = new List<XAudio2_Player>();
      this.Background = new BackgroundManager();
      this.Background3D = new BackgroundManager3D(this.StageData);
      this.Particle3D = new ParticleManager3D(this.StageData);
      this.TimeMain = 0;
      this.StageData.Ran = new MyRandom(0);
      this.StageData.C_History = this.StageData.PData.C_History.Find(new Predicate<ClearHistory>(this.StageData.FindClear));
      this.StageData.S_History = this.StageData.PData.S_History.FindAll(new Predicate<ScoreHistory>(this.StageData.FindScore));
      if (!this.StageData.OnReplay)
        ++this.StageData.C_History.StartTimes;
      this.MyPlane.HiScore = this.StageData.S_History[0].Score;
    }

    public override void UpdateData()
    {
      if (this.StageData.OnReplay && this.KClass.Key_minus)
      {
        ++this.Slowflag;
        if (this.Slowflag < (byte) 4)
          return;
        this.Slowflag = (byte) 0;
      }
      base.UpdateData();
      if (this.StageData.SlowMode > 0)
      {
        --this.StageData.SlowMode;
        if (this.TimeMain % 2 == 0)
          return;
      }
      if (this.KClass.Key_ESC)
      {
        this.StateSwitchData = new StateSwitchDataPackage()
        {
          NextState = "PauseMenu",
          NeedInit = true,
          SDPswitch = new StageDataPackage(this.GlobalData)
        };
        this.GlobalData.LastState = (IGameState) this;
        this.StageData.SoundPlay("se_pause.wav");
      }
      if (this.StageData.Rep != null)
      {
        if (this.StageData.OnReplay)
        {
          int keyValue = this.StageData.Rep.ReadKey();
          if (keyValue == 57358)
            keyValue = this.StageData.Rep.ReadKey();
          if (keyValue == 4080)
          {
            this.StateSwitchData = new StateSwitchDataPackage()
            {
              NextState = "GameOverMenu",
              NeedInit = true,
              SDPswitch = new StageDataPackage(this.GlobalData)
            };
            this.GlobalData.LastState = (IGameState) this;
            this.StageData.KClass.Hex2Key(0);
            this.StageData.SoundPlay("se_pause.wav");
          }
          else
            this.StageData.KClass.Hex2Key(keyValue);
        }
        else
          this.StageData.Rep.WriteKey(this.StageData.KClass.Key2Hex());
      }
      this.Background3D.Ctrl();
      this.Background.Ctrl();
      this.Background2.Ctrl();
      this.Drama();
      if (this.Story != null)
        this.Story.Ctrl();
      for (int index = this.MyBulletList.Count - 1; index >= 0; --index)
        this.MyBulletList[index].Ctrl();
      this.MyPlane.Ctrl();
      for (int index = this.SpellList.Count - 1; index >= 0; --index)
        this.SpellList[index].Ctrl();
      for (int index = this.EnemyPlaneList.Count - 1; index >= 0; --index)
        this.EnemyPlaneList[index].Ctrl();
      for (int index = this.BulletList.Count - 1; index >= 0; --index)
        this.BulletList[index].Ctrl();
      if (this.Boss != null)
        this.Boss.Ctrl();
      for (int index = this.EffectList.Count - 1; index >= 0; --index)
        this.EffectList[index].Ctrl();
      this.Particle3D.Ctrl();
      for (int index = this.ItemList.Count - 1; index >= 0; --index)
        this.ItemList[index].Ctrl();
      this.StageData.Vibrate();
      this.HitCheckAllinOne();
      for (int index = this.InterfaceList.Count - 1; index >= 0; --index)
        this.InterfaceList[index].Ctrl();
      this.SoundPlayList.ForEach((Action<XAudio2_Player>) (x => x.Play()));
      if (this.StageData.OnReplay && (this.TimeMain % 6 != 0 && this.KClass.Key_plus && this.MyPlane.Life >= 0 && this.StateSwitchData == null))
        this.UpdateData();
      this.GlobalData.LastState = (IGameState) this;
    }

    public virtual void HitCheckAllinOne()
    {
      if (this.MyPlane.Life < 0)
        this.StateSwitchData = new StateSwitchDataPackage()
        {
          NextState = "GameOverMenu",
          NeedInit = true,
          SDPswitch = new StageDataPackage(this.GlobalData)
        };
      this.ItemList.ForEach((Action<BaseItem>) (x => x.HitCheckAll()));
      if (this.Story != null)
        return;
      this.EnemyPlaneList.ForEach((Action<BaseEnemyPlane>) (x => x.HitCheckAll()));
      this.BulletList.ForEach((Action<BaseBullet_Touhou>) (x => x.HitCheckAll()));
      if (this.Boss != null)
        this.Boss.HitCheckAll();
      this.SpellList.ForEach((Action<BaseObject>) (x => x.HitCheckAll()));
    }

    public virtual void ShowInterface()
    {
      if (this.MyPlane != null)
        this.MyPlane.ShowCenter();
      this.SpriteMain.Draw2D(this.TextureObjectDictionary["TotalBackground"], 1f, 0.0f, new PointF(320f, 240f), (int) byte.MaxValue);
      this.DrawText(this.FPS.ToString("F1"), new Point(580, 460));
    }

    public virtual void Drama()
    {
      if (!this.StageData.OnReplay)
        ++this.StageData.C_History.PlayingTime;
      if (this.TimeMain != 1)
        return;
      if (this.StageData.StateSwitchData == null)
        this.StateSwitchData = new StateSwitchDataPackage()
        {
          NextState = "MusicLoading",
          NeedInit = true,
          SDPswitch = new StageDataPackage(this.GlobalData)
        };
      this.GlobalData.LastState = (IGameState) this;
      this.StageData.CurrentStageName = this.StageName;
      this.RoadFlag = false;
      this.EffectList.Clear();
      this.MyPlane.Refresh();
      this.Ran = new MyRandom(0);
    }

    public override void Render()
    {
      this.GlobalData.ScreenTexMan.Begin();
      this.Background3D.Show();
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      this.DeviceMain.SetRenderState(RenderState.SourceBlend, 5);
      this.DeviceMain.SetRenderState(RenderState.DestinationBlend, 2);
      this.Background2.Show(true);
      this.SpriteMain.End();
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      TextureObject textureObject = this.TextureObjectDictionary["White"];
      switch (this.MyPlane.EnchantmentState)
      {
        case EnchantmentType.Red:
          MySprite spriteMain1 = this.SpriteMain;
          TextureObject txtureObject1 = textureObject;
          Rectangle boundRect1 = this.BoundRect;
          int left1 = boundRect1.Left;
          boundRect1 = this.BoundRect;
          int right1 = boundRect1.Right;
          double num1 = (double) ((left1 + right1) / 2);
          boundRect1 = this.BoundRect;
          int top1 = boundRect1.Top;
          boundRect1 = this.BoundRect;
          int height1 = boundRect1.Height;
          double num2 = (double) ((top1 + height1) / 2);
          PointF position1 = new PointF((float) num1, (float) num2);
          Color color1 = Color.FromArgb(180, 30, 0, 0);
          spriteMain1.Draw2D(txtureObject1, 100f, 0.0f, position1, color1);
          break;
        case EnchantmentType.Blue:
          MySprite spriteMain2 = this.SpriteMain;
          TextureObject txtureObject2 = textureObject;
          Rectangle boundRect2 = this.BoundRect;
          int left2 = boundRect2.Left;
          boundRect2 = this.BoundRect;
          int right2 = boundRect2.Right;
          double num3 = (double) ((left2 + right2) / 2);
          boundRect2 = this.BoundRect;
          int top2 = boundRect2.Top;
          boundRect2 = this.BoundRect;
          int height2 = boundRect2.Height;
          double num4 = (double) ((top2 + height2) / 2);
          PointF position2 = new PointF((float) num3, (float) num4);
          Color color2 = Color.FromArgb(180, 0, 0, 30);
          spriteMain2.Draw2D(txtureObject2, 100f, 0.0f, position2, color2);
          break;
        case EnchantmentType.Green:
          MySprite spriteMain3 = this.SpriteMain;
          TextureObject txtureObject3 = textureObject;
          Rectangle boundRect3 = this.BoundRect;
          int left3 = boundRect3.Left;
          boundRect3 = this.BoundRect;
          int right3 = boundRect3.Right;
          double num5 = (double) ((left3 + right3) / 2);
          boundRect3 = this.BoundRect;
          int top3 = boundRect3.Top;
          boundRect3 = this.BoundRect;
          int height3 = boundRect3.Height;
          double num6 = (double) ((top3 + height3) / 2);
          PointF position3 = new PointF((float) num5, (float) num6);
          Color color3 = Color.FromArgb(180, 0, 30, 0);
          spriteMain3.Draw2D(txtureObject3, 100f, 0.0f, position3, color3);
          break;
      }
      this.Background2.Show(false);
      if (this.Boss != null)
        this.Boss.Show();
      this.MyBulletList.ForEach((Action<BaseObject>) (x => x.Show()));
      this.MyPlane.Show();
      this.EnemyPlaneList.ForEach((Action<BaseEnemyPlane>) (x => x.Show()));
      this.ItemList.ForEach((Action<BaseItem>) (x =>
      {
        if (x.Active)
          return;
        x.Show();
      }));
      this.SpriteMain.End();
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      this.DeviceMain.SetRenderState(RenderState.SourceBlend, 5);
      this.DeviceMain.SetRenderState(RenderState.DestinationBlend, 2);
      this.BulletList.ForEach((Action<BaseBullet_Touhou>) (x =>
      {
        if (!x.Active)
          return;
        x.Show();
      }));
      this.EffectList.ForEach((Action<BaseEffect>) (x =>
      {
        if (!x.Active)
          return;
        x.Show();
      }));
      this.SpellList.ForEach((Action<BaseObject>) (x => x.Show()));
      this.ItemList.ForEach((Action<BaseItem>) (x =>
      {
        if (!x.Active)
          return;
        x.Show();
      }));
      this.SpriteMain.End();
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      this.BulletList.ForEach((Action<BaseBullet_Touhou>) (x =>
      {
        if (x.Active || x.Layer >= 0)
          return;
        x.Show();
      }));
      this.BulletList.ForEach((Action<BaseBullet_Touhou>) (x =>
      {
        if (x.Active || x.Layer != 0)
          return;
        x.Show();
      }));
      this.BulletList.ForEach((Action<BaseBullet_Touhou>) (x =>
      {
        if (x.Active || x.Layer <= 0)
          return;
        x.Show();
      }));
      this.EffectList.ForEach((Action<BaseEffect>) (x =>
      {
        if (x.Active || x.Layer >= 0)
          return;
        x.Show();
      }));
      this.EffectList.ForEach((Action<BaseEffect>) (x =>
      {
        if (x.Active || x.Layer != 0)
          return;
        x.Show();
      }));
      this.EffectList.ForEach((Action<BaseEffect>) (x =>
      {
        if (x.Active || x.Layer <= 0)
          return;
        x.Show();
      }));
      this.SpriteMain.End();
      this.Particle3D.Show();
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      if (this.Story != null)
        this.Story.Show();
      this.ShowInterface();
      this.InterfaceList.ForEach((Action<BaseObject>) (x => x.Show()));
      this.SpriteMain.End();
      this.GlobalData.ScreenTexMan.End();
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      this.GlobalData.EffectMain = this.GlobalData.EffectDictionary["Filter"];
      this.GlobalData.EffectMain.Technique = (EffectHandle) "technique1";
      this.GlobalData.EffectMain.Begin();
      this.GlobalData.EffectMain.BeginPass(0);
      this.GlobalData.SpriteMain.Draw2D(this.GlobalData.ScreenTexMan.RenderTexture, (PointF) new Point(0, 0), 0.0f, new PointF(0.0f, 0.0f), Color.White);
      this.SpriteMain.End();
      this.GlobalData.EffectMain.EndPass();
      this.GlobalData.EffectMain.End();
    }
  }
}
