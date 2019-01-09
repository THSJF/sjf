 
// Type: Shooting.EnvironmentSSS06
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using SlimDX.Direct3D9;
using System;
using System.Drawing;

namespace Shooting
{
  public class EnvironmentSSS06 : BaseObject, IEnvironment
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

    public EnvironmentSSS06(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.DeviceMain = StageData.DeviceMain;
      this.Velocity = 0.5f;
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
      Rectangle boundRect;
      if (this.TimeMain == 3)
      {
        StageDataPackage stageData = this.StageData;
        boundRect = this.BoundRect;
        double num1 = (double) (boundRect.Width / 2);
        boundRect = this.BoundRect;
        double num2 = (double) (boundRect.Height / 2);
        PointF OriginalPosition = new PointF((float) num1, (float) num2);
        BaseParticle3D baseParticle3D = new BaseParticle3D(stageData, "BG01a", OriginalPosition, 0.0f, Math.PI / 2.0);
        baseParticle3D.TransparentVelocityDictionary.Add(500, -2f);
        this.Background3D.BackgroundParticleList.Add(baseParticle3D);
        new Background3DObject(this.StageData, "祭坛", new PointF(0.0f, 0.0f), false).Scale = 10f;
        this.Velocity = 0.0f;
        this.CameraPosition = new Vector3(0.0f, -550f, 280f);
        this.CameraTarget = new Vector3(0.0f, 0.0f, 100f);
        this.CameraDirection = new Vector3(0.0f, 0.0f, 1f);
      }
      if (this.TimeMain > 0 && this.TimeMain < 800)
      {
        this.CameraTarget.Z += 1.5f;
        this.CameraPosition.Z += 1.5f;
      }
      else if (this.TimeMain == 800)
      {
        this.PosY2 -= 4000;
        this.Background3D.BackgroundList.Clear();
        for (; (double) this.PosY2 < (double) this.CameraPosition.Y + 6132.0; this.PosY2 += 1314)
        {
          Background3DObject background3Dobject1 = new Background3DObject(this.StageData, "云（亮层）", new PointF(0.0f, (float) this.PosY2), true);
          background3Dobject1.Scale = 3f;
          background3Dobject1.Mirrored = false;
          background3Dobject1.OriginalPositionZ = this.CameraPosition.Z - 200f;
          background3Dobject1.Angle3DX = -3.141593f;
          background3Dobject1.TransparentValueF = 0.0f;
          background3Dobject1.MaxTransparent = 250;
          background3Dobject1.TransparentVelocity = 2.5f;
          background3Dobject1.Velocity = 0.0f;
          Background3DObject background3Dobject2 = new Background3DObject(this.StageData, "Cloud01", new PointF(0.0f, (float) (this.PosY2 + 250)), false);
          background3Dobject2.Scale = 3f;
          background3Dobject2.Mirrored = true;
          background3Dobject2.OriginalPositionZ = (float) ((double) this.CameraPosition.Z - 200.0 + 20.0);
          background3Dobject2.Angle3DX = -3.141593f;
          background3Dobject2.TransparentValueF = 0.0f;
          background3Dobject2.MaxTransparent = 50;
          background3Dobject2.TransparentVelocity = 0.5f;
          background3Dobject2.Velocity = 0.5f;
          background3Dobject2.Direction = -1.0 * Math.PI / 2.0;
          Background3DObject bo = background3Dobject2;
          bo.CtrlCall = (BaseObject.CtrlActionCallBack) (x =>
          {
            if (bo.Time <= 100)
              return;
            bo.TransparentVelocity = -0.6283185f * (float) Math.Sin((double) (this.Time - 100) / 300.0 * Math.PI * 2.0);
          });
        }
      }
      else if (this.TimeMain > 800)
      {
        if (this.TimeMain < 1000)
          ++this.CameraPosition.Z;
        if (this.TimeMain < 8000 && this.Time % 10 == 0)
        {
          Background3DObject background3Dobject = new Background3DObject(this.StageData, "591-1", new PointF((float) this.Ran.Next(-400, 400), this.CameraPos.Y + (float) this.Ran.Next(100, 500)), false);
          background3Dobject.Scale = (float) this.Ran.Next(80, 100) / 100f;
          background3Dobject.ScaleVelocity = -0.004f;
          background3Dobject.Velocity = (float) this.Ran.Next(-10, 10) / 20f;
          background3Dobject.DirectionDegree = (double) this.Ran.Next(360);
          background3Dobject.VelocityZ = (float) this.Ran.Next(6, 15) / 20f;
          background3Dobject.LifeTime = 200;
          background3Dobject.Active = true;
          background3Dobject.Angle3DX = this.StageData.Background3D.Envi.CameraAngle - 1.570796f;
          background3Dobject.TransparentValueF = 0.0f;
          background3Dobject.TransparentVelocity = 10f;
          background3Dobject.OriginalPositionZ = this.CameraPosition.Z - 200f;
        }
        if (8000 < this.TimeMain && this.TimeMain < 8200)
          this.CameraTarget.Z += 1.5f;
      }
      if (this.TimeMain == 8200)
      {
        StageDataPackage stageData = this.StageData;
        boundRect = this.BoundRect;
        double num1 = (double) (boundRect.Width / 2);
        boundRect = this.BoundRect;
        double num2 = (double) (boundRect.Height / 2);
        PointF OriginalPosition = new PointF((float) num1, (float) num2);
        BaseParticle3D baseParticle3D = new BaseParticle3D(stageData, "夜空（暗）", OriginalPosition, 0.0f, Math.PI / 2.0);
        baseParticle3D.TransparentValueF = 0.0f;
        baseParticle3D.TransparentVelocity = 3f;
        this.Background3D.BackgroundParticleList.Add(baseParticle3D);
      }
      if (this.TimeMain == 8401 && this.Background3D.BackgroundParticleList.Count == 0)
      {
        StageDataPackage stageData = this.StageData;
        boundRect = this.BoundRect;
        double num1 = (double) (boundRect.Width / 2);
        boundRect = this.BoundRect;
        double num2 = (double) (boundRect.Height / 2);
        PointF OriginalPosition = new PointF((float) num1, (float) num2);
        this.Background3D.BackgroundParticleList.Add(new BaseParticle3D(stageData, "夜空（暗）", OriginalPosition, 0.0f, Math.PI / 2.0));
      }
      for (int index = this.Background3D.BackgroundList.Count - 1; index >= 0; --index)
      {
        if ((double) this.Background3D.BackgroundList[index].OriginalPosition.Y < (double) this.CameraPosition.Y - 1000.0)
          this.Background3D.BackgroundList.RemoveAt(index);
      }
      this.light.Diffuse = (Color4) this.LightColor;
      this.light.Ambient = (Color4) this.LightColor;
      this.light.Direction = new Vector3(0.0f, 0.0f, -1f);
    }

    public void SetRenderPara()
    {
      this.DeviceMain.Clear(ClearFlags.ZBuffer | ClearFlags.Target, (Color4) this.FogColor, 1f, 0);
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      this.SpriteMain.End();
      this.DeviceMain.SetRenderState(RenderState.ZEnable, this.TimeMain < 800);
      this.DeviceMain.SetRenderState(RenderState.CullMode, true);
      this.DeviceMain.SetRenderState(RenderState.AlphaBlendEnable, true);
      this.DeviceMain.SetRenderState<Blend>(RenderState.SourceBlend, Blend.SourceAlpha);
      this.DeviceMain.SetRenderState<Blend>(RenderState.DestinationBlend, Blend.InverseSourceAlpha);
      this.DeviceMain.SetTextureStageState(0, TextureStage.AlphaArg1, TextureArgument.Texture);
      this.DeviceMain.SetTextureStageState(0, TextureStage.AlphaOperation, TextureOperation.Modulate);
      this.DeviceMain.SetTextureStageState(0, TextureStage.AlphaArg2, TextureArgument.Diffuse);
      this.DeviceMain.SetTransform(TransformState.View, Matrix.LookAtLH(this.CameraPosition, this.CameraTarget, this.CameraDirection));
      this.DeviceMain.SetTransform(TransformState.Projection, Matrix.PerspectiveFovLH(0.7853982f, 1f, 1f, this.FogEnd + 200f));
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
