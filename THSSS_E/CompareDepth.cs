// Decompiled with JetBrains decompiler
// Type: Shooting.CompareDepth
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Collections.Generic;

namespace Shooting
{
  public class CompareDepth : IComparer<BaseParticle3D>
  {
    public int Compare(BaseParticle3D p1, BaseParticle3D p2)
    {
      return (int) ((double) p1.Depth * 10.0 - (double) p2.Depth * 10.0);
    }
  }
}
