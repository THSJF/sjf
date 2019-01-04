// Decompiled with JetBrains decompiler
// Type: Shooting.Wave_Player
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

namespace Shooting
{
  public class Wave_Player
  {
    private XAudio2_PlayerV2[] x2p = new XAudio2_PlayerV2[2];
    private byte AudioIndex = 0;
    private string[] fileName = new string[2];
    private SlimDX.XAudio2.XAudio2 device;

    public bool OnPause { get; set; }

    public string FileName
    {
      get
      {
        return this.fileName[(int) this.AudioIndex];
      }
      set
      {
        if (this.fileName[1 - (int) this.AudioIndex] == value)
        {
          this.AudioIndex = (byte) (1U - (uint) this.AudioIndex);
        }
        else
        {
          int num = 100;
          this.fileName[(int) this.AudioIndex] = value;
          if (this.x2p[(int) this.AudioIndex] != null)
          {
            num = this.x2p[(int) this.AudioIndex].Volume;
            this.x2p[(int) this.AudioIndex].Dispose();
          }
          this.x2p[(int) this.AudioIndex] = new XAudio2_PlayerV2(this.fileName[(int) this.AudioIndex], this.device);
          this.x2p[(int) this.AudioIndex].Volume = num;
        }
      }
    }

    public long CurrentPosition
    {
      get
      {
        return this.x2p[(int) this.AudioIndex].Position;
      }
    }

    public int Volume
    {
      get
      {
        if (this.x2p[(int) this.AudioIndex] != null)
          return this.x2p[(int) this.AudioIndex].Volume;
        return 100;
      }
      set
      {
        if (this.x2p[(int) this.AudioIndex] == null)
          return;
        this.x2p[(int) this.AudioIndex].Volume = value;
      }
    }

    public Wave_Player(SlimDX.XAudio2.XAudio2 device)
    {
      this.Volume = 100;
      this.device = device;
    }

    public void Play()
    {
      this.x2p[(int) this.AudioIndex].Play();
    }

    public void PlayRepeat()
    {
      this.x2p[(int) this.AudioIndex].SetLoop(0, 0);
      this.x2p[(int) this.AudioIndex].Play();
    }

    public void PlayRepeat(int LoopBegin, int LoopEnd)
    {
      this.PlayRepeat(0, 0, (int) byte.MaxValue, LoopBegin, LoopEnd);
    }

    public void PlayRepeat(
      int PlayBegin,
      int PlayLength,
      int LoopCount,
      int LoopBegin,
      int LoopEnd)
    {
      this.x2p[(int) this.AudioIndex].Stop();
      this.x2p[(int) this.AudioIndex].SetLoop(PlayBegin, PlayLength, LoopCount, LoopBegin, LoopEnd);
      this.x2p[(int) this.AudioIndex].Play();
    }

    public void Stop()
    {
      if (this.x2p[(int) this.AudioIndex] == null)
        return;
      this.x2p[(int) this.AudioIndex].Stop();
    }

    public void Puase()
    {
      this.OnPause = true;
      this.Stop();
    }

    public void Resume()
    {
      this.OnPause = false;
      this.x2p[(int) this.AudioIndex].Resume();
    }

    public void PreLoad(string FileName)
    {
      this.FileName = FileName;
      this.x2p[(int) this.AudioIndex].Reset();
    }

    public void FilterON()
    {
      this.x2p[(int) this.AudioIndex].FilterON();
    }

    public void FilterOFF()
    {
      this.x2p[(int) this.AudioIndex].FilterOFF();
    }

    public void Dispose()
    {
      for (int index = 0; index < this.x2p.Length; ++index)
      {
        if (this.x2p[(int) this.AudioIndex] != null)
          this.x2p[(int) this.AudioIndex].Dispose();
      }
    }
  }
}
