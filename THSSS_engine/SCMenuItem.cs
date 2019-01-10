using System.Drawing;

namespace Shooting {
    public class SCMenuItem:DescriptionMenuItem {
        public int OffX = 50;
        public int OffY = -5;
        public SCMenuItem(StageDataPackage StageData,string Name) : base(StageData,Name) {
        }
        public override void Show() {
            base.Show();
            if(TxtureObject==null) return;
            MySprite spriteMain = SpriteMain;
            TextureObject txtureObject = TxtureObject;
            double scaleWidth = ScaleWidth;
            double scaleLength = ScaleLength;
            PointF position1 = Position;
            double num1 = position1.X+TxtureObject.Width*(double)Scale/2.0+OffX;
            position1=Position;
            double num2 = position1.Y+(double)OffY+TxtureObject.Height*(double)Scale/2.0;
            PointF position2 = new PointF((float)num1,(float)num2);
            Color color = Color.FromArgb(TransparentValue,ColorValue);
            int num3 = Mirrored ? 1 : 0;
            spriteMain.Draw2D(txtureObject,(float)scaleWidth,(float)scaleLength,0.0f,position2,color,num3!=0);
        }
    }
}
