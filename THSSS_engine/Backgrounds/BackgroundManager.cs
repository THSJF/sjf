 
// Type: Shooting.BackgroundManager
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Collections.Generic;

namespace Shooting
{
  public class BackgroundManager
  {
    private int light = 0;

    public int Light
    {
      get
      {
        return this.light;
      }
      set
      {
        if (value < 0)
          this.light = 0;
        else if (value > (int) byte.MaxValue)
          this.light = (int) byte.MaxValue;
        else
          this.light = value;
      }
    }

    public List<BaseObject> BackgroundList { get; set; }

    public BackgroundManager()
    {
      this.Light = (int) byte.MaxValue;
      this.BackgroundList = new List<BaseObject>();
    }

    public void Ctrl()
    {
      this.BackgroundList.ForEach((Action<BaseObject>) (x =>
      {
        if (!x.OutBoundary())
          return;
        this.BackgroundList.Remove(x);
      }));
      this.BackgroundList.ForEach((Action<BaseObject>) (x => x.Ctrl()));
    }

    public void Show(bool Active)
    {
      if (Active)
        this.BackgroundList.ForEach((Action<BaseObject>) (x =>
        {
          if (!x.Active)
            return;
          x.Show();
        }));
      else
        this.BackgroundList.ForEach((Action<BaseObject>) (x =>
        {
          if (x.Active)
            return;
          x.Show();
        }));
    }

    public void Clear()
    {
      this.BackgroundList.Clear();
    }
  }
}
