 
// Type: Shooting.Particle3D_BendLaser
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using SlimDX.Direct3D9;
using System;
using System.Drawing;

namespace Shooting
{
  public class Particle3D_BendLaser : BaseParticle3D
  {
    private VertexBuffer vertexBuffer;
    private Material material;
    private int Length;
    private int Width;
    private int ColorType;

    public Particle3D_BendLaser(StageDataPackage StageData, int Length, int Width, int ColorType)
    {
      StageData.Particle3D.ParticleList.Add((BaseParticle3D) this);
      this.Active = true;
      this.StageData = StageData;
      this.ColorType = ColorType;
      this.TxtureObject = this.TextureObjectDictionary["Laser0_" + ColorType.ToString()];
      this.Length = Length;
      this.Width = Width;
      this.vertexBuffer = new VertexBuffer(this.DeviceMain, 2 * Length * TexturedVertex.SizeBytes, Usage.WriteOnly, VertexFormat.None, Pool.Managed);
      this.material = new Material();
    }

    public override void Ctrl()
    {
      ++this.Time;
    }

    private void SetupVertex()
    {
      this.Length = this.GhostingCount;
      for (int index = this.GhostingCount - 1; index > 0 && Math.Sqrt(((double) this.LastPoints[index].X - (double) this.LastPoints[index - 1].X) * ((double) this.LastPoints[index].X - (double) this.LastPoints[index - 1].X) + ((double) this.LastPoints[index].Y - (double) this.LastPoints[index - 1].Y) * ((double) this.LastPoints[index].Y - (double) this.LastPoints[index - 1].Y)) < 1.0; --index)
        --this.Length;
      if (this.Length < 2)
        this.Length = 2;
      TexturedVertex[] data = new TexturedVertex[2 * this.Length];
      double num = Math.Atan2((double) this.LastPoints[0].Y - (double) this.LastPoints[1].Y, (double) this.LastPoints[0].X - (double) this.LastPoints[1].X);
      data[0] = new TexturedVertex(new Vector3(this.LastPoints[0].X - (float) (this.Width / 2) * (float) Math.Sin(num), this.LastPoints[0].Y + (float) (this.Width / 2) * (float) Math.Cos(num), 0.0f), new Vector2(0.0f, (float) this.ColorType / 16f));
      data[1] = new TexturedVertex(new Vector3(this.LastPoints[0].X + (float) (this.Width / 2) * (float) Math.Sin(num), this.LastPoints[0].Y - (float) (this.Width / 2) * (float) Math.Cos(num), 0.0f), new Vector2(0.0f, (float) (this.ColorType + 1) / 16f));
      for (int index = 1; index < this.Length; ++index)
      {
        data[2 * index] = new TexturedVertex(new Vector3(this.LastPoints[index].X - (float) (this.Width / 2) * (float) Math.Sin(num), this.LastPoints[index].Y + (float) (this.Width / 2) * (float) Math.Cos(num), 0.0f), new Vector2((float) index / ((float) this.Length - 1f), (float) this.ColorType / 16f));
        data[2 * index + 1] = new TexturedVertex(new Vector3(this.LastPoints[index].X + (float) (this.Width / 2) * (float) Math.Sin(num), this.LastPoints[index].Y - (float) (this.Width / 2) * (float) Math.Cos(num), 0.0f), new Vector2((float) index / ((float) this.Length - 1f), (float) (this.ColorType + 1) / 16f));
        if (this.LastPoints[index - 1] != this.LastPoints[index])
          num = Math.Atan2((double) this.LastPoints[index - 1].Y - (double) this.LastPoints[index].Y, (double) this.LastPoints[index - 1].X - (double) this.LastPoints[index].X);
      }
      this.vertexBuffer.Lock(0, 0, LockFlags.Discard).WriteRange<TexturedVertex>(data);
      this.vertexBuffer.Unlock();
    }

    public override bool OutBoundary()
    {
      return false;
    }

    public override void SetupMatrices()
    {
      this.DeviceMain.SetTransform(TransformState.World, Matrix.Identity * Matrix.Translation((float) (-this.StageData.BoundRect.Width / 2), (float) (-this.StageData.BoundRect.Height / 2), 0.0f));
    }

    public override void Show()
    {
      this.SetupVertex();
      this.DeviceMain.SetStreamSource(0, this.vertexBuffer, 0, TexturedVertex.SizeBytes);
      this.DeviceMain.SetTexture(0, (BaseTexture) this.TxtureObject.TXTure);
      this.SetupMatrices();
      if (this.Active)
        this.DeviceMain.SetRenderState<Blend>(RenderState.DestinationBlend, Blend.One);
      else
        this.DeviceMain.SetRenderState<Blend>(RenderState.DestinationBlend, Blend.InverseSourceAlpha);
      this.material.Diffuse = new Color4(Color.FromArgb(this.TransparentValue, this.ColorValue));
      this.material.Ambient = new Color4(Color.FromArgb(this.TransparentValue, this.ColorValue));
      this.DeviceMain.Material = this.material;
      this.DeviceMain.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2 * this.Length - 2);
    }

    public override void Dispose()
    {
      this.vertexBuffer.Dispose();
    }
  }
}
