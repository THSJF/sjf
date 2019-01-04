// Decompiled with JetBrains decompiler
// Type: THMHJ.ValueEventManager
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System.Collections.Generic;

namespace THMHJ
{
  internal class ValueEventManager
  {
    public static List<ValueEvent> VECollection = new List<ValueEvent>();

    public static void Update()
    {
      for (int index = 0; index < ValueEventManager.VECollection.Count; ++index)
      {
        if (ValueEventManager.VECollection[index].finished)
        {
          ValueEventManager.VECollection.RemoveAt(index);
          --index;
        }
        else
          ValueEventManager.VECollection[index].Update();
      }
    }
  }
}
