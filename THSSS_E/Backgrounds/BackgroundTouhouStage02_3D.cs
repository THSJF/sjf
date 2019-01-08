 
// Type: Shooting.BackgroundTouhouStage02_3D
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using SlimDX.Direct3D9;

namespace Shooting
{
  internal class BackgroundTouhouStage02_3D : BaseBackgroundTouhouStage_3D
  {
    public BackgroundTouhouStage02_3D(StageDataPackage StageData)
      : base(StageData, " ")
    {
      this.vertexBuffer = new VertexBuffer(this.DeviceMain, 14 * TexturedVertex.SizeBytes, Usage.WriteOnly, VertexFormat.None, Pool.Managed);
    }

    public override void SetupVertex()
    {
      this.vertexBuffer.Lock(0, 0, LockFlags.Discard).WriteRange<TexturedVertex>(new TexturedVertex[14]
      {
        new TexturedVertex(new Vector3(-500f, 6000f, 0.0f), new Vector2(0.0f, 0.0f)),
        new TexturedVertex(new Vector3(500f, 6000f, 0.0f), new Vector2(1f, 0.0f)),
        new TexturedVertex(new Vector3(-500f, 5000f, 0.0f), new Vector2(0.0f, 1f)),
        new TexturedVertex(new Vector3(500f, 5000f, 0.0f), new Vector2(1f, 1f)),
        new TexturedVertex(new Vector3(-500f, 4000f, 0.0f), new Vector2(0.0f, 0.0f)),
        new TexturedVertex(new Vector3(500f, 4000f, 0.0f), new Vector2(1f, 0.0f)),
        new TexturedVertex(new Vector3(-500f, 3000f, 0.0f), new Vector2(0.0f, 1f)),
        new TexturedVertex(new Vector3(500f, 3000f, 0.0f), new Vector2(1f, 1f)),
        new TexturedVertex(new Vector3(-500f, 2000f, 0.0f), new Vector2(0.0f, 0.0f)),
        new TexturedVertex(new Vector3(500f, 2000f, 0.0f), new Vector2(1f, 0.0f)),
        new TexturedVertex(new Vector3(-500f, 1000f, 0.0f), new Vector2(0.0f, 1f)),
        new TexturedVertex(new Vector3(500f, 1000f, 0.0f), new Vector2(1f, 1f)),
        new TexturedVertex(new Vector3(-500f, 0.0f, 0.0f), new Vector2(0.0f, 0.0f)),
        new TexturedVertex(new Vector3(500f, 0.0f, 0.0f), new Vector2(1f, 0.0f))
      });
      this.vertexBuffer.Unlock();
    }

    public override void Show()
    {
      base.Show();
      this.DeviceMain.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 12);
    }
  }
}
