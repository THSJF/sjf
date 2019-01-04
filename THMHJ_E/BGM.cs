// Decompiled with JetBrains decompiler
// Type: THMHJ.BGM
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace THMHJ
{
  internal class BGM
  {
    private static BGM bgm;
    private int time;
    private Sprite tex;
    private bool die;

    public static void Update()
    {
      if (BGM.bgm != null && !BGM.bgm.die)
      {
        BGM.bgm.Updates();
      }
      else
      {
        if (BGM.bgm == null || !BGM.bgm.die)
          return;
        BGM.bgm.Close();
        BGM.bgm = (BGM) null;
      }
    }

    public static void Disposes()
    {
      Music.BGM.Dispose();
      if (BGM.bgm != null)
        BGM.bgm.Close();
      BGM.bgm = (BGM) null;
    }

    public BGM(Texture2D t, int id)
    {
      this.tex = new Sprite(t);
      this.tex.position = new Vector2(91f, 479f);
      this.tex.rect = id < 15 ? new Rectangle(0, (id - 2) * 26, 326, 26) : new Rectangle(0, (id - 3) * 26, 326, 26);
      Music.BGM = Music.SB.GetCue(id.ToString());
      StreamReader streamReader = new StreamReader(Cry.Decry("Content/Music/00.xna", 2));
      streamReader.ReadLine();
      int num = int.Parse(streamReader.ReadLine());
      streamReader.Close();
      if (num < id - 1)
      {
        StreamWriter streamWriter = new StreamWriter("Content/Music/00.xna", false);
        streamWriter.WriteLine("Fantasy Danmaku Festival");
        streamWriter.WriteLine((id - 1).ToString());
        streamWriter.Close();
        Cry.Encry("Content/Music/00.xna", 2);
      }
      Program.game.game.Drawevents += new Game.DrawDelegate(this.Draw);
      BGM.bgm = this;
    }

    public void Close()
    {
      if (Program.game.game == null)
        return;
      Program.game.game.Drawevents -= new Game.DrawDelegate(this.Draw);
    }

    public void Updates()
    {
      ++this.time;
      if (this.time >= 80 && this.time < 100)
        this.tex.color.a += 0.05f;
      if (this.time >= 60 && this.time < 400)
        this.tex.position.Y += (float) ((439.0 - (double) this.tex.position.Y) / 20.0);
      if (this.time >= 400 && this.time < 540)
        this.tex.position.Y += (float) ((479.0 - (double) this.tex.position.Y) / 20.0);
      if (this.time >= 400 && this.time < 410)
        this.tex.color.a -= 0.1f;
      if (this.time < 540)
        return;
      this.die = true;
    }

    public void Draw(SpriteBatch s)
    {
      if (this.time >= 540)
        return;
      this.tex.Draw(s, SpriteEffects.None, 0.0f);
    }

    public void Dispose()
    {
      Music.BGM.Dispose();
    }
  }
}
