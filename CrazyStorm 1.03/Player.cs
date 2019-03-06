using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyStorm_1._03 {
    internal class Player {
        public static PointF position = new PointF(315f,300f);
        private static float alpha = 1f;
        public static int time = 0;
        public static bool Dis; //敌方单位碰撞

        public static void Clear() {
            position=new PointF(315f,300f);
            alpha=1f;
            Dis=false;
            time=0;
        }

        public static void Update() {
            if(!Time.Playing)
                return;
            if(Dis) {
                ++time;
                if(time<=40) {
                    return;
                }
                Dis=false;
            } else {
                time=0;
            }
        }

        public static void Draw(SpriteBatch s) {
            if(!(Time.Playing&!Dis))
                return;
            s.Draw(Main.player,new Vector2(position.X,position.Y),new Rectangle?(),new Color(1f,1f,1f,alpha),0.0f,new Vector2(4.5f,4.5f),1f,SpriteEffects.None,1f);
        }
    }
}
