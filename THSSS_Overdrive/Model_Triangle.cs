// Decompiled with JetBrains decompiler
// Type: Shooting.Model_Triangle
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using SlimDX.Direct3D9;
using System.Drawing;

namespace Shooting
{
  public class Model_Triangle : Model, IModel
  {
    public Vector2 LeftTop;
    public Vector2 RightTop;
    public Vector2 LeftBottom;
    public int Width;
    public int Height;

    public Model_Triangle()
    {
    }

    public Model_Triangle(
      Device DeviceMain,
      TextureObject TxtureObject,
      string Name,
      Vector2 LeftTop,
      Vector2 RightTop,
      Vector2 LeftBottom,
      int Width,
      int Height)
    {
      this.TransparentValue = (int) byte.MaxValue;
      this.ColorValue = Color.White;
      this.DeviceMain = DeviceMain;
      this.TxtureObject = TxtureObject;
      this.Name = Name;
      this.LeftTop = LeftTop;
      this.RightTop = RightTop;
      this.LeftBottom = LeftBottom;
      this.Width = Width;
      this.Height = Height;
      this.vertexDecl = new VertexDeclaration(DeviceMain, TexturedVertex.VertexElements);
      this.vertexBuffer = new VertexBuffer(DeviceMain, 3 * TexturedVertex.SizeBytes, Usage.WriteOnly, VertexFormat.None, Pool.Managed);
      this.material = new Material();
      this.SetupVertex();
    }

    public override void SetupVertex()
    {
      this.vertexBuffer.Lock(0, 0, LockFlags.Discard).WriteRange<TexturedVertex>(new TexturedVertex[3]
      {
        new TexturedVertex(new Vector3(0.0f, 0.0f, 0.0f), this.LeftTop),
        new TexturedVertex(new Vector3((float) this.Width, 0.0f, 0.0f), this.RightTop),
        new TexturedVertex(new Vector3(0.0f, (float) this.Height, 0.0f), this.LeftBottom)
      });
      this.vertexBuffer.Unlock();
    }

    public override void SetModel()
    {
      this.DeviceMain.SetStreamSource(0, this.vertexBuffer, 0, TexturedVertex.SizeBytes);
      this.DeviceMain.SetTexture(0, (BaseTexture) this.TxtureObject.TXTure);
    }

    public override void Draw()
    {
      this.SetupMaterial();
      this.DeviceMain.DrawPrimitives(PrimitiveType.TriangleList, 0, 1);
    }
  }
}
