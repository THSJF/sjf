// Decompiled with JetBrains decompiler
// Type: Shooting.Planes.Story.Story_SSS03_01C
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting.Planes.Story
{
  internal class Story_SSS03_01C : BaseStory_SSS
  {
    public Story_SSS03_01C(StageDataPackage StageData)
      : base(StageData)
    {
      CharacterR_Touhou characterRTouhou = new CharacterR_Touhou(StageData, "FaceSeiryuu_no");
      characterRTouhou.TxtureObject2 = this.TextureObjectDictionary[" "];
      characterRTouhou.OriginalPosition = new PointF((float) (this.BoundRect.Width - 60), 380f);
      this.CharR = characterRTouhou;
      CharacterL_Touhou characterLTouhou = new CharacterL_Touhou(StageData, "FaceSanae_no");
      characterLTouhou.TxtureObject2 = this.TextureObjectDictionary[" "];
      characterLTouhou.OriginalPosition = new PointF(70f, 380f);
      this.CharL = characterLTouhou;
      this.SBox = new StoryBox(StageData);
      this.Conv.Add(new Conversation("不知不觉已经进入密林当中了吗？", true, false, "FaceSanae_no", "FaceSeiryuu_sp"));
      this.Conv.Add(new Conversation("呜……视线都被遮挡住了 这样就没法看到流星了呢", true, false, "FaceSanae_lo", (string) null));
      this.Conv.Add(new Conversation("不赶紧飞上树林上方的话……", true, false, "FaceSanae_sw", (string) null));
      this.Conv.Add(new Conversation("咦？是人类吗", false, true, (string) null, "FaceSeiryuu_sp"));
      this.Conv.Add(new Conversation("人类为何会来这片偏远的柳林？", false, true, (string) null, "FaceSeiryuu_hp"));
      this.Conv.Add(new Conversation("那个 我是来调查这些流星碎片的", true, false, "FaceSanae_no2", (string) null));
      this.Conv.Add(new Conversation("总觉得要是收集到这份力量的话", true, false, "FaceSanae_no", (string) null));
      this.Conv.Add(new Conversation("信仰也会增加的吧", true, false, "FaceSanae_no", (string) null));
      this.Conv.Add(new Conversation("是这样啊~", false, true, (string) null, "FaceSeiryuu_hp"));
      this.Conv.Add(new Conversation("的确呢 能够感受到这些星星里面包含着充足的魔力", false, true, (string) null, "FaceSeiryuu_dp"));
      this.Conv.Add(new Conversation("你知道是谁在制造这些流星吗？", true, false, "FaceSanae_no", (string) null));
      this.Conv.Add(new Conversation("不知道呢", false, true, (string) null, "FaceSeiryuu_no"));
      this.Conv.Add(new Conversation("不过如果吸收掉的话", false, true, (string) null, "FaceSeiryuu_hp"));
      this.Conv.Add(new Conversation("我的力量也会增长的吧", false, true, (string) null, "FaceSeiryuu_sw"));
      this.Conv.Add(new Conversation("你是妖怪？", true, false, "FaceSanae_sp", (string) null));
      this.Conv.Add(new Conversation("你觉得会有孤零零的人类少女来到这偏远的地方吗", false, true, (string) null, "FaceSeiryuu_sw"));
      this.Conv.Add(new Conversation("你也在收集流星碎片吗？", true, false, "FaceSanae_an2", (string) null));
      this.Conv.Add(new Conversation("原来是竞争对手呢", true, false, "FaceSanae_an", (string) null));
      this.Conv.Add(new Conversation("区区人类也要与妖怪竞争吗？被小看了啊", false, true, (string) null, "FaceSeiryuu_dp"));
      this.Conv.Add(new Conversation("怎么说我也是存在了千年的妖怪了", false, true, (string) null, "FaceSeiryuu_dp"));
      this.Conv.Add(new Conversation("妖怪的厉害之处", false, true, (string) null, "FaceSeiryuu_sw"));
      this.Conv.Add(new Conversation("就让你好好体会一下吧！", false, true, (string) null, "FaceSeiryuu_sw"));
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time == 15 && this.LastTime < this.Time)
      {
        this.CharN = new CharacterName(this.StageData, "ename_Seiryuu");
        StoryEmitterStar storyEmitterStar = new StoryEmitterStar(this.StageData, this.CharN.Position, 0.0f, 0.0);
        this.LastTime = this.Time;
      }
      else if (this.Time == 20 && this.LastTime < this.Time)
      {
        this.StageData.ChangeBGM(".\\BGM\\Boss03.wav", 0, 0, (int) byte.MaxValue, 1286397, 6275430);
        this.LastTime = this.Time;
      }
      else
      {
        if (this.Time != this.Conv.Count)
          return;
        StageDataPackage stageData = this.StageData;
        Rectangle boundRect = this.BoundRect;
        int width1 = boundRect.Width;
        boundRect = this.BoundRect;
        int y = boundRect.Height - 16;
        Point DestPoint = new Point(width1, y);
        MusicTitle musicTitle1 = new MusicTitle(stageData, "青柳传说", DestPoint);
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
}
