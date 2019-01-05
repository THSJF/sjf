// Decompiled with JetBrains decompiler
// Type: Shooting.EnemyPlane_TouhouGhost
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class EnemyPlane_TouhouGhost : BaseEnemyPlane_Touhou
  {
    public bool BackFire { get; set; }

    public Color BackFireColor { get; set; }

    public EnemyPlane_TouhouGhost(
      StageDataPackage StageData,
      PointF OriginalPosition,
      float Velocity,
      double Direction,
      byte ColorType)
      : base(StageData, (string) null, OriginalPosition, Velocity, Direction, ColorType)
    {
      this.HealthPoint = 30f;
      this.Scale = 0.2f;
      this.MaxScale = 1f;
      this.ScaleVelocity = 0.2f;
    }

    public override void GiveItems()
    {
      if (this.ColorType == (byte) 0 || this.ColorType == (byte) 2)
      {
        PointF OriginalPosition = new PointF();
                ref PointF local = ref OriginalPosition;
        PointF originalPosition = this.OriginalPosition;
        double num1 = (double) originalPosition.X + (double) this.Ran.Next(-5, 5);
        originalPosition = this.OriginalPosition;
        double num2 = (double) originalPosition.Y + (double) this.Ran.Next(-5, 5);
        local = new PointF((float) num1, (float) num2);
        PowerItem_Touhou powerItemTouhou = new PowerItem_Touhou(this.StageData, OriginalPosition);
      }
      else if (this.ColorType == (byte) 1 || this.ColorType == (byte) 3)
      {
        PointF pointF = new PointF();
                ref PointF local = ref pointF;
        PointF originalPosition = this.OriginalPosition;
        double num1 = (double) originalPosition.X + (double) this.Ran.Next(-5, 5);
        originalPosition = this.OriginalPosition;
        double num2 = (double) originalPosition.Y + (double) this.Ran.Next(-5, 5);
        local = new PointF((float) num1, (float) num2);
        ScoreItem_Touhou scoreItemTouhou = new ScoreItem_Touhou(this.StageData, this.OriginalPosition);
      }
      if (this.Difficulty <= DifficultLevel.Normal)
        return;
      int num3 = this.Difficulty > DifficultLevel.Hard ? 8 : 1;
      double direction = this.GetDirection((BaseObject) this.MyPlane);
      for (int index1 = 0; index1 < num3; ++index1)
      {
        for (int index2 = 0; index2 < 5; ++index2)
        {
          int num1 = (int) this.ColorType * 3 + 2;
          Bullet_Touhou_01 bulletTouhou01 = new Bullet_Touhou_01(StageData, "bullet2_" +num1,OriginalPosition, (float) (1.5 +index2*0.400000005960464), direction, (byte) num1);
        }
        direction += 2.0 * Math.PI / (double) num3;
      }
    }

    public override void Shoot()
    {
    }

    public override void TextureCtrl()
    {
      this.TxtureObject = this.TextureObjectDictionary["EnemyGhost" + (object) this.ColorType + "_" + (object) (this.Time % 32 / 4)];
      int maxValue = 6;
      PointF Position = new PointF();
            ref PointF local = ref Position;
      PointF position = this.Position;
      double num1 = (double) position.X + (double) this.Ran.Next(maxValue) * Math.Sin((double) this.Ran.Next(360) * Math.PI / 180.0);
      position = this.Position;
      double num2 = (double) position.Y + (double) this.Ran.Next(maxValue) * Math.Cos((double) this.Ran.Next(360) * Math.PI / 180.0);
      local = new PointF((float) num1, (float) num2);
      BaseEffect baseEffect = new BaseEffect(this.StageData, "EnemyGhost" + (object) this.ColorType + "_" + (object) (this.Time % 32 / 4), Position, 1.5f, -1.0 * Math.PI / 2.0);
      baseEffect.Scale = 0.5f;
      baseEffect.LifeTime = 13;
      baseEffect.ScaleVelocity = -0.04f;
    }
  }
}
