 
// Type: Shooting.Planes.Story.Story_SSS02_01C
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting.Planes.Story
{
  internal class Story_SSS02_01C : BaseStory_SSS
  {
    public Story_SSS02_01C(StageDataPackage StageData)
      : base(StageData)
    {
      CharacterR_Touhou characterRTouhou = new CharacterR_Touhou(StageData, "FaceRakuki_no");
      characterRTouhou.TxtureObject2 = this.TextureObjectDictionary[" "];
      characterRTouhou.OriginalPosition = new PointF((float) (this.BoundRect.Width - 60), 380f);
      this.CharR = characterRTouhou;
      CharacterL_Touhou characterLTouhou = new CharacterL_Touhou(StageData, "FaceSanae_an");
      characterLTouhou.TxtureObject2 = this.TextureObjectDictionary[" "];
      characterLTouhou.OriginalPosition = new PointF(70f, 380f);
      this.CharL = characterLTouhou;
      this.SBox = new StoryBox(StageData);
      this.Conv.Add(new Conversation("前方的区域禁止进入", false, true, "FaceSanae_an", "FaceRakuki_no"));
      this.Conv.Add(new Conversation("你是谁 为什么要阻拦我？", true, false, "FaceSanae_an", "FaceRakuki_no"));
      this.Conv.Add(new Conversation("我叫洛熙", false, true, (string) null, "FaceRakuki_an2"));
      this.Conv.Add(new Conversation("你是人类？回去吧 这些与你无关", false, true, (string) null, "FaceRakuki_no"));
      this.Conv.Add(new Conversation("果然你们在谋划些什么", true, false, "FaceSanae_no", (string) null));
      this.Conv.Add(new Conversation("我是现人神 可不能坐视不管", true, false, "FaceSanae_no2", (string) null));
      this.Conv.Add(new Conversation("现人神也是一样", false, true, (string) null, "FaceRakuki_an2"));
      this.Conv.Add(new Conversation("只要争取到足够的时间的话", false, true, (string) null, "FaceRakuki_dp"));
      this.Conv.Add(new Conversation("我们自然会离开这里", false, true, (string) null, "FaceRakuki_no2"));
      this.Conv.Add(new Conversation("这怎么可以！", true, false, "FaceSanae_sw", (string) null));
      this.Conv.Add(new Conversation("再放任这些魔力的流星不管的话", true, false, "FaceSanae_sw", (string) null));
      this.Conv.Add(new Conversation("各路妖怪们都会暴动的", true, false, "FaceSanae_sw", (string) null));
      this.Conv.Add(new Conversation("妖怪会如何与我人类何干？", false, true, (string) null, "FaceRakuki_no"));
      this.Conv.Add(new Conversation("看来只能强行突破了", true, false, "FaceSanae_an", (string) null));
      this.Conv.Add(new Conversation("来吧 弹幕对战！", true, false, "FaceSanae_an2", (string) null));
      this.Conv.Add(new Conversation("天真！", false, true, (string) null, "FaceRakuki_an"));
      this.Conv.Add(new Conversation("你真以为你能逃过我的箭雨吗？", false, true, (string) null, "FaceRakuki_an"));
      this.Conv.Add(new Conversation("在这把琴引山的神弓下", false, true, (string) null, "FaceRakuki_dp"));
      this.Conv.Add(new Conversation("去死吧！", false, true, (string) null, "FaceRakuki_bk"));
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time == 2 && this.LastTime < this.Time)
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
