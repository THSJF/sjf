using System;

namespace Shooting {
    public class SpellCardHistory {
        public string MyPlaneFullName { get; set; }
        public DifficultLevel Rank { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public int Recorded { get; set; }
        public int History { get; set; }
        public string Data2String() => Index.ToString()+'\t'+MyPlaneFullName+'\t'+((int)Rank).ToString()+'\t'+Recorded.ToString()+'\t'+History.ToString()+"\r\n";
        public void String2Data(string Data) {
            char[] chArray = new char[1] { '\t' };
            string[] strArray = Data.Split(chArray);
            Index=Convert.ToInt32(strArray[0]);
            MyPlaneFullName=strArray[1];
            Rank=(DifficultLevel)Convert.ToInt32(strArray[2]);
            Recorded=Convert.ToInt32(strArray[3]);
            History=Convert.ToInt32(strArray[4]);
        }
    }
}
