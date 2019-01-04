// Decompiled with JetBrains decompiler
// Type: Shooting.Background3DParticle
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class Background3DParticle : Background3DObject
  {
    private double tr;

    public Background3DParticle(
      StageDataPackage StageData,
      string modelName,
      PointF OriginalPosition,
      bool InsertAtFirst)
      : base(StageData, modelName, OriginalPosition, InsertAtFirst)
    {
    }

    public override void Show()
    {
      float transparentValueF = this.TransparentValueF;
      this.tr = 50.0 * Math.Sin((double) this.Time / 2.0);
      this.TransparentValueF += (float) (int) this.tr;
      base.Show();
      this.TransparentValueF = transparentValueF;
    }
  }
}
