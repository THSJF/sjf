using System.Drawing;

namespace Shooting {
    internal class FullPic3:BaseObject {
        public FullPic3(StageDataPackage StageData,string textureName) {
            this.StageData=StageData;
            Rectangle boundRect = BoundRect;
            int left = boundRect.Left;
            boundRect=BoundRect;
            int num1 = boundRect.Width/2;
            double num2 = left+num1;
            boundRect=BoundRect;
            double num3 = boundRect.Bottom+100;
            Position=new PointF((float)num2,(float)num3);
            Velocity=9f;
            DirectionDegree=-90.0;
            Active=false;
            LifeTime=200;
            Accelerate=-0.2f;
            AccelerateDictionary.Add(90,0.1f);
            TransparentVelocityDictionary.Add(90,-10f);
            AngleWithDirection=false;
            AngleDegree=90.0;
            TxtureObject=TextureObjectDictionary[textureName];
            Background2.BackgroundList.Add(this);
            OutsideRegion=500;
        }
        public override void Ctrl() {
            base.Ctrl();
            if(Velocity>=1.20000004768372) return;
            Velocity=1.2f;
        }
    }
}
