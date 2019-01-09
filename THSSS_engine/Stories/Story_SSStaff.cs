 
// Type: Shooting.Planes.Story.Story_SSStaff
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

namespace Shooting.Planes.Story
{
  internal class Story_SSStaff : BaseStory_SSS
  {
    private CG Cg;

    public Story_SSStaff(StageDataPackage StageData)
      : base(StageData)
    {
      switch (this.MyPlane.Name)
      {
        case "Reimu":
          this.LoadConversation(".\\Story\\Staff-1A.csv");
          break;
        case "Marisa":
          this.LoadConversation(".\\Story\\Staff-1B.csv");
          break;
        case "Sanae":
          this.LoadConversation(".\\Story\\Staff-1C.csv");
          break;
        case "Koishi":
          this.LoadConversation(".\\Story\\Staff-1D.csv");
          break;
      }
      this.SBox.MaxTransparent = 0;
      this.Cg = new CG(StageData, (string) null);
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.CharL.TxtureObject = (TextureObject) null;
      this.CharR.TxtureObject = (TextureObject) null;
      this.Cg.Ctrl();
      if (this.Time < this.Conv.Count)
        this.Cg.TxtureObject = this.TextureObjectDictionary[this.Conv[this.Time].CharL];
      if (this.Time != this.Conv.Count)
        return;
      this.SBox.Dispose();
      this.Story = (BaseStory) null;
    }

    public override void Show()
    {
      this.Cg.Show();
      base.Show();
    }
  }
}
