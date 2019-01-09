// Decompiled with JetBrains decompiler
// Type: THMHJ.Sound
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;

namespace THMHJ
{
  internal class Sound
  {
    private static AudioListener listener;
    private static AudioEmitter emitter;
    private static AudioEngine AE;
    private static WaveBank WB;
    public static SoundBank SB;
    public static AudioCategory MV;
    public Dictionary<string, Cue> SEs;
    public static List<string> already;
    public static int SEvolume;

    public Sound()
    {
      this.SEs = new Dictionary<string, Cue>();
    }

    public static void Init()
    {
      Sound.AE = new AudioEngine("Content/Sound/01.xna");
      Sound.WB = new WaveBank(Sound.AE, "Content/Sound/02.xna");
      Sound.SB = new SoundBank(Sound.AE, "Content/Sound/03.xna");
      Sound.MV = Sound.AE.GetCategory("Default");
      Sound.already = new List<string>();
      Sound.listener = new AudioListener();
      Sound.emitter = new AudioEmitter();
      Sound.listener.Position = Vector3.Zero;
      Sound.emitter.Position = Vector3.Zero;
    }

    public static void Update()
    {
      if (Sound.SEvolume <= 0)
        Sound.SEvolume = 0;
      Sound.MV.SetVolume((float) ((double) Sound.SEvolume / 150.0 * 3.0));
      Sound.AE.Update();
      Sound.already.Clear();
    }

    public int Play(string k, bool apply3d, float Position)
    {
      if (Main.Mode == Modes.SINGLE)
      {
        float num = (float) (((double) Position - 224.0) / 448.0);
        Sound.emitter.Position = (double) Position - 224.0 <= 0.0 ? ((double) Position - 224.0 >= 0.0 ? new Vector3(1.5f * num, 0.0f, 1f - Math.Abs(num)) : new Vector3(1.5f * num, 0.0f, 1f - Math.Abs(num))) : new Vector3(1.5f * num, 0.0f, 1f - Math.Abs(num));
      }
      if (!apply3d)
        Sound.emitter.Position = Vector3.Zero;
      foreach (string str in Sound.already)
      {
        if (str == k)
          return 0;
      }
      if (k.Contains(".wav"))
        k = k.Replace(".wav", "");
      foreach (string key in this.SEs.Keys)
      {
        if (key == k)
        {
          this.SEs[key].Dispose();
          this.SEs[key] = Sound.SB.GetCue(k);
          this.SEs[key].Apply3D(Sound.listener, Sound.emitter);
          this.SEs[key].Play();
          Sound.already.Add(k);
          return 0;
        }
      }
      Cue cue = Sound.SB.GetCue(k);
      this.SEs.Add(k, cue);
      cue.Apply3D(Sound.listener, Sound.emitter);
      cue.Play();
      Sound.already.Add(k);
      return 0;
    }

    public void Stop(string k)
    {
      foreach (string key in this.SEs.Keys)
      {
        if (key == k)
        {
          this.SEs[key].Dispose();
          this.SEs[key] = Sound.SB.GetCue(k);
          break;
        }
      }
    }

    public void Pause()
    {
      foreach (Cue cue in this.SEs.Values)
      {
        if (cue != null && !cue.IsDisposed && cue.IsPlaying)
          cue.Pause();
      }
    }

    public void Resume()
    {
      foreach (Cue cue in this.SEs.Values)
      {
        if (cue != null && !cue.IsDisposed && cue.IsPaused)
          cue.Resume();
      }
    }
  }
}
