using SlimDX.Direct3D9;
using SlimDX.DirectInput;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Shooting {
    public class Game_Main {
        private GlobalDataPackage GDP = new GlobalDataPackage();
        private Watch fpsTimer = new Watch();
        private MapKey mapkey = new MapKey();
        private bool fullWindow = false;
        private bool useDirectInput = false;
        private bool verticalSync = false;
        private bool antiAlias = false;
        private bool deviceLost = false;
        private bool singleThreaded = false;
        private int windowSize = 0;
        private int presentInterval = 1;
        private bool fixedFPS = false;
        private int delayTolerance = 10;
        public bool initSuccess = false;
        private bool firstFrame = true;
        private bool OnPause = false;
        private bool InitFlag = false;
        public RenderForm_Main Form_Main;
        private IGameState PresentState;
        private Dictionary<string,IGameState> GameStatesDictionary;
        private Thread LoadingThread;
        private KeyboardCapture KCapture;
        private JoystickCapture JCapture;
        private int bgmVolume;
        private int seVolume;
        private string fontType;

        public GlobalDataPackage GlobalData {
            get => GDP;
            set => GDP=value;
        }

        public SlimDX.Direct3D9.Device DeviceMain {
            set => GlobalData.DeviceMain=value;
            get => GlobalData.DeviceMain;
        }

        public Game_Main() {
            Form_Main=new RenderForm_Main();
            Form_Main.FormClosing+=new FormClosingEventHandler(Form_Main_FormClosing);
            Form_Main.Deactivate+=new EventHandler(Form_Main_Deactivate);
            Form_Main.Activated+=new EventHandler(Form_Main_Activated);
            MouseCtrl.DrawCursor(!fullWindow);
            Dpi.GetDpi();
            try {
                INI_RW iniRw = new INI_RW(".\\Setting.INI");
                if(iniRw.ExistINIFile()) {
                    fullWindow=iniRw.IniReadValue("DirectX","FullWindow")=="1";
                    antiAlias=iniRw.IniReadValue("DirectX","AntiAlias")=="1";
                    verticalSync=iniRw.IniReadValue("DirectX","VerticalSync")=="1";
                    useDirectInput=iniRw.IniReadValue("DirectInput","UseDirectInput")=="1";
                    GlobalData.Clear=iniRw.IniReadValue("Mode","Clear")=="yes";
                    singleThreaded=iniRw.IniReadValue("Mode","SingleThreaded")=="1";
                    fixedFPS=iniRw.IniReadValue("Mode","FixedFPS")=="1";
                    delayTolerance=Convert.ToInt16(iniRw.IniReadValue("Mode","DelayTolerance"));
                    windowSize=Convert.ToInt16(iniRw.IniReadValue("Mode","WindowSize"));
                    presentInterval=Convert.ToInt16(iniRw.IniReadValue("Mode","PresentInterval"));
                    mapkey.Left=iniRw.IniReadValue("Key","Left");
                    mapkey.Right=iniRw.IniReadValue("Key","Right");
                    mapkey.Up=iniRw.IniReadValue("Key","Up");
                    mapkey.Down=iniRw.IniReadValue("Key","Down");
                    mapkey.Slow=iniRw.IniReadValue("Key","Slow");
                    mapkey.Shoot=iniRw.IniReadValue("Key","Shoot");
                    mapkey.Bomb=iniRw.IniReadValue("Key","Bomb");
                    MapJoyStick.Skip=Convert.ToInt16(iniRw.IniReadValue("JoyStick","Skip"));
                    MapJoyStick.Pause=Convert.ToInt16(iniRw.IniReadValue("JoyStick","Pause"));
                    MapJoyStick.Slow=Convert.ToInt16(iniRw.IniReadValue("JoyStick","Slow"));
                    MapJoyStick.Shoot=Convert.ToInt16(iniRw.IniReadValue("JoyStick","Shoot"));
                    MapJoyStick.Bomb=Convert.ToInt16(iniRw.IniReadValue("JoyStick","Bomb"));
                    MapJoyStick.C=Convert.ToInt16(iniRw.IniReadValue("JoyStick","C"));
                    bgmVolume=Convert.ToInt16(iniRw.IniReadValue("Volume","BGMVolume"));
                    seVolume=(int)Convert.ToInt16(iniRw.IniReadValue("Volume","SEVolume"));
                    fontType=iniRw.IniReadValue("Game","FontType");
                }
            } catch {
                MessageBox.Show("读取配置文件失败","Setting Load Error");
            }
            if(windowSize==1) {
                Form_Main.ClientSize=new Size(800,600);
            } else if(windowSize==2) {
                Form_Main.ClientSize=new Size(1024,768);
            }
            if(!Direct3DInit()) {
                Application.ExitThread();
            } else {
                initSuccess=true;
                if(useDirectInput) {
                    KCapture=new KeyboardCapture(Form_Main.Handle);
                    JCapture=new JoystickCapture(Form_Main.Handle);
                } else {
                    Form_Main.KeyDown+=new KeyEventHandler(Form_Main_KeyDown);
                    Form_Main.KeyUp+=new KeyEventHandler(Form_Main_KeyUp);
                }
                PresentState=new GameState_SplashScreen(GlobalData);
                PresentState.Init();
                PresentState.BGM_ON();
                GlobalData.LoadResources1();
                LoadingThread=new Thread(new ThreadStart(AddState));
                LoadingThread.Start();
            }
            SourseForm sourseForm = new SourseForm();
            //    sourseForm.Show();
        }

        public bool Direct3DInit() {
            try {
                Direct3D direct3D = new Direct3D();
                AdapterInformation defaultAdapter = direct3D.Adapters.DefaultAdapter;
                CreateFlags createFlags = (direct3D.GetDeviceCaps(defaultAdapter.Adapter,SlimDX.Direct3D9.DeviceType.Hardware).DeviceCaps&DeviceCaps.HWTransformAndLight)!=DeviceCaps.HWTransformAndLight ? CreateFlags.SoftwareVertexProcessing : CreateFlags.HardwareVertexProcessing;
                GlobalData.presentParams=new PresentParameters() {
                    BackBufferWidth=640,
                    BackBufferHeight=480,
                    BackBufferFormat=defaultAdapter.CurrentDisplayMode.Format,
                    DeviceWindowHandle=Form_Main.Handle,
                    Windowed=!fullWindow,
                    PresentFlags=PresentFlags.DiscardDepthStencil,
                    SwapEffect=SwapEffect.Discard
                };
                if(presentInterval==1) {
                    GlobalData.presentParams.PresentationInterval=!verticalSync ? PresentInterval.Immediate : PresentInterval.Default;
                } else if(fullWindow&&verticalSync) {
                    if(presentInterval==2) {
                        GlobalData.presentParams.PresentationInterval=PresentInterval.Two;
                    } else if(presentInterval==3) {
                        GlobalData.presentParams.PresentationInterval=PresentInterval.Three;
                    }
                } else {
                    GlobalData.presentParams.PresentationInterval=PresentInterval.Immediate;
                }
                DeviceMain=new SlimDX.Direct3D9.Device(direct3D,defaultAdapter.Adapter,SlimDX.Direct3D9.DeviceType.Hardware,Form_Main.Handle,createFlags,new PresentParameters[1]{
                     GlobalData.presentParams
                });
                GlobalData.SpriteMain=new MySprite(DeviceMain);
                return true;
            } catch {
                MessageBox.Show("DirectX初始化失败","DirectX Initial Error");
                return false;
            }
        }

        public void AddState() {
            Watch watch = new Watch();
            watch.Start();
            GlobalData.BGMVolume=bgmVolume;
            GlobalData.SEVolume=seVolume;
            GlobalData.FontType=fontType;
            GlobalData.LoadResources();
            Dictionary<string,IGameState> dictionary1 = new Dictionary<string,IGameState> {
                { "SplashScreen",PresentState },
                { "Stage_test",new GameState_testStage(GlobalData) },
                { "St1",new GameState_SSS01(GlobalData) },
                { "St2",new GameState_SSS02(GlobalData) },
                { "St3",new GameState_SSS03(GlobalData) },
                { "St4",new GameState_SSS04(GlobalData) },
                { "St5",new GameState_SSS05(GlobalData) },
                { "St6",new GameState_SSS06(GlobalData) },
                { "StEx",new GameState_SSSEx(GlobalData) },
                { "Bs1",new GameState_Boss01(GlobalData) },
                { "Bs2",new GameState_Boss02(GlobalData) },
                { "Bs3",new GameState_Boss03(GlobalData) },
                { "Bs4",new GameState_Boss04(GlobalData) },
                { "Bs5",new GameState_Boss05(GlobalData) },
                { "Bs6",new GameState_Boss06(GlobalData) },
                { "All",new GameState_ED(GlobalData) },
                { "PauseMenu",new GameState_PauseMenu(GlobalData) },
                { "MainMenu",new GameState_MainMenu(GlobalData) },
                { "GameOverMenu",new GameState_GameOverMenu(GlobalData) },
                { "GameSetMenu",new GameState_GameSetMenu(GlobalData) },
                { "FinalReplaySaveMenu",new GameState_ReplaySaveMenu(GlobalData) }
            };
            Dictionary<string,IGameState> dictionary2 = dictionary1;
            GameState_SplashScreen2 stateSplashScreen2_1 = new GameState_SplashScreen2(GlobalData) {
                TxtureObject=GlobalData.TextureObjectDictionary["GAME_OVER"]
            };
            GameState_SplashScreen2 stateSplashScreen2_2 = stateSplashScreen2_1;
            dictionary2.Add("GAME_OVER",stateSplashScreen2_2);
            Dictionary<string,IGameState> dictionary3 = dictionary1;
            GameState_SplashScreen2 stateSplashScreen2_3 = new GameState_SplashScreen2(GlobalData) {
                TxtureObject=GlobalData.TextureObjectDictionary["此功能尚未开通"]
            };
            GameState_SplashScreen2 stateSplashScreen2_4 = stateSplashScreen2_3;
            dictionary3.Add("此功能尚未开通",stateSplashScreen2_4);
            dictionary1.Add("MusicLoading",new GameState_MusicLoading(GlobalData));
            GameStatesDictionary=dictionary1;
            GlobalData.Rep=new Replay();
            if(!singleThreaded) {
                watch.SleepTo(3000f);
            }
            if(antiAlias) {
                DeviceMain.SetRenderState(RenderState.MultisampleAntialias,true);
            }
            GlobalData.LastState=PresentState;
            InitFlag=true;
        }

        public void MainProcess() {
            if(firstFrame) {
                fpsTimer.Start();
                firstFrame=false;
            } else if(!fixedFPS||PresentState is GameState_SplashScreen) {
                fpsTimer.Start();
            } else {
                for(int index = 0;index<presentInterval;++index) {
                    fpsTimer.IncreaseOneFrame();
                }
            }
            if(InitFlag&&GlobalData.LoadingList.Count==0) {
                GlobalData.LoadModelDictionary();
                InitFlag=false;
                PresentState.StateSwitchData=new StateSwitchDataPackage() {
                    NextState="MainMenu",
                    NeedInit=true,
                    SDPswitch=new StageDataPackage(GlobalData)
                };
            }
            if(PresentState.StateSwitchData!=null) {
                StateSwitchDataPackage stateSwitchData = PresentState.StateSwitchData;
                if(stateSwitchData.NextState=="GameExit") {
                    Form_Main.Close();
                    return;
                }
                if(stateSwitchData.NextState!=null) {
                    if(stateSwitchData.NextState=="MainMenu"&&GlobalData.Rep!=null) {
                        GlobalData.Rep.CloseRpy();
                    }
                    GlobalData.BGM_Pause();
                    PresentState.StateSwitchData=null;
                    PresentState=GameStatesDictionary[stateSwitchData.NextState];
                    if(stateSwitchData.SDPswitch!=null) {
                        PresentState.StageData=stateSwitchData.SDPswitch;
                    }
                    if(stateSwitchData.NeedInit) {
                        PresentState.Init();
                        PresentState.BGM_ON();
                    } else {
                        GlobalData.BGM_Resume();
                    }
                }
            }
            if(useDirectInput) {
                KeyClass KClass1 = new KeyClass();
                KeyClass KClass2 = new KeyClass();
                try {
                    KCapture.UpdateInput(ref KClass1);
                } catch {
                }
                try {
                    JCapture.UpdateInput(ref KClass2);
                } catch {
                }
                KeyClass.KeyMix(ref GlobalData.KClass,KClass1,KClass2);
                if(KCapture.currentKeyboardState!=null) {
                    if(KCapture.currentKeyboardState.IsPressed(Key.LeftAlt)&&KCapture.currentKeyboardState.IsPressed(Key.F4)) {
                        Form_Main.Close();
                        return;
                    }
                    if(KCapture.currentKeyboardState.IsPressed(Key.F8)&&KCapture.lastKeyboardState.IsReleased(Key.F8)) {
                        WindowSwitch();
                    }
                    if(KCapture.currentKeyboardState.IsPressed(Key.P)&&KCapture.lastKeyboardState.IsReleased(Key.P)) {
                        ScreenShot();
                    }
                }
            }
            if(deviceLost) {
                Thread.Sleep(15);
                if(!(DeviceMain.TestCooperativeLevel()==SlimDX.Direct3D9.ResultCode.DeviceNotReset)) {
                    return;
                }
                GlobalData.OnResetDevice();
                deviceLost=false;
                firstFrame=true;
            } else {
                try {
                    if(OnPause&&PresentState is BaseStage) {
                        GlobalData.KClass.Key_ESC=true;
                    }
                    PresentState.UpdateData();
                    for(int index = 1;index<presentInterval;++index) {
                        if(PresentState.StateSwitchData!=null) {
                            if(PresentState.StateSwitchData.NextState==null) {
                                PresentState.UpdateData();
                            }
                        } else {
                            PresentState.UpdateData();
                        }
                    }
                    DeviceMain.Clear(ClearFlags.ZBuffer|ClearFlags.Target,Color.Black,1f,0);
                    DeviceMain.BeginScene();
                    PresentState.Render();
                    DeviceMain.EndScene();
                    DeviceMain.Present(Present.None);
                    if(GlobalData.BGM_Player.OnPause)
                        PresentState.BGM_Resume();
                } catch(Direct3D9Exception ex) {
                    if(ex.ResultCode==SlimDX.Direct3D9.ResultCode.DeviceLost) {
                        GlobalData.OnLostDevice();
                        deviceLost=true;
                    } else {
                        ErrorLog.SaveErrorLog(ex.Message,ex.ResultCode.Description);
                        MessageBox.Show(ex.Message);
                        Form_Main.Close();
                    }
                }
                if(verticalSync&&(presentInterval==1||fullWindow)) {
                    return;
                }
                float num1 = 16f*presentInterval-fpsTimer.GetDuration();
                if(num1>0.0) {
                    Thread.Sleep((int)num1);
                }
                do { } while(16.6200008392334*presentInterval-fpsTimer.GetDuration()>0.0);
                if(fixedFPS&&num1<-16.6666698455811*delayTolerance) {
                    for(int index = 0;index<-num1/16.6666698455811-delayTolerance;++index) {
                        fpsTimer.IncreaseOneFrame();
                    }
                }
            }
        }

        private void ToggleFullScreen() {
            fullWindow=!fullWindow;
            GlobalData.presentParams.Windowed=!fullWindow;
            if(fullWindow&&verticalSync) {
                if(presentInterval==2) {
                    GlobalData.presentParams.PresentationInterval=PresentInterval.Two;
                } else if(presentInterval==3) {
                    GlobalData.presentParams.PresentationInterval=PresentInterval.Three;
                }
            } else if(presentInterval==2||presentInterval==3) {
                GlobalData.presentParams.PresentationInterval=PresentInterval.Immediate;
            }
            GlobalData.OnLostDevice();
            GlobalData.OnResetDevice();
            MouseCtrl.DrawCursor(!fullWindow);
        }

        private void WindowSwitch() {
            if(fullWindow) {
                ToggleFullScreen();
                Form_Main.ClientSize=new Size(640,480);
            } else {
                switch(windowSize) {
                    case 0:
                        ++windowSize;
                        Form_Main.ClientSize=new Size(800,600);
                        break;
                    case 1:
                        ++windowSize;
                        Form_Main.ClientSize=new Size(1024,768);
                        break;
                    case 2:
                        windowSize=0;
                        ToggleFullScreen();
                        break;
                }
            }
        }

        private void Form_Main_Deactivate(object sender,EventArgs e) {
            if(!initSuccess) {
                return;
            }
            OnPause=true;
        }

        private void Form_Main_Activated(object sender,EventArgs e) {
            if(!initSuccess) {
                return;
            }
            OnPause=false;
            GlobalData.KClass.Key_ESC=false;
        }

        private void Form_Main_FormClosing(object sender,FormClosingEventArgs e) {
            if(LoadingThread!=null&&LoadingThread.IsAlive) {
                LoadingThread.Abort();
            }
            GlobalData.PData.SaveData();
            GlobalData.Dispose();
            if(!useDirectInput) {
                GlobalData.DeviceMain.Dispose();
            }
            if(GameStatesDictionary!=null) {
                foreach(IGameState gameState in GameStatesDictionary.Values)
                    gameState.Dispose();
            }
            try {
                INI_RW iniRw = new INI_RW(".\\Setting.INI");
                if(iniRw.ExistINIFile()) {
                    iniRw.IniWriteValue("Volume","BGMVolume",GlobalData.BGMVolume.ToString());
                    iniRw.IniWriteValue("Volume","SEVolume",GlobalData.SEVolume.ToString());
                }
            } catch {
            }
        }

        private void Form_Main_KeyDown(object sender,KeyEventArgs e) {
            GlobalData.KClass.ArrowLeft=e.KeyCode.ToString()==mapkey.Left||GlobalData.KClass.ArrowLeft;
            GlobalData.KClass.ArrowRight=e.KeyCode.ToString()==mapkey.Right||GlobalData.KClass.ArrowRight;
            GlobalData.KClass.ArrowUp=e.KeyCode.ToString()==mapkey.Up||GlobalData.KClass.ArrowUp;
            GlobalData.KClass.ArrowDown=e.KeyCode.ToString()==mapkey.Down||GlobalData.KClass.ArrowDown;
            GlobalData.KClass.Key_Shift=e.KeyCode.ToString()==mapkey.Slow||GlobalData.KClass.Key_Shift;
            GlobalData.KClass.Key_Z=e.KeyCode.ToString()==mapkey.Shoot||GlobalData.KClass.Key_Z;
            GlobalData.KClass.Key_X=e.KeyCode.ToString()==mapkey.Bomb||GlobalData.KClass.Key_X;
            switch(e.KeyCode.ToString()) {
                case "R":
                    GlobalData.KClass.Key_C=true;
                    break;
                case "ControlKey":
                    GlobalData.KClass.Key_Ctrl=true;
                    GlobalData.KClass.Key_plus=true;
                    break;
                case "ShiftKey":
                    GlobalData.KClass.Key_minus=true;
                    break;
                case "Return":
                    GlobalData.KClass.Key_Z=true;
                    break;
                case "Escape":
                    GlobalData.KClass.Key_ESC=true;
                    break;
                case "Oemplus":
                    GlobalData.KClass.Key_plus=true;
                    break;
                case "OemMinus":
                    GlobalData.KClass.Key_minus=true;
                    break;
                case "F8":
                    WindowSwitch();
                    break;
                case "P":
                    ScreenShot();
                    break;
            }
        }

        private void Form_Main_KeyUp(object sender,KeyEventArgs e) {
            GlobalData.KClass.ArrowLeft=!(e.KeyCode.ToString()==mapkey.Left)&&GlobalData.KClass.ArrowLeft;
            GlobalData.KClass.ArrowRight=!(e.KeyCode.ToString()==mapkey.Right)&&GlobalData.KClass.ArrowRight;
            GlobalData.KClass.ArrowUp=!(e.KeyCode.ToString()==mapkey.Up)&&GlobalData.KClass.ArrowUp;
            GlobalData.KClass.ArrowDown=!(e.KeyCode.ToString()==mapkey.Down)&&GlobalData.KClass.ArrowDown;
            GlobalData.KClass.Key_Shift=!(e.KeyCode.ToString()==mapkey.Slow)&&GlobalData.KClass.Key_Shift;
            GlobalData.KClass.Key_Z=!(e.KeyCode.ToString()==mapkey.Shoot)&&GlobalData.KClass.Key_Z;
            GlobalData.KClass.Key_X=!(e.KeyCode.ToString()==mapkey.Bomb)&&GlobalData.KClass.Key_X;
            switch(e.KeyCode.ToString()) {
                case "R":
                    GlobalData.KClass.Key_C=false;
                    break;
                case "ControlKey":
                    GlobalData.KClass.Key_Ctrl=false;
                    GlobalData.KClass.Key_plus=false;
                    break;
                case "ShiftKey":
                    GlobalData.KClass.Key_minus=false;
                    break;
                case "Return":
                    GlobalData.KClass.Key_Z=false;
                    break;
                case "Escape":
                    GlobalData.KClass.Key_ESC=false;
                    break;
                case "Oemplus":
                    GlobalData.KClass.Key_plus=false;
                    break;
                case "OemMinus":
                    GlobalData.KClass.Key_minus=false;
                    break;
            }
        }

        private void ScreenShot() {
            Surface backBuffer = DeviceMain.GetBackBuffer(0,0);
            int num = 0;
            while(File.Exists(string.Format(".\\ScreenShot\\screen{0:0000}.jpg",num))) {
                ++num;
            }
            Surface.ToFile(backBuffer,string.Format(".\\ScreenShot\\screen{0:0000}.jpg",num),ImageFileFormat.Jpg);
            if(GlobalData==null||GlobalData.SoundDictionary==null||!GlobalData.SoundDictionary.ContainsKey("se_shutter.wav")) {
                return;
            }
            GlobalData.SoundDictionary["se_shutter.wav"].Play();
        }
    }
}
