// Decompiled with JetBrains decompiler
// Type: THMHJ.RecordManager
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace THMHJ
{
  [Serializable]
  public class RecordManager
  {
    public static Keys[] used = new Keys[8]
    {
      Keys.Up,
      Keys.Down,
      Keys.Left,
      Keys.Right,
      Keys.Z,
      Keys.X,
      Keys.LeftShift,
      Keys.RightShift
    };
    public static JOYKEYS[] padused = new JOYKEYS[8]
    {
      JOYKEYS.Up,
      JOYKEYS.Down,
      JOYKEYS.Left,
      JOYKEYS.Right,
      JOYKEYS.Confirm,
      JOYKEYS.Special,
      JOYKEYS.Slow,
      JOYKEYS.Slow
    };
    public List<byte>[] records;
    public List<ActionRecord> actions;
    public List<PositionRecord> Positions;
    public List<ScoreRecord> scores;
    public List<RandSeedRecord> seeds;
    public float lostrate;

    public RecordManager()
    {
      this.records = new List<byte>[7];
      for (int index = 0; index < 7; ++index)
        this.records[index] = new List<byte>();
      this.actions = new List<ActionRecord>();
      this.Positions = new List<PositionRecord>();
      this.scores = new List<ScoreRecord>();
      this.seeds = new List<RandSeedRecord>();
    }

    public RecordManager Clone()
    {
      MemoryStream memoryStream = new MemoryStream();
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      binaryFormatter.Serialize((Stream) memoryStream, (object) this);
      memoryStream.Seek(0L, SeekOrigin.Begin);
      object obj = binaryFormatter.Deserialize((Stream) memoryStream);
      memoryStream.Close();
      return (RecordManager) obj;
    }
  }
}
