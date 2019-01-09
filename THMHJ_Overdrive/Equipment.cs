// Decompiled with JetBrains decompiler
// Type: THMHJ.Equipment
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace THMHJ
{
  internal class Equipment : EquipShoot
  {
    private Texture2D tex;
    private List<Sprite> sprites;
    private float time;
    private float time2;
    private float ptime;
    private bool inited;
    private int id;
    private int level;
    private Vector2 player;
    private CrazyStorm ps;

    public Equipment(Texture2D tex_i)
    {
      this.tex = tex_i;
      this.sprites = new List<Sprite>();
    }

    public void Reinit()
    {
      this.time = 0.0f;
      this.inited = false;
      this.sprites.Clear();
    }

    public void Init()
    {
      this.time2 = 0.0f;
      this.Reinit();
      EquipShoot.Init();
    }

    public void Update(
      Boss b,
      EnemyManager em,
      Cname t,
      int id_i,
      int l,
      Vector2 pos,
      bool Ban)
    {
      this.player = pos;
      if (id_i != this.id || l != this.level)
        this.Reinit();
      this.level = l;
      this.id = id_i;
      switch (t)
      {
        case Cname.REIMU:
          if (this.id == 0)
          {
            this.H_AMULET(l, pos, Ban);
            break;
          }
          break;
        case Cname.MARISA:
          if (this.id == 0)
          {
            this.D_TORPEDO(l, pos, Ban);
            break;
          }
          break;
        case Cname.SANAE:
          if (this.id == 0)
          {
            this.S_BOMB(l, pos, Ban);
            break;
          }
          break;
        default:
          if (this.id == 0)
          {
            this.EM_BLAST(b, em, l, pos, Ban);
            break;
          }
          break;
      }
      if (!Ban && (Main.IsKeyDown(Keys.Z) || !Main.Replay && PadState.IsKeyDown(JOYKEYS.Confirm)))
        EquipShoot.CEquipShoot(this.tex, t, this.id, pos, this.sprites);
      this.time += Time.Stop;
    }

    public void Draw(SpriteBatch s, Vector2 quake)
    {
      for (int index = 0; index < this.sprites.Count; ++index)
      {
        Vector2 position = this.sprites[index].position;
        this.sprites[index].position = new Vector2(position.X + this.player.X + quake.X, position.Y + this.player.Y + quake.Y);
        this.sprites[index].Draw(s, SpriteEffects.None, 0.0f);
        this.sprites[index].position = position;
      }
    }

    private void H_AMULET(int l, Vector2 p, bool Ban)
    {
      if (!this.inited)
      {
        this.inited = true;
        for (int index = 0; index < l; ++index)
        {
          this.sprites.Add(new Sprite(this.tex, new Rectangle(12, 63, 45, 41)));
          this.sprites[this.sprites.Count - 1].origin = new Vector2(23f, 21f);
          this.sprites[this.sprites.Count - 1].scale = Vector2.Zero;
          this.sprites[this.sprites.Count - 1].color.a = 1f;
        }
        switch (l)
        {
          case 1:
            this.sprites[0].position = new Vector2(0.0f, -30f);
            break;
          case 2:
            this.sprites[0].position = new Vector2(-30f, 0.0f);
            this.sprites[1].position = new Vector2(30f, 0.0f);
            break;
          case 3:
            this.sprites[0].position = new Vector2(0.0f, -30f);
            this.sprites[1].position = new Vector2(-30f, 0.0f);
            this.sprites[2].position = new Vector2(30f, 0.0f);
            break;
          case 4:
            this.sprites[0].position = new Vector2(-20f, -25f);
            this.sprites[1].position = new Vector2(20f, -25f);
            this.sprites[2].position = new Vector2(-35f, 0.0f);
            this.sprites[3].position = new Vector2(35f, 0.0f);
            break;
        }
      }
      for (int index = 0; index < this.sprites.Count; ++index)
      {
        this.sprites[index].scale += new Vector2(0.06f, 0.06f);
        if ((double) this.sprites[index].scale.X >= 0.800000011920929)
          this.sprites[index].scale = new Vector2(0.8f, 0.8f);
        this.sprites[index].rotation -= 5f * Time.Stop;
        if ((double) this.sprites[index].rotation < 0.0)
          this.sprites[index].rotation = 360f - this.sprites[index].rotation;
      }
      if ((double) Time.Stop != 1.0)
        return;
      if (!Ban && (Main.IsKeyDown(Keys.LeftShift) || Main.IsKeyDown(Keys.RightShift) || !Main.Replay && PadState.IsKeyDown(JOYKEYS.Slow)))
      {
        switch (l)
        {
          case 1:
            this.sprites[0].position.X += (float) ((0.0 - (double) this.sprites[0].position.X) / 5.0);
            this.sprites[0].position.Y += (float) ((-30.0 - (double) this.sprites[0].position.Y) / 5.0);
            break;
          case 2:
            this.sprites[0].position.X += (float) ((-5.0 - (double) this.sprites[0].position.X) / 5.0);
            this.sprites[0].position.Y += (float) ((-30.0 - (double) this.sprites[0].position.Y) / 5.0);
            this.sprites[1].position.X += (float) ((5.0 - (double) this.sprites[1].position.X) / 5.0);
            this.sprites[1].position.Y += (float) ((-30.0 - (double) this.sprites[1].position.Y) / 5.0);
            break;
          case 3:
            this.sprites[0].position.X += (float) ((0.0 - (double) this.sprites[0].position.X) / 5.0);
            this.sprites[0].position.Y += (float) ((-30.0 - (double) this.sprites[0].position.Y) / 5.0);
            this.sprites[1].position.X += (float) ((-10.0 - (double) this.sprites[1].position.X) / 5.0);
            this.sprites[1].position.Y += (float) ((-25.0 - (double) this.sprites[1].position.Y) / 5.0);
            this.sprites[2].position.X += (float) ((10.0 - (double) this.sprites[2].position.X) / 5.0);
            this.sprites[2].position.Y += (float) ((-25.0 - (double) this.sprites[2].position.Y) / 5.0);
            break;
          case 4:
            this.sprites[0].position.X += (float) ((-15.0 - (double) this.sprites[0].position.X) / 5.0);
            this.sprites[0].position.Y += (float) ((-25.0 - (double) this.sprites[0].position.Y) / 5.0);
            this.sprites[1].position.X += (float) ((15.0 - (double) this.sprites[1].position.X) / 5.0);
            this.sprites[1].position.Y += (float) ((-25.0 - (double) this.sprites[1].position.Y) / 5.0);
            this.sprites[2].position.X += (float) ((-5.0 - (double) this.sprites[2].position.X) / 5.0);
            this.sprites[2].position.Y += (float) ((-30.0 - (double) this.sprites[2].position.Y) / 5.0);
            this.sprites[3].position.X += (float) ((5.0 - (double) this.sprites[3].position.X) / 5.0);
            this.sprites[3].position.Y += (float) ((-30.0 - (double) this.sprites[3].position.Y) / 5.0);
            break;
        }
      }
      else
      {
        switch (l)
        {
          case 1:
            this.sprites[0].position.X += (float) ((0.0 - (double) this.sprites[0].position.X) / 5.0);
            this.sprites[0].position.Y += (float) ((-30.0 - (double) this.sprites[0].position.Y) / 5.0);
            break;
          case 2:
            this.sprites[0].position.X += (float) ((-30.0 - (double) this.sprites[0].position.X) / 5.0);
            this.sprites[0].position.Y += (float) ((0.0 - (double) this.sprites[0].position.Y) / 5.0);
            this.sprites[1].position.X += (float) ((30.0 - (double) this.sprites[1].position.X) / 5.0);
            this.sprites[1].position.Y += (float) ((0.0 - (double) this.sprites[1].position.Y) / 5.0);
            break;
          case 3:
            this.sprites[0].position.X += (float) ((0.0 - (double) this.sprites[0].position.X) / 5.0);
            this.sprites[0].position.Y += (float) ((-30.0 - (double) this.sprites[0].position.Y) / 5.0);
            this.sprites[1].position.X += (float) ((-30.0 - (double) this.sprites[1].position.X) / 5.0);
            this.sprites[1].position.Y += (float) ((0.0 - (double) this.sprites[1].position.Y) / 5.0);
            this.sprites[2].position.X += (float) ((30.0 - (double) this.sprites[2].position.X) / 5.0);
            this.sprites[2].position.Y += (float) ((0.0 - (double) this.sprites[2].position.Y) / 5.0);
            break;
          case 4:
            this.sprites[0].position.X += (float) ((-20.0 - (double) this.sprites[0].position.X) / 5.0);
            this.sprites[0].position.Y += (float) ((-25.0 - (double) this.sprites[0].position.Y) / 5.0);
            this.sprites[1].position.X += (float) ((20.0 - (double) this.sprites[1].position.X) / 5.0);
            this.sprites[1].position.Y += (float) ((-25.0 - (double) this.sprites[1].position.Y) / 5.0);
            this.sprites[2].position.X += (float) ((-35.0 - (double) this.sprites[2].position.X) / 5.0);
            this.sprites[2].position.Y += (float) ((0.0 - (double) this.sprites[2].position.Y) / 5.0);
            this.sprites[3].position.X += (float) ((35.0 - (double) this.sprites[3].position.X) / 5.0);
            this.sprites[3].position.Y += (float) ((0.0 - (double) this.sprites[3].position.Y) / 5.0);
            break;
        }
      }
    }

    private void D_TORPEDO(int l, Vector2 p, bool Ban)
    {
      if (!this.inited)
      {
        this.inited = true;
        for (int index = 0; index < l; ++index)
        {
          this.sprites.Add(new Sprite(this.tex, new Rectangle(146, 61, 41, 40)));
          this.sprites[this.sprites.Count - 1].origin = new Vector2(21f, 20f);
          this.sprites[this.sprites.Count - 1].scale = Vector2.Zero;
          this.sprites[this.sprites.Count - 1].color.a = 1f;
        }
        switch (l)
        {
          case 1:
            this.sprites[0].position = new Vector2(0.0f, -30f);
            break;
          case 2:
            this.sprites[0].position = new Vector2(-20f, 0.0f);
            this.sprites[1].position = new Vector2(20f, 0.0f);
            break;
          case 3:
            this.sprites[0].position = new Vector2(0.0f, -30f);
            this.sprites[1].position = new Vector2(-20f, 0.0f);
            this.sprites[2].position = new Vector2(20f, 0.0f);
            break;
          case 4:
            this.sprites[0].position = new Vector2(-14f, -25f);
            this.sprites[1].position = new Vector2(14f, -25f);
            this.sprites[2].position = new Vector2(-30f, 0.0f);
            this.sprites[3].position = new Vector2(30f, 0.0f);
            break;
        }
      }
      for (int index = 0; index < this.sprites.Count; ++index)
      {
        this.sprites[index].scale += new Vector2(0.06f, 0.06f);
        if ((double) this.sprites[index].scale.X >= 0.5)
          this.sprites[index].scale = new Vector2((float) (0.5 + 0.300000011920929 * (double) Math.Abs((float) Math.Sin((double) this.time / 40.0 * Math.PI))), (float) (0.5 + 0.300000011920929 * (double) Math.Abs((float) Math.Sin((double) this.time / 40.0 * Math.PI))));
      }
      if ((double) Time.Stop == 1.0)
      {
        if (!Ban && (Main.IsKeyDown(Keys.LeftShift) || Main.IsKeyDown(Keys.RightShift) || !Main.Replay && PadState.IsKeyDown(JOYKEYS.Slow)))
        {
          switch (l)
          {
            case 1:
              this.sprites[0].position.X += (float) ((0.0 - (double) this.sprites[0].position.X) / 5.0);
              this.sprites[0].position.Y += (float) ((-30.0 - (double) this.sprites[0].position.Y) / 5.0);
              break;
            case 2:
              this.sprites[0].position.X += (float) ((-1.0 - (double) this.sprites[0].position.X) / 5.0);
              this.sprites[0].position.Y += (float) ((-30.0 - (double) this.sprites[0].position.Y) / 5.0);
              this.sprites[1].position.X += (float) ((1.0 - (double) this.sprites[1].position.X) / 5.0);
              this.sprites[1].position.Y += (float) ((-30.0 - (double) this.sprites[1].position.Y) / 5.0);
              break;
            case 3:
              this.sprites[0].position.X += (float) ((0.0 - (double) this.sprites[0].position.X) / 5.0);
              this.sprites[0].position.Y += (float) ((-30.0 - (double) this.sprites[0].position.Y) / 5.0);
              this.sprites[1].position.X += (float) ((-1.0 - (double) this.sprites[1].position.X) / 5.0);
              this.sprites[1].position.Y += (float) ((-30.0 - (double) this.sprites[1].position.Y) / 5.0);
              this.sprites[2].position.X += (float) ((1.0 - (double) this.sprites[2].position.X) / 5.0);
              this.sprites[2].position.Y += (float) ((-30.0 - (double) this.sprites[2].position.Y) / 5.0);
              break;
            case 4:
              this.sprites[0].position.X += (float) ((-1.0 - (double) this.sprites[0].position.X) / 5.0);
              this.sprites[0].position.Y += (float) ((-30.0 - (double) this.sprites[0].position.Y) / 5.0);
              this.sprites[1].position.X += (float) ((1.0 - (double) this.sprites[1].position.X) / 5.0);
              this.sprites[1].position.Y += (float) ((-30.0 - (double) this.sprites[1].position.Y) / 5.0);
              this.sprites[2].position.X += (float) ((-2.0 - (double) this.sprites[2].position.X) / 5.0);
              this.sprites[2].position.Y += (float) ((-30.0 - (double) this.sprites[2].position.Y) / 5.0);
              this.sprites[3].position.X += (float) ((2.0 - (double) this.sprites[3].position.X) / 5.0);
              this.sprites[3].position.Y += (float) ((-30.0 - (double) this.sprites[3].position.Y) / 5.0);
              break;
          }
        }
        else
        {
          switch (l)
          {
            case 1:
              this.sprites[0].position.X += (float) ((0.0 - (double) this.sprites[0].position.X) / 5.0);
              this.sprites[0].position.Y += (float) ((-30.0 - (double) this.sprites[0].position.Y) / 5.0);
              break;
            case 2:
              this.sprites[0].position.X += (float) ((-20.0 - (double) this.sprites[0].position.X) / 5.0);
              this.sprites[0].position.Y += (float) ((0.0 - (double) this.sprites[0].position.Y) / 5.0);
              this.sprites[1].position.X += (float) ((20.0 - (double) this.sprites[1].position.X) / 5.0);
              this.sprites[1].position.Y += (float) ((0.0 - (double) this.sprites[1].position.Y) / 5.0);
              break;
            case 3:
              this.sprites[0].position.X += (float) ((0.0 - (double) this.sprites[0].position.X) / 5.0);
              this.sprites[0].position.Y += (float) ((-30.0 - (double) this.sprites[0].position.Y) / 5.0);
              this.sprites[1].position.X += (float) ((-20.0 - (double) this.sprites[1].position.X) / 5.0);
              this.sprites[1].position.Y += (float) ((0.0 - (double) this.sprites[1].position.Y) / 5.0);
              this.sprites[2].position.X += (float) ((20.0 - (double) this.sprites[2].position.X) / 5.0);
              this.sprites[2].position.Y += (float) ((0.0 - (double) this.sprites[2].position.Y) / 5.0);
              break;
            case 4:
              this.sprites[0].position.X += (float) ((-14.0 - (double) this.sprites[0].position.X) / 5.0);
              this.sprites[0].position.Y += (float) ((-25.0 - (double) this.sprites[0].position.Y) / 5.0);
              this.sprites[1].position.X += (float) ((14.0 - (double) this.sprites[1].position.X) / 5.0);
              this.sprites[1].position.Y += (float) ((-25.0 - (double) this.sprites[1].position.Y) / 5.0);
              this.sprites[2].position.X += (float) ((-30.0 - (double) this.sprites[2].position.X) / 5.0);
              this.sprites[2].position.Y += (float) ((0.0 - (double) this.sprites[2].position.Y) / 5.0);
              this.sprites[3].position.X += (float) ((30.0 - (double) this.sprites[3].position.X) / 5.0);
              this.sprites[3].position.Y += (float) ((0.0 - (double) this.sprites[3].position.Y) / 5.0);
              break;
          }
        }
      }
      foreach (SelfBarrage sb in SelfBarrageManager.SBArray)
      {
        if (sb.label == 2 && Main.IsKeyUp(Keys.Z) && (Main.Replay || PadState.IsKeyUp(JOYKEYS.Confirm)))
          sb.Judged = true;
        else if (sb.label == 2 && sb.Judged)
        {
          sb.color.g -= 0.1f;
          sb.color.b -= 0.1f;
          if ((double) sb.color.g <= 0.0)
            sb.color = new Colors(1f, 0.0f, 0.0f, 1f);
        }
      }
    }

    private void S_BOMB(int l, Vector2 p, bool Ban)
    {
      if (!this.inited)
      {
        this.inited = true;
        for (int index = 0; index < l; ++index)
        {
          this.sprites.Add(new Sprite(this.tex, new Rectangle(103, 61, 41, 41)));
          this.sprites[this.sprites.Count - 1].origin = new Vector2(20f, 21f);
          this.sprites[this.sprites.Count - 1].scale = Vector2.Zero;
          this.sprites[this.sprites.Count - 1].color.a = 1f;
        }
        switch (l)
        {
          case 1:
            this.sprites[0].position = new Vector2(0.0f, -30f);
            break;
          case 2:
            this.sprites[0].position = new Vector2(-30f, 0.0f);
            this.sprites[1].position = new Vector2(30f, 0.0f);
            break;
          case 3:
            this.sprites[0].position = new Vector2(0.0f, -30f);
            this.sprites[1].position = new Vector2(-30f, 0.0f);
            this.sprites[2].position = new Vector2(30f, 0.0f);
            break;
          case 4:
            this.sprites[0].position = new Vector2(-22f, 10f);
            this.sprites[1].position = new Vector2(22f, 10f);
            this.sprites[2].position = new Vector2(-40f, 0.0f);
            this.sprites[3].position = new Vector2(40f, 0.0f);
            break;
        }
      }
      for (int index = 0; index < this.sprites.Count; ++index)
      {
        this.sprites[index].scale += new Vector2(0.06f, 0.06f);
        if ((double) this.sprites[index].scale.X >= 0.800000011920929)
          this.sprites[index].scale = new Vector2(0.8f, 0.8f);
        this.sprites[index].rotation += 10f * Time.Stop;
      }
      if ((double) Time.Stop == 1.0)
      {
        if (!Ban && (Main.IsKeyDown(Keys.LeftShift) || Main.IsKeyDown(Keys.RightShift) || !Main.Replay && PadState.IsKeyDown(JOYKEYS.Slow)))
        {
          switch (l)
          {
            case 1:
              this.sprites[0].position.X += (float) ((0.0 - (double) this.sprites[0].position.X) / 5.0);
              this.sprites[0].position.Y += (float) ((-30.0 - (double) this.sprites[0].position.Y) / 5.0);
              break;
            case 2:
              this.sprites[0].position.X += (float) ((-17.0 - (double) this.sprites[0].position.X) / 5.0);
              this.sprites[0].position.Y += (float) ((-11.0 - (double) this.sprites[0].position.Y) / 5.0);
              this.sprites[1].position.X += (float) ((17.0 - (double) this.sprites[1].position.X) / 5.0);
              this.sprites[1].position.Y += (float) ((-11.0 - (double) this.sprites[1].position.Y) / 5.0);
              break;
            case 3:
              this.sprites[0].position.X += (float) ((0.0 - (double) this.sprites[0].position.X) / 5.0);
              this.sprites[0].position.Y += (float) ((-30.0 - (double) this.sprites[0].position.Y) / 5.0);
              this.sprites[1].position.X += (float) ((-20.0 - (double) this.sprites[1].position.X) / 5.0);
              this.sprites[1].position.Y += (float) ((-10.0 - (double) this.sprites[1].position.Y) / 5.0);
              this.sprites[2].position.X += (float) ((20.0 - (double) this.sprites[2].position.X) / 5.0);
              this.sprites[2].position.Y += (float) ((-10.0 - (double) this.sprites[2].position.Y) / 5.0);
              break;
            case 4:
              this.sprites[0].position.X += (float) ((-12.0 - (double) this.sprites[0].position.X) / 5.0);
              this.sprites[0].position.Y += (float) ((-25.0 - (double) this.sprites[0].position.Y) / 5.0);
              this.sprites[1].position.X += (float) ((12.0 - (double) this.sprites[1].position.X) / 5.0);
              this.sprites[1].position.Y += (float) ((-25.0 - (double) this.sprites[1].position.Y) / 5.0);
              this.sprites[2].position.X += (float) ((-26.0 - (double) this.sprites[2].position.X) / 5.0);
              this.sprites[2].position.Y += (float) ((-5.0 - (double) this.sprites[2].position.Y) / 5.0);
              this.sprites[3].position.X += (float) ((26.0 - (double) this.sprites[3].position.X) / 5.0);
              this.sprites[3].position.Y += (float) ((-5.0 - (double) this.sprites[3].position.Y) / 5.0);
              break;
          }
        }
        else
        {
          switch (l)
          {
            case 1:
              this.sprites[0].position.X += (float) ((0.0 - (double) this.sprites[0].position.X) / 5.0);
              this.sprites[0].position.Y += (float) ((-30.0 - (double) this.sprites[0].position.Y) / 5.0);
              break;
            case 2:
              this.sprites[0].position.X += (float) ((-30.0 - (double) this.sprites[0].position.X) / 5.0);
              this.sprites[0].position.Y += (float) ((0.0 - (double) this.sprites[0].position.Y) / 5.0);
              this.sprites[1].position.X += (float) ((30.0 - (double) this.sprites[1].position.X) / 5.0);
              this.sprites[1].position.Y += (float) ((0.0 - (double) this.sprites[1].position.Y) / 5.0);
              break;
            case 3:
              this.sprites[0].position.X += (float) ((0.0 - (double) this.sprites[0].position.X) / 5.0);
              this.sprites[0].position.Y += (float) ((-30.0 - (double) this.sprites[0].position.Y) / 5.0);
              this.sprites[1].position.X += (float) ((-30.0 - (double) this.sprites[1].position.X) / 5.0);
              this.sprites[1].position.Y += (float) ((0.0 - (double) this.sprites[1].position.Y) / 5.0);
              this.sprites[2].position.X += (float) ((30.0 - (double) this.sprites[2].position.X) / 5.0);
              this.sprites[2].position.Y += (float) ((0.0 - (double) this.sprites[2].position.Y) / 5.0);
              break;
            case 4:
              this.sprites[0].position.X += (float) ((-22.0 - (double) this.sprites[0].position.X) / 5.0);
              this.sprites[0].position.Y += (float) ((10.0 - (double) this.sprites[0].position.Y) / 5.0);
              this.sprites[1].position.X += (float) ((22.0 - (double) this.sprites[1].position.X) / 5.0);
              this.sprites[1].position.Y += (float) ((10.0 - (double) this.sprites[1].position.Y) / 5.0);
              this.sprites[2].position.X += (float) ((-40.0 - (double) this.sprites[2].position.X) / 5.0);
              this.sprites[2].position.Y += (float) ((0.0 - (double) this.sprites[2].position.Y) / 5.0);
              this.sprites[3].position.X += (float) ((40.0 - (double) this.sprites[3].position.X) / 5.0);
              this.sprites[3].position.Y += (float) ((0.0 - (double) this.sprites[3].position.Y) / 5.0);
              break;
          }
        }
      }
      foreach (SelfBarrage sb in SelfBarrageManager.SBArray)
      {
        if (sb.label == 1 && ((double) sb.time >= 60.0 || sb.Judged))
        {
          Program.game.game.PlaySound("explo", true, sb.Position.X);
          CrazyStorm crazyStorm = Program.game.game.PlayEffect(true, "1", new Vector2(sb.Position.X + 93f, sb.Position.Y - 13f));
          crazyStorm.isforshoot = true;
          crazyStorm.BanSound(true);
          crazyStorm.shoot.AddRange((IEnumerable<byte>) new List<byte>()
          {
            (byte) 0,
            (byte) 1
          });
          crazyStorm.effect = true;
          crazyStorm.allpan = true;
          crazyStorm.bomb = true;
          sb.Judged = true;
          sb.label = 0;
        }
      }
    }

    private void EM_BLAST(Boss b, EnemyManager em, int l, Vector2 p, bool Ban)
    {
      if (this.ps != null && !this.ps.allpan && (double) this.ptime <= 30.0)
      {
        ++this.ptime;
        int num1 = int.Parse(this.ps.Id.Split('e')[1]) - 19;
        int power = 30 + num1 * 12;
        int num2 = 15 + (num1 - 1) * 5;
        foreach (Enemy enemy in em.EnemyArray)
        {
          if (!enemy.IsInWudi() && (double) Math.Abs(enemy.Position.X - p.X) <= (double) num2 && ((double) enemy.Position.Y >= 0.0 && (double) enemy.Position.Y <= (double) p.Y))
          {
            enemy.hp -= power;
            Program.game.game.Score += 10L;
          }
        }
        if (b != null && (double) Math.Abs(b.Position.X - p.X) <= (double) num2 && ((double) b.Position.Y >= 0.0 && (double) b.Position.Y <= (double) p.Y))
        {
          Program.game.game.Score += 10L;
          if (b.CardArray.Count >= 1)
            b.CardArray[0].DeHp(power, this.ps.isforshoot);
        }
      }
      else if (this.ps != null && this.ps.allpan && (double) this.ptime <= 10.0)
      {
        ++this.ptime;
        if ((double) this.ptime == 10.0)
          this.ps.shoot.AddRange((IEnumerable<byte>) new List<byte>()
          {
            (byte) 0,
            (byte) 37
          });
      }
      CrazyStorm effect = Program.game.game.FindEffect("e2");
      if (effect != null)
      {
        this.time2 += Time.Stop;
        effect.SetPos(new Vector2(p.X + 93f, p.Y - 13f), true);
        if (Main.IsKeyUp(Keys.Z) && (Main.Replay || PadState.IsKeyUp(JOYKEYS.Confirm)))
        {
          Program.game.game.StopSound("ch");
          if ((double) this.time2 >= 90.0 && l >= 1)
          {
            if (Main.IsKeyDown(Keys.LeftShift) || Main.IsKeyDown(Keys.RightShift) || !Main.Replay && PadState.IsKeyDown(JOYKEYS.Slow))
            {
              this.ps = Program.game.game.PlayEffect(true, (2 + l).ToString(), new Vector2(p.X + 93f, p.Y - 13f));
              this.ps.allpan = true;
            }
            else
              this.ps = Program.game.game.PlayEffect(true, (19 + l).ToString(), new Vector2(p.X + 93f, p.Y - 13f));
            this.ptime = 0.0f;
            this.ps.isforshoot = true;
            this.ps.BanSound(true);
            this.ps.effect = true;
            this.ps.bomb = true;
            Program.game.game.PlaySound("slash", true, p.X);
            this.time2 = 0.0f;
          }
          effect.Break();
        }
        if (Ban)
          effect.Break();
      }
      else if (!Ban && l >= 1 && (Main.IsKeyDown(Keys.Z) || !Main.Replay && PadState.IsKeyDown(JOYKEYS.Confirm)) && effect == null)
      {
        this.time2 = 0.0f;
        CrazyStorm crazyStorm = Program.game.game.PlayEffect(true, "2", new Vector2(p.X + 93f, p.Y - 13f));
        crazyStorm.isforshoot = true;
        crazyStorm.BanSound(true);
        crazyStorm.effect = true;
        crazyStorm.specialnotkill = true;
        crazyStorm.SetOPos(new Vector2(p.X + 93f, p.Y - 13f));
        Program.game.game.PlaySound("ch", true, p.X);
      }
      if (!this.inited)
      {
        this.inited = true;
        for (int index = 0; index < l; ++index)
        {
          this.sprites.Add(new Sprite(this.tex, new Rectangle(59, 61, 41, 41)));
          this.sprites[this.sprites.Count - 1].origin = new Vector2(21f, 21f);
          this.sprites[this.sprites.Count - 1].scale = Vector2.Zero;
          this.sprites[this.sprites.Count - 1].color.a = 1f;
        }
        switch (l)
        {
          case 1:
            this.sprites[0].position = new Vector2(0.0f, -30f);
            break;
          case 2:
            this.sprites[0].position = new Vector2(-30f, 0.0f);
            this.sprites[1].position = new Vector2(30f, 0.0f);
            break;
          case 3:
            this.sprites[0].position = new Vector2(0.0f, -30f);
            this.sprites[1].position = new Vector2(-30f, 0.0f);
            this.sprites[2].position = new Vector2(30f, 0.0f);
            break;
          case 4:
            this.sprites[0].position = new Vector2(0.0f, -30f);
            this.sprites[1].position = new Vector2(0.0f, 30f);
            this.sprites[2].position = new Vector2(-30f, 0.0f);
            this.sprites[3].position = new Vector2(30f, 0.0f);
            break;
        }
      }
      for (int index = 0; index < this.sprites.Count; ++index)
      {
        this.sprites[index].scale += new Vector2(0.06f, 0.06f);
        if ((double) this.sprites[index].scale.X >= 0.800000011920929)
          this.sprites[index].scale = new Vector2(0.8f, 0.8f);
        this.sprites[index].rotation = 10f * (float) Math.Sin((double) this.time / 40.0 * Math.PI);
      }
    }
  }
}
