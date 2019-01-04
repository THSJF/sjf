// Decompiled with JetBrains decompiler
// Type: Shooting.BaseMenu
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Windows.Forms;

namespace Shooting
{
  internal class BaseMenu : BaseGameState, IGameState
  {
    public int BackgroundLight { get; set; }

    public BaseMenu(GlobalDataPackage GlobalData)
    {
      this.Visible = false;
      this.Enabled = false;
      this.GlobalData = GlobalData;
    }

    public BaseMenu()
    {
    }

    public override void Init()
    {
      this.MenuInit();
    }

    public virtual void MenuInit()
    {
    }

    public override void UpdateData()
    {
      base.UpdateData();
      int count = this.StageData.MenuGroupList.Count;
      if (count > 0)
        this.StageData.MenuGroupList[count - 1].MenuSelect();
      this.StageData.MenuGroupList.ForEach((Action<BaseMenuGroup>) (x => x.Ctrl()));
      this.Background3D.Ctrl();
      this.Background.Ctrl();
      this.Background2.Ctrl();
      for (int index = this.EffectList.Count - 1; index >= 0; --index)
        this.EffectList[index].Ctrl();
      this.Particle3D.Ctrl();
      this.SoundPlayList.ForEach((Action<XAudio2_Player>) (x => x.Play()));
    }

    public virtual void BackgroundDrama()
    {
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      this.AutoScaleMode = AutoScaleMode.None;
      this.Name = nameof (BaseMenu);
      this.ResumeLayout(false);
    }
  }
}
