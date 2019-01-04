// Decompiled with JetBrains decompiler
// Type: Shooting.FullPic3
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class FullPic3 : BaseObject
  {
    public FullPic3(StageDataPackage StageData, string textureName)
    {
      this.StageData = StageData;
      Rectangle boundRect = this.BoundRect;
      int left = boundRect.Left;
      boundRect = this.BoundRect;
      int num1 = boundRect.Width / 2;
      double num2 = (double) (left + num1);
      boundRect = this.BoundRect;
      double num3 = (double) (boundRect.Bottom + 100);
      this.Position = new PointF((float) num2, (float) num3);
      this.Velocity = 9f;
      this.DirectionDegree = -90.0;
      this.Active = false;
      this.LifeTime = 200;
      this.Accelerate = -0.2f;
      this.AccelerateDictionary.Add(90, 0.1f);
      this.TransparentVelocityDictionary.Add(90, -10f);
      this.AngleWithDirection = false;
      this.AngleDegree = 90.0;
      this.TxtureObject = this.TextureObjectDictionary[textureName];
      this.Background2.BackgroundList.Add((BaseObject) this);
      this.OutsideRegion = 500;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if ((double) this.Velocity >= 1.20000004768372)
        return;
      this.Velocity = 1.2f;
    }
  }
}
