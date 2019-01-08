 
// Type: Shooting.BackgroundYoumu
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class BackgroundYoumu : BackgroundRotate
  {
    private double[] lastAngle = new double[10];
    private float sc;

    public BackgroundYoumu(StageDataPackage StageData, string textureName)
      : base(StageData, textureName)
    {
    }

    public override void Ctrl()
    {
      base.Ctrl();
      for (int index = this.lastAngle.Length - 1; index > 0; --index)
        this.lastAngle[index] = this.lastAngle[index - 1];
      this.lastAngle[0] = this.Angle;
      if (this.StageData.SlowMode > 0)
      {
        this.Active = true;
        this.ColorValue = Color.Pink;
        this.AngularVelocityDegree = 1f;
      }
      else
      {
        this.Active = false;
        this.ColorValue = Color.White;
        this.sc = (float) Math.Sin((double) this.Time / 103.5 * Math.PI * 2.0) / 16f;
        this.Scale = 2.5f + this.sc;
        this.AngularVelocityDegree = -0.5f;
      }
    }

    public override void Show()
    {
      if (this.StageData.SlowMode > 0)
      {
        double angle = this.Angle;
        int transparentValue = this.TransparentValue;
        for (int index = this.lastAngle.Length - 1; index >= 0; index -= 2)
        {
          this.Angle = this.lastAngle[index];
          this.TransparentValueF = (float) (transparentValue * (this.lastAngle.Length - index + 15) / (this.lastAngle.Length + 1 + 15));
          base.Show();
        }
        this.Angle = angle;
        this.TransparentValueF = (float) transparentValue;
      }
      base.Show();
    }
  }
}
