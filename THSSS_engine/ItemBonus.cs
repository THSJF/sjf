using System;
using System.Drawing;

namespace Shooting {
    public class ItemBonus:BaseEffect {
        public ItemBonus(StageDataPackage StageData) : base(StageData,null,new Point(0,0),0.0f,Math.PI/2.0) {
            Rectangle boundRect = BoundRect;
            double num1 = boundRect.Width/2;
            boundRect=BoundRect;
            double num2 = boundRect.Height/2;
            OriginalPosition=new PointF((float)num1,(float)num2);
            LifeTime=72;
            TransparentValueF=0.0f;
            Accelerate=0.1f;
        }
        public override void Ctrl() {
            base.Ctrl();
            Direction=GetDirection(MyPlane);
        }
        public override void Shoot() {
            int num1 = 160-Time;
            int num2 = 10;
            for(int index = 0;index<num2;++index) {
                PointF OriginalPosition = new PointF();
                ref PointF local1 = ref OriginalPosition;
                PointF originalPosition = OriginalPosition;
                double num3 = originalPosition.X+num1*Math.Sin(Angle)+Ran.Next(-15,15);
                originalPosition=OriginalPosition;
                double num4 = originalPosition.Y+num1*Math.Cos(Angle)+Ran.Next(-15,15);
                local1=new PointF((float)num3,(float)num4);
                StarItem_Touhou starItemTouhou1 = new StarItem_Touhou(StageData,OriginalPosition);
                ref PointF local2 = ref OriginalPosition;
                originalPosition=OriginalPosition;
                double num5 = originalPosition.X-num1*Math.Sin(Angle)+Ran.Next(-15,15);
                originalPosition=OriginalPosition;
                double num6 = originalPosition.Y-num1*Math.Cos(Angle)+Ran.Next(-15,15);
                local2=new PointF((float)num5,(float)num6);
                StarItem_Touhou starItemTouhou2 = new StarItem_Touhou(StageData,OriginalPosition);
            }
            Angle+=0.300000011920929;
        }
    }
}
