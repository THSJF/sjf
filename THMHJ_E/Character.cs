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
            this.body=b;
            this.Ban=true;
        }

        public Character(
          Sprite b,
          Sprite j,
          Texture2D sb,
          Texture2D it,
          Cname t,
          Attribute atb1,
          Attribute atb2) {
            this.body=b;
            this.judge=j;
            this.selfb=sb;
            this.type=t;
            this.mattribute=atb1;
            this.sattribute=atb2;
            this.body.position=new Vector2(224f,420f);
            this.body.origin=new Vector2(30f,25f);
            this.body.rect=new Rectangle(0,(int)(this.type-1)*60,60,60);
            this.body.scale=new Vector2(1f,1f);
            this.judge.position=this.body.position;
            this.judge.origin=new Vector2(35f,36f);
            if(Main.Mode==Modes.SINGLE) {
                this.rangex=new Vector2(42f,406f);
                this.rangey=new Vector2(43f,453f);
            } else {
                this.rangex=new Vector2(10f,630f);
                this.rangey=new Vector2(20f,465f);
            }
            this.Ban=true;
            this.equip=new Equipment(this.selfb);
            Program.game.game.DrawJudge+=new Game.DrawDelegate2(this.DrawJudge);
            this.praticle=new Praticle(false,true,new Rectangle(49,48,14,13),new Vector4(this.body.position.X,this.body.position.Y,0.0f,0.0f),new Vector2(7f,7f),18,5,30,3f,0.0f,new Vector2(0.0f,360f),10f);
            this.praticle.scale=new Vector4(1.2f,0.4f,0.0f,0.0f);
            this.praticle.calpha=1f;
            this.praticle.stop=true;
            this.speedadd=new Vector2(1f,1f);
        }

        public void Init() {
            equip.Init();
        }

        public void SetItemm(List<ItemManager> itemm_I) {
            this.itemm=itemm_I;
        }

        public void Grazed() {
            this.praticle.stop=false;
            this.praticle.TIME=0;
        }

        public void Update(CSManager csm,EnemyManager e,Boss b) {
            this.praticle.posrect=new Vector4(this.body.position.X,this.body.position.Y,0.0f,0.0f);
            this.equip.Update(b,e,this.type,this.mattribute.CHILDREN,this.eqlevel,this.body.position,this.Dis|this.Ban|this.BanShoot);
            SelfBarrageManager.Update(e,b,this);
            ++this.f;
            if(this.f%3==0) {
                if(this.flash<=40)
                    ++this.flash;
                if(this.flash%2==0) {
                    this.body.color.r=0.0f;
                    this.body.color.g=0.0f;
                } else {
                    this.body.color.r=1f;
                    this.body.color.g=1f;
                }
            }
            if(this.f==6) {
                this.f=0;
                ++this.ani;
                if(this.ani==7)
                    this.ani=0;
            }
            this.eqlevel=Program.game.game.Point/50;
            this.runtime+=Time.Stop;
            if((double)this.body.position.X>=(double)this.rangex.X&&(double)this.body.position.X<=(double)this.rangex.Y&&((double)this.body.position.Y>=(double)this.rangey.X&&(double)this.body.position.Y<=(double)this.rangey.Y)) {
                int num1 = -1;
                if(!this.Dis) {
                    if(Main.IsKeyDown(Keys.Up)||!Main.Replay&&PadState.IsKeyDown(JOYKEYS.Up)) {
                        num1=-90;
                        this.change=false;
                    }
                    if(Main.IsKeyDown(Keys.Down)||!Main.Replay&&PadState.IsKeyDown(JOYKEYS.Down)) {
                        num1=90;
                        this.change=false;
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
                    if((double)this.runtime-(double)this.runtimebf>=1.0) {
                        if(num1==225||num1==135||(num1==180||num1==0)||(num1==-45||num1==45)) {
                            this.ansave=num1;
                            this.change=true;
                            this.f3=1;
                            ++this.f2;
                            if(this.f2==3) {
                                switch(num1) {
                                    case -45:
                                    case 0:
                                    case 45:
                                        this.body.rect=new Rectangle(660,(int)(this.type-1)*60,60,60);
                                        break;
                                    case 135:
                                    case 180:
                                    case 225:
                                        this.body.rect=new Rectangle(420,(int)(this.type-1)*60,60,60);
                                        break;
                                }
                            } else if(this.f2==7) {
                                ++this.ani2;
                                if(this.ani2>=4)
                                    this.ani2=1;
                                switch(num1) {
                                    case -45:
                                    case 0:
                                    case 45:
                                        this.body.rect=new Rectangle((11+this.ani2)*60,(int)(this.type-1)*60,60,60);
                                        break;
                                    case 135:
                                    case 180:
                                    case 225:
                                        this.body.rect=new Rectangle((7+this.ani2)*60,(int)(this.type-1)*60,60,60);
                                        break;
                                }
                                this.f2=4;
                            }
                        } else
                            this.change=false;
                    }
                    float num2;
                    if(Main.IsKeyDown(Keys.LeftShift)||Main.IsKeyDown(Keys.RightShift)||!Main.Replay&&PadState.IsKeyDown(JOYKEYS.Slow)) {
                        num2=Characters.attribute[(int)(this.type-1+4)].MOVE*0.5f*this.speedadd.X;
                        this.shifted=true;
                    } else
                        num2=(float)(1.0+(double)Characters.attribute[(int)(this.type-1)].MOVE*0.5*(double)this.speedadd.Y);
                    this.body.position.X=MathHelper.Clamp(this.body.position.X+num2*(float)Math.Cos((double)num1*Math.PI/180.0)*Time.Stop,this.rangex.X,this.rangex.Y);
                    this.body.position.Y=MathHelper.Clamp(this.body.position.Y+num2*(float)Math.Sin((double)num1*Math.PI/180.0)*Time.Stop,this.rangey.X,this.rangey.Y);
                } else {
                    this.change=false;
                    this.f2=0;
                    this.ani2=0;
                }
                if((double)this.runtime-(double)this.runtimebf>=1.0) {
                    if(!this.change&&this.f3==0)
                        this.body.rect=new Rectangle(this.ani*60,(int)(this.type-1)*60,60,60);
                    else if(!this.change&&this.f3>=1) {
                        if(this.ansave==225||this.ansave==135||this.ansave==180)
                            this.body.rect=new Rectangle(420,(int)(this.type-1)*60,60,60);
                        else if(this.ansave==0||this.ansave==-45||this.ansave==45)
                            this.body.rect=new Rectangle(660,(int)(this.type-1)*60,60,60);
                        ++this.f3;
                        if(this.f3==4)
                            this.f3=0;
                    }
                    this.runtimebf=this.runtime;
                }
                Program.game.achivmanager.Check(AchievementType.Hidden,3,new Hashtable() {
                    [(object)"itemline"]=(object)Main.gn.Itemline[(int)(Main.Character-1)],
                    [(object)"y"]=(object)this.body.position.Y
                });
            }
            if((this.Dis||this.free)&&(double)Time.Stop==1.0) {
                ++this.time;
                if(this.time>30&&this.time<=100) {
                    for(int index = 0;index<e.EnemyArray.Count;++index) {
                        if(!e.EnemyArray[index].IsInWudi()&&!e.EnemyArray[index].die&&(e.EnemyArray[index].hp>0&&!Main.IsOut(e.EnemyArray[index].Position))&&Math.Sqrt(((double)e.EnemyArray[index].Position.X-(double)this.body.position.X)*((double)e.EnemyArray[index].Position.X-(double)this.body.position.X)+((double)e.EnemyArray[index].Position.Y-(double)this.body.position.Y)*((double)e.EnemyArray[index].Position.Y-(double)this.body.position.Y))<(double)Math.Abs((this.time-10)*10)) {
                            e.EnemyArray[index].deadkill=true;
                            e.EnemyArray[index].hp-=2;
                        }
                    }
                }
                if(this.time==1) {
                    Program.game.achivmanager.Check(AchievementType.Challenge,9,new Hashtable() {
                        [(object)"missorjust"]=(object)true
                    });
                    CrazyStorm crazyStorm = Program.game.game.PlayEffect(true,"14",new Vector2(this.body.position.X+93f,this.body.position.Y-13f));
                    crazyStorm.BanSound(true);
                    crazyStorm.effect=true;
                    Program.game.game.PlaySound("pldead00",true,this.body.position.X);
                    this.body.color.a=0.0f;
                } else if(this.time==30) {
                    if(Program.game.game.Point>=50)
                        Program.game.game.DeathItem();
                    Program.game.game.SpecialSystemReset();
                    this.dead=true;
                    this.havedead=true;
                    Program.game.game.Life-=5;
                    if(Program.game.game.Bomb<10)
                        Program.game.game.Bomb=10+Program.game.game.Bomb%5;
                    if(Program.game.game.Life==0) {
                        Program.game.game.Life=0;
                        if(!this.makeup)
                            Program.game.game.Point=150;
                        this.makeup=true;
                    } else if(Program.game.game.Life<0) {
                        this.alreadycal=true;
                        Program.game.game.PlaySound("pldead01",true,this.body.position.X);
                        Program.game.game.Life=-5;
                        Program.game.game.Bomb=0;
                        Program.game.game.BanPause=true;
                        this.makeup=false;
                    }
                } else if(this.time>30) {
                    if(this.time==31) {
                        this.body.position.X=224f;
                        this.body.position.Y=510f;
                    } else if(Program.game.game.Life>=0&&(double)this.body.position.Y>420.0&&!this.free) {
                        this.body.position.Y-=2f;
                        if((double)this.body.position.Y<=420.0)
                            this.body.position.Y=420f;
                    }
                    if(Program.game.game.Life>=0) {
                        if(this.time%6<3) {
                            this.body.color.r=0.0f;
                            this.body.color.g=0.0f;
                        } else {
                            this.body.color.r=1f;
                            this.body.color.g=1f;
                        }
                    }
                    this.body.color.a=1f;
                }
                if(this.time==95) {
                    if(!this.alreadycal)
                        Program.game.game.AddStgData(1,0,0);
                    else
                        this.alreadycal=false;
                    this.Dis=false;
                    this.free=true;
                    if(Program.game.game.Life==-5) {
                        this.free=false;
                        this.Dis=true;
                        this.time=50;
                        Program.game.game.DeathProcess();
                    }
                }
                if(this.time>280) {
                    this.free=false;
                    this.time=0;
                }
            }
            if(!this.Ban&&!this.Dis&&!this.BanShoot|this.type==Cname.PATCHOULI&&(Main.IsKeyDown(Keys.Z)||!Main.Replay&&PadState.IsKeyDown(JOYKEYS.Confirm))) {
                EquipShoot.BEquipShoot(this.selfb,this.type,this.mattribute.BODY,this.body.position);
                this.shot=true;
            }
            if(this.bomb!=null&&!this.bomb.Die)
                this.bomb.Update(this,csm,e,b);
            else if(this.bomb!=null) {
                this.bomb=(SingleBomb)null;
                this.Wudi=false;
                this.Auto=false;
            }
            int num = this.type!=Cname.SANAE||Main.Mode!=Modes.SINGLE||(Main.IsKeyDown(Keys.LeftShift)||Main.IsKeyDown(Keys.RightShift))||!Main.Replay&&PadState.IsKeyDown(JOYKEYS.Slow) ? 5 : 3;
            if(!this.Ban&&(this.jue<=10||this.free)&&(Program.game.game.Bomb>=num&&this.bomb==null)&&((Main.IsKeyPressed(Keys.X)||!Main.Replay&&PadState.IsKeyPressed(JOYKEYS.Special,Main.prepadstat))&&(double)Time.Stop!=0.0)) {
                this.bombed=true;
                this.BanShoot=true;
                this.body.color=new Colors(1f,1f,1f,1f);
                if(b!=null)
                    Program.game.game.AddStgData(0,1,0);
                Program.game.game.Bomb-=num;
                if(Program.game.game.Bomb<=0)
                    Program.game.game.Bomb=0;
                if(!this.free) {
                    this.Dis=false;
                    this.time=0;
                    Program.game.achivmanager.Check(AchievementType.Challenge,9,new Hashtable() {
                        [(object)"missorjust"]=(object)false
                    });
                }
                Program.game.game.PlaySound("slash",true,this.body.position.X);
                this.bomb=new SingleBomb(this.type,this.body.position+new Vector2(93f,-13f));
                this.Wudi=true;
                this.Auto=true;
            }
            if(this.Dis||this.free)
                ++this.jue;
            else
                this.jue=0;
            if(this.itemm==null)
                return;
            foreach(ItemManager itemManager in this.itemm) {
                if(!this.Dis)
                    itemManager.Ban(false);
                else
                    itemManager.Ban(true);
                itemManager.Transpos(this.body.position.X,this.body.position.Y);
            }
        }

        public void Draw(SpriteBatch s,bool Pause,Vector2 q) {
            Vector2 position = this.body.position;
            this.body.position=new Vector2(position.X+q.X,position.Y+q.Y);
            this.body.Draw(s,SpriteEffects.None,0.0f);
            this.body.position=position;
            this.equip.Draw(s,q);
            SelfBarrageManager.Draw(s,q);
        }

        private void INPUT(object obj) {
        }

        public void DrawJudge(SpriteBatch s,bool Pause,Vector2 q) {
            if(Pause)
                return;
            if(Main.IsKeyDown(Keys.LeftShift)||Main.IsKeyDown(Keys.RightShift)||!Main.Replay&&PadState.IsKeyDown(JOYKEYS.Slow)) {
                this.judge.color.a+=0.2f*Time.Stop;
                if((double)this.judge.color.a>=1.0)
                    this.judge.color.a=1f;
                this.judge.rotation+=3f*Time.Stop;
                if((double)this.judge.rotation>=360.0)
                    this.judge.rotation=0.0f;
                this.judge.position=new Vector2(this.body.position.X,this.body.position.Y-1f);
                this.judge.scale.X-=0.1f*Time.Stop;
                if((double)this.judge.scale.X<=1.0)
                    this.judge.scale.X=1f;
                this.judge.scale.Y-=0.1f*Time.Stop;
                if((double)this.judge.scale.Y<=1.0)
                    this.judge.scale.Y=1f;
                Vector2 position = this.judge.position;
                this.judge.position=new Vector2(position.X+q.X,position.Y+q.Y);
                this.judge.Draw(s,SpriteEffects.None,0.0f);
                this.judge.rotation=-this.judge.rotation;
                this.judge.Draw(s,SpriteEffects.None,0.0f);
                this.judge.rotation=-this.judge.rotation;
                this.judge.position=position;
            } else {
                this.judge.color.a=0.0f;
                this.judge.scale=new Vector2(1.6f,1.6f);
            }
        }

        public Vector2 Position() {
            return this.body.position;
        }

        public void SetPosition(Vector2 pos) {
            this.body.position=pos;
        }
    }
}
