using System.Collections.Generic;
using System.Drawing;

namespace Shooting {
    internal class MenuGroup_GameOver:BaseMenuGroup {
        public MenuGroup_GameOver(StageDataPackage StageData) {
            this.StageData=StageData;
            MenuSelectIndex=0;
            MenuItemList=new List<BaseMenuItem>();
            if(!StageData.GlobalData.LastState.StageData.OnReplay) {
                MenuItemList.Add(new BaseMenuItem(StageData,"Menu_再试一次"));
                if(StageData.GlobalData.LastState.StageData.ContinueTimes==0) MenuItemList.Add(new BaseMenuItem(StageData,"Menu_保存录像"));
            } else {
                StageData.OnReplay=false;
            }
            MenuItemList.Add(new BaseMenuItem(StageData,"Menu_返回主菜单"));
            MenuItemList.Add(new BaseMenuItem(StageData,"Menu_从头开始"));
            int num1 = 62;
            int num2 = 300;
            int num3 = -200;
            foreach(BaseMenuItem menuItem in MenuItemList) {
                menuItem.DestPoint=new PointF(num1,num2);
                menuItem.Position=new PointF(num1+num3,150f);
                num2+=30;
                num3-=50;
            }
            MenuItemList[MenuSelectIndex].Selected=true;
            BackgroundRotate backgroundRotate = new BackgroundRotate(StageData,"Menu_图案") {
                OriginalPosition=new PointF(120f,340f),
                Scale=1f,
                TransparentValueF=0.0f,
                TransparentVelocity=10f
            };
        }
        public override void ProcessKeys() {
            base.ProcessKeys();
            if(!KClass.Key_Z||LastZ!=0) return;
            MenuItemList[MenuSelectIndex].Click();
            OnChangeMenu=TimeMain+20;
            StageData.SoundPlay("se_ok00.wav");
        }
        public override void ProcessZ() {
            switch(MenuItemList[MenuSelectIndex].Name) {
                case "Menu_继续游戏":
                    StageData.StateSwitchData=new StateSwitchDataPackage() {
                        NextState=StageData.GlobalData.LastState.StageName,
                        NeedInit=false
                    };
                    ((BaseGameState)StageData.GlobalData.LastState).TimeSycn();
                    break;
                case "Menu_再试一次":
                    if(StageData.GlobalData.LastState==null) break;
                    ++StageData.GlobalData.LastState.StageData.ContinueTimes;
                    StageData.GlobalData.LastState.StageData.MyPlane.RetryClear();
                    StageData.StateSwitchData=new StateSwitchDataPackage() {
                        NextState=StageData.GlobalData.LastState.StageName,
                        NeedInit=false
                    };
                    StageData.Rep.Dispose();
                    StageData.Rep.CreatRpy();
                    break;
                case "Menu_保存录像":
                    StageData.MenuGroupList.Add(new MenuGroup_ReplaySaver(StageData,new PointF(36f,16f)));
                    break;
                case "Menu_从头开始":
                    if(StageData.GlobalData.LastState==null) break;
                    bool onReplay = StageData.GlobalData.LastState.StageData.OnReplay;
                    bool onPractice = StageData.GlobalData.LastState.StageData.OnPractice;
                    ReplayInfo repInfo = StageData.GlobalData.LastState.StageData.RepInfo;
                    StageData.StateSwitchData=new StateSwitchDataPackage() {
                        NextState=StageData.GlobalData.LastState.StageData.RepInfo.StartStage,
                        NeedInit=true,
                        SDPswitch=new StageDataPackage(StageData.GlobalData) {
                            Difficulty=repInfo.Rank,
                            OnReplay=onReplay
                        }
                    };
                    int index = 0;
                    Point point = new Point(192,398);
                    if(index>=0) point=new Point((int)repInfo.MyPlaneData[index].PosX,(int)repInfo.MyPlaneData[index].PosY);
                    BaseMyPlane baseMyPlane;
                    switch(repInfo.MyPlaneName) {
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
                            baseMyPlane=new MyPlane_Reimu(StageData.StateSwitchData.SDPswitch,point);
                            break;
                    }
                    if(index>=0) {
                        baseMyPlane.LifeUpCount=SourseForm.lifeUpCount;
                        baseMyPlane.Life=SourseForm.life;
                        baseMyPlane.LifeChip=SourseForm.lifeChip;
                        baseMyPlane.Spell=SourseForm.spell;
                        baseMyPlane.SpellChip=SourseForm.spellChip;
                        baseMyPlane.Power=SourseForm.power;
                        baseMyPlane.HighItemScore=SourseForm.highItemScore;
                        baseMyPlane.StarPoint=SourseForm.starPoint;
                        baseMyPlane.LastColor=SourseForm.starColor;
                        baseMyPlane.Score=SourseForm.score;

                        //  baseMyPlane.Life = repInfo.MyPlaneData[index].Life;
                        //  baseMyPlane.Spell = repInfo.MyPlaneData[index].Spell;
                        //  baseMyPlane.Power = repInfo.MyPlaneData[index].Power;
                        //  baseMyPlane.Score = repInfo.MyPlaneData[index].Score;
                        //  baseMyPlane.OriginalPosition = new PointF(repInfo.MyPlaneData[index].PosX, repInfo.MyPlaneData[index].PosY);
                        StageData.Rep.DataPosition=repInfo.MyPlaneData[index].DataPosition;
                    }
                    StageData.StateSwitchData.SDPswitch.MyPlane=baseMyPlane;
                    StageData.StateSwitchData.SDPswitch.OnPractice=onPractice;
                    if(!onReplay) {
                        StageData.Rep.Dispose();
                        StageData.Rep.CreatRpy();
                    } else {
                        StageData.Rep.DataPosition=0L;
                    }
                    if(!onReplay) {
                        StageData.StateSwitchData.SDPswitch.SetReplayInfo(StageData.StateSwitchData.NextState);
                    } else {
                        StageData.StateSwitchData.SDPswitch.RepInfo=repInfo;
                    }
                    break;
                case "Menu_返回主菜单":
                    StageData.StateSwitchData=new StateSwitchDataPackage() {
                        NextState="MainMenu",
                        NeedInit=true,
                        SDPswitch=new StageDataPackage(StageData.GlobalData)
                    };
                    StageData.Rep.CloseRpy();
                    break;
            }
        }
    }
}
