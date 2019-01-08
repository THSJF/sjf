 
// Type: Shooting.BaseInterface
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class BaseInterface : BaseObject
  {
    public int Delay { get; set; }

    public BaseInterface(StageDataPackage StageData, string textureName, PointF OriginalPosition)
    {
      this.StageData = StageData;
      if (textureName != null)
        this.TxtureObject = this.TextureObjectDictionary[textureName];
      this.OriginalPosition = OriginalPosition;
      this.TransparentVelocity = 10f;
    }

    public BaseInterface()
    {
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time > this.Delay)
        return;
      this.TransparentValueF = 0.0f;
    }

    public override void Show()
    {
      this.SpriteMain.Draw2D(this.TxtureObject, 1f, 0.0f, this.OriginalPosition, this.TxtureObject.LeftTop, Color.FromArgb(this.TransparentValue, this.ColorValue));
    }
  }
}
