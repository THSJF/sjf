using System;
using System.Windows.Forms;

namespace CrazyStorm_1._03 {
    internal static class Program {
        public static Main game;

        [STAThread]
        public static void Main(string[] args) {
            using(game=new Main()) {
                game.IsMouseVisible=true;
                game.IsFixedTimeStep=false;
                try {
                    game.InactiveSleepTime=new TimeSpan(0,0,0);
                    game.Run();
                } catch(Exception ex) {
                    MessageBox.Show(ex.ToString(),"错误",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                }
            }
        }
    }
}
