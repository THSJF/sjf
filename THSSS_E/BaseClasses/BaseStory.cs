// Decompiled with JetBrains decompiler
// Type: Shooting.BaseStory
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Collections.Generic;

namespace Shooting
{
  public class BaseStory : BaseObject
  {
    public List<BaseObject> StoryEffectList = new List<BaseObject>();
    private bool Z = true;

    public BaseStory()
    {
    }

    public BaseStory(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.Story = this;
      if (this.Boss == null)
        return;
      this.Boss.Enabled = false;
    }

    public override void Ctrl()
    {
      if (this.KClass.Key_Z || this.KClass.Key_Ctrl)
      {
        if (!this.Z)
        {
          ++this.Time;
          this.StageData.SoundPlay("se_plst00.wav");
        }
        if (this.KClass.Key_Ctrl)
          return;
        this.Z = true;
      }
      else
        this.Z = false;
    }
  }
}
