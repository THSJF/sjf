 
// Type: Shooting.GameRegion
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;
using System.Windows.Forms;

namespace Shooting
{
  internal class GameRegion : UserControl
  {
    private void InitializeComponent()
    {
      this.SuspendLayout();
      this.AutoScaleMode = AutoScaleMode.None;
      this.Name = nameof (GameRegion);
      this.Size = new Size(229, 148);
      this.ResumeLayout(false);
    }
  }
}
