// Decompiled with JetBrains decompiler
// Type: THMHJ.SpecialSystem
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace THMHJ {
    public class SpecialSystem {
        private int autotime;
        private int power;
        private int hipower;
        private int lightx;
        private float color;
        private Sprite grazebox;
        private int level;
        private int wait;
        private float flashalpha;

        public SpecialSystem(Sprite gb) {
            power=0;
            hipower=1500-120*(int)(Main.Level-1);
            lightx=0;
            color=1f;
            level=1220;
            grazebox=gb;
            autotime=30;
        }
        public int Power {
            get {
                return power;
            }
            set {
                power=value;
            }
        }

        public void Clear() {
            power=0;
            level=0;
        }

        public void Return() {
            power=0;
            hipower=1500-120*(int)(Main.Level-1);
            lightx=0;
            level=0;
            color=1f;
        }

        public void Update(Boss boss,Character player) {
            if(power>=hipower) {
                Program.game.game.Score+=(200000+Program.game.game.MaxBlue*20);
                power=0;
                flashalpha=1f;
                ++level;
                if(level%3==0) Program.game.game.BonusItem(1,0); else Program.game.game.BonusItem(0,1);
                autotime=0;
            }
            if(autotime<30) {
                ++autotime;
                player.IAuto=true;
            } else {
                player.IAuto=false;
            }
            if(flashalpha>0.0) flashalpha-=0.02f;
            if(power<=0) power=0;
            ++wait;
            if(wait<15) return;
            wait=15;
        }

        public void Add() {
            power+=30;
            wait=0;
        }

        public void Draw(SpriteBatch s) {
            grazebox.position=new Vector2(28f,444f);
            grazebox.rect=new Rectangle(0,0,4,22);
            grazebox.scale=new Vector2(1f,1f);
            grazebox.color.a=0.6f*color;
            grazebox.Draw(s,SpriteEffects.None,0.0f);
            for(int index = 0;index<18;++index) {
                grazebox.position=new Vector2((32+index*4),444f);
                grazebox.rect=new Rectangle(4+index*4,0,4,22);
                grazebox.color.a=0.6f*color;
                if(Math.Abs(33+index*4-lightx)<=25)
                    grazebox.color.a=(float)(1.0-Math.Abs(33+index*4-lightx)/25.0*0.400000005960464)*color;
                grazebox.Draw(s,SpriteEffects.None,0.0f);
            }
            grazebox.position=new Vector2(104f,444f);
            grazebox.rect=new Rectangle(76,0,6,22);
            grazebox.color.a=0.6f*color;
            grazebox.Draw(s,SpriteEffects.None,0.0f);
            float num = (float)power/hipower;
            if(num>=1.0) num=1f;
            grazebox.position=new Vector2(34f,452f);
            grazebox.rect=new Rectangle(7,31,(int)(68.0*num),7);
            grazebox.scale=new Vector2(1f,1f);
            grazebox.color.a=color;
            grazebox.Draw(s,SpriteEffects.None,0.0f);
            if(flashalpha>0.0) {
                s.End();
                s.Begin(SpriteBlendMode.Additive);
                grazebox.position=new Vector2(68f,456f);
                grazebox.rect=new Rectangle(7,31,68,7);
                grazebox.origin=new Vector2(34f,4f);
                grazebox.color.a=flashalpha;
                grazebox.Draw(s,SpriteEffects.None,0.0f);
                s.End();
                s.Begin();
            }
            grazebox.origin=Vector2.Zero;
            ++lightx;
            if(lightx<120) return;
            lightx=-30;
        }

        public void ChangeAlpha(Vector2 pp) {
            double num = Math.Sqrt((pp.X-65.0)*(pp.X-65.0)+(pp.Y-458.0)*(pp.Y-458.0));
            if(num<20.0||num>72.0)
                return;
            color=(float)num/72f;
        }
    }
}
