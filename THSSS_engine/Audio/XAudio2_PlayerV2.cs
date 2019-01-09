using SlimDX.Multimedia;
using SlimDX.XAudio2;
using System.IO;

namespace Shooting {
    public class XAudio2_PlayerV2 {
        private XAudio2 device;
        private SourceVoice sourceVoice;
        private AudioBuffer buffer;
        private bool xwmaMode;
        public bool loadSuccess { get; private set; }
        public long Position => sourceVoice.State.SamplesPlayed/44L;
        public int Volume {
            get => (int)(sourceVoice.Volume*100.0);
            set {
                if(0>value||value>100) return;
                sourceVoice.Volume=value/100f;
            }
        }
        public XAudio2_PlayerV2(string fileName,XAudio2 device) {
            this.device=device;
            loadSuccess=LoadSound(fileName);
        }
        private bool LoadSound(string fileName) {
            try {
                FileInfo fileInfo = new FileInfo(fileName);
                if(fileInfo.Extension==".xwma") {
                    xWMAStream xWmaStream = new xWMAStream(fileName);
                    buffer=new AudioBuffer {
                        AudioData=xWmaStream,
                        AudioBytes=(int)xWmaStream.Length,
                        Flags=BufferFlags.EndOfStream
                    };
                    sourceVoice=new SourceVoice(device,xWmaStream.Format,VoiceFlags.Music|VoiceFlags.UseFilter);
                    xwmaMode=true;
                } else if(fileInfo.Extension==".wav") {
                    WaveStream waveStream = new WaveStream(fileName);
                    buffer=new AudioBuffer {
                        AudioData=waveStream,
                        AudioBytes=(int)waveStream.Length,
                        Flags=BufferFlags.EndOfStream
                    };
                    sourceVoice=new SourceVoice(device,waveStream.Format,VoiceFlags.Music|VoiceFlags.UseFilter);
                }
                Volume=100;
                return true;
            } catch {
                return false;
            }
        }
        public void Play() {
            if(!loadSuccess) return;
            Reset();
            sourceVoice.Start(PlayFlags.None);
        }
        public void Play(int Volume) {
            int volume = this.Volume;
            this.Volume=Volume;
            Play();
            this.Volume=volume;
        }
        public void Resume() {
            if(!loadSuccess) return;
            sourceVoice.Start(PlayFlags.None);
        }
        public void Stop() {
            if(!loadSuccess) return;
            try {
                sourceVoice.Stop();
            } catch {
            }
        }
        public void Reset() {
            if(!loadSuccess) return;
            if(xwmaMode) {
                sourceVoice.SubmitSourceBuffer(buffer,((xWMAStream)buffer.AudioData).DecodedPacketCumulativeBytes);
            } else {
                sourceVoice.Stop();
                sourceVoice.FlushSourceBuffers();
                sourceVoice.SubmitSourceBuffer(buffer);
            }
        }
        public void SetLoop(int LoopBegin,int LoopEnd) => SetLoop(0,0,byte.MaxValue,LoopBegin,LoopEnd);
        public void SetLoop(int PlayBegin,int PlayLength,int LoopCount,int LoopBegin,int LoopEnd) {
            buffer.PlayBegin=PlayBegin;
            buffer.PlayLength=PlayLength;
            buffer.LoopCount=LoopCount;
            buffer.LoopBegin=LoopBegin;
            if(LoopEnd<=LoopBegin) return;
            buffer.LoopLength=LoopEnd-LoopBegin;
        }
        public void FilterON() {
            sourceVoice.FilterParameters=new FilterParameters() {
                Type=FilterType.HighPassFilter,
                Frequency=0.5f,
                OneOverQ=2f
            };
            sourceVoice.SetOutputMatrix(2,2,new float[3] { 0.0f,4f,4f });
        }
        public void FilterOFF() {
            sourceVoice.FilterParameters=new FilterParameters() {
                Type=FilterType.HighPassFilter,
                Frequency=0.0f,
                OneOverQ=2f
            };
            sourceVoice.SetOutputMatrix(2,2,new float[3] { 0.0f,1f,1f });
        }
        public void Dispose() {
            if(!loadSuccess) return;
            Stop();
            sourceVoice.Dispose();
            buffer.AudioData.Dispose();
            buffer.Dispose();
        }
    }
}
