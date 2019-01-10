using SlimDX;
using SlimDX.Direct3D9;
using System.Drawing;

namespace Shooting {
    public class Model:IModel {
        public VertexBuffer vertexBuffer;
        public VertexDeclaration vertexDecl;
        public Material material;
        public string Name { get; set; }
        public TextureObject TxtureObject { get; set; }
        public Device DeviceMain { get; set; }
        public int TransparentValue { get; set; }
        public Color ColorValue { get; set; }
        public Model() { }
        public Model(Device DeviceMain,TextureObject TxtureObject,string Name) {
            TransparentValue=byte.MaxValue;
            ColorValue=Color.White;
            this.DeviceMain=DeviceMain;
            this.TxtureObject=TxtureObject;
            this.Name=Name;
            vertexDecl=new VertexDeclaration(DeviceMain,TexturedVertex.VertexElements);
            vertexBuffer=new VertexBuffer(DeviceMain,4*TexturedVertex.SizeBytes,Usage.WriteOnly,VertexFormat.None,Pool.Managed);
            material=new Material();
            SetupVertex();
        }
        public virtual void SetupVertex() {
            DataStream dataStream = vertexBuffer.Lock(0,0,LockFlags.Discard);
            float x1 = -TxtureObject.RotatingCenter.X;
            float x2 = TxtureObject.Width-TxtureObject.RotatingCenter.X;
            float y1 = -TxtureObject.RotatingCenter.Y;
            float y2 = TxtureObject.Height-TxtureObject.RotatingCenter.Y;
            float x3 = TxtureObject.PosRect.X/(float)TxtureObject.SrcWidth;
            float x4 = (TxtureObject.PosRect.X+TxtureObject.Width)/(float)TxtureObject.SrcWidth;
            float y3 = TxtureObject.PosRect.Y/(float)TxtureObject.SrcHeight;
            float y4 = (TxtureObject.PosRect.Y+TxtureObject.Height)/(float)TxtureObject.SrcHeight;
            dataStream.WriteRange(new TexturedVertex[4]{
                new TexturedVertex(new Vector3(x1, y1, 0.0f), new Vector2(x3, y3)),
                new TexturedVertex(new Vector3(x2, y1, 0.0f), new Vector2(x4, y3)),
                new TexturedVertex(new Vector3(x1, y2, 0.0f), new Vector2(x3, y4)),
                new TexturedVertex(new Vector3(x2, y2, 0.0f), new Vector2(x4, y4))
              });
            vertexBuffer.Unlock();
        }
        public void SetupMaterial() {
            material.Diffuse=new Color4(Color.FromArgb(TransparentValue,ColorValue));
            material.Ambient=new Color4(Color.FromArgb(TransparentValue,ColorValue));
            DeviceMain.Material=material;
        }
        public virtual void SetModel() {
            DeviceMain.SetStreamSource(0,vertexBuffer,0,TexturedVertex.SizeBytes);
            DeviceMain.SetTexture(0,TxtureObject.TXTure);
        }
        public void SetVertexFormat() {
            DeviceMain.VertexDeclaration=vertexDecl;
            DeviceMain.VertexFormat=TexturedVertex.Format;
        }
        public virtual void Draw() {
            SetupMaterial();
            DeviceMain.DrawPrimitives(PrimitiveType.TriangleStrip,0,2);
        }
        public virtual void Dispose() {
            if(vertexBuffer==null) return;
            vertexBuffer.Dispose();
            vertexDecl.Dispose();
        }
    }
}
