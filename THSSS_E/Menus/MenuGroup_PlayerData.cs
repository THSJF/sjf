using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shooting {
    internal class MenuGroup_PlayerData:BaseMenuGroup {
        private int ScorePageIndex = 0;
        private List<BaseMenuItem> MenuItemListPlane;
        private int MenuPlaneSelectIndex;
        private List<DescriptionMenuItem> ScorePageList;
        private List<BaseMenuItem> ClearHistoryList;
        public MenuGroup_PlayerData(StageDataPackage StageData) : base(StageData) {
            TransparentValueF=0.0f;
            MaxTransparent=byte.MaxValue;
            TransparentVelocity=5f;
            TxtureObject=TextureObjectDictionary["MenuBackground"];
            Rectangle boundRect = BoundRect;
            double num1 = (boundRect.Width/2);
            boundRect=BoundRect;
            double num2 = (boundRect.Height/2);
            OriginalPosition=new PointF((float)num1,(float)num2);
            AngleDegree=90.0;
            ColorValue=Color.FromArgb(30,110,150);
            MenuTitlePos1=new PointF(140f,-30f);
            MenuTitlePos2=new PointF(140f,-150f);
            BaseMenuItem baseMenuItem1 = new BaseMenuItem(StageData,"MenuTitle_PlayerData") {
                Position=MenuTitlePos2
            };
            MenuTilte=baseMenuItem1;
            ClearHistoryList=new List<BaseMenuItem>();
            MenuPlaneSelectIndex=0;
            MenuItemListPlane=new List<BaseMenuItem>(){
                new BaseMenuItem(StageData, "History_ReimuA"),
                new BaseMenuItem(StageData, "History_MarisaA"),
                new BaseMenuItem(StageData, "History_SanaeA"),
                new BaseMenuItem(StageData, "History_KoishiA")
              };
            int num3 = 90;
            int num4 = 90;
            int num5 = 0;
            foreach(BaseMenuItem baseMenuItem2 in MenuItemListPlane) {
                baseMenuItem2.DestPoint=new PointF(num3,num4);
                baseMenuItem2.Position=new PointF((num3+num5),num4);
                baseMenuItem2.UnSelectVisible=false;
                baseMenuItem2.Vibrateable=false;
            }
            MenuItemListPlane[MenuSelectIndex].Selected=true;
            MenuSelectIndex=0;
            MenuItemList=new List<BaseMenuItem>()
           {
                new BaseMenuItem(StageData, "History_Easy"),
                new BaseMenuItem(StageData, "History_Normal"),
                new BaseMenuItem(StageData, "History_Hard"),
                new BaseMenuItem(StageData, "History_Lunatic"),
                new BaseMenuItem(StageData, "History_Extra")
              };
            int num6 = 480;
            int num7 = 90;
            int num8 = 0;
            foreach(BaseMenuItem menuItem in MenuItemList) {
                menuItem.DestPoint=new PointF(num6,num7);
                menuItem.Position=new PointF((num6+num8),num7);
                menuItem.UnSelectVisible=false;
                menuItem.Vibrateable=false;
            }
            MenuItemList[MenuSelectIndex].Selected=true;
            ScorePageList=new List<DescriptionMenuItem>();
            AddNewScorePage();
        }
        public override void Ctrl() {
            base.Ctrl();
            MenuItemListPlane.ForEach(x => x.Ctrl());
            ScorePageList.ForEach(x => x.Ctrl());
            ClearHistoryList.ForEach(x => x.Ctrl());
        }
        public override void ProcessKeys() {
            base.ProcessKeys();
            if(KClass.Key_Z&&LastZ==0) {
                ++ScorePageIndex;
                if(ScorePageIndex>(MenuSelectIndex==2||MenuSelectIndex==3 ? 5 : 4)) ScorePageIndex=0;
                AddNewScorePage();
                StageData.SoundPlay("se_ok00.wav");
            }
            if((KClass.Key_X||KClass.Key_ESC)&&LastX==0) {
                OnRemoveMenu=TimeMain+20;
                TransparentVelocity=-15f;
                foreach(BaseMenuItem menuItem in MenuItemList) {
                    menuItem.OnRemove=true;
                }
                foreach(BaseMenuItem baseMenuItem in MenuItemListPlane) {
                    baseMenuItem.OnRemove=true;
                }
                foreach(BaseMenuItem scorePage in ScorePageList) {
                    scorePage.OnRemove=true;
                }
                foreach(BaseMenuItem clearHistory in ClearHistoryList) {
                    clearHistory.OnRemove=true;
                }
                StageData.SoundPlay("se_cancel00.wav");
            }
            if(KClass.ArrowRight&&(LastRight==0||LastRight>30)) {
                ++MenuPlaneSelectIndex;
                StageData.SoundPlay("se_select00.wav");
                SelectItemChanged();
            }
            if(!KClass.ArrowLeft||LastLeft!=0&&LastLeft<=30) return;
            --MenuPlaneSelectIndex;
            StageData.SoundPlay("se_select00.wav");
            SelectItemChanged();
        }
        public override void SelectItemChanged() {
            base.SelectItemChanged();
            if(MenuPlaneSelectIndex<0)
                MenuPlaneSelectIndex+=MenuItemListPlane.Count;
            else if(MenuPlaneSelectIndex>MenuItemListPlane.Count-1)
                MenuPlaneSelectIndex-=MenuItemListPlane.Count;
            MenuItemListPlane.ForEach(x => x.Selected=false);
            MenuItemListPlane[MenuPlaneSelectIndex].Select();
            ScorePageIndex=0;
            AddNewScorePage();
        }
        private void AddNewScorePage() {
            ScorePageList.Clear();
            List<ScoreHistory> all1 = StageData.PData.S_History.FindAll(new Predicate<ScoreHistory>(FindScore));
            List<SpellCardHistory> all2 = StageData.PData.SC_History.FindAll(new Predicate<SpellCardHistory>(FindSC));
            List<ClearHistory> all3 = StageData.PData.C_History.FindAll(new Predicate<ClearHistory>(FindClear));
            switch(ScorePageIndex) {
                case 0:
                    for(int index = 0;index<all1.Count;++index)
                        ScorePageList.Add(new DescriptionMenuItem(StageData,(index+1).ToString().PadRight(2)) {
                            Description=all1[index].Data2DrawString(),
                            DefaultColor=Color.FromArgb(230-15*index,230-12*index,byte.MaxValue)
                        });
                    int num1 = 50;
                    int num2 = 130;
                    int num3 = 0;
                    using(List<DescriptionMenuItem>.Enumerator enumerator = ScorePageList.GetEnumerator()) {
                        while(enumerator.MoveNext()) {
                            BaseMenuItem current = enumerator.Current;
                            current.DestPoint=new PointF(num1,num2);
                            current.Position=new PointF((num1+num3),100f);
                            num2+=20;
                        }
                        break;
                    }
                case 1:
                    int num4;
                    for(int index = 0;index<10;++index) {
                        if(all2[index].History>0) {
                            List<DescriptionMenuItem> scorePageList = ScorePageList;
                            StageDataPackage stageData = StageData;
                            num4=all2[index].Index;
                            string Name = num4.ToString().PadRight(3);
                            SCMenuItem scMenuItem1 = new SCMenuItem(stageData,Name);
                            SCMenuItem scMenuItem2 = scMenuItem1;
                            num4=all2[index].Recorded;
                            string str1 = num4.ToString().PadLeft(2);
                            num4=all2[index].History;
                            string str2 = num4.ToString().PadLeft(2);
                            string str3 = (str1+"/"+str2).PadLeft(40);
                            scMenuItem2.Description=str3;
                            scMenuItem1.TxtureObject=StageData.TextureObjectDictionary["欧"+all2[index].Name];
                            scMenuItem1.DefaultColor=all2[index].Recorded>0 ? Color.SkyBlue : Color.White;
                            SCMenuItem scMenuItem3 = scMenuItem1;
                            scorePageList.Add(scMenuItem3);
                        } else {
                            List<DescriptionMenuItem> scorePageList = ScorePageList;
                            StageDataPackage stageData = StageData;
                            num4=all2[index].Index;
                            string Name = num4.ToString().PadRight(3);
                            SCMenuItem scMenuItem1 = new SCMenuItem(stageData,Name);
                            SCMenuItem scMenuItem2 = scMenuItem1;
                            num4=all2[index].Recorded;
                            string str1 = num4.ToString().PadLeft(2);
                            num4=all2[index].History;
                            string str2 = num4.ToString().PadLeft(2);
                            string str3 = (str1+"/"+str2).PadLeft(40);
                            scMenuItem2.Description=str3;
                            scMenuItem1.TxtureObject=StageData.TextureObjectDictionary["???"];
                            scMenuItem1.DefaultColor=all2[index].Recorded>0 ? Color.SkyBlue : Color.White;
                            SCMenuItem scMenuItem3 = scMenuItem1;
                            scorePageList.Add(scMenuItem3);
                        }
                    }
                    int num5 = 80;
                    int num6 = 130;
                    int num7 = 0;
                    using(List<DescriptionMenuItem>.Enumerator enumerator = ScorePageList.GetEnumerator()) {
                        while(enumerator.MoveNext()) {
                            BaseMenuItem current = enumerator.Current;
                            current.DestPoint=new PointF(num5,num6);
                            current.Position=new PointF((num5+num7),100f);
                            num6+=20;
                        }
                        break;
                    }
                case 2:
                    int num8;
                    for(int index = 10;index<20;++index) {
                        if(all2[index].History>0) {
                            List<DescriptionMenuItem> scorePageList = ScorePageList;
                            StageDataPackage stageData = StageData;
                            num8=all2[index].Index;
                            string Name = num8.ToString().PadRight(3);
                            SCMenuItem scMenuItem1 = new SCMenuItem(stageData,Name);
                            SCMenuItem scMenuItem2 = scMenuItem1;
                            num8=all2[index].Recorded;
                            string str1 = num8.ToString().PadLeft(2);
                            num8=all2[index].History;
                            string str2 = num8.ToString().PadLeft(2);
                            string str3 = (str1+"/"+str2).PadLeft(40);
                            scMenuItem2.Description=str3;
                            scMenuItem1.TxtureObject=StageData.TextureObjectDictionary["欧"+all2[index].Name];
                            scMenuItem1.DefaultColor=all2[index].Recorded>0 ? Color.SkyBlue : Color.White;
                            SCMenuItem scMenuItem3 = scMenuItem1;
                            scorePageList.Add(scMenuItem3);
                        } else {
                            List<DescriptionMenuItem> scorePageList = ScorePageList;
                            StageDataPackage stageData = StageData;
                            num8=all2[index].Index;
                            string Name = num8.ToString().PadRight(3);
                            SCMenuItem scMenuItem1 = new SCMenuItem(stageData,Name);
                            SCMenuItem scMenuItem2 = scMenuItem1;
                            num8=all2[index].Recorded;
                            string str1 = num8.ToString().PadLeft(2);
                            num8=all2[index].History;
                            string str2 = num8.ToString().PadLeft(2);
                            string str3 = (str1+"/"+str2).PadLeft(40);
                            scMenuItem2.Description=str3;
                            scMenuItem1.TxtureObject=StageData.TextureObjectDictionary["???"];
                            scMenuItem1.DefaultColor=all2[index].Recorded>0 ? Color.SkyBlue : Color.White;
                            SCMenuItem scMenuItem3 = scMenuItem1;
                            scorePageList.Add(scMenuItem3);
                        }
                    }
                    int num9 = 80;
                    int num10 = 130;
                    int num11 = 0;
                    using(List<DescriptionMenuItem>.Enumerator enumerator = ScorePageList.GetEnumerator()) {
                        while(enumerator.MoveNext()) {
                            BaseMenuItem current = enumerator.Current;
                            current.DestPoint=new PointF(num9,num10);
                            current.Position=new PointF((num9+num11),100f);
                            num10+=20;
                        }
                        break;
                    }
                case 3:
                    int num12;
                    for(int index = 20;index<Math.Min(all2.Count,30);++index) {
                        if(all2[index].History>0) {
                            List<DescriptionMenuItem> scorePageList = ScorePageList;
                            StageDataPackage stageData = StageData;
                            num12=all2[index].Index;
                            string Name = num12.ToString().PadRight(3);
                            SCMenuItem scMenuItem1 = new SCMenuItem(stageData,Name);
                            SCMenuItem scMenuItem2 = scMenuItem1;
                            num12=all2[index].Recorded;
                            string str1 = num12.ToString().PadLeft(2);
                            num12=all2[index].History;
                            string str2 = num12.ToString().PadLeft(2);
                            string str3 = (str1+"/"+str2).PadLeft(40);
                            scMenuItem2.Description=str3;
                            scMenuItem1.TxtureObject=StageData.TextureObjectDictionary["欧"+all2[index].Name];
                            scMenuItem1.DefaultColor=all2[index].Recorded>0 ? Color.SkyBlue : Color.White;
                            SCMenuItem scMenuItem3 = scMenuItem1;
                            scorePageList.Add(scMenuItem3);
                        } else {
                            List<DescriptionMenuItem> scorePageList = ScorePageList;
                            StageDataPackage stageData = StageData;
                            num12=all2[index].Index;
                            string Name = num12.ToString().PadRight(3);
                            SCMenuItem scMenuItem1 = new SCMenuItem(stageData,Name);
                            SCMenuItem scMenuItem2 = scMenuItem1;
                            num12=all2[index].Recorded;
                            string str1 = num12.ToString().PadLeft(2);
                            num12=all2[index].History;
                            string str2 = num12.ToString().PadLeft(2);
                            string str3 = (str1+"/"+str2).PadLeft(40);
                            scMenuItem2.Description=str3;
                            scMenuItem1.TxtureObject=StageData.TextureObjectDictionary["???"];
                            scMenuItem1.DefaultColor=all2[index].Recorded>0 ? Color.SkyBlue : Color.White;
                            SCMenuItem scMenuItem3 = scMenuItem1;
                            scorePageList.Add(scMenuItem3);
                        }
                    }
                    int num13 = 80;
                    int num14 = 130;
                    int num15 = 0;
                    using(List<DescriptionMenuItem>.Enumerator enumerator = ScorePageList.GetEnumerator()) {
                        while(enumerator.MoveNext()) {
                            BaseMenuItem current = enumerator.Current;
                            current.DestPoint=new PointF(num13,num14);
                            current.Position=new PointF((num13+num15),100f);
                            num14+=20;
                        }
                        break;
                    }
                case 4:
                    int num16;
                    for(int index = 30;index<Math.Min(all2.Count,40);++index) {
                        if(all2[index].History>0) {
                            List<DescriptionMenuItem> scorePageList = ScorePageList;
                            StageDataPackage stageData = StageData;
                            num16=all2[index].Index;
                            string Name = num16.ToString().PadRight(3);
                            SCMenuItem scMenuItem1 = new SCMenuItem(stageData,Name);
                            SCMenuItem scMenuItem2 = scMenuItem1;
                            num16=all2[index].Recorded;
                            string str1 = num16.ToString().PadLeft(2);
                            num16=all2[index].History;
                            string str2 = num16.ToString().PadLeft(2);
                            string str3 = (str1+"/"+str2).PadLeft(40);
                            scMenuItem2.Description=str3;
                            scMenuItem1.TxtureObject=StageData.TextureObjectDictionary["欧"+all2[index].Name];
                            scMenuItem1.DefaultColor=all2[index].Recorded>0 ? Color.SkyBlue : Color.White;
                            SCMenuItem scMenuItem3 = scMenuItem1;
                            scorePageList.Add(scMenuItem3);
                        } else {
                            List<DescriptionMenuItem> scorePageList = ScorePageList;
                            StageDataPackage stageData = StageData;
                            num16=all2[index].Index;
                            string Name = num16.ToString().PadRight(3);
                            SCMenuItem scMenuItem1 = new SCMenuItem(stageData,Name);
                            SCMenuItem scMenuItem2 = scMenuItem1;
                            num16=all2[index].Recorded;
                            string str1 = num16.ToString().PadLeft(2);
                            num16=all2[index].History;
                            string str2 = num16.ToString().PadLeft(2);
                            string str3 = (str1+"/"+str2).PadLeft(40);
                            scMenuItem2.Description=str3;
                            scMenuItem1.TxtureObject=StageData.TextureObjectDictionary["???"];
                            scMenuItem1.DefaultColor=all2[index].Recorded>0 ? Color.SkyBlue : Color.White;
                            SCMenuItem scMenuItem3 = scMenuItem1;
                            scorePageList.Add(scMenuItem3);
                        }
                    }
                    int num17 = 80;
                    int num18 = 130;
                    int num19 = 0;
                    using(List<DescriptionMenuItem>.Enumerator enumerator = ScorePageList.GetEnumerator()) {
                        while(enumerator.MoveNext()) {
                            BaseMenuItem current = enumerator.Current;
                            current.DestPoint=new PointF(num17,num18);
                            current.Position=new PointF((num17+num19),100f);
                            num18+=20;
                        }
                        break;
                    }
                case 5:
                    int num20;
                    for(int index = 40;index<Math.Min(all2.Count,50);++index) {
                        if(all2[index].History>0) {
                            List<DescriptionMenuItem> scorePageList = ScorePageList;
                            StageDataPackage stageData = StageData;
                            num20=all2[index].Index;
                            string Name = num20.ToString().PadRight(3);
                            SCMenuItem scMenuItem1 = new SCMenuItem(stageData,Name);
                            SCMenuItem scMenuItem2 = scMenuItem1;
                            num20=all2[index].Recorded;
                            string str1 = num20.ToString().PadLeft(2);
                            num20=all2[index].History;
                            string str2 = num20.ToString().PadLeft(2);
                            string str3 = (str1+"/"+str2).PadLeft(40);
                            scMenuItem2.Description=str3;
                            scMenuItem1.TxtureObject=StageData.TextureObjectDictionary["欧"+all2[index].Name];
                            scMenuItem1.DefaultColor=all2[index].Recorded>0 ? Color.SkyBlue : Color.White;
                            SCMenuItem scMenuItem3 = scMenuItem1;
                            scorePageList.Add(scMenuItem3);
                        } else {
                            List<DescriptionMenuItem> scorePageList = ScorePageList;
                            StageDataPackage stageData = StageData;
                            num20=all2[index].Index;
                            string Name = num20.ToString().PadRight(3);
                            SCMenuItem scMenuItem1 = new SCMenuItem(stageData,Name);
                            SCMenuItem scMenuItem2 = scMenuItem1;
                            num20=all2[index].Recorded;
                            string str1 = num20.ToString().PadLeft(2);
                            num20=all2[index].History;
                            string str2 = num20.ToString().PadLeft(2);
                            string str3 = (str1+"/"+str2).PadLeft(40);
                            scMenuItem2.Description=str3;
                            scMenuItem1.TxtureObject=StageData.TextureObjectDictionary["???"];
                            scMenuItem1.DefaultColor=all2[index].Recorded>0 ? Color.SkyBlue : Color.White;
                            SCMenuItem scMenuItem3 = scMenuItem1;
                            scorePageList.Add(scMenuItem3);
                        }
                    }
                    int num21 = 80;
                    int num22 = 130;
                    int num23 = 0;
                    using(List<DescriptionMenuItem>.Enumerator enumerator = ScorePageList.GetEnumerator()) {
                        while(enumerator.MoveNext()) {
                            BaseMenuItem current = enumerator.Current;
                            current.DestPoint=new PointF(num21,num22);
                            current.Position=new PointF((num21+num23),100f);
                            num22+=20;
                        }
                        break;
                    }
            }
            int num24 = 215;
            int num25 = 350;
            ClearHistoryList=new List<BaseMenuItem>();
            List<BaseMenuItem> clearHistoryList1 = ClearHistoryList;
            SCMenuItem scMenuItem4 = new SCMenuItem(StageData,"") {
                OriginalPosition=new PointF(num24,num25),
                DestPoint=new PointF(num24,num25),
                Scale=1f,
                OffX=0,
                OffY=-5,
                TxtureObject=StageData.TextureObjectDictionary["History_游戏次数"],
                Description=all3[0].StartTimes.ToString().PadLeft(18,' '),
                DefaultColor=Color.FromArgb(230,230,byte.MaxValue)
            };
            SCMenuItem scMenuItem5 = scMenuItem4;
            clearHistoryList1.Add(scMenuItem5);
            int num26 = num25+24;
            long playingTime = all3[0].PlayingTime;
            string str4 = ((playingTime/216000L)).ToString("d2")+":"+((playingTime%216000L/3600L)).ToString("d2")+":"+((playingTime%3600L/60L)).ToString("d2");
            List<BaseMenuItem> clearHistoryList2 = ClearHistoryList;
            SCMenuItem scMenuItem6 = new SCMenuItem(StageData,"") {
                OriginalPosition=new PointF(num24,num26),
                DestPoint=new PointF(num24,num26),
                Scale=1f,
                OffX=0,
                OffY=-5,
                TxtureObject=StageData.TextureObjectDictionary["History_游戏时间"],
                Description=str4.PadLeft(18,' '),
                DefaultColor=Color.FromArgb(230,230,byte.MaxValue)
            };
            SCMenuItem scMenuItem7 = scMenuItem6;
            clearHistoryList2.Add(scMenuItem7);
            int num27 = num26+24;
            List<BaseMenuItem> clearHistoryList3 = ClearHistoryList;
            SCMenuItem scMenuItem8 = new SCMenuItem(StageData,"") {
                OriginalPosition=new PointF(num24,num27),
                DestPoint=new PointF(num24,num27),
                Scale=1f,
                OffX=0,
                OffY=-5,
                TxtureObject=StageData.TextureObjectDictionary["History_通关次数"]
            };
            SCMenuItem scMenuItem9 = scMenuItem8;
            int num28 = all3[0].ClearTimes;
            string str5 = num28.ToString().PadLeft(18,' ');
            scMenuItem9.Description=str5;
            scMenuItem8.DefaultColor=Color.FromArgb(230,230,byte.MaxValue);
            SCMenuItem scMenuItem10 = scMenuItem8;
            clearHistoryList3.Add(scMenuItem10);
            int num29 = num27+24;
            List<BaseMenuItem> clearHistoryList4 = ClearHistoryList;
            SCMenuItem scMenuItem11 = new SCMenuItem(StageData,"") {
                OriginalPosition=new PointF(num24,num29),
                DestPoint=new PointF(num24,num29),
                Scale=1f,
                OffX=0,
                OffY=-5,
                TxtureObject=StageData.TextureObjectDictionary["History_无续关通关次数"]
            };
            SCMenuItem scMenuItem12 = scMenuItem11;
            num28=all3[0].NoContinueClearTimes;
            string str6 = num28.ToString().PadLeft(18,' ');
            scMenuItem12.Description=str6;
            scMenuItem11.DefaultColor=Color.FromArgb(230,230,byte.MaxValue);
            SCMenuItem scMenuItem13 = scMenuItem11;
            clearHistoryList4.Add(scMenuItem13);
            int num30 = num29+24;
            int num31 = num24-70;
            List<BaseMenuItem> clearHistoryList5 = ClearHistoryList;
            BaseMenuItem baseMenuItem1 = new BaseMenuItem(StageData,"History_切换") {
                OriginalPosition=new PointF(num31,num30),
                DestPoint=new PointF(num31,num30),
                Scale=1f,
                Selected=true
            };
            BaseMenuItem baseMenuItem2 = baseMenuItem1;
            clearHistoryList5.Add(baseMenuItem2);
            List<BaseMenuItem> clearHistoryList6 = ClearHistoryList;
            BaseMenuItem baseMenuItem3 = new BaseMenuItem(StageData,"History_Arrow") {
                OriginalPosition=new PointF(70f,95f),
                DestPoint=new PointF(70f,95f),
                Selected=true
            };
            BaseMenuItem baseMenuItem4 = baseMenuItem3;
            clearHistoryList6.Add(baseMenuItem4);
            List<BaseMenuItem> clearHistoryList7 = ClearHistoryList;
            BaseMenuItem baseMenuItem5 = new BaseMenuItem(StageData,"History_Arrow") {
                OriginalPosition=new PointF(322f,112f),
                DestPoint=new PointF(322f,112f),
                Selected=true,
                AngleDegree=180.0
            };
            BaseMenuItem baseMenuItem6 = baseMenuItem5;
            clearHistoryList7.Add(baseMenuItem6);
            List<BaseMenuItem> clearHistoryList8 = ClearHistoryList;
            BaseMenuItem baseMenuItem7 = new BaseMenuItem(StageData,"History_Arrow") {
                OriginalPosition=new PointF(480f,89f),
                DestPoint=new PointF(480f,89f),
                Selected=true,
                AngleDegree=90.0
            };
            BaseMenuItem baseMenuItem8 = baseMenuItem7;
            clearHistoryList8.Add(baseMenuItem8);
            List<BaseMenuItem> clearHistoryList9 = ClearHistoryList;
            BaseMenuItem baseMenuItem9 = new BaseMenuItem(StageData,"History_Arrow") {
                OriginalPosition=new PointF(464f,119f),
                DestPoint=new PointF(464f,119f),
                Selected=true,
                AngleDegree=-90.0
            };
            BaseMenuItem baseMenuItem10 = baseMenuItem9;
            clearHistoryList9.Add(baseMenuItem10);
        }
        public override void Show() {
            base.Show();
            MenuItemListPlane.ForEach((x => x.Show()));
            ScorePageList.ForEach(x => x.Show());
            ClearHistoryList.ForEach(x => x.Show());
        }
        public bool FindScore(ScoreHistory SH) => SH.Rank.ToString()==MenuItemList[MenuSelectIndex].Name.Replace("History_",string.Empty)&&SH.MyPlaneFullName==MenuItemListPlane[MenuPlaneSelectIndex].Name.Replace("History_",string.Empty);
        public bool FindClear(ClearHistory CH) => CH.Rank.ToString()==MenuItemList[MenuSelectIndex].Name.Replace("History_",string.Empty)&&CH.MyPlaneFullName==MenuItemListPlane[MenuPlaneSelectIndex].Name.Replace("History_",string.Empty);
        public bool FindSC(SpellCardHistory SCH) => SCH.Rank.ToString()==MenuItemList[MenuSelectIndex].Name.Replace("History_",string.Empty)&&SCH.MyPlaneFullName==MenuItemListPlane[MenuPlaneSelectIndex].Name.Replace("History_",string.Empty);
    }
}
