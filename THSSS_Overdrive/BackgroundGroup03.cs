// Decompiled with JetBrains decompiler
// Type: Shooting.BackgroundGroup03
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  internal class BackgroundGroup03
  {
    public BackgroundGroup03(StageDataPackage StageData)
    {
      BackgroundTouhouWater backgroundTouhouWater1 = new BackgroundTouhouWater(StageData, "world02");
      backgroundTouhouWater1.OriginalPosition = new PointF(0.0f, 0.0f);
      backgroundTouhouWater1.Height = 20;
      backgroundTouhouWater1.V1 = -0.2f;
      BackgroundTouhouWater backgroundTouhouWater2 = new BackgroundTouhouWater(StageData, "world02");
      backgroundTouhouWater2.OriginalPosition = new PointF(0.0f, 1000f);
      backgroundTouhouWater2.Height = 20;
      backgroundTouhouWater2.V1 = -0.2f;
      BackgroundTouhouWater backgroundTouhouWater3 = new BackgroundTouhouWater(StageData, "world02");
      backgroundTouhouWater3.OriginalPosition = new PointF(0.0f, 2000f);
      backgroundTouhouWater3.Height = 20;
      backgroundTouhouWater3.V1 = -0.2f;
      BackgroundTouhouWater backgroundTouhouWater4 = new BackgroundTouhouWater(StageData, "world02");
      backgroundTouhouWater4.OriginalPosition = new PointF(0.0f, 3000f);
      backgroundTouhouWater4.Height = 20;
      backgroundTouhouWater4.V1 = -0.2f;
      BackgroundTouhouWater backgroundTouhouWater5 = new BackgroundTouhouWater(StageData, "world02");
      backgroundTouhouWater5.OriginalPosition = new PointF(0.0f, 4000f);
      backgroundTouhouWater5.Height = 20;
      backgroundTouhouWater5.V1 = -0.2f;
      BackgroundTouhouWater backgroundTouhouWater6 = new BackgroundTouhouWater(StageData, "world02");
      backgroundTouhouWater6.ColorValue = Color.BlueViolet;
      backgroundTouhouWater6.OriginalPosition = new PointF(0.0f, -500f);
      backgroundTouhouWater6.Height = 25;
      backgroundTouhouWater6.TransparentValueF = 150f;
      backgroundTouhouWater6.V1 = 0.2f;
      backgroundTouhouWater6.Time = 100;
      BackgroundTouhouWater backgroundTouhouWater7 = new BackgroundTouhouWater(StageData, "world02");
      backgroundTouhouWater7.ColorValue = Color.BlueViolet;
      backgroundTouhouWater7.OriginalPosition = new PointF(0.0f, 500f);
      backgroundTouhouWater7.Height = 25;
      backgroundTouhouWater7.TransparentValueF = 150f;
      backgroundTouhouWater7.V1 = 0.2f;
      backgroundTouhouWater7.Time = 100;
      BackgroundTouhouWater backgroundTouhouWater8 = new BackgroundTouhouWater(StageData, "world02");
      backgroundTouhouWater8.ColorValue = Color.BlueViolet;
      backgroundTouhouWater8.OriginalPosition = new PointF(0.0f, 1500f);
      backgroundTouhouWater8.Height = 25;
      backgroundTouhouWater8.TransparentValueF = 150f;
      backgroundTouhouWater8.V1 = 0.2f;
      backgroundTouhouWater8.Time = 100;
      BackgroundTouhouWater backgroundTouhouWater9 = new BackgroundTouhouWater(StageData, "world02");
      backgroundTouhouWater9.ColorValue = Color.BlueViolet;
      backgroundTouhouWater9.OriginalPosition = new PointF(0.0f, 2500f);
      backgroundTouhouWater9.Height = 25;
      backgroundTouhouWater9.TransparentValueF = 150f;
      backgroundTouhouWater9.V1 = 0.2f;
      backgroundTouhouWater9.Time = 100;
      BackgroundTouhouWater backgroundTouhouWater10 = new BackgroundTouhouWater(StageData, "world02");
      backgroundTouhouWater10.ColorValue = Color.BlueViolet;
      backgroundTouhouWater10.OriginalPosition = new PointF(0.0f, 3500f);
      backgroundTouhouWater10.Height = 25;
      backgroundTouhouWater10.TransparentValueF = 150f;
      backgroundTouhouWater10.V1 = 0.2f;
      backgroundTouhouWater10.Time = 100;
      List<int> intList1 = new List<int>();
      List<int> intList2 = new List<int>();
      for (int index = 0; index < 20; ++index)
      {
        int num1 = StageData.Ran.Next(100, 350);
        intList1.Add(num1);
        int num2 = StageData.Ran.Next(100, 350);
        intList2.Add(num2);
      }
      for (int index1 = 3; index1 >= 1; --index1)
      {
        for (int index2 = 0; index2 < 20; ++index2)
        {
          BackgroundTree backgroundTree1 = new BackgroundTree(StageData, "EquinoxFlower00", new PointF((float) intList1[index2], (float) (1000 * index1 - index2 * 50)), false);
          BackgroundTree backgroundTree2 = new BackgroundTree(StageData, "EquinoxFlower01", new PointF((float) intList2[index2], (float) (1000 * index1 - index2 * 50)), false);
        }
      }
    }
  }
}
