// Decompiled with JetBrains decompiler
// Type: Shooting.SpellCard_SSS02_02
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  internal class SpellCard_SSS02_02 : BaseSpellCard
  {
    public SpellCard_SSS02_02(StageDataPackage StageData)
      : base(StageData)
    {
      if (this.Difficulty < DifficultLevel.Hard)
        this.SC_Name = "天诏「琴引山之诏琴」";
      else
        this.SC_Name = "异器「琴引山之神弓」";
      this.BaseScore = 15000000L;
      this.Boss.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 120);
      this.Boss.Velocity = 4f;
      StageData.SoundPlay("se_cat00.wav");
      BackgroundRotate backgroundRotate1 = new BackgroundRotate(StageData, "Card02b");
      backgroundRotate1.Scale = 1.3f;
      backgroundRotate1.TransparentValueF = (float) byte.MaxValue;
      backgroundRotate1.AngularVelocityDegree = -0.5f;
      BackgroundMove2 backgroundMove2_1 = new BackgroundMove2(StageData, "Card02a");
      backgroundMove2_1.DirectionDegree = -80.0;
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
      BackgroundRotate backgroundRotate2 = new BackgroundRotate(StageData, "Card02c");
      backgroundRotate2.Scale = 0.7f;
      backgroundRotate2.Active = true;
      backgroundRotate2.AngularVelocityDegree = 0.2f;
      BulletTitle bulletTitle = new BulletTitle(StageData, this.SC_Name);
      SpellCardAttack spellCardAttack = new SpellCardAttack(StageData);
      FullPic2 fullPic2 = new FullPic2(StageData, "FaceRakuki_ct");
    }

    public override void Shoot() { 
                this.Boss.Armon = 0.75f;
      if (this.Time > 100)
        this.Boss.MoveUpDown();
      if (this.Time != 150)
        return;
      string FileName;
      switch (this.Difficulty)
      {
        case DifficultLevel.Easy:
          FileName = ".\\CS\\St02\\关底Boss\\1符E.mbg";
          break;
        case DifficultLevel.Normal:
          FileName = ".\\CS\\St02\\关底Boss\\1符N.mbg";
          break;
        case DifficultLevel.Hard:
          FileName = ".\\CS\\St02\\关底Boss\\1符H.mbg";
          break;
        case DifficultLevel.Lunatic:
          FileName = ".\\CS\\St02\\关底Boss\\1符L.mbg";
          break;
        default:
          FileName = ".\\CS\\St02\\关底Boss\\1符L.mbg";
          break;
      }
      CSEmitterController emitterController = new CSEmitterController(this.StageData, this.StageData.LoadCS(FileName));
    }
  }
}
