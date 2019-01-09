using System.Drawing;

namespace Shooting {
    public class MyBullet_MarisaSub:BaseMyBullet_Touhou {
        public MyBullet_MarisaSub(StageDataPackage StageData,PointF p) : base(StageData,"MarisaMisile10",p,4f,-1.57079637050629) {
            Damage=5;
            Region=15;
            Accelerate=0.5f;
        }
        public override void GiveEndEffect() {
            Emitter2 emitter2 = new Emitter2(StageData,Position);
            ParticleEndAyaBullet particleEndAyaBullet = new ParticleEndAyaBullet(StageData,"MarisaMisile",OriginalPosition,3f,Direction);
        }
    }
}
