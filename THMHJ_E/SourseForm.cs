using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace THMHJ {
    public partial class SourseForm:Form {
        public static int life = 40;
        public static int spell = 10;
        public static int power = 200;
        public static int highItemScore = 0;
        public static int specialPower = 0;
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
        private void tbPowerTextChange(object sender,EventArgs e) {
            try {
                power=Convert.ToInt32(tbPower.Text)/2;
            } catch(Exception eb) {
                power=100;
            }
        }

        private void tbMaxPointTextChanged(object sender,EventArgs e) {
            try {
                highItemScore=Convert.ToInt32(tbHighItemScore.Text)-10000;
            } catch(Exception eb) {
                highItemScore=0;
            }
        }

        private void tbSpecialTextChanged(object sender,EventArgs e) {
            try {
                specialPower=Convert.ToInt32(tbSpecial.Text);
            } catch(Exception eb) {
                specialPower=0;
            }
        }
    }
}
