// Decompiled with JetBrains decompiler
// Type: Shooting.MenuGroup_GameOver
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Collections.Generic;
using System.Drawing;

namespace Shooting {
    internal class MenuGroup_GameOver:BaseMenuGroup {
        public MenuGroup_GameOver(StageDataPackage StageData) {
            this.StageData=StageData;
            this.MenuSelectIndex=0;
            this.MenuItemList=new List<BaseMenuItem>();
            if(!StageData.GlobalData.LastState.StageData.OnReplay) {
                this.MenuItemList.Add(new BaseMenuItem(StageData,"Menu_再试一次"));
                if(StageData.GlobalData.LastState.StageData.ContinueTimes==0)
                    this.MenuItemList.Add(new BaseMenuItem(StageData,"Menu_保存录像"));
            } else
                StageData.OnReplay=false;
            this.MenuItemList.Add(new BaseMenuItem(StageData,"Menu_返回主菜单"));
            this.MenuItemList.Add(new BaseMenuItem(StageData,"Menu_从头开始"));
            int num1 = 62;
            int num2 = 300;
            int num3 = -200;
            foreach(BaseMenuItem menuItem in this.MenuItemList) {
                menuItem.DestPoint=new PointF((float)num1,(float)num2);
                menuItem.Position=new PointF((float)(num1+num3),150f);
                num2+=30;
                num3-=50;
            }
            this.MenuItemList[this.MenuSelectIndex].Selected=true;
            BackgroundRotate backgroundRotate = new BackgroundRotate(StageData,"Menu_图案");
            backgroundRotate.OriginalPosition=new PointF(120f,340f);
            backgroundRotate.Scale=1f;
            backgroundRotate.TransparentValueF=0.0f;
            backgroundRotate.TransparentVelocity=10f;
        }

        public override void ProcessKeys() {
            base.ProcessKeys();
            if(!this.KClass.Key_Z||this.LastZ!=0)
                return;
            this.MenuItemList[this.MenuSelectIndex].Click();
            this.OnChangeMenu=this.TimeMain+20;
            this.StageData.SoundPlay("se_ok00.wav");
        }

        public override void ProcessZ() {
            switch(this.MenuItemList[this.MenuSelectIndex].Name) {
                case "Menu_继续游戏":
                    this.StageData.StateSwitchData=new StateSwitchDataPackage() {
                        NextState=this.StageData.GlobalData.LastState.StageName,
                        NeedInit=false
                    };
                    ((BaseGameState)this.StageData.GlobalData.LastState).TimeSycn();
                    break;
                case "Menu_再试一次":
                    if(this.StageData.GlobalData.LastState==null)
                        break;
                    ++this.StageData.GlobalData.LastState.StageData.ContinueTimes;
                    this.StageData.GlobalData.LastState.StageData.MyPlane.RetryClear();
                    this.StageData.StateSwitchData=new StateSwitchDataPackage() {
                        NextState=this.StageData.GlobalData.LastState.StageName,
                        NeedInit=false
                    };
                    this.StageData.Rep.Dispose();
                    this.StageData.Rep.CreatRpy();
                    break;
                case "Menu_保存录像":
                    this.StageData.MenuGroupList.Add((BaseMenuGroup)new MenuGroup_ReplaySaver(this.StageData,new PointF(36f,16f)));
                    break;
                case "Menu_从头开始":
                    if(this.StageData.GlobalData.LastState==null)
                        break;
                    bool onReplay = this.StageData.GlobalData.LastState.StageData.OnReplay;
                    bool onPractice = this.StageData.GlobalData.LastState.StageData.OnPractice;
                    ReplayInfo repInfo = this.StageData.GlobalData.LastState.StageData.RepInfo;
                    this.StageData.StateSwitchData=new StateSwitchDataPackage() {
                        NextState=this.StageData.GlobalData.LastState.StageData.RepInfo.StartStage,
                        NeedInit=true,
                        SDPswitch=new StageDataPackage(this.StageData.GlobalData) {
                            Difficulty=repInfo.Rank,
                            OnReplay=onReplay
                        }
                    };
                    int index = 0;
                    Point point = new Point(192,398);
                    if(index>=0)
                        point=new Point((int)repInfo.MyPlaneData[index].PosX,(int)repInfo.MyPlaneData[index].PosY);
                    BaseMyPlane baseMyPlane;
                    switch(repInfo.MyPlaneName) {
                        case "Aya":
                            switch(repInfo.WeaponType) {
                                case "A":
                                    baseMyPlane=(BaseMyPlane)new MyPlane_Aya(this.StageData.StateSwitchData.SDPswitch,point);
                                    break;
                                case "B":
                                    baseMyPlane=(BaseMyPlane)new MyPlane_AyaB(this.StageData.StateSwitchData.SDPswitch,point);
                                    break;
                                default:
                                    baseMyPlane=(BaseMyPlane)new MyPlane_Aya(this.StageData.StateSwitchData.SDPswitch,point);
                                    break;
                            }
                            break;
                        case "Plane":
                            switch(repInfo.WeaponType) {
                                case "A":
                                    baseMyPlane=(BaseMyPlane)new AutoPlane(this.StageData.StateSwitchData.SDPswitch,point);
                                    break;
                                case "B":
                                    baseMyPlane=(BaseMyPlane)new MyPlane_PlaneB(this.StageData.StateSwitchData.SDPswitch,point);
                                    break;
                                default:
                                    baseMyPlane=new BaseMyPlane(this.StageData.StateSwitchData.SDPswitch,point);
                                    break;
                            }
                            break;
                        case "Reimu":
                            baseMyPlane=(BaseMyPlane)new MyPlane_Reimu(this.StageData.StateSwitchData.SDPswitch,point);
                            break;
                        case "Sanae":
                            baseMyPlane=(BaseMyPlane)new MyPlane_Sanae(this.StageData.StateSwitchData.SDPswitch,point);
                            break;
                        case "Marisa":
                            baseMyPlane=(BaseMyPlane)new MyPlane_Marisa(this.StageData.StateSwitchData.SDPswitch,point);
                            break;
                        case "Koishi":
                            baseMyPlane=(BaseMyPlane)new MyPlane_Koishi(this.StageData.StateSwitchData.SDPswitch,point);
                            break;
                        default:
                            baseMyPlane=(BaseMyPlane)new MyPlane_Aya(this.StageData.StateSwitchData.SDPswitch,point);
                            break;
                    }
                    if(index>=0) {
                        //         baseMyPlane.LifeUpCount=SourseForm.lifeUpCount;
                        //         baseMyPlane.Life=SourseForm.life;
                        //         baseMyPlane.LifeChip=SourseForm.lifeChip;
                        //         baseMyPlane.Spell=SourseForm.spell;
                        //         baseMyPlane.SpellChip=SourseForm.spellChip;
                        //         baseMyPlane.Power=SourseForm.power;
                        //         baseMyPlane.HighItemScore=SourseForm.highItemScore;
                        //         baseMyPlane.StarPoint=SourseForm.starPoint;
                        //         baseMyPlane.LastColor=SourseForm.starColor;
                        //         baseMyPlane.Score=SourseForm.score;

                        baseMyPlane.Life=repInfo.MyPlaneData[index].Life;
                        baseMyPlane.Spell=repInfo.MyPlaneData[index].Spell;
                        baseMyPlane.Power=repInfo.MyPlaneData[index].Power;
                        baseMyPlane.Score=repInfo.MyPlaneData[index].Score;
                        baseMyPlane.OriginalPosition=new PointF(repInfo.MyPlaneData[index].PosX,repInfo.MyPlaneData[index].PosY);
                        this.StageData.Rep.DataPosition=repInfo.MyPlaneData[index].DataPosition;
                    }
                    this.StageData.StateSwitchData.SDPswitch.MyPlane=baseMyPlane;
                    this.StageData.StateSwitchData.SDPswitch.OnPractice=onPractice;
                    if(!onReplay) {
                        this.StageData.Rep.Dispose();
                        this.StageData.Rep.CreatRpy();
                    } else
                        this.StageData.Rep.DataPosition=0L;
                    if(!onReplay)
                        this.StageData.StateSwitchData.SDPswitch.SetReplayInfo(this.StageData.StateSwitchData.NextState);
                    else
                        this.StageData.StateSwitchData.SDPswitch.RepInfo=repInfo;
                    break;
                case "Menu_返回主菜单":
                    this.StageData.StateSwitchData=new StateSwitchDataPackage() {
                        NextState="MainMenu",
                        NeedInit=true,
                        SDPswitch=new StageDataPackage(this.StageData.GlobalData)
                    };
                    this.StageData.Rep.CloseRpy();
                    break;
            }
        }
    }
}
