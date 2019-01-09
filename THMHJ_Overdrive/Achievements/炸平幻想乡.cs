// Decompiled with JetBrains decompiler
// Type: THMHJ.Achievements.炸平幻想乡
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System.Collections;

namespace THMHJ.Achievements
{
  internal sealed class 炸平幻想乡 : AchievementBase
  {
    private bool bombed;
    private bool shot;

    public override bool Check(Hashtable data)
    {
      if (data.ContainsKey((object) "reset"))
      {
        this.bombed = false;
        this.shot = false;
      }
      if (data.ContainsKey((object) "bomb") && (bool) data[(object) "bomb"])
        this.bombed = true;
      if (data.ContainsKey((object) "shot") && (bool) data[(object) "shot"])
        this.shot = true;
      if (data.ContainsKey((object) "level") && (int) data[(object) "type"] == 1 && (this.bombed && !this.shot))
      {
        this.finishedlevel[(int) data[(object) "level"] - 1] = true;
        int num = 0;
        for (int index = 0; index < this.finishedlevel.Length; ++index)
        {
          if (this.finishedlevel[index])
            ++num;
        }
        if (num == this.finishedlevel.Length)
          this.finished = true;
        this.get = true;
      }
      return this.get;
    }
  }
}
