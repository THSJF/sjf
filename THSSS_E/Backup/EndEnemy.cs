// Decompiled with JetBrains decompiler
// Type: Shooting.EndEnemy
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class EndEnemy : BaseEffect
  {
    public EndEnemy(
      StageDataPackage StageData,
      string textureName,
      PointF Position,
      float Velocity,
      double Direction)
      : base(StageData)
    {
      this.Position = Position;
      this.Velocity = Velocity;
      this.Direction = Direction;
      this.Active = true;
      this.TransparentVelocity = -15f;
      this.ScaleVelocity = 0.1f;
      this.TxtureObject = this.TextureObjectDictionary[textureName];
    }

    public override bool OutBoundary()
    {
      return (double) this.TransparentValueF <= 0.0;
    }
  }
}
