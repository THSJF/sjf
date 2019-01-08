using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shooting {
    internal class MenuGroup_ScoreSaver:BaseMenuGroup {
        private int NameIndex = 0;
        private string[] PlayerName = new string[8];
        private int HistorySelectIndex = -1;
        private List<BaseMenuItem> ScoreHistorys;
        public MenuGroup_ScoreSaver(StageDataPackage StageData,PointF OriginalPosition) : base(StageData) {
            this.OriginalPosition=OriginalPosition;
            ScoreHistorys=new List<BaseMenuItem>();
            for(int index = 0;index<10;++index)
                ScoreHistorys.Add(new DescriptionMenuItem(StageData,string.Format("{0:00}",index+1)));
            StageDataPackage stageData = StageData.GlobalData.LastState.StageData;
            for(int index1 = 0;index1<stageData.S_History.Count;++index1) {
                if(stageData.MyPlane.Score>stageData.S_History[index1].Score) {
                    ScoreHistory scoreHistory1 = new ScoreHistory {
                        MyPlaneFullName=stageData.MyPlane.FullName,
                        Rank=stageData.Difficulty,
                        PlayerName="",
                        Score=stageData.MyPlane.Score
                    };
                    ScoreHistory scoreHistory2 = scoreHistory1;
                    DateTime dateTime = DateTime.Now;
                    dateTime=dateTime.Date;
                    string str = dateTime.ToString("yyyy'/'MM'/'dd");
                    scoreHistory2.Date=str;
                    scoreHistory1.Time=DateTime.Now.ToShortTimeString();
                    scoreHistory1.Stage=stageData.CurrentStageName;
                    scoreHistory1.SlowRate=stageData.SlowRate;
                    ScoreHistory SH = scoreHistory1;
                    for(int index2 = stageData.S_History.Count-1;index2>index1;--index2)
                        stageData.S_History[index2].Copy(stageData.S_History[index2-1]);
                    stageData.S_History[index1].Copy(SH);
                    HistorySelectIndex=index1;
                    break;
                }
            }
            float x = OriginalPosition.X+12f;
            float y = OriginalPosition.Y+30f;
            int num = 0;
            foreach(BaseMenuItem scoreHistory in ScoreHistorys) {
                scoreHistory.Position=new PointF(x,(BoundRect.Top+40));
                scoreHistory.DestPoint=new PointF(x,y);
                y+=17f;
                if(stageData.CurrentStageName.Contains("St"))
                    ((DescriptionMenuItem)scoreHistory).Description=stageData.S_History[num++].Data2DrawStringSimple();
                else
                    ((DescriptionMenuItem)scoreHistory).Description=stageData.S_History[num++].Data2DrawString();
            }
            if(HistorySelectIndex>=0) ScoreHistorys[HistorySelectIndex].Selected=true;
            string[,] strArray = new string[7,13]{
                {"A","B","C","D","E","F","G","H","I","J","K","L","M"},
                {"N","O","P","Q","R","S","T","U","V","W","X","Y","Z"},
                {"a","b","c","d","e","f","g","h","i","j","k","l","m"},
                {"n","o","p","q","r","s","t","u","v","w","x","y","z"},
                {"0","1","2","3","4","5","6","7","8","9","+","-","="},
                {".",",","!","?","@",":",";","[","]","(",")","_","/"},
                {"{","}","|","~","^","#","$","%","&","*"," ","BS","OK"}
             };
            MenuItemList=new List<BaseMenuItem>();
            for(int index1 = 0;index1<7;++index1) {
                for(int index2 = 0;index2<13;++index2) {
                    BaseMenuItem baseMenuItem = new DescriptionMenuItem(StageData,strArray[index1,index2]) {
                        OriginalPosition=new PointF((stageData.BoundRect.Left+stageData.BoundRect.Width/2-138),300f),
                        DestPoint=new PointF((stageData.BoundRect.Left+stageData.BoundRect.Width/2-138+index2*22),(270+index1*22))
                    };
                    MenuItemList.Add(baseMenuItem);
                }
            }
            MenuSelectIndex=MenuItemList.Count-1;
            if(MenuSelectIndex>=0) MenuItemList[MenuSelectIndex].Selected=true;
            for(char[] charArray = stageData.PData.PlayerName.ToCharArray();NameIndex<charArray.Length;++NameIndex) {
                PlayerName[NameIndex]=charArray[NameIndex].ToString();
            }
            ShowPlayerName();
        }
        public override void ProcessKeys() {
            ScoreHistorys.ForEach(x => x.Ctrl());
            if(KClass.ArrowDown&&(LastDown==0||LastDown>30)) {
                MenuSelectIndex+=13;
                StageData.SoundPlay("se_select00.wav");
                SelectItemChanged();
            }
            if(KClass.ArrowUp&&(LastUp==0||LastUp>30)) {
                MenuSelectIndex-=13;
                StageData.SoundPlay("se_select00.wav");
                SelectItemChanged();
            }
            if(KClass.ArrowLeft&&(LastLeft==0||LastLeft>30)) {
                --MenuSelectIndex;
                if((MenuSelectIndex+1)%13==0)
                    MenuSelectIndex+=13;
                StageData.SoundPlay("se_select00.wav");
                SelectItemChanged();
            }
            if(KClass.ArrowRight&&(LastRight==0||LastRight>30)) {
                ++MenuSelectIndex;
                if(MenuSelectIndex%13==0)
                    MenuSelectIndex-=13;
                StageData.SoundPlay("se_select00.wav");
                SelectItemChanged();
            }
            if(KClass.Key_Z&&LastZ==0) {
                MenuItemList[MenuSelectIndex].Click();
                OnChangeMenu=TimeMain+1;
            }
            if(!KClass.Key_X||LastX!=0) return;
            if(NameIndex>0) {
                --NameIndex;
                PlayerName[NameIndex]=null;
            }
            StageData.SoundPlay("se_cancel00.wav");
            ShowPlayerName();
        }
        public override void ProcessZ() {
            if(MenuSelectIndex==MenuItemList.Count-1) {
                OnRemoveMenu=TimeMain+20;
                TransparentVelocity=-15f;
                foreach(BaseMenuItem scoreHistory in ScoreHistorys) {
                    scoreHistory.DestPoint=new PointF(OriginalPosition.X+12f,OriginalPosition.Y+30f);
                    scoreHistory.OnRemove=true;
                }
                StageData.SoundPlay("se_ok00.wav");
            } else if(MenuSelectIndex==MenuItemList.Count-2) {
                if(NameIndex>0) {
                    --NameIndex;
                    PlayerName[NameIndex]=" ";
                }
                StageData.SoundPlay("se_cancel00.wav");
            } else {
                PlayerName[NameIndex]=MenuItemList[MenuSelectIndex].Name;
                StageData.SoundPlay("se_ok00.wav");
                if(NameIndex<7)
                    ++NameIndex;
            }
            ShowPlayerName();
        }
        private void ShowPlayerName() {
            string str = null;
            for(int index = 0;index<7;++index) {
                str+=PlayerName[index];
            }
            StageDataPackage stageData = StageData.GlobalData.LastState.StageData;
            if(HistorySelectIndex<0) stageData.S_History[HistorySelectIndex].PlayerName=str;
            stageData.PData.PlayerName=str;
            if(stageData.CurrentStageName.Contains("St")) {
                ((DescriptionMenuItem)ScoreHistorys[HistorySelectIndex]).Description=stageData.S_History[HistorySelectIndex].Data2DrawStringSimple();
            } else {
                ((DescriptionMenuItem)ScoreHistorys[HistorySelectIndex]).Description=stageData.S_History[HistorySelectIndex].Data2DrawString();
            }
        }
        public override void Show() {
            base.Show();
            if(ScoreHistorys.Count<=0) return;
            ScoreHistorys.ForEach(x => x.Show());
        }
    }
}
