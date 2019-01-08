 
// Type: Shooting.StageTitle3D
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using SlimDX.Direct3D9;
using System.Drawing;

namespace Shooting
{
  public class StageTitle3D : BaseParticle3D
  {
    protected int Length = 40;
    protected VertexBuffer vertexBuffer;
    protected VertexDeclaration vertexDecl;
    protected Material material;

    public StageTitle3D(StageDataPackage StageData, string TextureName)
    {
      this.StageData = StageData;
      Rectangle boundRect = this.BoundRect;
      double num1 = (double) (boundRect.Width / 2);
      boundRect = this.BoundRect;
      double num2 = (double) (boundRect.Height / 2);
      this.OriginalPosition = new PointF((float) num1, (float) num2);
      if (TextureName != null)
        this.TxtureObject = this.TextureObjectDictionary[TextureName];
      StageData.Particle3D.ParticleList.Add((BaseParticle3D) this);
      this.vertexDecl = new VertexDeclaration(this.DeviceMain, TexturedColoredVertex.VertexElements);
      this.vertexBuffer = new VertexBuffer(this.DeviceMain, 2 * this.Length * TexturedColoredVertex.SizeBytes, Usage.WriteOnly, VertexFormat.None, Pool.Managed);
      this.material = new Material();
      this.SetupVertex();
      this.LifeTime = 300;
      this.TransparentValueF = 0.0f;
      this.ColorValue = Color.White;
      this.Active = false;
    }

    public virtual void SetupVertex()
    {
      DataStream dataStream = this.vertexBuffer.Lock(0, 0, LockFlags.Discard);
      float x1 = -this.TxtureObject.RotatingCenter.X;
      float x2 = (float) this.TxtureObject.Width - this.TxtureObject.RotatingCenter.X;
      float num1 = -this.TxtureObject.RotatingCenter.Y;
      float num2 = (float) this.TxtureObject.Height - this.TxtureObject.RotatingCenter.Y;
      float x3 = (float) this.TxtureObject.PosRect.X / (float) this.TxtureObject.SrcWidth;
      float x4 = (float) (this.TxtureObject.PosRect.X + this.TxtureObject.Width) / (float) this.TxtureObject.SrcWidth;
      float num3 = (float) this.TxtureObject.PosRect.Y / (float) this.TxtureObject.SrcHeight;
      float num4 = (float) (this.TxtureObject.PosRect.Y + this.TxtureObject.Height) / (float) this.TxtureObject.SrcHeight;
      TexturedColoredVertex[] data = new TexturedColoredVertex[2 * this.Length];
      for (int index = 0; index < this.Length; ++index)
      {
        int alpha = -10 * index + this.Time * 3;
        if (alpha < 0)
          alpha = 0;
        else if (alpha > this.TransparentValue)
          alpha = this.TransparentValue;
        data[2 * index] = new TexturedColoredVertex(new Vector3(x1, num1 + (num2 - num1) * (float) index / (float) this.Length, 0.0f), new Vector2(x3, num3 + (num4 - num3) * (float) index / (float) this.Length), Color.FromArgb(alpha, this.ColorValue).ToArgb());
        data[2 * index + 1] = new TexturedColoredVertex(new Vector3(x2, num1 + (num2 - num1) * (float) index / (float) this.Length, 0.0f), new Vector2(x4, num3 + (num4 - num3) * (float) index / (float) this.Length), Color.FromArgb(alpha, this.ColorValue).ToArgb());
      }
      dataStream.WriteRange<TexturedColoredVertex>(data);
      this.vertexBuffer.Unlock();
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time < this.LifeTime / 3)
      {
        this.TransparentValueF += (float) this.MaxTransparent * 3f / (float) this.LifeTime;
      }
      else
      {
        if (this.Time <= this.LifeTime * 2 / 3)
          return;
        this.TransparentValueF -= (float) this.MaxTransparent * 3f / (float) this.LifeTime;
      }
    }

    public override void Show()
    {
      this.DeviceMain.EnableLight(0, false);
      this.DeviceMain.SetRenderState(RenderState.Lighting, false);
      this.DeviceMain.VertexDeclaration = this.vertexDecl;
      this.DeviceMain.VertexFormat = TexturedColoredVertex.Format;
      this.SetupVertex();
      this.DeviceMain.SetStreamSource(0, this.vertexBuffer, 0, TexturedColoredVertex.SizeBytes);
      this.DeviceMain.SetTexture(0, (BaseTexture) this.TxtureObject.TXTure);
      this.SetupMatrices();
      if (this.Active)
        this.DeviceMain.SetRenderState<Blend>(RenderState.DestinationBlend, Blend.One);
      else
        this.DeviceMain.SetRenderState<Blend>(RenderState.DestinationBlend, Blend.InverseSourceAlpha);
      this.material.Diffuse = new Color4(Color.FromArgb(this.TransparentValue, this.ColorValue));
      this.material.Ambient = new Color4(Color.FromArgb(this.TransparentValue, this.ColorValue));
      this.DeviceMain.Material = this.material;
      this.DeviceMain.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2 * this.Length - 2);
      this.DeviceMain.EnableLight(0, true);
      this.DeviceMain.SetRenderState(RenderState.Lighting, true);
      this.DeviceMain.VertexDeclaration = this.StageData.Particle3D.vertexDecl;
      this.DeviceMain.VertexFormat = TexturedVertex.Format;
    }
  }
}
