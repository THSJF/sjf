// Decompiled with JetBrains decompiler
// Type: Shooting.Planes.Story.Story_SSSEx_01
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Drawing;

namespace Shooting.Planes.Story
{
  internal class Story_SSSEx_01 : BaseStory_SSS
  {
    public Story_SSSEx_01(StageDataPackage StageData)
      : base(StageData)
    {
      switch (this.MyPlane.Name)
      {
        case "Reimu":
          this.LoadConversation2(".\\Story\\Ex-1A.csv");
          break;
        case "Marisa":
          this.LoadConversation(".\\Story\\Ex-1B.csv");
          break;
        case "Sanae":
          this.LoadConversation(".\\Story\\Ex-1C.csv");
          break;
        case "Koishi":
          this.LoadConversation(".\\Story\\Ex-1D.csv");
          break;
      }
    }

    public override void Ctrl()
    {
      base.Ctrl();
      if (this.Time == this.NameTime && this.LastTime < this.Time)
      {
        this.CharN = new CharacterName(this.StageData, "ename_Rika");
        this.LastTime = this.Time;
      }
      else if (this.Time == this.MusicTime && this.LastTime < this.Time)
      {
        this.StageData.ChangeBGM(".\\BGM\\BossEx.wav", 0, 0, (int) byte.MaxValue, 1125873, 10783332);
        this.LastTime = this.Time;
      }
      if (this.Time != this.Conv.Count)
        return;
      MusicTitle musicTitle = new MusicTitle(this.StageData, "风中花，雪中月", new Point(this.BoundRect.Width, this.BoundRect.Height - 16));
      musicTitle.OriginalPosition = new PointF((float) this.BoundRect.Width, (float) (this.BoundRect.Height + 100));
      musicTitle.Scale = 0.5f;
      this.Boss.Enabled = true;
      this.SBox.Dispose();
      this.Story = (BaseStory) null;
      EmitterBossFire emitterBossFire = new EmitterBossFire(this.StageData, this.Boss.OriginalPosition, Color.Yellow);
      new MagicCircle(this.StageData, "MagicCircleSix").Scale = 1.5f;
      this.Background3D.WarpEnabled = true;
    }
  }
}
