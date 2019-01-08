 
// Type: Shooting.ParticleBossFire2
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class ParticleBossFire2 : BaseObject
  {
    public double AngularVelocity { get; set; }

    public ParticleBossFire2(
      StageDataPackage StageData,
      string textureName,
      PointF OriginalPosition,
      float Velocity,
      double Direction,
      int LifeTime)
    {
      this.StageData = StageData;
      this.Velocity = Velocity;
      this.Direction = Direction;
      this.OriginalPosition = OriginalPosition;
      this.LifeTime = LifeTime;
      this.Scale = 0.01f;
      this.AngularVelocity = (double) this.Ran.Next(-2, 2) * Math.PI / 180.0;
      if (textureName != null)
        this.TxtureObject = this.TextureObjectDictionary[textureName];
      this.Active = true;
      this.Background.BackgroundList.Add((BaseObject) this);
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time > 0)
        this.TransparentValueF -= (float) ((int) byte.MaxValue / this.LifeTime);
      if (this.Boss != null)
        this.OriginalPosition = this.Boss.OriginalPosition;
      this.Direction += this.AngularVelocity;
      if (this.Time > 0)
      {
        this.Scale += 0.025f;
        this.TransparentValueF -= (float) (this.MaxTransparent / this.LifeTime);
      }
      if (!this.OutBoundary())
        return;
      this.Background.BackgroundList.Remove((BaseObject) this);
    }
  }
}
