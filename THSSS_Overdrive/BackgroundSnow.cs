// Decompiled with JetBrains decompiler
// Type: Shooting.BackgroundSnow
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class BackgroundSnow : BaseObject
  {
    public BackgroundSnow(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.Background.BackgroundList.Add((BaseObject) this);
    }

    public override void Ctrl()
    {
      ++this.Time;
      this.Shoot();
    }

    public override void Shoot()
    {
      if (this.Time % 20 != 0)
        return;
      for (int index = 0; index < 3; ++index)
      {
        StageDataPackage stageData = this.StageData;
        MyRandom ran1 = this.Ran;
        Rectangle boundRect = this.BoundRect;
        int left = boundRect.Left;
        boundRect = this.BoundRect;
        int right = boundRect.Right;
        double num1 = (double) ran1.Next(left, right);
        MyRandom ran2 = this.Ran;
        boundRect = this.BoundRect;
        int top = boundRect.Top;
        boundRect = this.BoundRect;
        int maxValue = boundRect.Bottom / 3;
        double num2 = (double) ran2.Next(top, maxValue);
        PointF Position = new PointF((float) num1, (float) num2);
        double num3 = (double) this.Ran.Next(10, 20) / 10.0;
        double Diretion = Math.PI / 2.0 + 0.5 * this.Ran.NextDouble();
        ParticleBack particleBack = new ParticleBack(stageData, "snow", Position, (float) num3, Diretion);
        particleBack.LifeTime = 200;
        particleBack.AngularVelocity = (float) this.Ran.Next(20) / 1000f;
        particleBack.Scale = (float) this.Ran.Next(2, 10) / 10f;
        particleBack.Active = true;
      }
    }

    public override void Show()
    {
    }
  }
}
