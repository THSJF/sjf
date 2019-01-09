using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace THMHJ {
    public class CrazyStorm {
        private float runtime;
        private float runtimebf;
        private string id;
        private bool bansound;
        private bool breaking;
        private bool closing;
        private bool running;
        private bool add;
        private bool item;
        public bool effect;
        public bool bomb;
        public bool specialnotkill;
        public bool clearb;
        public bool allpan;
        public bool isforshoot;
        public bool usekira;
        public bool itemed;
        public bool bansoundbg;
        private int itemtime;
        public Texture2D tex;
        private CSManager csm;
        public Time time;
        private Center center;
        private Vector2 opos;
        private Vector2 ppos;
        public LayerManager layerm;
        public List<BarrageType> bgset;
        public List<byte> shoot;

        public string Id => id;
        public bool Add => add;
        public CrazyStorm(CSManager csm_c) {
            shoot=new List<byte>();
            csm=csm_c;
            center=new Center();
        }
        public CrazyStorm(
          GraphicsDevice g,
          CSManager csm_c,
          bool bansound_b,
          string filename,
          Vector2 Player) {
            shoot=new List<byte>();
            id=filename;
            bgset=new List<BarrageType>();
            csm=csm_c;
            bansound=bansound_b;
            layerm=new LayerManager();
            center=new Center();
            time=new Time(csm,this,layerm);
            StreamReader streamReader = new StreamReader(Cry.Decry("Content/Data/"+filename+".xna",0));
            if(streamReader.ReadLine()=="Crazy Storm Data 1.01") {
                string source = streamReader.ReadLine();
                if(File.Exists("Content/Data/"+filename+".dat")) tex=Texture2D.FromFile(g,Cry.Decry("Content/Data/"+filename+".dat",0));
                if(source.Contains("Types")) {
                    int num = int.Parse(source.Split(' ')[0]);
                    for(int index = 0;index<num;++index) {
                        string str = streamReader.ReadLine();
                        BarrageType barrageType = new BarrageType {
                            name=str.Split('_')[0],
                            rect=new Rectangle(int.Parse(str.Split('_')[1]),int.Parse(str.Split('_')[2]),int.Parse(str.Split('_')[3]),int.Parse(str.Split('_')[4])),
                            origin=new Vector2(int.Parse(str.Split('_')[5]),int.Parse(str.Split('_')[6])),
                            origin0=new Vector2(int.Parse(str.Split('_')[5]),int.Parse(str.Split('_')[6])),
                            pdr0=int.Parse(str.Split('_')[7])
                        };
                        if(str.Split('_')[8]!="") {
                            barrageType.color=int.Parse(str.Split('_')[8]);
                        } else {
                            barrageType.color=-1;
                        }
                        bgset.Add(barrageType);
                    }
                    source=streamReader.ReadLine();
                }
                if(source.Contains("GlobalEvents")) {
                    int num1 = int.Parse(source.Split(' ')[0]);
                    for(int index = 0;index<num1;++index) {
                        string str = streamReader.ReadLine();
                        time.GEcount.Add(int.Parse(str.Split('_')[0])-1);
                        GlobalEvent globalEvent = new GlobalEvent {
                            gotocondition=int.Parse(str.Split('_')[1]),
                            gotoopreator=str.Split('_')[2],
                            gotocvalue=int.Parse(str.Split('_')[3]),
                            isgoto=(bool.Parse(str.Split('_')[4]) ? 1 : 0)!=0,
                            gototime=int.Parse(str.Split('_')[5]),
                            gotowhere=int.Parse(str.Split('_')[6]),
                            quakecondition=int.Parse(str.Split('_')[7]),
                            quakeopreator=str.Split('_')[8],
                            quakecvalue=int.Parse(str.Split('_')[9]),
                            isquake=(bool.Parse(str.Split('_')[10]) ? 1 : 0)!=0,
                            quaketime=int.Parse(str.Split('_')[11]),
                            quakelevel=int.Parse(str.Split('_')[12]),
                            stopcondition=int.Parse(str.Split('_')[13]),
                            stopopreator=str.Split('_')[14],
                            stopcvalue=int.Parse(str.Split('_')[15]),
                            isstop=(bool.Parse(str.Split('_')[16]) ? 1 : 0)!=0,
                            stoptime=int.Parse(str.Split('_')[17]),
                            stoplevel=int.Parse(str.Split('_')[18])
                        };
                        if(time.GE.Count<int.Parse(str.Split('_')[0])) {
                            int num2 = 0;
                            while(true) {
                                if(num2<int.Parse(str.Split('_')[0])) {
                                    time.GE.Add(new GlobalEvent() {
                                        gotocondition=-1,
                                        quakecondition=-1,
                                        stopcondition=-1,
                                        stoplevel=-1
                                    });
                                    ++num2;
                                } else {
                                    break;
                                }
                            }
                        }
                        time.GE[int.Parse(str.Split('_')[0])-1]=globalEvent;
                    }
                    source=streamReader.ReadLine();
                }
                if(source.Contains("Sounds")) {
                    int num = int.Parse(source.Split(' ')[0]);
                    for(int index = 0;index<num;++index) {
                        string str = streamReader.ReadLine();
                        csm.bgset[int.Parse(str.Split('_')[0])-1].sound=str.Split('_')[1];
                    }
                    source=streamReader.ReadLine();
                }
                if(source.Contains(',')) {
                    center.Available=true;
                    center.x=float.Parse(source.Split(':')[1].Split(',')[0]);
                    center.y=float.Parse(source.Split(':')[1].Split(',')[1]);
                    if(source.Split(':')[1].Split(',').Length>=7) {
                        center.speed=float.Parse(source.Split(':')[1].Split(',')[2]);
                        center.speedd=float.Parse(source.Split(':')[1].Split(',')[3]);
                        center.aspeed=float.Parse(source.Split(':')[1].Split(',')[4]);
                        center.aspeedd=float.Parse(source.Split(':')[1].Split(',')[5]);
                        int index = 0;
                        while(true) {
                            if(index<source.Split(':')[1].Split(',')[6].Split(';').Length-1) {
                                center.events.Add(source.Split(':')[1].Split(',')[6].Split(';')[index]);
                                ++index;
                            } else {
                                break;
                            }
                        }
                    }
                } else {
                    center.Available=false;
                }
                time.total=int.Parse(streamReader.ReadLine().Split(',')[0].Split(':')[1]);
                for(int index1 = 0;index1<4;++index1) {
                    string str1 = streamReader.ReadLine();
                    if(str1.Split(':')[1].Split(',')[0]!="empty") {
                        Layer layer = new Layer(layerm,int.Parse(str1.Split(':')[1].Split(',')[1]),int.Parse(str1.Split(':')[1].Split(',')[2]));
                        int num1 = int.Parse(str1.Split(':')[1].Split(',')[3]);
                        for(int index2 = 0;index2<num1;++index2) {
                            string str2 = streamReader.ReadLine();
                            Batch batch = new Batch(float.Parse(str2.Split(',')[6]),float.Parse(str2.Split(',')[7]),layerm) {
                                id=int.Parse(str2.Split(',')[0]),
                                parentid=int.Parse(str2.Split(',')[1]),
                                Binding=(bool.Parse(str2.Split(',')[2]) ? 1 : 0)!=0,
                                bindid=int.Parse(str2.Split(',')[3]),
                                Bindwithspeedd=(bool.Parse(str2.Split(',')[4]) ? 1 : 0)!=0,
                                begin=int.Parse(str2.Split(',')[8]),
                                life=int.Parse(str2.Split(',')[9]),
                                fx=float.Parse(str2.Split(',')[10]),
                                fy=float.Parse(str2.Split(',')[11]),
                                r=int.Parse(str2.Split(',')[12]),
                                rdirection=float.Parse(str2.Split(',')[13])
                            };
                            string str3 = str2.Split(',')[14].Replace("{","").Replace("}","");
                            batch.rdirections.X=float.Parse(str3.Split(' ')[0].Split(':')[1]);
                            batch.rdirections.Y=float.Parse(str3.Split(' ')[1].Split(':')[1]);
                            batch.tiao=int.Parse(str2.Split(',')[15]);
                            batch.t=int.Parse(str2.Split(',')[16]);
                            batch.fdirection=float.Parse(str2.Split(',')[17]);
                            string str4 = str2.Split(',')[18].Replace("{","").Replace("}","");
                            batch.fdirections.X=float.Parse(str4.Split(' ')[0].Split(':')[1]);
                            batch.fdirections.Y=float.Parse(str4.Split(' ')[1].Split(':')[1]);
                            batch.range=int.Parse(str2.Split(',')[19]);
                            batch.speed=float.Parse(str2.Split(',')[20]);
                            batch.speedd=float.Parse(str2.Split(',')[21]);
                            string str5 = str2.Split(',')[22].Replace("{","").Replace("}","");
                            batch.speedds.X=float.Parse(str5.Split(' ')[0].Split(':')[1]);
                            batch.speedds.Y=float.Parse(str5.Split(' ')[1].Split(':')[1]);
                            batch.aspeed=float.Parse(str2.Split(',')[23]);
                            batch.aspeedd=float.Parse(str2.Split(',')[24]);
                            string str6 = str2.Split(',')[25].Replace("{","").Replace("}","");
                            batch.aspeedds.X=float.Parse(str6.Split(' ')[0].Split(':')[1]);
                            batch.aspeedds.Y=float.Parse(str6.Split(' ')[1].Split(':')[1]);
                            batch.sonlife=int.Parse(str2.Split(',')[26]);
                            batch.type=int.Parse(str2.Split(',')[27]);
                            batch.wscale=float.Parse(str2.Split(',')[28]);
                            batch.hscale=float.Parse(str2.Split(',')[29]);
                            batch.colorR=int.Parse(str2.Split(',')[30]);
                            batch.colorG=int.Parse(str2.Split(',')[31]);
                            batch.colorB=int.Parse(str2.Split(',')[32]);
                            batch.alpha=int.Parse(str2.Split(',')[33]);
                            batch.head=float.Parse(str2.Split(',')[34]);
                            string str7 = str2.Split(',')[35].Replace("{","").Replace("}","");
                            batch.heads.X=float.Parse(str7.Split(' ')[0].Split(':')[1]);
                            batch.heads.Y=float.Parse(str7.Split(' ')[1].Split(':')[1]);
                            batch.Withspeedd=(bool.Parse(str2.Split(',')[36]) ? 1 : 0)!=0;
                            batch.sonspeed=float.Parse(str2.Split(',')[37]);
                            batch.sonspeedd=float.Parse(str2.Split(',')[38]);
                            string str8 = str2.Split(',')[39].Replace("{","").Replace("}","");
                            batch.sonspeedds.X=float.Parse(str8.Split(' ')[0].Split(':')[1]);
                            batch.sonspeedds.Y=float.Parse(str8.Split(' ')[1].Split(':')[1]);
                            batch.sonaspeed=float.Parse(str2.Split(',')[40]);
                            batch.sonaspeedd=float.Parse(str2.Split(',')[41]);
                            string str9 = str2.Split(',')[42].Replace("{","").Replace("}","");
                            batch.sonaspeedds.X=float.Parse(str9.Split(' ')[0].Split(':')[1]);
                            batch.sonaspeedds.Y=float.Parse(str9.Split(' ')[1].Split(':')[1]);
                            batch.xscale=float.Parse(str2.Split(',')[43]);
                            batch.yscale=float.Parse(str2.Split(',')[44]);
                            batch.Mist=(bool.Parse(str2.Split(',')[45]) ? 1 : 0)!=0;
                            batch.Dispel=(bool.Parse(str2.Split(',')[46]) ? 1 : 0)!=0;
                            batch.Blend=(bool.Parse(str2.Split(',')[47]) ? 1 : 0)!=0;
                            batch.Afterimage=(bool.Parse(str2.Split(',')[48]) ? 1 : 0)!=0;
                            batch.Outdispel=(bool.Parse(str2.Split(',')[49]) ? 1 : 0)!=0;
                            batch.Invincible=(bool.Parse(str2.Split(',')[50]) ? 1 : 0)!=0;
                            string str10 = str2.Split(',')[51];
                            int idx1 = 0;
                            while(true) {
                                if(idx1<str10.Split('&').Length-1) {
                                    string str11 = str10.Split('&')[idx1];
                                    Event @event = new Event(idx1) {
                                        tag=str11.Split('|')[0],
                                        t=int.Parse(str11.Split('|')[1]),
                                        addtime=int.Parse(str11.Split('|')[2])
                                    };
                                    int index3 = 0;
                                    while(true) {
                                        if(index3<str11.Split('|')[3].Split(';').Length-1) {
                                            @event.events.Add(str11.Split('|')[3].Split(';')[index3]);
                                            ++index3;
                                        } else {
                                            break;
                                        }
                                    }
                                    batch.Parentevents.Add(@event);
                                    ++idx1;
                                } else {
                                    break;
                                }
                            }
                            string str12 = str2.Split(',')[52];
                            int idx2 = 0;
                            while(true) {
                                if(idx2<str12.Split('&').Length-1) {
                                    string str11 = str12.Split('&')[idx2];
                                    Event @event = new Event(idx2) {
                                        tag=str11.Split('|')[0],
                                        t=int.Parse(str11.Split('|')[1]),
                                        addtime=int.Parse(str11.Split('|')[2])
                                    };
                                    int index3 = 0;
                                    while(true) {
                                        if(index3<str11.Split('|')[3].Split(';').Length-1) {
                                            @event.events.Add(str11.Split('|')[3].Split(';')[index3]);
                                            ++index3;
                                        } else {
                                            break;
                                        }
                                    }
                                    batch.Sonevents.Add(@event);
                                    ++idx2;
                                } else {
                                    break;
                                }
                            }
                            batch.rand.fx=float.Parse(str2.Split(',')[53]);
                            batch.rand.fy=float.Parse(str2.Split(',')[54]);
                            batch.rand.r=int.Parse(str2.Split(',')[55]);
                            batch.rand.rdirection=float.Parse(str2.Split(',')[56]);
                            batch.rand.tiao=int.Parse(str2.Split(',')[57]);
                            batch.rand.t=int.Parse(str2.Split(',')[58]);
                            batch.rand.fdirection=float.Parse(str2.Split(',')[59]);
                            batch.rand.range=int.Parse(str2.Split(',')[60]);
                            batch.rand.speed=float.Parse(str2.Split(',')[61]);
                            batch.rand.speedd=float.Parse(str2.Split(',')[62]);
                            batch.rand.aspeed=float.Parse(str2.Split(',')[63]);
                            batch.rand.aspeedd=float.Parse(str2.Split(',')[64]);
                            batch.rand.head=float.Parse(str2.Split(',')[65]);
                            batch.rand.sonspeed=float.Parse(str2.Split(',')[66]);
                            batch.rand.sonspeedd=float.Parse(str2.Split(',')[67]);
                            batch.rand.sonaspeed=float.Parse(str2.Split(',')[68]);
                            batch.rand.sonaspeedd=float.Parse(str2.Split(',')[69]);
                            if(str2.Split(',').Length>=72) {
                                batch.Cover=(bool.Parse(str2.Split(',')[70]) ? 1 : 0)!=0;
                                batch.Rebound=(bool.Parse(str2.Split(',')[71]) ? 1 : 0)!=0;
                                batch.Force=(bool.Parse(str2.Split(',')[72]) ? 1 : 0)!=0;
                            }
                            if(str2.Split(',').Length>=74) batch.Deepbind=(bool.Parse(str2.Split(',')[73]) ? 1 : 0)!=0;
                            layerm.LayerArray[index1].BatchArray.Add(batch);
                        }
                        if(str1.Split(':')[1].Split(',').Length>=7) {
                            int num2 = int.Parse(str1.Split(':')[1].Split(',')[4]);
                            for(int index2 = 0;index2<num2;++index2) {
                                string str2 = streamReader.ReadLine();
                                Lase lase = new Lase(float.Parse(str2.Split(',')[6]),float.Parse(str2.Split(',')[7]),layerm) {
                                    id=int.Parse(str2.Split(',')[0]),
                                    parentid=int.Parse(str2.Split(',')[1]),
                                    Binding=(bool.Parse(str2.Split(',')[2]) ? 1 : 0)!=0,
                                    bindid=int.Parse(str2.Split(',')[3]),
                                    Bindwithspeedd=(bool.Parse(str2.Split(',')[4]) ? 1 : 0)!=0,
                                    begin=int.Parse(str2.Split(',')[8]),
                                    life=int.Parse(str2.Split(',')[9]),
                                    r=int.Parse(str2.Split(',')[10]),
                                    rdirection=float.Parse(str2.Split(',')[11])
                                };
                                string str3 = str2.Split(',')[12].Replace("{","").Replace("}","");
                                lase.rdirections.X=float.Parse(str3.Split(' ')[0].Split(':')[1]);
                                lase.rdirections.Y=float.Parse(str3.Split(' ')[1].Split(':')[1]);
                                lase.tiao=int.Parse(str2.Split(',')[13]);
                                lase.t=int.Parse(str2.Split(',')[14]);
                                lase.fdirection=float.Parse(str2.Split(',')[15]);
                                string str4 = str2.Split(',')[16].Replace("{","").Replace("}","");
                                lase.fdirections.X=float.Parse(str4.Split(' ')[0].Split(':')[1]);
                                lase.fdirections.Y=float.Parse(str4.Split(' ')[1].Split(':')[1]);
                                lase.range=int.Parse(str2.Split(',')[17]);
                                lase.speed=float.Parse(str2.Split(',')[18]);
                                lase.speedd=float.Parse(str2.Split(',')[19]);
                                string str5 = str2.Split(',')[20].Replace("{","").Replace("}","");
                                lase.speedds.X=float.Parse(str5.Split(' ')[0].Split(':')[1]);
                                lase.speedds.Y=float.Parse(str5.Split(' ')[1].Split(':')[1]);
                                lase.aspeed=float.Parse(str2.Split(',')[21]);
                                lase.aspeedd=float.Parse(str2.Split(',')[22]);
                                string str6 = str2.Split(',')[23].Replace("{","").Replace("}","");
                                lase.aspeedds.X=float.Parse(str6.Split(' ')[0].Split(':')[1]);
                                lase.aspeedds.Y=float.Parse(str6.Split(' ')[1].Split(':')[1]);
                                lase.sonlife=int.Parse(str2.Split(',')[24]);
                                lase.type=int.Parse(str2.Split(',')[25]);
                                lase.wscale=float.Parse(str2.Split(',')[26]);
                                lase.longs=float.Parse(str2.Split(',')[27]);
                                lase.alpha=int.Parse(str2.Split(',')[28]);
                                lase.Ray=(bool.Parse(str2.Split(',')[29]) ? 1 : 0)!=0;
                                lase.sonspeed=float.Parse(str2.Split(',')[30]);
                                lase.sonspeedd=float.Parse(str2.Split(',')[31]);
                                string str7 = str2.Split(',')[32].Replace("{","").Replace("}","");
                                lase.sonspeedds.X=float.Parse(str7.Split(' ')[0].Split(':')[1]);
                                lase.sonspeedds.Y=float.Parse(str7.Split(' ')[1].Split(':')[1]);
                                lase.sonaspeed=float.Parse(str2.Split(',')[33]);
                                lase.sonaspeedd=float.Parse(str2.Split(',')[34]);
                                string str8 = str2.Split(',')[35].Replace("{","").Replace("}","");
                                lase.sonaspeedds.X=float.Parse(str8.Split(' ')[0].Split(':')[1]);
                                lase.sonaspeedds.Y=float.Parse(str8.Split(' ')[1].Split(':')[1]);
                                lase.xscale=float.Parse(str2.Split(',')[36]);
                                lase.yscale=float.Parse(str2.Split(',')[37]);
                                lase.Blend=(bool.Parse(str2.Split(',')[38]) ? 1 : 0)!=0;
                                lase.Outdispel=(bool.Parse(str2.Split(',')[39]) ? 1 : 0)!=0;
                                lase.Invincible=(bool.Parse(str2.Split(',')[40]) ? 1 : 0)!=0;
                                string str9 = str2.Split(',')[42];
                                int idx1 = 0;
                                while(true) {
                                    if(idx1<str9.Split('&').Length-1) {
                                        string str10 = str9.Split('&')[idx1];
                                        Event @event = new Event(idx1) {
                                            tag=str10.Split('|')[0],
                                            t=int.Parse(str10.Split('|')[1]),
                                            addtime=int.Parse(str10.Split('|')[2])
                                        };
                                        int index3 = 0;
                                        while(true) {
                                            if(index3<str10.Split('|')[3].Split(';').Length-1) {
                                                @event.events.Add(str10.Split('|')[3].Split(';')[index3]);
                                                ++index3;
                                            } else {
                                                break;
                                            }
                                        }
                                        lase.Parentevents.Add(@event);
                                        ++idx1;
                                    } else {
                                        break;
                                    }
                                }
                                string str11 = str2.Split(',')[43];
                                int idx2 = 0;
                                while(true) {
                                    if(idx2<str11.Split('&').Length-1) {
                                        string str10 = str11.Split('&')[idx2];
                                        Event @event = new Event(idx2) {
                                            tag=str10.Split('|')[0],
                                            t=int.Parse(str10.Split('|')[1]),
                                            addtime=int.Parse(str10.Split('|')[2])
                                        };
                                        int index3 = 0;
                                        while(true) {
                                            if(index3<str10.Split('|')[3].Split(';').Length-1) {
                                                @event.events.Add(str10.Split('|')[3].Split(';')[index3]);
                                                ++index3;
                                            } else {
                                                break;
                                            }
                                        }
                                        lase.Sonevents.Add(@event);
                                        ++idx2;
                                    } else {
                                        break;
                                    }
                                }
                                lase.rand.r=int.Parse(str2.Split(',')[44]);
                                lase.rand.rdirection=float.Parse(str2.Split(',')[45]);
                                lase.rand.tiao=int.Parse(str2.Split(',')[46]);
                                lase.rand.t=int.Parse(str2.Split(',')[47]);
                                lase.rand.fdirection=float.Parse(str2.Split(',')[48]);
                                lase.rand.range=int.Parse(str2.Split(',')[49]);
                                lase.rand.speed=float.Parse(str2.Split(',')[50]);
                                lase.rand.speedd=float.Parse(str2.Split(',')[51]);
                                lase.rand.aspeed=float.Parse(str2.Split(',')[52]);
                                lase.rand.aspeedd=float.Parse(str2.Split(',')[53]);
                                lase.rand.sonspeed=float.Parse(str2.Split(',')[54]);
                                lase.rand.sonspeedd=float.Parse(str2.Split(',')[55]);
                                lase.rand.sonaspeed=float.Parse(str2.Split(',')[56]);
                                lase.rand.sonaspeedd=float.Parse(str2.Split(',')[57]);
                                if(str2.Split(',').Length>=59) lase.Deepbind=(bool.Parse(str2.Split(',')[58]) ? 1 : 0)!=0;
                                layerm.LayerArray[index1].LaseArray.Add(lase);
                            }
                            int num3 = int.Parse(str1.Split(':')[1].Split(',')[5]);
                            for(int index2 = 0;index2<num3;++index2) {
                                string str2 = streamReader.ReadLine();
                                Cover cover = new Cover(float.Parse(str2.Split(',')[2]),float.Parse(str2.Split(',')[3]),layerm) {
                                    id=int.Parse(str2.Split(',')[0]),
                                    parentid=int.Parse(str2.Split(',')[1]),
                                    begin=int.Parse(str2.Split(',')[4]),
                                    life=int.Parse(str2.Split(',')[5]),
                                    halfw=int.Parse(str2.Split(',')[6]),
                                    halfh=int.Parse(str2.Split(',')[7]),
                                    Circle=(bool.Parse(str2.Split(',')[8]) ? 1 : 0)!=0,
                                    type=int.Parse(str2.Split(',')[9]),
                                    controlid=int.Parse(str2.Split(',')[10]),
                                    speed=float.Parse(str2.Split(',')[11]),
                                    speedd=float.Parse(str2.Split(',')[12])
                                };
                                string str3 = str2.Split(',')[13].Replace("{","").Replace("}","");
                                cover.speedds.X=float.Parse(str3.Split(' ')[0].Split(':')[1]);
                                cover.speedds.Y=float.Parse(str3.Split(' ')[1].Split(':')[1]);
                                cover.aspeed=float.Parse(str2.Split(',')[14]);
                                cover.aspeedd=float.Parse(str2.Split(',')[15]);
                                string str4 = str2.Split(',')[16].Replace("{","").Replace("}","");
                                cover.aspeedds.X=float.Parse(str4.Split(' ')[0].Split(':')[1]);
                                cover.aspeedds.Y=float.Parse(str4.Split(' ')[1].Split(':')[1]);
                                string str5 = str2.Split(',')[17];
                                int idx1 = 0;
                                while(true) {
                                    if(idx1<str5.Split('&').Length-1) {
                                        string str6 = str5.Split('&')[idx1];
                                        Event @event = new Event(idx1) {
                                            tag=str6.Split('|')[0],
                                            t=int.Parse(str6.Split('|')[1]),
                                            addtime=int.Parse(str6.Split('|')[2])
                                        };
                                        int index3 = 0;
                                        while(true) {
                                            if(index3<str6.Split('|')[3].Split(';').Length-1) {
                                                @event.events.Add(str6.Split('|')[3].Split(';')[index3]);
                                                ++index3;
                                            } else {
                                                break;
                                            }
                                        }
                                        cover.Parentevents.Add(@event);
                                        ++idx1;
                                    } else {
                                        break;
                                    }
                                }
                                string str7 = str2.Split(',')[18];
                                int idx2 = 0;
                                while(true) {
                                    if(idx2<str7.Split('&').Length-1) {
                                        string str6 = str7.Split('&')[idx2];
                                        Event @event = new Event(idx2) {
                                            tag=str6.Split('|')[0],
                                            t=int.Parse(str6.Split('|')[1]),
                                            addtime=int.Parse(str6.Split('|')[2])
                                        };
                                        int index3 = 0;
                                        while(true) {
                                            if(index3<str6.Split('|')[3].Split(';').Length-1) {
                                                @event.events.Add(str6.Split('|')[3].Split(';')[index3]);
                                                ++index3;
                                            } else {
                                                break;
                                            }
                                        }
                                        cover.Sonevents.Add(@event);
                                        ++idx2;
                                    } else {
                                        break;
                                    }
                                }
                                cover.rand.speed=float.Parse(str2.Split(',')[19]);
                                cover.rand.speedd=float.Parse(str2.Split(',')[20]);
                                cover.rand.aspeed=float.Parse(str2.Split(',')[21]);
                                cover.rand.aspeedd=float.Parse(str2.Split(',')[22]);
                                if(str2.Split(',').Length>=24) cover.bindid=int.Parse(str2.Split(',')[23]);
                                if(str2.Split(',').Length>=25) {
                                    if(str2.Split(',')[24]!="") cover.Deepbind=(bool.Parse(str2.Split(',')[24]) ? 1 : 0)!=0;
                                }
                                layerm.LayerArray[index1].CoverArray.Add(cover);
                            }
                            int num4 = int.Parse(str1.Split(':')[1].Split(',')[6]);
                            for(int index2 = 0;index2<num4;++index2) {
                                string str2 = streamReader.ReadLine();
                                Rebound rebound = new Rebound(float.Parse(str2.Split(',')[2]),float.Parse(str2.Split(',')[3]),layerm) {
                                    id=int.Parse(str2.Split(',')[0]),
                                    parentid=int.Parse(str2.Split(',')[1]),
                                    begin=int.Parse(str2.Split(',')[4]),
                                    life=int.Parse(str2.Split(',')[5]),
                                    longs=int.Parse(str2.Split(',')[6]),
                                    angle=int.Parse(str2.Split(',')[7]),
                                    time=int.Parse(str2.Split(',')[8]),
                                    speed=float.Parse(str2.Split(',')[9]),
                                    speedd=float.Parse(str2.Split(',')[10]),
                                    aspeed=float.Parse(str2.Split(',')[11]),
                                    aspeedd=float.Parse(str2.Split(',')[12])
                                };
                                string str3 = str2.Split(',')[13];
                                int idx = 0;
                                while(true) {
                                    if(idx<str3.Split('&').Length-1) {
                                        string str4 = str3.Split('&')[idx];
                                        rebound.Parentevents.Add(new Event(idx) {
                                            tag=str4
                                        });
                                        ++idx;
                                    } else {
                                        break;
                                    }
                                }
                                rebound.rand.speed=float.Parse(str2.Split(',')[14]);
                                rebound.rand.speedd=float.Parse(str2.Split(',')[15]);
                                rebound.rand.aspeed=float.Parse(str2.Split(',')[16]);
                                rebound.rand.aspeedd=float.Parse(str2.Split(',')[17]);
                                layerm.LayerArray[index1].ReboundArray.Add(rebound);
                            }
                            int num5 = int.Parse(str1.Split(':')[1].Split(',')[7]);
                            for(int index2 = 0;index2<num5;++index2) {
                                string str2 = streamReader.ReadLine();
                                layerm.LayerArray[index1].ForceArray.Add(new Force(float.Parse(str2.Split(',')[2]),float.Parse(str2.Split(',')[3]),layerm) {
                                    id=int.Parse(str2.Split(',')[0]),
                                    parentid=int.Parse(str2.Split(',')[1]),
                                    begin=int.Parse(str2.Split(',')[4]),
                                    life=int.Parse(str2.Split(',')[5]),
                                    halfw=int.Parse(str2.Split(',')[6]),
                                    halfh=int.Parse(str2.Split(',')[7]),
                                    Circle=(bool.Parse(str2.Split(',')[8]) ? 1 : 0)!=0,
                                    type=int.Parse(str2.Split(',')[9]),
                                    controlid=int.Parse(str2.Split(',')[10]),
                                    speed=float.Parse(str2.Split(',')[11]),
                                    speedd=float.Parse(str2.Split(',')[12]),
                                    aspeed=float.Parse(str2.Split(',')[13]),
                                    aspeedd=float.Parse(str2.Split(',')[14]),
                                    addaspeed=float.Parse(str2.Split(',')[15]),
                                    addaspeedd=float.Parse(str2.Split(',')[16]),
                                    Suction=(bool.Parse(str2.Split(',')[17]) ? 1 : 0)!=0,
                                    Repulsion=(bool.Parse(str2.Split(',')[18]) ? 1 : 0)!=0,
                                    addspeed=float.Parse(str2.Split(',')[19]),
                                    rand= {
                    speed = float.Parse(str2.Split(',')[20]),
                    speedd = float.Parse(str2.Split(',')[21]),
                    aspeed = float.Parse(str2.Split(',')[22]),
                    aspeedd = float.Parse(str2.Split(',')[23])
                  }
                                });
                            }
                        }
                    }
                }
            }
            time.Init(Player);
        }
        public void SetCsm(CSManager csm_c) => csm=csm_c;
        public void SetOPos(Vector2 pos) => opos=pos;
        public void SetPos(Vector2 pos,bool all) {
            if(center.Available&&!all) {
                center.ox=pos.X;
                center.oy=pos.Y;
            }
            if(!all) return;
            ppos=new Vector2(pos.X-opos.X,pos.Y-opos.Y);
        }
        public CrazyStorm Clone(bool add) {
            CrazyStorm crazyStorm = new CrazyStorm(csm) {
                id=id,
                tex=tex,
                bgset=bgset,
                center= {
                          x =  center.x,
                          y =  center.y,
                          speed =  center.speed,
                          speedd =  center.speedd,
                          aspeed =  center.aspeed,
                          aspeedd =  center.aspeedd,
                          Available =  center.Available,
                          events =  center.events
                         },
                layerm=(LayerManager)layerm.Clone()
            };
            crazyStorm.time=new Time(csm,this,crazyStorm.layerm);
            crazyStorm.time.total=time.total;
            crazyStorm.add=add;
            foreach(GlobalEvent globalEvent in time.GE) {
                crazyStorm.time.GE.Add(globalEvent);
            }
            foreach(int num in time.GEcount) {
                crazyStorm.time.GEcount.Add(num);
            }
            return crazyStorm;
        }
        public void Start() => running=true;
        public void EndStart() => running=false;
        public bool IsStarted() => running;
        public void BanSound(bool b) => bansound=b;
        public void Close() => closing=true;
        public bool IsClosing() => closing;
        public void Break() {
            closing=true;
            breaking=true;
        }
        public void Breakanditem() {
            closing=true;
            breaking=true;
            item=true;
        }
        public bool IsItem() => item;
        public bool IsItemed() => itemtime>120;
        public bool IsBreaking() => breaking;
        public bool Run() => running;
        public int BarrageCount() {
            int num = 0;
            for(int index = 0;index<layerm.LayerArray.Count;++index) num+=layerm.LayerArray[index].Barrages.Count;
            return num;
        }
        public void Update(Character Player,EnemyManager em,Boss boss) {
            if(itemed) ++itemtime;
            if(effect) {
                runtime+=Time.Stop;
            } else {
                ++runtime;
            }
            if(runtime-runtimebf<1.0) return;
            for(int index = 0;index<layerm.LayerArray.Count;++index) {
                layerm.LayerArray[index].sort=index;
                layerm.LayerArray[index].Update(layerm,this,csm,time,center,Player,em,boss,bansound,allpan,ppos,isforshoot,usekira,bansoundbg);
            }
            center.Update(csm,this,time,Player,boss);
            time.Update(this,center,new Vector2(Player.body.position.X+93f,Player.body.position.Y-13f));
            runtimebf=runtime;
        }
        public void Draw(SpriteBatch s,Vector2 q) {
            for(int index1 = 0;index1<layerm.LayerArray.Count;++index1) {
                for(int index2 = 0;index2<layerm.LayerArray[index1].Barrages.Count;++index2) {
                    if(!layerm.LayerArray[index1].Barrages[index2].Blend) {
                        if(!layerm.LayerArray[index1].Barrages[index2].NeedDelete) {
                            layerm.LayerArray[index1].Barrages[index2].Draw(s,csm,this,time,ppos,q);
                            layerm.LayerArray[index1].Barrages[index2].LDraw(s,csm,time,q);
                        } else {
                            layerm.LayerArray[index1].Barrages.RemoveAt(index2);
                            --index2;
                        }
                    }
                }
                s.End();
                s.Begin(SpriteBlendMode.Additive);
                for(int index2 = 0;index2<layerm.LayerArray[index1].Barrages.Count;++index2) {
                    if(layerm.LayerArray[index1].Barrages[index2].Blend) {
                        if(!layerm.LayerArray[index1].Barrages[index2].NeedDelete) {
                            layerm.LayerArray[index1].Barrages[index2].Draw(s,csm,this,time,ppos,q);
                            layerm.LayerArray[index1].Barrages[index2].LDraw(s,csm,time,q);
                        } else {
                            layerm.LayerArray[index1].Barrages.RemoveAt(index2);
                            --index2;
                        }
                    }
                }
                s.End();
                s.Begin();
            }
        }
    }
}
