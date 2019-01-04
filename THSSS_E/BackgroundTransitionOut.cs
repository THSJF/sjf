// Decompiled with JetBrains decompiler
// Type: Shooting.BackgroundTransitionOut
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class BackgroundTransitionOut : BaseObject
  {
    public BackgroundTransitionOut(StageDataPackage StageData, int LifeTime)
      : base(StageData, "bullet21_7", new PointF(0.0f, 0.0f), 0.0f, 0.0)
    {
      this.Background.BackgroundList.Add((BaseObject) this);
      this.Position = new PointF((float) (StageData.BoundRect.X + StageData.BoundRect.Width / 2), (float) (StageData.BoundRect.Y + StageData.BoundRect.Height / 2));
      this.Scale = 30f;
      this.TransparentValueF = 0.0f;
      this.TransparentVelocity = (float) (this.MaxTransparent / LifeTime);
      this.LifeTime = LifeTime + 1000;
      this.ColorValue = Color.Black;
    }
  }
}
