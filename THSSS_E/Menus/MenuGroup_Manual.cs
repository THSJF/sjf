﻿using System.Collections.Generic;
using System.Drawing;

namespace Shooting {
    internal class MenuGroup_Manual:BaseMenuGroup {
        private List<BaseMenuItem> MenuItemListManual;
        public MenuGroup_Manual(StageDataPackage StageData) : base(StageData) {
            MenuSelectIndex=0;
            MenuItemList=new List<BaseMenuItem>(){
                new BaseMenuItem(StageData, "Menu_Manual01"),
                new BaseMenuItem(StageData, "Menu_Manual02"),
                new BaseMenuItem(StageData, "Menu_Manual03"),
                new BaseMenuItem(StageData, "Menu_Manual04"),
                new BaseMenuItem(StageData, "Menu_Manual05"),
                new BaseMenuItem(StageData, "Menu_Manual06")
           };
            int num1 = 20;
            int num2 = 85;
            foreach(BaseMenuItem menuItem in MenuItemList) {
                menuItem.Position=new PointF(num1,90f);
                menuItem.DestPoint=new PointF(num1,num2);
                num2+=30;
            }
            MenuItemList[MenuSelectIndex].Selected=true;
            MenuItemListManual=new List<BaseMenuItem>(){
                new BaseMenuItem(StageData, "Manual01"),
                new BaseMenuItem(StageData, "Manual02"),
                new BaseMenuItem(StageData, "Manual03"),
                new BaseMenuItem(StageData, "Manual04"),
                new BaseMenuItem(StageData, "Manual05"),
                new BaseMenuItem(StageData, "Manual06")
             };
            foreach(BaseMenuItem baseMenuItem in MenuItemListManual) {
                baseMenuItem.Position=new PointF(0.0f,0.0f);
                baseMenuItem.DestPoint=new PointF(0.0f,0.0f);
                baseMenuItem.UnSelectVisible=false;
                baseMenuItem.Vibrateable=false;
                baseMenuItem.Twinkleable=false;
                baseMenuItem.TransparentValueF=0.0f;
            }
            MenuItemListManual[MenuSelectIndex].Selected=true;
            TransparentValueF=0.0f;
            MaxTransparent=byte.MaxValue;
            TransparentVelocity=5f;
            TxtureObject=TextureObjectDictionary["MenuBackground"];
            OriginalPosition=new PointF(BoundRect.Width/2,BoundRect.Height/2);
            AngleDegree=90.0;
            ColorValue=Color.FromArgb(30,110,150);
        }
        public override void SelectItemChanged() {
            base.SelectItemChanged();
            MenuItemListManual.ForEach(x => x.Selected=false);
            MenuItemListManual[MenuSelectIndex].Select();
        }
        public override void Ctrl() {
            base.Ctrl();
            MenuItemListManual.ForEach(x => x.Ctrl());
        }
        public override void ProcessKeys() {
            base.ProcessKeys();
            if(!KClass.Key_Z||LastZ!=0) { }
            if(!KClass.Key_X&&!KClass.Key_ESC||LastX!=0) return;
            OnRemoveMenu=TimeMain+20;
            TransparentVelocity=-15f;
            foreach(BaseMenuItem menuItem in MenuItemList) {
                menuItem.OnRemove=true;
            }
            foreach(BaseMenuItem baseMenuItem in MenuItemListManual) {
                baseMenuItem.OnRemove=true;
            }
            StageData.SoundPlay("se_cancel00.wav");
        }
        public override void Show() {
            base.Show();
            MenuItemListManual.ForEach(x => x.Show());
        }
    }
}
