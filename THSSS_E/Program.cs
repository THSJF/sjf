// Decompiled with JetBrains decompiler
// Type: Shooting.Program
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

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
