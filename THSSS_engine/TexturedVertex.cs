using SlimDX;
using SlimDX.Direct3D9;
using System.Runtime.InteropServices;

namespace Shooting
{
  internal struct TexturedVertex
  {
    public Vector3 Position { get; set; }

    public Vector2 TextureCoordinate { get; set; }

    public TexturedVertex(Vector3 position, Vector2 textureCoordinate)
    {
      this = new TexturedVertex();
      this.Position = position;
      this.TextureCoordinate = textureCoordinate;
    }

    public static int SizeBytes
    {
      get
      {
        return Marshal.SizeOf(typeof (TexturedVertex));
      }
    }

    public static VertexFormat Format
    {
      get
      {
        return VertexFormat.Position | VertexFormat.Texture1;
      }
    }

    public static VertexElement[] VertexElements
    {
      get
      {
        return new VertexElement[3]
        {
          new VertexElement((short) 0, (short) 0, DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.Position, (byte) 0),
          new VertexElement((short) 0, (short) 12, DeclarationType.Float2, DeclarationMethod.Default, DeclarationUsage.TextureCoordinate, (byte) 0),
          VertexElement.VertexDeclarationEnd
        };
      }
    }
  }
}
