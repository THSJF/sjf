// Decompiled with JetBrains decompiler
// Type: THMHJ._3DPraticleManager
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace THMHJ
{
  internal class _3DPraticleManager
  {
    public List<Launcher> LauncherCollection;
    public List<_3DPraticle> PraticleColleciton;

    public _3DPraticleManager()
    {
      this.LauncherCollection = new List<Launcher>();
      this.PraticleColleciton = new List<_3DPraticle>();
    }

    public int GetIndex(int id)
    {
      for (int index = 0; index < this.LauncherCollection.Count; ++index)
      {
        if (this.LauncherCollection[index].id == id)
          return index;
      }
      return -1;
    }

    public void Update(float step)
    {
      for (int index = 0; index < this.LauncherCollection.Count; ++index)
      {
        if (!this.LauncherCollection[index].die)
        {
          if (this.LauncherCollection[index].attach)
          {
            this.LauncherCollection[index].rectvta.Z += step;
            this.LauncherCollection[index].rectvtb.Z += step;
          }
          this.LauncherCollection[index].Update(this);
        }
        else
        {
          this.LauncherCollection.RemoveAt(index);
          --index;
        }
      }
      for (int index = 0; index < this.PraticleColleciton.Count; ++index)
      {
        if (!this.PraticleColleciton[index].die)
        {
          this.PraticleColleciton[index].Update();
        }
        else
        {
          this.PraticleColleciton.RemoveAt(index);
          --index;
        }
      }
    }

    public void Draw(SpriteBatch s, bool Anti, Matrix view, Matrix projection, GraphicsDevice g)
    {
      for (int index = 0; index < this.PraticleColleciton.Count; ++index)
      {
        if (!this.PraticleColleciton[index].die)
          this.PraticleColleciton[index].Draw(Anti, view, projection, g);
      }
    }

    public void Dispose()
    {
      this.LauncherCollection.Clear();
      this.PraticleColleciton.Clear();
    }
  }
}
