 
// Type: Shooting.BackgroundUUZtree
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX.Direct3D9;

namespace Shooting
{
  public class BackgroundUUZtree : BackgroundFix
  {
    public BackgroundUUZtree(StageDataPackage StageData, string textureName)
      : base(StageData, textureName)
    {
      this.TransparentValueF = 150f;
    }

    public override void Show()
    {
      this.SpriteMain.End();
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      this.StageData.DeviceMain.SetRenderState(RenderState.SourceBlend, 5);
      this.StageData.DeviceMain.SetRenderState(RenderState.DestinationBlend, 2);
      this.StageData.DeviceMain.SetRenderState<BlendOperation>(RenderState.BlendOperation, BlendOperation.ReverseSubtract);
      base.Show();
      base.Show();
      this.SpriteMain.End();
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
    }
  }
}
