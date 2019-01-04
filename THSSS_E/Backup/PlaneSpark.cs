// Decompiled with JetBrains decompiler
// Type: Shooting.PlaneSpark
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class PlaneSpark : BaseEffect
  {
    public PlaneSpark(
      StageDataPackage StageData,
      string textureName,
      PointF OriginalPosition,
      float Velocity,
      double Direction)
      : base(StageData, textureName, OriginalPosition, Velocity, Direction)
    {
      this.OriginalPosition = OriginalPosition;
      this.ScaleWidth = 0.05f;
      this.Active = true;
      this.LifeTime = 300;
      this.ColorValue = Color.FromArgb(85, 140, (int) byte.MaxValue);
      this.UnRemoveable = true;
      this.Angle = 0.0;
      this.ScaleVL = 0.1f;
      this.ScaleVW = 0.1f;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.Region = (int) ((double) this.TxtureObject.Width / 2.0 * 0.699999988079071);
      if (this.Time < this.LifeTime - 50)
        this.TransparentValueF = (float) (150 + this.Ran.Next(40));
      else
        this.TransparentValueF = (float) ((this.LifeTime - this.Time) * 2 - 20 + this.Ran.Next(40));
    }

    public override void Show()
    {
      if (this.TxtureObject == null)
        return;
      this.SpriteMain.Draw2D(this.TxtureObject.TXTure, this.TxtureObject.PosRect, new SizeF((float) this.TxtureObject.Width * this.ScaleWidth, (float) this.TxtureObject.Height * this.ScaleLength), new PointF((float) (this.TxtureObject.Width / 2), 0.0f), (float) (this.Direction - Math.PI / 2.0 + this.Angle), this.Position, Color.FromArgb(this.TransparentValue, this.ColorValue));
    }
  }
}
