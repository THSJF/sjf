// Decompiled with JetBrains decompiler
// Type: THMHJ.PRACTICE
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace THMHJ {
    internal class PRACTICE {
        private PracticeData practicedata;
        private Sprite displaybox;
        private Sprite[] level;
        private Sprite crapwise;
        private Sprite[] character;
        private Sprite cinfo;
        private Texture2D black;
        private Vector2 blackpos;
        private float blacka;
        private float worda;
        private Vector2[] crapwisexy;
        private int time;
        private int time2;
        private int time3;
        private int selection;
        private int selection2;
        private int selection3;
        private int stage;
        private bool steps;
        private bool steps2;
        private bool fadeout;
        private bool ok;

        public int Selection => selection;

        public int Selection2 => selection2;

        public int Selection3 => selection3;

        public bool Fadeout => fadeout;

        public bool Ok => ok;

        public PRACTICE(PracticeData data,Texture2D blackbox,Sprite displaybox_s,Sprite[] level_s,Sprite crapwise_s,Sprite[] character_s,Sprite cinfo_s,Vector2[] crapwisexy_i,int selection_i,int selection2_i) {
            practicedata=data;
            displaybox=displaybox_s;
            level=level_s;
            crapwise=crapwise_s;
            crapwisexy=crapwisexy_i;
            character=character_s;
            cinfo=cinfo_s;
            selection=selection_i;
            if(selection>=5) selection=1;
            selection2=selection2_i;
            selection3=1;
            black=blackbox;
            blackpos=new Vector2(249f,165f);
            time=0;
            time2=0;
        }

        public unsafe void Update() {
            if(time>=0&&time<=22) {
                displaybox.position.X=((displaybox.position.X*9.0f+88.0f)/10.0f);
                displaybox.color.a+=0.05f;
                if(displaybox.color.a>=1.0) displaybox.color.a=1f;
                level[selection-1].color.a+=0.05f;
                if(level[selection-1].color.a>=1.0) level[selection-1].color.a=1f;
                for(int index = 0;index<5;++index) {
                    if(time==1) {
                        fixed (float* v = &level[index].position.X) {
                            ValueEvent valueEvent = new ValueEvent(v,(80-(selection-1-index)*100),10,ChangeType.NONLINEAR);
                        }
                    }
                    if(index!=selection-1) {
                        level[index].color.a-=0.05f;
                        if(level[index].color.a<=0.0) level[index].color.a=0.0f;
                    }
                }
                if(time==1) {
                    fixed (float* v = &crapwise.color.a) {
                        ValueEvent valueEvent = new ValueEvent(v,0.0f,10,ChangeType.NONLINEAR);
                    }
                }
                if(time==11) {
                    crapwisexy[0]=new Vector2(366f,242f);
                    crapwisexy[1]=new Vector2(52f,242f);
                    fixed (float* v = &crapwise.color.a) {
                        ValueEvent valueEvent = new ValueEvent(v,1f,10,ChangeType.NONLINEAR);
                    }
                }
                if(!steps) {
                    for(int index = 0;index<4;++index) {
                        character[index].color.a-=0.05f;
                        if(character[index].color.a<=0.0)
                            character[index].color.a=0.0f;
                    }
                }
            }
            if(!fadeout&!steps) {
                if(((!fadeout ? 1 : 0)&(Main.keyboardstat.IsKeyDown(Keys.Left)&Main.keyboardstat!=Main.prekeyboard ? 1 : (PadState.IsKeyPressed(JOYKEYS.Left,Main.prepadstat) ? 1 : 0)))!=0) {
                    Program.game.entrance.PlaySound("select");
                    --selection;
                    if(selection==0) selection=4;
                    for(int index = 0;index<5;++index) {
                        fixed (float* v = &level[index].position.X) {
                            ValueEvent valueEvent = new ValueEvent(v,(80-(selection-1-index)*100),10,ChangeType.NONLINEAR);
                        }
                    }
                    time=0;
                } else if(((!fadeout ? 1 : 0)&(Main.keyboardstat.IsKeyDown(Keys.Right)&Main.keyboardstat!=Main.prekeyboard ? 1 : (PadState.IsKeyPressed(JOYKEYS.Right,Main.prepadstat) ? 1 : 0)))!=0) {
                    Program.game.entrance.PlaySound("select");
                    ++selection;
                    if(selection==5) selection=1;
                    for(int index = 0;index<5;++index) {
                        if(index!=selection-1) {
                            level[index].color.a-=0.05f;
                            if(level[index].color.a<=0.0) level[selection-1].color.a=0.0f;
                        }
                    }
                    for(int index = 0;index<5;++index) {
                        fixed (float* v = &level[index].position.X) {
                            ValueEvent valueEvent = new ValueEvent(v,(80-(selection-1-index)*100),10,ChangeType.NONLINEAR);
                        }
                    }
                    time=0;
                }
                if(time>=22) {
                    if(Main.keyboardstat.IsKeyDown(Keys.Enter)&Main.keyboardstat!=Main.prekeyboard||Main.keyboardstat.IsKeyDown(Keys.Z)&Main.keyboardstat!=Main.prekeyboard||PadState.IsKeyPressed(JOYKEYS.Confirm,Main.prepadstat)) {
                        Program.game.entrance.PlaySound("ok");
                        // Main.Level=(Difficulty)selection;
                        Main.Level=Difficulty.LUNATIC;
                        time2=0;
                        steps=true;
                    } else if(Main.keyboardstat.IsKeyDown(Keys.X)&Main.keyboardstat!=Main.prekeyboard||Main.keyboardstat.IsKeyDown(Keys.Escape)&Main.keyboardstat!=Main.prekeyboard||(PadState.IsKeyPressed(JOYKEYS.Special,Main.prepadstat)||PadState.IsKeyPressed(JOYKEYS.Pause,Main.prepadstat))) {
                        for(int index = 0;index<5;++index) {
                            fixed (float* v = &level[index].position.X) {
                                ValueEvent valueEvent = new ValueEvent(v,(30-(selection-1-index)*100),10,ChangeType.NONLINEAR);
                            }
                        }
                        Program.game.entrance.PlaySound("cancel");
                        fadeout=true;
                    }
                }
            }
            if(!steps) {
                if(time<=72) {
                    displaybox.color.a-=0.01f;
                    if(displaybox.color.a<=0.0) displaybox.color.a=0.0f;
                }
                if(time>=72&time<=122) {
                    displaybox.color.a+=0.01f;
                    if(displaybox.color.a>=1.0) displaybox.color.a=1f;
                }
                if(time>=122) time=42;
            } else {
                if(time2>0&time2<=22) {
                    displaybox.position.X=((displaybox.position.X*4.0f+88.0f-50.0f)/5.0f);
                    displaybox.color.a-=0.05f;
                    if(displaybox.color.a<=0.0) displaybox.color.a=0.0f;
                    level[selection-1].color.a-=0.05f;
                    if(level[selection-1].color.a<=0.0) level[selection-1].color.a=0.0f;
                    for(int index = 0;index<5;++index) {
                        if(time2==1) {
                            fixed (float* v = &level[index].position.X) {
                                ValueEvent valueEvent = new ValueEvent(v,(30-(selection-1-index)*100),10,ChangeType.NONLINEAR);
                            }
                        }
                    }
                    if(time2==1) {
                        fixed (float* v = &crapwise.color.a) {
                            ValueEvent valueEvent = new ValueEvent(v,0.0f,10,ChangeType.NONLINEAR);
                        }
                        fixed (float* v = &cinfo.color.a) {
                            ValueEvent valueEvent = new ValueEvent(v,1f,10,ChangeType.NONLINEAR);
                        }
                        fixed (float* v = &cinfo.position.X) {
                            ValueEvent valueEvent = new ValueEvent(v,20f,10,ChangeType.NONLINEAR);
                        }
                    }
                    if(time2==11) {
                        crapwisexy[0]=new Vector2(600f,242f);
                        crapwisexy[1]=new Vector2(22f,242f);
                        fixed (float* v = &crapwise.color.a) {
                            ValueEvent valueEvent = new ValueEvent(v,1f,10,ChangeType.NONLINEAR);
                        }
                    }
                }
                if(time2>=23) time2=23;
                if(time2>=0&&!ok) {
                    for(int index = 0;index<4;++index) {
                        if(time2==0)
                            character[index].position.X=200f;
                        if(index==selection2-1) {
                            character[index].color.a+=0.05f;
                            if(character[index].color.a>=1.0) character[index].color.a=1f;
                            character[index].position.X+=((0.0f-character[index].position.X)/10.0f);
                        } else {
                            character[index].color.a-=0.05f;
                            if(character[index].color.a<=0.0) character[index].color.a=0.0f;
                            character[index].position.X+=((200.0f-character[index].position.X)/10.0f);
                        }
                    }
                }
                if(time2>=22&&!steps2) {
                    if(((!fadeout ? 1 : 0)&(Main.keyboardstat.IsKeyDown(Keys.Left)&Main.keyboardstat!=Main.prekeyboard ? 1 : (PadState.IsKeyPressed(JOYKEYS.Left,Main.prepadstat) ? 1 : 0)))!=0) {
                        Program.game.entrance.PlaySound("select");
                        --selection2;
                        if(selection2==0) selection2=4;
                    } else if(((!fadeout ? 1 : 0)&(Main.keyboardstat.IsKeyDown(Keys.Right)&Main.keyboardstat!=Main.prekeyboard ? 1 : (PadState.IsKeyPressed(JOYKEYS.Right,Main.prepadstat) ? 1 : 0)))!=0) {
                        Program.game.entrance.PlaySound("select");
                        ++selection2;
                        if(selection2==5) selection2=1;
                    } else if(Main.keyboardstat.IsKeyDown(Keys.X)&Main.keyboardstat!=Main.prekeyboard||Main.keyboardstat.IsKeyDown(Keys.Escape)&Main.keyboardstat!=Main.prekeyboard||(PadState.IsKeyPressed(JOYKEYS.Special,Main.prepadstat)||PadState.IsKeyPressed(JOYKEYS.Pause,Main.prepadstat))) {
                        for(int index = 0;index<5;++index) {
                            fixed (float* v = &level[index].position.X) {
                                ValueEvent valueEvent = new ValueEvent(v,(80-(selection-1-index)*100),10,ChangeType.NONLINEAR);
                            }
                        }
                        fixed (float* v = &cinfo.color.a) {
                            ValueEvent valueEvent = new ValueEvent(v,0.0f,10,ChangeType.NONLINEAR);
                        }
                        fixed (float* v = &cinfo.position.X) {
                            ValueEvent valueEvent = new ValueEvent(v,100f,10,ChangeType.NONLINEAR);
                        }
                        Program.game.entrance.PlaySound("cancel");
                        steps=false;
                        time=0;
                        time2=0;
                        Main.keyboardstat=Main.prekeyboard;
                    }
                    if(Main.keyboardstat.IsKeyDown(Keys.Enter)&Main.keyboardstat!=Main.prekeyboard||Main.keyboardstat.IsKeyDown(Keys.Z)&Main.keyboardstat!=Main.prekeyboard||PadState.IsKeyPressed(JOYKEYS.Confirm,Main.prepadstat)) {
                        Program.game.entrance.PlaySound("ok");
                          Main.Character=(Cname)selection2;
                    //    Main.Character=Cname.SANAE;
                        steps2=true;
                        selection3=1;
                        time3=0;
                        blackpos.X=249f;
                    }
                }
                if(steps2) {
                    if(time3<=20) {
                        if(time3==0) {
                          stage=practicedata.clearstate[selection2-1][selection-1];
                        //    stage=6;
                            if(stage==7) selection3=7;
                        }
                        fixed (float* v = &blackpos.X) {
                            ValueEvent valueEvent = new ValueEvent(v,199f,10,ChangeType.NONLINEAR);
                        }
                        blacka+=0.035f;
                        if(blacka>=0.699999988079071) blacka=0.7f;
                        worda+=0.05f;
                    } else if(!ok) {
                        if(Main.keyboardstat.IsKeyDown(Keys.X)&Main.keyboardstat!=Main.prekeyboard||Main.keyboardstat.IsKeyDown(Keys.Escape)&Main.keyboardstat!=Main.prekeyboard||(PadState.IsKeyPressed(JOYKEYS.Special,Main.prepadstat)||PadState.IsKeyPressed(JOYKEYS.Pause,Main.prepadstat))) {
                            time3=0;
                            steps2=false;
                            fixed (float* v = &blacka) {
                                ValueEvent valueEvent = new ValueEvent(v,0.0f,10,ChangeType.LINEAR);
                            }
                            fixed (float* v = &worda) {
                                ValueEvent valueEvent = new ValueEvent(v,0.0f,10,ChangeType.LINEAR);
                            }
                            Program.game.entrance.PlaySound("cancel");
                        }
                        if((Main.keyboardstat.IsKeyDown(Keys.Up)&Main.keyboardstat!=Main.prekeyboard||PadState.IsKeyPressed(JOYKEYS.Up,Main.prepadstat))&&stage!=7) {
                            --selection3;
                            if(selection3<1) selection3=stage;
                            Program.game.entrance.PlaySound("select");
                        }
                        if((Main.keyboardstat.IsKeyDown(Keys.Down)&Main.keyboardstat!=Main.prekeyboard||PadState.IsKeyPressed(JOYKEYS.Down,Main.prepadstat))&&stage!=7) {
                            ++selection3;
                            if(selection3>stage) selection3=1;
                            Program.game.entrance.PlaySound("select");
                        }
                        if((Main.keyboardstat.IsKeyDown(Keys.Enter)&Main.keyboardstat!=Main.prekeyboard||Main.keyboardstat.IsKeyDown(Keys.Z)&Main.keyboardstat!=Main.prekeyboard||PadState.IsKeyPressed(JOYKEYS.Confirm,Main.prepadstat))&&stage!=0) {
                            Program.game.entrance.PlaySound("ok");
                            ok=true;
                            fixed (float* v = &blacka) {
                                ValueEvent valueEvent = new ValueEvent(v,0.0f,10,ChangeType.LINEAR);
                            }
                            fixed (float* v = &worda) {
                                ValueEvent valueEvent = new ValueEvent(v,0.0f,10,ChangeType.LINEAR);
                            }
                        }
                    }
                    ++time3;
                }
            }
            ++time;
            if(!steps) return;
            ++time2;
        }

        public void Draw(SpriteBatch s) {
            displaybox.Draw(s,SpriteEffects.None,0.0f);
            for(int index = 0;index<5;++index) {
                level[index].Draw(s,SpriteEffects.None,0.0f);
            }
            for(int index = 0;index<4;++index) {
                character[index].Draw(s,SpriteEffects.None,0.0f);
            }
            cinfo.rect=new Rectangle((selection2-1)*314,0,314,483);
            cinfo.Draw(s,SpriteEffects.None,0.0f);
            crapwise.position=crapwisexy[0];
            crapwise.Draw(s,SpriteEffects.None,0.0f);
            crapwise.position=crapwisexy[1];
            crapwise.Draw(s,SpriteEffects.FlipHorizontally,0.0f);
            s.Draw(black,blackpos,new Rectangle?(),new Color(1f,1f,1f,blacka),0.0f,Vector2.Zero,new Vector2(2.42f,1.51f),SpriteEffects.None,0.0f);
            int num = 1;
            if(stage==7) {
                num=7;
                for(int index = 1;index<=6;++index) {
                    Main.dfont.Draw(s,"-----------------------------",new Vector2(220f,(180+(index-1)*17+1)),new Color(0.0f,0.0f,0.0f,worda));
                    Main.dfont.Draw(s,"-----------------------------",new Vector2(219f,(180+(index-1)*17)),new Color(1f,1f,1f,worda));
                }
            }
            for(int index = num;index<=stage;++index) {
                Color color = new Color(1f,1f,1f,worda);
                if(index==selection3) color=new Color(1f,0.0f,0.0f,worda);
                string str1 = index.ToString()+" ";
                if(index==7) str1="Ex";
                string str2 = practicedata.data[(int)(Main.Character-1)][(int)(Main.Level-1)].score[index-1].ToString().PadLeft(10,'0');
                Main.dfont.Draw(s,"Stage "+str1+"  "+str2,new Vector2(220f,(180+(index-1)*17+1)),new Color(0.0f,0.0f,0.0f,worda));
                Main.dfont.Draw(s,"Stage "+str1+"  "+str2,new Vector2(219f,(180+(index-1)*17)),color);
            }
            if(stage>=7) return;
            for(int index = stage+1;index<=7;++index) {
                Main.dfont.Draw(s,"-----------------------------",new Vector2(220f,(180+(index-1)*17+1)),new Color(0.0f,0.0f,0.0f,worda));
                Main.dfont.Draw(s,"-----------------------------",new Vector2(219f,(180+(index-1)*17)),new Color(1f,1f,1f,worda));
            }
        }
    }
}
