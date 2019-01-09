using SlimDX.Windows;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Shooting {
    internal static class Program {
        [STAThread]
        private static void Main() {
            bool createdNew;
            Mutex mutex = new Mutex(false,"AA",out createdNew);
            if(createdNew) {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Game_Main gameMain = new Game_Main();
                if(!gameMain.initSuccess) {
                    return;
                }
                MessagePump.Run(gameMain.Form_Main,new MainLoop(gameMain.MainProcess));
            } else {
                MessageBox.Show("东方白丝祭(误)已启动，\r\n程序不允许双开。","程序已启动");
            }
        }
    }
}
