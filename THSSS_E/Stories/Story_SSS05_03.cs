// Decompiled with JetBrains decompiler
// Type: Shooting.Planes.Story.Story_SSS05_03
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

namespace Shooting.Planes.Story
{
  internal class Story_SSS05_03 : BaseStory_SSS
  {
    public Story_SSS05_03(StageDataPackage StageData)
      : base(StageData)
    {
      switch (this.MyPlane.Name)
      {
        case "Reimu":
          this.LoadConversation2(".\\Story\\5-3A.csv");
          break;
        case "Marisa":
          this.LoadConversation(".\\Story\\5-3B.csv");
          break;
        case "Sanae":
          this.LoadConversation(".\\Story\\5-3C.csv");
          break;
        case "Koishi":
          this.LoadConversation(".\\Story\\5-3D.csv");
          break;
      }
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time != this.Conv.Count)
        return;
      this.SBox.Dispose();
      this.Story = (BaseStory) null;
      EndStage endStage = new EndStage(this.StageData, "St6", false);
      ClearBonus clearBonus = new ClearBonus(this.StageData, 50000000);
    }
  }
}
