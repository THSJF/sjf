// Decompiled with JetBrains decompiler
// Type: Shooting.SpellClock
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class SpellClock : BaseObject
  {
    private int timeRemaining;

    public int TimeRemaining
    {
      get
      {
        return this.timeRemaining;
      }
      set
      {
        if (value < 0)
          this.timeRemaining = 0;
        else if (value > 5940)
          this.timeRemaining = 5940;
        else
          this.timeRemaining = value;
      }
    }

    public SpellClock(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.OriginalPosition = new PointF((float) (this.BoundRect.Left + 25), 40f);
    }

    public override void Ctrl()
    {
      if (this.Boss == null)
        return;
      base.Ctrl();
      this.TimeRemaining = this.Boss.SpellTime - this.Boss.Time;
      if (this.Boss.Life > 0)
      {
        if (this.TimeRemaining <= 300)
        {
          this.ColorValue = Color.FromArgb((int) byte.MaxValue, 100, 100);
          if (0 < this.TimeRemaining && this.TimeRemaining % 60 == 0)
          {
            if (this.TimeRemaining <= 120)
              this.StageData.SoundPlay("se_timeout2.wav");
            else
              this.StageData.SoundPlay("se_timeout.wav");
          }
        }
        else if (this.TimeRemaining <= 600)
          this.ColorValue = Color.FromArgb((int) byte.MaxValue, 200, 200);
        else
          this.ColorValue = Color.White;
      }
      int num1;
      if ((double) this.MyPlane.OriginalPosition.Y < 30.0)
      {
        double x1 = (double) this.MyPlane.OriginalPosition.X;
        PointF originalPosition = this.OriginalPosition;
        double num2 = (double) originalPosition.X + 60.0;
        if (x1 < num2)
        {
          originalPosition = this.MyPlane.OriginalPosition;
          double x2 = (double) originalPosition.X;
          originalPosition = this.OriginalPosition;
          double num3 = (double) originalPosition.X - 60.0;
          num1 = x2 <= num3 ? 1 : 0;
          goto label_18;
        }
      }
      num1 = 1;
label_18:
      if (num1 == 0)
      {
        this.TransparentValueF -= 10f;
        if ((double) this.TransparentValueF >= 50.0)
          return;
        this.TransparentValueF = 50f;
      }
      else
        this.TransparentValueF += 10f;
    }

    public override void Show()
    {
      if (this.Boss == null || this.Boss.Life <= 0)
        return;
      this.SpriteMain.Draw2D(this.TextureObjectDictionary["球球"], 1f, 0.0f, this.OriginalPosition, Color.FromArgb(this.TransparentValue, Color.White));
      string str = "tsnum";
      int num1 = 3;
      int num2 = 9;
      int num3 = 0;
      char[] charArray = ((float) this.TimeRemaining / 60f).ToString("F1").ToCharArray();
      for (int index = charArray.Length - 1; index >= 0; --index)
      {
        if (charArray[index] == '.')
        {
          num2 = 10;
          str = "tnum";
          num3 = 4;
        }
        PointF position = new PointF(this.OriginalPosition.X + 18f - (float) ((22 - num2) * (charArray.Length - 1 - index)) + (float) num3, this.OriginalPosition.Y + (float) num1);
        this.SpriteMain.Draw2D(this.TextureObjectDictionary[str + charArray[index].ToString()], this.Scale, 0.0f, position, Color.FromArgb(this.TransparentValue, this.ColorValue));
        if (charArray[index] == '.')
        {
          num1 = 0;
          num2 = 3;
          num3 = 20;
        }
      }
    }
  }
}
