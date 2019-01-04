// Decompiled with JetBrains decompiler
// Type: Shooting.BaseBackground
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class BaseBackground : BaseObject_CS
  {
    public BaseBackground()
    {
    }

    public BaseBackground(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.Background.BackgroundList.Add((BaseObject) this);
    }

    public BaseBackground(
      StageDataPackage StageData,
      string textureName,
      PointF Position,
      float Velocity,
      double Direction)
      : base(StageData, textureName, Position, Velocity, Direction)
    {
      this.Background.BackgroundList.Add((BaseObject) this);
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (!this.OutBoundary())
        return;
      this.Background.BackgroundList.Remove((BaseObject) this);
    }

    public override bool HitCheck(BaseObject Target)
    {
      return false;
    }
  }
}
