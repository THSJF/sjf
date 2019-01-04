// Decompiled with JetBrains decompiler
// Type: Shooting.MagicCircle
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class MagicCircle : BaseEffect
  {
    public MagicCircle(StageDataPackage StageData, string textureName)
      : base(StageData, textureName, new PointF(0.0f, 0.0f), 0.0f, 0.0)
    {
    }

    public override void Move()
    {
      if (this.Boss == null)
        return;
      this.OriginalPosition = this.Boss.OriginalPosition;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.Angle += 0.0199999995529652;
      this.Scale += (float) Math.Sin((double) this.Time * 3.0 / 180.0 * Math.PI) / 80f;
      this.TransparentValueF = (float) (100 + (int) (Math.Sin((double) this.Time * 2.0 / 180.0 * Math.PI) * 75.0));
    }

    public override bool OutBoundary()
    {
      return this.Boss == null;
    }
  }
}
