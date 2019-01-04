// Decompiled with JetBrains decompiler
// Type: Shooting.Spell_Koishi
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

namespace Shooting
{
  public class Spell_Koishi : BaseSpell
  {
    public Spell_Koishi(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.Position = this.MyPlane.Position;
      this.Damage = 0;
      this.Region = 1000;
      this.LifeTime = 60;
      this.SpellList.Add((BaseObject) this);
      new BulletRemover_Small(StageData, this.MyPlane.OriginalPosition).Region = 150;
      StageData.SoundPlay("se_focusrot.wav");
    }
  }
}
