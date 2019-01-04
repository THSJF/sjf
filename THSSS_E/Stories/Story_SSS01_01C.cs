// Decompiled with JetBrains decompiler
// Type: Shooting.Planes.Story.Story_SSS01_01C
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting.Planes.Story
{
  internal class Story_SSS01_01C : BaseStory_SSS
  {
    public Story_SSS01_01C(StageDataPackage StageData)
      : base(StageData)
    {
      CharacterR_Touhou characterRTouhou = new CharacterR_Touhou(StageData, "FaceAmi01");
      characterRTouhou.TxtureObject2 = this.TextureObjectDictionary[" "];
      characterRTouhou.OriginalPosition = new PointF((float) (this.BoundRect.Width - 60), 380f);
      this.CharR = characterRTouhou;
      CharacterL_Touhou characterLTouhou = new CharacterL_Touhou(StageData, "FaceSanae_hp");
      characterLTouhou.TxtureObject2 = this.TextureObjectDictionary[" "];
      characterLTouhou.OriginalPosition = new PointF(70f, 380f);
      this.CharL = characterLTouhou;
      this.SBox = new StoryBox(StageData);
      this.Conv.Add(new Conversation("那边的人类 请等一下！", false, true, "FaceSanae_hp", "FaceAmi01"));
      this.Conv.Add(new Conversation("哇 是妖精呢~", true, false, "FaceSanae_hp", (string) null));
      this.Conv.Add(new Conversation("有什么事情吗？", true, false, "FaceSanae_no2", (string) null));
      this.Conv.Add(new Conversation("我们来开party吧！", false, true, (string) null, "FaceAmi05"));
      this.Conv.Add(new Conversation("party？现在？", true, false, "FaceSanae_sw", (string) null));
      this.Conv.Add(new Conversation("是啊是啊 我还要邀请很多人呢", false, true, (string) null, "FaceAmi07"));
      this.Conv.Add(new Conversation("你也一起来吧~", false, true, (string) null, "FaceAmi02"));
      this.Conv.Add(new Conversation("真是有活力呢 妖精晚上都不睡觉的吗……", true, false, "FaceSanae_sw", (string) null));
      this.Conv.Add(new Conversation("真遗憾呢，我还有更重要的事情要调查才行", true, false, "FaceSanae_no", (string) null));
      this.Conv.Add(new Conversation("咦？忙着赶路吗？", false, true, (string) null, "FaceAmi01"));
      this.Conv.Add(new Conversation("那也没关系", false, true, (string) null, "FaceAmi04"));
      this.Conv.Add(new Conversation("party现在开始也是可以的哦！", false, true, (string) null, "FaceAmi05"));
      this.Conv.Add(new Conversation("妨碍的话我会揍你的哦？", true, false, "FaceSanae_sw", (string) null));
      this.Conv.Add(new Conversation("在这充满魔力的流星的夜晚", false, true, (string) null, "FaceAmi04"));
      this.Conv.Add(new Conversation("让我们用弹幕", false, true, (string) null, "FaceAmi01"));
      this.Conv.Add(new Conversation("喧闹起来吧！", false, true, (string) null, "FaceAmi05"));
      this.Conv.Add(new Conversation("这可不行呢，看来有必要退治一下了！", true, false, "FaceSanae_an2", (string) null));
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
      if (this.Time == 15 && this.LastTime < this.Time)
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
