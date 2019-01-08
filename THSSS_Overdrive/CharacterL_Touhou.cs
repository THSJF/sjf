// Decompiled with JetBrains decompiler
// Type: Shooting.CharacterL_Touhou
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class CharacterL_Touhou : CharacterR_Touhou
  {
    public CharacterL_Touhou(StageDataPackage StageData, string textureName)
      : base(StageData, textureName)
    {
      this.OriginalPosition = new PointF(70f, 128f);
    }

    public override void Move()
    {
      if (this.Active)
      {
        if ((double) this.OriginalPosition.X >= 100.0)
          return;
        PointF originalPosition = this.OriginalPosition;
        double num = (double) originalPosition.X + 2.0;
        originalPosition = this.OriginalPosition;
        double y = (double) originalPosition.Y;
        this.OriginalPosition = new PointF((float) num, (float) y);
      }
      else if ((double) this.OriginalPosition.X > 70.0)
      {
        PointF originalPosition = this.OriginalPosition;
        double num = (double) originalPosition.X - 2.0;
        originalPosition = this.OriginalPosition;
        double y = (double) originalPosition.Y;
        this.OriginalPosition = new PointF((float) num, (float) y);
      }
    }
  }
}
