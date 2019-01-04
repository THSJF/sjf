// Decompiled with JetBrains decompiler
// Type: Shooting.BackgroundBossEx
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  public class BackgroundBossEx : BaseObject
  {
    public BackgroundBossEx(StageDataPackage StageData)
      : base(StageData, (string) null, new PointF(0.0f, 0.0f), 0.0f, 0.0)
    {
      new BackgroundMove2(StageData, "底面").DirectionDegree = 90.0;
      BackgroundSC backgroundSc = new BackgroundSC(StageData, "中层");
      BackgroundRotate backgroundRotate1 = new BackgroundRotate(StageData, "最上");
      backgroundRotate1.DirectionDegree = 90.0;
      backgroundRotate1.TransparentValueF = 128f;
      backgroundRotate1.Scale = 1f;
      backgroundRotate1.Active = false;
      backgroundRotate1.AngularVelocityDegree = 0.5f;
      BackgroundRotate backgroundRotate2 = backgroundRotate1;
      backgroundRotate2.EventGroupList = new List<EventGroup>();
      backgroundRotate2.EventsExecutionList = new List<Execution>();
      EventGroup eventGroup = new EventGroup();
      eventGroup.index = 0;
      eventGroup.tag = "0";
      eventGroup.t = 200;
      eventGroup.addtime = 200;
      Event @event = new Event();
      @event.EventString = "当前帧=1：不透明度变化到5，正弦，200";
      @event.String2BulletEvent();
      eventGroup.EventList.Add(@event);
      backgroundRotate2.EventGroupList.Add(eventGroup);
    }
  }
}
