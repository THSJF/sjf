// Decompiled with JetBrains decompiler
// Type: Shooting.Spell_Shinmyoumaru
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class Spell_Shinmyoumaru : BaseSpell
  {
    public Spell_Shinmyoumaru(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.Position = this.MyPlane.Position;
      this.Damage = 32;
      this.Region = 4;
      this.LifeTime = 300;
      this.ScaleVelocity = 0.3f;
      this.MaxScale = 200f;
      BackgroundBlack backgroundBlack = new BackgroundBlack(StageData, this.Position);
      StageData.SoundPlay("se_cat00.wav");
      StageData.SoundPlay("se_nep00.wav");
      this.SpellList.Add((BaseObject) this);
    }

    public override void Move()
    {
      this.Position = this.MyPlane.Position;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (1 < this.Time && this.Time < 60)
      {
        int num1 = 7;
        double num2 = 360.0 / (double) num1;
        for (int index = 0; index < num1; ++index)
        {
          BaseEffect baseEffect1 = new BaseEffect(this.StageData, "bullet23_0", this.Position, 1.5f, 0.0);
          baseEffect1.DirectionDegree = (double) (this.Time * 18) + num2 * (double) index;
          baseEffect1.ScaleWidth = 0.3f;
          baseEffect1.ScaleLength = 0.3f;
          baseEffect1.LifeTime = 999;
          BaseEffect baseEffect2 = baseEffect1;
          baseEffect2.OutBound = false;
          baseEffect2.DirectionVelocityDegree = -2.8f;
          baseEffect2.VelocityDictionary.Add(40, 3f);
          baseEffect2.AccelerateDictionary.Add(115, 2f);
          baseEffect2.AccelerateDictionary.Add(123, 0.0f);
          baseEffect2.DirectionVelocityDegreeDictionary.Add(115, (float) ((this.Ran.NextPMDouble() - 80.0) / 45.0));
          baseEffect2.DirectionVelocityDegreeDictionary.Add(160, 0.0f);
          baseEffect2.ScaleLengthVelocityDictionary.Add(115, 0.3f);
          baseEffect2.ScaleWidthVelocityDictionary.Add(115, 0.1f);
          baseEffect2.ScaleLengthVelocityDictionary.Add(120, 0.0f);
          baseEffect2.ScaleWidthVelocityDictionary.Add(120, 0.0f);
          baseEffect2.SetBinding((BaseObject) this);
          BaseEffect baseEffect3 = new BaseEffect(this.StageData, "bullet23_0", this.Position, 1.5f, 0.0);
          baseEffect3.DirectionDegree = (double) (180 - this.Time * 18) + num2 * (double) index;
          baseEffect3.ScaleWidth = 0.3f;
          baseEffect3.ScaleLength = 0.3f;
          baseEffect3.LifeTime = 999;
          BaseEffect baseEffect4 = baseEffect3;
          baseEffect4.OutBound = false;
          baseEffect4.DirectionVelocityDegree = 2.8f;
          baseEffect4.VelocityDictionary.Add(40, 3f);
          baseEffect4.AccelerateDictionary.Add(115, 2f);
          baseEffect4.AccelerateDictionary.Add(123, 0.0f);
          baseEffect4.DirectionVelocityDegreeDictionary.Add(115, (float) ((80.0 + this.Ran.NextPMDouble()) / 45.0));
          baseEffect4.DirectionVelocityDegreeDictionary.Add(160, 0.0f);
          baseEffect4.ScaleLengthVelocityDictionary.Add(115, 0.3f);
          baseEffect4.ScaleWidthVelocityDictionary.Add(115, 0.1f);
          baseEffect4.ScaleLengthVelocityDictionary.Add(120, 0.0f);
          baseEffect4.ScaleWidthVelocityDictionary.Add(120, 0.0f);
          baseEffect4.SetBinding((BaseObject) this);
        }
      }
      if (130 < this.Time && this.Time < 220)
      {
        for (int index = 0; index < 3; ++index)
        {
          BaseEffect_CS baseEffectCs1 = new BaseEffect_CS(this.StageData);
          baseEffectCs1.TxtureObject = this.TextureObjectDictionary["bullet50_0"];
          BaseEffect_CS baseEffectCs2 = baseEffectCs1;
          Rectangle boundRect = this.BoundRect;
          double num1 = (double) (boundRect.Width / 2) + 200.0 * this.Ran.NextPMDouble();
          boundRect = this.BoundRect;
          double num2 = (double) (boundRect.Height / 2) + 280.0 * this.Ran.NextPMDouble();
          PointF pointF = new PointF((float) num1, (float) num2);
          baseEffectCs2.OriginalPosition = pointF;
          baseEffectCs1.Velocity = (float) this.Ran.NextPMDouble();
          baseEffectCs1.Direction = Math.PI / 2.0 * this.Ran.NextPMDouble();
          baseEffectCs1.Scale = 0.05f;
          baseEffectCs1.LifeTime = 40;
          EventGroup eventGroup = new EventGroup();
          eventGroup.index = 0;
          eventGroup.tag = "0";
          eventGroup.t = 15;
          eventGroup.addtime = 15;
          Event event1 = new Event();
          event1.EventString = "当前帧=1：高比变化到0，正弦，14";
          event1.String2BulletEvent();
          eventGroup.EventList.Add(event1);
          Event event2 = new Event();
          event2.EventString = "当前帧=1：宽比变化到0，正弦，14";
          event2.String2BulletEvent();
          eventGroup.EventList.Add(event2);
          baseEffectCs1.EventGroupList.Add(eventGroup);
          this.EffectList.Add((BaseEffect) baseEffectCs1);
        }
      }
      if (this.Time != 122)
        return;
      this.ScaleVelocity = 10f;
      EmitterGiveOutEnegy3D emitterGiveOutEnegy3D = new EmitterGiveOutEnegy3D(this.StageData, this.OriginalPosition, Color.White);
      this.StageData.SoundPlay("se_cat00.wav");
      this.StageData.VibrateStart(this.LifeTime - this.Time);
    }
  }
}
