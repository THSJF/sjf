using System;
using System.Drawing;

namespace Shooting {
    internal class ShootingStarShard:BaseItem_Touhou {
        public ShootingStarShard(StageDataPackage StageData,PointF OriginalPosition) : base(StageData,"StarShardBS",OriginalPosition) {
            Region=8;
            AngularVelocity=0.0f;
            DirectionDegree+=Ran.Next(-49,50)/10.0;
            TransparentValueF=0.0f;
            TransparentVelocity=16f;
            Active=true;
            ColorValue=Color.Blue;
        }

        public override void HitCheckAll() {
            if(HitCheck(MyPlane,48f)) {
                Obtain=true;
            } 
            if(!HitCheck(MyPlane)) {
                return;
            } 
            ItemList.Remove(this);
            if(ColorValue==Color.Red) {
                MyPlane.LastColor=EnchantmentType.Red;
            } else if(ColorValue==Color.Blue) {
                MyPlane.LastColor=EnchantmentType.Blue;
            } else if(ColorValue==Color.Green) {
                MyPlane.LastColor=EnchantmentType.Green;
            }

            MyPlane.StarPoint+=800;
            if(ColorValue==Color.Red) {
                ++MyPlane.LifeChip;
            } else if(ColorValue==Color.Blue) {
                MyPlane.HighItemScore+=5000;
            } else if(ColorValue==Color.Green) {
                ++MyPlane.SpellChip;
            }

            StageData.SoundPlay("se_item00.wav",OriginalPosition.X/(float)BoundRect.Width);
            for(int index = 0;index<50;++index) {
                ParticleSmaller particleSmaller = new ParticleSmaller(StageData,"光点",Position,Ran.Next(20,200)/10,Ran.Next(360)/180.0*Math.PI) {
                    LifeTime=20,
                    Scale=Ran.Next(100)/100f,
                    TransparentValueF=200f,
                    ColorValue=ColorValue
                };
            }
        }

        public override void Ctrl() {
            base.Ctrl();
            if(Time==200) {
                ColorValue=Color.Red;
                TxtureObject=TextureObjectDictionary["StarShardRS"];
            } else if(Time==300) {
                ColorValue=Color.Green;
                TxtureObject=TextureObjectDictionary["StarShardGS"];
            }
            GhostingColor=ColorValue;
            if(Time>40) {
                AngularVelocityDegree=3f;
                AngleDegree+=AngularVelocityDegree;
            }
            if(Time%4!=0) {
                return;
            }
            BaseEffect baseEffect = new BaseEffect(StageData,"StarShardW",Position,0.0f,0.0);
            baseEffect.Angle=Angle;
            baseEffect.ScaleVelocity=-0.0125f;
            baseEffect.TransparentVelocity=-3f;
            baseEffect.LifeTime=80;
            baseEffect.ColorValue=ColorValue;
        }

        public override void Show() {
            Color colorValue = ColorValue;
            ColorValue=Color.White;
            base.Show();
            ColorValue=colorValue;
        }
    }
}
