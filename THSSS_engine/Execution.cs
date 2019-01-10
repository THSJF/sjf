using System;
using System.Drawing;

namespace Shooting {
    [Serializable]
    public class Execution {
        public int parentid;
        public int id;
        public int change;
        public int changetype;
        public int changevalue;
        public string region;
        public float value;
        public int time;
        public int ctime;
        public void Update(BaseEmitter_CS objects) {
            switch(changevalue) {
                case 0:
                    PointF csPosition1 = objects.CS_Position;
                    float x = csPosition1.X;
                    BaseEmitter_CS baseEmitterCs1 = objects;
                    double num1 = ChangeValue(x);
                    csPosition1=objects.CS_Position;
                    double y1 = csPosition1.Y;
                    PointF pointF1 = new PointF((float)num1,(float)y1);
                    baseEmitterCs1.CS_Position=pointF1;
                    break;
                case 1:
                    PointF csPosition2 = objects.CS_Position;
                    float y2 = csPosition2.Y;
                    BaseEmitter_CS baseEmitterCs2 = objects;
                    csPosition2=objects.CS_Position;
                    PointF pointF2 = new PointF(csPosition2.X,ChangeValue(y2));
                    baseEmitterCs2.CS_Position=pointF2;
                    break;
                case 2:
                    objects.EmitRadius=ChangeValue(objects.EmitRadius);
                    break;
                case 3:
                    objects.RadiusDirection=ChangeValue(objects.RadiusDirection);
                    break;
                case 4:
                    objects.Way=ChangeValue(objects.Way);
                    break;
                case 5:
                    objects.Circle=ChangeValue(objects.Circle);
                    break;
                case 6:
                    objects.EmitDirection=ChangeValue(objects.EmitDirection);
                    break;
                case 7:
                    objects.Range=ChangeValue(objects.Range);
                    break;
                case 8:
                    objects.Velocity=ChangeValue(objects.Velocity);
                    break;
                case 9:
                    objects.DirectionDegree=ChangeValue(objects.DirectionDegree);
                    break;
                case 10:
                    objects.AccelerateCS=ChangeValue(objects.AccelerateCS);
                    break;
                case 11:
                    objects.AccDirection=ChangeValue(objects.AccDirection);
                    break;
                case 12:
                    objects.SubBullet.LifeTime=ChangeValue(objects.SubBullet.LifeTime);
                    break;
                case 13:
                    objects.SubBullet.Type=ChangeValue(objects.SubBullet.Type);
                    break;
                case 14:
                    objects.SubBullet.ScaleWidth=ChangeValue(objects.SubBullet.ScaleWidth);
                    break;
                case 15:
                    objects.SubBullet.ScaleLength=ChangeValue(objects.SubBullet.ScaleLength);
                    break;
                case 16:
                    int num2 = ChangeValue(objects.SubBullet.ColorValue.R);
                    int num3 = num2<0 ? 0 : num2;
                    int red = num3>byte.MaxValue ? byte.MaxValue : num3;
                    objects.SubBullet.ColorValue=Color.FromArgb(red,objects.SubBullet.ColorValue.G,objects.SubBullet.ColorValue.B);
                    break;
                case 17:
                    int num4 = ChangeValue(objects.SubBullet.ColorValue.G);
                    int num5 = num4<0 ? 0 : num4;
                    int green = num5>byte.MaxValue ? byte.MaxValue : num5;
                    objects.SubBullet.ColorValue=Color.FromArgb(objects.SubBullet.ColorValue.R,green,objects.SubBullet.ColorValue.B);
                    break;
                case 18:
                    int num6 = ChangeValue(objects.SubBullet.ColorValue.B);
                    int num7 = num6<0 ? 0 : num6;
                    int blue = num7>byte.MaxValue ? byte.MaxValue : num7;
                    objects.SubBullet.ColorValue=Color.FromArgb(objects.SubBullet.ColorValue.R,objects.SubBullet.ColorValue.G,blue);
                    break;
                case 19:
                    objects.SubBullet.TransparentValueF=ChangeValue(objects.SubBullet.TransparentValueF);
                    break;
                case 20:
                    objects.SubBullet.AngleDegree=ChangeValue(objects.SubBullet.AngleDegree);
                    break;
                case 21:
                    objects.SubBullet.Velocity=ChangeValue(objects.SubBullet.Velocity);
                    break;
                case 22:
                    objects.SubBullet.DirectionDegree=ChangeValue(objects.SubBullet.DirectionDegree);
                    break;
                case 23:
                    objects.SubBullet.AccelerateCS=ChangeValue(objects.SubBullet.AccelerateCS);
                    break;
                case 24:
                    objects.SubBullet.AccDirection=ChangeValue(objects.SubBullet.AccDirection);
                    break;
                case 25:
                    objects.SubBullet.ScaleX=ChangeValue(objects.SubBullet.ScaleX);
                    break;
                case 26:
                    objects.SubBullet.ScaleY=ChangeValue(objects.SubBullet.ScaleY);
                    break;
                case 27:
                    objects.SubBullet.BeginningEffect=value>0.0;
                    break;
                case 28:
                    objects.SubBullet.EndingEffect=value>0.0;
                    break;
                case 29:
                    objects.SubBullet.Active=value>0.0;
                    break;
                case 30:
                    objects.SubBullet.Ghosting=value>0.0;
                    break;
                case 31:
                    objects.SubBullet.OutBound=value>0.0;
                    break;
                case 32:
                    objects.SubBullet.UnRemoveable=value>0.0;
                    break;
            }
            --ctime;
            if(!(changetype==2&ctime==-1)&&!(changetype!=2&ctime==0)) return;
            objects.EventsExecutionList.Remove(this);
        }
        public void Update(BaseObject_CS objects) {
            switch(changevalue) {
                case 0:
                    objects.LifeTime=ChangeValue(objects.LifeTime);
                    break;
                case 1:
                    objects.Type=ChangeValue(objects.Type);
                    break;
                case 2:
                    objects.ScaleWidth=ChangeValue(objects.ScaleWidth);
                    break;
                case 3:
                    objects.ScaleLength=ChangeValue(objects.ScaleLength);
                    break;
                case 4:
                    Color colorValue1 = objects.ColorValue;
                    int num1 = ChangeValue(colorValue1.R);
                    int num2 = num1<0 ? 0 : num1;
                    int num3 = num2>byte.MaxValue ? byte.MaxValue : num2;
                    BaseObject_CS baseObjectCs1 = objects;
                    int red = num3;
                    colorValue1=objects.ColorValue;
                    int g1 = colorValue1.G;
                    colorValue1=objects.ColorValue;
                    int b1 = colorValue1.B;
                    Color color1 = Color.FromArgb(red,g1,b1);
                    baseObjectCs1.ColorValue=color1;
                    break;
                case 5:
                    Color colorValue2 = objects.ColorValue;
                    int num4 = ChangeValue(colorValue2.G);
                    int num5 = num4<0 ? 0 : num4;
                    int num6 = num5>byte.MaxValue ? byte.MaxValue : num5;
                    BaseObject_CS baseObjectCs2 = objects;
                    colorValue2=objects.ColorValue;
                    int r1 = colorValue2.R;
                    int green = num6;
                    colorValue2=objects.ColorValue;
                    int b2 = colorValue2.B;
                    Color color2 = Color.FromArgb(r1,green,b2);
                    baseObjectCs2.ColorValue=color2;
                    break;
                case 6:
                    Color colorValue3 = objects.ColorValue;
                    int num7 = ChangeValue(colorValue3.B);
                    int num8 = num7<0 ? 0 : num7;
                    int num9 = num8>byte.MaxValue ? byte.MaxValue : num8;
                    BaseObject_CS baseObjectCs3 = objects;
                    colorValue3=objects.ColorValue;
                    int r2 = colorValue3.R;
                    colorValue3=objects.ColorValue;
                    int g2 = colorValue3.G;
                    int blue = num9;
                    Color color3 = Color.FromArgb(r2,g2,blue);
                    baseObjectCs3.ColorValue=color3;
                    break;
                case 7:
                    objects.TransparentValueF=ChangeValue(objects.TransparentValueF);
                    break;
                case 8:
                    objects.AngleDegree=ChangeValue(objects.AngleDegree);
                    break;
                case 9:
                    objects.Velocity=ChangeValue(objects.Velocity);
                    break;
                case 10:
                    objects.DirectionDegree=ChangeValue(objects.DirectionDegree);
                    break;
                case 11:
                    objects.AccelerateCS=ChangeValue(objects.AccelerateCS);
                    break;
                case 12:
                    objects.AccDirection=ChangeValue(objects.AccDirection);
                    break;
                case 13:
                    objects.ScaleX=ChangeValue(objects.ScaleX);
                    break;
                case 14:
                    objects.ScaleY=ChangeValue(objects.ScaleY);
                    break;
                case 15:
                    objects.BeginningEffect=value>0.0;
                    break;
                case 16:
                    objects.EndingEffect=value>0.0;
                    break;
                case 17:
                    objects.Active=value>0.0;
                    break;
                case 18:
                    objects.Ghosting=value>0.0;
                    break;
                case 19:
                    objects.OutBound=value>0.0;
                    break;
                case 20:
                    objects.UnRemoveable=value>0.0;
                    break;
            }
            --ctime;
            if(!(changetype==2&ctime==-1)&&!(changetype!=2&ctime==0)) return;
            objects.EventsExecutionList.Remove(this);
        }
        private int ChangeValue(int Value) => (int)ChangeValue((double)Value);
        private float ChangeValue(float Value) => (float)ChangeValue((double)Value);
        private double ChangeValue(double Value) {
            if(changetype==0) {
                if(change==0) return (Value*(ctime-1.0)+value)/ctime;
                if(change==1) return Value+value/time;
                return Value-value/time;
            }
            if(changetype==1) {
                if(change==0) return value;
                if(change==1) return Value+value;
                return Value-value;
            }
            if(change==0) return float.Parse(region)+((double)value-float.Parse(region))*Math.Sin(2.0*Math.PI/time*((double)time-ctime));
            if(change==1) return float.Parse(region)+value*Math.Sin(2.0*Math.PI/time*((double)time-ctime));
            return float.Parse(region)-value*Math.Sin(2.0*Math.PI/time*((double)time-ctime));
        }
    }
}
