 
// Type: Shooting.Planes.Story.StoryEmitterStar
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting.Planes.Story
{
  internal class StoryEmitterStar : BaseObject
  {
    public StoryEmitterStar(
      StageDataPackage StageData,
      PointF Position,
      float Velocity,
      double Direction)
      : base(StageData, (string) null, Position, Velocity, Direction)
    {
      this.LifeTime = 30;
      this.Story.StoryEffectList.Add((BaseObject) this);
    }

    public override void Ctrl()
    {
      base.Ctrl();
      StageDataPackage stageData = this.StageData;
      MyRandom ran = this.Ran;
      PointF position = this.Position;
      int minValue = (int) position.X - 70;
      position = this.Position;
      int maxValue = (int) position.X + 70;
      PointF Position = new PointF((float) ran.Next(minValue, maxValue), this.Position.Y + 20f);
      double num = (double) (this.StageData.Ran.Next(10, 20) / 10);
      double Direction = -1.0 * Math.PI / 2.0 - (double) this.StageData.Ran.Next(1, 5) / 10.0;
      StoryStar storyStar = new StoryStar(stageData, "Star", Position, (float) num, Direction);
      storyStar.Active = true;
      storyStar.Scale = (float) this.StageData.Ran.Next(15, 40) / 80f;
      storyStar.LifeTime = 40;
      this.Story.StoryEffectList.Add((BaseObject) storyStar);
    }
  }
}
