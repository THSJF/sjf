// Decompiled with JetBrains decompiler
// Type: CrazyStorm_1._03.Batch
// Assembly: CrazyStorm 1.03, Version=1.0.0.3, Culture=neutral, PublicKeyToken=null
// MVID: 84431CDC-1E34-49EF-A5C5-D546FEF5A655
// Assembly location: E:\CrazyStorm 1.03I\CrazyStorm 1.03.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CrazyStorm_1._03 {
    [Serializable]
    public class Batch {
        public int bindid = -1;
        private float[] conditions = new float[13];
        private float[] results = new float[33];
        private static int record;
        private int clcount;
        private int clwait;
        public bool Selecting;
        public int Searched;
        public bool NeedDelete;
        public int id;
        public int parentid;
        public int parentcolor;
        public bool Binding;
        public bool Bindwithspeedd;
        public bool Deepbind;
        public bool Deepbinded;
        public float x;
        public float y;
        public int time;
        public int begin;
        public int life;
        public float fx;
        public float fy;
        public float r;
        public float rdirection;
        public Vector2 rdirections;
        public int tiao;
        public int t;
        public float fdirection;
        public float bfdirection;
        public Vector2 fdirections;
        public int range;
        public float speed;
        public float speedd;
        public float speedx;
        public float speedy;
        public Vector2 speedds;
        public float aspeed;
        public float aspeedx;
        public float aspeedy;
        public float aspeedd;
        public Vector2 aspeedds;
        public int sonlife;
        public float type;
        public float wscale;
        public float hscale;
        public float colorR;
        public float colorG;
        public float colorB;
        public float alpha;
        public float head;
        public Vector2 heads;
        public bool Withspeedd;
        public float sonspeed;
        public float sonspeedd;
        public Vector2 sonspeedds;
        public float sonaspeed;
        public float sonaspeedd;
        public float bsonaspeedd;
        public Vector2 sonaspeedds;
        public float xscale;
        public float yscale;
        public bool Mist;
        public bool Dispel;
        public bool Blend;
        public bool Afterimage;
        public bool Outdispel;
        public bool Invincible;
        public bool Cover;
        public bool Rebound;
        public bool Force;
        public Batch rand;
        public List<Event> Parentevents;
        public List<Execution> Eventsexe;
        public List<Event> Sonevents;
        public Batch copys;

        public Batch() {
        }

        public Batch(float xs,float ys,int pc) {
            this.rand=new Batch();
            this.Parentevents=new List<Event>();
            this.Sonevents=new List<Event>();
            this.Eventsexe=new List<Execution>();
            this.x=xs;
            this.y=ys;
            this.parentcolor=pc;
            this.begin=Layer.LayerArray[this.parentid].begin;
            this.life=Layer.LayerArray[this.parentid].end-Layer.LayerArray[this.parentid].begin+1;
            this.fx=-99998f;
            this.fy=-99998f;
            this.r=0.0f;
            this.rdirection=0.0f;
            this.tiao=1;
            this.t=5;
            this.fdirection=0.0f;
            this.range=360;
            this.speed=0.0f;
            this.speedd=0.0f;
            this.aspeed=0.0f;
            this.aspeedd=0.0f;
            this.sonlife=200;
            this.type=1f;
            this.wscale=1f;
            this.hscale=1f;
            this.colorR=(float)byte.MaxValue;
            this.colorG=(float)byte.MaxValue;
            this.colorB=(float)byte.MaxValue;
            this.alpha=100f;
            this.head=0.0f;
            this.Withspeedd=true;
            this.sonspeed=5f;
            this.sonspeedd=0.0f;
            this.sonaspeed=0.0f;
            this.sonaspeedd=0.0f;
            this.xscale=1f;
            this.yscale=1f;
            this.Mist=true;
            this.Dispel=true;
            this.Blend=false;
            this.Afterimage=false;
            this.Outdispel=true;
            this.Invincible=false;
            this.Cover=true;
            this.Rebound=true;
            this.Force=true;
        }

        public void Update() {
            int x = Main.mousestate.X;
            int y = Main.mousestate.Y;
            if(Main.mousestate.LeftButton==ButtonState.Pressed&Main.prostate.LeftButton!=ButtonState.Pressed) {
                if((double)x>150.0+(double)this.x-(double)this.Searched&(double)x<150.0+(double)this.x+32.0+(double)this.Searched&(double)y>22.0+(double)this.y+(double)this.Searched&(double)y<22.0+(double)this.y+32.0+(double)this.Searched) {
                    if(!this.Selecting) {
                        if(Batch.record<Layer.LayerArray[this.parentid].BatchArray.Count)
                            Layer.LayerArray[this.parentid].BatchArray[Batch.record].Selecting=false;
                        foreach(Layer layer in Layer.LayerArray) {
                            for(int index = 0;index<layer.BatchArray.Count;++index) {
                                if(layer.BatchArray[index].parentid<this.parentid)
                                    layer.BatchArray[index].Selecting=false;
                            }
                            for(int index = 0;index<layer.LaseArray.Count;++index)
                                layer.LaseArray[index].Selecting=false;
                            for(int index = 0;index<layer.CoverArray.Count;++index)
                                layer.CoverArray[index].Selecting=false;
                            for(int index = 0;index<layer.ReboundArray.Count;++index)
                                layer.ReboundArray[index].Selecting=false;
                            for(int index = 0;index<layer.ForceArray.Count;++index)
                                layer.ForceArray[index].Selecting=false;
                        }
                        Batch.record=this.id;
                        this.Selecting=true; 
                    } else if(Main.keyboardstat.IsKeyDown(Keys.LeftControl)||Main.keyboardstat.IsKeyDown(Keys.RightControl)) {
                        this.Selecting=false;
                        this.Searched=0;
                    }
                } else if(!Main.keyboardstat.IsKeyDown(Keys.LeftControl)&!Main.keyboardstat.IsKeyDown(Keys.RightControl)) {
                    this.Selecting=false;
                    this.Searched=0;
                }
                if((double)x>150.0+(double)this.x-(double)this.Searched&(double)x<150.0+(double)this.x+32.0+(double)this.Searched&(double)y>22.0+(double)this.y-(double)this.Searched&(double)y<22.0+(double)this.y+32.0+(double)this.Searched) {
                    this.clwait=0;
                    ++this.clcount;
                    if(this.clcount==2&this.Selecting) {
                        this.clcount=0;
                        this.clwait=0;     
                    }
                }
            }
            if(this.clcount==1) {
                ++this.clwait;
                if(this.clwait>15) {
                    this.clwait=0;
                    this.clcount=0;
                }
            }
            if(this.Selecting) {
                if(Main.keyboardstat.IsKeyDown(Keys.Delete)&!Main.prekeyboard.IsKeyDown(Keys.Delete))
                    this.NeedDelete=true;
                if(Main.keyboardstat.IsKeyDown(Keys.Up)||Main.keyboardstat.IsKeyDown(Keys.W))
                    this.y=MathHelper.Clamp(this.y-1f,0.0f,448f);
                if(Main.keyboardstat.IsKeyDown(Keys.Down)||Main.keyboardstat.IsKeyDown(Keys.S))
                    this.y=MathHelper.Clamp(this.y+1f,0.0f,448f);
                if(Main.keyboardstat.IsKeyDown(Keys.Left)||Main.keyboardstat.IsKeyDown(Keys.A))
                    this.x=MathHelper.Clamp(this.x-1f,0.0f,640f);
                if(Main.keyboardstat.IsKeyDown(Keys.Right)||Main.keyboardstat.IsKeyDown(Keys.D))
                    this.x=MathHelper.Clamp(this.x+1f,0.0f,640f);
                Main.display=new Vector2((float)((double)this.x+170.0-4.0),(float)((double)this.y+22.0+16.0));
            }
            if(!Time.Playing) {
                this.aspeedx=this.aspeed*(float)Math.Cos((double)MathHelper.ToRadians(this.aspeedd));
                this.aspeedy=this.aspeed*(float)Math.Sin((double)MathHelper.ToRadians(this.aspeedd));
                this.speedx=this.speed*(float)Math.Cos((double)MathHelper.ToRadians(this.speedd));
                this.speedy=this.speed*(float)Math.Sin((double)MathHelper.ToRadians(this.speedd));
                this.begin=(int)MathHelper.Clamp((float)this.begin,(float)Layer.LayerArray[this.parentid].begin,(float)(1+Layer.LayerArray[this.parentid].end-Layer.LayerArray[this.parentid].begin));
                this.life=(int)MathHelper.Clamp((float)this.life,1f,(float)(Layer.LayerArray[this.parentid].end-Layer.LayerArray[this.parentid].begin+2-this.begin));
            }
            if(this.bindid==this.id) {
                this.bindid=-1;
                this.Deepbind=false;
                this.Bindwithspeedd=false;
            }
            if(this.bindid!=-1&&this.bindid>=Layer.LayerArray[this.parentid].BatchArray.Count) {
                this.bindid=-1;
                this.Deepbind=false;
                this.Bindwithspeedd=false;
            }
            if(!Time.Playing)
                return;
            if(this.Deepbinded)
                ++this.time;
            if(!(!this.Deepbinded&Time.now>=this.begin&Time.now<=this.begin+this.life-1)&&!(this.Deepbinded&this.time>=this.begin&this.time<=this.begin+this.life-1)&&!this.Deepbind)
                return;
            if(!this.Deepbind&!this.Deepbinded)
                this.time=Time.now-this.begin+1;
            if(!this.Deepbind) {
                this.speedx+=this.aspeedx;
                this.speedy+=this.aspeedy;
                this.x+=this.speedx;
                this.y+=this.speedy;
                this.fx+=this.speedx;
                this.fy+=this.speedy;
                this.conditions[0]=!this.Deepbinded ? (float)this.time : (float)(this.time-this.begin+1);
                this.conditions[1]=this.fx;
                this.conditions[2]=this.fy;
                this.conditions[3]=this.r;
                this.conditions[4]=this.rdirection;
                this.conditions[5]=(float)this.tiao;
                this.conditions[6]=(float)this.t;
                this.conditions[7]=this.fdirection;
                this.conditions[8]=(float)this.range;
                this.conditions[9]=this.wscale;
                this.conditions[10]=this.hscale;
                this.conditions[11]=this.alpha;
                this.conditions[12]=this.head;
                this.results[0]=this.fx;
                this.results[1]=this.fy;
                this.results[2]=this.r;
                this.results[3]=this.rdirection;
                this.results[4]=(float)this.tiao;
                this.results[5]=(float)this.t;
                this.results[6]=this.fdirection;
                this.results[7]=(float)this.range;
                this.results[8]=this.speed;
                this.results[9]=this.speedd;
                this.results[10]=this.aspeed;
                this.results[11]=this.aspeedd;
                this.results[12]=(float)this.life;
                this.results[13]=this.type;
                this.results[14]=this.wscale;
                this.results[15]=this.hscale;
                this.results[16]=this.colorR;
                this.results[17]=this.colorG;
                this.results[18]=this.colorB;
                this.results[19]=this.alpha;
                this.results[20]=this.head;
                this.results[21]=this.sonspeed;
                this.results[22]=this.sonspeedd;
                this.results[23]=this.sonaspeed;
                this.results[24]=this.sonaspeedd;
                this.results[25]=this.xscale;
                this.results[26]=this.yscale;
                this.results[27]=0.0f;
                this.results[28]=0.0f;
                this.results[29]=0.0f;
                this.results[30]=0.0f;
                this.results[31]=0.0f;
                this.results[32]=0.0f;
                foreach(Event parentevent in this.Parentevents) {
                    if(parentevent.t<=0)
                        parentevent.t=1;
                    if(this.time%parentevent.t==0)
                        ++parentevent.loop;
                    foreach(EventRead result in parentevent.results) {
                        if(result.special==3) {
                            if(result.changevalue==0)
                                result.res=this.x-4f;
                            if(result.changevalue==1)
                                result.res=this.y+16f;
                            if(result.changevalue==6)
                                result.res=MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,this.fx,this.fy));
                            if(result.changevalue==24)
                                result.res=MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,this.fx,this.fy));
                        }
                        if(result.special==4) {
                            if(result.changevalue==0)
                                result.res=Player.position.X;
                            if(result.changevalue==1)
                                result.res=Player.position.Y;
                            if(result.changevalue==3)
                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.fx,this.fy));
                            if(result.changevalue==6)
                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.fx,this.fy));
                            if(result.changevalue==9)
                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.fx,this.fy));
                            if(result.changevalue==11)
                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.fx,this.fy));
                            if(result.changevalue==24)
                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.fx,this.fy));
                        }
                        if(result.opreator==">") {
                            if(result.opreator2==">") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        if(result.special==1)
                                            this.Recover();
                                        else if(result.special==2) {
                                            this.Shoot();
                                        } else {
                                            Execution execution = new Execution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                execution.parentid=this.parentid;
                                                execution.id=this.id;
                                                execution.change=result.change;
                                                execution.changetype=result.changetype;
                                                execution.changevalue=result.changevalue;
                                                execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                execution.region=this.results[result.changename].ToString();
                                                execution.time=result.times;
                                                execution.ctime=execution.time;
                                                this.Eventsexe.Add(execution);
                                            } else
                                                continue;
                                        }
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    if(result.special==1)
                                        this.Recover();
                                    else if(result.special==2) {
                                        this.Shoot();
                                    } else {
                                        Execution execution = new Execution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            execution.parentid=this.parentid;
                                            execution.id=this.id;
                                            execution.change=result.change;
                                            execution.changetype=result.changetype;
                                            execution.changevalue=result.changevalue;
                                            execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            execution.region=this.results[result.changename].ToString();
                                            execution.time=result.times;
                                            execution.ctime=execution.time;
                                            this.Eventsexe.Add(execution);
                                        } else
                                            continue;
                                    }
                                }
                            } else if(result.opreator2=="=") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        if(result.special==1)
                                            this.Recover();
                                        else if(result.special==2) {
                                            this.Shoot();
                                        } else {
                                            Execution execution = new Execution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                execution.parentid=this.parentid;
                                                execution.id=this.id;
                                                execution.change=result.change;
                                                execution.changetype=result.changetype;
                                                execution.changevalue=result.changevalue;
                                                execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                execution.region=this.results[result.changename].ToString();
                                                execution.time=result.times;
                                                execution.ctime=execution.time;
                                                this.Eventsexe.Add(execution);
                                            } else
                                                continue;
                                        }
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    if(result.special==1)
                                        this.Recover();
                                    else if(result.special==2) {
                                        this.Shoot();
                                    } else {
                                        Execution execution = new Execution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            execution.parentid=this.parentid;
                                            execution.id=this.id;
                                            execution.change=result.change;
                                            execution.changetype=result.changetype;
                                            execution.changevalue=result.changevalue;
                                            execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            execution.region=this.results[result.changename].ToString();
                                            execution.time=result.times;
                                            execution.ctime=execution.time;
                                            this.Eventsexe.Add(execution);
                                        } else
                                            continue;
                                    }
                                }
                            } else if(result.opreator2=="<") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        if(result.special==1)
                                            this.Recover();
                                        else if(result.special==2) {
                                            this.Shoot();
                                        } else {
                                            Execution execution = new Execution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                execution.parentid=this.parentid;
                                                execution.id=this.id;
                                                execution.change=result.change;
                                                execution.changetype=result.changetype;
                                                execution.changevalue=result.changevalue;
                                                execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                execution.region=this.results[result.changename].ToString();
                                                execution.time=result.times;
                                                execution.ctime=execution.time;
                                                this.Eventsexe.Add(execution);
                                            } else
                                                continue;
                                        }
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    if(result.special==1)
                                        this.Recover();
                                    else if(result.special==2) {
                                        this.Shoot();
                                    } else {
                                        Execution execution = new Execution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            execution.parentid=this.parentid;
                                            execution.id=this.id;
                                            execution.change=result.change;
                                            execution.changetype=result.changetype;
                                            execution.changevalue=result.changevalue;
                                            execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            execution.region=this.results[result.changename].ToString();
                                            execution.time=result.times;
                                            execution.ctime=execution.time;
                                            this.Eventsexe.Add(execution);
                                        } else
                                            continue;
                                    }
                                }
                            } else if((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)) {
                                if(result.special==1)
                                    this.Recover();
                                else if(result.special==2) {
                                    this.Shoot();
                                } else {
                                    Execution execution = new Execution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        execution.parentid=this.parentid;
                                        execution.id=this.id;
                                        execution.change=result.change;
                                        execution.changetype=result.changetype;
                                        execution.changevalue=result.changevalue;
                                        execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        execution.region=this.results[result.changename].ToString();
                                        execution.time=result.times;
                                        execution.ctime=execution.time;
                                        this.Eventsexe.Add(execution);
                                    } else
                                        continue;
                                }
                            }
                        }
                        if(result.opreator=="=") {
                            if(result.opreator2==">") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        if(result.special==1)
                                            this.Recover();
                                        else if(result.special==2) {
                                            this.Shoot();
                                        } else {
                                            Execution execution = new Execution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                execution.parentid=this.parentid;
                                                execution.id=this.id;
                                                execution.change=result.change;
                                                execution.changetype=result.changetype;
                                                execution.changevalue=result.changevalue;
                                                execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                execution.region=this.results[result.changename].ToString();
                                                execution.time=result.times;
                                                execution.ctime=execution.time;
                                                this.Eventsexe.Add(execution);
                                            } else
                                                continue;
                                        }
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    if(result.special==1)
                                        this.Recover();
                                    else if(result.special==2) {
                                        this.Shoot();
                                    } else {
                                        Execution execution = new Execution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            execution.parentid=this.parentid;
                                            execution.id=this.id;
                                            execution.change=result.change;
                                            execution.changetype=result.changetype;
                                            execution.changevalue=result.changevalue;
                                            execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            execution.region=this.results[result.changename].ToString();
                                            execution.time=result.times;
                                            execution.ctime=execution.time;
                                            this.Eventsexe.Add(execution);
                                        } else
                                            continue;
                                    }
                                }
                            } else if(result.opreator2=="=") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        if(result.special==1)
                                            this.Recover();
                                        else if(result.special==2) {
                                            this.Shoot();
                                        } else {
                                            Execution execution = new Execution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                execution.parentid=this.parentid;
                                                execution.id=this.id;
                                                execution.change=result.change;
                                                execution.changetype=result.changetype;
                                                execution.changevalue=result.changevalue;
                                                execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                execution.region=this.results[result.changename].ToString();
                                                execution.time=result.times;
                                                execution.ctime=execution.time;
                                                this.Eventsexe.Add(execution);
                                            } else
                                                continue;
                                        }
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    if(result.special==1)
                                        this.Recover();
                                    else if(result.special==2) {
                                        this.Shoot();
                                    } else {
                                        Execution execution = new Execution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            execution.parentid=this.parentid;
                                            execution.id=this.id;
                                            execution.change=result.change;
                                            execution.changetype=result.changetype;
                                            execution.changevalue=result.changevalue;
                                            execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            execution.region=this.results[result.changename].ToString();
                                            execution.time=result.times;
                                            execution.ctime=execution.time;
                                            this.Eventsexe.Add(execution);
                                        } else
                                            continue;
                                    }
                                }
                            } else if(result.opreator2=="<") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        if(result.special==1)
                                            this.Recover();
                                        else if(result.special==2) {
                                            this.Shoot();
                                        } else {
                                            Execution execution = new Execution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                execution.parentid=this.parentid;
                                                execution.id=this.id;
                                                execution.change=result.change;
                                                execution.changetype=result.changetype;
                                                execution.changevalue=result.changevalue;
                                                execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                execution.region=this.results[result.changename].ToString();
                                                execution.time=result.times;
                                                execution.ctime=execution.time;
                                                this.Eventsexe.Add(execution);
                                            } else
                                                continue;
                                        }
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    if(result.special==1)
                                        this.Recover();
                                    else if(result.special==2) {
                                        this.Shoot();
                                    } else {
                                        Execution execution = new Execution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            execution.parentid=this.parentid;
                                            execution.id=this.id;
                                            execution.change=result.change;
                                            execution.changetype=result.changetype;
                                            execution.changevalue=result.changevalue;
                                            execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            execution.region=this.results[result.changename].ToString();
                                            execution.time=result.times;
                                            execution.ctime=execution.time;
                                            this.Eventsexe.Add(execution);
                                        } else
                                            continue;
                                    }
                                }
                            } else if((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)) {
                                if(result.special==1)
                                    this.Recover();
                                else if(result.special==2) {
                                    this.Shoot();
                                } else {
                                    Execution execution = new Execution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        execution.parentid=this.parentid;
                                        execution.id=this.id;
                                        execution.change=result.change;
                                        execution.changetype=result.changetype;
                                        execution.changevalue=result.changevalue;
                                        execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        execution.region=this.results[result.changename].ToString();
                                        execution.time=result.times;
                                        execution.ctime=execution.time;
                                        this.Eventsexe.Add(execution);
                                    } else
                                        continue;
                                }
                            }
                        }
                        if(result.opreator=="<") {
                            if(result.opreator2==">") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        if(result.special==1)
                                            this.Recover();
                                        else if(result.special==2) {
                                            this.Shoot();
                                        } else {
                                            Execution execution = new Execution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                execution.parentid=this.parentid;
                                                execution.id=this.id;
                                                execution.change=result.change;
                                                execution.changetype=result.changetype;
                                                execution.changevalue=result.changevalue;
                                                execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                execution.region=this.results[result.changename].ToString();
                                                execution.time=result.times;
                                                execution.ctime=execution.time;
                                                this.Eventsexe.Add(execution);
                                            }
                                        }
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    if(result.special==1)
                                        this.Recover();
                                    else if(result.special==2) {
                                        this.Shoot();
                                    } else {
                                        Execution execution = new Execution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            execution.parentid=this.parentid;
                                            execution.id=this.id;
                                            execution.change=result.change;
                                            execution.changetype=result.changetype;
                                            execution.changevalue=result.changevalue;
                                            execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            execution.region=this.results[result.changename].ToString();
                                            execution.time=result.times;
                                            execution.ctime=execution.time;
                                            this.Eventsexe.Add(execution);
                                        }
                                    }
                                }
                            } else if(result.opreator2=="=") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        if(result.special==1)
                                            this.Recover();
                                        else if(result.special==2) {
                                            this.Shoot();
                                        } else {
                                            Execution execution = new Execution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                execution.parentid=this.parentid;
                                                execution.id=this.id;
                                                execution.change=result.change;
                                                execution.changetype=result.changetype;
                                                execution.changevalue=result.changevalue;
                                                execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                execution.region=this.results[result.changename].ToString();
                                                execution.time=result.times;
                                                execution.ctime=execution.time;
                                                this.Eventsexe.Add(execution);
                                            }
                                        }
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    if(result.special==1)
                                        this.Recover();
                                    else if(result.special==2) {
                                        this.Shoot();
                                    } else {
                                        Execution execution = new Execution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            execution.parentid=this.parentid;
                                            execution.id=this.id;
                                            execution.change=result.change;
                                            execution.changetype=result.changetype;
                                            execution.changevalue=result.changevalue;
                                            execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            execution.region=this.results[result.changename].ToString();
                                            execution.time=result.times;
                                            execution.ctime=execution.time;
                                            this.Eventsexe.Add(execution);
                                        }
                                    }
                                }
                            } else if(result.opreator2=="<") {
                                if(result.collector=="且") {
                                    if((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)&(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime)) {
                                        if(result.special==1)
                                            this.Recover();
                                        else if(result.special==2) {
                                            this.Shoot();
                                        } else {
                                            Execution execution = new Execution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                execution.parentid=this.parentid;
                                                execution.id=this.id;
                                                execution.change=result.change;
                                                execution.changetype=result.changetype;
                                                execution.changevalue=result.changevalue;
                                                execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                execution.region=this.results[result.changename].ToString();
                                                execution.time=result.times;
                                                execution.ctime=execution.time;
                                                this.Eventsexe.Add(execution);
                                            }
                                        }
                                    }
                                } else if(result.collector=="或"&&((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)||(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(parentevent.loop*parentevent.addtime))) {
                                    if(result.special==1)
                                        this.Recover();
                                    else if(result.special==2) {
                                        this.Shoot();
                                    } else {
                                        Execution execution = new Execution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            execution.parentid=this.parentid;
                                            execution.id=this.id;
                                            execution.change=result.change;
                                            execution.changetype=result.changetype;
                                            execution.changevalue=result.changevalue;
                                            execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            execution.region=this.results[result.changename].ToString();
                                            execution.time=result.times;
                                            execution.ctime=execution.time;
                                            this.Eventsexe.Add(execution);
                                        }
                                    }
                                }
                            } else if((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(parentevent.loop*parentevent.addtime)) {
                                if(result.special==1)
                                    this.Recover();
                                else if(result.special==2) {
                                    this.Shoot();
                                } else {
                                    Execution execution = new Execution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        execution.parentid=this.parentid;
                                        execution.id=this.id;
                                        execution.change=result.change;
                                        execution.changetype=result.changetype;
                                        execution.changevalue=result.changevalue;
                                        execution.value=(double)result.rand==0.0 ? result.res : result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        execution.region=this.results[result.changename].ToString();
                                        execution.time=result.times;
                                        execution.ctime=execution.time;
                                        this.Eventsexe.Add(execution);
                                    }
                                }
                            }
                        }
                    }
                }
                for(int index = 0;index<this.Eventsexe.Count;++index) {
                    if(!this.Eventsexe[index].NeedDelete) {
                        this.Eventsexe[index].Update(this);
                    } else {
                        this.Eventsexe.RemoveAt(index);
                        --index;
                    }
                }
            }
            if(this.t<=0)
                return;
            if(this.Deepbind) {
                this.Shoot();
            } else {
                if(this.time%this.t+(int)MathHelper.Lerp((float)-this.rand.t,(float)this.rand.t,(float)Main.rand.NextDouble())!=0)
                    return;
                this.Shoot();
            }
        }

        private void Shoot() {
            int num1 = this.tiao+(int)MathHelper.Lerp((float)-this.rand.tiao,(float)this.rand.tiao,(float)Main.rand.NextDouble());
            float num2 = (float)(int)MathHelper.Lerp(-this.rand.fx,this.rand.fx,(float)Main.rand.NextDouble());
            float num3 = (float)(int)MathHelper.Lerp(-this.rand.fy,this.rand.fy,(float)Main.rand.NextDouble());
            int num4 = (int)MathHelper.Lerp(-this.rand.r,this.rand.r,(float)Main.rand.NextDouble());
            float num5 = MathHelper.Lerp(-this.rand.rdirection,this.rand.rdirection,(float)Main.rand.NextDouble());
            float num6 = (float)(int)MathHelper.Lerp(-this.rand.head,this.rand.head,(float)Main.rand.NextDouble());
            int num7 = (int)MathHelper.Lerp((float)-this.rand.range,(float)this.rand.range,(float)Main.rand.NextDouble());
            float num8 = MathHelper.Lerp(-this.rand.sonspeed,this.rand.sonspeed,(float)Main.rand.NextDouble());
            float num9 = MathHelper.Lerp(-this.rand.fdirection,this.rand.fdirection,(float)Main.rand.NextDouble());
            float num10 = MathHelper.Lerp(-this.rand.sonaspeed,this.rand.sonaspeed,(float)Main.rand.NextDouble());
            float num11 = MathHelper.Lerp(-this.rand.sonaspeedd,this.rand.sonaspeedd,(float)Main.rand.NextDouble());
            float val1 = MathHelper.Lerp(-this.rand.wscale,this.rand.wscale,(float)Main.rand.NextDouble());
            float val2 = MathHelper.Lerp(-this.rand.hscale,this.rand.hscale,(float)Main.rand.NextDouble());
            if(this.bindid==-1) {
                for(int index1 = 0;index1<num1;++index1) {
                    Barrage barrage = new Barrage();
                    if((double)Layer.LayerArray[this.parentid].BatchArray[this.id].rdirection==-99999.0)
                        this.rdirection=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.fx,this.fy));
                    float degrees = this.rdirection+((float)index1-(float)(((double)num1-1.0)/2.0))*(float)(this.range+num7)/(float)num1+num5;
                    barrage.x=this.fx+(float)(((double)this.r+(double)num4)*Math.Cos((double)MathHelper.ToRadians(degrees)))+num2+Center.ox-Center.x;
                    barrage.y=this.fy+(float)(((double)this.r+(double)num4)*Math.Sin((double)MathHelper.ToRadians(degrees)))+num3+Center.oy-Center.y;
                    barrage.life=this.sonlife;
                    barrage.type=(int)this.type-1;
                    barrage.wscale=this.wscale+Math.Max(val1,val2);
                    barrage.hscale=this.hscale+Math.Max(val1,val2);
                    barrage.head=this.head+num6;
                    barrage.alpha=this.alpha;
                    barrage.R=this.colorR;
                    barrage.G=this.colorG;
                    barrage.B=this.colorB;
                    barrage.speed=this.sonspeed+num8;
                    barrage.aspeed=this.sonaspeed+num10;
                    barrage.fx=this.x-4f;
                    barrage.fy=this.y+16f;
                    barrage.fdirection=(double)this.bfdirection<-99997.0 ? this.bfdirection : this.fdirection;
                    barrage.fdirections=this.fdirections;
                    barrage.randfdirection=num9;
                    barrage.g=index1;
                    barrage.tiaos=num1;
                    barrage.range=this.range;
                    barrage.randrange=num7;
                    barrage.sonaspeedd=(double)this.bsonaspeedd<-99997.0 ? this.bsonaspeedd : this.sonaspeedd;
                    barrage.sonaspeedds=this.sonaspeedds;
                    barrage.randsonaspeedd=num11;
                    barrage.Withspeedd=this.Withspeedd;
                    barrage.xscale=this.xscale;
                    barrage.yscale=this.yscale;
                    barrage.Mist=this.Mist;
                    barrage.Dispel=this.Dispel;
                    barrage.Blend=this.Blend;
                    barrage.Outdispel=this.Outdispel;
                    barrage.Afterimage=this.Afterimage;
                    barrage.Invincible=this.Invincible;
                    barrage.Cover=this.Cover;
                    barrage.Rebound=this.Rebound;
                    barrage.Force=this.Force;
                    for(int idx = 0;idx<this.Sonevents.Count;++idx) {
                        Event @event = new Event(idx);
                        @event.t=this.Sonevents[idx].t;
                        @event.addtime=this.Sonevents[idx].addtime;
                        @event.events=this.Sonevents[idx].events;
                        for(int index2 = 0;index2<this.Sonevents[idx].results.Count;++index2)
                            @event.results.Add((EventRead)this.Sonevents[idx].results[index2].Copy());
                        @event.index=this.Sonevents[idx].index;
                        barrage.Events.Add(@event);
                    }
                    barrage.parentid=this.id;
                    Layer.LayerArray[this.parentid].Barrages.Add(barrage);
                }
            } else {
                for(int index1 = 0;index1<Layer.LayerArray[this.parentid].Barrages.Count;++index1) {
                    if(((!Layer.LayerArray[this.parentid].Barrages[index1].IsLase&Layer.LayerArray[this.parentid].Barrages[index1].parentid==this.bindid ? 1 : 0)&(Layer.LayerArray[this.parentid].Barrages[index1].time>15 ? 1 : (!Layer.LayerArray[this.parentid].Barrages[index1].Mist ? 1 : 0))&(!Layer.LayerArray[this.parentid].Barrages[index1].NeedDelete ? 1 : 0))!=0) {
                        if(this.Deepbind) {
                            if(Layer.LayerArray[this.parentid].Barrages[index1].batch!=null) {
                                Layer.LayerArray[this.parentid].Barrages[index1].batch.x=Layer.LayerArray[this.parentid].Barrages[index1].x;
                                Layer.LayerArray[this.parentid].Barrages[index1].batch.y=Layer.LayerArray[this.parentid].Barrages[index1].y;
                                Layer.LayerArray[this.parentid].Barrages[index1].batch.fx=Layer.LayerArray[this.parentid].Barrages[index1].x;
                                Layer.LayerArray[this.parentid].Barrages[index1].batch.fy=Layer.LayerArray[this.parentid].Barrages[index1].y;
                                Layer.LayerArray[this.parentid].Barrages[index1].batch.Update();
                            } else {
                                Layer.LayerArray[this.parentid].Barrages[index1].batch=this.BindClone();
                                Layer.LayerArray[this.parentid].Barrages[index1].batch.Deepbind=false;
                                Layer.LayerArray[this.parentid].Barrages[index1].batch.Deepbinded=true;
                                Layer.LayerArray[this.parentid].Barrages[index1].batch.bindid=-1;
                                Layer.LayerArray[this.parentid].Barrages[index1].batch.time=0;
                                if(this.Bindwithspeedd)
                                    Layer.LayerArray[this.parentid].Barrages[index1].batch.fdirection+=Layer.LayerArray[this.parentid].Barrages[index1].fdirection;
                                Layer.LayerArray[this.parentid].Barrages[index1].batch.Bindwithspeedd=false;
                            }
                        } else {
                            for(int index2 = 0;index2<num1;++index2) {
                                Barrage barrage = new Barrage();
                                if((double)Layer.LayerArray[this.parentid].BatchArray[this.id].rdirection==-99999.0)
                                    this.rdirection=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,Layer.LayerArray[this.parentid].Barrages[index1].x,Layer.LayerArray[this.parentid].Barrages[index1].y));
                                float degrees = this.rdirection+((float)index2-(float)(((double)num1-1.0)/2.0))*(float)(this.range+num7)/(float)num1+num5;
                                barrage.x=Layer.LayerArray[this.parentid].Barrages[index1].x+(float)(((double)this.r+(double)num4)*Math.Cos((double)MathHelper.ToRadians(degrees)))+num2;
                                barrage.y=Layer.LayerArray[this.parentid].Barrages[index1].y+(float)(((double)this.r+(double)num4)*Math.Sin((double)MathHelper.ToRadians(degrees)))+num3;
                                barrage.life=this.sonlife;
                                barrage.type=(int)this.type-1;
                                barrage.wscale=this.wscale+Math.Max(val1,val2);
                                barrage.hscale=this.hscale+Math.Max(val1,val2);
                                if((double)Layer.LayerArray[this.parentid].BatchArray[this.id].head==-100000.0)
                                    this.head=MathHelper.ToDegrees(Main.Twopointangle(this.heads.X,this.heads.Y,barrage.x,barrage.y));
                                barrage.head=this.head+num6;
                                barrage.alpha=this.alpha;
                                barrage.R=this.colorR;
                                barrage.G=this.colorG;
                                barrage.B=this.colorB;
                                barrage.speed=this.sonspeed+num8;
                                barrage.aspeed=this.sonaspeed+num10;
                                barrage.fx=this.x-4f;
                                barrage.fy=this.y+16f;
                                barrage.fdirection=(double)this.bfdirection<-99997.0 ? this.bfdirection : this.fdirection;
                                barrage.bindspeedd=Layer.LayerArray[this.parentid].Barrages[index1].speedd;
                                barrage.Bindwithspeedd=this.Bindwithspeedd;
                                barrage.fdirections=this.fdirections;
                                barrage.randfdirection=num9;
                                barrage.g=index2;
                                barrage.tiaos=num1;
                                barrage.range=this.range;
                                barrage.randrange=num7;
                                barrage.sonaspeedd=(double)this.bsonaspeedd<-99997.0 ? this.bsonaspeedd : this.sonaspeedd;
                                barrage.sonaspeedds=this.sonaspeedds;
                                barrage.randsonaspeedd=num11;
                                barrage.Withspeedd=this.Withspeedd;
                                barrage.xscale=this.xscale;
                                barrage.yscale=this.yscale;
                                barrage.Mist=this.Mist;
                                barrage.Dispel=this.Dispel;
                                barrage.Blend=this.Blend;
                                barrage.Outdispel=this.Outdispel;
                                barrage.Afterimage=this.Afterimage;
                                barrage.Invincible=this.Invincible;
                                barrage.Cover=this.Cover;
                                barrage.Rebound=this.Rebound;
                                barrage.Force=this.Force;
                                for(int idx = 0;idx<this.Sonevents.Count;++idx) {
                                    Event @event = new Event(idx);
                                    @event.t=this.Sonevents[idx].t;
                                    @event.addtime=this.Sonevents[idx].addtime;
                                    @event.events=this.Sonevents[idx].events;
                                    for(int index3 = 0;index3<this.Sonevents[idx].results.Count;++index3)
                                        @event.results.Add((EventRead)this.Sonevents[idx].results[index3].Copy());
                                    @event.index=this.Sonevents[idx].index;
                                    barrage.Events.Add(@event);
                                }
                                barrage.parentid=this.id;
                                Layer.LayerArray[this.parentid].Barrages.Add(barrage);
                            }
                        }
                    }
                }
            }
        }

        public void Draw(SpriteBatch s) {
            if(this.Searched!=0)
                s.Draw(Main.layercolor,new Vector2((float)(150.0+(double)this.x-1.0-4.0),(float)(22.0+(double)this.y-1.0-4.0)),new Rectangle?(new Rectangle(14*this.parentcolor,0,14,14)),Color.White,0.0f,Vector2.Zero,3f,SpriteEffects.None,1f);
            else
                s.Draw(Main.layercolor,new Vector2((float)(150.0+(double)this.x-1.0),(float)(22.0+(double)this.y-1.0)),new Rectangle?(new Rectangle(14*this.parentcolor,0,14,14)),Color.White,0.0f,Vector2.Zero,2.4f,SpriteEffects.None,1f);
            s.Draw(Main.item,new Vector2((float)(150.0+(double)this.x+1.0),(float)(22.0+(double)this.y+1.0)),new Rectangle?(new Rectangle(0,0,30,30)),Color.White,0.0f,Vector2.Zero,1f,SpriteEffects.None,1f);
            if(this.id<=8)
                Main.font.Draw(s,"0"+(this.id+1).ToString(),new Vector2((float)(150.0+(double)this.x+18.0),(float)(22.0+(double)this.y+21.0)),Color.Black);
            else
                Main.font.Draw(s,(this.id+1).ToString(),new Vector2((float)(150.0+(double)this.x+18.0),(float)(22.0+(double)this.y+21.0)),Color.Black);
            if(!this.Selecting)
                return;
            s.Draw(Main.create,new Vector2((float)(150.0+(double)this.x-1.0),(float)(22.0+(double)this.y-1.0)),Color.White);
        }

        public Batch BindClone() {
            Batch batch = this.Copy() as Batch;
            batch.Parentevents=new List<Event>();
            foreach(Event parentevent in this.Parentevents)
                batch.Parentevents.Add((Event)parentevent.Clone());
            batch.Eventsexe=new List<Execution>();
            foreach(Execution execution in this.Eventsexe)
                batch.Eventsexe.Add((Execution)execution.Clone());
            batch.Sonevents=new List<Event>();
            foreach(Event sonevent in this.Sonevents)
                batch.Sonevents.Add((Event)sonevent.Clone());
            return batch;
        }

        public object Clone() {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize((Stream)memoryStream,(object)this);
            memoryStream.Seek(0L,SeekOrigin.Begin);
            object obj = binaryFormatter.Deserialize((Stream)memoryStream);
            memoryStream.Close();
            return obj;
        }

        public object Copy() {
            return this.MemberwiseClone();
        }

        public void Recover() {
            this.x=Layer.LayerArray[this.parentid].BatchArray[this.id].x;
            this.y=Layer.LayerArray[this.parentid].BatchArray[this.id].y;
            this.parentcolor=Layer.LayerArray[this.parentid].BatchArray[this.id].parentcolor;
            this.begin=Layer.LayerArray[this.parentid].BatchArray[this.id].begin;
            this.life=Layer.LayerArray[this.parentid].BatchArray[this.id].life;
            this.fx=Layer.LayerArray[this.parentid].BatchArray[this.id].fx;
            this.fy=Layer.LayerArray[this.parentid].BatchArray[this.id].fy;
            this.r=Layer.LayerArray[this.parentid].BatchArray[this.id].r;
            this.rdirection=Layer.LayerArray[this.parentid].BatchArray[this.id].rdirection;
            this.tiao=Layer.LayerArray[this.parentid].BatchArray[this.id].tiao;
            this.t=Layer.LayerArray[this.parentid].BatchArray[this.id].t;
            this.fdirection=Layer.LayerArray[this.parentid].BatchArray[this.id].fdirection;
            this.range=Layer.LayerArray[this.parentid].BatchArray[this.id].range;
            this.speed=Layer.LayerArray[this.parentid].BatchArray[this.id].speed;
            this.speedd=Layer.LayerArray[this.parentid].BatchArray[this.id].speedd;
            this.aspeed=Layer.LayerArray[this.parentid].BatchArray[this.id].aspeed;
            this.aspeedd=Layer.LayerArray[this.parentid].BatchArray[this.id].aspeedd;
            this.sonlife=Layer.LayerArray[this.parentid].BatchArray[this.id].sonlife;
            this.type=Layer.LayerArray[this.parentid].BatchArray[this.id].type;
            this.wscale=Layer.LayerArray[this.parentid].BatchArray[this.id].wscale;
            this.hscale=Layer.LayerArray[this.parentid].BatchArray[this.id].hscale;
            this.colorR=Layer.LayerArray[this.parentid].BatchArray[this.id].colorR;
            this.colorG=Layer.LayerArray[this.parentid].BatchArray[this.id].colorG;
            this.colorB=Layer.LayerArray[this.parentid].BatchArray[this.id].colorB;
            this.alpha=Layer.LayerArray[this.parentid].BatchArray[this.id].alpha;
            this.head=Layer.LayerArray[this.parentid].BatchArray[this.id].head;
            this.Withspeedd=Layer.LayerArray[this.parentid].BatchArray[this.id].Withspeedd;
            this.sonspeed=Layer.LayerArray[this.parentid].BatchArray[this.id].sonspeed;
            this.sonspeedd=Layer.LayerArray[this.parentid].BatchArray[this.id].sonspeedd;
            this.sonaspeed=Layer.LayerArray[this.parentid].BatchArray[this.id].sonaspeed;
            this.sonaspeedd=Layer.LayerArray[this.parentid].BatchArray[this.id].sonaspeedd;
            this.xscale=Layer.LayerArray[this.parentid].BatchArray[this.id].xscale;
            this.yscale=Layer.LayerArray[this.parentid].BatchArray[this.id].yscale;
            this.Mist=Layer.LayerArray[this.parentid].BatchArray[this.id].Mist;
            this.Dispel=Layer.LayerArray[this.parentid].BatchArray[this.id].Dispel;
            this.Blend=Layer.LayerArray[this.parentid].BatchArray[this.id].Blend;
            this.Afterimage=Layer.LayerArray[this.parentid].BatchArray[this.id].Afterimage;
            this.Outdispel=Layer.LayerArray[this.parentid].BatchArray[this.id].Outdispel;
            this.Invincible=Layer.LayerArray[this.parentid].BatchArray[this.id].Invincible;
        }

        public void PreviewUpdate() {
            if(!(Time.now>=this.begin&Time.now<=this.begin+this.life-1))
                return;
            int now = Time.now;
            this.speedx+=this.aspeedx;
            this.speedy+=this.aspeedy;
            this.x+=this.speedx;
            this.y+=this.speedy;
            this.fx+=this.speedx;
            this.fy+=this.speedy;
        }
    }
}
