// Decompiled with JetBrains decompiler
// Type: Shooting.Spell_AyaB_Laser
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class Spell_AyaB_Laser : BaseSpell
  {
    private BaseObject Target;

    public Spell_AyaB_Laser(StageDataPackage StageData, PointF OriginalPosition, bool Left)
    {
      this.StageData = StageData;
      this.SpellList.Add((BaseObject) this);
      this.OriginalPosition = OriginalPosition;
      this.Damage = 50;
      this.Region = 25;
      this.LifeTime = 20;
      this.Velocity = 50f;
      this.ScaleLength = 2f;
      this.ScaleWidth = 1f;
      this.TxtureObject = this.TextureObjectDictionary["Laser"];
      if (this.Boss != null && ((double) this.Boss.OriginalPosition.X > 0.0 && (double) this.Boss.OriginalPosition.X < (double) this.BoundRect.Width && (double) this.Boss.OriginalPosition.Y > 0.0 && (double) this.Boss.OriginalPosition.Y < (double) this.BoundRect.Height))
        this.Target = (BaseObject) this.Boss;
      if (this.Target == null)
      {
        double dist = 500.0;
        this.EnemyPlaneList.ForEach((Action<BaseEnemyPlane>) (x =>
        {
          double distance = this.GetDistance((BaseObject) x);
          if (distance >= dist)
            return;
          this.Target = (BaseObject) x;
          dist = distance;
        }));
      }
      PointF originalPosition;
      Rectangle boundRect;
      if (this.Target == null)
      {
        this.Target = new BaseObject()
        {
          OriginalPosition = new PointF(OriginalPosition.X + (float) this.Ran.Next(-80, 80), OriginalPosition.Y + (float) this.Ran.Next(-80, 80))
        };
        originalPosition = this.Target.OriginalPosition;
        if ((double) originalPosition.Y < 0.0)
        {
          BaseObject target = this.Target;
          originalPosition = this.Target.OriginalPosition;
          PointF pointF = new PointF(originalPosition.X, 0.0f);
          target.OriginalPosition = pointF;
        }
        else
        {
          originalPosition = this.Target.OriginalPosition;
          if ((double) originalPosition.Y > (double) this.BoundRect.Height)
          {
            BaseObject target = this.Target;
            originalPosition = this.Target.OriginalPosition;
            double x = (double) originalPosition.X;
            boundRect = this.BoundRect;
            double height = (double) boundRect.Height;
            PointF pointF = new PointF((float) x, (float) height);
            target.OriginalPosition = pointF;
          }
        }
      }
      int num1;
      if (!Left)
      {
        boundRect = this.BoundRect;
        num1 = boundRect.Width + 150;
      }
      else
        num1 = -150;
      double num2 = (double) num1;
      MyRandom ran = this.Ran;
      originalPosition = this.Target.OriginalPosition;
      int minValue = (int) originalPosition.Y - 80;
      originalPosition = this.Target.OriginalPosition;
      int maxValue = (int) originalPosition.Y + 80;
      double num3 = (double) ran.Next(minValue, maxValue);
      this.OriginalPosition = new PointF((float) num2, (float) num3);
      this.Direction = this.GetDirection(this.Target);
      this.SpellList[0].OriginalPosition = this.Target.OriginalPosition;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Target == null)
        return;
      if ((double) this.Target.HealthPoint <= 0.0)
        this.Target = (BaseObject) null;
      if (this.OutBoundary())
      {
        this.Target = (BaseObject) null;
        this.MyPlane.Time = this.MyPlane.UnmatchedTime - 90;
      }
    }

    public override bool HitCheck(BaseObject Target)
    {
      double distance = this.GetDistance(Target);
      double direction = this.GetDirection(Target);
      double num1 = distance * Math.Cos(this.Direction - direction);
      double num2 = distance * Math.Sin(this.Direction - direction);
      double num3 = (double) this.Region * (double) this.ScaleWidth;
      double num4 = (double) this.TxtureObject.Height * (double) this.ScaleLength * 0.449999988079071;
      return num2 * num2 / num3 / num3 + (num1 - (double) this.TxtureObject.Height * (double) this.ScaleLength / 2.0) * (num1 - (double) this.TxtureObject.Height * (double) this.ScaleLength / 2.0) / num4 / num4 < 1.0;
    }

    public override void Show()
    {
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
