 
// Type: Shooting.SpellCardAttack
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class SpellCardAttack : BaseEffect
  {
    public SpellCardAttack(StageDataPackage StageData)
      : base(StageData)
    {
      this.LifeTime = 2;
      for (int index1 = 0; index1 < 10; ++index1)
      {
        for (int index2 = 0; index2 < 6; ++index2)
        {
          PointF pointF = new PointF((float) ((double) (index2 * 128) * Math.Cos(Math.PI / 6.0) - 50.0), (float) (200.0 - (double) (index2 * 128) * Math.Sin(Math.PI / 6.0)) + (float) (index1 * 35));
          BaseObject baseObject = new BaseObject(StageData, "SpellCircle06", new PointF(0.0f, 0.0f), 2f, -1.0 * Math.PI / 6.0)
          {
            OriginalPosition = pointF,
            Angle = -1.0 * Math.PI,
            LifeTime = 50
          };
          baseObject.TransparentVelocityDictionary.Add(30, -13f);
          if (index1 % 2 == 0)
            baseObject.Velocity *= -1f;
          this.Background2.BackgroundList.Add(baseObject);
        }
      }
    }
  }
}
