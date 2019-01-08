// Decompiled with JetBrains decompiler
// Type: Shooting.Spell
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class Spell : BaseSpell
  {
    public Spell(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.Position = this.MyPlane.Position;
      this.Damage = 10;
      this.LifeTime = 300;
      this.SpellList.Add((BaseObject) this);
      StageData.VibrateStart(this.LifeTime);
      BackgroundBlack backgroundBlack = new BackgroundBlack(StageData, this.Position);
    }

    public override void Move()
    {
      this.Position = this.MyPlane.Position;
    }

    public override bool HitCheck(BaseObject Enemy)
    {
      PointF position1 = Enemy.Position;
      double y = (double) position1.Y;
      position1 = this.Position;
      double num1 = (double) position1.Y + 5.0;
      int num2;
      if (y < num1)
      {
        PointF position2 = this.Position;
        double num3 = (double) position2.X - 140.0;
        position2 = Enemy.Position;
        double x1 = (double) position2.X;
        if (num3 < x1)
        {
          position2 = Enemy.Position;
          double x2 = (double) position2.X;
          position2 = this.Position;
          double num4 = (double) position2.X + 140.0;
          num2 = x2 >= num4 ? 1 : 0;
          goto label_4;
        }
      }
      num2 = 1;
label_4:
      return num2 == 0;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time % 4 == 0)
      {
        int num1 = 20;
        float num2 = 2f;
        for (int index = 0; index < num1; ++index)
        {
          ParticleColored particleColored = new ParticleColored(this.StageData, "光点", new PointF(this.Position.X - (float) num1 + (float) (2 * index), this.Position.Y - 20f), 20f, -1.0 * Math.PI / 2.0 - (double) num2 / 2.0 + (double) index / (double) num1 * (double) num2);
        }
      }
      if ((double) this.MyPlane.Position.Y >= (double) this.BoundRect.Bottom)
        return;
      BaseMyPlane myPlane = this.MyPlane;
      PointF position = this.MyPlane.Position;
      double x = (double) position.X;
      position = this.MyPlane.Position;
      double num = (double) position.Y + 2.0;
      PointF pointF = new PointF((float) x, (float) num);
      myPlane.Position = pointF;
    }

    public override void Show()
    {
    }
  }
}
