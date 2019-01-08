using System.Drawing;

namespace Shooting {
    public class StarPointLineR:StarPointLineG {
        public StarPointLineR(StageDataPackage StageData,PointF OriginalPosition) : base(StageData,OriginalPosition) => type="B";
        public override void Ctrl() {
            base.Ctrl();
            DestPoint=new PointF(MyPlane.LastColor==EnchantmentType.Red&&Story==null ? 66f : -6f,404f);
            Velocity=3f;
        }
    }
}
