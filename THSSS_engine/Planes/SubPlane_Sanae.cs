using System;
using System.Drawing;

namespace Shooting {
    public class SubPlane_Sanae:BaseSubPlane {
        public SubPlane_Sanae(StageDataPackage StageData,PointF Position) : base(StageData,"SanaeSubPlane",Position) => AngleDegree=90.0;
        public override void Ctrl() {
            base.Ctrl();
            Scale=(float)(1.0+0.100000001490116*Math.Sin(TimeMain/40.0*2.0*Math.PI));
        }
        public override void Shoot() {
            if(KClass.Key_Shift) {
                BaseMyBullet_Touhou baseMyBulletTouhou1 = new BaseMyBullet_Touhou(StageData,"SanaeSubBullet02",OriginalPosition,40f,ShootDirection-0.0299999993294477) {
                    Angle=1.57079637050629,
                    Damage=3
                };
                BaseMyBullet_Touhou baseMyBulletTouhou2 = new BaseMyBullet_Touhou(StageData,"SanaeSubBullet02",OriginalPosition,40f,ShootDirection+0.0299999993294477) {
                    Angle=1.57079637050629,
                    Damage=3
                };
            } else {
                BaseMyBullet_Touhou baseMyBulletTouhou1 = new BaseMyBullet_Touhou(StageData,"SanaeSubBullet00",OriginalPosition,30f,ShootDirection-0.150000005960464) {
                    Angle=3.14159274101257,
                    Damage=7,
                    Mirrored=Mirrored
                };
                BaseMyBullet_Touhou baseMyBulletTouhou2 = new BaseMyBullet_Touhou(StageData,"SanaeSubBullet00",OriginalPosition,30f,ShootDirection+0.150000005960464) {
                    Angle=3.14159274101257,
                    Damage=7,
                    Mirrored=Mirrored
                };
                BaseMyBullet_Touhou baseMyBulletTouhou3 = new BaseMyBullet_Touhou(StageData,"SanaeSubBullet00",OriginalPosition,30f,ShootDirection) {
                    Angle=3.14159274101257,
                    Damage=7,
                    Mirrored=Mirrored
                };
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
