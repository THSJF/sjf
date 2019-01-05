// Decompiled with JetBrains decompiler
// Type: Shooting.BaseMyPlane
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shooting {
    public class BaseMyPlane:BaseObject {
        private int life = 2;
        private int spell = 2;
        private int lifeChip = 0;
        private int spellChip = 0;
        public readonly int nextSpellChip = 4;
        public readonly int[] nextLifeChip = new int[9] { 3,5,8,10,12,15,18,20,22 };
        private int lifeUpCount = 0;
        private int power = 100;
        private long score = 0;
        private long hiScore = 0;
        private bool lastX = false;
        private int starPoint = 0;
        public readonly int maxStarPoint = 3000;
        private int nextBluePoint = 300;
        private int nextGreenPoint = 3000;
        private int bluePoint = 0;
        private int greenPoint = 0;
        private int blueLevel = 0;
        private int greenLevel = 0;
        private EnchantmentType enchantmentState = EnchantmentType.None;
        private EnchantmentType lastColor = EnchantmentType.Green;
        private float rate = 1f;
        private int enchantmentCount = 0;
        private int enchantmentCountNeeded = 0;
        private bool OnRotate = false;
        private int Angle3D = 0;
        private const int unmatchedTime = 300;
        private const int deltaGreen = 120;
        private int enchantmentTime;

        public string Name { get; set; }

        public string WeaponType { get; set; }

        public string FullName => Name+WeaponType;

        public bool SlowMove { get; private set; }

        public float HighSpeed { get; set; }

        public float LowSpeed { get; set; }

        public new float Vx { get; private set; }

        public new float Vy { get; private set; }

        public int DeadTime { get; set; }

        public int Life {
            get => life;
            set => life=value>8 ? 8 : value;
        }

        public int Spell {
            get => spell;
            set {
                if(value>8) {
                    spell=8;
                } else if(value<0) {
                    spell=0;
                } else {
                    spell=value;
                }
            }
        }

        public int LifeChip {
            get => lifeChip;
            set {
                for(lifeChip=value;lifeChip>=nextLifeChip[lifeUpCount];++lifeUpCount) {
                    Extend();
                    lifeChip-=nextLifeChip[lifeUpCount];
                }
            }
        }

        public int SpellChip {
            get => spellChip;
            set {
                for(spellChip=value;spellChip>=nextSpellChip;spellChip-=nextSpellChip) {
                    SpellExtand();
                }
            }
        }

        public int Power {
            get => power;
            set {
                if(value>400) {
                    power=400;
                } else if(value<100) {
                    power=100;
                } else {
                    power=value;
                }
            }
        }

        public int PowerLevel => power/100;

        public long Score {
            get => score;
            set {
                if(value>9999999999L) {
                    score=9999999999L;
                } else if(value<0L) {
                    score=0L;
                } else {
                    score=value;
                }
            }
        }

        public long HiScore {
            get => score>hiScore ? score : hiScore;
            set {
                if(value>9999999999L) {
                    hiScore=9999999999L;
                } else if(value<0L) {
                    hiScore=0L;
                } else {
                    hiScore=value;
                }
            }
        }

        public int BluePoint {
            get => bluePoint;
            set => bluePoint=value;
        }

        public int GreenPoint {
            get => greenPoint;
            set => greenPoint=value;
        }

        public int NextBluePoint {
            get => nextBluePoint;
            set => nextBluePoint=value;
        }

        public int NextGreenPoint {
            get => nextGreenPoint;
            set => nextGreenPoint=value;
        }

        public int StarPoint {
            get => starPoint;
            set {
                if(value>=maxStarPoint) {
                    if(starPoint<maxStarPoint) {
                        if(LastColor==EnchantmentType.Red) {
                            ChangeEnchantment(EnchantmentType.Red);
                        } else if(LastColor==EnchantmentType.Blue) {
                            ChangeEnchantment(EnchantmentType.Blue);
                        } else if(LastColor==EnchantmentType.Green) {
                            ChangeEnchantment(EnchantmentType.Green);
                        }
                        StageData.SoundPlay("se_focusrot.wav");
                        BaseBackground baseBackground1 = new BaseBackground(StageData,"pl02b",Position,0.0f,0.0) {
                            ScaleVelocity=1f,
                            LifeTime=26,
                            TransparentVelocity=-10f,
                            Active=false,
                            ColorValue=Color.Black
                        };
                        BaseBackground baseBackground2 = new BaseBackground(StageData,"pl02b",Position,0.0f,0.0) {
                            ScaleVelocity=1f,
                            LifeTime=26,
                            TransparentVelocity=-10f,
                            Active=false,
                            ColorValue=Color.Black
                        };
                        BaseBackground baseBackground3 = new BaseBackground(StageData,"pl02b",Position,0.0f,0.0) {
                            ScaleVelocity=1f,
                            LifeTime=26,
                            TransparentVelocity=-10f,
                            Active=false,
                            ColorValue=Color.Black
                        };
                        EnchantmentMagicCircle enchantmentMagicCircle = new EnchantmentMagicCircle(StageData,OriginalPosition);
                    }
                    starPoint=maxStarPoint;
                } else if(value<0) {
                    starPoint=0;
                } else {
                    starPoint=value;
                }
            }
        }

        public EnchantmentType EnchantmentState {
            get => enchantmentState;
            set => enchantmentState=value;
        }

        public EnchantmentType LastColor {
            get => lastColor;
            set => lastColor=value;
        }

        public int EnchantmentTime {
            get => enchantmentTime;
            set {
                if(value>0) {
                    enchantmentTime=value;
                } else {
                    if(enchantmentTime>0) {
                        if(enchantmentTime==1) {
                            ++EnchantmentCount;
                            Rate+=0.1f;
                            long Bonus = 0;
                            if(enchantmentState==EnchantmentType.Blue) {
                                Bonus=HighItemScore*20;
                            } else if(enchantmentState==EnchantmentType.Green) {
                                Bonus=1000000L;
                            } else if(enchantmentState==EnchantmentType.Red) {
                                Bonus=5120000L;
                            }
                            score+=Bonus;
                            EnchantmentBonus enchantmentBonus = new EnchantmentBonus(StageData,Bonus);
                            StageData.SoundPlay("se_cardget.wav");
                        } else {
                            BaseEffect baseEffect1 = new BaseEffect(StageData,"pl02b",Position,0.0f,0.0) {
                                ScaleVelocity=1f,
                                LifeTime=26,
                                TransparentVelocity=-10f,
                                Active=false,
                                ColorValue=Color.Black
                            };
                            BaseEffect baseEffect2 = new BaseEffect(StageData,"pl02b",Position,0.0f,0.0) {
                                ScaleVelocity=1f,
                                LifeTime=26,
                                TransparentVelocity=-10f,
                                Active=false,
                                ColorValue=Color.Black
                            };
                            BaseEffect baseEffect3 = new BaseEffect(StageData,"pl02b",Position,0.0f,0.0) {
                                ScaleVelocity=1f,
                                LifeTime=26,
                                TransparentVelocity=-10f,
                                Active=false,
                                ColorValue=Color.Black
                            };
                        }
                        if(enchantmentState==EnchantmentType.Green) {
                            Time=UnmatchedTime-60;
                            DeadTime=-1;
                            SpellDisable spellDisable = new SpellDisable(StageData);
                        }
                        StarPoint=0;
                        StageData.SoundPlay("ice005.wav");
                        TextureObject textureObject = TextureObjectDictionary["White"];
                        int num1 = 16;
                        int num2 = 8;
                        Color color = Color.White;
                        if(enchantmentState==EnchantmentType.Blue) {
                            color=Color.Blue;
                        } else if(enchantmentState==EnchantmentType.Green) {
                            color=Color.Green;
                        } else if(enchantmentState==EnchantmentType.Red) {
                            color=Color.Red;
                        }
                        int num3;
                        for(int index = 0;index<num1;++index) {
                            for(num3=0;num3<num2;++num3) {
                                Model_Triangle modelTriangle = new Model_Triangle(StageData.DeviceMain,textureObject,index.ToString()+"_"+num3.ToString(),new Vector2((float)index/(float)num1,(float)num3/(float)num2),new Vector2((float)(index+1)/(float)num1,(float)num3/(float)num2),new Vector2((float)index/(float)num1,(float)(num3+1)/(float)num2),640/num1,480/num2);
                                BaseParticle3D baseParticle3D = new BaseParticle3D {
                                    StageData=StageData,
                                    Position=new PointF(index*640/num1,num3*480/num2),
                                    model=modelTriangle,
                                    Velocity=Ran.Next(20)/10f,
                                    LifeTime=30,
                                    DirectionDegree=Ran.Next(360),
                                    RotatingAxis=new Vector3(Ran.Next(-100,100),Ran.Next(-100,100),Ran.Next(-100,100)),
                                    AngularVelocity3D=Ran.Next(20)/100f,
                                    TransparentVelocity=-6f,
                                    ScaleVelocity=-0.005f,
                                    ColorValue=color,
                                    TransparentValueF=150f
                                };
                                StageData.Particle3D.ParticleList.Add(baseParticle3D);
                            }
                        }
                        for(int index = 0;index<num1;++index) {
                            for(num3=0;num3<num2;++num3) {
                                Model_Triangle modelTriangle = new Model_Triangle(StageData.DeviceMain,textureObject,index.ToString()+"_"+num3.ToString(),new Vector2((float)(index+1)/(float)num1,(float)(num3+1)/(float)num2),new Vector2((float)index/(float)num1,(float)(num3+1)/(float)num2),new Vector2((float)(index+1)/(float)num1,(float)num3/(float)num2),640/num1,480/num2);
                                BaseParticle3D baseParticle3D = new BaseParticle3D {
                                    StageData=StageData,
                                    Position=new PointF((index+1)*640/num1,(num3+1)*480/num2),
                                    model=modelTriangle,
                                    Angle=Math.PI,
                                    Velocity=Ran.Next(20)/10f,
                                    LifeTime=30,
                                    DirectionDegree=Ran.Next(360),
                                    RotatingAxis=new Vector3(Ran.Next(-100,100),Ran.Next(-100,100),Ran.Next(-100,100)),
                                    AngularVelocity3D=Ran.Next(20)/100f,
                                    TransparentVelocity=-6f,
                                    ScaleVelocity=-0.005f,
                                    ColorValue=color,
                                    TransparentValueF=150f
                                };
                                StageData.Particle3D.ParticleList.Add(baseParticle3D);
                            }
                        }
                    }
                    enchantmentTime=0;
                    enchantmentState=EnchantmentType.None;
                }
            }
        }

        public int EnchantmentCount {
            get => enchantmentCount;
            set => enchantmentCount=value;
        }

        public int EnchantmentCountNeeded {
            get => enchantmentCountNeeded;
            set => enchantmentCountNeeded=value;
        }

        public bool FscEnabled => EnchantmentCount>=EnchantmentCountNeeded&&Difficulty>DifficultLevel.Normal;

        public float Rate {
            get => rate;
            set => rate=value;
        }

        public int HighItemScore { get; set; }

        public int Graze { get; set; }

        public int UnmatchedTime => 300;

        public TextureObject[] TxtureObjects { get; set; }

        public PointF[] SubPlanePoint { get; set; }

        public List<BaseSubPlane> SubPlaneList { get; set; }

        public bool SpellEnabled { get; set; }

        public int LifeUpCount {
            get => lifeUpCount;
            set => lifeUpCount=value;
        }

        public BaseMyPlane() {
        }

        public BaseMyPlane(StageDataPackage StageData,Point Position) {
            this.StageData=StageData;
            this.Position=Position;
            TxtureObjects=new TextureObject[72];
            for(int index = 0;index<72;++index) {
                TxtureObjects[index]=TextureObjectDictionary["MyPlane"+index.ToString("D3")];
            }
            TxtureObject=TxtureObjects[0];
            SubPlanePoint=new PointF[4];
            HighSpeed=4.5f;
            LowSpeed=2f;
            Region=1;
            Time=UnmatchedTime;
            DeadTime=-1;
            SubPlaneList=new List<BaseSubPlane>()
           {
        new BaseSubPlane(StageData, "MySubPlane",  Position),
        new BaseSubPlane(StageData, "MySubPlane",  Position),
        new BaseSubPlane(StageData, "MySubPlane",  Position),
        new BaseSubPlane(StageData, "MySubPlane",  Position)
      };
            Name="Plane";
            WeaponType="A";
            SpellEnabled=true;
            HighItemScore=100000;
        }

        public virtual void Refresh() {
            Time=300;
            EnchantmentCount=0;
            SubPlaneList.ForEach(x => x.Refresh());
            SpellEnabled=true;
        }

        public override void Move() {
            Vx=0.0f;
            Vy=0.0f;
            float x1 = OriginalPosition.X;
            float y1 = OriginalPosition.Y;
            SlowMove=KClass.Key_Shift;
            if(!SlowMove) {
                if(KClass.ArrowRight) {
                    Vx+=HighSpeed;
                }
                if(KClass.ArrowLeft) {
                    Vx-=HighSpeed;
                }
                if(KClass.ArrowUp) {
                    Vy+=HighSpeed;
                }
                if(KClass.ArrowDown) {
                    Vy-=HighSpeed;
                }
            } else {
                if(KClass.ArrowRight) {
                    Vx+=LowSpeed;
                }
                if(KClass.ArrowLeft) {
                    Vx-=LowSpeed;
                }
                if(KClass.ArrowUp) {
                    Vy+=LowSpeed;
                }
                if(KClass.ArrowDown) {
                    Vy-=LowSpeed;
                }
            }
            if(Vx!=0.0&&Vy!=0.0) {
                Vx=0.71f*Vx;
                Vy=0.71f*Vy;
            }
            float x2 = x1+Vx;
            float y2 = y1-Vy;
            Rectangle boundRect;
            if(x2<(double)(TxtureObject.Width/2-6)) {
                x2=TxtureObject.Width/2-6;
            } else {
                double num1 = x2;
                boundRect=BoundRect;
                double num2 = boundRect.Width-TxtureObject.Width/2+6;
                if(num1>num2) {
                    boundRect=BoundRect;
                    x2=boundRect.Width-TxtureObject.Width/2+6;
                }
            }
            if(y2<(double)(TxtureObject.Height/2)) {
                y2=TxtureObject.Height/2;
            } else {
                double num1 = y2;
                boundRect=BoundRect;
                double num2 = boundRect.Height-TxtureObject.Height/2+8;
                if(num1>=num2) {
                    boundRect=BoundRect;
                    y2=boundRect.Height-TxtureObject.Height/2+8;
                }
            }
            OriginalPosition=new PointF(x2,y2);
        }

        public virtual void SubPlaneCtrl() {
            if(KClass.Key_Shift) {
                switch(PowerLevel) {
                    case 1:
                        SubPlanePoint[0]=new PointF(OriginalPosition.X,OriginalPosition.Y-30f);
                        break;
                    case 2:
                        ref PointF local1 = ref SubPlanePoint[0];
                        double num1 = OriginalPosition.X-15.0;
                        PointF originalPosition1 = OriginalPosition;
                        double num2 = originalPosition1.Y-30.0;
                        PointF pointF1 = new PointF((float)num1,(float)num2);
                        local1=pointF1;
                        ref PointF local2 = ref SubPlanePoint[1];
                        originalPosition1=OriginalPosition;
                        double num3 = originalPosition1.X+15.0;
                        originalPosition1=OriginalPosition;
                        double num4 = originalPosition1.Y-30.0;
                        PointF pointF2 = new PointF((float)num3,(float)num4);
                        local2=pointF2;
                        break;
                    case 3:
                        ref PointF local3 = ref SubPlanePoint[0];
                        double x1 = OriginalPosition.X;
                        PointF originalPosition2 = OriginalPosition;
                        double num5 = originalPosition2.Y-30.0;
                        PointF pointF3 = new PointF((float)x1,(float)num5);
                        local3=pointF3;
                        ref PointF local4 = ref SubPlanePoint[1];
                        originalPosition2=OriginalPosition;
                        double num6 = originalPosition2.X+20.0;
                        originalPosition2=OriginalPosition;
                        double num7 = originalPosition2.Y-20.0;
                        PointF pointF4 = new PointF((float)num6,(float)num7);
                        local4=pointF4;
                        ref PointF local5 = ref SubPlanePoint[2];
                        originalPosition2=OriginalPosition;
                        double num8 = originalPosition2.X-20.0;
                        originalPosition2=OriginalPosition;
                        double num9 = originalPosition2.Y-20.0;
                        PointF pointF5 = new PointF((float)num8,(float)num9);
                        local5=pointF5;
                        break;
                    case 4:
                        ref PointF local6 = ref SubPlanePoint[0];
                        double num10 = OriginalPosition.X-15.0;
                        PointF originalPosition3 = OriginalPosition;
                        double num11 = originalPosition3.Y-40.0;
                        PointF pointF6 = new PointF((float)num10,(float)num11);
                        local6=pointF6;
                        ref PointF local7 = ref SubPlanePoint[1];
                        originalPosition3=OriginalPosition;
                        double num12 = originalPosition3.X+15.0;
                        originalPosition3=OriginalPosition;
                        double num13 = originalPosition3.Y-40.0;
                        PointF pointF7 = new PointF((float)num12,(float)num13);
                        local7=pointF7;
                        ref PointF local8 = ref SubPlanePoint[2];
                        originalPosition3=OriginalPosition;
                        double num14 = originalPosition3.X-30.0;
                        originalPosition3=OriginalPosition;
                        double num15 = originalPosition3.Y-30.0;
                        PointF pointF8 = new PointF((float)num14,(float)num15);
                        local8=pointF8;
                        ref PointF local9 = ref SubPlanePoint[3];
                        originalPosition3=OriginalPosition;
                        double num16 = originalPosition3.X+30.0;
                        originalPosition3=OriginalPosition;
                        double num17 = originalPosition3.Y-30.0;
                        PointF pointF9 = new PointF((float)num16,(float)num17);
                        local9=pointF9;
                        break;
                }
            } else {
                switch(PowerLevel) {
                    case 1:
                        SubPlanePoint[0]=new PointF(OriginalPosition.X,OriginalPosition.Y-40f);
                        break;
                    case 2:
                        ref PointF local10 = ref SubPlanePoint[0];
                        double num18 = OriginalPosition.X-25.0;
                        PointF originalPosition4 = OriginalPosition;
                        double num19 = originalPosition4.Y-20.0;
                        PointF pointF10 = new PointF((float)num18,(float)num19);
                        local10=pointF10;
                        ref PointF local11 = ref SubPlanePoint[1];
                        originalPosition4=OriginalPosition;
                        double num20 = originalPosition4.X+25.0;
                        originalPosition4=OriginalPosition;
                        double num21 = originalPosition4.Y-20.0;
                        PointF pointF11 = new PointF((float)num20,(float)num21);
                        local11=pointF11;
                        break;
                    case 3:
                        ref PointF local12 = ref SubPlanePoint[0];
                        double x2 = OriginalPosition.X;
                        PointF originalPosition5 = OriginalPosition;
                        double num22 = originalPosition5.Y-40.0;
                        PointF pointF12 = new PointF((float)x2,(float)num22);
                        local12=pointF12;
                        ref PointF local13 = ref SubPlanePoint[1];
                        originalPosition5=OriginalPosition;
                        double num23 = originalPosition5.X+30.0;
                        originalPosition5=OriginalPosition;
                        double num24 = originalPosition5.Y-20.0;
                        PointF pointF13 = new PointF((float)num23,(float)num24);
                        local13=pointF13;
                        ref PointF local14 = ref SubPlanePoint[2];
                        originalPosition5=OriginalPosition;
                        double num25 = originalPosition5.X-30.0;
                        originalPosition5=OriginalPosition;
                        double num26 = originalPosition5.Y-20.0;
                        PointF pointF14 = new PointF((float)num25,(float)num26);
                        local14=pointF14;
                        break;
                    case 4:
                        ref PointF local15 = ref SubPlanePoint[0];
                        double num27 = OriginalPosition.X-25.0;
                        PointF originalPosition6 = OriginalPosition;
                        double num28 = originalPosition6.Y-0.0;
                        PointF pointF15 = new PointF((float)num27,(float)num28);
                        local15=pointF15;
                        ref PointF local16 = ref SubPlanePoint[1];
                        originalPosition6=OriginalPosition;
                        double num29 = originalPosition6.X+25.0;
                        originalPosition6=OriginalPosition;
                        double num30 = originalPosition6.Y-0.0;
                        PointF pointF16 = new PointF((float)num29,(float)num30);
                        local16=pointF16;
                        ref PointF local17 = ref SubPlanePoint[2];
                        originalPosition6=OriginalPosition;
                        double num31 = originalPosition6.X-50.0;
                        originalPosition6=OriginalPosition;
                        double num32 = originalPosition6.Y+5.0;
                        PointF pointF17 = new PointF((float)num31,(float)num32);
                        local17=pointF17;
                        ref PointF local18 = ref SubPlanePoint[3];
                        originalPosition6=OriginalPosition;
                        double num33 = originalPosition6.X+50.0;
                        originalPosition6=OriginalPosition;
                        double num34 = originalPosition6.Y+5.0;
                        PointF pointF18 = new PointF((float)num33,(float)num34);
                        local18=pointF18;
                        break;
                }
            }
            for(int index = 0;index<PowerLevel;++index) {
                SubPlaneList[index].Enabled=true;
                SubPlaneList[index].DestPoint=SubPlanePoint[index];
                SubPlaneList[index].Ctrl();
            }
            for(int powerLevel = PowerLevel;powerLevel<SubPlaneList.Count;++powerLevel) {
                SubPlaneList[powerLevel].Enabled=false;
                SubPlaneList[powerLevel].Position=Position;
            }
        }

        public virtual void TextureCtrl() {
            if(Vx>0.5) {
                if(SlowMove) {
                    OnRotate=false;
                    if(0<=Angle3D&&Angle3D<30) {
                        Angle3D+=5;
                    } else if(Angle3D<0) {
                        Angle3D=0;
                    }
                } else if(!OnRotate) {
                    if(0<=Angle3D&&Angle3D<40) {
                        Angle3D+=5;
                    } else if(Angle3D<0) {
                        OnRotate=true;
                    }
                } else
                    Angle3D+=13;
            } else if(Vx<-0.5) {
                if(SlowMove) {
                    OnRotate=false;
                    if(-30<Angle3D&&Angle3D<=0) {
                        Angle3D-=5;
                    } else if(Angle3D>0) {
                        Angle3D=0;
                    }
                } else if(!OnRotate) {
                    if(-40<Angle3D&&Angle3D<=0) {
                        Angle3D-=5;
                    } else if(Angle3D>0) {
                        OnRotate=true;
                    }
                } else
                    Angle3D-=13;
            } else {
                Angle3D/=2;
                if(-10<Angle3D&&Angle3D<10) {
                    Angle3D=0;
                    OnRotate=false;
                }
            }
            if(Angle3D>180) {
                Angle3D-=360;
            } else if(Angle3D<-180) {
                Angle3D+=360;
            }
            int index = Angle3D/5;
            if(index<0) {
                index+=72;
            } else if(index>72) {
                index-=72;
            }
            TxtureObject=TxtureObjects[index];
        }

        public override void Shoot() {
            if(Time%3==0) {
                StageData.SoundPlay("se_plst00.wav",OriginalPosition.X/(float)BoundRect.Width);
                float x = Position.X;
                float y = Position.Y;
                float num = 7f*(float)Math.Cos((double)Angle3D*Math.PI/180.0);
                BaseMyBullet baseMyBullet1 = new BaseMyBullet(StageData,"自机子弹",new PointF(x-num,y),30f,-1.0*Math.PI/2.0);
                BaseMyBullet baseMyBullet2 = new BaseMyBullet(StageData,"自机子弹",new PointF(x+num,y),30f,-1.0*Math.PI/2.0);
            }
            if(Time%5!=0) {
                return;
            }
            for(int index = 0;index<PowerLevel;++index) {
                SubPlaneList[index].Shoot();
            }
        }

        public virtual void SpellShoot() {
            Spell spell = new Spell(StageData);
            StageData.SoundPlay("se_nep00.wav");
        }

        public virtual void PreMiss() {
            if(Time<UnmatchedTime||Time<DeadTime||SpellList.Count!=0)
                return;
            if(EnchantmentState==EnchantmentType.Green) {
                new BulletRemover_Small(StageData,OriginalPosition).Region=500;
                ChangeEnchantment(EnchantmentType.None);
                EnemyPlaneList.ForEach(x => {
                    if(!(x is BaseSpellCard)) {
                        return;
                    } 
                    ((BaseSpellCard)x).Missed=true;
                });
            } else {
                Emitter emitter = new Emitter(StageData,MyPlane.Position);
                StageData.SoundPlay("se_pldead00.wav",OriginalPosition.X/BoundRect.Width);
                DeadTime=Time+20;
            }
        }

        public virtual void Miss() {
            if(EnchantmentState==EnchantmentType.Red||EnchantmentState==EnchantmentType.Blue) {
                ChangeEnchantment(EnchantmentType.None);
            }
            BulletRemover bulletRemover = new BulletRemover(StageData,OriginalPosition);
            Rectangle boundRect = BoundRect;
            double num1 = (double)(boundRect.Width/2);
            boundRect=BoundRect;
            double num2 = (double)(boundRect.Height+100);
            OriginalPosition=new PointF((float)num1,(float)num2);
            Vx=0.0f;
            Vy=0.0f;
            --Life;
            Power-=16;
            Time=0;
            DeadTime=-1;
        }

        public override void Ctrl() {
            if(!Enabled) {
                return;
            }
            ++Time;
            if(Time==DeadTime) {
                Miss();
            } else if(Time>DeadTime) {
                if(Time==1&&Spell<2) {
                    Spell=2;
                }
                if(Time>70) {
                    Move();
                } else {
                    Rectangle boundRect = BoundRect;
                    double num1 = boundRect.Width/2;
                    boundRect=BoundRect;
                    double num2 = boundRect.Height-30;
                    DestPoint=new PointF((float)num1,(float)num2);
                    Velocity=2f;
                    base.Move();
                    TextureCtrl();
                }
                TextureCtrl();
                Direction+=0.0199999995529652;
                SubPlaneCtrl();
                --EnchantmentTime;
                if(EnchantmentState==EnchantmentType.Blue) {
                    ItemList.ForEach(x => {
                        if(x is ShootingStarShard) {
                            return;
                        }
                        x.Obtain=true;
                        x.Doubled=true;
                    });
                }
            }
            if(Story!=null||Time<=70) {
                return;
            }
            if(KClass.Key_Z&&TimeMain>15) {
                Shoot();
            }
            if(KClass.Key_X&&!lastX) {
                if(EnchantmentState==EnchantmentType.Green) {
                    new BulletRemover_Small(StageData,OriginalPosition).Region=500;
                    ChangeEnchantment(EnchantmentType.None);
                    EnemyPlaneList.ForEach(x => {
                        if(!(x is BaseSpellCard)) {
                            return;
                        } ((BaseSpellCard)x).Bombed=true;
                    });
                } else if(Spell>0&&SpellList.Count==0&&Time>30&&SpellEnabled) {
                    SpellShoot();
                    --Spell;
                }
            }
            lastX=KClass.Key_X;
        }

        public void RetryClear() {
            EnchantmentTime=0;
            Life=2;
            Spell=2;
            Power=400;
            Score=StageData.ContinueTimes;
            Graze=0;
            HiScore=StageData.S_History[0].Score;
            LifeChip=0;
            SpellChip=0;
            LifeUpCount=0;
            StarPoint=0;
            HighItemScore=100000;
            Rate=0.0f;
            LastColor=EnchantmentType.Green;
        }

        public void Extend() {
            if(Life<8) {
                ++Life;
            } else {
                ++Spell;
            }
            StageData.SoundPlay("se_extend.wav");
            BaseEffect baseEffect1 = new BaseEffect(StageData,nameof(Extend),new PointF(0.0f,0.0f),0.0f,Math.PI/2.0) {
                Active=false,
                OriginalPosition=new PointF(BoundRect.Width/2,112f),
                LifeTime=90,
                TransparentValueF=0.0f,
                Layer=1
            };
            BaseEffect baseEffect2 = baseEffect1;
            baseEffect2.TransparentVelocityDictionary.Add(1,13f);
            baseEffect2.TransparentVelocityDictionary.Add(70,-13f);
        }

        public void SpellExtand() {
            StageData.SoundPlay("se_cardget.wav");
            ++Spell;
            BaseEffect baseEffect1 = new BaseEffect(StageData,"SpellExtend",new PointF(0.0f,0.0f),0.0f,Math.PI/2.0) {
                Active=false,
                OriginalPosition=new PointF(BoundRect.Width/2,80f),
                LifeTime=90,
                TransparentValueF=0.0f,
                Layer=1
            };
            BaseEffect baseEffect2 = baseEffect1;
            baseEffect2.TransparentVelocityDictionary.Add(1,13f);
            baseEffect2.TransparentVelocityDictionary.Add(70,-13f);
        }

        public void ChangeEnchantment(EnchantmentType EnchantmentState) {
            switch(EnchantmentState) {
                case EnchantmentType.None:
                    EnchantmentTime=0;
                    break;
                case EnchantmentType.Red:
                    this.EnchantmentState=EnchantmentState;
                    EnchantmentTime=600;
                    break;
                case EnchantmentType.Blue:
                    this.EnchantmentState=EnchantmentState;
                    EnchantmentTime=600;
                    break;
                case EnchantmentType.Green:
                    this.EnchantmentState=EnchantmentState;
                    EnchantmentTime=420;
                    break;
                default:
                    EnchantmentTime=0;
                    break;
            }
        }

        public override void Show() {
            if(Time<DeadTime||Time==0) {
                return;
            }
            if(Time<UnmatchedTime&&Time/2%2==0) {
                SpriteMain.Draw2D(TxtureObject,1f,0.0f,Position,Color.DarkBlue);
            } else {
                SpriteMain.Draw2D(TxtureObject,1f,0.0f,Position,Color.White);
            }
            for(int index = 0;index<PowerLevel;++index) {
                SubPlaneList[index].Show();
            }
        }

        public virtual void ShowCenter() {
            if(!SlowMove) {
                return;
            }
            SpriteMain.Draw2D(TextureObjectDictionary["MyPlaneCenter1"],1f,(float)Direction*4f,Position,Color.White);
        }
    }
}
