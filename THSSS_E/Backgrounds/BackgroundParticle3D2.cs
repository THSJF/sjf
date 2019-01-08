 
// Type: Shooting.BackgroundParticle3D2
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX.Direct3D9;
using System.Drawing;

namespace Shooting
{
  public class BackgroundParticle3D2 : BaseParticle3D
  {
    public BackgroundParticle3D2(
      StageDataPackage StageData,
      string textureName,
      PointF OriginalPosition,
      float Velocity,
      double Direction,
      int LifeTime)
      : base(StageData, textureName, OriginalPosition, Velocity, Direction)
    {
      this.Background3D.BackgroundParticleList.Add((BaseParticle3D) this);
      this.TransparentValueF = 0.0f;
      this.LifeTime = LifeTime;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (0 < this.Time && this.Time < this.LifeTime / 3)
      {
        this.TransparentValueF += (float) (this.MaxTransparent * 3 / this.LifeTime);
      }
      else
      {
        if (this.LifeTime * 2 / 3 >= this.Time || this.Time >= this.LifeTime)
          return;
        this.TransparentValueF -= (float) (this.MaxTransparent * 3 / this.LifeTime);
      }
    }

    public override void Show()
    {
      this.DeviceMain.SetRenderState(RenderState.FogEnable, true);
      this.DeviceMain.SetRenderState<FogMode>(RenderState.FogTableMode, FogMode.Linear);
      this.DeviceMain.SetRenderState(RenderState.FogColor, Color.FromArgb(160, 190, 230).ToArgb());
      this.DeviceMain.SetRenderState(RenderState.FogStart, 0.0f);
      this.DeviceMain.SetRenderState(RenderState.FogEnd, 400f);
      base.Show();
      this.DeviceMain.SetRenderState(RenderState.FogEnable, false);
    }
  }
}
