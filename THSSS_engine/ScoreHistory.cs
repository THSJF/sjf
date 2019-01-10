using System;

namespace Shooting {
    public class ScoreHistory {
        public string MyPlaneFullName { get; set; }
        public DifficultLevel Rank { get; set; }
        public string PlayerName { get; set; }
        public long Score { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Stage { get; set; }
        public string SlowRate { get; set; }
        public string Data2String() => MyPlaneFullName+'\t'+((int)Rank).ToString()+'\t'+PlayerName+'\t'+Score.ToString()+'\t'+Date+'\t'+Time+'\t'+Stage+'\t'+SlowRate+"\r\n";
        public string Data2DrawString() => PlayerName.PadRight(8)+Score.ToString().PadLeft(11)+Date.PadLeft(12)+Time.PadLeft(6)+Stage.PadLeft(4)+SlowRate.PadLeft(5);
        public string Data2DrawStringSimple() => PlayerName.PadRight(8)+Score.ToString().PadLeft(11)+Stage.PadLeft(5)+SlowRate.PadLeft(6);
        public void String2Data(string Data) {
            char[] chArray = new char[1] { '\t' };
            string[] strArray = Data.Split(chArray);
            MyPlaneFullName=strArray[0];
            Rank=(DifficultLevel)Convert.ToInt32(strArray[1]);
            PlayerName=strArray[2];
            Score=Convert.ToInt64(strArray[3]);
            Date=strArray[4];
            Time=strArray[5];
            Stage=strArray[6];
            SlowRate=strArray[7];
        }
        public void Copy(ScoreHistory SH) => String2Data(SH.Data2String().Replace("\r\n",string.Empty));
    }
}
