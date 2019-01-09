 
// Type: Shooting.EnemyFactory
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting {
    public class EnemyFactory {
        private readonly string[] EnemyType0 = new string[10]{
            "EnemyA0","EnemyA1","EnemyA2","EnemyA3","EnemyA4","EnemyA5","EnemyA6","EnemyA7","EnemyC0","EnemyC1"
        };
        private readonly string[] EnemyType1 = new string[4]{
            "EnemyA8","EnemyB1","EnemyC2","EnemyC3"
        };
        private readonly string[] EnemyType2 = new string[4]{
            "EnemyGhost0","EnemyGhost1","EnemyGhost2","EnemyGhost3"
        };
        private readonly string[] EnemyType3 = new string[4]{
            "EnemyMaoYu00","EnemyMaoYu01","EnemyMaoYu02","EnemyMaoYu03"
        };
        private readonly string[] EnemyType4 = new string[4]{
            "EnemyYYY4","EnemyYYY5","EnemyYYY6","EnemyYYY7"
        };
        private int EnemyType = -1;
        private string EnemyName;
        public int HealthPoint;
        public int RedCount;
        public int BlueCount;
        public int GreenCount;
        public byte ColorType;
        public bool BackFire;
        public int ClearRadius;
        public bool StarFall;

        public EnemyFactory(string EnemyName) {
            this.EnemyName=EnemyName;
            if(ContainName(EnemyType0,EnemyName)) {
                EnemyType=0;
            } else if(ContainName(EnemyType1,EnemyName)) {
                EnemyType=1;
            } else if(ContainName(EnemyType2,EnemyName)) {
                EnemyType=2;
            } else if(ContainName(EnemyType3,EnemyName)) {
                EnemyType=3;
            } else {
                if(!ContainName(EnemyType4,EnemyName)) {
                    return;
                }
                EnemyType=4;
            }
        }

        private bool ContainName(string[] EnemyType,string EnemyName) {
            foreach(string str in EnemyType) {
                if(str==EnemyName) {
                    return true;
                }
            }
            return false;
        }

        public BaseEnemyPlane_Touhou GenerateEnemy(StageDataPackage StageData) {
            BaseEnemyPlane_Touhou enemyPlaneTouhou;
            switch(EnemyType) {
                case 0:
                    ColorType=byte.Parse(EnemyName.Replace("EnemyA","").Replace("EnemyB","").Replace("EnemyC",""));
                    ColorType=ColorType>3 ? (byte)(ColorType-4U) : ColorType;
                    enemyPlaneTouhou=new EnemyPlane_TouhouSmall(StageData,EnemyName,new PointF(0.0f,0.0f),0.0f,0.0,ColorType);
                    if(BackFire) {
                        ((EnemyPlane_TouhouSmall)enemyPlaneTouhou).SetBackFire();
                        break;
                    }
                    break;
                case 1:
                    enemyPlaneTouhou=new EnemyPlane_TouhouBig(StageData,EnemyName,new PointF(0.0f,0.0f),0.0f,0.0,ColorType);
                    break;
                case 2:
                    ColorType=byte.Parse(EnemyName.Replace("EnemyGhost",""));
                    enemyPlaneTouhou=new EnemyPlane_TouhouGhost(StageData,new PointF(0.0f,0.0f),0.0f,0.0,ColorType);
                    break;
                case 3:
                    ColorType=byte.Parse(EnemyName.Replace("EnemyMaoYu0",""));
                    enemyPlaneTouhou=new EnemyPlane_TouhouMaoYu(StageData,new PointF(0.0f,0.0f),0.0f,0.0,ColorType);
                    break;
                case 4:
                    ColorType=(byte)(int.Parse(EnemyName.Replace("EnemyYYY",""))-4);
                    enemyPlaneTouhou=new EnemyPlane_TouhouYYY(StageData,new PointF(0.0f,0.0f),0.0f,0.0,ColorType);
                    break;
                default:
                    enemyPlaneTouhou=new EnemyPlane_TouhouNormal(StageData,EnemyName,new PointF(0.0f,0.0f),0.0f,0.0,ColorType);
                    break;
            }
            enemyPlaneTouhou.HealthPoint=HealthPoint;
            enemyPlaneTouhou.RedCount=RedCount;
            enemyPlaneTouhou.BlueCount=BlueCount;
            enemyPlaneTouhou.GreenCount=GreenCount;
            enemyPlaneTouhou.ClearRadius=ClearRadius;
            enemyPlaneTouhou.StarFall=StarFall;
            StageData.EnemyPlaneList.Remove(enemyPlaneTouhou);
            return enemyPlaneTouhou;
        }
    }
}
