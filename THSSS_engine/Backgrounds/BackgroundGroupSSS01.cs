 
// Type: Shooting.BackgroundGroupSSS01
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class BackgroundGroupSSS01
  {
    public BackgroundGroupSSS01(StageDataPackage StageData)
    {
      new BackgroundTouhouStage02_3D(StageData).TxtureObject = StageData.TextureObjectDictionary["BG01b"];
      for (int index = 0; index < 20; ++index)
      {
        new BackgroundTree(StageData, "Tree", new PointF(290f, (float) (4200 - index * 200 + 100)), false).Mirrored = true;
        BackgroundTree backgroundTree1 = new BackgroundTree(StageData, "Tree", new PointF(290f, (float) (4200 - index * 200)), false);
        new BackgroundTree(StageData, "Tree", new PointF(-400f, (float) (4200 - index * 200 + 162)), false).Mirrored = true;
        BackgroundTree backgroundTree2 = new BackgroundTree(StageData, "Tree", new PointF(-400f, (float) (4200 - index * 200 + 62)), false);
      }
      for (int index = 0; index < 10; ++index)
      {
        Background3DObject background3Dobject1 = new Background3DObject(StageData, "Cloud02", new PointF(0.0f, (float) (index * 500)), false);
        background3Dobject1.Scale = 2f;
        background3Dobject1.Mirrored = false;
        background3Dobject1.OriginalPositionZ = -10f;
        background3Dobject1.Angle3DX = -3.141593f;
        background3Dobject1.TransparentValueF = 50f;
        background3Dobject1.Velocity = 0.5f;
        Background3DObject background3Dobject2 = new Background3DObject(StageData, "Cloud02", new PointF(-1024f, (float) (index * 500)), false);
        background3Dobject2.Scale = 2f;
        background3Dobject2.Mirrored = false;
        background3Dobject2.OriginalPositionZ = -10f;
        background3Dobject2.Angle3DX = -3.141593f;
        background3Dobject2.TransparentValueF = 50f;
        background3Dobject2.Velocity = 0.5f;
        Background3DObject background3Dobject3 = new Background3DObject(StageData, "Cloud02", new PointF(-2048f, (float) (index * 500)), false);
        background3Dobject3.Scale = 2f;
        background3Dobject3.Mirrored = false;
        background3Dobject3.OriginalPositionZ = -10f;
        background3Dobject3.Angle3DX = -3.141593f;
        background3Dobject3.TransparentValueF = 50f;
        background3Dobject3.Velocity = 0.5f;
        Background3DObject background3Dobject4 = new Background3DObject(StageData, "Cloud01", new PointF(0.0f, (float) (index * 500 + 250)), false);
        background3Dobject4.Scale = 2f;
        background3Dobject4.Mirrored = true;
        background3Dobject4.OriginalPositionZ = -20f;
        background3Dobject4.Angle3DX = -3.141593f;
        background3Dobject4.TransparentValueF = 50f;
        background3Dobject4.Velocity = -0.5f;
        Background3DObject background3Dobject5 = new Background3DObject(StageData, "Cloud01", new PointF(1024f, (float) (index * 500 + 250)), false);
        background3Dobject5.Scale = 2f;
        background3Dobject5.Mirrored = true;
        background3Dobject5.OriginalPositionZ = -20f;
        background3Dobject5.Angle3DX = -3.141593f;
        background3Dobject5.TransparentValueF = 50f;
        background3Dobject5.Velocity = -0.5f;
        Background3DObject background3Dobject6 = new Background3DObject(StageData, "Cloud01", new PointF(2048f, (float) (index * 500 + 250)), false);
        background3Dobject6.Scale = 2f;
        background3Dobject6.Mirrored = true;
        background3Dobject6.OriginalPositionZ = -20f;
        background3Dobject6.Angle3DX = -3.141593f;
        background3Dobject6.TransparentValueF = 50f;
        background3Dobject6.Velocity = -0.5f;
      }
    }
  }
}
