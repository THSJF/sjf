// Decompiled with JetBrains decompiler
// Type: Shooting.SpellCard_SSS03_01
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  internal class SpellCard_SSS03_01 : BaseSpellCard
  {
    public SpellCard_SSS03_01(StageDataPackage StageData)
      : base(StageData)
    {
      if (this.Difficulty < DifficultLevel.Hard)
        this.SC_Name = "火符「逼近的火焰」";
      else
        this.SC_Name = "火符「燃烧地狱火海」";
      this.BaseScore = 20000000L;
      this.Boss.DestPoint = (PointF) new Point(this.BoundRect.Width / 2, 120);
      this.Boss.Velocity = 4f;
      StageData.SoundPlay("se_cat00.wav");
      BackgroundRotate backgroundRotate1 = new BackgroundRotate(StageData, "Card03b");
      backgroundRotate1.Scale = 1.3f;
      backgroundRotate1.TransparentValueF = (float) byte.MaxValue;
      backgroundRotate1.AngularVelocityDegree = -0.5f;
      BackgroundRotate backgroundRotate2 = new BackgroundRotate(StageData, "Card03a");
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
      BackgroundRotate backgroundRotate4 = new BackgroundRotate(StageData, "Card03c");
      backgroundRotate4.Scale = 0.7f;
      backgroundRotate4.Active = true;
      backgroundRotate4.AngularVelocityDegree = 0.2f;
      BulletTitle bulletTitle = new BulletTitle(StageData, this.SC_Name);
      SpellCardAttack spellCardAttack = new SpellCardAttack(StageData);
      new FullPic2(StageData, "FaceKoreirei_ct").Scale = 0.8f;
    }

    public override void Shoot()
    {
      this.Boss.Armon = 0.15f;
      if (this.Time > 50)
        this.Boss.RandomMove(150, 20, 2f, new Rectangle(this.BoundRect.Width / 2 - 45, 100, 90, 40));
      if (this.Time != 100)
        return;
      string FileName;
      switch (this.Difficulty)
      {
        case DifficultLevel.Easy:
          FileName = ".\\CS\\St03\\道中Boss\\1符E.mbg";
          break;
        case DifficultLevel.Normal:
          FileName = ".\\CS\\St03\\道中Boss\\1符N.mbg";
          break;
        case DifficultLevel.Hard:
          FileName = ".\\CS\\St03\\道中Boss\\1符H.mbg";
          break;
        case DifficultLevel.Lunatic:
          FileName = ".\\CS\\St03\\道中Boss\\1符L.mbg";
          break;
        default:
          FileName = ".\\CS\\St03\\道中Boss\\1符U.mbg";
          break;
      }
      new CSEmitterController(this.StageData, this.StageData.LoadCS(FileName)).BossBinding = true;
    }
  }
}
