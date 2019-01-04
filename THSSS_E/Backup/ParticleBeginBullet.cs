// Decompiled with JetBrains decompiler
// Type: Shooting.ParticleBeginBullet
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class ParticleBeginBullet : BaseEffect
  {
    public TextureObject[] TxtureObjects { get; set; }

    public int IndexX { get; set; }

    public ParticleBeginBullet(StageDataPackage StageData, PointF Position, byte ColorType)
      : this(StageData, Position)
    {
      switch (ColorType)
      {
        case 0:
          this.TxtureObject = this.TextureObjectDictionary["bullet25_0"];
          break;
        case 1:
          this.TxtureObject = this.TextureObjectDictionary["bullet25_1"];
          break;
        case 2:
          this.TxtureObject = this.TextureObjectDictionary["bullet25_1"];
          break;
        case 3:
          this.TxtureObject = this.TextureObjectDictionary["bullet25_2"];
          break;
        case 4:
          this.TxtureObject = this.TextureObjectDictionary["bullet25_2"];
          break;
        case 5:
          this.TxtureObject = this.TextureObjectDictionary["bullet25_3"];
          break;
        case 6:
          this.TxtureObject = this.TextureObjectDictionary["bullet25_3"];
          break;
        case 7:
          this.TxtureObject = this.TextureObjectDictionary["bullet25_4"];
          break;
        case 8:
          this.TxtureObject = this.TextureObjectDictionary["bullet25_4"];
          break;
        case 9:
          this.TxtureObject = this.TextureObjectDictionary["bullet25_5"];
          break;
        case 10:
          this.TxtureObject = this.TextureObjectDictionary["bullet25_5"];
          break;
        case 11:
          this.TxtureObject = this.TextureObjectDictionary["bullet25_5"];
          break;
        case 12:
          this.TxtureObject = this.TextureObjectDictionary["bullet25_6"];
          break;
        case 13:
          this.TxtureObject = this.TextureObjectDictionary["bullet25_6"];
          break;
        case 14:
          this.TxtureObject = this.TextureObjectDictionary["bullet25_6"];
          break;
        case 15:
          this.TxtureObject = this.TextureObjectDictionary["bullet25_7"];
          break;
        default:
          this.TxtureObject = this.TextureObjectDictionary["bullet25_0"];
          break;
      }
    }

    public ParticleBeginBullet(StageDataPackage StageData, PointF Position)
      : base(StageData, (string) null, Position, 0.0f, 0.0)
    {
      this.Direction = (double) this.Ran.Next(360) * Math.PI / 180.0;
      this.TxtureObject = this.TextureObjectDictionary["bullet25_0"];
      this.LifeTime = 8;
      this.Scale = 2f;
      this.Active = false;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.LifeTime - 8 >= this.Time || this.Time >= this.LifeTime)
        return;
      this.TransparentValueF -= (float) (this.MaxTransparent / 8);
    }
  }
}
