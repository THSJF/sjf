 
// Type: Shooting.EnemyPlane_TouhouYYY
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class EnemyPlane_TouhouYYY : BaseEnemyPlane_Touhou
  {
    private BaseEffect circle0;
    private BaseEffect circle1;

    public bool BackFire { get; set; }

    public Color BackFireColor { get; set; }

    public EnemyPlane_TouhouYYY(
      StageDataPackage StageData,
      PointF OriginalPosition,
      float Velocity,
      double Direction,
      byte ColorType)
      : base(StageData, (string) null, OriginalPosition, Velocity, Direction, ColorType)
    {
      this.HealthPoint = 30f;
      this.Region = 8;
      this.TxtureObject = this.TextureObjectDictionary["EnemyYYY" + ((int) ColorType + 4).ToString() + "_1"];
      this.AngularVelocityDegree = 5f;
    }

    public override void Shoot()
    {
    }

    public override void TextureCtrl()
    {
    }

    public override void GiveEndEffect()
    {
      base.GiveEndEffect();
      this.EffectList.Remove(this.circle0);
      this.EffectList.Remove(this.circle1);
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time == 1)
      {
        StageDataPackage stageData1 = this.StageData;
        int num = (int) this.ColorType + 4;
        string textureName1 = "EnemyYYY" + num.ToString() + "_0";
        PointF position1 = this.Position;
        BaseEffect baseEffect1 = new BaseEffect(stageData1, textureName1, position1, 0.0f, 0.0);
        baseEffect1.Active = false;
        baseEffect1.AngularVelocityDegree = -5f;
        baseEffect1.AngleDegree = 90.0;
        this.circle0 = baseEffect1;
        StageDataPackage stageData2 = this.StageData;
        num = (int) this.ColorType + 4;
        string textureName2 = "EnemyYYY" + num.ToString() + "_1";
        PointF position2 = this.Position;
        BaseEffect baseEffect2 = new BaseEffect(stageData2, textureName2, position2, 0.0f, 0.0);
        baseEffect2.Scale = 1.5f;
        baseEffect2.AngularVelocityDegree = -10f;
        this.circle1 = baseEffect2;
        this.circle0.SetBinding((BaseObject) this);
        this.circle1.SetBinding((BaseObject) this);
      }
      if (!this.OutBoundary())
        return;
      this.EffectList.Remove(this.circle0);
      this.EffectList.Remove(this.circle1);
    }
  }
}
