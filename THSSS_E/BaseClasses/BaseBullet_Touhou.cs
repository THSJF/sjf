 
// Type: Shooting.BaseBullet_Touhou
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class BaseBullet_Touhou : BaseObject_CS
  {
    public int Layer { get; set; }

    public byte ColorType { get; set; }

    public int SizeValue { get; set; }

    public byte Reflect { get; set; }

    public bool Grazed { get; set; }

    public BaseBullet_Touhou(StageDataPackage StageData)
      : base(StageData)
    {
    }

    public BaseBullet_Touhou(
      StageDataPackage StageData,
      string textureName,
      PointF OriginalPosition,
      float Velocity,
      double Direction,
      byte ColorType)
      : this(StageData, textureName, OriginalPosition, Velocity, Direction)
    {
      this.ColorType = ColorType;
      this.BeginningEffect = true;
    }

    public BaseBullet_Touhou(
      StageDataPackage StageData,
      string textureName,
      PointF OriginalPosition,
      float Velocity,
      double Direction)
      : base(StageData, textureName, OriginalPosition, Velocity, Direction)
    {
      this.BulletList.Add(this);
      this.OriginalPosition = OriginalPosition;
      this.AngleDegree = 180.0;
      this.SizeValue = 32;
      this.SetRegion(textureName);
    }

    public void SetRegion(string textureName)
    {
      if (textureName == null)
        return;
      char[] chArray = new char[1]{ '_' };
      switch (textureName.Split(chArray)[0])
      {
        case "bullet0":
          this.Region = 1;
          break;
        case "bullet1":
          this.Region = 1;
          break;
        case "bullet2":
          this.Region = 2;
          break;
        case "bullet3":
          this.Region = 2;
          break;
        case "bullet4":
          this.Region = 1;
          break;
        case "bullet5":
          this.Region = 1;
          break;
        case "bullet6":
          this.Region = 1;
          break;
        case "bullet7":
          this.Region = 1;
          break;
        case "bullet8":
          this.Region = 1;
          break;
        case "bullet9":
          this.Region = 1;
          break;
        case "bullet10":
          this.Region = 2;
          break;
        case "bullet11":
          this.Region = 2;
          break;
        case "bullet12":
          this.Region = 1;
          break;
        case "bullet13":
          this.Region = 3;
          break;
        case "bullet15":
          this.Region = 1;
          break;
        case "bullet20":
          this.Region = 6;
          break;
        case "bullet21":
          this.Region = 6;
          break;
        case "bullet22":
          this.Region = 3;
          break;
        case "bullet23":
          this.Region = 3;
          break;
        case "bullet24":
          this.Region = 3;
          break;
        case "bullet26":
          this.Region = 16;
          this.AngularVelocityDegree = 10f;
          this.Active = true;
          this.SizeValue = 80;
          this.OutsideRegion = 32;
          break;
        case "bullet50":
          this.Region = 12;
          this.Active = true;
          this.SizeValue = 64;
          this.OutsideRegion = 64;
          break;
        case "bullet40":
          this.Region = 6;
          this.SizeValue = 32;
          this.OutsideRegion = 32;
          break;
        case "bullet46":
          this.Region = 1;
          break;
        case "bullet61":
          this.Region = 2;
          break;
        case "bullet62":
          this.Region = 3;
          break;
        case "bullet64":
          this.Region = 3;
          break;
        case "bullet65":
          this.Region = 3;
          break;
        case "bullet66":
          this.Region = 3;
          break;
        case "bullet67":
          this.Region = 3;
          break;
      }
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time == 1 && this.BeginningEffect)
        new ParticleBeginBullet(this.StageData, this.Position, this.ColorType).Active = this.Active;
      if (this.Time == this.LifeTime && this.EndingEffect)
        this.GiveEndEffect();
      if (!this.OutBoundary())
        return;
      this.BulletList.Remove(this);
    }

    public override bool OutBoundary()
    {
      if (this.LifeTime != 0 && this.Time > this.LifeTime)
        return true;
      if (this.Reflect <= (byte) 0)
        return base.OutBoundary();
      PointF originalPosition = this.OriginalPosition;
      if ((double) originalPosition.X < 0.0)
      {
        --this.Reflect;
        this.Direction -= 2.0 * (this.Direction - Math.PI / 2.0);
        originalPosition = this.OriginalPosition;
        double num = -(double) originalPosition.X;
        originalPosition = this.OriginalPosition;
        double y = (double) originalPosition.Y;
        this.OriginalPosition = new PointF((float) num, (float) y);
      }
      else
      {
        originalPosition = this.OriginalPosition;
        double x1 = (double) originalPosition.X;
        Rectangle boundRect = this.BoundRect;
        double width = (double) boundRect.Width;
        if (x1 >= width)
        {
          --this.Reflect;
          this.Direction -= 2.0 * (this.Direction - Math.PI / 2.0);
          boundRect = this.BoundRect;
          double num1 = (double) (2 * boundRect.Width);
          originalPosition = this.OriginalPosition;
          double x2 = (double) originalPosition.X;
          double num2 = num1 - x2;
          originalPosition = this.OriginalPosition;
          double y = (double) originalPosition.Y;
          this.OriginalPosition = new PointF((float) num2, (float) y);
        }
      }
      originalPosition = this.OriginalPosition;
      if ((double) originalPosition.Y < 20.0 && this.Reflect > (byte) 0)
      {
        --this.Reflect;
        this.Direction = -this.Direction;
        originalPosition = this.OriginalPosition;
        double x = (double) originalPosition.X;
        originalPosition = this.OriginalPosition;
        double num = 20.0 - (double) originalPosition.Y;
        this.OriginalPosition = new PointF((float) x, (float) num);
      }
      return false;
    }

    public override void HitCheckAll()
    {
      if (!this.MyPlane.HitEnabled)
        return;
      if (this.HitCheck((BaseObject) this.MyPlane))
      {
        this.MyPlane.PreMiss();
        if (this.UnRemoveable)
          return;
        this.GiveEndEffect();
        this.BulletList.Remove(this);
      }
      else
      {
        if (this.Grazed || !this.HitCheck((BaseObject) this.MyPlane, 24f / this.ScaleLength + (float) this.Region))
          return;
        this.Grazed = true;
        ++this.MyPlane.Graze;
        if (this.MyPlane.Graze % 10 == 0)
          this.MyPlane.HighItemScore += 10;
        this.StageData.SoundPlay("se_graze.wav");
        BaseEffect baseEffect = new BaseEffect(this.StageData, "GrazeG", this.MyPlane.Position, 5f, this.Ran.NextDouble() * Math.PI * 2.0);
        baseEffect.Scale = 1f;
        baseEffect.TransparentVelocity = -20f;
        baseEffect.ScaleVelocity = -0.05f;
        baseEffect.AngleWithDirection = false;
      }
    }

    public override void GiveEndEffect()
    {
      ParticleEndBullet particleEndBullet = new ParticleEndBullet(this.StageData, this.OriginalPosition, this.ColorType, this.SizeValue);
    }

    public override void GiveItems()
    {
      StarItem_Touhou starItemTouhou = new StarItem_Touhou(this.StageData, this.OriginalPosition);
    }
  }
}
