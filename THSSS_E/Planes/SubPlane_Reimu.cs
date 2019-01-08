using System;
using System.Drawing;

namespace Shooting {
    public class SubPlane_Reimu:BaseSubPlane {
        public SubPlane_Reimu(StageDataPackage StageData,PointF Position) : base(StageData,"ReimuSubPlane",Position) {
        }
        public override void Ctrl() {
            base.Ctrl();
            TransparentVelocity=KClass.Key_Shift ? -20f : 20f;
        }
        public override void Shoot() {
            if(KClass.Key_Shift) {
                BaseMyBullet_Touhou baseMyBulletTouhou1 = new BaseMyBullet_Touhou(StageData,"MaruBullet",OriginalPosition,18f,ShootDirection+Math.PI/60.0) {
                    Angle=1.57079637050629,
                    Damage=5
                };
                BaseMyBullet_Touhou baseMyBulletTouhou2 = new BaseMyBullet_Touhou(StageData,"MaruBullet",OriginalPosition,18f,ShootDirection-Math.PI/60.0) {
                    Angle=1.57079637050629,
                    Damage=5
                };
            } else {
                BulletGuidance bulletGuidance = new BulletGuidance(StageData,"ReimuSubBullet",Position,8f,ShootDirection) {
                    TransparentValueF=180f,
                    Angle=1.57079637050629,
                    Damage=9
                };
            }
        }
        public override void Show() {
            if(!Enabled||TxtureObject==null) return;
            double num = -Time*5%360*Math.PI/180.0;
            if(MyPlane.Power>=400) {
                SpriteMain.Draw2D(TxtureObject,1.3f,1.3f,-(float)num,Position,Color.FromArgb(TransparentValue*6/10,ColorValue),this.Mirrored);
            }
            SpriteMain.Draw2D(TxtureObject,ScaleWidth,ScaleLength,(float)num,Position,Color.FromArgb(TransparentValue,ColorValue),Mirrored);
        }
    }
}
