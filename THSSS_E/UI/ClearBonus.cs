 
// Type: Shooting.ClearBonus
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class ClearBonus : BaseEffect
  {
    private int Index = 0;
    private PointF ValuePoint;

    private char[] BonusCharArray { get; set; }

    public ClearBonus(StageDataPackage StageData, int Bonus)
      : base(StageData)
    {
      this.Layer = 1;
      this.LifeTime = 150;
      this.TxtureObject = this.TextureObjectDictionary["StageClear"];
      this.MyPlane.Score += (long) Bonus;
      this.TransparentVelocity = 6f;
      this.TransparentValueF = 0.0f;
      this.OriginalPosition = new PointF((float) (this.BoundRect.Width / 2), 150f);
      this.AngleDegree = 90.0;
      this.BonusCharArray = Bonus.ToString().ToCharArray();
      int num = 0;
      for (int index = 0; index < this.BonusCharArray.Length; ++index)
        num += this.TextureObjectDictionary["Num" + this.BonusCharArray[index].ToString()].Width;
      this.ValuePoint = new PointF(this.OriginalPosition.X - (float) (num / 2), this.OriginalPosition.Y + 36f);
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time == 100)
        this.TransparentVelocity = -6f;
      if (this.Time != 20)
        return;
      for (; this.Index < this.BonusCharArray.Length; ++this.Index)
      {
        this.ValuePoint = new PointF(this.ValuePoint.X + (float) (this.TextureObjectDictionary["Num" + this.BonusCharArray[this.Index].ToString()].Width / 2), this.ValuePoint.Y);
        BaseEffect baseEffect1 = new BaseEffect(this.StageData, "Num" + this.BonusCharArray[this.Index].ToString(), new PointF(0.0f, 0.0f), 0.0f, Math.PI / 2.0);
        baseEffect1.Active = false;
        baseEffect1.OriginalPosition = this.ValuePoint;
        baseEffect1.ColorValue = Color.FromArgb((int) byte.MaxValue - this.Index * 10, (int) byte.MaxValue - this.Index * 5, (int) byte.MaxValue - this.Index * 10);
        baseEffect1.LifeTime = 100;
        baseEffect1.TransparentValueF = 0.0f;
        BaseEffect baseEffect2 = baseEffect1;
        baseEffect2.TransparentVelocityDictionary.Add(1, 13f);
        baseEffect2.TransparentVelocityDictionary.Add(80, -13f);
        this.ValuePoint = new PointF(this.ValuePoint.X + (float) (this.TextureObjectDictionary["Num" + this.BonusCharArray[this.Index].ToString()].Width / 2), this.ValuePoint.Y);
      }
    }
  }
}
