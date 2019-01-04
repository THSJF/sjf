// Decompiled with JetBrains decompiler
// Type: Shooting.XAudio2_PlayerV2
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX.Multimedia;
using SlimDX.XAudio2;
using System.IO;

namespace Shooting
{
  public class XAudio2_PlayerV2
  {
    private SlimDX.XAudio2.XAudio2 device;
    private SourceVoice sourceVoice;
    private AudioBuffer buffer;
    private bool xwmaMode;

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
        return (int) ((double) this.sourceVoice.Volume * 100.0);
      }
      set
      {
        if (0 > value || value > 100)
          return;
        this.sourceVoice.Volume = (float) value / 100f;
      }
    }

    public XAudio2_PlayerV2(string fileName, SlimDX.XAudio2.XAudio2 device)
    {
      this.device = device;
      this.loadSuccess = this.LoadSound(fileName);
    }

    private bool LoadSound(string fileName)
    {
      try
      {
        FileInfo fileInfo = new FileInfo(fileName);
        if (fileInfo.Extension == ".xwma")
        {
          xWMAStream xWmaStream = new xWMAStream(fileName);
          this.buffer = new AudioBuffer();
          this.buffer.AudioData = (Stream) xWmaStream;
          this.buffer.AudioBytes = (int) xWmaStream.Length;
          this.buffer.Flags = BufferFlags.EndOfStream;
          this.sourceVoice = new SourceVoice(this.device, xWmaStream.Format, VoiceFlags.Music | VoiceFlags.UseFilter);
          this.xwmaMode = true;
        }
        else if (fileInfo.Extension == ".wav")
        {
          WaveStream waveStream = new WaveStream(fileName);
          this.buffer = new AudioBuffer();
          this.buffer.AudioData = (Stream) waveStream;
          this.buffer.AudioBytes = (int) waveStream.Length;
          this.buffer.Flags = BufferFlags.EndOfStream;
          this.sourceVoice = new SourceVoice(this.device, waveStream.Format, VoiceFlags.Music | VoiceFlags.UseFilter);
        }
        this.Volume = 100;
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

    public void Reset()
    {
      if (!this.loadSuccess)
        return;
      if (this.xwmaMode)
      {
        this.sourceVoice.SubmitSourceBuffer(this.buffer, ((xWMAStream) this.buffer.AudioData).DecodedPacketCumulativeBytes);
      }
      else
      {
        this.sourceVoice.Stop();
        this.sourceVoice.FlushSourceBuffers();
        this.sourceVoice.SubmitSourceBuffer(this.buffer);
      }
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

    public void FilterON()
    {
      this.sourceVoice.FilterParameters = new FilterParameters()
      {
        Type = FilterType.HighPassFilter,
        Frequency = 0.5f,
        OneOverQ = 2f
      };
      this.sourceVoice.SetOutputMatrix(2, 2, new float[3]
      {
        0.0f,
        4f,
        4f
      });
    }

    public void FilterOFF()
    {
      this.sourceVoice.FilterParameters = new FilterParameters()
      {
        Type = FilterType.HighPassFilter,
        Frequency = 0.0f,
        OneOverQ = 2f
      };
      this.sourceVoice.SetOutputMatrix(2, 2, new float[3]
      {
        0.0f,
        1f,
        1f
      });
    }

    public void Dispose()
    {
      if (!this.loadSuccess)
        return;
      this.Stop();
      this.sourceVoice.Dispose();
      this.buffer.AudioData.Dispose();
      this.buffer.Dispose();
    }
  }
}
