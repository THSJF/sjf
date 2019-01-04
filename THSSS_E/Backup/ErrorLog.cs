// Decompiled with JetBrains decompiler
// Type: Shooting.ErrorLog
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.IO;

namespace Shooting
{
  internal class ErrorLog
  {
    public static void SaveErrorLog(string Message, string Description)
    {
      string str = (string) null + DateTime.Now.ToString("yyyy'/'MM'/'dd HH:mm") + "\r\n" + Message + "\r\n" + Description + "\r\n";
      string path = "Log.txt";
      StreamWriter streamWriter = File.Exists(path) ? new StreamWriter(path, true) : File.CreateText(path);
      streamWriter.Write(str);
      streamWriter.Close();
    }
  }
}
