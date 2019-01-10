using SlimDX;
using SlimDX.Direct3D9;
using System.Runtime.InteropServices;

namespace Shooting {
    internal struct TexturedColoredVertex {
        public Vector3 Position { get; set; }
        public int Color { get; set; }
        public Vector2 TextureCoordinate { get; set; }
        public TexturedColoredVertex(Vector3 position,Vector2 textureCoordinate,int color) {
            this=new TexturedColoredVertex();
            Position=position;
            TextureCoordinate=textureCoordinate;
            Color=color;
        }
        public static int SizeBytes => Marshal.SizeOf(typeof(TexturedColoredVertex));
        public static VertexFormat Format => VertexFormat.Position|VertexFormat.Diffuse|VertexFormat.Texture1;
        public static VertexElement[] VertexElements => new VertexElement[4]{
          new VertexElement( 0,  0, DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.Position,  0),
          new VertexElement( 0,  12, DeclarationType.Float2, DeclarationMethod.Default, DeclarationUsage.TextureCoordinate,  0),
          new VertexElement( 0,  20, DeclarationType.Color, DeclarationMethod.Default, DeclarationUsage.Color,  0),
          VertexElement.VertexDeclarationEnd
        };
    }
}
