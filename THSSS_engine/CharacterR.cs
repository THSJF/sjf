using System.Drawing;

namespace Shooting {
    internal class CharacterR:BaseStoryItem {
        public CharacterR(StageDataPackage StageData,string textureName) : base(StageData) {
            Rectangle boundRect = BoundRect;
            double num1 = boundRect.Right-100;
            boundRect=BoundRect;
            double num2 = boundRect.Top+200;
            Position=new PointF((float)num1,(float)num2);
            Velocity=0.0f;
            Direction=0.0;
            TxtureObject=TextureObjectDictionary[textureName];
            Active=false;
            TransparentValueF=0.0f;
        }
        public override void Move() {
            if(Active) {
                if((double)Position.X<=BoundRect.Right-130) return;
                PointF originalPosition = OriginalPosition;
                double num = originalPosition.X-2.0;
                originalPosition=OriginalPosition;
                double y = originalPosition.Y;
                OriginalPosition=new PointF((float)num,(float)y);
            } else if(Position.X<(double)(BoundRect.Right-100)) {
                PointF originalPosition = OriginalPosition;
                double num = originalPosition.X+2.0;
                originalPosition=OriginalPosition;
                double y = originalPosition.Y;
                OriginalPosition=new PointF((float)num,(float)y);
            }
        }
        public override void Ctrl() {
            base.Ctrl();
            if(Time<=1) {
                TransparentValueF=0.0f;
            } else {
                if(Time>=26) return;
                TransparentValueF+=10f;
            }
        }
        public override void Show() {
            SizeF destinationSize = new SizeF(TxtureObject.Width*Scale,TxtureObject.Height*Scale);
            SpriteMain.Draw2D(TxtureObject.TXTure,TxtureObject.PosRect,destinationSize,TxtureObject.RotatingCenter,0.0f,Position,Color.FromArgb(TransparentValue,Active ? Color.White : Color.Gray));
        }
    }
}
