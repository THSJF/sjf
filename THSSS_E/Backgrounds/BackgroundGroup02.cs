 
// Type: Shooting.BackgroundGroup02
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class BackgroundGroup02
  {
    public BackgroundGroup02(StageDataPackage StageData)
    {
      BackgroundTouhouStage02_3D backgroundTouhouStage023D = new BackgroundTouhouStage02_3D(StageData);
      for (int index = 0; index < 20; ++index)
      {
        BackgroundTree backgroundTree1 = new BackgroundTree(StageData, "Background_Sunflowers", new PointF((float) StageData.Ran.Next(25, 300), (float) (5400 - index * 50 + 25)), false);
        backgroundTree1.Mirrored = true;
        backgroundTree1.Scale = 0.5f;
        BackgroundTree backgroundTree2 = new BackgroundTree(StageData, "Background_Sunflowers", new PointF((float) StageData.Ran.Next(-300, -25), (float) (5400 - index * 50 + 31)), false);
        backgroundTree2.Mirrored = true;
        backgroundTree2.Scale = 0.5f;
        new BackgroundTree(StageData, "Background_Sunflowers", new PointF((float) StageData.Ran.Next(-300, -25), (float) (5400 - index * 50 + 6)), false).Scale = 0.5f;
        new BackgroundTree(StageData, "Background_Sunflowers", new PointF((float) StageData.Ran.Next(25, 300), (float) (5400 - index * 50)), false).Scale = 0.5f;
      }
      for (int index = 0; index < 20; ++index)
      {
        new BackgroundTree(StageData, "ea1655f0", new PointF(300f, (float) (4200 - index * 200 + 100)), false).Mirrored = true;
        BackgroundTree backgroundTree1 = new BackgroundTree(StageData, "ea1655f0", new PointF(290f, (float) (4200 - index * 200)), false);
        new BackgroundTree(StageData, "ea1655f0", new PointF(-400f, (float) (4200 - index * 200 + 162)), false).Mirrored = true;
        BackgroundTree backgroundTree2 = new BackgroundTree(StageData, "ea1655f0", new PointF(-410f, (float) (4200 - index * 200 + 62)), false);
      }
    }
  }
}
