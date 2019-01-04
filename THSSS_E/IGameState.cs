// Decompiled with JetBrains decompiler
// Type: Shooting.IGameState
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

namespace Shooting
{
  public interface IGameState
  {
    GlobalDataPackage GlobalData { get; set; }

    StageDataPackage StageData { get; set; }

    StateSwitchDataPackage StateSwitchData { get; set; }

    string StageName { get; set; }

    void Init();

    void UpdateData();

    void Render();

    void BGM_ON();

    void BGM_Pause();

    void BGM_Resume();

    void Dispose();
  }
}
