// Decompiled with JetBrains decompiler
// Type: THMHJ.Layer
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace THMHJ
{
  [Serializable]
  public class Layer
  {
    public int sort;
    public bool Visible;
    public int begin;
    public int end;
    public List<Batch> BatchArray;
    public List<Lase> LaseArray;
    public List<Cover> CoverArray;
    public List<Rebound> ReboundArray;
    public List<Force> ForceArray;
    public List<Barrage> Barrages;

    public Layer(LayerManager lm, int bg, int ed)
    {
      this.Visible = true;
      this.sort = lm.LayerArray.Count;
      this.begin = bg;
      this.end = ed;
      this.BatchArray = new List<Batch>();
      this.LaseArray = new List<Lase>();
      this.CoverArray = new List<Cover>();
      this.ReboundArray = new List<Rebound>();
      this.ForceArray = new List<Force>();
      this.Barrages = new List<Barrage>();
      lm.LayerArray.Add(this);
    }

    public void Update(
      LayerManager lm,
      CrazyStorm cs,
      CSManager csm,
      Time Times,
      Center Centers,
      Character Player,
      EnemyManager em,
      Boss b,
      bool bs,
      bool allpan,
      Vector2 ppos,
      bool isforshoot,
      bool usekira,
      bool bansound)
    {
      if (!cs.IsClosing() && this.Visible)
      {
        for (int index = 0; index < this.ForceArray.Count; ++index)
        {
          this.ForceArray[index].id = index;
          this.ForceArray[index].parentid = this.sort;
          this.ForceArray[index].copys.Update(lm, Times, Centers, Player);
        }
        for (int index = 0; index < this.ReboundArray.Count; ++index)
        {
          this.ReboundArray[index].id = index;
          this.ReboundArray[index].parentid = this.sort;
          this.ReboundArray[index].copys.Update(lm, cs, Times, Centers, Player.body.position + new Vector2(93f, -13f));
        }
        for (int index = 0; index < this.CoverArray.Count; ++index)
        {
          this.CoverArray[index].id = index;
          this.CoverArray[index].parentid = this.sort;
          this.CoverArray[index].copys.Update(lm, cs, Times, Centers, Player.body.position + new Vector2(93f, -13f));
        }
        for (int index = 0; index < this.LaseArray.Count; ++index)
        {
          this.LaseArray[index].id = index;
          this.LaseArray[index].parentid = this.sort;
          this.LaseArray[index].copys.Update(lm, cs, Times, Centers, Player.body.position + new Vector2(93f, -13f));
        }
        for (int index = 0; index < this.BatchArray.Count; ++index)
        {
          this.BatchArray[index].id = index;
          this.BatchArray[index].parentid = this.sort;
          this.BatchArray[index].copys.Update(lm, cs, Times, Centers, Player.body.position + new Vector2(93f, -13f));
        }
      }
      bool flag = false;
      for (int index = 0; index < this.Barrages.Count; ++index)
      {
        this.Barrages[index].id = index;
        this.Barrages[index].Update(csm, cs, Times, Centers, Player, em, b, bs, allpan, ppos, isforshoot, usekira, bansound);
        this.Barrages[index].LUpdate(csm, cs, Times, Centers, Player, bs);
        if (cs.IsBreaking())
        {
          if (!this.Barrages[index].Dis && cs.IsItem())
          {
            Program.game.game.SmallItem(new Vector2(this.Barrages[index].x - 93f, this.Barrages[index].y + 13f));
            flag = true;
          }
          this.Barrages[index].life = 0;
          this.Barrages[index].Dis = true;
          this.Barrages[index].Blend = true;
          this.Barrages[index].randf = 6.283185f * (float) Main.rand.NextDouble();
        }
      }
      if (!flag)
        return;
      cs.itemed = true;
    }
  }
}
