// Decompiled with JetBrains decompiler
// Type: THMHJ.Achievements.可怕的毅力
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System.Collections;

namespace THMHJ.Achievements
{
  internal sealed class 可怕的毅力 : AchievementBase
  {
    public override bool Check(Hashtable data)
    {
      PlayData playData = (PlayData) data[(object) "playdata"];
      for (int index = 0; index < playData.players.Length; ++index)
      {
        if (playData.players[index].playtime >= 100)
        {
          this.finished = true;
          this.get = true;
          break;
        }
      }
      return this.get;
    }
  }
}
