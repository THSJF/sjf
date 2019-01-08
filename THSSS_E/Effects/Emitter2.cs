 
// Type: Shooting.Emitter2
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class Emitter2 : BaseEffect
  {
    public Emitter2(StageDataPackage StageData, PointF Position)
      : base(StageData)
    {
      this.Position = Position;
      this.Velocity = 0.0f;
      this.Direction = 0.0;
      this.LifeTime = 2;
    }

    public override void Shoot()
    {
      for (int index = 0; index < 1; ++index)
      {
        string str = this.MyPlane.Name == "Aya" ? "MyParticle" : "MyParticle01";
        string textureName;
        switch (this.MyPlane.Name)
        {
          case "Aya":
            textureName = "MyParticle";
            break;
          case "Reimu":
            textureName = "Light01";
            break;
          case "Marisa":
            textureName = "Light03";
            break;
          case "Sanae":
            textureName = "Light04";
            break;
          case "Koishi":
            textureName = "Light05";
            break;
          default:
            textureName = "MyParticle01";
            break;
        }
        ParticleSmaller particleSmaller = new ParticleSmaller(this.StageData, textureName, this.Position, (float) (this.Ran.Next(100, 300) / 10), (double) this.Ran.Next(0, 180) / 180.0 * Math.PI);
        particleSmaller.LifeTime = 10;
        particleSmaller.Scale = (float) this.Ran.Next(60) / 100f;
        particleSmaller.TransparentValueF = 200f;
        particleSmaller.Accelerate = -particleSmaller.Velocity / (float) particleSmaller.LifeTime;
      }
    }
  }
}
