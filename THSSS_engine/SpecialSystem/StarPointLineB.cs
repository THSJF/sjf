using System.Drawing;

namespace Shooting {
    public class StarPointLineB:StarPointLineG {
        public StarPointLineB(StageDataPackage StageData,PointF OriginalPosition) : base(StageData,OriginalPosition) => type="A";
        public override void Ctrl() {
            base.Ctrl();
            DestPoint=new PointF(MyPlane.LastColor==EnchantmentType.Blue&&Story==null ? 66f : -6f,404f);
            Velocity=3f;
        }
    }
}
