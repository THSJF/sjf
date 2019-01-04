// Decompiled with JetBrains decompiler
// Type: Shooting.GameState_SSS06
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using Shooting.Planes.Story;
using System.Drawing;
using System.IO;

namespace Shooting
{
  internal class GameState_SSS06 : BaseStage, IGameState
  {
    public GameState_SSS06(GlobalDataPackage GlobalData)
      : base(GlobalData)
    {
      this.StageName = "St6";
    }

    public override void Drama()
    {
      base.Drama();
      int[] numArray = new int[3]{ 2550, 3000, 8550 };
      if (this.TimeMain == 1)
      {
        switch (this.StageData.Difficulty)
        {
          case DifficultLevel.Hard:
            this.MyPlane.EnchantmentCountNeeded = 6;
            break;
          case DifficultLevel.Lunatic:
            this.MyPlane.EnchantmentCountNeeded = 7;
            break;
        }
      }
      Rectangle boundRect;
      if (this.TimeMain == 2)
      {
        if (this.StageData.C_History.PracticeLevel < 6)
          this.StageData.C_History.PracticeLevel = 6;
        this.StageData.ChangeBGM(".\\BGM\\Stage06.wav", (this.testStartTime + 60) * 44100 / 60, 0, (int) byte.MaxValue, 0, 6220746);
        StageDataPackage stageData = this.StageData;
        boundRect = this.BoundRect;
        int width1 = boundRect.Width;
        boundRect = this.BoundRect;
        int y = boundRect.Height - 16;
        Point DestPoint = new Point(width1, y);
        MusicTitle musicTitle1 = new MusicTitle(stageData, "银河的彼方", DestPoint);
        MusicTitle musicTitle2 = musicTitle1;
        boundRect = this.BoundRect;
        double width2 = (double) boundRect.Width;
        boundRect = this.BoundRect;
        double num = (double) (boundRect.Height + 100);
        PointF pointF = new PointF((float) width2, (float) num);
        musicTitle2.OriginalPosition = pointF;
        musicTitle1.Scale = 0.5f;
        this.Background3D.Envi = (IEnvironment) new EnvironmentSSS06(this.StageData);
        new BackgroundTransitionIn(this.StageData)
        {
          Delay = 30
        }.LifeTime = 250;
        if (this.testStartTime > this.TimeMain)
          this.TimeMain = this.testStartTime;
        if (this.TimeMain < numArray[2])
        {
          string[] files;
          switch (this.StageData.Difficulty)
          {
            case DifficultLevel.Easy:
              files = Directory.GetFiles(".\\CS\\St06\\A\\E\\", "*.mbg");
              break;
            case DifficultLevel.Normal:
              files = Directory.GetFiles(".\\CS\\St06\\A\\N\\", "*.mbg");
              break;
            case DifficultLevel.Hard:
              files = Directory.GetFiles(".\\CS\\St06\\A\\H\\", "*.mbg");
              break;
            case DifficultLevel.Lunatic:
              files = Directory.GetFiles(".\\CS\\St06\\A\\L\\", "*.mbg");
              break;
            default:
              files = Directory.GetFiles(".\\CS\\St06\\A\\L\\", "*.mbg");
              break;
          }
          foreach (string FileName in files)
            new CSEmitterController(this.StageData, this.StageData.LoadCS(FileName))
            {
              OnRoad = true
            }.Time = this.TimeMain - 60;
        }
      }
      if (numArray[2] - 130 == this.TimeMain)
      {
        StageDataPackage stageData = this.StageData;
        boundRect = this.BoundRect;
        PointF OriginalPosition = new PointF((float) (boundRect.Width / 2), 150f);
        new BossStar(stageData, OriginalPosition).ColorType = 4;
      }
      else
      {
        if (numArray[2] != this.TimeMain)
          return;
        this.StageData.RemoveBullets();
        Boss_Tensei01 bossTensei01 = new Boss_Tensei01(this.StageData);
        Story_SSS06_01 storySsS0601 = new Story_SSS06_01(this.StageData);
        this.Background3D.WarpEnabled = false;
        this.Background3D.WarpColorKey = 0;
      }
    }

    public override void BGM_ON()
    {
    }
  }
}
