// Decompiled with JetBrains decompiler
// Type: THMHJ.EquipShoot
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace THMHJ
{
  public class EquipShoot
  {
    private static float btime;
    private static float ctime;

    public static void Init()
    {
      EquipShoot.btime = 0.0f;
      EquipShoot.ctime = 0.0f;
    }

    protected static void BEquipShoot(Texture2D s, Cname t, int id, Vector2 p)
    {
      EquipShoot.btime += Time.Stop;
      if (id != 0)
        return;
      EquipShoot.NORMAL(s, t, p);
    }

    protected static void CEquipShoot(Texture2D s, Cname t, int id, Vector2 p, List<Sprite> sprt)
    {
      EquipShoot.ctime += Time.Stop;
      switch (t)
      {
        case Cname.REIMU:
          if (id != 0)
            break;
          EquipShoot.H_AMULET(s, p, sprt);
          break;
        case Cname.MARISA:
          if (id != 0)
            break;
          EquipShoot.D_TORPEDO(s, p, sprt);
          break;
        case Cname.SANAE:
          if (id != 0)
            break;
          EquipShoot.S_BOMB(s, p, sprt);
          break;
      }
    }

    private static void NORMAL(Texture2D s, Cname t, Vector2 p)
    {
      if ((double) EquipShoot.btime < 3.0)
        return;
      Program.game.game.PlaySound("plst", true, p.X);
      Rectangle r = new Rectangle();
      Vector2 o = new Vector2();
      float alpha_f = 0.0f;
      Vector2 scale_v = new Vector2();
      switch (t)
      {
        case Cname.REIMU:
          r = new Rectangle(8, 0, 28, 59);
          o = new Vector2(14f, 26f);
          scale_v = new Vector2(0.9f, 0.9f);
          alpha_f = 0.7f;
          break;
        case Cname.MARISA:
          r = new Rectangle(43, 7, 23, 38);
          o = new Vector2(11f, 15f);
          scale_v = new Vector2(0.9f, 0.9f);
          alpha_f = 0.7f;
          break;
        case Cname.SANAE:
          r = new Rectangle(78, 6, 22, 40);
          o = new Vector2(11f, 19f);
          scale_v = new Vector2(0.9f, 0.9f);
          alpha_f = 0.8f;
          break;
        case Cname.PATCHOULI:
          r = new Rectangle(108, 9, 25, 44);
          o = new Vector2(12f, 17f);
          scale_v = new Vector2(0.9f, 0.9f);
          alpha_f = 0.8f;
          break;
      }
      SelfBarrage selfBarrage1 = new SelfBarrage(s, r, o, new Vector2(p.X - 10f, p.Y + 10f), alpha_f, scale_v)
      {
        speed = 20f,
        speedd = -90f,
        power = 20
      };
      SelfBarrage selfBarrage2 = new SelfBarrage(s, r, o, new Vector2(p.X + 10f, p.Y + 10f), alpha_f, scale_v)
      {
        speed = 20f,
        speedd = -90f,
        power = 20
      };
      EquipShoot.btime = 0.0f;
    }

    private static void H_AMULET(Texture2D s, Vector2 p, List<Sprite> sprt)
    {
      if ((double) EquipShoot.ctime < 7.0)
        return;
      for (int index = 0; index < sprt.Count; ++index)
      {
        SelfBarrage selfBarrage = new SelfBarrage(s, new Rectangle(22, 111, 13, 42), new Vector2(6f, 20f), sprt[index].position + p, 1f, new Vector2(1f, 1f));
        selfBarrage.chase = true;
        selfBarrage.further = true;
        if (Main.IsKeyDown(Keys.LeftShift) || Main.IsKeyDown(Keys.RightShift) || !Main.Replay && PadState.IsKeyDown(JOYKEYS.Slow))
          selfBarrage.further = false;
        selfBarrage.speed = 9f;
        selfBarrage.speedd = 270f;
        selfBarrage.power = 12;
      }
      EquipShoot.ctime = 0.0f;
    }

    private static void D_TORPEDO(Texture2D s, Vector2 p, List<Sprite> sprt)
    {
      for (int index = 0; index < sprt.Count; ++index)
      {
        SelfBarrage selfBarrage = new SelfBarrage(s, new Rectangle(60, 110, 12, 40), new Vector2(6f, -10f), sprt[index].position + p, 1f, new Vector2(1f, 1f))
        {
          color = {
            a = 1f
          },
          straight = true,
          dx = sprt[index].position.X - 93f,
          dy = sprt[index].position.Y,
          speed = 39.5f
        };
        selfBarrage.speedd = (double) selfBarrage.dx <= -77.0 ? ((double) selfBarrage.dx >= -109.0 ? -90f : -92f) : -88f;
        selfBarrage.power = (int) EquipShoot.btime % 2 != 0 ? (int) (1.0 * (double) Time.Stop) : (int) (2.0 * (double) Time.Stop);
      }
      if ((double) EquipShoot.ctime < 10.0)
        return;
      bool flag = false;
      for (int index = 0; index < sprt.Count; ++index)
      {
        SelfBarrage selfBarrage = new SelfBarrage(s, new Rectangle(51, 159, 30, 17), new Vector2(15f, 0.0f), sprt[index].position + p, 1f, new Vector2(1f, 1f))
        {
          label = 2,
          ignore = true,
          straight = true,
          dx = sprt[index].position.X - 93f,
          dy = sprt[index].position.Y,
          speed = 10f
        };
        selfBarrage.speedd = (double) selfBarrage.dx <= -77.0 ? ((double) selfBarrage.dx >= -109.0 ? -90f : -92f) : -88f;
        selfBarrage.scale = new Vector2(0.8f, 0.8f);
        flag = true;
      }
      if (flag)
        Program.game.game.PlaySound("lazer02", true, p.X);
      EquipShoot.ctime = 0.0f;
    }

    private static void S_BOMB(Texture2D s, Vector2 p, List<Sprite> sprt)
    {
      if ((double) EquipShoot.ctime < 15.0)
        return;
      List<SelfBarrage> selfBarrageList = new List<SelfBarrage>(sprt.Count * 2);
      for (int index = 0; index < sprt.Count; ++index)
      {
        SelfBarrage selfBarrage1 = new SelfBarrage(s, new Rectangle(101, 115, 25, 27), new Vector2(13f, 14f), sprt[index].position + p, 1f, new Vector2(1f, 1f));
        SelfBarrage selfBarrage2 = new SelfBarrage(s, new Rectangle(101, 115, 25, 27), new Vector2(13f, 14f), sprt[index].position + p, 1f, new Vector2(1f, 1f));
        selfBarrageList.Add(selfBarrage1);
        selfBarrageList.Add(selfBarrage2);
        selfBarrage1.label = selfBarrage2.label = 1;
        selfBarrage1.scale = selfBarrage2.scale = new Vector2(0.8f, 0.8f);
        selfBarrage1.rotate = selfBarrage2.rotate = true;
        selfBarrage1.speed = selfBarrage2.speed = 5f;
        selfBarrage1.power = selfBarrage2.power = 0;
      }
      switch (sprt.Count)
      {
        case 1:
          selfBarrageList[0].speedd = 280f;
          selfBarrageList[1].speedd = 260f;
          break;
        case 2:
          selfBarrageList[0].speedd = selfBarrageList[2].speedd = 270f;
          selfBarrageList[1].speedd = (float) byte.MaxValue;
          selfBarrageList[3].speedd = 285f;
          break;
        case 3:
          selfBarrageList[0].speedd = 280f;
          selfBarrageList[1].speedd = 260f;
          selfBarrageList[2].speedd = (float) byte.MaxValue;
          selfBarrageList[3].speedd = 240f;
          selfBarrageList[4].speedd = 285f;
          selfBarrageList[5].speedd = 300f;
          break;
        case 4:
          selfBarrageList[0].speedd = selfBarrageList[2].speedd = 270f;
          selfBarrageList[1].speedd = 285f;
          selfBarrageList[3].speedd = (float) byte.MaxValue;
          selfBarrageList[4].speedd = 240f;
          selfBarrageList[5].speedd = (float) byte.MaxValue;
          selfBarrageList[6].speedd = 285f;
          selfBarrageList[7].speedd = 300f;
          break;
      }
      EquipShoot.ctime = 0.0f;
    }
  }
}
