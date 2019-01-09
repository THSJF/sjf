 
// Type: Shooting.EmitterStageTitleStar
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class EmitterStageTitleStar : BaseEffect
  {
    public EmitterStageTitleStar(StageDataPackage StageData)
      : base(StageData, (string) null, new PointF(0.0f, 0.0f), 0.0f, 0.0)
    {
      this.OriginalPosition = new PointF(0.0f, (float) (this.BoundRect.Height / 2 - 50));
      this.Velocity = 4f;
      this.MaxVelocity = 8f;
      this.AccelerateCS = 0.08f;
      this.AccDirection = 0.0;
    }

    public override void Shoot()
    {
      if (this.Time % 1 != 0)
        return;
      for (int index = 0; index < 4; ++index)
      {
        float num1 = (float) this.Ran.Next(0, 15);
        double num2 = (double) this.Ran.Next(360) * Math.PI / 180.0;
        PointF Position = new PointF();
                ref PointF local = ref Position;
        PointF originalPosition = this.OriginalPosition;
        double num3 = (double) originalPosition.X + (double) num1 * Math.Sin(num2);
        originalPosition = this.OriginalPosition;
        double num4 = (double) originalPosition.Y + (double) num1 * Math.Cos(num2);
        local = new PointF((float) num3, (float) num4);
        Particle particle = new Particle(this.StageData, "Star", Position, (float) this.StageData.Ran.Next(1, 110) / 100f, (double) this.Ran.Next(360) * Math.PI / 180.0);
        particle.Active = true;
        particle.Scale = (float) this.StageData.Ran.Next(15, 40) / 100f;
        particle.LifeTime = 80;
      }
    }
  }
}
