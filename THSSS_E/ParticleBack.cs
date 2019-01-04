// Decompiled with JetBrains decompiler
// Type: Shooting.ParticleBack
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class ParticleBack : BaseEffect
  {
    public float AngularVelocity { get; set; }

    public ParticleBack(
      StageDataPackage StageData,
      string textureName,
      PointF Position,
      float Velocity,
      double Diretion)
    {
      this.StageData = StageData;
      this.Position = Position;
      this.Velocity = Velocity;
      this.Direction = Diretion;
      this.TxtureObject = this.TextureObjectDictionary[textureName];
      this.LifeTime = 200;
      this.TransparentValueF = 0.0f;
      this.AngularVelocity = 0.01f;
      this.EffectList.Add((BaseEffect) this);
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.Angle += (double) this.AngularVelocity;
      if (0 < this.Time && this.Time < this.LifeTime / 3)
      {
        this.TransparentValueF += (float) (765 / this.LifeTime);
      }
      else
      {
        if (this.LifeTime * 2 / 3 >= this.Time || this.Time >= this.LifeTime)
          return;
        this.TransparentValueF -= (float) ((int) byte.MaxValue / this.LifeTime * 3);
      }
    }
  }
}
