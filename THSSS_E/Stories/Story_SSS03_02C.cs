 
// Type: Shooting.Planes.Story.Story_SSS03_02C
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting.Planes.Story
{
  internal class Story_SSS03_02C : BaseStory_SSS
  {
    public Story_SSS03_02C(StageDataPackage StageData)
      : base(StageData)
    {
      CharacterR_Touhou characterRTouhou = new CharacterR_Touhou(StageData, "FaceSeiryuu_lo");
      characterRTouhou.TxtureObject2 = this.TextureObjectDictionary[" "];
      characterRTouhou.OriginalPosition = new PointF((float) (this.BoundRect.Width - 60), 380f);
      this.CharR = characterRTouhou;
      CharacterL_Touhou characterLTouhou = new CharacterL_Touhou(StageData, "FaceSanae_sw");
      characterLTouhou.TxtureObject2 = this.TextureObjectDictionary[" "];
      characterLTouhou.OriginalPosition = new PointF(70f, 380f);
      this.CharL = characterLTouhou;
      this.SBox = new StoryBox(StageData);
      this.Conv.Add(new Conversation("呜~被打败啦", false, true, "FaceSanae_hp", "FaceSeiryuu_lo"));
      this.Conv.Add(new Conversation("好不甘心呀", false, true, "FaceSanae_hp", "FaceSeiryuu_lo"));
      this.Conv.Add(new Conversation("那么你的流星碎片我就收下啦", true, false, "FaceSanae_hp", "FaceSeiryuu_lo"));
      this.Conv.Add(new Conversation("这样我的信仰也会增加的吧？", true, false, "FaceSanae_hp", "FaceSeiryuu_lo"));
      this.Conv.Add(new Conversation("不过这样真的好吗？", false, true, (string) null, "FaceSeiryuu_lo"));
      this.Conv.Add(new Conversation("你指什么？", true, false, "FaceSanae_sw", (string) null));
      this.Conv.Add(new Conversation("你收集的流星碎片", false, true, (string) null, "FaceSeiryuu_lo"));
      this.Conv.Add(new Conversation("那份光芒会让你迷失方向的哦？", false, true, (string) null, "FaceSeiryuu_lo"));
      this.Conv.Add(new Conversation("净说什么瞎话", true, false, "FaceSanae_lo", (string) null));
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time != this.Conv.Count)
        return;
      this.SBox.Dispose();
      this.Story = (BaseStory) null;
      EndStage endStage = new EndStage(this.StageData, "St4", false);
      ClearBonus clearBonus = new ClearBonus(this.StageData, 30000000);
    }
  }
}
