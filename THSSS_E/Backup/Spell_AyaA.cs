// Decompiled with JetBrains decompiler
// Type: Shooting.Spell_AyaA
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class Spell_AyaA : BaseSpell
  {
    public Spell_AyaA(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.OriginalPosition = this.MyPlane.OriginalPosition;
      this.Damage = 10;
      this.Region = 30;
      this.LifeTime = 300;
      this.Direction = Math.PI / 2.0;
      this.SpellList.Add((BaseObject) this);
      BackgroundBlack backgroundBlack = new BackgroundBlack(StageData, this.Position);
      BackgroundMySC backgroundMySc1 = new BackgroundMySC(StageData, "76-4");
      backgroundMySc1.LifeTime = 350;
      backgroundMySc1.MaxTransparent = 180;
      backgroundMySc1.TransparentValueF = 0.0f;
      backgroundMySc1.TransparentVelocity = 4f;
      backgroundMySc1.ColorValue = Color.Green;
      BackgroundMySC backgroundMySc2 = new BackgroundMySC(StageData, "76-4");
      backgroundMySc2.LifeTime = 350;
      backgroundMySc2.MaxTransparent = 150;
      backgroundMySc2.TransparentValueF = 0.0f;
      backgroundMySc2.TransparentVelocity = 4f;
      backgroundMySc2.ColorValue = Color.Green;
      backgroundMySc2.AngularVelocityDegree = -0.5f;
      backgroundMySc2.Active = true;
      StageData.VibrateStart(this.LifeTime);
      this.MyPlane.HighSpeed = 2f;
      this.MyPlane.LowSpeed = 1f;
      this.TransparentValueF = 0.0f;
      this.TransparentVelocity = 4f;
      this.ScaleLength = 0.2f;
      this.ScaleVelocity = 0.05f;
      this.MaxScale = 2f;
    }

    public override void Move()
    {
      this.OriginalPosition = this.MyPlane.OriginalPosition;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time < 16)
        this.TxtureObject = this.TextureObjectDictionary["wind" + string.Format("{0:00}", (object) (this.Time % 16 / 2))];
      else if (this.Time < 284)
        this.TxtureObject = this.TextureObjectDictionary["wind" + string.Format("{0:00}", (object) (7 + (this.Time - 16) % 36 / 2))];
      else
        this.TxtureObject = this.TextureObjectDictionary["wind" + string.Format("{0:00}", (object) (25 + (this.Time - 300 + 16) % 16 / 2))];
      this.TxtureObject.OffsetY = 100;
      if (this.Time != 240)
        return;
      this.TransparentVelocity = -4f;
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
      double y1 = (double) originalPosition1.Y;
      originalPosition1 = this.OriginalPosition;
      double y2 = (double) originalPosition1.Y;
      double num1 = y1 - y2;
      originalPosition1 = Target.OriginalPosition;
      double x1 = (double) originalPosition1.X;
      originalPosition1 = this.OriginalPosition;
      double x2 = (double) originalPosition1.X;
      double num2 = 2.79999995231628 * (x1 - x2) + 136.0;
      int num3;
      if (num1 < num2)
      {
        PointF originalPosition2 = Target.OriginalPosition;
        double y3 = (double) originalPosition2.Y;
        originalPosition2 = this.OriginalPosition;
        double y4 = (double) originalPosition2.Y;
        double num4 = y3 - y4;
        originalPosition2 = Target.OriginalPosition;
        double x3 = (double) originalPosition2.X;
        originalPosition2 = this.OriginalPosition;
        double x4 = (double) originalPosition2.X;
        double num5 = -2.79999995231628 * (x3 - x4) + 136.0;
        num3 = num4 >= num5 ? 1 : 0;
      }
      else
        num3 = 1;
      return num3 == 0;
    }

    public override void HitCheckAll()
    {
      for (int index = this.BulletList.Count - 1; index >= 0; --index)
      {
        if (this.HitCheck((BaseObject) this.BulletList[index]) && !this.BulletList[index].UnRemoveable)
        {
          this.BulletList[index].GiveEndEffect();
          this.BulletList[index].GiveItems();
          this.BulletList.RemoveAt(index);
        }
      }
      for (int index = this.EnemyPlaneList.Count - 1; index >= 0; --index)
      {
        if (this.HitCheck((BaseObject) this.EnemyPlaneList[index]))
        {
          int num = this.Damage + (int) ((400.0 - this.EnemyPlaneList[index].GetDistance((BaseObject) this.MyPlane)) / 50.0);
          if (num < this.Damage)
            num = this.Damage;
          else if (num > 19)
            num = 19;
          this.EnemyPlaneList[index].HealthPoint -= (float) num;
          if ((double) this.EnemyPlaneList[index].HealthPoint <= 0.0)
          {
            this.EnemyPlaneList[index].GiveEndEffect();
            this.EnemyPlaneList[index].GiveItems();
            this.EnemyPlaneList.RemoveAt(index);
            this.StageData.SoundPlay("se_enep00.wav");
            break;
          }
        }
      }
      if (this.Boss == null || (this.Boss.Time <= this.Boss.UnmatchedTime || !this.HitCheck((BaseObject) this.Boss)))
        return;
      int num1 = this.Damage + (int) ((400.0 - this.Boss.GetDistance((BaseObject) this.MyPlane)) / 40.0);
      if (num1 < this.Damage)
        num1 = this.Damage;
      else if (num1 > 19)
        num1 = 19;
      this.Boss.HealthPoint -= (float) (int) ((double) num1 * (1.0 - (double) this.Boss.Armon));
      if ((double) this.Boss.HealthPoint <= 200.0)
        this.StageData.SoundPlay("se_damage01.wav");
    }
  }
}
