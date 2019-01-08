// Decompiled with JetBrains decompiler
// Type: Shooting.EndBoss_Touhou_Small
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using System.Drawing;

namespace Shooting
{
  internal class EndBoss_Touhou_Small : EndBoss_Touhou
  {
    public EndBoss_Touhou_Small(
      StageDataPackage StageData,
      PointF OriginalPosition,
      Color Color1,
      Color Color2)
      : base(StageData, OriginalPosition, Color1, Color2)
    {
    }

    public EndBoss_Touhou_Small(StageDataPackage StageData)
      : base(StageData)
    {
    }

    public override void Shoot()
    {
      if (this.Time != 1)
        return;
      this.StageData.SoundPlay("se_enep01.wav", this.OriginalPosition.X / (float) this.BoundRect.Width);
      for (int index = 0; index < 40; ++index)
      {
        Particle3D2 particle3D2 = new Particle3D2(this.StageData, "Effect-1", this.OriginalPosition, (float) this.Ran.Next(50, 70) / 10f, (double) this.Ran.Next(360) / 180.0 * 3.14159274101257, 30 + this.StageData.Ran.Next(50));
        particle3D2.Direction3D = (double) this.StageData.Ran.Next(0, 90) * 3.14159274101257 / 180.0;
        particle3D2.Angle = (double) this.StageData.Ran.Next(0, 360) * 3.14159274101257 / 180.0;
        particle3D2.AngularVelocity3D = (float) this.StageData.Ran.Next(10, 18) / 100f;
        particle3D2.Scale = (float) this.StageData.Ran.Next(30, 40) / 10f;
        particle3D2.RotatingAxis = new Vector3((float) this.StageData.Ran.Next(-100, 100), (float) this.StageData.Ran.Next(-100, 100), (float) this.StageData.Ran.Next(-100, 100));
        particle3D2.ColorValue = Color.FromArgb(this.Ran.Next(this.R1, this.R2), this.Ran.Next(this.G1, this.G2), this.Ran.Next(this.B1, this.B2));
      }
      this.StageData.VibrateStart(90);
      this.Boss = (BaseBossTouhou) null;
    }

    public override void Show()
    {
    }
  }
}
