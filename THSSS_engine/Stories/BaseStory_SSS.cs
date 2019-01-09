 
// Type: Shooting.Planes.Story.BaseStory_SSS
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Shooting.Planes.Story
{
  internal class BaseStory_SSS : BaseStory
  {
    protected List<Conversation> Conv = new List<Conversation>();
    protected CharacterL_Touhou CharL;
    protected CharacterL_Touhou CharL2;
    protected CharacterR_Touhou CharR;
    protected StoryBox SBox;
    protected CharacterName CharN;
    protected int LastTime;
    protected int NameTime;
    protected int MusicTime;

    public BaseStory_SSS()
    {
    }

    public BaseStory_SSS(StageDataPackage StageData)
      : base(StageData)
    {
      CharacterR_Touhou characterRTouhou = new CharacterR_Touhou(StageData, " ");
      characterRTouhou.OriginalPosition = new PointF((float) (this.BoundRect.Width - 60), 380f);
      this.CharR = characterRTouhou;
      CharacterL_Touhou characterLTouhou1 = new CharacterL_Touhou(StageData, " ");
      characterLTouhou1.OriginalPosition = new PointF(70f, 380f);
      this.CharL = characterLTouhou1;
      CharacterL_Touhou characterLTouhou2 = new CharacterL_Touhou(StageData, " ");
      characterLTouhou2.OriginalPosition = new PointF(70f, 380f);
      this.CharL2 = characterLTouhou2;
      this.SBox = new StoryBox(StageData);
    }

    public override void Ctrl()
    {
      base.Ctrl();
      this.CharL.Ctrl();
      this.CharL2.Ctrl();
      this.CharR.Ctrl();
      this.SBox.Ctrl();
      this.StoryEffectList.ForEach((Action<BaseObject>) (x =>
      {
        x.Ctrl();
        if (!x.OutBoundary())
          return;
        this.StoryEffectList.Remove(x);
      }));
      if (this.CharN != null)
        this.CharN.Ctrl();
      if (this.Time >= this.Conv.Count)
        return;
      this.CharR.Active = this.Conv[this.Time].CharRAcitve;
      this.CharL.Active = this.Conv[this.Time].CharLAcitve;
      this.CharL2.Active = this.Conv[this.Time].CharL2Acitve;
      if (this.Conv[this.Time].CharL != null)
        this.CharL.TxtureObject = this.TextureObjectDictionary[this.Conv[this.Time].CharL];
      if (this.Conv[this.Time].CharL2 != null)
        this.CharL2.TxtureObject = this.TextureObjectDictionary[this.Conv[this.Time].CharL2];
      if (this.Conv[this.Time].CharR != null)
        this.CharR.TxtureObject = this.TextureObjectDictionary[this.Conv[this.Time].CharR];
      this.SBox.Text = this.Conv[this.Time].Text;
    }

    public override void Show()
    {
      if (this.CharR.Active)
      {
        if (this.CharL2.Active)
        {
          this.CharL2.Show();
          this.CharL.Show();
        }
        else
        {
          this.CharL.Show();
          this.CharL2.Show();
        }
        this.CharR.Show();
      }
      else
      {
        this.CharR.Show();
        if (this.CharL2.Active)
        {
          this.CharL.Show();
          this.CharL2.Show();
        }
        else
        {
          this.CharL2.Show();
          this.CharL.Show();
        }
      }
      this.SBox.Show();
      if (this.CharN != null)
        this.CharN.Show();
      if (this.StoryEffectList.Count <= 0)
        return;
      this.StoryEffectList.ForEach((Action<BaseObject>) (x =>
      {
        if (x.Active)
          return;
        x.Show();
      }));
      this.SpriteMain.End();
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      this.StageData.DeviceMain.SetRenderState(RenderState.SourceBlend, 5);
      this.StageData.DeviceMain.SetRenderState(RenderState.DestinationBlend, 2);
      this.StoryEffectList.ForEach((Action<BaseObject>) (x =>
      {
        if (!x.Active)
          return;
        x.Show();
      }));
      this.SpriteMain.End();
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
    }

    protected virtual void LoadConversation(string fileName)
    {
      if (!File.Exists(fileName))
        return;
      char[] chArray = new char[1]{ ',' };
      string[] strArray1 = File.ReadAllLines(fileName, Encoding.Default);
      this.Conv.Clear();
      int num = 0;
      foreach (string str in strArray1)
      {
        string[] strArray2 = str.Split(chArray);
        if (num == 0)
        {
          ++num;
          this.NameTime = int.Parse(strArray2[0]);
          this.MusicTime = int.Parse(strArray2[1]);
        }
        else
          this.Conv.Add(new Conversation(strArray2[0], bool.Parse(strArray2[1]), bool.Parse(strArray2[2]), strArray2[3], strArray2[4]));
      }
    }

    protected virtual void LoadConversation2(string fileName)
    {
      if (!File.Exists(fileName))
        return;
      char[] chArray = new char[1]{ ',' };
      string[] strArray1 = File.ReadAllLines(fileName, Encoding.Default);
      this.Conv.Clear();
      int num = 0;
      foreach (string str in strArray1)
      {
        string[] strArray2 = str.Split(chArray);
        if (num == 0)
        {
          ++num;
          this.NameTime = int.Parse(strArray2[0]);
          this.MusicTime = int.Parse(strArray2[1]);
        }
        else
          this.Conv.Add(new Conversation(strArray2[0], bool.Parse(strArray2[1]), strArray2[2], bool.Parse(strArray2[3]), strArray2[4], bool.Parse(strArray2[5]), strArray2[6]));
      }
    }
  }
}
