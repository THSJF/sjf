using SlimDX.Windows;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Shooting {
    public class RenderForm_Main:RenderForm {
        private IContainer components = null;
        protected override void Dispose(bool disposing) {
            if(disposing&&components!=null) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent() {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RenderForm_Main));
            SuspendLayout();
            AutoScaleMode=AutoScaleMode.None;
            ClientSize=new Size(640,480);
            FormBorderStyle=FormBorderStyle.FixedDialog;
            Icon=(Icon)componentResourceManager.GetObject("$ Icon");
            MaximizeBox=false;
            Name=nameof(RenderForm_Main);
            StartPosition=FormStartPosition.CenterScreen;
            Text="东方夏夜祭 ～ Shining Shooting Star. ver 1.00";
            ResumeLayout(false);
        }
        public RenderForm_Main() => InitializeComponent();
    }
}
