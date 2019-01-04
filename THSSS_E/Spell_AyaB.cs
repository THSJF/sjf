// Decompiled with JetBrains decompiler
// Type: Shooting.Spell_AyaB
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class Spell_AyaB : BaseSpell
  {
    private int Circle = 32;
    private bool Left = true;
    private PointF tmpPoint;
    private int tmpRegion;

    public Spell_AyaB(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.OriginalPosition = this.MyPlane.OriginalPosition;
      this.tmpPoint = this.MyPlane.OriginalPosition;
      this.LifeTime = 270;
      this.SpellList.Add((BaseObject) this);
      BaseEffect baseEffect = new BaseEffect(StageData, (string) null, this.Position, 0.0f, Math.PI / 2.0);
      baseEffect.TxtureObject = this.MyPlane.TxtureObject;
      baseEffect.TransparentVelocity = -20f;
      baseEffect.ScaleVelocity = 0.1f;
      BackgroundBlack backgroundBlack = new BackgroundBlack(StageData, this.Position);
      BackgroundMySC backgroundMySc1 = new BackgroundMySC(StageData, "76-4");
      backgroundMySc1.LifeTime = 350;
      backgroundMySc1.MaxTransparent = 180;
      backgroundMySc1.TransparentValueF = 0.0f;
      backgroundMySc1.TransparentVelocity = 4f;
      backgroundMySc1.ColorValue = Color.Green;
      BackgroundMySC backgroundMySc2 = new BackgroundMySC(StageData, "76-4");
      backgroundMySc2.LifeTime = 350;
      backgroundMySc2.MaxTransparent = 150;
      backgroundMySc2.TransparentValueF = 0.0f;
      backgroundMySc2.TransparentVelocity = 4f;
      backgroundMySc2.ColorValue = Color.Green;
      backgroundMySc2.AngularVelocityDegree = -0.5f;
      backgroundMySc2.Active = true;
      this.tmpRegion = this.MyPlane.Region;
      this.MyPlane.Region = -100;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time > 64 && this.Time <= 96)
        this.Circle = 16;
      else if (this.Time > 96 && this.Time <= 112)
        this.Circle = 8;
      if (this.Time % this.Circle == 0)
      {
        Spell_AyaB_Laser spellAyaBLaser = new Spell_AyaB_Laser(this.StageData, this.OriginalPosition, this.Left);
        if (this.Time <= 96)
        {
          StageDataPackage stageData = this.StageData;
          PointF position = spellAyaBLaser.Position;
          double num1 = (double) position.X + 360.0 * Math.Cos(spellAyaBLaser.Direction);
          position = spellAyaBLaser.Position;
          double num2 = (double) position.Y + 360.0 * Math.Sin(spellAyaBLaser.Direction);
          PointF Position = new PointF((float) num1, (float) num2);
          double velocity = (double) spellAyaBLaser.Velocity;
          double direction = spellAyaBLaser.Direction;
          BaseEffect baseEffect = new BaseEffect(stageData, "Ayaya", Position, (float) velocity, direction);
          baseEffect.Active = false;
          baseEffect.Mirrored = !this.Left;
          baseEffect.Scale = 1.5f;
          baseEffect.GhostingCount = 5;
        }
        this.Left = !this.Left;
        this.StageData.SoundPlay("se_tan01.wav");
        this.StageData.VibrateStart(8);
      }
      this.ItemList.ForEach((Action<BaseItem>) (x =>
      {
        x.Region = 1000;
        x.Doubled = true;
      }));
      if (this.Time != this.LifeTime)
        return;
      this.ItemList.ForEach((Action<BaseItem>) (x => x.Obtain = true));
      BaseEffect baseEffect1 = new BaseEffect(this.StageData, (string) null, this.MyPlane.Position, 0.0f, Math.PI / 2.0);
      baseEffect1.TxtureObject = this.MyPlane.TxtureObject;
      baseEffect1.Scale = 3f;
      baseEffect1.ScaleVelocity = -0.1f;
      baseEffect1.LifeTime = 20;
      baseEffect1.TransparentValueF = 0.0f;
      baseEffect1.TransparentVelocity = 10f;
      this.MyPlane.Region = this.tmpRegion;
    }

    public override void HitCheckAll()
    {
    }

    public override void Show()
    {
    }
  }
}
