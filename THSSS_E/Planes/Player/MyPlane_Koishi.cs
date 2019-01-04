// Decompiled with JetBrains decompiler
// Type: Shooting.MyPlane_Koishi
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  public class MyPlane_Koishi : BaseMyPlane_Touhou
  {
    private bool GodMode;

    public MyPlane_Koishi(StageDataPackage StageData, Point OriginalPosition)
      : base(StageData, OriginalPosition, "Koishi")
    {
      this.WeaponType = "A";
      this.SubPlaneList = new List<BaseSubPlane>()
      {
        (BaseSubPlane) new SubPlane_Koishi(StageData, this.Position),
        (BaseSubPlane) new SubPlane_Koishi(StageData, this.Position),
        (BaseSubPlane) new SubPlane_Koishi(StageData, this.Position),
        (BaseSubPlane) new SubPlane_Koishi(StageData, this.Position)
      };
      this.HighSpeed = 5f;
      this.LowSpeed = 2f;
    }

    public override void Shoot()
    {
      if (this.Time % 3 == 0)
      {
        this.StageData.SoundPlay("se_plst00.wav", this.OriginalPosition.X / (float) this.BoundRect.Width);
        float x = this.OriginalPosition.X;
        float y = this.OriginalPosition.Y;
        new BaseMyBullet_Touhou(this.StageData, "KoishiBullet", new PointF(x + 7f, y), 30f, -1.0 * Math.PI / 2.0).Damage = 13;
        new BaseMyBullet_Touhou(this.StageData, "KoishiBullet", new PointF(x - 7f, y), 30f, -1.0 * Math.PI / 2.0).Damage = 13;
      }
      if (this.Time % 10 != 0)
        return;
      for (int index = 0; index < this.PowerLevel; ++index)
        this.SubPlaneList[index].Shoot();
    }

    public override void SpellShoot()
    {
      if (this.GodMode)
        return;
      Spell_Koishi spellKoishi = new Spell_Koishi(this.StageData);
      this.GodMode = true;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.TransparentVelocity = this.GodMode ? -10f : 10f;
      this.TransparentValueF += this.TransparentVelocity;
      this.SpellEnabled = !this.GodMode;
    }

    public override void SubPlaneCtrl()
    {
      if (this.KClass.Key_Shift)
      {
        switch (this.PowerLevel)
        {
          case 1:
            this.SubPlanePoint[0] = new PointF(this.OriginalPosition.X, this.OriginalPosition.Y - 44f);
            this.SubPlaneList[0].ShootDirection = -1.0 * Math.PI / 2.0;
            break;
          case 2:
            ref PointF local1 = ref this.SubPlanePoint[0];
            double num1 = (double) this.OriginalPosition.X - 7.0;
            PointF originalPosition1 = this.OriginalPosition;
            double num2 = (double) originalPosition1.Y - 36.0;
            PointF pointF1 = new PointF((float) num1, (float) num2);
            local1 = pointF1;
            ref PointF local2 = ref this.SubPlanePoint[1];
            originalPosition1 = this.OriginalPosition;
            double num3 = (double) originalPosition1.X + 7.0;
            originalPosition1 = this.OriginalPosition;
            double num4 = (double) originalPosition1.Y - 36.0;
            PointF pointF2 = new PointF((float) num3, (float) num4);
            local2 = pointF2;
            this.SubPlaneList[0].ShootDirection = -1.0 * Math.PI / 2.0;
            this.SubPlaneList[1].ShootDirection = -1.0 * Math.PI / 2.0;
            break;
          case 3:
            ref PointF local3 = ref this.SubPlanePoint[2];
            double x1 = (double) this.OriginalPosition.X;
            PointF originalPosition2 = this.OriginalPosition;
            double num5 = (double) originalPosition2.Y - 36.0;
            PointF pointF3 = new PointF((float) x1, (float) num5);
            local3 = pointF3;
            ref PointF local4 = ref this.SubPlanePoint[1];
            originalPosition2 = this.OriginalPosition;
            double num6 = (double) originalPosition2.X - 16.0;
            originalPosition2 = this.OriginalPosition;
            double num7 = (double) originalPosition2.Y - 29.0;
            PointF pointF4 = new PointF((float) num6, (float) num7);
            local4 = pointF4;
            ref PointF local5 = ref this.SubPlanePoint[0];
            originalPosition2 = this.OriginalPosition;
            double num8 = (double) originalPosition2.X + 16.0;
            originalPosition2 = this.OriginalPosition;
            double num9 = (double) originalPosition2.Y - 29.0;
            PointF pointF5 = new PointF((float) num8, (float) num9);
            local5 = pointF5;
            this.SubPlaneList[2].ShootDirection = -1.0 * Math.PI / 2.0;
            this.SubPlaneList[1].ShootDirection = -1.0 * Math.PI / 2.0;
            this.SubPlaneList[0].ShootDirection = -1.0 * Math.PI / 2.0;
            break;
          case 4:
            ref PointF local6 = ref this.SubPlanePoint[3];
            double num10 = (double) this.OriginalPosition.X - 7.0;
            PointF originalPosition3 = this.OriginalPosition;
            double num11 = (double) originalPosition3.Y - 36.0;
            PointF pointF6 = new PointF((float) num10, (float) num11);
            local6 = pointF6;
            ref PointF local7 = ref this.SubPlanePoint[2];
            originalPosition3 = this.OriginalPosition;
            double num12 = (double) originalPosition3.X + 7.0;
            originalPosition3 = this.OriginalPosition;
            double num13 = (double) originalPosition3.Y - 36.0;
            PointF pointF7 = new PointF((float) num12, (float) num13);
            local7 = pointF7;
            ref PointF local8 = ref this.SubPlanePoint[1];
            originalPosition3 = this.OriginalPosition;
            double num14 = (double) originalPosition3.X - 16.0;
            originalPosition3 = this.OriginalPosition;
            double num15 = (double) originalPosition3.Y - 29.0;
            PointF pointF8 = new PointF((float) num14, (float) num15);
            local8 = pointF8;
            ref PointF local9 = ref this.SubPlanePoint[0];
            originalPosition3 = this.OriginalPosition;
            double num16 = (double) originalPosition3.X + 16.0;
            originalPosition3 = this.OriginalPosition;
            double num17 = (double) originalPosition3.Y - 29.0;
            PointF pointF9 = new PointF((float) num16, (float) num17);
            local9 = pointF9;
            this.SubPlaneList[3].ShootDirection = -1.0 * Math.PI / 2.0;
            this.SubPlaneList[2].ShootDirection = -1.0 * Math.PI / 2.0;
            this.SubPlaneList[1].ShootDirection = -1.0 * Math.PI / 2.0;
            this.SubPlaneList[0].ShootDirection = -1.0 * Math.PI / 2.0;
            break;
        }
      }
      else
      {
        switch (this.PowerLevel)
        {
          case 1:
            this.SubPlanePoint[0] = new PointF(this.OriginalPosition.X, this.OriginalPosition.Y - 44f);
            this.SubPlaneList[0].ShootDirection = -1.0 * Math.PI / 2.0;
            break;
          case 2:
            ref PointF local10 = ref this.SubPlanePoint[0];
            double num18 = (double) this.OriginalPosition.X - 32.0;
            PointF originalPosition4 = this.OriginalPosition;
            double num19 = (double) originalPosition4.Y - 32.0;
            PointF pointF10 = new PointF((float) num18, (float) num19);
            local10 = pointF10;
            ref PointF local11 = ref this.SubPlanePoint[1];
            originalPosition4 = this.OriginalPosition;
            double num20 = (double) originalPosition4.X + 32.0;
            originalPosition4 = this.OriginalPosition;
            double num21 = (double) originalPosition4.Y - 32.0;
            PointF pointF11 = new PointF((float) num20, (float) num21);
            local11 = pointF11;
            this.SubPlaneList[0].ShootDirection = 5.0 * Math.PI / 4.0;
            this.SubPlaneList[1].ShootDirection = 7.0 * Math.PI / 4.0;
            break;
          case 3:
            ref PointF local12 = ref this.SubPlanePoint[2];
            double x2 = (double) this.OriginalPosition.X;
            PointF originalPosition5 = this.OriginalPosition;
            double num22 = (double) originalPosition5.Y + 44.0;
            PointF pointF12 = new PointF((float) x2, (float) num22);
            local12 = pointF12;
            ref PointF local13 = ref this.SubPlanePoint[1];
            originalPosition5 = this.OriginalPosition;
            double num23 = (double) originalPosition5.X - 32.0;
            originalPosition5 = this.OriginalPosition;
            double num24 = (double) originalPosition5.Y - 32.0;
            PointF pointF13 = new PointF((float) num23, (float) num24);
            local13 = pointF13;
            ref PointF local14 = ref this.SubPlanePoint[0];
            originalPosition5 = this.OriginalPosition;
            double num25 = (double) originalPosition5.X + 32.0;
            originalPosition5 = this.OriginalPosition;
            double num26 = (double) originalPosition5.Y - 32.0;
            PointF pointF14 = new PointF((float) num25, (float) num26);
            local14 = pointF14;
            this.SubPlaneList[2].ShootDirection = Math.PI / 2.0;
            this.SubPlaneList[1].ShootDirection = 5.0 * Math.PI / 4.0;
            this.SubPlaneList[0].ShootDirection = 7.0 * Math.PI / 4.0;
            break;
          case 4:
            ref PointF local15 = ref this.SubPlanePoint[3];
            double num27 = (double) this.OriginalPosition.X - 32.0;
            PointF originalPosition6 = this.OriginalPosition;
            double num28 = (double) originalPosition6.Y + 32.0;
            PointF pointF15 = new PointF((float) num27, (float) num28);
            local15 = pointF15;
            ref PointF local16 = ref this.SubPlanePoint[2];
            originalPosition6 = this.OriginalPosition;
            double num29 = (double) originalPosition6.X + 32.0;
            originalPosition6 = this.OriginalPosition;
            double num30 = (double) originalPosition6.Y + 32.0;
            PointF pointF16 = new PointF((float) num29, (float) num30);
            local16 = pointF16;
            ref PointF local17 = ref this.SubPlanePoint[1];
            originalPosition6 = this.OriginalPosition;
            double num31 = (double) originalPosition6.X - 32.0;
            originalPosition6 = this.OriginalPosition;
            double num32 = (double) originalPosition6.Y - 32.0;
            PointF pointF17 = new PointF((float) num31, (float) num32);
            local17 = pointF17;
            ref PointF local18 = ref this.SubPlanePoint[0];
            originalPosition6 = this.OriginalPosition;
            double num33 = (double) originalPosition6.X + 32.0;
            originalPosition6 = this.OriginalPosition;
            double num34 = (double) originalPosition6.Y - 32.0;
            PointF pointF18 = new PointF((float) num33, (float) num34);
            local18 = pointF18;
            this.SubPlaneList[3].ShootDirection = 3.0 * Math.PI / 4.0;
            this.SubPlaneList[2].ShootDirection = Math.PI / 4.0;
            this.SubPlaneList[1].ShootDirection = 5.0 * Math.PI / 4.0;
            this.SubPlaneList[0].ShootDirection = 7.0 * Math.PI / 4.0;
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

    public override void PreMiss()
    {
      if (this.Time < this.UnmatchedTime || this.Time < this.UnmatchedTime || (this.Time < this.DeadTime || this.SpellList.Count != 0))
        return;
      if (this.EnchantmentState == EnchantmentType.Green)
      {
        new BulletRemover_Small(this.StageData, this.OriginalPosition).Region = 500;
        this.ChangeEnchantment(EnchantmentType.None);
        this.EnemyPlaneList.ForEach((Action<BaseEnemyPlane>) (x =>
        {
          if (!(x is BaseSpellCard))
            return;
          ((BaseSpellCard) x).Missed = true;
        }));
      }
      else if (this.GodMode)
      {
        this.GodMode = false;
        this.StageData.SoundPlay("ice005.wav");
        new BulletRemover_Small(this.StageData, this.MyPlane.OriginalPosition).Region = 150;
        this.Time = this.UnmatchedTime - 60;
        ItemGetter itemGetter = new ItemGetter(this.StageData);
        this.EnemyPlaneList.ForEach((Action<BaseEnemyPlane>) (x =>
        {
          if (!(x is BaseSpellCard))
            return;
          ((BaseSpellCard) x).Missed = true;
        }));
      }
      else
      {
        Emitter emitter = new Emitter(this.StageData, this.MyPlane.Position);
        this.StageData.SoundPlay("se_pldead00.wav", this.OriginalPosition.X / (float) this.BoundRect.Width);
        this.DeadTime = this.Time + 20;
      }
    }

    public override void Refresh()
    {
      if (this.GodMode)
      {
        this.SpellExtand();
        this.GodMode = false;
      }
      base.Refresh();
    }

    public override void Show()
    {
      if (this.Time < this.DeadTime || this.Time == 0)
        return;
      if (this.Time < this.UnmatchedTime && this.Time / 2 % 2 == 0)
        this.SpriteMain.Draw2D(this.TxtureObject, 1f, 0.0f, this.Position, Color.FromArgb(this.TransparentValue, Color.DarkBlue));
      else
        this.SpriteMain.Draw2D(this.TxtureObject, 1f, 0.0f, this.Position, Color.FromArgb(this.TransparentValue, Color.White));
      if (this.GodMode)
        this.SpriteMain.Draw2D(this.TextureObjectDictionary["jiejie"], 1f, (float) (-this.Direction * 4.0), this.Position, Color.FromArgb((int) byte.MaxValue - this.TransparentValue, Color.White));
      for (int index = 0; index < this.PowerLevel; ++index)
        this.SubPlaneList[index].Show();
    }
  }
}
