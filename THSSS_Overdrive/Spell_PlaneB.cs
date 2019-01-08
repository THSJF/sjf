// Decompiled with JetBrains decompiler
// Type: Shooting.Spell_PlaneB
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class Spell_PlaneB : BaseSpell
  {
    public Spell_PlaneB(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.OriginalPosition = this.MyPlane.OriginalPosition;
            this.Damage=0;// 45;
      this.Region = 30;
      this.LifeTime = 390;
      this.Direction = Math.PI / 2.0;
      this.SpellList.Add((BaseObject) this);
      new BackgroundBlack(StageData, this.Position).LifeTime = 410;
      this.MyPlane.HighSpeed = 1.6f;
      this.MyPlane.LowSpeed = 0.8f;
      new EmitterSaveEnegy3(StageData, this.Position).SetBinding((BaseObject) this);
      StageData.SoundPlay("boss_change.wav");
    }

    public override void Move()
    {
      this.OriginalPosition = this.MyPlane.OriginalPosition;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time < 90)
        return;
      if (this.Time == 90)
      {
        this.StageData.SoundPlay("se_nep00.wav");
        this.StageData.SoundPlay("se_spell.wav");
        this.StageData.VibrateStart(300);
        PointF OriginalPosition = new PointF(this.OriginalPosition.X, this.OriginalPosition.Y + 70f);
        PlaneSpark planeSpark1 = new PlaneSpark(this.StageData, "Master Spark", OriginalPosition, 0.0f, -1.0 * Math.PI / 2.0);
        planeSpark1.MaxScaleW = 1f;
        planeSpark1.MaxScaleL = 3f;
        planeSpark1.SetBinding((BaseObject) this);
        PlaneSpark planeSpark2 = new PlaneSpark(this.StageData, "Master Spark", OriginalPosition, 0.0f, -1.0 * Math.PI / 2.0);
        planeSpark2.MaxScaleW = 1.6f;
        planeSpark2.MaxScaleL = 3f;
        planeSpark2.SetBinding((BaseObject) this);
        PlaneSpark planeSpark3 = new PlaneSpark(this.StageData, "Master Spark", OriginalPosition, 0.0f, -1.0 * Math.PI / 2.0);
        planeSpark3.MaxScaleW = 2.2f;
        planeSpark3.MaxScaleL = 3f;
        planeSpark3.SetBinding((BaseObject) this);
      }
      if (this.Time == this.LifeTime - 30)
        this.Damage = 20;
      if ((double) this.MyPlane.Position.Y >= (double) this.BoundRect.Bottom)
        return;
      this.MyPlane.Position = new PointF(this.MyPlane.Position.X, this.MyPlane.Position.Y + 8f);
    }

    public override bool OutBoundary()
    {
      bool flag = base.OutBoundary();
      if (flag)
      {
        this.MyPlane.HighSpeed = 5f;
        this.MyPlane.LowSpeed = 2f;
      }
      return flag;
    }

    public override bool HitCheck(BaseObject Target)
    {
      PointF originalPosition1 = Target.OriginalPosition;
      double y = (double) originalPosition1.Y;
      originalPosition1 = this.OriginalPosition;
      double num1 = (double) originalPosition1.Y + 5.0;
      int num2;
      if (y < num1)
      {
        PointF originalPosition2 = this.OriginalPosition;
        double num3 = (double) originalPosition2.X - 120.0;
        originalPosition2 = Target.OriginalPosition;
        double x1 = (double) originalPosition2.X;
        if (num3 < x1)
        {
          originalPosition2 = Target.OriginalPosition;
          double x2 = (double) originalPosition2.X;
          originalPosition2 = this.OriginalPosition;
          double num4 = (double) originalPosition2.X + 120.0;
          num2 = x2 >= num4 ? 1 : 0;
          goto label_4;
        }
      }
      num2 = 1;
label_4:
      return num2 == 0;
    }

    public override void HitCheckAll()
    {
      if (this.Time < 90)
        return;
      base.HitCheckAll();
    }
  }
}
