﻿using System;
using System.Drawing;

namespace Shooting {
    public class DescriptionMenuItem:BaseMenuItem {
        public string Description { get; set; }
        public Color DefaultColor { get; set; }
        public DescriptionMenuItem(StageDataPackage StageData,string Name) {
            this.StageData=StageData;
            this.Name=Name;
            MaxVelocity=100f;
            Selected=false;
            UnSelectVisible=true;
            DefaultColor=Color.Gray;
        }
        public override void Ctrl() {
            if(!Enabled) return;
            ++Time;
            Move();
            Velocity+=Accelerate;
            TransparentValueF+=TransparentVelocity;
            if(Selected) {
                double num = 1.0+Math.Sin(Time/6.0);
                ColorValue=Color.Yellow;
                TransparentVelocity=25f;
            } else {
                ColorValue=DefaultColor;
                if(!UnSelectVisible) TransparentVelocity=-25f;
            }
            if(!OnRemove) return;
            MaxTransparent-=15;
        }
        public override void Select() {
            Time=1;
            Selected=true;
            VibrateTime=0;
            TwinkleTime=0;
        }
        public override void Click() {
            Time=1;
            VibrateTime=0;
            TwinkleTime=Time+30;
        }
        public void DrawText(string text,PointF Pos) {
            text=text.Replace("\t","    ");
            text=text.Replace("\r\n",string.Empty);
            int num = 0;
            char[] charArray = text.ToCharArray();
            for(int index = 0;index<charArray.Length;++index) {
                PointF position = new PointF(Pos.X+5f+num,Pos.Y+9f);
                if(TextureObjectDictionary.ContainsKey(charArray[index].ToString())) SpriteMain.Draw2D(TextureObjectDictionary[charArray[index].ToString()],1f,0.0f,position,Color.FromArgb(TransparentValue,ColorValue));
                num+=11;
                if(charArray[index]=='.') num-=6;
            }
        }
        public override void Show() => DrawText(Name+" "+Description,OriginalPosition);
    }
}
