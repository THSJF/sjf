 
// Type: Shooting.ParticleColored
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class ParticleColored : BaseEffect
  {
    private Color color;

    public ParticleColored(
      StageDataPackage StageData,
      string textureName,
      PointF Position,
      float Velocity,
      double Direction)
      : base(StageData, textureName, Position, Velocity, Direction)
    {
      switch (this.Ran.Next(7))
      {
        case 0:
          this.color = Color.BlueViolet;
          break;
        case 1:
          this.color = Color.CadetBlue;
          break;
        case 2:
          this.color = Color.DarkBlue;
          break;
        case 3:
          this.color = Color.Green;
          break;
        case 4:
          this.color = Color.SkyBlue;
          break;
        case 5:
          this.color = Color.Blue;
          break;
        case 6:
          this.color = Color.CornflowerBlue;
          break;
        default:
          this.color = Color.White;
          break;
      }
      this.TransparentValueF = 150f;
      this.Scale = 2f;
      this.LifeTime = 50;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Direction <= Math.PI)
        return;
      double num = Math.PI / 2.0 + this.Direction;
      if (num > Math.PI)
        num -= 2.0 * Math.PI;
      this.Direction -= num / 5.0;
    }

    public override void Show()
    {
      this.SpriteMain.Draw2D(this.TxtureObject.TXTure, this.TxtureObject.PosRect, new SizeF((float) this.TxtureObject.Width * this.Scale, (float) this.TxtureObject.Height * this.Scale), this.TxtureObject.RotatingCenter, 0.0f, this.Position, Color.FromArgb(this.TransparentValue, this.color));
    }
  }
}
