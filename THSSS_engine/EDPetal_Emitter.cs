using System;
using System.Drawing;

namespace Shooting {
    public class EDPetal_Emitter:BaseEffect {
        private string EDText;
        public int Hold { get; set; }
        public EDPetal_Emitter(StageDataPackage StageData,PointF OriginalPosition,string EDText) : base(StageData,null,new Point(0,0),0.0f,Math.PI/2.0) {
            this.OriginalPosition=OriginalPosition;
            LifeTime=130;
            this.EDText=EDText;
        }
        public override void Shoot() {
            if(Time==10) {
                BaseEffect baseEffect = new BaseEffect(StageData,EDText,OriginalPosition,0.0f,0.0) {
                    Scale=Scale,
                    Direction=Math.PI/2.0,
                    OriginalPosition=OriginalPosition,
                    Active=false,
                    TransparentValueF=0.0f,
                    TransparentVelocity=10f,
                    LifeTime=322+Hold
                };
                baseEffect.TransparentVelocityDictionary.Add(300+Hold,-12f);
            }
            for(int index = 0;index<5;++index) {
                if(Time==1+index*3)
                    new EDPetal(StageData,"ED_Petal",OriginalPosition,0.0f,0.0) {
                        DestAngleDegree=72*index
                    }.LifeTime=300+Hold;
            }
        }
    }
}
