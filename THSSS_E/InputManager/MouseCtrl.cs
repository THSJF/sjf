// Decompiled with JetBrains decompiler
// Type: Shooting.MouseCtrl
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Runtime.InteropServices;

namespace Shooting
{
  public class MouseCtrl
  {
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern int ShowCursor(bool bShow);

    public static void DrawCursor(bool cursorShow)
    {
      if (cursorShow)
      {
                do { }
                while(MouseCtrl.ShowCursor(true)<0);
      }
      else
      {
                do { }
                while(MouseCtrl.ShowCursor(false)>=0);
      }
    }
  }
}
