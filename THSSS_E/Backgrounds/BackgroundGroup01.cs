 
// Type: Shooting.BackgroundGroup01
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class BackgroundGroup01
  {
    public BackgroundGroup01(StageDataPackage StageData)
    {
      new BackgroundTouhouStage01B_3D(StageData, "stage01a1").OriginalPosition = new PointF(0.0f, 0.0f);
      new BackgroundTouhouStage01B_3D(StageData, "stage01a1").OriginalPosition = new PointF(0.0f, 1000f);
      new BackgroundTouhouStage01B_3D(StageData, "stage01a1").OriginalPosition = new PointF(0.0f, 2000f);
      new BackgroundTouhouStage01B_3D(StageData, "stage01a1").OriginalPosition = new PointF(0.0f, 3000f);
      BackgroundTouhouStage01C_3D touhouStage01C3D1 = new BackgroundTouhouStage01C_3D(StageData, "world02c");
      touhouStage01C3D1.OriginalPosition = new PointF(0.0f, 0.0f);
      touhouStage01C3D1.TransparentValueF = 128f;
      touhouStage01C3D1.Time = 300;
      touhouStage01C3D1.Height = 50;
      BackgroundTouhouStage01C_3D touhouStage01C3D2 = new BackgroundTouhouStage01C_3D(StageData, "world02c");
      touhouStage01C3D2.OriginalPosition = new PointF(0.0f, 1000f);
      touhouStage01C3D2.TransparentValueF = 128f;
      touhouStage01C3D2.Time = 300;
      touhouStage01C3D2.Height = 50;
      BackgroundTouhouStage01C_3D touhouStage01C3D3 = new BackgroundTouhouStage01C_3D(StageData, "world02c");
      touhouStage01C3D3.OriginalPosition = new PointF(0.0f, 2000f);
      touhouStage01C3D3.TransparentValueF = 128f;
      touhouStage01C3D3.Time = 300;
      touhouStage01C3D3.Height = 50;
      BackgroundTouhouStage01C_3D touhouStage01C3D4 = new BackgroundTouhouStage01C_3D(StageData, "world02c");
      touhouStage01C3D4.OriginalPosition = new PointF(0.0f, 3000f);
      touhouStage01C3D4.TransparentValueF = 128f;
      touhouStage01C3D4.Time = 300;
      touhouStage01C3D4.Height = 50;
      BackgroundTouhouStage01C_3D touhouStage01C3D5 = new BackgroundTouhouStage01C_3D(StageData, "world02c2");
      touhouStage01C3D5.OriginalPosition = new PointF(0.0f, 0.0f);
      touhouStage01C3D5.TransparentValueF = 128f;
      touhouStage01C3D5.DirectionDegree = 180.0;
      touhouStage01C3D5.Height = 100;
      BackgroundTouhouStage01C_3D touhouStage01C3D6 = new BackgroundTouhouStage01C_3D(StageData, "world02c2");
      touhouStage01C3D6.OriginalPosition = new PointF(0.0f, 1000f);
      touhouStage01C3D6.TransparentValueF = 128f;
      touhouStage01C3D6.DirectionDegree = 180.0;
      touhouStage01C3D6.Height = 100;
      BackgroundTouhouStage01C_3D touhouStage01C3D7 = new BackgroundTouhouStage01C_3D(StageData, "world02c2");
      touhouStage01C3D7.OriginalPosition = new PointF(0.0f, 2000f);
      touhouStage01C3D7.TransparentValueF = 128f;
      touhouStage01C3D7.DirectionDegree = 180.0;
      touhouStage01C3D7.Height = 100;
      BackgroundTouhouStage01C_3D touhouStage01C3D8 = new BackgroundTouhouStage01C_3D(StageData, "world02c2");
      touhouStage01C3D8.OriginalPosition = new PointF(0.0f, 3000f);
      touhouStage01C3D8.TransparentValueF = 128f;
      touhouStage01C3D8.DirectionDegree = 180.0;
      touhouStage01C3D8.Height = 100;
    }
  }
}
