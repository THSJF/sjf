 
// Type: Shooting.BaseParticle3D
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using SlimDX.Direct3D9;
using System;
using System.Drawing;

namespace Shooting
{
  public class BaseParticle3D : BaseObject
  {
    public IModel model { get; set; }

    public Device DeviceMain
    {
      get
      {
        return this.StageData.DeviceMain;
      }
    }

    public float Depth { get; set; }

    public float MaxDepth { get; set; }

    public double Direction3D { get; set; }

    public Vector3 RotatingAxis { get; set; }

    public float Angle3D { get; set; }

    public float AngularVelocity3D { get; set; }

    public BaseParticle3D(
      StageDataPackage StageData,
      string modelName,
      PointF OriginalPosition,
      float Velocity,
      double Direction)
      : base(StageData, modelName, OriginalPosition, Velocity, Direction)
    {
      this.OriginalPosition = OriginalPosition;
      this.model = StageData.ModelDictionary[modelName];
      this.MaxDepth = 80f;
    }

    public BaseParticle3D()
    {
    }

    public override void Move()
    {
      int num1;
      if (this.DestPoint != new PointF(0.0f, 0.0f))
      {
        PointF destPoint = this.DestPoint;
        num1 = false ? 1 : 0;
      }
      else
        num1 = 1;
      if (num1 == 0)
        this.MovePoint();
      float num2 = this.Velocity * (float) Math.Cos(this.Direction3D);
      this.Position = new PointF(this.Position.X + num2 * (float) Math.Cos(this.Direction), this.Position.Y + num2 * (float) Math.Sin(this.Direction));
      this.Depth += this.Velocity * (float) Math.Sin(this.Direction3D);
      if ((double) this.Depth <= (double) this.MaxDepth)
        return;
      this.Depth = this.MaxDepth;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.Angle3D += this.AngularVelocity3D;
      if ((double) this.Velocity >= 0.0)
        return;
      this.Velocity = 0.0f;
    }

    public virtual void SetupMatrices()
    {
      Matrix identity = Matrix.Identity;
      if (this.Mirrored)
        identity *= Matrix.RotationY(3.141593f);
      Matrix matrix1 = identity * Matrix.Scaling(new Vector3(this.Scale, this.Scale, this.Scale)) * Matrix.RotationZ((float) this.Angle) * Matrix.RotationAxis(this.RotatingAxis, this.Mirrored ? -this.Angle3D : this.Angle3D);
      PointF originalPosition = this.OriginalPosition;
      double num1 = (double) originalPosition.X - (double) (this.StageData.BoundRect.Width / 2);
      originalPosition = this.OriginalPosition;
      double num2 = (double) originalPosition.Y - (double) (this.StageData.BoundRect.Height / 2);
      double depth = (double) this.Depth;
      Matrix matrix2 = Matrix.Translation((float) num1, (float) num2, (float) depth);
      this.DeviceMain.SetTransform(TransformState.World, matrix1 * matrix2);
    }

    public override void Show()
    {
      this.SetupMatrices();
      this.model.TransparentValue = this.TransparentValue;
      this.model.ColorValue = this.ColorValue;
      if (this.Active)
        this.DeviceMain.SetRenderState<Blend>(RenderState.DestinationBlend, Blend.One);
      else
        this.DeviceMain.SetRenderState<Blend>(RenderState.DestinationBlend, Blend.InverseSourceAlpha);
      this.model.Draw();
    }

    public override void Dispose()
    {
    }
  }
}
