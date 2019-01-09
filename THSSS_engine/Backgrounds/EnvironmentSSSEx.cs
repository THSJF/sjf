 
// Type: Shooting.EnvironmentSSSEx
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using SlimDX.Direct3D9;
using System;
using System.Drawing;

namespace Shooting
{
  public class EnvironmentSSSEx : BaseObject, IEnvironment
  {
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

    public EnvironmentSSSEx(StageDataPackage StageData)
    {
      this.StageData = StageData;
      this.DeviceMain = StageData.DeviceMain;
      this.Velocity = 1f;
      this.CameraPosition = new Vector3(0.0f, 0.0f, 250f);
      this.CameraTarget = new Vector3(0.0f, 200f, 170f);
      this.CameraDirection = new Vector3(0.0f, 0.0f, 1f);
      this.FogColor = Color.FromArgb(80, 165, (int) byte.MaxValue);
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
      for (; (double) this.PosY3 < (double) this.CameraPosition.Y + 4200.0; this.PosY3 += 400)
      {
        Background3DObject background3Dobject1 = new Background3DObject(this.StageData, "Tree2", new PointF(300f, (float) this.PosY3), true)
        {
          Angle3DX = this.CameraAngle - 1.570796f,
          Height = 233f * (float) Math.Cos((double) this.CameraAngle)
        };
        new Background3DObject(this.StageData, "Tree2", new PointF(-300f, (float) this.PosY3), true)
        {
          Angle3DX = (this.CameraAngle - 1.570796f),
          Height = (233f * (float) Math.Cos((double) this.CameraAngle))
        }.Mirrored = true;
        new Background3DObject(this.StageData, "Tree1", new PointF(300f, (float) (this.PosY3 + 200)), true)
        {
          Angle3DX = (this.CameraAngle - 1.570796f),
          Height = (225f * (float) Math.Cos((double) this.CameraAngle))
        }.Mirrored = true;
        Background3DObject background3Dobject2 = new Background3DObject(this.StageData, "Tree1", new PointF(-300f, (float) (this.PosY3 + 200)), true)
        {
          Angle3DX = this.CameraAngle - 1.570796f,
          Height = 225f * (float) Math.Cos((double) this.CameraAngle)
        };
      }
      for (; (double) this.PosY2 < (double) this.CameraPosition.Y + 1950.0; this.PosY2 += 486)
        new Background3DObject(this.StageData, "草地ex", new PointF(0.0f, (float) this.PosY2), true)
        {
          Angle3DX = -3.141593f
        }.Scale = 2f;
      for (int index = this.Background3D.BackgroundList.Count - 1; index >= 0; --index)
      {
        if ((double) this.Background3D.BackgroundList[index].OriginalPosition.Y < (double) this.CameraPosition.Y - 1000.0)
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
      TextureObject textureObject = this.StageData.TextureObjectDictionary["天色"];
      Rectangle boundRect = this.BoundRect;
      double num1 = (double) (boundRect.Left + 204);
      boundRect = this.BoundRect;
      double num2 = (double) (boundRect.Top + 240);
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
      this.DeviceMain.SetTransform(TransformState.Projection, Matrix.PerspectiveFovLH(1.570796f, 1f, 1f, 1000f));
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
