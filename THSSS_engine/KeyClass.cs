namespace Shooting {
    public class KeyClass {
        public bool ArrowUp = false;
        public bool ArrowDown = false;
        public bool ArrowLeft = false;
        public bool ArrowRight = false;
        public bool Key_Shift = false;
        public bool Key_Z = false;
        public bool Key_X = false;
        public bool Key_C = false;
        public bool Key_Ctrl = false;
        public bool Key_ESC = false;
        public bool Key_plus = false;
        public bool Key_minus = false;
        public int Key2Hex() {
            int num1 = 0;
            if(ArrowUp) ++num1;
            int num2 = num1<<1;
            if(ArrowDown) ++num2;
            int num3 = num2<<1;
            if(ArrowLeft) ++num3;
            int num4 = num3<<1;
            if(ArrowRight) ++num4;
            int num5 = num4<<1;
            if(Key_Shift) ++num5;
            int num6 = num5<<1;
            if(Key_Z) ++num6;
            int num7 = num6<<1;
            if(Key_X) ++num7;
            int num8 = num7<<1;
            if(Key_C) ++num8;
            int num9 = num8<<1;
            if(Key_Ctrl) ++num9;
            return num9<<1<<6;
        }
        public void Hex2Key(int keyValue) {
            keyValue>>=7;
            Key_Ctrl=keyValue%2==1;
            keyValue>>=1;
            Key_C=keyValue%2==1;
            keyValue>>=1;
            Key_X=keyValue%2==1;
            keyValue>>=1;
            Key_Z=keyValue%2==1;
            keyValue>>=1;
            Key_Shift=keyValue%2==1;
            keyValue>>=1;
            ArrowRight=keyValue%2==1;
            keyValue>>=1;
            ArrowLeft=keyValue%2==1;
            keyValue>>=1;
            ArrowDown=keyValue%2==1;
            keyValue>>=1;
            ArrowUp=keyValue%2==1;
            keyValue>>=1;
        }
        public static void KeyMix(ref KeyClass KClass,KeyClass KClass1,KeyClass KClass2) {
            KClass.Key_Z=KClass1.Key_Z|KClass2.Key_Z;
            KClass.Key_X=KClass1.Key_X|KClass2.Key_X;
            KClass.Key_C=KClass1.Key_C|KClass2.Key_C;
            KClass.Key_Shift=KClass1.Key_Shift|KClass2.Key_Shift;
            KClass.Key_Ctrl=KClass1.Key_Ctrl|KClass2.Key_Ctrl;
            KClass.ArrowLeft=KClass1.ArrowLeft|KClass2.ArrowLeft;
            KClass.ArrowRight=KClass1.ArrowRight|KClass2.ArrowRight;
            KClass.ArrowDown=KClass1.ArrowDown|KClass2.ArrowDown;
            KClass.ArrowUp=KClass1.ArrowUp|KClass2.ArrowUp;
            KClass.Key_ESC=KClass1.Key_ESC|KClass2.Key_ESC;
            KClass.Key_plus=KClass1.Key_plus|KClass2.Key_plus;
            KClass.Key_minus=KClass1.Key_minus|KClass2.Key_minus;
        }
    }
}
