namespace Shooting {
    public class Wave_Player {
        private XAudio2_PlayerV2[] x2p = new XAudio2_PlayerV2[2];
        private byte AudioIndex = 0;
        private string[] fileName = new string[2];
        private SlimDX.XAudio2.XAudio2 device;
        public bool OnPause { get; set; }
        public string FileName {
            get => fileName[AudioIndex];
            set {
                if(fileName[1-AudioIndex]==value) {
                    AudioIndex=(byte)(1U-AudioIndex);
                } else {
                    int num = 100;
                    fileName[AudioIndex]=value;
                    if(x2p[AudioIndex]!=null) {
                        num=x2p[AudioIndex].Volume;
                        x2p[AudioIndex].Dispose();
                    }
                    x2p[AudioIndex]=new XAudio2_PlayerV2(fileName[AudioIndex],device) {
                        Volume=num
                    };
                }
            }
        }
        public long CurrentPosition => x2p[AudioIndex].Position;
        public int Volume {
            get {
                if(x2p[AudioIndex]!=null) return x2p[AudioIndex].Volume;
                return 100;
            }
            set {
                if(x2p[AudioIndex]==null) return;
                x2p[AudioIndex].Volume=value;
            }
        }
        public Wave_Player(SlimDX.XAudio2.XAudio2 device) {
            Volume=100;
            this.device=device;
        }
        public void Play() {
            x2p[AudioIndex].Play();
        }
        public void PlayRepeat() {
            x2p[AudioIndex].SetLoop(0,0);
            x2p[AudioIndex].Play();
        }
        public void PlayRepeat(int LoopBegin,int LoopEnd) {
            PlayRepeat(0,0,byte.MaxValue,LoopBegin,LoopEnd);
        }
        public void PlayRepeat(int PlayBegin,int PlayLength,int LoopCount,int LoopBegin,int LoopEnd) {
            x2p[AudioIndex].Stop();
            x2p[AudioIndex].SetLoop(PlayBegin,PlayLength,LoopCount,LoopBegin,LoopEnd);
            x2p[AudioIndex].Play();
        }
        public void Stop() {
            if(x2p[AudioIndex]==null) return;
            x2p[AudioIndex].Stop();
        }
        public void Puase() {
            OnPause=true;
            Stop();
        }
        public void Resume() {
            OnPause=false;
            x2p[AudioIndex].Resume();
        }
        public void PreLoad(string FileName) {
            this.FileName=FileName;
            x2p[AudioIndex].Reset();
        }
        public void FilterON() => x2p[AudioIndex].FilterON();
        public void FilterOFF() => x2p[AudioIndex].FilterOFF();
        public void Dispose() {
            for(int index = 0;index<x2p.Length;++index) {
                if(x2p[AudioIndex]!=null) x2p[AudioIndex].Dispose();
            }
        }
    }
}
