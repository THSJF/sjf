// Decompiled with JetBrains decompiler
// Type: Shooting.Spell_Sanae
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting {
    public class Spell_Sanae:BaseSpell {
        public Spell_Sanae(StageDataPackage StageData) {
            this.StageData=StageData;
            Position=MyPlane.Position;
            Damage=36;
            Region=4;
            LifeTime=300;
            ScaleVelocity=0.1f;
            MaxScale=200f;
            BackgroundBlack backgroundBlack = new BackgroundBlack(StageData,Position);
            StageData.SoundPlay("se_cat00.wav");
            StageData.SoundPlay("se_nep00.wav");
            SpellList.Add(this);
        }

        public override void Ctrl() {
            base.Ctrl();
            if(Time==1) {
                BaseEffect baseEffect1 = new BaseEffect(StageData,"球",Position,0.0f,0.0) {
                    ScaleWidth=0.05f,
                    ScaleLength=0.05f
                };
                BaseEffect baseEffect2 = baseEffect1;
                baseEffect2.ScaleLengthVelocityDictionary.Add(1,0.01666667f);
                baseEffect2.ScaleWidthVelocityDictionary.Add(1,0.01666667f);
                baseEffect2.ScaleLengthVelocityDictionary.Add(120,1.25f);
                baseEffect2.ScaleWidthVelocityDictionary.Add(120,1.25f);
                baseEffect2.TransparentVelocityDictionary.Add(120,-10f);
                baseEffect2.AngularVelocityDegree=10f;
            } else if(Time==120) {
                StageData.SoundPlay("se_cat00.wav");
                EmitterGiveOutEnegy3D emitterGiveOutEnegy3D = new EmitterGiveOutEnegy3D(StageData,OriginalPosition,Color.Green);
                StageData.VibrateStart(LifeTime-Time);
                ScaleVelocity=10f;
            } else if(120<Time&&Time<=170) {
                AngularVelocityDegree=2.5f;
                BaseEffect baseEffect1 = new BaseEffect(StageData,"bullet50_5",Position,7f,Angle-Math.PI/2.0) {
                    ScaleLength=15f,
                    ScaleWidth=0.3f
                };
                BaseEffect baseEffect2 = new BaseEffect(StageData,"bullet50_5",Position,7f,-1.0*Math.PI/2.0-Angle) {
                    ScaleLength=15f,
                    ScaleWidth=0.3f
                };
            } else {
                if(Time!=240) {
                    return;
                }
            }
        }
    }
}
