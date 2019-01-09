// Decompiled with JetBrains decompiler
// Type: THMHJ.RecordSave
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace THMHJ
{
  public class RecordSave
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
    private PlayRank recovery;
    private bool step;
    private bool ok;
    private PlayData playdata;
    private float worda;
    private int time;
    private int selection;
    private int selection2;
    private int stage;
    private long score;
    private string nametemp;

    public bool Ok
    {
      get
      {
        return this.ok;
      }
    }

    public PlayData Playdata
    {
      get
      {
        return this.playdata;
      }
    }

    public RecordSave(PlayData data, int stagenow, long scorenow)
    {
      this.playdata = data;
      this.stage = stagenow;
      this.score = scorenow;
      this.selection = 0;
      for (int index1 = 0; index1 < this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data.Length; ++index1)
      {
        if (this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[index1] != null && this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[index1].score > scorenow)
          this.selection = index1 + 1;
        else if (this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[index1] != null)
        {
          this.selection = index1;
          for (int index2 = this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data.Length - 1; index2 >= index1; --index2)
          {
            if (index2 + 1 <= 9)
            {
              if (this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[index2] != null)
              {
                this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[index2 + 1] = new PlayRank();
                this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[index2 + 1].name = this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[index2].name;
                this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[index2 + 1].score = this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[index2].score;
                this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[index2 + 1].stage = this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[index2].stage;
                this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[index2 + 1].time = this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[index2].time;
              }
              else
                this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[index2 + 1] = (PlayRank) null;
            }
          }
          break;
        }
      }
      if (this.selection > 9)
        this.ok = true;
      if (this.ok)
        return;
      if (this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[this.selection] != null)
      {
        this.recovery = new PlayRank();
        this.recovery.name = this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[this.selection].name;
        this.recovery.score = this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[this.selection].score;
        this.recovery.stage = this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[this.selection].stage;
        this.recovery.time = this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[this.selection].time;
      }
      this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[this.selection] = new PlayRank();
      this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[this.selection].name = "_";
      this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[this.selection].score = this.score;
      this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[this.selection].stage = this.stage;
      DateTime now = DateTime.Now;
      this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[this.selection].time = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
      this.step = true;
      this.selection2 = 64;
      this.nametemp = Main.nametemp;
      if (this.nametemp == "")
        this.selection2 = 0;
      this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[this.selection].name = this.nametemp + "_";
    }

    public void Update()
    {
      this.worda += 0.1f;
      if ((double) this.worda >= 1.0)
        this.worda = 1f;
      if (this.step)
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
          if (this.selection2 <= 61 && this.nametemp.Length < 8)
          {
            Program.game.PlaySound("ok");
            this.nametemp += this.kyboard[this.selection2];
            this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[this.selection].name = this.nametemp + "_";
          }
          else if (this.selection2 == 62 && this.nametemp.Length < 8)
          {
            Program.game.PlaySound("ok");
            this.nametemp += " ";
            this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[this.selection].name = this.nametemp + "_";
          }
          if (this.selection2 == 63)
            this.BackSpace();
          else if (this.selection2 == 64)
            this.Save();
        }
        else if (Main.keyboardstat.IsKeyDown(Keys.X) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Escape) & Main.keyboardstat != Main.prekeyboard || (PadState.IsKeyPressed(JOYKEYS.Pause, Main.prepadstat) || PadState.IsKeyPressed(JOYKEYS.Special, Main.prepadstat)))
          this.BackSpace();
      }
      ++this.time;
    }

    private void BackSpace()
    {
      if (this.nametemp.Length <= 0)
        return;
      Program.game.PlaySound("cancel");
      this.nametemp = this.nametemp.Remove(this.nametemp.Length - 1);
      this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[this.selection].name = this.nametemp + "_";
    }

    private void Save()
    {
      Program.game.PlaySound("ok");
      this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[this.selection].name = this.nametemp;
      Main.nametemp = this.nametemp;
      this.ok = true;
    }

    public void Draw(SpriteBatch s, Vector2 pos)
    {
      float x = pos.X;
      float y = pos.Y;
      for (int index = 0; index < 10; ++index)
      {
        Vector3 vector3 = new Vector3(1f, 1f, 1f);
        if (this.selection == index)
          vector3 = new Vector3(1f, 0.0f, 0.0f);
        if (this.step && index == this.selection)
          vector3 = new Vector3(1f, 0.972549f, 0.4235294f);
        if (this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[index] != null)
        {
          string name = this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[index].name;
          Main.dfont.Draw(s, (index + 1).ToString().PadLeft(2, '0') + "." + name, new Vector2((float) (48.0 + (double) x + 1.0), (float) (68.0 + (double) y + (double) (index * 19) + 1.0)), new Color(0.0f, 0.0f, 0.0f, this.worda));
          Main.dfont.Draw(s, (index + 1).ToString().PadLeft(2, '0') + "." + name, new Vector2(48f + x, 68f + y + (float) (index * 19)), new Color(vector3.X, vector3.Y, vector3.Z, this.worda));
          string str1 = this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[index].score.ToString();
          string str2 = this.playdata.players[(int) (Main.Character - 1)].ranks[(int) (Main.Level - 1)].data[index].stage.ToString();
          if (str2 == "7")
            str2 = "EX";
          string str3 = str1.PadLeft(10, '0');
          Main.dfont.Draw(s, str3, new Vector2((float) (215.0 + (double) x + 1.0), (float) (68.0 + (double) y + (double) (index * 19) + 1.0)), new Color(0.0f, 0.0f, 0.0f, this.worda));
          Main.dfont.Draw(s, str3, new Vector2(215f + x, 68f + y + (float) (index * 19)), new Color(vector3.X, vector3.Y, vector3.Z, this.worda));
          string str4 = "Stage" + str2;
          Main.dfont.Draw(s, str4, new Vector2((float) (333.0 + (double) x + 1.0), (float) (68.0 + (double) y + (double) (index * 19) + 1.0)), new Color(0.0f, 0.0f, 0.0f, this.worda));
          Main.dfont.Draw(s, str4, new Vector2(333f + x, 68f + y + (float) (index * 19)), new Color(vector3.X, vector3.Y, vector3.Z, this.worda));
        }
        else
        {
          Main.dfont.Draw(s, (index + 1).ToString().PadLeft(2, '0') + ".------------", new Vector2((float) (48.0 + (double) x + 1.0), (float) (68.0 + (double) y + (double) (index * 19) + 1.0)), new Color(0.0f, 0.0f, 0.0f, this.worda));
          Main.dfont.Draw(s, (index + 1).ToString().PadLeft(2, '0') + ".------------", new Vector2(48f + x, 68f + y + (float) (index * 19)), new Color(vector3.X, vector3.Y, vector3.Z, this.worda));
          Main.dfont.Draw(s, "--------------", new Vector2((float) (215.0 + (double) x + 1.0), (float) (68.0 + (double) y + (double) (index * 19) + 1.0)), new Color(0.0f, 0.0f, 0.0f, this.worda));
          Main.dfont.Draw(s, "--------------", new Vector2(215f + x, 68f + y + (float) (index * 19)), new Color(vector3.X, vector3.Y, vector3.Z, this.worda));
          Main.dfont.Draw(s, "-------", new Vector2((float) (333.0 + (double) x + 1.0), (float) (68.0 + (double) y + (double) (index * 19) + 1.0)), new Color(0.0f, 0.0f, 0.0f, this.worda));
          Main.dfont.Draw(s, "-------", new Vector2(333f + x, 68f + y + (float) (index * 19)), new Color(vector3.X, vector3.Y, vector3.Z, this.worda));
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
