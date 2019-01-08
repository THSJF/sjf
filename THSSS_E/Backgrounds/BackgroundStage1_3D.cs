 
// Type: Shooting.BackgroundStage1_3D
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using SlimDX.Direct3D9;
using System.Drawing;

namespace Shooting
{
  internal class BackgroundStage1_3D : BaseObject
  {
    private float deltaY = 0.0f;
    private VertexBuffer vertexBuffer;
    private VertexDeclaration vertexDecl;

    public Device DeviceMain
    {
      get
      {
        return this.StageData.DeviceMain;
      }
    }

    public BackgroundStage1_3D(StageDataPackage StageData)
      : base(StageData, "Background_Stage1", new PointF(0.0f, 0.0f), 0.0f, 0.0)
    {
      this.Background3D.BackgroundList.Add((BaseObject) this);
      this.vertexDecl = new VertexDeclaration(this.DeviceMain, TexturedVertex.VertexElements);
      this.vertexBuffer = new VertexBuffer(this.DeviceMain, 4 * TexturedVertex.SizeBytes, Usage.WriteOnly, VertexFormat.None, Pool.Managed);
      this.Velocity = 1f;
    }

    public override void Ctrl()
    {
      ++this.Time;
      if (this.Time == 660)
        this.Velocity = 5f;
      this.deltaY += this.Velocity;
      if ((double) this.deltaY <= 1000.0)
        return;
      this.deltaY = 0.0f;
    }

    public override bool OutBoundary()
    {
      return false;
    }

    private void SetupVertex()
    {
      this.vertexBuffer.Lock(0, 0, LockFlags.None).WriteRange<TexturedVertex>(new TexturedVertex[4]
      {
        new TexturedVertex(new Vector3(-1000f, -4000f, 0.0f), new Vector2(0.0f, 4f)),
        new TexturedVertex(new Vector3(1000f, -4000f, 0.0f), new Vector2(1f, 4f)),
        new TexturedVertex(new Vector3(-1000f, 0.0f, 0.0f), new Vector2(0.0f, 0.0f)),
        new TexturedVertex(new Vector3(1000f, 0.0f, 0.0f), new Vector2(1f, 0.0f))
      });
      this.vertexBuffer.Unlock();
    }

    private void SetupMatrices()
    {
      this.DeviceMain.SetTransform(TransformState.World, Matrix.Identity);
      this.DeviceMain.SetTransform(TransformState.View, Matrix.LookAtLH(new Vector3(0.0f, -1400f - this.deltaY, 150f), new Vector3(0.0f, -1500f - this.deltaY, 0.0f), new Vector3(0.0f, -1f, 0.0f)));
    }

    public override void Show()
    {
      this.SetupVertex();
      this.SetupMatrices();
      this.DeviceMain.SetTexture(0, (BaseTexture) this.TxtureObject.TXTure);
      this.DeviceMain.SetStreamSource(0, this.vertexBuffer, 0, TexturedVertex.SizeBytes);
      this.DeviceMain.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2);
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
