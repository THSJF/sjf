 
// Type: Shooting.ParticleEndBullet
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class ParticleEndBullet : BaseEffect
  {
    public TextureObject[] TxtureObjects { get; set; }

    public int IndexX { get; set; }

    public ParticleEndBullet(
      StageDataPackage StageData,
      PointF OriginalPosition,
      byte ColorType,
      int Size)
      : this(StageData, OriginalPosition)
    {
      this.Scale = (float) Size / 32f;
      switch (ColorType)
      {
        case 0:
          this.ColorValue = Color.White;
          break;
        case 1:
          this.ColorValue = Color.Red;
          break;
        case 2:
          this.ColorValue = Color.Red;
          break;
        case 3:
          this.ColorValue = Color.Violet;
          break;
        case 4:
          this.ColorValue = Color.Violet;
          break;
        case 5:
          this.ColorValue = Color.Blue;
          break;
        case 6:
          this.ColorValue = Color.Blue;
          break;
        case 7:
          this.ColorValue = Color.Cyan;
          break;
        case 8:
          this.ColorValue = Color.Cyan;
          break;
        case 9:
          this.ColorValue = Color.Green;
          break;
        case 10:
          this.ColorValue = Color.Green;
          break;
        case 11:
          this.ColorValue = Color.YellowGreen;
          break;
        case 12:
          this.ColorValue = Color.Yellow;
          break;
        case 13:
          this.ColorValue = Color.Yellow;
          break;
        case 14:
          this.ColorValue = Color.Orange;
          break;
        case 15:
          this.ColorValue = Color.White;
          break;
        default:
          this.ColorValue = Color.White;
          break;
      }
    }

    public ParticleEndBullet(
      StageDataPackage StageData,
      PointF OriginalPosition,
      Color ColorValue,
      int Size)
      : this(StageData, OriginalPosition)
    {
      this.ColorValue = ColorValue;
      this.Scale = (float) Size / 32f;
    }

    public ParticleEndBullet(StageDataPackage StageData, PointF OriginalPosition)
      : base(StageData, (string) null, new PointF(0.0f, 0.0f), 0.0f, 0.0)
    {
      this.OriginalPosition = OriginalPosition;
      this.Direction = (double) this.Ran.Next(360) / 180.0 * Math.PI;
      this.TxtureObjects = new TextureObject[8]
      {
        this.TextureObjectDictionary["EndBullet00"],
        this.TextureObjectDictionary["EndBullet01"],
        this.TextureObjectDictionary["EndBullet02"],
        this.TextureObjectDictionary["EndBullet03"],
        this.TextureObjectDictionary["EndBullet04"],
        this.TextureObjectDictionary["EndBullet05"],
        this.TextureObjectDictionary["EndBullet06"],
        this.TextureObjectDictionary["EndBullet07"]
      };
      this.TxtureObject = this.TxtureObjects[0];
      this.LifeTime = 31;
      this.AngularVelocityDegree = (float) this.Ran.Next(-3, 3);
      this.ScaleVelocity = 0.05f;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.IndexX = this.Time % 32 / 4;
      this.TxtureObject = this.TxtureObjects[this.IndexX];
      if (this.Time != this.LifeTime / 2)
        return;
      this.ScaleVelocity = -this.ScaleVelocity;
    }
  }
}
