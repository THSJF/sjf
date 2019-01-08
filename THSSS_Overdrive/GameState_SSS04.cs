// Decompiled with JetBrains decompiler
// Type: Shooting.GameState_SSS04
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using Shooting.Planes.Story;
using System.Drawing;
using System.IO;

namespace Shooting
{
  internal class GameState_SSS04 : BaseStage, IGameState
  {
    public GameState_SSS04(GlobalDataPackage GlobalData)
      : base(GlobalData)
    {
      this.StageName = "St4";
    }

    public override void Drama()
    {
      base.Drama();
      int[] numArray = new int[3]{ 0, 0, 8850 };
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
        if (this.StageData.C_History.PracticeLevel < 4)
          this.StageData.C_History.PracticeLevel = 4;
        this.StageData.ChangeBGM(".\\BGM\\Stage04.wav", (this.testStartTime + 60) * 44100 / 60, 0, (int) byte.MaxValue, 575990, 7775976);
        MusicTitle musicTitle1 = new MusicTitle(this.StageData, "万花世界的光与影", new Point(this.BoundRect.Width, this.BoundRect.Height - 16));
        MusicTitle musicTitle2 = musicTitle1;
        double width = (double) this.BoundRect.Width;
        boundRect = this.BoundRect;
        double num = (double) (boundRect.Height + 100);
        PointF pointF = new PointF((float) width, (float) num);
        musicTitle2.OriginalPosition = pointF;
        musicTitle1.Scale = 0.5f;
        this.Background3D.Envi = (IEnvironment) new EnvironmentSSS04(this.StageData);
        new BackgroundTransitionIn(this.StageData)
        {
          Delay = 20
        }.LifeTime = 150;
        if (this.testStartTime > this.TimeMain)
          this.TimeMain = this.testStartTime;
        if (this.TimeMain < numArray[2])
        {
          string[] files;
          switch (this.StageData.Difficulty)
          {
            case DifficultLevel.Easy:
              files = Directory.GetFiles(".\\CS\\St04\\A\\E\\", "*.mbg");
              break;
            case DifficultLevel.Normal:
              files = Directory.GetFiles(".\\CS\\St04\\A\\N\\", "*.mbg");
              break;
            case DifficultLevel.Hard:
              files = Directory.GetFiles(".\\CS\\St04\\A\\H\\", "*.mbg");
              break;
            case DifficultLevel.Lunatic:
              files = Directory.GetFiles(".\\CS\\St04\\A\\L\\", "*.mbg");
              break;
            default:
              files = Directory.GetFiles(".\\CS\\St04\\A\\L\\", "*.mbg");
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
        new BossStar(stageData, OriginalPosition).ColorType = 2;
      }
      else
      {
        if (numArray[2] != this.TimeMain)
          return;
        this.StageData.RemoveBullets();
        Boss_Kage01 bossKage01 = new Boss_Kage01(this.StageData);
        Story_SSS04_01 storySsS0401 = new Story_SSS04_01(this.StageData);
        this.Background3D.WarpEnabled = false;
        this.Background3D.WarpColorKey = 0;
      }
    }

    public override void BGM_ON()
    {
    }
  }
}
