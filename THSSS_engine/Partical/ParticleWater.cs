 
// Type: Shooting.ParticleWater
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class ParticleWater : BaseEffect
  {
    public TextureObject[] TxtureObjects { get; set; }

    public ParticleWater(StageDataPackage StageData, PointF p, float v, double drctn)
      : base(StageData, (string) null, p, v, drctn)
    {
      this.TxtureObjects = new TextureObject[6]
      {
        this.TextureObjectDictionary["588-1"],
        this.TextureObjectDictionary["589-1"],
        this.TextureObjectDictionary["590-1"],
        this.TextureObjectDictionary["591-1"],
        this.TextureObjectDictionary["592-1"],
        this.TextureObjectDictionary["593-1"]
      };
      this.LifeTime = 17;
      this.Ay = 0.6f;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.TxtureObject = this.TxtureObjects[this.Time % 18 / 3];
    }
  }
}
