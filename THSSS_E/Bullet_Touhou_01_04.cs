// Decompiled with JetBrains decompiler
// Type: Shooting.Bullet_Touhou_01_04
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class Bullet_Touhou_01_04 : Bullet_Touhou_01
  {
    public string SubBulletName { get; set; }

    public Bullet_Touhou_01_04(
      StageDataPackage StageData,
      string textureName,
      PointF OriginalPosition,
      float Velocity,
      double Direction,
      byte ColorType)
      : base(StageData, textureName, OriginalPosition, Velocity, Direction, ColorType)
    {
      this.LifeTime = 50;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time != this.LifeTime)
        return;
      byte colorType = this.ColorType;
      int num1 = (int) (this.Difficulty + 4);
      float num2 = -0.5235988f;
      float num3 = -2.094395f;
      switch (this.Difficulty)
      {
        case DifficultLevel.Easy:
          num1 = 2;
          break;
        case DifficultLevel.Normal:
          num1 = 4;
          break;
        case DifficultLevel.Hard:
          num1 = 6;
          break;
        case DifficultLevel.Lunatic:
          num1 = 7;
          break;
        case DifficultLevel.Ultra:
          num1 = 8;
          break;
      }
      float num4 = num3 / ((float) num1 - 1f);
      for (int index = 0; index < num1; ++index)
      {
        BaseBullet_Touhou baseBulletTouhou = new BaseBullet_Touhou(this.StageData, this.SubBulletName + colorType.ToString(), this.OriginalPosition, 2.5f, (double) num2, colorType);
        baseBulletTouhou.Ay = 0.08f;
        baseBulletTouhou.MaxVelocity = 2.5f;
        num2 += num4;
      }
      this.StageData.SoundPlay("se_kira01.wav");
      this.GiveEndEffect();
    }
  }
}
