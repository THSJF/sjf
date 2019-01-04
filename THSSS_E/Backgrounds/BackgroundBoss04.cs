// Decompiled with JetBrains decompiler
// Type: Shooting.BackgroundBoss04
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  public class BackgroundBoss04 : BaseObject
  {
    public BackgroundBoss04(StageDataPackage StageData)
      : base(StageData, (string) null, new PointF(0.0f, 0.0f), 0.0f, 0.0)
    {
      BackgroundSC backgroundSc = new BackgroundSC(StageData, "Card04c");
      BackgroundRotate backgroundRotate1 = new BackgroundRotate(StageData, "Card04a");
      backgroundRotate1.DirectionDegree = 90.0;
      backgroundRotate1.TransparentValueF = 128f;
      backgroundRotate1.Scale = 1f;
      backgroundRotate1.Active = false;
      backgroundRotate1.AngularVelocityDegree = 0.0f;
      BackgroundRotate backgroundRotate2 = backgroundRotate1;
      backgroundRotate2.EventGroupList = new List<EventGroup>();
      backgroundRotate2.EventsExecutionList = new List<Execution>();
      EventGroup eventGroup1 = new EventGroup();
      eventGroup1.index = 0;
      eventGroup1.tag = "0";
      eventGroup1.t = 200;
      eventGroup1.addtime = 200;
      Event event1 = new Event();
      event1.EventString = "当前帧=1：不透明度变化到5，正弦，200";
      event1.String2BulletEvent();
      eventGroup1.EventList.Add(event1);
      backgroundRotate2.EventGroupList.Add(eventGroup1);
      BackgroundRotate backgroundRotate3 = new BackgroundRotate(StageData, "Card04b");
      backgroundRotate3.DirectionDegree = 90.0;
      backgroundRotate3.TransparentValueF = 128f;
      backgroundRotate3.Scale = 1f;
      backgroundRotate3.Active = false;
      backgroundRotate3.AngularVelocityDegree = 0.0f;
      BackgroundRotate backgroundRotate4 = backgroundRotate3;
      backgroundRotate4.EventGroupList = new List<EventGroup>();
      backgroundRotate4.EventsExecutionList = new List<Execution>();
      EventGroup eventGroup2 = new EventGroup();
      eventGroup2.index = 0;
      eventGroup2.tag = "0";
      eventGroup2.t = 200;
      eventGroup2.addtime = 200;
      Event event2 = new Event();
      event2.EventString = "当前帧=1：不透明度变化到255，正弦，200";
      event2.String2BulletEvent();
      eventGroup2.EventList.Add(event2);
      backgroundRotate4.EventGroupList.Add(eventGroup2);
    }
  }
}
