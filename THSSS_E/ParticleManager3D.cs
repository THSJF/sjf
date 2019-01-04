// Decompiled with JetBrains decompiler
// Type: Shooting.ParticleManager3D
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using SlimDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  public class ParticleManager3D
  {
    private Light light;

    public List<BaseParticle3D> ParticleList { get; set; }

    public VertexDeclaration vertexDecl { get; set; }

    public StageDataPackage StageData { get; private set; }

    public Device DeviceMain
    {
      get
      {
        return this.StageData.DeviceMain;
      }
    }

    public ParticleManager3D(StageDataPackage StageData)
    {
      this.ParticleList = new List<BaseParticle3D>();
      this.StageData = StageData;
      this.vertexDecl = new VertexDeclaration(this.DeviceMain, TexturedVertex.VertexElements);
      this.SetupLight();
    }

    private void SetupLight()
    {
      this.light = new Light();
      this.light.Type = LightType.Directional;
      this.light.Diffuse = (Color4) Color.White;
      this.light.Ambient = (Color4) Color.White;
      this.light.Direction = new Vector3(0.0f, 0.0f, -1f);
    }

    public void Ctrl()
    {
      this.ParticleList.ForEach((Action<BaseParticle3D>) (x =>
      {
        if (!x.OutBoundary())
          return;
        x.Dispose();
        this.ParticleList.Remove(x);
      }));
      this.ParticleList.ForEach((Action<BaseParticle3D>) (x => x.Ctrl()));
      this.ParticleList.Sort((IComparer<BaseParticle3D>) new CompareDepth());
    }

    private void SetParticleRenderPara()
    {
      this.DeviceMain.SetTransform(TransformState.View, Matrix.LookAtLH(new Vector3(0.0f, 0.0f, (float) (this.DeviceMain.Viewport.Height / 2)), new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, -1f, 0.0f)));
      Device deviceMain = this.DeviceMain;
      Viewport viewport = this.DeviceMain.Viewport;
      double width = (double) viewport.Width;
      viewport = this.DeviceMain.Viewport;
      double height = (double) viewport.Height;
      Matrix matrix = Matrix.PerspectiveFovLH(1.570796f, (float) (width / height), 1f, 1000f);
      deviceMain.SetTransform(TransformState.Projection, matrix);
      this.DeviceMain.SetRenderState(RenderState.ZEnable, false);
      this.DeviceMain.SetRenderState(RenderState.CullMode, true);
      this.DeviceMain.SetRenderState(RenderState.AlphaBlendEnable, true);
      this.DeviceMain.SetRenderState<Blend>(RenderState.SourceBlend, Blend.SourceAlpha);
      this.DeviceMain.SetRenderState(RenderState.FogEnable, false);
      this.DeviceMain.SetTextureStageState(0, TextureStage.AlphaArg1, TextureArgument.Texture);
      this.DeviceMain.SetTextureStageState(0, TextureStage.AlphaOperation, TextureOperation.Modulate);
      this.DeviceMain.SetTextureStageState(0, TextureStage.AlphaArg2, TextureArgument.Diffuse);
      this.DeviceMain.SetLight(0, this.light);
      this.DeviceMain.SetRenderState(RenderState.Lighting, true);
      this.DeviceMain.EnableLight(0, true);
      this.DeviceMain.VertexDeclaration = this.vertexDecl;
      this.DeviceMain.VertexFormat = TexturedVertex.Format;
    }

    public void Show()
    {
      this.StageData.ScreenTexMan.Begin();
      Viewport viewport = this.StageData.DeviceMain.Viewport;
      this.DeviceMain.Viewport = new Viewport()
      {
        X = this.StageData.BoundRect.Left - 10,
        Y = this.StageData.BoundRect.Top - 10,
        Width = this.StageData.BoundRect.Width + 20,
        Height = this.StageData.BoundRect.Height + 20
      };
      this.SetParticleRenderPara();
      string ModelName = (string) null;
      this.ParticleList.ForEach((Action<BaseParticle3D>) (x =>
      {
        if (x.model != null)
        {
          if (ModelName != x.model.Name)
            x.model.SetModel();
          ModelName = x.model.Name;
        }
        else
          ModelName = (string) null;
        x.Show();
      }));
      this.StageData.ScreenTexMan.End();
      this.DeviceMain.Viewport = viewport;
      this.StageData.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      this.DeviceMain.SetRenderState(RenderState.SourceBlend, 5);
      this.DeviceMain.SetRenderState(RenderState.DestinationBlend, 2);
      this.StageData.SpriteMain.Draw2D(this.StageData.ScreenTexMan.RenderTexture, (PointF) new Point(0, 0), 0.0f, new PointF(0.0f, 0.0f), Color.White);
      this.StageData.SpriteMain.End();
    }

    public void Dispose()
    {
      this.ParticleList.ForEach((Action<BaseParticle3D>) (x => x.Dispose()));
      if (this.vertexDecl == null)
        return;
      this.vertexDecl.Dispose();
    }

    public void Clear()
    {
      this.ParticleList.Clear();
    }
  }
}
