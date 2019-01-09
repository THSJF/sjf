using System.Runtime.InteropServices;

namespace Shooting {
    public class MouseCtrl {
        [DllImport("user32.dll",CharSet = CharSet.Auto)]
        private static extern int ShowCursor(bool bShow);
        public static void DrawCursor(bool cursorShow) {
            if(cursorShow) {
                do { } while(ShowCursor(true)<0);
            } else {
                do { } while(ShowCursor(false)>=0);
            }
        }
    }
}
