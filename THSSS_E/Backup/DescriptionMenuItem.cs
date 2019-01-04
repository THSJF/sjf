// Decompiled with JetBrains decompiler
// Type: Shooting.DescriptionMenuItem
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class DescriptionMenuItem : BaseMenuItem
  {
    public string Description { get; set; }

    public Color DefaultColor { get; set; }

    public DescriptionMenuItem(StageDataPackage StageData, string Name)
    {
      this.StageData = StageData;
      this.Name = Name;
      this.MaxVelocity = 100f;
      this.Selected = false;
      this.UnSelectVisible = true;
      this.DefaultColor = Color.Gray;
    }

    public override void Ctrl()
    {
      if (!this.Enabled)
        return;
      ++this.Time;
      this.Move();
      this.Velocity += this.Accelerate;
      this.TransparentValueF += this.TransparentVelocity;
      if (this.Selected)
      {
        double num = 1.0 + Math.Sin((double) this.Time / 6.0);
        this.ColorValue = Color.Yellow;
        this.TransparentVelocity = 25f;
      }
      else
      {
        this.ColorValue = this.DefaultColor;
        if (!this.UnSelectVisible)
          this.TransparentVelocity = -25f;
      }
      if (!this.OnRemove)
        return;
      this.MaxTransparent -= 15;
    }

    public override void Select()
    {
      this.Time = 1;
      this.Selected = true;
      this.VibrateTime = 0;
      this.TwinkleTime = 0;
    }

    public override void Click()
    {
      this.Time = 1;
      this.VibrateTime = 0;
      this.TwinkleTime = this.Time + 30;
    }

    public void DrawText(string text, PointF Pos)
    {
      text = text.Replace("\t", "    ");
      text = text.Replace("\r\n", string.Empty);
      int num = 0;
      char[] charArray = text.ToCharArray();
      for (int index = 0; index < charArray.Length; ++index)
      {
        PointF position = new PointF(Pos.X + 5f + (float) num, Pos.Y + 9f);
        if (this.TextureObjectDictionary.ContainsKey(charArray[index].ToString()))
          this.SpriteMain.Draw2D(this.TextureObjectDictionary[charArray[index].ToString()], 1f, 0.0f, position, Color.FromArgb(this.TransparentValue, this.ColorValue));
        num += 11;
        if (charArray[index] == '.')
          num -= 6;
      }
    }

    public override void Show()
    {
      this.DrawText(this.Name + " " + this.Description, this.OriginalPosition);
    }
  }
}
