// Decompiled with JetBrains decompiler
// Type: THMHJ.Program
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System;

namespace THMHJ
{
  internal static class Program
  {
    public static Main game;

    private static void Main(string[] args)
    {
      using (Program.game = new Main())
      {
        Program.game.InactiveSleepTime = new TimeSpan(0, 0, 0);
        Program.game.Run();
            }
    }
  }
}
