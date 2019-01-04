// Decompiled with JetBrains decompiler
// Type: THMHJ.PLAYDATA
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace THMHJ
{
  internal class PLAYDATA
  {
    private PlayData pdata;
    private Texture2D black;
    private Sprite crapwise;
    private Sprite playdata;
    private Sprite playerdata;
    private Sprite leveldata;
    private Vector2[] crapwisepos;
    private Vector2 blackpos;
    private Vector2 blackscale;
    private float blackalpha;
    private float worda;
    private int time;
    private int player;
    private int level;
    private bool showsc;
    private int scpage;
    private bool fadeout;

    public bool Fadeout
    {
      get
      {
        return this.fadeout;
      }
    }

    public PLAYDATA(
      Texture2D blackbox,
      Sprite crapwise,
      Sprite playdata,
      Sprite playerdata,
      Sprite leveldata)
    {
      this.black = blackbox;
      this.crapwise = crapwise;
      this.playdata = playdata;
      this.playerdata = playerdata;
      this.leveldata = leveldata;
      this.blackpos = new Vector2(9f, 170f);
      this.blackscale = new Vector2(6.22f, 2.3f);
      this.blackalpha = 0.0f;
      playdata.position = new Vector2(210f, 408f);
      crapwise.scale = new Vector2(0.8f, 0.8f);
      crapwise.origin = new Vector2(10f, 16f);
      this.crapwisepos = new Vector2[4];
      this.crapwisepos[0] = new Vector2(22f, 146f);
      this.crapwisepos[1] = new Vector2(173f, 146f);
      this.crapwisepos[2] = new Vector2(323f, 123f);
      this.crapwisepos[3] = new Vector2(323f, 159f);
      this.player = this.level = this.scpage = 0;
      playerdata.position = new Vector2(39f, 131f);
      leveldata.position = new Vector2(263f, 128f);
      this.pdata = this.Load("Content/Data/4.xna");
    }

    private PlayData Load(string filename)
    {
      Stream serializationStream = Cry.Decry(filename, 2);
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

    public void Update()
    {
      if (this.time < 22)
      {
        this.blackalpha += 0.03f;
        if ((double) this.blackalpha >= 0.600000023841858)
          this.blackalpha = 0.6f;
        this.playdata.color.a += 0.05f;
        if ((double) this.playdata.color.a >= 1.0)
          this.playdata.color.a = 1f;
        this.crapwise.color.a += 0.05f;
        if ((double) this.crapwise.color.a >= 1.0)
          this.crapwise.color.a = 1f;
        this.leveldata.color.a += 0.05f;
        if ((double) this.leveldata.color.a >= 1.0)
          this.leveldata.color.a = 1f;
        this.playerdata.color.a += 0.05f;
        if ((double) this.playerdata.color.a >= 1.0)
          this.playerdata.color.a = 1f;
      }
      else if (this.time == 22)
      {
        PracticeData practiceData = this.LoadPracticeData();
        Hashtable data1 = new Hashtable();
        data1[(object) "ok"] = (object) false;
        for (int index = 0; index < 4; ++index)
        {
          if (this.pdata.players[index].cleartime > 0)
          {
            data1[(object) "ok"] = (object) true;
            break;
          }
        }
        Program.game.achivmanager.Check(AchievementType.Normal, 2, data1);
        Program.game.achivmanager.Check(AchievementType.Normal, 3, new Hashtable()
        {
          [(object) "practice"] = (object) practiceData
        });
        Program.game.achivmanager.Check(AchievementType.Normal, 5, new Hashtable()
        {
          [(object) "practice"] = (object) practiceData
        });
        Hashtable data2 = new Hashtable();
        data2[(object) "playdata"] = (object) this.pdata;
        Program.game.achivmanager.Check(AchievementType.Challenge, 14, data2);
        Program.game.achivmanager.Check(AchievementType.Hidden, 0, data2);
        Program.game.achivmanager.Check(AchievementType.Hidden, 5, new Hashtable()
        {
          [(object) "playerdata"] = (object) this.pdata.players
        });
      }
      if (this.time >= 22 && this.time < 32)
      {
        this.worda += 0.1f;
        if ((double) this.worda >= 1.0)
          this.worda = 1f;
      }
      if (!this.fadeout && this.time >= 32)
      {
        if (((!this.fadeout ? 1 : 0) & (Main.keyboardstat.IsKeyDown(Keys.Left) & Main.keyboardstat != Main.prekeyboard ? 1 : (PadState.IsKeyPressed(JOYKEYS.Left, Main.prepadstat) ? 1 : 0))) != 0)
        {
          Program.game.entrance.PlaySound("select");
          --this.player;
          if (this.player < 0)
            this.player = 3;
        }
        else if (((!this.fadeout ? 1 : 0) & (Main.keyboardstat.IsKeyDown(Keys.Right) & Main.keyboardstat != Main.prekeyboard ? 1 : (PadState.IsKeyPressed(JOYKEYS.Right, Main.prepadstat) ? 1 : 0))) != 0)
        {
          Program.game.entrance.PlaySound("select");
          ++this.player;
          if (this.player > 3)
            this.player = 0;
        }
        else if (((!this.fadeout ? 1 : 0) & (Main.keyboardstat.IsKeyDown(Keys.Up) & Main.keyboardstat != Main.prekeyboard ? 1 : (PadState.IsKeyPressed(JOYKEYS.Up, Main.prepadstat) ? 1 : 0))) != 0)
        {
          Program.game.entrance.PlaySound("select");
          --this.level;
          if (this.level < 0)
            this.level = 4;
        }
        else if (((!this.fadeout ? 1 : 0) & (Main.keyboardstat.IsKeyDown(Keys.Down) & Main.keyboardstat != Main.prekeyboard ? 1 : (PadState.IsKeyPressed(JOYKEYS.Down, Main.prepadstat) ? 1 : 0))) != 0)
        {
          Program.game.entrance.PlaySound("select");
          ++this.level;
          if (this.level > 4)
            this.level = 0;
        }
        if (Main.keyboardstat.IsKeyDown(Keys.Z) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Enter) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Confirm, Main.prepadstat))
        {
          Program.game.entrance.PlaySound("select");
          if (!this.showsc)
            this.showsc = true;
          else if (this.scpage < this.pdata.players[this.player].sc[this.level].Count / 10)
          {
            ++this.scpage;
          }
          else
          {
            this.scpage = 0;
            this.showsc = false;
          }
        }
        else if (Main.keyboardstat.IsKeyDown(Keys.X) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Escape) & Main.keyboardstat != Main.prekeyboard || (PadState.IsKeyPressed(JOYKEYS.Special, Main.prepadstat) || PadState.IsKeyPressed(JOYKEYS.Pause, Main.prepadstat)))
        {
          Program.game.entrance.PlaySound("cancel");
          this.fadeout = true;
        }
      }
      if (this.fadeout)
      {
        this.worda -= 0.1f;
        if ((double) this.worda <= 0.0)
          this.worda = 0.0f;
        this.blackalpha -= 0.03f;
        if ((double) this.blackalpha <= 0.0)
          this.blackalpha = 0.0f;
        this.playdata.color.a -= 0.05f;
        if ((double) this.playdata.color.a <= 0.0)
          this.playdata.color.a = 0.0f;
        this.crapwise.color.a -= 0.05f;
        if ((double) this.crapwise.color.a <= 0.0)
          this.crapwise.color.a = 0.0f;
        this.leveldata.color.a -= 0.05f;
        if ((double) this.leveldata.color.a <= 0.0)
          this.leveldata.color.a = 0.0f;
        this.playerdata.color.a -= 0.05f;
        if ((double) this.playerdata.color.a <= 0.0)
          this.playerdata.color.a = 0.0f;
      }
      ++this.time;
    }

    public void Draw(SpriteBatch s)
    {
      s.Draw(this.black, this.blackpos, new Rectangle?(), new Color(1f, 1f, 1f, this.blackalpha), 0.0f, Vector2.Zero, this.blackscale, SpriteEffects.None, 0.0f);
      this.playdata.Draw(s, SpriteEffects.None, 0.0f);
      this.crapwise.rotation = 0.0f;
      this.crapwise.position = this.crapwisepos[0];
      this.crapwise.Draw(s, SpriteEffects.FlipHorizontally, 0.0f);
      this.crapwise.position = this.crapwisepos[1];
      this.crapwise.Draw(s, SpriteEffects.None, 0.0f);
      this.crapwise.rotation = -90f;
      this.crapwise.position = this.crapwisepos[2];
      this.crapwise.Draw(s, SpriteEffects.None, 0.0f);
      this.crapwise.rotation = 90f;
      this.crapwise.position = this.crapwisepos[3];
      this.crapwise.Draw(s, SpriteEffects.FlipVertically, 0.0f);
      this.playerdata.rect = new Rectangle(0, 27 * this.player, 117, 27);
      this.playerdata.Draw(s, SpriteEffects.None, 0.0f);
      this.leveldata.rect = new Rectangle(0, 27 * this.level, 117, 27);
      this.leveldata.Draw(s, SpriteEffects.None, 0.0f);
      Vector3 vector3 = new Vector3(1f, 1f, 1f);
      if (!this.showsc)
      {
        for (int index = 0; index < 10; ++index)
        {
          if (this.pdata.players[this.player].ranks[this.level].data[index] == null)
          {
            Main.dfont.Draw(s, "--------------------------------------------------------------------------------", new Vector2(40f, (float) (179 + index * 21)), new Color(0.0f, 0.0f, 0.0f, this.worda));
            Main.dfont.Draw(s, "--------------------------------------------------------------------------------", new Vector2(39f, (float) (178 + index * 21)), new Color(vector3.X, vector3.Y - (float) index * 0.055f, vector3.Z - (float) index * 0.055f, this.worda));
          }
          else
          {
            Main.dfont.Draw(s, this.pdata.players[this.player].ranks[this.level].data[index].name, new Vector2(40f, (float) (179 + index * 21)), new Color(0.0f, 0.0f, 0.0f, this.worda));
            Main.dfont.Draw(s, this.pdata.players[this.player].ranks[this.level].data[index].name, new Vector2(39f, (float) (178 + index * 21)), new Color(vector3.X, vector3.Y - (float) index * 0.055f, vector3.Z - (float) index * 0.055f, this.worda));
            Main.dfont.Draw(s, this.pdata.players[this.player].ranks[this.level].data[index].score.ToString().PadLeft(10, '0'), new Vector2(151f, (float) (179 + index * 21)), new Color(0.0f, 0.0f, 0.0f, this.worda));
            Main.dfont.Draw(s, this.pdata.players[this.player].ranks[this.level].data[index].score.ToString().PadLeft(10, '0'), new Vector2(150f, (float) (178 + index * 21)), new Color(vector3.X, vector3.Y - (float) index * 0.055f, vector3.Z - (float) index * 0.055f, this.worda));
            string str1 = this.pdata.players[this.player].ranks[this.level].data[index].time.Year.ToString().PadLeft(4, '0') + "/" + this.pdata.players[this.player].ranks[this.level].data[index].time.Month.ToString().PadLeft(2, '0') + "/" + this.pdata.players[this.player].ranks[this.level].data[index].time.Day.ToString().PadLeft(2, '0') + " " + this.pdata.players[this.player].ranks[this.level].data[index].time.ToLongTimeString();
            Main.dfont.Draw(s, str1, new Vector2(301f, (float) (179 + index * 21)), new Color(0.0f, 0.0f, 0.0f, this.worda));
            Main.dfont.Draw(s, str1, new Vector2(300f, (float) (178 + index * 21)), new Color(vector3.X, vector3.Y - (float) index * 0.055f, vector3.Z - (float) index * 0.055f, this.worda));
            string str2 = this.pdata.players[this.player].ranks[this.level].data[index].stage.ToString();
            if (str2 == "7")
              str2 = "EX";
            Main.dfont.Draw(s, "Stage" + str2, new Vector2(534f, (float) (179 + index * 21)), new Color(0.0f, 0.0f, 0.0f, this.worda));
            Main.dfont.Draw(s, "Stage" + str2, new Vector2(533f, (float) (178 + index * 21)), new Color(vector3.X, vector3.Y - (float) index * 0.055f, vector3.Z - (float) index * 0.055f, this.worda));
          }
        }
      }
      else
      {
        for (int index = 0; index < 10; ++index)
        {
          if (this.pdata.players[this.player].sc[this.level].Count > this.scpage * 10 + index)
          {
            string name = this.pdata.players[this.player].sc[this.level][this.scpage * 10 + index].name;
            string str1 = this.pdata.players[this.player].sc[this.level][this.scpage * 10 + index].playtime.ToString().PadLeft(3, '0');
            string str2 = this.pdata.players[this.player].sc[this.level][this.scpage * 10 + index].cleartime.ToString().PadLeft(3, '0');
            Main.dfont.Draw(s, name, new Vector2(40f, (float) (179 + index * 21)), new Color(0.0f, 0.0f, 0.0f, this.worda));
            Main.dfont.Draw(s, name, new Vector2(39f, (float) (178 + index * 21)), new Color(vector3.X, vector3.Y, vector3.Z, this.worda));
            Main.dfont.Draw(s, str2 + "/" + str1, new Vector2(538f, (float) (179 + index * 21)), new Color(0.0f, 0.0f, 0.0f, this.worda));
            Main.dfont.Draw(s, str2 + "/" + str1, new Vector2(537f, (float) (178 + index * 21)), new Color(vector3.X, vector3.Y, vector3.Z, this.worda));
          }
        }
      }
      Main.dfont.Draw(s, this.pdata.players[this.player].playtime.ToString(), new Vector2(369f, 411f), new Color(0.0f, 0.0f, 0.0f, this.worda));
      Main.dfont.Draw(s, this.pdata.players[this.player].playtime.ToString(), new Vector2(368f, 410f), new Color(vector3.X, vector3.Y, vector3.Z, this.worda));
      Main.dfont.Draw(s, this.pdata.players[this.player].cleartime.ToString(), new Vector2(369f, 430f), new Color(0.0f, 0.0f, 0.0f, this.worda));
      Main.dfont.Draw(s, this.pdata.players[this.player].cleartime.ToString(), new Vector2(368f, 429f), new Color(vector3.X, vector3.Y, vector3.Z, this.worda));
      string str3 = "";
      int num1 = this.pdata.players[this.player].totaltime / 3600;
      string str4 = str3 + num1.ToString().PadLeft(2, '0') + ":";
      int num2 = (this.pdata.players[this.player].totaltime - num1 * 3600) / 60;
      string str5 = str4 + num2.ToString().PadLeft(2, '0') + ":" + (this.pdata.players[this.player].totaltime - num1 * 3600 - num2 * 60).ToString().PadLeft(2, '0');
      Main.dfont.Draw(s, str5, new Vector2(369f, 449f), new Color(0.0f, 0.0f, 0.0f, this.worda));
      Main.dfont.Draw(s, str5, new Vector2(368f, 448f), new Color(vector3.X, vector3.Y, vector3.Z, this.worda));
    }
  }
}
