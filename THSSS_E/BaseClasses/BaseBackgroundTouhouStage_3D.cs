 
// Type: Shooting.BaseBackgroundTouhouStage_3D
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using SlimDX.Direct3D9;
using System.Drawing;

namespace Shooting
{
  internal class BaseBackgroundTouhouStage_3D : BaseObject
  {
    public VertexBuffer vertexBuffer;
    public VertexDeclaration vertexDecl;
    public Material material;

    public Device DeviceMain
    {
      get
      {
        return this.StageData.DeviceMain;
      }
    }

    public BaseBackgroundTouhouStage_3D(StageDataPackage StageData, string textureName)
      : base(StageData, textureName, new PointF(0.0f, 0.0f), 0.0f, 0.0)
    {
      this.OriginalPosition = new PointF(0.0f, 0.0f);
      this.Background3D.BackgroundList.Add((BaseObject) this);
      this.vertexDecl = new VertexDeclaration(this.DeviceMain, TexturedVertex.VertexElements);
    }

    public void SetupMaterial()
    {
      this.material = new Material();
      this.material.Diffuse = new Color4(Color.FromArgb(this.TransparentValue, this.ColorValue));
      this.material.Ambient = new Color4(Color.FromArgb(this.TransparentValue, this.ColorValue));
    }

    public override bool OutBoundary()
    {
      return false;
    }

    public virtual void SetupVertex()
    {
    }

    public virtual void SetupMatrices()
    {
      this.DeviceMain.SetTransform(TransformState.World, Matrix.Identity);
    }

    public override void Show()
    {
      this.SetupVertex();
      this.SetupMaterial();
      this.SetupMatrices();
      this.DeviceMain.Material = this.material;
      this.DeviceMain.SetTexture(0, (BaseTexture) this.TxtureObject.TXTure);
      this.DeviceMain.SetStreamSource(0, this.vertexBuffer, 0, TexturedVertex.SizeBytes);
      this.DeviceMain.VertexDeclaration = this.vertexDecl;
      this.DeviceMain.VertexFormat = TexturedVertex.Format;
    }

    public override void Dispose()
    {
      if (this.vertexBuffer == null)
        return;
      this.vertexBuffer.Dispose();
      this.vertexDecl.Dispose();
    }
  }
}
