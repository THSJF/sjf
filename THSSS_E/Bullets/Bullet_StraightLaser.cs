 
// Type: Shooting.Bullet_StraightLaser
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class Bullet_StraightLaser : BaseBullet_Touhou
  {
    public bool LaserHead { get; set; }

    private int HeadTransparent { get; set; }

    public Bullet_StraightLaser(StageDataPackage StageData)
      : base(StageData)
    {
    }

    public Bullet_StraightLaser(
      StageDataPackage StageData,
      PointF OriginalPosition,
      float Velocity,
      double Direction,
      byte ColorType,
      int Length)
      : this(StageData, OriginalPosition, Velocity, Direction, ColorType, Length, 16)
    {
    }

    public Bullet_StraightLaser(
      StageDataPackage StageData,
      PointF OriginalPosition,
      float Velocity,
      double Direction,
      byte ColorType,
      int Length,
      int Width)
      : this(StageData, "Laser0_" + (object) ColorType, OriginalPosition, Velocity, Direction, Length)
    {
      this.ColorType = ColorType;
      this.Active = true;
      this.Angle = Math.PI / 2.0;
      this.ScaleLength = (float) Width / (float) this.TxtureObject.Height;
    }

    public Bullet_StraightLaser(
      StageDataPackage StageData,
      string textureName,
      PointF OriginalPosition,
      float Velocity,
      double Direction,
      int Length)
      : base(StageData, textureName, OriginalPosition, Velocity, Direction)
    {
      this.GhostingCount = Length;
      this.Region = 2;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.ScaleWidth = (float) this.GetDistance(this.LastPoints[this.LastPoints.Length - 1]) / (float) this.TxtureObject.Width;
      if (this.Time == 1)
      {
        ParticleBeginBullet particleBeginBullet = new ParticleBeginBullet(this.StageData, this.Position, this.ColorType);
        particleBeginBullet.Scale = 0.5f;
        particleBeginBullet.Active = true;
        particleBeginBullet.LifeTime = this.GhostingCount;
      }
      if (this.Time % 8 == 0)
        this.Grazed = false;
      if (!this.LaserHead)
        return;
      this.HeadTransparent = this.Ran.Next(150, (int) byte.MaxValue);
    }

    public override bool OutBoundary()
    {
      if (this.LifeTime != 0 && this.Time > this.LifeTime)
        return true;
      if (this.Reflect <= (byte) 0)
      {
        if (this.Time < 100)
          return false;
        int num1 = this.Region >= 10 ? this.Region : 10;
        Rectangle boundRect;
        int num2;
        if ((double) -num1 < (double) this.LastPoints[this.LastPoints.Length - 1].X)
        {
          double x = (double) this.LastPoints[this.LastPoints.Length - 1].X;
          boundRect = this.BoundRect;
          double num3 = (double) (boundRect.Width + num1);
          if (x < num3 && (double) -num1 < (double) this.LastPoints[this.LastPoints.Length - 1].Y)
          {
            double y = (double) this.LastPoints[this.LastPoints.Length - 1].Y;
            boundRect = this.BoundRect;
            double num4 = (double) (boundRect.Height + num1);
            num2 = y >= num4 ? 1 : 0;
            goto label_9;
          }
        }
        num2 = 1;
label_9:
        if (num2 == 0)
          return false;
        int num5;
        if ((double) -num1 < (double) this.OriginalPosition.X)
        {
          PointF originalPosition = this.OriginalPosition;
          double x = (double) originalPosition.X;
          boundRect = this.BoundRect;
          double num3 = (double) (boundRect.Width + num1);
          if (x < num3)
          {
            double num4 = (double) -num1;
            originalPosition = this.OriginalPosition;
            double y1 = (double) originalPosition.Y;
            if (num4 < y1)
            {
              originalPosition = this.OriginalPosition;
              double y2 = (double) originalPosition.Y;
              boundRect = this.BoundRect;
              double num6 = (double) (boundRect.Height + num1);
              num5 = y2 >= num6 ? 1 : 0;
              goto label_16;
            }
          }
        }
        num5 = 1;
label_16:
        return num5 != 0;
      }
      PointF originalPosition1 = this.OriginalPosition;
      int num;
      if ((double) originalPosition1.X >= 0.0)
      {
        originalPosition1 = this.OriginalPosition;
        num = (double) originalPosition1.X < (double) this.BoundRect.Width ? 1 : 0;
      }
      else
        num = 0;
      if (num == 0)
      {
        --this.Reflect;
        Bullet_StraightLaser bulletStraightLaser = new Bullet_StraightLaser(this.StageData, new PointF(0.0f, 0.0f), 0.0f, 0.0, (byte) 0, 0);
        bulletStraightLaser.Copy((BaseObject) this);
        bulletStraightLaser.Direction -= 2.0 * (this.Direction - Math.PI / 2.0);
      }
      originalPosition1 = this.OriginalPosition;
      if ((double) originalPosition1.Y < 20.0)
      {
        --this.Reflect;
        Bullet_StraightLaser bulletStraightLaser = new Bullet_StraightLaser(this.StageData, new PointF(0.0f, 0.0f), 0.0f, 0.0, (byte) 0, 0);
        bulletStraightLaser.Copy((BaseObject) this);
        bulletStraightLaser.Direction = -this.Direction;
      }
      return false;
    }

    public override bool HitCheck(BaseObject Target, float Radius)
    {
      for (int index = 3; index < this.LastPoints.Length - 3; ++index)
      {
        PointF lastPoint = this.LastPoints[index];
        double x1 = (double) lastPoint.X;
        PointF originalPosition = Target.OriginalPosition;
        double x2 = (double) originalPosition.X;
        double num1 = x1 - x2;
        double x3 = (double) lastPoint.X;
        originalPosition = Target.OriginalPosition;
        double x4 = (double) originalPosition.X;
        double num2 = x3 - x4;
        double num3 = num1 * num2;
        double y1 = (double) lastPoint.Y;
        originalPosition = Target.OriginalPosition;
        double y2 = (double) originalPosition.Y;
        double num4 = y1 - y2;
        double y3 = (double) lastPoint.Y;
        originalPosition = Target.OriginalPosition;
        double y4 = (double) originalPosition.Y;
        double num5 = y3 - y4;
        double num6 = num4 * num5;
        if (Math.Sqrt(num3 + num6) - (double) Target.Region * (double) Target.Scale < (double) Radius * (double) this.ScaleLength)
          return true;
      }
      return false;
    }

    public override void GiveEndEffect()
    {
      for (int index = 0; index < this.LastPoints.Length; ++index)
      {
        if (index % 8 == 0)
        {
          ParticleEndBullet particleEndBullet = new ParticleEndBullet(this.StageData, this.LastPoints[index], this.ColorType, this.SizeValue);
        }
      }
    }

    public override void GiveItems()
    {
      int num = this.Region / 5;
      for (int index1 = 0; index1 < this.LastPoints.Length; index1 += 8)
      {
        for (int index2 = 0; index2 <= num; ++index2)
        {
          double direction = this.Direction;
          for (int index3 = 0; index3 < index2 * 5 + 1; ++index3)
          {
            StarItem_Touhou starItemTouhou = new StarItem_Touhou(this.StageData, new PointF(this.LastPoints[index1].X + (float) index2 * (float) Math.Cos(direction), this.LastPoints[index1].Y + (float) index2 * (float) Math.Sin(direction)));
            direction += 2.0 * Math.PI / (double) (index2 * 6);
          }
        }
      }
    }

    public override void Show()
    {
      if (this.TxtureObject == null)
        return;
      PointF position = new PointF((float) (((double) this.OriginalPosition.X + (double) this.LastPoints[this.LastPoints.Length - 1].X) / 2.0), (float) (((double) this.OriginalPosition.Y + (double) this.LastPoints[this.LastPoints.Length - 1].Y) / 2.0));
      position = new PointF(position.X + (float) this.BoundRect.Left, position.Y + (float) this.BoundRect.Top);
      this.SpriteMain.Draw2D(this.TxtureObject, this.ScaleWidth, this.ScaleLength, (float) (this.Direction - Math.PI / 2.0 + this.Angle), position, Color.FromArgb(this.TransparentValue, this.ColorValue), this.Mirrored);
      if (!this.LaserHead)
        return;
      TextureObject textureObject = this.TextureObjectDictionary["光点"];
      if ((byte) 0 < this.ColorType && this.ColorType <= (byte) 2)
        textureObject = this.TextureObjectDictionary["FY_Particle6_0"];
      else if ((byte) 2 < this.ColorType && this.ColorType <= (byte) 4)
        textureObject = this.TextureObjectDictionary["FY_Particle4_0"];
      else if ((byte) 4 < this.ColorType && this.ColorType <= (byte) 8)
        textureObject = this.TextureObjectDictionary["FY_Particle5_0"];
      this.SpriteMain.Draw2D(textureObject, 0.4f, 0.4f, (float) (this.Direction - Math.PI / 2.0 + this.Angle + (double) this.Time / 10.0), this.Position, Color.FromArgb(this.HeadTransparent, this.ColorValue), this.Mirrored);
    }

    public override void ShowRegion()
    {
      PointF originalPosition = this.OriginalPosition;
      for (int index = 3; index < this.LastPoints.Length - 3; ++index)
      {
        this.OriginalPosition = this.LastPoints[index];
        base.ShowRegion();
      }
      this.OriginalPosition = originalPosition;
    }
  }
}
