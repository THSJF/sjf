// Decompiled with JetBrains decompiler
// Type: Shooting.XAudio2_Player
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX.Multimedia;
using SlimDX.XAudio2;
using System.IO;

namespace Shooting
{
  public class XAudio2_Player
  {
    private SlimDX.XAudio2.XAudio2 device;
    private SourceVoice sourceVoice;
    private AudioBuffer buffer;

    public float VoicePos { get; set; }

    public bool loadSuccess { get; private set; }

    public long Position
    {
      get
      {
        return this.sourceVoice.State.SamplesPlayed / 44L;
      }
    }

    public int Volume
    {
      get
      {
        return (int) ((double) this.sourceVoice.Volume * 200.0);
      }
      set
      {
        if (0 > value || value > 100)
          return;
        this.sourceVoice.Volume = (float) value / 200f;
      }
    }

    public XAudio2_Player(string fileName, SlimDX.XAudio2.XAudio2 device)
    {
      this.device = device;
      this.loadSuccess = this.LoadSound(fileName);
    }

    private bool LoadSound(string fileName)
    {
      try
      {
        FileStream fileStream = File.OpenRead(fileName);
        WaveStream waveStream = new WaveStream((Stream) fileStream);
        fileStream.Close();
        this.buffer = new AudioBuffer();
        this.buffer.AudioData = (Stream) waveStream;
        this.buffer.AudioBytes = (int) waveStream.Length;
        this.buffer.Flags = BufferFlags.EndOfStream;
        this.sourceVoice = new SourceVoice(this.device, waveStream.Format);
        this.Volume = 40;
        return true;
      }
      catch
      {
        return false;
      }
    }

    public void Play()
    {
      if (!this.loadSuccess)
        return;
      float num = (float) ((double) this.VoicePos * 0.400000005960464 + 0.300000011920929);
      int inputChannels = this.sourceVoice.VoiceDetails.InputChannels;
      float[] matrix = new float[2]{ 1f - num, num };
      if (inputChannels == 2)
        matrix = new float[3]{ 0.0f, 1f - num, num };
      this.sourceVoice.SetOutputMatrix(inputChannels, 2, matrix);
      this.Reset();
      this.sourceVoice.Start(PlayFlags.None);
    }

    public void Play(int Volume)
    {
      int volume = this.Volume;
      this.Volume = Volume;
      this.Play();
      this.Volume = volume;
    }

    public void Resume()
    {
      if (!this.loadSuccess)
        return;
      this.sourceVoice.Start(PlayFlags.None);
    }

    public void Stop()
    {
      if (!this.loadSuccess)
        return;
      try
      {
        this.sourceVoice.Stop();
      }
      catch
      {
      }
    }

    private void Reset()
    {
      if (!this.loadSuccess)
        return;
      this.sourceVoice.Stop();
      this.sourceVoice.FlushSourceBuffers();
      this.sourceVoice.SubmitSourceBuffer(this.buffer);
    }

    public void SetLoop(int LoopBegin, int LoopEnd)
    {
      this.SetLoop(0, 0, (int) byte.MaxValue, LoopBegin, LoopEnd);
    }

    public void SetLoop(int PlayBegin, int PlayLength, int LoopCount, int LoopBegin, int LoopEnd)
    {
      this.buffer.PlayBegin = PlayBegin;
      this.buffer.PlayLength = PlayLength;
      this.buffer.LoopCount = LoopCount;
      this.buffer.LoopBegin = LoopBegin;
      if (LoopEnd <= LoopBegin)
        return;
      this.buffer.LoopLength = LoopEnd - LoopBegin;
    }

    public void Dispose()
    {
      if (!this.loadSuccess)
        return;
      this.Stop();
      this.sourceVoice.Dispose();
      this.buffer.Dispose();
    }
  }
}
