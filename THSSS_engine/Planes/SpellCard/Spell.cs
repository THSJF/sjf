using System;
using System.Drawing;

namespace Shooting {
    public class Spell:BaseSpell {
        public Spell(StageDataPackage StageData) {
            this.StageData=StageData;
            Position=MyPlane.Position;
            Damage=10;
            LifeTime=300;
            SpellList.Add(this);
            StageData.VibrateStart(LifeTime);
            BackgroundBlack backgroundBlack = new BackgroundBlack(StageData,Position);
        }
        public override void Move() => Position=MyPlane.Position;

        public override bool HitCheck(BaseObject Enemy) {
            PointF position1 = Enemy.Position;
            double y = position1.Y;
            position1=Position;
            double num1 = position1.Y+5.0;
            int num2;
            if(y<num1) {
                PointF position2 = Position;
                double num3 = position2.X-140.0;
                position2=Enemy.Position;
                double x1 = position2.X;
                if(num3<x1) {
                    position2=Enemy.Position;
                    double x2 = position2.X;
                    position2=Position;
                    double num4 = position2.X+140.0;
                    num2=x2>=num4 ? 1 : 0;
                    goto label_4;
                }
            }
            num2=1;
            label_4:
            return num2==0;
        }
        public override void Ctrl() {
            base.Ctrl();
            if(Time%4==0) {
                int num1 = 20;
                float num2 = 2f;
                for(int index = 0;index<num1;++index) {
                    ParticleColored particleColored = new ParticleColored(StageData,"光点",new PointF(Position.X-num1+2*index,Position.Y-20f),20f,-1.0*Math.PI/2.0-num2/2.0+index/(double)num1*num2);
                }
            }
            if(MyPlane.Position.Y>=(double)BoundRect.Bottom) return;
            BaseMyPlane myPlane = MyPlane;
            PointF position = MyPlane.Position;
            double x = position.X;
            position=MyPlane.Position;
            double num = position.Y+2.0;
            PointF pointF = new PointF((float)x,(float)num);
            myPlane.Position=pointF;
        }
        public override void Show() {
        }
    }
}
