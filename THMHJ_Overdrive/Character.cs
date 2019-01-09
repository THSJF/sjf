// Decompiled with JetBrains decompiler
// Type: THMHJ.Character
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;

namespace THMHJ {
    public class Character:EquipShoot {
        private float runtime;
        private float runtimebf;
        private Praticle praticle;
        private List<ItemManager> itemm;
        public int eqlevel;
        public Sprite body;
        public bool Wudi;
        public bool Auto;
        public bool IAuto;
        public bool Dis;
        public bool free;
        public bool Ban;
        public bool BanShoot;
        public bool dead;
        public bool shot;
        public bool bombed;
        public bool shifted;
        public bool havedead;
        public int time;
        public Vector2 speedadd;
        public Vector2 rangex;
        public Vector2 rangey;
        private Sprite judge;
        private Texture2D selfb;
        public Cname type;
        private Attribute mattribute;
        private Attribute sattribute;
        private Equipment equip;
        private int ani;
        private int ani2;
        private int f;
        private int f2;
        private int f3;
        private int flash;
        private int ansave;
        private bool alreadycal;
        private bool change;
        private bool makeup;
        private int jue;
        private SingleBomb bomb;

        public Character(Sprite b) {
            body=b;
            Ban=true;
        }

        public Character(Sprite b,Sprite j,Texture2D sb,Texture2D it,Cname t,Attribute atb1,Attribute atb2) {
            body=b;
            judge=j;
            selfb=sb;
            type=t;
            mattribute=atb1;
            sattribute=atb2;
            body.position=new Vector2(224f,420f);
            body.origin=new Vector2(30f,25f);
            body.rect=new Rectangle(0,(int)(type-1)*60,60,60);
            body.scale=new Vector2(1f,1f);
            judge.position=body.position;
            judge.origin=new Vector2(35f,36f);
            if(Main.Mode==Modes.SINGLE) {
                rangex=new Vector2(42f,406f);
                rangey=new Vector2(43f,453f);
            } else {
                rangex=new Vector2(10f,630f);
                rangey=new Vector2(20f,465f);
            }
            Ban=true;
            equip=new Equipment(selfb);
            Program.game.game.DrawJudge+=new Game.DrawDelegate2(DrawJudge);
            praticle=new Praticle(false,true,new Rectangle(49,48,14,13),new Vector4(body.position.X,body.position.Y,0.0f,0.0f),new Vector2(7f,7f),18,5,30,3f,0.0f,new Vector2(0.0f,360f),10f);
            praticle.scale=new Vector4(1.2f,0.4f,0.0f,0.0f);
            praticle.calpha=1f;
            praticle.stop=true;
            speedadd=new Vector2(1f,1f);
        }
        public void Init() {
            equip.Init();
        }
        public void SetItemm(List<ItemManager> itemm_I) {
            itemm=itemm_I;
        }
        public void Grazed() {
            praticle.stop=false;
            praticle.TIME=0;
        }
        public void Update(CSManager csm,EnemyManager e,Boss b) {
            praticle.posrect=new Vector4(body.position.X,body.position.Y,0.0f,0.0f);
            equip.Update(b,e,type,mattribute.CHILDREN,eqlevel,body.position,Dis|Ban|BanShoot);
            SelfBarrageManager.Update(e,b,this);
            ++f;
            if(f%3==0) {
                if(flash<=40) ++flash;
                if(flash%2==0) {
                    body.color.r=0.0f;
                    body.color.g=0.0f;
                } else {
                    body.color.r=1f;
                    body.color.g=1f;
                }
            }
            if(f==6) {
                f=0;
                ++ani;
                if(ani==7) ani=0;
            }
            eqlevel=Program.game.game.Point/50;
            runtime+=Time.Stop;
            if(body.position.X>=rangex.X&&body.position.X<=rangex.Y&&(body.position.Y>=rangey.X&&body.position.Y<=rangey.Y)) {
                int num1 = -1;
                if(!Dis) {
                    if(Main.IsKeyDown(Keys.Up)||!Main.Replay&&PadState.IsKeyDown(JOYKEYS.Up)) {
                        num1=-90;
                        change=false;
                    }
                    if(Main.IsKeyDown(Keys.Down)||!Main.Replay&&PadState.IsKeyDown(JOYKEYS.Down)) {
                        num1=90;
                        change=false;
                    }
                    if(Main.IsKeyDown(Keys.Left)||!Main.Replay&&PadState.IsKeyDown(JOYKEYS.Left)) {
                        num1=180;
                        if(Main.IsKeyDown(Keys.Up)||!Main.Replay&&PadState.IsKeyDown(JOYKEYS.Up))
                            num1=225;
                        if(Main.IsKeyDown(Keys.Down)||!Main.Replay&&PadState.IsKeyDown(JOYKEYS.Down))
                            num1=135;
                    }
                    if(Main.IsKeyDown(Keys.Right)||!Main.Replay&&PadState.IsKeyDown(JOYKEYS.Right)) {
                        num1=0;
                        if(Main.IsKeyDown(Keys.Up)||!Main.Replay&&PadState.IsKeyDown(JOYKEYS.Up))
                            num1=-45;
                        if(Main.IsKeyDown(Keys.Down)||!Main.Replay&&PadState.IsKeyDown(JOYKEYS.Down))
                            num1=45;
                    }
                }
                if(num1!=-1) {
                    if(runtime-runtimebf>=1.0) {
                        if(num1==225||num1==135||(num1==180||num1==0)||(num1==-45||num1==45)) {
                            ansave=num1;
                            change=true;
                            f3=1;
                            ++f2;
                            if(f2==3) {
                                switch(num1) {
                                    case -45:
                                    case 0:
                                    case 45:
                                        body.rect=new Rectangle(660,(int)(type-1)*60,60,60);
                                        break;
                                    case 135:
                                    case 180:
                                    case 225:
                                        body.rect=new Rectangle(420,(int)(type-1)*60,60,60);
                                        break;
                                }
                            } else if(f2==7) {
                                ++ani2;
                                if(ani2>=4)
                                    ani2=1;
                                switch(num1) {
                                    case -45:
                                    case 0:
                                    case 45:
                                        body.rect=new Rectangle((11+ani2)*60,(int)(type-1)*60,60,60);
                                        break;
                                    case 135:
                                    case 180:
                                    case 225:
                                        body.rect=new Rectangle((7+ani2)*60,(int)(type-1)*60,60,60);
                                        break;
                                }
                                f2=4;
                            }
                        } else
                            change=false;
                    }
                    float num2;
                    if(Main.IsKeyDown(Keys.LeftShift)||Main.IsKeyDown(Keys.RightShift)||!Main.Replay&&PadState.IsKeyDown(JOYKEYS.Slow)) {
                        num2=Characters.attribute[(int)(type-1+4)].MOVE*0.5f*speedadd.X;
                        shifted=true;
                    } else {
                        num2=(float)(1.0+Characters.attribute[(int)(type-1)].MOVE*0.5*speedadd.Y);
                    }
                    body.position.X=MathHelper.Clamp(body.position.X+num2*(float)Math.Cos(num1*Math.PI/180.0)*Time.Stop,rangex.X,rangex.Y);
                    body.position.Y=MathHelper.Clamp(body.position.Y+num2*(float)Math.Sin(num1*Math.PI/180.0)*Time.Stop,rangey.X,rangey.Y);
                } else {
                    change=false;
                    f2=0;
                    ani2=0;
                }
                if(runtime-runtimebf>=1.0) {
                    if(!change&&f3==0)
                        body.rect=new Rectangle(ani*60,(int)(type-1)*60,60,60);
                    else if(!change&&f3>=1) {
                        if(ansave==225||ansave==135||ansave==180)
                            body.rect=new Rectangle(420,(int)(type-1)*60,60,60);
                        else if(ansave==0||ansave==-45||ansave==45)
                            body.rect=new Rectangle(660,(int)(type-1)*60,60,60);
                        ++f3;
                        if(f3==4) f3=0;
                    }
                    runtimebf=runtime;
                }
                Program.game.achivmanager.Check(AchievementType.Hidden,3,new Hashtable() {
                    ["itemline"]=Main.gn.Itemline[(int)(Main.Character-1)],
                    ["y"]=body.position.Y
                });
            }
            if((Dis||free)&&Time.Stop==1.0) {
                ++time;
                if(time>30&&time<=100) {
                    for(int index = 0;index<e.EnemyArray.Count;++index) {
                        if(!e.EnemyArray[index].IsInWudi()&&!e.EnemyArray[index].die&&(e.EnemyArray[index].hp>0&&!Main.IsOut(e.EnemyArray[index].Position))&&Math.Sqrt((e.EnemyArray[index].Position.X-body.position.X)*(e.EnemyArray[index].Position.X-body.position.X)+(e.EnemyArray[index].Position.Y-body.position.Y)*(e.EnemyArray[index].Position.Y-body.position.Y))<Math.Abs((time-10)*10)) {
                            e.EnemyArray[index].deadkill=true;
                            e.EnemyArray[index].hp-=2;
                        }
                    }
                }
                if(time==1) {
                    Program.game.achivmanager.Check(AchievementType.Challenge,9,new Hashtable() {
                        ["missorjust"]=true
                    });
                    CrazyStorm crazyStorm = Program.game.game.PlayEffect(true,"14",new Vector2(body.position.X+93f,body.position.Y-13f));
                    crazyStorm.BanSound(true);
                    crazyStorm.effect=true;
                    Program.game.game.PlaySound("pldead00",true,body.position.X);
                    body.color.a=0.0f;
                } else if(time==30) {
                    if(Program.game.game.Point>=50) Program.game.game.DeathItem();
                    Program.game.game.SpecialSystemReset();
                    dead=true;
                    havedead=true;
                    Program.game.game.Life-=5;
                    if(Program.game.game.Bomb<10) Program.game.game.Bomb=10+Program.game.game.Bomb%5;
                    if(Program.game.game.Life==0) {
                        Program.game.game.Life=0;
                        if(!makeup) Program.game.game.Point=150;
                        makeup=true;
                    } else if(Program.game.game.Life<0) {
                        alreadycal=true;
                        Program.game.game.PlaySound("pldead01",true,body.position.X);
                        Program.game.game.Life=-5;
                        Program.game.game.Bomb=0;
                        Program.game.game.BanPause=true;
                        makeup=false;
                    }
                } else if(time>30) {
                    if(time==31) {
                        body.position.X=224f;
                        body.position.Y=510f;
                    } else if(Program.game.game.Life>=0&&body.position.Y>420.0&&!free) {
                        body.position.Y-=2f;
                        if(body.position.Y<=420.0) body.position.Y=420f;
                    }
                    if(Program.game.game.Life>=0) {
                        if(time%6<3) {
                            body.color.r=0.0f;
                            body.color.g=0.0f;
                        } else {
                            body.color.r=1f;
                            body.color.g=1f;
                        }
                    }
                    body.color.a=1f;
                }
                if(time==95) {
                    if(!alreadycal) {
                        Program.game.game.AddStgData(1,0,0);
                    } else {
                        alreadycal=false;
                    }
                    Dis=false;
                    free=true;
                    if(Program.game.game.Life==-5) {
                        free=false;
                        Dis=true;
                        time=50;
                        Program.game.game.DeathProcess();
                    }
                }
                if(time>280) {
                    free=false;
                    time=0;
                }
            }
            if(!Ban&&!Dis&&!BanShoot|type==Cname.PATCHOULI&&(Main.IsKeyDown(Keys.Z)||!Main.Replay&&PadState.IsKeyDown(JOYKEYS.Confirm))) {
                BEquipShoot(selfb,type,mattribute.BODY,body.position);
                shot=true;
            }
            if(bomb!=null&&!bomb.Die) {
                bomb.Update(this,csm,e,b);
            } else if(bomb!=null) {
                bomb=null;
                Wudi=false;
                Auto=false;
            }
            int num = type!=Cname.SANAE||Main.Mode!=Modes.SINGLE||(Main.IsKeyDown(Keys.LeftShift)||Main.IsKeyDown(Keys.RightShift))||!Main.Replay&&PadState.IsKeyDown(JOYKEYS.Slow) ? 5 : 3;
            if(!Ban&&(jue<=10||free)&&(Program.game.game.Bomb>=num&&bomb==null)&&((Main.IsKeyPressed(Keys.X)||!Main.Replay&&PadState.IsKeyPressed(JOYKEYS.Special,Main.prepadstat))&&Time.Stop!=0.0)) {
                bombed=true;
                BanShoot=true;
                body.color=new Colors(1f,1f,1f,1f);
                if(b!=null) Program.game.game.AddStgData(0,1,0);
                Program.game.game.Bomb-=num;
                if(Program.game.game.Bomb<=0) Program.game.game.Bomb=0;
                if(!free) {
                    Dis=false;
                    time=0;
                    Program.game.achivmanager.Check(AchievementType.Challenge,9,new Hashtable() {
                        ["missorjust"]=false
                    });
                }
                Program.game.game.PlaySound("slash",true,body.position.X);
                bomb=new SingleBomb(type,body.position+new Vector2(93f,-13f));
                Wudi=true;
                Auto=true;
            }
            if(Dis||free) {
                ++jue;
            } else {
                jue=0;
            }
            if(itemm==null) return;
            foreach(ItemManager itemManager in itemm) {
                if(!Dis) {
                    itemManager.Ban(false);
                } else {
                    itemManager.Ban(true);
                }
                itemManager.Transpos(body.position.X,body.position.Y);
            }
        }
        public void Draw(SpriteBatch s,bool Pause,Vector2 q) {
            Vector2 position = body.position;
            body.position=new Vector2(position.X+q.X,position.Y+q.Y);
            body.Draw(s,SpriteEffects.None,0.0f);
            body.position=position;
            equip.Draw(s,q);
            SelfBarrageManager.Draw(s,q);
        }

        private void INPUT(object obj) {
        }

        public void DrawJudge(SpriteBatch s,bool Pause,Vector2 q) {
            if(Pause) return;
        //    if(Main.IsKeyDown(Keys.LeftShift)||Main.IsKeyDown(Keys.RightShift)||!Main.Replay&&PadState.IsKeyDown(JOYKEYS.Slow)) {
                judge.color.a+=0.2f*Time.Stop;
                if(judge.color.a>=1.0) judge.color.a=1f;
                judge.rotation+=3f*Time.Stop;
                if(judge.rotation>=360.0) judge.rotation=0.0f;
                judge.position=new Vector2(body.position.X,body.position.Y-1f);
                judge.scale.X-=0.1f*Time.Stop;
                if(judge.scale.X<=1.0) judge.scale.X=1f;
                judge.scale.Y-=0.1f*Time.Stop;
                if(judge.scale.Y<=1.0) judge.scale.Y=1f;
                Vector2 position = judge.position;
                judge.position=new Vector2(position.X+q.X,position.Y+q.Y);
                judge.Draw(s,SpriteEffects.None,0.0f);
                judge.rotation=-judge.rotation;
                judge.Draw(s,SpriteEffects.None,0.0f);
                judge.rotation=-judge.rotation;
                judge.position=position;
        //    } else {
         //       judge.color.a=0.0f;
        //        judge.scale=new Vector2(1.6f,1.6f);
        //    }
        }

        public Vector2 Position() {
            return body.position;
        }

        public void SetPosition(Vector2 pos) {
            body.position=pos;
        }
    }
}
