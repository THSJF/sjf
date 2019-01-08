// Decompiled with JetBrains decompiler
// Type: Shooting.MyPlane_Reimu
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  public class MyPlane_Reimu : BaseMyPlane_Touhou
  {
    public MyPlane_Reimu(StageDataPackage StageData, Point OriginalPosition)
      : base(StageData, OriginalPosition, "Reimu")
    {
      this.WeaponType = "A";
      this.SubPlaneList = new List<BaseSubPlane>()
      {
        (BaseSubPlane) new Shinmyoumaru(StageData, this.Position),
        (BaseSubPlane) new SubPlane_Reimu(StageData, this.Position),
        (BaseSubPlane) new SubPlane_Reimu(StageData, this.Position),
        (BaseSubPlane) new SubPlane_Reimu(StageData, this.Position)
      };
      this.HighSpeed = 4.5f;
      this.LowSpeed = 2f;
    }

    public override void Shoot()
    {
      if (this.Time % 3 == 0)
      {
        this.StageData.SoundPlay("se_plst00.wav", this.OriginalPosition.X / (float) this.BoundRect.Width);
        float x = this.OriginalPosition.X;
        float y = this.OriginalPosition.Y;
        new BaseMyBullet_Touhou(this.StageData, "ReimuBullet", new PointF(x - 7f, y), 30f, -1.0 * Math.PI / 2.0).Damage = 14;
        new BaseMyBullet_Touhou(this.StageData, "ReimuBullet", new PointF(x + 7f, y), 30f, -1.0 * Math.PI / 2.0).Damage = 14;
      }
      if (this.Time % 4 != 0)
        return;
      for (int index = 0; index < this.PowerLevel; ++index)
        this.SubPlaneList[index].Shoot();
    }

    public override void SpellShoot()
    {
      if (this.KClass.Key_Shift)
      {
        Spell_Reimu spellReimu = new Spell_Reimu(this.StageData);
      }
      else
      {
        Spell_Shinmyoumaru spellShinmyoumaru = new Spell_Shinmyoumaru(this.StageData);
      }
    }

    public override void SubPlaneCtrl()
    {
      if (this.KClass.Key_Shift)
      {
        switch (this.PowerLevel)
        {
          case 1:
            this.SubPlanePoint[0] = new PointF(this.OriginalPosition.X, this.OriginalPosition.Y - 70f);
            this.SubPlaneList[0].ShootDirection = -1.0 * Math.PI / 2.0;
            break;
          case 2:
            ref PointF local1 = ref this.SubPlanePoint[0];
            double num1 = (double) this.OriginalPosition.X - 0.0;
            PointF originalPosition1 = this.OriginalPosition;
            double num2 = (double) originalPosition1.Y - 70.0;
            PointF pointF1 = new PointF((float) num1, (float) num2);
            local1 = pointF1;
            ref PointF local2 = ref this.SubPlanePoint[1];
            originalPosition1 = this.OriginalPosition;
            double num3 = (double) originalPosition1.X + 0.0;
            originalPosition1 = this.OriginalPosition;
            double num4 = (double) originalPosition1.Y - 70.0;
            PointF pointF2 = new PointF((float) num3, (float) num4);
            local2 = pointF2;
            this.SubPlaneList[0].ShootDirection = -1.0 * Math.PI / 2.0;
            this.SubPlaneList[1].ShootDirection = -1.0 * Math.PI / 2.0;
            break;
          case 3:
            ref PointF local3 = ref this.SubPlanePoint[0];
            double x1 = (double) this.OriginalPosition.X;
            PointF originalPosition2 = this.OriginalPosition;
            double num5 = (double) originalPosition2.Y - 70.0;
            PointF pointF3 = new PointF((float) x1, (float) num5);
            local3 = pointF3;
            ref PointF local4 = ref this.SubPlanePoint[1];
            originalPosition2 = this.OriginalPosition;
            double num6 = (double) originalPosition2.X - 24.0;
            originalPosition2 = this.OriginalPosition;
            double num7 = (double) originalPosition2.Y - 0.0;
            PointF pointF4 = new PointF((float) num6, (float) num7);
            local4 = pointF4;
            ref PointF local5 = ref this.SubPlanePoint[2];
            originalPosition2 = this.OriginalPosition;
            double num8 = (double) originalPosition2.X + 24.0;
            originalPosition2 = this.OriginalPosition;
            double num9 = (double) originalPosition2.Y - 0.0;
            PointF pointF5 = new PointF((float) num8, (float) num9);
            local5 = pointF5;
            this.SubPlaneList[0].ShootDirection = -1.0 * Math.PI / 2.0;
            this.SubPlaneList[1].ShootDirection = 109.0 * Math.PI / 72.0;
            this.SubPlaneList[2].ShootDirection = 107.0 * Math.PI / 72.0;
            break;
          case 4:
            ref PointF local6 = ref this.SubPlanePoint[0];
            double num10 = (double) this.OriginalPosition.X - 0.0;
            PointF originalPosition3 = this.OriginalPosition;
            double num11 = (double) originalPosition3.Y - 70.0;
            PointF pointF6 = new PointF((float) num10, (float) num11);
            local6 = pointF6;
            ref PointF local7 = ref this.SubPlanePoint[1];
            originalPosition3 = this.OriginalPosition;
            double num12 = (double) originalPosition3.X + 0.0;
            originalPosition3 = this.OriginalPosition;
            double num13 = (double) originalPosition3.Y - 70.0;
            PointF pointF7 = new PointF((float) num12, (float) num13);
            local7 = pointF7;
            ref PointF local8 = ref this.SubPlanePoint[2];
            originalPosition3 = this.OriginalPosition;
            double num14 = (double) originalPosition3.X - 24.0;
            originalPosition3 = this.OriginalPosition;
            double num15 = (double) originalPosition3.Y - 0.0;
            PointF pointF8 = new PointF((float) num14, (float) num15);
            local8 = pointF8;
            ref PointF local9 = ref this.SubPlanePoint[3];
            originalPosition3 = this.OriginalPosition;
            double num16 = (double) originalPosition3.X + 24.0;
            originalPosition3 = this.OriginalPosition;
            double num17 = (double) originalPosition3.Y - 0.0;
            PointF pointF9 = new PointF((float) num16, (float) num17);
            local9 = pointF9;
            this.SubPlaneList[0].ShootDirection = -1.0 * Math.PI / 2.0;
            this.SubPlaneList[1].ShootDirection = -1.0 * Math.PI / 2.0;
            this.SubPlaneList[2].ShootDirection = 109.0 * Math.PI / 72.0;
            this.SubPlaneList[3].ShootDirection = 107.0 * Math.PI / 72.0;
            break;
        }
      }
      else
      {
        switch (this.PowerLevel)
        {
          case 1:
            this.SubPlanePoint[0] = new PointF(this.OriginalPosition.X, this.OriginalPosition.Y - 48f);
            this.SubPlaneList[0].ShootDirection = -1.0 * Math.PI / 2.0;
            break;
          case 2:
            ref PointF local10 = ref this.SubPlanePoint[0];
            double num18 = (double) this.OriginalPosition.X - 0.0;
            PointF originalPosition4 = this.OriginalPosition;
            double num19 = (double) originalPosition4.Y - 48.0;
            PointF pointF10 = new PointF((float) num18, (float) num19);
            local10 = pointF10;
            ref PointF local11 = ref this.SubPlanePoint[1];
            originalPosition4 = this.OriginalPosition;
            double num20 = (double) originalPosition4.X + 0.0;
            originalPosition4 = this.OriginalPosition;
            double num21 = (double) originalPosition4.Y + 48.0;
            PointF pointF11 = new PointF((float) num20, (float) num21);
            local11 = pointF11;
            this.SubPlaneList[0].ShootDirection = -1.0 * Math.PI / 2.0;
            this.SubPlaneList[1].ShootDirection = -1.0 * Math.PI / 2.0;
            break;
          case 3:
            ref PointF local12 = ref this.SubPlanePoint[0];
            double x2 = (double) this.OriginalPosition.X;
            PointF originalPosition5 = this.OriginalPosition;
            double num22 = (double) originalPosition5.Y - 48.0;
            PointF pointF12 = new PointF((float) x2, (float) num22);
            local12 = pointF12;
            ref PointF local13 = ref this.SubPlanePoint[1];
            originalPosition5 = this.OriginalPosition;
            double num23 = (double) originalPosition5.X - 48.0;
            originalPosition5 = this.OriginalPosition;
            double num24 = (double) originalPosition5.Y + 0.0;
            PointF pointF13 = new PointF((float) num23, (float) num24);
            local13 = pointF13;
            ref PointF local14 = ref this.SubPlanePoint[2];
            originalPosition5 = this.OriginalPosition;
            double num25 = (double) originalPosition5.X + 48.0;
            originalPosition5 = this.OriginalPosition;
            double num26 = (double) originalPosition5.Y + 0.0;
            PointF pointF14 = new PointF((float) num25, (float) num26);
            local14 = pointF14;
            this.SubPlaneList[0].ShootDirection = -1.0 * Math.PI / 2.0;
            this.SubPlaneList[1].ShootDirection = -1.0 * Math.PI / 2.0;
            this.SubPlaneList[2].ShootDirection = -1.0 * Math.PI / 2.0;
            break;
          case 4:
            ref PointF local15 = ref this.SubPlanePoint[0];
            double x3 = (double) this.OriginalPosition.X;
            PointF originalPosition6 = this.OriginalPosition;
            double num27 = (double) originalPosition6.Y - 48.0;
            PointF pointF15 = new PointF((float) x3, (float) num27);
            local15 = pointF15;
            ref PointF local16 = ref this.SubPlanePoint[1];
            originalPosition6 = this.OriginalPosition;
            double x4 = (double) originalPosition6.X;
            originalPosition6 = this.OriginalPosition;
            double num28 = (double) originalPosition6.Y + 48.0;
            PointF pointF16 = new PointF((float) x4, (float) num28);
            local16 = pointF16;
            ref PointF local17 = ref this.SubPlanePoint[2];
            originalPosition6 = this.OriginalPosition;
            double num29 = (double) originalPosition6.X - 48.0;
            originalPosition6 = this.OriginalPosition;
            double num30 = (double) originalPosition6.Y + 0.0;
            PointF pointF17 = new PointF((float) num29, (float) num30);
            local17 = pointF17;
            ref PointF local18 = ref this.SubPlanePoint[3];
            originalPosition6 = this.OriginalPosition;
            double num31 = (double) originalPosition6.X + 48.0;
            originalPosition6 = this.OriginalPosition;
            double num32 = (double) originalPosition6.Y + 0.0;
            PointF pointF18 = new PointF((float) num31, (float) num32);
            local18 = pointF18;
            this.SubPlaneList[0].ShootDirection = -1.0 * Math.PI / 2.0;
            this.SubPlaneList[1].ShootDirection = -1.0 * Math.PI / 2.0;
            this.SubPlaneList[2].ShootDirection = -1.0 * Math.PI / 2.0;
            this.SubPlaneList[3].ShootDirection = -1.0 * Math.PI / 2.0;
            break;
        }
      }
      for (int index = 0; index < this.PowerLevel; ++index)
      {
        this.SubPlaneList[index].Enabled = true;
        this.SubPlaneList[index].DestPoint = this.SubPlanePoint[index];
        this.SubPlaneList[index].Ctrl();
      }
      for (int powerLevel = this.PowerLevel; powerLevel < this.SubPlaneList.Count; ++powerLevel)
      {
        this.SubPlaneList[powerLevel].Enabled = false;
        this.SubPlaneList[powerLevel].Position = this.Position;
      }
    }
  }
}
