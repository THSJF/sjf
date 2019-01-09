// Decompiled with JetBrains decompiler
// Type: THMHJ.Achievements.不惧风雨
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using System.Collections;

namespace THMHJ.Achievements
{
  internal sealed class 不惧风雨 : AchievementBase
  {
    private Vector2 before;
    private int timecount;

    public override bool Check(Hashtable data)
    {
      Vector2 vector2 = (Vector2) data[(object) "position"];
      if ((int) data[(object) "count"] >= 500)
      {
        if ((double) vector2.X == (double) this.before.X && (double) vector2.Y == (double) this.before.Y)
          ++this.timecount;
        else
          this.timecount = 0;
        this.before = new Vector2(vector2.X, vector2.Y);
      }
      else
        this.timecount = 0;
      if (this.timecount < 300)
        return false;
      this.timecount = 0;
      this.finished = true;
      this.get = true;
      return true;
    }
  }
}
