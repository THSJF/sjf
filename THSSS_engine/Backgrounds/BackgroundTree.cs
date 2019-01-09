 
// Type: Shooting.BackgroundTree
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using SlimDX.Direct3D9;
using System;
using System.Drawing;

namespace Shooting
{
  internal class BackgroundTree : BaseObject
  {
    public IModel model { get; set; }

    public float CameraAngle { get; set; }

    public int Height { get; set; }

    public Device DeviceMain
    {
      get
      {
        return this.StageData.DeviceMain;
      }
    }

    public BackgroundTree(
      StageDataPackage StageData,
      string modelName,
      PointF OriginalPosition,
      bool InsertAtFirst)
      : base(StageData, (string) null, new PointF(0.0f, 0.0f), 0.0f, 0.0)
    {
      this.OriginalPosition = OriginalPosition;
      if (modelName != null)
        this.model = StageData.ModelDictionary[modelName];
      if (InsertAtFirst)
        this.Background3D.BackgroundList.Insert(0, (BaseObject) this);
      else
        this.Background3D.BackgroundList.Add((BaseObject) this);
    }

    public override bool OutBoundary()
    {
      return this.Time > this.LifeTime && this.LifeTime != 0;
    }

    private void SetupMatrices()
    {
      this.CameraAngle = this.StageData.Background3D.Envi.CameraAngle - 1.570796f;
      Matrix matrix1 = Matrix.Identity * Matrix.RotationZ((float) this.Angle) * Matrix.Scaling(new Vector3(this.Scale, this.Scale, this.Scale));
      if (this.Mirrored)
        matrix1 *= Matrix.RotationY(3.141593f);
      Matrix matrix2 = matrix1 * Matrix.RotationX(this.CameraAngle);
      PointF originalPosition = this.OriginalPosition;
      double x = (double) originalPosition.X;
      originalPosition = this.OriginalPosition;
      double y = (double) originalPosition.Y;
      double num = (double) (this.model.TxtureObject.Height / 2 + this.Height) * (double) this.Scale * Math.Cos(-(double) this.CameraAngle - Math.PI / 2.0);
      Matrix matrix3 = Matrix.Translation((float) x, (float) y, (float) num);
      this.DeviceMain.SetTransform(TransformState.World, matrix2 * matrix3);
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
      this.model.SetModel();
      this.model.Draw();
    }

    public override void Dispose()
    {
    }
  }
}
