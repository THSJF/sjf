// Decompiled with JetBrains decompiler
// Type: Shooting.GameState_SSS05
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using Shooting.Planes.Story;
using System.Drawing;
using System.IO;

namespace Shooting
{
  internal class GameState_SSS05 : BaseStage, IGameState
  {
    public GameState_SSS05(GlobalDataPackage GlobalData)
      : base(GlobalData)
    {
      this.StageName = "St5";
    }

    public override void Drama()
    {
      base.Drama();
      int[] numArray = new int[3]{ 2500, 3000, 8750 };
      if (this.TimeMain == 1)
      {
        switch (this.StageData.Difficulty)
        {
          case DifficultLevel.Hard:
            this.MyPlane.EnchantmentCountNeeded = 8;
            break;
          case DifficultLevel.Lunatic:
            this.MyPlane.EnchantmentCountNeeded = 9;
            break;
        }
      }
      Rectangle boundRect;
      if (this.TimeMain == 2)
      {
        if (this.StageData.C_History.PracticeLevel < 5)
          this.StageData.C_History.PracticeLevel = 5;
        this.StageData.ChangeBGM(".\\BGM\\Stage05.wav", (this.testStartTime + 60) * 44100 / 60, 0, (int) byte.MaxValue, 66150, 0);
        StageDataPackage stageData = this.StageData;
        boundRect = this.BoundRect;
        int width1 = boundRect.Width;
        boundRect = this.BoundRect;
        int y = boundRect.Height - 16;
        Point DestPoint = new Point(width1, y);
        MusicTitle musicTitle1 = new MusicTitle(stageData, "记忆中遥远的星星", DestPoint);
        MusicTitle musicTitle2 = musicTitle1;
        boundRect = this.BoundRect;
        double width2 = (double) boundRect.Width;
        boundRect = this.BoundRect;
        double num = (double) (boundRect.Height + 100);
        PointF pointF = new PointF((float) width2, (float) num);
        musicTitle2.OriginalPosition = pointF;
        musicTitle1.Scale = 0.5f;
        this.Background3D.Envi = (IEnvironment) new EnvironmentSSS05(this.StageData);
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
              files = Directory.GetFiles(".\\CS\\St05\\A\\E\\", "*.mbg");
              break;
            case DifficultLevel.Normal:
              files = Directory.GetFiles(".\\CS\\St05\\A\\N\\", "*.mbg");
              break;
            case DifficultLevel.Hard:
              files = Directory.GetFiles(".\\CS\\St05\\A\\H\\", "*.mbg");
              break;
            case DifficultLevel.Lunatic:
              files = Directory.GetFiles(".\\CS\\St05\\A\\L\\", "*.mbg");
              break;
            default:
              files = Directory.GetFiles(".\\CS\\St05\\A\\L\\", "*.mbg");
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
        Boss_Rakuki04 bossRakuki04 = new Boss_Rakuki04(this.StageData);
        this.StageData.RemoveBullets();
      }
      else if (this.TimeMain == numArray[0] + 90)
      {
        Story_SSS05_01 storySsS0501 = new Story_SSS05_01(this.StageData);
      }
      else if (this.TimeMain > numArray[1] && this.Boss == null && !this.RoadFlag)
      {
        this.RoadFlag = true;
        string[] files;
        switch (this.StageData.Difficulty)
        {
          case DifficultLevel.Easy:
            files = Directory.GetFiles(".\\CS\\St05\\B\\E\\", "*.mbg");
            break;
          case DifficultLevel.Normal:
            files = Directory.GetFiles(".\\CS\\St05\\B\\N\\", "*.mbg");
            break;
          case DifficultLevel.Hard:
            files = Directory.GetFiles(".\\CS\\St05\\B\\H\\", "*.mbg");
            break;
          case DifficultLevel.Lunatic:
            files = Directory.GetFiles(".\\CS\\St05\\B\\L\\", "*.mbg");
            break;
          default:
            files = Directory.GetFiles(".\\CS\\St05\\B\\L\\", "*.mbg");
            break;
        }
        foreach (string FileName in files)
          new CSEmitterController(this.StageData, this.StageData.LoadCS(FileName))
          {
            OnRoad = true
          }.Time = this.TimeMain - 60;
      }
      if (numArray[2] - 130 == this.TimeMain)
      {
        StageDataPackage stageData = this.StageData;
        boundRect = this.BoundRect;
        PointF OriginalPosition = new PointF((float) (boundRect.Width / 2), 150f);
        new BossStar(stageData, OriginalPosition).ColorType = 1;
      }
      else
      {
        if (numArray[2] != this.TimeMain)
          return;
        this.StageData.RemoveBullets();
        Boss_Rakukun01 bossRakukun01 = new Boss_Rakukun01(this.StageData);
        Story_SSS05_02 storySsS0502 = new Story_SSS05_02(this.StageData);
        this.Background3D.WarpEnabled = false;
        this.Background3D.WarpColorKey = 0;
      }
    }

    public override void BGM_ON()
    {
    }
  }
}
