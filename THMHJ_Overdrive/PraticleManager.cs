// Decompiled with JetBrains decompiler
// Type: THMHJ.PraticleManager
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace THMHJ
{
  public class PraticleManager
  {
    public static List<Praticle> PraticleArray = new List<Praticle>();
    public static List<Praticle> APraticleArray = new List<Praticle>();
    public static Texture2D practile;

    public static void initialize(GraphicsDevice g)
    {
      PraticleManager.practile = Texture2D.FromFile(g, Cry.Decry("Content/Graphics/List/praticle.xna", 0));
    }

    public static void Update()
    {
      foreach (Praticle apraticle in PraticleManager.APraticleArray)
        apraticle.Update();
    }

    public static void Draw(SpriteBatch s, Vector2 Quakeset)
    {
      foreach (Praticle apraticle in PraticleManager.APraticleArray)
        apraticle.Draw(s, Quakeset);
    }

    public static void Clear()
    {
      PraticleManager.PraticleArray.Clear();
      PraticleManager.APraticleArray.Clear();
    }
  }
}
