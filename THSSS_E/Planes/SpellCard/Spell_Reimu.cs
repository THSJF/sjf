using System.Drawing;

namespace Shooting {
    public class Spell_Reimu:BaseSpell {
        public Spell_Reimu(StageDataPackage StageData) {
            this.StageData=StageData;
            Position=MyPlane.Position;
            Damage=40;
            Region=64;
            LifeTime=260;
            Scale=0.0f;
            BackgroundBlack backgroundBlack = new BackgroundBlack(StageData,Position);
            EmitterGiveOutEnegy3D emitterGiveOutEnegy3D = new EmitterGiveOutEnegy3D(StageData,OriginalPosition,Color.FromArgb(byte.MaxValue,100,100));
            StageData.SoundPlay("se_cat00.wav");
            StageData.SoundPlay("se_nep00.wav");
            TxtureObject=TextureObjectDictionary["YINYANGYU"];
            Velocity=2.2f;
            DirectionDegree=-90.0;
            AngularVelocityDegree=-3f;
            Accelerate=-Velocity/210;
            SpellList.Add(this);
        }

        public override void Ctrl() {
            base.Ctrl();
            if(1<Time&&Time<50) {
                ScaleVelocity+=0.0004f;
            } else if(150<Time&&Time<240) {
                ScaleVelocity-=0.0004f;
            } else if(Time==240) {
                ScaleVelocity=-Scale/20;
            } else if(Time==260) {
                ScaleVelocity=0.0f;
            }
            if(Time==22) {
                StageData.VibrateStart(LifeTime-Time);
            }
            if(Time==260) {
                EmitterGiveOutEnegy3D emitterGiveOutEnegy3D1 = new EmitterGiveOutEnegy3D(StageData,OriginalPosition,Color.FromArgb(150,150,byte.MaxValue));
                EmitterGiveOutEnegy3D emitterGiveOutEnegy3D2 = new EmitterGiveOutEnegy3D(StageData,OriginalPosition,Color.FromArgb(150,150,byte.MaxValue));
                EmitterGiveOutEnegy3D emitterGiveOutEnegy3D3 = new EmitterGiveOutEnegy3D(StageData,OriginalPosition,Color.FromArgb(150,150,byte.MaxValue));
                StageData.SoundPlay("se_cat00.wav");
            }
            if(Time%12!=0) return;
            int num1 = 60;
            double num2 = 360.0/num1;
            float Velocity = Time<150 ? 2.0f+Time*4.0f/150.0f : 6f;
            for(int index = 0;index<num1;++index) {
                BaseEffect baseEffect1 = new BaseEffect(StageData,"yuan_9",Position,Velocity,0.0) {
                    DirectionDegree=num2*index,
                    ScaleWidth=0.4f,
                    ScaleLength=0.13f,
                    LifeTime=60,
                    TransparentValueF=0.0f,
                    ColorValue=Color.FromArgb(100,100,200)
                };
                BaseEffect baseEffect2 = baseEffect1;
                baseEffect2.AccelerateDictionary.Add(1,-(Velocity-0.5f)/50.0f);
                baseEffect2.AccelerateDictionary.Add(50,0.0f);
                baseEffect2.ScaleWidthVelocityDictionary.Add(1,0.01f);
                baseEffect2.ScaleWidthVelocityDictionary.Add(50,0.0f);
                baseEffect2.ScaleLengthVelocityDictionary.Add(1,-baseEffect2.ScaleLength/50.0f);
                baseEffect2.ScaleLengthVelocityDictionary.Add(50,0.0f);
                baseEffect2.TransparentVelocityDictionary.Add(1,1f);
                baseEffect2.TransparentVelocityDictionary.Add(60,0.0f);
            }
        }

        public override void Show() {
            base.Show();
            SpriteMain.Draw2D(TextureObjectDictionary["bullet50_3"],(float)(ScaleWidth*0.129999995231628/0.0399999991059303),(float)(ScaleLength*0.129999995231628/0.0399999991059303),0.0f,Position,Color.FromArgb(76,ColorValue),Mirrored);
        }
    }
}
