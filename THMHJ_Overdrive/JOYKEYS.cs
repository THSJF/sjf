// Decompiled with JetBrains decompiler
// Type: THMHJ.JOYKEYS
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System;

namespace THMHJ
{
  [Flags]
  public enum JOYKEYS
  {
    Up = 0,
    Down = 1,
    Left = 2,
    Right = Left | Down, // 0x00000003
    Confirm = 4,
    Special = Confirm | Down, // 0x00000005
    Slow = Confirm | Left, // 0x00000006
    Pause = Slow | Down, // 0x00000007
  }
}
