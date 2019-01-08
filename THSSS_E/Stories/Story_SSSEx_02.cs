 
// Type: Shooting.Planes.Story.Story_SSSEx_02
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

namespace Shooting.Planes.Story
{
  internal class Story_SSSEx_02 : BaseStory_SSS
  {
    public Story_SSSEx_02(StageDataPackage StageData)
      : base(StageData)
    {
      switch (this.MyPlane.Name)
      {
        case "Reimu":
          this.LoadConversation2(".\\Story\\Ex-2A.csv");
          break;
        case "Marisa":
          this.LoadConversation(".\\Story\\Ex-2B.csv");
          break;
        case "Sanae":
          this.LoadConversation(".\\Story\\Ex-2C.csv");
          break;
        case "Koishi":
          this.LoadConversation(".\\Story\\Ex-2D.csv");
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
      EndStage endStage = new EndStage(this.StageData, "GameSetMenu", true);
      ClearBonus clearBonus = new ClearBonus(this.StageData, 70000000);
    }
  }
}
