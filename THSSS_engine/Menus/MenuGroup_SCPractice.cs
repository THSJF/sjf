using Shooting.Planes.Story;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shooting {
    internal class MenuGroup_SCPractice:BaseMenuGroup {
        private int deltaY = 20;
        private DescriptionBox DescriptionBox;
        public MenuGroup_SCPractice(StageDataPackage StageData) : base(StageData) {
            MenuSelectIndex=0;
            MenuItemList=new List<BaseMenuItem>();
            List<SpellCardHistory> all = StageData.PData.SC_History.FindAll((a => a.MyPlaneFullName=="ReimuA"));
            for(int index = 0;index<all.Count;++index) {
                List<BaseMenuItem> menuItemList = MenuItemList;
                SCMenuItem scMenuItem1 = new SCMenuItem(StageData,all[index].Index.ToString().PadRight(3)) {
                    Description=(all[index].Rank.ToString().PadLeft(10)+all[index].Recorded.ToString().PadLeft(2)+"/"+all[index].History.ToString().PadLeft(2)).PadLeft(40),
                    TxtureObject=StageData.TextureObjectDictionary["欧"+all[index].Name],
                    DefaultColor=all[index].Recorded>0 ? Color.SkyBlue : Color.White
                };
                SCMenuItem scMenuItem2 = scMenuItem1;
                menuItemList.Add(scMenuItem2);
            }
            int num1 = 100;
            int num2 = 100;
            foreach(BaseMenuItem menuItem in MenuItemList) {
                menuItem.TransparentValueF=0.0f;
                menuItem.Position=new PointF(num1,90f);
                menuItem.DestPoint=new PointF(num1,num2);
                menuItem.MaxVelocity=10000f;
                num2+=deltaY;
            }
            MenuItemList[MenuSelectIndex].Selected=true;
            MenuTitlePos1=new PointF(140f,-30f);
            MenuTitlePos2=new PointF(140f,-150f);
            BaseMenuItem baseMenuItem = new BaseMenuItem(StageData,"MenuTitle_MusicRoom") {
                Position=MenuTitlePos2
            };
            MenuTilte=baseMenuItem;
            TransparentValueF=0.0f;
            TransparentVelocity=5f;
            TxtureObject=TextureObjectDictionary["MenuBackground"];
            Scale=0.625f;
            Rectangle boundRect = BoundRect;
            double num3 = (boundRect.Width/2);
            boundRect=BoundRect;
            double num4 = (boundRect.Height/2);
            OriginalPosition=new PointF((float)num3,(float)num4);
            AngleDegree=90.0;
            ColorValue=Color.SlateBlue;
            DescriptionBox descriptionBox = new DescriptionBox(StageData) {
                MaxTransparent=0,
                OffsetX=50
            };
            DescriptionBox=descriptionBox;
        }
        public override void SelectItemChanged() {
            base.SelectItemChanged();
            int num1 = 100;
            int num2 = 100;
            int num3 = (MenuSelectIndex-8)*deltaY;
            if(num3<0) num3=0;
            foreach(BaseObject menuItem in MenuItemList) {
                menuItem.DestPoint=new PointF(num1,(num2-num3));
                num2+=deltaY;
            }
        }
        public override void Ctrl() {
            base.Ctrl();
            DescriptionBox.Ctrl();
            foreach(BaseMenuItem menuItem in MenuItemList) {
                menuItem.TransparentValueF=(float)(400.0-Math.Abs(260f-menuItem.Position.Y)*2.0);
            }
        }
        public override void ProcessKeys() {
            base.ProcessKeys();
            if(!KClass.Key_Z||LastZ!=0) { }
            if(!KClass.Key_X&&!KClass.Key_ESC||LastX!=0) return;
            OnRemoveMenu=TimeMain+20;
            TransparentVelocity=-15f;
            DescriptionBox.TransparentVelocity=-15f;
            foreach(BaseMenuItem menuItem in MenuItemList) {
                menuItem.DestPoint=new PointF(100f,60f);
                menuItem.OnRemove=true;
            }
            StageData.SoundPlay("se_cancel00.wav");
        }
        public override void Show() {
            base.Show();
            DescriptionBox.Show();
        }
    }
}
