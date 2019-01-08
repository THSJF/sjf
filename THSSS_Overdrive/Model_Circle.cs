// Decompiled with JetBrains decompiler
// Type: Shooting.Model_Circle
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using SlimDX.Direct3D9;
using System;
using System.Drawing;

namespace Shooting
{
  public class Model_Circle : Model, IModel
  {
    private int Length = 64;
    private int Width = 16;
    private int Radius = 100;

    public Model_Circle(Device DeviceMain, TextureObject TxtureObject, string Name)
    {
      this.TransparentValue = (int) byte.MaxValue;
      this.ColorValue = Color.White;
      this.DeviceMain = DeviceMain;
      this.TxtureObject = TxtureObject;
      this.Name = Name;
      this.vertexDecl = new VertexDeclaration(DeviceMain, TexturedVertex.VertexElements);
      this.vertexBuffer = new VertexBuffer(DeviceMain, 2 * (this.Length + 1) * TexturedVertex.SizeBytes, Usage.WriteOnly, VertexFormat.None, Pool.Managed);
      this.material = new Material();
      this.SetupVertex();
    }

    public override void SetupVertex()
    {
      float x1 = (float) this.TxtureObject.PosRect.X / (float) this.TxtureObject.SrcWidth;
      float x2 = (float) (this.TxtureObject.PosRect.X + this.TxtureObject.Width) / (float) this.TxtureObject.SrcWidth;
      TexturedVertex[] data = new TexturedVertex[2 * (this.Length + 1)];
      for (int index = 0; index <= this.Length; ++index)
      {
        double num1 = (double) (index * 2) * Math.PI / (double) this.Length;
        int num2 = this.Radius - this.Width / 2;
        float y = (float) (index % (this.Length / 3)) / (float) (this.Length / 3);
        data[2 * index] = new TexturedVertex(new Vector3((float) num2 * (float) Math.Cos(num1), (float) num2 * (float) Math.Sin(num1), 0.0f), new Vector2(x1, y));
        int num3 = this.Radius + this.Width / 2;
        data[2 * index + 1] = new TexturedVertex(new Vector3((float) num3 * (float) Math.Cos(num1), (float) num3 * (float) Math.Sin(num1), 0.0f), new Vector2(x2, y));
      }
      this.vertexBuffer.Lock(0, 0, LockFlags.Discard).WriteRange<TexturedVertex>(data);
      this.vertexBuffer.Unlock();
    }

    public override void Draw()
    {
      this.SetupMaterial();
      this.DeviceMain.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2 * this.Length);
    }
  }
}
