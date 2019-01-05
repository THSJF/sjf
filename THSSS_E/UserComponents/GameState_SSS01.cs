// Decompiled with JetBrains decompiler
// Type: Shooting.GameState_SSS01
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using Shooting.Planes.Story;
using System;
using System.Drawing;
using System.IO;

namespace Shooting {
    internal class GameState_SSS01:BaseStage, IGameState {
        public GameState_SSS01(GlobalDataPackage GlobalData) : base(GlobalData) {
            StageName="St1";
        }
        public override void Drama() {
            base.Drama();
            int[] numArray = new int[3] { 3180,4000,6440 };
            if(TimeMain==1) {
                switch(StageData.Difficulty) {
                    case DifficultLevel.Hard:
                        MyPlane.EnchantmentCountNeeded=3;
                        break;
                    case DifficultLevel.Lunatic:
                        MyPlane.EnchantmentCountNeeded=4;
                        break;
                }
                TransitionIn transitionIn = new TransitionIn(StageData);
            }
            if(TimeMain==2) {
                if(StageData.C_History.PracticeLevel<1) {
                    StageData.C_History.PracticeLevel=1;
                }
                StageData.ChangeBGM(".\\BGM\\Stage01.wav",(testStartTime+60)*44100/60,0,0,0,0);
                Point DestPoint = new Point(BoundRect.Width,BoundRect.Height-16);
                MusicTitle musicTitle1 = new MusicTitle(StageData,"宁静夏夜的微风",DestPoint);
                MusicTitle musicTitle2 = musicTitle1;
                PointF pointF = new PointF(BoundRect.Width,BoundRect.Height+100);
                musicTitle2.OriginalPosition=pointF;
                musicTitle1.Scale=0.5f;
                Background3D.Envi=new EnvironmentSSS01(StageData);
                new BackgroundTransitionIn(StageData) {
                    Delay=200
                }.LifeTime=320;
                BackgroundGroupSSS01 backgroundGroupSsS01 = new BackgroundGroupSSS01(StageData);
                if(testStartTime>TimeMain) TimeMain=testStartTime;
                if(TimeMain<numArray[0]) {
                    string[] files;
                    switch(StageData.Difficulty) {
                        case DifficultLevel.Easy: files=Directory.GetFiles(".\\CS\\St01\\A\\E\\","*.mbg"); break;
                        case DifficultLevel.Normal: files=Directory.GetFiles(".\\CS\\St01\\A\\N\\","*.mbg"); break;
                        case DifficultLevel.Hard: files=Directory.GetFiles(".\\CS\\St01\\A\\H\\","*.mbg"); break;
                        case DifficultLevel.Lunatic: files=Directory.GetFiles(".\\CS\\St01\\A\\L\\","*.mbg"); break;
                        default: files=Directory.GetFiles(".\\CS\\St01\\A\\L\\","*.mbg"); break;
                    }
                    foreach(string FileName in files) {
                        new CSEmitterController(StageData,StageData.LoadCS(FileName)) {
                            OnRoad=true
                        }.Time=TimeMain+60;
                    }
                }
                PointF Position = new PointF(BoundRect.X+BoundRect.Width/2,BoundRect.Y+16);
                new TextTwinkle(StageData,StageData.Difficulty.ToString(),Position,0.0f,Math.PI/2.0) {
                    TwinkleColor=Color.Gray,Circle=10
                }.LifeTime=150;
            } else if(TimeMain==30) {
                new TextTwinkle(StageData,"ItemGetBorderLine",new PointF(BoundRect.X+BoundRect.Width/2,BoundRect.Y+130),0.0f,Math.PI/2.0).TwinkleColor=Color.OrangeRed;
                new TextTwinkle(StageData,"ItemGetBorderLine01",new PointF(BoundRect.X+BoundRect.Width/2-168,BoundRect.Y+130),0.0f,Math.PI/2.0).TwinkleColor=Color.OrangeRed;
                new TextTwinkle(StageData,"ItemGetBorderLine01",new PointF(BoundRect.X+BoundRect.Width/2+158,BoundRect.Y+130),0.0f,Math.PI/2.0).TwinkleColor=Color.OrangeRed;
            }
            if(TimeMain==numArray[0]) {
                StageData.RemoveBullets();
                Boss_Ami01 bossAmi01 = new Boss_Ami01(StageData);
                EmitterBossFire emitterBossFire = new EmitterBossFire(StageData,Boss.OriginalPosition,Color.FromArgb(40,byte.MaxValue,20));
                new MagicCircle(StageData,"MagicCircleSix").Scale=1.5f;
                Background3D.WarpEnabled=true;
                Background3D.WarpColorKey=0;
            } else if(TimeMain>numArray[1]&&Boss==null&&!RoadFlag) {
                RoadFlag=true;
                string[] files;
                switch(StageData.Difficulty) {
                    case DifficultLevel.Easy:
                        files=Directory.GetFiles(".\\CS\\St01\\B\\E\\","*.mbg");
                        break;
                    case DifficultLevel.Normal:
                        files=Directory.GetFiles(".\\CS\\St01\\B\\N\\","*.mbg");
                        break;
                    case DifficultLevel.Hard:
                        files=Directory.GetFiles(".\\CS\\St01\\B\\H\\","*.mbg");
                        break;
                    case DifficultLevel.Lunatic:
                        files=Directory.GetFiles(".\\CS\\St01\\B\\L\\","*.mbg");
                        break;
                    default:
                        files=Directory.GetFiles(".\\CS\\St01\\B\\L\\","*.mbg");
                        break;
                }
                foreach(string FileName in files) {
                    CS_Data CSData = new CS_Data(FileName);
                    CSData.String2Data(StageData);
                    new CSEmitterController(StageData,CSData) {
                        OnRoad=true
                    }.Time=TimeMain+60;
                }
            } else if(numArray[2]-130==TimeMain) {
                PointF OriginalPosition = new PointF(BoundRect.Width/2,150f);
                new BossStar(StageData,OriginalPosition).ColorType=6;
            } else {
                if(numArray[2]!=TimeMain) {
                    return;
                }
                StageData.RemoveBullets();
                Boss_Ami02 bossAmi02 = new Boss_Ami02(StageData);
                switch(MyPlane.Name) {
                    case "Aya":
                        Story_SSS01_01 storySsS0101 = new Story_SSS01_01(StageData);
                        break;
                    case "Reimu":
                        Story_SSS01_01A storySsS0101A = new Story_SSS01_01A(StageData);
                        break;
                    case "Marisa":
                        Story_SSS01_01B storySsS0101B = new Story_SSS01_01B(StageData);
                        break;
                    case "Sanae":
                        Story_SSS01_01C storySsS0101C = new Story_SSS01_01C(StageData);
                        break;
                    case "Koishi":
                        Story_SSS01_01D storySsS0101D = new Story_SSS01_01D(StageData);
                        break;
                    default:
                        Story_SSS01_01X storySsS0101X = new Story_SSS01_01X(StageData);
                        break;
                }
                Background3D.WarpEnabled=false;
                Background3D.WarpColorKey=0;
            }
        }

        public override void BGM_ON() {
        }
    }
}
