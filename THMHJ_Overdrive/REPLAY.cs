// Decompiled with JetBrains decompiler
// Type: THMHJ.REPLAY
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace THMHJ
{
  internal class REPLAY
  {
    private List<RPYInfo> rpys;
    private List<RecordManager> rms;
    private List<int?> seeds;
    private Texture2D black;
    private Vector2 blackpos;
    private Vector2 blackscale;
    private float blackalpha;
    private Vector2 black2pos;
    private float black2alpha;
    private int time;
    private int time2;
    private int page;
    private int selection;
    private int vselection;
    private int selection2;
    private List<int> stage;
    private List<long> stagescore;
    private float worda;
    private float word2a;
    private bool step;
    private bool spellcard;
    private int bossstage;
    private int barrageid;
    private bool fadeout;
    private bool ok;

    public int Selection2
    {
      get
      {
        return this.selection2;
      }
    }

    public bool Spellcard
    {
      get
      {
        return this.spellcard;
      }
    }

    public int BossStage
    {
      get
      {
        return this.bossstage;
      }
    }

    public int BarrageId
    {
      get
      {
        return this.barrageid;
      }
    }

    public bool Fadeout
    {
      get
      {
        return this.fadeout;
      }
    }

    public bool Ok
    {
      get
      {
        return this.ok;
      }
    }

    public REPLAY(Texture2D blackbox)
    {
      this.black = blackbox;
      this.blackpos = new Vector2(9f, 131f);
      this.blackscale = new Vector2(6.22f, 3.3f);
      this.blackalpha = 0.0f;
      this.black2pos = new Vector2(249f, 165f);
      this.black2alpha = 0.0f;
      this.GetFileInfo();
    }

    private void GetFileInfo()
    {
      this.rpys = new List<RPYInfo>();
      this.rms = new List<RecordManager>();
      this.seeds = new List<int?>();
      for (int index = 0; index < 45; ++index)
      {
        this.rpys.Add((RPYInfo) null);
        this.rms.Add((RecordManager) null);
        this.seeds.Add(new int?());
      }
      string[] files = Directory.GetFiles("Replay\\", "*.rpy");
      try
      {
        for (int index = 0; index < files.Length; ++index)
        {
          if (files[index].Contains("thmhj_"))
          {
            if (files[index].Split('.')[0].Split('_').Length > 1)
            {
              SaveData saveData = this.Load(files[index]);
              if (saveData != null)
              {
                this.rms[int.Parse(files[index].Split('.')[0].Split('_')[1])] = saveData.record;
                this.rpys[int.Parse(files[index].Split('.')[0].Split('_')[1])] = saveData.rpy;
                this.seeds[int.Parse(files[index].Split('.')[0].Split('_')[1])] = saveData.seed;
              }
            }
          }
        }
      }
      catch
      {
      }
    }

    private SaveData Load(string filename)
    {
      Stream serializationStream = Cry.Decry(filename, 3);
      SaveData saveData = (SaveData) new BinaryFormatter().Deserialize(serializationStream);
      serializationStream.Close();
      if (saveData.rpy.Version == Main.rpyversion)
        return saveData;
      return (SaveData) null;
    }

    public unsafe void Update()
    {
      if (this.time < 22)
      {
        this.blackalpha += 0.03f;
        if ((double) this.blackalpha >= 0.600000023841858)
          this.blackalpha = 0.6f;
      }
      else if (this.time >= 22 && this.time < 32)
      {
        this.worda += 0.1f;
        if ((double) this.worda >= 1.0)
          this.worda = 1f;
      }
      if (!this.fadeout && !this.step && this.time >= 32)
      {
        if (((!this.fadeout ? 1 : 0) & (Main.keyboardstat.IsKeyDown(Keys.Left) & Main.keyboardstat != Main.prekeyboard ? 1 : (PadState.IsKeyPressed(JOYKEYS.Left, Main.prepadstat) ? 1 : 0))) != 0)
        {
          Program.game.entrance.PlaySound("select");
          --this.page;
          if (this.page < 0)
            this.page = 2;
        }
        else if (((!this.fadeout ? 1 : 0) & (Main.keyboardstat.IsKeyDown(Keys.Right) & Main.keyboardstat != Main.prekeyboard ? 1 : (PadState.IsKeyPressed(JOYKEYS.Right, Main.prepadstat) ? 1 : 0))) != 0)
        {
          Program.game.entrance.PlaySound("select");
          ++this.page;
          if (this.page > 2)
            this.page = 0;
        }
        else if (((!this.fadeout ? 1 : 0) & (Main.keyboardstat.IsKeyDown(Keys.Up) & Main.keyboardstat != Main.prekeyboard ? 1 : (PadState.IsKeyPressed(JOYKEYS.Up, Main.prepadstat) ? 1 : 0))) != 0)
        {
          Program.game.entrance.PlaySound("select");
          --this.selection;
          if (this.selection < 0)
            this.selection = 14;
        }
        else if (((!this.fadeout ? 1 : 0) & (Main.keyboardstat.IsKeyDown(Keys.Down) & Main.keyboardstat != Main.prekeyboard ? 1 : (PadState.IsKeyPressed(JOYKEYS.Down, Main.prepadstat) ? 1 : 0))) != 0)
        {
          Program.game.entrance.PlaySound("select");
          ++this.selection;
          if (this.selection > 14)
            this.selection = 0;
        }
        else if (Main.keyboardstat.IsKeyDown(Keys.Enter) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Z) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Confirm, Main.prepadstat))
        {
          if (this.rpys[this.page * 15 + this.selection] != null)
          {
            Program.game.entrance.PlaySound("ok");
            this.step = true;
            this.time2 = 0;
            this.black2pos.X = 245f;
            this.vselection = 0;
          }
        }
        else if (Main.keyboardstat.IsKeyDown(Keys.X) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Escape) & Main.keyboardstat != Main.prekeyboard || (PadState.IsKeyPressed(JOYKEYS.Special, Main.prepadstat) || PadState.IsKeyPressed(JOYKEYS.Pause, Main.prepadstat)))
        {
          Program.game.entrance.PlaySound("cancel");
          this.fadeout = true;
        }
      }
      if (this.step)
      {
        if (this.time2 <= 20)
        {
          if (this.time2 == 0)
          {
            int num = 0;
            this.stage = new List<int>();
            this.stagescore = new List<long>();
            for (int index = 0; index < 7; ++index)
              this.stagescore.Add(0L);
            foreach (ScoreRecord score in this.rms[this.page * 15 + this.selection].scores)
            {
              if ((int) score.stage != (int) (byte) num)
              {
                this.stage.Add((int) score.stage);
                num = (int) score.stage;
              }
            }
            Main.ReplayFirstStage = this.stage[0];
            foreach (ScoreRecord score in this.rms[this.page * 15 + this.selection].scores)
            {
              if (score.type == (byte) 10)
                this.stagescore[(int) score.stage - 1] = score.score;
            }
            this.selection2 = this.stage[this.vselection];
          }
          this.black2pos.X += (float) ((195.0 - (double) this.black2pos.X) / 10.0);
          this.black2alpha += 0.035f;
          if ((double) this.black2alpha >= 0.699999988079071)
            this.black2alpha = 0.7f;
          this.word2a += 0.05f;
        }
        else if (!this.ok)
        {
          if (Main.keyboardstat.IsKeyDown(Keys.X) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Escape) & Main.keyboardstat != Main.prekeyboard || (PadState.IsKeyPressed(JOYKEYS.Special, Main.prepadstat) || PadState.IsKeyPressed(JOYKEYS.Pause, Main.prepadstat)))
          {
            this.time2 = 0;
            this.stage = (List<int>) null;
            this.step = false;
            fixed (float* v = &this.black2alpha)
            {
              ValueEvent valueEvent = new ValueEvent(v, 0.0f, 10, ChangeType.LINEAR);
            }
            fixed (float* v = &this.word2a)
            {
              ValueEvent valueEvent = new ValueEvent(v, 0.0f, 10, ChangeType.LINEAR);
            }
            Program.game.entrance.PlaySound("cancel");
          }
          if (Main.keyboardstat.IsKeyDown(Keys.Up) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Up, Main.prepadstat))
          {
            --this.vselection;
            if (this.vselection < 0)
              this.vselection = this.stage.Count - 1;
            this.selection2 = this.stage[this.vselection];
            Program.game.entrance.PlaySound("select");
          }
          if (Main.keyboardstat.IsKeyDown(Keys.Down) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Down, Main.prepadstat))
          {
            ++this.vselection;
            if (this.vselection >= this.stage.Count)
              this.vselection = 0;
            this.selection2 = this.stage[this.vselection];
            Program.game.entrance.PlaySound("select");
          }
          if (Main.keyboardstat.IsKeyDown(Keys.Enter) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Z) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Confirm, Main.prepadstat))
          {
            Program.game.entrance.PlaySound("ok");
            this.ok = true;
            if (this.rpys[this.page * 15 + this.selection].Level == (byte) 5)
            {
              this.spellcard = true;
              Main.Mode = Modes.SINGLE;
              Main.SpecialMode = Modes.SPELLCARD;
              this.bossstage = (int) this.rpys[this.page * 15 + this.selection].Mode;
              this.barrageid = (int) this.rpys[this.page * 15 + this.selection].SpecialMode;
            }
            else
            {
              Main.Mode = (Modes) this.rpys[this.page * 15 + this.selection].Mode;
              Main.SpecialMode = (Modes) this.rpys[this.page * 15 + this.selection].SpecialMode;
              Main.Level = (Difficulty) ((int) this.rpys[this.page * 15 + this.selection].Level + 1);
            }
            Main.Character = (Cname) ((int) this.rpys[this.page * 15 + this.selection].Chara + 1);
            Main.SetReplay(this.rms[this.page * 15 + this.selection]);
            Main.gameseed = this.seeds[this.page * 15 + this.selection];
            fixed (float* v = &this.blackalpha)
            {
              ValueEvent valueEvent = new ValueEvent(v, 0.0f, 10, ChangeType.LINEAR);
            }
            fixed (float* v = &this.worda)
            {
              ValueEvent valueEvent = new ValueEvent(v, 0.0f, 10, ChangeType.LINEAR);
            }
            fixed (float* v = &this.black2alpha)
            {
              ValueEvent valueEvent = new ValueEvent(v, 0.0f, 10, ChangeType.LINEAR);
            }
            fixed (float* v = &this.word2a)
            {
              ValueEvent valueEvent = new ValueEvent(v, 0.0f, 10, ChangeType.LINEAR);
            }
          }
        }
        ++this.time2;
      }
      if (this.fadeout)
      {
        this.blackalpha -= 0.03f;
        if ((double) this.blackalpha <= 0.0)
          this.blackalpha = 0.0f;
        this.worda -= 0.1f;
        if ((double) this.worda <= 0.0)
          this.worda = 0.0f;
      }
      ++this.time;
    }

    public void Draw(SpriteBatch s)
    {
      s.Draw(this.black, this.blackpos, new Rectangle?(), new Color(1f, 1f, 1f, this.blackalpha), 0.0f, Vector2.Zero, this.blackscale, SpriteEffects.None, 0.0f);
      if (this.time >= 22)
      {
        for (int index = this.page * 15; index < this.page * 15 + 15; ++index)
        {
          Vector3 vector3 = new Vector3(1f, 1f, 1f);
          if (this.selection == index - this.page * 15)
            vector3 = new Vector3(1f, 0.0f, 0.0f);
          if (this.rpys[index] != null)
          {
            string name = this.rpys[index].Name;
            Main.dfont.Draw(s, name, new Vector2(39f, (float) (150 + (index - this.page * 15) * 19 + 1)), new Color(0.0f, 0.0f, 0.0f, this.worda));
            Main.dfont.Draw(s, name, new Vector2(38f, (float) (150 + (index - this.page * 15) * 19)), new Color(vector3.X, vector3.Y, vector3.Z, this.worda));
            string str1 = this.rpys[index].Time.Year.ToString().PadLeft(4, '0') + "/" + this.rpys[index].Time.Month.ToString().PadLeft(2, '0') + "/" + this.rpys[index].Time.Day.ToString().PadLeft(2, '0');
            string str2 = this.rpys[index].Time.Hour.ToString().PadLeft(2, '0') + ":" + this.rpys[index].Time.Minute.ToString().PadLeft(2, '0') + ":" + this.rpys[index].Time.Second.ToString().PadLeft(2, '0');
            Main.dfont.Draw(s, str1 + " " + str2, new Vector2(151f, (float) (150 + (index - this.page * 15) * 19 + 1)), new Color(0.0f, 0.0f, 0.0f, this.worda));
            Main.dfont.Draw(s, str1 + " " + str2, new Vector2(150f, (float) (150 + (index - this.page * 15) * 19)), new Color(vector3.X, vector3.Y, vector3.Z, this.worda));
            string str3 = Main.CharacterString[(int) this.rpys[index].Chara];
            Main.dfont.Draw(s, str3, new Vector2(351f, (float) (150 + (index - this.page * 15) * 19 + 1)), new Color(0.0f, 0.0f, 0.0f, this.worda));
            Main.dfont.Draw(s, str3, new Vector2(350f, (float) (150 + (index - this.page * 15) * 19)), new Color(vector3.X, vector3.Y, vector3.Z, this.worda));
            string str4 = Main.LevelString[(int) this.rpys[index].Level];
            Main.dfont.Draw(s, str4, new Vector2(454f, (float) (150 + (index - this.page * 15) * 19 + 1)), new Color(0.0f, 0.0f, 0.0f, this.worda));
            Main.dfont.Draw(s, str4, new Vector2(453f, (float) (150 + (index - this.page * 15) * 19)), new Color(vector3.X, vector3.Y, vector3.Z, this.worda));
            string str5 = this.rpys[index].Score.ToString().PadLeft(10, '0');
            Main.dfont.Draw(s, str5, new Vector2(499f, (float) (150 + (index - this.page * 15) * 19 + 1)), new Color(0.0f, 0.0f, 0.0f, this.worda));
            Main.dfont.Draw(s, str5, new Vector2(498f, (float) (150 + (index - this.page * 15) * 19)), new Color(vector3.X, vector3.Y, vector3.Z, this.worda));
          }
          else
          {
            Main.dfont.Draw(s, "--------------------------------------------------------------------------------", new Vector2(39f, (float) (150 + (index - this.page * 15) * 19 + 1)), new Color(0.0f, 0.0f, 0.0f, this.worda));
            Main.dfont.Draw(s, "--------------------------------------------------------------------------------", new Vector2(38f, (float) (150 + (index - this.page * 15) * 19)), new Color(vector3.X, vector3.Y, vector3.Z, this.worda));
          }
        }
      }
      s.Draw(this.black, this.black2pos, new Rectangle?(), new Color(1f, 1f, 1f, this.black2alpha), 0.0f, Vector2.Zero, new Vector2(2.42f, 1.51f), SpriteEffects.None, 0.0f);
      if (this.stage == null)
        return;
      for (int index1 = 1; index1 <= 7; ++index1)
      {
        for (int index2 = 0; index2 < this.stage.Count; ++index2)
        {
          if (this.stage[index2] == index1)
          {
            Color color = new Color(1f, 1f, 1f, this.word2a);
            if (index1 == this.selection2)
              color = new Color(1f, 0.0f, 0.0f, this.word2a);
            string str1 = index1.ToString() + " ";
            if (index1 == 7)
              str1 = "Ex";
            string str2 = this.stagescore[index1 - 1].ToString().PadLeft(10, '0');
            Main.dfont.Draw(s, "Stage " + str1 + "  " + str2, new Vector2(220f, (float) (180 + (index1 - 1) * 17 + 1)), new Color(0.0f, 0.0f, 0.0f, this.word2a));
            Main.dfont.Draw(s, "Stage " + str1 + "  " + str2, new Vector2(219f, (float) (180 + (index1 - 1) * 17)), color);
            break;
          }
          if (index2 == this.stage.Count - 1)
          {
            Main.dfont.Draw(s, "-----------------------------", new Vector2(220f, (float) (180 + (index1 - 1) * 17 + 1)), new Color(0.0f, 0.0f, 0.0f, this.word2a));
            Main.dfont.Draw(s, "-----------------------------", new Vector2(219f, (float) (180 + (index1 - 1) * 17)), new Color(1f, 1f, 1f, this.word2a));
          }
        }
      }
    }
  }
}
