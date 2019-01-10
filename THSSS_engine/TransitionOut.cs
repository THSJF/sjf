using System.Drawing;

namespace Shooting {
    public class TransitionOut:BaseObject {
        public TransitionOut(StageDataPackage StageData) {
            this.StageData=StageData;
            TxtureObject=TextureObjectDictionary["MenuBackground"];
            OriginalPosition=new PointF(0.0f,0.0f);
            TransparentValueF=0.0f;
            StageData.InterfaceList.Add(this);
            LifeTime=byte.MaxValue;
        }
        public override void Ctrl() {
            base.Ctrl();
            TransparentValueF+=byte.MaxValue/LifeTime;
        }
        public override void Show() => SpriteMain.Draw2D(TxtureObject,1f,0.0f,OriginalPosition,TxtureObject.LeftTop,Color.FromArgb(TransparentValue,Color.Black));
    }
}
