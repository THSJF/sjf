﻿using SlimDX;
using System;
using System.Drawing;

namespace Shooting {
    public class EDPetal:BaseParticle3D {
        public double DestAngleDegree { get; set; }
        public EDPetal(StageDataPackage StageData,string modelName,PointF OriginalPosition,float Velocity,double Direction) : base(StageData,modelName,OriginalPosition,0.0f,Math.PI/2.0) {
            this.OriginalPosition=OriginalPosition;
            LifeTime=300;
            TransparentValueF=0.0f;
            TransparentVelocity=10f;
            Angle3D=1.570796f;
            Depth=1f;
            Background3D.BackgroundParticleList.Add(this);
        }
        public override void Ctrl() {
            base.Ctrl();
            if(Angle3D>0.0) {
                Angle3D-=(float)Math.PI/90f;
            }
            if(DestAngleDegree-AngleDegree>1.0) {
                AngleDegree+=(DestAngleDegree-AngleDegree)/8.0;
            } else {
                AngleDegree=DestAngleDegree;
            }
            RotatingAxis=new Vector3((float)Math.Cos(Angle),(float)Math.Sin(Angle),0.0f);
            if(Time!=LifeTime-22) return;
            TransparentVelocity=-12f;
        }
    }
}
