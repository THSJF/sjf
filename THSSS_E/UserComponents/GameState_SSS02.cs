// Decompiled with JetBrains decompiler
// Type: Shooting.GameState_SSS02
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using Shooting.Planes.Story;
using System.Drawing;
using System.IO;

namespace Shooting
{
  internal class GameState_SSS02 : BaseStage, IGameState
  {
    public GameState_SSS02(GlobalDataPackage GlobalData)
      : base(GlobalData)
    {
      this.StageName = "St2";
    }

    public override void Drama()
    {
      base.Drama();
      int[] numArray = new int[3]{ 4680, 5000, 7890 };
      if (this.TimeMain == 1)
      {
        switch (this.StageData.Difficulty)
        {
          case DifficultLevel.Hard:
            this.MyPlane.EnchantmentCountNeeded = 5;
            break;
          case DifficultLevel.Lunatic:
            this.MyPlane.EnchantmentCountNeeded = 6;
            break;
        }
      }
      Rectangle boundRect;
      if (this.TimeMain == 2)
      {
        if (this.StageData.C_History.PracticeLevel < 2)
          this.StageData.C_History.PracticeLevel = 2;
        this.StageData.ChangeBGM(".\\BGM\\Stage02.wav", (this.testStartTime + 60) * 44100 / 60, 0, (int) byte.MaxValue, 1194228, 6866370);
        StageDataPackage stageData = this.StageData;
        boundRect = this.BoundRect;
        int width1 = boundRect.Width;
        boundRect = this.BoundRect;
        int y = boundRect.Height - 16;
        Point DestPoint = new Point(width1, y);
        MusicTitle musicTitle1 = new MusicTitle(stageData, "灯火竹林", DestPoint);
        MusicTitle musicTitle2 = musicTitle1;
        boundRect = this.BoundRect;
        double width2 = (double) boundRect.Width;
        boundRect = this.BoundRect;
        double num = (double) (boundRect.Height + 100);
        PointF pointF = new PointF((float) width2, (float) num);
        musicTitle2.OriginalPosition = pointF;
        musicTitle1.Scale = 0.5f;
        this.Background3D.Envi = (IEnvironment) new EnvironmentSSS02(this.StageData);
        new BackgroundTransitionIn(this.StageData)
        {
          Delay = 200
        }.LifeTime = 320;
        if (this.testStartTime > this.TimeMain)
          this.TimeMain = this.testStartTime;
        if (this.TimeMain < numArray[0])
        {
          string[] files;
          switch (this.StageData.Difficulty)
          {
            case DifficultLevel.Easy:
              files = Directory.GetFiles(".\\CS\\St02\\A\\E\\", "*.mbg");
              break;
            case DifficultLevel.Normal:
              files = Directory.GetFiles(".\\CS\\St02\\A\\N\\", "*.mbg");
              break;
            case DifficultLevel.Hard:
              files = Directory.GetFiles(".\\CS\\St02\\A\\H\\", "*.mbg");
              break;
            case DifficultLevel.Lunatic:
              files = Directory.GetFiles(".\\CS\\St02\\A\\L\\", "*.mbg");
              break;
            default:
              files = Directory.GetFiles(".\\CS\\St02\\A\\L\\", "*.mbg");
              break;
          }
          foreach (string FileName in files)
            new CSEmitterController(this.StageData, this.StageData.LoadCS(FileName))
            {
              OnRoad = true
            }.Time = this.TimeMain - 60;
        }
      }
      if (this.TimeMain == numArray[0])
      {
        this.StageData.RemoveBullets();
        Boss_Rakuki01 bossRakuki01 = new Boss_Rakuki01(this.StageData);
        EmitterBossFire emitterBossFire = new EmitterBossFire(this.StageData, this.Boss.OriginalPosition, Color.FromArgb(144, (int) byte.MaxValue, 120));
        new MagicCircle(this.StageData, "MagicCircleSix").Scale = 1.5f;
        this.Background3D.WarpEnabled = true;
        this.Background3D.WarpColorKey = 2;
      }
      else if (this.TimeMain > numArray[1] && this.Boss == null && !this.RoadFlag)
      {
        this.RoadFlag = true;
        string[] files;
        switch (this.StageData.Difficulty)
        {
          case DifficultLevel.Easy:
            files = Directory.GetFiles(".\\CS\\St02\\B\\E\\", "*.mbg");
            break;
          case DifficultLevel.Normal:
            files = Directory.GetFiles(".\\CS\\St02\\B\\N\\", "*.mbg");
            break;
          case DifficultLevel.Hard:
            files = Directory.GetFiles(".\\CS\\St02\\B\\H\\", "*.mbg");
            break;
          case DifficultLevel.Lunatic:
            files = Directory.GetFiles(".\\CS\\St02\\B\\L\\", "*.mbg");
            break;
          default:
            files = Directory.GetFiles(".\\CS\\St02\\B\\L\\", "*.mbg");
            break;
        }
        foreach (string FileName in files)
          new CSEmitterController(this.StageData, this.StageData.LoadCS(FileName))
          {
            OnRoad = true
          }.Time = this.TimeMain - 60;
      }
      else if (numArray[2] - 130 == this.TimeMain)
      {
        StageDataPackage stageData = this.StageData;
        boundRect = this.BoundRect;
        PointF OriginalPosition = new PointF((float) (boundRect.Width / 2), 120f);
        new BossStar(stageData, OriginalPosition).ColorType = 5;
      }
      else
      {
        if (numArray[2] != this.TimeMain)
          return;
        this.StageData.RemoveBullets();
        Boss_Rakuki02 bossRakuki02 = new Boss_Rakuki02(this.StageData);
        switch (this.MyPlane.Name)
        {
          case "Aya":
            Story_SSS02_01 storySsS0201 = new Story_SSS02_01(this.StageData);
            break;
          case "Reimu":
            Story_SSS02_01A storySsS0201A = new Story_SSS02_01A(this.StageData);
            break;
          case "Marisa":
            Story_SSS02_01B storySsS0201B = new Story_SSS02_01B(this.StageData);
            break;
          case "Sanae":
            Story_SSS02_01C storySsS0201C = new Story_SSS02_01C(this.StageData);
            break;
          case "Koishi":
            Story_SSS02_01D storySsS0201D = new Story_SSS02_01D(this.StageData);
            break;
          default:
            Story_SSS02_01X storySsS0201X = new Story_SSS02_01X(this.StageData);
            break;
        }
        this.Background3D.WarpEnabled = false;
        this.Background3D.WarpColorKey = 2;
      }
    }

    public override void BGM_ON()
    {
    }
  }
}
