using System.Collections.Generic;
using System.Drawing;

namespace Shooting {
    internal class MenuOption:BaseMenuGroup {
        private BaseNum BGMvolumn;
        private BaseNum SEvolumn;
        public MenuOption(StageDataPackage StageData) : base(StageData) {
            MenuSelectIndex=0;
            MenuItemList=new List<BaseMenuItem>(){
                new BaseMenuItem(StageData, "Menu_BGM_Vol"),
                new BaseMenuItem(StageData, "Menu_SE_Vol"),
                new BaseMenuItem(StageData, "Menu_Quit")
              };
            int num1 = 220;
            int num2 = 220;
            int num3 = -200;
            foreach(BaseMenuItem menuItem in MenuItemList) {
                menuItem.DestPoint=new PointF(num1,num2);
                menuItem.Position=new PointF((num1+num3),140f);
                num2+=24;
                num3-=50;
            }
            StageDataPackage StageData1 = StageData;
            PointF destPoint = MenuItemList[0].DestPoint;
            double num4 = destPoint.X+130.0;
            destPoint=MenuItemList[0].DestPoint;
            double num5 = destPoint.Y+16.0;
            PointF Position = new PointF((float)num4,(float)num5);
            BGMvolumn=new BaseNum(StageData1,Position) {
                Num=BGM_Player.Volume,
                Count=3
            };
            SEvolumn=new BaseNum(StageData,new PointF(MenuItemList[1].DestPoint.X+130f,MenuItemList[1].DestPoint.Y+16f)) {
                Num=StageData.GlobalData.SEVolume,
                Count=3
            };
            MenuItemList[MenuSelectIndex].Selected=true;
        }
        public override void ProcessKeys() {
            base.ProcessKeys();
            if(KClass.Key_Z&&LastZ==0) {
                switch(MenuItemList[MenuSelectIndex].Name) {
                    case "Menu_Quit":
                        OnRemoveMenu=TimeMain+20;
                        TransparentVelocity=-15f;
                        using(List<BaseMenuItem>.Enumerator enumerator = MenuItemList.GetEnumerator()) {
                            while(enumerator.MoveNext()) {
                                BaseMenuItem current = enumerator.Current;
                                current.DestPoint=new PointF(60f,160f);
                                current.OnRemove=true;
                            }
                            goto case "Menu_BGM_Vol";
                        }
                    case "Menu_BGM_Vol":
                    case "Menu_SE_Vol":
                        StageData.SoundPlay("se_ok00.wav");
                        break;
                    default:
                        StageData.StateSwitchData=new StateSwitchDataPackage() {
                            NextState="此功能尚未开通",
                            NeedInit=true,
                            SDPswitch=StageData
                        };
                        goto case "Menu_BGM_Vol";
                }
            }
            if((KClass.Key_X||KClass.Key_ESC)&&LastX==0) {
                MenuSelectIndex=MenuItemList.Count-1;
                SelectItemChanged();
                StageData.SoundPlay("se_cancel00.wav");
            }
            if(KClass.ArrowRight&&(LastRight==0||LastRight>30)) {
                switch(MenuItemList[MenuSelectIndex].Name) {
                    case "Menu_BGM_Vol":
                        BGM_Player.Volume+=5;
                        BGMvolumn.Num=BGM_Player.Volume;
                        break;
                    case "Menu_SE_Vol":
                        foreach(XAudio2_Player xaudio2Player in StageData.SoundDictionary.Values) {
                            xaudio2Player.Volume+=5;
                            SEvolumn.Num=xaudio2Player.Volume;
                        }
                        StageData.SoundPlay("se_ok00.wav");
                        break;
                }
                LastSelectTime=TimeMain;
                StageData.GlobalData.BGMVolume=BGM_Player.Volume;
                StageData.GlobalData.SEVolume=SEvolumn.Num;
            }
            if(!KClass.ArrowLeft||LastLeft!=0&&LastLeft<=30) return;
            switch(MenuItemList[MenuSelectIndex].Name) {
                case "Menu_BGM_Vol":
                    BGM_Player.Volume-=5;
                    BGMvolumn.Num=BGM_Player.Volume;
                    break;
                case "Menu_SE_Vol":
                    foreach(XAudio2_Player xaudio2Player in StageData.SoundDictionary.Values) {
                        xaudio2Player.Volume-=5;
                        SEvolumn.Num=xaudio2Player.Volume;
                    }
                    StageData.SoundPlay("se_ok00.wav");
                    break;
            }
            LastSelectTime=TimeMain;
            StageData.GlobalData.BGMVolume=BGM_Player.Volume;
            StageData.GlobalData.SEVolume=SEvolumn.Num;
        }
        public override void Show() {
            base.Show();
            BGMvolumn.Show();
            SEvolumn.Show();
        }
    }
}
