﻿// Decompiled with JetBrains decompiler
// Type: Shooting.Planes.Story.Story_SSS02_01A
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting.Planes.Story
{
  internal class Story_SSS02_01A : BaseStory_SSS
  {
    public Story_SSS02_01A(StageDataPackage StageData)
      : base(StageData)
    {
      this.LoadConversation2(".\\Story\\2-1A.csv");
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time == this.NameTime && this.LastTime < this.Time)
      {
        this.LastTime = this.Time;
        this.CharN = new CharacterName(this.StageData, "ename_Rakuki");
        StoryEmitterStar storyEmitterStar = new StoryEmitterStar(this.StageData, this.CharN.Position, 0.0f, 0.0);
      }
      if (this.Time == this.MusicTime && this.LastTime < this.Time)
      {
        this.StageData.ChangeBGM(".\\BGM\\Boss02.wav", 0, 0, (int) byte.MaxValue, 327663, 3504627);
        this.LastTime = this.Time;
      }
      if (this.Time != this.Conv.Count)
        return;
      MusicTitle musicTitle = new MusicTitle(this.StageData, "疾风闪电", new Point(this.BoundRect.Width, this.BoundRect.Height - 16));
      musicTitle.OriginalPosition = new PointF((float) this.BoundRect.Width, (float) (this.BoundRect.Height + 100));
      musicTitle.Scale = 0.5f;
      this.Boss.Enabled = true;
      this.SBox.Dispose();
      this.Story = (BaseStory) null;
      EmitterBossFire emitterBossFire = new EmitterBossFire(this.StageData, this.Boss.OriginalPosition, Color.FromArgb(144, (int) byte.MaxValue, 120));
      new MagicCircle(this.StageData, "MagicCircleSix").Scale = 1.5f;
      this.Background3D.WarpEnabled = true;
    }
  }
}
