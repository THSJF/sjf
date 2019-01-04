// Decompiled with JetBrains decompiler
// Type: THMHJ.Event
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace THMHJ
{
  [Serializable]
  public class Event
  {
    public string tag = "新事件组";
    public int t = 1;
    public List<string> events = new List<string>();
    public List<EventRead> results = new List<EventRead>();
    public int index;
    public int loop;
    public int addtime;
    public int special;

    public Event(int idx)
    {
      this.index = idx;
    }

    public object Clone()
    {
      MemoryStream memoryStream = new MemoryStream();
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      binaryFormatter.Serialize((Stream) memoryStream, (object) this);
      memoryStream.Seek(0L, SeekOrigin.Begin);
      object obj = binaryFormatter.Deserialize((Stream) memoryStream);
      memoryStream.Close();
      return obj;
    }
  }
}
