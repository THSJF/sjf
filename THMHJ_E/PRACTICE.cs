// Decompiled with JetBrains decompiler
// Type: THMHJ.PRACTICE
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace THMHJ
{
  internal class PRACTICE
  {
    private PracticeData practicedata;
    private Sprite displaybox;
    private Sprite[] level;
    private Sprite crapwise;
    private Sprite[] character;
    private Sprite cinfo;
    private Texture2D black;
    private Vector2 blackpos;
    private float blacka;
    private float worda;
    private Vector2[] crapwisexy;
    private int time;
    private int time2;
    private int time3;
    private int selection;
    private int selection2;
    private int selection3;
    private int stage;
    private bool steps;
    private bool steps2;
    private bool fadeout;
    private bool ok;

    public int Selection
    {
      get
      {
        return this.selection;
      }
    }

    public int Selection2
    {
      get
      {
        return this.selection2;
      }
    }

    public int Selection3
    {
      get
      {
        return this.selection3;
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

    public PRACTICE(
      PracticeData data,
      Texture2D blackbox,
      Sprite displaybox_s,
      Sprite[] level_s,
      Sprite crapwise_s,
      Sprite[] character_s,
      Sprite cinfo_s,
      Vector2[] crapwisexy_i,
      int selection_i,
      int selection2_i)
    {
      this.practicedata = data;
      this.displaybox = displaybox_s;
      this.level = level_s;
      this.crapwise = crapwise_s;
      this.crapwisexy = crapwisexy_i;
      this.character = character_s;
      this.cinfo = cinfo_s;
      this.selection = selection_i;
      if (this.selection >= 5)
        this.selection = 1;
      this.selection2 = selection2_i;
      this.selection3 = 1;
      this.black = blackbox;
      this.blackpos = new Vector2(249f, 165f);
      this.time = 0;
      this.time2 = 0;
    }

    public unsafe void Update()
    {
      if (this.time >= 0 && this.time <= 22)
      {
        this.displaybox.position.X = (float) (((double) this.displaybox.position.X * 9.0 + 88.0) / 10.0);
        this.displaybox.color.a += 0.05f;
        if ((double) this.displaybox.color.a >= 1.0)
          this.displaybox.color.a = 1f;
        this.level[this.selection - 1].color.a += 0.05f;
        if ((double) this.level[this.selection - 1].color.a >= 1.0)
          this.level[this.selection - 1].color.a = 1f;
        for (int index = 0; index < 5; ++index)
        {
          if (this.time == 1)
          {
            fixed (float* v = &this.level[index].position.X)
            {
              ValueEvent valueEvent = new ValueEvent(v, (float) (80 - (this.selection - 1 - index) * 100), 10, ChangeType.NONLINEAR);
            }
          }
          if (index != this.selection - 1)
          {
            this.level[index].color.a -= 0.05f;
            if ((double) this.level[index].color.a <= 0.0)
              this.level[index].color.a = 0.0f;
          }
        }
        if (this.time == 1)
        {
          fixed (float* v = &this.crapwise.color.a)
          {
            ValueEvent valueEvent = new ValueEvent(v, 0.0f, 10, ChangeType.NONLINEAR);
          }
        }
        if (this.time == 11)
        {
          this.crapwisexy[0] = new Vector2(366f, 242f);
          this.crapwisexy[1] = new Vector2(52f, 242f);
          fixed (float* v = &this.crapwise.color.a)
          {
            ValueEvent valueEvent = new ValueEvent(v, 1f, 10, ChangeType.NONLINEAR);
          }
        }
        if (!this.steps)
        {
          for (int index = 0; index < 4; ++index)
          {
            this.character[index].color.a -= 0.05f;
            if ((double) this.character[index].color.a <= 0.0)
              this.character[index].color.a = 0.0f;
          }
        }
      }
      if (!this.fadeout & !this.steps)
      {
        if (((!this.fadeout ? 1 : 0) & (Main.keyboardstat.IsKeyDown(Keys.Left) & Main.keyboardstat != Main.prekeyboard ? 1 : (PadState.IsKeyPressed(JOYKEYS.Left, Main.prepadstat) ? 1 : 0))) != 0)
        {
          Program.game.entrance.PlaySound("select");
          --this.selection;
          if (this.selection == 0)
            this.selection = 4;
          for (int index = 0; index < 5; ++index)
          {
            fixed (float* v = &this.level[index].position.X)
            {
              ValueEvent valueEvent = new ValueEvent(v, (float) (80 - (this.selection - 1 - index) * 100), 10, ChangeType.NONLINEAR);
            }
          }
          this.time = 0;
        }
        else if (((!this.fadeout ? 1 : 0) & (Main.keyboardstat.IsKeyDown(Keys.Right) & Main.keyboardstat != Main.prekeyboard ? 1 : (PadState.IsKeyPressed(JOYKEYS.Right, Main.prepadstat) ? 1 : 0))) != 0)
        {
          Program.game.entrance.PlaySound("select");
          ++this.selection;
          if (this.selection == 5)
            this.selection = 1;
          for (int index = 0; index < 5; ++index)
          {
            if (index != this.selection - 1)
            {
              this.level[index].color.a -= 0.05f;
              if ((double) this.level[index].color.a <= 0.0)
                this.level[this.selection - 1].color.a = 0.0f;
            }
          }
          for (int index = 0; index < 5; ++index)
          {
            fixed (float* v = &this.level[index].position.X)
            {
              ValueEvent valueEvent = new ValueEvent(v, (float) (80 - (this.selection - 1 - index) * 100), 10, ChangeType.NONLINEAR);
            }
          }
          this.time = 0;
        }
        if (this.time >= 22)
        {
          if (Main.keyboardstat.IsKeyDown(Keys.Enter) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Z) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Confirm, Main.prepadstat))
          {
            Program.game.entrance.PlaySound("ok");
            Main.Level = (Difficulty) this.selection;
            this.time2 = 0;
            this.steps = true;
          }
          else if (Main.keyboardstat.IsKeyDown(Keys.X) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Escape) & Main.keyboardstat != Main.prekeyboard || (PadState.IsKeyPressed(JOYKEYS.Special, Main.prepadstat) || PadState.IsKeyPressed(JOYKEYS.Pause, Main.prepadstat)))
          {
            for (int index = 0; index < 5; ++index)
            {
              fixed (float* v = &this.level[index].position.X)
              {
                ValueEvent valueEvent = new ValueEvent(v, (float) (30 - (this.selection - 1 - index) * 100), 10, ChangeType.NONLINEAR);
              }
            }
            Program.game.entrance.PlaySound("cancel");
            this.fadeout = true;
          }
        }
      }
      if (!this.steps)
      {
        if (this.time <= 72)
        {
          this.displaybox.color.a -= 0.01f;
          if ((double) this.displaybox.color.a <= 0.0)
            this.displaybox.color.a = 0.0f;
        }
        if (this.time >= 72 & this.time <= 122)
        {
          this.displaybox.color.a += 0.01f;
          if ((double) this.displaybox.color.a >= 1.0)
            this.displaybox.color.a = 1f;
        }
        if (this.time >= 122)
          this.time = 42;
      }
      else
      {
        if (this.time2 > 0 & this.time2 <= 22)
        {
          this.displaybox.position.X = (float) (((double) this.displaybox.position.X * 4.0 + 88.0 - 50.0) / 5.0);
          this.displaybox.color.a -= 0.05f;
          if ((double) this.displaybox.color.a <= 0.0)
            this.displaybox.color.a = 0.0f;
          this.level[this.selection - 1].color.a -= 0.05f;
          if ((double) this.level[this.selection - 1].color.a <= 0.0)
            this.level[this.selection - 1].color.a = 0.0f;
          for (int index = 0; index < 5; ++index)
          {
            if (this.time2 == 1)
            {
              fixed (float* v = &this.level[index].position.X)
              {
                ValueEvent valueEvent = new ValueEvent(v, (float) (30 - (this.selection - 1 - index) * 100), 10, ChangeType.NONLINEAR);
              }
            }
          }
          if (this.time2 == 1)
          {
            fixed (float* v = &this.crapwise.color.a)
            {
              ValueEvent valueEvent = new ValueEvent(v, 0.0f, 10, ChangeType.NONLINEAR);
            }
            fixed (float* v = &this.cinfo.color.a)
            {
              ValueEvent valueEvent = new ValueEvent(v, 1f, 10, ChangeType.NONLINEAR);
            }
            fixed (float* v = &this.cinfo.position.X)
            {
              ValueEvent valueEvent = new ValueEvent(v, 20f, 10, ChangeType.NONLINEAR);
            }
          }
          if (this.time2 == 11)
          {
            this.crapwisexy[0] = new Vector2(600f, 242f);
            this.crapwisexy[1] = new Vector2(22f, 242f);
            fixed (float* v = &this.crapwise.color.a)
            {
              ValueEvent valueEvent = new ValueEvent(v, 1f, 10, ChangeType.NONLINEAR);
            }
          }
        }
        if (this.time2 >= 23)
          this.time2 = 23;
        if (this.time2 >= 0 && !this.ok)
        {
          for (int index = 0; index < 4; ++index)
          {
            if (this.time2 == 0)
              this.character[index].position.X = 200f;
            if (index == this.selection2 - 1)
            {
              this.character[index].color.a += 0.05f;
              if ((double) this.character[index].color.a >= 1.0)
                this.character[index].color.a = 1f;
              this.character[index].position.X += (float) ((0.0 - (double) this.character[index].position.X) / 10.0);
            }
            else
            {
              this.character[index].color.a -= 0.05f;
              if ((double) this.character[index].color.a <= 0.0)
                this.character[index].color.a = 0.0f;
              this.character[index].position.X += (float) ((200.0 - (double) this.character[index].position.X) / 10.0);
            }
          }
        }
        if (this.time2 >= 22 && !this.steps2)
        {
          if (((!this.fadeout ? 1 : 0) & (Main.keyboardstat.IsKeyDown(Keys.Left) & Main.keyboardstat != Main.prekeyboard ? 1 : (PadState.IsKeyPressed(JOYKEYS.Left, Main.prepadstat) ? 1 : 0))) != 0)
          {
            Program.game.entrance.PlaySound("select");
            --this.selection2;
            if (this.selection2 == 0)
              this.selection2 = 4;
          }
          else if (((!this.fadeout ? 1 : 0) & (Main.keyboardstat.IsKeyDown(Keys.Right) & Main.keyboardstat != Main.prekeyboard ? 1 : (PadState.IsKeyPressed(JOYKEYS.Right, Main.prepadstat) ? 1 : 0))) != 0)
          {
            Program.game.entrance.PlaySound("select");
            ++this.selection2;
            if (this.selection2 == 5)
              this.selection2 = 1;
          }
          else if (Main.keyboardstat.IsKeyDown(Keys.X) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Escape) & Main.keyboardstat != Main.prekeyboard || (PadState.IsKeyPressed(JOYKEYS.Special, Main.prepadstat) || PadState.IsKeyPressed(JOYKEYS.Pause, Main.prepadstat)))
          {
            for (int index = 0; index < 5; ++index)
            {
              fixed (float* v = &this.level[index].position.X)
              {
                ValueEvent valueEvent = new ValueEvent(v, (float) (80 - (this.selection - 1 - index) * 100), 10, ChangeType.NONLINEAR);
              }
            }
            fixed (float* v = &this.cinfo.color.a)
            {
              ValueEvent valueEvent = new ValueEvent(v, 0.0f, 10, ChangeType.NONLINEAR);
            }
            fixed (float* v = &this.cinfo.position.X)
            {
              ValueEvent valueEvent = new ValueEvent(v, 100f, 10, ChangeType.NONLINEAR);
            }
            Program.game.entrance.PlaySound("cancel");
            this.steps = false;
            this.time = 0;
            this.time2 = 0;
            Main.keyboardstat = Main.prekeyboard;
          }
          if (Main.keyboardstat.IsKeyDown(Keys.Enter) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Z) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Confirm, Main.prepadstat))
          {
            Program.game.entrance.PlaySound("ok");
            Main.Character = (Cname) this.selection2;
            this.steps2 = true;
            this.selection3 = 1;
            this.time3 = 0;
            this.blackpos.X = 249f;
          }
        }
        if (this.steps2)
        {
          if (this.time3 <= 20)
          {
            if (this.time3 == 0)
            {
              this.stage = this.practicedata.clearstate[this.selection2 - 1][this.selection - 1];
              if (this.stage == 7)
                this.selection3 = 7;
            }
            fixed (float* v = &this.blackpos.X)
            {
              ValueEvent valueEvent = new ValueEvent(v, 199f, 10, ChangeType.NONLINEAR);
            }
            this.blacka += 0.035f;
            if ((double) this.blacka >= 0.699999988079071)
              this.blacka = 0.7f;
            this.worda += 0.05f;
          }
          else if (!this.ok)
          {
            if (Main.keyboardstat.IsKeyDown(Keys.X) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Escape) & Main.keyboardstat != Main.prekeyboard || (PadState.IsKeyPressed(JOYKEYS.Special, Main.prepadstat) || PadState.IsKeyPressed(JOYKEYS.Pause, Main.prepadstat)))
            {
              this.time3 = 0;
              this.steps2 = false;
              fixed (float* v = &this.blacka)
              {
                ValueEvent valueEvent = new ValueEvent(v, 0.0f, 10, ChangeType.LINEAR);
              }
              fixed (float* v = &this.worda)
              {
                ValueEvent valueEvent = new ValueEvent(v, 0.0f, 10, ChangeType.LINEAR);
              }
              Program.game.entrance.PlaySound("cancel");
            }
            if ((Main.keyboardstat.IsKeyDown(Keys.Up) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Up, Main.prepadstat)) && this.stage != 7)
            {
              --this.selection3;
              if (this.selection3 < 1)
                this.selection3 = this.stage;
              Program.game.entrance.PlaySound("select");
            }
            if ((Main.keyboardstat.IsKeyDown(Keys.Down) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Down, Main.prepadstat)) && this.stage != 7)
            {
              ++this.selection3;
              if (this.selection3 > this.stage)
                this.selection3 = 1;
              Program.game.entrance.PlaySound("select");
            }
            if ((Main.keyboardstat.IsKeyDown(Keys.Enter) & Main.keyboardstat != Main.prekeyboard || Main.keyboardstat.IsKeyDown(Keys.Z) & Main.keyboardstat != Main.prekeyboard || PadState.IsKeyPressed(JOYKEYS.Confirm, Main.prepadstat)) && this.stage != 0)
            {
              Program.game.entrance.PlaySound("ok");
              this.ok = true;
              fixed (float* v = &this.blacka)
              {
                ValueEvent valueEvent = new ValueEvent(v, 0.0f, 10, ChangeType.LINEAR);
              }
              fixed (float* v = &this.worda)
              {
                ValueEvent valueEvent = new ValueEvent(v, 0.0f, 10, ChangeType.LINEAR);
              }
            }
          }
          ++this.time3;
        }
      }
      ++this.time;
      if (!this.steps)
        return;
      ++this.time2;
    }

    public void Draw(SpriteBatch s)
    {
      this.displaybox.Draw(s, SpriteEffects.None, 0.0f);
      for (int index = 0; index < 5; ++index)
        this.level[index].Draw(s, SpriteEffects.None, 0.0f);
      for (int index = 0; index < 4; ++index)
        this.character[index].Draw(s, SpriteEffects.None, 0.0f);
      this.cinfo.rect = new Rectangle((this.selection2 - 1) * 314, 0, 314, 483);
      this.cinfo.Draw(s, SpriteEffects.None, 0.0f);
      this.crapwise.position = this.crapwisexy[0];
      this.crapwise.Draw(s, SpriteEffects.None, 0.0f);
      this.crapwise.position = this.crapwisexy[1];
      this.crapwise.Draw(s, SpriteEffects.FlipHorizontally, 0.0f);
      s.Draw(this.black, this.blackpos, new Rectangle?(), new Color(1f, 1f, 1f, this.blacka), 0.0f, Vector2.Zero, new Vector2(2.42f, 1.51f), SpriteEffects.None, 0.0f);
      int num = 1;
      if (this.stage == 7)
      {
        num = 7;
        for (int index = 1; index <= 6; ++index)
        {
          Main.dfont.Draw(s, "-----------------------------", new Vector2(220f, (float) (180 + (index - 1) * 17 + 1)), new Color(0.0f, 0.0f, 0.0f, this.worda));
          Main.dfont.Draw(s, "-----------------------------", new Vector2(219f, (float) (180 + (index - 1) * 17)), new Color(1f, 1f, 1f, this.worda));
        }
      }
      for (int index = num; index <= this.stage; ++index)
      {
        Color color = new Color(1f, 1f, 1f, this.worda);
        if (index == this.selection3)
          color = new Color(1f, 0.0f, 0.0f, this.worda);
        string str1 = index.ToString() + " ";
        if (index == 7)
          str1 = "Ex";
        string str2 = this.practicedata.data[(int) (Main.Character - 1)][(int) (Main.Level - 1)].score[index - 1].ToString().PadLeft(10, '0');
        Main.dfont.Draw(s, "Stage " + str1 + "  " + str2, new Vector2(220f, (float) (180 + (index - 1) * 17 + 1)), new Color(0.0f, 0.0f, 0.0f, this.worda));
        Main.dfont.Draw(s, "Stage " + str1 + "  " + str2, new Vector2(219f, (float) (180 + (index - 1) * 17)), color);
      }
      if (this.stage >= 7)
        return;
      for (int index = this.stage + 1; index <= 7; ++index)
      {
        Main.dfont.Draw(s, "-----------------------------", new Vector2(220f, (float) (180 + (index - 1) * 17 + 1)), new Color(0.0f, 0.0f, 0.0f, this.worda));
        Main.dfont.Draw(s, "-----------------------------", new Vector2(219f, (float) (180 + (index - 1) * 17)), new Color(1f, 1f, 1f, this.worda));
      }
    }
  }
}
