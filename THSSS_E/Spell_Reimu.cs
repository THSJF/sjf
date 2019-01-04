// Decompiled with JetBrains decompiler
// Type: Shooting.Spell_Reimu
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class Spell_Reimu : BaseSpell
  {
    public Spell_Reimu(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.Position = this.MyPlane.Position;
      this.Damage = 40;
      this.Region = 64;
      this.LifeTime = 260;
      this.Scale = 0.0f;
      BackgroundBlack backgroundBlack = new BackgroundBlack(StageData, this.Position);
      EmitterGiveOutEnegy3D emitterGiveOutEnegy3D = new EmitterGiveOutEnegy3D(StageData, this.OriginalPosition, Color.FromArgb((int) byte.MaxValue, 100, 100));
      StageData.SoundPlay("se_cat00.wav");
      StageData.SoundPlay("se_nep00.wav");
      this.TxtureObject = this.TextureObjectDictionary["YINYANGYU"];
      this.Velocity = 2.2f;
      this.DirectionDegree = -90.0;
      this.AngularVelocityDegree = -3f;
      this.Accelerate = (float) (-(double) this.Velocity / 210.0);
      this.SpellList.Add((BaseObject) this);
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (1 < this.Time && this.Time < 50)
        this.ScaleVelocity += 0.0004f;
      else if (150 < this.Time && this.Time < 240)
        this.ScaleVelocity -= 0.0004f;
      else if (this.Time == 240)
        this.ScaleVelocity = (float) (-(double) this.Scale / 20.0);
      else if (this.Time == 260)
        this.ScaleVelocity = 0.0f;
      if (this.Time == 22)
        this.StageData.VibrateStart(this.LifeTime - this.Time);
      if (this.Time == 260)
      {
        EmitterGiveOutEnegy3D emitterGiveOutEnegy3D1 = new EmitterGiveOutEnegy3D(this.StageData, this.OriginalPosition, Color.FromArgb(150, 150, (int) byte.MaxValue));
        EmitterGiveOutEnegy3D emitterGiveOutEnegy3D2 = new EmitterGiveOutEnegy3D(this.StageData, this.OriginalPosition, Color.FromArgb(150, 150, (int) byte.MaxValue));
        EmitterGiveOutEnegy3D emitterGiveOutEnegy3D3 = new EmitterGiveOutEnegy3D(this.StageData, this.OriginalPosition, Color.FromArgb(150, 150, (int) byte.MaxValue));
        this.StageData.SoundPlay("se_cat00.wav");
      }
      if (this.Time % 12 != 0)
        return;
      int num1 = 60;
      double num2 = 360.0 / (double) num1;
      float Velocity = this.Time < 150 ? (float) (2.0 + (double) this.Time * 4.0 / 150.0) : 6f;
      for (int index = 0; index < num1; ++index)
      {
        BaseEffect baseEffect1 = new BaseEffect(this.StageData, "yuan_9", this.Position, Velocity, 0.0);
        baseEffect1.DirectionDegree = num2 * (double) index;
        baseEffect1.ScaleWidth = 0.4f;
        baseEffect1.ScaleLength = 0.13f;
        baseEffect1.LifeTime = 60;
        baseEffect1.TransparentValueF = 0.0f;
        baseEffect1.ColorValue = Color.FromArgb(100, 100, 200);
        BaseEffect baseEffect2 = baseEffect1;
        baseEffect2.AccelerateDictionary.Add(1, (float) (-((double) Velocity - 0.5) / 50.0));
        baseEffect2.AccelerateDictionary.Add(50, 0.0f);
        baseEffect2.ScaleWidthVelocityDictionary.Add(1, 0.01f);
        baseEffect2.ScaleWidthVelocityDictionary.Add(50, 0.0f);
        baseEffect2.ScaleLengthVelocityDictionary.Add(1, (float) (-(double) baseEffect2.ScaleLength / 50.0));
        baseEffect2.ScaleLengthVelocityDictionary.Add(50, 0.0f);
        baseEffect2.TransparentVelocityDictionary.Add(1, 1f);
        baseEffect2.TransparentVelocityDictionary.Add(60, 0.0f);
      }
    }

    public override void Show()
    {
      base.Show();
      this.SpriteMain.Draw2D(this.TextureObjectDictionary["bullet50_3"], (float) ((double) this.ScaleWidth * 0.129999995231628 / 0.0399999991059303), (float) ((double) this.ScaleLength * 0.129999995231628 / 0.0399999991059303), 0.0f, this.Position, Color.FromArgb(76, this.ColorValue), this.Mirrored);
    }
  }
}
