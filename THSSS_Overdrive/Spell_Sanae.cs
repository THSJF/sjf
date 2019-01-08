// Decompiled with JetBrains decompiler
// Type: Shooting.Spell_Sanae
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class Spell_Sanae : BaseSpell
  {
    public Spell_Sanae(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.Position = this.MyPlane.Position;
            this.Damage=0;// 36;
      this.Region = 4;
      this.LifeTime = 300;
      this.ScaleVelocity = 0.1f;
      this.MaxScale = 200f;
      BackgroundBlack backgroundBlack = new BackgroundBlack(StageData, this.Position);
      StageData.SoundPlay("se_cat00.wav");
      StageData.SoundPlay("se_nep00.wav");
      this.SpellList.Add((BaseObject) this);
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time == 1)
      {
        BaseEffect baseEffect1 = new BaseEffect(this.StageData, "球", this.Position, 0.0f, 0.0);
        baseEffect1.ScaleWidth = 0.05f;
        baseEffect1.ScaleLength = 0.05f;
        BaseEffect baseEffect2 = baseEffect1;
        baseEffect2.ScaleLengthVelocityDictionary.Add(1, 0.01666667f);
        baseEffect2.ScaleWidthVelocityDictionary.Add(1, 0.01666667f);
        baseEffect2.ScaleLengthVelocityDictionary.Add(120, 1.25f);
        baseEffect2.ScaleWidthVelocityDictionary.Add(120, 1.25f);
        baseEffect2.TransparentVelocityDictionary.Add(120, -10f);
        baseEffect2.AngularVelocityDegree = 10f;
      }
      else if (this.Time == 120)
      {
        this.StageData.SoundPlay("se_cat00.wav");
        EmitterGiveOutEnegy3D emitterGiveOutEnegy3D = new EmitterGiveOutEnegy3D(this.StageData, this.OriginalPosition, Color.Green);
        this.StageData.VibrateStart(this.LifeTime - this.Time);
        this.ScaleVelocity = 10f;
      }
      else if (120 < this.Time && this.Time <= 170)
      {
        this.AngularVelocityDegree = 2.5f;
        BaseEffect baseEffect1 = new BaseEffect(this.StageData, "bullet50_5", this.Position, 7f, this.Angle - Math.PI / 2.0);
        baseEffect1.ScaleLength = 15f;
        baseEffect1.ScaleWidth = 0.3f;
        BaseEffect baseEffect2 = new BaseEffect(this.StageData, "bullet50_5", this.Position, 7f, -1.0 * Math.PI / 2.0 - this.Angle);
        baseEffect2.ScaleLength = 15f;
        baseEffect2.ScaleWidth = 0.3f;
      }
      else
      {
        if (this.Time != 240)
          return;
        this.Damage = 0;
      }
    }
  }
}
