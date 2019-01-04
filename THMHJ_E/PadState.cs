// Decompiled with JetBrains decompiler
// Type: THMHJ.PadState
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System.Collections.Generic;

namespace THMHJ
{
  public class PadState
  {
    private static int JOY_BUTTON1 = 1;
    private static int JOY_BUTTON2 = 2;
    private static int JOY_BUTTON3 = 4;
    private static int JOY_BUTTON4 = 8;
    private static int JOY_BUTTON5 = 16;
    private static int JOY_BUTTON6 = 32;
    private static int JOY_BUTTON7 = 64;
    private static int JOY_BUTTON8 = 128;
    private static int JOY_BUTTON9 = 256;
    private static int JOY_BUTTON10 = 512;
    public static JOYBUTTONS[] JOY_BUTTON = new JOYBUTTONS[10]
    {
      JOYBUTTONS.B1,
      JOYBUTTONS.B2,
      JOYBUTTONS.B3,
      JOYBUTTONS.B4,
      JOYBUTTONS.B5,
      JOYBUTTONS.B6,
      JOYBUTTONS.B7,
      JOYBUTTONS.B8,
      JOYBUTTONS.B9,
      JOYBUTTONS.B10
    };
    private static JOYBUTTONS buttons;
    public static Dictionary<JOYKEYS, JOYBUTTONS> set;
    public static Dictionary<JOYKEYS, int> setf;

    public static void InitPad(IniFiles ini)
    {
      PadState.set = new Dictionary<JOYKEYS, JOYBUTTONS>();
      PadState.setf = new Dictionary<JOYKEYS, int>();
      PadState.set.Add(JOYKEYS.Up, JOYBUTTONS.UP);
      PadState.set.Add(JOYKEYS.Down, JOYBUTTONS.Down);
      PadState.set.Add(JOYKEYS.Left, JOYBUTTONS.Left);
      PadState.set.Add(JOYKEYS.Right, JOYBUTTONS.Right);
      int num1 = int.Parse(ini.ReadValue("Input", "Confirm"));
      if (num1 >= 1 && num1 <= 10)
      {
        PadState.set.Add(JOYKEYS.Confirm, PadState.JOY_BUTTON[num1 - 1]);
        PadState.setf.Add(JOYKEYS.Confirm, num1);
      }
      else
      {
        PadState.set.Add(JOYKEYS.Confirm, JOYBUTTONS.B1);
        PadState.setf.Add(JOYKEYS.Confirm, 1);
      }
      int num2 = int.Parse(ini.ReadValue("Input", "Special"));
      if (num2 >= 1 && num2 <= 10)
      {
        PadState.set.Add(JOYKEYS.Special, PadState.JOY_BUTTON[num2 - 1]);
        PadState.setf.Add(JOYKEYS.Special, num2);
      }
      else
      {
        PadState.set.Add(JOYKEYS.Special, JOYBUTTONS.B2);
        PadState.setf.Add(JOYKEYS.Special, 2);
      }
      int num3 = int.Parse(ini.ReadValue("Input", "Slow"));
      if (num3 >= 1 && num3 <= 10)
      {
        PadState.set.Add(JOYKEYS.Slow, PadState.JOY_BUTTON[num3 - 1]);
        PadState.setf.Add(JOYKEYS.Slow, num3);
      }
      else
      {
        PadState.set.Add(JOYKEYS.Slow, JOYBUTTONS.B3);
        PadState.setf.Add(JOYKEYS.Slow, 3);
      }
      int num4 = int.Parse(ini.ReadValue("Input", "Pause"));
      if (num4 >= 1 && num4 <= 10)
      {
        PadState.set.Add(JOYKEYS.Pause, PadState.JOY_BUTTON[num4 - 1]);
        PadState.setf.Add(JOYKEYS.Pause, num4);
      }
      else
      {
        PadState.set.Add(JOYKEYS.Pause, JOYBUTTONS.B4);
        PadState.setf.Add(JOYKEYS.Pause, 4);
      }
    }

    public static bool IsKeyDown(JOYKEYS key)
    {
      return (PadState.buttons & PadState.set[key]) == PadState.set[key];
    }

    public static bool IsKeyPressed(JOYKEYS key, JOYBUTTONS pre)
    {
      return (PadState.buttons & PadState.set[key]) == PadState.set[key] && (pre & PadState.set[key]) != PadState.set[key];
    }

    public static bool IsKeyUp(JOYKEYS key)
    {
      return !PadState.IsKeyDown(key);
    }

    public static JOYBUTTONS GetState(int ifjoy, int x, int y, int dwButtons)
    {
      PadState.buttons = JOYBUTTONS.None;
      if (ifjoy == 0)
      {
        if ((dwButtons & PadState.JOY_BUTTON1) == PadState.JOY_BUTTON1)
          PadState.buttons |= JOYBUTTONS.B1;
        if ((dwButtons & PadState.JOY_BUTTON2) == PadState.JOY_BUTTON2)
          PadState.buttons |= JOYBUTTONS.B2;
        if ((dwButtons & PadState.JOY_BUTTON3) == PadState.JOY_BUTTON3)
          PadState.buttons |= JOYBUTTONS.B3;
        if ((dwButtons & PadState.JOY_BUTTON4) == PadState.JOY_BUTTON4)
          PadState.buttons |= JOYBUTTONS.B4;
        if ((dwButtons & PadState.JOY_BUTTON5) == PadState.JOY_BUTTON5)
          PadState.buttons |= JOYBUTTONS.B5;
        if ((dwButtons & PadState.JOY_BUTTON6) == PadState.JOY_BUTTON6)
          PadState.buttons |= JOYBUTTONS.B6;
        if ((dwButtons & PadState.JOY_BUTTON7) == PadState.JOY_BUTTON7)
          PadState.buttons |= JOYBUTTONS.B7;
        if ((dwButtons & PadState.JOY_BUTTON8) == PadState.JOY_BUTTON8)
          PadState.buttons |= JOYBUTTONS.B8;
        if ((dwButtons & PadState.JOY_BUTTON9) == PadState.JOY_BUTTON9)
          PadState.buttons |= JOYBUTTONS.B9;
        if ((dwButtons & PadState.JOY_BUTTON10) == PadState.JOY_BUTTON10)
          PadState.buttons |= JOYBUTTONS.B10;
        int maxValue = (int) short.MaxValue;
        if (x - maxValue > 256)
          PadState.buttons |= JOYBUTTONS.Right;
        else if (maxValue - x > 256)
          PadState.buttons |= JOYBUTTONS.Left;
        if (y - maxValue > 256)
          PadState.buttons |= JOYBUTTONS.Down;
        else if (maxValue - y > 256)
          PadState.buttons |= JOYBUTTONS.UP;
      }
      return PadState.buttons;
    }

    public static JOYBUTTONS GetPressedKeys()
    {
      return PadState.buttons;
    }
  }
}
