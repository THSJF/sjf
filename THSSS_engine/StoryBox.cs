using SlimDX.Direct3D9;
using System.Drawing;

namespace Shooting {
    internal class StoryBox:BaseStoryItem {
        private string text;
        private Texture StringTexture;
        private System.Drawing.Font sysfont;
        private char[] TextArray;
        private string text2;
        private Texture StringTexture2;
        public Color FontColor2 = new Color();
        public string DrawText2;
        private char[] TextArray2;
        private SlimDX.Direct3D9.Font DXfont { get; set; }
        public Color FontColor { get; set; }
        public int OffsetX { get; set; }
        public int OffsetY { get; set; }
        public bool Shadowed { get; set; }
        public string DrawText { get; set; }
        public string Text {
            get => text;
            set {
                if(!(value!=text)) return;
                text=value;
                TextArray=text.ToCharArray();
                DrawText="";
                Time=0;
            }
        }
        public string Text2 {
            get => text2;
            set {
                if(!(value!=text2)) return;
                text2=value;
                TextArray2=text2.ToCharArray();
                DrawText2="";
                Time=0;
            }
        }
        public StoryBox(StageDataPackage StageData) : base(StageData) {
            TxtureObject=TextureObjectDictionary["对话框"];
            Rectangle boundRect = BoundRect;
            double left = boundRect.Left;
            boundRect=BoundRect;
            int bottom = boundRect.Bottom;
            int height = TxtureObject.Height;
            boundRect=BoundRect;
            int width = boundRect.Width;
            int num1 = height*width/TxtureObject.Width;
            double num2 = bottom-num1-8;
            Position=new PointF((float)left,(float)num2);
            Velocity=0.0f;
            Direction=0.0;
            TransparentValueF=0.0f;
            TransparentVelocity=10f;
            OffsetX=20;
            OffsetY=21;
            Shadowed=true;
            sysfont=new System.Drawing.Font(StageData.GlobalData.FontType,1536f/Dpi.PixelsPerXLogicalInch,FontStyle.Bold);
            DXfont=new SlimDX.Direct3D9.Font(StageData.DeviceMain,sysfont);
            FontColor=Color.White;
        }
        public override void Ctrl() {
            if(DrawText!=null&&DrawText.Replace("\r\n","")==text) {
                TransparentValueF=MaxTransparent;
            } else {
                if(TextArray!=null&&Time<TextArray.Length) {
                    if(DXfont.MeasureString(SpriteMain.sprite,DrawText+TextArray[Time].ToString(),DrawTextFormat.Left).Width/1.14999997615814>(double)(TxtureObject.Width-OffsetX))
                        DrawText+="\r\n";
                    DrawText+=TextArray[Time].ToString();
                }
                if(StringTexture!=null) StringTexture.Dispose();
                StringTexture=StageData.DrawString(DrawText,sysfont,Brushes.White,512,256);
                if(TextArray2!=null&&Time<TextArray2.Length) {
                    if(DXfont.MeasureString(SpriteMain.sprite,DrawText2+TextArray2[Time].ToString(),DrawTextFormat.Left).Width/1.14999997615814>(double)(TxtureObject.Width-OffsetX))
                        DrawText2+="\r\n";
                    DrawText2+=TextArray2[Time].ToString();
                }
                if(StringTexture2!=null)
                    StringTexture2.Dispose();
                StringTexture2=StageData.DrawString(DrawText2,sysfont,Brushes.White,512,256);
                base.Ctrl();
            }
        }
        public void DrawFullText() {
            StoryBox storyBox1;
            if(TextArray!=null) {
                for(;Time<TextArray.Length;++storyBox1.Time) {
                    if(DXfont.MeasureString(SpriteMain.sprite,DrawText+TextArray[Time].ToString(),DrawTextFormat.Left).Width/1.14999997615814>(double)(TxtureObject.Width-OffsetX))
                        DrawText+="\r\n";
                    DrawText+=TextArray[Time].ToString();
                    storyBox1=this;
                }
            }
            if(StringTexture!=null) StringTexture.Dispose();
            StringTexture=StageData.DrawString(DrawText,sysfont,Brushes.White,512,256);
            StoryBox storyBox2;
            if(TextArray2!=null) {
                for(;Time<TextArray2.Length;++storyBox2.Time) {
                    if(DXfont.MeasureString(SpriteMain.sprite,DrawText2+TextArray2[Time].ToString(),DrawTextFormat.Left).Width/1.14999997615814>(double)(TxtureObject.Width-OffsetX))
                        DrawText2+="\r\n";
                    DrawText2+=TextArray2[Time].ToString();
                    storyBox2=this;
                }
            }
            if(StringTexture2!=null) StringTexture2.Dispose();
            StringTexture2=StageData.DrawString(DrawText2,sysfont,Brushes.White,512,256);
        }
        public void SetFont(float FontSize) {
            if(sysfont==null) return;
            FontSize=FontSize*96f/Dpi.PixelsPerXLogicalInch;
            if((double)sysfont.Size==FontSize) return;
            sysfont=new System.Drawing.Font(StageData.GlobalData.FontType,FontSize,FontStyle.Bold);
            DXfont=new SlimDX.Direct3D9.Font(StageData.DeviceMain,sysfont);
        }
        public override void Show() {
            SizeF destinationSize1 = new SizeF(TxtureObject.Width,116f);
            SpriteMain.Draw2D(TxtureObject.TXTure,TxtureObject.PosRect,destinationSize1,TxtureObject.LeftTop,0.0f,Position,Color.FromArgb(TransparentValue,Color.White));
            if(Text==null||StringTexture==null) return;
            PointF position1;
            if(Shadowed) {
                MySprite spriteMain = SpriteMain;
                Texture stringTexture = StringTexture;
                Rectangle srcRectangle = new Rectangle(0,0,512,256);
                SizeF destinationSize2 = new SizeF(512f,256f);
                position1=Position;
                double num1 = (int)position1.X+2+OffsetX;
                position1=Position;
                double num2 = (int)position1.Y+2+(int)(OffsetY*(double)destinationSize1.Height/90.0);
                PointF position2 = new PointF((float)num1,(float)num2);
                Color color = Color.FromArgb(150,0,0,0);
                spriteMain.Draw2D(stringTexture,srcRectangle,destinationSize2,position2,color);
            }
            MySprite spriteMain1 = SpriteMain;
            Texture stringTexture1 = StringTexture;
            Rectangle srcRectangle1 = new Rectangle(0,0,512,256);
            SizeF destinationSize3 = new SizeF(512f,256f);
            position1=Position;
            double num3 = (int)position1.X+OffsetX;
            position1=Position;
            double num4 = (int)position1.Y+(int)(OffsetY*(double)destinationSize1.Height/90.0);
            PointF position3 = new PointF((float)num3,(float)num4);
            Color fontColor = FontColor;
            spriteMain1.Draw2D(stringTexture1,srcRectangle1,destinationSize3,position3,fontColor);
            if(StringTexture2==null) return;
            MySprite spriteMain2 = SpriteMain;
            Texture stringTexture2 = StringTexture2;
            Rectangle srcRectangle2 = new Rectangle(0,0,512,256);
            SizeF destinationSize4 = new SizeF(512f,256f);
            position1=Position;
            double num5 = (int)position1.X+OffsetX;
            position1=Position;
            double num6 = (int)position1.Y+(int)(OffsetY*(double)destinationSize1.Height/90.0);
            PointF position4 = new PointF((float)num5,(float)num6);
            Color fontColor2 = FontColor2;
            spriteMain2.Draw2D(stringTexture2,srcRectangle2,destinationSize4,position4,fontColor2);
        }
        public override void Dispose() {
            DXfont.Dispose();
            if(StringTexture==null) return;
            StringTexture.Dispose();
        }
    }
}
