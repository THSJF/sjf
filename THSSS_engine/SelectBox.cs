using SlimDX.Direct3D9;
using System.Drawing;

namespace Shooting {
    internal class SelectBox:BaseEffect {
        public SelectBox(StageDataPackage StageData) : base(StageData) {
            TxtureObject=TextureObjectDictionary["selectframe2"];
        }
        public override void Show() {
            MySprite spriteMain = SpriteMain;
            Texture txTure = TxtureObject.TXTure;
            PointF originalPosition1 = OriginalPosition;
            int x = (int)originalPosition1.X;
            originalPosition1=OriginalPosition;
            int y = (int)originalPosition1.Y;
            Rectangle srcRectangle = new Rectangle(x,y,512,22);
            SizeF destinationSize = new SizeF(512f,22f);
            PointF rotationCenter = new PointF(0.0f,0.0f);
            PointF originalPosition2 = OriginalPosition;
            Color white = Color.White;
            spriteMain.Draw2D(txTure,srcRectangle,destinationSize,rotationCenter,0.0f,originalPosition2,white);
        }
    }
}
