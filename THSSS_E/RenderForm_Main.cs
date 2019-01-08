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
