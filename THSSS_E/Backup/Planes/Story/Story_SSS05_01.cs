// Decompiled with JetBrains decompiler
// Type: Shooting.Planes.Story.Story_SSS05_01
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting.Planes.Story
{
  internal class Story_SSS05_01 : BaseStory_SSS
  {
    private int circle = 120;
    private int tCount = 0;

    public Story_SSS05_01(StageDataPackage StageData)
      : base(StageData)
    {
      switch (this.MyPlane.Name)
      {
        case "Reimu":
          this.LoadConversation2(".\\Story\\5-1A.csv");
          break;
        case "Marisa":
          this.LoadConversation(".\\Story\\5-1B.csv");
          break;
        case "Sanae":
          this.LoadConversation(".\\Story\\5-1C.csv");
          break;
        case "Koishi":
          this.LoadConversation(".\\Story\\5-1D.csv");
          break;
      }
    }

    public override void Ctrl()
    {
      ++this.tCount;
      if (this.Time < this.tCount / this.circle)
        ++this.Time;
      base.Ctrl();
      if (this.Time == this.NameTime && this.LastTime < this.Time)
        this.LastTime = this.Time;
      else if (this.Time == this.MusicTime && this.LastTime < this.Time)
        this.LastTime = this.Time;
      if (this.Time != this.Conv.Count)
        return;
      this.Boss.Enabled = true;
      this.SBox.Dispose();
      this.Story = (BaseStory) null;
      EmitterBossFire emitterBossFire = new EmitterBossFire(this.StageData, this.Boss.OriginalPosition, Color.FromArgb(144, (int) byte.MaxValue, 120));
      new MagicCircle(this.StageData, "MagicCircleSix").Scale = 1.5f;
      this.Background3D.WarpColorKey = 2;
      this.Background3D.WarpEnabled = true;
    }
  }
}
