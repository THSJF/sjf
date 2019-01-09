using System;
using System.Drawing;

namespace Shooting {
    public class SubPlane_PlaneB:BaseSubPlane {
        public SubPlane_PlaneB(StageDataPackage StageData,PointF Position) : base(StageData,"MySubPlane",Position) => ShootDirection=-1.0*Math.PI/2.0;
        public override void Shoot() {
            BaseMyBullet_Touhou baseMyBulletTouhou = new BaseMyBullet_Touhou(StageData,"子机子弹",OriginalPosition,4f,ShootDirection) {
                Angle=3.14159274101257,
                Damage=5,
                Accelerate=0.5f
            };
        }
    }
}
