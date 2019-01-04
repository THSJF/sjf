// Decompiled with JetBrains decompiler
// Type: Shooting.ItemGetter
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class ItemGetter : BaseEffect
  {
    public ItemGetter(StageDataPackage StageData)
      : base(StageData, (string) null, (PointF) new Point(0, 0), 0.0f, Math.PI / 2.0)
    {
      this.LifeTime = 2;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.ItemList.ForEach((Action<BaseItem>) (x =>
      {
        x.Obtain = true;
        x.Doubled = true;
      }));
    }

    public override void Show()
    {
    }
  }
}
