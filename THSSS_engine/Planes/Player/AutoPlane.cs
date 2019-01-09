using SlimDX;
using System;
using System.Drawing;

namespace Shooting {
    public class AutoPlane:BaseMyPlane {
        private int CtrlCircle = 1;
        private KeyClass KC = new KeyClass();
        public AutoPlane(StageDataPackage StageData,Point Position) : base(StageData,Position) {
        }
        public override void Ctrl() {
            if(Time%CtrlCircle==0) {
                KC=new KeyClass {
                    Key_Z=true
                };
                Vector2 move = GenerateMove();
                double num1 = -move.X;
                double num2 = -move.Y;
                if(move.Length()<80.0) {
                    KC.Key_Shift=true;
                }
                if(num1>1.0) {
                    KC.ArrowLeft=true;
                } else if(num1<-1.0) {
                    KC.ArrowRight=true;
                }
                if(num2>1.0) {
                    KC.ArrowUp=true;
                } else if(num2<-1.0) {
                    KC.ArrowDown=true;
                }
            }
            BulletList.ForEach(x => {
                if(!x.HitCheck(this,x.Region)&&DeadTime<=Time) return;
                KC.Key_X=true;
            });
            StageData.GlobalData.KClass.Hex2Key(KC.Key2Hex());
            base.Ctrl();
        }
        private double GenerateDanger(PointF OriginalPos) {
            double tmp = 0.0;
            double d;
            BulletList.ForEach(x => {
                Vector2 vector2_1 = new Vector2(OriginalPos.X,OriginalPos.Y);
                Vector2 vector2_2 = new Vector2();
                ref Vector2 local = ref vector2_2;
                PointF originalPosition = x.OriginalPosition;
                double x1 = originalPosition.X;
                originalPosition=x.OriginalPosition;
                double y = originalPosition.Y;
                local=new Vector2((float)x1,(float)y);
                d=(vector2_1-vector2_2).Length()-(double)Region-x.Region;
                if(d>=200.0) return;
                tmp+=7000.0/d/d;
                Vector2 vector2_3 = x.Velocity*new Vector2((float)Math.Cos(x.Direction),(float)Math.Sin(x.Direction));
                Vector2 vector2_4 = vector2_2+(float)GetDistance(OriginalPos)/5f*vector2_3;
                d=(double)(vector2_1-vector2_4).Length()-Region-x.Region;
                tmp+=3000.0/d/d;
            });
            EnemyPlaneList.ForEach(x => {
                PointF originalPosition;
                int num;
                if(x.OriginalPosition.X>0.0) {
                    originalPosition=x.OriginalPosition;
                    if(originalPosition.X<(double)BoundRect.Width) {
                        originalPosition=x.OriginalPosition;
                        if(originalPosition.Y>0.0) {
                            originalPosition=x.OriginalPosition;
                            num=originalPosition.Y>=(double)BoundRect.Height ? 1 : 0;
                            goto label_5;
                        }
                    }
                }
                num=1;
                label_5:
                if(num!=0) return;
                Vector2 vector2_1 = new Vector2(OriginalPos.X,OriginalPos.Y);
                Vector2 vector2_2 = new Vector2();
                ref Vector2 local = ref vector2_2;
                originalPosition=x.OriginalPosition;
                double x1 = originalPosition.X;
                originalPosition=x.OriginalPosition;
                double y = originalPosition.Y;
                local=new Vector2((float)x1,(float)y);
                d=(vector2_1-vector2_2).Length()-(double)Region-x.Region;
                tmp+=10000.0/d/d;
            });
            if(Boss!=null) {
                d=Boss.GetDistance(OriginalPos)-Boss.Region-Region;
                tmp+=10000.0/d/d;
            }
            return tmp;
        }
        private Vector2 GenerateDestPoint(int div,int count,float x,float y) {
            Vector2 vector2 = Vector2.Zero;
            double num1 = 1000000000.0;
            double num2 = 0.0;
            x-=div*(count-1)/2;
            y-=div*(count-1)/2;
            Rectangle boundRect;
            if(x<0.0) {
                x=0.0f;
            } else {
                double num3 = x;
                boundRect=BoundRect;
                double num4 = boundRect.Width-div*(count-1);
                if(num3>num4) {
                    boundRect=BoundRect;
                    x=boundRect.Width-div*(count-1);
                }
            }
            if(y<0.0) {
                y=0.0f;
            } else {
                double num3 = (double)y;
                boundRect=this.BoundRect;
                double num4 = (double)(boundRect.Height-div*(count-1));
                if(num3>num4) {
                    boundRect=this.BoundRect;
                    y=(float)(boundRect.Height-div*(count-1));
                }
            }
            for(int index1 = 0;index1<count;++index1) {
                for(int index2 = 0;index2<count;++index2) {
                    double danger = GenerateDanger(new PointF(x,y));
                    if(danger<num1) {
                        num1=danger;
                        vector2=new Vector2(x,y);
                    }
                    if(danger>num2)
                        num2=danger;
                    x+=div;
                }
                y+=div;
                x-=div*count;
            }
            if(num2>2.0) return vector2;
            PointF originalPosition = OriginalPosition;
            double x1 = originalPosition.X;
            originalPosition=OriginalPosition;
            double y1 = originalPosition.Y;
            return new Vector2((float)x1,(float)y1);
        }
        private Vector2 GenerateMove() {
            Vector2 forceSum = Vector2.Zero;
            float d;
            BulletList.ForEach(x => {
                Vector2 vector2_1 = new Vector2();
                ref Vector2 local1 = ref vector2_1;
                PointF originalPosition1 = OriginalPosition;
                double x1 = originalPosition1.X;
                originalPosition1=OriginalPosition;
                double y1 = originalPosition1.Y;
                local1=new Vector2((float)x1,(float)y1);
                Vector2 vector2_2 = new Vector2();
                ref Vector2 local2 = ref vector2_2;
                PointF originalPosition2 = x.OriginalPosition;
                double x2 = originalPosition2.X;
                originalPosition2=x.OriginalPosition;
                double y2 = originalPosition2.Y;
                local2=new Vector2((float)x2,(float)y2);
                Vector2 vector2_3 = vector2_1-vector2_2;
                d=vector2_3.Length()-Region-x.Region;
                if(d>=200.0) return;
                vector2_3.Normalize();
                vector2_3*=5000f/d/d;
                forceSum+=vector2_3;
                Vector2 vector2_4 = x.Velocity*new Vector2((float)Math.Cos(x.Direction),(float)Math.Sin(x.Direction));
                Vector2 vector2_5 = vector2_2+3f*vector2_4;
                Vector2 vector2_6 = vector2_1-vector2_5;
                d=vector2_6.Length()-Region-x.Region;
                vector2_6.Normalize();
                forceSum+=vector2_6*(5000f/d/d);
                Vector2 vector2_7 = vector2_5+6f*vector2_4;
                Vector2 vector2_8 = vector2_1-vector2_7;
                d=vector2_8.Length()-Region-x.Region;
                vector2_8.Normalize();
                vector2_8*=2000f/d/d;
                forceSum+=vector2_8;
            });
            EnemyPlaneList.ForEach(x => {
                PointF originalPosition;
                int num;
                if(x.OriginalPosition.X>0.0) {
                    originalPosition=x.OriginalPosition;
                    if(originalPosition.X<(double)BoundRect.Width) {
                        originalPosition=x.OriginalPosition;
                        if(originalPosition.Y>0.0) {
                            originalPosition=x.OriginalPosition;
                            num=originalPosition.Y>=(double)BoundRect.Height ? 1 : 0;
                            goto label_5;
                        }
                    }
                }
                num=1;
                label_5:
                if(num!=0) return;
                Vector2 vector2_1 = new Vector2();
                ref Vector2 local1 = ref vector2_1;
                originalPosition=OriginalPosition;
                double x1 = originalPosition.X;
                originalPosition=OriginalPosition;
                double y1 = originalPosition.Y;
                local1=new Vector2((float)x1,(float)y1);
                Vector2 vector2_2 = new Vector2();
                ref Vector2 local2 = ref vector2_2;
                originalPosition=x.OriginalPosition;
                double x2 = originalPosition.X;
                originalPosition=x.OriginalPosition;
                double y2 = originalPosition.Y;
                local2=new Vector2((float)x2,(float)y2);
                Vector2 vector2_3 = vector2_1-vector2_2;
                d=vector2_3.Length()-Region-x.Region;
                vector2_3.Normalize();
                forceSum+=vector2_3*(5000f/d/d);
                Vector2 vector2_4 = x.Velocity*new Vector2((float)Math.Cos(x.Direction),(float)Math.Sin(x.Direction));
                Vector2 vector2_5 = vector2_2+5f*vector2_4;
                Vector2 vector2_6 = vector2_1-vector2_5;
                d=vector2_6.Length()-Region-x.Region;
                vector2_6.Normalize();
                forceSum+=vector2_6*(5000f/d/d);
            });
            PointF pointF;
            if(Boss!=null) {
                Vector2 vector2_1 = new Vector2();
                ref Vector2 local1 = ref vector2_1;
                pointF=OriginalPosition;
                double x1 = pointF.X;
                pointF=OriginalPosition;
                double y1 = pointF.Y;
                local1=new Vector2((float)x1,(float)y1);
                Vector2 vector2_2 = new Vector2();
                ref Vector2 local2 = ref vector2_2;
                pointF=Boss.OriginalPosition;
                double x2 = pointF.X;
                pointF=Boss.OriginalPosition;
                double y2 = pointF.Y;
                local2=new Vector2((float)x2,(float)y2);
                Vector2 vector2_3 = vector2_1-vector2_2;
                d=vector2_3.Length()-Region-Boss.Region;
                vector2_3.Normalize();
                Vector2 vector2_4 = vector2_3*(10000f/d/d);
                forceSum+=vector2_4;
            }
            pointF=OriginalPosition;
            double x3 = pointF.X;
            pointF=OriginalPosition;
            double y3 = pointF.Y;
            Vector2 destPoint = GenerateDestPoint(40,4,(float)x3,(float)y3);
            Vector2 start = GenerateDestPoint(10,4,destPoint.X,destPoint.Y);
            start=GenerateDestPoint(2,5,start.X,start.Y);
            Vector2 end = new Vector2();
            ref Vector2 local3 = ref end;
            pointF=DestPoint;
            double x4 = pointF.X;
            pointF=DestPoint;
            double y4 = pointF.Y;
            local3=new Vector2((float)x4,(float)y4);
            if(Time>300) start=Vector2.Lerp(start,end,0.5f);
            Vector2 vector2_9 = new Vector2();
            ref Vector2 local4 = ref vector2_9;
            pointF=OriginalPosition;
            double x5 = pointF.X;
            pointF=OriginalPosition;
            double y5 = pointF.Y;
            local4=new Vector2((float)x5,(float)y5);
            Vector2 vector2_10 = start-vector2_9;
            forceSum+=1f*vector2_10;
            DestPoint=new PointF(start.X,start.Y);
            if(Boss!=null) {
                Vector2 vector2_1 = forceSum;
                pointF=Boss.OriginalPosition;
                double x1 = pointF.X;
                pointF=OriginalPosition;
                double x2 = pointF.X;
                Vector2 vector2_2 = new Vector2((float)(5.0*(x1-x2)),0.0f);
                forceSum=vector2_1+vector2_2;
            } else {
                Vector2 vector2_1 = forceSum;
                Rectangle boundRect = BoundRect;
                double num1 = boundRect.Width/2;
                pointF=OriginalPosition;
                double x1 = pointF.X;
                double num2 = 0.100000001490116*(num1-x1);
                boundRect=BoundRect;
                double height = boundRect.Height;
                pointF=OriginalPosition;
                double y1 = pointF.Y;
                double num3 = 0.100000001490116*(height-y1);
                Vector2 vector2_2 = new Vector2((float)num2,(float)num3);
                forceSum=vector2_1+vector2_2;
                forceSum+=GenerateEnemyBeat();
            }
            forceSum+=GenerateItemGet();
            return forceSum;
        }
        private Vector2 GenerateEnemyBeat() {
            Vector2 vector2 = Vector2.Zero;
            float tmp = 1000f;
            EnemyPlaneList.ForEach(x => {
                PointF originalPosition;
                int num;
                if(x.OriginalPosition.Y>0.0) {
                    originalPosition=x.OriginalPosition;
                    if(originalPosition.Y<300.0) {
                        num=x.HealthPoint>=20000.0 ? 1 : 0;
                        goto label_4;
                    }
                }
                num=1;
                label_4:
                if(num!=0) return;
                originalPosition=x.OriginalPosition;
                double x1 = originalPosition.X;
                originalPosition=OriginalPosition;
                double x2 = originalPosition.X;
                if(Math.Abs((float)(x1-x2))<(double)tmp) {
                    originalPosition=x.OriginalPosition;
                    tmp=originalPosition.X;
                }
            });
            if(tmp<1000.0) vector2=new Vector2((float)(10.0*(tmp-(double)OriginalPosition.X)),0.0f);
            return vector2;
        }
        private Vector2 GenerateItemGet() {
            if(BulletList.Count>10||Boss!=null) return Vector2.Zero;
            int itemCount = 0;
            ItemList.ForEach(x => {
                if(x.Obtain) return;
                ++itemCount;
            });
            if(itemCount>5) return new Vector2(0.0f,(float)(2.0*(110.0-OriginalPosition.Y)));
            return Vector2.Zero;
        }
        public override void Show() {
            MySprite spriteMain = SpriteMain;
            TextureObject textureObject = TextureObjectDictionary["Region"];
            PointF destPoint = DestPoint;
            double num1 = destPoint.X+(double)BoundRect.Left;
            destPoint=DestPoint;
            double num2 = destPoint.Y+(double)BoundRect.Top;
            PointF position = new PointF((float)num1,(float)num2);
            Color white = Color.White;
            spriteMain.Draw2D(textureObject,0.1f,0.0f,position,white);
            base.Show();
        }
    }
}
