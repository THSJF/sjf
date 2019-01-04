// Decompiled with JetBrains decompiler
// Type: Shooting.ReplayInfo
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Collections.Generic;

namespace Shooting
{
  public class ReplayInfo
  {
    public List<MyPlaneInfo> MyPlaneData = new List<MyPlaneInfo>();
    public string Version;
    public string PlayerName;
    public string MyPlaneName;
    public string Date;
    public string Time;
    public string WeaponType;
    public DifficultLevel Rank;
    public string StartStage;
    public string LastStage;
    public string SlowRate;
  }
}
