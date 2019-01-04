// Decompiled with JetBrains decompiler
// Type: Shooting.ParticleScoreValue
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class ParticleScoreValue : BaseEffect
  {
    private char[] ScoreCharArray { get; set; }

    public ParticleScoreValue(StageDataPackage StageData, PointF OriginalPosition, long ScoreValue)
      : base(StageData, (string) null, new PointF(0.0f, 0.0f), 1f, -1.57079637050629)
    {
      this.LifeTime = 50;
      this.Active = false;
      this.OriginalPosition = OriginalPosition;
      this.ScoreCharArray = ScoreValue.ToString().ToCharArray();
    }

    public override void Ctrl()
    {
      this.Angle = -this.Direction + Math.PI / 2.0;
      base.Ctrl();
      if (this.Time <= 0)
        return;
      this.TransparentValueF -= (float) ((int) byte.MaxValue / this.LifeTime);
    }

    public override void Show()
    {
      int width = this.TextureObjectDictionary["Score_+"].Width;
      for (int index = 0; index < this.ScoreCharArray.Length; ++index)
        width += this.TextureObjectDictionary[this.ScoreCharArray[index].ToString()].Width;
      float scale = 0.6f;
      PointF position = new PointF();
            ref PointF local = ref position;
      PointF originalPosition = this.OriginalPosition;
      double num = (double) originalPosition.X - (double) width * (double) scale / 2.0;
      originalPosition = this.OriginalPosition;
      double y = (double) originalPosition.Y;
      local = new PointF((float) num, (float) y);
      this.SpriteMain.Draw2D(this.TextureObjectDictionary["Score_+"], scale, 0.0f, position, Color.FromArgb(this.TransparentValue, this.ColorValue));
      position = new PointF(position.X + (float) ((double) this.TextureObjectDictionary["Score_+"].Width * (double) scale / 2.0), position.Y);
      for (int index = 0; index < this.ScoreCharArray.Length; ++index)
      {
        position = new PointF(position.X + (float) ((double) this.TextureObjectDictionary["Score_" + this.ScoreCharArray[index].ToString()].Width * (double) scale / 2.0), position.Y);
        this.SpriteMain.Draw2D(this.TextureObjectDictionary["Score_" + this.ScoreCharArray[index].ToString()], scale, 0.0f, position, Color.FromArgb(this.TransparentValue, this.ColorValue));
        position = new PointF(position.X + (float) ((double) this.TextureObjectDictionary["Score_" + this.ScoreCharArray[index].ToString()].Width * (double) scale / 2.0), position.Y);
      }
    }
  }
}
