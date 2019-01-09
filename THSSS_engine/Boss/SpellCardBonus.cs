 
// Type: Shooting.SpellCardBonus
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class SpellCardBonus : BaseEffect
  {
    private int Index = 0;
    private PointF ValuePoint;

    private char[] BonusCharArray { get; set; }

    public SpellCardBonus(StageDataPackage StageData, long Bonus)
      : base(StageData)
    {
      this.Layer = 1;
      this.LifeTime = 150;
      this.TxtureObject = this.TextureObjectDictionary["GetSpellCardBonus"];
      this.MyPlane.Score += Bonus;
      this.TransparentVelocity = 100f;
      this.TransparentValueF = 0.0f;
      this.OriginalPosition = new PointF((float) (this.BoundRect.Width / 2), 120f);
      this.AngleDegree = 90.0;
      this.BonusCharArray = Bonus.ToString().ToCharArray();
      int num = 0;
      for (int index = 0; index < this.BonusCharArray.Length; ++index)
        num += this.TextureObjectDictionary["Num" + this.BonusCharArray[index].ToString()].Width;
      this.ValuePoint = new PointF(this.OriginalPosition.X - (float) (num / 2), this.OriginalPosition.Y + 40f);
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time == 100)
        this.TransparentVelocity = -10f;
      if (this.Time < 20 || this.Time % 4 != 0 || this.Index >= this.BonusCharArray.Length)
        return;
      this.ValuePoint = new PointF(this.ValuePoint.X + (float) (this.TextureObjectDictionary["Num" + this.BonusCharArray[this.Index].ToString()].Width / 2), this.ValuePoint.Y);
      new ParticleBonusNum(this.StageData, "Num" + this.BonusCharArray[this.Index].ToString(), this.ValuePoint).ColorValue = Color.FromArgb((int) byte.MaxValue - this.Index * 10, (int) byte.MaxValue - this.Index * 5, (int) byte.MaxValue - this.Index * 10);
      this.ValuePoint = new PointF(this.ValuePoint.X + (float) (this.TextureObjectDictionary["Num" + this.BonusCharArray[this.Index].ToString()].Width / 2), this.ValuePoint.Y);
      ++this.Index;
    }
  }
}
