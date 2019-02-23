using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;

namespace CrazyStorm_1._03 {
    internal class Player {
        public static Vector2 position = new Vector2(233,100);
        private static float alpha = 1f;
        private static int guru = 0;
        public static int time = 0;
        public static bool Dis;
        public static int add;
        public static int addy;

        public static void Clear() {
            position=new Vector2(233,100);
            alpha=1f;
            guru=0;
            Dis=false;
            time=0;
        }

        public static void Update() {
            if(!Time.Playing) {
                return;
            }
            --guru;
            if(guru<=-360) {
                guru=0;
            }
            add=0;
            addy=0;
            if(position.X>=0.5f&position.X<=564.5f&position.Y>=0.5f&position.Y<=719.5f&!Dis) {
                int num = -1;
                if(Main.keyboardstat.IsKeyDown(Keys.Up)) {
                    num=-90;
                }
                if(Main.keyboardstat.IsKeyDown(Keys.Down)) {
                    num=90;
                }
                if(Main.keyboardstat.IsKeyDown(Keys.Left)) {
                    num=180;
                    if(Main.keyboardstat.IsKeyDown(Keys.Up)) {
                        num=225;
                    }
                    if(Main.keyboardstat.IsKeyDown(Keys.Down)) {
                        num=135;
                    }
                }
                if(Main.keyboardstat.IsKeyDown(Keys.Right)) {
                    num=0;
                    if(Main.keyboardstat.IsKeyDown(Keys.Up)) {
                        num=-45;
                    }
                    if(Main.keyboardstat.IsKeyDown(Keys.Down)) {
                        num=45;
                    }
                }
                if(num!=-1) {
                    if(Main.keyboardstat.IsKeyDown(Keys.LeftShift)||Main.keyboardstat.IsKeyDown(Keys.RightShift)) {
                        position.X+=(float)(1.89999997615814*Math.Cos(num*Math.PI/180.0))*Time.stop;
                        position.Y+=(float)(1.89999997615814*Math.Sin(num*Math.PI/180.0))*Time.stop;
                    } else {
                        position.X+=(float)(3.59999990463257*Math.Cos(num*Math.PI/180.0))*Time.stop;
                        position.Y+=(float)(3.59999990463257*Math.Sin(num*Math.PI/180.0))*Time.stop;
                    }
                }
                if(position.X<=0.5f) {
                    position.X=0.5f;
                }
                if(position.X>=564.5f) {
                    position.X=564.5f;
                }
                if(position.Y<=0.5f) {
                    position.Y=0.5f;
                }
                if(position.Y>=719.5f) {
                    position.Y=719.5f;
                }
            }
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
            if(!(Time.Playing&!Dis)) {
                return;
            }
            s.Draw(Main.player,new Vector2(position.X,position.Y),new Rectangle?(),new Color(1f,1f,1f,alpha),0.0f,new Vector2(4.5f,4.5f),1f,SpriteEffects.None,1f);
            if(!Main.keyboardstat.IsKeyDown(Keys.LeftShift)&&!Main.keyboardstat.IsKeyDown(Keys.RightShift)) {
                return;
            }
            s.Draw(Main.playerc,new Vector2(position.X,position.Y),new Rectangle?(),new Color(1f,1f,1f,alpha),MathHelper.ToRadians(guru),new Vector2(32f,32f),1f,SpriteEffects.None,1f);
        }
    }
}
