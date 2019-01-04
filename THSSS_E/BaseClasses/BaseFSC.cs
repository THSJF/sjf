// Decompiled with JetBrains decompiler
// Type: Shooting.BaseFSC
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

namespace Shooting
{
  internal class BaseFSC : BaseSpellCard
  {
    public BaseFSC(StageDataPackage StageData)
      : base(StageData)
    {
    }

    public override long GetSpellCardBonus()
    {
      return this.Bombed || this.Missed ? 0L : 99999990L;
    }
  }
}
