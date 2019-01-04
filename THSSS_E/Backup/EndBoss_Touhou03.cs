// Decompiled with JetBrains decompiler
// Type: Shooting.EndBoss_Touhou03
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using Shooting.Planes.Story;
using System.Drawing;

namespace Shooting
{
  internal class EndBoss_Touhou03 : EndBoss_Touhou
  {
    public EndBoss_Touhou03(
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
          Story_SSS03_02 storySsS0302 = new Story_SSS03_02(this.StageData);
          break;
        case "Reimu":
          Story_SSS03_02A storySsS0302A = new Story_SSS03_02A(this.StageData);
          break;
        case "Marisa":
          Story_SSS03_02B storySsS0302B = new Story_SSS03_02B(this.StageData);
          break;
        case "Sanae":
          Story_SSS03_02C storySsS0302C = new Story_SSS03_02C(this.StageData);
          break;
        case "Koishi":
          Story_SSS03_02D storySsS0302D = new Story_SSS03_02D(this.StageData);
          break;
        default:
          Story_SSS03_02X storySsS0302X = new Story_SSS03_02X(this.StageData);
          break;
      }
    }
  }
}
