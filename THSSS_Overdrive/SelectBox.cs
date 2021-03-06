﻿// Decompiled with JetBrains decompiler
// Type: Shooting.SelectBox
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX.Direct3D9;
using System.Drawing;

namespace Shooting
{
  internal class SelectBox : BaseEffect
  {
    public SelectBox(StageDataPackage StageData)
      : base(StageData)
    {
      this.TxtureObject = this.TextureObjectDictionary["selectframe2"];
    }

    public override void Show()
    {
      MySprite spriteMain = this.SpriteMain;
      Texture txTure = this.TxtureObject.TXTure;
      PointF originalPosition1 = this.OriginalPosition;
      int x = (int) originalPosition1.X;
      originalPosition1 = this.OriginalPosition;
      int y = (int) originalPosition1.Y;
      Rectangle srcRectangle = new Rectangle(x, y, 512, 22);
      SizeF destinationSize = new SizeF(512f, 22f);
      PointF rotationCenter = new PointF(0.0f, 0.0f);
      PointF originalPosition2 = this.OriginalPosition;
      Color white = Color.White;
      spriteMain.Draw2D(txTure, srcRectangle, destinationSize, rotationCenter, 0.0f, originalPosition2, white);
    }
  }
}
