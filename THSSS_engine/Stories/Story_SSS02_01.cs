 
// Type: Shooting.Planes.Story.Story_SSS02_01
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting.Planes.Story
{
  internal class Story_SSS02_01 : BaseStory_SSS
  {
    public Story_SSS02_01(StageDataPackage StageData)
      : base(StageData)
    {
      CharacterR_Touhou characterRTouhou = new CharacterR_Touhou(StageData, "FaceRakuki_no");
      characterRTouhou.TxtureObject2 = this.TextureObjectDictionary[" "];
      characterRTouhou.OriginalPosition = new PointF((float) (this.BoundRect.Width - 60), 380f);
      this.CharR = characterRTouhou;
      CharacterL_Touhou characterLTouhou = new CharacterL_Touhou(StageData, "FaceAya_no");
      characterLTouhou.TxtureObject2 = this.TextureObjectDictionary["FaceAya_base"];
      this.CharL = characterLTouhou;
      this.SBox = new StoryBox(StageData);
      this.CharN = new CharacterName(StageData, "ename_Rakuki");
      StoryEmitterStar storyEmitterStar = new StoryEmitterStar(StageData, this.CharN.Position, 0.0f, 0.0);
      this.Conv.Add(new Conversation("。。。", false, true, "FaceAya_no", "FaceRakuki_no"));
      this.Conv.Add(new Conversation("。。。。。。", true, false, "FaceAya_no", "FaceRakuki_no"));
      this.Conv.Add(new Conversation("四只老鼠在吹牛：", false, true, (string) null, "FaceRakuki_no2"));
      this.Conv.Add(new Conversation("甲：我每天都拿鼠药当糖吃；", false, true, (string) null, "FaceRakuki_hp"));
      this.Conv.Add(new Conversation("乙：我一天不踩老鼠夹脚发痒；", false, true, (string) null, "FaceRakuki_no"));
      this.Conv.Add(new Conversation("丙：我每天不过几次大街不踏实；", false, true, (string) null, "FaceRakuki_an"));
      this.Conv.Add(new Conversation("丁：时间不早了，回家抱猫去咯。", false, true, (string) null, "FaceRakuki_bk"));
      this.Conv.Add(new Conversation("@画师，我需要一个泪奔的表情", true, false, "FaceAya_lo", (string) null));
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time != this.Conv.Count)
        return;
      this.Boss.Enabled = true;
      this.StageData.ChangeBGM(".\\BGM\\Boss02.wav", 0, 0, (int) byte.MaxValue, 327663, 3504627);
      StageDataPackage stageData = this.StageData;
      Rectangle boundRect1 = this.BoundRect;
      int width1 = boundRect1.Width;
      boundRect1 = this.BoundRect;
      int y = boundRect1.Height - 16;
      Point DestPoint = new Point(width1, y);
      MusicTitle musicTitle1 = new MusicTitle(stageData, "疾风闪电", DestPoint);
      MusicTitle musicTitle2 = musicTitle1;
      Rectangle boundRect2 = this.BoundRect;
      double width2 = (double) boundRect2.Width;
      boundRect2 = this.BoundRect;
      double num = (double) (boundRect2.Height + 100);
      PointF pointF = new PointF((float) width2, (float) num);
      musicTitle2.OriginalPosition = pointF;
      musicTitle1.Scale = 0.5f;
      this.SBox.Dispose();
      this.Story = (BaseStory) null;
      EmitterBossFire emitterBossFire = new EmitterBossFire(this.StageData, this.Boss.OriginalPosition, Color.FromArgb(144, (int) byte.MaxValue, 120));
      new MagicCircle(this.StageData, "MagicCircleSix").Scale = 1.5f;
      this.Background3D.WarpEnabled = true;
    }
  }
}
