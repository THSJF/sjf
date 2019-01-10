using System;
using System.Drawing;

namespace Shooting {
    internal class PlaneSpark:BaseEffect {
        public PlaneSpark(StageDataPackage StageData,string textureName,PointF OriginalPosition,float Velocity,double Direction) : base(StageData,textureName,OriginalPosition,Velocity,Direction) {
            this.OriginalPosition=OriginalPosition;
            ScaleWidth=0.05f;
            Active=true;
            LifeTime=300;
            ColorValue=Color.FromArgb(85,140,byte.MaxValue);
            UnRemoveable=true;
            Angle=0.0;
            ScaleVL=0.1f;
            ScaleVW=0.1f;
        }
        public override void Ctrl() {
            base.Ctrl();
            Region=(int)(TxtureObject.Width/2.0*0.699999988079071);
            if(Time<LifeTime-50) {
                TransparentValueF=150+Ran.Next(40);
            } else {
                TransparentValueF=(LifeTime-Time)*2-20+Ran.Next(40);
            }
        }
        public override void Show() {
            if(TxtureObject==null) return;
            SpriteMain.Draw2D(TxtureObject.TXTure,TxtureObject.PosRect,new SizeF(TxtureObject.Width*ScaleWidth,TxtureObject.Height*ScaleLength),new PointF(TxtureObject.Width/2,0.0f),(float)(Direction-Math.PI/2.0+Angle),Position,Color.FromArgb(TransparentValue,ColorValue));
        }
    }
}
