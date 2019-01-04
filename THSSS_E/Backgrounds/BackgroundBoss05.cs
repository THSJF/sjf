// Decompiled with JetBrains decompiler
// Type: Shooting.BackgroundBoss05
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  public class BackgroundBoss05 : BaseObject
  {
    public BackgroundBoss05(StageDataPackage StageData)
      : base(StageData, (string) null, new PointF(0.0f, 0.0f), 0.0f, 0.0)
    {
      BackgroundRotate backgroundRotate1 = new BackgroundRotate(StageData, "card05b");
      backgroundRotate1.Scale = 1.3f;
      backgroundRotate1.TransparentValueF = (float) byte.MaxValue;
      backgroundRotate1.AngularVelocityDegree = -0.5f;
      BackgroundMove2 backgroundMove2_1 = new BackgroundMove2(StageData, "card05c");
      backgroundMove2_1.DirectionDegree = -180.0;
      backgroundMove2_1.TransparentValueF = 155f;
      backgroundMove2_1.Scale = 1f;
      backgroundMove2_1.Active = false;
      BackgroundMove2 backgroundMove2_2 = backgroundMove2_1;
      backgroundMove2_2.EventGroupList = new List<EventGroup>();
      backgroundMove2_2.EventsExecutionList = new List<Execution>();
      EventGroup eventGroup = new EventGroup();
      eventGroup.index = 0;
      eventGroup.tag = "0";
      eventGroup.t = 200;
      eventGroup.addtime = 200;
      Event @event = new Event();
      @event.EventString = "当前帧=1：不透明度变化到60，正弦，400";
      @event.String2BulletEvent();
      eventGroup.EventList.Add(@event);
      backgroundMove2_2.EventGroupList.Add(eventGroup);
      BackgroundRotate backgroundRotate2 = new BackgroundRotate(StageData, "card05a");
      backgroundRotate2.Scale = 0.7f;
      backgroundRotate2.Active = true;
      backgroundRotate2.AngularVelocityDegree = 0.2f;
    }
  }
}
