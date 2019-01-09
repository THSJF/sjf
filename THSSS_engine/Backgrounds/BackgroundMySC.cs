 
// Type: Shooting.BackgroundMySC
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class BackgroundMySC : BaseObject
  {
    public BackgroundMySC(StageDataPackage StageData, string textureName)
      : base(StageData, textureName, new PointF(0.0f, 0.0f), 0.0f, 0.0)
    {
      this.Background.BackgroundList.Add((BaseObject) this);
      Rectangle boundRect = this.BoundRect;
      double num1 = (double) (boundRect.Width / 2);
      boundRect = this.BoundRect;
      double num2 = (double) (boundRect.Height / 2);
      this.OriginalPosition = new PointF((float) num1, (float) num2);
      this.Scale = 2.5f;
      this.AngularVelocityDegree = 0.5f;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time < this.LifeTime - 50)
        return;
      this.TransparentVelocity = -5f;
    }
  }
}
