using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;

namespace CrazyStorm_1._03 {
    internal class Player {
        public static Vector2 position = new Vector2(316f,401f);
        private static float alpha = 1f;
        private static int guru = 0;
        public static int time = 0;
        public static bool Dis;
        public static int add;
        public static int addy;

        public static void Clear() {
            position=new Vector2(316f,401f);
            alpha=1f;
            guru=0;
            Dis=false;
            time=0;
        }

        public static void Update() {
            if(!Time.Playing)
                return;
            --Player.guru;
            if(Player.guru<=-360)
                Player.guru=0;
            Player.add=140;
            Player.addy=16;
            if((double)Player.position.X>=4.5+(double)Player.add&(double)Player.position.X<=(double)(630-Player.add)&(double)Player.position.Y>=4.5&(double)Player.position.Y<=475.5&!Player.Dis) {
                int num = -1;
                if(Main.keyboardstat.IsKeyDown(Keys.Up))
                    num=-90;
                if(Main.keyboardstat.IsKeyDown(Keys.Down))
                    num=90;
                if(Main.keyboardstat.IsKeyDown(Keys.Left)) {
                    num=180;
                    if(Main.keyboardstat.IsKeyDown(Keys.Up))
                        num=225;
                    if(Main.keyboardstat.IsKeyDown(Keys.Down))
                        num=135;
                }
                if(Main.keyboardstat.IsKeyDown(Keys.Right)) {
                    num=0;
                    if(Main.keyboardstat.IsKeyDown(Keys.Up))
                        num=-45;
                    if(Main.keyboardstat.IsKeyDown(Keys.Down))
                        num=45;
                }
                if(num!=-1) {
                    if(Main.keyboardstat.IsKeyDown(Keys.LeftShift)||Main.keyboardstat.IsKeyDown(Keys.RightShift)) {
                        Player.position.X+=(float)(1.89999997615814*Math.Cos((double)num*Math.PI/180.0))*Time.stop;
                        Player.position.Y+=(float)(1.89999997615814*Math.Sin((double)num*Math.PI/180.0))*Time.stop;
                    } else {
                        Player.position.X+=(float)(3.59999990463257*Math.Cos((double)num*Math.PI/180.0))*Time.stop;
                        Player.position.Y+=(float)(3.59999990463257*Math.Sin((double)num*Math.PI/180.0))*Time.stop;
                    }
                }
                if((double)Player.position.X<=4.5+(double)Player.add)
                    Player.position.X=4.5f+(float)Player.add;
                if(Player.add!=0) {
                    if((double)Player.position.X>=628.5-(double)Player.add)
                        Player.position.X=628.5f-(float)Player.add;
                } else if((double)Player.position.X>=625.5)
                    Player.position.X=625.5f;
                if((double)Player.position.Y<=4.5+(double)Player.addy)
                    Player.position.Y=4.5f+(float)Player.addy;
                if((double)Player.position.Y>=475.5-(double)Player.addy)
                    Player.position.Y=475.5f-(float)Player.addy;
            }
            if(Player.Dis) {
                ++Player.time;
                if(Player.time<=40)
                    return;
                Player.Dis=false;
            } else
                Player.time=0;
        }

        public static void Draw(SpriteBatch s) {
            if(!(Time.Playing&!Player.Dis))
                return;
            s.Draw(Main.player,new Vector2(Player.position.X+170f+Time.quake.X,Player.position.Y+22f+Time.quake.Y),new Rectangle?(),new Color(1f,1f,1f,Player.alpha),0.0f,new Vector2(4.5f,4.5f),1f,SpriteEffects.None,1f);
            if(!Main.keyboardstat.IsKeyDown(Keys.LeftShift)&&!Main.keyboardstat.IsKeyDown(Keys.RightShift))
                return;
            s.Draw(Main.playerc,new Vector2(Player.position.X+170f+Time.quake.X,Player.position.Y+22f+Time.quake.Y),new Rectangle?(),new Color(1f,1f,1f,Player.alpha),MathHelper.ToRadians((float)Player.guru),new Vector2(32f,32f),1f,SpriteEffects.None,1f);
        }
    }
}
