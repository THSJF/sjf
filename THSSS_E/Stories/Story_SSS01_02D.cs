 
// Type: Shooting.Planes.Story.Story_SSS01_02D
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

namespace Shooting.Planes.Story
{
  internal class Story_SSS01_02D : BaseStory_SSS
  {
    public Story_SSS01_02D(StageDataPackage StageData)
      : base(StageData)
    {
      this.LoadConversation(".\\Story\\1-2D.csv");
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time != this.Conv.Count)
        return;
      this.SBox.Dispose();
      this.Story = (BaseStory) null;
      EndStage endStage = new EndStage(this.StageData, "St2", false);
      ClearBonus clearBonus = new ClearBonus(this.StageData, 10000000);
    }
  }
}
