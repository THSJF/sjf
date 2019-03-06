using System;
using System.Windows.Forms;

namespace CrazyStorm_1._03 {
    public partial class dataReader:Form {
        public dataReader() {
            InitializeComponent();
        }
        private int lastFrame = 0;
        private void timer1_Tick(object sender,EventArgs e) {
            bulletCount.Text="bullet:"+Th902Interface.getBulletCount();
        }

        private void timer2_Tick(object sender,EventArgs e) {
            Th902Interface.update();
        }

        private void timer3_Tick(object sender,EventArgs e) {
            label1.Text="FPS:"+(Main.FPS-lastFrame);
            lastFrame=Main.FPS;
        }

        private void top_Click(object sender,EventArgs e) {
            Th902Interface.getPalyerPosition().Y-=5;
        }

        private void bottom_Click(object sender,EventArgs e) {
            Th902Interface.getPalyerPosition().Y+=5;
        }

        private void left_Click(object sender,EventArgs e) {
            Th902Interface.getPalyerPosition().X-=5;
        }

        private void right_Click(object sender,EventArgs e) {
            Th902Interface.getPalyerPosition().X+=5;
        }

        private void start_Click(object sender,EventArgs e) {
            Th902Interface.openDanmakuFile(@"D:\th902\th902-main\src\resources\Danmaku\里冬.mbg");
        }
    }
}
