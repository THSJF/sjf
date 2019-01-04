// Decompiled with JetBrains decompiler
// Type: Shooting.BackgroundBoss06
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  public class BackgroundBoss06 : BaseObject
  {
    public BackgroundBoss06(StageDataPackage StageData)
      : base(StageData, (string) null, new PointF(0.0f, 0.0f), 0.0f, 0.0)
    {
      BackgroundSC backgroundSc = new BackgroundSC(StageData, "底色");
      BackgroundSC bsc1 = new BackgroundSC(StageData, "绿光");
      bsc1.CtrlCall = (BaseObject.CtrlActionCallBack) (x =>
      {
        if (bsc1.Time % 300 == 0)
        {
          bsc1.TransparentVelocity = -2.55f;
        }
        else
        {
          if (bsc1.Time % 300 != 100)
            return;
          bsc1.TransparentVelocity = 2.55f;
        }
      });
      BackgroundSC bsc2 = new BackgroundSC(StageData, "蓝光");
      bsc2.CtrlCall = (BaseObject.CtrlActionCallBack) (x =>
      {
        if (bsc2.Time % 300 == 100)
        {
          bsc2.TransparentVelocity = -2.55f;
        }
        else
        {
          if (bsc2.Time % 300 != 200)
            return;
          bsc2.TransparentVelocity = 2.55f;
        }
      });
      BackgroundSC bsc = new BackgroundSC(StageData, "红光");
      bsc.CtrlCall = (BaseObject.CtrlActionCallBack) (x =>
      {
        if (bsc.Time % 300 == 200)
        {
          bsc.TransparentVelocity = -2.55f;
        }
        else
        {
          if (bsc.Time % 300 != 0)
            return;
          bsc.TransparentVelocity = 2.55f;
        }
      });
    }
  }
}
