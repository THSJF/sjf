// Decompiled with JetBrains decompiler
// Type: Shooting.TransitionIn
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class TransitionIn : BaseObject
  {
    public int Delay { get; set; }

    public TransitionIn(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.TxtureObject = this.TextureObjectDictionary["MenuBackground"];
      this.OriginalPosition = new PointF(0.0f, 0.0f);
      this.TransparentValueF = (float) byte.MaxValue;
      StageData.InterfaceList.Add((BaseObject) this);
      this.Delay = 1;
      this.LifeTime = 50;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time <= this.Delay)
        return;
      this.TransparentValueF -= (float) ((int) byte.MaxValue / (this.LifeTime - this.Delay));
    }

    public override void Show()
    {
      this.SpriteMain.Draw2D(this.TxtureObject, 1f, 0.0f, this.OriginalPosition, this.TxtureObject.LeftTop, Color.FromArgb(this.TransparentValue, Color.Black));
    }
  }
}
