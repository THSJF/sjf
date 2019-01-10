using System.Diagnostics;
using System.Threading;

namespace Shooting {
    public class Watch {
        private long startTime { get; set; }
        public void Start() => startTime=Stopwatch.GetTimestamp();
        public float GetDuration() {
            if(startTime==0L) return 0.0f;
            return 1000f*(Stopwatch.GetTimestamp()-startTime)/Stopwatch.Frequency;
        }
        public void IncreaseOneFrame() => startTime+=Stopwatch.Frequency/60L;
        public void SleepTo(float Time) {
            Time-=GetDuration();
            if(Time<=0.0) return;
            Thread.Sleep((int)Time);
        }
    }
}
