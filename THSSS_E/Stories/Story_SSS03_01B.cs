// Decompiled with JetBrains decompiler
// Type: Shooting.Planes.Story.Story_SSS03_01B
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting.Planes.Story
{
  internal class Story_SSS03_01B : BaseStory_SSS
  {
    public Story_SSS03_01B(StageDataPackage StageData)
      : base(StageData)
    {
      CharacterR_Touhou characterRTouhou = new CharacterR_Touhou(StageData, "FaceSeiryuu_no");
      characterRTouhou.TxtureObject2 = this.TextureObjectDictionary[" "];
      characterRTouhou.OriginalPosition = new PointF((float) (this.BoundRect.Width - 60), 380f);
      this.CharR = characterRTouhou;
      CharacterL_Touhou characterLTouhou = new CharacterL_Touhou(StageData, "FaceMarisa_sp");
      characterLTouhou.TxtureObject2 = this.TextureObjectDictionary[" "];
      characterLTouhou.OriginalPosition = new PointF(70f, 340f);
      this.CharL = characterLTouhou;
      this.SBox = new StoryBox(StageData);
      this.Conv.Add(new Conversation("碎片掉到这片密林里去了呢…", true, false, "FaceMarisa_sp", "FaceSeiryuu_sp"));
      this.Conv.Add(new Conversation("不过话说这附近的树木也太茂密了吧…不方便收集呢", true, false, "FaceMarisa_lo", (string) null));
      this.Conv.Add(new Conversation("不赶紧到视野好一点的地方去的话……", true, false, "FaceMarisa_lo", (string) null));
      this.Conv.Add(new Conversation("你是…人类？", false, true, (string) null, "FaceSeiryuu_sp"));
      this.Conv.Add(new Conversation("暂时还是~", true, false, "FaceMarisa_hp", (string) null));
      this.Conv.Add(new Conversation("人类为何要来这偏远的柳林呢？", false, true, (string) null, "FaceSeiryuu_no"));
      this.Conv.Add(new Conversation("本来是顺着魔力来收集星星碎片的说…然后…", true, false, "FaceMarisa_no2", (string) null));
      this.Conv.Add(new Conversation("迷路了~", true, false, "FaceMarisa_hp2", (string) null));
      this.Conv.Add(new Conversation("哈？", false, true, (string) null, "FaceSeiryuu_sw"));
      this.Conv.Add(new Conversation("那个 方便的话 可以指个路么ZE~", true, false, "FaceMarisa_hp", (string) null));
      this.Conv.Add(new Conversation("诶嘿~可以的哟~", false, true, (string) null, "FaceSeiryuu_no"));
      this.Conv.Add(new Conversation("不过作为交换", false, true, (string) null, "FaceSeiryuu_hp"));
      this.Conv.Add(new Conversation("把你手中的流星碎片留下吧", false, true, (string) null, "FaceSeiryuu_dp"));
      this.Conv.Add(new Conversation("只有这个不可以呢", true, false, "FaceMarisa_no", (string) null));
      this.Conv.Add(new Conversation("你该不会一开始就看准了这个吧？", true, false, "FaceMarisa_sw", (string) null));
      this.Conv.Add(new Conversation("柳树的妖怪？", true, false, "FaceMarisa_sw", (string) null));
      this.Conv.Add(new Conversation("被识破了吗？", false, true, (string) null, "FaceSeiryuu_no"));
      this.Conv.Add(new Conversation("你也不是简单的人类啊", false, true, (string) null, "FaceSeiryuu_dp"));
      this.Conv.Add(new Conversation("人类少女怎么会孤零零地来这偏远的柳林", true, false, "FaceMarisa_no", (string) null));
      this.Conv.Add(new Conversation("把你手中的八卦炉作为交换也是可以的哦~", false, true, (string) null, "FaceSeiryuu_sp"));
      this.Conv.Add(new Conversation("这个也不行！", true, false, "FaceMarisa_an", (string) null));
      this.Conv.Add(new Conversation("是吗？那么……", false, true, (string) null, "FaceSeiryuu_dp"));
      this.Conv.Add(new Conversation("就把你的命留下吧！", false, true, (string) null, "FaceSeiryuu_sw"));
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time == 16 && this.LastTime < this.Time)
      {
        this.CharN = new CharacterName(this.StageData, "ename_Seiryuu");
        StoryEmitterStar storyEmitterStar = new StoryEmitterStar(this.StageData, this.CharN.Position, 0.0f, 0.0);
        this.LastTime = this.Time;
      }
      else if (this.Time == 21 && this.LastTime < this.Time)
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
