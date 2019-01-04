// Decompiled with JetBrains decompiler
// Type: THMHJ.CautionManager
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace THMHJ
{
  internal class CautionManager
  {
    private List<Caution> Cautionm;

    public CautionManager()
    {
      this.Cautionm = new List<Caution>();
    }

    public void Add(Caution a)
    {
      this.Cautionm.Add(a);
    }

    public void Update()
    {
      for (int index = 0; index < this.Cautionm.Count; ++index)
      {
        if (!this.Cautionm[index].die)
        {
          this.Cautionm[index].Update();
        }
        else
        {
          this.Cautionm.RemoveAt(index);
          --index;
        }
      }
    }

    public void Draw(SpriteBatch s)
    {
      for (int index = 0; index < this.Cautionm.Count; ++index)
      {
        if (!this.Cautionm[index].die)
          this.Cautionm[index].Draw(s);
      }
    }
  }
}
