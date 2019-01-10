using SlimDX;
using SlimDX.Direct3D9;
using System.Drawing;

namespace Shooting {
    public class Model_Mesh:Model, IModel {
        public bool CullMode = false;
        public GlobalDataPackage GlobalData;
        private Mesh mesh;
        private ExtendedMaterial[] materials;
        private Texture[] textures;
        public Model_Mesh(Device DeviceMain,string ModelName) {
            TransparentValue=byte.MaxValue;
            ColorValue=Color.White;
            this.DeviceMain=DeviceMain;
            Name=ModelName;
            SetupVertex();
        }
        public override void SetupVertex() {
            this.mesh=Mesh.FromFile(DeviceMain,".\\Model\\"+Name+".x",MeshFlags.Managed);
            materials=this.mesh.GetMaterials();
            if((this.mesh.VertexFormat&VertexFormat.Normal)==VertexFormat.None) {
                Mesh mesh = this.mesh.Clone(DeviceMain,MeshFlags.SystemMemory,this.mesh.VertexFormat|VertexFormat.Normal);
                mesh.ComputeNormals();
                this.mesh.Dispose();
                this.mesh=mesh;
            }
            if(materials.Length<1) return;
            textures=new Texture[materials.Length];
            for(int index = 0;index<materials.Length;++index) {
                textures[index]=null;
                if(!string.IsNullOrEmpty(materials[index].TextureFileName)) textures[index]=Texture.FromFile(DeviceMain,".\\Model\\"+materials[index].TextureFileName);
            }
        }
        public override void SetModel() { }
        public override void Draw() {
            for(int subset = 0;subset<materials.Length;++subset) {
                Material materialD3D = this.materials[subset].MaterialD3D;
                materialD3D.Diffuse=new Color4(Color.FromArgb(TransparentValue,ColorValue));
                materialD3D.Ambient=new Color4(Color.FromArgb(TransparentValue,ColorValue));
                DeviceMain.Material=materialD3D;
                DeviceMain.SetTexture(0,textures[subset]);
                mesh.DrawSubset(subset);
            }
            DeviceMain.VertexFormat=TexturedVertex.Format;
        }
        public override void Dispose() {
            foreach(Texture texture in textures) {
                texture?.Dispose();
            }
            mesh.Dispose();
        }
    }
}
