using System;
using System.Drawing;

namespace Shooting {
    public class Spell_PlaneB:BaseSpell {
        public Spell_PlaneB(StageDataPackage StageData) {
            this.StageData=StageData;
            OriginalPosition=MyPlane.OriginalPosition;
            Damage=45;
            Region=30;
            LifeTime=390;
            Direction=Math.PI/2.0;
            SpellList.Add(this);
            new BackgroundBlack(StageData,Position).LifeTime=410;
            MyPlane.HighSpeed=1.6f;
            MyPlane.LowSpeed=0.8f;
            new EmitterSaveEnegy3(StageData,Position).SetBinding(this);
            StageData.SoundPlay("boss_change.wav");
        }
        public override void Move() => OriginalPosition=MyPlane.OriginalPosition;
        public override void Ctrl() {
            base.Ctrl();
            if(Time<90) return;
            if(Time==90) {
                StageData.SoundPlay("se_nep00.wav");
                StageData.SoundPlay("se_spell.wav");
                StageData.VibrateStart(300);
                PointF OriginalPosition = new PointF(this.OriginalPosition.X,this.OriginalPosition.Y+70f);
                PlaneSpark planeSpark1 = new PlaneSpark(StageData,"Master Spark",OriginalPosition,0.0f,-1.0*Math.PI/2.0) {
                    MaxScaleW=1f,
                    MaxScaleL=3f
                };
                planeSpark1.SetBinding(this);
                PlaneSpark planeSpark2 = new PlaneSpark(StageData,"Master Spark",OriginalPosition,0.0f,-1.0*Math.PI/2.0) {
                    MaxScaleW=1.6f,
                    MaxScaleL=3f
                };
                planeSpark2.SetBinding(this);
                PlaneSpark planeSpark3 = new PlaneSpark(StageData,"Master Spark",OriginalPosition,0.0f,-1.0*Math.PI/2.0) {
                    MaxScaleW=2.2f,
                    MaxScaleL=3f
                };
                planeSpark3.SetBinding(this);
            }
            if(Time==LifeTime-30) Damage=20;
            if((double)MyPlane.Position.Y>=BoundRect.Bottom) return;
            MyPlane.Position=new PointF(MyPlane.Position.X,MyPlane.Position.Y+8f);
        }
        public override bool OutBoundary() {
            bool flag = base.OutBoundary();
            if(flag) {
                MyPlane.HighSpeed=5f;
                MyPlane.LowSpeed=2f;
            }
            return flag;
        }
        public override bool HitCheck(BaseObject Target) {
            PointF originalPosition1 = Target.OriginalPosition;
            double y = originalPosition1.Y;
            originalPosition1=OriginalPosition;
            double num1 = originalPosition1.Y+5.0;
            int num2;
            if(y<num1) {
                PointF originalPosition2 = OriginalPosition;
                double num3 = originalPosition2.X-120.0;
                originalPosition2=Target.OriginalPosition;
                double x1 = originalPosition2.X;
                if(num3<x1) {
                    originalPosition2=Target.OriginalPosition;
                    double x2 = originalPosition2.X;
                    originalPosition2=OriginalPosition;
                    double num4 = originalPosition2.X+120.0;
                    num2=x2>=num4 ? 1 : 0;
                    goto label_4;
                }
            }
            num2=1;
            label_4:
            return num2==0;
        }
        public override void HitCheckAll() {
            if(Time<90) return;
            base.HitCheckAll();
        }
    }
}
