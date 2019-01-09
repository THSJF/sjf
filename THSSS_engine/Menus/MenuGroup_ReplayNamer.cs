using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shooting {
    internal class MenuGroup_ReplayNamer:BaseMenuGroup {
        private int NameIndex = 0;
        private string[] PlayerName = new string[8];
        private string RepDescription = null;
        private DescriptionMenuItem RepMenuItem;
        public MenuGroup_ReplayNamer(StageDataPackage StageData,PointF OriginalPosition,DescriptionMenuItem RepMenuItem) : base(StageData) {
            this.RepMenuItem=RepMenuItem;
            MenuItemList=new List<BaseMenuItem>();
            StageDataPackage stageData = StageData.GlobalData.LastState.StageData;
            string[,] strArray = new string[7,13]{
                {"A","B","C","D","E","F","G","H","I","J","K","L","M"},
                {"N","O","P","Q","R","S","T","U","V","W","X","Y","Z"},
                {"a","b","c","d","e","f","g","h","i","j","k","l","m"},
                {"n","o","p","q","r","s","t","u","v","w","x","y","z"},
                {"0","1","2","3","4","5","6","7","8","9","+","-","="},
                {".",",","!","?","@",":",";","[","]","(",")","_","/"},
                {"{","}","|","~","^","#","$","%","&","*"," ","BS","OK"}
             };
            for(int index1 = 0;index1<7;++index1) {
                for(int index2 = 0;index2<13;++index2) {
                    BaseMenuItem baseMenuItem = new DescriptionMenuItem(StageData,strArray[index1,index2]);
                    baseMenuItem.OriginalPosition=new PointF((stageData.BoundRect.Left+stageData.BoundRect.Width/2-138),300f);
                    baseMenuItem.DestPoint=new PointF((stageData.BoundRect.Left+stageData.BoundRect.Width/2-138+index2*22),(270+index1*22));
                    MenuItemList.Add(baseMenuItem);
                }
            }
            MenuSelectIndex=MenuItemList.Count-1;
            ReplayInfo repInfo = StageData.GlobalData.LastState.StageData.RepInfo;
            RepDescription+=DateTime.Now.Date.ToString("yy'/'MM'/'dd").PadRight(9);
            RepDescription+=repInfo.MyPlaneName.PadRight(7);
            switch(repInfo.Rank) {
                case DifficultLevel.Easy:
                    RepDescription+="E  ";
                    break;
                case DifficultLevel.Normal:
                    RepDescription+="N  ";
                    break;
                case DifficultLevel.Hard:
                    RepDescription+="H  ";
                    break;
                case DifficultLevel.Lunatic:
                    RepDescription+="L  ";
                    break;
                case DifficultLevel.Ultra:
                    RepDescription+="U  ";
                    break;
                case DifficultLevel.Extra:
                    RepDescription+="EX ";
                    break;
            }
            RepDescription+=repInfo.LastStage==null ? "   " : repInfo.LastStage.PadRight(4);
            MenuItemList[MenuSelectIndex].Selected=true;
            DescriptionMenuItem descriptionMenuItem = new DescriptionMenuItem(StageData,RepMenuItem.Name) {
                Description="        "+RepDescription,
                OriginalPosition=RepMenuItem.OriginalPosition,
                Selected=true
            };
            MenuTilte=descriptionMenuItem;
            MenuTitlePos1=new PointF(OriginalPosition.X,OriginalPosition.Y);
            MenuTitlePos2=RepMenuItem.OriginalPosition;
            for(char[] charArray = stageData.PData.PlayerName.ToCharArray();NameIndex<charArray.Length;++NameIndex) {
                PlayerName[NameIndex]=charArray[NameIndex].ToString();
            }
            ShowPlayerName();
        }
        public override void ProcessKeys() {
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
            if(KClass.Key_X&&LastX==0) {
                if(NameIndex>0) {
                    --NameIndex;
                    PlayerName[NameIndex]=null;
                }
                StageData.SoundPlay("se_cancel00.wav");
                ShowPlayerName();
            }
            if(!KClass.Key_ESC) return;
            OnRemoveMenu=TimeMain+20;
            TransparentVelocity=-15f;
            foreach(BaseMenuItem menuItem in MenuItemList) {
                BaseMenuItem baseMenuItem = menuItem;
                PointF originalPosition = MenuItemList[0].OriginalPosition;
                double x = originalPosition.X;
                originalPosition=MenuItemList[0].OriginalPosition;
                double y = originalPosition.Y;
                PointF pointF = new PointF((float)x,(float)y);
                baseMenuItem.DestPoint=pointF;
                menuItem.OnRemove=true;
            }
            StageData.SoundPlay("se_cancel00.wav");
        }
        public override void ProcessZ() {
            if(MenuSelectIndex==MenuItemList.Count-1) {
                ReplayInfo repInfo = StageData.GlobalData.LastState.StageData.RepInfo;
                repInfo.PlayerName=(string)null;
                for(int index = 0;index<7;++index)
                    repInfo.PlayerName+=PlayerName[index];
                StageData.Rep.SaveRpy(".\\Replay\\thSSS_"+RepMenuItem.Name+".rpy",repInfo);
                RepMenuItem.Description=((DescriptionMenuItem)MenuTilte).Description;
                OnRemoveMenu=TimeMain+20;
                TransparentVelocity=-15f;
                foreach(BaseMenuItem menuItem in MenuItemList) {
                    BaseMenuItem baseMenuItem = menuItem;
                    PointF originalPosition = MenuItemList[0].OriginalPosition;
                    double x = originalPosition.X;
                    originalPosition=MenuItemList[0].OriginalPosition;
                    double y = originalPosition.Y;
                    PointF pointF = new PointF((float)x,(float)y);
                    baseMenuItem.DestPoint=pointF;
                    menuItem.OnRemove=true;
                }
                StageData.SoundPlay("se_extend.wav");
            } else if(MenuSelectIndex==MenuItemList.Count-2) {
                if(NameIndex>0) {
                    --NameIndex;
                    PlayerName[NameIndex]=null;
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
          ((DescriptionMenuItem)MenuTilte).Description=str.PadRight(8)+RepDescription;
            StageData.GlobalData.LastState.StageData.PData.PlayerName=str;
        }
    }
}
