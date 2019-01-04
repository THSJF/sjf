// Decompiled with JetBrains decompiler
// Type: Shooting.EnvironmentSSS04
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using SlimDX.Direct3D9;
using System;
using System.Drawing;

namespace Shooting
{
  public class EnvironmentSSS04 : BaseObject, IEnvironment
  {
    private int PosY = -1000;
    private int PosY2 = -1000;
    private int PosY3 = -1000;
    private Light light;
    private Color LightColor;
    private Color FogColor;
    private float FogStart;
    private float FogEnd;
    public Vector3 CameraPosition;
    public Vector3 CameraTarget;
    public Vector3 CameraDirection;

    public Device DeviceMain { get; set; }

    public bool OnBossAttack { get; set; }

    public Vector3 CameraPos
    {
      get
      {
        return this.CameraPosition;
      }
    }

    public float CameraAngle
    {
      get
      {
        return (float) Math.Atan(((double) this.CameraTarget.Z - (double) this.CameraPosition.Z) / ((double) this.CameraTarget.Y - (double) this.CameraPosition.Y));
      }
    }

    public EnvironmentSSS04(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.DeviceMain = StageData.DeviceMain;
      this.Velocity = 1f;
      this.CameraPosition = new Vector3(0.0f, 0.0f, 170f);
      this.CameraTarget = new Vector3(0.0f, 200f, 170f);
      this.CameraDirection = new Vector3(0.0f, 0.0f, 1f);
      this.FogStart = 0.0f;
      this.FogEnd = 200f;
      this.LightColor = Color.White;
      this.light = new Light();
      this.light.Type = LightType.Directional;
    }

    public override void Ctrl()
    {
      ++this.Time;
      if (this.TimeMain < 400)
      {
        if (this.Time > 50)
        {
          ++this.FogStart;
          if ((double) this.FogStart > 10.0)
            this.FogStart = 10f;
          this.FogEnd += 20f;
          if ((double) this.FogEnd > 900.0)
            this.FogEnd = 900f;
        }
        this.Velocity += this.Accelerate;
        if ((double) this.Velocity < 0.5)
          this.Velocity = 0.5f;
        this.CameraPosition.Y += this.Velocity;
        this.CameraTarget.Y += this.Velocity;
        this.CameraPosition.X = 40f * (float) Math.Sin((double) this.Time / 360.0);
        this.CameraTarget.X = 40f * (float) Math.Sin((double) (this.Time - 60) / 360.0);
        for (; (double) this.PosY3 < (double) this.CameraPosition.Y + 4200.0; this.PosY3 += 400)
        {
          Background3DObject background3Dobject1 = new Background3DObject(this.StageData, "柳树", new PointF(300f, (float) this.PosY3), true)
          {
            Angle3DX = -1.570796f,
            Height = 400f
          };
          new Background3DObject(this.StageData, "柳树", new PointF(-300f, (float) this.PosY3), true)
          {
            Angle3DX = -1.570796f,
            Height = 400f
          }.Mirrored = true;
          new Background3DObject(this.StageData, "柳树", new PointF(300f, (float) (this.PosY3 + 200)), true)
          {
            Angle3DX = -1.570796f,
            Height = 400f
          }.Mirrored = true;
          Background3DObject background3Dobject2 = new Background3DObject(this.StageData, "柳树", new PointF(-300f, (float) (this.PosY3 + 200)), true)
          {
            Angle3DX = -1.570796f,
            Height = 400f
          };
        }
        for (; (double) this.PosY < (double) this.CameraPosition.Y + 3072.0; this.PosY += 256)
          new Background3DObject(this.StageData, "地砖", new PointF(0.0f, (float) this.PosY), true)
          {
            Angle3DX = -3.141593f
          }.Scale = 1f;
        for (; (double) this.PosY2 < (double) this.CameraPosition.Y + 1950.0; this.PosY2 += 1625)
          new Background3DObject(this.StageData, "草地", new PointF(0.0f, (float) this.PosY2), true)
          {
            Angle3DX = -3.141593f
          }.Scale = 5f;
        for (int index = this.Background3D.BackgroundList.Count - 1; index >= 0; --index)
        {
          if ((double) this.Background3D.BackgroundList[index].OriginalPosition.Y < (double) this.CameraPosition.Y - 1000.0)
            this.Background3D.BackgroundList.RemoveAt(index);
        }
      }
      else if (this.TimeMain > 4000 && (double) this.CameraTarget.Y < 500.0)
        ++this.CameraTarget.Y;
      Background3DObject background3Dobject3;
      if (this.TimeMain == 150)
        new BackgroundTransitionOut(this.StageData, 150).LifeTime = 400;
      else if (this.TimeMain == 550)
      {
        new BackgroundTransitionIn(this.StageData)
        {
          Delay = 0
        }.LifeTime = 300;
        this.CameraPosition = new Vector3(0.0f, 0.0f, 250f);
        this.CameraTarget = new Vector3(0.0f, 0.0f, 0.0f);
        this.CameraDirection = new Vector3(0.0f, 1f, 1f);
        this.Background3D.BackgroundList.Clear();
        Background3DObject background3Dobject1 = new Background3DObject(this.StageData, "万花镜素材", new PointF(0.0f, 0.0f), false);
        background3Dobject1.AngularVelocityDegree = 0.1f;
        background3Dobject3 = background3Dobject1;
        Background3DObject background3Dobject2 = new Background3DObject(this.StageData, "黑暗滤镜", new PointF(0.0f, 0.0f), false);
        background3Dobject2.Height = 10f;
        background3Dobject2.Scale = 1f;
        background3Dobject2.TransparentVelocityDictionary.Add(3350, -5f);
        this.FogStart = 0.0f;
        this.FogEnd = 2000000f;
      }
      else if (this.TimeMain == 4300)
      {
        BaseParticle3D baseParticle3D = new BaseParticle3D(this.StageData, "极光素材", new PointF((float) (this.BoundRect.Width / 2), 125f), 0.0f, 0.0);
        baseParticle3D.TransparentValueF = 128f;
        baseParticle3D.Active = true;
        baseParticle3D.AngleDegree = 0.0;
        baseParticle3D.ColorValue = Color.Black;
        BaseParticle3D bk = baseParticle3D;
        bk.CtrlCall = (BaseObject.CtrlActionCallBack) (x =>
        {
          if (bk.Time * 2 < (int) byte.MaxValue)
            bk.ColorValue = Color.FromArgb(bk.Time * 2, bk.Time * 2, bk.Time * 2);
          bk.TransparentValueF = (float) (128.0 + 48.0 * Math.Sin((double) bk.Time / 200.0 * Math.PI * 2.0));
        });
        this.Background3D.BackgroundParticleList.Add(bk);
      }
      if (this.TimeMain == 8701 && this.Background3D.BackgroundParticleList.Count == 0)
      {
        this.CameraPosition = new Vector3(0.0f, 0.0f, 250f);
        this.CameraTarget = new Vector3(0.0f, 500f, 0.0f);
        this.CameraDirection = new Vector3(0.0f, 1f, 1f);
        Background3DObject background3Dobject1 = new Background3DObject(this.StageData, "万花镜素材", new PointF(0.0f, 0.0f), false);
        background3Dobject1.AngularVelocityDegree = 0.1f;
        background3Dobject3 = background3Dobject1;
        this.FogStart = 0.0f;
        this.FogEnd = 2000000f;
        BaseParticle3D baseParticle3D = new BaseParticle3D(this.StageData, "极光素材", new PointF((float) (this.BoundRect.Width / 2), 125f), 0.0f, 0.0);
        baseParticle3D.TransparentValueF = 128f;
        baseParticle3D.Active = true;
        baseParticle3D.AngleDegree = 0.0;
        baseParticle3D.ColorValue = Color.Black;
        BaseParticle3D bk = baseParticle3D;
        bk.CtrlCall = (BaseObject.CtrlActionCallBack) (x =>
        {
          if (bk.Time * 2 < (int) byte.MaxValue)
            bk.ColorValue = Color.FromArgb(bk.Time * 2, bk.Time * 2, bk.Time * 2);
          bk.TransparentValueF = (float) (128.0 + 48.0 * Math.Sin((double) bk.Time / 200.0 * Math.PI * 2.0));
        });
        this.Background3D.BackgroundParticleList.Add(bk);
      }
      this.light.Diffuse = (Color4) this.LightColor;
      this.light.Ambient = (Color4) this.LightColor;
      this.light.Direction = new Vector3(0.0f, 0.0f, -1f);
    }

    public void SetRenderPara()
    {
      this.DeviceMain.Clear(ClearFlags.ZBuffer | ClearFlags.Target, (Color4) this.FogColor, 1f, 0);
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      if (this.TimeMain < 400)
        this.SpriteMain.Draw2D(this.StageData.TextureObjectDictionary["BG01a"], 1f, 0.0f, new PointF((float) (this.BoundRect.Left + 256), (float) (this.BoundRect.Top + 256)), Color.White);
      this.SpriteMain.End();
      this.DeviceMain.SetRenderState(RenderState.ZEnable, false);
      this.DeviceMain.SetRenderState(RenderState.CullMode, true);
      this.DeviceMain.SetRenderState(RenderState.AlphaBlendEnable, true);
      this.DeviceMain.SetRenderState<Blend>(RenderState.SourceBlend, Blend.SourceAlpha);
      this.DeviceMain.SetRenderState<Blend>(RenderState.DestinationBlend, Blend.InverseSourceAlpha);
      this.DeviceMain.SetTextureStageState(0, TextureStage.AlphaArg1, TextureArgument.Texture);
      this.DeviceMain.SetTextureStageState(0, TextureStage.AlphaOperation, TextureOperation.Modulate);
      this.DeviceMain.SetTextureStageState(0, TextureStage.AlphaArg2, TextureArgument.Diffuse);
      this.DeviceMain.SetTransform(TransformState.View, Matrix.LookAtLH(this.CameraPosition, this.CameraTarget, this.CameraDirection));
      this.DeviceMain.SetTransform(TransformState.Projection, Matrix.PerspectiveFovLH(1.570796f, 1f, 1f, this.FogEnd + 200f));
      this.DeviceMain.SetRenderState(RenderState.FogEnable, true);
      this.DeviceMain.SetRenderState<FogMode>(RenderState.FogTableMode, FogMode.Linear);
      this.DeviceMain.SetRenderState(RenderState.FogColor, this.FogColor.ToArgb());
      this.DeviceMain.SetRenderState(RenderState.FogStart, this.FogStart);
      this.DeviceMain.SetRenderState(RenderState.FogEnd, this.FogEnd);
      this.DeviceMain.SetLight(0, this.light);
      this.DeviceMain.SetRenderState(RenderState.Lighting, true);
      this.DeviceMain.EnableLight(0, true);
    }
  }
}
