using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CrazyStorm_1._03
{
  public class Centermanager : Form
  {
    private Label label1;
    public TextBox X坐标;
    public TextBox Y坐标;
    private Label label2;
    public TextBox 加速度方向;
    private Label label5;
    public TextBox 加速度;
    private Label label6;
    private GroupBox 事件;
    public TextBox 事件体;
    private Label label4;
    public TextBox 速度;
    private Label label3;
    public TextBox 速度方向;
    public CheckBox 关闭中心;
        
    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Centermanager));
      this.label1 = new Label();
      this.X坐标 = new TextBox();
      this.Y坐标 = new TextBox();
      this.label2 = new Label();
      this.加速度方向 = new TextBox();
      this.label5 = new Label();
      this.加速度 = new TextBox();
      this.label6 = new Label();
      this.事件 = new GroupBox();
      this.事件体 = new TextBox();
      this.label4 = new Label();
      this.速度 = new TextBox();
      this.label3 = new Label();
      this.速度方向 = new TextBox();
      this.关闭中心 = new CheckBox();
      this.事件.SuspendLayout();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.Name = "label1";
      componentResourceManager.ApplyResources((object) this.X坐标, "X坐标");
      this.X坐标.Name = "X坐标";
      componentResourceManager.ApplyResources((object) this.Y坐标, "Y坐标");
      this.Y坐标.Name = "Y坐标";
      componentResourceManager.ApplyResources((object) this.label2, "label2");
      this.label2.Name = "label2";
      componentResourceManager.ApplyResources((object) this.加速度方向, "加速度方向");
      this.加速度方向.Name = "加速度方向";
      componentResourceManager.ApplyResources((object) this.label5, "label5");
      this.label5.Name = "label5";
      componentResourceManager.ApplyResources((object) this.加速度, "加速度");
      this.加速度.Name = "加速度";
      componentResourceManager.ApplyResources((object) this.label6, "label6");
      this.label6.Name = "label6";
      this.事件.Controls.Add((Control) this.事件体);
      componentResourceManager.ApplyResources((object) this.事件, "事件");
      this.事件.Name = "事件";
      this.事件.TabStop = false;
      this.事件体.AcceptsReturn = true;
      componentResourceManager.ApplyResources((object) this.事件体, "事件体");
      this.事件体.Name = "事件体";
      componentResourceManager.ApplyResources((object) this.label4, "label4");
      this.label4.Name = "label4";
      componentResourceManager.ApplyResources((object) this.速度, "速度");
      this.速度.Name = "速度";
      componentResourceManager.ApplyResources((object) this.label3, "label3");
      this.label3.Name = "label3";
      componentResourceManager.ApplyResources((object) this.速度方向, "速度方向");
      this.速度方向.Name = "速度方向";
      componentResourceManager.ApplyResources((object) this.关闭中心, "关闭中心");
      this.关闭中心.Name = "关闭中心";
      this.关闭中心.UseVisualStyleBackColor = true;
      this.关闭中心.CheckedChanged += new EventHandler(this.关闭中心_CheckedChanged);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.关闭中心);
      this.Controls.Add((Control) this.事件);
      this.Controls.Add((Control) this.加速度方向);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.加速度);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.速度方向);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.速度);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.Y坐标);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.X坐标);
      this.Controls.Add((Control) this.label1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (Centermanager);
      this.ShowInTaskbar = false;
      this.TopMost = true;
      this.Load += new EventHandler(this.Centermanager_Load);
      this.FormClosed += new FormClosedEventHandler(this.Centermanager_FormClosed);
      this.事件.ResumeLayout(false);
      this.事件.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public Centermanager()
    {
      this.InitializeComponent();
    }

    private void Centermanager_FormClosed(object sender, FormClosedEventArgs e)
    {
      Center.x = float.Parse(this.X坐标.Text);
      Center.y = float.Parse(this.Y坐标.Text);
      Center.speed = float.Parse(this.速度.Text);
      Center.speedd = float.Parse(this.速度方向.Text);
      Center.aspeed = float.Parse(this.加速度.Text);
      Center.aspeedd = float.Parse(this.加速度方向.Text);
      string[] strArray = this.事件体.Text.Split('\r');
      Center.events.Clear();
      foreach (string str in strArray)
      {
        if (str.Replace("\r", "").Replace("\n", "") != "")
        {
          if (((str.Contains("当前帧") & str.Contains("：") ? 1 : 0) & (((str.Contains("=") & str.Contains("，") ? 1 : 0) & (str.Contains("速度") || str.Contains("速度方向") || str.Contains("加速度") ? 1 : (str.Contains("加速度方向") ? 1 : 0)) & (str.Contains("增加") || str.Contains("减少") ? 1 : (str.Contains("变化到") ? 1 : 0)) & (str.Contains("正比") || str.Contains("固定") ? 1 : (str.Contains("正弦") ? 1 : 0))) != 0 || str.Contains("跟随自机") || (str.Contains("范围移动") || str.Contains("PlayMusic")) || str.Contains("UseKira") ? 1 : (str.Contains("BanSound") ? 1 : 0))) != 0)
            Center.events.Add(str.Replace("\r", "").Replace("\n", ""));
          else
            Main.Message("格式无效");
        }
      }
    }

    private void 关闭中心_CheckedChanged(object sender, EventArgs e)
    {
      Center.Available = !this.关闭中心.Checked;
    }

    private void Centermanager_Load(object sender, EventArgs e)
    {
    }
  }
}
