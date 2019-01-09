using SlimDX.Direct3D9;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Shooting {
    internal class GameState_MainMenu:BaseMenu, IGameState {
        private GameRegion GameRegion_Menu;
        private BaseEffect SelectFrame;

        private void InitializeComponent() {
            GameRegion_Menu=new GameRegion();
            SuspendLayout();
            GameRegion_Menu.AutoSize=true;
            GameRegion_Menu.BackColor=Color.Transparent;
            GameRegion_Menu.BackgroundImage=(Image)Shooting.Properties.Resources.Menu_Start;
            GameRegion_Menu.BackgroundImageLayout=ImageLayout.Center;
            GameRegion_Menu.Enabled=false;
            GameRegion_Menu.Location=new Point(59,138);
            GameRegion_Menu.Name="GameRegion_Menu";
            GameRegion_Menu.Size=new Size(103,28);
            GameRegion_Menu.TabIndex=0;
            GameRegion_Menu.Visible=false;
            BackgroundImage=Properties.Resources.菜单背景;
            Controls.Add(GameRegion_Menu);
            Enabled=false;
            Name=nameof(GameState_MainMenu);
            Size=new Size(640,480);
            ResumeLayout(false);
            PerformLayout();
        }

        public GameState_MainMenu(GlobalDataPackage GlobalData) : base(GlobalData) {
            InitializeComponent();
            DXFont=new SlimDX.Direct3D9.Font(DeviceMain,new System.Drawing.Font("Arial",12f,FontStyle.Bold|FontStyle.Italic));
        }

        public override void Init() {
            StageData.PData.CheckEnable();
            StageData.PData.SaveData();
            BackgroundLight=0;
            BGM_Player.Volume=StageData.GlobalData.BGMVolume;
        }

        public override void UpdateData() {
            if(TimeMain==50) {
                BaseEffect baseEffect = new BaseEffect(StageData,"woshixingtu",new PointF(385f,240f),4f,0.0);
                baseEffect.AngleDegree=90.0;
                baseEffect.Active=false;
                baseEffect.DestPoint=new PointF(320f,240f);
                baseEffect.AngleWithDirection=false;
                baseEffect.Scale=1f;
                baseEffect.TransparentValueF=0.0f;
                baseEffect.TransparentVelocity=5f;
            } else if(TimeMain==100) {
                BaseEffect baseEffect = new BaseEffect(StageData,"woshibiaotihebaisi",new PointF(385f,240f),4f,0.0);
                baseEffect.AngleDegree=90.0;
                baseEffect.Active=false;
                baseEffect.DestPoint=new PointF(320f,240f);
                baseEffect.AngleWithDirection=false;
                baseEffect.Scale=1f;
                baseEffect.TransparentValueF=0.0f;
                baseEffect.TransparentVelocity=5f;
                EmitterTitleStarFall emitterTitleStarFall = new EmitterTitleStarFall(StageData);
                StageData.MenuGroupList.Add(new MenuGroup_Main(StageData));
            } else if(TimeMain==130) {
                SelectBox selectBox = new SelectBox(StageData);
                selectBox.Velocity=100f;
                selectBox.OriginalPosition=new PointF(0.0f,500f);
                SelectFrame=selectBox;
            }
            if(StageData.MenuGroupList.Count>0) {
                BaseMenuItem menuItem1 = StageData.MenuGroupList[StageData.MenuGroupList.Count-1].MenuItemList[StageData.MenuGroupList[StageData.MenuGroupList.Count-1].MenuSelectIndex];
                PointF pointF1;
                if(StageData.MenuGroupList.Count==1||StageData.MenuGroupList[StageData.MenuGroupList.Count-1] is MenuOption) {
                    StageDataPackage stageData = StageData;
                    MyRandom ran = Ran;
                    pointF1=menuItem1.OriginalPosition;
                    int minValue = (int)pointF1.X-10;
                    pointF1=menuItem1.OriginalPosition;
                    int maxValue = (int)pointF1.X+menuItem1.TxtureObject.PosRect.Width+10;
                    double num1 = ran.Next(minValue,maxValue);
                    pointF1=menuItem1.OriginalPosition;
                    double num2 = pointF1.Y+20.0;
                    PointF Position = new PointF((float)num1,(float)num2);
                    double num3 = StageData.Ran.Next(10,20)/10;
                    double Direction = -1.0*Math.PI/2.0-StageData.Ran.Next(1,5)/10.0;
                    Particle particle = new Particle(stageData,"Star",Position,(float)num3,Direction);
                    particle.Active=true;
                    particle.Scale=StageData.Ran.Next(15,40)/100f;
                    particle.LifeTime=20;
                }
                if(SelectFrame!=null) {
                    BaseMenuItem menuItem2 = StageData.MenuGroupList[0].MenuItemList[StageData.MenuGroupList[0].MenuSelectIndex];
                    pointF1=SelectFrame.DestPoint;
                    double y1 = pointF1.Y;
                    pointF1=menuItem2.OriginalPosition;
                    double y2 = pointF1.Y;
                    if(Math.Abs((float)(y1-y2-6.0))>=1.0) {
                        BaseEffect selectFrame = SelectFrame;
                        pointF1=SelectFrame.DestPoint;
                        double y3 = pointF1.Y;
                        pointF1=menuItem2.OriginalPosition;
                        double y4 = pointF1.Y;
                        double num = Math.Abs((float)(y3-y4-6.0))/5.0;
                        selectFrame.Velocity=(float)num;
                        if(SelectFrame.Velocity>16.0) {
                            SelectFrame.Velocity=16f;
                        } else if(SelectFrame.Velocity<2.0) {
                            SelectFrame.Velocity=2f;
                        }
                    }
                    BaseEffect selectFrame1 = SelectFrame;
                    pointF1=menuItem2.OriginalPosition;
                    PointF pointF2 = new PointF(0.0f,(float)(pointF1.Y+6.0));
                    selectFrame1.DestPoint=pointF2;
                }
            }
            base.UpdateData();
            if(0<=TimeMain&&TimeMain<130) {
                BackgroundLight+=4;
                if(BackgroundLight<=byte.MaxValue) {
                    return;
                }
                BackgroundLight=byte.MaxValue;
            } else {
                BackgroundLight=byte.MaxValue;
            }
        }

        public override void Render() {
            SpriteMain.Begin(SpriteFlags.AlphaBlend);
            SpriteMain.Draw2D(TextureObjectDictionary["MenuBackground"],0.625f,0.0f,new PointF(320f,240f),byte.MaxValue);
            DXFont.DrawString(SpriteMain.sprite,"ver 1.00",560,460,Color.Black);
            SpriteMain.End();
            Background3D.Show();
            SpriteMain.Begin(SpriteFlags.AlphaBlend);
            DeviceMain.SetRenderState(RenderState.SourceBlend,5);
            DeviceMain.SetRenderState(RenderState.DestinationBlend,2);
            Background2.Show(true);
            SpriteMain.End();
            SpriteMain.Begin(SpriteFlags.AlphaBlend);
            Background2.Show(false);
            EffectList.ForEach(x => {
                if(x.Active) {
                    return;
                }
                x.Show();
            });
            StageData.MenuGroupList.ForEach(x => x.Show());
            SpriteMain.End();
            SpriteMain.Begin(SpriteFlags.AlphaBlend);
            DeviceMain.SetRenderState(RenderState.SourceBlend,5);
            DeviceMain.SetRenderState(RenderState.DestinationBlend,2);
            EffectList.ForEach(x => {
                if(!x.Active) {
                    return;
                }
                x.Show();
            });
            SpriteMain.End();
            Particle3D.Show();
            if(TimeMain>=126) {
                return;
            }
            GlobalData.ScreenTexMan.Begin();
            GlobalData.LastState.Render();
            GlobalData.ScreenTexMan.End();
            SpriteMain.Begin(SpriteFlags.AlphaBlend);
            GlobalData.SpriteMain.Draw2D(GlobalData.ScreenTexMan.RenderTexture,new Point(0,0),0.0f,new PointF(0.0f,0.0f),Color.FromArgb(byte.MaxValue-TimeMain*2,Color.White));
            SpriteMain.End();
        }

        public override void BGM_ON() {
            StageData.ChangeBGM(".\\BGM\\OP.wav",0,0,(int)byte.MaxValue,604611,6047874);
        }

        public override void BGM_Resume() {
        }
    }
}
