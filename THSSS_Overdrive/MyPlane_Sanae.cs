// Decompiled with JetBrains decompiler
// Type: Shooting.MyPlane_Sanae
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  public class MyPlane_Sanae : BaseMyPlane_Touhou
  {
    private int CtrlCircle = 1;
    private KeyClass KC = new KeyClass();

    public MyPlane_Sanae(StageDataPackage StageData, Point OriginalPosition)
      : base(StageData, OriginalPosition, "Sanae")
    {
      this.WeaponType = "A";
      List<BaseSubPlane> baseSubPlaneList1 = new List<BaseSubPlane>();
      baseSubPlaneList1.Add((BaseSubPlane) new SubPlane_Sanae(StageData, this.Position));
      baseSubPlaneList1.Add((BaseSubPlane) new SubPlane_Sanae(StageData, this.Position));
      List<BaseSubPlane> baseSubPlaneList2 = baseSubPlaneList1;
      SubPlane_Sanae subPlaneSanae1 = new SubPlane_Sanae(StageData, this.Position);
      subPlaneSanae1.Mirrored = true;
      SubPlane_Sanae subPlaneSanae2 = subPlaneSanae1;
      baseSubPlaneList2.Add((BaseSubPlane) subPlaneSanae2);
      List<BaseSubPlane> baseSubPlaneList3 = baseSubPlaneList1;
      SubPlane_Sanae subPlaneSanae3 = new SubPlane_Sanae(StageData, this.Position);
      subPlaneSanae3.Mirrored = true;
      SubPlane_Sanae subPlaneSanae4 = subPlaneSanae3;
      baseSubPlaneList3.Add((BaseSubPlane) subPlaneSanae4);
      this.SubPlaneList = baseSubPlaneList1;
      this.HighSpeed = 4.5f;
      this.LowSpeed = 2f;
    }

    public override void Shoot()
    {
      if (this.Time % 3 == 0)
      {
        this.StageData.SoundPlay("se_plst00.wav", this.OriginalPosition.X / (float) this.BoundRect.Width);
        float x = this.OriginalPosition.X;
        float y = this.OriginalPosition.Y;
        BaseMyBullet_Touhou baseMyBulletTouhou1 = new BaseMyBullet_Touhou(this.StageData, "SanaeBullet00", new PointF(x + 7f, y), 30f, -1.0 * Math.PI / 2.0);
        BaseMyBullet_Touhou baseMyBulletTouhou2 = new BaseMyBullet_Touhou(this.StageData, "SanaeBullet00", new PointF(x - 7f, y), 30f, -1.0 * Math.PI / 2.0);
      }
      if (this.Time % 4 != 0)
        return;
      for (int index = 0; index < this.PowerLevel; ++index)
        this.SubPlaneList[index].Shoot();
    }

    public override void SpellShoot()
    {
      Spell_Sanae spellSanae = new Spell_Sanae(this.StageData);
    }

    public override void SubPlaneCtrl()
    {
      if (this.KClass.Key_Shift)
      {
        switch (this.PowerLevel)
        {
          case 1:
            this.SubPlanePoint[0] = new PointF(this.OriginalPosition.X, this.OriginalPosition.Y - 30f);
            this.SubPlaneList[0].ShootDirection = -1.0 * Math.PI / 2.0;
            break;
          case 2:
            ref PointF local1 = ref this.SubPlanePoint[0];
            double num1 = (double) this.OriginalPosition.X - 10.0;
            PointF originalPosition1 = this.OriginalPosition;
            double num2 = (double) originalPosition1.Y - 30.0;
            PointF pointF1 = new PointF((float) num1, (float) num2);
            local1 = pointF1;
            ref PointF local2 = ref this.SubPlanePoint[1];
            originalPosition1 = this.OriginalPosition;
            double num3 = (double) originalPosition1.X + 10.0;
            originalPosition1 = this.OriginalPosition;
            double num4 = (double) originalPosition1.Y - 30.0;
            PointF pointF2 = new PointF((float) num3, (float) num4);
            local2 = pointF2;
            this.SubPlaneList[0].ShootDirection = -1.0 * Math.PI / 2.0;
            this.SubPlaneList[1].ShootDirection = -1.0 * Math.PI / 2.0;
            break;
          case 3:
            ref PointF local3 = ref this.SubPlanePoint[2];
            double x1 = (double) this.OriginalPosition.X;
            PointF originalPosition2 = this.OriginalPosition;
            double num5 = (double) originalPosition2.Y - 30.0;
            PointF pointF3 = new PointF((float) x1, (float) num5);
            local3 = pointF3;
            ref PointF local4 = ref this.SubPlanePoint[1];
            originalPosition2 = this.OriginalPosition;
            double num6 = (double) originalPosition2.X - 7.0;
            originalPosition2 = this.OriginalPosition;
            double num7 = (double) originalPosition2.Y - 30.0;
            PointF pointF4 = new PointF((float) num6, (float) num7);
            local4 = pointF4;
            ref PointF local5 = ref this.SubPlanePoint[0];
            originalPosition2 = this.OriginalPosition;
            double num8 = (double) originalPosition2.X + 7.0;
            originalPosition2 = this.OriginalPosition;
            double num9 = (double) originalPosition2.Y - 30.0;
            PointF pointF5 = new PointF((float) num8, (float) num9);
            local5 = pointF5;
            this.SubPlaneList[2].ShootDirection = -1.0 * Math.PI / 2.0;
            this.SubPlaneList[1].ShootDirection = -1.0 * Math.PI / 2.0;
            this.SubPlaneList[0].ShootDirection = -1.0 * Math.PI / 2.0;
            break;
          case 4:
            ref PointF local6 = ref this.SubPlanePoint[3];
            double num10 = (double) this.OriginalPosition.X - 6.0;
            PointF originalPosition3 = this.OriginalPosition;
            double num11 = (double) originalPosition3.Y - 30.0;
            PointF pointF6 = new PointF((float) num10, (float) num11);
            local6 = pointF6;
            ref PointF local7 = ref this.SubPlanePoint[2];
            originalPosition3 = this.OriginalPosition;
            double num12 = (double) originalPosition3.X + 6.0;
            originalPosition3 = this.OriginalPosition;
            double num13 = (double) originalPosition3.Y - 30.0;
            PointF pointF7 = new PointF((float) num12, (float) num13);
            local7 = pointF7;
            ref PointF local8 = ref this.SubPlanePoint[1];
            originalPosition3 = this.OriginalPosition;
            double num14 = (double) originalPosition3.X - 12.0;
            originalPosition3 = this.OriginalPosition;
            double num15 = (double) originalPosition3.Y - 30.0;
            PointF pointF8 = new PointF((float) num14, (float) num15);
            local8 = pointF8;
            ref PointF local9 = ref this.SubPlanePoint[0];
            originalPosition3 = this.OriginalPosition;
            double num16 = (double) originalPosition3.X + 12.0;
            originalPosition3 = this.OriginalPosition;
            double num17 = (double) originalPosition3.Y - 30.0;
            PointF pointF9 = new PointF((float) num16, (float) num17);
            local9 = pointF9;
            this.SubPlaneList[3].ShootDirection = -1.0 * Math.PI / 2.0;
            this.SubPlaneList[2].ShootDirection = -1.0 * Math.PI / 2.0;
            this.SubPlaneList[1].ShootDirection = -1.0 * Math.PI / 2.0;
            this.SubPlaneList[0].ShootDirection = -1.0 * Math.PI / 2.0;
            break;
        }
      }
      else
      {
        switch (this.PowerLevel)
        {
          case 1:
            this.SubPlanePoint[0] = new PointF(this.OriginalPosition.X, this.OriginalPosition.Y + 30f);
            this.SubPlaneList[0].ShootDirection = -1.0 * Math.PI / 2.0;
            break;
          case 2:
            ref PointF local10 = ref this.SubPlanePoint[0];
            double num18 = (double) this.OriginalPosition.X - 36.0;
            PointF originalPosition4 = this.OriginalPosition;
            double num19 = (double) originalPosition4.Y + 0.0;
            PointF pointF10 = new PointF((float) num18, (float) num19);
            local10 = pointF10;
            ref PointF local11 = ref this.SubPlanePoint[1];
            originalPosition4 = this.OriginalPosition;
            double num20 = (double) originalPosition4.X + 36.0;
            originalPosition4 = this.OriginalPosition;
            double num21 = (double) originalPosition4.Y - 0.0;
            PointF pointF11 = new PointF((float) num20, (float) num21);
            local11 = pointF11;
            this.SubPlaneList[0].ShootDirection = -1.66079633037118;
            this.SubPlaneList[1].ShootDirection = -1.48079632321862;
            break;
          case 3:
            ref PointF local12 = ref this.SubPlanePoint[2];
            double x2 = (double) this.OriginalPosition.X;
            PointF originalPosition5 = this.OriginalPosition;
            double num22 = (double) originalPosition5.Y + 30.0;
            PointF pointF12 = new PointF((float) x2, (float) num22);
            local12 = pointF12;
            ref PointF local13 = ref this.SubPlanePoint[1];
            originalPosition5 = this.OriginalPosition;
            double num23 = (double) originalPosition5.X - 36.0;
            originalPosition5 = this.OriginalPosition;
            double num24 = (double) originalPosition5.Y + 0.0;
            PointF pointF13 = new PointF((float) num23, (float) num24);
            local13 = pointF13;
            ref PointF local14 = ref this.SubPlanePoint[0];
            originalPosition5 = this.OriginalPosition;
            double num25 = (double) originalPosition5.X + 36.0;
            originalPosition5 = this.OriginalPosition;
            double num26 = (double) originalPosition5.Y + 0.0;
            PointF pointF14 = new PointF((float) num25, (float) num26);
            local14 = pointF14;
            this.SubPlaneList[2].ShootDirection = -1.0 * Math.PI / 2.0;
            this.SubPlaneList[1].ShootDirection = -1.66079633037118;
            this.SubPlaneList[0].ShootDirection = -1.48079632321862;
            break;
          case 4:
            ref PointF local15 = ref this.SubPlanePoint[3];
            double num27 = (double) this.OriginalPosition.X - 36.0;
            PointF originalPosition6 = this.OriginalPosition;
            double num28 = (double) originalPosition6.Y + 0.0;
            PointF pointF15 = new PointF((float) num27, (float) num28);
            local15 = pointF15;
            ref PointF local16 = ref this.SubPlanePoint[2];
            originalPosition6 = this.OriginalPosition;
            double num29 = (double) originalPosition6.X + 36.0;
            originalPosition6 = this.OriginalPosition;
            double num30 = (double) originalPosition6.Y + 0.0;
            PointF pointF16 = new PointF((float) num29, (float) num30);
            local16 = pointF16;
            ref PointF local17 = ref this.SubPlanePoint[1];
            originalPosition6 = this.OriginalPosition;
            double num31 = (double) originalPosition6.X - 66.0;
            originalPosition6 = this.OriginalPosition;
            double num32 = (double) originalPosition6.Y + 0.0;
            PointF pointF17 = new PointF((float) num31, (float) num32);
            local17 = pointF17;
            ref PointF local18 = ref this.SubPlanePoint[0];
            originalPosition6 = this.OriginalPosition;
            double num33 = (double) originalPosition6.X + 66.0;
            originalPosition6 = this.OriginalPosition;
            double num34 = (double) originalPosition6.Y + 0.0;
            PointF pointF18 = new PointF((float) num33, (float) num34);
            local18 = pointF18;
            this.SubPlaneList[3].ShootDirection = -1.0 * Math.PI / 2.0;
            this.SubPlaneList[2].ShootDirection = -1.0 * Math.PI / 2.0;
            this.SubPlaneList[1].ShootDirection = -1.66079633037118;
            this.SubPlaneList[0].ShootDirection = -1.48079632321862;
            break;
        }
      }
      for (int index = 0; index < this.PowerLevel; ++index)
      {
        this.SubPlaneList[index].Enabled = true;
        this.SubPlaneList[index].DestPoint = this.SubPlanePoint[index];
        this.SubPlaneList[index].Ctrl();
      }
      for (int powerLevel = this.PowerLevel; powerLevel < this.SubPlaneList.Count; ++powerLevel)
      {
        this.SubPlaneList[powerLevel].Enabled = false;
        this.SubPlaneList[powerLevel].Position = this.Position;
      }
    }


        public override void Ctrl() {
       /*     if(this.Time%this.CtrlCircle==0) {
                this.KC=new KeyClass();
                this.KC.Key_Z=true;
                Vector2 move = this.GenerateMove();
                double num1 = -(double)move.X;
                double num2 = -(double)move.Y;
                if((double)move.Length()<80.0)
                    this.KC.Key_Shift=true;
                if(num1>1.0)
                    this.KC.ArrowLeft=true;
                else if(num1<-1.0)
                    this.KC.ArrowRight=true;
                if(num2>1.0)
                    this.KC.ArrowUp=true;
                else if(num2<-1.0)
                    this.KC.ArrowDown=true;
            }
            this.BulletList.ForEach((Action<BaseBullet_Touhou>)(x =>
            {
                if(!x.HitCheck((BaseObject)this,(float)x.Region)&&this.DeadTime<=this.Time)
                    return;
                this.KC.Key_X=true;
            }));
            this.StageData.GlobalData.KClass.Hex2Key(this.KC.Key2Hex());
            */
            base.Ctrl();
        }

        private double GenerateDanger(PointF OriginalPos) {
            double tmp = 0.0;
            double d;
            this.BulletList.ForEach((Action<BaseBullet_Touhou>)(x =>
            {
                Vector2 vector2_1 = new Vector2(OriginalPos.X,OriginalPos.Y);
                Vector2 vector2_2 = new Vector2();
                ref Vector2 local = ref vector2_2;
                PointF originalPosition = x.OriginalPosition;
                double x1 = (double)originalPosition.X;
                originalPosition=x.OriginalPosition;
                double y = (double)originalPosition.Y;
                local=new Vector2((float)x1,(float)y);
                d=(double)(vector2_1-vector2_2).Length()-(double)this.Region-(double)x.Region;
                if(d>=200.0)
                    return;
                tmp+=7000.0/d/d;
                Vector2 vector2_3 = x.Velocity*new Vector2((float)Math.Cos(x.Direction),(float)Math.Sin(x.Direction));
                Vector2 vector2_4 = vector2_2+(float)this.GetDistance(OriginalPos)/5f*vector2_3;
                d=(double)(vector2_1-vector2_4).Length()-(double)this.Region-(double)x.Region;
                tmp+=3000.0/d/d;
            }));
            this.EnemyPlaneList.ForEach((Action<BaseEnemyPlane>)(x =>
            {
                PointF originalPosition;
                int num;
                if((double)x.OriginalPosition.X>0.0) {
                    originalPosition=x.OriginalPosition;
                    if((double)originalPosition.X<(double)this.BoundRect.Width) {
                        originalPosition=x.OriginalPosition;
                        if((double)originalPosition.Y>0.0) {
                            originalPosition=x.OriginalPosition;
                            num=(double)originalPosition.Y>=(double)this.BoundRect.Height ? 1 : 0;
                            goto label_5;
                        }
                    }
                }
                num=1;
                label_5:
                if(num!=0)
                    return;
                Vector2 vector2_1 = new Vector2(OriginalPos.X,OriginalPos.Y);
                Vector2 vector2_2 = new Vector2();
                ref Vector2 local = ref vector2_2;
                originalPosition=x.OriginalPosition;
                double x1 = (double)originalPosition.X;
                originalPosition=x.OriginalPosition;
                double y = (double)originalPosition.Y;
                local=new Vector2((float)x1,(float)y);
                d=(double)(vector2_1-vector2_2).Length()-(double)this.Region-(double)x.Region;
                tmp+=10000.0/d/d;
            }));
            if(this.Boss!=null) {
                d=this.Boss.GetDistance(OriginalPos)-(double)this.Boss.Region-(double)this.Region;
                tmp+=10000.0/d/d;
            }
            return tmp;
        }

        private Vector2 GenerateDestPoint(int div,int count,float x,float y) {
            Vector2 vector2 = Vector2.Zero;
            double num1 = 1000000000.0;
            double num2 = 0.0;
            x-=(float)(div*(count-1)/2);
            y-=(float)(div*(count-1)/2);
            Rectangle boundRect;
            if((double)x<0.0) {
                x=0.0f;
            } else {
                double num3 = (double)x;
                boundRect=this.BoundRect;
                double num4 = (double)(boundRect.Width-div*(count-1));
                if(num3>num4) {
                    boundRect=this.BoundRect;
                    x=(float)(boundRect.Width-div*(count-1));
                }
            }
            if((double)y<0.0) {
                y=0.0f;
            } else {
                double num3 = (double)y;
                boundRect=this.BoundRect;
                double num4 = (double)(boundRect.Height-div*(count-1));
                if(num3>num4) {
                    boundRect=this.BoundRect;
                    y=(float)(boundRect.Height-div*(count-1));
                }
            }
            for(int index1 = 0;index1<count;++index1) {
                for(int index2 = 0;index2<count;++index2) {
                    double danger = this.GenerateDanger(new PointF(x,y));
                    if(danger<num1) {
                        num1=danger;
                        vector2=new Vector2(x,y);
                    }
                    if(danger>num2)
                        num2=danger;
                    x+=(float)div;
                }
                y+=(float)div;
                x-=(float)(div*count);
            }
            if(num2>2.0)
                return vector2;
            PointF originalPosition = this.OriginalPosition;
            double x1 = (double)originalPosition.X;
            originalPosition=this.OriginalPosition;
            double y1 = (double)originalPosition.Y;
            return new Vector2((float)x1,(float)y1);
        }

        private Vector2 GenerateMove() {
            Vector2 forceSum = Vector2.Zero;
            float d;
            this.BulletList.ForEach((Action<BaseBullet_Touhou>)(x =>
            {
                Vector2 vector2_1 = new Vector2();
                ref Vector2 local1 = ref vector2_1;
                PointF originalPosition1 = this.OriginalPosition;
                double x1 = (double)originalPosition1.X;
                originalPosition1=this.OriginalPosition;
                double y1 = (double)originalPosition1.Y;
                local1=new Vector2((float)x1,(float)y1);
                Vector2 vector2_2 = new Vector2();
                ref Vector2 local2 = ref vector2_2;
                PointF originalPosition2 = x.OriginalPosition;
                double x2 = (double)originalPosition2.X;
                originalPosition2=x.OriginalPosition;
                double y2 = (double)originalPosition2.Y;
                local2=new Vector2((float)x2,(float)y2);
                Vector2 vector2_3 = vector2_1-vector2_2;
                d=vector2_3.Length()-(float)this.Region-(float)x.Region;
                if((double)d>=200.0)
                    return;
                vector2_3.Normalize();
                vector2_3*=5000f/d/d;
                forceSum+=vector2_3;
                Vector2 vector2_4 = x.Velocity*new Vector2((float)Math.Cos(x.Direction),(float)Math.Sin(x.Direction));
                Vector2 vector2_5 = vector2_2+3f*vector2_4;
                Vector2 vector2_6 = vector2_1-vector2_5;
                d=vector2_6.Length()-(float)this.Region-(float)x.Region;
                vector2_6.Normalize();
                forceSum+=vector2_6*(5000f/d/d);
                Vector2 vector2_7 = vector2_5+6f*vector2_4;
                Vector2 vector2_8 = vector2_1-vector2_7;
                d=vector2_8.Length()-(float)this.Region-(float)x.Region;
                vector2_8.Normalize();
                vector2_8*=2000f/d/d;
                forceSum+=vector2_8;
            }));
            this.EnemyPlaneList.ForEach((Action<BaseEnemyPlane>)(x =>
            {
                PointF originalPosition;
                int num;
                if((double)x.OriginalPosition.X>0.0) {
                    originalPosition=x.OriginalPosition;
                    if((double)originalPosition.X<(double)this.BoundRect.Width) {
                        originalPosition=x.OriginalPosition;
                        if((double)originalPosition.Y>0.0) {
                            originalPosition=x.OriginalPosition;
                            num=(double)originalPosition.Y>=(double)this.BoundRect.Height ? 1 : 0;
                            goto label_5;
                        }
                    }
                }
                num=1;
                label_5:
                if(num!=0)
                    return;
                Vector2 vector2_1 = new Vector2();
                ref Vector2 local1 = ref vector2_1;
                originalPosition=this.OriginalPosition;
                double x1 = (double)originalPosition.X;
                originalPosition=this.OriginalPosition;
                double y1 = (double)originalPosition.Y;
                local1=new Vector2((float)x1,(float)y1);
                Vector2 vector2_2 = new Vector2();
                ref Vector2 local2 = ref vector2_2;
                originalPosition=x.OriginalPosition;
                double x2 = (double)originalPosition.X;
                originalPosition=x.OriginalPosition;
                double y2 = (double)originalPosition.Y;
                local2=new Vector2((float)x2,(float)y2);
                Vector2 vector2_3 = vector2_1-vector2_2;
                d=vector2_3.Length()-(float)this.Region-(float)x.Region;
                vector2_3.Normalize();
                forceSum+=vector2_3*(5000f/d/d);
                Vector2 vector2_4 = x.Velocity*new Vector2((float)Math.Cos(x.Direction),(float)Math.Sin(x.Direction));
                Vector2 vector2_5 = vector2_2+5f*vector2_4;
                Vector2 vector2_6 = vector2_1-vector2_5;
                d=vector2_6.Length()-(float)this.Region-(float)x.Region;
                vector2_6.Normalize();
                forceSum+=vector2_6*(5000f/d/d);
            }));
            PointF pointF;
            if(this.Boss!=null) {
                Vector2 vector2_1 = new Vector2();
                ref Vector2 local1 = ref vector2_1;
                pointF=this.OriginalPosition;
                double x1 = (double)pointF.X;
                pointF=this.OriginalPosition;
                double y1 = (double)pointF.Y;
                local1=new Vector2((float)x1,(float)y1);
                Vector2 vector2_2 = new Vector2();
                ref Vector2 local2 = ref vector2_2;
                pointF=this.Boss.OriginalPosition;
                double x2 = (double)pointF.X;
                pointF=this.Boss.OriginalPosition;
                double y2 = (double)pointF.Y;
                local2=new Vector2((float)x2,(float)y2);
                Vector2 vector2_3 = vector2_1-vector2_2;
                d=vector2_3.Length()-(float)this.Region-(float)this.Boss.Region;
                vector2_3.Normalize();
                Vector2 vector2_4 = vector2_3*(10000f/d/d);
                forceSum+=vector2_4;
            }
            pointF=this.OriginalPosition;
            double x3 = (double)pointF.X;
            pointF=this.OriginalPosition;
            double y3 = (double)pointF.Y;
            Vector2 destPoint = this.GenerateDestPoint(40,4,(float)x3,(float)y3);
            Vector2 start = this.GenerateDestPoint(10,4,destPoint.X,destPoint.Y);
            start=this.GenerateDestPoint(2,5,start.X,start.Y);
            Vector2 end = new Vector2();
            ref Vector2 local3 = ref end;
            pointF=this.DestPoint;
            double x4 = (double)pointF.X;
            pointF=this.DestPoint;
            double y4 = (double)pointF.Y;
            local3=new Vector2((float)x4,(float)y4);
            if(this.Time>300)
                start=Vector2.Lerp(start,end,0.5f);
            Vector2 vector2_9 = new Vector2();
            ref Vector2 local4 = ref vector2_9;
            pointF=this.OriginalPosition;
            double x5 = (double)pointF.X;
            pointF=this.OriginalPosition;
            double y5 = (double)pointF.Y;
            local4=new Vector2((float)x5,(float)y5);
            Vector2 vector2_10 = start-vector2_9;
            forceSum+=1f*vector2_10;
            this.DestPoint=new PointF(start.X,start.Y);
            if(this.Boss!=null) {
                Vector2 vector2_1 = forceSum;
                pointF=this.Boss.OriginalPosition;
                double x1 = (double)pointF.X;
                pointF=this.OriginalPosition;
                double x2 = (double)pointF.X;
                Vector2 vector2_2 = new Vector2((float)(5.0*(x1-x2)),0.0f);
                forceSum=vector2_1+vector2_2;
            } else {
                Vector2 vector2_1 = forceSum;
                Rectangle boundRect = this.BoundRect;
                double num1 = (double)(boundRect.Width/2);
                pointF=this.OriginalPosition;
                double x1 = (double)pointF.X;
                double num2 = 0.100000001490116*(num1-x1);
                boundRect=this.BoundRect;
                double height = (double)boundRect.Height;
                pointF=this.OriginalPosition;
                double y1 = (double)pointF.Y;
                double num3 = 0.100000001490116*(height-y1);
                Vector2 vector2_2 = new Vector2((float)num2,(float)num3);
                forceSum=vector2_1+vector2_2;
                forceSum+=this.GenerateEnemyBeat();
            }
            forceSum+=this.GenerateItemGet();
            return forceSum;
        }

        private Vector2 GenerateEnemyBeat() {
            Vector2 vector2 = Vector2.Zero;
            float tmp = 1000f;
            this.EnemyPlaneList.ForEach((Action<BaseEnemyPlane>)(x =>
            {
                PointF originalPosition;
                int num;
                if((double)x.OriginalPosition.Y>0.0) {
                    originalPosition=x.OriginalPosition;
                    if((double)originalPosition.Y<300.0) {
                        num=(double)x.HealthPoint>=20000.0 ? 1 : 0;
                        goto label_4;
                    }
                }
                num=1;
                label_4:
                if(num!=0)
                    return;
                originalPosition=x.OriginalPosition;
                double x1 = (double)originalPosition.X;
                originalPosition=this.OriginalPosition;
                double x2 = (double)originalPosition.X;
                if((double)Math.Abs((float)(x1-x2))<(double)tmp) {
                    originalPosition=x.OriginalPosition;
                    tmp=originalPosition.X;
                }
            }));
            if((double)tmp<1000.0)
                vector2=new Vector2((float)(10.0*((double)tmp-(double)this.OriginalPosition.X)),0.0f);
            return vector2;
        }

        private Vector2 GenerateItemGet() {
            if(this.BulletList.Count>10||this.Boss!=null)
                return Vector2.Zero;
            int itemCount = 0;
            this.ItemList.ForEach((Action<BaseItem>)(x =>
            {
                if(x.Obtain)
                    return;
                ++itemCount;
            }));
            if(itemCount>5)
                return new Vector2(0.0f,(float)(2.0*(110.0-(double)this.OriginalPosition.Y)));
            return Vector2.Zero;
        }
    }
}
