using SlimDX;
using SlimDX.Direct3D9;
using System.Drawing;

namespace Shooting
{
  public class Model : IModel
  {
    public VertexBuffer vertexBuffer;
    public VertexDeclaration vertexDecl;
    public Material material;

    public string Name { get; set; }

    public TextureObject TxtureObject { get; set; }

    public Device DeviceMain { get; set; }

    public int TransparentValue { get; set; }

    public Color ColorValue { get; set; }

    public Model()
    {
    }

    public Model(Device DeviceMain, TextureObject TxtureObject, string Name)
    {
      this.TransparentValue = (int) byte.MaxValue;
      this.ColorValue = Color.White;
      this.DeviceMain = DeviceMain;
      this.TxtureObject = TxtureObject;
      this.Name = Name;
      this.vertexDecl = new VertexDeclaration(DeviceMain, TexturedVertex.VertexElements);
      this.vertexBuffer = new VertexBuffer(DeviceMain, 4 * TexturedVertex.SizeBytes, Usage.WriteOnly, VertexFormat.None, Pool.Managed);
      this.material = new Material();
      this.SetupVertex();
    }

    public virtual void SetupVertex()
    {
      DataStream dataStream = this.vertexBuffer.Lock(0, 0, LockFlags.Discard);
      float x1 = -this.TxtureObject.RotatingCenter.X;
      float x2 = (float) this.TxtureObject.Width - this.TxtureObject.RotatingCenter.X;
      float y1 = -this.TxtureObject.RotatingCenter.Y;
      float y2 = (float) this.TxtureObject.Height - this.TxtureObject.RotatingCenter.Y;
      float x3 = (float) this.TxtureObject.PosRect.X / (float) this.TxtureObject.SrcWidth;
      float x4 = (float) (this.TxtureObject.PosRect.X + this.TxtureObject.Width) / (float) this.TxtureObject.SrcWidth;
      float y3 = (float) this.TxtureObject.PosRect.Y / (float) this.TxtureObject.SrcHeight;
      float y4 = (float) (this.TxtureObject.PosRect.Y + this.TxtureObject.Height) / (float) this.TxtureObject.SrcHeight;
      dataStream.WriteRange<TexturedVertex>(new TexturedVertex[4]
      {
        new TexturedVertex(new Vector3(x1, y1, 0.0f), new Vector2(x3, y3)),
        new TexturedVertex(new Vector3(x2, y1, 0.0f), new Vector2(x4, y3)),
        new TexturedVertex(new Vector3(x1, y2, 0.0f), new Vector2(x3, y4)),
        new TexturedVertex(new Vector3(x2, y2, 0.0f), new Vector2(x4, y4))
      });
      this.vertexBuffer.Unlock();
    }

    public void SetupMaterial()
    {
      this.material.Diffuse = new Color4(Color.FromArgb(this.TransparentValue, this.ColorValue));
      this.material.Ambient = new Color4(Color.FromArgb(this.TransparentValue, this.ColorValue));
      this.DeviceMain.Material = this.material;
    }

    public virtual void SetModel()
    {
      this.DeviceMain.SetStreamSource(0, this.vertexBuffer, 0, TexturedVertex.SizeBytes);
      this.DeviceMain.SetTexture(0, (BaseTexture) this.TxtureObject.TXTure);
    }

    public void SetVertexFormat()
    {
      this.DeviceMain.VertexDeclaration = this.vertexDecl;
      this.DeviceMain.VertexFormat = TexturedVertex.Format;
    }

    public virtual void Draw()
    {
      this.SetupMaterial();
      this.DeviceMain.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2);
    }

    public virtual void Dispose()
    {
      if (this.vertexBuffer == null)
        return;
      this.vertexBuffer.Dispose();
      this.vertexDecl.Dispose();
    }
  }
}
