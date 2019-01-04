// Decompiled with JetBrains decompiler
// Type: Shooting.RenderForm_Main
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX.Windows;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Shooting
{
  public class RenderForm_Main : RenderForm
  {
    private IContainer components = (IContainer) null;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (RenderForm_Main));
      this.SuspendLayout();
      this.AutoScaleMode = AutoScaleMode.None;
      this.ClientSize = new Size(640, 480);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.Name = nameof (RenderForm_Main);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "东方夏夜祭 ～ Shining Shooting Star. ver 1.00";
      this.ResumeLayout(false);
    }

    public RenderForm_Main()
    {
      this.InitializeComponent();
    }
  }
}
