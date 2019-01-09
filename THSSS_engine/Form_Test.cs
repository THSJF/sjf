using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Shooting
{
  public class Form_Test : Form
  {
    private IContainer components = (IContainer) null;
    private NumericUpDown numericUpDown1;
    private NumericUpDown numericUpDown2;
    private NumericUpDown numericUpDown3;
    private NumericUpDown numericUpDown4;
    private NumericUpDown numericUpDown5;
    private NumericUpDown numericUpDown6;
    private RichTextBox richTextBox1;
    private NumericUpDown numericUpDown7;
    private NumericUpDown numericUpDown8;
    public ListBox listBox1;
    public CheckBox checkBox1;
    public FolderBrowserDialog folderBrowserDialog1;
    public TreeView treeView1;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.numericUpDown1 = new NumericUpDown();
      this.numericUpDown2 = new NumericUpDown();
      this.numericUpDown3 = new NumericUpDown();
      this.numericUpDown4 = new NumericUpDown();
      this.numericUpDown5 = new NumericUpDown();
      this.numericUpDown6 = new NumericUpDown();
      this.richTextBox1 = new RichTextBox();
      this.numericUpDown7 = new NumericUpDown();
      this.numericUpDown8 = new NumericUpDown();
      this.listBox1 = new ListBox();
      this.checkBox1 = new CheckBox();
      this.folderBrowserDialog1 = new FolderBrowserDialog();
      this.treeView1 = new TreeView();
      this.numericUpDown1.BeginInit();
      this.numericUpDown2.BeginInit();
      this.numericUpDown3.BeginInit();
      this.numericUpDown4.BeginInit();
      this.numericUpDown5.BeginInit();
      this.numericUpDown6.BeginInit();
      this.numericUpDown7.BeginInit();
      this.numericUpDown8.BeginInit();
      this.SuspendLayout();
      this.numericUpDown1.Location = new Point(0, 0);
      this.numericUpDown1.Maximum = new Decimal(new int[4]
      {
        (int) byte.MaxValue,
        0,
        0,
        0
      });
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new Size(128, 21);
      this.numericUpDown1.TabIndex = 0;
      this.numericUpDown1.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown2.Location = new Point(0, 22);
      this.numericUpDown2.Maximum = new Decimal(new int[4]
      {
        (int) byte.MaxValue,
        0,
        0,
        0
      });
      this.numericUpDown2.Name = "numericUpDown2";
      this.numericUpDown2.Size = new Size(128, 21);
      this.numericUpDown2.TabIndex = 1;
      this.numericUpDown2.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown3.Location = new Point(0, 44);
      this.numericUpDown3.Maximum = new Decimal(new int[4]
      {
        (int) byte.MaxValue,
        0,
        0,
        0
      });
      this.numericUpDown3.Name = "numericUpDown3";
      this.numericUpDown3.Size = new Size(128, 21);
      this.numericUpDown3.TabIndex = 2;
      this.numericUpDown3.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown4.Increment = new Decimal(new int[4]
      {
        500,
        0,
        0,
        0
      });
      this.numericUpDown4.Location = new Point(0, 73);
      this.numericUpDown4.Maximum = new Decimal(new int[4]
      {
        100000,
        0,
        0,
        0
      });
      this.numericUpDown4.Name = "numericUpDown4";
      this.numericUpDown4.Size = new Size(128, 21);
      this.numericUpDown4.TabIndex = 3;
      this.numericUpDown4.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown5.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown5.Location = new Point(0, 94);
      this.numericUpDown5.Maximum = new Decimal(new int[4]
      {
        10000,
        0,
        0,
        0
      });
      this.numericUpDown5.Name = "numericUpDown5";
      this.numericUpDown5.Size = new Size(128, 21);
      this.numericUpDown5.TabIndex = 4;
      this.numericUpDown5.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown6.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown6.Location = new Point(0, 115);
      this.numericUpDown6.Maximum = new Decimal(new int[4]
      {
        10000,
        0,
        0,
        0
      });
      this.numericUpDown6.Name = "numericUpDown6";
      this.numericUpDown6.Size = new Size(128, 21);
      this.numericUpDown6.TabIndex = 5;
      this.numericUpDown6.TextAlign = HorizontalAlignment.Center;
      this.richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.richTextBox1.Location = new Point(0, 209);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.Size = new Size(128, 272);
      this.richTextBox1.TabIndex = 8;
      this.richTextBox1.Text = "";
      this.numericUpDown7.Increment = new Decimal(new int[4]
      {
        10,
        0,
        0,
        0
      });
      this.numericUpDown7.Location = new Point(0, 136);
      this.numericUpDown7.Maximum = new Decimal(new int[4]
      {
        10000,
        0,
        0,
        0
      });
      this.numericUpDown7.Name = "numericUpDown7";
      this.numericUpDown7.Size = new Size(128, 21);
      this.numericUpDown7.TabIndex = 6;
      this.numericUpDown7.TextAlign = HorizontalAlignment.Center;
      this.numericUpDown8.Increment = new Decimal(new int[4]
      {
        100,
        0,
        0,
        0
      });
      this.numericUpDown8.Location = new Point(0, 157);
      this.numericUpDown8.Maximum = new Decimal(new int[4]
      {
        10000,
        0,
        0,
        0
      });
      this.numericUpDown8.Name = "numericUpDown8";
      this.numericUpDown8.Size = new Size(128, 21);
      this.numericUpDown8.TabIndex = 7;
      this.numericUpDown8.TextAlign = HorizontalAlignment.Center;
      this.listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.listBox1.FormattingEnabled = true;
      this.listBox1.HorizontalScrollbar = true;
      this.listBox1.ItemHeight = 12;
      this.listBox1.Location = new Point(134, 0);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new Size(183, 196);
      this.listBox1.TabIndex = 9;
      this.listBox1.DoubleClick += new EventHandler(this.listBox1_DoubleClick);
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new Point(0, 187);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new Size(96, 16);
      this.checkBox1.TabIndex = 10;
      this.checkBox1.Text = "显示判定范围";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.treeView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.treeView1.Location = new Point(134, 209);
      this.treeView1.Name = "treeView1";
      this.treeView1.Size = new Size(183, 272);
      this.treeView1.TabIndex = 11;
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(318, 480);
      this.Controls.Add((Control) this.treeView1);
      this.Controls.Add((Control) this.checkBox1);
      this.Controls.Add((Control) this.listBox1);
      this.Controls.Add((Control) this.numericUpDown8);
      this.Controls.Add((Control) this.numericUpDown7);
      this.Controls.Add((Control) this.richTextBox1);
      this.Controls.Add((Control) this.numericUpDown4);
      this.Controls.Add((Control) this.numericUpDown5);
      this.Controls.Add((Control) this.numericUpDown6);
      this.Controls.Add((Control) this.numericUpDown3);
      this.Controls.Add((Control) this.numericUpDown2);
      this.Controls.Add((Control) this.numericUpDown1);
      this.Name = nameof (Form_Test);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Test";
      this.Load += new EventHandler(this.Form_Test_Load);
      this.numericUpDown1.EndInit();
      this.numericUpDown2.EndInit();
      this.numericUpDown3.EndInit();
      this.numericUpDown4.EndInit();
      this.numericUpDown5.EndInit();
      this.numericUpDown6.EndInit();
      this.numericUpDown7.EndInit();
      this.numericUpDown8.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public int Para1
    {
      get
      {
        return (int) this.numericUpDown1.Value;
      }
    }

    public int Para2
    {
      get
      {
        return (int) this.numericUpDown2.Value;
      }
    }

    public int Para3
    {
      get
      {
        return (int) this.numericUpDown3.Value;
      }
    }

    public int Para4
    {
      get
      {
        return (int) this.numericUpDown4.Value;
      }
    }

    public int Para5
    {
      get
      {
        return (int) this.numericUpDown5.Value;
      }
    }

    public int Para6
    {
      get
      {
        return (int) this.numericUpDown6.Value;
      }
    }

    public int Para7
    {
      get
      {
        return (int) this.numericUpDown7.Value;
      }
    }

    public int Para8
    {
      get
      {
        return (int) this.numericUpDown8.Value;
      }
    }

    public Form_Test()
    {
      this.InitializeComponent();
      this.folderBrowserDialog1.SelectedPath = Application.StartupPath + "\\CS";
    }

    private void Form_Test_Load(object sender, EventArgs e)
    {
      Point location = this.Location;
      int x = location.X + 325 + this.Width / 2;
      location = this.Location;
      int y = location.Y;
      this.Location = new Point(x, y);
    }

    public void SendString(string s)
    {
      this.richTextBox1.Text += s;
      this.richTextBox1.Text += (string) (object) '\n';
    }

    private void listBox1_DoubleClick(object sender, EventArgs e)
    {
      if (DialogResult.OK != this.folderBrowserDialog1.ShowDialog())
        return;
      this.listBox1.Items.Clear();
      foreach (string file in Directory.GetFiles(this.folderBrowserDialog1.SelectedPath, "*.mbg"))
        this.listBox1.Items.Add((object) new FileInfo(file).Name);
      if (this.listBox1.Items.Count > 0)
        this.listBox1.SelectedIndex = 0;
    }
  }
}
