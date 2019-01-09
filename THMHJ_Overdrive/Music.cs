// Decompiled with JetBrains decompiler
// Type: THMHJ.Music
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework.Audio;

namespace THMHJ
{
  internal class Music
  {
    private static AudioEngine AE;
    private static WaveBank WB;
    public static SoundBank SB;
    public static AudioCategory MV;
    public static Cue BGM;
    public static bool BGMContaining;
    public static int BGMvolume;
    public static int Savevolume;

    public static void Init()
    {
      Music.AE = new AudioEngine("Content/Music/01.xna");
      Music.WB = new WaveBank(Music.AE, "Content/Music/02.xna", 0, (short) 4);
      Music.SB = new SoundBank(Music.AE, "Content/Music/03.xna");
      Music.MV = Music.AE.GetCategory(nameof (Music));
    }

    public static void Update()
    {
      if (Music.BGMvolume <= 0)
        Music.BGMvolume = 0;
      Music.MV.SetVolume((float) ((double) Music.BGMvolume / 100.0 * 3.0));
      Music.AE.Update();
    }
  }
}
