 
// Type: Shooting.HP_Line
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class HP_Line : BaseObject
  {
    private int hp = 0;

    public int HP
    {
      get
      {
        return this.hp;
      }
      set
      {
        if (value < 0)
          this.hp = 0;
        else if (value > this.MaxHP)
          this.hp = this.MaxHP;
        else
          this.hp = value;
      }
    }

    public int MaxHP { get; set; }

    public HP_Line(StageDataPackage StageData, string textureName, PointF OriginalPosition)
    {
      this.StageData = StageData;
      this.TxtureObject = this.TextureObjectDictionary[textureName];
      this.OriginalPosition = OriginalPosition;
      this.MaxHP = 1;
      this.TransparentValueF = 0.0f;
    }

    public override void Ctrl()
    {
      if (this.Boss == null)
      {
        this.TransparentValueF -= 25f;
      }
      else
      {
        base.Ctrl();
        this.MaxHP = this.Boss.MaxHP;
        if (this.HP < (int) this.Boss.HealthPoint)
          this.HP += 300;
        else
          this.HP = (int) this.Boss.HealthPoint;
        if ((double) this.MyPlane.OriginalPosition.Y < 30.0)
        {
          this.TransparentValueF -= 10f;
          if ((double) this.TransparentValueF >= 50.0)
            return;
          this.TransparentValueF = 50f;
        }
        else
          this.TransparentValueF += 10f;
      }
    }

    public override void Show()
    {
      int num = this.TxtureObject.Width * this.HP / this.MaxHP;
      Size size = new Size(num > 1 ? num : 1, this.TxtureObject.Height);
      this.SpriteMain.Draw2D(this.TxtureObject.TXTure, new Rectangle(new Point(0, 0), size), (SizeF) size, this.TxtureObject.RotatingCenter, 0.0f, this.OriginalPosition, Color.FromArgb(this.TransparentValue * 10 / 10, Color.White));
      if (this.Boss != null && (!this.Boss.OnSpell && this.Boss.SpellcardHP != 0))
        this.SpriteMain.Draw2D(this.TextureObjectDictionary["HP_Flag"], 1f, 0.0f, (PointF) new Point((int) this.OriginalPosition.X - this.TxtureObject.Width / 2 + this.TxtureObject.Width * this.Boss.SpellcardHP / this.MaxHP, (int) this.OriginalPosition.Y), Color.FromArgb(this.TransparentValue, Color.White));
      this.SpriteMain.Draw2D(this.TextureObjectDictionary["HP_Line2"], 1f, 0.0f, this.OriginalPosition, Color.FromArgb(this.TransparentValue, Color.White));
    }
  }
}
