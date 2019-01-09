// Decompiled with JetBrains decompiler
// Type: THMHJ.Watch
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System.Diagnostics;
using System.Threading;

namespace THMHJ
{
  public class Watch
  {
    private long startTime { get; set; }

    public void Start()
    {
      this.startTime = Stopwatch.GetTimestamp();
    }

    public float GetDuration()
    {
      if (this.startTime == 0L)
        return 0.0f;
      return 1000f * (float) (Stopwatch.GetTimestamp() - this.startTime) / (float) Stopwatch.Frequency;
    }

    public void IncreaseOneFrame()
    {
      this.startTime += Stopwatch.Frequency / 60L;
    }

    public void SleepTo(float Time)
    {
      Time -= this.GetDuration();
      if ((double) Time <= 0.0)
        return;
      Thread.Sleep((int) Time);
    }
  }
}
