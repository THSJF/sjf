// Decompiled with JetBrains decompiler
// Type: Shooting.SpellDisable
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

namespace Shooting
{
  internal class SpellDisable : BaseEffect
  {
    private bool spellenable;

    public SpellDisable(StageDataPackage StageData)
      : base(StageData)
    {
      this.spellenable = this.MyPlane.SpellEnabled;
      this.LifeTime = 30;
      this.MyPlane.SpellEnabled = false;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time != this.LifeTime)
        return;
      this.MyPlane.SpellEnabled = this.spellenable;
    }
  }
}
