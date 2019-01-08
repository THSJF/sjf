 
// Type: Shooting.EnvironmentSSS05
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using SlimDX.Direct3D9;
using System;
using System.Drawing;

namespace Shooting
{
  public class EnvironmentSSS05 : BaseObject, IEnvironment
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

    public EnvironmentSSS05(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.DeviceMain = StageData.DeviceMain;
      this.Velocity = 1f;
      this.CameraPosition = new Vector3(400f, -460f, 210f);
      this.CameraTarget = new Vector3(400f, 0.0f, 0.0f);
      this.CameraDirection = new Vector3(0.0f, 0.0f, 1f);
      this.FogStart = 0.0f;
      this.FogEnd = 0.0f;
      this.light = new Light();
      this.light.Type = LightType.Directional;
      Background3DObject background3Dobject = new Background3DObject(StageData, "Stair", new PointF(0.0f, 0.0f), false);
    }

    public override void Ctrl()
    {
      ++this.Time;
      this.Velocity += this.Accelerate;
      this.CameraPosition.Y += this.Velocity;
      this.CameraTarget.Y += this.Velocity;
      this.CameraPosition.Z += this.Velocity;
      this.CameraTarget.Z += this.Velocity;
      if ((double) this.CameraPosition.Y > -100.0)
      {
        this.CameraPosition.Y -= 150f;
        this.CameraTarget.Y -= 150f;
        this.CameraPosition.Z -= 150f;
        this.CameraTarget.Z -= 150f;
      }
      this.CameraPosition.X += 0.05555556f * (float) Math.Cos((double) this.Time / 180.0);
      this.CameraTarget.X += 0.05555556f * (float) Math.Cos((double) this.Time / 180.0);
      if (this.Time > 100 && this.Time < 5050)
      {
        ++this.FogEnd;
        if ((double) this.FogEnd > 700.0)
          this.FogEnd = 700f;
      }
      if (this.TimeMain > 400 && this.TimeMain < 700)
      {
        --this.CameraPosition.X;
        --this.CameraTarget.X;
      }
      else if (this.TimeMain >= 700 && this.TimeMain < 800)
      {
        this.CameraPosition.X -= 0.5f;
        this.CameraTarget.X -= 0.5f;
      }
      else if (this.TimeMain >= 800 && this.TimeMain < 850)
      {
        this.CameraPosition.X -= 0.2f;
        this.CameraTarget.X -= 0.2f;
      }
      if (this.TimeMain > 200 && this.TimeMain < 300)
      {
        this.CameraPosition.Y += 0.5f;
        this.CameraPosition.Z -= 0.5f;
      }
      else if (this.TimeMain > 1100 && this.TimeMain < 1400)
      {
        this.CameraPosition.X += 0.1f;
        this.CameraTarget.X += 0.13f;
        this.CameraPosition.Z -= 0.1f;
        if ((double) this.CameraDirection.X < 0.0299999993294477)
          this.CameraDirection.X += 0.0001f;
      }
      else if (this.TimeMain > 1800 && this.TimeMain < 2100)
      {
        if ((double) this.CameraPosition.X > 30.0)
          this.CameraPosition.X -= 0.35f;
        if ((double) this.CameraTarget.X < 200.0)
          this.CameraTarget.X += 0.25f;
        this.CameraPosition.Z -= 0.3f;
        this.CameraDirection.X -= 0.0001f;
      }
      if (this.TimeMain > 8200 && this.TimeMain < 8250)
      {
        BaseParticle3D baseParticle3D1 = new BaseParticle3D(this.StageData, "云（亮层）", new PointF((float) (this.BoundRect.Width / 2 + this.Ran.Next(-20, 20)), (float) (240 + this.Ran.Next(-20, 20))), 0.0f, 0.0);
        baseParticle3D1.TransparentValueF = 0.0f;
        baseParticle3D1.TransparentVelocity = 0.2f;
        baseParticle3D1.Scale = 2f;
        baseParticle3D1.ColorValue = Color.Gray;
        BaseParticle3D baseParticle3D2 = baseParticle3D1;
        baseParticle3D2.TransparentVelocityDictionary.Add(300, -0.2f);
        baseParticle3D2.AngularVelocityDegree = (float) this.Ran.Next(-50, 50) / 20f;
        baseParticle3D2.Depth = (float) (this.TimeMain - 8200) / 10f;
        baseParticle3D2.LifeTime = 1500;
        this.Background3D.BackgroundParticleList.Add(baseParticle3D2);
      }
      if (this.TimeMain == 8601)
      {
        this.Background3D.BackgroundList.Clear();
        new Background3DObject(this.StageData, "祭坛", new PointF(0.0f, 0.0f), false).Scale = 10f;
        this.Velocity = 0.0f;
        this.CameraPosition = new Vector3(0.0f, -480f, 480f);
        this.CameraTarget = new Vector3(0.0f, 0.0f, 300f);
        this.CameraDirection = new Vector3(0.0f, 0.0f, 1f);
        this.FogEnd = 700f;
        this.FogStart = 200f;
      }
      if (this.TimeMain > 8600)
      {
        this.CameraPosition.X += 0.1f * (float) Math.Cos((double) this.Time / 180.0);
        this.CameraTarget.X += 0.08333334f * (float) Math.Cos((double) this.Time / 180.0);
        this.CameraPosition.Y -= 0.05882353f * (float) Math.Cos((double) this.Time / 180.0);
        this.CameraTarget.Y -= 0.07692308f * (float) Math.Cos((double) this.Time / 180.0);
      }
      this.LightColor = Color.White;
      this.light.Diffuse = (Color4) this.LightColor;
      this.light.Ambient = (Color4) this.LightColor;
      this.light.Direction = new Vector3(0.0f, 0.0f, -1f);
    }

    public void SetRenderPara()
    {
      this.DeviceMain.Clear(ClearFlags.ZBuffer | ClearFlags.Target, (Color4) this.FogColor, 1f, 0);
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      MySprite spriteMain1 = this.SpriteMain;
      TextureObject textureObject1 = this.StageData.TextureObjectDictionary["夜空底色"];
      Rectangle boundRect1 = this.BoundRect;
      double num1 = (double) (boundRect1.Left + 205);
      boundRect1 = this.BoundRect;
      double num2 = (double) (boundRect1.Top + 240);
      PointF position1 = new PointF((float) num1, (float) num2);
      Color white = Color.White;
      spriteMain1.Draw2D(textureObject1, 1f, 0.0f, position1, white);
      MySprite spriteMain2 = this.SpriteMain;
      TextureObject textureObject2 = this.StageData.TextureObjectDictionary["星星1"];
      Rectangle boundRect2 = this.BoundRect;
      double num3 = (double) (boundRect2.Left + 205);
      boundRect2 = this.BoundRect;
      double num4 = (double) (boundRect2.Top + 240);
      PointF position2 = new PointF((float) num3, (float) num4);
      Color color1 = Color.FromArgb((int) (128.0 + (double) sbyte.MaxValue * Math.Sin((double) this.Time / 200.0 * 2.0 * Math.PI)), Color.White);
      spriteMain2.Draw2D(textureObject2, 1f, 0.0f, position2, color1);
      MySprite spriteMain3 = this.SpriteMain;
      TextureObject textureObject3 = this.StageData.TextureObjectDictionary["星星2"];
      Rectangle boundRect3 = this.BoundRect;
      double num5 = (double) (boundRect3.Left + 205);
      boundRect3 = this.BoundRect;
      double num6 = (double) (boundRect3.Top + 240);
      PointF position3 = new PointF((float) num5, (float) num6);
      Color color2 = Color.FromArgb((int) (128.0 - (double) sbyte.MaxValue * Math.Sin((double) this.Time / 200.0 * 2.0 * Math.PI)), Color.White);
      spriteMain3.Draw2D(textureObject3, 1f, 0.0f, position3, color2);
      this.SpriteMain.End();
      this.DeviceMain.SetRenderState(RenderState.ZEnable, true);
      this.DeviceMain.SetRenderState(RenderState.ZWriteEnable, true);
      this.DeviceMain.SetRenderState(RenderState.CullMode, true);
      this.DeviceMain.SetRenderState(RenderState.AlphaBlendEnable, true);
      this.DeviceMain.SetRenderState<Blend>(RenderState.SourceBlend, Blend.SourceAlpha);
      this.DeviceMain.SetRenderState<Blend>(RenderState.DestinationBlend, Blend.InverseSourceAlpha);
      this.DeviceMain.SetTextureStageState(0, TextureStage.AlphaArg1, TextureArgument.Texture);
      this.DeviceMain.SetTextureStageState(0, TextureStage.AlphaOperation, TextureOperation.Modulate);
      this.DeviceMain.SetTextureStageState(0, TextureStage.AlphaArg2, TextureArgument.Diffuse);
      this.DeviceMain.SetTransform(TransformState.View, Matrix.LookAtLH(this.CameraPosition, this.CameraTarget, this.CameraDirection));
      this.DeviceMain.SetTransform(TransformState.Projection, Matrix.PerspectiveFovLH(0.7853982f, 1f, 1f, this.FogEnd + 400f));
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
