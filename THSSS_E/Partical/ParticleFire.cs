// Decompiled with JetBrains decompiler
// Type: Shooting.ParticleFire
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class ParticleFire : BaseEffect
  {
    public int ColorType { get; set; }

    public ParticleFire(
      StageDataPackage StageData,
      PointF Position,
      float Velocity,
      double Direcity)
      : base(StageData, (string) null, Position, Velocity, Direcity)
    {
      this.LifeTime = 31;
      this.Time = this.Ran.Next(32);
    }

    public override void Ctrl()
    {
      base.Ctrl();
      switch (this.ColorType)
      {
        case 0:
          this.TxtureObject = this.TextureObjectDictionary["FY_Particle0_" + (this.Time % 32 / 4).ToString()];
          break;
        case 1:
          this.TxtureObject = this.TextureObjectDictionary["FY_Particle1_" + (this.Time % 32 / 4).ToString()];
          break;
        case 2:
          this.TxtureObject = this.TextureObjectDictionary["FY_Particle2_" + (this.Time % 32 / 4).ToString()];
          break;
      }
    }
  }
}
