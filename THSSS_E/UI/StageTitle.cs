// Decompiled with JetBrains decompiler
// Type: Shooting.StageTitle
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class StageTitle : BaseEffect
  {
    public StageTitle(StageDataPackage StageData, string TextureName)
      : base(StageData, TextureName, (PointF) new Point(0, 0), 0.0f, Math.PI / 2.0)
    {
      Rectangle boundRect = this.BoundRect;
      double num1 = (double) (boundRect.Width / 2);
      boundRect = this.BoundRect;
      double num2 = (double) (boundRect.Height / 2 - 80);
      this.OriginalPosition = new PointF((float) num1, (float) num2);
      this.LifeTime = 200;
      this.TransparentValueF = 0.0f;
      this.Active = false;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time < this.LifeTime / 3)
      {
        this.TransparentValueF += (float) (this.MaxTransparent * 3 / this.LifeTime);
      }
      else
      {
        if (this.Time <= this.LifeTime * 2 / 3)
          return;
        this.TransparentValueF -= (float) (this.MaxTransparent * 3 / this.LifeTime);
      }
    }
  }
}
