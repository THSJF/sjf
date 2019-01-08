 
// Type: Shooting.Bullet_RadialLaser
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class Bullet_RadialLaser : BaseBullet_Touhou
  {
    private BaseEffect beginEffect;

    public int UnmatchedTime { get; set; }

    public Bullet_RadialLaser(StageDataPackage StageData)
      : base(StageData)
    {
    }

    public Bullet_RadialLaser(
      StageDataPackage StageData,
      PointF OriginalPosition,
      float Velocity,
      double Direction,
      byte ColorType,
      int Length)
      : this(StageData, OriginalPosition, Velocity, Direction, ColorType, Length, 16)
    {
    }

    public Bullet_RadialLaser(
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
      this.MaxScaleL = (float) Width / (float) this.TxtureObject.Height;
    }

    public Bullet_RadialLaser(
      StageDataPackage StageData,
      string textureName,
      PointF OriginalPosition,
      float Velocity,
      double Direction,
      int Length)
      : base(StageData, textureName, OriginalPosition, Velocity, Direction)
    {
      this.UnRemoveable = true;
      this.Region = 2;
      this.ScaleVW = 0.5f;
      this.MaxScaleW = (float) Length / (float) this.TxtureObject.Width;
      this.ScaleWidth = this.MaxScaleW;
      this.MaxScaleL = 1f;
      this.ScaleLength = 0.2f;
      this.UnmatchedTime = 60;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time == 1)
      {
        ParticleBeginBullet particleBeginBullet = new ParticleBeginBullet(this.StageData, this.Position, this.ColorType);
        particleBeginBullet.Scale = this.MaxScaleW * 0.5f;
        particleBeginBullet.Active = true;
        particleBeginBullet.LifeTime = this.LifeTime;
        this.beginEffect = (BaseEffect) particleBeginBullet;
        this.beginEffect.SetBinding((BaseObject) this);
      }
      if (this.Time == this.UnmatchedTime)
        this.ScaleVL = 0.1f;
      if (this.Time == this.LifeTime - 8)
      {
        this.TransparentVelocity = (float) (-this.MaxTransparent / 8);
        this.ScaleVL = (float) (-(double) this.ScaleLength / 8.0);
      }
      if (this.Time % 8 != 0)
        return;
      this.Grazed = false;
    }

    public override bool OutBoundary()
    {
      return this.LifeTime != 0 && this.Time > this.LifeTime;
    }

    public override bool HitCheck(BaseObject Target, float Radius)
    {
      if (this.Time < this.UnmatchedTime)
        return false;
      double distance = this.GetDistance(Target);
      double direction = this.GetDirection(Target);
      double num1 = distance * Math.Cos(this.Direction - direction);
      double num2 = distance * Math.Sin(this.Direction - direction);
      double num3 = (double) Radius * (double) this.ScaleLength + (double) Target.Region * (double) Target.Scale;
      double num4 = ((double) this.TxtureObject.Width + (double) Radius) * (double) this.ScaleWidth * 0.449999988079071 + (double) Target.Region * (double) Target.Scale;
      return num2 * num2 / num3 / num3 + (num1 - (double) this.TxtureObject.Width * (double) this.ScaleWidth / 2.0) * (num1 - (double) this.TxtureObject.Width * (double) this.ScaleWidth / 2.0) / num4 / num4 < 1.0;
    }

    public override void GiveEndEffect()
    {
      this.beginEffect.LifeTime = this.beginEffect.Time + 1;
    }

    public override void Show()
    {
      if (this.TxtureObject == null)
        return;
      this.SpriteMain.Draw2D(this.TxtureObject.TXTure, this.TxtureObject.PosRect, new SizeF((float) this.TxtureObject.Width * this.ScaleWidth, (float) this.TxtureObject.Height * this.ScaleLength), new PointF(0.0f, (float) (this.TxtureObject.Height / 2)), (float) (this.Direction - Math.PI / 2.0 + this.Angle), this.Position, Color.FromArgb(this.TransparentValue, this.ColorValue));
    }

    public override void ShowRegion()
    {
      PointF originalPosition1 = this.OriginalPosition;
      PointF originalPosition2 = this.OriginalPosition;
      double num1 = (double) originalPosition2.X + (double) this.TxtureObject.Width * (double) this.ScaleWidth * 0.5 * Math.Cos(this.Direction);
      originalPosition2 = this.OriginalPosition;
      double num2 = (double) originalPosition2.Y + (double) this.TxtureObject.Width * (double) this.ScaleWidth * 0.5 * Math.Sin(this.Direction);
      this.OriginalPosition = new PointF((float) num1, (float) num2);
      this.SpriteMain.Draw2D(this.TextureObjectDictionary["Region"], (float) this.TxtureObject.Width * 0.9f / (float) this.TextureObjectDictionary["Region"].Height * this.ScaleWidth, 2f * (float) this.Region / (float) this.TextureObjectDictionary["Region"].Width * this.ScaleLength, (float) (this.Direction - Math.PI / 2.0 + this.Angle), this.Position, Color.Red, this.Mirrored);
      this.OriginalPosition = originalPosition1;
    }
  }
}
