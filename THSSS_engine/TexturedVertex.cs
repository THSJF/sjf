using SlimDX;
using SlimDX.Direct3D9;
using System.Runtime.InteropServices;

namespace Shooting {
    internal struct TexturedVertex {
        public Vector3 Position { get; set; }
        public Vector2 TextureCoordinate { get; set; }
        public TexturedVertex(Vector3 position,Vector2 textureCoordinate) {
            this=new TexturedVertex();
            Position=position;
            TextureCoordinate=textureCoordinate;
        }
        public static int SizeBytes => Marshal.SizeOf(typeof(TexturedVertex));
        public static VertexFormat Format => VertexFormat.Position|VertexFormat.Texture1;
        public static VertexElement[] VertexElements => new VertexElement[3]{
          new VertexElement( 0,  0, DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.Position,  0),
          new VertexElement( 0,  12, DeclarationType.Float2, DeclarationMethod.Default, DeclarationUsage.TextureCoordinate,  0),
          VertexElement.VertexDeclarationEnd
        };
    }
}
