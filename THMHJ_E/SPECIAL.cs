// Decompiled with JetBrains decompiler
// Type: THMHJ.SPECIAL
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace THMHJ
{
  internal class SPECIAL
  {
    private static string[] level = new string[5]
    {
      "EASY",
      "NORMAL",
      "HARD",
      "LUNATIC",
      "EXTRA"
    };
    private PlayData pdata;
    private PracticeData prdata;
    private SpecialData sdata;
    private Sprite[] character;
    private Sprite black;
    private Sprite[] button;
    private Sprite[] buttonon;
    private Texture2D achivbox;
    private Sprite achivboxon;
    private Texture2D achivlogo;
    private Sprite achivrate;
    private Texture2D achivstatus;
    private Sprite achivtype;
    private Sprite crapwise;
    private Vector2[] crappos;
    private string[][] achivs;
    private int[] achivrates;
    private int time;
    private int steptime;
    private int step2time;
    private int ftime;
    private float wordalpha;
    private float ccolor;
    private bool cleared;
    private bool step;
    private bool step2;
    private bool fadeout;
    private string[] scname;
    private int selection;
    private int selection2;
    private int selection3;
    private int selection3range;
    private int cselection;
    private string scselection;
    private bool finished;

    public bool Step
    {
      get
      {
        return this.step;
      }
    }

    public int Selection
    {
      get
      {
        return this.selection;
      }
    }

    public string Scselection
    {
      get
      {
        return this.scselection;
      }
    }

    public bool Finished
    {
      get
      {
        return this.finished;
      }
    }

    public SPECIAL(
      PracticeData pdata,
      Sprite[] character,
      Texture2D blackbox,
      params Texture2D[] button)
    {
      for (int index = 0; index < 4; ++index)
      {
        if (pdata.clear[index])
        {
          this.cleared = true;
          break;
        }
      }
      if (!this.cleared)
        this.selection = 1;
      this.character = character;
      this.black = new Sprite(blackbox);
      this.black.scale = new Vector2(6.4f, 4.8f);
      this.button = new Sprite[4];
      this.buttonon = new Sprite[4];
      for (int index = 0; index < button.Length / 2; ++index)
      {
        this.button[index] = new Sprite(button[index]);
        this.button[index].position = new Vector2((float) (44 + 20 * index - 30), (float) (285 + 30 * index));
      }
      for (int index = button.Length / 2; index < button.Length; ++index)
      {
        this.buttonon[index - button.Length / 2] = new Sprite(button[index]);
        this.buttonon[index - button.Length / 2].position = new Vector2((float) (44 + 20 * (index - button.Length / 2) - 30), (float) (285 + 30 * (index - button.Length / 2)));
      }
      if (Main.SkiptoSCChanllenges)
      {
        this.step = true;
        this.selection = 2;
      }
      this.pdata = this.LoadPlayData();
      this.prdata = this.LoadPracticeData();
      this.sdata = this.Load("Content/Data/8.xna");
      this.achivrates = new int[3];
      for (int index1 = 0; index1 < 3; ++index1)
      {
        float num = 0.0f;
        for (int index2 = 0; index2 < this.sdata.ach[index1].achiv.Length; ++index2)
        {
          if (this.sdata.ach[index1].achiv[index2].get)
            ++num;
        }
        this.achivrates[index1] = (int) ((double) num / (double) this.sdata.ach[index1].achiv.Length * 100.0);
      }
      for (int index = 0; index < 4; ++index)
        character[index].position = new Vector2(0.0f, 0.0f);
    }

    public void Texture(
      GraphicsDevice g,
      Texture2D achivbox,
      Texture2D achivboxon,
      Texture2D achivlogo,
      Texture2D achivrate,
      Texture2D achivstatus,
      Texture2D achivtype,
      Texture2D crapwise)
    {
      this.achivbox = achivbox;
      this.achivboxon = new Sprite(achivboxon);
      this.achivlogo = achivlogo;
      this.achivrate = new Sprite(achivrate);
      this.achivstatus = achivstatus;
      this.achivtype = new Sprite(achivtype);
      this.crapwise = new Sprite(crapwise);
      this.crappos = new Vector2[2];
      this.crappos[0] = new Vector2(37f, 125f);
      this.crappos[1] = new Vector2(177f, 125f);
      this.achivtype.position = new Vector2(70f, 122f);
      this.achivrate.position = new Vector2(480f, 125f);
    }

    public void Update()
    {
      for (int index = 0; index < this.button.Length; ++index)
      {
        if (this.time >= index * 3 && this.time < 10 + index * 3)
        {
          this.button[index].color.a += 0.1f;
          this.button[index].position.X += 3f;
          this.buttonon[index].color.a += 0.1f;
          this.buttonon[index].position.X += 3f;
        }
      }
      if (!this.step && !this.fadeout && this.time >= 32)
      {
        if (Main.keyboardstat.IsKeyDown(Keys.Up) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Up, Main.prepadstat))
        {
          Program.game.entrance.PlaySound("select");
          --this.selection;
          if (this.cleared)
          {
            if (this.selection < 0)
              this.selection = 3;
          }
          else if (this.selection < 1)
            this.selection = 3;
        }
        else if (Main.keyboardstat.IsKeyDown(Keys.Down) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Down, Main.prepadstat))
        {
          Program.game.entrance.PlaySound("select");
          ++this.selection;
          if (this.cleared)
          {
            if (this.selection > 3)
              this.selection = 0;
          }
          else if (this.selection > 3)
            this.selection = 1;
        }
        if (Main.keyboardstat.IsKeyDown(Keys.Z) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Enter) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Confirm, Main.prepadstat))
        {
          Program.game.entrance.PlaySound("ok");
          switch (this.selection)
          {
            case 0:
              this.fadeout = true;
              break;
            case 1:
              this.achivs = this.LoadAchievementList("Content/Data/9.xna");
              this.step = true;
              break;
            case 2:
              this.step = true;
              break;
            case 3:
              this.fadeout = true;
              break;
          }
        }
        else if (Main.keyboardstat.IsKeyDown(Keys.X) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Escape) & Main.keyboardstat != Main.prekeyboard || (PadState.IsKeyPressed(JOYKEYS.Special, Main.prepadstat) || PadState.IsKeyPressed(JOYKEYS.Pause, Main.prepadstat)))
        {
          Program.game.entrance.PlaySound("cancel");
          this.selection = 3;
        }
        this.buttonon[this.selection].color.a = 1f;
      }
      if (this.step)
      {
        if ((double) this.ccolor > 0.0)
          this.ccolor -= 0.05f;
        for (int index = 0; index < 4; ++index)
        {
          if (index == this.cselection)
          {
            if ((double) this.character[index].color.a > 0.0)
              this.character[index].color.a -= 0.05f;
          }
          else
            this.character[index].color.a = 0.0f;
        }
        for (int index = 0; index < this.button.Length; ++index)
        {
          if (this.steptime >= index * 3 && this.steptime < 10 + index * 3)
          {
            this.button[index].color.a -= 0.1f;
            this.button[index].position.X -= 3f;
            this.buttonon[index].color.a -= 0.1f;
            this.buttonon[index].position.X -= 3f;
          }
        }
        if (this.selection == 2)
        {
          if (this.steptime == 0)
            this.cselection = (int) (Main.Character - 1);
          for (int index = 0; index < 4; ++index)
          {
            if (index == this.cselection)
            {
              if ((double) this.character[index].color.a < 1.0)
                this.character[index].color.a += 0.1f;
            }
            else
              this.character[index].color.a = 0.0f;
          }
          if ((double) this.wordalpha < 1.0)
            this.wordalpha += 0.05f;
          if (this.steptime >= 32)
          {
            if (!this.step2)
            {
              if (Main.keyboardstat.IsKeyDown(Keys.Up) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Up, Main.prepadstat))
              {
                Program.game.entrance.PlaySound("select");
                --this.selection2;
                if (this.selection2 < 0)
                  this.selection2 = 6;
              }
              else if (Main.keyboardstat.IsKeyDown(Keys.Down) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Down, Main.prepadstat))
              {
                Program.game.entrance.PlaySound("select");
                ++this.selection2;
                if (this.selection2 > 6)
                  this.selection2 = 0;
              }
              if (Main.keyboardstat.IsKeyDown(Keys.Z) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Enter) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Confirm, Main.prepadstat))
              {
                Program.game.entrance.PlaySound("ok");
                this.scname = this.LoadSpellCardList("Content/Data/7.xna");
                bool flag = false;
                if (this.selection2 < 5)
                {
                  for (int index1 = 0; index1 < this.prdata.clearstate.Length; ++index1)
                  {
                    for (int index2 = 0; index2 < this.prdata.clearstate[index1].Length - 1; ++index2)
                    {
                      if (this.prdata.clearstate[index1][index2] > this.selection2 + 1)
                      {
                        flag = true;
                        break;
                      }
                    }
                  }
                }
                else if (this.selection2 == 5)
                {
                  for (int index = 0; index < this.prdata.clear.Length; ++index)
                  {
                    if (this.prdata.clear[index])
                    {
                      flag = true;
                      break;
                    }
                  }
                }
                if (this.selection2 == 6)
                {
                  for (int index = 0; index < this.pdata.players.Length; ++index)
                  {
                    if (this.pdata.players[index].sc[4].Count >= (int) Main.SpellcardNum[4])
                    {
                      flag = true;
                      break;
                    }
                  }
                }
                if (flag)
                  this.selection3range = this.scname[this.selection2].Split('^').Length - 2;
                else
                  this.selection3range = 0;
                this.step2 = true;
              }
              else if (Main.keyboardstat.IsKeyDown(Keys.X) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Escape) & Main.keyboardstat != Main.prekeyboard || (PadState.IsKeyPressed(JOYKEYS.Special, Main.prepadstat) || PadState.IsKeyPressed(JOYKEYS.Pause, Main.prepadstat)))
              {
                Program.game.entrance.PlaySound("cancel");
                this.step = false;
                this.time = 0;
                this.steptime = 0;
                this.selection2 = 0;
              }
            }
            if (Main.keyboardstat.IsKeyDown(Keys.Left) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Left, Main.prepadstat))
            {
              Program.game.entrance.PlaySound("select");
              --this.cselection;
              if (this.cselection < 0)
                this.cselection = 3;
            }
            else if (Main.keyboardstat.IsKeyDown(Keys.Right) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Right, Main.prepadstat))
            {
              Program.game.entrance.PlaySound("select");
              ++this.cselection;
              if (this.cselection > 3)
                this.cselection = 0;
            }
          }
          if (this.step2)
          {
            if ((double) this.ccolor < 0.5)
              this.ccolor += 0.1f;
            ++this.step2time;
            if (this.step2time > 1 && !this.fadeout)
            {
              if (Main.keyboardstat.IsKeyDown(Keys.Up) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Up, Main.prepadstat))
              {
                Program.game.entrance.PlaySound("select");
                --this.selection3;
                if (this.selection3 < 0)
                  this.selection3 = this.selection3range;
              }
              else if (Main.keyboardstat.IsKeyDown(Keys.Down) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Down, Main.prepadstat))
              {
                Program.game.entrance.PlaySound("select");
                ++this.selection3;
                if (this.selection3 > this.selection3range)
                  this.selection3 = 0;
              }
              if (Main.keyboardstat.IsKeyDown(Keys.Z) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Enter) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Confirm, Main.prepadstat))
              {
                if (this.selection3range != 0)
                {
                  Program.game.entrance.PlaySound("ok");
                  string[] strArray = this.scname[this.selection2].Split('^');
                  for (int index = 0; index < strArray.Length - 1; ++index)
                  {
                    if (this.selection3 == index)
                      this.scselection = strArray[index].Split(' ')[1] + " " + strArray[index].Split(' ')[2];
                  }
                  Main.Character = (Cname) (this.cselection + 1);
                  this.fadeout = true;
                }
              }
              else if (Main.keyboardstat.IsKeyDown(Keys.X) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Escape) & Main.keyboardstat != Main.prekeyboard || (PadState.IsKeyPressed(JOYKEYS.Special, Main.prepadstat) || PadState.IsKeyPressed(JOYKEYS.Pause, Main.prepadstat)))
              {
                Program.game.entrance.PlaySound("cancel");
                this.step2 = false;
                this.step2time = 0;
                this.selection3 = 0;
              }
            }
          }
        }
        else if (this.selection == 1)
        {
          if ((double) this.wordalpha < 1.0)
            this.wordalpha += 0.05f;
          if (this.steptime >= 32)
          {
            if (Main.keyboardstat.IsKeyDown(Keys.Left) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Left, Main.prepadstat))
            {
              Program.game.entrance.PlaySound("select");
              --this.selection3;
              if (this.selection3 < 0)
                this.selection3 = 2;
              this.selection2 = 0;
              this.step2 = false;
            }
            else if (Main.keyboardstat.IsKeyDown(Keys.Right) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Right, Main.prepadstat))
            {
              Program.game.entrance.PlaySound("select");
              ++this.selection3;
              if (this.selection3 > 2)
                this.selection3 = 0;
              this.selection2 = 0;
              this.step2 = false;
            }
            if (Main.keyboardstat.IsKeyDown(Keys.Up) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Up, Main.prepadstat))
            {
              Program.game.entrance.PlaySound("select");
              --this.selection2;
              if (this.selection2 < 0)
                this.selection2 = this.achivs[this.selection3].Length - 1;
              this.step2 = false;
            }
            else if (Main.keyboardstat.IsKeyDown(Keys.Down) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Down, Main.prepadstat))
            {
              Program.game.entrance.PlaySound("select");
              ++this.selection2;
              if (this.selection2 > this.achivs[this.selection3].Length - 1)
                this.selection2 = 0;
              this.step2 = false;
            }
            if (Main.keyboardstat.IsKeyDown(Keys.Z) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Enter) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Confirm, Main.prepadstat))
            {
              Program.game.entrance.PlaySound("ok");
              this.step2 = !this.step2;
            }
            else if (Main.keyboardstat.IsKeyDown(Keys.X) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Escape) & Main.keyboardstat != Main.prekeyboard || (PadState.IsKeyPressed(JOYKEYS.Special, Main.prepadstat) || PadState.IsKeyPressed(JOYKEYS.Pause, Main.prepadstat)))
            {
              Program.game.entrance.PlaySound("cancel");
              this.step = false;
              this.step2 = false;
              this.steptime = 0;
              this.time = 0;
              this.selection2 = 0;
              this.selection3 = 0;
            }
          }
        }
        ++this.steptime;
      }
      else
      {
        if ((double) this.wordalpha > 0.0)
          this.wordalpha -= 0.1f;
        if ((double) this.character[this.cselection].color.a > 0.0)
          this.character[this.cselection].color.a -= 0.1f;
      }
      if (this.fadeout)
      {
        if (this.ftime >= 20)
        {
          for (int index = 0; index < 4; ++index)
          {
            this.character[index].position = new Vector2(200f, 0.0f);
            this.character[index].color.a = 0.0f;
          }
        }
        if (Main.SkiptoSCChanllenges)
          Main.SkiptoSCChanllenges = false;
        if (this.selection == 3)
        {
          for (int index = 0; index < this.button.Length; ++index)
          {
            if (this.ftime >= index * 3 && this.ftime < 10 + index * 3)
            {
              this.button[index].color.a -= 0.1f;
              this.button[index].position.X -= 3f;
              this.buttonon[index].color.a -= 0.1f;
              this.buttonon[index].position.X -= 3f;
            }
          }
          if (this.ftime >= 20)
            this.finished = true;
        }
        else if (this.selection == 2)
        {
          if ((double) this.wordalpha > 0.0)
            this.wordalpha -= 0.1f;
          this.black.color.a += 0.05f;
          if (this.ftime >= 20)
            this.finished = true;
        }
        else if (this.selection == 0)
        {
          this.black.color.a += 0.05f;
          if (this.ftime >= 20)
            this.finished = true;
        }
        ++this.ftime;
      }
      ++this.time;
    }

    private string[][] LoadAchievementList(string filename)
    {
      StreamReader streamReader = new StreamReader(Cry.Decry(filename, 2));
      string[][] strArray = new string[3][];
      int index1 = 0;
      while (!streamReader.EndOfStream)
      {
        int length = int.Parse(streamReader.ReadLine());
        strArray[index1] = new string[length];
        for (int index2 = 0; index2 < length; ++index2)
          strArray[index1][index2] = streamReader.ReadLine();
        ++index1;
      }
      return strArray;
    }

    private string[] LoadSpellCardList(string filename)
    {
      StreamReader streamReader = new StreamReader(Cry.Decry(filename, 2));
      string[] strArray1 = new string[7];
      for (int index = 0; index < 7; ++index)
        strArray1[index] = "";
      int num1 = 0;
      while (!streamReader.EndOfStream)
      {
        int num2 = int.Parse(streamReader.ReadLine());
        for (int index1 = 0; index1 < num2; ++index1)
        {
          string[] strArray2;
          IntPtr index2;
          (strArray2 = strArray1)[(int) (index2 = (IntPtr) num1)] = strArray2[(int)index2] + streamReader.ReadLine() + "^";
        }
        ++num1;
      }
      return strArray1;
    }

    private PlayData LoadPlayData()
    {
      Stream serializationStream = Cry.Decry("Content\\Data\\4.xna", 2);
      PlayData playData = (PlayData) new BinaryFormatter().Deserialize(serializationStream);
      serializationStream.Close();
      return playData;
    }

    private PracticeData LoadPracticeData()
    {
      Stream serializationStream = Cry.Decry("Content\\Data\\5.xna", 2);
      PracticeData practiceData = (PracticeData) new BinaryFormatter().Deserialize(serializationStream);
      serializationStream.Close();
      return practiceData;
    }

    private SpecialData Load(string filename)
    {
      Stream serializationStream = Cry.Decry(filename, 2);
      SpecialData specialData = (SpecialData) new BinaryFormatter().Deserialize(serializationStream);
      serializationStream.Close();
      return specialData;
    }

    public void Draw(SpriteBatch s)
    {
      this.button[0].color.r = !this.cleared ? (this.button[0].color.g = this.button[0].color.b = 0.5f) : (this.button[0].color.g = this.button[0].color.b = 1f);
      for (int index = 0; index < this.button.Length; ++index)
        this.button[index].Draw(s, SpriteEffects.None, 0.0f);
      this.buttonon[this.selection].Draw(s, SpriteEffects.None, 0.0f);
      for (int index = 0; index < 4; ++index)
      {
        this.character[index].color.r = this.character[index].color.g = this.character[index].color.b = 1f - this.ccolor;
        this.character[index].Draw(s, SpriteEffects.None, 0.0f);
      }
      this.black.Draw(s, SpriteEffects.None, 0.0f);
      if (this.step && this.selection == 2)
      {
        if (!this.step2)
        {
          for (int index = 1; index <= 7; ++index)
          {
            string str = index.ToString();
            if (index == 7)
              str = "EX";
            Color color = this.selection2 != index - 1 ? new Color(1f, 1f, 1f, this.wordalpha) : new Color(1f, 0.0f, 0.0f, this.wordalpha);
            Main.dfont.Draw(s, "＋ Stage " + str, new Vector2(41f, (float) (130 + index * 25 + 1)), new Color(0.0f, 0.0f, 0.0f, this.wordalpha));
            Main.dfont.Draw(s, "＋ Stage " + str, new Vector2(40f, (float) (130 + index * 25)), color);
          }
        }
        else
        {
          int num1 = 130;
          for (int index1 = 1; index1 <= 7; ++index1)
          {
            string str1 = index1.ToString();
            if (index1 == 7)
              str1 = "EX";
            num1 += 25;
            if (this.selection2 == index1 - 1)
            {
              Main.dfont.Draw(s, "－ Stage " + str1, new Vector2(41f, (float) (num1 + 1)), new Color(0.0f, 0.0f, 0.0f, this.wordalpha));
              Main.dfont.Draw(s, "－ Stage " + str1, new Vector2(40f, (float) num1), new Color(1f, 1f, 1f, this.wordalpha));
              if (this.selection3range != 0)
              {
                string[] strArray = this.scname[this.selection2].Split('^');
                for (int index2 = 0; index2 < strArray.Length - 1; ++index2)
                {
                  num1 += 25;
                  string str2 = strArray[index2].Split(' ')[0].Replace('&', ' ');
                  int num2 = int.Parse(strArray[index2].Split(' ')[2]) + 1;
                  string str3 = this.sdata.spe[this.cselection].sc[num2 - 1].score.ToString().PadLeft(8, '0');
                  string str4 = this.sdata.spe[this.cselection].sc[num2 - 1].cleartime.ToString().PadLeft(3, '0') + "/" + this.sdata.spe[this.cselection].sc[num2 - 1].playtime.ToString().PadLeft(3, '0');
                  if (this.selection3 == index2)
                  {
                    Main.dfont.Draw(s, num2.ToString().PadLeft(2, '0') + ". " + str2, new Vector2(61f, (float) (num1 + 1)), new Color(0.0f, 0.0f, 0.0f, this.wordalpha));
                    Main.dfont.Draw(s, num2.ToString().PadLeft(2, '0') + ". " + str2, new Vector2(60f, (float) num1), new Color(1f, 0.0f, 0.0f, this.wordalpha));
                    Main.dfont.Draw(s, str3, new Vector2(341f, (float) (num1 + 1)), new Color(0.0f, 0.0f, 0.0f, this.wordalpha));
                    Main.dfont.Draw(s, str3, new Vector2(340f, (float) num1), new Color(1f, 0.0f, 0.0f, this.wordalpha));
                    Main.dfont.Draw(s, str4, new Vector2(515f, (float) (num1 + 1)), new Color(0.0f, 0.0f, 0.0f, this.wordalpha));
                    Main.dfont.Draw(s, str4, new Vector2(514f, (float) num1), new Color(1f, 0.0f, 0.0f, this.wordalpha));
                  }
                  else
                  {
                    Main.dfont.Draw(s, num2.ToString().PadLeft(2, '0') + ". " + str2, new Vector2(61f, (float) (num1 + 1)), new Color(0.0f, 0.0f, 0.0f, this.wordalpha));
                    Main.dfont.Draw(s, num2.ToString().PadLeft(2, '0') + ". " + str2, new Vector2(60f, (float) num1), new Color(1f, 1f, 1f, this.wordalpha));
                    Main.dfont.Draw(s, str3, new Vector2(341f, (float) (num1 + 1)), new Color(0.0f, 0.0f, 0.0f, this.wordalpha));
                    Main.dfont.Draw(s, str3, new Vector2(340f, (float) num1), new Color(1f, 1f, 1f, this.wordalpha));
                    Main.dfont.Draw(s, str4, new Vector2(515f, (float) (num1 + 1)), new Color(0.0f, 0.0f, 0.0f, this.wordalpha));
                    Main.dfont.Draw(s, str4, new Vector2(514f, (float) num1), new Color(1f, 1f, 1f, this.wordalpha));
                  }
                }
              }
              else
              {
                num1 += 25;
                if (this.selection2 == 6)
                {
                  Main.dfont.Draw(s, "你需要解锁此关卡的所有符卡才能解锁挑战符卡。", new Vector2(61f, (float) (num1 + 1)), new Color(0.0f, 0.0f, 0.0f, this.wordalpha));
                  Main.dfont.Draw(s, "你需要解锁此关卡的所有符卡才能解锁挑战符卡。", new Vector2(60f, (float) num1), new Color(1f, 1f, 1f, this.wordalpha));
                }
                else
                {
                  Main.dfont.Draw(s, "你需要通过此关卡才能解锁挑战符卡", new Vector2(61f, (float) (num1 + 1)), new Color(0.0f, 0.0f, 0.0f, this.wordalpha));
                  Main.dfont.Draw(s, "你需要通过此关卡才能解锁挑战符卡。", new Vector2(60f, (float) num1), new Color(1f, 1f, 1f, this.wordalpha));
                }
              }
            }
            else
            {
              Main.dfont.Draw(s, "＋ Stage " + str1, new Vector2(41f, (float) (num1 + 1)), new Color(0.0f, 0.0f, 0.0f, this.wordalpha));
              Main.dfont.Draw(s, "＋ Stage " + str1, new Vector2(40f, (float) num1), new Color(1f, 1f, 1f, this.wordalpha));
            }
          }
        }
      }
      else
      {
        if (!this.step || this.selection != 1)
          return;
        this.crapwise.color.a = this.wordalpha;
        this.achivtype.color.a = this.wordalpha;
        this.achivrate.color.a = this.wordalpha;
        this.achivboxon.color.a = (double) this.wordalpha > 0.5 ? 0.5f : this.wordalpha;
        this.crapwise.position = this.crappos[0];
        this.crapwise.Draw(s, SpriteEffects.FlipHorizontally, 0.0f);
        this.crapwise.position = this.crappos[1];
        this.crapwise.Draw(s, SpriteEffects.None, 0.0f);
        this.achivtype.rect = new Rectangle(93 * this.selection3, 0, 93, 35);
        this.achivtype.Draw(s, SpriteEffects.None, 0.0f);
        this.achivrate.Draw(s, SpriteEffects.None, 0.0f);
        Main.dfont.Draw(s, this.achivrates[this.selection3].ToString() + "%", new Vector2(556f, 131f), new Color(0.0f, 0.0f, 0.0f, this.wordalpha));
        Main.dfont.Draw(s, this.achivrates[this.selection3].ToString() + "%", new Vector2(555f, 130f), new Color(1f, 1f, 1f, this.wordalpha));
        int index1 = this.selection2 - 4 >= 0 ? this.selection2 - 4 : 0;
        if (index1 + 4 >= this.achivs[this.selection3].Length)
          index1 = this.achivs[this.selection3].Length - 1 - 4;
        for (int index2 = 0; index2 < 5; ++index2)
        {
          s.Draw(this.achivbox, new Vector2(26f, (float) (155 + 60 * index2)), new Rectangle?(), new Color(1f, 1f, 1f, this.wordalpha));
          if (this.selection2 == index1)
          {
            this.achivboxon.position = new Vector2(30f, (float) (158 + 60 * index2));
            this.achivboxon.Draw(s, SpriteEffects.None, 0.0f);
          }
          if (this.sdata.ach[this.selection3].achiv[index1].get)
          {
            s.Draw(this.achivlogo, new Vector2(51f, (float) (162 + 60 * index2)), new Rectangle?(new Rectangle(52 + 52 * this.selection3, 0, 52, 52)), new Color(1f, 1f, 1f, this.wordalpha));
            s.Draw(this.achivstatus, new Vector2(514f, (float) (188 + 60 * index2)), new Rectangle?(new Rectangle(94, 0, 94, 30)), new Color(1f, 1f, 1f, this.wordalpha));
          }
          else
          {
            s.Draw(this.achivlogo, new Vector2(51f, (float) (162 + 60 * index2)), new Rectangle?(new Rectangle(0, 0, 52, 52)), new Color(1f, 1f, 1f, this.wordalpha));
            s.Draw(this.achivstatus, new Vector2(514f, (float) (188 + 60 * index2)), new Rectangle?(new Rectangle(0, 0, 94, 30)), new Color(1f, 1f, 1f, this.wordalpha));
          }
          string[] strArray = this.achivs[this.selection3][index1].Split("：".ToCharArray());
          Main.dfont.Draw(s, strArray[0], new Vector2(136f, (float) (166 + 60 * index2 + 1)), new Color(0.0f, 0.0f, 0.0f, this.wordalpha));
          Main.dfont.Draw(s, strArray[0], new Vector2(135f, (float) (166 + 60 * index2)), new Color(1f, 1f, 0.0f, this.wordalpha));
          if (this.selection3 == 2 && !this.sdata.ach[this.selection3].achiv[index1].get)
          {
            Main.dfont.Draw(s, "？？？？？？？？？？？？？", new Vector2(136f, (float) (186 + 60 * index2 + 1)), Vector2.Zero, new Vector2(0.82f, 0.82f), new Color(0.0f, 0.0f, 0.0f, this.wordalpha));
            Main.dfont.Draw(s, "？？？？？？？？？？？？？", new Vector2(135f, (float) (186 + 60 * index2)), Vector2.Zero, new Vector2(0.82f, 0.82f), new Color(1f, 1f, 1f, this.wordalpha));
          }
          else
          {
            bool flag = false;
            for (int index3 = 0; index3 < this.sdata.ach[this.selection3].achiv[index1].level.Length; ++index3)
            {
              if (this.sdata.ach[this.selection3].achiv[index1].level[index3])
              {
                flag = true;
                break;
              }
            }
            if (!this.step2 || !flag || this.selection2 != index1)
            {
              Main.dfont.Draw(s, strArray[1], new Vector2(136f, (float) (186 + 60 * index2 + 1)), Vector2.Zero, new Vector2(0.82f, 0.82f), new Color(0.0f, 0.0f, 0.0f, this.wordalpha));
              Main.dfont.Draw(s, strArray[1], new Vector2(135f, (float) (186 + 60 * index2)), Vector2.Zero, new Vector2(0.82f, 0.82f), new Color(1f, 1f, 1f, this.wordalpha));
            }
            else
            {
              string str = "已取得难度：";
              for (int index3 = 0; index3 < this.sdata.ach[this.selection3].achiv[index1].level.Length; ++index3)
              {
                if (this.sdata.ach[this.selection3].achiv[index1].level[index3])
                  str = str + SPECIAL.level[index3] + " ";
              }
              Main.dfont.Draw(s, str, new Vector2(136f, (float) (186 + 60 * index2 + 1)), Vector2.Zero, new Vector2(0.82f, 0.82f), new Color(0.0f, 0.0f, 0.0f, this.wordalpha));
              Main.dfont.Draw(s, str, new Vector2(135f, (float) (186 + 60 * index2)), Vector2.Zero, new Vector2(0.82f, 0.82f), new Color(0.0f, 1f, 0.0f, this.wordalpha));
            }
          }
          ++index1;
        }
      }
    }
  }
}
