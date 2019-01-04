// Decompiled with JetBrains decompiler
// Type: THMHJ.NSpriteBatch
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace THMHJ
{
  public class NSpriteBatch : SpriteBatch
  {
    private bool isbegan;

    public NSpriteBatch(GraphicsDevice graphicsDevice)
      : base(graphicsDevice)
    {
    }

    public bool IsBegan
    {
      get
      {
        return this.isbegan;
      }
    }

    public new void Begin()
    {
      base.Begin();
      this.isbegan = true;
    }

    public new void Begin(SpriteBlendMode blendMode)
    {
      base.Begin(blendMode);
      this.isbegan = true;
    }

    public new void Begin(
      SpriteBlendMode blendMode,
      SpriteSortMode sortMode,
      SaveStateMode stateMode)
    {
      base.Begin(blendMode, sortMode, stateMode);
      this.isbegan = true;
    }

    public new void Begin(
      SpriteBlendMode blendMode,
      SpriteSortMode sortMode,
      SaveStateMode stateMode,
      Matrix transformMatrix)
    {
      base.Begin(blendMode, sortMode, stateMode, transformMatrix);
      this.isbegan = true;
    }

    public new void End()
    {
      base.End();
      this.isbegan = false;
    }
  }
}
