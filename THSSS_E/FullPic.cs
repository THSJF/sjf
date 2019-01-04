// Decompiled with JetBrains decompiler
// Type: Shooting.FullPic
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class FullPic : BaseObject
  {
    public FullPic(StageDataPackage StageData, string textureName)
    {
      this.StageData = StageData;
      Rectangle boundRect = this.BoundRect;
      double num1 = (double) (boundRect.Left + 250);
      boundRect = this.BoundRect;
      double num2 = (double) (boundRect.Top + 150);
      this.Position = new PointF((float) num1, (float) num2);
      this.Velocity = 2f;
      this.Direction = Math.PI / 2.0;
      this.Active = false;
      this.LifeTime = 200;
      this.Accelerate = -0.025f;
      this.TxtureObject = this.TextureObjectDictionary[textureName];
      this.Background2.BackgroundList.Add((BaseObject) this);
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if ((double) this.Velocity < 0.0)
        this.Velocity = 0.0f;
      if (this.Time <= 40)
        return;
      this.TransparentVelocity = -5f;
    }
  }
}
