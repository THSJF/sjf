// Decompiled with JetBrains decompiler
// Type: Shooting.ParticleBossFire
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class ParticleBossFire : BaseObject
  {
    public ParticleBossFire(
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
      if (textureName != null)
        this.TxtureObject = this.TextureObjectDictionary[textureName];
      this.Active = true;
      this.Background.BackgroundList.Add((BaseObject) this);
      this.ScaleLength = 0.5f;
      this.ScaleWidth = 0.3f;
      this.DirectionDegree = (double) (90 + this.Ran.Next(-4, 5));
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time > 0)
        this.TransparentValueF -= (float) ((int) byte.MaxValue / this.LifeTime);
      if (this.Boss != null)
        this.OriginalPosition = this.Boss.OriginalPosition;
      if (this.Time > 0)
      {
        this.ScaleLength += 0.07f;
        this.ScaleWidth += 0.03f;
        this.TransparentValueF -= (float) (this.MaxTransparent / this.LifeTime);
      }
      if (!this.OutBoundary())
        return;
      this.Background.BackgroundList.Remove((BaseObject) this);
    }
  }
}
