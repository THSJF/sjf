// Decompiled with JetBrains decompiler
// Type: CrazyStorm_1._03.EventRead
// Assembly: CrazyStorm 1.03, Version=1.0.0.3, Culture=neutral, PublicKeyToken=null
// MVID: 84431CDC-1E34-49EF-A5C5-D546FEF5A655
// Assembly location: E:\CrazyStorm 1.03I\CrazyStorm 1.03.exe

using System;

namespace CrazyStorm_1._03
{
  [Serializable]
  public class EventRead
  {
    public float rand;
    public int special;
    public int special2;
    public string condition;
    public string result;
    public string condition2;
    public int contype;
    public int contype2;
    public string opreator;
    public string opreator2;
    public string collector;
    public int change;
    public int changetype;
    public int changevalue;
    public int changename;
    public float res;
    public int times;
    public int time;
    public bool noloop;

    public object Copy()
    {
      return this.MemberwiseClone();
    }
  }
}
