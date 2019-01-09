using System.Collections.Generic;
using System.Drawing;

namespace Shooting {
    internal class MenuGroup_PlayerSelect:BaseMenuGroup {
        private bool StageSelect;
        protected List<BaseMenuItem> PlayerDescription;
        public MenuGroup_PlayerSelect(StageDataPackage StageData,bool StageSelect) : base(StageData) {
            this.StageSelect=StageSelect;
            MenuSelectIndex=0;
            MenuItemList=new List<BaseMenuItem>();
            PlayerDescription=new List<BaseMenuItem>();
            List<BaseMenuItem> menuItemList1 = MenuItemList;
            CharacterMenuItem characterMenuItem1 = new CharacterMenuItem(StageData,"FaceReimu_me") {
                DestPoint1=new PointF(sbyte.MinValue,10f),
                DestPoint2=new PointF(-228f,10f),
                TransparentValueF=0.0f
            };
            CharacterMenuItem characterMenuItem2 = characterMenuItem1;
            menuItemList1.Add(characterMenuItem2);
            List<BaseMenuItem> playerDescription1 = PlayerDescription;
            CharacterMenuItem characterMenuItem3 = new CharacterMenuItem(StageData,"DescriptionReimu") {
                DestPoint1=new PointF(190f,10f),
                DestPoint2=new PointF(260f,10f),
                TransparentValueF=0.0f
            };
            CharacterMenuItem characterMenuItem4 = characterMenuItem3;
            playerDescription1.Add(characterMenuItem4);
            List<BaseMenuItem> menuItemList2 = MenuItemList;
            CharacterMenuItem characterMenuItem5 = new CharacterMenuItem(StageData,"FaceMarisa_me") {
                DestPoint1=new PointF(sbyte.MinValue,10f),
                DestPoint2=new PointF(-228f,10f),
                TransparentValueF=0.0f
            };
            CharacterMenuItem characterMenuItem6 = characterMenuItem5;
            menuItemList2.Add(characterMenuItem6);
            List<BaseMenuItem> playerDescription2 = PlayerDescription;
            CharacterMenuItem characterMenuItem7 = new CharacterMenuItem(StageData,"DescriptionMarisa") {
                DestPoint1=new PointF(190f,10f),
                DestPoint2=new PointF(260f,10f),
                TransparentValueF=0.0f
            };
            CharacterMenuItem characterMenuItem8 = characterMenuItem7;
            playerDescription2.Add(characterMenuItem8);
            List<BaseMenuItem> menuItemList3 = MenuItemList;
            CharacterMenuItem characterMenuItem9 = new CharacterMenuItem(StageData,"FaceSanae_me") {
                DestPoint1=new PointF(0.0f,30f),
                DestPoint2=new PointF(-100f,30f),
                TransparentValueF=0.0f
            };
            CharacterMenuItem characterMenuItem10 = characterMenuItem9;
            menuItemList3.Add(characterMenuItem10);
            List<BaseMenuItem> playerDescription3 = PlayerDescription;
            CharacterMenuItem characterMenuItem11 = new CharacterMenuItem(StageData,"DescriptionSanae") {
                DestPoint1=new PointF(190f,10f),
                DestPoint2=new PointF(260f,10f),
                TransparentValueF=0.0f
            };
            CharacterMenuItem characterMenuItem12 = characterMenuItem11;
            playerDescription3.Add(characterMenuItem12);
            List<BaseMenuItem> menuItemList4 = MenuItemList;
            CharacterMenuItem characterMenuItem13 = new CharacterMenuItem(StageData,"FaceKoishi_me") {
                DestPoint1=new PointF(sbyte.MinValue,10f),
                DestPoint2=new PointF(-228f,10f),
                TransparentValueF=0.0f
            };
            CharacterMenuItem characterMenuItem14 = characterMenuItem13;
            menuItemList4.Add(characterMenuItem14);
            List<BaseMenuItem> playerDescription4 = PlayerDescription;
            CharacterMenuItem characterMenuItem15 = new CharacterMenuItem(StageData,"DescriptionKoishi") {
                DestPoint1=new PointF(190f,10f),
                DestPoint2=new PointF(260f,10f),
                TransparentValueF=0.0f
            };
            CharacterMenuItem characterMenuItem16 = characterMenuItem15;
            playerDescription4.Add(characterMenuItem16);
            MenuItemList[MenuSelectIndex].Selected=true;
            PlayerDescription[MenuSelectIndex].Selected=true;
            BaseMenuItem baseMenuItem = new BaseMenuItem(StageData,"MenuTitle_PlayerSelect") {
                Position=MenuTitlePos2
            };
            MenuTilte=baseMenuItem;
            TransparentValueF=0.0f;
            MaxTransparent=byte.MaxValue;
            TransparentVelocity=10f;
            TxtureObject=TextureObjectDictionary["MenuBackground"];
            AngleDegree=90.0;
            Scale=0.75f;
            Rectangle boundRect = BoundRect;
            double num1 = (boundRect.Width/2+30*(int)(StageData.StateSwitchData.SDPswitch.Difficulty-1));
            boundRect=BoundRect;
            double num2 = (boundRect.Height/2-20*(int)(StageData.StateSwitchData.SDPswitch.Difficulty-1));
            OriginalPosition=new PointF((float)num1,(float)num2);
        }

        public override void Ctrl() {
            base.Ctrl();
            PlayerDescription.ForEach(x => x.Ctrl());
        }
        public override void ProcessKeys() {
            if(KClass.ArrowLeft&&LastLeft==0) {
                --MenuSelectIndex;
                StageData.SoundPlay("se_select00.wav");
                SelectItemChanged();
            }
            if(KClass.ArrowRight&&LastRight==0) {
                ++MenuSelectIndex;
                StageData.SoundPlay("se_select00.wav");
                SelectItemChanged();
            }
            if(KClass.Key_Z&&LastZ==0) {
                MenuItemList[MenuSelectIndex].Click();
                OnChangeMenu=TimeMain+20;
                StageData.SoundPlay("se_ok00.wav");
            }
            if(!KClass.Key_X&&!KClass.Key_ESC||LastX!=0) return;
            OnRemoveMenu=TimeMain+20;
            TransparentVelocity=-15f;
            foreach(BaseMenuItem menuItem in MenuItemList) {
                menuItem.Selected=false;
                menuItem.OnRemove=true;
            }
            foreach(BaseMenuItem baseMenuItem in PlayerDescription) {
                baseMenuItem.Selected=false;
                baseMenuItem.OnRemove=true;
            }
            StageData.SoundPlay("se_cancel00.wav");
        }
        public override void SelectItemChanged() {
            base.SelectItemChanged();
            for(int index = 0;index<PlayerDescription.Count;++index) {
                if(index==MenuSelectIndex) {
                    PlayerDescription[index].Select();
                } else {
                    PlayerDescription[index].Selected=false;
                }
            }
        }
        public override void ProcessZ() {
            Point OriginalPosition = new Point(192,398);
            switch(MenuItemList[MenuSelectIndex].Name) {
                case "FaceReimu_me":
                    StageData.StateSwitchData.SDPswitch.MyPlane=new MyPlane_Reimu(StageData.StateSwitchData.SDPswitch,OriginalPosition);
                    if(!StageSelect) {
                        StageData.Rep.CreatRpy();
                        StageData.StateSwitchData.NextState="St1";
                        StageData.StateSwitchData.SDPswitch.SetReplayInfo(StageData.StateSwitchData.NextState);
                        break;
                    }
                    StageData.MenuGroupList.Add(new MenuGroup_StageSelect(StageData));
                    break;
                case "FaceSanae_me":
                    StageData.StateSwitchData.SDPswitch.MyPlane=new MyPlane_Sanae(StageData.StateSwitchData.SDPswitch,OriginalPosition);
                    if(!StageSelect) {
                        StageData.Rep.CreatRpy();
                        StageData.StateSwitchData.NextState="St1";
                        StageData.StateSwitchData.SDPswitch.SetReplayInfo(StageData.StateSwitchData.NextState);
                        break;
                    }
                    StageData.MenuGroupList.Add(new MenuGroup_StageSelect(StageData));
                    break;
                case "FaceMarisa_me":
                    StageData.StateSwitchData.SDPswitch.MyPlane=new MyPlane_Marisa(StageData.StateSwitchData.SDPswitch,OriginalPosition);
                    if(!StageSelect) {
                        StageData.Rep.CreatRpy();
                        StageData.StateSwitchData.NextState="St1";
                        StageData.StateSwitchData.SDPswitch.SetReplayInfo(StageData.StateSwitchData.NextState);
                        break;
                    }
                    StageData.MenuGroupList.Add(new MenuGroup_StageSelect(StageData));
                    break;
                case "FaceKoishi_me":
                    StageData.StateSwitchData.SDPswitch.MyPlane=new MyPlane_Koishi(StageData.StateSwitchData.SDPswitch,OriginalPosition);
                    if(!StageSelect) {
                        StageData.Rep.CreatRpy();
                        StageData.StateSwitchData.NextState="St1";
                        StageData.StateSwitchData.SDPswitch.SetReplayInfo(StageData.StateSwitchData.NextState);
                        break;
                    }
                    StageData.MenuGroupList.Add(new MenuGroup_StageSelect(StageData));
                    break;
            }
        }
        public override void Show() {
            base.Show();
            if(StageData.MenuGroupList[StageData.MenuGroupList.Count-1]!=this) return;
            PlayerDescription.ForEach(x => x.Show());
        }
    }
}
