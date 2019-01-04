// Decompiled with JetBrains decompiler
// Type: Shooting.BackgroundTouhouStage01_3D
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using SlimDX.Direct3D9;
using System.Drawing;

namespace Shooting
{
  internal class BackgroundTouhouStage01_3D : BaseBackgroundTouhouStage_3D
  {
    public int Height { get; set; }

    public BackgroundTouhouStage01_3D(StageDataPackage StageData, string textureName)
      : base(StageData, textureName)
    {
      this.vertexBuffer = new VertexBuffer(this.DeviceMain, 4 * TexturedVertex.SizeBytes, Usage.WriteOnly, VertexFormat.None, Pool.Managed);
    }

    public override void SetupVertex()
    {
      this.vertexBuffer.Lock(0, 0, LockFlags.Discard).WriteRange<TexturedVertex>(new TexturedVertex[4]
      {
        new TexturedVertex(new Vector3(-500f, 0.0f, 0.0f), new Vector2(0.0f, 0.0f)),
        new TexturedVertex(new Vector3(-500f, 1000f, 0.0f), new Vector2(0.0f, 1f)),
        new TexturedVertex(new Vector3(500f, 0.0f, 0.0f), new Vector2(1f, 0.0f)),
        new TexturedVertex(new Vector3(500f, 1000f, 0.0f), new Vector2(1f, 1f))
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
      PointF originalPosition1 = this.OriginalPosition;
      double num1 = (double) originalPosition1.X - 1000.0;
      originalPosition1 = this.OriginalPosition;
      double y1 = (double) originalPosition1.Y;
      this.OriginalPosition = new PointF((float) num1, (float) y1);
      this.SetupMatrices();
      this.DeviceMain.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2);
      PointF originalPosition2 = this.OriginalPosition;
      double num2 = (double) originalPosition2.X + 1000.0;
      originalPosition2 = this.OriginalPosition;
      double y2 = (double) originalPosition2.Y;
      this.OriginalPosition = new PointF((float) num2, (float) y2);
      this.SetupMatrices();
      this.DeviceMain.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2);
      PointF originalPosition3 = this.OriginalPosition;
      double num3 = (double) originalPosition3.X + 1000.0;
      originalPosition3 = this.OriginalPosition;
      double y3 = (double) originalPosition3.Y;
      this.OriginalPosition = new PointF((float) num3, (float) y3);
      this.SetupMatrices();
      this.DeviceMain.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2);
      PointF originalPosition4 = this.OriginalPosition;
      double num4 = (double) originalPosition4.X - 1000.0;
      originalPosition4 = this.OriginalPosition;
      double y4 = (double) originalPosition4.Y;
      this.OriginalPosition = new PointF((float) num4, (float) y4);
    }
  }
}
