using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Shooting {
    internal class MenuGroup_ReplaySaver:BaseMenuGroup {
        public MenuGroup_ReplaySaver(StageDataPackage StageData,PointF OriginalPosition) : base(StageData) {
            this.OriginalPosition=OriginalPosition;
            MenuSelectIndex=0;
            MenuItemList=new List<BaseMenuItem>();
            for(int index = 0;index<25;++index) {
                MenuItemList.Add(new DescriptionMenuItem(StageData,string.Format("{0:00}",index+1)));
            }
            float x = OriginalPosition.X+12f;
            float y = OriginalPosition.Y+12f;
            foreach(BaseMenuItem menuItem in MenuItemList) {
                menuItem.Position=new PointF(x,(BoundRect.Top+10));
                menuItem.DestPoint=new PointF(x,y);
                y+=17f;
                ((DescriptionMenuItem)menuItem).Description=SetDescroption(".\\Replay\\thSSS_"+menuItem.Name+".rpy");
            }
            MenuItemList[MenuSelectIndex].Selected=true;
        }
        public virtual string SetDescroption(string fileName) {
            string str1 = "------- -------- ------ -- --- ";
            if(!File.Exists(fileName)) return str1;
            try {
                ReplayInfo replayInfo = Replay.ReadTitle(fileName);
                if(replayInfo.Version!="ver 1.00") return str1;
                string str2 = null;
                if(replayInfo!=null) {
                    string str3 = str2+(replayInfo.PlayerName==null ? "        " : replayInfo.PlayerName.PadRight(8))+(replayInfo.Date==null ? "       " : replayInfo.Date.PadRight(9))+(replayInfo.MyPlaneName==null ? "               " : replayInfo.MyPlaneName.PadRight(7));
                    switch(replayInfo.Rank) {
                        case DifficultLevel.Easy:
                            str3+="E  ";
                            break;
                        case DifficultLevel.Normal:
                            str3+="N  ";
                            break;
                        case DifficultLevel.Hard:
                            str3+="H  ";
                            break;
                        case DifficultLevel.Lunatic:
                            str3+="L  ";
                            break;
                        case DifficultLevel.Ultra:
                            str3+="U  ";
                            break;
                        case DifficultLevel.Extra:
                            str3+="EX ";
                            break;
                    }
                    str2=str3+(replayInfo.LastStage==null ? "   " : replayInfo.LastStage.PadRight(4));
                }
                return str2;
            } catch {
                return str1;
            }
        }
        public override void ProcessKeys() {
            base.ProcessKeys();
            ProcessKeys2();
        }
        public virtual void ProcessKeys2() {
            if(KClass.Key_Z&&LastZ==0) {
                MenuItemList[MenuSelectIndex].Click();
                OnChangeMenu=TimeMain+1;
            }
            if(!KClass.Key_X&&!KClass.Key_ESC||LastX!=0) return;
            StageData.SoundPlay("se_cancel00.wav");
            if(StageData.Rep.CanRead) {
                ReplayInfo repInfo = StageData.GlobalData.LastState.StageData.RepInfo;
                repInfo.PlayerName="autosave";
                StageData.Rep.SaveRpy(".\\Replay\\AutoSave.rpy",repInfo);
            }
            StageData.StateSwitchData=new StateSwitchDataPackage() {
                NextState="MainMenu",
                NeedInit=true,
                SDPswitch=new StageDataPackage(StageData.GlobalData)
            };
            StageData.Rep.CloseRpy();
        }
        public override void ProcessZ() {
            if(!StageData.Rep.CanRead) return;
            StageData.SoundPlay("se_ok00.wav");
            StageData.GlobalData.LastState.StageData.SetReplayStageInfo();
            StageData.MenuGroupList.Add(new MenuGroup_ReplayNamer(StageData,MenuItemList[0].OriginalPosition,(DescriptionMenuItem)MenuItemList[MenuSelectIndex]));
        }
    }
}
