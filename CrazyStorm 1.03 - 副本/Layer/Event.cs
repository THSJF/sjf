// Decompiled with JetBrains decompiler
// Type: CrazyStorm_1._03.Event
// Assembly: CrazyStorm 1.03, Version=1.0.0.3, Culture=neutral, PublicKeyToken=null
// MVID: 84431CDC-1E34-49EF-A5C5-D546FEF5A655
// Assembly location: E:\CrazyStorm 1.03I\CrazyStorm 1.03.exe

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CrazyStorm_1._03
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
