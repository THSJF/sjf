using SlimDX.Direct3D9;
using System;
using System.Drawing;

namespace Shooting {
    public class MarisaLaser:BaseEffect {
        public MarisaLaser(StageDataPackage StageData,string textureName,PointF OriginalPosition,float v,double drctn) : base(StageData,textureName,new PointF(0.0f,0.0f),v,drctn) {
            this.StageData=StageData;
            this.OriginalPosition=OriginalPosition;
            Damage=4;
            Region=128;
            MaxVelocity=1000f;
            MinVelocity=-1000f;
            Velocity=v;
            LifeTime=5;
        }
        public override void Ctrl() {
            base.Ctrl();
            Velocity=192f;
            bool flag = false;
            for(int index = EnemyPlaneList.Count-1;index>=0;--index) {
                if(HitCheck(EnemyPlaneList[index])) {
                    flag=true;
                    if(MyPlane.EnchantmentState==EnchantmentType.Red) {
                        EnemyPlaneList[index].HealthPoint-=Damage*1.25f;
                    } else {
                        EnemyPlaneList[index].HealthPoint-=Damage;
                    }
                    if(EnemyPlaneList[index].HealthPoint<10000.0) MyPlane.Score+=10L;
                    if(EnemyPlaneList[index].HealthPoint<=0.0) {
                        EnemyPlaneList[index].GiveEndEffect();
                        EnemyPlaneList[index].GiveItems();
                        EnemyPlaneList.RemoveAt(index);
                        StageData.SoundPlay("se_enep00.wav",OriginalPosition.X/BoundRect.Width);
                        break;
                    }
                }
            }
            if(Boss!=null&&HitCheck(Boss)) {
                flag=true;
                if(Boss.Time>Boss.UnmatchedTime) {
                    if(MyPlane.EnchantmentState==EnchantmentType.Red) {
                        Boss.HealthPoint-=(float)(Damage*1.25*(1.0-Boss.Armon));
                    } else {
                        Boss.HealthPoint-=Damage*(1f-Boss.Armon);
                    }
                }
                MyPlane.Score+=10L;
                if(Boss.HealthPoint<=200.0) StageData.SoundPlay("se_damage01.wav");
            }
            if(!flag) return;
            Damage=0;
        }
        public override bool HitCheck(BaseObject Target) {
            double distance = GetDistance(Target);
            double direction = GetDirection(Target);
            double num1 = distance*Math.Cos(Direction-direction);
            double num2 = distance*Math.Sin(Direction-direction);
            double num3 = TxtureObject.Width*(double)ScaleWidth*0.5;
            double num4 = TxtureObject.Height*(double)ScaleLength*0.5;
            return num2*num2/num4/num4+(num1-256.0+64.0-TxtureObject.Height*(double)ScaleLength/2.0)*(num1-256.0+64.0-TxtureObject.Height*(double)ScaleLength/2.0)/num3/num3<1.0;
        }
        public override void Show() {
            int num1 = TimeMain%8*8;
            SizeF sizeF = new SizeF((TxtureObject.Width-64)*ScaleWidth,TxtureObject.Height*ScaleLength);
            MySprite spriteMain = SpriteMain;
            Texture txTure = TxtureObject.TXTure;
            Rectangle posRect = TxtureObject.PosRect;
            int x = posRect.X+64-num1;
            posRect=TxtureObject.PosRect;
            int y = posRect.Y;
            posRect=TxtureObject.PosRect;
            int width = posRect.Width-64;
            posRect=TxtureObject.PosRect;
            int height = posRect.Height;
            Rectangle srcRectangle = new Rectangle(x,y,width,height);
            SizeF destinationSize = sizeF;
            PointF rotationCenter = new PointF((TxtureObject.Width-64)/2,TxtureObject.Height/2);
            double num2 = Direction-Math.PI/2.0+Angle;
            PointF position = Position;
            Color color = Color.FromArgb(TransparentValue,ColorValue);
            spriteMain.Draw2D(txTure,srcRectangle,destinationSize,rotationCenter,(float)num2,position,color);
        }
        public override void ShowRegion() => SpriteMain.Draw2D(TextureObjectDictionary["Region"],(TxtureObject.Width-64)*1f/TextureObjectDictionary["Region"].Width*ScaleWidth,TxtureObject.Height*1f/TextureObjectDictionary["Region"].Height*ScaleLength,(float)(Direction-Math.PI/2.0+Angle),Position,Color.White,Mirrored);
    }
}
