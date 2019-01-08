using SlimDX.Direct3D9;
using System.Drawing;

namespace Shooting {
    public class StarPointLineG:BaseObject {
        protected string type;
        public StarPointLineG(StageDataPackage StageData,PointF OriginalPosition) {
            this.StageData=StageData;
            this.OriginalPosition=OriginalPosition;
            TransparentValueF=0.0f;
            TransparentVelocity=10f;
            type="C";
        }
        public override void Ctrl() {
            base.Ctrl();
            TransparentVelocity=MyPlane.OriginalPosition.X<100.0&&MyPlane.OriginalPosition.Y>(double)(BoundRect.Height-140) ? -10f : 10f;
            if(TransparentValue<50) TransparentValueF=50f;
            TxtureObject=TextureObjectDictionary["border"+type+"2"];
            DestPoint=new PointF(MyPlane.LastColor==EnchantmentType.Green&&Story==null ? 66f : -6f,404f);
            Velocity=3f;
        }
        public override void Show() {
            if(TxtureObject==null) return;
            SpriteMain.Draw2D(TextureObjectDictionary["border"+type+"1"],1f,0.0f,OriginalPosition,Color.FromArgb(TransparentValue,Color.White));
            int num1 = TxtureObject.Height*MyPlane.StarPoint/MyPlane.maxStarPoint;
            int height = num1>1 ? num1 : 1;
            Size size1 = new Size(TxtureObject.Width,height);
            Rectangle rectangle = new Rectangle();
            ref Rectangle local = ref rectangle;
            Rectangle posRect = TxtureObject.PosRect;
            int x1 = posRect.X;
            posRect=TxtureObject.PosRect;
            int y = posRect.Y+TxtureObject.Height-height;
            Point location = new Point(x1,y);
            Size size2 = size1;
            local=new Rectangle(location,size2);
            MySprite spriteMain = SpriteMain;
            Texture txTure = TxtureObject.TXTure;
            Rectangle srcRectangle = rectangle;
            SizeF destinationSize = size1;
            PointF rotatingCenter = TxtureObject.RotatingCenter;
            PointF originalPosition = OriginalPosition;
            double x2 = originalPosition.X;
            originalPosition=OriginalPosition;
            double num2 = originalPosition.Y+(double)TxtureObject.Height-height;
            PointF position = new PointF((float)x2,(float)num2);
            Color color = Color.FromArgb(TransparentValue*8/10,Color.White);
            spriteMain.Draw2D(txTure,srcRectangle,destinationSize,rotatingCenter,0.0f,position,color);
            SpriteMain.Draw2D(TextureObjectDictionary["border"+type+"0"],1f,0.0f,OriginalPosition,Color.FromArgb(TransparentValue,Color.White));
        }
    }
}
