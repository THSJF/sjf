 
// Type: Shooting.BulletPicEmitter01
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  public class BulletPicEmitter01 : BaseBulleEmitter
  {
    private int indexY = 0;
    private bool[,] BulletPic;
    private BaseObject Bullet;
    private int length;
    private byte ColorType;

    public BulletPicEmitter01(
      StageDataPackage StageData,
      string BPicName,
      BaseObject Bullet,
      PointF OriginalPosition,
      double Direction,
      byte ColorType)
      : base(StageData)
    {
      this.OriginalPosition = OriginalPosition;
      this.BulletPic = StageData.GlobalData.BulletPicDictionary[BPicName];
      this.Bullet = Bullet;
      this.ColorType = ColorType;
      this.length = (int) Math.Sqrt((double) this.BulletPic.Length);
      this.LifeTime = this.length * 2 + 10;
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time >= this.LifeTime)
        this.BulletList.ForEach((Action<BaseBullet_Touhou>) (x => x.Enabled = true));
      if (this.Time % 2 != 0 || this.indexY >= this.length)
        return;
      for (int index = 0; index < this.length; ++index)
      {
        if (this.BulletPic[index, this.indexY])
        {
          PointF OriginalPosition = new PointF(this.OriginalPosition.X + (float) (index - this.length / 2) * 5f, this.OriginalPosition.Y + (float) (this.indexY - this.length / 2) * 5f);
          BaseBullet_Touhou baseBulletTouhou = new BaseBullet_Touhou(this.StageData, (string) null, OriginalPosition, 0.0f, 0.0);
          baseBulletTouhou.Copy(this.Bullet);
          baseBulletTouhou.OriginalPosition = OriginalPosition;
          baseBulletTouhou.Velocity = (float) baseBulletTouhou.GetDistance(this.OriginalPosition) * 3f / (float) this.length;
          baseBulletTouhou.DirectionDegree = (double) this.Ran.Next(360);
          baseBulletTouhou.Enabled = false;
          this.StageData.SoundPlay("se_tan00a.wav");
        }
      }
      ++this.indexY;
    }

    public override void Shoot()
    {
    }
  }
}
