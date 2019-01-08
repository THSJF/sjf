// Decompiled with JetBrains decompiler
// Type: Shooting.EnemyFactory
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class EnemyFactory
  {
    private readonly string[] EnemyType0 = new string[10]
    {
      "EnemyA0",
      "EnemyA1",
      "EnemyA2",
      "EnemyA3",
      "EnemyA4",
      "EnemyA5",
      "EnemyA6",
      "EnemyA7",
      "EnemyC0",
      "EnemyC1"
    };
    private readonly string[] EnemyType1 = new string[4]
    {
      "EnemyA8",
      "EnemyB1",
      "EnemyC2",
      "EnemyC3"
    };
    private readonly string[] EnemyType2 = new string[4]
    {
      "EnemyGhost0",
      "EnemyGhost1",
      "EnemyGhost2",
      "EnemyGhost3"
    };
    private readonly string[] EnemyType3 = new string[4]
    {
      "EnemyMaoYu00",
      "EnemyMaoYu01",
      "EnemyMaoYu02",
      "EnemyMaoYu03"
    };
    private readonly string[] EnemyType4 = new string[4]
    {
      "EnemyYYY4",
      "EnemyYYY5",
      "EnemyYYY6",
      "EnemyYYY7"
    };
    private int EnemyType = -1;
    private string EnemyName;
    public int HealthPoint;
    public int RedCount;
    public int BlueCount;
    public int GreenCount;
    public byte ColorType;
    public bool BackFire;
    public int ClearRadius;
    public bool StarFall;

    public EnemyFactory(string EnemyName)
    {
      this.EnemyName = EnemyName;
      if (this.ContainName(this.EnemyType0, EnemyName))
        this.EnemyType = 0;
      else if (this.ContainName(this.EnemyType1, EnemyName))
        this.EnemyType = 1;
      else if (this.ContainName(this.EnemyType2, EnemyName))
        this.EnemyType = 2;
      else if (this.ContainName(this.EnemyType3, EnemyName))
      {
        this.EnemyType = 3;
      }
      else
      {
        if (!this.ContainName(this.EnemyType4, EnemyName))
          return;
        this.EnemyType = 4;
      }
    }

    private bool ContainName(string[] EnemyType, string EnemyName)
    {
      foreach (string str in EnemyType)
      {
        if (str == EnemyName)
          return true;
      }
      return false;
    }

    public BaseEnemyPlane_Touhou GenerateEnemy(StageDataPackage StageData)
    {
      BaseEnemyPlane_Touhou enemyPlaneTouhou;
      switch (this.EnemyType)
      {
        case 0:
          this.ColorType = byte.Parse(this.EnemyName.Replace("EnemyA", "").Replace("EnemyB", "").Replace("EnemyC", ""));
          this.ColorType = this.ColorType > (byte) 3 ? (byte) ((uint) this.ColorType - 4U) : this.ColorType;
          enemyPlaneTouhou = (BaseEnemyPlane_Touhou) new EnemyPlane_TouhouSmall(StageData, this.EnemyName, new PointF(0.0f, 0.0f), 0.0f, 0.0, this.ColorType);
          if (this.BackFire)
          {
            ((EnemyPlane_TouhouSmall) enemyPlaneTouhou).SetBackFire();
            break;
          }
          break;
        case 1:
          enemyPlaneTouhou = (BaseEnemyPlane_Touhou) new EnemyPlane_TouhouBig(StageData, this.EnemyName, new PointF(0.0f, 0.0f), 0.0f, 0.0, this.ColorType);
          break;
        case 2:
          this.ColorType = byte.Parse(this.EnemyName.Replace("EnemyGhost", ""));
          enemyPlaneTouhou = (BaseEnemyPlane_Touhou) new EnemyPlane_TouhouGhost(StageData, new PointF(0.0f, 0.0f), 0.0f, 0.0, this.ColorType);
          break;
        case 3:
          this.ColorType = byte.Parse(this.EnemyName.Replace("EnemyMaoYu0", ""));
          enemyPlaneTouhou = (BaseEnemyPlane_Touhou) new EnemyPlane_TouhouMaoYu(StageData, new PointF(0.0f, 0.0f), 0.0f, 0.0, this.ColorType);
          break;
        case 4:
          this.ColorType = (byte) (int.Parse(this.EnemyName.Replace("EnemyYYY", "")) - 4);
          enemyPlaneTouhou = (BaseEnemyPlane_Touhou) new EnemyPlane_TouhouYYY(StageData, new PointF(0.0f, 0.0f), 0.0f, 0.0, this.ColorType);
          break;
        default:
          enemyPlaneTouhou = (BaseEnemyPlane_Touhou) new EnemyPlane_TouhouNormal(StageData, this.EnemyName, new PointF(0.0f, 0.0f), 0.0f, 0.0, this.ColorType);
          break;
      }
      enemyPlaneTouhou.HealthPoint = (float) this.HealthPoint;
      enemyPlaneTouhou.RedCount = this.RedCount;
      enemyPlaneTouhou.BlueCount = this.BlueCount;
      enemyPlaneTouhou.GreenCount = this.GreenCount;
      enemyPlaneTouhou.ClearRadius = this.ClearRadius;
      enemyPlaneTouhou.StarFall = this.StarFall;
      StageData.EnemyPlaneList.Remove((BaseEnemyPlane) enemyPlaneTouhou);
      return enemyPlaneTouhou;
    }
  }
}
