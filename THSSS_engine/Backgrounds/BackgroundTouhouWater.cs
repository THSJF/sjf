 
// Type: Shooting.BackgroundTouhouWater
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class BackgroundTouhouWater : BackgroundTouhouStage01_3D
  {
    public float V1 { get; set; }

    public BackgroundTouhouWater(StageDataPackage StageData, string textureName)
      : base(StageData, textureName)
    {
    }

    public override void Ctrl()
    {
      base.Ctrl();
      float v1 = this.V1;
      float num = 0.2f * (float) Math.Sin((double) (this.Time + 30) * Math.PI * 2.0 / 200.0);
      float x = this.OriginalPosition.X + v1;
      float y = this.OriginalPosition.Y + num;
      if ((double) x < -500.0)
        x += 1000f;
      else if ((double) x > 500.0)
        x -= 1000f;
      this.OriginalPosition = new PointF(x, y);
    }
  }
}
