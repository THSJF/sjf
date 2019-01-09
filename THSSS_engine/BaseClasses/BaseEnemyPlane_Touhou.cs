 
// Type: Shooting.BaseEnemyPlane_Touhou
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  public class BaseEnemyPlane_Touhou : BaseEnemyPlane
  {
    private TextureObject[,] TxtureObjects { get; set; }

    private float IndexX { get; set; }

    private int IndexY { get; set; }

    public byte ColorType { get; set; }

    public int ItemCount
    {
      set
      {
        this.RedCount = value;
        this.BlueCount = value;
      }
    }

    public int RedCount { get; set; }

    public int BlueCount { get; set; }

    public int GreenCount { get; set; }

    public int ClearRadius { get; set; }

    public bool StarFall { get; set; }

    public BaseEnemyPlane_Touhou()
    {
    }

    public BaseEnemyPlane_Touhou(
      StageDataPackage StageData,
      string EnemyName,
      PointF OriginalPosition,
      float Velocity,
      double Direction,
      byte ColorType)
      : this(StageData, EnemyName, OriginalPosition, Velocity, Direction)
    {
      this.ColorType = ColorType;
    }

    public BaseEnemyPlane_Touhou(
      StageDataPackage StageData,
      string EnemyName,
      PointF OriginalPosition,
      float Velocity,
      double Direction)
      : base(StageData, (string) null, OriginalPosition, Velocity, Direction)
    {
      this.OriginalPosition = OriginalPosition;
      if (EnemyName != null)
        this.TxtureObjects = new TextureObject[2, 8]
        {
          {
            this.TextureObjectDictionary[EnemyName + "_0"],
            this.TextureObjectDictionary[EnemyName + "_1"],
            this.TextureObjectDictionary[EnemyName + "_2"],
            this.TextureObjectDictionary[EnemyName + "_3"],
            this.TextureObjectDictionary[EnemyName + "_0"],
            this.TextureObjectDictionary[EnemyName + "_1"],
            this.TextureObjectDictionary[EnemyName + "_2"],
            this.TextureObjectDictionary[EnemyName + "_3"]
          },
          {
            this.TextureObjectDictionary[EnemyName + "_4"],
            this.TextureObjectDictionary[EnemyName + "_5"],
            this.TextureObjectDictionary[EnemyName + "_6"],
            this.TextureObjectDictionary[EnemyName + "_7"],
            this.TextureObjectDictionary[EnemyName + "_8"],
            this.TextureObjectDictionary[EnemyName + "_9"],
            this.TextureObjectDictionary[EnemyName + "_A"],
            this.TextureObjectDictionary[EnemyName + "_B"]
          }
        };
      this.EventGroupList = new List<EventGroup>();
      this.EventsExecutionList = new List<Execution>();
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.TextureCtrl();
    }

    public virtual void TextureCtrl()
    {
      this.AngleWithDirection = false;
      this.Angle = Math.PI / 2.0;
      int num = this.Mirrored ? this.IndexY : -this.IndexY;
      if ((double) this.Vx < -0.5)
      {
        this.Mirrored = true;
        this.IndexY = 1;
        if ((double) this.IndexX < 3.0)
          this.IndexX += 0.1666667f;
        else
          this.IndexX = (float) (3 + this.Time % 24 / 6);
      }
      else if ((double) this.Vx > 0.5)
      {
        this.Mirrored = false;
        this.IndexY = 1;
        if ((double) this.IndexX < 3.0)
          this.IndexX += 0.1666667f;
        else
          this.IndexX = (float) (3 + this.Time % 24 / 6);
      }
      else
      {
        this.Mirrored = false;
        this.IndexY = 0;
        this.IndexX = (float) (this.Time % 48 / 6);
      }
      if (num != (this.Mirrored ? this.IndexY : -this.IndexY))
        this.IndexX = 0.0f;
      if ((double) this.IndexX > 7.0)
        this.IndexX = 7f;
      this.TxtureObject = this.TxtureObjects[this.IndexY, (int) this.IndexX];
    }

    public override void Shoot()
    {
    }

    public override void GiveEndEffect()
    {
      Color color;
      switch (this.ColorType)
      {
        case 0:
          color = Color.Red;
          new EndEnemy(this.StageData, "EndEnemy0", this.Position, 0.0f, 0.0).Scale = 0.2f;
          break;
        case 1:
          color = Color.CornflowerBlue;
          new EndEnemy(this.StageData, "EndEnemy1", this.Position, 0.0f, 0.0).Scale = 0.2f;
          break;
        case 2:
          color = Color.Green;
          new EndEnemy(this.StageData, "EndEnemy2", this.Position, 0.0f, 0.0).Scale = 0.2f;
          break;
        case 3:
          color = Color.Yellow;
          new EndEnemy(this.StageData, "EndEnemy3", this.Position, 0.0f, 0.0).Scale = 0.2f;
          break;
        default:
          color = Color.White;
          new EndEnemy(this.StageData, "EndEnemy2", this.Position, 0.0f, 0.0).Scale = 0.2f;
          new EndEnemy(this.StageData, "EndEnemy3", this.Position, 0.0f, 0.0).Scale = 0.2f;
          break;
      }
      for (int index = 0; index < 10; ++index)
      {
        Particle3D3 particle3D3 = new Particle3D3(this.StageData, "Effect-0", this.OriginalPosition, (float) this.Ran.Next(40) / 10f, (double) this.Ran.Next(360) / 180.0 * 3.14159274101257, 40);
        particle3D3.Angle = (double) this.StageData.Ran.Next(0, 360) * 3.14159274101257 / 180.0;
        particle3D3.AngularVelocity3D = (float) this.StageData.Ran.Next(10, 30) / 100f;
        particle3D3.Scale = (float) this.StageData.Ran.Next(12, 18) / 10f;
        particle3D3.RotatingAxis = new Vector3((float) this.StageData.Ran.Next(-100, 100), (float) this.StageData.Ran.Next(-100, 100), (float) this.StageData.Ran.Next(-100, 100));
        particle3D3.ColorValue = color;
        particle3D3.MaxTransparent = 200;
      }
    }

    public override void GiveItems()
    {
      PointF OriginalPosition = new PointF();
            for (int index = 0; index < this.RedCount; ++index)
      {
        ref PointF local = ref OriginalPosition;
        PointF originalPosition = this.OriginalPosition;
        double num1 = (double) originalPosition.X + (double) this.Ran.Next(-this.RedCount * 5, this.RedCount * 5);
        originalPosition = this.OriginalPosition;
        double num2 = (double) originalPosition.Y + (double) this.Ran.Next(-this.RedCount * 5, this.RedCount * 5);
        local = new PointF((float) num1, (float) num2);
        PowerItem_Touhou powerItemTouhou = new PowerItem_Touhou(this.StageData, OriginalPosition);
      }
      for (int index = 0; index < this.BlueCount; ++index)
      {
        ref PointF local = ref OriginalPosition;
        PointF originalPosition = this.OriginalPosition;
        double num1 = (double) originalPosition.X + (double) this.Ran.Next(-this.BlueCount * 5, this.BlueCount * 5);
        originalPosition = this.OriginalPosition;
        double num2 = (double) originalPosition.Y + (double) this.Ran.Next(-this.BlueCount * 5, this.BlueCount * 5);
        local = new PointF((float) num1, (float) num2);
        ScoreItem_Touhou scoreItemTouhou = new ScoreItem_Touhou(this.StageData, OriginalPosition);
      }
      for (int index = 0; index < this.GreenCount; ++index)
      {
        ref PointF local = ref OriginalPosition;
        PointF originalPosition = this.OriginalPosition;
        double num1 = (double) originalPosition.X + (double) this.Ran.Next(-this.GreenCount * 5, this.GreenCount * 5);
        originalPosition = this.OriginalPosition;
        double num2 = (double) originalPosition.Y + (double) this.Ran.Next(-this.GreenCount * 5, this.GreenCount * 5);
        local = new PointF((float) num1, (float) num2);
        BeliefItem_Touhou beliefItemTouhou = new BeliefItem_Touhou(this.StageData, OriginalPosition);
      }
      if (this.ClearRadius != 0)
      {
        BulletRemover_Small bulletRemoverSmall = new BulletRemover_Small(this.StageData, this.OriginalPosition);
        bulletRemoverSmall.Region = this.ClearRadius;
        bulletRemoverSmall.LifeTime = 60;
      }
      if (!this.StarFall)
        return;
      BaseEffect baseEffect = new BaseEffect(this.StageData, "StarShardBS", this.Position, 8f, -1.0 * Math.PI / 2.0);
      baseEffect.GhostingCount = 40;
      baseEffect.AngularVelocityDegree = 5f;
      ShootingStarShard shootingStarShard = new ShootingStarShard(this.StageData, new PointF(this.OriginalPosition.X, 0.0f));
    }

    public override void EventCtrl()
    {
      this.EventGroupList.ForEach((Action<EventGroup>) (a => a.Update((BaseObject_CS) this)));
      this.EventsExecutionList.ForEach((Action<Execution>) (a => a.Update((BaseObject_CS) this)));
    }
  }
}
