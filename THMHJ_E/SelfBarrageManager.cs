// Decompiled with JetBrains decompiler
// Type: THMHJ.SelfBarrageManager
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace THMHJ
{
  public class SelfBarrageManager
  {
    public static List<SelfBarrage> SBArray = new List<SelfBarrage>();

    public static void Update(EnemyManager e, Boss b, Character p)
    {
      for (int index = 0; index < SelfBarrageManager.SBArray.Count; ++index)
        SelfBarrageManager.SBArray[index].Update(e, b, p);
    }

    public static void Draw(SpriteBatch s, Vector2 Quakeset)
    {
      for (int index = 0; index < SelfBarrageManager.SBArray.Count; ++index)
      {
        if (!SelfBarrageManager.SBArray[index].ＮeedDelete)
        {
          SelfBarrageManager.SBArray[index].Draw(s, Quakeset);
        }
        else
        {
          SelfBarrageManager.SBArray.RemoveAt(index);
          --index;
        }
      }
    }

    public static void Dispose()
    {
      SelfBarrageManager.SBArray.Clear();
    }
  }
}
