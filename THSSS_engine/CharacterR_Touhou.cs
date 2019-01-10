using System;
using System.Drawing;

namespace Shooting {
    internal class CharacterR_Touhou:BaseStoryItem {
        public TextureObject TxtureObject2 { get; set; }
        public CharacterR_Touhou(StageDataPackage StageData,string textureName) : base(StageData) {
            OriginalPosition=new PointF(BoundRect.Width-70,128f);
            Velocity=0.0f;
            Direction=0.0;
            TxtureObject=TextureObjectDictionary[textureName];
            Active=false;
            TransparentValueF=0.0f;
        }
        public override void Move() {
            if(Active) {
                if((double)OriginalPosition.X<=BoundRect.Width-100) return;
                PointF originalPosition = OriginalPosition;
                double num = originalPosition.X-2.0;
                originalPosition=OriginalPosition;
                double y = originalPosition.Y;
                OriginalPosition=new PointF((float)num,(float)y);
            } else if((double)OriginalPosition.X<BoundRect.Width-70) {
                PointF originalPosition = OriginalPosition;
                double num = originalPosition.X+2.0;
                originalPosition=OriginalPosition;
                double y = originalPosition.Y;
                OriginalPosition=new PointF((float)num,(float)y);
            }
        }
        public override void Ctrl() {
            base.Ctrl();
            Angle=-(Direction-Math.PI/2.0);
            if(Active) {
                TransparentValueF+=10f;
                ColorValue=Color.White;
            } else {
                ColorValue=Color.Gray;
            }
        }
        public override void Show() {
            if(TxtureObject2!=null) SpriteMain.Draw2D(TxtureObject2,ScaleWidth,ScaleLength,(float)(Direction-Math.PI/2.0+Angle),Position,Color.FromArgb(TransparentValue,ColorValue),Mirrored);
            base.Show();
        }
    }
}
