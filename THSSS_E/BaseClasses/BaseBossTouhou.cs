// Decompiled with JetBrains decompiler
// Type: Shooting.BaseBossTouhou
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace Shooting
{
  public class BaseBossTouhou : BaseBoss
  {
    public TextureObject[,] TxtureObjects { get; set; }

    public float IndexX { get; set; }

    public int IndexY { get; set; }

    public int OnAction { get; set; }

    public float[] ArmonArray { get; set; }

    public BaseBossTouhou()
    {
    }

    public BaseBossTouhou(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.Boss = this;
      this.AngleWithDirection = false;
      this.Angle = Math.PI / 2.0;
      this.SetBossLifeLineTex();
    }

    public void SetBossLifeLineTex()
    {
    }

    public void MoveToPoint(PointF destOriginalPosition)
    {
      float distance = (float) this.GetDistance(destOriginalPosition);
      if ((double) distance > (double) Math.Abs(this.Velocity))
      {
        this.Direction = this.GetDirection(destOriginalPosition);
        this.Accelerate = (float) (-(double) this.Velocity * (double) this.Velocity / (2.0 * (double) distance));
        if ((double) this.Velocity >= 0.0)
          return;
        this.Velocity = 0.0f;
      }
      else
      {
        this.Accelerate = 0.0f;
        this.Velocity = 0.0f;
      }
    }

    public void MoveUpDown()
    {
      if ((double) this.Velocity >= 0.00999999977648258)
        return;
      if (this.Time % 80 == 0)
      {
        float y = this.DestPoint.Y + 10f;
        this.Velocity = 0.5f;
        this.DestPoint = new PointF(this.DestPoint.X, y);
      }
      else if (this.Time % 80 == 40)
      {
        float y = this.DestPoint.Y - 10f;
        this.Velocity = 0.5f;
        this.DestPoint = new PointF(this.DestPoint.X, y);
      }
    }

    public void MoveUpDown(int circle)
    {
      if ((double) this.Velocity >= 0.00999999977648258)
        return;
      if (this.Time % circle == 0)
      {
        float y = this.DestPoint.Y + 10f;
        this.Velocity = 0.5f;
        this.DestPoint = new PointF(this.DestPoint.X, y);
      }
      else if (this.Time % circle == circle / 2)
      {
        float y = this.DestPoint.Y - 10f;
        this.Velocity = 0.5f;
        this.DestPoint = new PointF(this.DestPoint.X, y);
      }
    }

    public void RandomMove(int T, float velocity)
    {
      if (this.Time % T == 0)
      {
        this.DestPoint = (PointF) new Point(this.Ran.Next(100, this.BoundRect.Width - 100), this.Ran.Next(70, 200));
        this.Velocity = velocity;
      }
      this.MoveToPoint(this.DestPoint);
    }

    public void RandomMove(int T, float velocity, Rectangle RangeRect)
    {
      if (this.Time % T == 0)
      {
        this.DestPoint = (PointF) new Point(this.Ran.Next(RangeRect.Left, RangeRect.Right), this.Ran.Next(RangeRect.Top, RangeRect.Bottom));
        this.Velocity = velocity;
      }
      this.MoveToPoint(this.DestPoint);
    }

    public void RandomMove(int T, int Dist, float Velocity, Rectangle RangeRect)
    {
      if (this.Time % T == 0)
      {
        for (int index = 0; index < 300; ++index)
        {
          double num = (double) this.Ran.Next(360) * Math.PI / 180.0;
          PointF originalPosition = this.OriginalPosition;
          float x = originalPosition.X + (float) Dist * (float) Math.Sin(num);
          originalPosition = this.OriginalPosition;
          float y = originalPosition.Y + (float) Dist * (float) Math.Cos(num);
          if ((double) x > (double) RangeRect.Left && (double) x < (double) RangeRect.Right && (double) y > (double) RangeRect.Top && (double) y < (double) RangeRect.Bottom)
          {
            this.DestPoint = new PointF(x, y);
            this.Velocity = Velocity;
            break;
          }
        }
      }
      this.MoveToPoint(this.DestPoint);
    }

    public void RandomMove1(int T, float velocity)
    {
      if (this.Time % T == 0)
      {
        double x1 = (double) this.OriginalPosition.X;
        Rectangle boundRect = this.BoundRect;
        double num1 = (double) (boundRect.Width / 2 - 50);
        if (x1 < num1)
        {
          MyRandom ran1 = this.Ran;
          boundRect = this.BoundRect;
          int minValue1 = boundRect.Width / 2 + 50;
          boundRect = this.BoundRect;
          int maxValue1 = boundRect.Width - 110;
          double num2 = (double) ran1.Next(minValue1, maxValue1);
          MyRandom ran2 = this.Ran;
          boundRect = this.BoundRect;
          int minValue2 = boundRect.Top + 100;
          boundRect = this.BoundRect;
          int maxValue2 = boundRect.Top + 150;
          double num3 = (double) ran2.Next(minValue2, maxValue2);
          this.DestPoint = new PointF((float) num2, (float) num3);
        }
        else
        {
          double x2 = (double) this.OriginalPosition.X;
          boundRect = this.BoundRect;
          double num2 = (double) (boundRect.Width / 2 + 50);
          if (x2 > num2)
          {
            MyRandom ran1 = this.Ran;
            boundRect = this.BoundRect;
            int maxValue1 = boundRect.Width / 2 - 50;
            double num3 = (double) ran1.Next(110, maxValue1);
            MyRandom ran2 = this.Ran;
            boundRect = this.BoundRect;
            int minValue = boundRect.Top + 100;
            boundRect = this.BoundRect;
            int maxValue2 = boundRect.Top + 150;
            double num4 = (double) ran2.Next(minValue, maxValue2);
            this.DestPoint = new PointF((float) num3, (float) num4);
          }
          else
          {
            double x3 = (double) this.MyPlane.OriginalPosition.X;
            boundRect = this.BoundRect;
            double num3 = (double) (boundRect.Width / 2);
            if (x3 < num3)
            {
              MyRandom ran1 = this.Ran;
              boundRect = this.BoundRect;
              int maxValue1 = boundRect.Width / 2 - 50;
              double num4 = (double) ran1.Next(110, maxValue1);
              MyRandom ran2 = this.Ran;
              boundRect = this.BoundRect;
              int minValue = boundRect.Top + 100;
              boundRect = this.BoundRect;
              int maxValue2 = boundRect.Top + 150;
              double num5 = (double) ran2.Next(minValue, maxValue2);
              this.DestPoint = new PointF((float) num4, (float) num5);
            }
            else
            {
              MyRandom ran1 = this.Ran;
              boundRect = this.BoundRect;
              int minValue1 = boundRect.Width / 2 + 50;
              boundRect = this.BoundRect;
              int maxValue1 = boundRect.Width - 110;
              double num4 = (double) ran1.Next(minValue1, maxValue1);
              MyRandom ran2 = this.Ran;
              boundRect = this.BoundRect;
              int minValue2 = boundRect.Top + 100;
              boundRect = this.BoundRect;
              int maxValue2 = boundRect.Top + 150;
              double num5 = (double) ran2.Next(minValue2, maxValue2);
              this.DestPoint = new PointF((float) num4, (float) num5);
            }
          }
        }
        this.Velocity = velocity;
      }
      this.MoveToPoint(this.DestPoint);
    }

    public virtual void TextureCtrl()
    {
      int num = this.Mirrored ? this.IndexY : -this.IndexY;
      if (this.OnAction > 0)
      {
        this.IndexY = 2;
        this.IndexX += 0.125f;
        --this.OnAction;
      }
      else if ((double) this.Vx < -0.0500000007450581)
      {
        this.Mirrored = true;
        this.IndexY = 1;
        if ((double) this.Vx < -1.0)
        {
          if ((double) this.IndexX < 2.0)
            this.IndexX += 0.125f;
          else
            this.IndexX = (float) (2 + this.Time % 16 / 8);
        }
        else
          this.IndexX = (double) this.Vx >= -0.5 ? 0.0f : 1f;
      }
      else if ((double) this.Vx > 0.0500000007450581)
      {
        this.Mirrored = false;
        this.IndexY = 1;
        if ((double) this.Vx > 1.0)
        {
          if ((double) this.IndexX < 2.0)
            this.IndexX += 0.125f;
          else
            this.IndexX = (float) (2 + this.Time % 16 / 8);
        }
        else
          this.IndexX = (double) this.Vx <= 0.5 ? 0.0f : 1f;
      }
      else
      {
        this.Mirrored = false;
        this.IndexY = 0;
        this.IndexX = (float) (this.TimeMain % 32 / 8);
      }
      if (num != (this.Mirrored ? this.IndexY : -this.IndexY))
        this.IndexX = 0.0f;
      if ((double) this.IndexX > 3.0)
        this.IndexX = 3f;
      this.TxtureObject = this.TxtureObjects[this.IndexY, (int) this.IndexX];
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.Shoot();
      this.TextureCtrl();
      if (!this.OutBoundary())
        return;
      this.Boss = (BaseBossTouhou) null;
    }

    public override bool OutBoundary()
    {
      return this.Time > this.LifeTime;
    }

    public override void GiveItems()
    {
      if (this.MyPlane.Power < 400)
      {
        PointF OriginalPosition;
        for (int index = 0; index < 15; ++index)
        {
          OriginalPosition = new PointF(this.OriginalPosition.X + (float) this.Ran.Next(-49, 50), this.OriginalPosition.Y + (float) this.Ran.Next(-49, 50));
          PowerItem_Touhou powerItemTouhou = new PowerItem_Touhou(this.StageData, OriginalPosition);
        }
        for (int index = 0; index < 15; ++index)
        {
          OriginalPosition = new PointF(this.OriginalPosition.X + (float) this.Ran.Next(-49, 50), this.OriginalPosition.Y + (float) this.Ran.Next(-49, 50));
          ScoreItem_Touhou scoreItemTouhou = new ScoreItem_Touhou(this.StageData, OriginalPosition);
        }
      }
      else
      {
        for (int index = 0; index < 30; ++index)
        {
          ScoreItem_Touhou scoreItemTouhou = new ScoreItem_Touhou(this.StageData, new PointF(this.OriginalPosition.X + (float) this.Ran.Next(-49, 50), this.OriginalPosition.Y + (float) this.Ran.Next(-49, 50)));
        }
      }
    }

    protected virtual void LoadArmon(string fileName)
    {
      if (!File.Exists(fileName))
        return;
      char[] chArray = new char[1]{ ',' };
      string[] strArray = File.ReadAllLines(fileName, Encoding.Default);
      this.ArmonArray = new float[strArray.Length];
      for (int index = 0; index < strArray.Length; ++index)
        this.ArmonArray[index] = float.Parse(strArray[index]);
    }
  }
}
