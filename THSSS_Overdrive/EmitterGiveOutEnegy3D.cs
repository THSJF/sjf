// Decompiled with JetBrains decompiler
// Type: Shooting.EmitterGiveOutEnegy3D
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using System.Drawing;

namespace Shooting
{
  internal class EmitterGiveOutEnegy3D : BaseEffect
  {
    public EmitterGiveOutEnegy3D(StageDataPackage StageData, PointF OriginalPosition, Color color)
      : base(StageData)
    {
      this.OriginalPosition = OriginalPosition;
      this.Velocity = 0.0f;
      this.Direction = 0.0;
      this.LifeTime = 25;
      this.ColorValue = color;
      BaseEffect baseEffect = new BaseEffect(StageData, "Effect-2", this.Position, 0.0f, 0.0);
      baseEffect.LifeTime = 100;
      baseEffect.Scale = 1f;
      baseEffect.ScaleVelocity = 0.8f;
      baseEffect.ColorValue = color;
      baseEffect.TransparentValueF = 180f;
      baseEffect.TransparentVelocity = -2f;
    }

    public override void Shoot()
    {
      if (this.Time != 1)
        return;
      for (int index = 0; index < 50; ++index)
      {
        Particle3D1 particle3D1 = new Particle3D1(this.StageData, "Effect-1", this.OriginalPosition, (float) this.Ran.Next(50, 130) / 10f, (double) this.Ran.Next(360) / 180.0 * 3.14159274101257, 30 + this.StageData.Ran.Next(50));
        particle3D1.Direction3D = (double) this.StageData.Ran.Next(0, 60) * 3.14159274101257 / 180.0;
        particle3D1.Angle = (double) this.StageData.Ran.Next(0, 360) * 3.14159274101257 / 180.0;
        particle3D1.AngularVelocity3D = (float) this.StageData.Ran.Next(10, 18) / 100f;
        particle3D1.Scale = (float) this.StageData.Ran.Next(20, 30) / 10f;
        particle3D1.RotatingAxis = new Vector3((float) this.StageData.Ran.Next(-100, 100), (float) this.StageData.Ran.Next(-100, 100), (float) this.StageData.Ran.Next(-100, 100));
        particle3D1.ColorValue = this.ColorValue;
      }
    }

    public override void Show()
    {
    }
  }
}
