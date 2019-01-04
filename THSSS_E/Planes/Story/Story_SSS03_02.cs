// Decompiled with JetBrains decompiler
// Type: Shooting.Planes.Story.Story_SSS03_02
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting.Planes.Story
{
  internal class Story_SSS03_02 : BaseStory_SSS
  {
    public Story_SSS03_02(StageDataPackage StageData)
      : base(StageData)
    {
      CharacterR_Touhou characterRTouhou = new CharacterR_Touhou(StageData, "FaceSeiryuu_lo");
      characterRTouhou.TxtureObject2 = this.TextureObjectDictionary[" "];
      characterRTouhou.OriginalPosition = new PointF((float) (this.BoundRect.Width - 60), 380f);
      this.CharR = characterRTouhou;
      CharacterL_Touhou characterLTouhou = new CharacterL_Touhou(StageData, "FaceAya_no");
      characterLTouhou.TxtureObject2 = this.TextureObjectDictionary["FaceAya_base"];
      this.CharL = characterLTouhou;
      this.SBox = new StoryBox(StageData);
      this.Conv.Add(new Conversation("。。。", false, true, "FaceAya_no", "FaceSeiryuu_no"));
      this.Conv.Add(new Conversation("。。。。。。", true, false, "FaceAya_no", "FaceSeiryuu_no"));
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
