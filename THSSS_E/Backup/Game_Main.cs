// Decompiled with JetBrains decompiler
// Type: Shooting.Game_Main
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using SlimDX.Direct3D9;
using SlimDX.DirectInput;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Shooting
{
  public class Game_Main
  {
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
    private Dictionary<string, IGameState> GameStatesDictionary;
    private Thread LoadingThread;
    private KeyboardCapture KCapture;
    private JoystickCapture JCapture;
    private int bgmVolume;
    private int seVolume;
    private string fontType;

    public GlobalDataPackage GlobalData
    {
      get
      {
        return this.GDP;
      }
      set
      {
        this.GDP = value;
      }
    }

    public SlimDX.Direct3D9.Device DeviceMain
    {
      set
      {
        this.GlobalData.DeviceMain = value;
      }
      get
      {
        return this.GlobalData.DeviceMain;
      }
    }

    public Game_Main()
    {
      this.Form_Main = new RenderForm_Main();
      this.Form_Main.FormClosing += new FormClosingEventHandler(this.Form_Main_FormClosing);
      this.Form_Main.Deactivate += new EventHandler(this.Form_Main_Deactivate);
      this.Form_Main.Activated += new EventHandler(this.Form_Main_Activated);
      MouseCtrl.DrawCursor(!this.fullWindow);
      Dpi.GetDpi();
      try
      {
        INI_RW iniRw = new INI_RW(".\\Setting.INI");
        if (iniRw.ExistINIFile())
        {
          this.fullWindow = iniRw.IniReadValue("DirectX", "FullWindow") == "1";
          this.antiAlias = iniRw.IniReadValue("DirectX", "AntiAlias") == "1";
          this.verticalSync = iniRw.IniReadValue("DirectX", "VerticalSync") == "1";
          this.useDirectInput = iniRw.IniReadValue("DirectInput", "UseDirectInput") == "1";
          this.GlobalData.Clear = iniRw.IniReadValue("Mode", "Clear") == "yes";
          this.singleThreaded = iniRw.IniReadValue("Mode", "SingleThreaded") == "1";
          this.fixedFPS = iniRw.IniReadValue("Mode", "FixedFPS") == "1";
          this.delayTolerance = (int) Convert.ToInt16(iniRw.IniReadValue("Mode", "DelayTolerance"));
          this.windowSize = (int) Convert.ToInt16(iniRw.IniReadValue("Mode", "WindowSize"));
          this.presentInterval = (int) Convert.ToInt16(iniRw.IniReadValue("Mode", "PresentInterval"));
          this.mapkey.Left = iniRw.IniReadValue("Key", "Left");
          this.mapkey.Right = iniRw.IniReadValue("Key", "Right");
          this.mapkey.Up = iniRw.IniReadValue("Key", "Up");
          this.mapkey.Down = iniRw.IniReadValue("Key", "Down");
          this.mapkey.Slow = iniRw.IniReadValue("Key", "Slow");
          this.mapkey.Shoot = iniRw.IniReadValue("Key", "Shoot");
          this.mapkey.Bomb = iniRw.IniReadValue("Key", "Bomb");
          MapJoyStick.Skip = (int) Convert.ToInt16(iniRw.IniReadValue("JoyStick", "Skip"));
          MapJoyStick.Pause = (int) Convert.ToInt16(iniRw.IniReadValue("JoyStick", "Pause"));
          MapJoyStick.Slow = (int) Convert.ToInt16(iniRw.IniReadValue("JoyStick", "Slow"));
          MapJoyStick.Shoot = (int) Convert.ToInt16(iniRw.IniReadValue("JoyStick", "Shoot"));
          MapJoyStick.Bomb = (int) Convert.ToInt16(iniRw.IniReadValue("JoyStick", "Bomb"));
          MapJoyStick.C = (int) Convert.ToInt16(iniRw.IniReadValue("JoyStick", "C"));
          this.bgmVolume = (int) Convert.ToInt16(iniRw.IniReadValue("Volume", "BGMVolume"));
          this.seVolume = (int) Convert.ToInt16(iniRw.IniReadValue("Volume", "SEVolume"));
          this.fontType = iniRw.IniReadValue("Game", "FontType");
        }
      }
      catch
      {
        int num = (int) MessageBox.Show("读取配置文件失败", "Setting Load Error");
      }
      if (this.windowSize == 1)
        this.Form_Main.ClientSize = new Size(800, 600);
      else if (this.windowSize == 2)
        this.Form_Main.ClientSize = new Size(1024, 768);
      if (!this.Direct3DInit())
      {
        Application.ExitThread();
      }
      else
      {
        this.initSuccess = true;
        if (this.useDirectInput)
        {
          this.KCapture = new KeyboardCapture(this.Form_Main.Handle);
          this.JCapture = new JoystickCapture(this.Form_Main.Handle);
        }
        else
        {
          this.Form_Main.KeyDown += new KeyEventHandler(this.Form_Main_KeyDown);
          this.Form_Main.KeyUp += new KeyEventHandler(this.Form_Main_KeyUp);
        }
        this.PresentState = (IGameState) new GameState_SplashScreen(this.GlobalData);
        this.PresentState.Init();
        this.PresentState.BGM_ON();
        this.GlobalData.LoadResources1();
        this.LoadingThread = new Thread(new ThreadStart(this.AddState));
        this.LoadingThread.Start();
      }
    }

    public bool Direct3DInit()
    {
      try
      {
        Direct3D direct3D = new Direct3D();
        AdapterInformation defaultAdapter = direct3D.Adapters.DefaultAdapter;
        CreateFlags createFlags = (direct3D.GetDeviceCaps(defaultAdapter.Adapter, SlimDX.Direct3D9.DeviceType.Hardware).DeviceCaps & DeviceCaps.HWTransformAndLight) != DeviceCaps.HWTransformAndLight ? CreateFlags.SoftwareVertexProcessing : CreateFlags.HardwareVertexProcessing;
        this.GlobalData.presentParams = new PresentParameters()
        {
          BackBufferWidth = 640,
          BackBufferHeight = 480,
          BackBufferFormat = defaultAdapter.CurrentDisplayMode.Format,
          DeviceWindowHandle = this.Form_Main.Handle,
          Windowed = !this.fullWindow,
          PresentFlags = PresentFlags.DiscardDepthStencil,
          SwapEffect = SwapEffect.Discard
        };
        if (this.presentInterval == 1)
          this.GlobalData.presentParams.PresentationInterval = !this.verticalSync ? PresentInterval.Immediate : PresentInterval.Default;
        else if (this.fullWindow && this.verticalSync)
        {
          if (this.presentInterval == 2)
            this.GlobalData.presentParams.PresentationInterval = PresentInterval.Two;
          else if (this.presentInterval == 3)
            this.GlobalData.presentParams.PresentationInterval = PresentInterval.Three;
        }
        else
          this.GlobalData.presentParams.PresentationInterval = PresentInterval.Immediate;
        this.DeviceMain = new SlimDX.Direct3D9.Device(direct3D, defaultAdapter.Adapter, SlimDX.Direct3D9.DeviceType.Hardware, this.Form_Main.Handle, createFlags, new PresentParameters[1]
        {
          this.GlobalData.presentParams
        });
        this.GlobalData.SpriteMain = new MySprite(this.DeviceMain);
        return true;
      }
      catch
      {
        int num = (int) MessageBox.Show("DirectX初始化失败", "DirectX Initial Error");
        return false;
      }
    }

    public void AddState()
    {
      Watch watch = new Watch();
      watch.Start();
      this.GlobalData.BGMVolume = this.bgmVolume;
      this.GlobalData.SEVolume = this.seVolume;
      this.GlobalData.FontType = this.fontType;
      this.GlobalData.LoadResources();
      Dictionary<string, IGameState> dictionary1 = new Dictionary<string, IGameState>();
      dictionary1.Add("SplashScreen", this.PresentState);
      dictionary1.Add("Stage_test", (IGameState) new GameState_testStage(this.GlobalData));
      dictionary1.Add("St1", (IGameState) new GameState_SSS01(this.GlobalData));
      dictionary1.Add("St2", (IGameState) new GameState_SSS02(this.GlobalData));
      dictionary1.Add("St3", (IGameState) new GameState_SSS03(this.GlobalData));
      dictionary1.Add("St4", (IGameState) new GameState_SSS04(this.GlobalData));
      dictionary1.Add("St5", (IGameState) new GameState_SSS05(this.GlobalData));
      dictionary1.Add("St6", (IGameState) new GameState_SSS06(this.GlobalData));
      dictionary1.Add("StEx", (IGameState) new GameState_SSSEx(this.GlobalData));
      dictionary1.Add("Bs1", (IGameState) new GameState_Boss01(this.GlobalData));
      dictionary1.Add("Bs2", (IGameState) new GameState_Boss02(this.GlobalData));
      dictionary1.Add("Bs3", (IGameState) new GameState_Boss03(this.GlobalData));
      dictionary1.Add("Bs4", (IGameState) new GameState_Boss04(this.GlobalData));
      dictionary1.Add("Bs5", (IGameState) new GameState_Boss05(this.GlobalData));
      dictionary1.Add("Bs6", (IGameState) new GameState_Boss06(this.GlobalData));
      dictionary1.Add("All", (IGameState) new GameState_ED(this.GlobalData));
      dictionary1.Add("PauseMenu", (IGameState) new GameState_PauseMenu(this.GlobalData));
      dictionary1.Add("MainMenu", (IGameState) new GameState_MainMenu(this.GlobalData));
      dictionary1.Add("GameOverMenu", (IGameState) new GameState_GameOverMenu(this.GlobalData));
      dictionary1.Add("GameSetMenu", (IGameState) new GameState_GameSetMenu(this.GlobalData));
      dictionary1.Add("FinalReplaySaveMenu", (IGameState) new GameState_ReplaySaveMenu(this.GlobalData));
      Dictionary<string, IGameState> dictionary2 = dictionary1;
      GameState_SplashScreen2 stateSplashScreen2_1 = new GameState_SplashScreen2(this.GlobalData);
      stateSplashScreen2_1.TxtureObject = this.GlobalData.TextureObjectDictionary["GAME_OVER"];
      GameState_SplashScreen2 stateSplashScreen2_2 = stateSplashScreen2_1;
      dictionary2.Add("GAME_OVER", (IGameState) stateSplashScreen2_2);
      Dictionary<string, IGameState> dictionary3 = dictionary1;
      GameState_SplashScreen2 stateSplashScreen2_3 = new GameState_SplashScreen2(this.GlobalData);
      stateSplashScreen2_3.TxtureObject = this.GlobalData.TextureObjectDictionary["此功能尚未开通"];
      GameState_SplashScreen2 stateSplashScreen2_4 = stateSplashScreen2_3;
      dictionary3.Add("此功能尚未开通", (IGameState) stateSplashScreen2_4);
      dictionary1.Add("MusicLoading", (IGameState) new GameState_MusicLoading(this.GlobalData));
      this.GameStatesDictionary = dictionary1;
      this.GlobalData.Rep = new Replay();
      if (!this.singleThreaded)
        watch.SleepTo(3000f);
      if (this.antiAlias)
        this.DeviceMain.SetRenderState(RenderState.MultisampleAntialias, true);
      this.GlobalData.LastState = this.PresentState;
      this.InitFlag = true;
    }

    public void MainProcess()
    {
      if (this.firstFrame)
      {
        this.fpsTimer.Start();
        this.firstFrame = false;
      }
      else if (!this.fixedFPS || this.PresentState is GameState_SplashScreen)
      {
        this.fpsTimer.Start();
      }
      else
      {
        for (int index = 0; index < this.presentInterval; ++index)
          this.fpsTimer.IncreaseOneFrame();
      }
      if (this.InitFlag && this.GlobalData.LoadingList.Count == 0)
      {
        this.GlobalData.LoadModelDictionary();
        this.InitFlag = false;
        this.PresentState.StateSwitchData = new StateSwitchDataPackage()
        {
          NextState = "MainMenu",
          NeedInit = true,
          SDPswitch = new StageDataPackage(this.GlobalData)
        };
      }
      if (this.PresentState.StateSwitchData != null)
      {
        StateSwitchDataPackage stateSwitchData = this.PresentState.StateSwitchData;
        if (stateSwitchData.NextState == "GameExit")
        {
          this.Form_Main.Close();
          return;
        }
        if (stateSwitchData.NextState != null)
        {
          if (stateSwitchData.NextState == "MainMenu" && this.GlobalData.Rep != null)
            this.GlobalData.Rep.CloseRpy();
          this.GlobalData.BGM_Pause();
          this.PresentState.StateSwitchData = (StateSwitchDataPackage) null;
          this.PresentState = this.GameStatesDictionary[stateSwitchData.NextState];
          if (stateSwitchData.SDPswitch != null)
            this.PresentState.StageData = stateSwitchData.SDPswitch;
          if (stateSwitchData.NeedInit)
          {
            this.PresentState.Init();
            this.PresentState.BGM_ON();
          }
          else
            this.GlobalData.BGM_Resume();
        }
      }
      if (this.useDirectInput)
      {
        KeyClass KClass1 = new KeyClass();
        KeyClass KClass2 = new KeyClass();
        try
        {
          this.KCapture.UpdateInput(ref KClass1);
        }
        catch
        {
        }
        try
        {
          this.JCapture.UpdateInput(ref KClass2);
        }
        catch
        {
        }
        KeyClass.KeyMix(ref this.GlobalData.KClass, KClass1, KClass2);
        if (this.KCapture.currentKeyboardState != null)
        {
          if (this.KCapture.currentKeyboardState.IsPressed(Key.LeftAlt) && this.KCapture.currentKeyboardState.IsPressed(Key.F4))
          {
            this.Form_Main.Close();
            return;
          }
          if (this.KCapture.currentKeyboardState.IsPressed(Key.F8) && this.KCapture.lastKeyboardState.IsReleased(Key.F8))
            this.WindowSwitch();
          if (this.KCapture.currentKeyboardState.IsPressed(Key.P) && this.KCapture.lastKeyboardState.IsReleased(Key.P))
            this.ScreenShot();
        }
      }
      if (this.deviceLost)
      {
        Thread.Sleep(15);
        if (!(this.DeviceMain.TestCooperativeLevel() == SlimDX.Direct3D9.ResultCode.DeviceNotReset))
          return;
        this.GlobalData.OnResetDevice();
        this.deviceLost = false;
        this.firstFrame = true;
      }
      else
      {
        try
        {
          if (this.OnPause && this.PresentState is BaseStage)
            this.GlobalData.KClass.Key_ESC = true;
          this.PresentState.UpdateData();
          for (int index = 1; index < this.presentInterval; ++index)
          {
            if (this.PresentState.StateSwitchData != null)
            {
              if (this.PresentState.StateSwitchData.NextState == null)
                this.PresentState.UpdateData();
            }
            else
              this.PresentState.UpdateData();
          }
          this.DeviceMain.Clear(ClearFlags.ZBuffer | ClearFlags.Target, (Color4) Color.Black, 1f, 0);
          this.DeviceMain.BeginScene();
          this.PresentState.Render();
          this.DeviceMain.EndScene();
          this.DeviceMain.Present(Present.None);
          if (this.GlobalData.BGM_Player.OnPause)
            this.PresentState.BGM_Resume();
        }
        catch (Direct3D9Exception ex)
        {
          if (ex.ResultCode == SlimDX.Direct3D9.ResultCode.DeviceLost)
          {
            this.GlobalData.OnLostDevice();
            this.deviceLost = true;
          }
          else
          {
            ErrorLog.SaveErrorLog(ex.Message, ex.ResultCode.Description);
            int num = (int) MessageBox.Show(ex.Message);
            this.Form_Main.Close();
          }
        }
        if (this.verticalSync && (this.presentInterval == 1 || this.fullWindow))
          return;
        float num1 = 16f * (float) this.presentInterval - this.fpsTimer.GetDuration();
        if ((double) num1 > 0.0)
          Thread.Sleep((int) num1);
        do
          ;
        while (16.6200008392334 * (double) this.presentInterval - (double) this.fpsTimer.GetDuration() > 0.0);
        if (this.fixedFPS && (double) num1 < -16.6666698455811 * (double) this.delayTolerance)
        {
          for (int index = 0; (double) index < -(double) num1 / 16.6666698455811 - (double) this.delayTolerance; ++index)
            this.fpsTimer.IncreaseOneFrame();
        }
      }
    }

    private void ToggleFullScreen()
    {
      this.fullWindow = !this.fullWindow;
      this.GlobalData.presentParams.Windowed = !this.fullWindow;
      if (this.fullWindow && this.verticalSync)
      {
        if (this.presentInterval == 2)
          this.GlobalData.presentParams.PresentationInterval = PresentInterval.Two;
        else if (this.presentInterval == 3)
          this.GlobalData.presentParams.PresentationInterval = PresentInterval.Three;
      }
      else if (this.presentInterval == 2 || this.presentInterval == 3)
        this.GlobalData.presentParams.PresentationInterval = PresentInterval.Immediate;
      this.GlobalData.OnLostDevice();
      this.GlobalData.OnResetDevice();
      MouseCtrl.DrawCursor(!this.fullWindow);
    }

    private void WindowSwitch()
    {
      if (this.fullWindow)
      {
        this.ToggleFullScreen();
        this.Form_Main.ClientSize = new Size(640, 480);
      }
      else
      {
        switch (this.windowSize)
        {
          case 0:
            ++this.windowSize;
            this.Form_Main.ClientSize = new Size(800, 600);
            break;
          case 1:
            ++this.windowSize;
            this.Form_Main.ClientSize = new Size(1024, 768);
            break;
          case 2:
            this.windowSize = 0;
            this.ToggleFullScreen();
            break;
        }
      }
    }

    private void Form_Main_Deactivate(object sender, EventArgs e)
    {
      if (!this.initSuccess)
        return;
      this.OnPause = true;
    }

    private void Form_Main_Activated(object sender, EventArgs e)
    {
      if (!this.initSuccess)
        return;
      this.OnPause = false;
      this.GlobalData.KClass.Key_ESC = false;
    }

    private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (this.LoadingThread != null && this.LoadingThread.IsAlive)
        this.LoadingThread.Abort();
      this.GlobalData.PData.SaveData();
      this.GlobalData.Dispose();
      if (!this.useDirectInput)
        this.GlobalData.DeviceMain.Dispose();
      if (this.GameStatesDictionary != null)
      {
        foreach (IGameState gameState in this.GameStatesDictionary.Values)
          gameState.Dispose();
      }
      try
      {
        INI_RW iniRw = new INI_RW(".\\Setting.INI");
        if (iniRw.ExistINIFile())
        {
          iniRw.IniWriteValue("Volume", "BGMVolume", this.GlobalData.BGMVolume.ToString());
          iniRw.IniWriteValue("Volume", "SEVolume", this.GlobalData.SEVolume.ToString());
        }
      }
      catch
      {
      }
    }

    private void Form_Main_KeyDown(object sender, KeyEventArgs e)
    {
      this.GlobalData.KClass.ArrowLeft = e.KeyCode.ToString() == this.mapkey.Left || this.GlobalData.KClass.ArrowLeft;
      this.GlobalData.KClass.ArrowRight = e.KeyCode.ToString() == this.mapkey.Right || this.GlobalData.KClass.ArrowRight;
      this.GlobalData.KClass.ArrowUp = e.KeyCode.ToString() == this.mapkey.Up || this.GlobalData.KClass.ArrowUp;
      this.GlobalData.KClass.ArrowDown = e.KeyCode.ToString() == this.mapkey.Down || this.GlobalData.KClass.ArrowDown;
      this.GlobalData.KClass.Key_Shift = e.KeyCode.ToString() == this.mapkey.Slow || this.GlobalData.KClass.Key_Shift;
      this.GlobalData.KClass.Key_Z = e.KeyCode.ToString() == this.mapkey.Shoot || this.GlobalData.KClass.Key_Z;
      this.GlobalData.KClass.Key_X = e.KeyCode.ToString() == this.mapkey.Bomb || this.GlobalData.KClass.Key_X;
      switch (e.KeyCode.ToString())
      {
        case "R":
          this.GlobalData.KClass.Key_C = true;
          break;
        case "ControlKey":
          this.GlobalData.KClass.Key_Ctrl = true;
          this.GlobalData.KClass.Key_plus = true;
          break;
        case "ShiftKey":
          this.GlobalData.KClass.Key_minus = true;
          break;
        case "Return":
          this.GlobalData.KClass.Key_Z = true;
          break;
        case "Escape":
          this.GlobalData.KClass.Key_ESC = true;
          break;
        case "Oemplus":
          this.GlobalData.KClass.Key_plus = true;
          break;
        case "OemMinus":
          this.GlobalData.KClass.Key_minus = true;
          break;
        case "F8":
          this.WindowSwitch();
          break;
        case "P":
          this.ScreenShot();
          break;
      }
    }

    private void Form_Main_KeyUp(object sender, KeyEventArgs e)
    {
      this.GlobalData.KClass.ArrowLeft = !(e.KeyCode.ToString() == this.mapkey.Left) && this.GlobalData.KClass.ArrowLeft;
      this.GlobalData.KClass.ArrowRight = !(e.KeyCode.ToString() == this.mapkey.Right) && this.GlobalData.KClass.ArrowRight;
      this.GlobalData.KClass.ArrowUp = !(e.KeyCode.ToString() == this.mapkey.Up) && this.GlobalData.KClass.ArrowUp;
      this.GlobalData.KClass.ArrowDown = !(e.KeyCode.ToString() == this.mapkey.Down) && this.GlobalData.KClass.ArrowDown;
      this.GlobalData.KClass.Key_Shift = !(e.KeyCode.ToString() == this.mapkey.Slow) && this.GlobalData.KClass.Key_Shift;
      this.GlobalData.KClass.Key_Z = !(e.KeyCode.ToString() == this.mapkey.Shoot) && this.GlobalData.KClass.Key_Z;
      this.GlobalData.KClass.Key_X = !(e.KeyCode.ToString() == this.mapkey.Bomb) && this.GlobalData.KClass.Key_X;
      switch (e.KeyCode.ToString())
      {
        case "R":
          this.GlobalData.KClass.Key_C = false;
          break;
        case "ControlKey":
          this.GlobalData.KClass.Key_Ctrl = false;
          this.GlobalData.KClass.Key_plus = false;
          break;
        case "ShiftKey":
          this.GlobalData.KClass.Key_minus = false;
          break;
        case "Return":
          this.GlobalData.KClass.Key_Z = false;
          break;
        case "Escape":
          this.GlobalData.KClass.Key_ESC = false;
          break;
        case "Oemplus":
          this.GlobalData.KClass.Key_plus = false;
          break;
        case "OemMinus":
          this.GlobalData.KClass.Key_minus = false;
          break;
      }
    }

    private void ScreenShot()
    {
      Surface backBuffer = this.DeviceMain.GetBackBuffer(0, 0);
      int num = 0;
      while (File.Exists(string.Format(".\\ScreenShot\\screen{0:0000}.jpg", (object) num)))
        ++num;
      Surface.ToFile(backBuffer, string.Format(".\\ScreenShot\\screen{0:0000}.jpg", (object) num), ImageFileFormat.Jpg);
      if (this.GlobalData == null || this.GlobalData.SoundDictionary == null || !this.GlobalData.SoundDictionary.ContainsKey("se_shutter.wav"))
        return;
      this.GlobalData.SoundDictionary["se_shutter.wav"].Play();
    }
  }
}
