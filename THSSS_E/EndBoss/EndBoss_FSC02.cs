// Decompiled with JetBrains decompiler
// Type: Shooting.EndBoss_FSC02
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting
{
  internal class EndBoss_FSC02 : EndBoss_Touhou_Small
  {
    public EndBoss_FSC02(
      StageDataPackage StageData,
      PointF OriginalPosition,
      Color Color1,
      Color Color2)
      : base(StageData, OriginalPosition, Color1, Color2)
    {
      this.LifeTime = 150;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      PointF OriginalPosition = new PointF((float) (this.BoundRect.Width / 2), 150f);
      if (this.Time == this.LifeTime - 60 || this.Time == this.LifeTime - 40 || this.Time == this.LifeTime - 20)
      {
        EmitterSaveEnegy3D emitterSaveEnegy3D = new EmitterSaveEnegy3D(this.StageData, OriginalPosition, Color.Green);
        this.StageData.SoundPlay("se_ch02.wav");
      }
      if (this.Time != this.LifeTime)
        return;
      Boss_Rakuki03 bossRakuki03 = new Boss_Rakuki03(this.StageData);
      this.Background3D.WarpEnabled = true;
    }
  }
}
