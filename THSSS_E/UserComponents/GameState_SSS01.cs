// Decompiled with JetBrains decompiler
// Type: Shooting.GameState_SSS01
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using Shooting.Planes.Story;
using System;
using System.Drawing;
using System.IO;

namespace Shooting
{
  internal class GameState_SSS01 : BaseStage, IGameState
  {
    public GameState_SSS01(GlobalDataPackage GlobalData)
      : base(GlobalData)
    {
      this.StageName = "St1";
    }

    public override void Drama()
    {
      base.Drama();
      int[] numArray = new int[3]{ 3180, 4000, 6440 };
      if (this.TimeMain == 1)
      {
        switch (this.StageData.Difficulty)
        {
          case DifficultLevel.Hard:
            this.MyPlane.EnchantmentCountNeeded = 3;
            break;
          case DifficultLevel.Lunatic:
            this.MyPlane.EnchantmentCountNeeded = 4;
            break;
        }
        TransitionIn transitionIn = new TransitionIn(this.StageData);
      }
      Rectangle boundRect;
      if (this.TimeMain == 2)
      {
        if (this.StageData.C_History.PracticeLevel < 1)
          this.StageData.C_History.PracticeLevel = 1;
        this.StageData.ChangeBGM(".\\BGM\\Stage01.wav", (this.testStartTime + 60) * 44100 / 60, 0, 0, 0, 0);
        StageDataPackage stageData1 = this.StageData;
        boundRect = this.BoundRect;
        int width1 = boundRect.Width;
        boundRect = this.BoundRect;
        int y = boundRect.Height - 16;
        Point DestPoint = new Point(width1, y);
        MusicTitle musicTitle1 = new MusicTitle(stageData1, "宁静夏夜的微风", DestPoint);
        MusicTitle musicTitle2 = musicTitle1;
        boundRect = this.BoundRect;
        double width2 = (double) boundRect.Width;
        boundRect = this.BoundRect;
        double num1 = (double) (boundRect.Height + 100);
        PointF pointF = new PointF((float) width2, (float) num1);
        musicTitle2.OriginalPosition = pointF;
        musicTitle1.Scale = 0.5f;
        this.Background3D.Envi = (IEnvironment) new EnvironmentSSS01(this.StageData);
        new BackgroundTransitionIn(this.StageData)
        {
          Delay = 200
        }.LifeTime = 320;
        BackgroundGroupSSS01 backgroundGroupSsS01 = new BackgroundGroupSSS01(this.StageData);
        if (this.testStartTime > this.TimeMain)
          this.TimeMain = this.testStartTime;
        if (this.TimeMain < numArray[0])
        {
          string[] files;
          switch (this.StageData.Difficulty)
          {
            case DifficultLevel.Easy:
              files = Directory.GetFiles(".\\CS\\St01\\A\\E\\", "*.mbg");
              break;
            case DifficultLevel.Normal:
              files = Directory.GetFiles(".\\CS\\St01\\A\\N\\", "*.mbg");
              break;
            case DifficultLevel.Hard:
              files = Directory.GetFiles(".\\CS\\St01\\A\\H\\", "*.mbg");
              break;
            case DifficultLevel.Lunatic:
              files = Directory.GetFiles(".\\CS\\St01\\A\\L\\", "*.mbg");
              break;
            default:
              files = Directory.GetFiles(".\\CS\\St01\\A\\L\\", "*.mbg");
              break;
          }
          foreach (string FileName in files)
            new CSEmitterController(this.StageData, this.StageData.LoadCS(FileName))
            {
              OnRoad = true
            }.Time = this.TimeMain + 60;
        }
        StageDataPackage stageData2 = this.StageData;
        string textureName = this.StageData.Difficulty.ToString();
        boundRect = this.BoundRect;
        int x = boundRect.X;
        boundRect = this.BoundRect;
        int num2 = boundRect.Width / 2;
        double num3 = (double) (x + num2);
        boundRect = this.BoundRect;
        double num4 = (double) (boundRect.Y + 16);
        PointF Position = new PointF((float) num3, (float) num4);
        new TextTwinkle(stageData2, textureName, Position, 0.0f, Math.PI / 2.0)
        {
          TwinkleColor = Color.Gray,
          Circle = 10
        }.LifeTime = 150;
      }
      else if (this.TimeMain == 30)
      {
        new TextTwinkle(this.StageData, "ItemGetBorderLine", new PointF((float) (this.BoundRect.X + this.BoundRect.Width / 2), (float) (this.BoundRect.Y + 130)), 0.0f, Math.PI / 2.0).TwinkleColor = Color.OrangeRed;
        new TextTwinkle(this.StageData, "ItemGetBorderLine01", new PointF((float) (this.BoundRect.X + this.BoundRect.Width / 2 - 168), (float) (this.BoundRect.Y + 130)), 0.0f, Math.PI / 2.0).TwinkleColor = Color.OrangeRed;
        new TextTwinkle(this.StageData, "ItemGetBorderLine01", new PointF((float) (this.BoundRect.X + this.BoundRect.Width / 2 + 158), (float) (this.BoundRect.Y + 130)), 0.0f, Math.PI / 2.0).TwinkleColor = Color.OrangeRed;
      }
      if (this.TimeMain == numArray[0])
      {
        this.StageData.RemoveBullets();
        Boss_Ami01 bossAmi01 = new Boss_Ami01(this.StageData);
        EmitterBossFire emitterBossFire = new EmitterBossFire(this.StageData, this.Boss.OriginalPosition, Color.FromArgb(40, (int) byte.MaxValue, 20));
        new MagicCircle(this.StageData, "MagicCircleSix").Scale = 1.5f;
        this.Background3D.WarpEnabled = true;
        this.Background3D.WarpColorKey = 0;
      }
      else if (this.TimeMain > numArray[1] && this.Boss == null && !this.RoadFlag)
      {
        this.RoadFlag = true;
        string[] files;
        switch (this.StageData.Difficulty)
        {
          case DifficultLevel.Easy:
            files = Directory.GetFiles(".\\CS\\St01\\B\\E\\", "*.mbg");
            break;
          case DifficultLevel.Normal:
            files = Directory.GetFiles(".\\CS\\St01\\B\\N\\", "*.mbg");
            break;
          case DifficultLevel.Hard:
            files = Directory.GetFiles(".\\CS\\St01\\B\\H\\", "*.mbg");
            break;
          case DifficultLevel.Lunatic:
            files = Directory.GetFiles(".\\CS\\St01\\B\\L\\", "*.mbg");
            break;
          default:
            files = Directory.GetFiles(".\\CS\\St01\\B\\L\\", "*.mbg");
            break;
        }
        foreach (string FileName in files)
        {
          CS_Data CSData = new CS_Data(FileName);
          CSData.String2Data(this.StageData);
          new CSEmitterController(this.StageData, CSData)
          {
            OnRoad = true
          }.Time = this.TimeMain + 60;
        }
      }
      else if (numArray[2] - 130 == this.TimeMain)
      {
        StageDataPackage stageData = this.StageData;
        boundRect = this.BoundRect;
        PointF OriginalPosition = new PointF((float) (boundRect.Width / 2), 150f);
        new BossStar(stageData, OriginalPosition).ColorType = 6;
      }
      else
      {
        if (numArray[2] != this.TimeMain)
          return;
        this.StageData.RemoveBullets();
        Boss_Ami02 bossAmi02 = new Boss_Ami02(this.StageData);
        switch (this.MyPlane.Name)
        {
          case "Aya":
            Story_SSS01_01 storySsS0101 = new Story_SSS01_01(this.StageData);
            break;
          case "Reimu":
            Story_SSS01_01A storySsS0101A = new Story_SSS01_01A(this.StageData);
            break;
          case "Marisa":
            Story_SSS01_01B storySsS0101B = new Story_SSS01_01B(this.StageData);
            break;
          case "Sanae":
            Story_SSS01_01C storySsS0101C = new Story_SSS01_01C(this.StageData);
            break;
          case "Koishi":
            Story_SSS01_01D storySsS0101D = new Story_SSS01_01D(this.StageData);
            break;
          default:
            Story_SSS01_01X storySsS0101X = new Story_SSS01_01X(this.StageData);
            break;
        }
        this.Background3D.WarpEnabled = false;
        this.Background3D.WarpColorKey = 0;
      }
    }

    public override void BGM_ON()
    {
    }
  }
}
