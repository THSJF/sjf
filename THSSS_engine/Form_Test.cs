using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Shooting {
    public class Form_Test:Form {
        private IContainer components = null;
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
        protected override void Dispose(bool disposing) {
            if(disposing&&components!=null) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent() {
            numericUpDown1=new NumericUpDown();
            numericUpDown2=new NumericUpDown();
            numericUpDown3=new NumericUpDown();
            numericUpDown4=new NumericUpDown();
            numericUpDown5=new NumericUpDown();
            numericUpDown6=new NumericUpDown();
            richTextBox1=new RichTextBox();
            numericUpDown7=new NumericUpDown();
            numericUpDown8=new NumericUpDown();
            listBox1=new ListBox();
            checkBox1=new CheckBox();
            folderBrowserDialog1=new FolderBrowserDialog();
            treeView1=new TreeView();
            numericUpDown1.BeginInit();
            numericUpDown2.BeginInit();
            numericUpDown3.BeginInit();
            numericUpDown4.BeginInit();
            numericUpDown5.BeginInit();
            numericUpDown6.BeginInit();
            numericUpDown7.BeginInit();
            numericUpDown8.BeginInit();
            SuspendLayout();
            numericUpDown1.Location=new Point(0,0);
            numericUpDown1.Maximum=new Decimal(new int[4] { byte.MaxValue,0,0,0 });
            numericUpDown1.Name="numericUpDown1";
            numericUpDown1.Size=new Size(128,21);
            numericUpDown1.TabIndex=0;
            numericUpDown1.TextAlign=HorizontalAlignment.Center;
            numericUpDown2.Location=new Point(0,22);
            numericUpDown2.Maximum=new Decimal(new int[4] { byte.MaxValue,0,0,0 });
            numericUpDown2.Name="numericUpDown2";
            numericUpDown2.Size=new Size(128,21);
            numericUpDown2.TabIndex=1;
            numericUpDown2.TextAlign=HorizontalAlignment.Center;
            numericUpDown3.Location=new Point(0,44);
            numericUpDown3.Maximum=new Decimal(new int[4] { byte.MaxValue,0,0,0 });
            numericUpDown3.Name="numericUpDown3";
            numericUpDown3.Size=new Size(128,21);
            numericUpDown3.TabIndex=2;
            numericUpDown3.TextAlign=HorizontalAlignment.Center;
            numericUpDown4.Increment=new Decimal(new int[4] { 500,0,0,0 });
            numericUpDown4.Location=new Point(0,73);
            numericUpDown4.Maximum=new Decimal(new int[4] { 100000,0,0,0 });
            numericUpDown4.Name="numericUpDown4";
            numericUpDown4.Size=new Size(128,21);
            numericUpDown4.TabIndex=3;
            numericUpDown4.TextAlign=HorizontalAlignment.Center;
            numericUpDown5.Increment=new Decimal(new int[4] { 10,0,0,0 });
            numericUpDown5.Location=new Point(0,94);
            numericUpDown5.Maximum=new Decimal(new int[4] { 10000,0,0,0 });
            numericUpDown5.Name="numericUpDown5";
            numericUpDown5.Size=new Size(128,21);
            numericUpDown5.TabIndex=4;
            numericUpDown5.TextAlign=HorizontalAlignment.Center;
            numericUpDown6.Increment=new Decimal(new int[4] { 10,0,0,0 });
            numericUpDown6.Location=new Point(0,115);
            numericUpDown6.Maximum=new Decimal(new int[4] { 10000,0,0,0 });
            numericUpDown6.Name="numericUpDown6";
            numericUpDown6.Size=new Size(128,21);
            numericUpDown6.TabIndex=5;
            numericUpDown6.TextAlign=HorizontalAlignment.Center;
            richTextBox1.Anchor=AnchorStyles.Top|AnchorStyles.Bottom|AnchorStyles.Left;
            richTextBox1.Location=new Point(0,209);
            richTextBox1.Name="richTextBox1";
            richTextBox1.Size=new Size(128,272);
            richTextBox1.TabIndex=8;
            richTextBox1.Text="";
            numericUpDown7.Increment=new Decimal(new int[4] { 10,0,0,0 });
            numericUpDown7.Location=new Point(0,136);
            numericUpDown7.Maximum=new Decimal(new int[4] { 10000,0,0,0 });
            numericUpDown7.Name="numericUpDown7";
            numericUpDown7.Size=new Size(128,21);
            numericUpDown7.TabIndex=6;
            numericUpDown7.TextAlign=HorizontalAlignment.Center;
            numericUpDown8.Increment=new Decimal(new int[4] { 100,0,0,0 });
            numericUpDown8.Location=new Point(0,157);
            numericUpDown8.Maximum=new Decimal(new int[4] { 10000,0,0,0 });
            numericUpDown8.Name="numericUpDown8";
            numericUpDown8.Size=new Size(128,21);
            numericUpDown8.TabIndex=7;
            numericUpDown8.TextAlign=HorizontalAlignment.Center;
            listBox1.Anchor=AnchorStyles.Top|AnchorStyles.Left|AnchorStyles.Right;
            listBox1.FormattingEnabled=true;
            listBox1.HorizontalScrollbar=true;
            listBox1.ItemHeight=12;
            listBox1.Location=new Point(134,0);
            listBox1.Name="listBox1";
            listBox1.Size=new Size(183,196);
            listBox1.TabIndex=9;
            listBox1.DoubleClick+=new EventHandler(listBox1_DoubleClick);
            checkBox1.AutoSize=true;
            checkBox1.Location=new Point(0,187);
            checkBox1.Name="checkBox1";
            checkBox1.Size=new Size(96,16);
            checkBox1.TabIndex=10;
            checkBox1.Text="显示判定范围";
            checkBox1.UseVisualStyleBackColor=true;
            treeView1.Anchor=AnchorStyles.Top|AnchorStyles.Bottom|AnchorStyles.Left|AnchorStyles.Right;
            treeView1.Location=new Point(134,209);
            treeView1.Name="treeView1";
            treeView1.Size=new Size(183,272);
            treeView1.TabIndex=11;
            AutoScaleDimensions=new SizeF(6f,12f);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(318,480);
            Controls.Add(treeView1);
            Controls.Add(checkBox1);
            Controls.Add(listBox1);
            Controls.Add(numericUpDown8);
            Controls.Add(numericUpDown7);
            Controls.Add(richTextBox1);
            Controls.Add(numericUpDown4);
            Controls.Add(numericUpDown5);
            Controls.Add(numericUpDown6);
            Controls.Add(numericUpDown3);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Name=nameof(Form_Test);
            StartPosition=FormStartPosition.CenterScreen;
            Text="Test";
            Load+=new EventHandler(Form_Test_Load);
            numericUpDown1.EndInit();
            numericUpDown2.EndInit();
            numericUpDown3.EndInit();
            numericUpDown4.EndInit();
            numericUpDown5.EndInit();
            numericUpDown6.EndInit();
            numericUpDown7.EndInit();
            numericUpDown8.EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        public int Para1 => (int)numericUpDown1.Value;
        public int Para2 => (int)numericUpDown2.Value;
        public int Para3 => (int)numericUpDown3.Value;
        public int Para4 => (int)numericUpDown4.Value;
        public int Para5 => (int)numericUpDown5.Value;
        public int Para6 => (int)numericUpDown6.Value;
        public int Para7 => (int)numericUpDown7.Value;
        public int Para8 => (int)numericUpDown8.Value;
        public Form_Test() {
            InitializeComponent();
            folderBrowserDialog1.SelectedPath=Application.StartupPath+"\\CS";
        }
        private void Form_Test_Load(object sender,EventArgs e) {
            Point location = Location;
            int x = location.X+325+Width/2;
            location=Location;
            int y = location.Y;
            Location=new Point(x,y);
        }
        public void SendString(string s) {
            richTextBox1.Text+=s;
            richTextBox1.Text+=(string)(object)'\n';
        }
        private void listBox1_DoubleClick(object sender,EventArgs e) {
            if(DialogResult.OK!=folderBrowserDialog1.ShowDialog()) return;
            listBox1.Items.Clear();
            foreach(string file in Directory.GetFiles(folderBrowserDialog1.SelectedPath,"*.mbg")) {
                listBox1.Items.Add(new FileInfo(file).Name);
            }
            if(listBox1.Items.Count>0) listBox1.SelectedIndex=0;
        }
    }
}
