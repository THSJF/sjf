// Decompiled with JetBrains decompiler
// Type: CrazyStorm_1._03.Force
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
    public class Force:ICloneable {
        private static int record;
        private int clcount;
        private int clwait;
        public bool Selecting;
        public bool NeedDelete;
        public int Searched;
        public int id;
        public int parentid;
        public int parentcolor;
        public float x;
        public float y;
        public int begin;
        public int life;
        public int halfw;
        public int halfh;
        public bool Circle;
        public int type;
        public int controlid;
        public float speed;
        public float speedd;
        public float speedx;
        public float speedy;
        public float aspeed;
        public float aspeedx;
        public float aspeedy;
        public float aspeedd;
        public float addaspeed;
        public float addaspeedd;
        public bool Suction;
        public bool Repulsion;
        public float addspeed;
        public Force rand;
        public List<Event> Parentevents;
        public Force copys;

        public Force() {
        }

        public Force(float xs,float ys,int pc) {
            this.rand=new Force();
            this.Parentevents=new List<Event>();
            this.x=xs;
            this.y=ys;
            this.parentcolor=pc;
            this.begin=Layer.LayerArray[this.parentid].begin;
            this.life=Layer.LayerArray[this.parentid].end-Layer.LayerArray[this.parentid].begin+1;
            this.halfw=100;
            this.halfh=100;
            this.type=0;
            this.controlid=1;
            this.speed=0.0f;
            this.speedd=0.0f;
            this.aspeed=0.0f;
            this.aspeedd=0.0f;
            this.Circle=false;
        }

        public void Update() {
            int x = Main.mousestate.X;
            int y = Main.mousestate.Y;
            if(Main.mousestate.LeftButton==ButtonState.Pressed&Main.prostate.LeftButton!=ButtonState.Pressed) {
                if((double)x>150.0+(double)this.x-(double)this.Searched&(double)x<150.0+(double)this.x+32.0+(double)this.Searched&(double)y>22.0+(double)this.y+(double)this.Searched&(double)y<22.0+(double)this.y+32.0+(double)this.Searched) {
                    if(!this.Selecting) {
                        if(Force.record<Layer.LayerArray[this.parentid].ForceArray.Count)
                            Layer.LayerArray[this.parentid].ForceArray[Force.record].Selecting=false;
                        foreach(Layer layer in Layer.LayerArray) {
                            for(int index = 0;index<layer.BatchArray.Count;++index)
                                layer.BatchArray[index].Selecting=false;
                            for(int index = 0;index<layer.LaseArray.Count;++index)
                                layer.LaseArray[index].Selecting=false;
                            for(int index = 0;index<layer.CoverArray.Count;++index)
                                layer.CoverArray[index].Selecting=false;
                            for(int index = 0;index<layer.ReboundArray.Count;++index)
                                layer.ReboundArray[index].Selecting=false;
                            for(int index = 0;index<layer.ForceArray.Count;++index) {
                                if(layer.ForceArray[index].parentid<this.parentid)
                                    layer.ForceArray[index].Selecting=false;
                            }
                        }
                        Force.record=this.id;
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
            if(!Time.Playing||!(Time.now>=this.begin&Time.now<=this.begin+this.life-1))
                return;
            int now = Time.now;
            this.speedx+=this.aspeedx;
            this.speedy+=this.aspeedy;
            this.x+=this.speedx;
            this.y+=this.speedy;
            if(this.Circle) {
                if(Math.Sqrt(((double)this.x-4.0-(double)Player.position.X)*((double)this.x-4.0-(double)Player.position.X)+((double)this.y+16.0-(double)Player.position.Y)*((double)this.y+16.0-(double)Player.position.Y))<=(double)Math.Max(this.halfw,this.halfh)) {
                    if(this.Suction) {
                        float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,Player.position.X,Player.position.Y));
                        Player.position.X+=this.addspeed*(float)Math.Cos((double)MathHelper.ToRadians(degrees));
                        Player.position.Y+=this.addspeed*(float)Math.Sin((double)MathHelper.ToRadians(degrees));
                    } else if(this.Repulsion) {
                        float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,Player.position.X,Player.position.Y));
                        Player.position.X+=this.addspeed*(float)Math.Cos((double)MathHelper.ToRadians(180f+degrees));
                        Player.position.Y+=this.addspeed*(float)Math.Sin((double)MathHelper.ToRadians(180f+degrees));
                    } else {
                        Player.position.X+=this.addspeed*(float)Math.Cos((double)MathHelper.ToRadians(this.addaspeedd));
                        Player.position.Y+=this.addspeed*(float)Math.Sin((double)MathHelper.ToRadians(this.addaspeedd));
                    }
                    if((double)Player.position.X<=4.5+(double)Player.add)
                        Player.position.X=4.5f+(float)Player.add;
                    if((double)Player.position.X>=625.5-(double)Player.add)
                        Player.position.X=625.5f-(float)Player.add;
                    if((double)Player.position.Y<=4.5)
                        Player.position.Y=4.5f;
                    if((double)Player.position.Y>=475.5)
                        Player.position.Y=475.5f;
                }
            } else if((double)Math.Abs(this.x-4f-Player.position.X)<=(double)this.halfw&(double)Math.Abs(this.y+16f-Player.position.Y)<=(double)this.halfh) {
                if(this.Suction) {
                    float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,Player.position.X,Player.position.Y));
                    Player.position.X+=this.addspeed*(float)Math.Cos((double)MathHelper.ToRadians(degrees));
                    Player.position.Y+=this.addspeed*(float)Math.Sin((double)MathHelper.ToRadians(degrees));
                } else if(this.Repulsion) {
                    float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,Player.position.X,Player.position.Y));
                    Player.position.X+=this.addspeed*(float)Math.Cos((double)MathHelper.ToRadians(180f+degrees));
                    Player.position.Y+=this.addspeed*(float)Math.Sin((double)MathHelper.ToRadians(180f+degrees));
                } else {
                    Player.position.X+=this.addspeed*(float)Math.Cos((double)MathHelper.ToRadians(this.addaspeedd));
                    Player.position.Y+=this.addspeed*(float)Math.Sin((double)MathHelper.ToRadians(this.addaspeedd));
                }
                if((double)Player.position.X<=4.5+(double)Player.add)
                    Player.position.X=4.5f+(float)Player.add;
                if((double)Player.position.X>=625.5-(double)Player.add)
                    Player.position.X=625.5f-(float)Player.add;
                if((double)Player.position.Y<=4.5)
                    Player.position.Y=4.5f;
                if((double)Player.position.Y>=475.5)
                    Player.position.Y=475.5f;
            }
            foreach(Barrage barrage in Layer.LayerArray[this.parentid].Barrages) {
                if(barrage.Force) {
                    if(this.Circle) {
                        if(this.type==0) {
                            if(Math.Sqrt(((double)this.x-4.0-(double)barrage.x)*((double)this.x-4.0-(double)barrage.x)+((double)this.y+16.0-(double)barrage.y)*((double)this.y+16.0-(double)barrage.y))<=(double)Math.Max(this.halfw,this.halfh)) {
                                if(this.Suction) {
                                    float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,barrage.x,barrage.y));
                                    barrage.speedx+=barrage.xscale*this.addaspeed*(float)Math.Cos((double)MathHelper.ToRadians(degrees));
                                    barrage.speedy+=barrage.yscale*this.addaspeed*(float)Math.Sin((double)MathHelper.ToRadians(degrees));
                                } else if(this.Repulsion) {
                                    float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,barrage.x,barrage.y));
                                    barrage.speedx+=barrage.xscale*this.addaspeed*(float)Math.Cos((double)MathHelper.ToRadians(180f+degrees));
                                    barrage.speedy+=barrage.yscale*this.addaspeed*(float)Math.Sin((double)MathHelper.ToRadians(180f+degrees));
                                } else {
                                    barrage.speedx+=barrage.xscale*this.addaspeed*(float)Math.Cos((double)MathHelper.ToRadians(this.addaspeedd));
                                    barrage.speedy+=barrage.yscale*this.addaspeed*(float)Math.Sin((double)MathHelper.ToRadians(this.addaspeedd));
                                }
                            }
                        } else if(this.type==1&&barrage.parentid==this.controlid-1&Math.Sqrt(((double)this.x-4.0-(double)barrage.x)*((double)this.x-4.0-(double)barrage.x)+((double)this.y+16.0-(double)barrage.y)*((double)this.y+16.0-(double)barrage.y))<=(double)Math.Max(this.halfw,this.halfh)) {
                            if(this.Suction) {
                                float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,barrage.x,barrage.y));
                                barrage.speedx+=barrage.xscale*this.addaspeed*(float)Math.Cos((double)MathHelper.ToRadians(degrees));
                                barrage.speedy+=barrage.yscale*this.addaspeed*(float)Math.Sin((double)MathHelper.ToRadians(degrees));
                            } else if(this.Repulsion) {
                                float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,barrage.x,barrage.y));
                                barrage.speedx+=barrage.xscale*this.addaspeed*(float)Math.Cos((double)MathHelper.ToRadians(180f+degrees));
                                barrage.speedy+=barrage.yscale*this.addaspeed*(float)Math.Sin((double)MathHelper.ToRadians(180f+degrees));
                            } else {
                                barrage.speedx+=barrage.xscale*this.addaspeed*(float)Math.Cos((double)MathHelper.ToRadians(this.addaspeedd));
                                barrage.speedy+=barrage.yscale*this.addaspeed*(float)Math.Sin((double)MathHelper.ToRadians(this.addaspeedd));
                            }
                        }
                    } else if(this.type==0) {
                        if((double)Math.Abs(this.x-4f-barrage.x)<=(double)this.halfw&(double)Math.Abs(this.y+16f-barrage.y)<=(double)this.halfh) {
                            if(this.Suction) {
                                float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,barrage.x,barrage.y));
                                barrage.speedx+=barrage.xscale*this.addaspeed*(float)Math.Cos((double)MathHelper.ToRadians(degrees));
                                barrage.speedy+=barrage.yscale*this.addaspeed*(float)Math.Sin((double)MathHelper.ToRadians(degrees));
                            } else if(this.Repulsion) {
                                float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,barrage.x,barrage.y));
                                barrage.speedx+=barrage.xscale*this.addaspeed*(float)Math.Cos((double)MathHelper.ToRadians(180f+degrees));
                                barrage.speedy+=barrage.yscale*this.addaspeed*(float)Math.Sin((double)MathHelper.ToRadians(180f+degrees));
                            } else {
                                barrage.speedx+=barrage.xscale*this.addaspeed*(float)Math.Cos((double)MathHelper.ToRadians(this.addaspeedd));
                                barrage.speedy+=barrage.yscale*this.addaspeed*(float)Math.Sin((double)MathHelper.ToRadians(this.addaspeedd));
                            }
                        }
                    } else if(this.type==1&&barrage.parentid==this.controlid-1&(double)Math.Abs(this.x-4f-barrage.x)<=(double)this.halfw&(double)Math.Abs(this.y+16f-barrage.y)<=(double)this.halfh) {
                        if(this.Suction) {
                            float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,barrage.x,barrage.y));
                            barrage.speedx+=barrage.xscale*this.addaspeed*(float)Math.Cos((double)MathHelper.ToRadians(degrees));
                            barrage.speedy+=barrage.yscale*this.addaspeed*(float)Math.Sin((double)MathHelper.ToRadians(degrees));
                        } else if(this.Repulsion) {
                            float degrees = MathHelper.ToDegrees(Main.Twopointangle(this.x-4f,this.y+16f,barrage.x,barrage.y));
                            barrage.speedx+=barrage.xscale*this.addaspeed*(float)Math.Cos((double)MathHelper.ToRadians(180f+degrees));
                            barrage.speedy+=barrage.yscale*this.addaspeed*(float)Math.Sin((double)MathHelper.ToRadians(180f+degrees));
                        } else {
                            barrage.speedx+=barrage.xscale*this.addaspeed*(float)Math.Cos((double)MathHelper.ToRadians(this.addaspeedd));
                            barrage.speedy+=barrage.yscale*this.addaspeed*(float)Math.Sin((double)MathHelper.ToRadians(this.addaspeedd));
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
            s.Draw(Main.item,new Vector2((float)(150.0+(double)this.x+1.0),(float)(22.0+(double)this.y+1.0)),new Rectangle?(new Rectangle(120,0,30,30)),Color.White,0.0f,Vector2.Zero,1f,SpriteEffects.None,1f);
            if(this.id<=8)
                Main.font.Draw(s,"0"+(this.id+1).ToString(),new Vector2((float)(150.0+(double)this.x+18.0),(float)(22.0+(double)this.y+21.0)),Color.Black);
            else
                Main.font.Draw(s,(this.id+1).ToString(),new Vector2((float)(150.0+(double)this.x+18.0),(float)(22.0+(double)this.y+21.0)),Color.Black);
            if(this.Selecting)
                s.Draw(Main.create,new Vector2((float)(150.0+(double)this.x-1.0),(float)(22.0+(double)this.y-1.0)),Color.White);
            Vector2 position = new Vector2((float)(150.0+(double)this.x+16.0)-(float)this.halfw,(float)(22.0+(double)this.y+16.0)-(float)this.halfh);
            s.Draw(Main.line,position,new Rectangle?(),Color.Yellow,1.570796f,Vector2.Zero,new Vector2((float)((double)this.halfh*2.0/50.0),1f),SpriteEffects.None,0.0f);
            s.Draw(Main.line,position,new Rectangle?(),Color.Yellow,0.0f,Vector2.Zero,new Vector2((float)((double)this.halfw*2.0/50.0),1f),SpriteEffects.None,0.0f);
            position=new Vector2((float)(150.0+(double)this.x+16.0)+(float)this.halfw,(float)(22.0+(double)this.y+16.0)+(float)this.halfh);
            s.Draw(Main.line,position,new Rectangle?(),Color.Yellow,-1.570796f,Vector2.Zero,new Vector2((float)((double)this.halfh*2.0/50.0),1f),SpriteEffects.None,0.0f);
            s.Draw(Main.line,position,new Rectangle?(),Color.Yellow,3.141593f,Vector2.Zero,new Vector2((float)((double)this.halfw*2.0/50.0),1f),SpriteEffects.None,0.0f);
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

        public void PreviewUpdate() {
            if(!(Time.now>=this.begin&Time.now<=this.begin+this.life-1))
                return;
            int now = Time.now;
            this.speedx+=this.aspeedx;
            this.speedy+=this.aspeedy;
            this.x+=this.speedx;
            this.y+=this.speedy;
        }
    }
}
