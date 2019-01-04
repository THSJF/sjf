// Decompiled with JetBrains decompiler
// Type: Shooting.GameState_SSSEx
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using Shooting.Planes.Story;
using System;
using System.Drawing;
using System.IO;

namespace Shooting
{
  internal class GameState_SSSEx : BaseStage, IGameState
  {
    private new int testStartTime = 0;

    public GameState_SSSEx(GlobalDataPackage GlobalData)
      : base(GlobalData)
    {
      this.StageName = "StEx";
    }

    public override void Drama()
    {
      base.Drama();
      int[] numArray = new int[3]{ 4920, 5060, 10260 };
      if (this.TimeMain == 1)
        this.MyPlane.EnchantmentCountNeeded = 10;
      Rectangle boundRect;
      if (this.TimeMain == 62)
      {
        if (this.StageData.C_History.PracticeLevel < 8)
          this.StageData.C_History.PracticeLevel = 8;
        this.StageData.ChangeBGM(".\\BGM\\StageEx.wav", (this.testStartTime + 60) * 44100 / 60, 0, (int) byte.MaxValue, 1341963, 7621362);
        StageDataPackage stageData1 = this.StageData;
        boundRect = this.BoundRect;
        int width1 = boundRect.Width;
        boundRect = this.BoundRect;
        int y = boundRect.Height - 16;
        Point DestPoint = new Point(width1, y);
        MusicTitle musicTitle1 = new MusicTitle(stageData1, "来自仙界的新风", DestPoint);
        MusicTitle musicTitle2 = musicTitle1;
        boundRect = this.BoundRect;
        double width2 = (double) boundRect.Width;
        boundRect = this.BoundRect;
        double num1 = (double) (boundRect.Height + 100);
        PointF pointF = new PointF((float) width2, (float) num1);
        musicTitle2.OriginalPosition = pointF;
        musicTitle1.Scale = 0.5f;
        this.Background3D.Envi = (IEnvironment) new EnvironmentSSSEx(this.StageData);
        new BackgroundTransitionIn(this.StageData)
        {
          Delay = 0
        }.LifeTime = 320;
        if (this.testStartTime > this.TimeMain)
          this.TimeMain = this.testStartTime;
        if (this.TimeMain < numArray[0])
        {
          foreach (string file in Directory.GetFiles(".\\CS\\StEx\\A\\", "*.mbg"))
            new CSEmitterController(this.StageData, this.StageData.LoadCS(file))
            {
              OnRoad = true
            }.Time = this.TimeMain - 60;
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
      if (this.TimeMain == numArray[0])
      {
        this.StageData.RemoveBullets();
        Boss_Seiryuu03 bossSeiryuu03 = new Boss_Seiryuu03(this.StageData);
        EmitterBossFire emitterBossFire = new EmitterBossFire(this.StageData, this.Boss.OriginalPosition, Color.FromArgb(40, (int) byte.MaxValue, 20));
        new MagicCircle(this.StageData, "MagicCircleSix").Scale = 1.5f;
        this.Background3D.WarpEnabled = true;
        this.Background3D.WarpColorKey = 2;
      }
      else if (this.TimeMain > numArray[1] && this.Boss == null && !this.RoadFlag)
      {
        this.RoadFlag = true;
        foreach (string file in Directory.GetFiles(".\\CS\\StEx\\B\\", "*.mbg"))
          new CSEmitterController(this.StageData, this.StageData.LoadCS(file))
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
        Boss_Rika01 bossRika01 = new Boss_Rika01(this.StageData);
        Story_SSSEx_01 storySssEx01 = new Story_SSSEx_01(this.StageData);
        this.Background3D.WarpEnabled = false;
        this.Background3D.WarpColorKey = 2;
      }
    }

    public override void BGM_ON()
    {
    }
  }
}
