// Decompiled with JetBrains decompiler
// Type: Shooting.AutoPlane
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using System;
using System.Drawing;

namespace Shooting
{
  public class AutoPlane : BaseMyPlane
  {
    private int CtrlCircle = 1;
    private KeyClass KC = new KeyClass();

    public AutoPlane(StageDataPackage StageData, Point Position)
      : base(StageData, Position)
    {
    }

    public override void Ctrl()
    {
      if (this.Time % this.CtrlCircle == 0)
      {
        this.KC = new KeyClass();
        this.KC.Key_Z = true;
        Vector2 move = this.GenerateMove();
        double num1 = -(double) move.X;
        double num2 = -(double) move.Y;
        if ((double) move.Length() < 80.0)
          this.KC.Key_Shift = true;
        if (num1 > 1.0)
          this.KC.ArrowLeft = true;
        else if (num1 < -1.0)
          this.KC.ArrowRight = true;
        if (num2 > 1.0)
          this.KC.ArrowUp = true;
        else if (num2 < -1.0)
          this.KC.ArrowDown = true;
      }
      this.BulletList.ForEach((Action<BaseBullet_Touhou>) (x =>
      {
        if (!x.HitCheck((BaseObject) this, (float) x.Region) && this.DeadTime <= this.Time)
          return;
        this.KC.Key_X = true;
      }));
      this.StageData.GlobalData.KClass.Hex2Key(this.KC.Key2Hex());
      base.Ctrl();
    }

    private double GenerateDanger(PointF OriginalPos)
    {
      double tmp = 0.0;
      double d;
      this.BulletList.ForEach((Action<BaseBullet_Touhou>) (x =>
      {
        Vector2 vector2_1 = new Vector2(OriginalPos.X, OriginalPos.Y);
          Vector2 vector2_2 = new Vector2();
        ref Vector2 local = ref vector2_2;
        PointF originalPosition = x.OriginalPosition;
        double x1 = (double) originalPosition.X;
        originalPosition = x.OriginalPosition;
        double y = (double) originalPosition.Y;
        local = new Vector2((float) x1, (float) y);
        d = (double) (vector2_1 - vector2_2).Length() - (double) this.Region - (double) x.Region;
        if (d >= 200.0)
          return;
        tmp += 7000.0 / d / d;
        Vector2 vector2_3 = x.Velocity * new Vector2((float) Math.Cos(x.Direction), (float) Math.Sin(x.Direction));
        Vector2 vector2_4 = vector2_2 + (float) this.GetDistance(OriginalPos) / 5f * vector2_3;
        d = (double) (vector2_1 - vector2_4).Length() - (double) this.Region - (double) x.Region;
        tmp += 3000.0 / d / d;
      }));
      this.EnemyPlaneList.ForEach((Action<BaseEnemyPlane>) (x =>
      {
        PointF originalPosition;
        int num;
        if ((double) x.OriginalPosition.X > 0.0)
        {
          originalPosition = x.OriginalPosition;
          if ((double) originalPosition.X < (double) this.BoundRect.Width)
          {
            originalPosition = x.OriginalPosition;
            if ((double) originalPosition.Y > 0.0)
            {
              originalPosition = x.OriginalPosition;
              num = (double) originalPosition.Y >= (double) this.BoundRect.Height ? 1 : 0;
              goto label_5;
            }
          }
        }
        num = 1;
label_5:
        if (num != 0)
          return;
        Vector2 vector2_1 = new Vector2(OriginalPos.X, OriginalPos.Y);
        Vector2 vector2_2 = new Vector2();
          ref Vector2 local = ref vector2_2;
        originalPosition = x.OriginalPosition;
        double x1 = (double) originalPosition.X;
        originalPosition = x.OriginalPosition;
        double y = (double) originalPosition.Y;
        local = new Vector2((float) x1, (float) y);
        d = (double) (vector2_1 - vector2_2).Length() - (double) this.Region - (double) x.Region;
        tmp += 10000.0 / d / d;
      }));
      if (this.Boss != null)
      {
        d = this.Boss.GetDistance(OriginalPos) - (double) this.Boss.Region - (double) this.Region;
        tmp += 10000.0 / d / d;
      }
      return tmp;
    }

    private Vector2 GenerateDestPoint(int div, int count, float x, float y)
    {
      Vector2 vector2 = Vector2.Zero;
      double num1 = 1000000000.0;
      double num2 = 0.0;
      x -= (float) (div * (count - 1) / 2);
      y -= (float) (div * (count - 1) / 2);
      Rectangle boundRect;
      if ((double) x < 0.0)
      {
        x = 0.0f;
      }
      else
      {
        double num3 = (double) x;
        boundRect = this.BoundRect;
        double num4 = (double) (boundRect.Width - div * (count - 1));
        if (num3 > num4)
        {
          boundRect = this.BoundRect;
          x = (float) (boundRect.Width - div * (count - 1));
        }
      }
      if ((double) y < 0.0)
      {
        y = 0.0f;
      }
      else
      {
        double num3 = (double) y;
        boundRect = this.BoundRect;
        double num4 = (double) (boundRect.Height - div * (count - 1));
        if (num3 > num4)
        {
          boundRect = this.BoundRect;
          y = (float) (boundRect.Height - div * (count - 1));
        }
      }
      for (int index1 = 0; index1 < count; ++index1)
      {
        for (int index2 = 0; index2 < count; ++index2)
        {
          double danger = this.GenerateDanger(new PointF(x, y));
          if (danger < num1)
          {
            num1 = danger;
            vector2 = new Vector2(x, y);
          }
          if (danger > num2)
            num2 = danger;
          x += (float) div;
        }
        y += (float) div;
        x -= (float) (div * count);
      }
      if (num2 > 2.0)
        return vector2;
      PointF originalPosition = this.OriginalPosition;
      double x1 = (double) originalPosition.X;
      originalPosition = this.OriginalPosition;
      double y1 = (double) originalPosition.Y;
      return new Vector2((float) x1, (float) y1);
    }

    private Vector2 GenerateMove()
    {
      Vector2 forceSum = Vector2.Zero;
      float d;
      this.BulletList.ForEach((Action<BaseBullet_Touhou>) (x =>
      {
        Vector2 vector2_1 = new Vector2();
          ref Vector2 local1 = ref vector2_1;
        PointF originalPosition1 = this.OriginalPosition;
        double x1 = (double) originalPosition1.X;
        originalPosition1 = this.OriginalPosition;
        double y1 = (double) originalPosition1.Y;
        local1 = new Vector2((float) x1, (float) y1);
        Vector2 vector2_2 = new Vector2();
          ref Vector2 local2 = ref vector2_2;
        PointF originalPosition2 = x.OriginalPosition;
        double x2 = (double) originalPosition2.X;
        originalPosition2 = x.OriginalPosition;
        double y2 = (double) originalPosition2.Y;
        local2 = new Vector2((float) x2, (float) y2);
        Vector2 vector2_3 = vector2_1 - vector2_2;
        d = vector2_3.Length() - (float) this.Region - (float) x.Region;
        if ((double) d >= 200.0)
          return;
        vector2_3.Normalize();
        vector2_3 *= 5000f / d / d;
        forceSum += vector2_3;
        Vector2 vector2_4 = x.Velocity * new Vector2((float) Math.Cos(x.Direction), (float) Math.Sin(x.Direction));
        Vector2 vector2_5 = vector2_2 + 3f * vector2_4;
        Vector2 vector2_6 = vector2_1 - vector2_5;
        d = vector2_6.Length() - (float) this.Region - (float) x.Region;
        vector2_6.Normalize();
        forceSum += vector2_6 * (5000f / d / d);
        Vector2 vector2_7 = vector2_5 + 6f * vector2_4;
        Vector2 vector2_8 = vector2_1 - vector2_7;
        d = vector2_8.Length() - (float) this.Region - (float) x.Region;
        vector2_8.Normalize();
        vector2_8 *= 2000f / d / d;
        forceSum += vector2_8;
      }));
      this.EnemyPlaneList.ForEach((Action<BaseEnemyPlane>) (x =>
      {
        PointF originalPosition;
        int num;
        if ((double) x.OriginalPosition.X > 0.0)
        {
          originalPosition = x.OriginalPosition;
          if ((double) originalPosition.X < (double) this.BoundRect.Width)
          {
            originalPosition = x.OriginalPosition;
            if ((double) originalPosition.Y > 0.0)
            {
              originalPosition = x.OriginalPosition;
              num = (double) originalPosition.Y >= (double) this.BoundRect.Height ? 1 : 0;
              goto label_5;
            }
          }
        }
        num = 1;
label_5:
        if (num != 0)
          return;
        Vector2 vector2_1 = new Vector2();
          ref Vector2 local1 = ref vector2_1;
        originalPosition = this.OriginalPosition;
        double x1 = (double) originalPosition.X;
        originalPosition = this.OriginalPosition;
        double y1 = (double) originalPosition.Y;
        local1 = new Vector2((float) x1, (float) y1);
        Vector2 vector2_2 = new Vector2();
          ref Vector2 local2 = ref vector2_2;
        originalPosition = x.OriginalPosition;
        double x2 = (double) originalPosition.X;
        originalPosition = x.OriginalPosition;
        double y2 = (double) originalPosition.Y;
        local2 = new Vector2((float) x2, (float) y2);
        Vector2 vector2_3 = vector2_1 - vector2_2;
        d = vector2_3.Length() - (float) this.Region - (float) x.Region;
        vector2_3.Normalize();
        forceSum += vector2_3 * (5000f / d / d);
        Vector2 vector2_4 = x.Velocity * new Vector2((float) Math.Cos(x.Direction), (float) Math.Sin(x.Direction));
        Vector2 vector2_5 = vector2_2 + 5f * vector2_4;
        Vector2 vector2_6 = vector2_1 - vector2_5;
        d = vector2_6.Length() - (float) this.Region - (float) x.Region;
        vector2_6.Normalize();
        forceSum += vector2_6 * (5000f / d / d);
      }));
      PointF pointF;
      if (this.Boss != null)
      {
        Vector2 vector2_1 = new Vector2();
                ref Vector2 local1 = ref vector2_1;
        pointF = this.OriginalPosition;
        double x1 = (double) pointF.X;
        pointF = this.OriginalPosition;
        double y1 = (double) pointF.Y;
        local1 = new Vector2((float) x1, (float) y1);
        Vector2 vector2_2 = new Vector2();
                ref Vector2 local2 = ref vector2_2;
        pointF = this.Boss.OriginalPosition;
        double x2 = (double) pointF.X;
        pointF = this.Boss.OriginalPosition;
        double y2 = (double) pointF.Y;
        local2 = new Vector2((float) x2, (float) y2);
        Vector2 vector2_3 = vector2_1 - vector2_2;
        d = vector2_3.Length() - (float) this.Region - (float) this.Boss.Region;
        vector2_3.Normalize();
        Vector2 vector2_4 = vector2_3 * (10000f / d / d);
        forceSum += vector2_4;
      }
      pointF = this.OriginalPosition;
      double x3 = (double) pointF.X;
      pointF = this.OriginalPosition;
      double y3 = (double) pointF.Y;
      Vector2 destPoint = this.GenerateDestPoint(40, 4, (float) x3, (float) y3);
      Vector2 start = this.GenerateDestPoint(10, 4, destPoint.X, destPoint.Y);
      start = this.GenerateDestPoint(2, 5, start.X, start.Y);
      Vector2 end = new Vector2();
            ref Vector2 local3 = ref end;
      pointF = this.DestPoint;
      double x4 = (double) pointF.X;
      pointF = this.DestPoint;
      double y4 = (double) pointF.Y;
      local3 = new Vector2((float) x4, (float) y4);
      if (this.Time > 300)
        start = Vector2.Lerp(start, end, 0.5f);
      Vector2 vector2_9 = new Vector2();
            ref Vector2 local4 = ref vector2_9;
      pointF = this.OriginalPosition;
      double x5 = (double) pointF.X;
      pointF = this.OriginalPosition;
      double y5 = (double) pointF.Y;
      local4 = new Vector2((float) x5, (float) y5);
      Vector2 vector2_10 = start - vector2_9;
      forceSum += 1f * vector2_10;
      this.DestPoint = new PointF(start.X, start.Y);
      if (this.Boss != null)
      {
        Vector2 vector2_1 = forceSum;
        pointF = this.Boss.OriginalPosition;
        double x1 = (double) pointF.X;
        pointF = this.OriginalPosition;
        double x2 = (double) pointF.X;
        Vector2 vector2_2 = new Vector2((float) (5.0 * (x1 - x2)), 0.0f);
        forceSum = vector2_1 + vector2_2;
      }
      else
      {
        Vector2 vector2_1 = forceSum;
        Rectangle boundRect = this.BoundRect;
        double num1 = (double) (boundRect.Width / 2);
        pointF = this.OriginalPosition;
        double x1 = (double) pointF.X;
        double num2 = 0.100000001490116 * (num1 - x1);
        boundRect = this.BoundRect;
        double height = (double) boundRect.Height;
        pointF = this.OriginalPosition;
        double y1 = (double) pointF.Y;
        double num3 = 0.100000001490116 * (height - y1);
        Vector2 vector2_2 = new Vector2((float) num2, (float) num3);
        forceSum = vector2_1 + vector2_2;
        forceSum += this.GenerateEnemyBeat();
      }
      forceSum += this.GenerateItemGet();
      return forceSum;
    }

    private Vector2 GenerateEnemyBeat()
    {
      Vector2 vector2 = Vector2.Zero;
      float tmp = 1000f;
      this.EnemyPlaneList.ForEach((Action<BaseEnemyPlane>) (x =>
      {
        PointF originalPosition;
        int num;
        if ((double) x.OriginalPosition.Y > 0.0)
        {
          originalPosition = x.OriginalPosition;
          if ((double) originalPosition.Y < 300.0)
          {
            num = (double) x.HealthPoint >= 20000.0 ? 1 : 0;
            goto label_4;
          }
        }
        num = 1;
label_4:
        if (num != 0)
          return;
        originalPosition = x.OriginalPosition;
        double x1 = (double) originalPosition.X;
        originalPosition = this.OriginalPosition;
        double x2 = (double) originalPosition.X;
        if ((double) Math.Abs((float) (x1 - x2)) < (double) tmp)
        {
          originalPosition = x.OriginalPosition;
          tmp = originalPosition.X;
        }
      }));
      if ((double) tmp < 1000.0)
        vector2 = new Vector2((float) (10.0 * ((double) tmp - (double) this.OriginalPosition.X)), 0.0f);
      return vector2;
    }

    private Vector2 GenerateItemGet()
    {
      if (this.BulletList.Count > 10 || this.Boss != null)
        return Vector2.Zero;
      int itemCount = 0;
      this.ItemList.ForEach((Action<BaseItem>) (x =>
      {
        if (x.Obtain)
          return;
        ++itemCount;
      }));
      if (itemCount > 5)
        return new Vector2(0.0f, (float) (2.0 * (110.0 - (double) this.OriginalPosition.Y)));
      return Vector2.Zero;
    }

    public override void Show()
    {
      MySprite spriteMain = this.SpriteMain;
      TextureObject textureObject = this.TextureObjectDictionary["Region"];
      PointF destPoint = this.DestPoint;
      double num1 = (double) destPoint.X + (double) this.BoundRect.Left;
      destPoint = this.DestPoint;
      double num2 = (double) destPoint.Y + (double) this.BoundRect.Top;
      PointF position = new PointF((float) num1, (float) num2);
      Color white = Color.White;
      spriteMain.Draw2D(textureObject, 0.1f, 0.0f, position, white);
      base.Show();
    }
  }
}
