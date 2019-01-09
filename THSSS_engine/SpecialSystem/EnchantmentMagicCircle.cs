using System;
using System.Drawing;

namespace Shooting {
    public class EnchantmentMagicCircle:BaseEffect {
        public EnchantmentMagicCircle(StageDataPackage StageData,PointF OriginalPosition) : base(StageData,null,new Point(0,0),0.0f,Math.PI/2.0) {
            this.OriginalPosition=OriginalPosition;
            switch(MyPlane.EnchantmentState) {
                case EnchantmentType.Red:
                    TxtureObject=TextureObjectDictionary["MC-R"];
                    break;
                case EnchantmentType.Blue:
                    TxtureObject=TextureObjectDictionary["MC-B"];
                    break;
                case EnchantmentType.Green:
                    TxtureObject=TextureObjectDictionary["MC-G"];
                    break;
            }
            LifeTime=MyPlane.EnchantmentTime;
            TransparentValueF=0.0f;
            TransparentVelocity=20f;
            MaxTransparent=160;
            AngularVelocityDegree=5f;
            Active=true;
        }
        public override bool OutBoundary() {
            if(LifeTime!=0&&Time>LifeTime) return true;
            return MyPlane.EnchantmentState==EnchantmentType.None;
        }
        public override void Ctrl() {
            base.Ctrl();
            OriginalPosition=MyPlane.OriginalPosition;
            Scale=(float)(0.200000002980232+MyPlane.EnchantmentTime*1.5/LifeTime);
        }
    }
}
