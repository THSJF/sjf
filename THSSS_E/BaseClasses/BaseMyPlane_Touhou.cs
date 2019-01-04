// Decompiled with JetBrains decompiler
// Type: Shooting.BaseMyPlane_Touhou
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class BaseMyPlane_Touhou : BaseMyPlane
  {
    public float IndexX { get; set; }

    public int IndexY { get; set; }

    public BaseMyPlane_Touhou(StageDataPackage StageData, Point OriginalPosition, string Name)
    {
      this.StageData = StageData;
      this.OriginalPosition = (PointF) OriginalPosition;
      this.Name = Name;
      this.Region = 1;
      this.Time = this.UnmatchedTime;
      this.DeadTime = -1;
      this.SubPlanePoint = new PointF[4];
      string str1 = Name;
      int num = this.IndexY;
      string str2 = num.ToString();
      num = (int) this.IndexX;
      string str3 = num.ToString();
      this.TxtureObject = this.TextureObjectDictionary[str1 + str2 + str3];
      this.SpellEnabled = true;
      this.HighItemScore = 10000;
    }

    public override void TextureCtrl()
    {
      int indexY = this.IndexY;
      if ((double) this.Vx > 0.5)
      {
        this.IndexY = 2;
        if ((double) this.IndexX < 4.0)
          this.IndexX += 0.5f;
        else
          this.IndexX = (float) (4 + this.Time % 24 / 6);
      }
      else if ((double) this.Vx < -0.5)
      {
        this.IndexY = 1;
        if ((double) this.IndexX < 4.0)
          this.IndexX += 0.5f;
        else
          this.IndexX = (float) (4 + this.Time % 24 / 6);
      }
      else
      {
        this.IndexY = 0;
        this.IndexX = (float) (this.Time % 48 / 6);
      }
      if (indexY != this.IndexY)
        this.IndexX = 1f;
      if ((double) this.IndexX > 7.0)
        this.IndexX = 7f;
      string name = this.Name;
      int num = this.IndexY;
      string str1 = num.ToString();
      num = (int) this.IndexX;
      string str2 = num.ToString();
      this.TxtureObject = this.TextureObjectDictionary[name + str1 + str2];
    }

    public override void ShowCenter()
    {
      if (!this.SlowMove)
        return;
      MySprite spriteMain1 = this.SpriteMain;
      TextureObject textureObject1 = this.TextureObjectDictionary["SlowEffect01"];
      double num1 = -this.Direction * 4.0;
      PointF position1 = this.Position;
      double x1 = (double) position1.X;
      position1 = this.Position;
      double y1 = (double) position1.Y;
      PointF position2 = new PointF((float) x1, (float) y1);
      spriteMain1.Draw2D(textureObject1, 1f, (float) num1, position2, 120);
      MySprite spriteMain2 = this.SpriteMain;
      TextureObject textureObject2 = this.TextureObjectDictionary["SlowEffect01"];
      double num2 = this.Direction * 4.0;
      PointF position3 = this.Position;
      double x2 = (double) position3.X;
      position3 = this.Position;
      double y2 = (double) position3.Y;
      PointF position4 = new PointF((float) x2, (float) y2);
      spriteMain2.Draw2D(textureObject2, 1f, (float) num2, position4, 120);
      MySprite spriteMain3 = this.SpriteMain;
      TextureObject textureObject3 = this.TextureObjectDictionary["Center"];
      double num3 = this.Direction * 4.0;
      PointF position5 = this.Position;
      double x3 = (double) position5.X;
      position5 = this.Position;
      double y3 = (double) position5.Y;
      PointF position6 = new PointF((float) x3, (float) y3);
      Color white = Color.White;
      spriteMain3.Draw2D(textureObject3, 1f, (float) num3, position6, white);
    }

    public override void Miss()
    {
      double num1 = -2.27079631487397;
      for (int index = 0; index < 8; ++index)
      {
        PointF OriginalPosition = new PointF();
                ref PointF local = ref OriginalPosition;
        PointF originalPosition = this.OriginalPosition;
        double num2 = (double) (originalPosition.X + (float) (40.0 * Math.Cos(num1)));
        originalPosition = this.OriginalPosition;
        double num3 = (double) (originalPosition.Y + (float) (40.0 * Math.Sin(num1)));
        local = new PointF((float) num2, (float) num3);
        PowerItem_Touhou powerItemTouhou = new PowerItem_Touhou(this.StageData, OriginalPosition);
        powerItemTouhou.Direction = num1;
        powerItemTouhou.Velocity = 5f;
        num1 += 0.19999999659402;
      }
      base.Miss();
    }
  }
}
