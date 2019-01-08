 
// Type: Shooting.Planes.Story.StoryStar
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting.Planes.Story
{
  internal class StoryStar : BaseObject
  {
    private int Tran;

    public StoryStar(
      StageDataPackage StageData,
      string textureName,
      PointF Position,
      float Velocity,
      double Direction)
      : base(StageData, textureName, Position, Velocity, Direction)
    {
      this.TransparentValueF = 180f;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time > 10)
        this.TransparentValueF -= 5f;
      this.Tran = this.TransparentValue + (int) (80.0 * Math.Sin((double) this.Time * 33.0 / 180.0 * Math.PI));
      if (this.Tran < 0)
      {
        this.Tran = 0;
      }
      else
      {
        if (this.Tran <= (int) byte.MaxValue)
          return;
        this.Tran = (int) byte.MaxValue;
      }
    }

    public override void Show()
    {
      this.SpriteMain.Draw2D(this.TxtureObject.TXTure, this.TxtureObject.PosRect, new SizeF((float) this.TxtureObject.Width * this.Scale, (float) this.TxtureObject.Height * this.Scale), this.TxtureObject.RotatingCenter, 0.0f, this.Position, Color.FromArgb(this.Tran, Color.White));
    }
  }
}
