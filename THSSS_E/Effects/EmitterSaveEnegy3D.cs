 
// Type: Shooting.EmitterSaveEnegy3D
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using System;
using System.Drawing;

namespace Shooting
{
  internal class EmitterSaveEnegy3D : BaseEffect
  {
    public EmitterSaveEnegy3D(StageDataPackage StageData, PointF OriginalPosition, Color color)
      : base(StageData)
    {
      this.OriginalPosition = OriginalPosition;
      this.Velocity = 0.0f;
      this.Direction = 0.0;
      this.LifeTime = 25;
      this.ColorValue = color;
      BaseEffect baseEffect = new BaseEffect(StageData, "Effect-2", this.Position, 0.0f, 0.0);
      baseEffect.LifeTime = 50;
      baseEffect.Scale = 14f;
      baseEffect.ScaleVelocity = -0.25f;
      baseEffect.ColorValue = color;
      baseEffect.TransparentValueF = 0.0f;
      baseEffect.TransparentVelocity = 6f;
      baseEffect.MaxTransparent = 128;
    }

    public override void Shoot()
    {
      if (this.Time % 2 != 0)
        return;
      for (int index = 0; index < 2; ++index)
      {
        double num1 = (double) this.Ran.Next(360) / 180.0 * Math.PI;
        int num2 = this.Ran.Next(150, 200);
        Particle3D1 particle3D1_1 = new Particle3D1(this.StageData, "Effect-1", new PointF(this.OriginalPosition.X + (float) num2 * (float) Math.Cos(num1), this.OriginalPosition.Y + (float) num2 * (float) Math.Sin(num1)), 0.0f, num1 + Math.PI, this.Ran.Next(50, 80));
        particle3D1_1.Angle = (double) this.StageData.Ran.Next(0, 360) * 3.14159274101257 / 180.0;
        particle3D1_1.AngularVelocity3D = (float) this.StageData.Ran.Next(10, 18) / 100f;
        particle3D1_1.Scale = (float) this.StageData.Ran.Next(30, 40) / 10f;
        particle3D1_1.RotatingAxis = new Vector3((float) this.StageData.Ran.Next(-100, 100), (float) this.StageData.Ran.Next(-100, 100), (float) this.StageData.Ran.Next(-100, 100));
        particle3D1_1.ColorValue = this.ColorValue;
        Particle3D1 particle3D1_2 = particle3D1_1;
        particle3D1_2.Velocity = 2f * (float) num2 / (float) particle3D1_2.LifeTime;
        particle3D1_2.Accelerate = -particle3D1_2.Velocity * particle3D1_2.Velocity / (float) (2 * num2);
        particle3D1_2.LifeTime -= 15;
      }
    }

    public override void Show()
    {
    }
  }
}
