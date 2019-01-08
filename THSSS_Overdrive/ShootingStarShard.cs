// Decompiled with JetBrains decompiler
// Type: Shooting.ShootingStarShard
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting {
    internal class ShootingStarShard:BaseItem_Touhou {
        public ShootingStarShard(StageDataPackage StageData,PointF OriginalPosition)
          : base(StageData,"StarShardBS",OriginalPosition) {
            this.Region=8;
            this.AngularVelocity=0.0f;
            this.DirectionDegree+=(double)this.Ran.Next(-49,50)/10.0;
            this.TransparentValueF=0.0f;
            this.TransparentVelocity=16f;
            this.Active=true;
            this.ColorValue=Color.Blue;
        }

        public override void HitCheckAll() {
            if(this.HitCheck((BaseObject)this.MyPlane,48f))
                this.Obtain=true;
            if(!this.HitCheck((BaseObject)this.MyPlane))
                return;
            this.ItemList.Remove((BaseItem)this);
            if(this.ColorValue==Color.Red)
                this.MyPlane.LastColor=EnchantmentType.Red;
            else if(this.ColorValue==Color.Blue)
                this.MyPlane.LastColor=EnchantmentType.Blue;
            else if(this.ColorValue==Color.Green)
                this.MyPlane.LastColor=EnchantmentType.Green;

            if(StageData.Boss is Boss_Tensei01) {
                MyPlane.StarPoint+=800;
            } else {
                MyPlane.StarPoint+=2*800;
            }

            if(this.ColorValue==Color.Red)
                MyPlane.LifeChip+=2;
            else if(this.ColorValue==Color.Blue)
                this.MyPlane.HighItemScore+=1000;
            else if(this.ColorValue==Color.Green)
                MyPlane.SpellChip+=2;
            this.StageData.SoundPlay("se_item00.wav",this.OriginalPosition.X/(float)this.BoundRect.Width);
            for(int index = 0;index<50;++index) {
                ParticleSmaller particleSmaller = new ParticleSmaller(this.StageData,"光点",this.Position,(float)(this.Ran.Next(20,200)/10),(double)this.Ran.Next(360)/180.0*Math.PI);
                particleSmaller.LifeTime=20;
                particleSmaller.Scale=(float)this.Ran.Next(100)/100f;
                particleSmaller.TransparentValueF=200f;
                particleSmaller.ColorValue=this.ColorValue;
            }
        }

        public override void Ctrl() {
            base.Ctrl();
            if(this.Time==200) {
                this.ColorValue=Color.Red;
                this.TxtureObject=this.TextureObjectDictionary["StarShardRS"];
            } else if(this.Time==300) {
                this.ColorValue=Color.Green;
                this.TxtureObject=this.TextureObjectDictionary["StarShardGS"];
            }
            this.GhostingColor=this.ColorValue;
            if(this.Time>40) {
                this.AngularVelocityDegree=3f;
                this.AngleDegree+=(double)this.AngularVelocityDegree;
            }
            if(this.Time%4!=0)
                return;
            BaseEffect baseEffect = new BaseEffect(this.StageData,"StarShardW",this.Position,0.0f,0.0);
            baseEffect.Angle=this.Angle;
            baseEffect.ScaleVelocity=-0.0125f;
            baseEffect.TransparentVelocity=-3f;
            baseEffect.LifeTime=80;
            baseEffect.ColorValue=this.ColorValue;
        }

        public override void Show() {
            Color colorValue = this.ColorValue;
            this.ColorValue=Color.White;
            base.Show();
            this.ColorValue=colorValue;
        }
    }
}
