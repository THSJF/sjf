using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace CrazyStorm_1._03 {
    public class Barrage {
        public int id = -1;
        public int parentid = -2;
        public Shadows[] savesha = new Shadows[50];
        public List<int> Covered = new List<int>();
        public float dscale = 0.9f;
        private float[] conditions = new float[3];
        private float[] results = new float[21];
        public bool IsLase;
        public bool IsRay;
        public int shatime;
        public bool NeedDelete;
        public bool Dis;
        public int life;
        public int time;
        public int type;
        public float x;
        public float y;
        public float wscale;
        public float rwscale;
        public float hscale;
        public float longs;
        public float rlongs;
        public float randf;
        public float R;
        public float G;
        public float B;
        public float alpha;
        public float head;
        public float speed;
        public float speedx;
        public float speedy;
        public float bspeedx;
        public float bspeedy;
        public float speedd;
        public float vf;
        public float aspeed;
        public float aspeedx;
        public float aspeedy;
        public float aspeedd;
        public bool Withspeedd;
        public float fdirection;
        public float sonaspeedd;
        public float fx;
        public float fy;
        public Microsoft.Xna.Framework.Vector2 fdirections;
        public Microsoft.Xna.Framework.Vector2 sonaspeedds;
        public float randfdirection;
        public float randsonaspeedd;
        public int g;
        public int tiaos;
        public int range;
        public int randrange;
        public float bindspeedd;
        public bool Bindwithspeedd;
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
        public bool Alreadylong;
        public int reboundtime;
        public int fadeout;
        public Batch batch;
        public Lase lase;
        public CrazyStorm_1._03.Cover cover;
        public List<Event> Events;
        public List<BExecution> Eventsexe;
        public List<BLExecution> LEventsexe;

        public Barrage() {
            this.NeedDelete=false;
            for(int index = 0;index<50;++index) {
                this.savesha[index]=new Shadows();
                this.savesha[index].x=this.x;
                this.savesha[index].y=this.y;
                this.savesha[index].alpha=0.0f;
            }
            this.Events=new List<Event>();
            this.Eventsexe=new List<BExecution>();
            this.LEventsexe=new List<BLExecution>();
        }

        public void Update() {
            if(!this.IsLase&this.type!=-2) {
                float x1 = this.x;
                float y1 = this.y;
                float x2 = Player.position.X;
                float y2 = Player.position.Y;
                int num1 = 0;
                if(this.Mist)
                    num1=15;
                ++this.time;
                if(this.type<=-1)
                    this.type=-1;
                if(this.type>=Main.bgset.Count)
                    this.type=Main.bgset.Count-1;
                if(this.time>15||!this.Mist) {
                    if(this.Mist&this.time==16||!this.Mist&this.time==1) {
                        if((double)this.fdirection==-99998.0)
                            this.fdirection=MathHelper.ToDegrees(Main.Twopointangle(this.fx,this.fy,this.x,this.y));
                        else if((double)this.fdirection==-99999.0)
                            this.fdirection=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                        else if((double)this.fdirection==-100000.0)
                            this.fdirection=MathHelper.ToDegrees(Main.Twopointangle(this.fdirections.X,this.fdirections.Y,this.x,this.y));
                        this.speedd=!this.Bindwithspeedd ? (float)((double)this.fdirection+(double)this.randfdirection+(double)((float)this.g-(float)(((double)this.tiaos-1.0)/2.0))*(double)(this.range+this.randrange)/(double)this.tiaos) : (float)((double)this.fdirection+(double)this.randfdirection+(double)((float)this.g-(float)(((double)this.tiaos-1.0)/2.0))*(double)(this.range+this.randrange)/(double)this.tiaos)+this.bindspeedd;
                        if((double)this.sonaspeedd==-99998.0)
                            this.sonaspeedd=MathHelper.ToDegrees(Main.Twopointangle(this.fx,this.fy,this.x,this.y));
                        else if((double)this.sonaspeedd==-99999.0)
                            this.sonaspeedd=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                        else if((double)this.sonaspeedd==-100000.0)
                            this.sonaspeedd=MathHelper.ToDegrees(Main.Twopointangle(this.sonaspeedds.X,this.sonaspeedds.Y,this.x,this.y));
                        this.aspeedd=this.sonaspeedd+this.randsonaspeedd;
                        this.speedx=this.xscale*this.speed*(float)Math.Cos((double)MathHelper.ToRadians(this.speedd));
                        this.speedy=this.yscale*this.speed*(float)Math.Sin((double)MathHelper.ToRadians(this.speedd));
                        this.aspeedx=this.xscale*this.aspeed*(float)Math.Cos((double)MathHelper.ToRadians(this.aspeedd));
                        this.aspeedy=this.yscale*this.aspeed*(float)Math.Sin((double)MathHelper.ToRadians(this.aspeedd));
                        if(this.Withspeedd)
                            this.head=this.speedd+90f;
                    }
                    if(!this.Dis) {
                        this.speedx+=this.aspeedx*Time.stop;
                        this.speedy+=this.aspeedy*Time.stop;
                        this.x+=this.speedx*Time.stop;
                        this.y+=this.speedy*Time.stop;
                    }
                    if((double)this.speed!=0.0) {
                        if((double)this.speedy!=0.0) {
                            this.vf=1.570796f-(float)Math.Atan((double)this.speedx/(double)this.xscale/((double)this.speedy/(double)this.yscale));
                            if((double)this.speedy<0.0)
                                this.vf+=3.141593f;
                        } else {
                            if((double)this.speedx>=0.0)
                                this.vf=0.0f;
                            if((double)this.speedx<0.0)
                                this.vf=3.141593f;
                        }
                        if((double)this.speed>0.0) {
                            this.speedd=MathHelper.ToDegrees(this.vf);
                            if(this.Withspeedd)
                                this.head=this.speedd;
                        } else if(this.Withspeedd)
                            this.head=MathHelper.ToDegrees(this.vf);
                    }
                    if(this.Afterimage&this.time<=num1+this.life) {
                        this.savesha[this.shatime].alpha=(float)(0.400000005960464*((double)this.alpha/100.0));
                        this.savesha[this.shatime].x=this.x;
                        this.savesha[this.shatime].y=this.y;
                        this.savesha[this.shatime].d=this.head;
                        ++this.shatime;
                        if(this.shatime>=49)
                            this.shatime=0;
                    } else
                        this.shatime=0;
                    this.conditions[0]=(float)(this.time-num1);
                    this.conditions[1]=this.x;
                    this.conditions[2]=this.y;
                    this.results[0]=(float)this.life;
                    this.results[1]=(float)this.type;
                    this.results[2]=this.wscale;
                    this.results[3]=this.hscale;
                    this.results[4]=this.R;
                    this.results[5]=this.G;
                    this.results[6]=this.B;
                    this.results[7]=this.alpha;
                    this.results[8]=this.head;
                    this.results[9]=this.speed;
                    this.results[10]=this.speedd;
                    this.results[11]=this.aspeed;
                    this.results[12]=this.aspeedd;
                    this.results[13]=this.xscale;
                    this.results[14]=this.yscale;
                    this.results[15]=0.0f;
                    this.results[16]=0.0f;
                    this.results[17]=0.0f;
                    this.results[18]=0.0f;
                    this.results[19]=0.0f;
                    this.results[20]=0.0f;
                    foreach(Event @event in this.Events) {
                        if(@event.t<=0)
                            @event.t=1;
                        if((this.time-num1)%@event.t==0)
                            ++@event.loop;
                        foreach(EventRead result in @event.results) {
                            if(result.special2==1)
                                this.conditions[0]=(float)Time.now;
                            if(result.opreator==">") {
                                if(result.opreator2==">") {
                                    if(result.collector=="且") {
                                        if((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==10)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                                if(result.changevalue==12)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            }
                                            BExecution bexecution = new BExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                bexecution.change=result.change;
                                                bexecution.changetype=result.changetype;
                                                bexecution.changevalue=result.changevalue;
                                                bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                bexecution.region=this.results[result.changename].ToString();
                                                bexecution.time=result.times;
                                                bexecution.ctime=bexecution.time;
                                                this.Eventsexe.Add(bexecution);
                                            } else
                                                continue;
                                        }
                                    } else if(result.collector=="或"&&((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==10)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            if(result.changevalue==12)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                        }
                                        BExecution bexecution = new BExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            bexecution.change=result.change;
                                            bexecution.changetype=result.changetype;
                                            bexecution.changevalue=result.changevalue;
                                            bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            bexecution.region=this.results[result.changename].ToString();
                                            bexecution.time=result.times;
                                            bexecution.ctime=bexecution.time;
                                            this.Eventsexe.Add(bexecution);
                                        } else
                                            continue;
                                    }
                                } else if(result.opreator2=="=") {
                                    if(result.collector=="且") {
                                        if((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==10)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                                if(result.changevalue==12)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            }
                                            BExecution bexecution = new BExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                bexecution.change=result.change;
                                                bexecution.changetype=result.changetype;
                                                bexecution.changevalue=result.changevalue;
                                                bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                bexecution.region=this.results[result.changename].ToString();
                                                bexecution.time=result.times;
                                                bexecution.ctime=bexecution.time;
                                                this.Eventsexe.Add(bexecution);
                                            } else
                                                continue;
                                        }
                                    } else if(result.collector=="或"&&((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==10)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            if(result.changevalue==12)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                        }
                                        BExecution bexecution = new BExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            bexecution.change=result.change;
                                            bexecution.changetype=result.changetype;
                                            bexecution.changevalue=result.changevalue;
                                            bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            bexecution.region=this.results[result.changename].ToString();
                                            bexecution.time=result.times;
                                            bexecution.ctime=bexecution.time;
                                            this.Eventsexe.Add(bexecution);
                                        } else
                                            continue;
                                    }
                                } else if(result.opreator2=="<") {
                                    if(result.collector=="且") {
                                        if((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==10)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                                if(result.changevalue==12)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            }
                                            BExecution bexecution = new BExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                bexecution.change=result.change;
                                                bexecution.changetype=result.changetype;
                                                bexecution.changevalue=result.changevalue;
                                                bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                bexecution.region=this.results[result.changename].ToString();
                                                bexecution.time=result.times;
                                                bexecution.ctime=bexecution.time;
                                                this.Eventsexe.Add(bexecution);
                                            } else
                                                continue;
                                        }
                                    } else if(result.collector=="或"&&((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==10)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            if(result.changevalue==12)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                        }
                                        BExecution bexecution = new BExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            bexecution.change=result.change;
                                            bexecution.changetype=result.changetype;
                                            bexecution.changevalue=result.changevalue;
                                            bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            bexecution.region=this.results[result.changename].ToString();
                                            bexecution.time=result.times;
                                            bexecution.ctime=bexecution.time;
                                            this.Eventsexe.Add(bexecution);
                                        } else
                                            continue;
                                    }
                                } else if((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)) {
                                    if(result.special==4) {
                                        if(result.changevalue==10)
                                            result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                        if(result.changevalue==12)
                                            result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                    }
                                    BExecution bexecution = new BExecution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        bexecution.change=result.change;
                                        bexecution.changetype=result.changetype;
                                        bexecution.changevalue=result.changevalue;
                                        bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        bexecution.region=this.results[result.changename].ToString();
                                        bexecution.time=result.times;
                                        bexecution.ctime=bexecution.time;
                                        this.Eventsexe.Add(bexecution);
                                    } else
                                        continue;
                                }
                            }
                            if(result.opreator=="=") {
                                if(result.opreator2==">") {
                                    if(result.collector=="且") {
                                        if((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==10)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                                if(result.changevalue==12)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            }
                                            BExecution bexecution = new BExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                bexecution.change=result.change;
                                                bexecution.changetype=result.changetype;
                                                bexecution.changevalue=result.changevalue;
                                                bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                bexecution.region=this.results[result.changename].ToString();
                                                bexecution.time=result.times;
                                                bexecution.ctime=bexecution.time;
                                                this.Eventsexe.Add(bexecution);
                                            } else
                                                continue;
                                        }
                                    } else if(result.collector=="或"&&((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==10)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            if(result.changevalue==12)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                        }
                                        BExecution bexecution = new BExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            bexecution.change=result.change;
                                            bexecution.changetype=result.changetype;
                                            bexecution.changevalue=result.changevalue;
                                            bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            bexecution.region=this.results[result.changename].ToString();
                                            bexecution.time=result.times;
                                            bexecution.ctime=bexecution.time;
                                            this.Eventsexe.Add(bexecution);
                                        } else
                                            continue;
                                    }
                                } else if(result.opreator2=="=") {
                                    if(result.collector=="且") {
                                        if((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==10)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                                if(result.changevalue==12)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            }
                                            BExecution bexecution = new BExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                bexecution.change=result.change;
                                                bexecution.changetype=result.changetype;
                                                bexecution.changevalue=result.changevalue;
                                                bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                bexecution.region=this.results[result.changename].ToString();
                                                bexecution.time=result.times;
                                                bexecution.ctime=bexecution.time;
                                                this.Eventsexe.Add(bexecution);
                                            } else
                                                continue;
                                        }
                                    } else if(result.collector=="或"&&((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==10)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            if(result.changevalue==12)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                        }
                                        BExecution bexecution = new BExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            bexecution.change=result.change;
                                            bexecution.changetype=result.changetype;
                                            bexecution.changevalue=result.changevalue;
                                            bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            bexecution.region=this.results[result.changename].ToString();
                                            bexecution.time=result.times;
                                            bexecution.ctime=bexecution.time;
                                            this.Eventsexe.Add(bexecution);
                                        } else
                                            continue;
                                    }
                                } else if(result.opreator2=="<") {
                                    if(result.collector=="且") {
                                        if((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==10)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                                if(result.changevalue==12)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            }
                                            BExecution bexecution = new BExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                bexecution.change=result.change;
                                                bexecution.changetype=result.changetype;
                                                bexecution.changevalue=result.changevalue;
                                                bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                bexecution.region=this.results[result.changename].ToString();
                                                bexecution.time=result.times;
                                                bexecution.ctime=bexecution.time;
                                                this.Eventsexe.Add(bexecution);
                                            } else
                                                continue;
                                        }
                                    } else if(result.collector=="或"&&((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==10)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            if(result.changevalue==12)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                        }
                                        BExecution bexecution = new BExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            bexecution.change=result.change;
                                            bexecution.changetype=result.changetype;
                                            bexecution.changevalue=result.changevalue;
                                            bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            bexecution.region=this.results[result.changename].ToString();
                                            bexecution.time=result.times;
                                            bexecution.ctime=bexecution.time;
                                            this.Eventsexe.Add(bexecution);
                                        } else
                                            continue;
                                    }
                                } else if((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)) {
                                    if(result.special==4) {
                                        if(result.changevalue==10)
                                            result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                        if(result.changevalue==12)
                                            result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                    }
                                    BExecution bexecution = new BExecution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        bexecution.change=result.change;
                                        bexecution.changetype=result.changetype;
                                        bexecution.changevalue=result.changevalue;
                                        bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        bexecution.region=this.results[result.changename].ToString();
                                        bexecution.time=result.times;
                                        bexecution.ctime=bexecution.time;
                                        this.Eventsexe.Add(bexecution);
                                    } else
                                        continue;
                                }
                            }
                            if(result.opreator=="<") {
                                if(result.opreator2==">") {
                                    if(result.collector=="且") {
                                        if((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==10)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                                if(result.changevalue==12)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            }
                                            BExecution bexecution = new BExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                bexecution.change=result.change;
                                                bexecution.changetype=result.changetype;
                                                bexecution.changevalue=result.changevalue;
                                                bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                bexecution.region=this.results[result.changename].ToString();
                                                bexecution.time=result.times;
                                                bexecution.ctime=bexecution.time;
                                                this.Eventsexe.Add(bexecution);
                                            } else
                                                continue;
                                        }
                                    } else if(result.collector=="或"&&((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==10)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            if(result.changevalue==12)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                        }
                                        BExecution bexecution = new BExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            bexecution.change=result.change;
                                            bexecution.changetype=result.changetype;
                                            bexecution.changevalue=result.changevalue;
                                            bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            bexecution.region=this.results[result.changename].ToString();
                                            bexecution.time=result.times;
                                            bexecution.ctime=bexecution.time;
                                            this.Eventsexe.Add(bexecution);
                                        } else
                                            continue;
                                    }
                                } else if(result.opreator2=="=") {
                                    if(result.collector=="且") {
                                        if((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==10)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                                if(result.changevalue==12)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            }
                                            BExecution bexecution = new BExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                bexecution.change=result.change;
                                                bexecution.changetype=result.changetype;
                                                bexecution.changevalue=result.changevalue;
                                                bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                bexecution.region=this.results[result.changename].ToString();
                                                bexecution.time=result.times;
                                                bexecution.ctime=bexecution.time;
                                                this.Eventsexe.Add(bexecution);
                                            } else
                                                continue;
                                        }
                                    } else if(result.collector=="或"&&((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==10)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            if(result.changevalue==12)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                        }
                                        BExecution bexecution = new BExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            bexecution.change=result.change;
                                            bexecution.changetype=result.changetype;
                                            bexecution.changevalue=result.changevalue;
                                            bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            bexecution.region=this.results[result.changename].ToString();
                                            bexecution.time=result.times;
                                            bexecution.ctime=bexecution.time;
                                            this.Eventsexe.Add(bexecution);
                                        } else
                                            continue;
                                    }
                                } else if(result.opreator2=="<") {
                                    if(result.collector=="且") {
                                        if((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==10)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                                if(result.changevalue==12)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            }
                                            BExecution bexecution = new BExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                bexecution.change=result.change;
                                                bexecution.changetype=result.changetype;
                                                bexecution.changevalue=result.changevalue;
                                                bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                bexecution.region=this.results[result.changename].ToString();
                                                bexecution.time=result.times;
                                                bexecution.ctime=bexecution.time;
                                                this.Eventsexe.Add(bexecution);
                                            } else
                                                continue;
                                        }
                                    } else if(result.collector=="或"&&((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==10)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            if(result.changevalue==12)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                        }
                                        BExecution bexecution = new BExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            bexecution.change=result.change;
                                            bexecution.changetype=result.changetype;
                                            bexecution.changevalue=result.changevalue;
                                            bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            bexecution.region=this.results[result.changename].ToString();
                                            bexecution.time=result.times;
                                            bexecution.ctime=bexecution.time;
                                            this.Eventsexe.Add(bexecution);
                                        } else
                                            continue;
                                    }
                                } else if((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)) {
                                    if(result.special==4) {
                                        if(result.changevalue==10)
                                            result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                        if(result.changevalue==12)
                                            result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                    }
                                    BExecution bexecution = new BExecution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        bexecution.change=result.change;
                                        bexecution.changetype=result.changetype;
                                        bexecution.changevalue=result.changevalue;
                                        bexecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        bexecution.region=this.results[result.changename].ToString();
                                        bexecution.time=result.times;
                                        bexecution.ctime=bexecution.time;
                                        this.Eventsexe.Add(bexecution);
                                    } else
                                        continue;
                                }
                            }
                            if(result.special==5) {
                                this.x=Center.ox;
                                this.y=Center.oy;
                            }
                            if(result.special2==1)
                                this.conditions[0]=(float)Time.now;
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
                    if(!Dis&!Player.Dis&alpha>95.0&type>=0&&Judge(x1,y1,x,y,x2,y2,Player.position.X,Player.position.Y,wscale,hscale,Main.bgset[type].pdr0,head)) {
                        if(!this.Invincible) {
                            this.time=1+num1+this.life;
                            this.Dis=true;
                            this.Blend=true;
                            this.randf=10f*(float)Main.rand.NextDouble();
                        }
                        Player.Dis=true;
                    }
                    if(!Dis&&Math.Sqrt((x-(double)Player.position.X)*(x-(double)Player.position.X)+(y-(double)Player.position.Y)*(y-(double)Player.position.Y))<Math.Abs(Player.time*15)&&!Invincible) {
                        this.time=1+num1+this.life;
                        this.Dis=true;
                        this.Blend=true;
                        this.randf=10f*(float)Main.rand.NextDouble();
                    }
                    if(this.time>num1+this.life) {
                        if(this.Dispel&this.type>=0) {
                            if(Main.bgset[this.type].rect.Width<=32) {
                                this.fadeout+=5;
                                this.alpha-=5f;
                                if((double)this.alpha<=0.0)
                                    this.alpha=0.0f;
                                this.wscale=MathHelper.Clamp(this.wscale-0.06f,0.0f,100f);
                                this.hscale=MathHelper.Clamp(this.hscale-0.06f,0.0f,100f);
                                if(this.time-(num1+this.life)>=20)
                                    this.NeedDelete=true;
                            } else {
                                this.fadeout+=5;
                                this.alpha-=5f;
                                if((double)this.alpha<=0.0)
                                    this.alpha=0.0f;
                                this.wscale+=0.06f;
                                this.hscale+=0.06f;
                                if(this.time-(num1+this.life)>=20)
                                    this.NeedDelete=true;
                            }
                        } else
                            this.NeedDelete=true;
                    }
                } else if(!this.Invincible&&Math.Sqrt(((double)this.x-(double)Player.position.X)*((double)this.x-(double)Player.position.X)+((double)this.y-(double)Player.position.Y)*((double)this.y-(double)Player.position.Y))<=10.0)
                    this.NeedDelete=true;
                int num2 = 0;
                foreach(Shadows shadows in this.savesha) {
                    if((double)shadows.alpha<=0.0)
                        ++num2;
                }
                if(this.Outdispel) {
                    if(num2==this.savesha.Length) {
                        if((double)this.x<90.0||(double)this.x>540.0||((double)this.y<-50.0||(double)this.y>530.0)) {
                            this.NeedDelete=true;
                        }
                    }
                } else if(num2==this.savesha.Length) {
                    if((double)this.x<-110.0||(double)this.x>740.0||((double)this.y<-250.0||(double)this.y>730.0))
                        this.NeedDelete=true;
                }
            }
            if(!(!this.IsLase&this.type==-2))
                return;
            this.NeedDelete=true;
        }

        public void Draw(SpriteBatch s) {
            if(this.IsLase||this.type==-1)
                return;
            if(this.time<=15&this.Mist) {
                if(Main.bgset[this.type].rect.Width<=48) {
                    if(Main.bgset[this.type].color!=-1)
                        s.Draw(Main.mist,new Microsoft.Xna.Framework.Vector2(x,y),new Rectangle?(new Rectangle(Main.bgset[this.type].color*32,0,32,30)),new Color(this.R/(float)byte.MaxValue,this.G/(float)byte.MaxValue,this.B/(float)byte.MaxValue,(float)((double)this.time/15.0*((double)this.alpha/100.0))),0.0f,new Microsoft.Xna.Framework.Vector2(16f,15f),(float)((double)Main.bgset[this.type].rect.Width/30.0+1.5*(15.0-(double)this.time)/15.0),SpriteEffects.None,0.0f);
                    else if(this.type<228)
                        s.Draw(Main.barrages,new Microsoft.Xna.Framework.Vector2(x,y),new Rectangle?(Main.bgset[this.type].rect),new Color(this.R/(float)byte.MaxValue,this.G/(float)byte.MaxValue,this.B/(float)byte.MaxValue,(float)((double)this.time/15.0*((double)this.alpha/100.0))),MathHelper.ToRadians(this.head)+1.570796f,Main.bgset[this.type].origin,new Microsoft.Xna.Framework.Vector2(this.wscale,this.hscale),SpriteEffects.None,0.0f);
                    else
                        s.Draw(Main.barrages2,new Microsoft.Xna.Framework.Vector2(x,y),new Rectangle?(Main.bgset[this.type].rect),new Color(this.R/(float)byte.MaxValue,this.G/(float)byte.MaxValue,this.B/(float)byte.MaxValue,(float)((double)this.time/15.0*((double)this.alpha/100.0))),MathHelper.ToRadians(this.head)+1.570796f,Main.bgset[this.type].origin,new Microsoft.Xna.Framework.Vector2(this.wscale,this.hscale),SpriteEffects.None,0.0f);
                } else if(this.type<228)
                    s.Draw(Main.barrages,new Microsoft.Xna.Framework.Vector2(x,y),new Rectangle?(Main.bgset[this.type].rect),new Color(this.R/(float)byte.MaxValue,this.G/(float)byte.MaxValue,this.B/(float)byte.MaxValue,(float)((double)this.time/15.0*((double)this.alpha/100.0))),MathHelper.ToRadians(this.head)+1.570796f,Main.bgset[this.type].origin,new Microsoft.Xna.Framework.Vector2(this.wscale+(float)((15.0-(double)this.time)/15.0),this.hscale+(float)((15.0-(double)this.time)/15.0)),SpriteEffects.None,0.0f);
                else
                    s.Draw(Main.barrages2,new Microsoft.Xna.Framework.Vector2(x,y),new Rectangle?(Main.bgset[this.type].rect),new Color(this.R/(float)byte.MaxValue,this.G/(float)byte.MaxValue,this.B/(float)byte.MaxValue,(float)((double)this.time/15.0*((double)this.alpha/100.0))),MathHelper.ToRadians(this.head)+1.570796f,Main.bgset[this.type].origin,new Microsoft.Xna.Framework.Vector2(this.wscale+(float)((15.0-(double)this.time)/15.0),this.hscale+(float)((15.0-(double)this.time)/15.0)),SpriteEffects.None,0.0f);
            } else {
                if(this.type<228)
                    s.Draw(Main.barrages,new Microsoft.Xna.Framework.Vector2(x,y),new Rectangle?(Main.bgset[this.type].rect),new Color(this.R/(float)byte.MaxValue,this.G/(float)byte.MaxValue,this.B/(float)byte.MaxValue,this.alpha/100f),MathHelper.ToRadians(this.head)+1.570796f,Main.bgset[this.type].origin,new Microsoft.Xna.Framework.Vector2(this.wscale,this.hscale),SpriteEffects.None,0.0f);
                else
                    s.Draw(Main.barrages2,new Microsoft.Xna.Framework.Vector2(x,y),new Rectangle?(Main.bgset[this.type].rect),new Color(this.R/(float)byte.MaxValue,this.G/(float)byte.MaxValue,this.B/(float)byte.MaxValue,this.alpha/100f),MathHelper.ToRadians(this.head)+1.570796f,Main.bgset[this.type].origin,new Microsoft.Xna.Framework.Vector2(this.wscale,this.hscale),SpriteEffects.None,0.0f);
                if(this.Afterimage) {
                    foreach(Shadows shadows in this.savesha) {
                        if((double)shadows.alpha>0.0) {
                            shadows.alpha-=0.02f;
                            if(this.type<228)
                                s.Draw(Main.barrages,new Microsoft.Xna.Framework.Vector2( shadows.x , shadows.y ),new Rectangle?(Main.bgset[this.type].rect),new Color(this.R/(float)byte.MaxValue,this.G/(float)byte.MaxValue,this.B/(float)byte.MaxValue,shadows.alpha),MathHelper.ToRadians(shadows.d)+1.570796f,Main.bgset[this.type].origin,new Microsoft.Xna.Framework.Vector2(this.wscale,this.hscale),SpriteEffects.None,0.0f);
                            else
                                s.Draw(Main.barrages2,new Microsoft.Xna.Framework.Vector2( shadows.x , shadows.y ),new Rectangle?(Main.bgset[this.type].rect),new Color(this.R/(float)byte.MaxValue,this.G/(float)byte.MaxValue,this.B/(float)byte.MaxValue,shadows.alpha),MathHelper.ToRadians(shadows.d)+1.570796f,Main.bgset[this.type].origin,new Microsoft.Xna.Framework.Vector2(this.wscale,this.hscale),SpriteEffects.None,0.0f);
                        }
                    }
                }
               }
        }

        public void LUpdate() {
            if(this.IsLase&this.type!=-1) {
                float x1 = this.x;
                float y1 = this.y;
                float x2 = Player.position.X;
                float y2 = Player.position.Y;
                ++this.time;
                if(this.time<=this.life) {
                    this.conditions[0]=(float)this.time;
                    this.results[0]=(float)this.life;
                    this.results[1]=(float)this.type;
                    this.results[2]=this.wscale;
                    this.results[3]=this.longs;
                    this.results[4]=this.alpha;
                    this.results[5]=this.speed;
                    this.results[6]=this.speedd;
                    this.results[7]=this.aspeed;
                    this.results[8]=this.aspeedd;
                    this.results[9]=this.xscale;
                    this.results[10]=this.yscale;
                    this.results[11]=0.0f;
                    this.results[12]=0.0f;
                    this.results[13]=0.0f;
                    foreach(Event @event in this.Events) {
                        if(@event.t<=0)
                            @event.t=1;
                        if(this.time%@event.t==0)
                            ++@event.loop;
                        foreach(EventRead result in @event.results) {
                            if(result.opreator==">") {
                                if(result.opreator2==">") {
                                    if(result.collector=="且") {
                                        if((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==6)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                                if(result.changevalue==8)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            }
                                            BLExecution blExecution = new BLExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                blExecution.change=result.change;
                                                blExecution.changetype=result.changetype;
                                                blExecution.changevalue=result.changevalue;
                                                blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                blExecution.region=this.results[result.changename].ToString();
                                                blExecution.time=result.times;
                                                blExecution.ctime=blExecution.time;
                                                this.LEventsexe.Add(blExecution);
                                            } else
                                                continue;
                                        }
                                    } else if(result.collector=="或"&&((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==6)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            if(result.changevalue==8)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                        }
                                        BLExecution blExecution = new BLExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            blExecution.change=result.change;
                                            blExecution.changetype=result.changetype;
                                            blExecution.changevalue=result.changevalue;
                                            blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            blExecution.region=this.results[result.changename].ToString();
                                            blExecution.time=result.times;
                                            blExecution.ctime=blExecution.time;
                                            this.LEventsexe.Add(blExecution);
                                        } else
                                            continue;
                                    }
                                } else if(result.opreator2=="=") {
                                    if(result.collector=="且") {
                                        if((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==6)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                                if(result.changevalue==8)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            }
                                            BLExecution blExecution = new BLExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                blExecution.change=result.change;
                                                blExecution.changetype=result.changetype;
                                                blExecution.changevalue=result.changevalue;
                                                blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                blExecution.region=this.results[result.changename].ToString();
                                                blExecution.time=result.times;
                                                blExecution.ctime=blExecution.time;
                                                this.LEventsexe.Add(blExecution);
                                            } else
                                                continue;
                                        }
                                    } else if(result.collector=="或"&&((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==6)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            if(result.changevalue==8)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                        }
                                        BLExecution blExecution = new BLExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            blExecution.change=result.change;
                                            blExecution.changetype=result.changetype;
                                            blExecution.changevalue=result.changevalue;
                                            blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            blExecution.region=this.results[result.changename].ToString();
                                            blExecution.time=result.times;
                                            blExecution.ctime=blExecution.time;
                                            this.LEventsexe.Add(blExecution);
                                        } else
                                            continue;
                                    }
                                } else if(result.opreator2=="<") {
                                    if(result.collector=="且") {
                                        if((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==6)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                                if(result.changevalue==8)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            }
                                            BLExecution blExecution = new BLExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                blExecution.change=result.change;
                                                blExecution.changetype=result.changetype;
                                                blExecution.changevalue=result.changevalue;
                                                blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                blExecution.region=this.results[result.changename].ToString();
                                                blExecution.time=result.times;
                                                blExecution.ctime=blExecution.time;
                                                this.LEventsexe.Add(blExecution);
                                            } else
                                                continue;
                                        }
                                    } else if(result.collector=="或"&&((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==6)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            if(result.changevalue==8)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                        }
                                        BLExecution blExecution = new BLExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            blExecution.change=result.change;
                                            blExecution.changetype=result.changetype;
                                            blExecution.changevalue=result.changevalue;
                                            blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            blExecution.region=this.results[result.changename].ToString();
                                            blExecution.time=result.times;
                                            blExecution.ctime=blExecution.time;
                                            this.LEventsexe.Add(blExecution);
                                        } else
                                            continue;
                                    }
                                } else if((double)this.conditions[result.contype]>(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)) {
                                    if(result.special==4) {
                                        if(result.changevalue==6)
                                            result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                        if(result.changevalue==8)
                                            result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                    }
                                    BLExecution blExecution = new BLExecution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        blExecution.change=result.change;
                                        blExecution.changetype=result.changetype;
                                        blExecution.changevalue=result.changevalue;
                                        blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        blExecution.region=this.results[result.changename].ToString();
                                        blExecution.time=result.times;
                                        blExecution.ctime=blExecution.time;
                                        this.LEventsexe.Add(blExecution);
                                    } else
                                        continue;
                                }
                            }
                            if(result.opreator=="=") {
                                if(result.opreator2==">") {
                                    if(result.collector=="且") {
                                        if((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==6)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                                if(result.changevalue==8)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            }
                                            BLExecution blExecution = new BLExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                blExecution.change=result.change;
                                                blExecution.changetype=result.changetype;
                                                blExecution.changevalue=result.changevalue;
                                                blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                blExecution.region=this.results[result.changename].ToString();
                                                blExecution.time=result.times;
                                                blExecution.ctime=blExecution.time;
                                                this.LEventsexe.Add(blExecution);
                                            } else
                                                continue;
                                        }
                                    } else if(result.collector=="或"&&((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==6)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            if(result.changevalue==8)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                        }
                                        BLExecution blExecution = new BLExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            blExecution.change=result.change;
                                            blExecution.changetype=result.changetype;
                                            blExecution.changevalue=result.changevalue;
                                            blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            blExecution.region=this.results[result.changename].ToString();
                                            blExecution.time=result.times;
                                            blExecution.ctime=blExecution.time;
                                            this.LEventsexe.Add(blExecution);
                                        } else
                                            continue;
                                    }
                                } else if(result.opreator2=="=") {
                                    if(result.collector=="且") {
                                        if((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==6)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                                if(result.changevalue==8)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            }
                                            BLExecution blExecution = new BLExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                blExecution.change=result.change;
                                                blExecution.changetype=result.changetype;
                                                blExecution.changevalue=result.changevalue;
                                                blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                blExecution.region=this.results[result.changename].ToString();
                                                blExecution.time=result.times;
                                                blExecution.ctime=blExecution.time;
                                                this.LEventsexe.Add(blExecution);
                                            } else
                                                continue;
                                        }
                                    } else if(result.collector=="或"&&((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==6)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            if(result.changevalue==8)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                        }
                                        BLExecution blExecution = new BLExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            blExecution.change=result.change;
                                            blExecution.changetype=result.changetype;
                                            blExecution.changevalue=result.changevalue;
                                            blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            blExecution.region=this.results[result.changename].ToString();
                                            blExecution.time=result.times;
                                            blExecution.ctime=blExecution.time;
                                            this.LEventsexe.Add(blExecution);
                                        } else
                                            continue;
                                    }
                                } else if(result.opreator2=="<") {
                                    if(result.collector=="且") {
                                        if((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==6)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                                if(result.changevalue==8)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            }
                                            BLExecution blExecution = new BLExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                blExecution.change=result.change;
                                                blExecution.changetype=result.changetype;
                                                blExecution.changevalue=result.changevalue;
                                                blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                blExecution.region=this.results[result.changename].ToString();
                                                blExecution.time=result.times;
                                                blExecution.ctime=blExecution.time;
                                                this.LEventsexe.Add(blExecution);
                                            } else
                                                continue;
                                        }
                                    } else if(result.collector=="或"&&((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==6)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            if(result.changevalue==8)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                        }
                                        BLExecution blExecution = new BLExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            blExecution.change=result.change;
                                            blExecution.changetype=result.changetype;
                                            blExecution.changevalue=result.changevalue;
                                            blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            blExecution.region=this.results[result.changename].ToString();
                                            blExecution.time=result.times;
                                            blExecution.ctime=blExecution.time;
                                            this.LEventsexe.Add(blExecution);
                                        } else
                                            continue;
                                    }
                                } else if((double)this.conditions[result.contype]==(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)) {
                                    if(result.special==4) {
                                        if(result.changevalue==6)
                                            result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                        if(result.changevalue==8)
                                            result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                    }
                                    BLExecution blExecution = new BLExecution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        blExecution.change=result.change;
                                        blExecution.changetype=result.changetype;
                                        blExecution.changevalue=result.changevalue;
                                        blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        blExecution.region=this.results[result.changename].ToString();
                                        blExecution.time=result.times;
                                        blExecution.ctime=blExecution.time;
                                        this.LEventsexe.Add(blExecution);
                                    } else
                                        continue;
                                }
                            }
                            if(result.opreator=="<") {
                                if(result.opreator2==">") {
                                    if(result.collector=="且") {
                                        if((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==6)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                                if(result.changevalue==8)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            }
                                            BLExecution blExecution = new BLExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                blExecution.change=result.change;
                                                blExecution.changetype=result.changetype;
                                                blExecution.changevalue=result.changevalue;
                                                blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                blExecution.region=this.results[result.changename].ToString();
                                                blExecution.time=result.times;
                                                blExecution.ctime=blExecution.time;
                                                this.LEventsexe.Add(blExecution);
                                            } else
                                                continue;
                                        }
                                    } else if(result.collector=="或"&&((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||(double)this.conditions[result.contype2]>(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==6)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            if(result.changevalue==8)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                        }
                                        BLExecution blExecution = new BLExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            blExecution.change=result.change;
                                            blExecution.changetype=result.changetype;
                                            blExecution.changevalue=result.changevalue;
                                            blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            blExecution.region=this.results[result.changename].ToString();
                                            blExecution.time=result.times;
                                            blExecution.ctime=blExecution.time;
                                            this.LEventsexe.Add(blExecution);
                                        } else
                                            continue;
                                    }
                                } else if(result.opreator2=="=") {
                                    if(result.collector=="且") {
                                        if((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==6)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                                if(result.changevalue==8)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            }
                                            BLExecution blExecution = new BLExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                blExecution.change=result.change;
                                                blExecution.changetype=result.changetype;
                                                blExecution.changevalue=result.changevalue;
                                                blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                blExecution.region=this.results[result.changename].ToString();
                                                blExecution.time=result.times;
                                                blExecution.ctime=blExecution.time;
                                                this.LEventsexe.Add(blExecution);
                                            } else
                                                continue;
                                        }
                                    } else if(result.collector=="或"&&((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||(double)this.conditions[result.contype2]==(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==6)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            if(result.changevalue==8)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                        }
                                        BLExecution blExecution = new BLExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            blExecution.change=result.change;
                                            blExecution.changetype=result.changetype;
                                            blExecution.changevalue=result.changevalue;
                                            blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            blExecution.region=this.results[result.changename].ToString();
                                            blExecution.time=result.times;
                                            blExecution.ctime=blExecution.time;
                                            this.LEventsexe.Add(blExecution);
                                        } else
                                            continue;
                                    }
                                } else if(result.opreator2=="<") {
                                    if(result.collector=="且") {
                                        if((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)&(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime)) {
                                            if(result.special==4) {
                                                if(result.changevalue==6)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                                if(result.changevalue==8)
                                                    result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            }
                                            BLExecution blExecution = new BLExecution();
                                            if(!result.noloop) {
                                                if(result.time>0) {
                                                    --result.time;
                                                    if(result.time==0)
                                                        result.noloop=true;
                                                }
                                                blExecution.change=result.change;
                                                blExecution.changetype=result.changetype;
                                                blExecution.changevalue=result.changevalue;
                                                blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                                blExecution.region=this.results[result.changename].ToString();
                                                blExecution.time=result.times;
                                                blExecution.ctime=blExecution.time;
                                                this.LEventsexe.Add(blExecution);
                                            } else
                                                continue;
                                        }
                                    } else if(result.collector=="或"&&((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)||(double)this.conditions[result.contype2]<(double)float.Parse(result.condition2)+(double)(@event.loop*@event.addtime))) {
                                        if(result.special==4) {
                                            if(result.changevalue==6)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                            if(result.changevalue==8)
                                                result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                        }
                                        BLExecution blExecution = new BLExecution();
                                        if(!result.noloop) {
                                            if(result.time>0) {
                                                --result.time;
                                                if(result.time==0)
                                                    result.noloop=true;
                                            }
                                            blExecution.change=result.change;
                                            blExecution.changetype=result.changetype;
                                            blExecution.changevalue=result.changevalue;
                                            blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                            blExecution.region=this.results[result.changename].ToString();
                                            blExecution.time=result.times;
                                            blExecution.ctime=blExecution.time;
                                            this.LEventsexe.Add(blExecution);
                                        } else
                                            continue;
                                    }
                                } else if((double)this.conditions[result.contype]<(double)float.Parse(result.condition)+(double)(@event.loop*@event.addtime)) {
                                    if(result.special==4) {
                                        if(result.changevalue==6)
                                            result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                        if(result.changevalue==8)
                                            result.res=MathHelper.ToDegrees(Main.Twopointangle(Player.position.X,Player.position.Y,this.x,this.y));
                                    }
                                    BLExecution blExecution = new BLExecution();
                                    if(!result.noloop) {
                                        if(result.time>0) {
                                            --result.time;
                                            if(result.time==0)
                                                result.noloop=true;
                                        }
                                        blExecution.change=result.change;
                                        blExecution.changetype=result.changetype;
                                        blExecution.changevalue=result.changevalue;
                                        blExecution.value=result.res+MathHelper.Lerp(-result.rand,result.rand,(float)Main.rand.NextDouble());
                                        blExecution.region=this.results[result.changename].ToString();
                                        blExecution.time=result.times;
                                        blExecution.ctime=blExecution.time;
                                        this.LEventsexe.Add(blExecution);
                                    } else
                                        continue;
                                }
                            }
                            if(result.special==5) {
                                this.x=Center.ox;
                                this.y=Center.oy;
                            }
                        }
                    }
                    for(int index = 0;index<this.LEventsexe.Count;++index) {
                        if(!this.LEventsexe[index].NeedDelete) {
                            this.LEventsexe[index].Update(this);
                        } else {
                            this.LEventsexe.RemoveAt(index);
                            --index;
                        }
                    }
                    this.rwscale=this.wscale;
                    if(!this.IsRay) {
                        if((double)this.speedy!=0.0) {
                            this.vf=1.570796f-(float)Math.Atan((double)this.speedx/(double)this.speedy);
                            if((double)this.speedy<0.0)
                                this.vf+=3.141593f;
                        } else {
                            if((double)this.speedx>=0.0)
                                this.vf=0.0f;
                            if((double)this.speedx<0.0)
                                this.vf=3.141593f;
                        }
                        this.head=MathHelper.ToDegrees(this.vf);
                        if((double)this.rlongs<(double)this.longs&!this.Alreadylong)
                            this.rlongs+=this.speed;
                        if((double)this.rlongs>=(double)this.longs)
                            this.Alreadylong=true;
                        if((double)this.rlongs>=(double)this.longs||this.Alreadylong) {
                            this.rlongs=this.longs;
                            this.speedx+=this.aspeedx*Time.stop;
                            this.speedy+=this.aspeedy*Time.stop;
                            this.x+=this.speedx*Time.stop;
                            this.y+=this.speedy*Time.stop;
                            if(this.Outdispel) {
                                if((double)this.x<90.0||(double)this.x>540.0||((double)this.y<-50.0||(double)this.y>530.0)) {
                                    this.NeedDelete=true;
                                }
                            } else if((double)this.x<-110.0||(double)this.x>740.0||((double)this.y<-250.0||(double)this.y>730.0)) {
                                this.NeedDelete=true;
                            }
                        }
                        if( !Player.Dis&(double)this.alpha>95.0) {
                            float bx = (float)(((double)x1+(double)x1+(double)this.rlongs*Math.Cos((double)MathHelper.ToRadians(this.speedd)))/2.0);
                            float by = (float)(((double)y1+(double)y1+(double)this.rlongs*Math.Sin((double)MathHelper.ToRadians(this.speedd)))/2.0);
                            float x3 = (float)(((double)this.x+(double)this.x+(double)this.rlongs*Math.Cos((double)MathHelper.ToRadians(this.speedd)))/2.0);
                            float y3 = (float)(((double)this.y+(double)this.y+(double)this.rlongs*Math.Sin((double)MathHelper.ToRadians(this.speedd)))/2.0);
                            float hs = this.rlongs/6f;
                            if(this.Judge(bx,by,x3,y3,x2,y2,Player.position.X,Player.position.Y,this.wscale,hs,2f,this.head)&(double)this.wscale>=0.5) {
                                if(!this.Invincible) {
                                    this.time=1+this.life;
                                    this.Dis=true;
                                    this.randf=10f*(float)Main.rand.NextDouble();
                                }
                                Player.Dis=true;
                            }
                        }
                        if( !this.Dis&&Math.Sqrt(((double)this.x-(double)Player.position.X)*((double)this.x-(double)Player.position.X)+((double)this.y-(double)Player.position.Y)*((double)this.y-(double)Player.position.Y))<(double)Math.Abs(Player.time*15)&&!this.Invincible) {
                            this.time=1+this.life;
                            this.Dis=true;
                            this.randf=10f*(float)Main.rand.NextDouble();
                        }
                    } else {
                        this.rlongs=792f;
                        this.head=this.speedd;
                        this.speedx+=this.aspeedx*Time.stop;
                        this.speedy+=this.aspeedy*Time.stop;
                        this.x+=this.speedx*Time.stop;
                        this.y+=this.speedy*Time.stop;
                        if( !Dis&!Player.Dis&alpha>95.0) {
                            float bx = (float)(((double)x1+(double)x1+(double)this.rlongs*Math.Cos((double)MathHelper.ToRadians(this.speedd)))/2.0);
                            float by = (float)(((double)y1+(double)y1+(double)this.rlongs*Math.Sin((double)MathHelper.ToRadians(this.speedd)))/2.0);
                            float x3 = (float)(((double)this.x+(double)this.x+(double)this.rlongs*Math.Cos((double)MathHelper.ToRadians(this.speedd)))/2.0);
                            float y3 = (float)(((double)this.y+(double)this.y+(double)this.rlongs*Math.Sin((double)MathHelper.ToRadians(this.speedd)))/2.0);
                            float hs = this.rlongs/6f;
                            if(this.Judge(bx,by,x3,y3,x2,y2,Player.position.X,Player.position.Y,this.wscale,hs,2f,this.head)&(double)this.wscale>=0.5) {
                                if(!this.Invincible) {
                                    this.time=1+this.life;
                                    this.Dis=true;
                                    this.randf=10f*(float)Main.rand.NextDouble();
                                }
                                Player.Dis=true;
                            }
                        }
                        if( !this.Dis&&Math.Sqrt(((double)this.x-(double)Player.position.X)*((double)this.x-(double)Player.position.X)+((double)this.y-(double)Player.position.Y)*((double)this.y-(double)Player.position.Y))<(double)Math.Abs(Player.time*15)&&!this.Invincible) {
                            this.time=1+this.life;
                            this.Dis=true;
                            this.randf=10f*(float)Main.rand.NextDouble();
                        }
                    }
                } else {
                    if(!this.IsRay) {
                        this.speedx+=this.aspeedx;
                        this.speedy+=this.aspeedy;
                        this.x+=this.speedx;
                        this.y+=this.speedy;
                        this.rlongs-=this.speed;
                        this.wscale-=0.1f*this.rwscale;
                        if((double)this.wscale<0.0)
                            this.wscale=0.0f;
                        if((double)this.rlongs<0.0)
                            this.rlongs=0.0f;
                        if((double)this.rlongs==0.0)
                            this.NeedDelete=true;
                    } else {
                        this.head=this.speedd;
                        this.wscale-=0.1f*this.rwscale;
                        if((double)this.wscale<0.0)
                            this.wscale=0.0f;
                        if((double)this.wscale==0.0)
                            this.NeedDelete=true;
                    }
                    for(int index = 0;index<this.LEventsexe.Count;++index) {
                        if(!this.LEventsexe[index].NeedDelete) {
                            this.LEventsexe[index].Update(this);
                        } else {
                            this.LEventsexe.RemoveAt(index);
                            --index;
                        }
                    }
                }
            }
            if(!(this.IsLase&this.type==-1))
                return;
            this.NeedDelete=true;
        }

        public void LDraw(SpriteBatch s) {
            if(!(this.IsLase&this.type!=-1))
                return;
            if(((this.time<=this.life ? 1 : 0)&((double)this.rlongs<(double)this.longs&!this.Alreadylong ? 1 : (this.IsRay ? 1 : 0)))!=0)
                s.Draw(Main.mist,new Microsoft.Xna.Framework.Vector2(x,y),new Rectangle?(new Rectangle(Main.bgset[32+this.type].color*32,0,32,30)),new Color(1f,1f,1f,0.8f),MathHelper.ToDegrees((float)(this.time*5)),new Microsoft.Xna.Framework.Vector2(16f,15f),1f,SpriteEffects.None,0.0f);
            s.Draw(Main.barrages,new Microsoft.Xna.Framework.Vector2(x,y),new Rectangle?(Main.bgset[32+this.type].rect),new Color(1f,1f,1f,this.alpha/100f),MathHelper.ToRadians(this.head)-1.570796f,new Microsoft.Xna.Framework.Vector2((float)(Main.bgset[32+this.type].rect.Width/2),0.0f),new Microsoft.Xna.Framework.Vector2(this.wscale,this.rlongs/(float)Main.bgset[32+this.type].rect.Height),SpriteEffects.None,0.0f);
        }

        private bool Judge(
          float bx,
          float by,
          float x,
          float y,
          float bpx,
          float bpy,
          float px,
          float py,
          float ws,
          float hs,
          float pdr,
          float dr) {
            ++pdr;
            bpx=x+bpx-bx;
            bpy=y+bpy-by;
            float num1 = px-bpx;
            float num2 = py-bpy;
            float num3;
            float num4;
            if((double)num1!=0.0) {
                float num5 = num2/num1;
                if((double)num5!=0.0) {
                    num3=(float)(((double)y-(double)bpy+1.0/(double)num5*(double)x+(double)num5*(double)bpx)/((double)num5+1.0/(double)num5));
                    num4=bpy+num5*(num3-bpx);
                } else {
                    num3=x;
                    num4=py;
                }
                if((double)Math.Abs(Math.Abs(px-num3)+Math.Abs(bpx-num3)-Math.Abs(px-bpx))>0.0) {
                    num3=px;
                    num4=py;
                }
            } else if((double)num2!=0.0) {
                num3=px;
                num4=y;
                if((double)Math.Abs(Math.Abs(py-num4)+Math.Abs(bpy-num4)-Math.Abs(py-bpy))>0.0) {
                    num3=px;
                    num4=py;
                }
            } else {
                num3=px;
                num4=py;
            }
            dr=MathHelper.ToRadians(dr);
            double num6;
            if((double)num3-(double)x!=0.0) {
                num6=Math.Atan(((double)num4-(double)y)/((double)num3-(double)x));
                if((double)num3-(double)x<0.0)
                    num6+=3.14159274101257;
            } else
                num6=(double)num4-(double)y<=0.0 ? -1.57079637050629 : 1.57079637050629;
            float num7 = (float)Math.Sqrt(((double)x-(double)num3)*((double)x-(double)num3)+((double)y-(double)num4)*((double)y-(double)num4));
            float num8 = x+num7*(float)Math.Cos(num6-(double)dr);
            float num9 = y+num7*(float)Math.Sin(num6-(double)dr);
            x=(float)(((double)x-(double)num8)*((double)x-(double)num8));
            y=(float)(((double)y-(double)num9)*((double)y-(double)num9));
            float num10 = (float)((double)pdr*(double)ws*((double)pdr*(double)ws));
            float num11 = (float)((double)pdr*(double)hs*((double)pdr*(double)hs));
            return (double)x/(double)num11+(double)y/(double)num10<=1.0;
        }
    }
}
