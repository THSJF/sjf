// Decompiled with JetBrains decompiler
// Type: Shooting.GameState_SSS03
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using Shooting.Planes.Story;
using System.Drawing;
using System.IO;

namespace Shooting
{
  internal class GameState_SSS03 : BaseStage, IGameState
  {
    public GameState_SSS03(GlobalDataPackage GlobalData)
      : base(GlobalData)
    {
      this.StageName = "St3";
    }

    public override void Drama()
    {
      base.Drama();
      int[] numArray = new int[3]{ 3360, 3800, 7300 };
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
        if (this.StageData.C_History.PracticeLevel < 3)
          this.StageData.C_History.PracticeLevel = 3;
        this.StageData.ChangeBGM(".\\BGM\\Stage03.wav", (this.testStartTime + 60) * 44100 / 60, 0, (int) byte.MaxValue, 88200, 5606874);
        StageDataPackage stageData = this.StageData;
        boundRect = this.BoundRect;
        int width1 = boundRect.Width;
        boundRect = this.BoundRect;
        int y = boundRect.Height - 16;
        Point DestPoint = new Point(width1, y);
        MusicTitle musicTitle1 = new MusicTitle(stageData, "木灵们的夏夜祭", DestPoint);
        MusicTitle musicTitle2 = musicTitle1;
        boundRect = this.BoundRect;
        double width2 = (double) boundRect.Width;
        boundRect = this.BoundRect;
        double num = (double) (boundRect.Height + 100);
        PointF pointF = new PointF((float) width2, (float) num);
        musicTitle2.OriginalPosition = pointF;
        musicTitle1.Scale = 0.5f;
        this.Background3D.Envi = (IEnvironment) new EnvironmentSSS03(this.StageData);
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
              files = Directory.GetFiles(".\\CS\\St03\\A\\E\\", "*.mbg");
              break;
            case DifficultLevel.Normal:
              files = Directory.GetFiles(".\\CS\\St03\\A\\N\\", "*.mbg");
              break;
            case DifficultLevel.Hard:
              files = Directory.GetFiles(".\\CS\\St03\\A\\H\\", "*.mbg");
              break;
            case DifficultLevel.Lunatic:
              files = Directory.GetFiles(".\\CS\\St03\\A\\L\\", "*.mbg");
              break;
            default:
              files = Directory.GetFiles(".\\CS\\St03\\A\\L\\", "*.mbg");
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
        Boss_Koreirei01 bossKoreirei01 = new Boss_Koreirei01(this.StageData);
        EmitterBossFire emitterBossFire = new EmitterBossFire(this.StageData, this.Boss.OriginalPosition, Color.OrangeRed);
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
            files = Directory.GetFiles(".\\CS\\St03\\B\\E\\", "*.mbg");
            break;
          case DifficultLevel.Normal:
            files = Directory.GetFiles(".\\CS\\St03\\B\\N\\", "*.mbg");
            break;
          case DifficultLevel.Hard:
            files = Directory.GetFiles(".\\CS\\St03\\B\\H\\", "*.mbg");
            break;
          case DifficultLevel.Lunatic:
            files = Directory.GetFiles(".\\CS\\St03\\B\\L\\", "*.mbg");
            break;
          default:
            files = Directory.GetFiles(".\\CS\\St03\\B\\L\\", "*.mbg");
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
        PointF OriginalPosition = new PointF((float) (boundRect.Width / 2), 150f);
        new BossStar(stageData, OriginalPosition).ColorType = 5;
      }
      else
      {
        if (numArray[2] != this.TimeMain)
          return;
        this.StageData.RemoveBullets();
        Boss_Seiryuu01 bossSeiryuu01 = new Boss_Seiryuu01(this.StageData);
        switch (this.MyPlane.Name)
        {
          case "Aya":
            Story_SSS03_01 storySsS0301 = new Story_SSS03_01(this.StageData);
            break;
          case "Reimu":
            Story_SSS03_01A storySsS0301A = new Story_SSS03_01A(this.StageData);
            break;
          case "Marisa":
            Story_SSS03_01B storySsS0301B = new Story_SSS03_01B(this.StageData);
            break;
          case "Sanae":
            Story_SSS03_01C storySsS0301C = new Story_SSS03_01C(this.StageData);
            break;
          case "Koishi":
            Story_SSS03_01D storySsS0301D = new Story_SSS03_01D(this.StageData);
            break;
          default:
            Story_SSS03_01X storySsS0301X = new Story_SSS03_01X(this.StageData);
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
