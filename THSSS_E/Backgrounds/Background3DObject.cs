// Decompiled with JetBrains decompiler
// Type: Shooting.Background3DObject
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using SlimDX.Direct3D9;
using System.Drawing;

namespace Shooting
{
  internal class Background3DObject : BaseObject
  {
    public IModel model { get; set; }

    public float Angle3DX { get; set; }

    public float Angle3DY { get; set; }

    public float Height { get; set; }

    public float OriginalPositionZ { get; set; }

    public float VelocityZ { get; set; }

    public Device DeviceMain
    {
      get
      {
        return this.StageData.DeviceMain;
      }
    }

    public Background3DObject(
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

    public override void Ctrl()
    {
      base.Ctrl();
      this.OriginalPositionZ += this.VelocityZ;
    }

    public override bool OutBoundary()
    {
      return this.Time > this.LifeTime && this.LifeTime > 0;
    }

    private void SetupMatrices()
    {
      Matrix matrix = Matrix.Identity * Matrix.RotationZ((float) this.Angle) * Matrix.Scaling(new Vector3(this.Scale, this.Scale, this.Scale));
      if (this.Mirrored)
        matrix *= Matrix.RotationY(3.141593f);
      this.DeviceMain.SetTransform(TransformState.World, matrix * Matrix.RotationY(this.Angle3DY) * Matrix.RotationX(this.Angle3DX) * Matrix.Translation(this.OriginalPosition.X, this.OriginalPosition.Y, this.OriginalPositionZ + this.Height));
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
