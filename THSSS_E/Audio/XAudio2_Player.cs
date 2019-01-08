using SlimDX.Multimedia;
using SlimDX.XAudio2;
using System.IO;

namespace Shooting {
    public class XAudio2_Player {
        private XAudio2 device;
        private SourceVoice sourceVoice;
        private AudioBuffer buffer;
        public float VoicePos { get; set; }
        public bool loadSuccess { get; private set; }
        public long Position => sourceVoice.State.SamplesPlayed/44L;
        public int Volume {
            get => (int)(sourceVoice.Volume*200.0);
            set {
                if(0>value||value>100) return;
                sourceVoice.Volume=value/200f;
            }
        }
        public XAudio2_Player(string fileName,XAudio2 device) {
            this.device=device;
            loadSuccess=LoadSound(fileName);
        }
        private bool LoadSound(string fileName) {
            try {
                FileStream fileStream = File.OpenRead(fileName);
                WaveStream waveStream = new WaveStream(fileStream);
                fileStream.Close();
                buffer=new AudioBuffer {
                    AudioData=waveStream,
                    AudioBytes=(int)waveStream.Length,
                    Flags=BufferFlags.EndOfStream
                };
                sourceVoice=new SourceVoice(device,waveStream.Format);
                Volume=40;
                return true;
            } catch {
                return false;
            }
        }
        public void Play() {
            if(!loadSuccess) return;
            float num = (float)(VoicePos*0.400000005960464+0.300000011920929);
            int inputChannels = sourceVoice.VoiceDetails.InputChannels;
            float[] matrix = new float[2] { 1f-num,num };
            if(inputChannels==2) matrix=new float[3] { 0.0f,1f-num,num };
            sourceVoice.SetOutputMatrix(inputChannels,2,matrix);
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
        private void Reset() {
            if(!loadSuccess) return;
            sourceVoice.Stop();
            sourceVoice.FlushSourceBuffers();
            sourceVoice.SubmitSourceBuffer(buffer);
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
        public void Dispose() {
            if(!loadSuccess) return;
            Stop();
            sourceVoice.Dispose();
            buffer.Dispose();
        }
    }
}
