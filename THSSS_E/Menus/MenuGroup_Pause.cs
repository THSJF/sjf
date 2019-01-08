using System.Collections.Generic;
using System.Drawing;

namespace Shooting {
    internal class MenuGroup_Pause:MenuGroup_GameOver {
        public MenuGroup_Pause(StageDataPackage StageData) : base(StageData) {
            MenuSelectIndex=0;
            MenuItemList=new List<BaseMenuItem> {
                new BaseMenuItem(StageData,"Menu_继续游戏")
            };
            if(!StageData.GlobalData.LastState.StageData.OnReplay&&StageData.GlobalData.LastState.StageData.ContinueTimes==0)
                MenuItemList.Add(new BaseMenuItem(StageData,"Menu_保存录像"));
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
            MenuTitlePos2=new PointF(-50f,240f);
            MenuTitlePos1=new PointF(44f,240f);
            BaseMenuItem baseMenuItem = new BaseMenuItem(StageData,"Menu_游戏暂停");
            baseMenuItem.Position=MenuTitlePos2;
            MenuTilte=baseMenuItem;
            MenuItemList[MenuSelectIndex].Selected=true;
        }
        public override void ProcessKeys() {
            base.ProcessKeys();
            if(!KClass.Key_C) return;
            for(int index = 0;index<MenuItemList.Count;++index) {
                MenuItemList[index].Selected=false;
                if(MenuItemList[index].Name=="Menu_从头开始") {
                    MenuItemList[index].Selected=true;
                    MenuSelectIndex=index;
                    MenuItemList[MenuSelectIndex].Click();
                    OnChangeMenu=TimeMain+20;
                    StageData.SoundPlay("se_ok00.wav");
                }
            }
        }
    }
}
