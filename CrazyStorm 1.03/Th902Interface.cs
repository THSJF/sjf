using System.Collections.Generic;
using System.Linq;

namespace CrazyStorm_1._03 {
    class Th902Interface {
        public static List<Barrage> bullets = new List<Barrage>();
        public static List<Barrage> getBulletInfo() {
            return bullets;
        }

        public static int getBulletCount() {
            return bullets.Count();
        }

        public static void openDanmakuFile(string mbgPath) {
            Main.Open(mbgPath);
        }

        public static void update() {
            Main.updateAll();
        }

        public static PointF getPalyerPosition() {
            return Player.position;
        }

        public static void setPlayerX(float x) {
            Player.position.X=x;
        }

        public static void setPlayerY(float y) {
            Player.position.Y=y;
        }

        public static void setPlayerPosition(float x,float y) {
            Player.position.X=x;
            Player.position.Y=y;
        }
    }
}
