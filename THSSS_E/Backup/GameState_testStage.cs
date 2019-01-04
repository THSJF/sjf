// Decompiled with JetBrains decompiler
// Type: Shooting.GameState_testStage
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  internal class GameState_testStage : BaseStage, IGameState
  {
    public GameState_testStage(GlobalDataPackage GlobalData)
      : base(GlobalData)
    {
      this.StageName = "Stage_test";
    }

    public override void Drama()
    {
      if (this.TimeMain == 1)
      {
        this.StageData.SetReplayInfo(this.StageName);
        if (this.MyPlane == null)
        {
          StageDataPackage stageData = this.StageData;
          Rectangle boundRect = this.BoundRect;
          int width = boundRect.Width;
          boundRect = this.BoundRect;
          int y = boundRect.Height - 50;
          Point Position = new Point(width, y);
          this.MyPlane = new BaseMyPlane(stageData, Position);
        }
        BackgroundRotate backgroundRotate1 = new BackgroundRotate(this.StageData, "Card02b");
        backgroundRotate1.Scale = 1.3f;
        backgroundRotate1.TransparentValueF = (float) byte.MaxValue;
        backgroundRotate1.AngularVelocityDegree = -0.5f;
        BackgroundRotate backgroundRotate2 = new BackgroundRotate(this.StageData, "Card02a");
        backgroundRotate2.DirectionDegree = 90.0;
        backgroundRotate2.TransparentValueF = 155f;
        backgroundRotate2.Scale = 1f;
        backgroundRotate2.Active = false;
        backgroundRotate2.AngularVelocityDegree = 0.0f;
        BackgroundRotate backgroundRotate3 = backgroundRotate2;
        backgroundRotate3.EventGroupList = new List<EventGroup>();
        backgroundRotate3.EventsExecutionList = new List<Execution>();
        EventGroup eventGroup = new EventGroup();
        eventGroup.index = 0;
        eventGroup.tag = "0";
        eventGroup.t = 200;
        eventGroup.addtime = 200;
        Event @event = new Event();
        @event.EventString = "当前帧=1：不透明度变化到60，正弦，400";
        @event.String2BulletEvent();
        eventGroup.EventList.Add(@event);
        backgroundRotate3.EventGroupList.Add(eventGroup);
        BackgroundRotate backgroundRotate4 = new BackgroundRotate(this.StageData, "Card02c");
        backgroundRotate4.Scale = 0.7f;
        backgroundRotate4.Active = true;
        backgroundRotate4.AngularVelocityDegree = 0.2f;
      }
      if (this.TimeMain != 50)
        ;
      if (this.TimeMain % 400 != 100)
        ;
    }

    public override void BGM_ON()
    {
    }
  }
}
