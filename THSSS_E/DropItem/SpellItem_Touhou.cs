// Decompiled with JetBrains decompiler
// Type: Shooting.SpellItem_Touhou
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class SpellItem_Touhou : BaseItem_Touhou
  {
    public SpellItem_Touhou(StageDataPackage StageData, PointF p)
      : base(StageData, "SpellItem", p)
    {
      this.Region = 10;
      this.Scale = 1f;
    }

    public override void HitCheckAll()
    {
      base.HitCheckAll();
      if (!this.HitCheck((BaseObject) this.MyPlane))
        return;
      this.ItemList.Remove((BaseItem) this);
      this.MyPlane.SpellExtand();
    }

    public override void Show()
    {
      base.Show();
    }
  }
}
