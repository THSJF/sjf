using System;
using System.Drawing;

namespace Shooting {
    internal class FullPic:BaseObject {
        public FullPic(StageDataPackage StageData,string textureName) {
            this.StageData=StageData;
            Rectangle boundRect = BoundRect;
            double num1 = boundRect.Left+250;
            boundRect=BoundRect;
            double num2 = boundRect.Top+150;
            Position=new PointF((float)num1,(float)num2);
            Velocity=2f;
            Direction=Math.PI/2.0;
            Active=false;
            LifeTime=200;
            Accelerate=-0.025f;
            TxtureObject=TextureObjectDictionary[textureName];
            Background2.BackgroundList.Add(this);
        }
        public override void Ctrl() {
            base.Ctrl();
            if(Velocity<0.0) Velocity=0.0f;
            if(Time<=40) return;
            TransparentVelocity=-5f;
        }
    }
}
