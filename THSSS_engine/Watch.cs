using System.Diagnostics;
using System.Threading;

namespace Shooting
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
