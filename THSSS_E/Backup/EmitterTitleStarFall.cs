// Decompiled with JetBrains decompiler
// Type: Shooting.EmitterTitleStarFall
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class EmitterTitleStarFall : BaseEffect
  {
    public EmitterTitleStarFall(StageDataPackage StageData)
      : base(StageData, (string) null, new PointF(0.0f, 0.0f), 0.0f, 0.0)
    {
      this.OriginalPosition = new PointF((float) (this.BoundRect.Width - 100), 0.0f);
    }

    public override void Shoot()
    {
      if (this.Time % 80 != 0)
        return;
      EmitterStarFall01 emitterStarFall01 = new EmitterStarFall01(this.StageData, new PointF(this.OriginalPosition.X + 50f + (float) this.Ran.Next(-200, 200), (float) this.Ran.Next(30)));
    }
  }
}
