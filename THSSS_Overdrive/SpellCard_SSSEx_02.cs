// Decompiled with JetBrains decompiler
// Type: Shooting.SpellCard_SSSEx_02
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  internal class SpellCard_SSSEx_02 : BaseSpellCard
  {
    public SpellCard_SSSEx_02(StageDataPackage StageData)
      : base(StageData)
    {
      this.SC_Name = "柳符「新生的柳叶绿芽」";
      this.BaseScore = 20000000L;
      this.Boss.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 120);
      this.Boss.Velocity = 4f;
      StageData.SoundPlay("se_cat00.wav");
      BackgroundRotate backgroundRotate = new BackgroundRotate(StageData, "Card03f");
      backgroundRotate.Scale = 1f;
      backgroundRotate.AngularVelocityDegree = 0.0f;
      backgroundRotate.AngleDegree = 90.0;
      backgroundRotate.AngleWithDirection = false;
      BackgroundMove2 backgroundMove2_1 = new BackgroundMove2(StageData, "Card03d");
      backgroundMove2_1.Velocity = 1f;
      backgroundMove2_1.DirectionDegree = 0.0;
      backgroundMove2_1.TransparentValueF = 155f;
      backgroundMove2_1.Scale = 1f;
      backgroundMove2_1.Active = false;
      backgroundMove2_1.AngularVelocityDegree = 0.0f;
      BackgroundMove2 backgroundMove2_2 = backgroundMove2_1;
      backgroundMove2_2.EventGroupList = new List<EventGroup>();
      backgroundMove2_2.EventsExecutionList = new List<Execution>();
      EventGroup eventGroup1 = new EventGroup();
      eventGroup1.index = 0;
      eventGroup1.tag = "0";
      eventGroup1.t = 200;
      eventGroup1.addtime = 200;
      Event event1 = new Event();
      event1.EventString = "当前帧=1：不透明度变化到60，正弦，400";
      event1.String2BulletEvent();
      eventGroup1.EventList.Add(event1);
      backgroundMove2_2.EventGroupList.Add(eventGroup1);
      BackgroundMove2 backgroundMove2_3 = new BackgroundMove2(StageData, "Card03e");
      backgroundMove2_3.Velocity = 1f;
      backgroundMove2_3.DirectionDegree = 180.0;
      backgroundMove2_3.TransparentValueF = 60f;
      backgroundMove2_3.Scale = 1f;
      backgroundMove2_3.Active = false;
      backgroundMove2_3.AngularVelocityDegree = 0.0f;
      BackgroundMove2 backgroundMove2_4 = backgroundMove2_3;
      backgroundMove2_4.EventGroupList = new List<EventGroup>();
      backgroundMove2_4.EventsExecutionList = new List<Execution>();
      EventGroup eventGroup2 = new EventGroup();
      eventGroup2.index = 0;
      eventGroup2.tag = "0";
      eventGroup2.t = 200;
      eventGroup2.addtime = 200;
      Event event2 = new Event();
      event2.EventString = "当前帧=1：不透明度变化到155，正弦，400";
      event2.String2BulletEvent();
      eventGroup2.EventList.Add(event2);
      backgroundMove2_4.EventGroupList.Add(eventGroup2);
      BulletTitle bulletTitle = new BulletTitle(StageData, this.SC_Name);
      SpellCardAttack spellCardAttack = new SpellCardAttack(StageData);
      FullPic2 fullPic2 = new FullPic2(StageData, "FaceSeiryuu_ct");
    }

    public override void Shoot() {
            if(SpellList.Count>0 ) {
                Boss.Armon=1f;
            } else {
            this.Boss.Armon = this.Boss.ArmonArray[1]; 
            }
      if (this.Time > 50)
        this.Boss.RandomMove(150, 20, 2f, new Rectangle(this.BoundRect.Width / 2 - 45, 100, 90, 40));
      if (this.Time != 100)
        return;
      new CSEmitterController(this.StageData, this.StageData.LoadCS(".\\CS\\StEx\\道中Boss\\2符.mbg")).BossBinding = true;
    }
  }
}
