using System;
using System.Drawing;

namespace Shooting {
    public class Spell_Shinmyoumaru:BaseSpell {
        public Spell_Shinmyoumaru(StageDataPackage StageData) {
            this.StageData=StageData;
            Position=MyPlane.Position;
            Damage=32;
            Region=4;
            LifeTime=300;
            ScaleVelocity=0.3f;
            MaxScale=200f;
            BackgroundBlack backgroundBlack = new BackgroundBlack(StageData,Position);
            StageData.SoundPlay("se_cat00.wav");
            StageData.SoundPlay("se_nep00.wav");
            SpellList.Add(this);
        }

        public override void Move() => Position=MyPlane.Position;

        public override void Ctrl() {
            base.Ctrl();
            if(1<Time&&Time<60) {
                int num1 = 7;
                double num2 = 360.0/num1;
                for(int index = 0;index<num1;++index) {
                    BaseEffect baseEffect1 = new BaseEffect(StageData,"bullet23_0",Position,1.5f,0.0) {
                        DirectionDegree=Time*18+num2*index,
                        ScaleWidth=0.3f,
                        ScaleLength=0.3f,
                        LifeTime=999
                    };
                    BaseEffect baseEffect2 = baseEffect1;
                    baseEffect2.OutBound=false;
                    baseEffect2.DirectionVelocityDegree=-2.8f;
                    baseEffect2.VelocityDictionary.Add(40,3f);
                    baseEffect2.AccelerateDictionary.Add(115,2f);
                    baseEffect2.AccelerateDictionary.Add(123,0.0f);
                    baseEffect2.DirectionVelocityDegreeDictionary.Add(115,(float)((Ran.NextPMDouble()-80.0)/45.0));
                    baseEffect2.DirectionVelocityDegreeDictionary.Add(160,0.0f);
                    baseEffect2.ScaleLengthVelocityDictionary.Add(115,0.3f);
                    baseEffect2.ScaleWidthVelocityDictionary.Add(115,0.1f);
                    baseEffect2.ScaleLengthVelocityDictionary.Add(120,0.0f);
                    baseEffect2.ScaleWidthVelocityDictionary.Add(120,0.0f);
                    baseEffect2.SetBinding(this);
                    BaseEffect baseEffect3 = new BaseEffect(StageData,"bullet23_0",Position,1.5f,0.0) {
                        DirectionDegree=180-Time*18+num2*index,
                        ScaleWidth=0.3f,
                        ScaleLength=0.3f,
                        LifeTime=999
                    };
                    BaseEffect baseEffect4 = baseEffect3;
                    baseEffect4.OutBound=false;
                    baseEffect4.DirectionVelocityDegree=2.8f;
                    baseEffect4.VelocityDictionary.Add(40,3f);
                    baseEffect4.AccelerateDictionary.Add(115,2f);
                    baseEffect4.AccelerateDictionary.Add(123,0.0f);
                    baseEffect4.DirectionVelocityDegreeDictionary.Add(115,(float)((80.0+Ran.NextPMDouble())/45.0));
                    baseEffect4.DirectionVelocityDegreeDictionary.Add(160,0.0f);
                    baseEffect4.ScaleLengthVelocityDictionary.Add(115,0.3f);
                    baseEffect4.ScaleWidthVelocityDictionary.Add(115,0.1f);
                    baseEffect4.ScaleLengthVelocityDictionary.Add(120,0.0f);
                    baseEffect4.ScaleWidthVelocityDictionary.Add(120,0.0f);
                    baseEffect4.SetBinding(this);
                }
            }
            if(130<Time&&Time<220) {
                for(int index = 0;index<3;++index) {
                    BaseEffect_CS baseEffectCs1 = new BaseEffect_CS(StageData) {
                        TxtureObject=TextureObjectDictionary["bullet50_0"]
                    };
                    BaseEffect_CS baseEffectCs2 = baseEffectCs1;
                    Rectangle boundRect = BoundRect;
                    double num1 = boundRect.Width/2+200.0*Ran.NextPMDouble();
                    boundRect=BoundRect;
                    double num2 = boundRect.Height/2+280.0*Ran.NextPMDouble();
                    PointF pointF = new PointF((float)num1,(float)num2);
                    baseEffectCs2.OriginalPosition=pointF;
                    baseEffectCs1.Velocity=(float)Ran.NextPMDouble();
                    baseEffectCs1.Direction=Math.PI/2.0*Ran.NextPMDouble();
                    baseEffectCs1.Scale=0.05f;
                    baseEffectCs1.LifeTime=40;
                    EventGroup eventGroup = new EventGroup();
                    eventGroup.index=0;
                    eventGroup.tag="0";
                    eventGroup.t=15;
                    eventGroup.addtime=15;
                    Event event1 = new Event();
                    event1.EventString="当前帧=1：高比变化到0，正弦，14";
                    event1.String2BulletEvent();
                    eventGroup.EventList.Add(event1);
                    Event event2 = new Event();
                    event2.EventString="当前帧=1：宽比变化到0，正弦，14";
                    event2.String2BulletEvent();
                    eventGroup.EventList.Add(event2);
                    baseEffectCs1.EventGroupList.Add(eventGroup);
                    EffectList.Add(baseEffectCs1);
                }
            }
            if(Time!=122) return;
            ScaleVelocity=10f;
            EmitterGiveOutEnegy3D emitterGiveOutEnegy3D = new EmitterGiveOutEnegy3D(StageData,OriginalPosition,Color.White);
            StageData.SoundPlay("se_cat00.wav");
            StageData.VibrateStart(LifeTime-Time);
        }
    }
}
