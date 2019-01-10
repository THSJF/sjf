using System;

namespace Shooting {
    [Serializable]
    public class Event {
        public string EventString;
        public float rand;
        public int special;
        public int special2;
        public string condition;
        public string condition2;
        public string result;
        public int contype;
        public int contype2;
        public string opreator;
        public string opreator2;
        public string collector;
        public int change;
        public int changetype;
        public int changevalue;
        public int changename;
        public float res;
        public int times;
        public int time;
        public bool noloop;
        public void String2EmitterEvent() {
            string eventString = EventString;
            string str1 = eventString.Split('：')[0];
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            string str7 = eventString.Split('：')[1];
            float num1 = 0.0f;
            int num2 = 0;
            if(eventString.Contains("且")) {
                str6="且";
                str2=str1.Split("且".ToCharArray())[1];
                str1=str1.Split("且".ToCharArray())[0];
            } else if(eventString.Contains("或")) {
                str6="或";
                str2=str1.Split("或".ToCharArray())[1];
                str1=str1.Split("或".ToCharArray())[0];
            }
            if(str1.Contains(">")) {
                str3=str1.Split('>')[0];
                str4=">";
                str1=str1.Split('>')[1];
            } else if(str1.Contains("=")) {
                str3=str1.Split('=')[0];
                str4="=";
                str1=str1.Split('=')[1];
            } else if(str1.Contains("<")) {
                str3=str1.Split('<')[0];
                str4="<";
                str1=str1.Split('<')[1];
            }
            if(str2.Contains(">")) {
                string str8 = str2.Split('>')[0];
                str5=">";
                str2=str2.Split('>')[1];
            } else if(str2.Contains("=")) {
                string str8 = str2.Split('=')[0];
                str5="=";
                str2=str2.Split('=')[1];
            } else if(str2.Contains("<")) {
                string str8 = str2.Split('<')[0];
                str5="<";
                str2=str2.Split('<')[1];
            }
            if(eventString.Contains("变化到")) {
                int num3 = 0;
                string[] strArray = str7.Split("变".ToCharArray())[1].Split("，".ToCharArray());
                int result = (int)Hash.results[str7.Split("变".ToCharArray())[0]];
                string str8 = str7.Split("变".ToCharArray())[0];
                if(strArray[0].Replace("化到","").Contains("+")) {
                    if(strArray[0].Replace("化到","").Split('+')[0]=="自身") {
                        num2=3;
                    } else if(strArray[0].Replace("化到","").Split('+')[0]=="自机") {
                        num2=4;
                    } else {
                        num1=float.Parse(strArray[0].Replace("化到","").Split('+')[0]);
                    }
                } else if(strArray[0].Replace("化到","")=="自身") {
                    num2=3;
                } else if(strArray[0].Replace("化到","")=="自机") {
                    num2=4;
                } else {
                    num1=float.Parse(strArray[0].Replace("化到",""));
                }
                string str9 = strArray[1];
                int num4 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                condition=str1;
                this.result=str7;
                condition2=str2;
                contype=(int)Hash.conditions[str3];
                contype2=(int)Hash.conditions[str3];
                opreator=str4;
                opreator2=str5;
                collector=str6;
                change=num3;
                changetype=(int)Hash.type[str9];
                changevalue=result;
                changename=(int)Hash.results[str8];
                res=num1;
                special=num2;
                if(strArray[0].Replace("化到","").Contains("+")) {
                    rand=float.Parse(strArray[0].Replace("化到","").Split('+')[1]);
                }
                times=num4;
                if(!strArray[2].Contains("(")) return;
                time=int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
            } else if(eventString.Contains("增加")) {
                int num3 = 1;
                string[] strArray = str7.Split("增".ToCharArray())[1].Split("，".ToCharArray());
                strArray[0]=strArray[0].Replace("加","");
                int result = (int)Hash.results[str7.Split("增".ToCharArray())[0]];
                string str8 = str7.Split("增".ToCharArray())[0];
                if(strArray[0].Contains("+")) {
                    if(strArray[0].Split('+')[0]=="自身") {
                        num2=3;
                    } else if(strArray[0].Split('+')[0]=="自机") {
                        num2=4;
                    } else {
                        num1=float.Parse(strArray[0].Split('+')[0]);
                    }
                } else if(strArray[0]=="自身") {
                    num2=3;
                } else if(strArray[0]=="自机") {
                    num2=4;
                } else {
                    num1=float.Parse(strArray[0]);
                }
                string str9 = strArray[1];
                int num4 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                condition=str1;
                this.result=str7;
                condition2=str2;
                contype=(int)Hash.conditions[str3];
                contype2=(int)Hash.conditions[str3];
                opreator=str4;
                opreator2=str5;
                collector=str6;
                change=num3;
                changetype=(int)Hash.type[str9];
                changevalue=result;
                changename=(int)Hash.results[str8];
                res=num1;
                special=num2;
                if(strArray[0].Contains("+")) rand=float.Parse(strArray[0].Split('+')[1]);
                times=num4;
                if(!strArray[2].Contains("(")) return;
                time=int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
            } else if(eventString.Contains("减少")) {
                int num3 = 2;
                string[] strArray = str7.Split("减少".ToCharArray())[2].Split("，".ToCharArray());
                int result = (int)Hash.results[str7.Split("减少".ToCharArray())[0]];
                string str8 = str7.Split("减少".ToCharArray())[0];
                if(strArray[0].Contains("+")) {
                    if(strArray[0].Split('+')[0]=="自身") {
                        num2=3;
                    } else if(strArray[0].Split('+')[0]=="自机") {
                        num2=4;
                    } else {
                        num1=float.Parse(strArray[0].Split('+')[0]);
                    }
                } else if(strArray[0]=="自身") {
                    num2=3;
                } else if(strArray[0]=="自机") {
                    num2=4;
                } else {
                    num1=float.Parse(strArray[0]);
                }
                string str9 = strArray[1];
                int num4 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                condition=str1;
                this.result=str7;
                condition2=str2;
                contype=(int)Hash.conditions[str3];
                contype2=(int)Hash.conditions[str3];
                opreator=str4;
                opreator2=str5;
                collector=str6;
                change=num3;
                changetype=(int)Hash.type[str9];
                changevalue=result;
                changename=(int)Hash.results[str8];
                res=num1;
                special=num2;
                if(strArray[0].Contains("+")) rand=float.Parse(strArray[0].Split('+')[1]);
                times=num4;
                if(!strArray[2].Contains("(")) return;
                time=int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
            } else if(eventString.Contains("恢复")) {
                special=1;
                opreator=str4;
                opreator2=str5;
                condition=str1;
                condition2=str2;
                contype=(int)Hash.conditions[str3];
                contype2=(int)Hash.conditions[str3];
                collector=str6;
            } else if(eventString.Contains("发射")) {
                special=2;
                opreator=str4;
                opreator2=str5;
                condition=str1;
                condition2=str2;
                contype=(int)Hash.conditions[str3];
                contype2=(int)Hash.conditions[str3];
                collector=str6;
            }
        }
        public void String2BulletEvent() {
            string eventString = EventString;
            string str1 = eventString.Split('：')[0];
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            string str7 = eventString.Split('：')[1];
            float num1 = 0.0f;
            int num2 = 0;
            if(eventString.Contains("且")) {
                str6="且";
                str2=str1.Split("且".ToCharArray())[1];
                str1=str1.Split("且".ToCharArray())[0];
            } else if(eventString.Contains("或")) {
                str6="或";
                str2=str1.Split("或".ToCharArray())[1];
                str1=str1.Split("或".ToCharArray())[0];
            }
            if(str1.Contains(">")) {
                str3=str1.Split('>')[0];
                str4=">";
                str1=str1.Split('>')[1];
            } else if(str1.Contains("=")) {
                str3=str1.Split('=')[0];
                str4="=";
                str1=str1.Split('=')[1];
            } else if(str1.Contains("<")) {
                str3=str1.Split('<')[0];
                str4="<";
                str1=str1.Split('<')[1];
            }
            if(str2.Contains(">")) {
                string str8 = str2.Split('>')[0];
                str5=">";
                str2=str2.Split('>')[1];
            } else if(str2.Contains("=")) {
                string str8 = str2.Split('=')[0];
                str5="=";
                str2=str2.Split('=')[1];
            } else if(str2.Contains("<")) {
                string str8 = str2.Split('<')[0];
                str5="<";
                str2=str2.Split('<')[1];
            }
            if(eventString.Contains("变化到")) {
                int num3 = 0;
                string[] strArray = str7.Split("变".ToCharArray())[1].Split("，".ToCharArray());
                int num4 = (int)Hash.results2[str7.Split("变".ToCharArray())[0]];
                string str8 = str7.Split("变".ToCharArray())[0];
                if(strArray[0].Replace("化到","").Contains("+")) {
                    if(strArray[0].Replace("化到","").Split('+')[0]=="自身") {
                        num2=3;
                    } else if(strArray[0].Replace("化到","").Split('+')[0]=="自机") {
                        num2=4;
                    } else {
                        num1=float.Parse(strArray[0].Replace("化到","").Split('+')[0]);
                    }
                } else if(strArray[0].Replace("化到","")=="自身") {
                    num2=3;
                } else if(strArray[0].Replace("化到","")=="自机") {
                    num2=4;
                } else {
                    num1=float.Parse(strArray[0].Replace("化到",""));
                }
                string str9 = strArray[1];
                int num5 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                condition=str1;
                result=str7;
                condition2=str2;
                contype=(int)Hash.conditions2[str3];
                contype2=(int)Hash.conditions2[str3];
                opreator=str4;
                opreator2=str5;
                collector=str6;
                change=num3;
                changetype=(int)Hash.type[str9];
                changevalue=num4;
                changename=(int)Hash.results2[str8];
                res=num1;
                special=num2;
                if(strArray[0].Replace("化到","").Contains("+")) rand=float.Parse(strArray[0].Replace("化到","").Split('+')[1]);
                times=num5;
                if(!strArray[2].Contains("(")) return;
                time=int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
            } else if(eventString.Contains("增加")) {
                int num3 = 1;
                string[] strArray = str7.Split("增".ToCharArray())[1].Split("，".ToCharArray());
                strArray[0]=strArray[0].Replace("加","");
                int num4 = (int)Hash.results2[str7.Split("增".ToCharArray())[0]];
                string str8 = str7.Split("增".ToCharArray())[0];
                if(strArray[0].Contains("+")) {
                    if(strArray[0].Split('+')[0]=="自身") {
                        num2=3;
                    } else if(strArray[0].Split('+')[0]=="自机") {
                        num2=4;
                    } else {
                        num1=float.Parse(strArray[0].Split('+')[0]);
                    }
                } else if(strArray[0]=="自身") {
                    num2=3;
                } else if(strArray[0]=="自机") {
                    num2=4;
                } else {
                    num1=float.Parse(strArray[0]);
                }
                string str9 = strArray[1];
                int num5 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                condition=str1;
                result=str7;
                condition2=str2;
                contype=(int)Hash.conditions2[str3];
                contype2=(int)Hash.conditions2[str3];
                opreator=str4;
                opreator2=str5;
                collector=str6;
                change=num3;
                changetype=(int)Hash.type[str9];
                changevalue=num4;
                changename=(int)Hash.results2[str8];
                res=num1;
                special=num2;
                if(strArray[0].Contains("+")) rand=float.Parse(strArray[0].Split('+')[1]);
                times=num5;
                if(!strArray[2].Contains("(")) return;
                time=int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
            } else if(eventString.Contains("减少")) {
                int num3 = 2;
                string[] strArray = str7.Split("减少".ToCharArray())[2].Split("，".ToCharArray());
                int num4 = (int)Hash.results2[str7.Split("减少".ToCharArray())[0]];
                string str8 = str7.Split("减少".ToCharArray())[0];
                if(strArray[0].Contains("+")) {
                    if(strArray[0].Split('+')[0]=="自身") {
                        num2=3;
                    } else if(strArray[0].Split('+')[0]=="自机") {
                        num2=4;
                    } else {
                        num1=float.Parse(strArray[0].Split('+')[0]);
                    }
                } else if(strArray[0]=="自身") {
                    num2=3;
                } else if(strArray[0]=="自机") {
                    num2=4;
                } else {
                    num1=float.Parse(strArray[0]);
                }
                string str9 = strArray[1];
                int num5 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
                condition=str1;
                result=str7;
                condition2=str2;
                contype=(int)Hash.conditions2[str3];
                contype2=(int)Hash.conditions2[str3];
                opreator=str4;
                opreator2=str5;
                collector=str6;
                change=num3;
                changetype=(int)Hash.type[str9];
                changevalue=num4;
                changename=(int)Hash.results2[str8];
                res=num1;
                special=num2;
                if(strArray[0].Contains("+")) rand=float.Parse(strArray[0].Split('+')[1]);
                times=num5;
                if(!strArray[2].Contains("(")) return;
                time=int.Parse(strArray[2].Split('(')[1].Split(')')[0]);
            } else if(eventString.Contains("恢复")) {
                special=1;
                opreator=str4;
                opreator2=str5;
                condition=str1;
                condition2=str2;
                contype=(int)Hash.conditions2[str3];
                contype2=(int)Hash.conditions2[str3];
                collector=str6;
            } else if(eventString.Contains("发射")) {
                special=2;
                opreator=str4;
                opreator2=str5;
                condition=str1;
                condition2=str2;
                contype=(int)Hash.conditions2[str3];
                contype2=(int)Hash.conditions2[str3];
                collector=str6;
            }
        }
        public object Clone() => MemberwiseClone();
    }
}
