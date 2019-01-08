 
// Type: Shooting.BaseBullet
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class BaseBullet : BaseBullet_Touhou
  {
    private int highLightValue = 0;

    public int HighLightValue
    {
      get
      {
        return this.highLightValue;
      }
      set
      {
        if (value < 0)
          this.highLightValue = 0;
        else if (value > (int) byte.MaxValue)
          this.highLightValue = (int) byte.MaxValue;
        else
          this.highLightValue = value;
      }
    }

    public BaseBullet(
      StageDataPackage StageData,
      string textureName,
      PointF OriginalPosition,
      float Velocity,
      double Direction)
      : base(StageData, textureName, OriginalPosition, Velocity, Direction)
    {
      this.HighLightValue = 200;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.HighLightValue > 0)
        this.HighLightValue -= 10;
      else
        this.HighLightValue = 0;
    }

    public override void HitCheckAll()
    {
      if (!this.MyPlane.HitEnabled || !this.HitCheck((BaseObject) this.MyPlane))
        return;
      this.MyPlane.PreMiss();
    }

    public override void GiveEndEffect()
    {
      new ParticleSmaller(this.StageData, "光点", this.Position, this.Velocity, this.Direction).LifeTime = 30;
    }

    public override void Show()
    {
      base.Show();
      if (this.HighLightValue <= 0)
        return;
      this.SpriteMain.Draw2D(this.TextureObjectDictionary["光点"].TXTure, this.TextureObjectDictionary["光点"].PosRect, new SizeF((float) this.TextureObjectDictionary["光点"].Width * this.Scale, (float) this.TextureObjectDictionary["光点"].Height * this.Scale), this.TextureObjectDictionary["光点"].RotatingCenter, (float) (this.Direction - Math.PI / 2.0), this.Position, Color.FromArgb(this.HighLightValue, Color.White));
    }
  }
}
