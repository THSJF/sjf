// Decompiled with JetBrains decompiler
// Type: Shooting.SCMenuItem
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class SCMenuItem : DescriptionMenuItem
  {
    public int OffX = 50;
    public int OffY = -5;

    public SCMenuItem(StageDataPackage StageData, string Name)
      : base(StageData, Name)
    {
    }

    public override void Show()
    {
      base.Show();
      if (this.TxtureObject == null)
        return;
      MySprite spriteMain = this.SpriteMain;
      TextureObject txtureObject = this.TxtureObject;
      double scaleWidth = (double) this.ScaleWidth;
      double scaleLength = (double) this.ScaleLength;
      PointF position1 = this.Position;
      double num1 = (double) position1.X + (double) this.TxtureObject.Width * (double) this.Scale / 2.0 + (double) this.OffX;
      position1 = this.Position;
      double num2 = (double) position1.Y + (double) this.OffY + (double) this.TxtureObject.Height * (double) this.Scale / 2.0;
      PointF position2 = new PointF((float) num1, (float) num2);
      Color color = Color.FromArgb(this.TransparentValue, this.ColorValue);
      int num3 = this.Mirrored ? 1 : 0;
      spriteMain.Draw2D(txtureObject, (float) scaleWidth, (float) scaleLength, 0.0f, position2, color, num3 != 0);
    }
  }
}
