namespace THMHJ {
    partial class SourseForm {
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
            this.tbLife = new System.Windows.Forms.TextBox();
            this.tbSpell = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPower = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbHighItemScore = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSpecial = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbLife
            // 
            this.tbLife.Location = new System.Drawing.Point(71, 10);
            this.tbLife.Name = "tbLife";
            this.tbLife.Size = new System.Drawing.Size(57, 21);
            this.tbLife.TabIndex = 0;
            this.tbLife.TextChanged += new System.EventHandler(this.lifeTextChaged);
            // 
            // tbSpell
            // 
            this.tbSpell.Location = new System.Drawing.Point(71, 37);
            this.tbSpell.Name = "tbSpell";
            this.tbSpell.Size = new System.Drawing.Size(57, 21);
            this.tbSpell.TabIndex = 1;
            this.tbSpell.TextChanged += new System.EventHandler(this.spellTextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "残机";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "雷";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "火力";
            // 
            // tbPower
            // 
            this.tbPower.Location = new System.Drawing.Point(71, 64);
            this.tbPower.Name = "tbPower";
            this.tbPower.Size = new System.Drawing.Size(57, 21);
            this.tbPower.TabIndex = 7;
            this.tbPower.TextChanged += new System.EventHandler(this.tbPowerTextChange);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "得点";
            // 
            // tbHighItemScore
            // 
            this.tbHighItemScore.Location = new System.Drawing.Point(71, 91);
            this.tbHighItemScore.Name = "tbHighItemScore";
            this.tbHighItemScore.Size = new System.Drawing.Size(57, 21);
            this.tbHighItemScore.TabIndex = 9;
            this.tbHighItemScore.TextChanged += new System.EventHandler(this.tbMaxPointTextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "特殊系统";
            // 
            // tbSpecial
            // 
            this.tbSpecial.Location = new System.Drawing.Point(71, 118);
            this.tbSpecial.Name = "tbSpecial";
            this.tbSpecial.Size = new System.Drawing.Size(57, 21);
            this.tbSpecial.TabIndex = 12;
            this.tbSpecial.TextChanged += new System.EventHandler(this.tbSpecialTextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(146, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 120);
            this.label6.TabIndex = 14;
            this.label6.Text = "残:残机*5+残机碎片\r\n\r\n雷:雷*5+雷碎片\r\n\r\n特殊系统:\r\nE:0-1500\r\nN:0-1380\r\nH:0-1260\r\nL:0-1140\r\nEx:0-1" +
    "020\r\n";
            // 
            // SourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 160);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSpecial);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbHighItemScore);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPower);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSpell);
            this.Controls.Add(this.tbLife);
            this.Name = "SourseForm";
            this.Text = "发发发";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLife;
        private System.Windows.Forms.TextBox tbSpell;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPower;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbHighItemScore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSpecial;
        private System.Windows.Forms.Label label6;
    }
}