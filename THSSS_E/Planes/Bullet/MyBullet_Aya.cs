// Decompiled with JetBrains decompiler
// Type: Shooting.MyBullet_Aya
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class MyBullet_Aya : BaseMyBullet_Touhou
  {
    public MyBullet_Aya(StageDataPackage StageData, PointF p)
      : base(StageData, "AyaBullet00", p, 30f, -1.57079637050629)
    {
      this.Damage = 20;
    }

    public override void GiveEndEffect()
    {
      Emitter2 emitter2 = new Emitter2(this.StageData, this.Position);
      ParticleEndAyaBullet particleEndAyaBullet = new ParticleEndAyaBullet(this.StageData, "AyaBullet", this.OriginalPosition, 3f, this.Direction);
    }
  }
}
