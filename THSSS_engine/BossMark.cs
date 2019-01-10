using System;
using System.Drawing;

namespace Shooting {
    public class BossMark:BaseObject {
        public BossMark(StageDataPackage StageData) {
            this.StageData=StageData;
            TxtureObject=TextureObjectDictionary[nameof(BossMark)];
            Rectangle boundRect = BoundRect;
            int left = boundRect.Left;
            boundRect=BoundRect;
            int num = boundRect.Width/2;
            Position=new PointF(left+num,472f);
            AngleDegree=90.0;
        }
        public override void Ctrl() {
            ++Time;
            if(Boss==null) return;
            OriginalPosition=new PointF(Boss.OriginalPosition.X+BoundRect.X,472f);
            TransparentValueF=150+(int)(100.0*Math.Sin(Time*Math.PI*2.0/60.0));
        }
        public override void Show() {
            if(Boss==null||TxtureObject==null) return;
            SpriteMain.Draw2D(TxtureObject,ScaleWidth,ScaleLength,(float)(Direction-Math.PI/2.0+Angle),OriginalPosition,Color.FromArgb(TransparentValue,ColorValue),Mirrored);
        }
    }
}
