// Decompiled with JetBrains decompiler
// Type: Shooting.Planes.Story.Story_SSS01_01B
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting.Planes.Story
{
  internal class Story_SSS01_01B : BaseStory_SSS
  {
    public Story_SSS01_01B(StageDataPackage StageData)
      : base(StageData)
    {
      CharacterR_Touhou characterRTouhou = new CharacterR_Touhou(StageData, "FaceAmi05");
      characterRTouhou.TxtureObject2 = this.TextureObjectDictionary[" "];
      characterRTouhou.OriginalPosition = new PointF((float) (this.BoundRect.Width - 60), 380f);
      this.CharR = characterRTouhou;
      CharacterL_Touhou characterLTouhou = new CharacterL_Touhou(StageData, "FaceMarisa_sp");
      characterLTouhou.TxtureObject2 = this.TextureObjectDictionary[" "];
      characterLTouhou.OriginalPosition = new PointF(70f, 340f);
      this.CharL = characterLTouhou;
      this.SBox = new StoryBox(StageData);
      this.Conv.Add(new Conversation("流星碎片的确是掉落在这附近了……", true, false, "FaceMarisa_sp", "FaceAmi05"));
      this.Conv.Add(new Conversation("没找到啊……", true, false, "FaceMarisa_lo", (string) null));
      this.Conv.Add(new Conversation("出现了~可以邀请到Party的人类~", false, true, (string) null, "FaceAmi05"));
      this.Conv.Add(new Conversation("哈？搞什么 原来是只妖精啊", true, false, "FaceMarisa_sw", (string) null));
      this.Conv.Add(new Conversation("别飞那么快嘛 来参加热闹的Party吧！", false, true, (string) null, "FaceAmi03"));
      this.Conv.Add(new Conversation("不好意思 我可是很忙的呐", true, false, "FaceMarisa_hp", (string) null));
      this.Conv.Add(new Conversation("妨碍我的话会狠狠揍你的哦", true, false, "FaceMarisa_hp2", (string) null));
      this.Conv.Add(new Conversation("你很忙吗？", false, true, (string) null, "FaceAmi05"));
      this.Conv.Add(new Conversation("很忙的哟", true, false, "FaceMarisa_no", (string) null));
      this.Conv.Add(new Conversation("啊啊…虽然有点早 不过现在就开始吧", false, true, (string) null, "FaceAmi06"));
      this.Conv.Add(new Conversation("为大忙人准备的Party！", false, true, (string) null, "FaceAmi04"));
      this.Conv.Add(new Conversation("呀咧呀咧…果然还是要揍一顿ZE~", true, false, "FaceMarisa_sw", (string) null));
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time == 3 && this.LastTime < this.Time)
      {
        this.LastTime = this.Time;
        this.CharN = new CharacterName(this.StageData, "ename_Ami");
        StoryEmitterStar storyEmitterStar = new StoryEmitterStar(this.StageData, this.CharN.Position, 0.0f, 0.0);
      }
      if (this.Time == 10 && this.LastTime < this.Time)
      {
        this.LastTime = this.Time;
        this.StageData.ChangeBGM(".\\BGM\\Boss01.wav", 0, 0, (int) byte.MaxValue, 754110, 3294270);
      }
      if (this.Time != this.Conv.Count)
        return;
      StageDataPackage stageData = this.StageData;
      Rectangle boundRect = this.BoundRect;
      int width1 = boundRect.Width;
      boundRect = this.BoundRect;
      int y = boundRect.Height - 16;
      Point DestPoint = new Point(width1, y);
      MusicTitle musicTitle1 = new MusicTitle(stageData, "喧闹吧！在这不眠之夜", DestPoint);
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
      EmitterBossFire emitterBossFire = new EmitterBossFire(this.StageData, this.Boss.OriginalPosition, Color.FromArgb(40, (int) byte.MaxValue, 20));
      new MagicCircle(this.StageData, "MagicCircleSix").Scale = 1.5f;
      this.Background3D.WarpEnabled = true;
    }
  }
}
