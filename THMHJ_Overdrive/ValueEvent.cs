// Decompiled with JetBrains decompiler
// Type: THMHJ.ValueEvent
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System;

namespace THMHJ
{
  internal class ValueEvent : ValueEventManager
  {
    private unsafe float* value;
    private float values;
    private float target;
    private int time;
    private int needtime;
    private float step;
    public bool finished;
    private ChangeType type;

    public unsafe ValueEvent(float* v, float tg, int t, ChangeType ct)
    {
      this.values = *v;
      this.value = v;
      this.target = tg;
      this.needtime = t;
      this.type = ct;
      switch (this.type)
      {
        case ChangeType.LINEAR:
          this.step = (this.target - this.values) / (float) this.needtime;
          ValueEventManager.VECollection.Add(this);
          break;
        case ChangeType.NONLINEAR:
          if (ValueEventManager.VECollection.Count == 0)
          {
            ValueEventManager.VECollection.Add(this);
            break;
          }
          for (int index = 0; index < ValueEventManager.VECollection.Count; ++index)
          {
            if (ValueEventManager.VECollection[index].value == v)
            {
              ValueEventManager.VECollection[index] = this;
              break;
            }
            if (index == ValueEventManager.VECollection.Count - 1 && ValueEventManager.VECollection[index].value != v)
              ValueEventManager.VECollection.Add(this);
          }
          break;
      }
    }

    public unsafe void Update()
    {
      ++this.time;
      if (this.finished)
        return;
      switch (this.type)
      {
        case ChangeType.LINEAR:
          float* numPtr1 = this.value;
          double num1 = (double) *numPtr1 + (double) this.step;
          *numPtr1 = (float) num1;
          if (this.time < this.needtime)
            break;
          this.finished = true;
          break;
        case ChangeType.NONLINEAR:
          float* numPtr2 = this.value;
          double num2 = (double) *numPtr2 + ((double) this.target - (double) *this.value) / (double) this.needtime;
          *numPtr2 = (float) num2;
          if ((double) Math.Abs(*this.value - this.target) >= 0.100000001490116)
            break;
          *this.value = this.target;
          this.finished = true;
          break;
      }
    }
  }
}
