 
// Type: Shooting.CSEmitterController
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting {
    public class CSEmitterController:BaseBulleEmitter {
        private CS_Data CSData;
        public bool BossBinding { get; set; }
        public bool OnRoad { get; set; }
        public PointF BaseOriginalPosition { get; set; }
        public CSEmitterController(StageDataPackage StageData,CS_Data CSData) : base(StageData) {
            this.CSData=CSData;
            BaseOriginalPosition=new PointF(BoundRect.Width/2,130f);
        }

        public override void Shoot() {
            if(Time>=CSData.TimeTotal) {
                Time-=CSData.TimeTotal;
            }
            if(OnRoad&&Boss!=null) {
                return;
            }
            CSData.EmitterList.ForEach(em => {
                if(em.BindingID!=-1||em.StartTime!=Time) return;
                BaseEmitter_CS baseEmitterCs1 = (BaseEmitter_CS)em.Clone();
                if(BossBinding&&Boss!=null) {
                    BaseEmitter_CS baseEmitterCs2 = baseEmitterCs1;
                    float x1 = baseEmitterCs1.OriginalPosition.X;
                    PointF originalPosition1 = Boss.OriginalPosition;
                    float x2 = originalPosition1.X;
                    float num1 = x1+x2;
                    originalPosition1=BaseOriginalPosition;
                    float x3 = originalPosition1.X;
                    float num2 = num1-x3;
                    float y1 = baseEmitterCs1.OriginalPosition.Y;
                    PointF originalPosition2 = Boss.OriginalPosition;
                    float y2 = originalPosition2.Y;
                    float num3 = y1+y2;
                    originalPosition2=BaseOriginalPosition;
                    float y3 = originalPosition2.Y;
                    float num4 = num3-y3;
                    PointF pointF = new PointF(num2,num4);
                    baseEmitterCs2.OriginalPosition=pointF;
                    baseEmitterCs1.EmitPoint=new PointF(-99998f,-99998f);
                    baseEmitterCs1.SetBinding(Boss);
                }
                baseEmitterCs1.Time=Time;
                StageData.EnemyPlaneList.Add(baseEmitterCs1);
            });
        }
    }
}
