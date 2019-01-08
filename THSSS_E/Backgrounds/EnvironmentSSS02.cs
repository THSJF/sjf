 
// Type: Shooting.EnvironmentSSS02
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using SlimDX.Direct3D9;
using System;
using System.Drawing;

namespace Shooting
{
  public class EnvironmentSSS02 : BaseObject, IEnvironment
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

    public EnvironmentSSS02(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.DeviceMain = StageData.DeviceMain;
      this.Velocity = 1f;
      this.CameraPosition = new Vector3(0.0f, 0.0f, 70f);
      this.CameraTarget = new Vector3(0.0f, 200f, 70f);
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
      this.Velocity += this.Accelerate;
      if ((double) this.Velocity < 0.5)
        this.Velocity = 0.5f;
      for (; (double) this.PosY3 < (double) this.CameraPosition.Y + 1600.0; this.PosY3 += 200)
      {
        Background3DObject background3Dobject1 = new Background3DObject(this.StageData, "zhu", new PointF(200f, (float) this.PosY3), true)
        {
          Angle3DX = -1.570796f,
          Height = 256f
        };
        new Background3DObject(this.StageData, "zhu", new PointF(-200f, (float) this.PosY3), true)
        {
          Angle3DX = -1.570796f,
          Height = 256f
        }.Mirrored = true;
        new Background3DObject(this.StageData, "zhu", new PointF(200f, (float) (this.PosY3 + 100)), true)
        {
          Angle3DX = -1.570796f,
          Height = 256f
        }.Mirrored = true;
        Background3DObject background3Dobject2 = new Background3DObject(this.StageData, "zhu", new PointF(-200f, (float) (this.PosY3 + 100)), true)
        {
          Angle3DX = -1.570796f,
          Height = 256f
        };
      }
      for (; (double) this.PosY2 < (double) this.CameraPosition.Y + 1500.0; this.PosY2 += 310)
        new Background3DObject(this.StageData, "BG02d", new PointF(0.0f, (float) this.PosY2), true).Angle3DX = -3.141593f;
      for (; (double) this.PosY < (double) this.CameraPosition.Y + 1500.0; this.PosY += 133)
      {
        Background3DObject background3Dobject1 = new Background3DObject(this.StageData, "liba", new PointF(150f, (float) this.PosY), false);
        background3Dobject1.Angle = 1.57079637050629;
        background3Dobject1.Angle3DY = -1.570796f;
        background3Dobject1.Height = 45f;
        Background3DObject background3Dobject2 = new Background3DObject(this.StageData, "liba", new PointF(-150f, (float) this.PosY), false);
        background3Dobject2.Angle = -1.57079637050629;
        background3Dobject2.Angle3DY = 1.570796f;
        background3Dobject2.Height = 45f;
        Background3DObject background3Dobject3 = new Background3DObject(this.StageData, "591-1R", new PointF(150f, (float) this.PosY), false);
        background3Dobject3.Scale = 1.5f;
        background3Dobject3.Active = true;
        background3Dobject3.Angle3DX = this.StageData.Background3D.Envi.CameraAngle - 1.570796f;
        background3Dobject3.TransparentValueF = 0.0f;
        background3Dobject3.TransparentVelocity = 10f;
        background3Dobject3.Height = 60f;
        Background3DObject background3Dobject4 = new Background3DObject(this.StageData, "591-1R", new PointF(-150f, (float) this.PosY), false);
        background3Dobject4.Scale = 1.5f;
        background3Dobject4.Active = true;
        background3Dobject4.Angle3DX = this.StageData.Background3D.Envi.CameraAngle - 1.570796f;
        background3Dobject4.TransparentValueF = 0.0f;
        background3Dobject4.TransparentVelocity = 10f;
        background3Dobject4.Height = 60f;
      }
      for (int index = this.Background3D.BackgroundList.Count - 1; index >= 0; --index)
      {
        if ((double) this.Background3D.BackgroundList[index].OriginalPosition.Y < (double) this.CameraPosition.Y - 310.0)
          this.Background3D.BackgroundList.RemoveAt(index);
      }
      this.CameraPosition.Y += this.Velocity;
      this.CameraTarget.Y += this.Velocity;
      this.CameraPosition.X = 40f * (float) Math.Sin((double) this.Time / 360.0);
      this.CameraTarget.X = 40f * (float) Math.Sin((double) (this.Time - 60) / 360.0);
      if (this.Time > 50)
      {
        ++this.FogStart;
        if ((double) this.FogStart > 10.0)
          this.FogStart = 10f;
        this.FogEnd += 20f;
        if ((double) this.FogEnd > 900.0)
          this.FogEnd = 900f;
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
