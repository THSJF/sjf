 
// Type: Shooting.BackgroundQB
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class BackgroundQB : BaseObject
  {
    public BackgroundQB(StageDataPackage StageData, string textureName)
      : base(StageData, textureName, new PointF(0.0f, 0.0f), 0.0f, Math.PI / 2.0)
    {
      this.Background.BackgroundList.Add((BaseObject) this);
      this.OriginalPosition = new PointF((float) (this.BoundRect.Width / 2), 200f);
      this.TransparentValueF = 0.0f;
      this.Scale = 0.9f;
    }

    public override void Ctrl()
    {
      ++this.Time;
      if ((double) this.TransparentValueF >= 200.0)
        return;
      this.TransparentValueF += 5f;
    }
  }
}
