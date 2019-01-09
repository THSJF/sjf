// Decompiled with JetBrains decompiler
// Type: THMHJ.ModelM
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace THMHJ
{
  internal class ModelM
  {
    public string label;
    public Model models;
    public Vector3 ats;
    public Vector3 rotations;
    public Vector3 scales;
    public float alpha;
    public bool IsC;
    public Vector3 color;
    private BlendTypes blend;
    public int light;
    private bool changealpha;
    private bool changecx;
    private bool changecy;
    private bool changecz;
    private float alphaorigin;
    private float alphatarget;
    private int alphatime;
    private float cxorigin;
    private float cyorigin;
    private float czorigin;
    private float cxtarget;
    private float cytarget;
    private float cztarget;
    private int cxtime;
    private int cytime;
    private int cztime;

    public ModelM(Model model, BlendTypes bt)
    {
      this.models = model;
      this.ats = Vector3.Zero;
      this.rotations = new Vector3(0.0f, 0.0f, 0.0f);
      this.scales = new Vector3(1f, 1f, 1f);
      this.alpha = 1f;
      this.color = new Vector3(1f, 1f, 1f);
      this.blend = bt;
    }

    public ModelM(Model model, Vector3 at, BlendTypes bt)
    {
      this.models = model;
      this.ats = at;
      this.rotations = new Vector3(0.0f, 0.0f, 0.0f);
      this.scales = new Vector3(1f, 1f, 1f);
      this.alpha = 1f;
      this.color = new Vector3(1f, 1f, 1f);
      this.blend = bt;
    }

    public ModelM(Model model, Vector3 at, Vector3 rotation, BlendTypes bt)
    {
      this.models = model;
      this.ats = at;
      this.rotations = rotation;
      this.scales = new Vector3(1f, 1f, 1f);
      this.alpha = 1f;
      this.color = new Vector3(1f, 1f, 1f);
      this.blend = bt;
    }

    public ModelM(Model model, Vector3 at, Vector3 rotation, Vector3 scale, BlendTypes bt)
    {
      this.models = model;
      this.ats = at;
      this.rotations = rotation;
      this.scales = scale;
      this.alpha = 1f;
      this.color = new Vector3(1f, 1f, 1f);
      this.blend = bt;
    }

    public void ChangeColorX(float tg, int t)
    {
      this.cxorigin = this.color.X;
      this.cxtarget = tg;
      this.cxtime = t;
      this.changecx = true;
    }

    public void ChangeColorY(float tg, int t)
    {
      this.cyorigin = this.color.Y;
      this.cytarget = tg;
      this.cytime = t;
      this.changecy = true;
    }

    public void ChangeColorZ(float tg, int t)
    {
      this.czorigin = this.color.Z;
      this.cztarget = tg;
      this.cztime = t;
      this.changecz = true;
    }

    public void ChangeAlpha(float tg, int t)
    {
      this.alphaorigin = this.alpha;
      this.alphatarget = tg;
      this.alphatime = t;
      this.changealpha = true;
    }

    public void ChangeUpdate()
    {
      if (this.changecx)
      {
        this.color.X += (this.cxtarget - this.cxorigin) / (float) this.cxtime;
        if ((double) Math.Abs(this.color.X - this.cxtarget) < 1.0 / 1000.0)
        {
          this.changecx = false;
          this.color.X = this.cxtarget;
        }
      }
      if (this.changecy)
      {
        this.color.Y += (this.cytarget - this.cyorigin) / (float) this.cytime;
        if ((double) Math.Abs(this.color.Y - this.cytarget) < 1.0 / 1000.0)
        {
          this.changecy = false;
          this.color.Y = this.cytarget;
        }
      }
      if (this.changecz)
      {
        this.color.Z += (this.cztarget - this.czorigin) / (float) this.cztime;
        if ((double) Math.Abs(this.color.Z - this.cztarget) < 1.0 / 1000.0)
        {
          this.changecz = false;
          this.color.Z = this.cztarget;
        }
      }
      if (!this.changealpha)
        return;
      this.alpha += (this.alphatarget - this.alphaorigin) / (float) this.alphatime;
      if ((double) Math.Abs(this.alpha - this.alphatarget) >= 1.0 / 1000.0)
        return;
      this.changealpha = false;
      this.alpha = this.alphatarget;
    }

    public void Draw(bool Anti, Matrix view, Matrix projection, GraphicsDevice g)
    {
      RenderState renderState = g.RenderState;
      renderState.MultiSampleAntiAlias = Anti;
      renderState.AlphaBlendEnable = true;
      renderState.DepthBufferEnable = this.IsC;
      renderState.AlphaTestEnable = true;
      switch (this.blend)
      {
        case BlendTypes.AlphaBlend:
          renderState.SourceBlend = Blend.SourceAlpha;
          renderState.DestinationBlend = Blend.InverseSourceAlpha;
          break;
        case BlendTypes.Additive:
          renderState.SourceBlend = Blend.One;
          renderState.DestinationBlend = Blend.One;
          break;
        case BlendTypes.Multiplicative:
          renderState.SourceBlend = Blend.Zero;
          renderState.DestinationBlend = Blend.SourceColor;
          break;
        case BlendTypes.TXMultiplicative:
          renderState.SourceBlend = Blend.DestinationColor;
          renderState.DestinationBlend = Blend.SourceColor;
          break;
      }
      if (this.IsC)
      {
        renderState.AlphaFunction = CompareFunction.GreaterEqual;
        renderState.ReferenceAlpha = 200;
      }
      else
      {
        renderState.AlphaFunction = CompareFunction.Always;
        renderState.ReferenceAlpha = 0;
      }
      if (this.IsC)
        renderState.CullMode = CullMode.None;
      foreach (ModelMesh mesh in this.models.Meshes)
      {
        foreach (BasicEffect effect in mesh.Effects)
        {
          effect.Alpha = this.alpha;
          effect.DiffuseColor = this.color;
          effect.LightingEnabled = true;
          effect.AmbientLightColor = new Vector3(0.3f, 0.3f, 0.5f);
          effect.PreferPerPixelLighting = true;
          effect.DirectionalLight0.Direction = new Vector3(1f, -1f, 0.0f);
          effect.DirectionalLight0.DiffuseColor = new Vector3(0.8f, 1f, 1f);
          if (this.light == 0)
          {
            effect.DirectionalLight0.Enabled = true;
            effect.DirectionalLight1.Enabled = false;
            effect.DirectionalLight2.Enabled = false;
          }
          else
            effect.EnableDefaultLighting();
          effect.World = mesh.ParentBone.Transform * Matrix.CreateTranslation(this.ats) * Matrix.CreateScale(this.scales) * Matrix.CreateRotationX(this.rotations.X) * Matrix.CreateRotationY(this.rotations.Y) * Matrix.CreateRotationZ(this.rotations.Z);
          effect.View = view;
          effect.Projection = projection;
        }
        mesh.Draw(SaveStateMode.None);
      }
      if (!this.IsC)
        return;
      renderState.CullMode = CullMode.CullCounterClockwiseFace;
    }
  }
}
