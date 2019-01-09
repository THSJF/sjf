using SlimDX;
using SlimDX.Direct3D9;
using System.Runtime.InteropServices;

namespace Shooting
{
  internal struct TexturedColoredVertex
  {
    public Vector3 Position { get; set; }

    public int Color { get; set; }

    public Vector2 TextureCoordinate { get; set; }

    public TexturedColoredVertex(Vector3 position, Vector2 textureCoordinate, int color)
    {
      this = new TexturedColoredVertex();
      this.Position = position;
      this.TextureCoordinate = textureCoordinate;
      this.Color = color;
    }

    public static int SizeBytes
    {
      get
      {
        return Marshal.SizeOf(typeof (TexturedColoredVertex));
      }
    }

    public static VertexFormat Format
    {
      get
      {
        return VertexFormat.Position | VertexFormat.Diffuse | VertexFormat.Texture1;
      }
    }

    public static VertexElement[] VertexElements
    {
      get
      {
        return new VertexElement[4]
        {
          new VertexElement((short) 0, (short) 0, DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.Position, (byte) 0),
          new VertexElement((short) 0, (short) 12, DeclarationType.Float2, DeclarationMethod.Default, DeclarationUsage.TextureCoordinate, (byte) 0),
          new VertexElement((short) 0, (short) 20, DeclarationType.Color, DeclarationMethod.Default, DeclarationUsage.Color, (byte) 0),
          VertexElement.VertexDeclarationEnd
        };
      }
    }
  }
}
