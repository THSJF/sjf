using System;
using System.Windows.Forms;

namespace Shooting {
    public partial class SourseForm:Form {
        public static int life = 8;
        public static int lifeUpCount = 0;
        public static int lifeChip = 0;
        public static int spell = 2;
        public static int spellChip = 0;
        public static int power = 100;
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
            } catch(Exception el) {
                life=8;
            }
        }

        private void spellTextChanged(object sender,EventArgs e) {
            try {
                spell=Convert.ToInt32(tbSpell.Text);
            } catch(Exception eb) {
                spell=2;
            }
        }
        

        private void lifeChipTextChanged(object sender,EventArgs e) {
            try {
                lifeChip=Convert.ToInt32(tbLifeChip.Text);
            } catch(Exception el) {
                lifeChip=0;
            }
        }

        private void spellChipTextChanged(object sender,EventArgs e) {
            try {
                spellChip=Convert.ToInt32(tbSpellChip.Text);
            } catch(Exception eb) {
                spellChip=0;
            }
        }

        private void tbLifeUpCountTextChange(object sender,EventArgs e) {
            try {
                lifeUpCount=Convert.ToInt32(tbLifeUpCount.Text);
            } catch(Exception eb) {
                lifeUpCount=0;
            }
        }

        private void tbPowerTextChange(object sender,EventArgs e) {
            try {
                power=Convert.ToInt32(tbPower.Text);
            } catch(Exception eb) {
                power=100;
            }
        }

        private void tbMaxPointTextChanged(object sender,EventArgs e) {
            try {
                highItemScore=Convert.ToInt32(tbHighItemScore.Text);
            } catch(Exception eb) {
                highItemScore=10000;
            }
        }
        

        private void tbStarPointTextchanged(object sender,EventArgs e) {
            try {
                starPoint=Convert.ToInt32(tbStarPoint.Text);
            } catch(Exception eb) {
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
            } catch(Exception eb) {
                score=0;
            }
        }
    }
}
