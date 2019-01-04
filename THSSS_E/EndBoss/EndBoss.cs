// Decompiled with JetBrains decompiler
// Type: Shooting.EndBoss
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class EndBoss : BaseEffect
  {
    public EndBoss(StageDataPackage StageData)
      : base(StageData)
    {
      this.LifeTime = 200;
    }

    public override void Move()
    {
      if (this.Boss == null)
        return;
      this.Position = this.Boss.Position;
    }

    public override void Shoot()
    {
      if (this.Time == 1)
      {
        this.StageData.SoundPlay("se_enep01.wav");
        for (int index = 0; index < 16; ++index)
        {
          ParticleSmaller particleSmaller = new ParticleSmaller(this.StageData, "光点", this.Position, (float) (2.0 + (double) this.Ran.Next(30) / 10.0), (double) this.Ran.Next(360) / 180.0 * Math.PI);
          particleSmaller.Scale = (float) this.Ran.Next(10, 20) / 10f;
          particleSmaller.ColorValue = Color.FromArgb((int) byte.MaxValue, this.Ran.Next(20, 240), this.Ran.Next(200, (int) byte.MaxValue));
        }
        this.StageData.VibrateStart(50);
      }
      else if (this.Time == 100)
      {
        this.StageData.SoundPlay("se_enep01.wav");
        for (int index = 0; index < 60; ++index)
        {
          ParticleSmaller particleSmaller = new ParticleSmaller(this.StageData, "光点", this.Position, (float) (1.0 + (double) this.Ran.Next(50) / 10.0), (double) this.Ran.Next(360) / 180.0 * Math.PI);
          particleSmaller.Scale = (float) this.Ran.Next(10, 20) / 10f;
          particleSmaller.ColorValue = Color.FromArgb((int) byte.MaxValue, this.Ran.Next(20, 240), this.Ran.Next(220, (int) byte.MaxValue));
        }
        this.StageData.VibrateStart(50);
        this.MyBulletList.Clear();
        this.Boss = (BaseBossTouhou) null;
      }
      else
      {
        if (this.Time != 250)
          return;
        EndStage endStage = new EndStage(this.StageData, "在世界的某个角落", true);
        TransitionOut transitionOut = new TransitionOut(this.StageData);
        try
        {
          INI_RW iniRw = new INI_RW(".\\Setting.INI");
          if (iniRw.ExistINIFile())
            iniRw.IniWriteValue("Mode", "Clear", "yes");
        }
        catch
        {
        }
      }
    }

    public override void Show()
    {
    }
  }
}
