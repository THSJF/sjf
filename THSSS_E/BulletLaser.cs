// Decompiled with JetBrains decompiler
// Type: Shooting.BulletLaser
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class BulletLaser : BaseBullet
  {
    public float DesScaleWidth { get; set; }

    public float DesScaleLength { get; set; }

    public BulletLaser(
      StageDataPackage StageData,
      string textureName,
      PointF OriginalPosition,
      float Velocity,
      double Direction)
      : base(StageData, textureName, OriginalPosition, Velocity, Direction)
    {
      this.ScaleLength = 0.1f;
      this.DesScaleLength = 3f;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if ((double) this.ScaleLength > (double) this.DesScaleLength)
        return;
      this.ScaleLength += 0.02f;
    }

    public override bool HitCheck(BaseObject MyPlane)
    {
      double distance = this.GetDistance(MyPlane);
      double direction = this.GetDirection(MyPlane);
      double num1 = distance * Math.Cos(this.Direction - direction);
      double num2 = distance * Math.Sin(this.Direction - direction);
      double num3 = (double) this.Region * (double) this.ScaleWidth;
      double num4 = (double) this.TxtureObject.Height * (double) this.ScaleLength * 0.449999988079071;
      return num2 * num2 / num3 / num3 + (num1 - (double) this.TxtureObject.Height * (double) this.ScaleLength / 2.0) * (num1 - (double) this.TxtureObject.Height * (double) this.ScaleLength / 2.0) / num4 / num4 < 1.0;
    }

    public override void GiveItems()
    {
    }

    public override void Show()
    {
      if (this.TxtureObject == null)
        return;
      this.SpriteMain.Draw2D(this.TxtureObject.TXTure, this.TxtureObject.PosRect, new SizeF((float) this.TxtureObject.Width * this.ScaleWidth, (float) this.TxtureObject.Height * this.ScaleLength), new PointF((float) (this.TxtureObject.Width / 2), 0.0f), (float) (this.Direction - Math.PI / 2.0 + this.Angle), this.Position, Color.FromArgb(this.TransparentValue, this.ColorValue));
    }

    public override void ShowRegion()
    {
      PointF originalPosition1 = this.OriginalPosition;
      PointF originalPosition2 = this.OriginalPosition;
      double num1 = (double) originalPosition2.X + (double) this.TxtureObject.Height * (double) this.ScaleLength * 0.5 * Math.Cos(this.Direction);
      originalPosition2 = this.OriginalPosition;
      double num2 = (double) originalPosition2.Y + (double) this.TxtureObject.Height * (double) this.ScaleLength * 0.5 * Math.Sin(this.Direction);
      this.OriginalPosition = new PointF((float) num1, (float) num2);
      this.SpriteMain.Draw2D(this.TextureObjectDictionary["Region"], 2f * (float) this.Region / (float) this.TextureObjectDictionary["Region"].Width * this.ScaleWidth, (float) this.TxtureObject.Height * 0.9f / (float) this.TextureObjectDictionary["Region"].Height * this.ScaleLength, (float) (this.Direction - Math.PI / 2.0 + this.Angle), this.Position, Color.White, this.Mirrored);
      this.OriginalPosition = originalPosition1;
    }
  }
}
