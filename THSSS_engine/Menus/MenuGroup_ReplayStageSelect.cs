using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Shooting {
    internal class MenuGroup_ReplayStageSelect:BaseMenuGroup {
        private const string NullDescription = "----------";
        private string RepIndex;
        public MenuGroup_ReplayStageSelect(StageDataPackage StageData,PointF OriginalPosition,DescriptionMenuItem RepMenuItem) : base(StageData) {
            RepIndex=RepMenuItem.Name;
            MenuSelectIndex=0;
            MenuItemList=new List<BaseMenuItem>();
            for(int index = 0;index<6;++index)
                MenuItemList.Add(new DescriptionMenuItem(StageData,string.Format("Stage{0:00}",(object)(index+1))) {
                    Description="----------"
                });
            MenuItemList.Add(new DescriptionMenuItem(StageData,"StageEx") {
                Description="----------"
            });
            float x = OriginalPosition.X+12f;
            float y = OriginalPosition.Y+12f;
            foreach(BaseMenuItem menuItem in MenuItemList) {
                menuItem.Position=new PointF(x,OriginalPosition.Y+10f);
                menuItem.DestPoint=new PointF(x,y);
                y+=17f;
            }
            string str = ".\\Replay\\thSSS_"+RepIndex+".rpy";
            if(File.Exists(str)) {
                ReplayInfo replayInfo = Replay.ReadTitle(str);
                if(replayInfo.StartStage=="StEx") {
                    ((DescriptionMenuItem)MenuItemList[6]).Description=replayInfo.MyPlaneData[1].Score.ToString().PadLeft(10);
                } else {
                    int num = !replayInfo.StartStage.Contains("St") ? Convert.ToInt32(replayInfo.StartStage.Replace("Bs","")) : Convert.ToInt32(replayInfo.StartStage.Replace("St",""));
                    for(int index = 0;index<replayInfo.MyPlaneData.Count-1;++index) {
                        if(num-1+index<6) ((DescriptionMenuItem)MenuItemList[num-1+index]).Description=replayInfo.MyPlaneData[index+1].Score.ToString().PadLeft(10);
                    }
                }
            }
            MenuItemList[MenuSelectIndex].Selected=true;
            DescriptionMenuItem descriptionMenuItem = new DescriptionMenuItem(StageData,RepIndex) {
                Description=RepMenuItem.Description,
                OriginalPosition=RepMenuItem.OriginalPosition,
                Selected=true
            };
            MenuTilte=descriptionMenuItem;
            MenuTitlePos1=new PointF(RepMenuItem.OriginalPosition.X,16f);
            MenuTitlePos2=RepMenuItem.OriginalPosition;
            TxtureObject=TextureObjectDictionary["MenuBackground"];
            OriginalPosition=new PointF((BoundRect.Width/2),(BoundRect.Height/2));
            AngleDegree=90.0;
            ColorValue=Color.SkyBlue;
        }
        public override void ProcessKeys() {
            base.ProcessKeys();
            if(KClass.Key_Z&&LastZ==0) {
                MenuItemList[MenuSelectIndex].Click();
                OnChangeMenu=TimeMain+1;
            }
            if(!KClass.Key_X&&!KClass.Key_ESC||LastX!=0)
                return;
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
            if(!(((DescriptionMenuItem)MenuItemList[MenuSelectIndex]).Description!="----------"))
                return;
            StageData.SoundPlay("se_ok00.wav");
            string fileName = ".\\Replay\\thSSS_"+RepIndex+".rpy";
            StageData.Rep.LoadRpy(fileName);
            ReplayInfo replayInfo = Replay.ReadTitle(fileName);
            StageData.RepInfo=replayInfo;
            int num;
            string str;
            if(MenuSelectIndex<6) {
                if(replayInfo.StartStage.Contains("St")) {
                    num=MenuSelectIndex+1;
                    str="St"+num.ToString();
                } else {
                    num=MenuSelectIndex+1;
                    str="Bs"+num.ToString();
                }
            } else {
                str="StEx";
            }
            StageData.StateSwitchData=new StateSwitchDataPackage() {
                NextState=str,
                NeedInit=true,
                SDPswitch=new StageDataPackage(StageData.GlobalData) {
                    OnReplay=true,
                    Difficulty=replayInfo.Rank
                }
            };
            int index = !(str=="StEx") ? (!replayInfo.StartStage.Contains("St") ? MenuSelectIndex-Convert.ToInt32(replayInfo.StartStage.Replace("Bs",""))+1 : MenuSelectIndex-Convert.ToInt32(replayInfo.StartStage.Replace("St",""))+1) : 0;
            Point point = new Point(192,398);
            if(index>=0) point=new Point((int)replayInfo.MyPlaneData[index].PosX,(int)replayInfo.MyPlaneData[index].PosY);
            BaseMyPlane baseMyPlane;
            switch(replayInfo.MyPlaneName) {
                case "Reimu":
                    baseMyPlane=new MyPlane_Reimu(StageData.StateSwitchData.SDPswitch,point);
                    break;
                case "Sanae":
                    baseMyPlane=new MyPlane_Sanae(StageData.StateSwitchData.SDPswitch,point);
                    break;
                case "Marisa":
                    baseMyPlane=new MyPlane_Marisa(StageData.StateSwitchData.SDPswitch,point);
                    break;
                case "Koishi":
                    baseMyPlane=new MyPlane_Koishi(StageData.StateSwitchData.SDPswitch,point);
                    break;
                default:
                    baseMyPlane=new BaseMyPlane(StageData.StateSwitchData.SDPswitch,point);
                    break;
            }
            if(index>=0) {
                baseMyPlane.Life=replayInfo.MyPlaneData[index].Life;
                baseMyPlane.Spell=replayInfo.MyPlaneData[index].Spell;
                baseMyPlane.Power=replayInfo.MyPlaneData[index].Power;
                baseMyPlane.Score=replayInfo.MyPlaneData[index].Score;
                baseMyPlane.OriginalPosition=new PointF(replayInfo.MyPlaneData[index].PosX,replayInfo.MyPlaneData[index].PosY);
                baseMyPlane.Graze=replayInfo.MyPlaneData[index].Graze;
                baseMyPlane.LifeUpCount=replayInfo.MyPlaneData[index].LifeUpCount;
                baseMyPlane.LifeChip=replayInfo.MyPlaneData[index].LifeChip;
                baseMyPlane.SpellChip=replayInfo.MyPlaneData[index].SpellChip;
                baseMyPlane.StarPoint=replayInfo.MyPlaneData[index].StarPoint;
                baseMyPlane.HighItemScore=replayInfo.MyPlaneData[index].HighItemScore;
                baseMyPlane.Rate=replayInfo.MyPlaneData[index].Rate;
                baseMyPlane.LastColor=replayInfo.MyPlaneData[index].LastColor;
                StageData.Rep.DataPosition=replayInfo.MyPlaneData[index].DataPosition;
            }
            StageData.StateSwitchData.SDPswitch.MyPlane=baseMyPlane;
            StageData.StateSwitchData.SDPswitch.RepInfo=replayInfo;
        }
    }
}
