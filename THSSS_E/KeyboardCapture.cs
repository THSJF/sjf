// Decompiled with JetBrains decompiler
// Type: Shooting.KeyboardCapture
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using SlimDX.DirectInput;
using System;
using System.Windows.Forms;

namespace Shooting
{
  public class KeyboardCapture
  {
    private Keyboard keyboard;
    public KeyboardState currentKeyboardState;
    public KeyboardState lastKeyboardState;

    public KeyboardCapture(IntPtr handle)
    {
      SlimDX.DirectInput.DirectInput directInput = new SlimDX.DirectInput.DirectInput();
      CooperativeLevel flags = CooperativeLevel.NoWinKey | CooperativeLevel.Foreground | CooperativeLevel.Exclusive;
      try
      {
        this.keyboard = new Keyboard(directInput);
        this.keyboard.SetCooperativeLevel(handle, flags);
      }
      catch (DirectInputException ex)
      {
        int num = (int) MessageBox.Show("DirectInput Error " + ex.Message);
        return;
      }
      this.keyboard.Acquire();
    }

    public void UpdateInput(ref KeyClass KClass)
    {
      if (this.keyboard.Acquire().IsFailure)
        return;
      Result result = this.keyboard.Poll();
      if (result.IsFailure)
        return;
      this.lastKeyboardState = this.currentKeyboardState;
      this.currentKeyboardState = this.keyboard.GetCurrentState();
      result = Result.Last;
      if (result.IsFailure)
        return;
      KClass.ArrowLeft = this.currentKeyboardState.IsPressed(Key.LeftArrow);
      KClass.ArrowRight = this.currentKeyboardState.IsPressed(Key.RightArrow);
      KClass.ArrowUp = this.currentKeyboardState.IsPressed(Key.UpArrow);
      KClass.ArrowDown = this.currentKeyboardState.IsPressed(Key.DownArrow);
      KClass.Key_Shift = this.currentKeyboardState.IsPressed(Key.LeftShift);
      KClass.Key_Z = this.currentKeyboardState.IsPressed(Key.Z) | this.currentKeyboardState.IsPressed(Key.Return);
      KClass.Key_X = this.currentKeyboardState.IsPressed(Key.X);
      KClass.Key_C = this.currentKeyboardState.IsPressed(Key.R);
      KClass.Key_Ctrl = this.currentKeyboardState.IsPressed(Key.LeftControl);
      KClass.Key_ESC = this.currentKeyboardState.IsPressed(Key.Escape);
      KClass.Key_plus = this.currentKeyboardState.IsPressed(Key.Equals);
      KClass.Key_minus = this.currentKeyboardState.IsPressed(Key.Minus);
      KClass.Key_plus |= KClass.Key_Ctrl;
      KClass.Key_minus |= KClass.Key_Shift;
    }

    public void Dispose()
    {
      if (this.keyboard != null)
      {
        this.keyboard.Unacquire();
        this.keyboard.Dispose();
      }
      this.keyboard = (Keyboard) null;
    }
  }
}
