namespace Shooting {
    public class BaseBoss:BaseObject {
        private int spellcardHP = 2000;
        private float armor = 0.0f;
        private const int unmatchedTime = 100;
        public int SpellcardHP {
            get => spellcardHP;
            set => spellcardHP=value;
        }
        public int UnmatchedTime => 100;
        public int Life { get; set; }
        public int MaxHP { get; set; }
        public bool OnSpell { get; set; }
        public int SpellTime { get; set; }
        public float Armon {
            get => armor;
            set {
                if(value<0.0) {
                    armor=0.0f;
                } else if(value>1.0) {
                    armor=1f;
                } else {
                    armor=value;
                }
            }
        }
        public override void HitCheckAll() {
            if(Life<0||!HitEnabled) return;
            if(MyPlane.HitEnabled&&HitCheck(MyPlane)) MyPlane.PreMiss();
            for(int index = MyBulletList.Count-1;index>=0;--index) {
                if(HitCheck(MyBulletList[index])) {
                    if(Time>UnmatchedTime) {
                        if(MyPlane.EnchantmentState==EnchantmentType.Red) {
                            HealthPoint-=(float)(MyBulletList[index].Damage*1.25*(1.0-Armon));
                        } else {
                            HealthPoint-=MyBulletList[index].Damage*(1f-Armon);
                        }
                    }
                    MyBulletList[index].GiveEndEffect();
                    MyBulletList.RemoveAt(index);
                    MyPlane.Score+=10L;
                    if(HealthPoint<=200.0) {
                        StageData.SoundPlay("se_damage01.wav");
                    }
                }
            }
        }
    }
}
