// Decompiled with JetBrains decompiler
// Type: Shooting.StarPointLineB
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class StarPointLineB : StarPointLineG
  {
    public StarPointLineB(StageDataPackage StageData, PointF OriginalPosition)
      : base(StageData, OriginalPosition)
    {
      this.type = "A";
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.MyPlane.LastColor == EnchantmentType.Blue && this.Story == null)
        this.DestPoint = new PointF(66f, 404f);
      else
        this.DestPoint = new PointF(-6f, 404f);
      this.Velocity = 3f;
    }
  }
}
