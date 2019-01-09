namespace Shooting {
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
            this.tbSpellChip = new System.Windows.Forms.TextBox();
            this.tbLifeChip = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPower = new System.Windows.Forms.TextBox();
            this.tbLifeUpCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbStarPoint = new System.Windows.Forms.TextBox();
            this.tbHighItemScore = new System.Windows.Forms.TextBox();
            this.comboBoxStarColor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbScore = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbLife
            // 
            this.tbLife.Location = new System.Drawing.Point(62, 10);
            this.tbLife.Name = "tbLife";
            this.tbLife.Size = new System.Drawing.Size(57, 21);
            this.tbLife.TabIndex = 0;
            this.tbLife.TextChanged += new System.EventHandler(this.lifeTextChaged);
            // 
            // tbSpell
            // 
            this.tbSpell.Location = new System.Drawing.Point(62, 64);
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
            this.label1.Size = new System.Drawing.Size(29, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "残机\r\n\r\n残碎";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 36);
            this.label2.TabIndex = 5;
            this.label2.Text = "雷\r\n\r\n雷碎";
            // 
            // tbSpellChip
            // 
            this.tbSpellChip.Location = new System.Drawing.Point(62, 91);
            this.tbSpellChip.Name = "tbSpellChip";
            this.tbSpellChip.Size = new System.Drawing.Size(57, 21);
            this.tbSpellChip.TabIndex = 4;
            this.tbSpellChip.TextChanged += new System.EventHandler(this.spellChipTextChanged);
            // 
            // tbLifeChip
            // 
            this.tbLifeChip.Location = new System.Drawing.Point(62, 37);
            this.tbLifeChip.Name = "tbLifeChip";
            this.tbLifeChip.Size = new System.Drawing.Size(57, 21);
            this.tbLifeChip.TabIndex = 3;
            this.tbLifeChip.TextChanged += new System.EventHandler(this.lifeChipTextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(137, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 36);
            this.label3.TabIndex = 8;
            this.label3.Text = "已奖残\r\n\r\n火力";
            // 
            // tbPower
            // 
            this.tbPower.Location = new System.Drawing.Point(186, 37);
            this.tbPower.Name = "tbPower";
            this.tbPower.Size = new System.Drawing.Size(57, 21);
            this.tbPower.TabIndex = 7;
            this.tbPower.TextChanged += new System.EventHandler(this.tbPowerTextChange);
            // 
            // tbLifeUpCount
            // 
            this.tbLifeUpCount.Location = new System.Drawing.Point(186, 10);
            this.tbLifeUpCount.Name = "tbLifeUpCount";
            this.tbLifeUpCount.Size = new System.Drawing.Size(57, 21);
            this.tbLifeUpCount.TabIndex = 6;
            this.tbLifeUpCount.TextChanged += new System.EventHandler(this.tbLifeUpCountTextChange);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(137, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 36);
            this.label4.TabIndex = 11;
            this.label4.Text = "得点\r\n\r\n星星槽";
            // 
            // tbStarPoint
            // 
            this.tbStarPoint.Location = new System.Drawing.Point(186, 91);
            this.tbStarPoint.Name = "tbStarPoint";
            this.tbStarPoint.Size = new System.Drawing.Size(57, 21);
            this.tbStarPoint.TabIndex = 10;
            this.tbStarPoint.TextChanged += new System.EventHandler(this.tbStarPointTextchanged);
            // 
            // tbHighItemScore
            // 
            this.tbHighItemScore.Location = new System.Drawing.Point(186, 64);
            this.tbHighItemScore.Name = "tbHighItemScore";
            this.tbHighItemScore.Size = new System.Drawing.Size(57, 21);
            this.tbHighItemScore.TabIndex = 9;
            this.tbHighItemScore.TextChanged += new System.EventHandler(this.tbMaxPointTextChanged);
            // 
            // comboBoxStarColor
            // 
            this.comboBoxStarColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStarColor.FormattingEnabled = true;
            this.comboBoxStarColor.Items.AddRange(new object[] {
            "红",
            "绿",
            "蓝"});
            this.comboBoxStarColor.Location = new System.Drawing.Point(84, 122);
            this.comboBoxStarColor.Name = "comboBoxStarColor";
            this.comboBoxStarColor.Size = new System.Drawing.Size(57, 20);
            this.comboBoxStarColor.TabIndex = 12;
            this.comboBoxStarColor.DropDownClosed += new System.EventHandler(this.starColorList);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "星星槽颜色";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "星星槽的值为0-3000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(147, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "分数";
            // 
            // tbScore
            // 
            this.tbScore.Location = new System.Drawing.Point(186, 122);
            this.tbScore.Name = "tbScore";
            this.tbScore.Size = new System.Drawing.Size(57, 21);
            this.tbScore.TabIndex = 15;
            this.tbScore.TextChanged += new System.EventHandler(this.tbScoreTextChange);
            // 
            // SourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 186);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbScore);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxStarColor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbStarPoint);
            this.Controls.Add(this.tbHighItemScore);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPower);
            this.Controls.Add(this.tbLifeUpCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSpellChip);
            this.Controls.Add(this.tbLifeChip);
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
        private System.Windows.Forms.TextBox tbSpellChip;
        private System.Windows.Forms.TextBox tbLifeChip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPower;
        private System.Windows.Forms.TextBox tbLifeUpCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbStarPoint;
        private System.Windows.Forms.TextBox tbHighItemScore;
        private System.Windows.Forms.ComboBox comboBoxStarColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbScore;
    }
}