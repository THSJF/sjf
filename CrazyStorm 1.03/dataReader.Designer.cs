namespace CrazyStorm_1._03 {
    partial class dataReader {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing&&(components!=null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bulletCount = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.top = new System.Windows.Forms.Button();
            this.left = new System.Windows.Forms.Button();
            this.right = new System.Windows.Forms.Button();
            this.bottom = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.start = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 16;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bulletCount
            // 
            this.bulletCount.AutoSize = true;
            this.bulletCount.Location = new System.Drawing.Point(13, 13);
            this.bulletCount.Name = "bulletCount";
            this.bulletCount.Size = new System.Drawing.Size(41, 12);
            this.bulletCount.TabIndex = 0;
            this.bulletCount.Text = "label1";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // top
            // 
            this.top.Location = new System.Drawing.Point(73, 20);
            this.top.Name = "top";
            this.top.Size = new System.Drawing.Size(46, 22);
            this.top.TabIndex = 2;
            this.top.Text = "up";
            this.top.UseVisualStyleBackColor = true;
            this.top.Click += new System.EventHandler(this.top_Click);
            // 
            // left
            // 
            this.left.Location = new System.Drawing.Point(22, 40);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(52, 21);
            this.left.TabIndex = 3;
            this.left.Text = "left";
            this.left.UseVisualStyleBackColor = true;
            this.left.Click += new System.EventHandler(this.left_Click);
            // 
            // right
            // 
            this.right.Location = new System.Drawing.Point(119, 41);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(50, 21);
            this.right.TabIndex = 4;
            this.right.Text = "right";
            this.right.UseVisualStyleBackColor = true;
            this.right.Click += new System.EventHandler(this.right_Click);
            // 
            // bottom
            // 
            this.bottom.Location = new System.Drawing.Point(75, 59);
            this.bottom.Name = "bottom";
            this.bottom.Size = new System.Drawing.Size(46, 23);
            this.bottom.TabIndex = 5;
            this.bottom.Text = "down";
            this.bottom.UseVisualStyleBackColor = true;
            this.bottom.Click += new System.EventHandler(this.bottom_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.top);
            this.groupBox1.Controls.Add(this.left);
            this.groupBox1.Controls.Add(this.bottom);
            this.groupBox1.Controls.Add(this.right);
            this.groupBox1.Location = new System.Drawing.Point(89, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 97);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(15, 65);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(46, 22);
            this.start.TabIndex = 6;
            this.start.Text = "start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // dataReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 143);
            this.Controls.Add(this.start);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bulletCount);
            this.Name = "dataReader";
            this.Text = "dataReader";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label bulletCount;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button top;
        private System.Windows.Forms.Button left;
        private System.Windows.Forms.Button right;
        private System.Windows.Forms.Button bottom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button start;
    }
}