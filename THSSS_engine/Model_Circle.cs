using SlimDX;
using SlimDX.Direct3D9;
using System;
using System.Drawing;

namespace Shooting {
    public class Model_Circle:Model, IModel {
        private int Length = 64;
        private int Width = 16;
        private int Radius = 100;
        public Model_Circle(Device DeviceMain,TextureObject TxtureObject,string Name) {
            TransparentValue=byte.MaxValue;
            ColorValue=Color.White;
            this.DeviceMain=DeviceMain;
            this.TxtureObject=TxtureObject;
            this.Name=Name;
            vertexDecl=new VertexDeclaration(DeviceMain,TexturedVertex.VertexElements);
            vertexBuffer=new VertexBuffer(DeviceMain,2*(Length+1)*TexturedVertex.SizeBytes,Usage.WriteOnly,VertexFormat.None,Pool.Managed);
            material=new Material();
            SetupVertex();
        }
        public override void SetupVertex() {
            float x1 = TxtureObject.PosRect.X/(float)TxtureObject.SrcWidth;
            float x2 = (TxtureObject.PosRect.X+TxtureObject.Width)/(float)TxtureObject.SrcWidth;
            TexturedVertex[] data = new TexturedVertex[2*(Length+1)];
            for(int index = 0;index<=Length;++index) {
                double num1 = (index*2)*Math.PI/Length;
                int num2 = Radius-Width/2;
                float y = index%(Length/3)/(float)(Length/3);
                data[2*index]=new TexturedVertex(new Vector3(num2*(float)Math.Cos(num1),num2*(float)Math.Sin(num1),0.0f),new Vector2(x1,y));
                int num3 = Radius+Width/2;
                data[2*index+1]=new TexturedVertex(new Vector3(num3*(float)Math.Cos(num1),num3*(float)Math.Sin(num1),0.0f),new Vector2(x2,y));
            }
            vertexBuffer.Lock(0,0,LockFlags.Discard).WriteRange(data);
            vertexBuffer.Unlock();
        }
        public override void Draw() {
            SetupMaterial();
            DeviceMain.DrawPrimitives(PrimitiveType.TriangleStrip,0,2*Length);
        }
    }
}
