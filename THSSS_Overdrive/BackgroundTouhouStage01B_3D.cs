// Decompiled with JetBrains decompiler
// Type: Shooting.BackgroundTouhouStage01B_3D
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using SlimDX.Direct3D9;
using System.Drawing;

namespace Shooting
{
  internal class BackgroundTouhouStage01B_3D : BaseBackgroundTouhouStage_3D
  {
    public int Height { get; set; }

    public BackgroundTouhouStage01B_3D(StageDataPackage StageData, string textureName)
      : base(StageData, textureName)
    {
      this.vertexBuffer = new VertexBuffer(this.DeviceMain, 6 * TexturedVertex.SizeBytes, Usage.WriteOnly, VertexFormat.None, Pool.Managed);
    }

    public override void SetupVertex()
    {
      this.vertexBuffer.Lock(0, 0, LockFlags.Discard).WriteRange<TexturedVertex>(new TexturedVertex[6]
      {
        new TexturedVertex(new Vector3(-2000f, 0.0f, 0.0f), new Vector2(0.0f, 0.0f)),
        new TexturedVertex(new Vector3(-2000f, 1000f, 0.0f), new Vector2(0.0f, 1f)),
        new TexturedVertex(new Vector3(0.0f, 0.0f, 0.0f), new Vector2(1f, 0.0f)),
        new TexturedVertex(new Vector3(0.0f, 1000f, 0.0f), new Vector2(1f, 1f)),
        new TexturedVertex(new Vector3(2000f, 0.0f, 0.0f), new Vector2(0.0f, 0.0f)),
        new TexturedVertex(new Vector3(2000f, 1000f, 0.0f), new Vector2(0.0f, 1f))
      });
      this.vertexBuffer.Unlock();
    }

    public override void SetupMatrices()
    {
      Matrix identity = Matrix.Identity;
      PointF originalPosition = this.OriginalPosition;
      double x = (double) originalPosition.X;
      originalPosition = this.OriginalPosition;
      double y = (double) originalPosition.Y;
      double height = (double) this.Height;
      Matrix matrix = Matrix.Translation((float) x, (float) y, (float) height);
      this.DeviceMain.SetTransform(TransformState.World, identity * matrix);
    }

    public override void Show()
    {
      base.Show();
      this.DeviceMain.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 4);
    }
  }
}
