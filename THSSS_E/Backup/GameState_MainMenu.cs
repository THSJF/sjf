// Decompiled with JetBrains decompiler
// Type: Shooting.GameState_MainMenu
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using SlimDX.Direct3D9;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Shooting
{
  internal class GameState_MainMenu : BaseMenu, IGameState
  {
    private GameRegion GameRegion_Menu;
    private BaseEffect SelectFrame;

    private void InitializeComponent()
    {
      this.GameRegion_Menu = new GameRegion();
      this.SuspendLayout();
      this.GameRegion_Menu.AutoSize = true;
      this.GameRegion_Menu.BackColor = Color.Transparent;
      this.GameRegion_Menu.BackgroundImage = (Image) Shooting.Properties.Resources.Menu_Start;
      this.GameRegion_Menu.BackgroundImageLayout = ImageLayout.Center;
      this.GameRegion_Menu.Enabled = false;
      this.GameRegion_Menu.Location = new Point(59, 138);
      this.GameRegion_Menu.Name = "GameRegion_Menu";
      this.GameRegion_Menu.Size = new Size(103, 28);
      this.GameRegion_Menu.TabIndex = 0;
      this.GameRegion_Menu.Visible = false;
      this.BackgroundImage = (Image) Shooting.Properties.Resources.菜单背景;
      this.Controls.Add((Control) this.GameRegion_Menu);
      this.Enabled = false;
      this.Name = nameof (GameState_MainMenu);
      this.Size = new Size(640, 480);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public GameState_MainMenu(GlobalDataPackage GlobalData)
      : base(GlobalData)
    {
      this.InitializeComponent();
      this.DXFont = new SlimDX.Direct3D9.Font(this.DeviceMain, new System.Drawing.Font("Arial", 12f, FontStyle.Bold | FontStyle.Italic));
    }

    public override void Init()
    {
      this.StageData.PData.CheckEnable();
      this.StageData.PData.SaveData();
      this.BackgroundLight = 0;
      this.BGM_Player.Volume = this.StageData.GlobalData.BGMVolume;
    }

    public override void UpdateData()
    {
      if (this.TimeMain == 50)
      {
        BaseEffect baseEffect = new BaseEffect(this.StageData, "woshixingtu", new PointF(385f, 240f), 4f, 0.0);
        baseEffect.AngleDegree = 90.0;
        baseEffect.Active = false;
        baseEffect.DestPoint = new PointF(320f, 240f);
        baseEffect.AngleWithDirection = false;
        baseEffect.Scale = 1f;
        baseEffect.TransparentValueF = 0.0f;
        baseEffect.TransparentVelocity = 5f;
      }
      else if (this.TimeMain == 100)
      {
        BaseEffect baseEffect = new BaseEffect(this.StageData, "woshibiaotihebaisi", new PointF(385f, 240f), 4f, 0.0);
        baseEffect.AngleDegree = 90.0;
        baseEffect.Active = false;
        baseEffect.DestPoint = new PointF(320f, 240f);
        baseEffect.AngleWithDirection = false;
        baseEffect.Scale = 1f;
        baseEffect.TransparentValueF = 0.0f;
        baseEffect.TransparentVelocity = 5f;
        EmitterTitleStarFall emitterTitleStarFall = new EmitterTitleStarFall(this.StageData);
        this.StageData.MenuGroupList.Add((BaseMenuGroup) new MenuGroup_Main(this.StageData));
      }
      else if (this.TimeMain == 130)
      {
        SelectBox selectBox = new SelectBox(this.StageData);
        selectBox.Velocity = 100f;
        selectBox.OriginalPosition = new PointF(0.0f, 500f);
        this.SelectFrame = (BaseEffect) selectBox;
      }
      if (this.StageData.MenuGroupList.Count > 0)
      {
        BaseMenuItem menuItem1 = this.StageData.MenuGroupList[this.StageData.MenuGroupList.Count - 1].MenuItemList[this.StageData.MenuGroupList[this.StageData.MenuGroupList.Count - 1].MenuSelectIndex];
        PointF pointF1;
        if (this.StageData.MenuGroupList.Count == 1 || this.StageData.MenuGroupList[this.StageData.MenuGroupList.Count - 1] is MenuOption)
        {
          StageDataPackage stageData = this.StageData;
          MyRandom ran = this.Ran;
          pointF1 = menuItem1.OriginalPosition;
          int minValue = (int) pointF1.X - 10;
          pointF1 = menuItem1.OriginalPosition;
          int maxValue = (int) pointF1.X + menuItem1.TxtureObject.PosRect.Width + 10;
          double num1 = (double) ran.Next(minValue, maxValue);
          pointF1 = menuItem1.OriginalPosition;
          double num2 = (double) pointF1.Y + 20.0;
          PointF Position = new PointF((float) num1, (float) num2);
          double num3 = (double) (this.StageData.Ran.Next(10, 20) / 10);
          double Direction = -1.0 * Math.PI / 2.0 - (double) this.StageData.Ran.Next(1, 5) / 10.0;
          Particle particle = new Particle(stageData, "Star", Position, (float) num3, Direction);
          particle.Active = true;
          particle.Scale = (float) this.StageData.Ran.Next(15, 40) / 100f;
          particle.LifeTime = 20;
        }
        if (this.SelectFrame != null)
        {
          BaseMenuItem menuItem2 = this.StageData.MenuGroupList[0].MenuItemList[this.StageData.MenuGroupList[0].MenuSelectIndex];
          pointF1 = this.SelectFrame.DestPoint;
          double y1 = (double) pointF1.Y;
          pointF1 = menuItem2.OriginalPosition;
          double y2 = (double) pointF1.Y;
          if ((double) Math.Abs((float) (y1 - y2 - 6.0)) >= 1.0)
          {
            BaseEffect selectFrame = this.SelectFrame;
            pointF1 = this.SelectFrame.DestPoint;
            double y3 = (double) pointF1.Y;
            pointF1 = menuItem2.OriginalPosition;
            double y4 = (double) pointF1.Y;
            double num = (double) Math.Abs((float) (y3 - y4 - 6.0)) / 5.0;
            selectFrame.Velocity = (float) num;
            if ((double) this.SelectFrame.Velocity > 16.0)
              this.SelectFrame.Velocity = 16f;
            else if ((double) this.SelectFrame.Velocity < 2.0)
              this.SelectFrame.Velocity = 2f;
          }
          BaseEffect selectFrame1 = this.SelectFrame;
          pointF1 = menuItem2.OriginalPosition;
          PointF pointF2 = new PointF(0.0f, (float) ((double) pointF1.Y + 6.0));
          selectFrame1.DestPoint = pointF2;
        }
      }
      base.UpdateData();
      if (0 <= this.TimeMain && this.TimeMain < 130)
      {
        this.BackgroundLight += 4;
        if (this.BackgroundLight <= (int) byte.MaxValue)
          return;
        this.BackgroundLight = (int) byte.MaxValue;
      }
      else
        this.BackgroundLight = (int) byte.MaxValue;
    }

    public override void Render()
    {
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      this.SpriteMain.Draw2D(this.TextureObjectDictionary["MenuBackground"], 0.625f, 0.0f, new PointF(320f, 240f), (int) byte.MaxValue);
      this.DXFont.DrawString(this.SpriteMain.sprite, "ver 1.00", 560, 460, (Color4) Color.Black);
      this.SpriteMain.End();
      this.Background3D.Show();
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      this.DeviceMain.SetRenderState(RenderState.SourceBlend, 5);
      this.DeviceMain.SetRenderState(RenderState.DestinationBlend, 2);
      this.Background2.Show(true);
      this.SpriteMain.End();
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      this.Background2.Show(false);
      this.EffectList.ForEach((Action<BaseEffect>) (x =>
      {
        if (x.Active)
          return;
        x.Show();
      }));
      this.StageData.MenuGroupList.ForEach((Action<BaseMenuGroup>) (x => x.Show()));
      this.SpriteMain.End();
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      this.DeviceMain.SetRenderState(RenderState.SourceBlend, 5);
      this.DeviceMain.SetRenderState(RenderState.DestinationBlend, 2);
      this.EffectList.ForEach((Action<BaseEffect>) (x =>
      {
        if (!x.Active)
          return;
        x.Show();
      }));
      this.SpriteMain.End();
      this.Particle3D.Show();
      if (this.TimeMain >= 126)
        return;
      this.GlobalData.ScreenTexMan.Begin();
      this.GlobalData.LastState.Render();
      this.GlobalData.ScreenTexMan.End();
      this.SpriteMain.Begin(SpriteFlags.AlphaBlend);
      this.GlobalData.SpriteMain.Draw2D(this.GlobalData.ScreenTexMan.RenderTexture, (PointF) new Point(0, 0), 0.0f, new PointF(0.0f, 0.0f), Color.FromArgb((int) byte.MaxValue - this.TimeMain * 2, Color.White));
      this.SpriteMain.End();
    }

    public override void BGM_ON()
    {
      this.StageData.ChangeBGM(".\\BGM\\OP.wav", 0, 0, (int) byte.MaxValue, 604611, 6047874);
    }

    public override void BGM_Resume()
    {
    }
  }
}
