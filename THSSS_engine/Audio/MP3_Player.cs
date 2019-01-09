using System;
using System.Runtime.InteropServices;

namespace Shooting {
    public class MP3_Player {
        [MarshalAs(UnmanagedType.ByValTStr,SizeConst = 260)]
        private string Name = "";
        [MarshalAs(UnmanagedType.ByValTStr,SizeConst = 128)]
        private string durLength = "";
        [MarshalAs(UnmanagedType.LPTStr)]
        private string TemStr = "";
        public structMCI mc = new structMCI();
        private int ilong;
        private int volumn;
        public MP3_Player() => Volumn=100;
        public string FileName {
            get => mc.iName;
            set {
                try {
                    TemStr="";
                    TemStr=TemStr.PadLeft(sbyte.MaxValue,Convert.ToChar(" "));
                    Name=Name.PadLeft(260,Convert.ToChar(" "));
                    mc.iName=value;
                    ilong=APIClass.GetShortPathName(mc.iName,Name,Name.Length);
                    Name=GetCurrPath(Name);
                    Name="open "+Convert.ToChar(34)+Name+Convert.ToChar(34)+" alias media";
                    ilong=APIClass.mciSendString("close all",TemStr,TemStr.Length,0);
                    ilong=APIClass.mciSendString(Name,TemStr,TemStr.Length,0);
                    ilong=APIClass.mciSendString("set media time format milliseconds",TemStr,TemStr.Length,0);
                    mc.state=State.mStop;
                } catch {
                }
            }
        }
        public void Play() {
            TemStr="";
            TemStr=TemStr.PadLeft(sbyte.MaxValue,Convert.ToChar(" "));
            APIClass.mciSendString("play media",TemStr,TemStr.Length,0);
            mc.state=State.mPlaying;
        }
        public void PlayRepeat() {
            TemStr="";
            TemStr=TemStr.PadLeft(sbyte.MaxValue,Convert.ToChar(" "));
            APIClass.mciSendString("play media repeat",TemStr,TemStr.Length,0);
            mc.state=State.mPlaying;
        }
        public void Stop() {
            TemStr="";
            TemStr=TemStr.PadLeft(128,Convert.ToChar(" "));
            ilong=APIClass.mciSendString("close media",TemStr,128,0);
            ilong=APIClass.mciSendString("close all",TemStr,128,0);
            mc.state=State.mStop;
        }
        public void Puase() {
            TemStr="";
            TemStr=TemStr.PadLeft(128,Convert.ToChar(" "));
            ilong=APIClass.mciSendString("pause media",TemStr,TemStr.Length,0);
            mc.state=State.mPuase;
        }
        public void Resume() {
            if(mc.state!=State.mPuase) return;
            TemStr="";
            TemStr=TemStr.PadLeft(sbyte.MaxValue,Convert.ToChar(" "));
            ilong=APIClass.mciSendString("resume media",TemStr,TemStr.Length,0);
            mc.state=State.mPlaying;
        }
        public void SetStartEnd(int t1,int t2) {
            TemStr="";
            TemStr=TemStr.PadLeft(128,Convert.ToChar(" "));
            APIClass.mciSendString("play media from "+t1.ToString()+" to "+t2.ToString()+" repeat",TemStr,TemStr.Length,0);
        }
        public void SetStartEnd(float t1,float t2) => SetStartEnd((int)t1*1000,(int)t2*1000);
        private string GetCurrPath(string name) {
            if(name.Length<1) return "";
            name=name.Trim();
            name=name.Substring(0,name.Length-1);
            return name;
        }
        public int Duration {
            get {
                durLength="";
                durLength=durLength.PadLeft(128,Convert.ToChar(" "));
                APIClass.mciSendString("status media length",durLength,durLength.Length,0);
                durLength=durLength.Trim();
                if(durLength=="") return 0;
                return (int)(Convert.ToDouble(durLength)/1000.0);
            }
        }
        public int CurrentPosition {
            get {
                durLength="";
                durLength=durLength.PadLeft(128,Convert.ToChar(" "));
                APIClass.mciSendString("status media position",durLength,durLength.Length,0);
                mc.iPos=(int)Convert.ToDouble(durLength.Replace("\0",""));
                return mc.iPos;
            }
        }
        public int Volumn {
            get => volumn;
            set {
                volumn=value>=0 ? (value<=100 ? value : 100) : 0;
                TemStr="";
                TemStr=TemStr.PadLeft(sbyte.MaxValue,Convert.ToChar(" "));
                APIClass.mciSendString("setaudio media volume to "+(value*10).ToString(),TemStr,TemStr.Length,0);
            }
        }
        public enum State {
            mPlaying = 1,
            mPuase = 2,
            mStop = 3,
        }
        public struct structMCI {
            public bool bMut;
            public int iDur;
            public int iPos;
            public int iVol;
            public int iBal;
            public string iName;
            public State state;
        }
    }
}
