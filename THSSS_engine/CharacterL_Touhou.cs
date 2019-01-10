using System.Drawing;

namespace Shooting {
    internal class CharacterL_Touhou:CharacterR_Touhou {
        public CharacterL_Touhou(StageDataPackage StageData,string textureName) : base(StageData,textureName) => OriginalPosition=new PointF(70f,128f);
        public override void Move() {
            if(Active) {
                if(OriginalPosition.X>=100.0) return;
                PointF originalPosition = OriginalPosition;
                double num = originalPosition.X+2.0;
                originalPosition=OriginalPosition;
                double y = originalPosition.Y;
                OriginalPosition=new PointF((float)num,(float)y);
            } else if(OriginalPosition.X>70.0) {
                PointF originalPosition = OriginalPosition;
                double num = originalPosition.X-2.0;
                originalPosition=OriginalPosition;
                double y = originalPosition.Y;
                OriginalPosition=new PointF((float)num,(float)y);
            }
        }
    }
}
