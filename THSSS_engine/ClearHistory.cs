using System;

namespace Shooting {
    public class ClearHistory {
        public string MyPlaneFullName { get; set; }
        public DifficultLevel Rank { get; set; }
        public int StartTimes { get; set; }
        public long PlayingTime { get; set; }
        public int ClearTimes { get; set; }
        public int NoContinueClearTimes { get; set; }
        public int PracticeLevel { get; set; }
        public string Data2String() => MyPlaneFullName+'\t'+((int)Rank).ToString()+'\t'+StartTimes.ToString()+'\t'+PlayingTime.ToString()+'\t'+ClearTimes.ToString()+'\t'+NoContinueClearTimes.ToString()+'\t'+PracticeLevel.ToString()+"\r\n";
        public void String2Data(string Data) {
            char[] chArray = new char[1] { '\t' };
            string[] strArray = Data.Split(chArray);
            MyPlaneFullName=strArray[0];
            Rank=(DifficultLevel)Convert.ToInt32(strArray[1]);
            StartTimes=Convert.ToInt32(strArray[2]);
            PlayingTime=Convert.ToInt32(strArray[3]);
            ClearTimes=Convert.ToInt32(strArray[4]);
            NoContinueClearTimes=Convert.ToInt32(strArray[5]);
            PracticeLevel=Convert.ToInt32(strArray[6]);
        }
    }
}
