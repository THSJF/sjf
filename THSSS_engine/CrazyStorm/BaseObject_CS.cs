using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shooting {
    public class BaseObject_CS:BaseObject {
        public int type;

        public virtual int Type {
            get => type;
            set => type=value;
        }

        public bool Ghosting {
            get => GhostingCount>0;
            set {
                if(value) {
                    GhostingCount=20;
                    GhostingColor=Color.White;
                } else
                    GhostingCount=0;
            }
        }

        public bool OutBound {
            get => OutsideRegion<80;
            set {
                if(value)
                    return;
                OutsideRegion=200;
            }
        }

        public bool BeginningEffect { get; set; }

        public bool EndingEffect { get; set; }

        public PointF CS_Position {
            get {
                PointF originalPosition = OriginalPosition;
                double num1 = originalPosition.X+320.0-192.0;
                originalPosition=OriginalPosition;
                double num2 = originalPosition.Y+240.0-224.0;
                return new PointF((float)num1,(float)num2);
            }
            set {
                OriginalPosition=new PointF((float)(value.X-320.0+192.0),(float)(value.Y-240.0+224.0));
            }
        }

        public int ID { get; set; }

        public int LayerID { get; set; }

        public float AccelerateCS { get; set; }

        public double AccDirection { get; set; }

        public double RanAngle { get; set; }

        public float RanVelocity { get; set; }

        public double RanDirection { get; set; }

        public float RanAccelerate { get; set; }

        public double RanAccDirection { get; set; }

        public bool Cover { get; set; }

        public bool Rebound { get; set; }

        public bool Force { get; set; }

        public List<EventGroup> EventGroupList { get; set; }

        public List<Execution> EventsExecutionList { get; set; }

        public BaseObject_CS() {
        }

        public BaseObject_CS(StageDataPackage StageData) : base(StageData) {
        }

        public BaseObject_CS(StageDataPackage StageData,string textureName,PointF Position,float Velocity,double Direction) : base(StageData,textureName,Position,Velocity,Direction) {
        }

        public override void Ctrl() {
            double num = AccDirection/180.0*Math.PI;
            Ax=AccelerateCS*(float)Math.Cos(num);
            Ay=AccelerateCS*(float)Math.Sin(num);
            EventCtrl();
            base.Ctrl();
        }

        public virtual void EventCtrl() {
            if(EventGroupList!=null)
                EventGroupList.ForEach(a => a.Update(this));
            if(EventsExecutionList==null)
                return;
            EventsExecutionList.ForEach(a => a.Update(this));
        }

        public override object Clone() {
            BaseObject_CS b = (BaseObject_CS)base.Clone();
            b.EventsExecutionList=new List<Execution>();
            b.EventGroupList=new List<EventGroup>();
            EventGroupList.ForEach(x => b.EventGroupList.Add((EventGroup)x.Clone()));
            return b;
        }
    }
}
