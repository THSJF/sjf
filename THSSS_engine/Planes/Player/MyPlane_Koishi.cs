using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shooting {
    public class MyPlane_Koishi:BaseMyPlane_Touhou {
        private bool GodMode;
        public MyPlane_Koishi(StageDataPackage StageData,Point OriginalPosition) : base(StageData,OriginalPosition,"Koishi") {
            WeaponType="A";
            SubPlaneList=new List<BaseSubPlane>(){
                 new SubPlane_Koishi(StageData, Position),
                 new SubPlane_Koishi(StageData, Position),
                 new SubPlane_Koishi(StageData, Position),
                 new SubPlane_Koishi(StageData, Position)
              };
            HighSpeed=5f;
            LowSpeed=2f;
        }
        public override void Shoot() {
            if(Time%3==0) {
                StageData.SoundPlay("se_plst00.wav",OriginalPosition.X/BoundRect.Width);
                float x = OriginalPosition.X;
                float y = OriginalPosition.Y;
                new BaseMyBullet_Touhou(StageData,"KoishiBullet",new PointF(x+7f,y),30f,-1.0*Math.PI/2.0).Damage=13;
                new BaseMyBullet_Touhou(StageData,"KoishiBullet",new PointF(x-7f,y),30f,-1.0*Math.PI/2.0).Damage=13;
            }
            if(Time%10!=0) return;
            for(int index = 0;index<PowerLevel;++index) {
                SubPlaneList[index].Shoot();
            }
        }
        public override void SpellShoot() {
            if(GodMode) return;
            Spell_Koishi spellKoishi = new Spell_Koishi(StageData);
            GodMode=true;
        }
        public override void Ctrl() {
            base.Ctrl();
            TransparentVelocity=GodMode ? -10f : 10f;
            TransparentValueF+=TransparentVelocity;
            SpellEnabled=!GodMode;
        }
        public override void SubPlaneCtrl() {
            if(KClass.Key_Shift) {
                switch(PowerLevel) {
                    case 1:
                        SubPlanePoint[0]=new PointF(OriginalPosition.X,OriginalPosition.Y-44f);
                        SubPlaneList[0].ShootDirection=-1.0*Math.PI/2.0;
                        break;
                    case 2:
                        ref PointF local1 = ref SubPlanePoint[0];
                        double num1 = OriginalPosition.X-7.0;
                        PointF originalPosition1 = OriginalPosition;
                        double num2 = originalPosition1.Y-36.0;
                        PointF pointF1 = new PointF((float)num1,(float)num2);
                        local1=pointF1;
                        ref PointF local2 = ref SubPlanePoint[1];
                        originalPosition1=OriginalPosition;
                        double num3 = originalPosition1.X+7.0;
                        originalPosition1=OriginalPosition;
                        double num4 = originalPosition1.Y-36.0;
                        PointF pointF2 = new PointF((float)num3,(float)num4);
                        local2=pointF2;
                        SubPlaneList[0].ShootDirection=-1.0*Math.PI/2.0;
                        SubPlaneList[1].ShootDirection=-1.0*Math.PI/2.0;
                        break;
                    case 3:
                        ref PointF local3 = ref SubPlanePoint[2];
                        double x1 = OriginalPosition.X;
                        PointF originalPosition2 = OriginalPosition;
                        double num5 = originalPosition2.Y-36.0;
                        PointF pointF3 = new PointF((float)x1,(float)num5);
                        local3=pointF3;
                        ref PointF local4 = ref SubPlanePoint[1];
                        originalPosition2=OriginalPosition;
                        double num6 = originalPosition2.X-16.0;
                        originalPosition2=OriginalPosition;
                        double num7 = originalPosition2.Y-29.0;
                        PointF pointF4 = new PointF((float)num6,(float)num7);
                        local4=pointF4;
                        ref PointF local5 = ref SubPlanePoint[0];
                        originalPosition2=OriginalPosition;
                        double num8 = originalPosition2.X+16.0;
                        originalPosition2=OriginalPosition;
                        double num9 = originalPosition2.Y-29.0;
                        PointF pointF5 = new PointF((float)num8,(float)num9);
                        local5=pointF5;
                        SubPlaneList[2].ShootDirection=-1.0*Math.PI/2.0;
                        SubPlaneList[1].ShootDirection=-1.0*Math.PI/2.0;
                        SubPlaneList[0].ShootDirection=-1.0*Math.PI/2.0;
                        break;
                    case 4:
                        ref PointF local6 = ref SubPlanePoint[3];
                        double num10 = OriginalPosition.X-7.0;
                        PointF originalPosition3 = OriginalPosition;
                        double num11 = originalPosition3.Y-36.0;
                        PointF pointF6 = new PointF((float)num10,(float)num11);
                        local6=pointF6;
                        ref PointF local7 = ref SubPlanePoint[2];
                        originalPosition3=OriginalPosition;
                        double num12 = originalPosition3.X+7.0;
                        originalPosition3=OriginalPosition;
                        double num13 = originalPosition3.Y-36.0;
                        PointF pointF7 = new PointF((float)num12,(float)num13);
                        local7=pointF7;
                        ref PointF local8 = ref SubPlanePoint[1];
                        originalPosition3=OriginalPosition;
                        double num14 = originalPosition3.X-16.0;
                        originalPosition3=OriginalPosition;
                        double num15 = originalPosition3.Y-29.0;
                        PointF pointF8 = new PointF((float)num14,(float)num15);
                        local8=pointF8;
                        ref PointF local9 = ref SubPlanePoint[0];
                        originalPosition3=OriginalPosition;
                        double num16 = originalPosition3.X+16.0;
                        originalPosition3=OriginalPosition;
                        double num17 = originalPosition3.Y-29.0;
                        PointF pointF9 = new PointF((float)num16,(float)num17);
                        local9=pointF9;
                        SubPlaneList[3].ShootDirection=-1.0*Math.PI/2.0;
                        SubPlaneList[2].ShootDirection=-1.0*Math.PI/2.0;
                        SubPlaneList[1].ShootDirection=-1.0*Math.PI/2.0;
                        SubPlaneList[0].ShootDirection=-1.0*Math.PI/2.0;
                        break;
                }
            } else {
                switch(PowerLevel) {
                    case 1:
                        SubPlanePoint[0]=new PointF(OriginalPosition.X,OriginalPosition.Y-44f);
                        SubPlaneList[0].ShootDirection=-1.0*Math.PI/2.0;
                        break;
                    case 2:
                        ref PointF local10 = ref SubPlanePoint[0];
                        double num18 = OriginalPosition.X-32.0;
                        PointF originalPosition4 = OriginalPosition;
                        double num19 = originalPosition4.Y-32.0;
                        PointF pointF10 = new PointF((float)num18,(float)num19);
                        local10=pointF10;
                        ref PointF local11 = ref SubPlanePoint[1];
                        originalPosition4=OriginalPosition;
                        double num20 = originalPosition4.X+32.0;
                        originalPosition4=OriginalPosition;
                        double num21 = originalPosition4.Y-32.0;
                        PointF pointF11 = new PointF((float)num20,(float)num21);
                        local11=pointF11;
                        SubPlaneList[0].ShootDirection=5.0*Math.PI/4.0;
                        SubPlaneList[1].ShootDirection=7.0*Math.PI/4.0;
                        break;
                    case 3:
                        ref PointF local12 = ref SubPlanePoint[2];
                        double x2 = OriginalPosition.X;
                        PointF originalPosition5 = OriginalPosition;
                        double num22 = originalPosition5.Y+44.0;
                        PointF pointF12 = new PointF((float)x2,(float)num22);
                        local12=pointF12;
                        ref PointF local13 = ref SubPlanePoint[1];
                        originalPosition5=OriginalPosition;
                        double num23 = originalPosition5.X-32.0;
                        originalPosition5=OriginalPosition;
                        double num24 = originalPosition5.Y-32.0;
                        PointF pointF13 = new PointF((float)num23,(float)num24);
                        local13=pointF13;
                        ref PointF local14 = ref SubPlanePoint[0];
                        originalPosition5=OriginalPosition;
                        double num25 = originalPosition5.X+32.0;
                        originalPosition5=OriginalPosition;
                        double num26 = originalPosition5.Y-32.0;
                        PointF pointF14 = new PointF((float)num25,(float)num26);
                        local14=pointF14;
                        SubPlaneList[2].ShootDirection=Math.PI/2.0;
                        SubPlaneList[1].ShootDirection=5.0*Math.PI/4.0;
                        SubPlaneList[0].ShootDirection=7.0*Math.PI/4.0;
                        break;
                    case 4:
                        ref PointF local15 = ref SubPlanePoint[3];
                        double num27 = OriginalPosition.X-32.0;
                        PointF originalPosition6 = OriginalPosition;
                        double num28 = originalPosition6.Y+32.0;
                        PointF pointF15 = new PointF((float)num27,(float)num28);
                        local15=pointF15;
                        ref PointF local16 = ref SubPlanePoint[2];
                        originalPosition6=OriginalPosition;
                        double num29 = originalPosition6.X+32.0;
                        originalPosition6=OriginalPosition;
                        double num30 = originalPosition6.Y+32.0;
                        PointF pointF16 = new PointF((float)num29,(float)num30);
                        local16=pointF16;
                        ref PointF local17 = ref SubPlanePoint[1];
                        originalPosition6=OriginalPosition;
                        double num31 = originalPosition6.X-32.0;
                        originalPosition6=OriginalPosition;
                        double num32 = originalPosition6.Y-32.0;
                        PointF pointF17 = new PointF((float)num31,(float)num32);
                        local17=pointF17;
                        ref PointF local18 = ref SubPlanePoint[0];
                        originalPosition6=OriginalPosition;
                        double num33 = originalPosition6.X+32.0;
                        originalPosition6=OriginalPosition;
                        double num34 = originalPosition6.Y-32.0;
                        PointF pointF18 = new PointF((float)num33,(float)num34);
                        local18=pointF18;
                        SubPlaneList[3].ShootDirection=3.0*Math.PI/4.0;
                        SubPlaneList[2].ShootDirection=Math.PI/4.0;
                        SubPlaneList[1].ShootDirection=5.0*Math.PI/4.0;
                        SubPlaneList[0].ShootDirection=7.0*Math.PI/4.0;
                        break;
                }
            }
            for(int index = 0;index<PowerLevel;++index) {
                SubPlaneList[index].Enabled=true;
                SubPlaneList[index].DestPoint=SubPlanePoint[index];
                SubPlaneList[index].Ctrl();
            }
            for(int powerLevel = PowerLevel;powerLevel<SubPlaneList.Count;++powerLevel) {
                SubPlaneList[powerLevel].Enabled=false;
                SubPlaneList[powerLevel].Position=Position;
            }
        }
        public override void PreMiss() {
            if(Time<UnmatchedTime||Time<UnmatchedTime||(Time<DeadTime||SpellList.Count!=0)) return;
            if(EnchantmentState==EnchantmentType.Green) {
                new BulletRemover_Small(StageData,OriginalPosition).Region=500;
                ChangeEnchantment(EnchantmentType.None);
                EnemyPlaneList.ForEach(x => {
                    if(!(x is BaseSpellCard)) return;
                    ((BaseSpellCard)x).Missed=true;
                });
            } else if(GodMode) {
                GodMode=false;
                StageData.SoundPlay("ice005.wav");
                new BulletRemover_Small(StageData,MyPlane.OriginalPosition).Region=150;
                Time=UnmatchedTime-60;
                ItemGetter itemGetter = new ItemGetter(StageData);
                EnemyPlaneList.ForEach(x => {
                    if(!(x is BaseSpellCard)) return;
                    ((BaseSpellCard)x).Missed=true;
                });
            } else {
                Emitter emitter = new Emitter(StageData,MyPlane.Position);
                StageData.SoundPlay("se_pldead00.wav",OriginalPosition.X/BoundRect.Width);
                DeadTime=Time+20;
            }
        }
        public override void Refresh() {
            if(GodMode) {
                SpellExtand();
                GodMode=false;
            }
            base.Refresh();
        }
        public override void Show() {
            if(Time<DeadTime||Time==0) return;
            SpriteMain.Draw2D(TxtureObject,1f,0.0f,Position,Color.FromArgb(TransparentValue,Time<UnmatchedTime&&Time/2%2==0 ? Color.DarkBlue : Color.White));
            if(GodMode) SpriteMain.Draw2D(TextureObjectDictionary["jiejie"],1f,(float)(-Direction*4.0),Position,Color.FromArgb(byte.MaxValue-TransparentValue,Color.White));
            for(int index = 0;index<PowerLevel;++index) {
                SubPlaneList[index].Show();
            }
        }
    }
}
