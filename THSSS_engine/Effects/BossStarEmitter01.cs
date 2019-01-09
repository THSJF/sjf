 
// Type: Shooting.BossStarEmitter01
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class BossStarEmitter01 : BaseEffect
  {
    public int ColorType;

    public BossStarEmitter01(StageDataPackage StageData, PointF OriginalPosition)
      : base(StageData, (string) null, (PointF) new Point(0, 0), 0.0f, Math.PI / 2.0)
    {
      this.OriginalPosition = OriginalPosition;
      this.LifeTime = 130;
    }

    public override void Shoot()
    {
      if (this.Time % 1 != 0)
        return;
      for (int index = 0; index < 2; ++index)
      {
        float num1 = (float) this.Ran.Next(0, 15);
        double num2 = (double) this.Ran.Next(360) * Math.PI / 180.0;
        PointF Position = new PointF();
                ref PointF local = ref Position;
        PointF position = this.Position;
        double num3 = (double) position.X + (double) num1 * Math.Sin(num2);
        position = this.Position;
        double num4 = (double) position.Y + (double) num1 * Math.Cos(num2);
        local = new PointF((float) num3, (float) num4);
        Particle particle = new Particle(this.StageData, "Star0" + this.ColorType.ToString(), Position, (float) this.StageData.Ran.Next(1, 15) / 10f, this.Direction);
        particle.Scale = (float) this.StageData.Ran.Next(15, 40) / 100f;
        particle.MaxTransparent = (int) byte.MaxValue;
        particle.LifeTime = 40 + this.Ran.Next(60);
      }
    }
  }
}
