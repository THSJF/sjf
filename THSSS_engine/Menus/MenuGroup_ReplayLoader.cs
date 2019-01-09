using System.Drawing;
using System.IO;

namespace Shooting {
    internal class MenuGroup_ReplayLoader:MenuGroup_ReplaySaver {
        private const string NullDescription = "------- -------- ----- ------- ------- --- ----";
        public MenuGroup_ReplayLoader(StageDataPackage StageData,PointF OriginalPosition) : base(StageData,OriginalPosition) {
            TransparentValueF=0.0f;
            TransparentVelocity=5f;
            TxtureObject=TextureObjectDictionary["MenuBackground"];
            Scale=0.625f;
            Rectangle boundRect = BoundRect;
            double num1 = (boundRect.Width/2);
            boundRect=BoundRect;
            double num2 = (boundRect.Height/2);
            OriginalPosition=new PointF((float)num1,(float)num2);
            AngleDegree=90.0;
            ColorValue=Color.SkyBlue;
        }
        public override string SetDescroption(string fileName) {
            if(!File.Exists(fileName)) return "------- -------- ----- ------- ------- --- ----";
            try {
                ReplayInfo replayInfo = Replay.ReadTitle(fileName);
                if(replayInfo.Version!="ver 1.00") return "------- -------- ----- ------- ------- --- ----";
                string str = null;
                if(replayInfo!=null) str=str+(replayInfo.PlayerName==null ? "        " : replayInfo.PlayerName.PadRight(8))+(replayInfo.Date==null ? "        " : replayInfo.Date.PadRight(9))+(replayInfo.Time==null ? "        " : replayInfo.Time.PadRight(6))+(replayInfo.MyPlaneName==null ? "               " : replayInfo.MyPlaneName.PadRight(8))+replayInfo.Rank.ToString().PadRight(8)+(replayInfo.LastStage==null ? "   " : replayInfo.LastStage.PadRight(4))+(replayInfo.SlowRate==null ? "   " : replayInfo.SlowRate.PadRight(4));
                return str;
            } catch {
                return "------- -------- ----- ------- ------- --- ----";
            }
        }
        public override void ProcessKeys2() {
            if(KClass.Key_Z&&LastZ==0) {
                MenuItemList[MenuSelectIndex].Click();
                OnChangeMenu=TimeMain+1;
            }
            if(!KClass.Key_X&&!KClass.Key_ESC||LastX!=0) return;
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
            if(!(((DescriptionMenuItem)MenuItemList[MenuSelectIndex]).Description!="------- -------- ----- ------- ------- --- ----")) return;
            StageData.SoundPlay("se_ok00.wav");
            StageData.MenuGroupList.Add(new MenuGroup_ReplayStageSelect(StageData,new PointF(200f,150f),(DescriptionMenuItem)MenuItemList[MenuSelectIndex]));
        }
    }
}
