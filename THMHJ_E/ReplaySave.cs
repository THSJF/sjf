// Decompiled with JetBrains decompiler
// Type: THMHJ.ReplaySave
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace THMHJ
{
  public class ReplaySave
  {
    private string[] kyboard = new string[65]
    {
      "A",
      "B",
      "C",
      "D",
      "E",
      "F",
      "G",
      "H",
      "I",
      "J",
      "K",
      "L",
      "M",
      "N",
      "O",
      "P",
      "Q",
      "R",
      "S",
      "T",
      "U",
      "V",
      "W",
      "X",
      "Y",
      "Z",
      "a",
      "b",
      "c",
      "d",
      "e",
      "f",
      "g",
      "h",
      "i",
      "j",
      "k",
      "l",
      "m",
      "n",
      "o",
      "p",
      "q",
      "r",
      "s",
      "t",
      "u",
      "v",
      "w",
      "x",
      "y",
      "z",
      "0",
      "1",
      "2",
      "3",
      "4",
      "5",
      "6",
      "7",
      "8",
      "9",
      "□",
      "←",
      "终"
    };
    private SaveData data;
    private RPYInfo rpytemp;
    private List<RPYInfo> rpys;
    private long score;
    private int chara;
    private int level;
    private int time;
    private int page;
    private int selection;
    private int selection2;
    private string nametemp;
    private float worda;
    private int bossstage;
    private int barrageid;
    private bool spellcard;
    private bool start;
    private bool step;
    private bool ok;

    public SaveData Data
    {
      get
      {
        return this.data;
      }
    }

    public bool Ok
    {
      get
      {
        return this.ok;
      }
    }

    public ReplaySave(
      RecordManager records,
      int rtime,
      long scores,
      int charas,
      int levels,
      int stage)
    {
      this.data = new SaveData(Main.gameseed);
      this.data.record = records;
      this.score = scores;
      this.chara = charas;
      this.level = levels;
      this.FinalSave(rtime, stage);
      this.GetFileInfo();
      this.nametemp = Main.nametemp;
    }

    public ReplaySave(
      RecordManager records,
      int rtime,
      long scores,
      int charas,
      int levels,
      int bossstage,
      int barrageid)
    {
      this.data = new SaveData(Main.gameseed);
      this.data.record = records;
      this.bossstage = bossstage;
      this.barrageid = barrageid;
      this.spellcard = true;
      this.score = scores;
      this.chara = charas;
      this.level = levels;
      this.FinalSave(rtime, bossstage / 10);
      this.GetFileInfo();
      this.nametemp = Main.nametemp;
    }

    private void FinalSave(int rtime, int stage)
    {
      this.data.record.lostrate = Main.GetFpsLostRate();
      this.data.record.actions.Add(new ActionRecord()
      {
        type = (byte) 3,
        time = rtime,
        stage = (byte) stage
      });
    }

    private void GetFileInfo()
    {
      this.rpys = new List<RPYInfo>();
      for (int index = 0; index < 45; ++index)
        this.rpys.Add((RPYInfo) null);
      string[] files = Directory.GetFiles("Replay\\", "*.rpy");
      try
      {
        for (int index = 0; index < files.Length; ++index)
        {
          if (files[index].Contains("thmhj_"))
          {
            if (files[index].Split('.')[0].Split('_').Length > 1)
              this.rpys[int.Parse(files[index].Split('.')[0].Split('_')[1])] = this.Load(files[index]);
          }
        }
      }
      catch
      {
      }
    }

    public void Update()
    {
      this.worda += 0.1f;
      if ((double) this.worda >= 1.0)
        this.worda = 1f;
      if (this.time > 10 && !this.ok && !this.step)
      {
        if (Main.keyboardstat.IsKeyDown(Keys.Left) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Left, Main.prepadstat))
        {
          Program.game.PlaySound("select");
          --this.page;
          if (this.page < 0)
            this.page = 2;
        }
        else if (Main.keyboardstat.IsKeyDown(Keys.Right) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Right, Main.prepadstat))
        {
          Program.game.PlaySound("select");
          ++this.page;
          if (this.page > 2)
            this.page = 0;
        }
        else if (Main.keyboardstat.IsKeyDown(Keys.Up) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Up, Main.prepadstat))
        {
          Program.game.PlaySound("select");
          --this.selection;
          if (this.selection < 0)
            this.selection = 14;
        }
        else if (Main.keyboardstat.IsKeyDown(Keys.Down) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Down, Main.prepadstat))
        {
          Program.game.PlaySound("select");
          ++this.selection;
          if (this.selection > 14)
            this.selection = 0;
        }
        else if (Main.keyboardstat.IsKeyDown(Keys.Enter) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Z) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Confirm, Main.prepadstat))
        {
          Program.game.PlaySound("ok");
          if (this.rpys[this.page * 15 + this.selection] != null)
          {
            this.rpytemp = new RPYInfo();
            this.rpytemp.SetVersion(Main.rpyversion);
            this.rpytemp.SetChara(this.rpys[this.page * 15 + this.selection].Chara);
            this.rpytemp.SetName(this.rpys[this.page * 15 + this.selection].Name);
            this.rpytemp.SetTime(this.rpys[this.page * 15 + this.selection].Time);
            this.rpytemp.SetLevel(this.rpys[this.page * 15 + this.selection].Level);
            this.rpytemp.SetScore(this.rpys[this.page * 15 + this.selection].Score);
            this.rpytemp.SetMode(this.rpys[this.page * 15 + this.selection].Mode);
            this.rpytemp.SetSpecialMode(this.rpys[this.page * 15 + this.selection].SpecialMode);
          }
          this.rpys[this.page * 15 + this.selection] = new RPYInfo();
          this.rpys[this.page * 15 + this.selection].SetVersion(Main.rpyversion);
          this.rpys[this.page * 15 + this.selection].SetName(this.nametemp + "_");
          this.rpys[this.page * 15 + this.selection].SetScore(this.score);
          this.rpys[this.page * 15 + this.selection].SetMode((byte) Main.Mode);
          this.rpys[this.page * 15 + this.selection].SetSpecialMode((byte) Main.SpecialMode);
          this.rpys[this.page * 15 + this.selection].SetChara((byte) this.chara);
          this.rpys[this.page * 15 + this.selection].SetLevel((byte) this.level);
          if (this.spellcard)
          {
            this.rpys[this.page * 15 + this.selection].SetLevel((byte) 5);
            this.rpys[this.page * 15 + this.selection].SetMode((byte) this.bossstage);
            this.rpys[this.page * 15 + this.selection].SetSpecialMode((byte) this.barrageid);
          }
          DateTime now = DateTime.Now;
          this.rpys[this.page * 15 + this.selection].SetTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
          this.step = true;
          this.selection2 = 64;
          if (this.nametemp == "")
            this.selection2 = 0;
        }
        else if (Main.keyboardstat.IsKeyDown(Keys.X) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Escape) & Main.keyboardstat != Main.prekeyboard || (PadState.IsKeyPressed(JOYKEYS.Special, Main.prepadstat) || PadState.IsKeyPressed(JOYKEYS.Pause, Main.prepadstat)))
        {
          Program.game.PlaySound("cancel");
          this.ok = true;
        }
      }
      else if (this.time > 10 && !this.ok && this.step)
      {
        if (Main.keyboardstat.IsKeyDown(Keys.Left) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Left, Main.prepadstat))
        {
          Program.game.PlaySound("select");
          --this.selection2;
          if (this.selection2 < 0)
            this.selection2 = 0;
        }
        else if (Main.keyboardstat.IsKeyDown(Keys.Right) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Right, Main.prepadstat))
        {
          Program.game.PlaySound("select");
          ++this.selection2;
          if (this.selection2 > this.kyboard.Length - 1)
            this.selection2 = this.kyboard.Length - 1;
        }
        else if (Main.keyboardstat.IsKeyDown(Keys.Up) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Up, Main.prepadstat))
        {
          Program.game.PlaySound("select");
          if (this.selection2 - 13 >= 0)
            this.selection2 -= 13;
          else
            this.selection2 = this.kyboard.Length - 1 - (12 - this.selection2);
        }
        else if (Main.keyboardstat.IsKeyDown(Keys.Down) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Down, Main.prepadstat))
        {
          Program.game.PlaySound("select");
          if (this.selection2 + 13 <= this.kyboard.Length - 1)
            this.selection2 += 13;
          else
            this.selection2 = 12 - (this.kyboard.Length - 1 - this.selection2);
        }
        else if (Main.keyboardstat.IsKeyDown(Keys.Enter) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Z) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Confirm, Main.prepadstat))
        {
          if (this.start)
          {
            if (this.selection2 <= 61 && this.nametemp.Length < 8)
            {
              Program.game.PlaySound("ok");
              this.nametemp += this.kyboard[this.selection2];
              this.rpys[this.page * 15 + this.selection].SetName(this.nametemp + "_");
            }
            else if (this.selection2 == 62 && this.nametemp.Length < 8)
            {
              Program.game.PlaySound("ok");
              this.nametemp += " ";
              this.rpys[this.page * 15 + this.selection].SetName(this.nametemp + "_");
            }
          }
          this.start = true;
          if (this.selection2 == 63)
            this.BackSpace();
          else if (this.selection2 == 64)
            this.Save();
        }
        else if (Main.keyboardstat.IsKeyDown(Keys.X) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Escape) & Main.keyboardstat != Main.prekeyboard || (PadState.IsKeyPressed(JOYKEYS.Special, Main.prepadstat) || PadState.IsKeyPressed(JOYKEYS.Pause, Main.prepadstat)))
          this.BackSpace();
      }
      ++this.time;
    }

    private void BackSpace()
    {
      if (this.nametemp.Length > 0)
      {
        Program.game.PlaySound("cancel");
        this.nametemp = this.nametemp.Remove(this.nametemp.Length - 1);
        this.rpys[this.page * 15 + this.selection].SetName(this.nametemp + "_");
      }
      else
      {
        Program.game.PlaySound("cancel");
        this.step = false;
        this.start = false;
        this.nametemp = "";
        if (this.rpytemp != null)
        {
          this.rpys[this.page * 15 + this.selection].SetVersion(Main.rpyversion);
          this.rpys[this.page * 15 + this.selection].SetName(this.rpytemp.Name);
          this.rpys[this.page * 15 + this.selection].SetScore(this.rpytemp.Score);
          this.rpys[this.page * 15 + this.selection].SetMode(this.rpytemp.Mode);
          this.rpys[this.page * 15 + this.selection].SetSpecialMode(this.rpytemp.SpecialMode);
          this.rpys[this.page * 15 + this.selection].SetChara(this.rpytemp.Chara);
          this.rpys[this.page * 15 + this.selection].SetLevel(this.rpytemp.Level);
          this.rpys[this.page * 15 + this.selection].SetTime(this.rpytemp.Time);
        }
        else
          this.rpys[this.page * 15 + this.selection] = (RPYInfo) null;
      }
    }

    private void Save()
    {
      Program.game.PlaySound("extend");
      this.rpys[this.page * 15 + this.selection].SetName(this.nametemp);
      this.data.rpy = this.rpys[this.page * 15 + this.selection];
      string str = "Replay\\thmhj_" + (this.page * 15 + this.selection).ToString().PadLeft(2, '0') + ".rpy";
      FileStream fileStream = File.Open(str, FileMode.Create);
      new BinaryFormatter().Serialize((Stream) fileStream, (object) this.data);
      fileStream.Close();
      Cry.Encry(str, 3);
      this.step = false;
      this.start = false;
      Main.nametemp = this.nametemp;
      this.nametemp = "";
    }

    private RPYInfo Load(string filename)
    {
      Stream serializationStream = Cry.Decry(filename, 3);
      SaveData saveData = (SaveData) new BinaryFormatter().Deserialize(serializationStream);
      serializationStream.Close();
      if (saveData.rpy.Version == Main.rpyversion)
        return saveData.rpy;
      return (RPYInfo) null;
    }

    public void Draw(SpriteBatch s, Vector2 pos)
    {
      float x = pos.X;
      float y = pos.Y;
      for (int index = this.page * 15; index < this.page * 15 + 15; ++index)
      {
        Vector3 vector3 = new Vector3(1f, 1f, 1f);
        if (this.selection == index - this.page * 15)
          vector3 = new Vector3(1f, 0.0f, 0.0f);
        if (this.step && index == this.selection)
          vector3 = new Vector3(1f, 0.972549f, 0.4235294f);
        if (this.rpys[index] != null)
        {
          string name = this.rpys[index].Name;
          Main.dfont.Draw(s, name, new Vector2((float) (48.0 + (double) x + 1.0), (float) (38.0 + (double) y + (double) ((index - this.page * 15) * 19) + 1.0)), new Color(0.0f, 0.0f, 0.0f, this.worda));
          Main.dfont.Draw(s, name, new Vector2(48f + x, 38f + y + (float) ((index - this.page * 15) * 19)), new Color(vector3.X, vector3.Y, vector3.Z, this.worda));
          string str = this.rpys[index].Time.Year.ToString().PadLeft(4, '0') + "/" + this.rpys[index].Time.Month.ToString().PadLeft(2, '0') + "/" + this.rpys[index].Time.Day.ToString().PadLeft(2, '0') + " " + (this.rpys[index].Time.Hour.ToString().PadLeft(2, '0') + ":" + this.rpys[index].Time.Minute.ToString().PadLeft(2, '0') + ":" + this.rpys[index].Time.Second.ToString().PadLeft(2, '0'));
          Main.dfont.Draw(s, str, new Vector2((float) (225.0 + (double) x + 1.0), (float) (38.0 + (double) y + (double) ((index - this.page * 15) * 19) + 1.0)), new Color(0.0f, 0.0f, 0.0f, this.worda));
          Main.dfont.Draw(s, str, new Vector2(225f + x, 38f + y + (float) ((index - this.page * 15) * 19)), new Color(vector3.X, vector3.Y, vector3.Z, this.worda));
        }
        else
        {
          Main.dfont.Draw(s, "------------", new Vector2((float) (48.0 + (double) x + 1.0), (float) (38.0 + (double) y + (double) ((index - this.page * 15) * 19) + 1.0)), new Color(0.0f, 0.0f, 0.0f, this.worda));
          Main.dfont.Draw(s, "------------", new Vector2(48f + x, 38f + y + (float) ((index - this.page * 15) * 19)), new Color(vector3.X, vector3.Y, vector3.Z, this.worda));
          Main.dfont.Draw(s, "----/--/-- --:--:--", new Vector2((float) (265.0 + (double) x + 1.0), (float) (38.0 + (double) y + (double) ((index - this.page * 15) * 19) + 1.0)), new Color(0.0f, 0.0f, 0.0f, this.worda));
          Main.dfont.Draw(s, "----/--/-- --:--:--", new Vector2(265f + x, 38f + y + (float) ((index - this.page * 15) * 19)), new Color(vector3.X, vector3.Y, vector3.Z, this.worda));
        }
      }
      for (int index = 0; index < this.kyboard.Length; ++index)
      {
        Vector3 vector3 = new Vector3(1f, 1f, 1f);
        if (this.step && index == this.selection2)
          vector3 = new Vector3(1f, 0.0f, 0.0f);
        int num1 = index % 13 * 22;
        int num2 = index / 13 * 22;
        Main.dfont.Draw(s, this.kyboard[index], new Vector2((float) ((double) (85 + num1) + (double) x + 1.0), (float) ((double) (338 + num2) + (double) y + 1.0)), new Color(0.0f, 0.0f, 0.0f, this.worda));
        Main.dfont.Draw(s, this.kyboard[index], new Vector2((float) (85 + num1) + x, (float) (338 + num2) + y), new Color(vector3.X, vector3.Y, vector3.Z, this.worda));
      }
    }
  }
}
