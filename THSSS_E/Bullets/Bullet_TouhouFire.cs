// Decompiled with JetBrains decompiler
// Type: Shooting.Bullet_TouhouFire
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class Bullet_TouhouFire : Bullet_Touhou_01
  {
    private int timeOffset;

    public TextureObject[] TxtureObjects { get; set; }

    public Bullet_TouhouFire(
      StageDataPackage StageData,
      int type,
      PointF OriginalPosition,
      float Velocity,
      double Direction)
      : base(StageData, (string) null, OriginalPosition, Velocity, Direction, (byte) 0)
    {
      switch (type)
      {
        case 0:
          this.ColorType = (byte) 1;
          this.TxtureObjects = new TextureObject[4]
          {
            this.TextureObjectDictionary["bullet30-0"],
            this.TextureObjectDictionary["bullet30-1"],
            this.TextureObjectDictionary["bullet30-2"],
            this.TextureObjectDictionary["bullet30-3"]
          };
          this.Active = false;
          break;
        case 1:
          this.ColorType = (byte) 1;
          this.TxtureObjects = new TextureObject[4]
          {
            this.TextureObjectDictionary["bullet17-0"],
            this.TextureObjectDictionary["bullet17-1"],
            this.TextureObjectDictionary["bullet17-2"],
            this.TextureObjectDictionary["bullet17-3"]
          };
          this.Angle = 3.14159274101257;
          this.Active = true;
          break;
        case 2:
          this.ColorType = (byte) 7;
          this.TxtureObjects = new TextureObject[4]
          {
            this.TextureObjectDictionary["bullet18-0"],
            this.TextureObjectDictionary["bullet18-1"],
            this.TextureObjectDictionary["bullet18-2"],
            this.TextureObjectDictionary["bullet18-3"]
          };
          this.Angle = 3.14159274101257;
          this.Active = true;
          break;
        case 3:
          this.ColorType = (byte) 4;
          this.TxtureObjects = new TextureObject[4]
          {
            this.TextureObjectDictionary["bullet42_0"],
            this.TextureObjectDictionary["bullet42_1"],
            this.TextureObjectDictionary["bullet42_2"],
            this.TextureObjectDictionary["bullet42_3"]
          };
          this.Angle = 3.14159274101257;
          this.Active = true;
          break;
        case 4:
          this.ColorType = (byte) 14;
          this.TxtureObjects = new TextureObject[4]
          {
            this.TextureObjectDictionary["bullet43_0"],
            this.TextureObjectDictionary["bullet43_1"],
            this.TextureObjectDictionary["bullet43_2"],
            this.TextureObjectDictionary["bullet43_3"]
          };
          this.Angle = 3.14159274101257;
          this.Active = true;
          break;
        case 5:
          this.ColorType = (byte) 14;
          this.TxtureObjects = new TextureObject[4]
          {
            this.TextureObjectDictionary["bullet44_0"],
            this.TextureObjectDictionary["bullet44_1"],
            this.TextureObjectDictionary["bullet44_2"],
            this.TextureObjectDictionary["bullet44_3"]
          };
          this.Angle = 3.14159274101257;
          this.Active = true;
          break;
        default:
          this.TxtureObjects = new TextureObject[4]
          {
            this.TextureObjectDictionary["bullet30-0"],
            this.TextureObjectDictionary["bullet30-1"],
            this.TextureObjectDictionary["bullet30-2"],
            this.TextureObjectDictionary["bullet30-3"]
          };
          this.Active = true;
          break;
      }
      this.timeOffset = this.Ran.Next(16);
      this.TxtureObject = this.TxtureObjects[(this.Time + this.timeOffset) % 16 / 4];
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.TxtureObject = this.TxtureObjects[(this.Time + this.timeOffset) % 16 / 4];
    }
  }
}
