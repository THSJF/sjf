using SlimDX.Direct3D9;
using System;
using System.Drawing;

namespace Shooting
{
  public class MarisaLaser : BaseEffect
  {
    public MarisaLaser(
      StageDataPackage StageData,
      string textureName,
      PointF OriginalPosition,
      float v,
      double drctn)
      : base(StageData, textureName, new PointF(0.0f, 0.0f), v, drctn)
    {
      this.StageData = StageData;
      this.OriginalPosition = OriginalPosition;
      this.Damage = 4;
      this.Region = 128;
      this.MaxVelocity = 1000f;
      this.MinVelocity = -1000f;
      this.Velocity = v;
      this.LifeTime = 5;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.Velocity = 192f;
      bool flag = false;
      for (int index = this.EnemyPlaneList.Count - 1; index >= 0; --index)
      {
        if (this.HitCheck((BaseObject) this.EnemyPlaneList[index]))
        {
          flag = true;
          if (this.MyPlane.EnchantmentState == EnchantmentType.Red)
            this.EnemyPlaneList[index].HealthPoint -= (float) this.Damage * 1.25f;
          else
            this.EnemyPlaneList[index].HealthPoint -= (float) this.Damage;
          if ((double) this.EnemyPlaneList[index].HealthPoint < 10000.0)
            this.MyPlane.Score += 10L;
          if ((double) this.EnemyPlaneList[index].HealthPoint <= 0.0)
          {
            this.EnemyPlaneList[index].GiveEndEffect();
            this.EnemyPlaneList[index].GiveItems();
            this.EnemyPlaneList.RemoveAt(index);
            this.StageData.SoundPlay("se_enep00.wav", this.OriginalPosition.X / (float) this.BoundRect.Width);
            break;
          }
        }
      }
      if (this.Boss != null && this.HitCheck((BaseObject) this.Boss))
      {
        flag = true;
        if (this.Boss.Time > this.Boss.UnmatchedTime)
        {
          if (this.MyPlane.EnchantmentState == EnchantmentType.Red)
            this.Boss.HealthPoint -= (float) ((double) this.Damage * 1.25 * (1.0 - (double) this.Boss.Armon));
          else
            this.Boss.HealthPoint -= (float) this.Damage * (1f - this.Boss.Armon);
        }
        this.MyPlane.Score += 10L;
        if ((double) this.Boss.HealthPoint <= 200.0)
          this.StageData.SoundPlay("se_damage01.wav");
      }
      if (!flag)
        return;
      this.Damage = 0;
    }

    public override bool HitCheck(BaseObject Target)
    {
      double distance = this.GetDistance(Target);
      double direction = this.GetDirection(Target);
      double num1 = distance * Math.Cos(this.Direction - direction);
      double num2 = distance * Math.Sin(this.Direction - direction);
      double num3 = (double) this.TxtureObject.Width * (double) this.ScaleWidth * 0.5;
      double num4 = (double) this.TxtureObject.Height * (double) this.ScaleLength * 0.5;
      return num2 * num2 / num4 / num4 + (num1 - 256.0 + 64.0 - (double) this.TxtureObject.Height * (double) this.ScaleLength / 2.0) * (num1 - 256.0 + 64.0 - (double) this.TxtureObject.Height * (double) this.ScaleLength / 2.0) / num3 / num3 < 1.0;
    }

    public override void Show()
    {
      int num1 = this.TimeMain % 8 * 8;
      SizeF sizeF = new SizeF((float) (this.TxtureObject.Width - 64) * this.ScaleWidth, (float) this.TxtureObject.Height * this.ScaleLength);
      MySprite spriteMain = this.SpriteMain;
      Texture txTure = this.TxtureObject.TXTure;
      Rectangle posRect = this.TxtureObject.PosRect;
      int x = posRect.X + 64 - num1;
      posRect = this.TxtureObject.PosRect;
      int y = posRect.Y;
      posRect = this.TxtureObject.PosRect;
      int width = posRect.Width - 64;
      posRect = this.TxtureObject.PosRect;
      int height = posRect.Height;
      Rectangle srcRectangle = new Rectangle(x, y, width, height);
      SizeF destinationSize = sizeF;
      PointF rotationCenter = new PointF((float) ((this.TxtureObject.Width - 64) / 2), (float) (this.TxtureObject.Height / 2));
      double num2 = this.Direction - Math.PI / 2.0 + this.Angle;
      PointF position = this.Position;
      Color color = Color.FromArgb(this.TransparentValue, this.ColorValue);
      spriteMain.Draw2D(txTure, srcRectangle, destinationSize, rotationCenter, (float) num2, position, color);
    }

    public override void ShowRegion()
    {
      this.SpriteMain.Draw2D(this.TextureObjectDictionary["Region"], (float) (this.TxtureObject.Width - 64) * 1f / (float) this.TextureObjectDictionary["Region"].Width * this.ScaleWidth, (float) this.TxtureObject.Height * 1f / (float) this.TextureObjectDictionary["Region"].Height * this.ScaleLength, (float) (this.Direction - Math.PI / 2.0 + this.Angle), this.Position, Color.White, this.Mirrored);
    }
  }
}
