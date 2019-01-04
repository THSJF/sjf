// Decompiled with JetBrains decompiler
// Type: Shooting.Model_Mesh
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using SlimDX.Direct3D9;
using System.Drawing;

namespace Shooting
{
  public class Model_Mesh : Model, IModel
  {
    public bool CullMode = false;
    public GlobalDataPackage GlobalData;
    private Mesh mesh;
    private ExtendedMaterial[] materials;
    private Texture[] textures;

    public Model_Mesh(Device DeviceMain, string ModelName)
    {
      this.TransparentValue = (int) byte.MaxValue;
      this.ColorValue = Color.White;
      this.DeviceMain = DeviceMain;
      this.Name = ModelName;
      this.SetupVertex();
    }

    public override void SetupVertex()
    {
      this.mesh = Mesh.FromFile(this.DeviceMain, ".\\Model\\" + this.Name + ".x", MeshFlags.Managed);
      this.materials = this.mesh.GetMaterials();
      if ((this.mesh.VertexFormat & VertexFormat.Normal) == VertexFormat.None)
      {
        Mesh mesh = this.mesh.Clone(this.DeviceMain, MeshFlags.SystemMemory, this.mesh.VertexFormat | VertexFormat.Normal);
        mesh.ComputeNormals();
        this.mesh.Dispose();
        this.mesh = mesh;
      }
      if (this.materials.Length < 1)
        return;
      this.textures = new Texture[this.materials.Length];
      for (int index = 0; index < this.materials.Length; ++index)
      {
        this.textures[index] = (Texture) null;
        if (!string.IsNullOrEmpty(this.materials[index].TextureFileName))
          this.textures[index] = Texture.FromFile(this.DeviceMain, ".\\Model\\" + this.materials[index].TextureFileName);
      }
    }

    public override void SetModel()
    {
    }

    public override void Draw()
    {
      for (int subset = 0; subset < this.materials.Length; ++subset)
      {
        Material materialD3D = this.materials[subset].MaterialD3D;
        materialD3D.Diffuse = new Color4(Color.FromArgb(this.TransparentValue, this.ColorValue));
        materialD3D.Ambient = new Color4(Color.FromArgb(this.TransparentValue, this.ColorValue));
        this.DeviceMain.Material = materialD3D;
        this.DeviceMain.SetTexture(0, (BaseTexture) this.textures[subset]);
        this.mesh.DrawSubset(subset);
      }
      this.DeviceMain.VertexFormat = TexturedVertex.Format;
    }

    public override void Dispose()
    {
      foreach (Texture texture in this.textures)
        texture?.Dispose();
      this.mesh.Dispose();
    }
  }
}
