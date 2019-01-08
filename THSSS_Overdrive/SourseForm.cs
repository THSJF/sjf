using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shooting {
    public partial class SourseForm:Form {
        public static int life = 8;
        public static int lifeUpCount = 0;
        public static int lifeChip = 0;
        public static int spell = 8;
        public static int spellChip = 0;
        public static int power = 400;
        public static int highItemScore = 100;
        public static int starPoint = 0;
        public static long score = 0;
        public static EnchantmentType starColor = EnchantmentType.Green;
        public SourseForm() {
            InitializeComponent();
        }

        private void lifeTextChaged(object sender,EventArgs e) {
            try {
                life=Convert.ToInt32(tbLife.Text);
            } catch {
                life=8;
            }
        }

        private void spellTextChanged(object sender,EventArgs e) {
            try {
                spell=Convert.ToInt32(tbSpell.Text);
            } catch {
                spell=2;
            }
        }


        private void lifeChipTextChanged(object sender,EventArgs e) {
            try {
                lifeChip=Convert.ToInt32(tbLifeChip.Text);
            } catch {
                lifeChip=0;
            }
        }

        private void spellChipTextChanged(object sender,EventArgs e) {
            try {
                spellChip=Convert.ToInt32(tbSpellChip.Text);
            } catch {
                spellChip=0;
            }
        }

        private void tbLifeUpCountTextChange(object sender,EventArgs e) {
            try {
                lifeUpCount=Convert.ToInt32(tbLifeUpCount.Text);
            } catch {
                lifeUpCount=0;
            }
        }

        private void tbPowerTextChange(object sender,EventArgs e) {
            try {
                power=Convert.ToInt32(tbPower.Text);
            } catch {
                power=100;
            }
        }

        private void tbMaxPointTextChanged(object sender,EventArgs e) {
            try {
                highItemScore=Convert.ToInt32(tbHighItemScore.Text);
            } catch {
                highItemScore=10000;
            }
        }


        private void tbStarPointTextchanged(object sender,EventArgs e) {
            try {
                starPoint=Convert.ToInt32(tbStarPoint.Text);
            } catch {
                starPoint=0;
            }
        }

        private void starColorList(object sender,EventArgs e) {
            switch(comboBoxStarColor.Text) {
                case "红": starColor=EnchantmentType.Red; break;
                case "绿": starColor=EnchantmentType.Green; break;
                case "蓝": starColor=EnchantmentType.Blue; break;
            }
        }

        private void tbScoreTextChange(object sender,EventArgs e) {
            try {
                score=Convert.ToInt32(tbScore.Text);
            } catch {
                score=0;
            }
        }
    }
}
