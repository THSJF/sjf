// Decompiled with JetBrains decompiler
// Type: Shooting.EnvironmentSSS01
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using SlimDX.Direct3D9;
using System;
using System.Drawing;

namespace Shooting
{
  public class EnvironmentSSS01 : BaseObject, IEnvironment
  {
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

    public EnvironmentSSS01(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.DeviceMain = StageData.DeviceMain;
      this.Velocity = 2f;
      this.CameraPosition = new Vector3(0.0f, 2200f, 130f);
      this.CameraTarget = new Vector3(0.0f, 2400f, 50f);
      this.FogStart = 0.0f;
      this.FogEnd = 50f;
      this.LightColor = Color.White;
      this.light = new Light();
      this.light.Type = LightType.Directional;
    }

    public override void Ctrl()
    {
      ++this.Time;
      this.Velocity += this.Accelerate;
      if (this.Time % 2048 == 0)
        this.Background3D.BackgroundList.ForEach((Action<BaseObject>) (x =>
        {
          if (!(x is Background3DObject) || !(((Background3DObject) x).model.Name != "591-1"))
            return;
          x.OriginalPosition = new PointF(x.OriginalPosition.X - 1024f, x.OriginalPosition.Y);
        }));
      if (this.Time % 30 == 0)
      {
        Background3DObject background3Dobject = new Background3DObject(this.StageData, "591-1", new PointF((float) this.Ran.Next(-200, 200), this.CameraPos.Y + (float) this.Ran.Next(100, 500)), false);
        background3Dobject.Scale = (float) this.Ran.Next(40, 60) / 100f;
        background3Dobject.ScaleVelocity = -0.004f;
        background3Dobject.Velocity = (float) this.Ran.Next(-10, 10) / 20f;
        background3Dobject.DirectionDegree = (double) this.Ran.Next(360);
        background3Dobject.VelocityZ = (float) this.Ran.Next(6, 15) / 20f;
        background3Dobject.LifeTime = 200;
        background3Dobject.Active = true;
        background3Dobject.Angle3DX = this.StageData.Background3D.Envi.CameraAngle - 1.570796f;
        background3Dobject.TransparentValueF = 0.0f;
        background3Dobject.TransparentVelocity = 10f;
      }
      if (6000 == this.TimeMain)
        this.OnBossAttack = true;
      this.CameraPosition.Y += this.Velocity;
      this.CameraTarget.Y += this.Velocity;
      if ((double) this.CameraPosition.Y > 3500.0)
      {
        this.CameraPosition.Y -= 2000f;
        this.CameraTarget.Y -= 2000f;
        this.Background3D.BackgroundList.ForEach((Action<BaseObject>) (x =>
        {
          if (!(x is Background3DObject) || !(((Background3DObject) x).model.Name == "591-1"))
            return;
          x.OriginalPosition = new PointF(x.OriginalPosition.X, x.OriginalPosition.Y - 2000f);
        }));
      }
      this.CameraPosition.X = 40f * (float) Math.Sin((double) this.Time / 180.0);
      this.CameraTarget.X = 40f * (float) Math.Sin((double) this.Time / 180.0);
      this.CameraDirection = new Vector3(0.02f * (float) Math.Sin((double) this.Time / 90.0), 1f, 0.0f);
      if (this.OnBossAttack)
      {
        if ((double) this.CameraPosition.Z < 430.0)
        {
          ++this.CameraPosition.Z;
          this.CameraTarget.Z += 1.05f;
        }
        this.Background3D.BackgroundList.ForEach((Action<BaseObject>) (x =>
        {
          if (!(x is Background3DObject))
            return;
          x.TransparentValueF -= 0.5f;
        }));
      }
      if (!this.OnBossAttack)
      {
        if (this.Time <= 980)
        {
          this.FogEnd += 2f;
          if ((double) this.FogEnd > 400.0)
            this.FogEnd = 400f;
        }
        if (this.Time > 980)
        {
          ++this.FogStart;
          if ((double) this.FogStart > 130.0)
            this.FogStart = 130f;
          ++this.FogEnd;
          if ((double) this.FogEnd > 510.0)
            this.FogEnd = 510f;
        }
      }
      else
      {
        ++this.FogStart;
        if ((double) this.FogStart > 230.0)
          this.FogStart = 230f;
        ++this.FogEnd;
        if ((double) this.FogEnd > 1010.0)
          this.FogEnd = 1010f;
      }
      this.light.Diffuse = (Color4) this.LightColor;
      this.light.Ambient = (Color4) this.LightColor;
      this.light.Direction = new Vector3(0.0f, 0.0f, -1f);
    }

    public void SetRenderPara()
    {
      this.DeviceMain.Clear(ClearFlags.Target, (Color4) this.FogColor, 0.0f, 0);
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      MySprite spriteMain = this.SpriteMain;
      TextureObject textureObject = this.StageData.TextureObjectDictionary["BG01a"];
      Rectangle boundRect = this.BoundRect;
      double num1 = (double) (boundRect.Left + 256);
      boundRect = this.BoundRect;
      double num2 = (double) (boundRect.Top + 256);
      PointF position = new PointF((float) num1, (float) num2);
      Color white = Color.White;
      spriteMain.Draw2D(textureObject, 1f, 0.0f, position, white);
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
