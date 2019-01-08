 
// Type: Shooting.Planes.Story.Story_SSS02_01B
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting.Planes.Story
{
  internal class Story_SSS02_01B : BaseStory_SSS
  {
    public Story_SSS02_01B(StageDataPackage StageData)
      : base(StageData)
    {
      CharacterR_Touhou characterRTouhou = new CharacterR_Touhou(StageData, "FaceRakuki_an2");
      characterRTouhou.TxtureObject2 = this.TextureObjectDictionary[" "];
      characterRTouhou.OriginalPosition = new PointF((float) (this.BoundRect.Width - 60), 380f);
      this.CharR = characterRTouhou;
      CharacterL_Touhou characterLTouhou = new CharacterL_Touhou(StageData, "FaceMarisa_sp");
      characterLTouhou.TxtureObject2 = this.TextureObjectDictionary[" "];
      characterLTouhou.OriginalPosition = new PointF(70f, 340f);
      this.CharL = characterLTouhou;
      this.SBox = new StoryBox(StageData);
      this.Conv.Add(new Conversation("到此为止了 魔女小姐！", false, true, "FaceMarisa_sp", "FaceRakuki_an2"));
      this.Conv.Add(new Conversation("诶 出现了一个奇怪的人类呢", true, false, "FaceMarisa_sp", "FaceRakuki_an2"));
      this.Conv.Add(new Conversation("才不是什么奇怪的人类呢", false, true, (string) null, "FaceRakuki_an"));
      this.Conv.Add(new Conversation("我叫洛熙", false, true, (string) null, "FaceRakuki_an"));
      this.Conv.Add(new Conversation("罕见的弓箭使呢", true, false, "FaceMarisa_no", (string) null));
      this.Conv.Add(new Conversation("你也是来妨碍我的吗？", true, false, "FaceMarisa_sw", (string) null));
      this.Conv.Add(new Conversation("因为和姐姐约定好了……", false, true, (string) null, "FaceRakuki_dp"));
      this.Conv.Add(new Conversation("总之你不能继续往前的哦", false, true, (string) null, "FaceRakuki_an2"));
      this.Conv.Add(new Conversation("前面有些什么我并不感兴趣", true, false, "FaceMarisa_no", (string) null));
      this.Conv.Add(new Conversation("我只是来收集流星碎片的说~", true, false, "FaceMarisa_hp", (string) null));
      this.Conv.Add(new Conversation("就让我过去吧 如何？", true, false, "FaceMarisa_hp2", (string) null));
      this.Conv.Add(new Conversation("那你可要问问我手里这张弓了！", false, true, (string) null, "FaceRakuki_dp"));
      this.Conv.Add(new Conversation("只不过是弓箭而已", true, false, "FaceMarisa_hp", (string) null));
      this.Conv.Add(new Conversation("追的上我的魔法话就来试试吧~", true, false, "FaceMarisa_hp2", (string) null));
      this.Conv.Add(new Conversation("真是目光短浅！", false, true, (string) null, "FaceRakuki_an"));
      this.Conv.Add(new Conversation("那种三脚猫魔法在我面前毫无用处", false, true, (string) null, "FaceRakuki_an"));
      this.Conv.Add(new Conversation("就让你带着恐惧和后悔", false, true, (string) null, "FaceRakuki_dp"));
      this.Conv.Add(new Conversation("去死吧！", false, true, (string) null, "FaceRakuki_bk"));
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time == 3 && this.LastTime < this.Time)
      {
        this.LastTime = this.Time;
        this.CharN = new CharacterName(this.StageData, "ename_Rakuki");
        StoryEmitterStar storyEmitterStar = new StoryEmitterStar(this.StageData, this.CharN.Position, 0.0f, 0.0);
      }
      if (this.Time == 17 && this.LastTime < this.Time)
      {
        this.StageData.ChangeBGM(".\\BGM\\Boss02.wav", 0, 0, (int) byte.MaxValue, 327663, 3504627);
        this.LastTime = this.Time;
      }
      if (this.Time != this.Conv.Count)
        return;
      StageDataPackage stageData = this.StageData;
      Rectangle boundRect = this.BoundRect;
      int width1 = boundRect.Width;
      boundRect = this.BoundRect;
      int y = boundRect.Height - 16;
      Point DestPoint = new Point(width1, y);
      MusicTitle musicTitle1 = new MusicTitle(stageData, "疾风闪电", DestPoint);
      MusicTitle musicTitle2 = musicTitle1;
      boundRect = this.BoundRect;
      double width2 = (double) boundRect.Width;
      boundRect = this.BoundRect;
      double num = (double) (boundRect.Height + 100);
      PointF pointF = new PointF((float) width2, (float) num);
      musicTitle2.OriginalPosition = pointF;
      musicTitle1.Scale = 0.5f;
      this.Boss.Enabled = true;
      this.SBox.Dispose();
      this.Story = (BaseStory) null;
      EmitterBossFire emitterBossFire = new EmitterBossFire(this.StageData, this.Boss.OriginalPosition, Color.FromArgb(144, (int) byte.MaxValue, 120));
      new MagicCircle(this.StageData, "MagicCircleSix").Scale = 1.5f;
      this.Background3D.WarpEnabled = true;
    }
  }
}
