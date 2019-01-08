 
// Type: Shooting.ParticleEndAyaBullet
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class ParticleEndAyaBullet : BaseEffect
  {
    public TextureObject[] TxtureObjects { get; set; }

    public int IndexX { get; set; }

    public ParticleEndAyaBullet(
      StageDataPackage StageData,
      string Name,
      PointF OriginalPosition,
      float Velocity,
      double Direction)
      : base(StageData, (string) null, OriginalPosition, Velocity, Direction)
    {
      this.OriginalPosition = OriginalPosition;
      this.TxtureObjects = new TextureObject[4]
      {
        this.TextureObjectDictionary[Name + "00"],
        this.TextureObjectDictionary[Name + "01"],
        this.TextureObjectDictionary[Name + "02"],
        this.TextureObjectDictionary[Name + "03"]
      };
      this.TxtureObject = this.TxtureObjects[0];
      this.LifeTime = 15;
      this.Angle = 1.57079637050629;
      this.MaxTransparent = 80;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.IndexX = this.Time % 16 / 4;
      this.TxtureObject = this.TxtureObjects[this.IndexX];
      this.TransparentValueF -= (float) (this.MaxTransparent / this.LifeTime);
      this.Scale += 0.1f;
    }
  }
}
