// Decompiled with JetBrains decompiler
// Type: Shooting.EndBoss_Touhou
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using System;
using System.Drawing;

namespace Shooting
{
  internal class EndBoss_Touhou : BaseEffect
  {
    public int R1;
    public int R2;
    public int G1;
    public int G2;
    public int B1;
    public int B2;

    public EndBoss_Touhou(
      StageDataPackage StageData,
      PointF OriginalPosition,
      Color Color1,
      Color Color2)
      : this(StageData)
    {
      this.OriginalPosition = OriginalPosition;
      this.R2 = (int) Math.Max(Color1.R, Color2.R);
      this.R1 = (int) Math.Min(Color1.R, Color2.R);
      this.G2 = (int) Math.Max(Color1.G, Color2.G);
      this.G1 = (int) Math.Min(Color1.G, Color2.G);
      this.B2 = (int) Math.Max(Color1.B, Color2.B);
      this.B1 = (int) Math.Min(Color1.B, Color2.B);
    }

    public EndBoss_Touhou(StageDataPackage StageData)
      : base(StageData)
    {
      this.LifeTime = 250;
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
        this.StageData.SoundPlay("se_enep01.wav", this.OriginalPosition.X / (float) this.BoundRect.Width);
        for (int index = 0; index < 20; ++index)
        {
          Particle3D2 particle3D2 = new Particle3D2(this.StageData, "Effect-1", this.OriginalPosition, (float) this.Ran.Next(10, 80) / 10f, (double) this.Ran.Next(360) / 180.0 * 3.14159274101257, 30 + this.StageData.Ran.Next(50));
          particle3D2.Direction3D = (double) this.StageData.Ran.Next(0, 30) * 3.14159274101257 / 180.0;
          particle3D2.Angle = (double) this.StageData.Ran.Next(0, 360) * 3.14159274101257 / 180.0;
          particle3D2.AngularVelocity3D = (float) this.StageData.Ran.Next(10, 18) / 100f;
          particle3D2.Scale = (float) this.StageData.Ran.Next(30, 40) / 10f;
          particle3D2.RotatingAxis = new Vector3((float) this.StageData.Ran.Next(-100, 100), (float) this.StageData.Ran.Next(-100, 100), (float) this.StageData.Ran.Next(-100, 100));
          particle3D2.ColorValue = Color.FromArgb(this.Ran.Next(this.R1, this.R2), this.Ran.Next(this.G1, this.G2), this.Ran.Next(this.B1, this.B2));
        }
        this.StageData.VibrateStart(50);
      }
      else
      {
        if (this.Time != 100)
          return;
        this.StageData.SoundPlay("se_enep01.wav", this.OriginalPosition.X / (float) this.BoundRect.Width);
        for (int index = 0; index < 80; ++index)
        {
          Particle3D2 particle3D2 = new Particle3D2(this.StageData, "Effect-1", this.OriginalPosition, (float) this.Ran.Next(10, 140) / 10f, (double) this.Ran.Next(360) / 180.0 * 3.14159274101257, 30 + this.StageData.Ran.Next(50));
          particle3D2.Direction3D = (double) this.StageData.Ran.Next(0, 30) * 3.14159274101257 / 180.0;
          particle3D2.Angle = (double) this.StageData.Ran.Next(0, 360) * 3.14159274101257 / 180.0;
          particle3D2.AngularVelocity3D = (float) this.StageData.Ran.Next(10, 18) / 100f;
          particle3D2.Scale = (float) this.StageData.Ran.Next(30, 40) / 10f;
          particle3D2.RotatingAxis = new Vector3((float) this.StageData.Ran.Next(-100, 100), (float) this.StageData.Ran.Next(-100, 100), (float) this.StageData.Ran.Next(-100, 100));
          particle3D2.ColorValue = Color.FromArgb(this.Ran.Next(this.R1, this.R2), this.Ran.Next(this.G1, this.G2), this.Ran.Next(this.B1, this.B2));
        }
        this.StageData.VibrateStart(90);
        this.Boss = (BaseBossTouhou) null;
      }
    }

    public override void Show()
    {
    }
  }
}
