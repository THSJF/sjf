 
// Type: Shooting.EndBoss_FSC06
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class EndBoss_FSC06 : EndBoss_Touhou_Small
  {
    private int tempVolumn;

    public EndBoss_FSC06(
      StageDataPackage StageData,
      PointF OriginalPosition,
      Color Color1,
      Color Color2)
      : base(StageData, OriginalPosition, Color1, Color2)
    {
      this.tempVolumn = this.BGM_Player.Volume;
      this.LifeTime = 300;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.BGM_Player.Volume = (int) ((double) this.tempVolumn * (1.0 - (double) this.Time / (double) (this.LifeTime - 90)));
      PointF OriginalPosition = new PointF((float) (this.BoundRect.Width / 2), 150f);
      if (this.Time == this.LifeTime - 60 || this.Time == this.LifeTime - 40 || this.Time == this.LifeTime - 20)
      {
        EmitterSaveEnegy3D emitterSaveEnegy3D = new EmitterSaveEnegy3D(this.StageData, OriginalPosition, Color.SkyBlue);
        this.StageData.SoundPlay("se_ch02.wav");
      }
      if (this.Time != this.LifeTime)
        return;
      this.StageData.ChangeBGM(".\\BGM\\Boss06FSC.wav", 0, 0, (int) byte.MaxValue, 0, 0);
      Boss_Tensei02 bossTensei02 = new Boss_Tensei02(this.StageData);
      this.Background3D.WarpEnabled = true;
    }
  }
}
