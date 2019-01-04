// Decompiled with JetBrains decompiler
// Type: Shooting.EnchantmentMagicCircle
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class EnchantmentMagicCircle : BaseEffect
  {
    public EnchantmentMagicCircle(StageDataPackage StageData, PointF OriginalPosition)
      : base(StageData, (string) null, (PointF) new Point(0, 0), 0.0f, Math.PI / 2.0)
    {
      this.OriginalPosition = OriginalPosition;
      switch (this.MyPlane.EnchantmentState)
      {
        case EnchantmentType.Red:
          this.TxtureObject = this.TextureObjectDictionary["MC-R"];
          break;
        case EnchantmentType.Blue:
          this.TxtureObject = this.TextureObjectDictionary["MC-B"];
          break;
        case EnchantmentType.Green:
          this.TxtureObject = this.TextureObjectDictionary["MC-G"];
          break;
      }
      this.LifeTime = this.MyPlane.EnchantmentTime;
      this.TransparentValueF = 0.0f;
      this.TransparentVelocity = 20f;
      this.MaxTransparent = 160;
      this.AngularVelocityDegree = 5f;
      this.Active = true;
    }

    public override bool OutBoundary()
    {
      if (this.LifeTime != 0 && this.Time > this.LifeTime)
        return true;
      return this.MyPlane.EnchantmentState == EnchantmentType.None;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.OriginalPosition = this.MyPlane.OriginalPosition;
      this.Scale = (float) (0.200000002980232 + (double) this.MyPlane.EnchantmentTime * 1.5 / (double) this.LifeTime);
    }
  }
}
