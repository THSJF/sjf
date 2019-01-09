using System.Collections.Generic;
using System.Drawing;

namespace Shooting {
    internal class MenuGroup_RankSelectEx:MenuGroup_RankSelect {
        public MenuGroup_RankSelectEx(StageDataPackage StageData) : base(StageData,false) {
            MenuSelectIndex=0;
            MenuItemList=new List<BaseMenuItem>(){
                new BaseMenuItem(StageData, "Menu_Extra")
              };
            int num1 = 200+MenuSelectIndex*150;
            int num2 = 200-MenuSelectIndex*100;
            int num3 = -200;
            int num4 = 0;
            foreach(BaseMenuItem menuItem in MenuItemList) {
                menuItem.Position=new PointF((num1+num3),48f);
                menuItem.DestPoint=new PointF(num1,num2);
                menuItem.Scale=0.8f;
                menuItem.Vibrateable=false;
                menuItem.MaxVelocity=30f;
                num2+=100;
                num1-=150;
                num3-=100;
                ++num4;
            }
            MenuItemList[MenuSelectIndex].Selected=true;
        }
        public override void SelectItemChanged() {
            if(MenuSelectIndex<0) {
                MenuSelectIndex=0;
            } else if(MenuSelectIndex>MenuItemList.Count-1) {
                MenuSelectIndex=MenuItemList.Count-1;
            }
            LastSelectTime=TimeMain;
            MenuItemList.ForEach(x => x.Selected=false);
            MenuItemList[MenuSelectIndex].Select();
        }
        public override void ProcessZ() {
            StageData.StateSwitchData.SDPswitch.Difficulty=DifficultLevel.Extra;
            List<BaseMenuGroup> menuGroupList = StageData.MenuGroupList;
            MenuGroup_PlayerSelectEx groupPlayerSelectEx1 = new MenuGroup_PlayerSelectEx(StageData) {
                OriginalPosition=OriginalPosition
            };
            MenuGroup_PlayerSelectEx groupPlayerSelectEx2 = groupPlayerSelectEx1;
            menuGroupList.Add(groupPlayerSelectEx2);
        }
    }
}
