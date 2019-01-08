// Decompiled with JetBrains decompiler
// Type: Shooting.SpellCard_SSS06_06
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting {
    internal class SpellCard_SSS06_06:BaseSpellCard {
        private int flag = 1;

        public SpellCard_SSS06_06(StageDataPackage StageData) : base(StageData) {
            SC_Name="「流星神话」";
            BaseScore=35000000L;
            Boss.DestPoint=new Point(BoundRect.Width/2,120);
            Boss.Velocity=4f;
            StageData.SoundPlay("se_cat00.wav");
            BackgroundBoss06 backgroundBoss06 = new BackgroundBoss06(StageData);
            BulletTitle bulletTitle = new BulletTitle(StageData,SC_Name);
            SpellCardAttack spellCardAttack = new SpellCardAttack(StageData);
            FullPic3 fullPic3 = new FullPic3(StageData,"FaceTensei_ct3");
        }

        public override void Shoot() {
            if(SpellList.Count>0) {
                Boss.Armon=1f;
                switch(flag) {
                    case 1: Boss.HealthPoint++; break;
                    case 2: Boss.HealthPoint+=2; break;
                    case 3: MyPlane.Score-=100000; break;
                    case 4: Boss.HealthPoint+=3; MyPlane.Score-=100000; break;
                }
            } else {
                Boss.Armon=Boss.ArmonArray[9];
            }

            if(Time>100) {
                Boss.MoveUpDown();
            }

            if(Time==150) {
                string FileName;
                switch(Difficulty) {
                    case DifficultLevel.Easy: FileName=".\\CS\\St06\\关底Boss\\6符P1E.mbg"; break;
                    case DifficultLevel.Normal: FileName=".\\CS\\St06\\关底Boss\\6符P1N.mbg"; break;
                    case DifficultLevel.Hard: FileName=".\\CS\\St06\\关底Boss\\6符P1H.mbg"; break;
                    case DifficultLevel.Lunatic: FileName=".\\CS\\St06\\关底Boss\\6符P1L.mbg"; break;
                    default: FileName=".\\CS\\St06\\关底Boss\\6符P1L.mbg"; break;
                }
                CSEmitterController emitterController = new CSEmitterController(StageData,StageData.LoadCS(FileName));
            }
            if((Boss.HealthPoint<Boss.MaxHP*3/4.0||Time>1800)&&flag==1) {
                ++flag;
                ClearEmitter();
                string FileName;
                switch(Difficulty) {
                    case DifficultLevel.Easy: FileName=".\\CS\\St06\\关底Boss\\6符P2E.mbg"; break;
                    case DifficultLevel.Normal: FileName=".\\CS\\St06\\关底Boss\\6符P2N.mbg"; break;
                    case DifficultLevel.Hard: FileName=".\\CS\\St06\\关底Boss\\6符P2H.mbg"; break;
                    case DifficultLevel.Lunatic: FileName=".\\CS\\St06\\关底Boss\\6符P2L.mbg"; break;
                    default: FileName=".\\CS\\St06\\关底Boss\\6符P2L.mbg"; break;
                }
                CSEmitterController emitterController = new CSEmitterController(StageData,StageData.LoadCS(FileName));
            }
            if((Boss.HealthPoint<Boss.MaxHP*2/4.0||Time>3600)&&flag==2) {
                ++flag;
                ClearEmitter();
                string FileName;
                switch(Difficulty) {
                    case DifficultLevel.Easy: FileName=".\\CS\\St06\\关底Boss\\6符P3E.mbg"; break;
                    case DifficultLevel.Normal: FileName=".\\CS\\St06\\关底Boss\\6符P3E.mbg"; break;
                    case DifficultLevel.Hard: FileName=".\\CS\\St06\\关底Boss\\6符P3N.mbg"; break;
                    case DifficultLevel.Lunatic: FileName=".\\CS\\St06\\关底Boss\\6符P3N.mbg"; break;
                    default: FileName=".\\CS\\St06\\关底Boss\\6符P2L.mbg"; break;
                }
                CSEmitterController emitterController = new CSEmitterController(StageData,StageData.LoadCS(FileName));
            }
            if(Boss.HealthPoint>=Boss.MaxHP/4.0&&Time<=4500||flag!=3) return;
            ++flag;
            ClearEmitter();
            string FileName1;
            switch(Difficulty) {
                case DifficultLevel.Easy: FileName1=".\\CS\\St06\\关底Boss\\6符P4E.mbg"; break;
                case DifficultLevel.Normal: FileName1=".\\CS\\St06\\关底Boss\\6符P4E.mbg"; break;
                case DifficultLevel.Hard: FileName1=".\\CS\\St06\\关底Boss\\6符P4N.mbg"; break;
                case DifficultLevel.Lunatic: FileName1=".\\CS\\St06\\关底Boss\\6符P4H.mbg"; break;
                default: FileName1=".\\CS\\St06\\关底Boss\\6符P4L.mbg"; break;
            }
            CSEmitterController emitterController1 = new CSEmitterController(StageData,StageData.LoadCS(FileName1));
        }

        private void ClearEmitter() {
            for(int index = EnemyPlaneList.Count-1;index>=0;--index) {
                if(!(EnemyPlaneList[index] is BaseSpellCard)) {
                    EnemyPlaneList[index].GiveEndEffect();
                    EnemyPlaneList.RemoveAt(index);
                }
            }
            foreach(BaseObject bullet in BulletList) {
                bullet.GiveEndEffect();
            }
            BulletList.Clear();
        }
    }
}
