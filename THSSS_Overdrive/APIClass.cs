// Decompiled with JetBrains decompiler
// Type: Shooting.APIClass
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Runtime.InteropServices;

namespace Shooting
{
  public class APIClass
  {
    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public static extern int GetShortPathName(string lpszLongPath, string shortFile, int cchBuffer);

    [DllImport("winmm.dll", CharSet = CharSet.Auto)]
    public static extern int mciSendString(
      string lpstrCommand,
      string lpstrReturnString,
      int uReturnLength,
      int hwndCallback);
  }
}
