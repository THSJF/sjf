using System;
using System.Drawing;

namespace Shooting {
    internal class CG:BaseStoryItem {
        public CG(StageDataPackage StageData,string textureName) : base(StageData) {
            Rectangle boundRect = BoundRect;
            double num1 = (boundRect.Width/2);
            boundRect=BoundRect;
            double num2 = (boundRect.Height/2);
            OriginalPosition=new PointF((float)num1,(float)num2);
            Velocity=0.0f;
            Direction=0.0;
            Active=false;
            TransparentValueF=0.0f;
            TransparentVelocity=20f;
            Angle=-(Direction-Math.PI/2.0);
        }
    }
}
