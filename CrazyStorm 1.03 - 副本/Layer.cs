// Decompiled with JetBrains decompiler
// Type: CrazyStorm_1._03.Layer
// Assembly: CrazyStorm 1.03, Version=1.0.0.3, Culture=neutral, PublicKeyToken=null
// MVID: 84431CDC-1E34-49EF-A5C5-D546FEF5A655
// Assembly location: E:\CrazyStorm 1.03I\CrazyStorm 1.03.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CrazyStorm_1._03 {
    internal class Layer {
        public static List<Layer> LayerArray = new List<Layer>();
        public static int total = 0;
        public static int selection = 0;
        public static int oldcolor = 0;
        private static int clcount = 0;
        private static int clwait = 0;
        public string name;
        public int sort;
        public bool Visible;
        public int color;
        public int begin;
        public int end;
        public bool NeedDelete;
        public List<Batch> BatchArray;
        public List<Lase> LaseArray;
        public List<Cover> CoverArray;
        public List<Rebound> ReboundArray;
        public List<Force> ForceArray;
        public List<Barrage> Barrages;

        public static void Clear() {
            total=0;
            selection=0;
            oldcolor=0;
            clcount=0;
            clwait=0;
            LayerArray.Clear();
        }

        public Layer(string nm,int bg,int ed) {
            name=nm;
            Visible=true;
            sort=LayerArray.Count;
            selection=0;
            color=oldcolor;
            ++oldcolor;
            if(oldcolor>6) {
                oldcolor=0;
            }
            begin=bg;
            end=ed;
            ++total;
            NeedDelete=false;
            BatchArray=new List<Batch>();
            LaseArray=new List<Lase>();
            CoverArray=new List<Cover>();
            ReboundArray=new List<Rebound>();
            ForceArray=new List<Force>();
            Barrages=new List<Barrage>();
            LayerArray.Add(this);
        }

        public void Update() {
            if(!Main.Available) {
                return;
            }
            int x = Main.mousestate.X;
            int y = Main.mousestate.Y;
            if(x>=2&x<=16&y>=545+13*(LayerArray.Count-sort-1)&y<=545+13*(LayerArray.Count-sort-1)+14&&
                Main.mousestate.LeftButton==Microsoft.Xna.Framework.Input.ButtonState.Pressed&
                Main.prostate.LeftButton!=Microsoft.Xna.Framework.Input.ButtonState.Pressed&!Time.Playing) {
                Visible=!Visible;
            }
            if(x>=16&x<=30&y>=545+13*(LayerArray.Count-sort-1)&y<=545+13*(LayerArray.Count-sort-1)+14&&
                Main.mousestate.LeftButton==Microsoft.Xna.Framework.Input.ButtonState.Pressed&
                Main.prostate.LeftButton!=Microsoft.Xna.Framework.Input.ButtonState.Pressed&!Time.Playing) {
                ++color;
                if(color>6) {
                    color=0;
                }
                for(int index = 0;index<BatchArray.Count;++index) {
                    BatchArray[index].parentcolor=color;
                }
            }
            if(x>=30&x<=154&y>=545+13*(LayerArray.Count-sort-1)&y<=545+13*(LayerArray.Count-sort-1)+14&&
                Main.mousestate.LeftButton==Microsoft.Xna.Framework.Input.ButtonState.Pressed&
                Main.prostate.LeftButton!=Microsoft.Xna.Framework.Input.ButtonState.Pressed&!Time.Playing) {
                selection=LayerArray.Count-sort-1;
            }
            if(!Visible) {
                return;
            }
            for(int index = 0;index<ForceArray.Count;++index) {
                ForceArray[index].id=index;
                ForceArray[index].parentid=sort;
                if(!Time.Playing) {
                    ForceArray[index].Update();
                } else {
                    ForceArray[index].copys.Update();
                }
            }
            for(int index = 0;index<ReboundArray.Count;++index) {
                ReboundArray[index].id=index;
                ReboundArray[index].parentid=this.sort;
                if(!Time.Playing) {
                    ReboundArray[index].Update();
                } else {
                    ReboundArray[index].copys.Update();
                }
            }
            for(int index = 0;index<CoverArray.Count;++index) {
                CoverArray[index].id=index;
                CoverArray[index].parentid=sort;
                if(!Time.Playing) {
                    CoverArray[index].Update();
                } else {
                    CoverArray[index].copys.Update();
                }
            }
            for(int index = 0;index<LaseArray.Count;++index) {
                LaseArray[index].id=index;
                LaseArray[index].parentid=sort;
                if(!Time.Playing) {
                    LaseArray[index].Update();
                } else {
                    LaseArray[index].copys.Update();
                }
            }
            for(int index = 0;index<BatchArray.Count;++index) {
                BatchArray[index].id=index;
                BatchArray[index].parentid=sort;
                if(!Time.Playing) {
                    BatchArray[index].Update();
                } else {
                    BatchArray[index].copys.Update();
                }
            }
            if(!Time.Playing) {
                return;
            }
            for(int index = 0;index<Barrages.Count;++index) {
                Barrages[index].id=index;
                Barrages[index].Update();
                Barrages[index].LUpdate();
            }
        }

        public void Draw(SpriteBatch s) {
            if(!Main.Available) {
                return;
            }
            Main.font.Draw(s,name.ToCharArray(),new Vector2(35f,546+13*(LayerArray.Count-sort-1)),Color.White);
            s.Draw(Main.layercolor,new Vector2(16f,545+13*(LayerArray.Count-sort-1)),new Rectangle?(new Rectangle(14*color,0,14,14)),Color.White);
            if(Visible) {
                s.Draw(Main.layercolor,new Vector2(2f,545+13*(LayerArray.Count-sort-1)),new Rectangle?(new Rectangle(0,14,14,14)),Color.White);
            }
            if(169+(begin-Time.left)*6>=169&169+(end-Time.left)*6<=800) {
                s.Draw(Main.layercolor,
                    new Vector2(MathHelper.Clamp(169+(begin-Time.left)*6,169f,800f),545+13*(LayerArray.Count-sort-1)),
                    new Rectangle?(new Rectangle(14*color,0,14,14)),
                    Color.White,
                    0.0f,
                    Vector2.Zero,
                    new Vector2((float)(MathHelper.Clamp(end-begin+1,0.0f,106f)*6.0/14.0),1f),
                    SpriteEffects.None,
                    1f);
            } else {
                s.Draw(Main.layercolor,
                    new Vector2(MathHelper.Clamp(169+(begin-Time.left)*6,169f,800f),545+13*(LayerArray.Count-sort-1)),
                    new Rectangle?(new Rectangle(14*color,0,14,14)),
                    Color.White,
                    0.0f,
                    Vector2.Zero,
                    new Vector2((float)(MathHelper.Clamp(end-Time.left+1,0.0f,106f)*6.0/14.0),1f),
                    SpriteEffects.None,
                    1f);
            }
        }
    }
}
