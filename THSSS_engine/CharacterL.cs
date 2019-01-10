using System.Drawing;

namespace Shooting {
    internal class CharacterL:CharacterR {
        public CharacterL(StageDataPackage StageData,string textureName) : base(StageData,textureName) {
            Rectangle boundRect = BoundRect;
            double num1 = (boundRect.Left+100);
            boundRect=BoundRect;
            double num2 = (boundRect.Top+200);
            Position=new PointF((float)num1,(float)num2);
        }
        public override void Move() {
            if(Active) {
                if(OriginalPosition.X>=150.0) return;
                PointF originalPosition = OriginalPosition;
                double num = originalPosition.X+2.0;
                originalPosition=OriginalPosition;
                double y = originalPosition.Y;
                OriginalPosition=new PointF((float)num,(float)y);
            } else if(OriginalPosition.X>100.0) {
                PointF originalPosition = OriginalPosition;
                double num = originalPosition.X-2.0;
                originalPosition=OriginalPosition;
                double y = originalPosition.Y;
                OriginalPosition=new PointF((float)num,(float)y);
            }
        }
    }
}
