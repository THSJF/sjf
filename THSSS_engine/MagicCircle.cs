using System;
using System.Drawing;

namespace Shooting {
    internal class MagicCircle:BaseEffect {
        public MagicCircle(StageDataPackage StageData,string textureName) : base(StageData,textureName,new PointF(0.0f,0.0f),0.0f,0.0) { }
        public override void Move() {
            if(Boss==null) return;
            OriginalPosition=Boss.OriginalPosition;
        }
        public override void Ctrl() {
            base.Ctrl();
            Angle+=0.0199999995529652;
            Scale+=(float)Math.Sin(Time*3.0/180.0*Math.PI)/80f;
            TransparentValueF=100+(int)(Math.Sin(Time*2.0/180.0*Math.PI)*75.0);
        }
        public override bool OutBoundary() => Boss==null;
    }
}
