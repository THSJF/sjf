// Decompiled with JetBrains decompiler
// Type: CrazyStorm_1._03.CExecution
// Assembly: CrazyStorm 1.03, Version=1.0.0.3, Culture=neutral, PublicKeyToken=null
// MVID: 84431CDC-1E34-49EF-A5C5-D546FEF5A655
// Assembly location: E:\CrazyStorm 1.03I\CrazyStorm 1.03.exe

using Microsoft.Xna.Framework;
using System;

namespace CrazyStorm_1._03
{
  public class CExecution
  {
    public int change;
    public int changetype;
    public int changevalue;
    public string region;
    public float value;
    public float value2;
    public int time;
    public int ctime;
    public bool NeedDelete;

    public void Update()
    {
            if(this.changetype==0) {
                switch(this.changevalue) {
                    case 0:
                        if(this.change==0)
                            Center.ospeed=(Center.ospeed*((float)this.ctime-1f)+this.value)/(float)this.ctime;
                        else if(this.change==1)
                            Center.ospeed+=this.value/(float)this.time;
                        else if(this.change==2)
                            Center.ospeed-=this.value/(float)this.time;
                        Center.speedx=Center.ospeed*(float)Math.Cos((double)MathHelper.ToRadians(Center.ospeedd));
                        Center.speedy=Center.ospeed*(float)Math.Sin((double)MathHelper.ToRadians(Center.ospeedd));
                        break;
                    case 1:
                        if(this.change==0)
                            Center.ospeedd=(Center.ospeedd*((float)this.ctime-1f)+this.value)/(float)this.ctime;
                        else if(this.change==1)
                            Center.ospeedd+=this.value/(float)this.time;
                        else if(this.change==2)
                            Center.ospeedd-=this.value/(float)this.time;
                        Center.speedx=Center.ospeed*(float)Math.Cos((double)MathHelper.ToRadians(Center.ospeedd));
                        Center.speedy=Center.ospeed*(float)Math.Sin((double)MathHelper.ToRadians(Center.ospeedd));
                        break;
                    case 2:
                        if(this.change==0)
                            Center.oaspeed=(Center.oaspeed*((float)this.ctime-1f)+this.value)/(float)this.ctime;
                        else if(this.change==1)
                            Center.oaspeed+=this.value/(float)this.time;
                        else if(this.change==2)
                            Center.oaspeed-=this.value/(float)this.time;
                        Center.aspeedx=Center.oaspeed*(float)Math.Cos((double)MathHelper.ToRadians(Center.oaspeedd));
                        Center.aspeedy=Center.oaspeed*(float)Math.Sin((double)MathHelper.ToRadians(Center.oaspeedd));
                        break;
                    case 3:
                        if(this.change==0)
                            Center.oaspeedd=(Center.oaspeedd*((float)this.ctime-1f)+this.value)/(float)this.ctime;
                        else if(this.change==1)
                            Center.oaspeedd+=this.value/(float)this.time;
                        else if(this.change==2)
                            Center.oaspeedd-=this.value/(float)this.time;
                        Center.aspeedx=Center.oaspeed*(float)Math.Cos((double)MathHelper.ToRadians(Center.oaspeedd));
                        Center.aspeedy=Center.oaspeed*(float)Math.Sin((double)MathHelper.ToRadians(Center.oaspeedd));
                        break;
                }
            } else if(this.changetype==1) {
                switch(this.changevalue) {
                    case 0:
                        if(this.change==0)
                            Center.ospeed=this.value;
                        else if(this.change==1)
                            Center.ospeed+=this.value;
                        else if(this.change==2)
                            Center.ospeed-=this.value;
                        Center.speedx=Center.ospeed*(float)Math.Cos((double)MathHelper.ToRadians(Center.ospeedd));
                        Center.speedy=Center.ospeed*(float)Math.Sin((double)MathHelper.ToRadians(Center.ospeedd));
                        break;
                    case 1:
                        if(this.change==0)
                            Center.ospeedd=this.value;
                        else if(this.change==1)
                            Center.ospeedd+=this.value;
                        else if(this.change==2)
                            Center.ospeedd-=this.value;
                        Center.speedx=Center.ospeed*(float)Math.Cos((double)MathHelper.ToRadians(Center.ospeedd));
                        Center.speedy=Center.ospeed*(float)Math.Sin((double)MathHelper.ToRadians(Center.ospeedd));
                        break;
                    case 2:
                        if(this.change==0)
                            Center.oaspeed=this.value;
                        else if(this.change==1)
                            Center.oaspeed+=this.value;
                        else if(this.change==2)
                            Center.oaspeed-=this.value;
                        Center.aspeedx=Center.oaspeed*(float)Math.Cos((double)MathHelper.ToRadians(Center.oaspeedd));
                        Center.aspeedy=Center.oaspeed*(float)Math.Sin((double)MathHelper.ToRadians(Center.oaspeedd));
                        break;
                    case 3:
                        if(this.change==0)
                            Center.oaspeedd=this.value;
                        else if(this.change==1)
                            Center.ospeedd+=this.value;
                        else if(this.change==2)
                            Center.ospeedd-=this.value;
                        Center.aspeedx=Center.oaspeed*(float)Math.Cos((double)MathHelper.ToRadians(Center.oaspeedd));
                        Center.aspeedy=Center.oaspeed*(float)Math.Sin((double)MathHelper.ToRadians(Center.oaspeedd));
                        break;
                }
            } else if(this.changetype==2) {
                switch(this.changevalue) {
                    case 0:
                        if(this.change==0)
                            Center.ospeed=float.Parse(this.region)+(this.value-float.Parse(this.region))*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                        else if(this.change==1)
                            Center.ospeed=float.Parse(this.region)+this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                        else if(this.change==2)
                            Center.ospeed=float.Parse(this.region)-this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                        Center.speedx=Center.ospeed*(float)Math.Cos((double)MathHelper.ToRadians(Center.ospeedd));
                        Center.speedy=Center.ospeed*(float)Math.Sin((double)MathHelper.ToRadians(Center.ospeedd));
                        break;
                    case 1:
                        if(this.change==0)
                            Center.ospeedd=float.Parse(this.region)+(this.value-float.Parse(this.region))*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                        else if(this.change==1)
                            Center.ospeedd=float.Parse(this.region)+this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                        else if(this.change==2)
                            Center.ospeedd=float.Parse(this.region)-this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                        Center.speedx=Center.ospeed*(float)Math.Cos((double)MathHelper.ToRadians(Center.ospeedd));
                        Center.speedy=Center.ospeed*(float)Math.Sin((double)MathHelper.ToRadians(Center.ospeedd));
                        break;
                    case 2:
                        if(this.change==0)
                            Center.oaspeed=float.Parse(this.region)+(this.value-float.Parse(this.region))*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                        else if(this.change==1)
                            Center.oaspeed=float.Parse(this.region)+this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                        else if(this.change==2)
                            Center.oaspeed=float.Parse(this.region)-this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                        Center.aspeedx=Center.oaspeed*(float)Math.Cos((double)MathHelper.ToRadians(Center.oaspeedd));
                        Center.aspeedy=Center.oaspeed*(float)Math.Sin((double)MathHelper.ToRadians(Center.oaspeedd));
                        break;
                    case 3:
                        if(this.change==0)
                            Center.oaspeedd=float.Parse(this.region)+(this.value-float.Parse(this.region))*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                        else if(this.change==1)
                            Center.oaspeedd=float.Parse(this.region)+this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                        else if(this.change==2)
                            Center.oaspeedd=float.Parse(this.region)-this.value*(float)Math.Sin((double)MathHelper.ToRadians((float)(360.0/(double)this.time*((double)this.time-(double)this.ctime))));
                        Center.aspeedx=Center.oaspeed*(float)Math.Cos((double)MathHelper.ToRadians(Center.oaspeedd));
                        Center.aspeedy=Center.oaspeed*(float)Math.Sin((double)MathHelper.ToRadians(Center.oaspeedd));
                        break;
                }
            } else if(this.changetype==3) { } else if(this.changetype==4) {
            }
      --this.ctime;
      if (this.changetype == 2 & this.ctime == -1)
      {
        this.NeedDelete = true;
      }
      else
      {
        if (!(this.changetype != 2 & this.ctime == 0))
          return;
        this.NeedDelete = true;
      }
    }
  }
}
