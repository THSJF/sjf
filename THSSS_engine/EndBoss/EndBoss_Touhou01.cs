 
// Type: Shooting.EndBoss_Touhou01
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using Shooting.Planes.Story;
using System.Drawing;

namespace Shooting
{
  internal class EndBoss_Touhou01 : EndBoss_Touhou
  {
    public EndBoss_Touhou01(
      StageDataPackage StageData,
      PointF OriginalPosition,
      Color Color1,
      Color Color2)
      : base(StageData, OriginalPosition, Color1, Color2)
    {
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time != this.LifeTime)
        return;
      switch (this.MyPlane.Name)
      {
        case "Aya":
          Story_SSS01_02 storySsS0102 = new Story_SSS01_02(this.StageData);
          break;
        case "Reimu":
          Story_SSS01_02A storySsS0102A = new Story_SSS01_02A(this.StageData);
          break;
        case "Marisa":
          Story_SSS01_02B storySsS0102B = new Story_SSS01_02B(this.StageData);
          break;
        case "Sanae":
          Story_SSS01_02C storySsS0102C = new Story_SSS01_02C(this.StageData);
          break;
        case "Koishi":
          Story_SSS01_02D storySsS0102D = new Story_SSS01_02D(this.StageData);
          break;
        default:
          Story_SSS01_02X storySsS0102X = new Story_SSS01_02X(this.StageData);
          break;
      }
    }
  }
}
