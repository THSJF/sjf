using System.Drawing;

namespace Shooting {
    internal class EnchantmentBonus:BaseEffect {
        private int Index = 0;
        private PointF ValuePoint;
        private char[] BonusCharArray { get; set; }
        public EnchantmentBonus(StageDataPackage StageData,long Bonus) : base(StageData) {
            Layer=1;
            LifeTime=150;
            MyPlane.Score+=Bonus;
            TransparentVelocity=100f;
            TransparentValueF=0.0f;
            OriginalPosition=new PointF(BoundRect.Width/2,120f);
            AngleDegree=90.0;
            BonusCharArray=Bonus.ToString().ToCharArray();
            int num = 0;
            for(int index = 0;index<BonusCharArray.Length;++index) {
                num+=TextureObjectDictionary["Num"+BonusCharArray[index].ToString()].Width;
            }
            ValuePoint=new PointF(OriginalPosition.X-num/2,OriginalPosition.Y+40f);
        }
        public override void Ctrl() {
            base.Ctrl();
            if(Time==100) TransparentVelocity=-10f;
            if(Time<20||Time%4!=0||Index>=BonusCharArray.Length) return;
            ValuePoint=new PointF(ValuePoint.X+TextureObjectDictionary["Num"+BonusCharArray[Index].ToString()].Width/2,ValuePoint.Y);
            new ParticleBonusNum(StageData,"Num"+BonusCharArray[Index].ToString(),ValuePoint).ColorValue=Color.FromArgb(byte.MaxValue-Index*10,byte.MaxValue-Index*5,byte.MaxValue-Index*10);
            ValuePoint=new PointF(ValuePoint.X+TextureObjectDictionary["Num"+BonusCharArray[Index].ToString()].Width/2,ValuePoint.Y);
            ++Index;
        }
    }
}
