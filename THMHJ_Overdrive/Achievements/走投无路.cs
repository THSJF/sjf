// Decompiled with JetBrains decompiler
// Type: THMHJ.Achievements.走投无路
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using System.Collections;

namespace THMHJ.Achievements
{
  internal sealed class 走投无路 : AchievementBase
  {
    private int time;

    public override bool Check(Hashtable data)
    {
      float y = ((Vector2) data[(object) "position"]).Y;
      if ((int) data[(object) "type"] == 1 && (double) y <= 190.0)
        ++this.time;
      else
        this.time = 0;
      if (this.time >= 600)
      {
        this.finished = true;
        this.get = true;
      }
      return this.get;
    }
  }
}
