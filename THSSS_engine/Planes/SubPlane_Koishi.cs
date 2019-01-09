using System;
using System.Drawing;

namespace Shooting {
    public class SubPlane_Koishi:BaseSubPlane {
        public SubPlane_Koishi(StageDataPackage StageData,PointF Position) : base(StageData,"KoishiSubPlane01",Position) => AngleDegree=90.0;
        public override void Ctrl() {
            base.Ctrl();
            Scale=(float)(1.0+0.100000001490116*Math.Sin(TimeMain/40.0*2.0*Math.PI));
            TxtureObject=TextureObjectDictionary[KClass.Key_Shift ? "KoishiSubPlane00" : "KoishiSubPlane01"];
        }
        public override void Shoot() {
            if(KClass.Key_Shift) {
                int num1 = 5;
                double num2 = 24.0*Math.PI/180.0/(num1-1);
                double Direction = ShootDirection-(num1-1)*num2/2.0;
                for(int index = 0;index<num1;++index) {
                    BaseMyBullet_Touhou baseMyBulletTouhou = new BaseMyBullet_Touhou(StageData,"KoishiSubBullet00",OriginalPosition,15f,Direction) {
                        Angle=1.57079637050629,
                        Damage=6
                    };
                    Direction+=num2;
                }
            } else {
                int num1 = 15;
                double num2 = 120.0*Math.PI/180.0/(num1-1);
                double Direction = ShootDirection-(num1-1)*num2/2.0;
                for(int index = 0;index<num1;++index) {
                    BaseMyBullet_Touhou baseMyBulletTouhou = new BaseMyBullet_Touhou(StageData,"KoishiSubBullet01",OriginalPosition,8f,Direction) {
                        Angle=1.57079637050629,
                        Damage=15
                    };
                    Direction+=num2;
                }
            }
        }
        public override void Show() {
            if(!Enabled) return;
            if(MyPlane.Power>=400) {
                float scale = Scale;
                float transparentValueF = TransparentValueF;
                Scale=1.3f;
                TransparentValueF=150f;
                base.Show();
                TransparentValueF=transparentValueF;
                Scale=scale;
            }
            base.Show();
        }
    }
}
